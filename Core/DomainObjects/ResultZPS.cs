using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ResultZPS : BusinessBase<ulong>
    {
        #region Declarations

        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;
        private string _ZPS_Segment_Type_ID = string.Empty;
        private string _ZPS_Sequence_Number = string.Empty;
        private string _ZPS_Facility_Mnemonic = string.Empty;
        private string _ZPS_Facility_Name = string.Empty;
        private string _ZPS_Facility_Address = string.Empty;
        private string _ZPS_Facility_Other_Designation = string.Empty;
        private string _ZPS_Facility_City = string.Empty;
        private string _ZPS_Facility_State = string.Empty;
        private string _ZPS_Facility_Zip = string.Empty;
        private string _ZPS_Facility_Phone_Number = string.Empty;
        private string _ZPS_Facility_Contact = string.Empty;
        private string _ZPS_Facility_Director_Title = string.Empty;
        private string _ZPS_Facility_Director_Last_Name = string.Empty;
        private string _ZPS_Facility_Director_First_Name = string.Empty;
        private string _ZPS_Facility_Director_Middle_Initial = string.Empty;
        private string _ZPS_Facility_Director_Suffix = string.Empty;
        private string _ZPS_Facility_Director_Prefix = string.Empty;
        private string _ZPS_Facility_Director_Degree = string.Empty;
        #endregion

        #region Constructors

        public ResultZPS() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Version);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Result_Master_ID);
            sb.Append(_ZPS_Segment_Type_ID);
            sb.Append(_ZPS_Sequence_Number);
            sb.Append(_ZPS_Facility_Mnemonic);
            sb.Append(_ZPS_Facility_Name);
            sb.Append(_ZPS_Facility_Address);
            sb.Append(_ZPS_Facility_Other_Designation);
            sb.Append(_ZPS_Facility_City);
            sb.Append(_ZPS_Facility_State);
            sb.Append(_ZPS_Facility_Zip);
            sb.Append(_ZPS_Facility_Phone_Number);
            sb.Append(_ZPS_Facility_Contact);
            sb.Append(_ZPS_Facility_Director_Title);
            sb.Append(_ZPS_Facility_Director_Last_Name);
            sb.Append(_ZPS_Facility_Director_First_Name);
            sb.Append(_ZPS_Facility_Director_Middle_Initial);
            sb.Append(_ZPS_Facility_Director_Suffix);
            sb.Append(_ZPS_Facility_Director_Prefix);
            sb.Append(_ZPS_Facility_Director_Degree);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
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
            set { _Created_Date_And_Time = value; }
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
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }
        [DataMember]
        public virtual string ZPS_Segment_Type_ID
        {
            get { return _ZPS_Segment_Type_ID; }
            set { _ZPS_Segment_Type_ID = value; }
        }
        [DataMember]
        public virtual string ZPS_Sequence_Number
        {
            get
            { return _ZPS_Sequence_Number; }
            set { _ZPS_Sequence_Number = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Mnemonic
        {
            get { return _ZPS_Facility_Mnemonic; }
            set { _ZPS_Facility_Mnemonic = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Name
        {
            get { return _ZPS_Facility_Name; }
            set { _ZPS_Facility_Name = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Address
        {
            get { return _ZPS_Facility_Address; }
            set { _ZPS_Facility_Address = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Other_Designation
        {
            get { return _ZPS_Facility_Other_Designation; }
            set { _ZPS_Facility_Other_Designation = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_City
        {
            get { return _ZPS_Facility_City; }
            set { _ZPS_Facility_City = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_State
        {
            get { return _ZPS_Facility_State; }
            set { _ZPS_Facility_State = value; }

        }
        [DataMember]
        public virtual string ZPS_Facility_Zip
        {
            get { return _ZPS_Facility_Zip; }
            set { _ZPS_Facility_Zip = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Phone_Number
        {
            get { return _ZPS_Facility_Phone_Number; }
            set { _ZPS_Facility_Phone_Number = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Contact
        {
            get { return _ZPS_Facility_Contact; }
            set { _ZPS_Facility_Contact = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_Title
        {
            get { return _ZPS_Facility_Director_Title; }
            set { _ZPS_Facility_Director_Title = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_Last_Name
        {
            get { return _ZPS_Facility_Director_Last_Name; }
            set { _ZPS_Facility_Director_Last_Name = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_First_Name
        {
            get { return _ZPS_Facility_Director_First_Name; }
            set { _ZPS_Facility_Director_First_Name = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_Middle_Initial
        {
            get { return _ZPS_Facility_Director_Middle_Initial; }
            set { _ZPS_Facility_Director_Middle_Initial = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_Suffix
        {
            get { return _ZPS_Facility_Director_Suffix; }
            set { _ZPS_Facility_Director_Suffix = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_Prefix
        {
            get { return _ZPS_Facility_Director_Prefix; }
            set { _ZPS_Facility_Director_Prefix = value; }
        }
        [DataMember]
        public virtual string ZPS_Facility_Director_Degree
        {
            get { return _ZPS_Facility_Director_Degree; }
            set { _ZPS_Facility_Director_Degree = value; }
        }
        #endregion
    }
}
