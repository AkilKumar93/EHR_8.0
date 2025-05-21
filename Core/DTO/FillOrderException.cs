using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class FillOrderException
    {
        ulong _HumanId = 0;
        string _Last_Name_In_Result = string.Empty;
        string _First_Name_In_Result = string.Empty;
        string _MI_In_Result = string.Empty;
        string _Sex_In_Result = string.Empty;
        string _SSN = string.Empty;
        string _Lab_Procedure = string.Empty;
        string _Provider_Name = string.Empty;
        string _Reason_Code = string.Empty;
        string _Reason_Description = string.Empty;
        bool _IsTotalCount = false;
        int _TotalCount = 0;
        ulong _Result_Master_ID = 0;
        ulong _Order_ID = 0;
        ulong _Order_Submit_ID = 0;
        DateTime _DOB_In_Result = new DateTime();
        DateTime _Order_Date = new DateTime();
        string _Patient_Name_In_Result = string.Empty;
        string _Lab_Name = string.Empty;
        string _Lab_Location_Name = string.Empty;
        string _Lab_ID = string.Empty;

        string _Patient_Name_In_Capella = string.Empty;
        string _Last_Name_In_Capella = string.Empty;
        string _First_Name_In_Capella = string.Empty;
        string _MI_In_Capella = string.Empty;
        string _Sex_In_Capella = string.Empty;
        ulong _Human_Id_In_Capella = 0;
        string _Result_Received_Date_And_Time = string.Empty;

        DateTime _DOB_In_Capella = new DateTime();

        private IList<Orders> _lstOrders = new List<Orders>();
        ulong _Matching_Patient_ID = 0;
        string _Specimen = string.Empty;
        string _Ordering_Provider_NPI = string.Empty;
        string _Is_Abnormal = string.Empty;
        //CAP-3207
        string _Patient_Account_External = string.Empty;
        string _Human_Type = string.Empty;
        string _Home_Phone_No = string.Empty;
        string _Street_Address1 = string.Empty;

        [DataMember]
        public virtual bool IsTotalCount
        {
            get { return _IsTotalCount; }
            set { _IsTotalCount = value; }
        }
        [DataMember]
        public virtual int TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; }
        }

        [DataMember]
        public virtual string Provider_Name
        {
            get { return _Provider_Name; }
            set { _Provider_Name = value; }
        }
        [DataMember]
        public virtual string Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        [DataMember]
        public virtual string Patient_Name_In_Result
        {
            get { return _Patient_Name_In_Result; }
            set { _Patient_Name_In_Result = value; }
        }
        [DataMember]
        public virtual string Patient_Name_In_Capella
        {
            get { return _Patient_Name_In_Capella; }
            set { _Patient_Name_In_Capella = value; }
        }
        [DataMember]
        public virtual string Lab_Name
        {
            get { return _Lab_Name; }
            set { _Lab_Name = value; }
        }
        [DataMember]
        public virtual string Lab_Location_Name
        {
            get { return _Lab_Location_Name; }
            set { _Lab_Location_Name = value; }
        }
        [DataMember]
        public virtual string Last_Name_In_Result
        {
            get { return _Last_Name_In_Result; }
            set { _Last_Name_In_Result = value; }
        }
        [DataMember]
        public virtual string Last_Name_In_Capella
        {
            get { return _Last_Name_In_Capella; }
            set { _Last_Name_In_Capella = value; }
        }
        [DataMember]
        public virtual string First_Name_In_Result
        {
            get { return _First_Name_In_Result; }
            set { _First_Name_In_Result = value; }
        }
        [DataMember]
        public virtual string First_Name_In_Capella
        {
            get { return _First_Name_In_Capella; }
            set { _First_Name_In_Capella = value; }
        }
        [DataMember]
        public virtual string MI_In_Result
        {
            get { return _MI_In_Result; }
            set { _MI_In_Result = value; }
        }
        [DataMember]
        public virtual string MI_In_Capella
        {
            get { return _MI_In_Capella; }
            set { _MI_In_Capella = value; }
        }
        [DataMember]
        public virtual string Sex_In_Result
        {
            get { return _Sex_In_Result; }
            set { _Sex_In_Result = value; }
        }
        [DataMember]
        public virtual string Sex_In_Capella
        {
            get { return _Sex_In_Capella; }
            set { _Sex_In_Capella = value; }
        }
        [DataMember]
        public virtual string SSN
        {
            get { return _SSN; }
            set { _SSN = value; }
        }
        [DataMember]
        public virtual string Lab_Procedure
        {
            get { return _Lab_Procedure; }
            set { _Lab_Procedure = value; }
        }
        [DataMember]
        public virtual string Reason_Code
        {
            get { return _Reason_Code; }
            set { _Reason_Code = value; }
        }
        [DataMember]
        public virtual string Reason_Description
        {
            get { return _Reason_Description; }
            set { _Reason_Description = value; }
        }
        [DataMember]
        public ulong HumanId
        {
            get { return _HumanId; }
            set { _HumanId = value; }
        }
        [DataMember]
        public DateTime DOB_In_Result
        {
            get { return _DOB_In_Result; }
            set { _DOB_In_Result = value; }
        }
        [DataMember]
        public DateTime DOB_In_Capella
        {
            get { return _DOB_In_Capella; }
            set { _DOB_In_Capella = value; }
        }


        [DataMember]
        public ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }
        [DataMember]
        public ulong Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }
        [DataMember]
        public ulong Order_Submit_ID
        {
            get { return _Order_Submit_ID; }
            set { _Order_Submit_ID = value; }
        }
        [DataMember]
        public DateTime Order_Date
        {
            get { return _Order_Date; }
            set { _Order_Date = value; }
        }
        [DataMember]
        public ulong Human_Id_In_Capella
        {
            get { return _Human_Id_In_Capella; }
            set { _Human_Id_In_Capella = value; }
        }
        [DataMember]
        public string Result_Received_Date_And_Time
        {
            get { return _Result_Received_Date_And_Time; }
            set { _Result_Received_Date_And_Time = value; }
        }

        [DataMember]
        public virtual IList<Orders> OrdersList
        {
            get { return _lstOrders; }
            set { _lstOrders = value; }
        }

        [DataMember]
        public ulong Matching_Patient_ID
        {
            get { return _Matching_Patient_ID; }
            set { _Matching_Patient_ID = value; }
        }

        [DataMember]
        public string Specimen
        {
            get { return _Specimen; }
            set { _Specimen = value; }
        }
        [DataMember]
        public string OrderingProviderNPI
        {
            get { return _Ordering_Provider_NPI; }
            set { _Ordering_Provider_NPI = value; }
        }

        [DataMember]
        public string Is_Abnormal
        {
            get { return _Is_Abnormal; }
            set { _Is_Abnormal = value; }
        }

        [DataMember]
        public virtual string Patient_Account_External
        {
            get { return _Patient_Account_External; }
            set { _Patient_Account_External = value; }
        }
        [DataMember]
        public virtual string Human_Type
        {
            get { return _Human_Type; }
            set { _Human_Type = value; }
        }
        [DataMember]
        public virtual string Home_Phone_No
        {
            get { return _Home_Phone_No; }
            set { _Home_Phone_No = value; }
        }
        [DataMember]
        public virtual string Street_Address1
        {
            get { return _Street_Address1; }
            set { _Street_Address1 = value; }
        }

    }
}
