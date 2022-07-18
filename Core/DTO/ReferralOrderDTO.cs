using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class ReferralOrderDTO
    {
        private IList<ReferralOrder> _refOrdList=new List<ReferralOrder>();
        private IList<ReferralOrdersAssessment> _refOrdAssList = new List<ReferralOrdersAssessment>();
        private IList<Assessment> _assessmentList = new List<Assessment>();
        private IList<ProblemList> _problemList = new List<ProblemList>();
        //private int _refOrdCount = 0;
        //private IList<TreatmentPlan> _Treatment_Plan = new List<TreatmentPlan>();
        private ulong _MaxGroupId = 0;
        //private FillHumanDTO _objHuman = new FillHumanDTO();
        public ReferralOrderDTO() { }


        [DataMember]
        public virtual IList<ReferralOrder> RefOrdList
        {
            get { return _refOrdList; }
            set { _refOrdList = value; }
        }
        [DataMember]
        public virtual IList<ReferralOrdersAssessment> RefOrdAssList
        {
            get { return _refOrdAssList; }
            set { _refOrdAssList = value; }
        }
        [DataMember]
        public virtual IList<Assessment> AssessmentList
        {
            get { return _assessmentList; }
            set { _assessmentList = value; }
        }
        [DataMember]
        public virtual IList<ProblemList> MedAdvProbList
        {
            get { return _problemList; }
            set { _problemList = value; }
        }
        //[DataMember]
        //public virtual int RefOrdCount
        //{
        //    get { return _refOrdCount; }
        //    set { _refOrdCount = value; }
        //}

        //[DataMember]
        //public virtual IList<TreatmentPlan> Treatment_Plan
        //{
        //    get { return _Treatment_Plan; }
        //    set { _Treatment_Plan = value; }
        //}

        //[DataMember]
        //public virtual FillHumanDTO objHuman
        //{
        //    get { return _objHuman; }
        //    set { _objHuman = value; }
        //}
        [DataMember]
        public virtual ulong MaxGroupId
        {
            get { return _MaxGroupId; }
            set { _MaxGroupId = value; }
        }
     
      
    }
}
