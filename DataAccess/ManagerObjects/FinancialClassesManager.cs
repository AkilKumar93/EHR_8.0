using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public interface IFinancialClassesManager : IManagerBase<FinancialClasses, ulong>
    {
        IList<FinancialClasses> GetFinancialClassesList();
    }

    public partial class FinancialClassesManager : ManagerBase<FinancialClasses, ulong>, IFinancialClassesManager
    {
        #region Constructors

        public FinancialClassesManager()
            : base()
        {

        }
        public FinancialClassesManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<FinancialClasses> GetFinancialClassesList()
        {
            IList<FinancialClasses> ilistFinancial = new List<FinancialClasses>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(FinancialClasses)).AddOrder(Order.Asc("Financial_Class_Name"));
                ilistFinancial = crit.List<FinancialClasses>();
                iMySession.Close();
            }
            return ilistFinancial;
        }

        #endregion


    }
}
