using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Human_Blob : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private byte[] _Human_XML = null;
        private string _createdby = string.Empty;
        private DateTime _createddateandtime;
        private string _modifiedby = string.Empty;
        private DateTime _modifieddateandtime;
        private int _version = 0;
        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Human_ID);
            sb.Append(_Human_XML);
            sb.Append(_createdby = string.Empty);
            sb.Append(_createddateandtime);
            sb.Append(_modifiedby = string.Empty);
            sb.Append(_modifieddateandtime);
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
        public virtual byte[] Human_XML
        {
            get { return _Human_XML; }
            set { _Human_XML = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _createdby; }
            set
            {
                _createdby = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _createddateandtime; }
            set
            {
                _createddateandtime = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _modifieddateandtime; }
            set
            {
                _modifieddateandtime = value;
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
