using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class SuperBillDTO
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private string _Patient_Name = string.Empty;
        private string _Patient_DOB = string.Empty;
        private string _Patient_Sex = string.Empty;
        private string _Patient_Address = string.Empty;
        private string _Patient_City = string.Empty;
        private string _Patient_State = string.Empty;
        private string _Patient_ZipCode = string.Empty;
        private string _Patient_HomePhoneNo = string.Empty;
        private string _SSN = string.Empty;
        private string _Referring_Prov_Name = string.Empty;
        private string _Appt_Prov_Name = string.Empty;
        private string _Appt_Prov_ID = string.Empty;
        private string _Pri_Ins_Name = string.Empty;
        private decimal _Pri_Copay = 0;
        private string _Pri_Member_ID = string.Empty;
        private string _Sec_Ins_Name = string.Empty;
        private decimal _Sec_Copay = 0;
        private string _Sec_Member_ID = string.Empty;
        private string _Appt_Date = string.Empty;
        private string _Appt_Time = string.Empty;
        private string _Appt_Facility = string.Empty;
        private string _App_Length = string.Empty;
        private string _Reason = string.Empty;
        private decimal _Acc_Balance = 0;
        private decimal _Patient_Due = 0;
        private ulong _Voucher_No = 0;
        private string _Auth_No = string.Empty;
        private string _Account_Type = string.Empty;        
        
        #endregion

        #region Constructor

        public SuperBillDTO()
        {

        }
        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Patient_Name
        {
            get { return _Patient_Name; }
            set { _Patient_Name = value; }
        }
        [DataMember]
        public virtual string Patient_DOB
        {
            get { return _Patient_DOB; }
            set { _Patient_DOB = value; }
        }
        [DataMember]
        public virtual string Patient_Sex
        {
            get { return _Patient_Sex; }
            set { _Patient_Sex = value; }
        }
        [DataMember]
        public virtual string Patient_Address
        {
            get { return _Patient_Address; }
            set { _Patient_Address = value; }
        }
        [DataMember]
        public virtual string Patient_City
        {
            get { return _Patient_City; }
            set { _Patient_City = value; }
        }
        [DataMember]
        public virtual string Patient_State
        {
            get { return _Patient_State; }
            set { _Patient_State = value; }
        }
        [DataMember]
        public virtual string Patient_ZipCode
        {
            get { return _Patient_ZipCode; }
            set { _Patient_ZipCode = value; }
        }
        [DataMember]
        public virtual string Patient_HomePhoneNo
        {
            get { return _Patient_HomePhoneNo; }
            set { _Patient_HomePhoneNo = value; }
        }
        [DataMember]
        public virtual string SSN
        {
            get { return _SSN; }
            set { _SSN = value; }
        }
        [DataMember]
        public virtual string Referring_Prov_Name
        {
            get { return _Referring_Prov_Name; }
            set { _Referring_Prov_Name = value; }
        }
        [DataMember]
        public virtual string Appt_Prov_Name
        {
            get { return _Appt_Prov_Name; }
            set { _Appt_Prov_Name = value; }
        }
        [DataMember]
        public virtual string Appt_Prov_ID
        {
            get { return _Appt_Prov_ID ; }
            set { _Appt_Prov_ID = value; }
        }
        [DataMember]
        public virtual string Pri_Ins_Name
        {
            get { return _Pri_Ins_Name; }
            set { _Pri_Ins_Name = value; }
        }
        [DataMember]
        public virtual decimal Pri_Copay
        {
            get { return _Pri_Copay; }
            set { _Pri_Copay = value; }
        }
        [DataMember]
        public virtual string Pri_Member_ID
        {
            get { return _Pri_Member_ID; }
            set { _Pri_Member_ID = value; }
        }

        [DataMember]
        public virtual string Sec_Ins_Name
        {
            get { return _Sec_Ins_Name; }
            set { _Sec_Ins_Name = value; }
        }
        [DataMember]
        public virtual decimal Sec_Copay
        {
            get { return _Sec_Copay; }
            set { _Sec_Copay = value; }
        }
        [DataMember]
        public virtual string Sec_Member_ID
        {
            get { return _Sec_Member_ID; }
            set { _Sec_Member_ID = value; }
        }
        [DataMember]
        public virtual string Appt_Date
        {
            get { return _Appt_Date; }
            set { _Appt_Date = value; }
        }
        [DataMember]
        public virtual string Appt_Time
        {
            get { return _Appt_Time; }
            set { _Appt_Time = value; }
        }
        [DataMember]
        public virtual string Appt_Facility
        {
            get { return _Appt_Facility; }
            set { _Appt_Facility = value; }
        }
        [DataMember]
        public virtual string App_Length
        {
            get { return _App_Length; }
            set { _App_Length = value; }
        }
        [DataMember]
        public virtual string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        [DataMember]
        public virtual decimal Acc_Balance
        {
            get { return _Acc_Balance; }
            set { _Acc_Balance = value; }
        }
        [DataMember]
        public virtual decimal Patient_Due
        {
            get { return _Patient_Due; }
            set { _Patient_Due = value; }
        }
        [DataMember]
        public virtual ulong Voucher_No
        {
            get { return _Voucher_No; }
            set { _Voucher_No = value; }
        }
        [DataMember]
        public virtual string Auth_No
        {
            get { return _Auth_No; }
            set { _Auth_No = value; }
        }
        [DataMember]
        public virtual string Account_Type
        {
            get { return _Account_Type; }
            set { _Account_Type = value; }
        }
        #endregion
    }
}
