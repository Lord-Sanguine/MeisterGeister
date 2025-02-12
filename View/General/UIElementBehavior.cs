﻿using MeisterGeister.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MeisterGeister.View.General
{
    public static class UIElementBehavior
    {
        #region ViewModelBehavior
        public static ViewModelBase GetViewModel(UIElement obj)
        {
            return (ViewModelBase)obj.GetValue(ViewModelProperty);
        }
        public static void SetViewModel(UIElement obj, ViewModelBase value)
        {
            obj.SetValue(ViewModelProperty, value);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.RegisterAttached("ViewModel", typeof(ViewModelBase), typeof(UIElementBehavior), new UIPropertyMetadata(null, onViewModelChanged));


        private static void onViewModelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            //Wenn das Behavior auf einem UIElement aktiviert wurde müssen wir mitkriegen wann sich die Sichtbarkeit ändert
            UIElement element = (UIElement)obj;
            if(e.OldValue != null)
            {
                deactivateVM(element, (ViewModelBase)e.OldValue);
            }
            if(e.NewValue != null)
            {
                activateVM(element, (ViewModelBase)e.NewValue);
            }
        }

        private static void activateVM(UIElement element, ViewModelBase vm)
        {
            element.IsVisibleChanged += element_IsVisibleChanged;
            if (element.IsVisible)
                vm.RegisterEvents();
        }

        private static void deactivateVM(UIElement element, ViewModelBase vm)
        {
            if (element.IsVisible)
                vm.UnregisterEvents();
            element.IsVisibleChanged -= element_IsVisibleChanged;
        }

        private static void element_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Je nachdem ob das UIElement sichtbar ist oder nicht soll das ViewModel die Events an-/abmelden
            ViewModelBase vm = GetViewModel((UIElement)sender);
            if ((bool)e.NewValue) vm.RegisterEvents();
            else vm.UnregisterEvents();
        }

        #endregion

        #region IgnoreScrollingBehavior

        public static ScrollViewer GetScrollViewer(UIElement obj)
        {
            return (ScrollViewer)obj.GetValue(ScrollViewerProperty);
        }

        public static void SetScrollViewer(UIElement obj, ScrollViewer value)
        {
            obj.SetValue(ScrollViewerProperty, value);
        }

        public static readonly DependencyProperty ScrollViewerProperty =
            DependencyProperty.RegisterAttached("ScrollViewer", typeof(ScrollViewer), typeof(UIElementBehavior), new PropertyMetadata(null, onScrollViewerChanged));

        private static void onScrollViewerChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)obj;
            if (e.OldValue != null)
            {
                element.PreviewMouseWheel -= Element_PreviewMouseWheel;
            }
            if (e.NewValue != null)
            {
                element.PreviewMouseWheel += Element_PreviewMouseWheel;
            }
        }

        private static void Element_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            UIElement element = (UIElement)sender;
            ScrollViewer viewer = GetScrollViewer(element);
            viewer.ScrollToVerticalOffset(viewer.VerticalOffset - e.Delta/2.5);
            e.Handled = true;
        }

        #endregion
    }
}
