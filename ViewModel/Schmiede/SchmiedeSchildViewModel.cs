﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
//Eigene usings
using Base = MeisterGeister.ViewModel.Base;
using Model = MeisterGeister.Model;
using Service = MeisterGeister.Model.Service;

namespace MeisterGeister.ViewModel.Schmiede
{
    public class SchmiedeSchildViewModel : Base.ViewModelBase
    {

        #region //---- FELDER ----

        //Intern: Zeichenketten für DB-Abfragen
        const string UIDBUCKLER = "";
        const string UIDBUCKLERVOLLMETAL = "";
        // TODO FK: Buckler,.. über UIDS

        //Felder
        private int _probePunkte;
        private int _tawSchmied;
        private int _tawSchmiedMod;
        private int _probeDauerNApprox;
        
        //Listen + SelectedItems
        private Model.Schild _selectedSchild;
        private List<Model.Schild> _schildListe = new List<Model.Schild>();

        #endregion

        #region //---- EIGENSCHAFTEN ----

        //Felder        
        public int ProbePunkte
        {
            get { return _probePunkte; }
            private set
            {
                _probePunkte = value;
                OnChanged("ProbePunkte");
            }
        }

        public int ProbeDauerNApprox
        {
            get { return _probeDauerNApprox; }
            private set
            {
                _probeDauerNApprox = value;
                OnChanged("ProbeDauerNApprox");
            }
        }

        public int TawSchmied
        {
            get { return _tawSchmied; }
            set
            {
                if (value < 0) value = 0;
                if (value == _tawSchmied) return;
                _tawSchmied = value;
                OnChanged("TawSchmied");
                BerechneNicwinscheApproximation();
            }
        }

        public int TawSchmiedMod
        {
            get { return _tawSchmiedMod; }
            set
            {
                if (value < -7)
                    value = -7;
                else if (value > 7)
                    value = 7;
                if (value == _tawSchmiedMod) return;
                _tawSchmiedMod = value;
                OnChanged("TawSchmiedMod");
                BerechneNicwinscheApproximation();
            }
        }

        //Auswahl der Listen
        public Model.Schild SelectedSchild
        {
            get { return _selectedSchild; }
            set
            {
                if (value == null) return;
                _selectedSchild = value;
                OnChanged("SelectedSchild");
                BerechneSchild();
            }
        }

        //Listen
        public List<Model.Schild> SchildListe
        {
            get { return _schildListe; }
            set
            {
                _schildListe = value;
                OnChanged("SchildListe");
            }
        }

        //Commands

        #endregion

        #region //---- KONSTRUKTOR ----

        public SchmiedeSchildViewModel()
        {
            TawSchmied = 12;
        }

        #endregion

        #region //---- INSTANZMETHODEN ----

        public void LoadDaten()
        {
            // Schilde - keine Parierwaffen
            SchildListe.AddRange(Global.ContextInventar.SchildListe.Where(w => (w.Typ == "S" || w.Name == "Buckler" || w.Name == "Großer (Vollmetall-) Buckler") && !SchildListe.Contains(w)).OrderBy(w => w.Name));
            SchildListe = SchildListe;
            OnChanged("SchildListe");
        }

        private void BerechneNicwinscheApproximation()
        {
            int tapStern = TawSchmied - TawSchmiedMod;
            if (tapStern > TawSchmied) tapStern = TawSchmied;
            tapStern /= 2;
            if (tapStern < 1) tapStern = 1;
            tapStern = ProbePunkte * 2 / tapStern;
            ProbeDauerNApprox = (tapStern > 0) ? tapStern : 1;
        }

        private void BerechneSchild()
        {
            if (_selectedSchild == null) return;
            ProbePunkte = _selectedSchild.WMPA * 3;
            BerechneNicwinscheApproximation();
        }
        #endregion

        #region //---- EVENTS ----

        #endregion

    }
}
