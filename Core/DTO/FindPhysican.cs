using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FindPhysican
    {
        private IList<PhysicianFacilityDTO> _phyList = new List<PhysicianFacilityDTO>();
        private int _phyCount = 0;

        #region Properties
        [DataMember]
        public virtual IList<PhysicianFacilityDTO> PhyList
        {
            get { return _phyList; }
            set { _phyList = value; }
        }

        [DataMember]
        public virtual int PhyCount
        {
            get { return _phyCount; }
            set { _phyCount = value; }
        }
        #endregion
    }
}
