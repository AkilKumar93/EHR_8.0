using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
   public partial class Blockdays:BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Physician_ID = 0;
        private string _Facility_Name = string.Empty;
        private DateTime _Block_Date = DateTime.MinValue;
        private string _Reason = string.Empty;
        private string _From_Time = string.Empty;
        private string _To_Time = string.Empty;
        private DateTime _From_Date_Choosen = DateTime.MinValue;
        private DateTime _To_Date_Choosen = DateTime.MinValue;
        private string _Day_Choosen = string.Empty;
        private string _Block_Type = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private ulong _Blockdays_Group_ID=0;
        private string _Is_Delete = string.Empty;
        private string _Is_Alternate_Weeks = string.Empty;
        private string _Is_Alternate_Months = string.Empty;
        private ulong _Machine_Technician_Library_ID = 0;

        #endregion

        #region Constructors

        public Blockdays() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Physician_ID);
            sb.Append(_Facility_Name);
            sb.Append(_Block_Date);
            sb.Append(_From_Time);
            sb.Append(_To_Time);
            sb.Append(_From_Date_Choosen);
            sb.Append(_To_Date_Choosen);
            sb.Append(_Day_Choosen);
            sb.Append(_Block_Type);
            sb.Append(_Created_By);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Is_Delete);
            sb.Append(_Is_Alternate_Weeks);
            sb.Append(_Is_Alternate_Months);
            sb.Append(_Machine_Technician_Library_ID);
            
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
       
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
       
        [DataMember]
        public virtual DateTime Block_Date
        {
            get { return _Block_Date; }
            set { _Block_Date = value; }
        }
        [DataMember]
        public virtual string From_Time
        {
            get { return _From_Time; }
            set { _From_Time = value; }
        }
        [DataMember]
        public virtual string To_Time
        {
            get { return _To_Time; }
            set { _To_Time = value; }

        }
        [DataMember]
        public virtual string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }

        }
        [DataMember]
        public virtual DateTime From_Date_Choosen
        {
            get { return _From_Date_Choosen; }
            set { _From_Date_Choosen = value; }
        }
        [DataMember]
        public virtual DateTime To_Date_Choosen
        {
            get { return _To_Date_Choosen; }
            set { _To_Date_Choosen = value; }
        }
        [DataMember]
        public virtual string Day_Choosen
        {
            get { return _Day_Choosen; }
            set { _Day_Choosen = value; }
        }
        [DataMember]
        public virtual string Block_Type
        {
            get { return _Block_Type; }
            set { _Block_Type = value; }
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
            get { return _Created_Date; }
            set { _Created_Date = value; }
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
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual ulong Blockdays_Group_ID
        {
            get { return _Blockdays_Group_ID; }
            set { _Blockdays_Group_ID = value; }
        }
        [DataMember]
        public virtual string Is_Delete
        {
            get { return _Is_Delete; }
            set { _Is_Delete = value; }
        }
        [DataMember]
        public virtual string Is_Alternate_Weeks
        {
            get { return _Is_Alternate_Weeks; }
            set { _Is_Alternate_Weeks = value; }
        }
        [DataMember]
        public virtual string Is_Alternate_Months
        {
            get { return _Is_Alternate_Months; }
            set { _Is_Alternate_Months = value; }
        }
         [DataMember]
        public virtual ulong Machine_Technician_Library_ID
        {
            get { return _Machine_Technician_Library_ID; }
            set { _Machine_Technician_Library_ID = value; }
        }
        #endregion
    }
}
