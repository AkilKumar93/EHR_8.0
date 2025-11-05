using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IIndexingExceptionLogManager : IManagerBase<IndexingExceptionLog,int>
    {
        void DeleteErrorLogByResultMasterID(int ResultMasterId, string MacAddress);
        void UpdateErrorLogByResultMasterID(int ResultMasterId, string Username, string MacAddress);
    }

    public partial class IndexingExceptionLogManager : ManagerBase<IndexingExceptionLog, int>, IIndexingExceptionLogManager
    {
        #region Constructors
        public IndexingExceptionLogManager()
            : base()
        {

        }
        public IndexingExceptionLogManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        
        public void DeleteErrorLogByResultMasterID(int ResultMasterId, string MacAddress)
        {

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("GetErrorLog.By.ResultMasterID");
                query.SetString(0, ResultMasterId.ToString());
                //ICriteria critOrders = session.GetISession().CreateCriteria(typeof(IndexingExceptionLog)).Add(Expression.Eq("Result_Master_ID", ResultMasterId));
                ArrayList ids = new ArrayList(query.List());
                if (ids != null && ids.Count > 0)
                {
                    IList<IndexingExceptionLog> ReturnList = new List<IndexingExceptionLog>();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        ReturnList.Add(GetById(Convert.ToInt32(ids[i])));
                    }
                    IList<IndexingExceptionLog> DeleteList = new List<IndexingExceptionLog>();
                    IList<IndexingExceptionLog> SaveList = new List<IndexingExceptionLog>();
                    if (ReturnList != null && ReturnList.Count > 0)
                    {
                        DeleteList.Add(ReturnList[0]);

                    }
                    IList<IndexingExceptionLog> ErrorLogTemp = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref ErrorLogTemp, DeleteList, MacAddress, false, false, 0, "");
                }
                iMySession.Close();
            }
        }

        public void UpdateErrorLogByResultMasterID(int ResultMasterId, string Username, string MacAddress)
        {
            IList<IndexingExceptionLog> ReturnList = new List<IndexingExceptionLog>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria critOrders = iMySession.CreateCriteria(typeof(IndexingExceptionLog)).Add(Expression.Eq("Result_Master_ID", ResultMasterId));
                 ReturnList = critOrders.List<IndexingExceptionLog>();
                 iMySession.Close();
            }
            IList<IndexingExceptionLog> UpdateList = new List<IndexingExceptionLog>();
            IList<IndexingExceptionLog> SaveList = new List<IndexingExceptionLog>();

            for (int iCount = 0; iCount <= ReturnList.Count - 1; iCount++)
            {
                ReturnList[iCount].Is_Active = "Y";
                ReturnList[iCount].Modified_By = Username;
                ReturnList[iCount].Modified_Date_And_Time = System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                UpdateList.Add(ReturnList[iCount]);
            }
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref UpdateList, null, MacAddress, false, false, 0, "");
        }
    }
}