using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using System;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IProcessMasterManager : IManagerBase<ProcessMaster, ulong>
    {
        IList<ProcessMaster> GetAllProcessList();
        IList<string> GetAllocatableProcessList(string sDocType, string sDocSubType);
        IList<ProcessMaster> GetProcessList(string ToProcess);
    }
    public partial class ProcessMasterManager : ManagerBase<ProcessMaster, ulong>, IProcessMasterManager
    {
        #region Constructors

        public ProcessMasterManager()
            : base()
        {

        }
        public ProcessMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<ProcessMaster> GetAllProcessList()
        {
            IList<ProcessMaster> ProcList = new List<ProcessMaster>();
            try
            {
                ProcList = GetAll();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Unable to connect to any of the specified MySQL hosts.")
                {
                    throw new Exception("Unable to connect to Databse.");
                }
            }
            return ProcList;
        }

        public IList<string> GetAllocatableProcessList(string sDocType, string sDocSubType)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<string> result = new List<string>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                ISQLQuery sql = iMySession.CreateSQLQuery("Select W.*,P.* from workflow W,Process_Master P where W.Doc_Type='" + sDocType + "' and W.Doc_Sub_Type='" + sDocSubType + "' and w.from_process=p.process_name and p.Is_Allocate='Y' group by w.from_process")
                    .AddEntity("W", typeof(WorkFlow)).AddEntity("P", typeof(ProcessMaster));

                foreach (IList<Object> l in sql.List())
                {
                    WorkFlow workfl = (WorkFlow)l[0];
                    result.Add(workfl.From_Process);
                }
                iMySession.Close();

            }
            return result;
        }

        /***  added for perfomance tuning
       * returns list contains ToProcess
       *  by Jisha  ***/

        public IList<ProcessMaster> GetProcessList(string ToProcess)
        {
            IList<ProcessMaster> ProcList;
          //  ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT p.* FROM process_master p where p.Process_Name ='" + ToProcess + "'").AddEntity("p", typeof(ProcessMaster));
                ProcList = sql.List<ProcessMaster>();
                iMySession.Close();
            }
            return ProcList;
        }
        #endregion
    }
}
