using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using System;
using NHibernate.Criterion;
namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IImmunizationSubmissionLogManager : IManagerBase<ImmunizationSubmissionLog, ulong>
    {
    }
    public partial class ImmunizationSubmissionLogManager : ManagerBase<ImmunizationSubmissionLog, ulong>, IImmunizationSubmissionLogManager
    {
        #region Constructors
        public ImmunizationSubmissionLogManager()
            : base()
        {
        }
        public ImmunizationSubmissionLogManager(INHibernateSession session)
            : base(session)
        {
        }

        #endregion
        #region Methods
        public IList<ImmunizationSubmissionLog> GetImmunizationLogsByHumanID(ulong ulHumanID)
        {
            IList<ImmunizationSubmissionLog> listImmSub = new List<ImmunizationSubmissionLog>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ImmunizationSubmissionLog))
                                               .Add(Expression.Eq("Human_ID", ulHumanID))
                                               .AddOrder(Order.Desc("Created_Date_And_Time"));
                listImmSub = criteria.List<ImmunizationSubmissionLog>();
                iMySession.Close();
            }
            return listImmSub;
        }
        #endregion
    }
}
