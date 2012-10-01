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
    public partial class Kultur : INotifyPropertyChanged
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
        public virtual System.Guid KulturGUID
        {
            get { return _kulturGUID; }
            set
    		{ 
    			_kulturGUID = value;
    			OnChanged("KulturGUID");
    		}
    
        }
        private System.Guid _kulturGUID;
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
        public virtual string Variante
        {
            get { return _variante; }
            set
    		{ 
    			_variante = value;
    			OnChanged("Variante");
    		}
    
        }
        private string _variante;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int GP
        {
            get { return _gP; }
            set
    		{ 
    			_gP = value;
    			OnChanged("GP");
    		}
    
        }
        private int _gP;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> SOmin
        {
            get { return _sOmin; }
            set
    		{ 
    			_sOmin = value;
    			OnChanged("SOmin");
    		}
    
        }
        private Nullable<int> _sOmin;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> SOmax
        {
            get { return _sOmax; }
            set
    		{ 
    			_sOmax = value;
    			OnChanged("SOmax");
    		}
    
        }
        private Nullable<int> _sOmax;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Voraussetzungen
        {
            get { return _voraussetzungen; }
            set
    		{ 
    			_voraussetzungen = value;
    			OnChanged("Voraussetzungen");
    		}
    
        }
        private string _voraussetzungen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int MUMod
        {
            get { return _mUMod; }
            set
    		{ 
    			_mUMod = value;
    			OnChanged("MUMod");
    		}
    
        }
        private int _mUMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int KLMod
        {
            get { return _kLMod; }
            set
    		{ 
    			_kLMod = value;
    			OnChanged("KLMod");
    		}
    
        }
        private int _kLMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int INMod
        {
            get { return _iNMod; }
            set
    		{ 
    			_iNMod = value;
    			OnChanged("INMod");
    		}
    
        }
        private int _iNMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int CHMod
        {
            get { return _cHMod; }
            set
    		{ 
    			_cHMod = value;
    			OnChanged("CHMod");
    		}
    
        }
        private int _cHMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int FFMod
        {
            get { return _fFMod; }
            set
    		{ 
    			_fFMod = value;
    			OnChanged("FFMod");
    		}
    
        }
        private int _fFMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int GEMod
        {
            get { return _gEMod; }
            set
    		{ 
    			_gEMod = value;
    			OnChanged("GEMod");
    		}
    
        }
        private int _gEMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int KOMod
        {
            get { return _kOMod; }
            set
    		{ 
    			_kOMod = value;
    			OnChanged("KOMod");
    		}
    
        }
        private int _kOMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int KKMod
        {
            get { return _kKMod; }
            set
    		{ 
    			_kKMod = value;
    			OnChanged("KKMod");
    		}
    
        }
        private int _kKMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int LEMod
        {
            get { return _lEMod; }
            set
    		{ 
    			_lEMod = value;
    			OnChanged("LEMod");
    		}
    
        }
        private int _lEMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int AUMod
        {
            get { return _aUMod; }
            set
    		{ 
    			_aUMod = value;
    			OnChanged("AUMod");
    		}
    
        }
        private int _aUMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int MRMod
        {
            get { return _mRMod; }
            set
    		{ 
    			_mRMod = value;
    			OnChanged("MRMod");
    		}
    
        }
        private int _mRMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Literatur
        {
            get { return _literatur; }
            set
    		{ 
    			_literatur = value;
    			OnChanged("Literatur");
    		}
    
        }
        private string _literatur;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Setting
        {
            get { return _setting; }
            set
    		{ 
    			_setting = value;
    			OnChanged("Setting");
    		}
    
        }
        private string _setting;

        #endregion
        #region Navigation Properties
    
    	[DataMember]
        public virtual ICollection<Kultur_Name> Kultur_Name
        {
            get
            {
                if (_kultur_Name == null)
                {
                    var newCollection = new FixupCollection<Kultur_Name>();
                    newCollection.CollectionChanged += FixupKultur_Name;
                    _kultur_Name = newCollection;
                }
                return _kultur_Name;
            }
            set
            {
                if (!ReferenceEquals(_kultur_Name, value))
                {
                    var previousValue = _kultur_Name as FixupCollection<Kultur_Name>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupKultur_Name;
                    }
                    _kultur_Name = value;
                    var newValue = value as FixupCollection<Kultur_Name>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupKultur_Name;
                    }
                }
            }
        }
        private ICollection<Kultur_Name> _kultur_Name;
    
    	[DataMember]
        public virtual ICollection<Rasse_Kultur> Rasse_Kultur
        {
            get
            {
                if (_rasse_Kultur == null)
                {
                    var newCollection = new FixupCollection<Rasse_Kultur>();
                    newCollection.CollectionChanged += FixupRasse_Kultur;
                    _rasse_Kultur = newCollection;
                }
                return _rasse_Kultur;
            }
            set
            {
                if (!ReferenceEquals(_rasse_Kultur, value))
                {
                    var previousValue = _rasse_Kultur as FixupCollection<Rasse_Kultur>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupRasse_Kultur;
                    }
                    _rasse_Kultur = value;
                    var newValue = value as FixupCollection<Rasse_Kultur>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupRasse_Kultur;
                    }
                }
            }
        }
        private ICollection<Rasse_Kultur> _rasse_Kultur;

        #endregion
        #region Association Fixup
    
        private void FixupKultur_Name(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Kultur_Name");
            if (e.NewItems != null)
            {
                foreach (Kultur_Name item in e.NewItems)
                {
                    item.Kultur = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Kultur_Name item in e.OldItems)
                {
                    if (ReferenceEquals(item.Kultur, this))
                    {
                        item.Kultur = null;
                    }
                }
            }
        }
    
        private void FixupRasse_Kultur(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Rasse_Kultur");
            if (e.NewItems != null)
            {
                foreach (Rasse_Kultur item in e.NewItems)
                {
                    item.Kultur = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Rasse_Kultur item in e.OldItems)
                {
                    if (ReferenceEquals(item.Kultur, this))
                    {
                        item.Kultur = null;
                    }
                }
            }
        }

        #endregion
    }
}
