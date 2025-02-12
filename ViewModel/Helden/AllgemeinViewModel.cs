﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//Eigene Usings
using M = MeisterGeister.Model;
using MeisterGeister.Logic.General;

namespace MeisterGeister.ViewModel.Helden {
    public class AllgemeinViewModel : Base.ViewModelBase {
        #region //FELDER
        //EasyTypes
        private bool hasChanges = false;
        //Selection
        private Model.Held selectedHeld = new M.Held();
        #endregion
        
        #region //EIGENSCHAFTEN
        
        //Selection
        public Model.Held SelectedHeld { get { return Global.SelectedHeld; } set { Global.SelectedHeld = value; OnChanged("SelectedHeld"); } }
        
        //Events
        public event EventHandler RefreshNotiz;

        private bool _isReadOnly = MeisterGeister.Logic.Einstellung.Einstellungen.IsReadOnly;
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        #endregion

        #region //KONSTRUKTOR

        public AllgemeinViewModel()
        {
            
        }

        public AllgemeinViewModel(Func<string> selectImage, Func<string> selectToken)
        {
            this.selectImage = selectImage;
            this.selectToken = selectToken;
        }

        #endregion

        #region //METHODEN

        private Base.CommandBase onOpenWikiHeldenbrief = null;
        public Base.CommandBase OnOpenWikiHeldenbrief
        {
            get
            {
                if (onOpenWikiHeldenbrief == null)
                    onOpenWikiHeldenbrief = new Base.CommandBase(OpenWikiHeldenbrief, null);
                return onOpenWikiHeldenbrief;
            }
        }

        public void OpenWikiHeldenbrief(object sender)
        {
            if (SelectedHeld != null)
                WikiAventurica.OpenBrowser("Spielerwelten:"
                    + SelectedHeld.Name.Replace(" ", "_"));
        }

        public override void RegisterEvents()
        {
            base.RegisterEvents();
            Global.HeldSelectionChanged += SelectedHeldChanged;
            Global.HeldSelectionChanging += SelectedHeldChanging;
            MeisterGeister.Logic.Einstellung.Einstellungen.IsReadOnlyChanged += IsReadOnlyChanged;
            SelectedHeldChanged(this, new EventArgs());
        }
        public override void UnregisterEvents()
        {
            base.UnregisterEvents();
            Global.HeldSelectionChanged -= SelectedHeldChanged;
            Global.HeldSelectionChanging -= SelectedHeldChanging;
            MeisterGeister.Logic.Einstellung.Einstellungen.IsReadOnlyChanged -= IsReadOnlyChanged;
        }

        private void OnSelectedHeldPropertyChanged(object sender, PropertyChangedEventArgs args) {
            if (new string[] { "Name", "BildLink", "Rasse", "Kultur", "Profession", "AktiveHeldengruppe" }.Contains(args.PropertyName))
                hasChanges = true;
        }

        #endregion

        #region Select Image/Token

        private Func<string> selectToken;

        private Base.CommandBase onSelectToken = null;
        public Base.CommandBase OnSelectToken
        {
            get
            {
                if (onSelectToken == null)
                    onSelectToken = new Base.CommandBase(SelectToken, null);
                return onSelectToken;
            }
        }

        private void SelectToken(object args)
        {
            if (SelectedHeld != null && selectToken != null)
            {
                string path = selectToken();
                if (path != null)
                    SelectedHeld.Token = path;
            }
        }

        private Func<string> selectImage;

        private Base.CommandBase onSelectImage = null;
        public Base.CommandBase OnSelectImage
        {
            get
            {
                if (onSelectImage == null)
                    onSelectImage = new Base.CommandBase(SelectImage, null);
                return onSelectImage;
            }
        }

        private void SelectImage(object args)
        {
            if (SelectedHeld != null && selectImage != null)
            {
                string path = selectImage();
                if (path != null)
                    SelectedHeld.Bild = path;
            }
        }

        #endregion

        #region //EVENTS
        
        private void IsReadOnlyChanged(object sender, EventArgs e)
        {
            _isReadOnly = MeisterGeister.Logic.Einstellung.Einstellungen.IsReadOnly;
            OnChanged("IsReadOnly");
        }

        //Event
        void SelectedHeldChanged(object sender, EventArgs args)
        {
            SelectedHeld = Global.SelectedHeld;
            if (SelectedHeld != null)
                SelectedHeld.PropertyChanged += OnSelectedHeldPropertyChanged;
            if (RefreshNotiz != null) {
                RefreshNotiz(this, new EventArgs());
            }
        }
        void SelectedHeldChanging(object sender, EventArgs args)
        {
            if (Global.SelectedHeld != null) {
                if (hasChanges)
                    Global.ContextHeld.Update<Model.Held>(SelectedHeld);
                hasChanges = false;
                Global.SelectedHeld.PropertyChanged -= OnSelectedHeldPropertyChanged;
            }
        }
        #endregion
        
    }
}
