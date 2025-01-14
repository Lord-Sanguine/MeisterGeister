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
// Eigene Usings
using VM = MeisterGeister.ViewModel.ZooBot;
using MeisterGeister.Logic.General;
using MeisterGeister.Daten;
using MeisterGeister.View.Windows;
using MeisterGeister.Logic.Kalender;
using MeisterGeister.Model;
using MeisterGeister.View.General;

namespace MeisterGeister.View.ZooBot
{
    /// <summary>
    /// Interaktionslogik für ZooBotView.xaml
    /// </summary>
    public partial class ZooBotView : UserControl
    {
        /// <summary>
        /// Ruft das ViewModel des Views ab oder legt es fest und weist das ViewModel dem DataContext zu.
        /// </summary>
        public VM.ZooBotViewModel VM
        {
            get
            {
                if (DataContext == null || !(DataContext is VM.ZooBotViewModel))
                    return null;
                return DataContext as VM.ZooBotViewModel;
            }
            set { DataContext = value; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (VM != null)
                VM.Refresh();
            Reload();
        }


        public ZooBotView()
        {
            InitializeComponent();

            //VM = new VM.ZooBotViewModel();            
        }

        public void Reload()
        {
            _comboBoxHeld.ItemsSource = Global.ContextHeld.HeldenGruppeListe;
        }

        private void BtnBekanntePflanzenForm_Click(object sender, RoutedEventArgs e)
        {
            BekanntePflanzenView wndBekanntePflanzen = new BekanntePflanzenView();
            wndBekanntePflanzen.VM.ZooBotVM = VM;
            //wndBekanntePflanzen.VM.SelectedHeld = VM.SelectedHeld;
            wndBekanntePflanzen.ShowDialog();
        }

        private void BtnGebieteAuswahlView_Click(object sender, RoutedEventArgs e)
        {
            BekanntePflanzenView wndBekanntePflanzen = new BekanntePflanzenView();
            wndBekanntePflanzen.VM.ZooBotVM = VM;
            //wndBekanntePflanzen.VM.SelectedHeld = VM.SelectedHeld;
            wndBekanntePflanzen.ShowDialog();
        }

        private void KarteAusrufen_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && (sender is Button || sender is MenuItem))
            {
                object tag = null;
                if (sender is Button)
                    tag = ((Button)sender).Tag;
                else if (sender is MenuItem)
                    tag = ((MenuItem)sender).Tag;
                if (tag != null && tag is string)
                    (App.Current.MainWindow as View.MainView).StarteTab(tag.ToString());
            }
        }


        private void ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (VM.HeldenPos != new Point(Global.HeldenLon, Global.HeldenLat))
                VM.GebieteVonPos(null);
        }
        
        private void cmbxPflanze_DropDownOpened(object sender, EventArgs e)
        {
       //     VM.Kräuter_LandschaftGebieteSelected = mComboGebieteSelected.SelectedItems;
        }


        private void mComboGebieteSelected_MouseLeave(object sender, MouseEventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();            
            VM.LandschaftsGruppen.FindAll(t => t.IsChecked != false).ForEach(delegate(ViewModel.Karte.LandschaftsGruppeViewModel lgVM)
            {
                lgVM.Landschaften.FindAll(t => t.IsChecked).ForEach(delegate(ViewModel.Karte.LandschaftViewModel l)
                { if (!dic.Values.Contains(l.Landschaft)) dic.Add(l.Landschaft.Name, l.Landschaft); });
            });
            VM.Kräuter_LandschaftGebieteSelected = dic;            
        }
        
    }
}
