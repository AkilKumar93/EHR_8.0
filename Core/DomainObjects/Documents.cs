using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial  class Documents:BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Encounter_ID =0;
        private ulong _Human_ID=0;
        private ulong _Physician_ID = 0;
        private string _Document_Type = string.Empty;
        private string _Document_Sub_Type = string.Empty;
        private string _Relationship=string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Given_To=string.Empty ;
        private string _Given_By=string.Empty;
        private DateTime _Given_Date=DateTime.MinValue;
        private int _Version=0;
     
        #endregion

        #region Constructors

        public Documents() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Document_Type);
            sb.Append(_Document_Sub_Type);
            sb.Append(_Relationship);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Given_To);
            sb.Append(_Given_By);
            sb.Append(_Given_Date);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
            }
        }
        [DataMember]
        public virtual string Document_Type
        {
            get { return _Document_Type; }
            set
            {
                _Document_Type = value;
            }
        }
        [DataMember]
        public virtual string Document_Sub_Type
        {
            get { return _Document_Sub_Type; }
            set
            {
                _Document_Sub_Type = value;
            }
        }
        [DataMember]
        public virtual string Relationship
        {
            get { return _Relationship; }
            set
            {
                _Relationship = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Given_To
        {
            get { return _Given_To; }
            set
            {
                _Given_To = value;
            }
        }
        [DataMember]
        public virtual string Given_By
        {
            get { return _Given_By; }
            set
            {
                _Given_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Given_Date
        {
            get { return _Given_Date; }
            set
            {
                _Given_Date = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
       
        #endregion
    }
}
