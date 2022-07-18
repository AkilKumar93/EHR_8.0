using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Web;
using System.IO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IProcessScnTabManager : IManagerBase<ProcessScnTab, ulong>
    {
        IList<ProcessScnTab> GetAllProcessScnTab(string sUserName);
    }
    public partial class ProcessScnTabManager : ManagerBase<ProcessScnTab, ulong>, IProcessScnTabManager
    {
        #region Constructors

        public ProcessScnTabManager()
            : base()
        {

        }
        public ProcessScnTabManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        public IList<ProcessScnTab> GetAllProcessScnTab(string sUserName)
        {
            IList<ProcessScnTab> ListProcScnTab = new List<ProcessScnTab>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select v.* from process_scn_tab v where v.process_name in (select process_name from process_user  where user_name='" + sUserName + "')")
                      .AddEntity("v.*", typeof(ProcessScnTab));
                //ICriteria crit = session.GetISession().CreateCriteria(typeof(ProcessScnTab)).Add(Expression.In(
                ListProcScnTab = sql.List<ProcessScnTab>();
                iMySession.Close();
            }
            return ListProcScnTab;
        }
    }
}
