using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAdvanceDirectiveMasterManager : IManagerBase<AdvanceDirectiveMaster, ulong>
    {
        void SaveAdvanceDirectiveMaster(AdvanceDirectiveMaster AdvanceDirectiveObj, ulong humanId, string macAddress);
        void UpdateAdvanceDirectiveMaster(AdvanceDirectiveMaster AdvanceDirectiveObj, ulong humanId, string macAddress);
    }

    public partial class AdvanceDirectiveMasterManager : ManagerBase<AdvanceDirectiveMaster, ulong>, IAdvanceDirectiveMasterManager
    {
        public AdvanceDirectiveMasterManager() : base()
        {

        }
        public AdvanceDirectiveMasterManager(INHibernateSession session): base(session)
        {

        }

        public void SaveAdvanceDirectiveMaster(AdvanceDirectiveMaster AdvanceDirectiveObj, ulong humanId, string macAddress)
        {
            IList<AdvanceDirectiveMaster> AdvanceDirectiveMasterList = null;
            if (AdvanceDirectiveObj != null)
            {
                AdvanceDirectiveMasterList = new List<AdvanceDirectiveMaster>();
                AdvanceDirectiveMasterList.Add(AdvanceDirectiveObj);
                IList<AdvanceDirectiveMaster> ADTemp = null;
                SaveUpdateDelete_DBAndXML_WithTransaction(ref AdvanceDirectiveMasterList, ref ADTemp, null, macAddress, true, true, humanId, string.Empty);
            }
        }

        public void UpdateAdvanceDirectiveMaster(AdvanceDirectiveMaster AdvanceDirectiveObj, ulong humanId, string macAddress)
        {
            IList<AdvanceDirectiveMaster> AdvanceDirectiveMasterListInsert = null;
            IList<AdvanceDirectiveMaster> AdvanceDirectiveMasterList = null;
            if (AdvanceDirectiveObj != null)
            {
                AdvanceDirectiveMasterList = new List<AdvanceDirectiveMaster>();
                AdvanceDirectiveMasterList.Add(AdvanceDirectiveObj);
                SaveUpdateDelete_DBAndXML_WithTransaction(ref AdvanceDirectiveMasterListInsert, ref AdvanceDirectiveMasterList, null, macAddress, true, true, humanId, string.Empty);

            }
        }
    }
}
