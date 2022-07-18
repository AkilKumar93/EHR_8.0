using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Linq;
using System.IO;
using System.Xml;
using System.Threading;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ITreatmentPlanManager : IManagerBase<TreatmentPlan, ulong>
    {
        IList<TreatmentPlan> SaveTreatmentPlan(TreatmentPlan objTreatmentPlan, string MacAddress);
        IList<TreatmentPlan> UpdateTreatmentPlan(TreatmentPlan objTreatmentPlan, string MacAddress);
        IList<TreatmentPlan> GetTreatmentPlanUsingEncounterId(ulong ulEncounterId, ulong ulHumanId);
        //  int SaveUpdateTreatmentPlan(TreatmentPlan SavePlan, TreatmentPlan UpdatePlan, ISession MySession, string sMacAddress);
        IList<TreatmentPlan> GetTreatmentPlan(ulong ulEncounterId);
        IList<TreatmentPlan> GetTreatmentPlan(ulong ulEncounterId, string _Type, bool isFromArchive);
        int SaveUpdateorDeleteTreatmentPlan(TreatmentPlan SavePlan, TreatmentPlan UpdatePlan, TreatmentPlan DeletePlan, ISession MySession, string sMacAddress);
        IList<TreatmentPlan> SaveUpdateDeleteTreatmentPlanList(IList<TreatmentPlan> SaveList, IList<TreatmentPlan> UpdateList, IList<TreatmentPlan> DeleteList, string sMacAddress, ulong ulEncounterID, ulong ulHumanID);
        int BatchOperationsToTreatmentPlan(IList<TreatmentPlan> SaveList, IList<TreatmentPlan> UpdateList, IList<TreatmentPlan> DeleteList, ISession MySession, string sMacAddress, bool isPhone_Encounter);

        FillTreatmentPlan GetTreatmentPlanForPastEncounter(ulong encounterId, ulong humanId, ulong physicianId);
        IList<TreatmentPlan> GetTreatmentPlanUsingEncounterIdForPrintDocuments(ulong ulEncounterId, ulong ulHumanId);
        void SaveTreatmentforSummary(IList<TreatmentPlan> lsttreatment);
        FillTreatmentPlan GetTreatmentPlanUsingWithEncounterId(ulong ulEncounterId, ulong ulHumanId, string UserName, out string BPStatusValue);
        IList<TreatmentPlan> GetTreatmentPlanusingSourceID(ulong[] uSourceID, ulong ulEncounterId);


    }
    public partial class TreatmentPlanManager : ManagerBase<TreatmentPlan, ulong>, ITreatmentPlanManager
    {
        #region Constructors

        public TreatmentPlanManager()
            : base()
        {

        }
        public TreatmentPlanManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<TreatmentPlan> SaveTreatmentPlan(TreatmentPlan objTreatmentPlan, string MacAddress)
        {
            IList<TreatmentPlan> Treatmentlst = new List<TreatmentPlan>();
            IList<TreatmentPlan> Updatelst = null;
            Treatmentlst.Add(objTreatmentPlan);
            //SaveUpdateDeleteWithTransaction(ref Treatmentlst, null, null, MacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref Treatmentlst, ref Updatelst, null, MacAddress, true, true, Treatmentlst[0].Encounter_Id, string.Empty);
            //GenerateXml XMLObj = new GenerateXml();
            //ISession MySession = session.GetISession();
            //int iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref Treatmentlst, ref Updatelst, null, MySession, MacAddress, true, true, Treatmentlst[0].Encounter_Id, string.Empty, ref XMLObj);
            //bool btreatmentPlan = XMLObj.CheckDataConsistency(Treatmentlst.Cast<object>().ToList(), true, "");
            //if (btreatmentPlan)
            //{
            //    XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
            //}            
            return GetTreatmentPlanUsingEncounterId(objTreatmentPlan.Encounter_Id, objTreatmentPlan.Human_ID);
        }

        public IList<TreatmentPlan> UpdateTreatmentPlan(TreatmentPlan objTreatmentPlan, string MacAddress)
        {
            IList<TreatmentPlan> Treatmentlst = new List<TreatmentPlan>();
            Treatmentlst.Add(objTreatmentPlan);
            IList<TreatmentPlan> Treatmentlstsave = null;
            //SaveUpdateDeleteWithTransaction(ref Treatmentlstsave, Treatmentlst, null, MacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref Treatmentlstsave, ref Treatmentlst, null, MacAddress, true, true, Treatmentlst[0].Encounter_Id, string.Empty);
            //GenerateXml XMLObj = new GenerateXml();
            //ISession MySession = session.GetISession();
            //int iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref Treatmentlstsave, ref Treatmentlst, null, MySession, MacAddress, true, true, Treatmentlst[0].Encounter_Id, string.Empty, ref XMLObj);
            //bool btreatmentPlan = XMLObj.CheckDataConsistency(Treatmentlst.Cast<object>().ToList(), true, "");
            //if (btreatmentPlan)
            //{
            //    XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
            //}       
            return GetTreatmentPlanUsingEncounterId(objTreatmentPlan.Encounter_Id, objTreatmentPlan.Human_ID);
        }

        public IList<TreatmentPlan> GetTreatmentPlanUsingEncounterId(ulong ulEncounterId, ulong ulHumanId)
        {
            IList<TreatmentPlan> ilstTreatmentPlan = new List<TreatmentPlan>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(TreatmentPlan)).Add(Expression.Eq("Encounter_Id", ulEncounterId)).Add(Expression.Eq("Human_ID", ulHumanId));
                ilstTreatmentPlan = crt.List<TreatmentPlan>();
                iMySession.Close();
            }
            return ilstTreatmentPlan;
        }


        public FillTreatmentPlan GetTreatmentPlanUsingWithEncounterId(ulong ulEncounterId, ulong ulHumanId, string UserName, out string BPStatusValue)
        {
            FillTreatmentPlan objFillTrtmntPlan = new FillTreatmentPlan();
            IList<TreatmentPlan> ilstTreatmentPlan = new List<TreatmentPlan>();
            UserLookupManager userLookupMngr = new UserLookupManager();
            DocumentManager DocumentMngr = new DocumentManager();
            BPStatusValue = String.Empty;
            //BugID:47880,48018
            //BugID:54763
            #region BP Status - Vitals from XML
            string[] lstStatus ={"BP-Sitting Sys/Dia Status","BP-Sitting$ Sys/Dia Status" ,"BP-Standing Sys/Dia Status",
                                 "BP-Standing$ Sys/Dia Status","BP-Lying Sys/Dia Status","BP-Lying$ Sys/Dia Status"};
            var Status = string.Empty;
            string humanXMl = "Human_" + ulHumanId + ".xml";
            string xmlpath = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["XMLPath"], humanXMl);
            if (File.Exists(xmlpath))
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlTextReader xmltxtReader = new XmlTextReader(xmlpath);
                xmldoc.Load(xmltxtReader);
                xmltxtReader.Close();
                XmlNodeList xmlnodeList = xmldoc.GetElementsByTagName("PatientResultsList");
                if (xmlnodeList != null && xmlnodeList.Count > 0 && xmlnodeList[0].ChildNodes != null && xmlnodeList[0].ChildNodes.Count > 0)
                {
                    Status = xmlnodeList[0].ChildNodes.Cast<XmlNode>().Where(a => a.Attributes["Encounter_ID"].Value == ulEncounterId.ToString()
                             && lstStatus.Contains(a.Attributes["Loinc_Observation"].Value) && a.Attributes["Value"].Value.Trim() != ""
                             && a.Attributes["Results_Type"].Value.ToUpper() == "VITALS").OrderByDescending(a => a.Attributes["Captured_date_and_time"].Value)
                        .Select(a => a.Attributes["Value"].Value).FirstOrDefault();
                }
            }
            #endregion
            if (Status != null && Status.ToString().Trim() != string.Empty)
                BPStatusValue = Status;
            objFillTrtmntPlan.FillDocumentList = DocumentMngr.GetDocumentsListForPlan(ulEncounterId);
            return objFillTrtmntPlan;
        }
        public IList<TreatmentPlan> GetTreatmentPlanUsingWithOutEncounterId(ulong ulHumanId)
        {
            IList<TreatmentPlan> listTreatmnt = new List<TreatmentPlan>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(TreatmentPlan)).Add(Expression.Eq("Human_ID", ulHumanId));
                listTreatmnt = crt.List<TreatmentPlan>();
                iMySession.Close();
            }
            return listTreatmnt;
        }


        public IList<TreatmentPlan> GetTreatmentPlan(ulong ulEncounterId)
        {
            IList<TreatmentPlan> ilstTreatmentPlan = new List<TreatmentPlan>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(TreatmentPlan)).Add(Expression.Eq("Encounter_Id", ulEncounterId));
                ilstTreatmentPlan = crt.List<TreatmentPlan>();
                iMySession.Close();
            }
            return ilstTreatmentPlan;
        }


        public IList<TreatmentPlan> GetTreatmentPlan(ulong encounterId, string planType, bool isFromArchive)
        {
            IList<TreatmentPlan> ilstTreatmentPlan = new List<TreatmentPlan>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var querySQL = string.Format(@"SELECT E.* 
                                               FROM   {0} E 
                                               WHERE  E.ENCOUNTER_ID = :ENCOUNTER_ID
                                               AND    E.PLAN_TYPE = :PLAN_TYPE",
                                               isFromArchive ? "TREATMENT_PLAN_ARC" : "TREATMENT_PLAN");

                var SQLQuery = iMySession.CreateSQLQuery(querySQL)
                       .AddEntity("E", typeof(TreatmentPlan));

                SQLQuery.SetParameter("ENCOUNTER_ID", encounterId);
                SQLQuery.SetParameter("PLAN_TYPE", planType);
                ilstTreatmentPlan = SQLQuery.List<TreatmentPlan>();
                iMySession.Close();
            }
            return ilstTreatmentPlan;
        }

        public int SaveUpdateorDeleteTreatmentPlan(TreatmentPlan SavePlan, TreatmentPlan UpdatePlan, TreatmentPlan DeletePlan, ISession MySession, string sMacAddress)
        {
            IList<TreatmentPlan> SaveList = new List<TreatmentPlan>();
            bool btreatmentPlan = true;
            ulong Encounter_id = 0;
            if (SavePlan != null)
            {
                Encounter_id = SavePlan.Encounter_Id;
                //SaveList = new List<TreatmentPlan>();
                SaveList.Add(SavePlan);
            }
            IList<TreatmentPlan> UpdateList = new List<TreatmentPlan>();
            if (UpdatePlan != null)
            {
                Encounter_id = UpdatePlan.Encounter_Id;
                // UpdateList = new List<TreatmentPlan>();
                UpdateList.Add(UpdatePlan);
            }
            IList<TreatmentPlan> DeleteList = new List<TreatmentPlan>();
            if (DeletePlan != null)
            {
                Encounter_id = DeletePlan.Encounter_Id;
                //DeleteList = new List<TreatmentPlan>();
                DeleteList.Add(DeletePlan);

            }
            GenerateXml XMLObj = new GenerateXml();
            int iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveList, ref UpdateList, DeleteList, MySession, sMacAddress, true, true, Encounter_id, string.Empty, ref XMLObj);
            if (SaveList != null && UpdateList != null && SaveList.Count > 0 && UpdateList.Count > 0)
            {
                btreatmentPlan = XMLObj.CheckDataConsistency(SaveList.Concat(UpdateList).Cast<object>().ToList(), true, "");
            }
            else if (SaveList != null)
            {
                btreatmentPlan = XMLObj.CheckDataConsistency(SaveList.Cast<object>().ToList(), true, "");
            }
            else if (UpdateList != null)
            {
                btreatmentPlan = XMLObj.CheckDataConsistency(UpdateList.Concat(UpdateList).Cast<object>().ToList(), true, "");
            }
            if (btreatmentPlan)
            {
                //XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
                int trycount = 0;
            trytosaveagain:
                try
                {
                    XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
                }
                catch (Exception xmlexcep)
                {
                    trycount++;
                    if (trycount <= 3)
                    {
                        int TimeMilliseconds = 0;
                        if (System.Configuration.ConfigurationSettings.AppSettings["ThreadSleepTime"] != null)
                            TimeMilliseconds = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ThreadSleepTime"]);

                        Thread.Sleep(TimeMilliseconds);
                        string sMsg = string.Empty;
                        string sExStackTrace = string.Empty;

                        string version = "";
                        if (System.Configuration.ConfigurationSettings.AppSettings["VersionConfiguration"] != null)
                            version = System.Configuration.ConfigurationSettings.AppSettings["VersionConfiguration"].ToString();

                        string[] server = version.Split('|');
                        string serverno = "";
                        if (server.Length > 1)
                            serverno = server[1].Trim();

                        if (xmlexcep.InnerException != null && xmlexcep.InnerException.Message != null)
                            sMsg = xmlexcep.InnerException.Message;
                        else
                            sMsg = xmlexcep.Message;

                        if (xmlexcep != null && xmlexcep.StackTrace != null)
                            sExStackTrace = xmlexcep.StackTrace;

                        string insertQuery = "insert into  stats_apperrorlog values(0,'" + sMsg.Replace(@"\\", @"\\\\").Replace(@"\", @"\\").Replace(@"\\\\\\\\", @"\\\\").Replace("'", "") + Environment.NewLine + " Retry: " + trycount + "', '" + serverno + "','" + DateTime.Now + "','','0','0','0','" + sExStackTrace.Replace("'", "") + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                        string ConnectionData;
                        ConnectionData = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(ConnectionData))
                        {
                            using (MySqlCommand cmd = new MySqlCommand(insertQuery))
                            {
                                cmd.Connection = con;
                                try
                                {
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch
                                {
                                }
                            }
                        }
                        goto trytosaveagain;
                    }
                }

            }
            return iResult;
        }


        public IList<TreatmentPlan> SaveUpdateDeleteTreatmentPlanList(IList<TreatmentPlan> SaveList, IList<TreatmentPlan> UpdateList, IList<TreatmentPlan> DeleteList, string sMacAddress, ulong ulEncounterID, ulong ulHumanID)
        {
            //  SaveUpdateDeleteWithTransaction(ref SaveList, UpdateList, DeleteList, sMacAddress);
            ulong Encounter_id = 0;
            if (SaveList.Count > 0)
            {
                Encounter_id = SaveList[0].Encounter_Id;
            }
            else if (UpdateList.Count > 0)
            {
                Encounter_id = UpdateList[0].Encounter_Id;
            }
            else if (DeleteList.Count > 0)
            {
                Encounter_id = DeleteList[0].Encounter_Id;
            }
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref UpdateList, DeleteList, sMacAddress, true, true, Encounter_id, string.Empty);
            return GetTreatmentPlanUsingEncounterId(ulEncounterID, ulHumanID);
        }

        public int BatchOperationsToTreatmentPlan(IList<TreatmentPlan> SaveList, IList<TreatmentPlan> UpdateList, IList<TreatmentPlan> DeleteList, ISession MySession, string sMacAddress, bool isPhone_Encounter)
        {
            //return SaveUpdateDeleteWithoutTransaction(ref SaveList, UpdateList, DeleteList, MySession, sMacAddress);
            GenerateXml XMLObj = new GenerateXml();
            IList<TreatmentPlan> CompleteTreatplanlist = new List<TreatmentPlan>();

            ulong Encounter_id = 0;
            if (SaveList.Count > 0)
            {
                Encounter_id = SaveList[0].Encounter_Id;
            }
            else if (UpdateList.Count > 0)
            {
                Encounter_id = UpdateList[0].Encounter_Id;
            }
            else if (DeleteList.Count > 0)
            {
                Encounter_id = DeleteList[0].Encounter_Id;
            }
            //bool bsaveinXml = true;
            //if (isPhone_Encounter == true)
            //    bsaveinXml = false;
            int iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveList, ref UpdateList, DeleteList, MySession, sMacAddress, true, true, Encounter_id, string.Empty, ref XMLObj);//sMacAddress, true, false // Bug Id 56669
            if (SaveList != null && SaveList.Count > 0)
            {
                foreach (TreatmentPlan obj in SaveList)
                {
                    CompleteTreatplanlist.Add(obj);
                }
            }
            if (UpdateList != null && UpdateList.Count > 0)
            {
                foreach (TreatmentPlan obj in UpdateList)
                {
                    CompleteTreatplanlist.Add(obj);
                }
            }
            //if (bsaveinXml == true)
            //{
                bool bXML = XMLObj.CheckDataConsistency(CompleteTreatplanlist.Cast<object>().ToList(), true, "");
                if (bXML)
                {
                   // XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
                    int trycount = 0;
                trytosaveagain:
                    try
                    {
                        XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
                    }
                    catch (Exception xmlexcep)
                    {
                        trycount++;
                        if (trycount <= 3)
                        {
                            int TimeMilliseconds = 0;
                            if (System.Configuration.ConfigurationSettings.AppSettings["ThreadSleepTime"] != null)
                                TimeMilliseconds = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ThreadSleepTime"]);

                            Thread.Sleep(TimeMilliseconds);
                            string sMsg = string.Empty;
                            string sExStackTrace = string.Empty;

                            string version = "";
                            if (System.Configuration.ConfigurationSettings.AppSettings["VersionConfiguration"] != null)
                                version = System.Configuration.ConfigurationSettings.AppSettings["VersionConfiguration"].ToString();

                            string[] server = version.Split('|');
                            string serverno = "";
                            if (server.Length > 1)
                                serverno = server[1].Trim();

                            if (xmlexcep.InnerException != null && xmlexcep.InnerException.Message != null)
                                sMsg = xmlexcep.InnerException.Message;
                            else
                                sMsg = xmlexcep.Message;

                            if (xmlexcep != null && xmlexcep.StackTrace != null)
                                sExStackTrace = xmlexcep.StackTrace;

                            string insertQuery = "insert into  stats_apperrorlog values(0,'" + sMsg.Replace(@"\\", @"\\\\").Replace(@"\", @"\\").Replace(@"\\\\\\\\", @"\\\\").Replace("'", "") + Environment.NewLine + " Retry: " + trycount + "', '" + serverno + "','" + DateTime.Now + "','','0','0','0','" + sExStackTrace.Replace("'", "") + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                            string ConnectionData;
                            ConnectionData = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                            using (MySqlConnection con = new MySqlConnection(ConnectionData))
                            {
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery))
                                {
                                    cmd.Connection = con;
                                    try
                                    {
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            goto trytosaveagain;
                        }
                    }
                }
            //}
            return iResult;
        }


        public FillTreatmentPlan GetTreatmentPlanForPastEncounter(ulong encounterId, ulong humanId, ulong physicianId)
        {
            EncounterManager objEncounterManager = new EncounterManager();
            FillTreatmentPlan objFillTreatmentPlanDTO = new FillTreatmentPlan();

            IList<TreatmentPlan> ilstTreatmentPlan = new List<TreatmentPlan>();

            ulong previousEncounterId = 0;

            bool isPhysicianProcess = false;
            bool isFromArchive = false;

            var ilstEncounter = objEncounterManager.GetPreviousEncounterDetails(encounterId, humanId, physicianId, out isPhysicianProcess, out isFromArchive);

            if (ilstEncounter.Count > 0)
            {
                previousEncounterId = ilstEncounter[0].Id;

                objFillTreatmentPlanDTO.PreviousEncounterId = previousEncounterId;
                objFillTreatmentPlanDTO.IsPhysicianProcess = isPhysicianProcess;

                if (isPhysicianProcess)
                {
                    var lstTreatmentPlan = GetTreatmentPlan(previousEncounterId, "PLAN", isFromArchive);

                    var lstCurrent = GetTreatmentPlan(encounterId).Where(a => string.Compare(a.Plan_Type, "PLAN", true) != 0).ToList();

                    var lstPlan = lstTreatmentPlan.Concat(lstCurrent).ToList();

                    objFillTreatmentPlanDTO.Treatment_Plan_List = lstPlan;
                }
            }

            return objFillTreatmentPlanDTO;
        }


        #endregion

        // Added by Manimozhi on 16th Oct 2012 - For Bug Id - 12102
        public IList<TreatmentPlan> GetTreatmentPlanUsingEncounterIdForPrintDocuments(ulong ulEncounterId, ulong ulHumanId)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<TreatmentPlan> TreatmentPlanList = new List<TreatmentPlan>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select * FROM Treatment_Plan  where Encounter_ID='" + ulEncounterId + "' and  Human_ID='" + ulHumanId + "'").AddEntity(typeof(TreatmentPlan));
                if (sql.List<TreatmentPlan>().Count != 0)
                {
                    TreatmentPlanList = sql.List<TreatmentPlan>();
                }
                //and Addendum_Plan <> \" \"
                iMySession.Close();
            }
            return TreatmentPlanList;
        }

        public void SaveTreatmentforSummary(IList<TreatmentPlan> lsttreatment)
        {
            //  SaveUpdateDeleteWithTransaction(ref lsttreatment, null, null, string.Empty);
            IList<TreatmentPlan> Updatetreatment = null;
            GenerateXml XMLObj = new GenerateXml();
            ISession MySession = session.GetISession();
            int iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref lsttreatment, ref Updatetreatment, null, MySession, string.Empty, true, true, lsttreatment[0].Encounter_Id, string.Empty, ref XMLObj);
            //commented for bug id:45349
            //bool btreatmentPlan = XMLObj.CheckDataConsistency(lsttreatment.Cast<object>().ToList(), true, "");
            //if (btreatmentPlan)
            //{
            //    XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
            //}           
            //SaveUpdateDelete_DBAndXML_WithTransaction(ref lsttreatment, ref Updatetreatment, null, string.Empty, true, false,0, string.Empty);
        }

        public IList<TreatmentPlan> GetTreatmentPlanusingSourceID(ulong[] uSourceID, ulong ulEncounterId)
        {
            IList<TreatmentPlan> ilstTreatmentPlan = new List<TreatmentPlan>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(TreatmentPlan)).Add(Expression.Eq("Encounter_Id", ulEncounterId)).Add(Expression.In("Source_ID", uSourceID));
                ilstTreatmentPlan = crt.List<TreatmentPlan>();
                iMySession.Close();
            }
            return ilstTreatmentPlan;
        }


    }
}
