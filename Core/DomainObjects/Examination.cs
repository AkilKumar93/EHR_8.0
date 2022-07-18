using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Examination : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _encounterid = 0;
        private ulong _Human_ID = 0;
        private ulong _physicianid = 0;
        private string _System_Name = string.Empty;  
      //  private string _Examination_Details = string.Empty;
        private string _Condition_Name = string.Empty;
        private string _status = string.Empty;
        private string _Examination_Notes = string.Empty;
        private string _createdby = string.Empty;
        private DateTime _createddateandtime;
        private string _modifiedby = string.Empty;
        private DateTime _modifieddateandtime;
        private ulong _Exam_Lookup_Id = 0;
        private int _version = 0;
        private string _Category = string.Empty;
        private string _Short_Description = string.Empty;
        #endregion

        #region Constructors

        public Examination() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_encounterid);
            sb.Append(_Human_ID);
            sb.Append(_physicianid);
         
           // sb.Append(_Examination_Details);
            sb.Append(_createdby);
            sb.Append(_Condition_Name = string.Empty);
            sb.Append(_status = string.Empty);
            sb.Append(_Examination_Notes = string.Empty);
            sb.Append(_createdby = string.Empty);
            sb.Append(_createddateandtime);
            sb.Append(_modifieddateandtime);
            sb.Append(_Exam_Lookup_Id);
            sb.Append(_version);
            sb.Append(_Category);
            sb.Append(_Short_Description);
            sb.Append(_System_Name);
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
        public virtual string System_Name
        {
            get { return _System_Name; }
            set
            {
                _System_Name = value;
            }
        }
        [DataMember]
        //public virtual string Examination_Details
        //{
        //    get { return _Examination_Details; }
        //    set
        //    {
        //        _Examination_Details = value;
        //    }
        //}
        //[DataMember]
        public virtual string Condition_Name
        {
            get { return _Condition_Name; }
            set
            {
                _Condition_Name = value;
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
        public virtual string Examination_Notes
        {
            get { return _Examination_Notes; }
            set
            {
                _Examination_Notes = value;
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
        public virtual ulong Exam_Lookup_Id
        {
            get { return _Exam_Lookup_Id; }
            set
            {
                _Exam_Lookup_Id = value;
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
        public virtual string Short_Description
        {
            get
            {
                return _Short_Description;
            }
            set
            {
                _Short_Description = value;
            }
        }
        #endregion



    }
}