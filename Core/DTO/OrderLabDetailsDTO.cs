using System;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class OrderLabDetailsDTO
    {
        private OrdersSubmit _OrdersSubmit;
        //private Specimen _objSpecimen;
        private Orders _objOrder;
        private string _labName=string.Empty;
        private string _labLocName=string.Empty;
        //private StandingOrder _objStandingOrder;
        private OrdersQuestionSetBloodLead _objBloodLead ;
        private OrdersQuestionSetCytology _objCytology ;
        private OrdersQuestionSetAfp _objAFP ;
        private IList<OrdersQuestionSetAOE> _OrderAOEList = new List<OrdersQuestionSetAOE>();
        private string _LabProcedureDesc = string.Empty;
        private IList<OrdersRequiredForms> _ilstOrdersRequiredForms = new List<OrdersRequiredForms>();
        IList<string> _lstQuestionSetNames = new List<string>();

        public OrderLabDetailsDTO() { }


        //[DataMember]
        //public virtual Specimen objSpecimen
        //{
        //    get { return _objSpecimen; }
        //    set { _objSpecimen = value; }
        //}
        [DataMember]
        public virtual Orders ObjOrder
        {
            get { return _objOrder; }
            set { _objOrder = value; }
        }
        [DataMember]
        public virtual IList<OrdersRequiredForms> ilstOrdersRequiredForms
        {
            get { return _ilstOrdersRequiredForms; }
            set { _ilstOrdersRequiredForms = value; }
        }
        [DataMember]
        public virtual OrdersSubmit OrdersSubmit
        {
            get { return _OrdersSubmit; }
            set { _OrdersSubmit = value; }
        }
        [DataMember]
        public virtual string LabName
        {
            get { return _labName; }
            set { _labName = value; }
        }
        [DataMember]
        public virtual string LabLocName
        {
            get { return _labLocName; }
            set { _labLocName = value; }
        }

        //[DataMember]
        //public virtual StandingOrder objStandingOrder
        //{
        //    get { return _objStandingOrder; }
        //    set { _objStandingOrder = value; }
        //}
        [DataMember]
        public virtual OrdersQuestionSetBloodLead objBloodLead 
        {
            get { return _objBloodLead; }
            set { _objBloodLead = value; }
        }
        [DataMember]
        public virtual OrdersQuestionSetCytology objCytology
        {
            get { return _objCytology; }
            set { _objCytology = value; }
        }
        [DataMember]
        public virtual OrdersQuestionSetAfp objAFP
        {
            get { return _objAFP; }
            set { _objAFP = value; }
        }

        [DataMember]
        public virtual string procedureCodeDesc
        {
            get { return _LabProcedureDesc; }
            set { _LabProcedureDesc = value; }
        }
        [DataMember]
        public virtual IList<OrdersQuestionSetAOE> OrderAOEList
        {
            get { return _OrderAOEList; }
            set { _OrderAOEList = value; }
        }
       
        [DataMember]
        public virtual IList<string> lstQuestionSetNames
        {
            get { return _lstQuestionSetNames; }
            set { _lstQuestionSetNames = value; }
        }
        

    }
}
