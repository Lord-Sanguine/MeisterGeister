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
    public partial class Zauber_Setting : INotifyPropertyChanged
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
        public virtual System.Guid ZauberGUID
        {
            get { return _zauberGUID; }
            set
            {
                if (_zauberGUID != value)
                {
                    if (Zauber != null && Zauber.ZauberGUID != value)
                    {
                        Zauber = null;
                    }
                    _zauberGUID = value;
                }
            }
    
        }
        private System.Guid _zauberGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual System.Guid SettingGUID
        {
            get { return _settingGUID; }
            set
            {
                if (_settingGUID != value)
                {
                    if (Setting != null && Setting.SettingGUID != value)
                    {
                        Setting = null;
                    }
                    _settingGUID = value;
                }
            }
    
        }
        private System.Guid _settingGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Repräsentationen
        {
            get { return _repräsentationen; }
            set
    		{ 
    			_repräsentationen = value;
    			OnChanged("Repräsentationen");
    		}
    
        }
        private string _repräsentationen;

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual Setting Setting
        {
            get { return _setting; }
            set
            {
                if (!ReferenceEquals(_setting, value))
                {
                    var previousValue = _setting;
                    _setting = value;
                    FixupSetting(previousValue);
                }
            }
        }
        private Setting _setting;
    
    	[DataMember]
        public virtual Zauber Zauber
        {
            get { return _zauber; }
            set
            {
                if (!ReferenceEquals(_zauber, value))
                {
                    var previousValue = _zauber;
                    _zauber = value;
                    FixupZauber(previousValue);
                }
            }
        }
        private Zauber _zauber;

        #endregion

        #region Association Fixup
    
        private void FixupSetting(Setting previousValue)
        {
    		OnChanged("Setting");
            if (previousValue != null && previousValue.Zauber_Setting.Contains(this))
            {
                previousValue.Zauber_Setting.Remove(this);
            }
    
            if (Setting != null)
            {
                if (!Setting.Zauber_Setting.Contains(this))
                {
                    Setting.Zauber_Setting.Add(this);
                }
                if (SettingGUID != Setting.SettingGUID)
                {
                    SettingGUID = Setting.SettingGUID;
                }
            }
        }
    
        private void FixupZauber(Zauber previousValue)
        {
    		OnChanged("Zauber");
            if (previousValue != null && previousValue.Zauber_Setting.Contains(this))
            {
                previousValue.Zauber_Setting.Remove(this);
            }
    
            if (Zauber != null)
            {
                if (!Zauber.Zauber_Setting.Contains(this))
                {
                    Zauber.Zauber_Setting.Add(this);
                }
                if (ZauberGUID != Zauber.ZauberGUID)
                {
                    ZauberGUID = Zauber.ZauberGUID;
                }
            }
        }

        #endregion

    }
}