﻿using MeisterGeister.Logic.Einstellung;
using MeisterGeister.Logic.Extensions;
using MeisterGeister.Logic.General;
using MeisterGeister.Model;
using MeisterGeister.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;

namespace MeisterGeister.Logic.HeldenImport
{
    public class HeldenSoftwareOnlineService : ILongLivingProcess
    {
        private string _token;

        public event EventHandler<DoWorkEventArgs> DoWork;
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        public event EventHandler<RunWorkerCompletedEventArgs> RunWorkerCompleted;

        public HeldenSoftwareOnlineService(string token)
        {
            Token = token;
        }

        public string Token
        {
            get
            {
                if (_token == null)
                    _token = Einstellungen.HeldenSoftwareOnlineToken;
                return _token;
            }
            set
            {
                _token = value;
            }
        }

        public bool IsAvailable(bool showError)
        {
            try
            {
                return HeldenSoftwareOnlineHelper.Post(Token, new KeyValuePair<string, string>("action", "listhelden")) != null;
            }
            catch (Exception ex)
            {
                if (showError)
                {
                    string msg = "HeldenSoftware-Online ist aktuell nicht verfügbar.";
                    var errWin = new MsgWindow("Erreichbarkeit HeldenSoftware-Online", msg, ex);
                    errWin.ShowDialog();
                    errWin.Close();
                }
                return false;
            }
        }
        
        public HeldenListe GetHeldenListe()
        {
            var heldenListeXml = HeldenSoftwareOnlineHelper.Post(Token, new KeyValuePair<string, string>("action", "listhelden"));
            return heldenListeXml.XmlDeserializeFromString<HeldenListe>();
        }

        public string GetHeldXml(HeldElement heldElement)
        {
            if (heldElement == null)
                throw new ArgumentException("Der Parameter darf nicht null sein.", "heldElement");

            // Für eine reduzierte Ansicht auf den Helden wäre auch folgendes "format" möglich:
            // new KeyValuePair<string, string>("format", "datenxml")
            return HeldenSoftwareOnlineHelper.Post(Token,
                new KeyValuePair<string, string>("action", "returnheld"),
                new KeyValuePair<string, string>("format", "heldenxml"),
                new KeyValuePair<string, string>("heldenid", heldElement.HeldenId.ToString()));
        }

        public BackgroundWorkerQueueItem DownloadHeldenAsync()
        {
            var worker = new BackgroundWorkerQueueItem(this);
            worker.DoWork += (s, e) =>
            {
                var bw = (BackgroundWorkerQueueItem)s;
                ICollection<HeldenImportResult> helden = DownloadHelden(bw);
                e.Result = helden;
                OnDoWork(s, e);
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                Global.SetIsBusy(false);
                var result = (IEnumerable<HeldenImportResult>)e.Result;
                OnRunWorkerCompleted(s, e);
            };
            App.Queue.QueueWorker(worker);
            return worker;
        }

        private void OnRunWorkerCompleted(object s, RunWorkerCompletedEventArgs e)
        {
            if (RunWorkerCompleted != null)
                RunWorkerCompleted(s, e);
        }

        private void OnDoWork(object s, DoWorkEventArgs e)
        {
            if (DoWork != null)
                DoWork(s, e);
        }

        public ICollection<HeldenImportResult> DownloadHelden()
        {
            return DownloadHelden(null);
        }

        private ICollection<HeldenImportResult> DownloadHelden(BackgroundWorkerQueueItem bw)
        {

            ICollection<HeldenImportResult> helden = new List<HeldenImportResult>();
            HeldenListe heldenListe = GetHeldenListe();
            int amountHelden = heldenListe.Helden.Count;
            if(bw != null)
                bw.ReportProgress(0, "0 von " + amountHelden + " Helden verarbeitet.");

            for (int i = 1; i <= amountHelden; i++)
            {
                var held = heldenListe.Helden[i - 1];
                helden.Add(DownloadHeld(held));
                int progress = (i / amountHelden) * 100;

                if (bw != null)
                {
                    bw.ReportProgress(progress, i + " von " + amountHelden + " Helden verarbeitet.");
                }
                else
                {
                    OnProgressChanged(progress, held);
                }
            }
            return helden;
        }

        private void OnProgressChanged(int progress, object userState)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, new ProgressChangedEventArgs(progress, userState));
        }

        public HeldenImportResult DownloadHeld(HeldElement heldElement)
        {
            if (heldElement == null)
                throw new ArgumentException("Der Parameter darf nicht null sein.", "heldElement");

            Guid heldenGuid = HeldenSoftwareImporter.KeyToGuid(heldElement.HeldenKey);
            Held held = Global.ContextHeld.Liste<Held>().SingleOrDefault(hl => hl.HeldGUID == heldenGuid);

            string heldXml = GetHeldXml(heldElement);
            var xml = new XmlDocument();
            xml.LoadXml(heldXml);

            return HeldenSoftwareImporter.ImportHeldenSoftwareXml(xml, held != null ? heldenGuid : Guid.Empty);
        }
    }
}
