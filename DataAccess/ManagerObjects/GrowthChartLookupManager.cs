using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IGrowthChartLookupManager : IManagerBase<GrowthChart_Lookup, ulong>
    {
        IList<GrowthChart_Lookup> GetGrowthChartLookup(string Gender, string Category, string X_Axis_Unit, string Y_Axis_Unit);
    }
        public partial class GrowthChartLookupManager : ManagerBase<GrowthChart_Lookup, ulong>, IGrowthChartLookupManager
    {
        #region Constructors
        public GrowthChartLookupManager()
            : base()
        {

        }
        public GrowthChartLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }

        #endregion

        public IList<GrowthChart_Lookup> GetGrowthChartLookup(string Gender, string Category, string X_Axis_Unit, string Y_Axis_Unit)
        {
            IList<GrowthChart_Lookup> GrowthList = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(GrowthChart_Lookup)).Add(Expression.Eq("Gender", Gender)).Add(Expression.Eq("X_Axis_Unit", X_Axis_Unit)).Add(Expression.Eq("Y_Axis_Unit", Y_Axis_Unit)).Add(Expression.Eq("Category", Category));
                GrowthList = crit.List<GrowthChart_Lookup>();
                iMySession.Close();
            }

            return GrowthList;
        }
    }
}
