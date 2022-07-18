using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
   public partial class FillLabOrder
    {
        private Orders _labProcedure = new Orders();
        private Orders _labProcedureDescription = new Orders();
        //private Specimen _specimen = new Specimen();
        private OrdersSubmit _ordernotes = new OrdersSubmit();
        private string _labName = string.Empty;
        private string _labLocation = string.Empty;
        private OrdersAssessment _ICD = new OrdersAssessment();
        private OrdersAssessment _ICDDescription = new OrdersAssessment();
        private OrdersAssessment _OrderID = new OrdersAssessment();

        [DataMember]
        public Orders labProcedure
        {
            get { return _labProcedure; }
            set { _labProcedure = value; }
        }

        [DataMember]
        public Orders labProcedureDescription
        {
            get { return _labProcedureDescription; }
            set { _labProcedureDescription = value; }
        }
        //[DataMember]
        //public Specimen specimen
        //{
        //    get { return _specimen; }
        //    set { _specimen = value; }
        //}
        [DataMember]
        public OrdersSubmit ordernotes
        {
            get { return _ordernotes; }
            set { _ordernotes = value; }
        }

        [DataMember]
        public string labName
        {
            get { return _labName; }
            set { _labName = value; }
        }
        [DataMember]
        public string labLocation
        {
            get { return _labLocation; }
            set { _labLocation = value; }
        }
        [DataMember]
        public OrdersAssessment ICD
        {
            get { return _ICD; }
            set { _ICD = value; }
        }
        [DataMember]
        public OrdersAssessment ICDDescription
        {
            get { return _ICDDescription; }
            set { _ICDDescription = value; }
        }

        [DataMember]
        public OrdersAssessment OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
    }
}
