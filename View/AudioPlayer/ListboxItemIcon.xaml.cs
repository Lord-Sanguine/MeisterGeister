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
using System.IO;
using MeisterGeister.Model;
using MeisterGeister.ViewModel.AudioPlayer;

namespace MeisterGeister.View.AudioPlayer
{
    /// <summary>
    /// Interaktionslogik für ListboxItemIcon.xaml
    /// </summary>
    public partial class ListboxItemIcon : ListBoxItem
    {
        public AudioPlayerViewModel PlayerVM;
        public bool _animateOnMouseEvent = true;

        public ListboxItemIcon()
        {
            InitializeComponent();
        }

        private void lbiEditorPlaylist_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (PlayerVM.rbEditorEditPlaylist) return;
            if (e.LeftButton == MouseButtonState.Pressed && !(this.Tag is ListboxItemIcon))
                this.Tag = e.GetPosition(null);
        }

        private void lbiEditorPlaylist_MouseMove(object sender, MouseEventArgs e)
        {
            if (PlayerVM.rbEditorEditPlaylist) return;
            if (this.Tag == null ||
                this.Tag is ListboxItemIcon ||
                ((sender) as StackPanel).Tag == null)
                return;

            Point mousePos = e.GetPosition(null);
            //Vector diff = (lbEditor.Tag is Point ? (Point)lbEditor.Tag : (Point){0;0}) - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed)// &&
            //(Mouse.GetPosition((AudioZeile)sender).X > 35 + 10 + ((AudioZeile)sender)._audioZeile.pbarTitel.ActualWidth))
            {

                Audio_Playlist aPlaylist = Global.ContextAudio.PlaylistListe.
                    FirstOrDefault(t => t.Audio_PlaylistGUID == (Guid)((sender) as StackPanel).Tag);
                //                VM.EditorListBoxItemListe[0].
                // Initialisiere drag & drop Operation
                DataObject dragData = new DataObject("meinListBoxItemIcon", aPlaylist);// lbi);// ListboxItemIcon);
                this.Tag = aPlaylist;
                DragDrop.DoDragDrop(sender as StackPanel, dragData, DragDropEffects.All); //ListboxItemIcon
                this.Tag = null;
            }
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!PlayerVM.rbEditorEditPlaylist && PlayerVM.AktKlangTheme != null)
            {
                Audio_Playlist aPlaylist = PlayerVM.AktKlangPlaylist;// ((lbEditorItem)(((StackPanel)obj).Parent)).APlaylist;
                PlayerVM.AktKlangTheme.Audio_Playlist.Add(aPlaylist);
                PlayerVM.SelectedEditorThemeItem = PlayerVM.SelectedEditorThemeItem;
            }
        }


        //public static Visual GetDescendantByType(Visual element, Type type)
        //{
        //    if (element == null)
        //        return null;

        //    if (element.GetType() == type)
        //        return element;

        //    Visual foundElement = null;
        //    if (element is FrameworkElement)
        //        (element as FrameworkElement).ApplyTemplate();

        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
        //    {
        //        Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
        //        foundElement = GetDescendantByType(visual, type);
        //        if (foundElement != null)
        //            break;

        //    }
        //    return foundElement;
        //}

        //private void btnLöschen_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Visibility = Visibility.Collapsed;
        //}
    }
}
