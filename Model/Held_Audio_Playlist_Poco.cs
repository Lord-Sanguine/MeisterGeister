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
    public partial class Held_Audio_Playlist : INotifyPropertyChanged
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
        public virtual System.Guid Audio_PlaylistGUID
        {
            get { return _audio_PlaylistGUID; }
            set
            {
                if (_audio_PlaylistGUID != value)
                {
                    if (Audio_Playlist != null && Audio_Playlist.Audio_PlaylistGUID != value)
                    {
                        Audio_Playlist = null;
                    }
                    _audio_PlaylistGUID = value;
                }
            }
    
        }
        private System.Guid _audio_PlaylistGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual System.Guid HeldGUID
        {
            get { return _heldGUID; }
            set
            {
                if (_heldGUID != value)
                {
                    if (Held != null && Held.HeldGUID != value)
                    {
                        Held = null;
                    }
                    _heldGUID = value;
                }
            }
    
        }
        private System.Guid _heldGUID;
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

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual Audio_Playlist Audio_Playlist
        {
            get { return _audio_Playlist; }
            set
            {
                if (!ReferenceEquals(_audio_Playlist, value))
                {
                    var previousValue = _audio_Playlist;
                    _audio_Playlist = value;
                    FixupAudio_Playlist(previousValue);
                }
            }
        }
        private Audio_Playlist _audio_Playlist;
    
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

        #endregion

        #region Association Fixup
    
        private void FixupAudio_Playlist(Audio_Playlist previousValue)
        {
    		OnChanged("Audio_Playlist");
            if (previousValue != null && previousValue.Held_Audio_Playlist.Contains(this))
            {
                previousValue.Held_Audio_Playlist.Remove(this);
            }
    
            if (Audio_Playlist != null)
            {
                if (!Audio_Playlist.Held_Audio_Playlist.Contains(this))
                {
                    Audio_Playlist.Held_Audio_Playlist.Add(this);
                }
                if (Audio_PlaylistGUID != Audio_Playlist.Audio_PlaylistGUID)
                {
                    Audio_PlaylistGUID = Audio_Playlist.Audio_PlaylistGUID;
                }
            }
        }
    
        private void FixupHeld(Held previousValue)
        {
    		OnChanged("Held");
            if (previousValue != null && previousValue.Held_Audio_Playlist.Contains(this))
            {
                previousValue.Held_Audio_Playlist.Remove(this);
            }
    
            if (Held != null)
            {
                if (!Held.Held_Audio_Playlist.Contains(this))
                {
                    Held.Held_Audio_Playlist.Add(this);
                }
                if (HeldGUID != Held.HeldGUID)
                {
                    HeldGUID = Held.HeldGUID;
                }
            }
        }

        #endregion

    }
}