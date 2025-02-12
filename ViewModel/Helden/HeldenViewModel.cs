﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeisterGeister.Logic.Einstellung;
using MeisterGeister.Model.Extensions;

namespace MeisterGeister.ViewModel.Helden
{
    public class HeldenViewModel : Base.ToolViewModelBase
    {
        #region //---- COMMANDS ----

        #endregion

        #region //---- EIGENSCHAFTEN & FELDER ----

        // Selection
        public Model.Held SelectedHeld
        {
            get { return Global.SelectedHeld; }
            set
            {
                Global.SelectedHeld = value;
                OnChanged("SelectedHeld");
            }
        }

        [DependentProperty("SelectedHeld")]
        public bool SelectedHeldIsNotNull
        {
            get { return SelectedHeld != null; }
        }

        public bool ShowPflanzenwissen
        {
            get { return Einstellungen.PflanzenwissenIntegrieren; }
        }

        private System.Windows.Controls.TabItem _selectedTabItem = null;
        /// <summary>
        /// Der aktuell ausgewählte Tab.
        /// </summary>
        public System.Windows.Controls.TabItem SelectedTabItem
        {
            get { return _selectedTabItem; }
            set { _selectedTabItem = value; OnChanged("SelectedTabItem"); }
        }

        private int _selectedTabIndex = 0;
        public int SelectedTabIndex 
        {
            get { return _selectedTabIndex; }
            set { 
                _selectedTabIndex = value < -1 ? -1 : value;
                MeisterGeister.Logic.Einstellung.Einstellungen.SelectedHeldenTab = _selectedTabIndex;
                OnChanged("SelectedTabIndex");
            }
        }

        public bool IsReadOnly
        {
            get { return MeisterGeister.Logic.Einstellung.Einstellungen.IsReadOnly; }
            set 
            {
                MeisterGeister.Logic.Einstellung.Einstellungen.IsReadOnly = value;
                OnChanged("IsReadOnly");
            }
        }

        #endregion

        #region //---- KONSTRUKTOR ----

        public HeldenViewModel()
        {
            SelectedTabIndex = MeisterGeister.Logic.Einstellung.Einstellungen.SelectedHeldenTab;
        }

        #endregion

        #region //---- INSTANZMETHODEN ----

        public override void RegisterEvents()
        {
            base.RegisterEvents();
            Global.HeldSelectionChanged += SelectedHeldChanged;
            SelectedHeldChanged(this, new EventArgs());
        }
        public override void UnregisterEvents()
        {
            base.UnregisterEvents();
            Global.HeldSelectionChanged -= SelectedHeldChanged;
        }

        public void Init()
        {
            
        }

        public void NotifyRefresh()
        {
            OnChanged("SelectedHeld");
            OnChanged("SelectedHeldIsNotNull");

            // Prüfen, ob ein ausgeblendeter Tab ausgewält ist
            if (SelectedTabItem == null
                || SelectedTabItem.Visibility != System.Windows.Visibility.Visible)
            {
                if (SelectedTabIndex > 0)
                    SelectedTabIndex--;
            }
        }

        #endregion

        #region //---- EVENTS ----

        private void SelectedHeldChanged(object sender, EventArgs e)
        {
            NotifyRefresh();
        }

        #endregion

    }
}
