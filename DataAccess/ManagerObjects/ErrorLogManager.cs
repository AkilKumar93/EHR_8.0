using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IErrorLogManager:IManagerBase<ErrorLog,ulong>
    {
        void DeleteErrorLogByResultMasterID(ulong ResultMasterId, string MacAddress);
        void UpdateErrorLogByResultMasterID(ulong ResultMasterId, string Username, string MacAddress);
    }
    public partial class ErrorLogManager : ManagerBase<ErrorLog, ulong>, IErrorLogManager
    {
        #region Constructors

        public ErrorLogManager()
            : base()
        {

        }
        public ErrorLogManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        public void DeleteErrorLogByResultMasterID(ulong ResultMasterId, string MacAddress)
        {

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("GetErrorLog.By.ResultMasterID");
                query.SetString(0, ResultMasterId.ToString());
                //ICriteria critOrders = session.GetISession().CreateCriteria(typeof(ErrorLog)).Add(Expression.Eq("Result_Master_ID", ResultMasterId));
                ArrayList ids = new ArrayList(query.List());
                if (ids != null && ids.Count > 0)
                {
                    IList<ErrorLog> ReturnList = new List<ErrorLog>();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        ReturnList.Add(GetById(Convert.ToUInt32(ids[i])));
                    }
                    IList<ErrorLog> DeleteList = new List<ErrorLog>();
                    IList<ErrorLog> SaveList = new List<ErrorLog>();
                    if (ReturnList != null && ReturnList.Count > 0)
                    {
                        DeleteList.Add(ReturnList[0]);

                    }
                    IList<ErrorLog> ErrorLogTemp = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref ErrorLogTemp, DeleteList, MacAddress, false, false, 0, "");
                }
                iMySession.Close();
            }
        }

        public void UpdateErrorLogByResultMasterID(ulong ResultMasterId, string Username, string MacAddress)
        {
            IList<ErrorLog> ReturnList = new List<ErrorLog>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria critOrders = iMySession.CreateCriteria(typeof(ErrorLog)).Add(Expression.Eq("Result_Master_ID", ResultMasterId));
                 ReturnList = critOrders.List<ErrorLog>();
                 iMySession.Close();
            }
            IList<ErrorLog> UpdateList = new List<ErrorLog>();
            IList<ErrorLog> SaveList = new List<ErrorLog>();

            for (int iCount = 0; iCount <= ReturnList.Count - 1; iCount++)
            {
                ReturnList[iCount].Is_Deleted = "Y";
                ReturnList[iCount].Modified_By = Username;
                ReturnList[iCount].Modified_Date_And_Time = System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                UpdateList.Add(ReturnList[iCount]);
            }
            
            
            //if (ReturnList != null && ReturnList.Count > 0)
            //{
            //    ReturnList[0].Is_Deleted = "Y";
            //    ReturnList[0].Modified_By = Username;
            //    ReturnList[0].Modified_Date_And_Time = System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            //    UpdateList.Add(ReturnList[0]);

            //}
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref UpdateList, null, MacAddress, false, false, 0, "");
        }

    }
}
