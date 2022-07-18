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

        #endregion




    }
}
