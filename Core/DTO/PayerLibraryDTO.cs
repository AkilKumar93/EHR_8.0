using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]

    public partial class PayerLibraryDTO
    {
        #region Declarations

        private IList<InsurancePlan> _InsurancePlanList;
        private int _InsurancePlanListCount=0;

        #endregion

        #region Constructor

        public PayerLibraryDTO() 
        {
            _InsurancePlanList = new List<InsurancePlan>();
        }

        #endregion


        #region Properties
        [DataMember]
        public virtual IList<InsurancePlan> InsurancePlanList
        {
            get { return _InsurancePlanList; }
            set { _InsurancePlanList = value; }
        }
        [DataMember]
        public virtual int InsurancePlanListCount
        {
            get { return _InsurancePlanListCount; }
            set { _InsurancePlanListCount = value; }
        }

        #endregion

    }
}
