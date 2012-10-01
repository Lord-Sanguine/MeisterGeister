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
using VM = MeisterGeister.ViewModel.Basar;
using MeisterGeister.View.Windows;
// Weitere Usings

namespace MeisterGeister.View.Basar
{
    /// <summary>
    /// Interaktionslogik für BasarView.xaml
    /// </summary>
    public partial class BasarView : UserControl
    {
        public BasarView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ruft das ViewModel des Views ab oder legt es fest und weist das ViewModel dem DataContext zu.
        /// </summary>
        public VM.BasarViewModel VM
        {
            get
            {
                if (DataContext == null || !(DataContext is VM.BasarViewModel))
                    return null;
                return DataContext as VM.BasarViewModel;
            }
            set { DataContext = value; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (VM != null)
                VM.Refresh();
        }

    }
}
