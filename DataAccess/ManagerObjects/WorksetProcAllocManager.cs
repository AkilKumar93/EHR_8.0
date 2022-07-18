using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IWorksetProcAllocManager : IManagerBase<Workset_proc_alloc, ulong>
    {
        Workset_proc_alloc GetUserName(string DOOS, string BatchName, string Process);


    }
    public partial class WorksetProcAllocManager : ManagerBase<Workset_proc_alloc, ulong>, IWorksetProcAllocManager
    {
        #region Constructors

        public WorksetProcAllocManager()
            : base()
        {

        }
        public WorksetProcAllocManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public Workset_proc_alloc GetUserName(string DOOS, string BatchName, string Process)
        {
            Workset_proc_alloc objWorkset = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Workset_proc_alloc)).Add(Expression.Eq("DOOS", DOOS))
                    .Add(Expression.Eq("Batch_Name", BatchName)).Add(Expression.Eq("Process_Name", Process));

                if (crit.List<Workset_proc_alloc>().Count != 0)
                    objWorkset = crit.List<Workset_proc_alloc>()[0];
                iMySession.Close();
            }
            return objWorkset;
        }

        #endregion
    }
}
