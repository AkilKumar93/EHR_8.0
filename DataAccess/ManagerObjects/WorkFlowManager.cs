using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Collections;
using System;
using MySql.Data.MySqlClient;
using System.IO;
using System.Web;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IWorkFlowManager : IManagerBase<WorkFlow, ulong>
    {
        IList<WorkFlow> GetWorkFlowBasedObjectType(string Obj_Type, int Close_Type);
        IList<WorkFlow> GetWorkFlowMapList(string ObjType);

        string GetPreviousProcess(string FacName, string Obj_Type, string Obj_Sub_Type, string To, int Close_Type,string Doc_Type, string Doc_Sub_Type );
        IList<string> GetWorkFlowMapListByLab(string sObj_Type, string sFacility_Name);

        IList<WorkFlow> GetWorkFlowMapListbyFacilityNameandObjType(string sFacilityName, string ObjType, string ToProcess);
    }
    public partial class WorkFlowManager : ManagerBase<WorkFlow, ulong>, IWorkFlowManager
    {
        #region Constructors

        public WorkFlowManager()
            : base()
        {

        }
        public WorkFlowManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods


        public IList<WorkFlow> GetWorkFlowMapList(string ObjType)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<WorkFlow> WFMapList;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(WorkFlow)).Add(Expression.Eq("Obj_Type", ObjType));
                WFMapList = criteria.List<WorkFlow>();
                iMySession.Close();
            }
            return WFMapList;
        }

        public IList<WorkFlow> GetWorkFlowMapListbyFacilityNameandObjType(string sFacilityName,string ObjType,string ToProcess)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<WorkFlowTypeMaster> WFTypeMasterList;
            IList<WorkFlowTypeMaster> WFTypeMasterListDefault;
            string WorkFlowType = string.Empty;

            IList<WorkFlow> WFMapList = new List<WorkFlow>(); ;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteriaWFType = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", sFacilityName)).Add(Expression.Eq("Legal_Org", System.Configuration.ConfigurationManager.AppSettings["Legal_Org"]));
                WFTypeMasterList = criteriaWFType.List<WorkFlowTypeMaster>();

                if (WFTypeMasterList.Count==0)
                {
                    ICriteria criteria1 = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", "DEFAULT")).Add(Expression.Eq("Legal_Org", System.Configuration.ConfigurationManager.AppSettings["Legal_Org"]));
                    WFTypeMasterListDefault = criteria1.List<WorkFlowTypeMaster>();
                    if (WFTypeMasterListDefault.Count > 0)
                        WorkFlowType = WFTypeMasterListDefault[0].Workflow_Type;
                }
                else
                {
                    WorkFlowType = WFTypeMasterList[0].Workflow_Type;
                }

                if (WorkFlowType != string.Empty)
                {
                    ICriteria criteria = iMySession.CreateCriteria(typeof(WorkFlow)).Add(Expression.Eq("Workflow_Type", WorkFlowType)).Add(Expression.Eq("Obj_Type", ObjType)).Add(Expression.Eq("To_Process", ToProcess));
                    WFMapList = criteria.List<WorkFlow>();
                }
                iMySession.Close();
            }
            return WFMapList;
        }

        public string GetPreviousProcess(string FacName, string Obj_Type, string Obj_Sub_Type, string To, int Close_Type, string Doc_Type, string Doc_Sub_Type)
        {
            IList<WorkFlow> wfList;
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            string FromProcess = string.Empty;

            IList<WorkFlowTypeMaster> WFTypeMasterList;
            IList<WorkFlowTypeMaster> WFTypeMasterListDefault;
            string WorkFlowType = string.Empty;
           
            IList<WorkFlow> WFMapList;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteriaWFType = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", FacName)).Add(Expression.Eq("Legal_Org", System.Configuration.ConfigurationManager.AppSettings["Legal_Org"]));
                WFTypeMasterList = criteriaWFType.List<WorkFlowTypeMaster>();

                if (WFTypeMasterList.Count == 0)
                {
                    ICriteria criteria1 = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", "DEFAULT")).Add(Expression.Eq("Legal_Org", System.Configuration.ConfigurationManager.AppSettings["Legal_Org"]));
                    WFTypeMasterListDefault = criteria1.List<WorkFlowTypeMaster>();
                    if (WFTypeMasterListDefault.Count > 0)
                        WorkFlowType = WFTypeMasterListDefault[0].Workflow_Type;
                }
                else
                {
                    WorkFlowType = WFTypeMasterList[0].Workflow_Type;
                }

                if (WorkFlowType != string.Empty)
                {
                    ICriteria criteria = iMySession.CreateCriteria(typeof(WorkFlow)).Add(Expression.Eq("Workflow_Type", WorkFlowType)).Add(Expression.Eq("Obj_Type", Obj_Type)).Add(Expression.Eq("Obj_Sub_Type", Obj_Sub_Type)).Add(Expression.Eq("To_Process", To)).Add(Expression.Eq("Close_Type", Close_Type))
                    .Add(Expression.Eq("Doc_Type", Doc_Type)).Add(Expression.Eq("Doc_Sub_Type", Doc_Sub_Type));

                    wfList = criteria.List<WorkFlow>();
                    if (wfList != null)
                    {
                        if (wfList.Count > 0)
                        {
                            FromProcess = criteria.List<WorkFlow>()[0].From_Process;
                        }
                    }
                }
                iMySession.Close();
            }
            return FromProcess;
        }

        public IList<WorkFlow> GetWorkFlowBasedObjectType(string Obj_Type, int Close_Type)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<WorkFlow> ilstflow = new List<WorkFlow>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(WorkFlow)).Add(Expression.Eq("Obj_Type", Obj_Type)).Add(Expression.Eq("Close_Type", Close_Type)).AddOrder(Order.Asc("Obj_Type"));
                ilstflow = criteria.List<WorkFlow>();
                iMySession.Close();
            }
            return ilstflow;
        }

        public IList<string> GetWorkFlowMapListByLab(string sObj_Type, string sFacility_Name)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<string> ilstflow = new List<string>();

            IList<WorkFlowTypeMaster> WFTypeMasterList;
            IList<WorkFlowTypeMaster> WFTypeMasterListDefault;
            string WorkFlowType = string.Empty;
           
            IList<WorkFlow> WFMapList;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteriaWFType = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", sFacility_Name)).Add(Expression.Eq("Legal_Org", System.Configuration.ConfigurationManager.AppSettings["Legal_Org"]));
                WFTypeMasterList = criteriaWFType.List<WorkFlowTypeMaster>();

                if (WFTypeMasterList.Count == 0)
                {
                    ICriteria criteria1 = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", "DEFAULT")).Add(Expression.Eq("Legal_Org", System.Configuration.ConfigurationManager.AppSettings["Legal_Org"]));
                    WFTypeMasterListDefault = criteria1.List<WorkFlowTypeMaster>();
                    if (WFTypeMasterListDefault.Count > 0)
                        WorkFlowType = WFTypeMasterListDefault[0].Workflow_Type;
                }
                else
                {
                    WorkFlowType = WFTypeMasterList[0].Workflow_Type;
                }

                if (WorkFlowType != string.Empty)
                {
                    ISQLQuery sql = iMySession.CreateSQLQuery("Select distinct To_Process from workflow where Obj_Type='" + sObj_Type + "' and Workflow_Type='" + WorkFlowType + "'");
                    ilstflow = sql.List<string>();
                }
                iMySession.Close();
            }
            return ilstflow;
        }
        #endregion
    }
}