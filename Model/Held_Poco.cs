//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeisterGeister.Model
{
    [DataContract(IsReference=true)]
    public partial class Held : INotifyPropertyChanged
    {
        #region ValidatePropertyChanging
    	protected event Extensions.ValidatePropertyChangingEventHandler ValidatePropertyChanging;
    
    	protected void OnValidatePropertyChanging(object currentValue, object newValue, [CallerMemberName] string propertyName = null)
    	{
    		if(ValidatePropertyChanging != null)
    		{
    			ValidatePropertyChanging(this, propertyName, currentValue, newValue);
    		}
    	}

        #endregion

        #region Primitive Properties
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Name
        {
            get { return _name; }
            set
    		{ 
    			Set(ref _name, value);
    		}
    
        }
        private string _name;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> MU
        {
            get { return _mU; }
            set
    		{ 
    			Set(ref _mU, value);
    		}
    
        }
        private Nullable<int> _mU;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> KL
        {
            get { return _kL; }
            set
    		{ 
    			Set(ref _kL, value);
    		}
    
        }
        private Nullable<int> _kL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> IN
        {
            get { return _iN; }
            set
    		{ 
    			Set(ref _iN, value);
    		}
    
        }
        private Nullable<int> _iN;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> CH
        {
            get { return _cH; }
            set
    		{ 
    			Set(ref _cH, value);
    		}
    
        }
        private Nullable<int> _cH;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> FF
        {
            get { return _fF; }
            set
    		{ 
    			Set(ref _fF, value);
    		}
    
        }
        private Nullable<int> _fF;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> GE
        {
            get { return _gE; }
            set
    		{ 
    			Set(ref _gE, value);
    		}
    
        }
        private Nullable<int> _gE;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> KO
        {
            get { return _kO; }
            set
    		{ 
    			Set(ref _kO, value);
    		}
    
        }
        private Nullable<int> _kO;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> KK
        {
            get { return _kK; }
            set
    		{ 
    			Set(ref _kK, value);
    		}
    
        }
        private Nullable<int> _kK;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> BE
        {
            get { return _bE; }
            set
    		{ 
    			Set(ref _bE, value);
    		}
    
        }
        private Nullable<int> _bE;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> INI_Mod
        {
            get { return _iNI_Mod; }
            set
    		{ 
    			Set(ref _iNI_Mod, value);
    		}
    
        }
        private Nullable<int> _iNI_Mod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> LE_Mod
        {
            get { return _lE_Mod; }
            set
    		{ 
    			Set(ref _lE_Mod, value);
    		}
    
        }
        private Nullable<int> _lE_Mod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> LE_Aktuell
        {
            get { return _lE_Aktuell; }
            set
    		{ 
    			Set(ref _lE_Aktuell, value);
    		}
    
        }
        private Nullable<int> _lE_Aktuell;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> AU_Mod
        {
            get { return _aU_Mod; }
            set
    		{ 
    			Set(ref _aU_Mod, value);
    		}
    
        }
        private Nullable<int> _aU_Mod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> AU_Aktuell
        {
            get { return _aU_Aktuell; }
            set
    		{ 
    			Set(ref _aU_Aktuell, value);
    		}
    
        }
        private Nullable<int> _aU_Aktuell;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> AE_Mod
        {
            get { return _aE_Mod; }
            set
    		{ 
    			Set(ref _aE_Mod, value);
    		}
    
        }
        private Nullable<int> _aE_Mod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> AE_Aktuell
        {
            get { return _aE_Aktuell; }
            set
    		{ 
    			Set(ref _aE_Aktuell, value);
    		}
    
        }
        private Nullable<int> _aE_Aktuell;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> KE_Mod
        {
            get { return _kE_Mod; }
            set
    		{ 
    			Set(ref _kE_Mod, value);
    		}
    
        }
        private Nullable<int> _kE_Mod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> KE_Aktuell
        {
            get { return _kE_Aktuell; }
            set
    		{ 
    			Set(ref _kE_Aktuell, value);
    		}
    
        }
        private Nullable<int> _kE_Aktuell;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> MR_Mod
        {
            get { return _mR_Mod; }
            set
    		{ 
    			Set(ref _mR_Mod, value);
    		}
    
        }
        private Nullable<int> _mR_Mod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Kampfwerte
        {
            get { return _kampfwerte; }
            set
    		{ 
    			Set(ref _kampfwerte, value);
    		}
    
        }
        private string _kampfwerte;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> Wunden
        {
            get { return _wunden; }
            set
    		{ 
    			Set(ref _wunden, value);
    		}
    
        }
        private Nullable<int> _wunden;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<bool> AktiveHeldengruppe
        {
            get { return _aktiveHeldengruppe; }
            set
    		{ 
    			Set(ref _aktiveHeldengruppe, value);
    		}
    
        }
        private Nullable<bool> _aktiveHeldengruppe;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<bool> Proben
        {
            get { return _proben; }
            set
    		{ 
    			Set(ref _proben, value);
    		}
    
        }
        private Nullable<bool> _proben;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Rasse
        {
            get { return _rasse; }
            set
    		{ 
    			Set(ref _rasse, value);
    		}
    
        }
        private string _rasse;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Kultur
        {
            get { return _kultur; }
            set
    		{ 
    			Set(ref _kultur, value);
    		}
    
        }
        private string _kultur;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Profession
        {
            get { return _profession; }
            set
    		{ 
    			Set(ref _profession, value);
    		}
    
        }
        private string _profession;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Notizen
        {
            get { return _notizen; }
            set
    		{ 
    			Set(ref _notizen, value);
    		}
    
        }
        private string _notizen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenKopf
        {
            get { return _wundenKopf; }
            set
    		{ 
    			Set(ref _wundenKopf, value);
    		}
    
        }
        private int _wundenKopf;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenBrust
        {
            get { return _wundenBrust; }
            set
    		{ 
    			Set(ref _wundenBrust, value);
    		}
    
        }
        private int _wundenBrust;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenArmL
        {
            get { return _wundenArmL; }
            set
    		{ 
    			Set(ref _wundenArmL, value);
    		}
    
        }
        private int _wundenArmL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenArmR
        {
            get { return _wundenArmR; }
            set
    		{ 
    			Set(ref _wundenArmR, value);
    		}
    
        }
        private int _wundenArmR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenBauch
        {
            get { return _wundenBauch; }
            set
    		{ 
    			Set(ref _wundenBauch, value);
    		}
    
        }
        private int _wundenBauch;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenBeinL
        {
            get { return _wundenBeinL; }
            set
    		{ 
    			Set(ref _wundenBeinL, value);
    		}
    
        }
        private int _wundenBeinL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int WundenBeinR
        {
            get { return _wundenBeinR; }
            set
    		{ 
    			Set(ref _wundenBeinR, value);
    		}
    
        }
        private int _wundenBeinR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSKopf
        {
            get { return _rSKopf; }
            set
    		{ 
    			Set(ref _rSKopf, value);
    		}
    
        }
        private int _rSKopf;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSBrust
        {
            get { return _rSBrust; }
            set
    		{ 
    			Set(ref _rSBrust, value);
    		}
    
        }
        private int _rSBrust;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSRücken
        {
            get { return _rSRücken; }
            set
    		{ 
    			Set(ref _rSRücken, value);
    		}
    
        }
        private int _rSRücken;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSArmL
        {
            get { return _rSArmL; }
            set
    		{ 
    			Set(ref _rSArmL, value);
    		}
    
        }
        private int _rSArmL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSArmR
        {
            get { return _rSArmR; }
            set
    		{ 
    			Set(ref _rSArmR, value);
    		}
    
        }
        private int _rSArmR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSBauch
        {
            get { return _rSBauch; }
            set
    		{ 
    			Set(ref _rSBauch, value);
    		}
    
        }
        private int _rSBauch;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSBeinL
        {
            get { return _rSBeinL; }
            set
    		{ 
    			Set(ref _rSBeinL, value);
    		}
    
        }
        private int _rSBeinL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int RSBeinR
        {
            get { return _rSBeinR; }
            set
    		{ 
    			Set(ref _rSBeinR, value);
    		}
    
        }
        private int _rSBeinR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> SO
        {
            get { return _sO; }
            set
    		{ 
    			Set(ref _sO, value);
    		}
    
        }
        private Nullable<int> _sO;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual System.Guid HeldGUID
        {
            get { return _heldGUID; }
            set
    		{ 
    			Set(ref _heldGUID, value);
    		}
    
        }
        private System.Guid _heldGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Bild
        {
            get { return _bild; }
            set
    		{ 
    			Set(ref _bild, value);
    		}
    
        }
        private string _bild;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Spieler
        {
            get { return _spieler; }
            set
    		{ 
    			Set(ref _spieler, value);
    		}
    
        }
        private string _spieler;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<double> Vermögen
        {
            get { return _vermögen; }
            set
    		{ 
    			Set(ref _vermögen, value);
    		}
    
        }
        private Nullable<double> _vermögen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> APGesamt
        {
            get { return _aPGesamt; }
            set
    		{ 
    			Set(ref _aPGesamt, value);
    		}
    
        }
        private Nullable<int> _aPGesamt;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> APEingesetzt
        {
            get { return _aPEingesetzt; }
            set
    		{ 
    			Set(ref _aPEingesetzt, value);
    		}
    
        }
        private Nullable<int> _aPEingesetzt;

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual ICollection<Held_Modifikator> Held_Modifikator
        {
            get
            {
                if (_held_Modifikator == null)
                {
                    var newCollection = new FixupCollection<Held_Modifikator>();
                    newCollection.CollectionChanged += FixupHeld_Modifikator;
                    _held_Modifikator = newCollection;
                }
                return _held_Modifikator;
            }
            set
            {
                if (!ReferenceEquals(_held_Modifikator, value))
                {
                    var previousValue = _held_Modifikator as FixupCollection<Held_Modifikator>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Modifikator;
                    }
                    _held_Modifikator = value;
                    var newValue = value as FixupCollection<Held_Modifikator>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Modifikator;
                    }
                }
            }
        }
        private ICollection<Held_Modifikator> _held_Modifikator;
    
    	[DataMember]
        public virtual ICollection<Held_Pflanze> Held_Pflanze
        {
            get
            {
                if (_held_Pflanze == null)
                {
                    var newCollection = new FixupCollection<Held_Pflanze>();
                    newCollection.CollectionChanged += FixupHeld_Pflanze;
                    _held_Pflanze = newCollection;
                }
                return _held_Pflanze;
            }
            set
            {
                if (!ReferenceEquals(_held_Pflanze, value))
                {
                    var previousValue = _held_Pflanze as FixupCollection<Held_Pflanze>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Pflanze;
                    }
                    _held_Pflanze = value;
                    var newValue = value as FixupCollection<Held_Pflanze>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Pflanze;
                    }
                }
            }
        }
        private ICollection<Held_Pflanze> _held_Pflanze;
    
    	[DataMember]
        public virtual ICollection<Held_Ausrüstung> Held_Ausrüstung
        {
            get
            {
                if (_held_Ausrüstung == null)
                {
                    var newCollection = new FixupCollection<Held_Ausrüstung>();
                    newCollection.CollectionChanged += FixupHeld_Ausrüstung;
                    _held_Ausrüstung = newCollection;
                }
                return _held_Ausrüstung;
            }
            set
            {
                if (!ReferenceEquals(_held_Ausrüstung, value))
                {
                    var previousValue = _held_Ausrüstung as FixupCollection<Held_Ausrüstung>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Ausrüstung;
                    }
                    _held_Ausrüstung = value;
                    var newValue = value as FixupCollection<Held_Ausrüstung>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Ausrüstung;
                    }
                }
            }
        }
        private ICollection<Held_Ausrüstung> _held_Ausrüstung;
    
    	[DataMember]
        public virtual ICollection<Held_Inventar> Held_Inventar
        {
            get
            {
                if (_held_Inventar == null)
                {
                    var newCollection = new FixupCollection<Held_Inventar>();
                    newCollection.CollectionChanged += FixupHeld_Inventar;
                    _held_Inventar = newCollection;
                }
                return _held_Inventar;
            }
            set
            {
                if (!ReferenceEquals(_held_Inventar, value))
                {
                    var previousValue = _held_Inventar as FixupCollection<Held_Inventar>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Inventar;
                    }
                    _held_Inventar = value;
                    var newValue = value as FixupCollection<Held_Inventar>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Inventar;
                    }
                }
            }
        }
        private ICollection<Held_Inventar> _held_Inventar;
    
    	[DataMember]
        public virtual ICollection<Held_Munition> Held_Munition
        {
            get
            {
                if (_held_Munition == null)
                {
                    var newCollection = new FixupCollection<Held_Munition>();
                    newCollection.CollectionChanged += FixupHeld_Munition;
                    _held_Munition = newCollection;
                }
                return _held_Munition;
            }
            set
            {
                if (!ReferenceEquals(_held_Munition, value))
                {
                    var previousValue = _held_Munition as FixupCollection<Held_Munition>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Munition;
                    }
                    _held_Munition = value;
                    var newValue = value as FixupCollection<Held_Munition>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Munition;
                    }
                }
            }
        }
        private ICollection<Held_Munition> _held_Munition;
    
    	[DataMember]
        public virtual ICollection<Held_Talent> Held_Talent
        {
            get
            {
                if (_held_Talent == null)
                {
                    var newCollection = new FixupCollection<Held_Talent>();
                    newCollection.CollectionChanged += FixupHeld_Talent;
                    _held_Talent = newCollection;
                }
                return _held_Talent;
            }
            set
            {
                if (!ReferenceEquals(_held_Talent, value))
                {
                    var previousValue = _held_Talent as FixupCollection<Held_Talent>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Talent;
                    }
                    _held_Talent = value;
                    var newValue = value as FixupCollection<Held_Talent>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Talent;
                    }
                }
            }
        }
        private ICollection<Held_Talent> _held_Talent;
    
    	[DataMember]
        public virtual ICollection<Held_Sonderfertigkeit> Held_Sonderfertigkeit
        {
            get
            {
                if (_held_Sonderfertigkeit == null)
                {
                    var newCollection = new FixupCollection<Held_Sonderfertigkeit>();
                    newCollection.CollectionChanged += FixupHeld_Sonderfertigkeit;
                    _held_Sonderfertigkeit = newCollection;
                }
                return _held_Sonderfertigkeit;
            }
            set
            {
                if (!ReferenceEquals(_held_Sonderfertigkeit, value))
                {
                    var previousValue = _held_Sonderfertigkeit as FixupCollection<Held_Sonderfertigkeit>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Sonderfertigkeit;
                    }
                    _held_Sonderfertigkeit = value;
                    var newValue = value as FixupCollection<Held_Sonderfertigkeit>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Sonderfertigkeit;
                    }
                }
            }
        }
        private ICollection<Held_Sonderfertigkeit> _held_Sonderfertigkeit;
    
    	[DataMember]
        public virtual ICollection<Held_VorNachteil> Held_VorNachteil
        {
            get
            {
                if (_held_VorNachteil == null)
                {
                    var newCollection = new FixupCollection<Held_VorNachteil>();
                    newCollection.CollectionChanged += FixupHeld_VorNachteil;
                    _held_VorNachteil = newCollection;
                }
                return _held_VorNachteil;
            }
            set
            {
                if (!ReferenceEquals(_held_VorNachteil, value))
                {
                    var previousValue = _held_VorNachteil as FixupCollection<Held_VorNachteil>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_VorNachteil;
                    }
                    _held_VorNachteil = value;
                    var newValue = value as FixupCollection<Held_VorNachteil>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_VorNachteil;
                    }
                }
            }
        }
        private ICollection<Held_VorNachteil> _held_VorNachteil;
    
    	[DataMember]
        public virtual ICollection<Held_Zauber> Held_Zauber
        {
            get
            {
                if (_held_Zauber == null)
                {
                    var newCollection = new FixupCollection<Held_Zauber>();
                    newCollection.CollectionChanged += FixupHeld_Zauber;
                    _held_Zauber = newCollection;
                }
                return _held_Zauber;
            }
            set
            {
                if (!ReferenceEquals(_held_Zauber, value))
                {
                    var previousValue = _held_Zauber as FixupCollection<Held_Zauber>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Zauber;
                    }
                    _held_Zauber = value;
                    var newValue = value as FixupCollection<Held_Zauber>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Zauber;
                    }
                }
            }
        }
        private ICollection<Held_Zauber> _held_Zauber;

        #endregion

        #region Association Fixup
    
        private void FixupHeld_Modifikator(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Modifikator");
            if (e.NewItems != null)
            {
                foreach (Held_Modifikator item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Modifikator item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Pflanze(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Pflanze");
            if (e.NewItems != null)
            {
                foreach (Held_Pflanze item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Pflanze item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Ausrüstung(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Ausrüstung");
            if (e.NewItems != null)
            {
                foreach (Held_Ausrüstung item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Ausrüstung item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Inventar(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Inventar");
            if (e.NewItems != null)
            {
                foreach (Held_Inventar item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Inventar item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Munition(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Munition");
            if (e.NewItems != null)
            {
                foreach (Held_Munition item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Munition item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Talent(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Talent");
            if (e.NewItems != null)
            {
                foreach (Held_Talent item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Talent item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Sonderfertigkeit(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Sonderfertigkeit");
            if (e.NewItems != null)
            {
                foreach (Held_Sonderfertigkeit item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Sonderfertigkeit item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_VorNachteil(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_VorNachteil");
            if (e.NewItems != null)
            {
                foreach (Held_VorNachteil item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_VorNachteil item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Zauber(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Zauber");
            if (e.NewItems != null)
            {
                foreach (Held_Zauber item in e.NewItems)
                {
                    item.Held = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Zauber item in e.OldItems)
                {
                    if (ReferenceEquals(item.Held, this))
                    {
                        item.Held = null;
                    }
                }
            }
        }

        #endregion

    }
}
