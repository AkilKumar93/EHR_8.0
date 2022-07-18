using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class FillPrintRecipt
    {
        #region Declarations

        private string _Provider_Name = string.Empty;
        private string _Facility_Name = string.Empty;
        private DateTime _Appointment_Date = DateTime.MinValue;
        private string _Last_Name = string.Empty;
        private string _Suffix = string.Empty;
        private string _First_Name = string.Empty;
        private string _MI = string.Empty;
        private DateTime _Birth_Date = DateTime.MinValue;
        private string _Street_Address = string.Empty;
        private string _City = string.Empty;
        private string _State = string.Empty;
        private string _Zipcode = string.Empty;
        private ulong _Human_ID = 0;
        private string _Insurance_Plan_Name = string.Empty;
        private string _Policy_Holder_ID = string.Empty;
        private ulong _Encounter_ID = 0;
        private string _PCP_Copay = string.Empty;
        private string _SPC_Copay = string.Empty;
        private string _Total_Deduction = string.Empty;
        private string _Deduction_Met = string.Empty;
        private string _Coinsurance = string.Empty;
        private string _PastDue = string.Empty;
        private string _Payment_Method = string.Empty;
        private string _Check_Card_No = string.Empty;
        private string _Payment_Amount = string.Empty;
        private string _Payment_Note = string.Empty;
        private DateTime _Payment_Date = DateTime.MinValue;
        private string _Refund_Amount = string.Empty;
        private string _Rec_On_Acc = string.Empty;

        private string _Amount_Paid_By = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Date_of_service = DateTime.MinValue;
        private string _Patient_Account_External = string.Empty;
        #endregion

        #region Constructor

        public FillPrintRecipt() { }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Patient_Account_External
        {
            get { return _Patient_Account_External; }
            set { _Patient_Account_External = value; }
        }




        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }



        [DataMember]
        public virtual string Amount_Paid_By
        {
            get { return _Amount_Paid_By; }
            set { _Amount_Paid_By = value; }
        }

        [DataMember]
        public virtual string Provider_Name
        {
            get { return _Provider_Name; }
            set { _Provider_Name = value; }
        }

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        [DataMember]
        public virtual DateTime Appointment_Date
        {
            get { return _Appointment_Date; }
            set { _Appointment_Date = value; }
        }

        [DataMember]
        public virtual string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }
        [DataMember]
        public virtual string Suffix
        {
            get { return _Suffix; }
            set { _Suffix = value; }
        }
        [DataMember]
        public virtual string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        [DataMember]
        public virtual string MI
        {
            get { return _MI; }
            set { _MI = value; }
        }
        [DataMember]
        public virtual DateTime Birth_Date
        {
            get { return _Birth_Date; }
            set { _Birth_Date = value; }
        }
        [DataMember]
        public virtual string Street_Address
        {
            get { return _Street_Address; }
            set { _Street_Address = value; }
        }
        [DataMember]
        public virtual string City
        {
            get { return _City; }
            set { _City = value; }
        }
        [DataMember]
        public virtual string State
        {
            get { return _State; }
            set { _State = value; }
        }
        [DataMember]
        public virtual string Zipcode
        {
            get { return _Zipcode; }
            set { _Zipcode = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Insurance_Plan_Name
        {
            get { return _Insurance_Plan_Name; }
            set { _Insurance_Plan_Name = value; }
        }
        [DataMember]
        public virtual string Policy_Holder_ID
        {
            get { return _Policy_Holder_ID; }
            set { _Policy_Holder_ID = value; }
        }
        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual string PCP_Copay
        {
            get { return _PCP_Copay; }
            set { _PCP_Copay = value; }
        }

        [DataMember]
        public virtual string SPC_Copay
        {
            get { return _SPC_Copay; }
            set { _SPC_Copay = value; }
        }

        [DataMember]
        public virtual string Total_Deduction
        {
            get { return _Total_Deduction; }
            set { _Total_Deduction = value; }
        }

        [DataMember]
        public virtual string Deduction_Met
        {
            get { return _Deduction_Met; }
            set { _Deduction_Met = value; }
        }

        [DataMember]
        public virtual string Coinsurance
        {
            get { return _Coinsurance; }
            set { _Coinsurance = value; }
        }
        [DataMember]
        public virtual string PastDue
        {
            get { return _PastDue; }
            set { _PastDue = value; }
        }
        [DataMember]
        public virtual string Payment_Method
        {
            get { return _Payment_Method; }
            set { _Payment_Method = value; }
        }
        [DataMember]
        public virtual string Check_Card_No
        {
            get { return _Check_Card_No; }
            set { _Check_Card_No = value; }
        }

        [DataMember]
        public virtual string Payment_Amount
        {
            get { return _Payment_Amount; }
            set { _Payment_Amount = value; }
        }
        [DataMember]
        public virtual string Payment_Note
        {
            get { return _Payment_Note; }
            set { _Payment_Note = value; }
        }
        [DataMember]
        public virtual DateTime Payment_Date
        {
            get { return _Payment_Date; }
            set { _Payment_Date = value; }
        }
        [DataMember]
        public virtual string Refund_Amount
        {
            get { return _Refund_Amount; }
            set { _Refund_Amount = value; }
        }
        [DataMember]
        public virtual string Rec_On_Acc
        {
            get { return _Rec_On_Acc; }
            set { _Rec_On_Acc = value; }
        }
        [DataMember]
        public virtual DateTime Date_of_service
        {
            get { return _Date_of_service; }
            set { _Date_of_service = value; }
        }
        #endregion
    }
}
