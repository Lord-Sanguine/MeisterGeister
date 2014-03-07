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
using MeisterGeister.ViewModel.Bodenplan;
using System.Windows.Controls.Primitives;
using MeisterGeister.ViewModel.Bodenplan.Logic;
using MeisterGeister.ViewModel.Kampf.Logic;

namespace MeisterGeister.View.Bodenplan
{
    /// <summary>
    /// Interaction logic for BattlegroundView.xaml
    /// </summary>
    public partial class BattlegroundView : UserControl
    {

        private double _x1, _y1, _x2, _y2;
        private double _xMovingOld, _yMovingOld;
        private bool _zoomChanged = false;

        public BattlegroundView()
        {
            InitializeComponent();
            VM = new BattlegroundViewModel();

            VM.TilePathData = BattlegroundUtilities.HexCellTile(100); //evtl in den setter rein?
            
            ArenaGrid.Cursor = Cursors.Arrow;
            AddPictureButtons();
        }

        public BattlegroundViewModel VM
        {
            get { return DataContext as BattlegroundViewModel; }
            set { DataContext = value; }
        }

        //Adds dynamicly created Picturebuttons for each picture in folder "Pictures".
        private void AddPictureButtons()
        {
            String[] picurls = Ressources.GetPictureUrls();
            for (int i = 0; i < picurls.Count(); i++)
            {
                String _buttonPrefix = "picbutton";
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(picurls[i], UriKind.Relative));
                String[] pathsplit = picurls[i].Split('\\');
                Button b = new Button() { Width = 50, Height = 50, Name = _buttonPrefix+i};
                //b.Content = brush;
                b.Background = brush;

                b.Click += (object sender, RoutedEventArgs e) =>
                    {
                        var vm = DataContext as BattlegroundViewModel;
                        if (vm != null)
                        {
                            int strlength = b.Name.Length-1;
                            int buttonNr = Convert.ToInt32(b.Name.Substring(_buttonPrefix.Length, b.Name.Length - _buttonPrefix.Length));
                            var newpic = vm.CreateImageObject(Ressources.Decoder(Ressources.GetFullApplicationPath() +"\\"+ Ressources.GetPictureUrls()[buttonNr]), new Point(_xMovingOld,_yMovingOld));
                            vm.UpdateCreatureLevelToTop();
                        }
                    };

                //Grid.SetRow(b,Convert.ToInt32(i/3));
                //Grid.SetColumn(b,i%3);
                //PictureButtonGrid.Children.Add(b);
                PictureButtonWrapPanel.Children.Add(b);
            }
            
        }

        private void Thumb_Drag(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb == null)
                return;

            var pathline = thumb.DataContext as PathLine;
            if (pathline == null)
                return;
        }

        private double _visualisationWidth = 100;
        public double VisualisationWidth
        {
            get { return _visualisationWidth; }
            private set { _visualisationWidth = value; }
        }

        private double _visualisationHeight = 100;
        public double VisualisationHeight
        {
            get { return _visualisationHeight; }
            private set { _visualisationHeight = value; }
        }

        //Zoom Funktion
        private void ArenaGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e) 
        {

        }

        private void ArenaGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                if (vm.SelectedObject != null) vm.SelectionChangedUpdateSliders();
                //handling different possibilities based on Objects (like Line1 Button) 
                //if (vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Held && x.IsSticked).Any())
                //{
                //    var currenthero = vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Held && x.IsSticked).First();
                //    currenthero.IsSticked = false;
                //    vm.CurrentlySelectedCreature =
                //        vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Held && x.IsSticked).Any() ?
                //            ((MeisterGeister.Model.Held)vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Held && x.IsSticked).First()).Kurzname
                //            : "";
                //}
                if (vm.BattlegroundObjects.Where(x => x is ViewModel.Kampf.Logic.Wesen && x.IsSticked).Any())
                {
                    var currentcreature = vm.BattlegroundObjects.Where(x => x is ViewModel.Kampf.Logic.Wesen && x.IsSticked).First();
                    currentcreature.IsSticked = false;
                    /*var kreatur = vm.BattlegroundObjects.Where(x => x.IsSticked).First();
                    if (kreatur is MeisterGeister.Model.Held) vm.CurrentlySelectedCreature = ((MeisterGeister.Model.Held)kreatur).Name;
                    else if (kreatur is MeisterGeister.Model.Gegner) vm.CurrentlySelectedCreature = ((MeisterGeister.Model.Gegner)kreatur).Name;
                    else vm.CurrentlySelectedCreature = "";*/

                    if (vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Held && x.IsSticked).Any())
                    {
                        vm.CurrentlySelectedCreature = ((MeisterGeister.Model.Held)vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Held && x.IsSticked).First()).Name;
                    }
                    else if (vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Gegner && x.IsSticked).Any())
                    {
                        vm.CurrentlySelectedCreature = ((MeisterGeister.Model.Gegner)vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Gegner && x.IsSticked).First()).Name;
                    }
                    else
                    {
                        vm.CurrentlySelectedCreature = "";
                    }
                    
                }
                else if (vm.CreateLine)
                {
                    _x1 = e.GetPosition(ArenaGrid).X;
                    _y1 = e.GetPosition(ArenaGrid).Y;
                    vm.CreatingNewLine = true;
                    var line = vm.CreateNewPathLine(_x1, _y1);
                    line.IsNew = true;
                    e.Handled = true;   
                }
                else if (vm.CreateFilledLine)
                {
                    _x1 = e.GetPosition(ArenaGrid).X;
                    _y1 = e.GetPosition(ArenaGrid).Y;
                    vm.CreatingNewFilledLine = true;
                    var line = vm.CreateNewFilledLine(_x1, _y1);
                    line.IsNew = true;
                    e.Handled = true;
                }
            }
        }

        private void ArenaGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                //handling different possibilities based on Objects (like Pathline or different BattlegroundBaseObject)
                if (vm.CreatingNewLine || vm.CreatingNewFilledLine)
                {
                    vm.FinishCurrentPathLine();
                    e.Handled = true;
                    vm.CreatingNewLine = false;
                    vm.CreatingNewFilledLine = false;
                    vm.UpdateCreatureLevelToTop();
                }
                else if (vm.SelectedObject != null)
                {
                    ArenaGrid.Cursor = Cursors.Arrow;
                }
            }
        }

        private void ArenaGrid_MouseMove(object sender, MouseEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                //cursor pixelchange?
                if (Math.Round(e.GetPosition(ArenaGrid).X, 0) != vm.CurrentMousePositionX ||
                    Math.Round(e.GetPosition(ArenaGrid).Y, 0) != vm.CurrentMousePositionY)
                {
                    vm.CurrentMousePositionX = e.GetPosition(ArenaGrid).X;
                    vm.CurrentMousePositionY = e.GetPosition(ArenaGrid).Y;
                    var listboxItem = ((DependencyObject)e.OriginalSource).FindAnchestor<ListBoxItem>();
                    //handling different possibilities based on Objects (like MoveObject or Hero, Create Line..)
                    var tempstick = vm.BattlegroundObjects.Where(x=>x is ViewModel.Kampf.Logic.Wesen && x.IsSticked).ToList();
                    foreach (var wesen in tempstick)
                    {
                        ((BattlegroundCreature)wesen).MoveObject(vm.CurrentMousePositionX, vm.CurrentMousePositionY,true);
                    }
                    if (vm.CreatingNewLine || vm.CreatingNewFilledLine)
                    {
                        _x2 = e.GetPosition(ArenaGrid).X;
                        _y2 = e.GetPosition(ArenaGrid).Y;
                        vm.MoveWhileDrawing(_x2, _y2, vm.LeftShiftPressed);
                    }
                    else if (e.LeftButton == MouseButtonState.Pressed && vm.SelectedObject != null && vm.IsMoving)
                    {
                        ArenaGrid.Cursor = Cursors.Hand;
                        vm.MoveObject(_xMovingOld, _yMovingOld, vm.CurrentMousePositionX, vm.CurrentMousePositionY);
                    }
                    _xMovingOld = vm.CurrentMousePositionX;
                    _yMovingOld = vm.CurrentMousePositionY;
                }
            }
        }

        private void ArenaScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                if (_zoomChanged)
                {
                    _zoomChanged = false;
                    vm.CurrentMousePositionX = Mouse.GetPosition(ArenaGrid).X;
                    vm.CurrentMousePositionY = Mouse.GetPosition(ArenaGrid).Y;
                }
            }
        }

        private void ArenaGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                vm.IsMoving = false;
            }
        }

        private void ArenaGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                var listboxItem = ((DependencyObject)e.OriginalSource).FindAnchestor<ListBoxItem>();
                if (listboxItem != null)
                {
                    BattlegroundBaseObject o = ArenaGrid.ItemContainerGenerator.ItemFromContainer(listboxItem) as BattlegroundBaseObject;
                    vm.SelectedObject = o; //TODO: Zugriff muss aus dem anderen Thread ausgeführt werden.
                    vm.IsMoving = true;
                    e.Handled = true;
                }
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                vm.LeftShiftPressed = (e.Key == Key.LeftShift);
                if (e.Key == Key.Delete && vm.SelectedObject != null) vm.Delete(); 
                if (vm.LeftShiftPressed && (vm.CreatingNewLine || vm.CreatingNewFilledLine))
                {
                    _x2 = _xMovingOld;
                    _y2 = _yMovingOld;
                    vm.MoveWhileDrawing(_x2, _y2, vm.LeftShiftPressed);
                }
            }
            if (e.Key == Key.Escape) UnselectObjects();
            if (e.Key == Key.D1) ToggleLinePathButton();
            if (e.Key == Key.D2) ToggleFilledLinePathButton();

        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
             var vm = DataContext as BattlegroundViewModel;
             if (vm != null)
             {
                 if (e.Key == Key.LeftShift) vm.LeftShiftPressed = !vm.LeftShiftPressed;
             }
        }

        //Set SelectedObject = null 
        private void UnselectObjects()
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null)
            {
                if (vm.SelectedObject != null) vm.SelectedObject = null;
                else
                {
                    vm.CreateLine = false;
                    vm.CreateFilledLine = false;
  
                }
            } 
        }

        private void ButtonEbeneHigher_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null) vm.ChangeEbeneHeight(true);
        }

        private void ButtonEbeneLower_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null) vm.ChangeEbeneHeight(false);
        }

        private void ToggleLinePathButton()
        {
           PathLineButton.IsChecked = (!Convert.ToBoolean(PathLineButton.IsChecked));
        }

        private void ToggleFilledLinePathButton()
        {
            FilledPathLineButton.IsChecked = (!Convert.ToBoolean(FilledPathLineButton.IsChecked));
        }

        private void ArenaGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if(vm!=null) vm.SelectionChangedUpdateSliders();
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonEbeneHigherMax_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null) vm.MoveSelectedObjectToTop(true);
        }

        private void ButtonEbeneLowerMin_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null) vm.MoveSelectedObjectToTop(false);
        }

        private void Button_SaveXML_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Battleground_"+System.DateTime.Now.ToShortDateString(); // Default file name
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var vm = DataContext as BattlegroundViewModel;
                if (vm != null) vm.SaveBattlegroundToXML(dlg.FileName);
            }
            
        }

        private void Button_LoadXML_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (.xml)|*.xml"; 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var vm = DataContext as BattlegroundViewModel;
                if (vm != null) vm.LoadBattlegroundFromXML(dlg.FileName);
            }
            AddPictureButtons(); //reload new pictures
            
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null) vm.ClearBattleground();
        }

        private void ButtonStickHeroes_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null && !vm.BattlegroundObjects.Where(x => x is MeisterGeister.Model.Gegner && x.IsSticked).Any()) vm.StickHeroes();
        }

        private void ButtonSticCreatues_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as BattlegroundViewModel;
            if (vm != null) vm.StickEnemies();
        }
    }
}

