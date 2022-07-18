using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class SummaryOfCareDTO
    {
        #region Declarations

        private IList<Human> _lst_human = new List<Human>();
        private IList<PhysicianLibrary> _lst_phy = new List<PhysicianLibrary>();
        private IList<FacilityLibrary> _lst_facility = new List<FacilityLibrary>();
        private IList<Encounter> _lst_encounter = new List<Encounter>();
        private IList<Rcopia_Allergy> _lst_allergy = new List<Rcopia_Allergy>();
        private IList<Immunization> _lst_immunization = new List<Immunization>();
        private IList<Rcopia_Medication> _lst_medication = new List<Rcopia_Medication>();
        private IList<SocialHistory> _lst_social = new List<SocialHistory>();
        private IList<PatientResults> _lst_patient = new List<PatientResults>();
        private IList<CarePlan> _lst_care = new List<CarePlan>();
        private IList<TreatmentPlan> _lst_treatment = new List<TreatmentPlan>();
        private IList<ReferralOrder> _lst_referal = new List<ReferralOrder>();
        private IList<InHouseProcedure> _lst_procedure = new List<InHouseProcedure>();
        private IList<ResultMaster> _lst_resultmaster = new List<ResultMaster>();
        private IList<ResultOBR> _lst_resultobr = new List<ResultOBR>();
        private IList<ResultOBX> _lst_resultobx = new List<ResultOBX>();
        private IList<ResultORC> _lst_resultorc = new List<ResultORC>();
        private IList<Assessment> _lst_assesment = new List<Assessment>();

        private IList<InHouseProcedure> _implantList = new List<InHouseProcedure>();
        private IList<TreatmentPlan> _goalList = new List<TreatmentPlan>();
        private IList<CarePlan> _mentalstatuslist = new List<CarePlan>();
        private IList<ProblemList> _healthconcernlist = new List<ProblemList>();

        #endregion


        #region Constructor

        public SummaryOfCareDTO() { }

        #endregion


        #region Properties

        [DataMember]
        public virtual IList<TreatmentPlan> goalList
        {
            get { return _goalList; }
            set { _goalList = value; }
        }

        [DataMember]
        public virtual IList<CarePlan> mentalstatuslist
        {
            get { return _mentalstatuslist; }
            set { _mentalstatuslist = value; }
        }

        [DataMember]
        public virtual IList<ProblemList> healthconcernlist
        {
            get { return _healthconcernlist; }
            set { _healthconcernlist = value; }
        }
        [DataMember]
        public virtual IList<Human> HumanList
        {
            get { return _lst_human; }
            set { _lst_human = value; }
        }

        [DataMember]
        public virtual IList<PhysicianLibrary> PhysicianList
        {
            get { return _lst_phy; }
            set { _lst_phy = value; }
        }

        [DataMember]
        public virtual IList<FacilityLibrary> FacilityList
        {
            get { return _lst_facility; }
            set { _lst_facility = value; }
        }

        [DataMember]
        public virtual IList<Encounter> EncounterList
        {
            get { return _lst_encounter; }
            set { _lst_encounter = value; }
        }

        [DataMember]
        public virtual IList<Rcopia_Allergy> AllergyList
        {
            get { return _lst_allergy; }
            set { _lst_allergy = value; }
        }

        [DataMember]
        public virtual IList<Immunization> ImmunizationList
        {
            get { return _lst_immunization; }
            set { _lst_immunization = value; }
        }

        [DataMember]
        public virtual IList<Rcopia_Medication> MedicationList
        {
            get { return _lst_medication; }
            set { _lst_medication = value; }
        }

        [DataMember]
        public virtual IList<SocialHistory> SocialHistoryList
        {
            get { return _lst_social; }
            set { _lst_social = value; }
        }

        [DataMember]
        public virtual IList<PatientResults> VitalList
        {
            get { return _lst_patient; }
            set { _lst_patient = value; }
        }

        [DataMember]
        public virtual IList<CarePlan> CareplanList
        {
            get { return _lst_care; }
            set { _lst_care = value; }
        }

        [DataMember]
        public virtual IList<TreatmentPlan> TreatmentPlanList
        {
            get { return _lst_treatment; }
            set { _lst_treatment = value; }
        }

        [DataMember]
        public virtual IList<ReferralOrder> ReferalOrderList
        {
            get { return _lst_referal; }
            set { _lst_referal = value; }
        }

        [DataMember]
        public virtual IList<InHouseProcedure> ProcedureList
        {
            get { return _lst_procedure; }
            set { _lst_procedure = value; }
        }

        [DataMember]
        public virtual IList<ResultMaster> ResultMasterList
        {
            get { return _lst_resultmaster; }
            set { _lst_resultmaster = value; }
        }

        [DataMember]
        public virtual IList<ResultOBR> ResultObrList
        {
            get { return _lst_resultobr; }
            set { _lst_resultobr = value; }
        }

        [DataMember]
        public virtual IList<ResultOBX> ResultObxList
        {
            get { return _lst_resultobx; }
            set { _lst_resultobx = value; }
        }

        [DataMember]
        public virtual IList<ResultORC> ResultOrcList
        {
            get { return _lst_resultorc; }
            set { _lst_resultorc = value; }
        }

        [DataMember]
        public virtual IList<InHouseProcedure> ImplantList
        {
            get { return _implantList; }
            set { _implantList = value; }
        }
        #endregion

    }
}
