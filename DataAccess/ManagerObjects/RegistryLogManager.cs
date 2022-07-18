using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using System;
using NHibernate.Criterion;
namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRegistryLogManager : IManagerBase<RegistryLog, ulong>
    {
    }
    public partial class RegistryLogManager : ManagerBase<RegistryLog, ulong>, IRegistryLogManager
    {
        #region Constructors
        public RegistryLogManager()
            : base()
        {
        }
        public RegistryLogManager(INHibernateSession session)
            : base(session)
        {
        }

        #endregion
        #region Methods
        public IList<RegistryLog> GetImmunizationLogsByHumanID(ulong ulHumanID)
        {
            IList<RegistryLog> listImmSub = new List<RegistryLog>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(RegistryLog))
                                               .Add(Expression.Eq("Human_ID", ulHumanID))
                                               .AddOrder(Order.Desc("Created_Date_And_Time"));
                listImmSub = criteria.List<RegistryLog>();
                iMySession.Close();
            }
            return listImmSub;
        }
        #endregion
    }
}
