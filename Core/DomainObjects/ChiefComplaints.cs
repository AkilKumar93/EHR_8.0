using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ChiefComplaints : BusinessBase<int>
    {

        #region Declarations
        private ulong _encounterid = 0;
        private ulong _humanid = 0;
        private ulong _physicianid = 0;
        //private int _groupid = 0; 
        private string _hpielement = String.Empty;
        private string _hpivalue = String.Empty;
        private string _createdby = String.Empty;
        private System.DateTime _createddatetime;
        private string _modifiedby = String.Empty;
        private System.DateTime _modifieddatetime;
        //private string _Is_Previous_Encounter_Value=string.Empty;
        private int _version = 0;

        #endregion

        #region Constructors

        public ChiefComplaints() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_humanid);
            sb.Append(_physicianid);
            sb.Append(_encounterid);
            //  sb.Append(_groupid);
            sb.Append(_hpielement);
            sb.Append(_hpielement);
            sb.Append(_createdby);
            sb.Append(_createddatetime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddatetime);
            sb.Append(_version);
            // sb.Append(_Is_Previous_Encounter_Value);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties


        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _encounterid; }
            set
            {
                _encounterid = value;
            }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _humanid; }
            set
            {
                _humanid = value;
            }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _physicianid; }
            set
            {
                _physicianid = value;
            }
        }
        [DataMember]
        public virtual string HPI_Element
        {
            get { return _hpielement; }
            set
            {
                _hpielement = value;
            }
        }
        [DataMember]
        public virtual string HPI_Value
        {
            get { return _hpivalue; }
            set
            {
                _hpivalue = value;
            }
        }

        //[DataMember]
        //public virtual int CC_Group_ID
        //{
        //    get { return _groupid; }
        //    set
        //    {
        //        _groupid = value;
        //    }
        //}


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
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set
            {
                _modifiedby = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Created_Date_And_Time
        {
            get { return _createddatetime; }
            set
            {
                _createddatetime = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Modified_Date_And_Time
        {
            get { return _modifieddatetime; }
            set
            {
                _modifieddatetime = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set
            {
                _version = value;
            }
        }
        //[DataMember]
        //public virtual string Is_Previous_Encounter_Value
        //{
        //    get { return _Is_Previous_Encounter_Value; }
        //    set
        //    {
        //        _Is_Previous_Encounter_Value = value;
        //    }
        //}

        #endregion
    }
}
