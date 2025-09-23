using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Human_Address : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private string _Street_Address1 = string.Empty;
        private string _Street_Address2 = string.Empty;
        private string _City = string.Empty;
        private string _State = string.Empty;
        private string _ZipCode = string.Empty;
        private string _Start_Date = string.Empty;
        private string _End_Date = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time;
        private int _version = 0;
        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Street_Address1);
            sb.Append(_Street_Address2);
            sb.Append(_City);
            sb.Append(_State);
            sb.Append(_ZipCode);
            sb.Append(_Start_Date);
            sb.Append(_End_Date);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            return sb.ToString().GetHashCode();
        }
        #endregion


        # region Properties
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        

        [DataMember]
        public virtual string Street_Address1
        {
            get { return _Street_Address1; }
            set
            {
                _Street_Address1 = value;
            }
        }
        [DataMember]
        public virtual string Street_Address2
        {
            get { return _Street_Address2; }
            set
            {
                _Street_Address2 = value;
            }
        }
        [DataMember]
        public virtual string City
        {
            get { return _City; }
            set
            {
                _City = value;
            }
        }
        [DataMember]
        public virtual string State
        {
            get { return _State; }
            set
            {
                _State = value;
            }
        }
        [DataMember]
        public virtual string ZipCode
        {
            get { return _ZipCode; }
            set
            {
                _ZipCode = value;
            }
        }
        [DataMember]
        public virtual string Start_Date
        {
            get { return _Start_Date; }
            set
            {
                _Start_Date = value;
            }
        }
        [DataMember]
        public virtual string End_Date
        {
            get { return _End_Date; }
            set
            {
                _End_Date = value;
            }
        }
        
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
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
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        #endregion
    }
}
