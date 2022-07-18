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
    public partial class GeneratePatientListsDTO
    {
        #region Declarations

        private IList<Loinc> _LoincCodeList = null;
        //private IList<ProcedureCodeLibrary> _ProcedureCodeList;
        private ulong _PatientAccountNo = 0;
        private string _PatientName = string.Empty;
        private string _DOB = string.Empty;
        private int _Age = 0;
        private string _Gender = string.Empty;
        private string _Medication = string.Empty;
        private string _ProblemList = string.Empty;      
        private string _LabResult = string.Empty;
        private string _Race = string.Empty;
        private string _Ethnicity = string.Empty;
        private string _CommunicationPreference = string.Empty;
        private string _MedicationAllergy = string.Empty;

        private string _Medication_Date = string.Empty;
        private string _ProblemList_Date = string.Empty;
        private string _LabResult_Date = string.Empty;
        private string _Medication_Allergy_Date = string.Empty;
        private string _Encounter_Date = string.Empty;
        ulong _Total_Record_Found = 0;

        #endregion

        #region Constructor

        public GeneratePatientListsDTO()
        {
            _LoincCodeList = new List<Loinc>();
            //_ProcedureCodeList = new List<ProcedureCodeLibrary>();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<Loinc> LoincCodeList
        {
            get { return _LoincCodeList; }
            set { _LoincCodeList = value; }
        }
        //[DataMember]
        //public virtual IList<ProcedureCodeLibrary> ProcedureCodeList
        //{
        //    get { return _ProcedureCodeList; }
        //    set { _ProcedureCodeList = value; }
        //}
        [DataMember]
        public virtual ulong PatientAccountNo
        {
            get { return _PatientAccountNo; }
            set { _PatientAccountNo = value; }
        }
        [DataMember]
        public virtual string PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }
        [DataMember]
        public virtual string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        [DataMember]
        public virtual int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        [DataMember]
        public virtual string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [DataMember]
        public virtual string Medication
        {
            get { return _Medication; }
            set { _Medication = value; }
        }
        [DataMember]
        public virtual string ProblemList
        {
            get { return _ProblemList; }
            set { _ProblemList = value; }
        }
        
        [DataMember]
        public virtual string LabResult
        {
            get { return _LabResult; }
            set { _LabResult = value; }
        }       

        [DataMember]
        public virtual string Race
        {
            get { return _Race; }
            set { _Race = value; }
        }

        [DataMember]
        public virtual string Ethnicity
        {
            get { return _Ethnicity; }
            set { _Ethnicity = value; }
        }

        [DataMember]
        public virtual string CommunicationPreference
        {
            get { return _CommunicationPreference; }
            set { _CommunicationPreference = value; }
        }

        [DataMember]
        public virtual string MedicationAllergy
        {
            get { return _MedicationAllergy; }
            set { _MedicationAllergy = value; }
        }

        [DataMember]
        public virtual string Medication_Date
        {
            get { return _Medication_Date; }
            set { _Medication_Date = value; }
        }

        [DataMember]
        public virtual string ProblemList_Date
        {
            get { return _ProblemList_Date; }
            set { _ProblemList_Date = value; }
        }

        [DataMember]
        public virtual string LabResult_Date
        {
            get { return _LabResult_Date; }
            set { _LabResult_Date = value; }
        }
        [DataMember]
        public virtual string Medication_Allergy_Date
        {
            get { return _Medication_Allergy_Date; }
            set { _Medication_Allergy_Date = value; }
        }
   

        [DataMember]
        public virtual string Encounter_Date
        {
            get { return _Encounter_Date; }
            set { _Encounter_Date = value; }
        }

        [DataMember]
        public virtual ulong Total_Record_Found
        {
            get { return _Total_Record_Found; }
            set { _Total_Record_Found = value; }
        }
        #endregion
    }
}
