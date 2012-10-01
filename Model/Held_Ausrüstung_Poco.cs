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
    public partial class Held_Ausrüstung : INotifyPropertyChanged
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
        public virtual System.Guid HeldGUID
        {
            get { return _heldGUID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_heldGUID != value)
                    {
                        if (Held != null && Held.HeldGUID != value)
                        {
                            Held = null;
                        }
                        _heldGUID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    
        }
        private System.Guid _heldGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual bool Angelegt
        {
            get { return _angelegt; }
            set
    		{ 
    			_angelegt = value;
    			OnChanged("Angelegt");
    		}
    
        }
        private bool _angelegt;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual System.Guid AusrüstungGUID
        {
            get { return _ausrüstungGUID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_ausrüstungGUID != value)
                    {
                        if (Ausrüstung != null && Ausrüstung.AusrüstungGUID != value)
                        {
                            Ausrüstung = null;
                        }
                        _ausrüstungGUID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    
        }
        private System.Guid _ausrüstungGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Talentname
        {
            get { return _talentname; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_talentname != value)
                    {
                        if (Talent != null && Talent.Talentname != value)
                        {
                            Talent = null;
                        }
                        _talentname = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    
        }
        private string _talentname;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<int> Anzahl
        {
            get { return _anzahl; }
            set
    		{ 
    			_anzahl = value;
    			OnChanged("Anzahl");
    		}
    
        }
        private Nullable<int> _anzahl;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int BF
        {
            get { return _bF; }
            set
    		{ 
    			_bF = value;
    			OnChanged("BF");
    		}
    
        }
        private int _bF;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual System.Guid TrageortGUID
        {
            get { return _trageortGUID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_trageortGUID != value)
                    {
                        if (Trageort != null && Trageort.TrageortGUID != value)
                        {
                            Trageort = null;
                        }
                        _trageortGUID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    
        }
        private System.Guid _trageortGUID;

        #endregion
        #region Navigation Properties
    
    	[DataMember]
        public virtual Ausrüstung Ausrüstung
        {
            get { return _ausrüstung; }
            set
            {
                if (!ReferenceEquals(_ausrüstung, value))
                {
                    var previousValue = _ausrüstung;
                    _ausrüstung = value;
                    FixupAusrüstung(previousValue);
                }
            }
        }
        private Ausrüstung _ausrüstung;
    
    	[DataMember]
        public virtual Held Held
        {
            get { return _held; }
            set
            {
                if (!ReferenceEquals(_held, value))
                {
                    var previousValue = _held;
                    _held = value;
                    FixupHeld(previousValue);
                }
            }
        }
        private Held _held;
    
    	[DataMember]
        public virtual Talent Talent
        {
            get { return _talent; }
            set
            {
                if (!ReferenceEquals(_talent, value))
                {
                    var previousValue = _talent;
                    _talent = value;
                    FixupTalent(previousValue);
                }
            }
        }
        private Talent _talent;
    
    	[DataMember]
        public virtual Trageort Trageort
        {
            get { return _trageort; }
            set
            {
                if (!ReferenceEquals(_trageort, value))
                {
                    var previousValue = _trageort;
                    _trageort = value;
                    FixupTrageort(previousValue);
                }
            }
        }
        private Trageort _trageort;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupAusrüstung(Ausrüstung previousValue)
        {
    		OnChanged("Ausrüstung");
            if (previousValue != null && previousValue.Held_Ausrüstung.Contains(this))
            {
                previousValue.Held_Ausrüstung.Remove(this);
            }
    
            if (Ausrüstung != null)
            {
                if (!Ausrüstung.Held_Ausrüstung.Contains(this))
                {
                    Ausrüstung.Held_Ausrüstung.Add(this);
                }
                if (AusrüstungGUID != Ausrüstung.AusrüstungGUID)
                {
                    AusrüstungGUID = Ausrüstung.AusrüstungGUID;
                }
            }
        }
    
        private void FixupHeld(Held previousValue)
        {
    		OnChanged("Held");
            if (previousValue != null && previousValue.Held_Ausrüstung.Contains(this))
            {
                previousValue.Held_Ausrüstung.Remove(this);
            }
    
            if (Held != null)
            {
                if (!Held.Held_Ausrüstung.Contains(this))
                {
                    Held.Held_Ausrüstung.Add(this);
                }
                if (HeldGUID != Held.HeldGUID)
                {
                    HeldGUID = Held.HeldGUID;
                }
            }
        }
    
        private void FixupTalent(Talent previousValue)
        {
    		OnChanged("Talent");
            if (previousValue != null && previousValue.Held_Ausrüstung.Contains(this))
            {
                previousValue.Held_Ausrüstung.Remove(this);
            }
    
            if (Talent != null)
            {
                if (!Talent.Held_Ausrüstung.Contains(this))
                {
                    Talent.Held_Ausrüstung.Add(this);
                }
                if (Talentname != Talent.Talentname)
                {
                    Talentname = Talent.Talentname;
                }
            }
            else if (!_settingFK)
            {
                Talentname = null;
            }
        }
    
        private void FixupTrageort(Trageort previousValue)
        {
    		OnChanged("Trageort");
            if (previousValue != null && previousValue.Held_Ausrüstung.Contains(this))
            {
                previousValue.Held_Ausrüstung.Remove(this);
            }
    
            if (Trageort != null)
            {
                if (!Trageort.Held_Ausrüstung.Contains(this))
                {
                    Trageort.Held_Ausrüstung.Add(this);
                }
                if (TrageortGUID != Trageort.TrageortGUID)
                {
                    TrageortGUID = Trageort.TrageortGUID;
                }
            }
        }

        #endregion
    }
}
