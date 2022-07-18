using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IVaccineInfoStatementManager : IManagerBase<VaccineInfoStatement, ulong>
    {
        IList<VaccineInfoStatement> GetVaccineInfoByVaccineInfoId(IList<ulong> VaccIDs);
    }
    public partial class VaccineInfoStatementManager : ManagerBase<VaccineInfoStatement, ulong>, IVaccineInfoStatementManager
    {
         #region Constructors

        public VaccineInfoStatementManager()
            : base()
        {

        }
        public VaccineInfoStatementManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        #region IVaccineInfoStatementManager Members

        public IList<VaccineInfoStatement> GetVaccineInfoByVaccineInfoId(IList<ulong> VaccIDs)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VaccineInfoStatement> vaccineList = new List<VaccineInfoStatement>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(VaccineInfoStatement)).Add(Expression.In("Id", VaccIDs.ToArray<ulong>()));
                 vaccineList = crit.List<VaccineInfoStatement>();
                iMySession.Close();
            }
            return vaccineList;
        }

        #endregion
    }
}
