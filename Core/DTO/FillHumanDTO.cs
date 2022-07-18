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
    public partial class FillHumanDTO
    {
        #region Declarations
        //Latha - Branch_52_production_for_Rcopia - Start - 4 Jul 2011
        private ulong _Human_ID = 0;
        //Latha - Branch_52_production_for_Rcopia - End - 4 Jul 2011
        private string _sPrefix = string.Empty;
        private string _sLastName = string.Empty;
        private string _sFirstName = string.Empty;
        private string _sMI = string.Empty;
        private string _sSuffix = string.Empty;
        private DateTime _dtBirthDate=DateTime.MinValue;
        private string _sStreetAddress1 = string.Empty;
        private string _sCity = string.Empty;
        private string _sSex = string.Empty;
        private string _sState = string.Empty;
        private string _sZipCode = string.Empty;
        private string _sSSN = string.Empty;
        private IList<PatientInsuredPlan> _PatientInsuredBag;
        private string _sStreetAddress2 = string.Empty;
        private string _sHomePhoneNo = string.Empty;
        private string _sMedicalRecordNumber = string.Empty;
        private string assignedphysician = string.Empty;
        private string insuranceplanname = string.Empty;
        private string _CarrierName = string.Empty;
        private string _InsuranceType = string.Empty;
        private string _sDriverLicenseNum = string.Empty;
        private string _sGuarantorLastName = string.Empty;
        private string _sGuarantorFirstName = string.Empty;
        private string _sGuarantorMI = string.Empty;
        private string _sGuarantorStreetAddress1 = string.Empty;
        private string _sGuarantorStreetAddress2 = string.Empty;
        private string _sGuarantorCity = string.Empty;
        private string _sGuarantorState = string.Empty;
        private string _sGuarantorZipCode = string.Empty;
        private string _sRace = string.Empty;
        private string _sEthnicity = string.Empty;
        private string _sGuarantorHomePhoneNumber = string.Empty;
        private string _Guarantor_Relationship = string.Empty;
        private int _Guarantor_Relationship_No = 0;
        private int _Ethnicity_No = 0;
        private string _sEmployerName =string.Empty;
        private string _sPatient_Status = "ALIVE";
        private string _cell_phone_no = string.Empty;
        private string _WorkPhoneNo = string.Empty;
        private string _Lab_Id = string.Empty; 

        #endregion
        #region Construcor
        public FillHumanDTO()
        {
        }
        #endregion
        # region variable value implementation
        //Latha - Branch_52_production_for_Rcopia - Start - 4 Jul 2011
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual string cell_phone_no
        {
            get { return _cell_phone_no; }
            set { _cell_phone_no = value; }
        }
        //Latha - Branch_52_production_for_Rcopia - End - 4 Jul 2011
        [DataMember]
        public virtual string Prefix
        {
            get { return _sPrefix; }
            set { _sPrefix = value; }
        }
        [DataMember]
        public virtual string Last_Name
        {
            get { return _sLastName; }
            set { _sLastName = value; }
        }
        [DataMember]
        public virtual string First_Name
        {
            get { return _sFirstName; }
            set { _sFirstName = value; }
        }
        [DataMember]
        public virtual string MI
        {
            get { return _sMI; }
            set { _sMI = value; }
        }
        [DataMember]
        public virtual string Suffix
        {
            get { return _sSuffix; }
            set { _sSuffix = value; }
        }
        [DataMember]
        public virtual DateTime Birth_Date
        {
            get { return _dtBirthDate; }
            set { _dtBirthDate = value; }
        }
        [DataMember]
        public virtual string Street_Address1
        {
            get { return _sStreetAddress1; }
            set { _sStreetAddress1 = value; }
        }
        [DataMember]
        public virtual string City
        {
            get { return _sCity; }
            set { _sCity = value; }
        }
        [DataMember]
        public virtual string Sex
        {
            get { return _sSex; }
            set { _sSex = value; }
        }
        [DataMember]
        public virtual string State
        {
            get { return _sState; }
            set { _sState = value; }
        }
        [DataMember]
        public virtual string ZipCode
        {
            get { return _sZipCode; }
            set { _sZipCode = value; }
        }
        [DataMember]
        public virtual string SSN
        {
            get { return _sSSN; }
            set { _sSSN = value; }
        }
        [DataMember]
        public virtual IList<PatientInsuredPlan> PatientInsuredBag
        {
            get { return _PatientInsuredBag; }
            set { _PatientInsuredBag = value; }
        }
        [DataMember]
        public virtual string Street_Address2
        {
            get { return _sStreetAddress2; }
            set { _sStreetAddress2 = value; }
        }
        [DataMember]
        public virtual string Home_Phone_No
        {
            get { return _sHomePhoneNo; }
            set { _sHomePhoneNo = value; }
        }
        
        [DataMember]
        public virtual string Medical_Record_Number
        {
            get { return _sMedicalRecordNumber; }
            set { _sMedicalRecordNumber = value; }
        }
        [DataMember]
        public virtual string Assigned_Physician
        {
            get { return assignedphysician; }
            set { assignedphysician = value; }
        }
        [DataMember]
        public virtual string Ins_Plan_Name
        {
            get { return insuranceplanname; }
            set
            {
                insuranceplanname = value;
            }
        }
        [DataMember]
        public virtual string CarrierName
        {
            get { return _CarrierName; }
            set { _CarrierName = value; }
        }
        [DataMember]
        public virtual string Insurance_Type
        {
            get { return _InsuranceType; }
            set
            {
                _InsuranceType = value;
            }
        }
        [DataMember]
        public virtual string Guarantor_Last_Name
        {
            get { return _sGuarantorLastName; }
            set { _sGuarantorLastName = value; }
        }
        [DataMember]
        public virtual string Guarantor_First_Name
        {
            get { return _sGuarantorFirstName; }
            set { _sGuarantorFirstName = value; }
        }
        [DataMember]
        public virtual string Guarantor_MI
        {
            get { return _sGuarantorMI; }
            set { _sGuarantorMI = value; }
        }
        [DataMember]
        public virtual string Guarantor_Street_Address1
        {
            get { return _sGuarantorStreetAddress1; }
            set { _sGuarantorStreetAddress1 = value; }
        }
        [DataMember]
        public virtual string Guarantor_Street_Address2
        {
            get { return _sGuarantorStreetAddress2; }
            set { _sGuarantorStreetAddress2 = value; }
        }
        [DataMember]
        public virtual string Guarantor_City
        {
            get { return _sGuarantorCity; }
            set { _sGuarantorCity = value; }
        }
        [DataMember]
        public virtual string Guarantor_State
        {
            get { return _sGuarantorState; }
            set { _sGuarantorState = value; }
        }
        [DataMember]
        public virtual string Guarantor_Zip_Code
        {
            get { return _sGuarantorZipCode; }
            set { _sGuarantorZipCode = value; }
        }
        [DataMember]
        public virtual string Race
        {
            get { return _sRace; }
            set { _sRace = value; }
        }
        [DataMember]
        public virtual string Ethnicity
        {
            get { return _sEthnicity; }
            set { _sEthnicity = value; }
        }
        [DataMember]
        public virtual string Guarantor_Home_Phone_Number
        {
            get { return _sGuarantorHomePhoneNumber; }
            set { _sGuarantorHomePhoneNumber = value; }
        }
        [DataMember]
        public virtual string Guarantor_Relationship
        {
            get { return _Guarantor_Relationship; }
            set { _Guarantor_Relationship = value; }
        }
        [DataMember]
        public virtual int Guarantor_Relationship_No
        {
            get { return _Guarantor_Relationship_No; }
            set { _Guarantor_Relationship_No = value; }
        }
        [DataMember]
        public virtual int Ethnicity_No
        {
            get { return _Ethnicity_No; }
            set { _Ethnicity_No = value; }
        }
        [DataMember]
        public virtual string Employer_Name
        {
            get { return _sEmployerName; }
            set { _sEmployerName = value; }
        }
        [DataMember]
        public virtual string Patient_Status
        {
            get { return _sPatient_Status; }
            set { _sPatient_Status = value; }
        }
        [DataMember]
        public virtual string Work_Phone_No
        {
            get { return _WorkPhoneNo; }
            set { _WorkPhoneNo = value; }
        }
        [DataMember]
        public virtual string Lab_Id
        {
            get { return _Lab_Id; }
            set { _Lab_Id = value; }
        }
        #endregion

    }
}
