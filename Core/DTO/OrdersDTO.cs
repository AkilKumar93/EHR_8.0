using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class OrdersDTO
    {
        private IList<Assessment> _assList = new List<Assessment>();
        //private IList<PhysicianProcedure> _ProcedureList = new List<PhysicianProcedure>();
        private IList<ProblemList> _MedAdvProblemList = new List<ProblemList>();
        //private OrderDetailsDTO _objOrderDetailsDTO = new OrderDetailsDTO();
        private IList<OrdersAssessment> _OrderAssList = new List<OrdersAssessment>();
        private IList<OrderLabDetailsDTO> _ilstOrderLabDetailsDTO = new List<OrderLabDetailsDTO>();
        private FillHumanDTO _objHuman = new FillHumanDTO();
        //private PhysicianLibrary _objPhysician = new PhysicianLibrary();
        //private IList<ulong> _labIDListBasedOnInsID = new List<ulong>();
        ulong _CMGEncounter_Physician_ID = 0;
        private IList<Orders> _Lists = new List<Orders>();
        private IList<OrdersSubmit> _ilstOrdersSubmitForPartialOrders = new List<OrdersSubmit>();

        public OrdersDTO() { }
        [DataMember]
        public virtual IList<OrdersAssessment> OrderAssList
        {
            get { return _OrderAssList; }
            set { _OrderAssList = value; }
        }

        [DataMember]
        public virtual IList<Orders> Lists
        {
            get { return _Lists; }
            set { _Lists = value; }
        }


        [DataMember]
        public virtual IList<Assessment> AssessmentList
        {
            get { return _assList; }
            set { _assList = value; }
        }
        //[DataMember]
        //public virtual IList<PhysicianProcedure> ProcedureList
        //{
        //    get { return _ProcedureList; }
        //    set { _ProcedureList = value; }
        //}

        [DataMember]
        public virtual IList<ProblemList> MedAdvProblemList
        {
            get { return _MedAdvProblemList; }
            set { _MedAdvProblemList = value; }
        }

        [DataMember]
        public virtual IList<OrderLabDetailsDTO> ilstOrderLabDetailsDTO
        {
            get { return _ilstOrderLabDetailsDTO; }
            set { _ilstOrderLabDetailsDTO = value; }
        }
        [DataMember]
        public virtual IList<OrdersSubmit> ilstOrdersSubmitForPartialOrders
        {
            get { return _ilstOrdersSubmitForPartialOrders; }
            set { _ilstOrdersSubmitForPartialOrders = value; }
        }

        //Added by Janani on 25-Jun-2011
        //[DataMember]
        //public virtual IList<PatientResults> VitalsList
        //{
        //    get { return _VitalsList; }
        //    set { _VitalsList = value; }
        //}

        [DataMember]
        public virtual FillHumanDTO objHuman
        {
            get { return _objHuman; }
            set { _objHuman = value; }
        }

        //[DataMember]
        //public virtual PhysicianLibrary objPhysician
        //{
        //    get { return _objPhysician; }
        //    set { _objPhysician = value; }
        //}

        //[DataMember]
        //public virtual IList<ulong> LabIDListBasedOnInsID
        //{
        //    get { return _labIDListBasedOnInsID; }
        //    set { _labIDListBasedOnInsID = value; }
        //}
        
             [DataMember]
        public virtual ulong CMGEncounter_Physician_ID
        {
            get { return _CMGEncounter_Physician_ID; }
            set { _CMGEncounter_Physician_ID = value; }
        }

    }
}
