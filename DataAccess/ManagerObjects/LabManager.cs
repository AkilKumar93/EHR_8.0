using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface ILabManager : IManagerBase<Lab, ulong>
    {

        IList<Lab> GetLabDetails(string LabType);
        IList<Lab> GetLabList();
        IList<Lab> GetlabName();
    }


    public partial class LabManager : ManagerBase<Lab, ulong>, ILabManager
    {

        #region Constructors

        public LabManager()
            : base()
        {

        }
        public LabManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

        public IList<Lab> GetLabDetails(string LabType)
        {
            IList<Lab> returnvalue = new List<Lab>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Lab)).Add(Expression.Eq("Lab_Type", LabType))
                    .AddOrder(Order.Asc("Lab_Name"));
                returnvalue = criteria.List<Lab>();
                iMySession.Close();
            }
            return returnvalue;
        }
        public IList<Lab> GetLabList()
        {
            return GetAll();
        }
        public IList<Lab> GetlabName()
        {
            IList<Lab> ilstlab = new List<Lab>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISQLQuery sqlquery = mySession.CreateSQLQuery("select * from lab l inner join lab_settings s on (l.lab_id=s.lab_id)").AddEntity("l", typeof(Lab));
                ISQLQuery sqlquery = mySession.CreateSQLQuery("select l.* from lab l, lab_settings s where l.lab_id=s.lab_id").AddEntity("l", typeof(Lab));
                ilstlab = sqlquery.List<Lab>();
                mySession.Close();
            }
            return ilstlab;
        }
        #endregion




    }
}
