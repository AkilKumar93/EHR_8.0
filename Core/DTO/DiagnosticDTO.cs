using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    public class DiagnosticDTO
    {
        private IList<Assessment> _assList = new List<Assessment>();
        private IList<ProblemList> _MedAdvProblemList = new List<ProblemList>();
        private IList<OrdersAssessment> _OrderAssList = new List<OrdersAssessment>();
        private IList<Orders> _Lists = new List<Orders>();
        private OrdersSubmit _objOrdersSubmit = new OrdersSubmit();
        private FillHumanDTO _objFillHumnaDTO = new FillHumanDTO();
        private IList<PhysicianProcedure> _procedureList = new List<PhysicianProcedure>();
        IList<ulong> _PrimaryInsuranceList = new List<ulong>();

        [DataMember]
        public virtual IList<OrdersAssessment> OrderAssList
        {
            get { return _OrderAssList; }
            set { _OrderAssList = value; }
        }
        [DataMember]
        public virtual IList<Orders> OrdersLists
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
        [DataMember]
        public virtual IList<ProblemList> MedAdvProblemList
        {
            get { return _MedAdvProblemList; }
            set { _MedAdvProblemList = value; }
        }
        [DataMember]
        public virtual OrdersSubmit objOrdersSubmit
        {
            get { return _objOrdersSubmit; }
            set { _objOrdersSubmit = value; }
        }
        [DataMember]
        public virtual FillHumanDTO objFillHumnaDTO
        {
            get { return _objFillHumnaDTO; }
            set { _objFillHumnaDTO = value; }
        }
        [DataMember]
        public virtual IList<PhysicianProcedure> procedureList
        {
            get { return _procedureList; }
            set { _procedureList = value; }
        }
      
        [DataMember]
        public virtual IList<ulong> PrimaryInsuranceList
        {
            get { return _PrimaryInsuranceList; }
            set { _PrimaryInsuranceList = value; }
        }
        
    }
}
