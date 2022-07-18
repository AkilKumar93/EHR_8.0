using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ReferralOrder:BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Encounter_ID = 0;
        private ulong _From_Physician_ID = 0;
        private DateTime _Referral_Date = DateTime.MinValue;
        private string _Service_Requested = string.Empty;
        private string _Referral_Notes = string.Empty;
        private string _To_Physician_Name = string.Empty;
        private string _To_Facility_Name = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version=0;
        private string _Authorization_Required = string.Empty;
        private ulong _Human_ID = 0;
        private int _Number_of_Visit = 0;
        private string _Special_Needs = string.Empty;
        private string _Reason_For_Referral = string.Empty;
        private string _Referral_Specialty = string.Empty;
        private string _To_Facility_Street_Address = string.Empty;
        private string _To_Facility_City = string.Empty;
        private string _To_Facility_State = string.Empty;
        private string _To_Facility_Zip = string.Empty;
        private string _To_Facility_Phone_Number = string.Empty;
        private string _To_Facility_Fax_Number = string.Empty;
        private ulong _Referral_Order_Group_ID = 0;
        private string _Move_To_MA = string.Empty;
        private DateTime _Valid_Till= DateTime.MinValue;
        private string _Authorization_Number = string.Empty;
        private DateTime _Internal_Property_Date_of_service = DateTime.MinValue;
        private string _From_Facility = string.Empty;

        #endregion


       #region Constructors

        public ReferralOrder() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_From_Physician_ID);
            sb.Append(_Referral_Date);
            sb.Append(_Service_Requested);
            sb.Append(_Referral_Notes);
            sb.Append(_To_Physician_Name);
            sb.Append(_To_Facility_Name);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Authorization_Required);
            sb.Append(_Human_ID);
            sb.Append(_Number_of_Visit);
            sb.Append(_Special_Needs);
            sb.Append(_Reason_For_Referral);
            sb.Append(_Referral_Specialty);
            sb.Append(_To_Facility_Street_Address);
            sb.Append(_To_Facility_City);
            sb.Append(_To_Facility_Fax_Number);
            sb.Append(_To_Facility_Phone_Number);
            sb.Append(_To_Facility_State);
            sb.Append(_To_Facility_Zip);
            sb.Append(_Referral_Order_Group_ID);
            sb.Append(_Move_To_MA);
            sb.Append(_Valid_Till);
            sb.Append(_Authorization_Number);
            sb.Append(_Internal_Property_Date_of_service);
            sb.Append(_From_Facility);            
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual ulong From_Physician_ID
        {
            get { return _From_Physician_ID; }
            set { _From_Physician_ID = value; }
        }
          

        [DataMember]
        public virtual DateTime Referral_Date
        {
            get { return _Referral_Date; }
            set { _Referral_Date = value; }
        }
        [DataMember]
        public virtual string Service_Requested
        {
            get { return _Service_Requested; }
            set { _Service_Requested = value; }
        }
        
        [DataMember]
        public virtual string Referral_Notes
        {
            get { return _Referral_Notes; }
            set { _Referral_Notes = value; }
        }


        [DataMember]
        public virtual string To_Physician_Name
        {
            get { return _To_Physician_Name; }
            set { _To_Physician_Name = value; }
        }

        [DataMember]
        public virtual string To_Facility_Name
        {
            get { return _To_Facility_Name; }
            set { _To_Facility_Name = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }


        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
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
        public virtual string Authorization_Required
        {
            get { return _Authorization_Required; }
            set { _Authorization_Required = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual int Number_of_Visit
        {
            get { return _Number_of_Visit; }
            set { _Number_of_Visit = value; }
        }

        [DataMember]
        public virtual string Special_Needs
        {
            get { return _Special_Needs; }
            set { _Special_Needs = value; }
        }

        [DataMember]
        public virtual string Reason_For_Referral
        {
            get { return _Reason_For_Referral; }
            set { _Reason_For_Referral = value; }
        }

        [DataMember]
        public virtual string Referral_Specialty
        {
            get { return _Referral_Specialty; }
            set { _Referral_Specialty = value; }
        }

        [DataMember]
        public virtual string To_Facility_Street_Address
        {
            get { return _To_Facility_Street_Address; }
            set { _To_Facility_Street_Address = value; }
        }
        [DataMember]
        public virtual string To_Facility_City
        {
            get { return _To_Facility_City; }
            set { _To_Facility_City = value; }
        }
        [DataMember]
        public virtual string To_Facility_State
        {
            get { return _To_Facility_State; }
            set { _To_Facility_State = value; }
        }
        [DataMember]
        public virtual string To_Facility_Zip
        {
            get { return _To_Facility_Zip; }
            set { _To_Facility_Zip = value; }
        }
        [DataMember]
        public virtual string To_Facility_Phone_Number
        {
            get { return _To_Facility_Phone_Number; }
            set { _To_Facility_Phone_Number = value; }
        }
        [DataMember]
        public virtual string To_Facility_Fax_Number
        {
            get { return _To_Facility_Fax_Number; }
            set { _To_Facility_Fax_Number = value; }
        }
        [DataMember]
        public virtual ulong Referral_Order_Group_ID
        {
            get { return _Referral_Order_Group_ID; }
            set { _Referral_Order_Group_ID = value; }
        }
        [DataMember]
        public virtual string Move_To_MA
        {
            get { return _Move_To_MA; }
            set { _Move_To_MA = value; }
        }
        
        [DataMember]
        public virtual DateTime Valid_Till
        {
            get { return _Valid_Till; }
            set { _Valid_Till = value; }
        }
         [DataMember]
        public virtual string Authorization_Number
        {
            get { return _Authorization_Number; }
            set { _Authorization_Number = value; }
        }
         [DataMember]
         public virtual DateTime Internal_Property_Date_of_service
         {
             get { return _Internal_Property_Date_of_service; }
             set { _Internal_Property_Date_of_service = value; }
         }

        [DataMember]
         public virtual string From_Facility
        {
            get { return _From_Facility; }
            set { _From_Facility = value; }
        }
        
        #endregion
       
    }
}
