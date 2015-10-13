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
    public partial class Talent : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
    	public event PropertyChangedEventHandler PropertyChanged;
    	
    	/// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void OnChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

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

        #region Set
    	/// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected bool Set<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
    
    		OnValidatePropertyChanging(storage, value, propertyName);
    		storage = value;
    		OnChanged(propertyName);
            return true;
        }

        #endregion

        #region Primitive Properties
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual System.Guid TalentGUID
        {
            get { return _talentGUID; }
            set
    		{ 
    			Set(ref _talentGUID, value);
    		}
    
        }
        private System.Guid _talentGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Talentname
        {
            get { return _talentname; }
            set
    		{ 
    			Set(ref _talentname, value);
    		}
    
        }
        private string _talentname;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> TalentgruppeID
        {
            get { return _talentgruppeID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_talentgruppeID != value)
                    {
                        if (Talentgruppe != null && Talentgruppe.TalentgruppeID != value)
                        {
                            Talentgruppe = null;
                        }
                        _talentgruppeID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    
        }
        private Nullable<int> _talentgruppeID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Eigenschaft1
        {
            get { return _eigenschaft1; }
            set
    		{ 
    			Set(ref _eigenschaft1, value);
    		}
    
        }
        private string _eigenschaft1;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Eigenschaft2
        {
            get { return _eigenschaft2; }
            set
    		{ 
    			Set(ref _eigenschaft2, value);
    		}
    
        }
        private string _eigenschaft2;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Eigenschaft3
        {
            get { return _eigenschaft3; }
            set
    		{ 
    			Set(ref _eigenschaft3, value);
    		}
    
        }
        private string _eigenschaft3;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Talenttyp
        {
            get { return _talenttyp; }
            set
    		{ 
    			Set(ref _talenttyp, value);
    		}
    
        }
        private string _talenttyp;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string eBE
        {
            get { return _eBE; }
            set
    		{ 
    			Set(ref _eBE, value);
    		}
    
        }
        private string _eBE;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Spezialisierungen
        {
            get { return _spezialisierungen; }
            set
    		{ 
    			Set(ref _spezialisierungen, value);
    		}
    
        }
        private string _spezialisierungen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Voraussetzungen
        {
            get { return _voraussetzungen; }
            set
    		{ 
    			Set(ref _voraussetzungen, value);
    		}
    
        }
        private string _voraussetzungen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Steigerung
        {
            get { return _steigerung; }
            set
    		{ 
    			Set(ref _steigerung, value);
    		}
    
        }
        private string _steigerung;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string WikiLink
        {
            get { return _wikiLink; }
            set
    		{ 
    			Set(ref _wikiLink, value);
    		}
    
        }
        private string _wikiLink;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Untergruppe
        {
            get { return _untergruppe; }
            set
    		{ 
    			Set(ref _untergruppe, value);
    		}
    
        }
        private string _untergruppe;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Setting
        {
            get { return _setting; }
            set
    		{ 
    			Set(ref _setting, value);
    		}
    
        }
        private string _setting;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Literatur
        {
            get { return _literatur; }
            set
    		{ 
    			Set(ref _literatur, value);
    		}
    
        }
        private string _literatur;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Regelsystem
        {
            get { return _regelsystem; }
            set
    		{ 
    			Set(ref _regelsystem, value);
    		}
    
        }
        private string _regelsystem;

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual ICollection<Held_Fernkampfwaffe> Held_Fernkampfwaffe
        {
            get
            {
                if (_held_Fernkampfwaffe == null)
                {
                    var newCollection = new FixupCollection<Held_Fernkampfwaffe>();
                    newCollection.CollectionChanged += FixupHeld_Fernkampfwaffe;
                    _held_Fernkampfwaffe = newCollection;
                }
                return _held_Fernkampfwaffe;
            }
            set
            {
                if (!ReferenceEquals(_held_Fernkampfwaffe, value))
                {
                    var previousValue = _held_Fernkampfwaffe as FixupCollection<Held_Fernkampfwaffe>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Fernkampfwaffe;
                    }
                    _held_Fernkampfwaffe = value;
                    var newValue = value as FixupCollection<Held_Fernkampfwaffe>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Fernkampfwaffe;
                    }
                }
            }
        }
        private ICollection<Held_Fernkampfwaffe> _held_Fernkampfwaffe;
    
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
        public virtual ICollection<Held_Waffe> Held_Waffe
        {
            get
            {
                if (_held_Waffe == null)
                {
                    var newCollection = new FixupCollection<Held_Waffe>();
                    newCollection.CollectionChanged += FixupHeld_Waffe;
                    _held_Waffe = newCollection;
                }
                return _held_Waffe;
            }
            set
            {
                if (!ReferenceEquals(_held_Waffe, value))
                {
                    var previousValue = _held_Waffe as FixupCollection<Held_Waffe>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHeld_Waffe;
                    }
                    _held_Waffe = value;
                    var newValue = value as FixupCollection<Held_Waffe>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHeld_Waffe;
                    }
                }
            }
        }
        private ICollection<Held_Waffe> _held_Waffe;
    
    	[DataMember]
        public virtual Talentgruppe Talentgruppe
        {
            get { return _talentgruppe; }
            set
            {
                if (!ReferenceEquals(_talentgruppe, value))
                {
                    var previousValue = _talentgruppe;
                    _talentgruppe = value;
                    FixupTalentgruppe(previousValue);
                }
            }
        }
        private Talentgruppe _talentgruppe;
    
    	[DataMember]
        public virtual ICollection<Fernkampfwaffe> Fernkampfwaffe
        {
            get
            {
                if (_fernkampfwaffe == null)
                {
                    var newCollection = new FixupCollection<Fernkampfwaffe>();
                    newCollection.CollectionChanged += FixupFernkampfwaffe;
                    _fernkampfwaffe = newCollection;
                }
                return _fernkampfwaffe;
            }
            set
            {
                if (!ReferenceEquals(_fernkampfwaffe, value))
                {
                    var previousValue = _fernkampfwaffe as FixupCollection<Fernkampfwaffe>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupFernkampfwaffe;
                    }
                    _fernkampfwaffe = value;
                    var newValue = value as FixupCollection<Fernkampfwaffe>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupFernkampfwaffe;
                    }
                }
            }
        }
        private ICollection<Fernkampfwaffe> _fernkampfwaffe;
    
    	[DataMember]
        public virtual ICollection<Waffe> Waffe
        {
            get
            {
                if (_waffe == null)
                {
                    var newCollection = new FixupCollection<Waffe>();
                    newCollection.CollectionChanged += FixupWaffe;
                    _waffe = newCollection;
                }
                return _waffe;
            }
            set
            {
                if (!ReferenceEquals(_waffe, value))
                {
                    var previousValue = _waffe as FixupCollection<Waffe>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupWaffe;
                    }
                    _waffe = value;
                    var newValue = value as FixupCollection<Waffe>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupWaffe;
                    }
                }
            }
        }
        private ICollection<Waffe> _waffe;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupTalentgruppe(Talentgruppe previousValue)
        {
    		OnChanged("Talentgruppe");
            if (previousValue != null && previousValue.Talent.Contains(this))
            {
                previousValue.Talent.Remove(this);
            }
    
            if (Talentgruppe != null)
            {
                if (!Talentgruppe.Talent.Contains(this))
                {
                    Talentgruppe.Talent.Add(this);
                }
                if (TalentgruppeID != Talentgruppe.TalentgruppeID)
                {
                    TalentgruppeID = Talentgruppe.TalentgruppeID;
                }
            }
            else if (!_settingFK)
            {
                TalentgruppeID = null;
            }
        }
    
        private void FixupHeld_Fernkampfwaffe(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Fernkampfwaffe");
            if (e.NewItems != null)
            {
                foreach (Held_Fernkampfwaffe item in e.NewItems)
                {
                    item.Talent = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Fernkampfwaffe item in e.OldItems)
                {
                    if (ReferenceEquals(item.Talent, this))
                    {
                        item.Talent = null;
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
                    item.Talent = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Talent item in e.OldItems)
                {
                    if (ReferenceEquals(item.Talent, this))
                    {
                        item.Talent = null;
                    }
                }
            }
        }
    
        private void FixupHeld_Waffe(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Held_Waffe");
            if (e.NewItems != null)
            {
                foreach (Held_Waffe item in e.NewItems)
                {
                    item.Talent = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Held_Waffe item in e.OldItems)
                {
                    if (ReferenceEquals(item.Talent, this))
                    {
                        item.Talent = null;
                    }
                }
            }
        }
    
        private void FixupFernkampfwaffe(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Fernkampfwaffe");
            if (e.NewItems != null)
            {
                foreach (Fernkampfwaffe item in e.NewItems)
                {
                    if (!item.Talent.Contains(this))
                    {
                        item.Talent.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Fernkampfwaffe item in e.OldItems)
                {
                    if (item.Talent.Contains(this))
                    {
                        item.Talent.Remove(this);
                    }
                }
            }
        }
    
        private void FixupWaffe(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Waffe");
            if (e.NewItems != null)
            {
                foreach (Waffe item in e.NewItems)
                {
                    if (!item.Talent.Contains(this))
                    {
                        item.Talent.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Waffe item in e.OldItems)
                {
                    if (item.Talent.Contains(this))
                    {
                        item.Talent.Remove(this);
                    }
                }
            }
        }

        #endregion

    }
}
