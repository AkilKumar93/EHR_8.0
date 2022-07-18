using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class FillClinicalSummary
    {
        private IList<ChiefComplaints> _chiefComplaints;
        private IList<ChiefComplaints> _ChiefComplaintsHPI;
        private IList<PatientResults> _vitals;
        //private IList<ROS> _ros;
        //private IList<GeneralNotes> _ROSList;
        private IList<Rcopia_Medication> _medication;
        private IList<Assessment> _assessment;
        //private IList<GeneralNotes> _assessmentNotes;
        private IList<ProblemList> _problemlist;
        private IList<ProblemList> _HealthConcernProblemList;
        //private IList<AssessmentSource> _assessmentSource;
        //private IList<Examination> _examination;
        private IList<TreatmentPlan> _treatmentPlan;
        private IList<TreatmentPlan> _OthertreatmentPlan;
        //private IList<PastMedicalHistory> _pastMedicalHistory;
        //private IList<GeneralNotes> _pastMedicalHistoryNotes;
        private IList<SocialHistory> _socialHistory;
        //private IList<GeneralNotes> _socialHistoryNotes;
        //private IList<SurgicalHistory> _surgicalHistory;
        //private IList<FamilyHistory> _familyHistory;
        //private IList<GeneralNotes> __familyHistoryNotes;
        //private IList<NonDrugAllergy> _nonDrugAllergy;
        private IList<Rcopia_Allergy> _Allergy;
        //private IList<GeneralNotes> _nonDrugAllergyNotes;
        private IList<HospitalizationHistory> _hospitalizationHistory;
        //private IList<GeneralNotes> _generalNotes;
        //private IList<FamilyDisease> _familyDisease;
        //private IList<AssessmentProblemListDifference> _assessmentDifference;
        private IList<CarePlan> _careplan;
        //private IList<PreventiveScreen> _prventiveplan;
        private IList<Immunization> _immunList;
        private IList<ImmunizationHistory> _immunhistoryList;
        private IList<Orders> _OrdersList;
        //private IList<InHouseProcedure> _InHouseProcList;
        //private IList<AdvanceDirective> _advancedirective;
        //private IList<PhysicianPatient> _physicianList;
        private IList<Encounter> _encounter;
        private IList<ResultOBX> _ResultList;
        //private IList<ResultSubEntry> _ResultSubEntry;

        //private IList<Rcopia_Medication> _eprescriptionList;
        private IList<FillLabOrder> _laborderList;
        //private IList<FillLabOrder> _imageorderList;
        private IList<FillReferralOrder> _referralorderList;
        //private IList<string> _RXNormList = new List<string>();

        //private ulong _humanid=0;
        //private IList<Medication> _medicationHistory;
        //private IList<FillAddendumNotes> _addendumNotes;
        private IList<StaticLookup> _lookupValues;
        private IList<StaticLookup> _lookupList;
        private IList<PhysicianLibrary> _phyList;
        //private IList<FacilityLibrary> _facilityLibrary;



        private string _Granulary_Race = string.Empty;
        private string _Last_Name = string.Empty;
        private string _First_Name = string.Empty;
        //private string _Patient_status = string.Empty;
        private string _MI = string.Empty;
       private string _Suffix = string.Empty;
        //private DateTime _Date_Of_Death = DateTime.MinValue;
        private DateTime _Birth_Date = DateTime.MinValue;
        private string _Sex = string.Empty;
        private ulong _ID = 0;
        //private string _Medical_Record_Number = string.Empty;
        //private string _Prefix = string.Empty;
        private string _Street_Address1 = string.Empty;
        private string _City = string.Empty;
        private string _State = string.Empty;
        private string _ZipCode = string.Empty;
        //private string _Race = string.Empty;
        private string _Home_Phone_No = string.Empty;
        //private string _Ethnicity = string.Empty;
        private string _Preferred_Language = string.Empty;
        private string _EMail = string.Empty;
        //new
        // private string _Guarantor_human_city = string.Empty;
        //private string _Guarantor_human_street_address1 = string.Empty;
        //private string _Guarantor_human_zipcode = string.Empty;
        //private string _Guarantor_human_country= string.Empty;
        //private string _Guarantor_human_state = string.Empty;
        private string _Guarantor_human_name = string.Empty;
        private string _Guarantor_human_MI = string.Empty;
        private string _Guarantor_human_Lastname = string.Empty;
        //private string _Guarantor_Home_Phone_No = string.Empty;
        private string _MaritalStatus = string.Empty;
        //private string _Ethinicity_No = string.Empty;
        //private string _Race_No = string.Empty;


        private IList<PatientInsuredPlan> _Pat_Ins_Plan;

        //private IList<CarePlan> _careplanList;

        //private IList<PatientResults> _patientresults;
        //private IList<Documents> _ClinicalInstructionDocuments;
        private IList<VaccineManufacturerCodes> _VaccineCodes;

        private IList<Rcopia_Medication> _MedicationAdministrative;
        private IList<ReferralOrder> _ReferralOrder;
        private IList<OrdersDTO> _OrdersTestPending_Future;
        private IList<CarePlan> _Care_Plan_Cognitive_Function;
        private IList<CarePlan> _Care_Plan_Cognitive_Function_MentalStaus;
        private IList<CarePlan> _Care_Plan_FunctionalStatus;
        private IList<Documents> _Document_Material;
        private IList<Assessment> _EncounterDiagnosis;
        private IList<Assessment> _Case_Report_EncounterDiagnosis;

        private IList<FacilityLibrary> _facilityLibraryCustodian;
        private IList<PhysicianLibrary> _PhysicianLibraryDocumentation;
        private IList<InHouseProcedure> _ImplantProcedure;


        private string _Data_Sharing_Preference = string.Empty;
        private string _Birth_Indicator = string.Empty;
        private string _Birth_Order = string.Empty;
        private IList<PatGuarantor> _PatGuarantor;
        private string _Guarantor_Relationship = string.Empty;
        private IList<Human> _HumanList;
        private IList<LabLocation> _LabLocation;
        private IList<Human> _GuardianList;
        private string _Previous_Name = string.Empty;

        #region Constructors
        public FillClinicalSummary()
        {

            _chiefComplaints = new List<ChiefComplaints>();
            _ChiefComplaintsHPI = new List<ChiefComplaints>();
            _vitals = new List<PatientResults>();
            //_ros = new List<ROS>();
            //_ROSList = new List<GeneralNotes>();
            _medication = new List<Rcopia_Medication>();
            _assessment = new List<Assessment>();
            //_assessmentNotes = new List<GeneralNotes>();
            _problemlist = new List<ProblemList>();
            //_assessmentSource = new List<AssessmentSource>();
            //_examination = new List<Examination>();
            _treatmentPlan = new List<TreatmentPlan>();
            _OthertreatmentPlan = new List<TreatmentPlan>();
            _HealthConcernProblemList = new List<ProblemList>();
            //_pastMedicalHistory = new List<PastMedicalHistory>();
            //_pastMedicalHistoryNotes = new List<GeneralNotes>();
            _socialHistory = new List<SocialHistory>();
            //_socialHistoryNotes = new List<GeneralNotes>();
            //_surgicalHistory = new List<SurgicalHistory>();
            //_familyHistory = new List<FamilyHistory>();
            //_nonDrugAllergy = new List<NonDrugAllergy>();
            //_nonDrugAllergyNotes = new List<GeneralNotes>();
            _hospitalizationHistory = new List<HospitalizationHistory>();
            //_generalNotes = new List<GeneralNotes>();
            //_assessmentDifference = new List<AssessmentProblemListDifference>();
            //_familyDisease = new List<FamilyDisease>();
            _careplan = new List<CarePlan>();
            //_prventiveplan = new List<PreventiveScreen>();
            _immunList = new List<Immunization>();
            _OrdersList = new List<Orders>();
            //_InHouseProcList = new List<InHouseProcedure>();
            //_advancedirective = new List<AdvanceDirective>();
            //_physicianList = new List<PhysicianPatient>();
            _encounter = new List<Encounter>();
            _ResultList = new List<ResultOBX>();
            //_eprescriptionList = new List<Rcopia_Medication>();
            _laborderList = new List<FillLabOrder>();
            //_imageorderList = new List<FillLabOrder>();
            _referralorderList = new List<FillReferralOrder>();
            //_medicationHistory = new List<Medication>();
            // _ResultSubEntry = new List<ResultSubEntry>();
            //_addendumNotes = new List<FillAddendumNotes>();
            _Pat_Ins_Plan = new List<PatientInsuredPlan>();
            //_careplanList = new List<CarePlan>();
            //_patientresults = new List<PatientResults>();
            _VaccineCodes = new List<VaccineManufacturerCodes>();
            _lookupValues = new List<StaticLookup>();
            _lookupList = new List<StaticLookup>();
            _phyList = new List<PhysicianLibrary>();
            _immunhistoryList = new List<ImmunizationHistory>();
            //_facilityLibrary = new List<FacilityLibrary>();
            _MedicationAdministrative = new List<Rcopia_Medication>();
            _ReferralOrder = new List<ReferralOrder>();
            _OrdersTestPending_Future = new List<OrdersDTO>();
            _Care_Plan_Cognitive_Function = new List<CarePlan>();
            _Care_Plan_Cognitive_Function_MentalStaus = new List<CarePlan>();
            _Care_Plan_FunctionalStatus = new List<CarePlan>();
            _Document_Material = new List<Documents>();
            _EncounterDiagnosis = new List<Assessment>();
            _facilityLibraryCustodian = new List<FacilityLibrary>();
            _PhysicianLibraryDocumentation = new List<PhysicianLibrary>();
            _ImplantProcedure = new List<InHouseProcedure>();
            _PatGuarantor = new List<PatGuarantor>();
            _HumanList = new List<Human>();
            _GuardianList = new List<Human>();
            _LabLocation = new List<LabLocation>();

        }
        #endregion

        #region Properties

        [DataMember]
        public virtual IList<ChiefComplaints> ChiefComplaints
        {
            get { return _chiefComplaints; }
            set { _chiefComplaints = value; }
        }       

             [DataMember]
        public virtual IList<ChiefComplaints> ChiefComplaintsHPI
        {
            get { return _ChiefComplaintsHPI; }
            set { _ChiefComplaintsHPI = value; }
        }
        [DataMember]
        public virtual IList<PatientResults> Vitals
        {
            get { return _vitals; }
            set { _vitals = value; }
        }
        [DataMember]
        public virtual IList<CarePlan> Careplan
        {
            get { return _careplan; }
            set { _careplan = value; }
        }
        //[DataMember]
        //public virtual IList<ROS> ROS
        //{
        //    get { return _ros; }
        //    set { _ros = value; }
        //}

        //[DataMember]
        //public virtual IList<GeneralNotes> ROSNotes
        //{
        //    get { return _ROSList; }
        //    set { _ROSList = value; }
        //}

        //[DataMember]
        //public virtual IList<Examination> Examination
        //{
        //    get { return _examination; }
        //    set { _examination = value; }
        //}
        [DataMember]
        public virtual IList<Rcopia_Medication> Medication
        {
            get { return _medication; }
            set { _medication = value; }
        }
        [DataMember]
        public virtual IList<Assessment> Assessment
        {
            get { return _assessment; }
            set { _assessment = value; }
        }
        //[DataMember]
        //public virtual IList<GeneralNotes> AssessmentNotes
        //{
        //    get { return _assessmentNotes; }
        //    set { _assessmentNotes = value; }
        //}
        [DataMember]
        public virtual IList<ProblemList> ProblemListing
        {
            get { return _problemlist; }
            set { _problemlist = value; }
        }
        //[DataMember]
        //public virtual IList<AssessmentSource> AssessmentSource
        //{
        //    get { return _assessmentSource; }
        //    set { _assessmentSource = value; }
        //}

        [DataMember]
        public virtual IList<TreatmentPlan> TreatmentPlan
        {
            get { return _treatmentPlan; }
            set { _treatmentPlan = value; }
        }
        [DataMember]
        public virtual IList<TreatmentPlan> OthertreatmentPlan
        {
            get { return _OthertreatmentPlan; }
            set { _OthertreatmentPlan = value; }
        }
        [DataMember]
        public virtual IList<ProblemList> HealthConcernProblemList
        {
            get { return _HealthConcernProblemList; }
            set { _HealthConcernProblemList = value; }
        }
        //[DataMember]
        //public virtual IList<PreventiveScreen> PrventivePlan
        //{
        //    get { return _prventiveplan; }
        //    set { _prventiveplan = value; }
        //}

        //[DataMember]
        //public virtual IList<PastMedicalHistory> PastMedicalHistory
        //{
        //    get { return _pastMedicalHistory; }
        //    set { _pastMedicalHistory = value; }
        //}
        //[DataMember]
        //public virtual IList<GeneralNotes> PastMedicalHistoryNotes
        //{
        //    get { return _pastMedicalHistoryNotes; }
        //    set { _pastMedicalHistoryNotes = value; }
        //}

        [DataMember]
        public virtual IList<SocialHistory> SocialHistory
        {
            get { return _socialHistory; }
            set { _socialHistory = value; }
        }
        //[DataMember]
        //public virtual IList<GeneralNotes> SocialHistoryNotes
        //{
        //    get { return _socialHistoryNotes; }
        //    set { _socialHistoryNotes = value; }
        //}

        //[DataMember]
        //public virtual IList<SurgicalHistory> SurgicalHistory
        //{
        //    get { return _surgicalHistory; }
        //    set { _surgicalHistory = value; }
        //}
        //[DataMember]
        //public virtual IList<FamilyHistory> FamilyHistory
        //{
        //    get { return _familyHistory; }
        //    set { _familyHistory = value; }
        //}
        //[DataMember]
        //public virtual IList<GeneralNotes> familyHistoryNotes
        //{
        //    get { return __familyHistoryNotes; }
        //    set { __familyHistoryNotes = value; }
        //}

        //[DataMember]
        //public virtual IList<NonDrugAllergy> NonDrugAllergy
        //{
        //    get { return _nonDrugAllergy; }
        //    set { _nonDrugAllergy = value; }
        //}
        [DataMember]
        public virtual IList<Rcopia_Allergy> Allergy
        {
            get { return _Allergy; }
            set { _Allergy = value; }
        }
        //[DataMember]
        //public virtual IList<GeneralNotes> NonDrugAllergyNotes
        //{
        //    get { return _nonDrugAllergyNotes; }
        //    set { _nonDrugAllergyNotes = value; }
        //}        
        [DataMember]
        public virtual IList<HospitalizationHistory> HospitalizationHistory
        {
            get { return _hospitalizationHistory; }
            set { _hospitalizationHistory = value; }
        }


        //[DataMember]
        //public virtual IList<GeneralNotes> GeneralNotes
        //{
        //    get { return _generalNotes; }
        //    set { _generalNotes = value; }
        //}

        //[DataMember]
        //public virtual IList<FamilyDisease> FamilyDisease
        //{
        //    get { return _familyDisease; }
        //    set { _familyDisease = value; }
        //}
        //[DataMember]
        //public virtual IList<CarePlan> CarePlanList
        //{
        //    get { return _careplan; }
        //    set { _careplan = value; }
        //}
        [DataMember]
        public virtual IList<Immunization> ImmunizationList
        {
            get { return _immunList; }
            set { _immunList = value; }
        }
        [DataMember]
        public virtual IList<Orders> OrdersList
        {
            get { return _OrdersList; }
            set { _OrdersList = value; }
        }
        //[DataMember]
        //public virtual IList<InHouseProcedure> InHouseProcList
        //{
        //    get { return _InHouseProcList; }
        //    set { _InHouseProcList = value; }
        //}
        //[DataMember]
        //public virtual IList<AdvanceDirective> AdvanceDirectiveList
        //{
        //    get { return _advancedirective; }
        //    set { _advancedirective = value; }
        //}
        [DataMember]
        public virtual IList<Encounter> Encounter
        {
            get { return _encounter; }
            set { _encounter = value; }
        }
        //[DataMember]
        //public virtual IList<PhysicianPatient> PhysicianList
        //{
        //    get { return _physicianList; }
        //    set { _physicianList = value; }
        //}
        [DataMember]
        public virtual IList<ResultOBX> ResultList
        {
            get { return _ResultList; }
            set { _ResultList = value; }
        }
        //[DataMember]
        //public virtual IList<string> RXNormList 
        //{
        //    get { return _RXNormList; }
        //    set { _RXNormList = value; }
        //}
        //[DataMember]
        //public virtual IList<ResultSubEntry> ResultSubEntry
        //{
        //    get { return _ResultSubEntry; }
        //    set { _ResultSubEntry = value; }
        //}
        //[DataMember]
        //public virtual IList<AssessmentProblemListDifference> AssessmentDifference
        //{
        //    get { return _assessmentDifference; }
        //    set { _assessmentDifference = value; }
        //}


        //[DataMember]
        //public virtual ulong HumanID
        //{
        //    get { return _humanid; }
        //    set { _humanid = value; }
        //}

        //[DataMember]
        //public virtual IList<Rcopia_Medication> eprescriptionList
        //{
        //    get { return _eprescriptionList; }
        //    set { _eprescriptionList = value; }
        //}

        [DataMember]
        public virtual IList<FillLabOrder> laborderList
        {
            get { return _laborderList; }
            set { _laborderList = value; }
        }

        //[DataMember]
        //public virtual IList<FillLabOrder> imageorderList
        //{
        //    get { return _imageorderList; }
        //    set { _imageorderList = value; }
        //}

        [DataMember]
        public virtual IList<FillReferralOrder> referralorderList
        {
            get { return _referralorderList; }
            set { _referralorderList = value; }
        }

        //[DataMember]
        //public virtual IList<Medication> medicationHistory
        //{
        //    get { return _medicationHistory; }
        //    set { _medicationHistory = value; }
        //}

        //[DataMember]
        //public virtual IList<FillAddendumNotes> addendumNotes
        //{
        //    get { return _addendumNotes; }
        //    set { _addendumNotes = value; }
        //}

        [DataMember]
        public virtual string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        [DataMember]
        public virtual string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        
        [DataMember]
        public virtual string Previous_Name
        {
            get { return _Previous_Name; }
            set { _Previous_Name = value; }
        }

        [DataMember]
        public virtual string Granulary_Race
        {
            get { return _Granulary_Race; }
            set { _Granulary_Race = value; }
        }
        //[DataMember]
        //public virtual string Patient_status
        //{
        //    get { return _Patient_status; }
        //    set { _Patient_status = value; }
        //}
        [DataMember]
        public virtual string MI
        {
            get { return _MI; }
            set { _MI = value; }
        }
        [DataMember]
        public virtual string Suffix
        {
            get { return _Suffix; }
            set { _Suffix = value; }
        }
        //[DataMember]
        //public virtual DateTime Date_Of_Death
        //{
        //    get { return _Date_Of_Death; }
        //    set { _Date_Of_Death = value; }
        //}
        [DataMember]
        public virtual string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        [DataMember]
        public virtual DateTime Birth_Date
        {
            get { return _Birth_Date; }
            set { _Birth_Date = value; }
        }
        [DataMember]
        public virtual ulong ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //[DataMember]
        //public virtual string Medical_Record_Number 
        //{
        //    get { return _Medical_Record_Number; }
        //    set { _Medical_Record_Number = value; }
        //}
        //[DataMember]
        //public virtual string Prefix
        //{
        //    get { return _Prefix; }
        //    set { _Prefix = value; }
        //}
        [DataMember]
        public virtual string Street_Address1
        {
            get { return _Street_Address1; }
            set { _Street_Address1 = value; }
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
        public virtual string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        //[DataMember]
        //public virtual string Race
        //{
        //    get { return _Race; }
        //    set { _Race = value; }
        //}
        [DataMember]
        public virtual string Home_Phone_No
        {
            get { return _Home_Phone_No; }
            set { _Home_Phone_No = value; }
        }

        [DataMember]
        public virtual IList<PatientInsuredPlan> Pat_Ins_Plan
        {
            get { return _Pat_Ins_Plan; }
            set { _Pat_Ins_Plan = value; }
        }

        //[DataMember]
        //public virtual string Ethnicity
        //{
        //    get { return _Ethnicity; }
        //    set { _Ethnicity = value; }
        //}


        [DataMember]
        public virtual string Preferred_Language
        {
            get { return _Preferred_Language; }
            set { _Preferred_Language = value; }
        }

        [DataMember]
        public virtual string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        //[DataMember]
        //public virtual IList<CarePlan> CarePlanLookup
        //{
        //    get { return _careplanList; }
        //    set { _careplanList = value; }
        //}

        //[DataMember]
        //public virtual IList<PatientResults> PatientResultsMeasure
        //{
        //    get { return _patientresults; }
        //    set { _patientresults = value; }
        //}
        //[DataMember]
        //public virtual IList<Documents> ClinicalInstructionDocuments
        //{
        //    get { return _ClinicalInstructionDocuments; }
        //    set { _ClinicalInstructionDocuments = value; }
        //}
        [DataMember]
        public virtual IList<VaccineManufacturerCodes> VaccineCodes
        {
            get { return _VaccineCodes; }
            set { _VaccineCodes = value; }
        }
        [DataMember]
        public virtual IList<StaticLookup> lookupValues
        {
            get { return _lookupValues; }
            set { _lookupValues = value; }
        }
        [DataMember]
        public virtual IList<StaticLookup> lookupList
        {
            get { return _lookupList; }
            set { _lookupList = value; }
        }
        [DataMember]
        public virtual IList<PhysicianLibrary> phyList
        {
            get { return _phyList; }
            set { _phyList = value; }
        }
        [DataMember]
        public virtual IList<ImmunizationHistory> immunhistoryList
        {
            get { return _immunhistoryList; }
            set { _immunhistoryList = value; }
        }
        //[DataMember]
        //public virtual string Guarantor_human_city
        //{
        //    get { return _Guarantor_human_city; }
        //    set { _Guarantor_human_city = value; }
        //}

        //[DataMember]
        //public virtual string Guarantor_human_street_address1
        //{
        //    get { return _Guarantor_human_street_address1; }
        //    set { _Guarantor_human_street_address1 = value; }
        //}

        [DataMember]
        public virtual string Guarantor_human_name
        {
            get { return _Guarantor_human_name; }
            set { _Guarantor_human_name = value; }
        }

        [DataMember]
        public virtual string Guarantor_human_MI
        {
            get { return _Guarantor_human_MI; }
            set { _Guarantor_human_MI = value; }
        }

        [DataMember]
        public virtual string Guarantor_human_Lastname
        {
            get { return _Guarantor_human_Lastname; }
            set { _Guarantor_human_Lastname = value; }
        }

        [DataMember]
        public virtual string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }



        [DataMember]
        public virtual IList<Rcopia_Medication> MedicationAdministrative
        {
            get { return _MedicationAdministrative; }
            set { _MedicationAdministrative = value; }
        }
        [DataMember]
        public virtual IList<ReferralOrder> ReferralOrder
        {
            get { return _ReferralOrder; }
            set { _ReferralOrder = value; }
        }
        [DataMember]
        public virtual IList<OrdersDTO> OrdersTestPending_Future
        {
            get { return _OrdersTestPending_Future; }
            set { _OrdersTestPending_Future = value; }
        }
        [DataMember]
        public virtual IList<CarePlan> Care_Plan_Cognitive_Function
        {
            get { return _Care_Plan_Cognitive_Function; }
            set { _Care_Plan_Cognitive_Function = value; }
        }
        [DataMember]
        public virtual IList<CarePlan> Care_Plan_Cognitive_Function_MentalStatus
        {
            get { return _Care_Plan_Cognitive_Function_MentalStaus; }
            set { _Care_Plan_Cognitive_Function_MentalStaus = value; }
        }
        [DataMember]
        public virtual IList<CarePlan> Care_Plan_FunctionalStatus
        {
            get { return _Care_Plan_FunctionalStatus; }
            set { _Care_Plan_FunctionalStatus = value; }
        }

        [DataMember]
        public virtual IList<Documents> Document_Material
        {
            get { return _Document_Material; }
            set { _Document_Material = value; }
        }
        [DataMember]
        public virtual IList<Assessment> EncounterDiagnosis
        {
            get { return _EncounterDiagnosis; }
            set { _EncounterDiagnosis = value; }
        }
        [DataMember]
        public virtual IList<Assessment> Case_Report_EncounterDiagnosis
        {
            get { return _Case_Report_EncounterDiagnosis; }
            set { _Case_Report_EncounterDiagnosis = value; }
        }

        [DataMember]
        public virtual IList<FacilityLibrary> facilityLibraryCustodian
        {
            get { return _facilityLibraryCustodian; }
            set { _facilityLibraryCustodian = value; }
        }

        [DataMember]
        public virtual IList<PhysicianLibrary> PhysicianLibraryDocumentation
        {
            get { return _PhysicianLibraryDocumentation; }
            set { _PhysicianLibraryDocumentation = value; }
        }

        [DataMember]
        public virtual IList<InHouseProcedure> ImplantProcedure
        {
            get { return _ImplantProcedure; }
            set { _ImplantProcedure = value; }
        }
        [DataMember]
        public virtual string Data_Sharing_Preference
        {
            get { return _Data_Sharing_Preference; }
            set
            {
                _Data_Sharing_Preference = value;
            }
        }
        [DataMember]
        public virtual string Birth_Indicator
        {
            get { return _Birth_Indicator; }
            set
            {
                _Birth_Indicator = value;
            }
        }
        [DataMember]
        public virtual string Birth_Order
        {
            get { return _Birth_Order; }
            set
            {
                _Birth_Order = value;
            }
        }
        [DataMember]
        public virtual IList<PatGuarantor> PatGuarantor
        {
            get { return _PatGuarantor; }
            set { _PatGuarantor = value; }
        }
        [DataMember]
        public virtual string Guarantor_Relationship
        {
            get { return _Guarantor_Relationship; }
            set { _Guarantor_Relationship = value; }
        }
        [DataMember]
        public virtual IList<Human> HumanList
        {
            get { return _HumanList; }
            set { _HumanList = value; }
        }
        [DataMember]
        public virtual IList<LabLocation> LabLocationList
        {
            get { return _LabLocation; }
            set { _LabLocation = value; }
        }

        [DataMember]
        public virtual IList<Human> GuardianList
        {
            get { return _GuardianList; }
            set { _GuardianList = value; }
        }
        #endregion
    }
}
