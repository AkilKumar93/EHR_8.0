using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillPatientSummaryBarDTO
    {
        #region Declarations

        private IList<ChiefComplaints> _ChiefComplaintList;
        private IList<PatientResults> _VitalsList;
        private IList<NonDrugAllergy> _NonDrugAllergyList;
        private IList<Rcopia_Medication> _MedicationList;
        private IList<Rcopia_Allergy> _AllergyList;
        private IList<ProblemList> _PblmMedList;
        //private IList<Encounter> _EncounterList;
        private IList<DateTime> _EncounterDateList;
        private IList<ulong> _EncounterIDList;
        private IList<string> _MedHistoryList;
        private int _Vitals=0;

        #endregion

        #region Constructor

        public FillPatientSummaryBarDTO()
        {
            _ChiefComplaintList = new List<ChiefComplaints>();
            _VitalsList = new List<PatientResults>();
            _NonDrugAllergyList = new List<NonDrugAllergy>();
            _AllergyList = new List<Rcopia_Allergy>();
            _MedicationList = new List<Rcopia_Medication>();
            //_EncounterList = new List<Encounter>();
            _EncounterDateList = new List<DateTime>();
            _EncounterIDList = new List<ulong>();
            _MedHistoryList = new List<string>();
            _PblmMedList = new List<ProblemList>();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual IList<ProblemList> PblmMedList
        {
            get { return _PblmMedList; }
            set
            {
                _PblmMedList = value;
            }
        }
        [DataMember]
        public virtual IList<ChiefComplaints> ChiefComplaintList
        {
            get { return _ChiefComplaintList; }
            set { _ChiefComplaintList = value; }
        }
        [DataMember]
        public virtual IList<PatientResults> VitalsList
        {
            get { return _VitalsList; }
            set { _VitalsList = value; }
        }
        [DataMember]
        public virtual IList<NonDrugAllergy> NonDrugAllergyList
        {
            get { return _NonDrugAllergyList; }
            set { _NonDrugAllergyList = value; }
        }
        [DataMember]
        public virtual IList<Rcopia_Medication> MedicationList
        {
            get { return _MedicationList; }
            set { _MedicationList = value; }
        }

        [DataMember]
        public virtual IList<Rcopia_Allergy> AllergyList
        {
            get { return _AllergyList; }
            set { _AllergyList = value; }
        }
        //[DataMember]
        //public virtual IList<Encounter> EncounterList
        //{
        //    get { return _EncounterList; }
        //    set { _EncounterList = value; }
        //}
        [DataMember]
        public virtual IList<DateTime> EncounterDateList
        {
            get { return _EncounterDateList; }
            set { _EncounterDateList = value; }
        }
        [DataMember]
        public virtual IList<ulong> EncounterIDList
        {
            get { return _EncounterIDList; }
            set { _EncounterIDList = value; }
        }
        [DataMember]
        public virtual IList<string> MedHistoryList
        {
            get { return _MedHistoryList; }
            set { _MedHistoryList = value; }
        }
        [DataMember]
        public virtual int Vitals
        {
            get { return _Vitals; }
            set { _Vitals = value; }
        }
        #endregion
    }
}
