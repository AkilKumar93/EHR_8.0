using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPhysicianPatientMasterManager : IManagerBase<PhysicianPatientMaster, ulong>
    {
        void SavePhysicianPatientMaster(IList<PhysicianPatientMaster> SavePhysicianPatient, IList<PhysicianPatientMaster> ilistPrevious, ulong humanId, string macAddress);
        void UpdatePhysicianPatientMaster(IList<PhysicianPatientMaster> UpdatePhysicianPatient, IList<PhysicianPatientMaster> SavePhysicianPat, ulong humanId, string macAddress);
        void DeletePhysicianPatientMaster(IList<PhysicianPatientMaster> ilistPhySpecDelteList, IList<PhysicianPatientMaster> SavePhyPat, ulong humanId, string macAddress);
    }

    public partial class PhysicianPatientMasterManager : ManagerBase<PhysicianPatientMaster, ulong>, IPhysicianPatientMasterManager
    {
        #region Constructors
        public PhysicianPatientMasterManager(): base()
        {

        }
        public PhysicianPatientMasterManager(INHibernateSession session) : base(session)
        {

        }
        #endregion



        public void SavePhysicianPatientMaster(IList<PhysicianPatientMaster> SavePhysicianPatient, IList<PhysicianPatientMaster> ilistPrevious, ulong humanId, string macAddress)
        {
            ISession MySession = Session.GetISession();
            if (SavePhysicianPatient != null && SavePhysicianPatient.Count > 0)
                SaveUpdateDelete_DBAndXML_WithTransaction(ref SavePhysicianPatient, ref ilistPrevious, null, macAddress, true, true, humanId, string.Empty);
        }

        public void UpdatePhysicianPatientMaster(IList<PhysicianPatientMaster> UpdatePhysicianPatient, IList<PhysicianPatientMaster> SavePhysicianPat, ulong humanId, string macAddress)
        {
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SavePhysicianPat, ref UpdatePhysicianPatient, null, macAddress, true, true, humanId, string.Empty);
        }

        public void DeletePhysicianPatientMaster(IList<PhysicianPatientMaster> ilistPhySpecDelteList, IList<PhysicianPatientMaster> SavePhyPat, ulong humanId, string macAddress)
        {
            IList<PhysicianPatientMaster> PhyPatTemp = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SavePhyPat, ref PhyPatTemp, ilistPhySpecDelteList, macAddress, true, true, humanId, string.Empty);      
        }
      
    }
}
