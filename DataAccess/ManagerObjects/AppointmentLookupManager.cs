using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAppointmentLookupManager : IManagerBase<AppointmentLookup, ulong>
    {
        //IList<AppointmentLookup> GetAppointmentLookupList(string FacName);
    }

    public partial class AppointmentLookupManager : ManagerBase<AppointmentLookup, ulong>, IAppointmentLookupManager
    {
        #region Constructors


        public AppointmentLookupManager()
            : base()
        {

        }
        public AppointmentLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods
        // Included the sort order criteria by Manimozhi on 19th Jan 2013
        //public IList<AppointmentLookup> GetAppointmentLookupList(string FacName)
        //{
        //    IList<AppointmentLookup> AppointmentList=new List<AppointmentLookup>();
        //    //ISession iMySessionAppointmentLookupList = NHibernateSessionManager.Instance.CreateISession();
        //    using (ISession iMySessionAppointmentLookupList = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria criteria = iMySessionAppointmentLookupList.CreateCriteria(typeof(AppointmentLookup)).Add(Expression.Eq("Facility_Name", FacName)).AddOrder(Order.Asc("Sort_Order"));
        //        AppointmentList = criteria.List<AppointmentLookup>();
        //        iMySessionAppointmentLookupList.Close();
        //    }
        //    return AppointmentList;
        //}
        #endregion
    }
}
