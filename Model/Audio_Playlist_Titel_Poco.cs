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
    public partial class Audio_Playlist_Titel : INotifyPropertyChanged
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
        public virtual System.Guid Audio_TitelGUID
        {
            get { return _audio_TitelGUID; }
            set
            {
                if (_audio_TitelGUID != value)
                {
                    if (Audio_Titel != null && Audio_Titel.Audio_TitelGUID != value)
                    {
                        Audio_Titel = null;
                    }
                    _audio_TitelGUID = value;
                }
            }
    
        }
        private System.Guid _audio_TitelGUID;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual bool Aktiv
        {
            get { return _aktiv; }
            set
    		{ 
    			_aktiv = value;
    			OnChanged("Aktiv");
    		}
    
        }
        private bool _aktiv;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int Volume
        {
            get { return _volume; }
            set
    		{ 
    			_volume = value;
    			OnChanged("Volume");
    		}
    
        }
        private int _volume;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual bool VolumeChange
        {
            get { return _volumeChange; }
            set
    		{ 
    			_volumeChange = value;
    			OnChanged("VolumeChange");
    		}
    
        }
        private bool _volumeChange;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int VolumeMin
        {
            get { return _volumeMin; }
            set
    		{ 
    			_volumeMin = value;
    			OnChanged("VolumeMin");
    		}
    
        }
        private int _volumeMin;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int VolumeMax
        {
            get { return _volumeMax; }
            set
    		{ 
    			_volumeMax = value;
    			OnChanged("VolumeMax");
    		}
    
        }
        private int _volumeMax;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual long Pause
        {
            get { return _pause; }
            set
    		{ 
    			_pause = value;
    			OnChanged("Pause");
    		}
    
        }
        private long _pause;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual bool PauseChange
        {
            get { return _pauseChange; }
            set
    		{ 
    			_pauseChange = value;
    			OnChanged("PauseChange");
    		}
    
        }
        private bool _pauseChange;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual long PauseMin
        {
            get { return _pauseMin; }
            set
    		{ 
    			_pauseMin = value;
    			OnChanged("PauseMin");
    		}
    
        }
        private long _pauseMin;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual long PauseMax
        {
            get { return _pauseMax; }
            set
    		{ 
    			_pauseMax = value;
    			OnChanged("PauseMax");
    		}
    
        }
        private long _pauseMax;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual double Speed
        {
            get { return _speed; }
            set
    		{ 
    			_speed = value;
    			OnChanged("Speed");
    		}
    
        }
        private double _speed;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual bool TeilAbspielen
        {
            get { return _teilAbspielen; }
            set
    		{ 
    			_teilAbspielen = value;
    			OnChanged("TeilAbspielen");
    		}
    
        }
        private bool _teilAbspielen;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<double> TeilStart
        {
            get { return _teilStart; }
            set
    		{ 
    			_teilStart = value;
    			OnChanged("TeilStart");
    		}
    
        }
        private Nullable<double> _teilStart;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual Nullable<double> TeilEnde
        {
            get { return _teilEnde; }
            set
    		{ 
    			_teilEnde = value;
    			OnChanged("TeilEnde");
    		}
    
        }
        private Nullable<double> _teilEnde;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual int Rating
        {
            get { return _rating; }
            set
    		{ 
    			_rating = value;
    			OnChanged("Rating");
    		}
    
        }
        private int _rating;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual double Länge
        {
            get { return _länge; }
            set
    		{ 
    			_länge = value;
    			OnChanged("Länge");
    		}
    
        }
        private double _länge;

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
        public virtual Audio_Titel Audio_Titel
        {
            get { return _audio_Titel; }
            set
            {
                if (!ReferenceEquals(_audio_Titel, value))
                {
                    var previousValue = _audio_Titel;
                    _audio_Titel = value;
                    FixupAudio_Titel(previousValue);
                }
            }
        }
        private Audio_Titel _audio_Titel;

        #endregion

        #region Association Fixup
    
        private void FixupAudio_Playlist(Audio_Playlist previousValue)
        {
    		OnChanged("Audio_Playlist");
            if (previousValue != null && previousValue.Audio_Playlist_Titel.Contains(this))
            {
                previousValue.Audio_Playlist_Titel.Remove(this);
            }
    
            if (Audio_Playlist != null)
            {
                if (!Audio_Playlist.Audio_Playlist_Titel.Contains(this))
                {
                    Audio_Playlist.Audio_Playlist_Titel.Add(this);
                }
                if (Audio_PlaylistGUID != Audio_Playlist.Audio_PlaylistGUID)
                {
                    Audio_PlaylistGUID = Audio_Playlist.Audio_PlaylistGUID;
                }
            }
        }
    
        private void FixupAudio_Titel(Audio_Titel previousValue)
        {
    		OnChanged("Audio_Titel");
            if (previousValue != null && previousValue.Audio_Playlist_Titel.Contains(this))
            {
                previousValue.Audio_Playlist_Titel.Remove(this);
            }
    
            if (Audio_Titel != null)
            {
                if (!Audio_Titel.Audio_Playlist_Titel.Contains(this))
                {
                    Audio_Titel.Audio_Playlist_Titel.Add(this);
                }
                if (Audio_TitelGUID != Audio_Titel.Audio_TitelGUID)
                {
                    Audio_TitelGUID = Audio_Titel.Audio_TitelGUID;
                }
            }
        }

        #endregion

    }
}
