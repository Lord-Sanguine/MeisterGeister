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
    public partial class NscMerkmal : INotifyPropertyChanged
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
        public virtual long NscMerkmalId
        {
            get { return _nscMerkmalId; }
            set
    		{ 
    			_nscMerkmalId = value;
    			OnChanged("NscMerkmalId");
    		}
    
        }
        private long _nscMerkmalId;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Kategorie
        {
            get { return _kategorie; }
            set
    		{ 
    			_kategorie = value;
    			OnChanged("Kategorie");
    		}
    
        }
        private string _kategorie;
    	///<summary>Database persistent property</summary>
    	[DataMember]
        public virtual string Merkmal
        {
            get { return _merkmal; }
            set
    		{ 
    			_merkmal = value;
    			OnChanged("Merkmal");
    		}
    
        }
        private string _merkmal;

        #endregion
    }
}
