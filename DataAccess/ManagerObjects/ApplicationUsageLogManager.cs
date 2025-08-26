using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IApplicationUsageLogManager : IManagerBase<ApplicationUsageLog, ulong>
    {
        void SaveRcopia_deduplicate_logWithTransaction(IList<ApplicationUsageLog> ilstApplication_Usage_Log, IList<ApplicationUsageLog> ListToUpdateApplication_Usage_Log, string MACAddress);
    }

    public partial class ApplicationUsageLogManager : ManagerBase<ApplicationUsageLog, ulong>, IApplicationUsageLogManager
    {
        #region Constructors

        public ApplicationUsageLogManager()
            : base()
        {

        }
        public ApplicationUsageLogManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public void SaveRcopia_deduplicate_logWithTransaction(IList<ApplicationUsageLog> ilstApplication_Usage_Log, IList<ApplicationUsageLog> ListToUpdateApplication_Usage_Log, string MACAddress)
        {
            SaveUpdateDeleteWithTransaction(ref ilstApplication_Usage_Log, ListToUpdateApplication_Usage_Log, null, MACAddress);
        }
        #endregion
    }
}
