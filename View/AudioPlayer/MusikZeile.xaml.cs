﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//eigene 
using MeisterGeister.Model;
using VM = MeisterGeister.ViewModel.AudioPlayer.Logic;
using System.Globalization;

namespace MeisterGeister.View.AudioPlayer
{

    /// <summary>
    /// Interaktionslogik für MusikZeile.xaml
    /// </summary>
    public partial class MusikZeile : UserControl
    {
        /// <summary>
        /// Ruft das ViewModel des Views ab oder legt es fest und weist das ViewModel dem DataContext zu.
        /// </summary>
        public VM.MusikZeileVM VM
        {
            get
            {
                if (DataContext == null || !(DataContext is VM.MusikZeileVM))
                    return null;
                return DataContext as VM.MusikZeileVM;
            }
            set { DataContext = value; }
        }

        /// <summary>
        /// Eine Zusammenführung aller durchsuchbaren Felder.
        /// </summary>
        private string _suchtext = string.Empty;

        public MusikZeile()
        {
            InitializeComponent();
            VM = new VM.MusikZeileVM();

            _suchtext = tblkTitel.Text.ToLower() + tboxKategorie.Text.ToLower();
        }


        #region //---- INSTANZMETHODEN ----

        /// <summary>
        /// Prüft, ob 'suchWort' im Namen, der Kategorie oder in den Tags vorkommt.
        /// </summary>
        /// <param name="suchWort"></param>
        /// <returns></returns>
        public bool Contains(string suchWort)
        {
            _suchtext = tblkTitel.Text.ToLower() + tboxKategorie.Text.ToLower();
            return _suchtext.Contains(suchWort.ToLower());
        }

        /// <summary>
        /// Prüft, ob die 'suchWorte' im Namen, der Kategorie oder in den Tags vorkommt.
        /// Es wird dabei eine UND-Prüfung durchgeführt.
        /// </summary>
        /// <param name="suchWorte"></param>
        /// <returns></returns>
        public bool Contains(string[] suchWorte)
        {
            foreach (string wort in suchWorte)
            {
                if (!Contains(wort.ToLower()))
                    return false;
            }
            return true;
        }


        private void OnTitelNameUpdated(object sender, DataTransferEventArgs e)
        {
            _suchtext = tblkTitel.Text.ToLower() + tboxKategorie.Text.ToLower();
        }

        #endregion

        private void TitelListe_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            VM.Liste = VM.grpobj.ListTitelLaufend;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.HorizontalContentAlignment != System.Windows.HorizontalAlignment.Stretch)
                this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
        }

        private void slVolume_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 1)
            {
                ((Slider)sender).Value += ((((Slider)sender).Value < 98) ? 3 : ((100 - ((Slider)sender).Value)));
            }
            else
            { ((Slider)sender).Value += ((((Slider)sender).Value > 2) ? -3 : 0); }
        }
    }
}
