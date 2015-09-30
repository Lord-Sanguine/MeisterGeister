﻿using MeisterGeister.Model;
using MeisterGeister.Model.Service;
using MeisterGeister.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
// Eigene Usings
using MeisterGeister.ViewModel.AudioPlayer;
using VM = MeisterGeister.ViewModel.AudioPlayer.Logic;

namespace MeisterGeister.View.AudioPlayer
{
    /// <summary>
    /// Interaktionslogik für ListWesenAuswahlView.xaml
    /// </summary>
    public partial class ListWesenAuswahlView : Window
    {
        /// <summary>
        /// Ruft das ViewModel des Views ab oder legt es fest und weist das ViewModel dem DataContext zu.
        /// </summary>
        public VM.ListWesenAuswahlVM VM
        {
            get
            {
                if (DataContext == null || !(DataContext is VM.ListWesenAuswahlVM))
                    return null;
                return DataContext as VM.ListWesenAuswahlVM;
            }
            set
            {
                DataContext = value;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (VM != null)
                VM.Refresh();
            VM = new VM.ListWesenAuswahlVM();
        }

        public ListWesenAuswahlView(AudioPlayerViewModel aPlayerVM)
        {
            InitializeComponent();
            VM = new VM.ListWesenAuswahlVM();
            VM.AudioVM = aPlayerVM;
            VM.AktPlaylist = aPlayerVM.AktKlangPlaylist;
            VM.Init();

            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = Convert.ToDouble(Screen.PrimaryScreen.Bounds.Location.X + 20);
            Top = Convert.ToDouble(Screen.PrimaryScreen.Bounds.Location.Y + 20);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (((System.Windows.Controls.CheckBox)sender).Tag as Held != null)
            {
                Audio_HotkeyWesen aHotWesen = new Audio_HotkeyWesen();
                aHotWesen.Audio_PListGUID = VM.AktPlaylist.Audio_PlaylistGUID;
                aHotWesen.Held = ((System.Windows.Controls.CheckBox)sender).Tag as Held;
                aHotWesen.IstHeld = true;
                aHotWesen.HatPlaylist = true;
                Global.ContextAudioHotkeyWesen.Insert<Audio_HotkeyWesen>(aHotWesen);
            }
            else
                if (((System.Windows.Controls.CheckBox)sender).Tag as GegnerBase != null)
                {
                    Audio_HotkeyWesen aHotWesen = new Audio_HotkeyWesen();
                    aHotWesen.Audio_PListGUID = VM.AktPlaylist.Audio_PlaylistGUID;
                    aHotWesen.GegnerBase = ((System.Windows.Controls.CheckBox)sender).Tag as GegnerBase;
                    aHotWesen.IstGegner = true;
                    aHotWesen.HatPlaylist = true;
                    Global.ContextAudioHotkeyWesen.Insert<Audio_HotkeyWesen>(aHotWesen);
                }      
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (((System.Windows.Controls.CheckBox)sender).Tag as Held != null)
            {
                Audio_HotkeyWesen aHotWesen = Global.ContextAudioHotkeyWesen.PlaylistHotkeyHeldListe
                    .Where(t => t.HeldGUID == (((System.Windows.Controls.CheckBox)sender).Tag as Held).HeldGUID)
                    .FirstOrDefault(tt => tt.Audio_PListGUID == VM.AktPlaylist.Audio_PlaylistGUID);

                Global.ContextAudioHotkeyWesen.Delete(aHotWesen);
            }
            else
                if (((System.Windows.Controls.CheckBox)sender).Tag as GegnerBase != null)
                {
                    Audio_HotkeyWesen aHotWesen = Global.ContextAudioHotkeyWesen.PlaylistHotkeyGegnerListe
                        .Where(t => t.GegnerBaseGUID == (((System.Windows.Controls.CheckBox)sender).Tag as GegnerBase).GegnerBaseGUID)
                        .FirstOrDefault(tt => tt.Audio_PListGUID == VM.AktPlaylist.Audio_PlaylistGUID);

                    Global.ContextAudioHotkeyWesen.Delete(aHotWesen);
                }
        }
    }
}
