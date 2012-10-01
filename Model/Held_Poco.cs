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

namespace MeisterGeister.Model
{
    [DataContract(IsReference=true)]
    public partial class Held : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
    	public event PropertyChangedEventHandler PropertyChanged;
    	
    	public void OnChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
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
    			_name = value;
    			OnChanged("Name");
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
    			_mU = value;
    			OnChanged("MU");
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
    			_kL = value;
    			OnChanged("KL");
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
    			_iN = value;
    			OnChanged("IN");
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
    			_cH = value;
    			OnChanged("CH");
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
    			_fF = value;
    			OnChanged("FF");
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
    			_gE = value;
    			OnChanged("GE");
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
    			_kO = value;
    			OnChanged("KO");
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
    			_kK = value;
    			OnChanged("KK");
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
    			_bE = value;
    			OnChanged("BE");
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
    			_iNI_Mod = value;
    			OnChanged("INI_Mod");
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
    			_lE_Mod = value;
    			OnChanged("LE_Mod");
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
    			_lE_Aktuell = value;
    			OnChanged("LE_Aktuell");
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
    			_aU_Mod = value;
    			OnChanged("AU_Mod");
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
    			_aU_Aktuell = value;
    			OnChanged("AU_Aktuell");
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
    			_aE_Mod = value;
    			OnChanged("AE_Mod");
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
    			_aE_Aktuell = value;
    			OnChanged("AE_Aktuell");
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
    			_kE_Mod = value;
    			OnChanged("KE_Mod");
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
    			_kE_Aktuell = value;
    			OnChanged("KE_Aktuell");
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
    			_mR_Mod = value;
    			OnChanged("MR_Mod");
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
    			_kampfwerte = value;
    			OnChanged("Kampfwerte");
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
    			_wunden = value;
    			OnChanged("Wunden");
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
    			_aktiveHeldengruppe = value;
    			OnChanged("AktiveHeldengruppe");
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
    			_proben = value;
    			OnChanged("Proben");
    		}
    
        }
        private Nullable<bool> _proben;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string BildLink
        {
            get { return _bildLink; }
            set
    		{ 
    			_bildLink = value;
    			OnChanged("BildLink");
    		}
    
        }
        private string _bildLink;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Rasse
        {
            get { return _rasse; }
            set
    		{ 
    			_rasse = value;
    			OnChanged("Rasse");
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
    			_kultur = value;
    			OnChanged("Kultur");
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
    			_profession = value;
    			OnChanged("Profession");
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
    			_notizen = value;
    			OnChanged("Notizen");
    		}
    
        }
        private string _notizen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenKopf
        {
            get { return _wundenKopf; }
            set
    		{ 
    			_wundenKopf = value;
    			OnChanged("WundenKopf");
    		}
    
        }
        private Nullable<int> _wundenKopf;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenBrust
        {
            get { return _wundenBrust; }
            set
    		{ 
    			_wundenBrust = value;
    			OnChanged("WundenBrust");
    		}
    
        }
        private Nullable<int> _wundenBrust;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenArmL
        {
            get { return _wundenArmL; }
            set
    		{ 
    			_wundenArmL = value;
    			OnChanged("WundenArmL");
    		}
    
        }
        private Nullable<int> _wundenArmL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenArmR
        {
            get { return _wundenArmR; }
            set
    		{ 
    			_wundenArmR = value;
    			OnChanged("WundenArmR");
    		}
    
        }
        private Nullable<int> _wundenArmR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenBauch
        {
            get { return _wundenBauch; }
            set
    		{ 
    			_wundenBauch = value;
    			OnChanged("WundenBauch");
    		}
    
        }
        private Nullable<int> _wundenBauch;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenBeinL
        {
            get { return _wundenBeinL; }
            set
    		{ 
    			_wundenBeinL = value;
    			OnChanged("WundenBeinL");
    		}
    
        }
        private Nullable<int> _wundenBeinL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> WundenBeinR
        {
            get { return _wundenBeinR; }
            set
    		{ 
    			_wundenBeinR = value;
    			OnChanged("WundenBeinR");
    		}
    
        }
        private Nullable<int> _wundenBeinR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSKopf
        {
            get { return _rSKopf; }
            set
    		{ 
    			_rSKopf = value;
    			OnChanged("RSKopf");
    		}
    
        }
        private Nullable<int> _rSKopf;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSBrust
        {
            get { return _rSBrust; }
            set
    		{ 
    			_rSBrust = value;
    			OnChanged("RSBrust");
    		}
    
        }
        private Nullable<int> _rSBrust;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSRücken
        {
            get { return _rSRücken; }
            set
    		{ 
    			_rSRücken = value;
    			OnChanged("RSRücken");
    		}
    
        }
        private Nullable<int> _rSRücken;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSArmL
        {
            get { return _rSArmL; }
            set
    		{ 
    			_rSArmL = value;
    			OnChanged("RSArmL");
    		}
    
        }
        private Nullable<int> _rSArmL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSArmR
        {
            get { return _rSArmR; }
            set
    		{ 
    			_rSArmR = value;
    			OnChanged("RSArmR");
    		}
    
        }
        private Nullable<int> _rSArmR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSBauch
        {
            get { return _rSBauch; }
            set
    		{ 
    			_rSBauch = value;
    			OnChanged("RSBauch");
    		}
    
        }
        private Nullable<int> _rSBauch;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSBeinL
        {
            get { return _rSBeinL; }
            set
    		{ 
    			_rSBeinL = value;
    			OnChanged("RSBeinL");
    		}
    
        }
        private Nullable<int> _rSBeinL;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> RSBeinR
        {
            get { return _rSBeinR; }
            set
    		{ 
    			_rSBeinR = value;
    			OnChanged("RSBeinR");
    		}
    
        }
        private Nullable<int> _rSBeinR;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> SO
        {
            get { return _sO; }
            set
    		{ 
    			_sO = value;
    			OnChanged("SO");
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
    			_heldGUID = value;
    			OnChanged("HeldGUID");
    		}
    
        }
        private System.Guid _heldGUID;

        #endregion
        #region Navigation Properties
    
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
