using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using System;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public interface IHospitalizationHistoryMasterManager : IManagerBase<HospitalizationHistoryMaster, uint>
    {
        HospitalizationDTO HospitalHistorySaveUpdateDelete(IList<HospitalizationHistoryMaster> HosptHistory, IList<HospitalizationHistoryMaster> InsertList, IList<HospitalizationHistoryMaster> UpdateList, IList<HospitalizationHistoryMaster> DeleteList, ulong HumanId, string macAddress);
    }
    public partial class HospitalizationHistoryMasterManager : ManagerBase<HospitalizationHistoryMaster, uint>, IHospitalizationHistoryMasterManager
    {
        #region Constructors
        public HospitalizationHistoryMasterManager(): base()
        {

        }
        public HospitalizationHistoryMasterManager(INHibernateSession session): base(session)
        {

        }
        #endregion
        #region Get Methods
        public HospitalizationDTO HospitalHistorySaveUpdateDelete(IList<HospitalizationHistoryMaster> HosptHistory, IList<HospitalizationHistoryMaster> InsertList, IList<HospitalizationHistoryMaster> UpdateList, IList<HospitalizationHistoryMaster> DeleteList, ulong HumanId, string macAddress)
        {
            ulong Human_ID = InsertList.Count > 0 ? InsertList[0].Human_ID : UpdateList.Count > 0 ? UpdateList[0].Human_ID : DeleteList.Count > 0 ? DeleteList[0].Human_ID : 0;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref UpdateList, null, macAddress, true, true, Human_ID, string.Empty);
            return null;
        }
        #endregion
    }
}
