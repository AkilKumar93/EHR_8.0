using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillQuickPatientArc
    {
          #region Declarations
        private Human _HumanObj = new Human();
        private IList<InsurancePlan> _InsurancePlanList;
        private IList<Eligibility_Verification> _EligibilityList;        
        private Encounter _EncounterObj = new Encounter();
        private IList<VisitPaymentDTO> _VisitPaymentDTO = new List<VisitPaymentDTO>();
        private IList<StaticLookup> _StaticLookupList;
        private IList<Carrier> _CarrierList;
        private IList<VisitPaymentArc> _VisitPaymentList;
        private IList<PPHeaderArc> _PPHeaderList;
        private IList<PPLineItemArc> _PPLineItemList;
        private IList<CheckArc> _CheckList;
        private IList<AccountTransactionArc> _AccountTransaction;
        
        #endregion
        #region Constructor
        public FillQuickPatientArc()
        {
            _InsurancePlanList = new List<InsurancePlan>();
            _EligibilityList = new List<Eligibility_Verification>();
            _StaticLookupList = new List<StaticLookup>();
            _CarrierList = new List<Carrier>();

            _VisitPaymentList=new List<VisitPaymentArc> ();
            _PPHeaderList = new List<PPHeaderArc>();
            _PPLineItemList = new List<PPLineItemArc>();
            _CheckList = new List<CheckArc>();

            _AccountTransaction = new List<AccountTransactionArc>();

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
        public virtual IList<VisitPaymentArc> VisitPaymentList
        {
            get { return _VisitPaymentList; }
            set { _VisitPaymentList = value; }
        }
        [DataMember]
        public virtual IList<PPHeaderArc> PPHeaderList
        {
            get { return _PPHeaderList; }
            set { _PPHeaderList = value; }
        }

        [DataMember]
        public virtual IList<PPLineItemArc> PPLineItemList
        {
            get { return _PPLineItemList; }
            set { _PPLineItemList = value; }
        }
        [DataMember]
        public virtual IList<CheckArc> CheckList
        {
            get { return _CheckList; }
            set { _CheckList = value; }
        }

        [DataMember]
        public virtual IList<AccountTransactionArc> AccountTransaction
        {
            get { return _AccountTransaction; }
            set { _AccountTransaction = value; }
        } 


        #endregion
    }
}
