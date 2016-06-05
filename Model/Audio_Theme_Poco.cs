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
    public partial class Audio_Theme : INotifyPropertyChanged
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
        public virtual System.Guid Audio_ThemeGUID
        {
            get { return _audio_ThemeGUID; }
            set
    		{ 
    			Set(ref _audio_ThemeGUID, value);
    		}
    
        }
        private System.Guid _audio_ThemeGUID;
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
        public virtual int Hintergrund_VolMod
        {
            get { return _hintergrund_VolMod; }
            set
    		{ 
    			Set(ref _hintergrund_VolMod, value);
    		}
    
        }
        private int _hintergrund_VolMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int Klang_VolMod
        {
            get { return _klang_VolMod; }
            set
    		{ 
    			Set(ref _klang_VolMod, value);
    		}
    
        }
        private int _klang_VolMod;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual bool NurGeräusche
        {
            get { return _nurGeräusche; }
            set
    		{ 
    			Set(ref _nurGeräusche, value);
    		}
    
        }
        private bool _nurGeräusche;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Kategorie
        {
            get { return _kategorie; }
            set
    		{ 
    			Set(ref _kategorie, value);
    		}
    
        }
        private string _kategorie;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<bool> Favorite
        {
            get { return _favorite; }
            set
    		{ 
    			Set(ref _favorite, value);
    		}
    
        }
        private Nullable<bool> _favorite;

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual ICollection<Audio_Playlist> Audio_Playlist
        {
            get
            {
                if (_audio_Playlist == null)
                {
                    var newCollection = new FixupCollection<Audio_Playlist>();
                    newCollection.CollectionChanged += FixupAudio_Playlist;
                    _audio_Playlist = newCollection;
                }
                return _audio_Playlist;
            }
            set
            {
                if (!ReferenceEquals(_audio_Playlist, value))
                {
                    var previousValue = _audio_Playlist as FixupCollection<Audio_Playlist>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAudio_Playlist;
                    }
                    _audio_Playlist = value;
                    var newValue = value as FixupCollection<Audio_Playlist>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAudio_Playlist;
                    }
                }
            }
        }
        private ICollection<Audio_Playlist> _audio_Playlist;
    
    	[DataMember]
        public virtual ICollection<Audio_Theme> Audio_Theme1
        {
            get
            {
                if (_audio_Theme1 == null)
                {
                    var newCollection = new FixupCollection<Audio_Theme>();
                    newCollection.CollectionChanged += FixupAudio_Theme1;
                    _audio_Theme1 = newCollection;
                }
                return _audio_Theme1;
            }
            set
            {
                if (!ReferenceEquals(_audio_Theme1, value))
                {
                    var previousValue = _audio_Theme1 as FixupCollection<Audio_Theme>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAudio_Theme1;
                    }
                    _audio_Theme1 = value;
                    var newValue = value as FixupCollection<Audio_Theme>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAudio_Theme1;
                    }
                }
            }
        }
        private ICollection<Audio_Theme> _audio_Theme1;
    
    	[DataMember]
        public virtual ICollection<Audio_Theme> Audio_Theme2
        {
            get
            {
                if (_audio_Theme2 == null)
                {
                    var newCollection = new FixupCollection<Audio_Theme>();
                    newCollection.CollectionChanged += FixupAudio_Theme2;
                    _audio_Theme2 = newCollection;
                }
                return _audio_Theme2;
            }
            set
            {
                if (!ReferenceEquals(_audio_Theme2, value))
                {
                    var previousValue = _audio_Theme2 as FixupCollection<Audio_Theme>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAudio_Theme2;
                    }
                    _audio_Theme2 = value;
                    var newValue = value as FixupCollection<Audio_Theme>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAudio_Theme2;
                    }
                }
            }
        }
        private ICollection<Audio_Theme> _audio_Theme2;

        #endregion

        #region Association Fixup
    
        private void FixupAudio_Playlist(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Audio_Playlist");
            if (e.NewItems != null)
            {
                foreach (Audio_Playlist item in e.NewItems)
                {
                    if (!item.Audio_Theme.Contains(this))
                    {
                        item.Audio_Theme.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Audio_Playlist item in e.OldItems)
                {
                    if (item.Audio_Theme.Contains(this))
                    {
                        item.Audio_Theme.Remove(this);
                    }
                }
            }
        }
    
        private void FixupAudio_Theme1(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Audio_Theme1");
            if (e.NewItems != null)
            {
                foreach (Audio_Theme item in e.NewItems)
                {
                    if (!item.Audio_Theme2.Contains(this))
                    {
                        item.Audio_Theme2.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Audio_Theme item in e.OldItems)
                {
                    if (item.Audio_Theme2.Contains(this))
                    {
                        item.Audio_Theme2.Remove(this);
                    }
                }
            }
        }
    
        private void FixupAudio_Theme2(object sender, NotifyCollectionChangedEventArgs e)
        {
    		OnChanged("Audio_Theme2");
            if (e.NewItems != null)
            {
                foreach (Audio_Theme item in e.NewItems)
                {
                    if (!item.Audio_Theme1.Contains(this))
                    {
                        item.Audio_Theme1.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Audio_Theme item in e.OldItems)
                {
                    if (item.Audio_Theme1.Contains(this))
                    {
                        item.Audio_Theme1.Remove(this);
                    }
                }
            }
        }

        #endregion

    }
}
