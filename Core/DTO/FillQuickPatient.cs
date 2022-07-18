using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillQuickPatient
    {
          #region Declarations
        private Human _HumanObj = new Human();
        private IList<InsurancePlan> _InsurancePlanList;
        private IList<Eligibility_Verification> _EligibilityList;        
        private Encounter _EncounterObj = new Encounter();
        private IList<VisitPaymentDTO> _VisitPaymentDTO = new List<VisitPaymentDTO>();
        private IList<StaticLookup> _StaticLookupList;
        private IList<Carrier> _CarrierList;
        private IList<VisitPayment> _VisitPaymentList;
        private IList<PPHeader> _PPHeaderList;
        private IList<PPLineItem> _PPLineItemList;
        private IList<Check> _CheckList;
        private IList<AccountTransaction> _AccountTransaction;
        private IList<VisitPaymentHistory> _VisitPaymentHistoryList;
        
        #endregion
        #region Constructor
        public FillQuickPatient()
        {
            _InsurancePlanList = new List<InsurancePlan>();
            _EligibilityList = new List<Eligibility_Verification>();
            _StaticLookupList = new List<StaticLookup>();
            _CarrierList = new List<Carrier>();

            _VisitPaymentList=new List<VisitPayment> ();
            _PPHeaderList = new List<PPHeader>();
            _PPLineItemList = new List<PPLineItem>();
            _CheckList = new List<Check>();

            _AccountTransaction = new List<AccountTransaction>();
            _VisitPaymentHistoryList = new List<VisitPaymentHistory>();

        }
        #endregion

        #region Properties
        [DataMember]
        public virtual Human HumanObj
        {
            get { return _HumanObj; }
            set { _HumanObj = value; }
        }
        [DataMember]
        public virtual IList<InsurancePlan> InsurancePlanList
        {
            get { return _InsurancePlanList; }
            set { _InsurancePlanList = value; }
        }

        [DataMember]
        public virtual IList<Eligibility_Verification> EligibilityList
        {
            get { return _EligibilityList; }
            set { _EligibilityList = value; }
        }

        [DataMember]
        public virtual Encounter EncounterObj
        {
            get { return _EncounterObj; }
            set { _EncounterObj = value; }
        }
        [DataMember]
        public virtual IList<VisitPaymentDTO> VisitPaymentDTO
        {
            get { return _VisitPaymentDTO; }
            set { _VisitPaymentDTO = value; }
        }
        [DataMember]
        public virtual IList<StaticLookup> StaticLookupList
        {
            get { return _StaticLookupList; }
            set { _StaticLookupList = value; }
        }  
        [DataMember]
        public virtual IList<Carrier> CarrierList
        {
            get { return _CarrierList; }
            set { _CarrierList = value; }
        }

        [DataMember]
        public virtual IList<VisitPayment> VisitPaymentList
        {
            get { return _VisitPaymentList; }
            set { _VisitPaymentList = value; }
        }
        [DataMember]
        public virtual IList<PPHeader> PPHeaderList
        {
            get { return _PPHeaderList; }
            set { _PPHeaderList = value; }
        }

        [DataMember]
        public virtual IList<PPLineItem> PPLineItemList
        {
            get { return _PPLineItemList; }
            set { _PPLineItemList = value; }
        }
        [DataMember]
        public virtual IList<Check> CheckList
        {
            get { return _CheckList; }
            set { _CheckList = value; }
        }

        [DataMember]
        public virtual IList<AccountTransaction> AccountTransaction
        {
            get { return _AccountTransaction; }
            set { _AccountTransaction = value; }
        }
        [DataMember]
        public virtual IList<VisitPaymentHistory> VisitPaymentHistoryList
        {
            get { return _VisitPaymentHistoryList; }
            set { _VisitPaymentHistoryList = value; }
        }

        #endregion
    }
}
