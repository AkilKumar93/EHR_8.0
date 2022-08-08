using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IMapVitalsPhysicianManager : IManagerBase<MapVitalsPhysician, ulong>
    {
        IList<MapVitalsPhysician> GetVitalsForPhysician(ulong PhyID );
    }
    public partial class MapVitalsPhysicianManager : ManagerBase<MapVitalsPhysician, ulong>, IMapVitalsPhysicianManager
    {
        #region Constructors

        public MapVitalsPhysicianManager()
            : base()
        {

        }
        public MapVitalsPhysicianManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion

        #region IMapVitalsPhysicianManager Members

        public IList<MapVitalsPhysician> GetVitalsForPhysician(ulong PhyID)
        {
            IList<MapVitalsPhysician> ilstMapVitalsPhysician = new List<MapVitalsPhysician>();
            // ISession MySessionobj = NHibernateSessionManager.Instance.CreateISession();
            using (ISession MySessionobj = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = MySessionobj.CreateCriteria(typeof(MapVitalsPhysician))
                                             .Add(Expression.Eq("Physician_ID", PhyID))
                                             .AddOrder(Order.Asc("Sort_Order"));

                ilstMapVitalsPhysician = crit.List<MapVitalsPhysician>();
                MySessionobj.Close();
            }
            return ilstMapVitalsPhysician;
            //return crit.List<MapVitalsPhysician>();
        }

        #endregion
    }
}
