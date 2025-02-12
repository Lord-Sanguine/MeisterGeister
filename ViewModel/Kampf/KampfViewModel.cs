﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MeisterGeister.Model;
using MeisterGeister.ViewModel.AudioPlayer.Logic;
using MeisterGeister.ViewModel.Bodenplan;
using MeisterGeister.ViewModel.Bodenplan.Logic;
using MeisterGeister.ViewModel.Kampf.Logic;
using K = MeisterGeister.ViewModel.Kampf.Logic.Kampf;

namespace MeisterGeister.ViewModel.Kampf
{
    public class KampfViewModel : Base.ToolViewModelBase
    {
        public KampfViewModel() : this((k => new View.Kampf.GegnerWindow(k).ShowDialog()), View.General.ViewHelper.Confirm)
        {
        }

        public KampfViewModel(Action<K> showGegnerView, Func<string, string, bool> confirm)
            : base(confirm, View.General.ViewHelper.ShowError)
        {
            Global.CurrentKampf = this;
            this.showGegnerView = showGegnerView;
            _kampf = new K();
        }

        public K Kampf
        {
            get { return _kampf; }

            set
            {
                Set(ref _kampf, value);
            }
        }

        private string _labelInfo = null;
        public string LabelInfo
        {
            get { return _labelInfo; }
            set { Set(ref _labelInfo, value); }
        }

        public View.Bodenplan.BattlegroundView BodenplanView
        {
            get { return _bodenplanView; }

            set
            {
                _bodenplanView = value;
                Kampf.Bodenplan = value ?? null;
                OnChanged(nameof(BodenplanView));
            }
        }

        public BattlegroundViewModel BodenplanViewModel
        {
            get { return _bodenplanViewModel; }
            set { Set(ref _bodenplanViewModel, value); }
        }

        public List<GegnerBase> lstGegnerBase
        {
            get { return Global.ContextHeld.Liste<GegnerBase>().OrderBy(h => h.Name).ToList(); }
        }

        private GegnerBase _gegnerToAdd = null;
        public GegnerBase GegnerToAdd
        {
            get { return _gegnerToAdd; }
            set 
            { 
                Set(ref _gegnerToAdd, value);
                if (value != null)
                {
                    Gegner gegner = new Gegner(value);
                    var gegner_name = gegner.Name;
                    int j = 1;
                    while (_kampf.KämpferIList.Any(k => k.Kämpfer.Name == gegner_name))
                        gegner_name = String.Format("{0} ({1})", gegner.Name, ++j);
                    gegner.Name = gegner_name;
                    Global.ContextHeld.Insert<Gegner>(gegner);
                    _kampf.KämpferIList.Add(gegner, 2);

                    // zur Arena hinzufügen
                    if (Global.CurrentKampf.BodenplanViewModel != null)
                        Global.CurrentKampf.BodenplanViewModel.AddCreature(gegner);
                    GegnerToAdd = null;
                }
            }
        }

        public ICollection<IWesenPlaylist> WesenPlaylist
        {
            get
            {
                return ((SelectedKämpfer != null && SelectedKämpfer.Kämpfer != null)
                    && (SelectedKämpfer.Kämpfer is Held)) ?
                    new ObservableCollection<IWesenPlaylist>((SelectedKämpfer.Kämpfer as Held).Held_Audio_Playlist.AsEnumerable<IWesenPlaylist>()) :

                    ((SelectedKämpfer != null && SelectedKämpfer.Kämpfer != null)
                    && (SelectedKämpfer.Kämpfer is GegnerBase)) ?
                    new ObservableCollection<IWesenPlaylist>((SelectedKämpfer.Kämpfer as GegnerBase).GegnerBase_Audio_Playlist.AsEnumerable<IWesenPlaylist>()) :

                    ((SelectedKämpfer != null && SelectedKämpfer.Kämpfer != null)
                    && (SelectedKämpfer.Kämpfer is Gegner)) ?
                    new ObservableCollection<IWesenPlaylist>((SelectedKämpfer.Kämpfer as Gegner).GegnerBase.GegnerBase_Audio_Playlist.AsEnumerable<IWesenPlaylist>()) :

                    null;
            }

            set
            {
                Set(ref _wesenPlaylist, value);
            }
        }

        public ManöverInfo SelectedManöver
        {
            get { return _selectedManöver; }

            set
            {
                if (value != null)
                {
                    BodenplanViewModel.DoChangeModPositionSelbst = true;
                }

                Set(ref _selectedManöver, value);
                if (value != null)
                {
                    SelectedKämpfer = null;
                }
            }
        }

        public ManöverInfo SelectedManöverInfo
        {
            get { return _selectedManöverInfo; }

            set
            {
                Set(ref _selectedManöverInfo, value);
                SelectedKämpfer = value != null ? value.Manöver.Ausführender : null;
            }
        }

        public KämpferInfo SelectedKämpfer
        {
            get
            {
                return _selectedKämpfer;
            }

            set
            {
                if (value != null && _selectedKämpfer != null &&
                    value.Kämpfer.Name == _selectedKämpfer.Kämpfer.Name)
                {
                    return;
                }
                //if (value != null && !value.IstImKampf)
                //    Set(ref _selectedKämpfer, null);
                //else
                    Set(ref _selectedKämpfer, value);
                if (value != null)
                {
                    SelectedManöver = null;
                    if (BodenplanViewModel.SelectedObject == null ||
                        ((BodenplanViewModel.SelectedObject is IKämpfer) &&
                         (BodenplanViewModel.SelectedObject as IKämpfer).Name != value.Kämpfer.Name))
                    {
                        BodenplanViewModel.SelectedObject = BodenplanViewModel.BattlegroundObjects
                            .Where(t => t is IKämpfer)
                            .FirstOrDefault(tt => tt as IKämpfer == value.Kämpfer);
                    }
                }
            }
        }

        private K _kampf = null;
        private View.Bodenplan.BattlegroundView _bodenplanView;
        private BattlegroundViewModel _bodenplanViewModel = null;
        private ICollection<IWesenPlaylist> _wesenPlaylist = null;
        private ManöverInfo _selectedManöver;
        private ManöverInfo _selectedManöverInfo;
        private KämpferInfo _selectedKämpfer;

        #region // ---- COMMANDS ----

        private Base.CommandBase onCreatureLeft = null;
        public Base.CommandBase OnCreatureLeft
        {
            get
            {
                if (onCreatureLeft == null)
                    onCreatureLeft = new Base.CommandBase((o) => CreatureLeft(), null);
                return onCreatureLeft;
            }
        }
        private Base.CommandBase onCreatureRight = null;
        public Base.CommandBase OnCreatureRight
        {
            get
            {
                if (onCreatureRight == null)
                    onCreatureRight = new Base.CommandBase((o) => CreatureRight(), null);
                return onCreatureRight;
            }
        }
        private Base.CommandBase onCreatureUp = null;
        public Base.CommandBase OnCreatureUp
        {
            get
            {
                if (onCreatureUp == null)
                    onCreatureUp = new Base.CommandBase((o) => CreatureUp(), null);
                return onCreatureUp;
            }
        }
        private Base.CommandBase onCreatureDown = null;
        public Base.CommandBase OnCreatureDown
        {
            get
            {
                if (onCreatureDown == null)
                    onCreatureDown = new Base.CommandBase((o) => CreatureDown(), null);
                return onCreatureDown;
            }
        }

        public void CreatureLeft()
        {
            if (BodenplanViewModel?.SelectedObject != null && BodenplanViewModel.SelectedObject is BattlegroundCreature)
                BodenplanViewModel.SelectedObject.MoveObject(-100, 0, false);
        }
        public void CreatureRight()
        {
            if (BodenplanViewModel?.SelectedObject != null && BodenplanViewModel.SelectedObject is BattlegroundCreature)
                BodenplanViewModel.SelectedObject.MoveObject(100, 0, false);
        } 
        public void CreatureUp()
        {
            if (BodenplanViewModel?.SelectedObject != null && BodenplanViewModel.SelectedObject is BattlegroundCreature)
                BodenplanViewModel.SelectedObject.MoveObject(0, -100, false);
        }
        public void CreatureDown()
        {
            if (BodenplanViewModel?.SelectedObject != null && BodenplanViewModel.SelectedObject is BattlegroundCreature)
                BodenplanViewModel.SelectedObject.MoveObject(0, 100, false);
        }

        public Base.CommandBase OnAddHelden
        {
            get
            {
                if (onAddHelden == null)
                {
                    onAddHelden = new Base.CommandBase((o) => AddHelden(), null);
                }

                return onAddHelden;
            }
        }

        public Base.CommandBase OnDeleteKämpfer
        {
            get
            {
                if (onDeleteKämpfer == null)
                {
                    onDeleteKämpfer = new Base.CommandBase((o) => DeleteKämpfer(), null);
                }

                return onDeleteKämpfer;
            }
        }

        public Base.CommandBase OnDeleteAllKämpfer
        {
            get
            {
                if (onDeleteAllKämpfer == null)
                {
                    onDeleteAllKämpfer = new Base.CommandBase((o) => DeleteAllKämpfer(), null);
                }

                return onDeleteAllKämpfer;
            }
        }

        public Base.CommandBase OnEinfärbenKämpfer
        {
            get
            {
                if (onEinfärbenKämpfer == null)
                {
                    onEinfärbenKämpfer = new Base.CommandBase(EinfärbenKämpfer, null);
                }

                return onEinfärbenKämpfer;
            }
        }

        public Base.CommandBase OnShowGegnerView
        {
            get
            {
                if (onShowGegnerView == null)
                {
                    onShowGegnerView = new Base.CommandBase(ShowGegnerView, null);
                }

                return onShowGegnerView;
            }
        }

        public Base.CommandBase OnShowBodenplanView
        {
            get
            {
                if (onShowBodenplanView == null)
                {
                    onShowBodenplanView = new Base.CommandBase(ShowBodenplanView, null);
                }

                return onShowBodenplanView;
            }
        }

        public ObservableCollection<Xceed.Wpf.Toolkit.ColorItem> RecentColors
        {
            get { return recentColors; }

            set
            {
                recentColors = value;
                Farbmarkierungen.RecentColors = value;
                OnChanged(nameof(RecentColors));
            }
        }

        public ObservableCollection<Xceed.Wpf.Toolkit.ColorItem> StandardColors
        {
            get { return standardColors; }

            set
            {
                Farbmarkierungen.StandardColors = value;
                standardColors = value;
                OnChanged(nameof(StandardColors));
            }
        }

        public Action<K> ShowGegnerViewAction
        {
            get { return showGegnerView; }
            set { showGegnerView = value; }
        }

        public Action<KampfViewModel> ShowBodenplanViewAction
        {
            get { return showBodenplanView; }
            set { showBodenplanView = value; }
        }

        public Base.CommandBase OnNext
        {
            get
            {
                if (onNext == null)
                {
                    onNext = new Base.CommandBase(Next, null);
                }

                return onNext;
            }
        }

        public Base.CommandBase OnNextKampfrunde
        {
            get
            {
                if (onNextKampfrunde == null)
                {
                    onNextKampfrunde = new Base.CommandBase(NextKampfrunde, null);
                }

                return onNextKampfrunde;
            }
        }

        public Base.CommandBase OnNewKampf
        {
            get
            {
                if (onNewKampf == null)
                {
                    onNewKampf = new Base.CommandBase(NewKampf, null);
                }

                return onNewKampf;
            }
        }

        public void DeleteKämpfer()
        {
            if (SelectedKämpfer != null && Confirm("Kämpfer entfernen", $"Soll der Kämpfer {SelectedKämpfer.Kämpfer.Name} entfernt werden?"))
            {
                IKämpfer k = SelectedKämpfer.Kämpfer;

                Global.CurrentKampf.SelectedKämpfer = null;
                if (Global.CurrentKampf.BodenplanViewModel != null)
                {
                    BodenplanViewModel.SelectectedKämpferInfo = null;
                    BodenplanViewModel.SelectedObject = null;
                    Global.CurrentKampf.BodenplanViewModel.RemoveCreature(k);
                }

                Global.CurrentKampf.Kampf.KämpferIList.Remove(k);
            }
        }

        private Base.CommandBase onAddHelden = null;

        private Base.CommandBase onDeleteKämpfer = null;

        private Base.CommandBase onDeleteAllKämpfer = null;

        private Base.CommandBase onEinfärbenKämpfer = null;

        private Base.CommandBase onShowGegnerView = null;

        private Base.CommandBase onShowBodenplanView = null;

        private ObservableCollection<Xceed.Wpf.Toolkit.ColorItem> recentColors = Farbmarkierungen.RecentColors;

        private ObservableCollection<Xceed.Wpf.Toolkit.ColorItem> standardColors = Farbmarkierungen.StandardColors;

        private Action<K> showGegnerView;

        private Action<KampfViewModel> showBodenplanView;

        private Base.CommandBase onNext = null;

        private Base.CommandBase onNextKampfrunde = null;

        private Base.CommandBase onNewKampf = null;

        private void AddHelden() 
        {
            foreach (Held held in Global.ContextHeld.HeldenGruppeListe)
            {
                if (!Kampf.KämpferIList.Any(k => k.Kämpfer == held))
                {
                    Kampf.KämpferIList.Add(held);
                    held.ki = Global.CurrentKampf?.Kampf?.KämpferIList?.FirstOrDefault(t => t.Kämpfer == held);
                    BodenplanViewModel.AddCreature(Kampf.KämpferIList.Last().Kämpfer);
                }
            }
        }


        private void DeleteAllKämpfer()
        {
            if (Confirm("Liste leeren", "Sollen alle Kämpfer entfernt werden?"))
            {
                SelectedKämpfer = null;
                if (BodenplanViewModel != null)
                {
                    BodenplanViewModel.SelectectedKämpferInfo = null;
                    BodenplanViewModel.SelectedObject = null;
                    BodenplanViewModel.RemoveCreatureAll();
                }
                Kampf.KämpferIList.Clear();
           //     Kampf.KämpferIListImKampf.Clear();
            }
        }

        private void EinfärbenKämpfer(object obj)
        {
            if (SelectedKämpfer != null && SelectedKämpfer.Kämpfer != null && obj != null)
            {
                var color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(obj.ToString());
                SelectedKämpfer.Kämpfer.Farbmarkierung = color;
            }
        }

        private void ShowGegnerView(object obj)
        {
            //Gegner werden hinzugefügt und ebenfalls die BattlegroundCreatures
            showGegnerView?.Invoke(Kampf);
            
            BodenplanViewModel.CenterMeisterView(null);
        }

        private void ShowBodenplanView(object obj)
        {
            showBodenplanView?.Invoke(this);
        }

        private void Next(object obj)
        {
            Kampf.Next();
        }

        private void NextKampfrunde(object obj)
        {
            Kampf.NeueKampfrunde();
        }

        private void NewKampf(object obj)
        {
            Kampf.KampfNeuStarten();
            Global.CurrentKampf = this;
        }

        #endregion // ---- COMMANDS ----



    }

    public class MultiBooleanAndConverter : System.Windows.Data.IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (((value is bool) && (bool)value == false) || value == null)
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("BooleanAndConverter is a OneWay converter.");
        }
    }

    public class TrefferpunkteOptionsConverter : System.Windows.Data.IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TrefferpunkteOptions opt = TrefferpunkteOptions.Default;
            foreach (var o in values)
            {
                opt |= (TrefferpunkteOptions)o;
            }
            return opt;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            var opt = new List<TrefferpunkteOptions>();
            foreach (var o in Enum.GetValues(typeof(TrefferpunkteOptions)))
            {
                if (((TrefferpunkteOptions)value & (TrefferpunkteOptions)o) == (TrefferpunkteOptions)o)
                {
                    opt.Add((TrefferpunkteOptions)o);
                }
            }
            if (opt.Count == 0)
            {
                return new object[] { TrefferpunkteOptions.Default };
            }

            return opt.Select(a => (object)a).ToArray();
        }
    }
}
