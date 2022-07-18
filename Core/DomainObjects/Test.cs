using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Test : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _encounterid=0;
        private ulong _Human_ID=0;
        private ulong _physicianid=0;
        private string _Test_Name = string.Empty;
        private string _Question_Name = string.Empty;
        private string _status = string.Empty;
        private string _testnotes = string.Empty;
        private string _createdby = string.Empty;
        private DateTime _createddateandtime;
        private string _modifiedby = string.Empty;
        private DateTime _modifieddateandtime;
        private ulong _test_Lookup_Id=0;
        private int _version = 0;
        private string _Category = string.Empty;
        private string _Score = string.Empty;
        #endregion
       
        #region Constructors

        public Test() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_encounterid);
            sb.Append(_Human_ID);
            sb.Append(_physicianid);
            sb.Append(_Test_Name = string.Empty);
            sb.Append(_Question_Name = string.Empty);
            sb.Append(_status = string.Empty);
            sb.Append(_testnotes = string.Empty);
            sb.Append(_createdby = string.Empty);
            sb.Append(_createddateandtime);
            sb.Append(_modifiedby = string.Empty);
            sb.Append(_modifieddateandtime);
            sb.Append(_test_Lookup_Id);
            sb.Append(_version);
            sb.Append(_Category);
            sb.Append(_Score);
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
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
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
        public virtual string Test_Name
        {
            get { return _Test_Name; }
            set
            {
                _Test_Name = value;
            }
        }
        [DataMember]
        public virtual string Question_Name
        {
            get { return _Question_Name; }
            set
            {
                _Question_Name = value;
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
        [DataMember]
        public virtual string Test_Notes
        {
            get { return _testnotes; }
            set
            {
                _testnotes = value;
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
        public virtual ulong Test_Lookup_Id
        {
            get { return _test_Lookup_Id; }
            set
            {
                _test_Lookup_Id = value;
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
        [DataMember]
        public virtual string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        [DataMember]
        public virtual string Score
        {
            get
            {
                return _Score;
            }
            set
            {
                _Score = value;
            }
        }

        #endregion
    }
}
