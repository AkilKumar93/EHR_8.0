using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IRoomInLookupManager : IManagerBase<RoomInLookup, int>
    {
      IList<RoomInLookup> GetRoomsforFacility(string FacName);

    }

    public partial class RoomInLookupManager : ManagerBase<RoomInLookup, int>, IRoomInLookupManager
    {

        #region Constructors

        public RoomInLookupManager()
            : base()
        {

        }
        public RoomInLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

      public IList<RoomInLookup> GetRoomsforFacility(string FacName)
        {
            IList<RoomInLookup> RoomList = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(RoomInLookup)).Add(Expression.Eq("Facility_Name", FacName)).AddOrder(Order.Asc("Sort_Order"));
                RoomList = crit.List<RoomInLookup>();
                iMySession.Close();
            }

            return RoomList;
        }

        #endregion



    }
}
