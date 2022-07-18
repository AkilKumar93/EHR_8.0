using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ROS : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _encounterid = 0;
        private ulong _humanid = 0;
        private ulong _physicianid = 0;
        private string _systemname = String.Empty;
        private string _symptomname = String.Empty;
        //private string _notes = String.Empty;
        private string _createdby = String.Empty;
        private DateTime _createddateandtime = DateTime.MinValue;
        private string _modifiedby = string.Empty;
        private DateTime _modifieddateandtime = DateTime.MinValue;
        private int _version = 0;
        private string _status = string.Empty;

        #endregion

        #region Constructors

        public ROS() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_encounterid);
            sb.Append(_humanid);
            sb.Append(_physicianid);
            sb.Append(_systemname);
            sb.Append(_symptomname);
            //sb.Append(_notes);
            sb.Append(_createdby);
            sb.Append(_createddateandtime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddateandtime);
            sb.Append(_version);
            sb.Append(_status);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual ulong Encounter_Id
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
        public virtual ulong Physician_Id
        {
            get { return _physicianid; }
            set
            {
                _physicianid = value;
            }
        }
        [DataMember]
        public virtual string System_Name
        {
            get { return _systemname; }
            set
            {
                _systemname = value;
            }
        }
        //[DataMember]
        //public virtual string Notes
        //{
        //    get { return _notes; }
        //    set
        //    {
        //        _notes = value;
        //    }
        //}
        [DataMember]
        public virtual string Symptom_Name
        {
            get { return _symptomname; }
            set
            {
                _symptomname = value;
            }
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
            set
            {
                _modifiedby = value;
            }
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
            get { return _version; }
            set
            {
                _version = value;
            }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }
        #endregion
    }
}
