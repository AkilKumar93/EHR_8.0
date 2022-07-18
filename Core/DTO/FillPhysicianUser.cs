using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
    public class FillPhysicianUser
    {
        private IList<PhysicianLibrary> _PhyList;
        private IList<User> _UserList;
        private IList<MapFacilityPhysician> _MapFacList;

        public FillPhysicianUser()
        {
            _PhyList = new List<PhysicianLibrary>();
            _UserList = new List<User>();
            _MapFacList = new List<MapFacilityPhysician>();
        }

        [DataMember]
        public virtual IList<PhysicianLibrary> PhyList
        {
            get { return _PhyList; }
            set { _PhyList = value; }
        }
        [DataMember]
        public virtual IList<User> UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
        [DataMember]
        public virtual IList<MapFacilityPhysician> MapFacList
        {
            get { return _MapFacList; }
            set { _MapFacList = value; }
        }
    }
}
