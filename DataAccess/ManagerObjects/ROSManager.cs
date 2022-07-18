using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IROSManager : IManagerBase<ROS, uint>
    {
        IList<ROS> ROSByEncounterId(ulong encounterId);
        FillROS BatchOperationsToRosAndGeneralNotes(IList<ROS> ListToInsertRos, IList<ROS> ListToUpdateRos, IList<ROS> ListToDeleteRos, IList<GeneralNotes> ListToInsertGeneralNotes, IList<GeneralNotes> ListToUpdateGeneralNotes, GeneralNotes rosGeneralNotes, ulong EncounterId, string sMacAddress);
        FillROS GetROSAndGeneralNotesByEncounterId(ulong encounter_ID, ulong human_ID, bool isFromArchive);
        FillROS GetRosAndGeneralNotesForPastEncounter(ulong encounter_ID, ulong human_ID, ulong physician_ID);
    }
    public partial class ROSManager : ManagerBase<ROS, uint>, IROSManager
    {
        #region Constructors

        public ROSManager()
            : base()
        {

        }
        public ROSManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<ROS> ROSByEncounterId(ulong encounterId)
        {
            IList<ROS> list = new List<ROS>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ROS)).Add(Expression.Eq("Encounter_Id", encounterId));
                list = criteria.List<ROS>();
                iMySession.Close();
            }
            return list;
            //return criteria.List<ROS>();
        }

        public IList<ROS> ROSByEncounterId(ulong encounterId, bool isFromArchive)
        {
            IList<ROS> lstROS = new List<ROS>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var querySQL = string.Format(@"SELECT E.* 
                                               FROM   {0} E 
                                               WHERE  E.ENCOUNTER_ID = :ENCOUNTER_ID",
                                               isFromArchive ? "REVIEW_OF_SYSTEMS_ARC" : "REVIEW_OF_SYSTEMS");

                var SQLQuery = iMySession.CreateSQLQuery(querySQL)
                       .AddEntity("E", typeof(ROS));

                SQLQuery.SetParameter("ENCOUNTER_ID", encounterId);

                lstROS = SQLQuery.List<ROS>();

                iMySession.Close();
            }
            return lstROS;
        }

        //BugID:54702
        int iTryCount = 0;
        public FillROS BatchOperationsToRosAndGeneralNotes(IList<ROS> ListToInsertRos, IList<ROS> ListToUpdateRos, IList<ROS> ListToDeleteRos, IList<GeneralNotes> ListToInsertGeneralNotes, IList<GeneralNotes> ListToUpdateGeneralNotes, GeneralNotes rosGeneralNotes, ulong EncounterId, string sMacAddress)
        {
            GeneralNotesManager generalNotesMngr = new GeneralNotesManager();
            GeneralNotesManager generalNotesManager = new GeneralNotesManager();
            IList<GeneralNotes> generalNotesListInsert = new List<GeneralNotes>();
            IList<GeneralNotes> generalNotesListUpdate = new List<GeneralNotes>();
            GenerateXml XMLObj = new GenerateXml();
            bool bDataROS = true, bDataROSNotes = true, bDataGeneralNotes = true;
            FillROS fillros = new FillROS();
            IList<ROS> lstSaveUpdateROS = new List<ROS>();
            IList<GeneralNotes> lstSaveUpdateROSNotes = new List<GeneralNotes>();
            IList<GeneralNotes> lstSaveUpdateGenNotes = new List<GeneralNotes>();
            #region Commented
            //Since the DeleteList is always passed empty, this code is commented.
            /*using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (ListToInsertRos != null && ListToInsertRos.Count > 0)
                {
                    IList<ROS> insertlst = new List<ROS>();
                    IList<ROS> Deletelst = new List<ROS>();
                    ICriteria crit = iMySession.CreateCriteria(typeof(ROS)).Add(Expression.Eq("Encounter_Id", ListToInsertRos[0].Encounter_Id)).Add(Expression.Eq("Human_ID", ListToInsertRos[0].Human_ID));
                    Deletelst = crit.List<ROS>();
                    if (Deletelst != null && Deletelst.Count > 0)
                        SaveUpdateDeleteWithTransaction(ref insertlst, null, Deletelst, sMacAddress);
                }

                if (ListToInsertGeneralNotes != null && ListToInsertGeneralNotes.Count > 0)
                {
                    IList<GeneralNotes> insertlst = new List<GeneralNotes>();//System
                    IList<GeneralNotes> Deletelst = new List<GeneralNotes>();
                    ICriteria crit = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Parent_Field", "System")).Add(Expression.Eq("Encounter_ID", ListToInsertGeneralNotes[0].Encounter_ID)).Add(Expression.Eq("Human_ID", ListToInsertGeneralNotes[0].Human_ID));
                    Deletelst = crit.List<GeneralNotes>();
                    if (Deletelst != null && Deletelst.Count > 0)
                        generalNotesMngr.SaveUpdateDeleteWithTransaction(ref insertlst, null, Deletelst, sMacAddress);
                }
                iMySession.Close();
            }*/
            //if (rosGeneralNotes != null)
            //{
            //    //Parent_Field  ROS GENERAL NOTES
            //    IList<GeneralNotes> insertlst = new List<GeneralNotes>();
            //    IList<GeneralNotes> Deletelst = new List<GeneralNotes>();
            //    ICriteria crit = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Parent_Field", "ROS GENERAL NOTES")).Add(Expression.Eq("Encounter_ID", rosGeneralNotes.Encounter_ID)).Add(Expression.Eq("Human_ID", rosGeneralNotes.Human_ID));
            //    Deletelst = crit.List<GeneralNotes>();
            //    if (Deletelst != null && Deletelst.Count > 0)
            //       generalNotesMngr.SaveUpdateDeleteWithTransaction(ref insertlst, null, Deletelst, sMacAddress);
            //}
            #endregion

            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            ulong humanId = 0;
            ISession MySession = Session.GetISession();
            // ITransaction trans = null;

            try
            {
                using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        //trans = MySession.BeginTransaction();
                        IList<ROS> ListToInsertROS = new List<ROS>();
                        ListToInsertROS = ListToInsertRos;

                        if ((ListToInsertROS != null) && (ListToUpdateRos != null) && (ListToDeleteRos != null))
                        {
                            if ((ListToInsertROS.Count > 0) || (ListToUpdateRos.Count > 0) || (ListToDeleteRos.Count > 0))
                            {
                                if (ListToInsertROS.Count == 0)
                                {
                                    ListToInsertROS = null;
                                }
                                else if (ListToUpdateRos.Count == 0)
                                {
                                    ListToUpdateRos = null;
                                }
                                else if (ListToDeleteRos.Count == 0)
                                {
                                    ListToDeleteRos = null;
                                }
                                if (ListToInsertRos != null && ListToInsertRos.Count > 0)
                                {
                                    humanId = ListToInsertRos[0].Human_ID;
                                }
                                else if (ListToUpdateRos != null && ListToUpdateRos.Count > 0)
                                {
                                    humanId = ListToUpdateRos[0].Human_ID;
                                }
                                else if (ListToDeleteRos != null && ListToDeleteRos.Count > 0)
                                {
                                    humanId = ListToDeleteRos[0].Human_ID;
                                }
                                //iResult = SaveUpdateDeleteWithoutTransaction(ref ListToInsertROS, ListToUpdateRos, null, MySession, sMacAddress);
                                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsertROS, ref ListToUpdateRos, ListToDeleteRos, MySession, sMacAddress, true, false, EncounterId, string.Empty, ref XMLObj);

                                //if bResult = false then, the deadlock is occured 
                                if (iResult == 2)
                                {
                                    if (iTryCount < 5)
                                    {
                                        iTryCount++;
                                        goto TryAgain;
                                    }
                                    else
                                    {

                                        trans.Rollback();
                                        // MySession.Close();
                                        throw new Exception("Deadlock is occured. Transaction failed");

                                    }
                                }
                                else if (iResult == 1)
                                {

                                    trans.Rollback();
                                    // MySession.Close();
                                    throw new Exception("Exception is occured. Transaction failed");

                                }
                                if (ListToInsertROS != null)
                                    lstSaveUpdateROS = lstSaveUpdateROS.Concat<ROS>(ListToInsertROS).ToList();
                                if (ListToUpdateRos != null)
                                    lstSaveUpdateROS = lstSaveUpdateROS.Concat<ROS>(ListToUpdateRos).ToList();

                                bDataROS = XMLObj.CheckDataConsistency(lstSaveUpdateROS.Cast<object>().ToList(), true, string.Empty);
                            }
                        }

                        if ((ListToInsertGeneralNotes != null) && (ListToUpdateGeneralNotes != null))
                        {
                            if ((ListToInsertGeneralNotes.Count > 0) || (ListToUpdateGeneralNotes.Count > 0))
                            {

                                generalNotesMngr = new GeneralNotesManager();
                                //iResult = generalNotesMngr.SaveUpdateDeleteGeneralNotes(ListToInsertGeneralNotes, ListToUpdateGeneralNotes, MySession, sMacAddress);
                                iResult = generalNotesMngr.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsertGeneralNotes, ref ListToUpdateGeneralNotes, null, MySession, sMacAddress, true, true, EncounterId, "ROS", ref XMLObj);

                                //if bResult = false then, the deadlock is occured 
                                if (iResult == 2)
                                {
                                    if (iTryCount < 5)
                                    {
                                        iTryCount++;
                                        goto TryAgain;
                                    }
                                    else
                                    {

                                        trans.Rollback();
                                        // MySession.Close();
                                        throw new Exception("Deadlock is occured. Transaction failed");

                                    }
                                }
                                else if (iResult == 1)
                                {

                                    trans.Rollback();
                                    //  MySession.Close();
                                    throw new Exception("Exception is occured. Transaction failed");

                                }

                                if (ListToInsertGeneralNotes != null)
                                    lstSaveUpdateROSNotes = lstSaveUpdateROSNotes.Concat<GeneralNotes>(ListToInsertGeneralNotes).ToList();
                                if (ListToUpdateGeneralNotes != null)
                                    lstSaveUpdateROSNotes = lstSaveUpdateROSNotes.Concat<GeneralNotes>(ListToUpdateGeneralNotes).ToList();

                                bDataROSNotes = XMLObj.CheckDataConsistency(lstSaveUpdateROSNotes.Cast<object>().ToList(), true, "ROS");
                            }
                        }

                        if (rosGeneralNotes != null)
                        {
                            //GeneralNotesManager generalNotesManager = new GeneralNotesManager();

                            //IList<GeneralNotes> generalNotesListInsert = new List<GeneralNotes>();
                            //IList<GeneralNotes> generalNotesListUpdate = new List<GeneralNotes>();

                            if (rosGeneralNotes.Id == 0)
                                generalNotesListInsert.Add(rosGeneralNotes);
                            else
                                generalNotesListUpdate.Add(rosGeneralNotes);

                            //iResult = generalNotesManager.SaveUpdateDeleteGeneralNotes(generalNotesListInsert, generalNotesListUpdate, MySession, sMacAddress);
                            iResult = generalNotesManager.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref generalNotesListInsert, ref generalNotesListUpdate, null, MySession, sMacAddress, true, true, EncounterId, "ROSGeneralNotes", ref XMLObj);

                            if (iResult == 2)
                            {
                                if (iTryCount < 5)
                                {
                                    iTryCount++;
                                    goto TryAgain;
                                }
                                else
                                {
                                    trans.Rollback();
                                    throw new Exception("Deadlock occurred. Transaction failed.");
                                }
                            }
                            else if (iResult == 1)
                            {
                                trans.Rollback();
                                throw new Exception("Exception occurred. Transaction failed.");
                            }
                        }
                        if (generalNotesListInsert != null)
                            lstSaveUpdateGenNotes = lstSaveUpdateGenNotes.Concat<GeneralNotes>(generalNotesListInsert).ToList();
                        if (generalNotesListUpdate != null)
                            lstSaveUpdateGenNotes = lstSaveUpdateGenNotes.Concat<GeneralNotes>(generalNotesListUpdate).ToList();

                        bDataGeneralNotes = XMLObj.CheckDataConsistency(lstSaveUpdateGenNotes.Cast<object>().ToList(), true, "ROSGeneralNotes");

                        //MySession.Flush();
                        //trans.Commit();
                        if (bDataROS && bDataROSNotes && bDataGeneralNotes)
                        {
                            trans.Commit();
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
                        else
                            throw new Exception("Data inconsistency detected while saving. Please try again or notify support.");
                        fillros.Ros_List = lstSaveUpdateROS;
                        fillros.General_Notes_List = lstSaveUpdateROSNotes;
                        fillros.ROS_GeneralNotes_List = lstSaveUpdateGenNotes;
                    }
                    catch (NHibernate.Exceptions.GenericADOException ex)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception(ex.Message);
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        MySession.Close();
                    }
                }
            }
            catch (Exception ex1)
            {
                //MySession.Close();
                throw new Exception(ex1.Message);
            }


            //GenerateXml XMLObj = new GenerateXml();
            //FillROS fillros = new FillROS();

            /*if (ListToInsertRos.Count > 0)
            {

                ulong encounterid = ListToInsertRos[0].Encounter_Id;
                List<object> lstObj = ListToInsertRos.Cast<object>().ToList();
                XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
                fillros.Ros_List = ListToInsertRos;
            }
            else if (ListToUpdateRos.Count > 0)
            {
                ulong encounterid = ListToUpdateRos[0].Encounter_Id;

                for (int l = 0; l < ListToUpdateRos.Count; l++)
                {
                    ListToUpdateRos[l].Version = ListToUpdateRos[l].Version + 1;
                }
                List<object> lstObj = ListToUpdateRos.Cast<object>().ToList();
                XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
                fillros.Ros_List = ListToUpdateRos;
            }


            if (ListToInsertGeneralNotes.Count > 0)
            {

                ulong encounterid = ListToInsertGeneralNotes[0].Encounter_ID;
                List<object> lstObj = ListToInsertGeneralNotes.Cast<object>().ToList();
                XMLObj.GenerateXmlSave(lstObj, encounterid, "ROS");
                //fillros.ROS_GeneralNotes_List = ListToInsertGeneralNotes;
                fillros.General_Notes_List = ListToInsertGeneralNotes;
            }
            else if (ListToUpdateGeneralNotes.Count > 0)
            {
                for (int l = 0; l < ListToUpdateGeneralNotes.Count; l++)
                {
                    ListToUpdateGeneralNotes[l].Version = ListToUpdateGeneralNotes[l].Version + 1;
                }

                ulong encounterid = ListToUpdateGeneralNotes[0].Encounter_ID;
                List<object> lstObj = ListToUpdateGeneralNotes.Cast<object>().ToList();
                XMLObj.GenerateXmlSave(lstObj, encounterid, "ROS");
                //fillros.ROS_GeneralNotes_List = ListToUpdateGeneralNotes;
                fillros.General_Notes_List = ListToUpdateGeneralNotes;
            }

            if (generalNotesListInsert.Count > 0)
            {
                ulong encounterid = generalNotesListInsert[0].Encounter_ID;
                List<object> lstObj = generalNotesListInsert.Cast<object>().ToList();
                XMLObj.GenerateXmlSave(lstObj, encounterid, "ROSGeneralNotes");
                //fillros.General_Notes_List = generalNotesListInsert;
                fillros.ROS_GeneralNotes_List = generalNotesListInsert;
            }
            else if (generalNotesListUpdate.Count > 0)
            {
                ulong encounterid = generalNotesListUpdate[0].Encounter_ID;
                for (int l = 0; l < generalNotesListUpdate.Count; l++)
                {
                    generalNotesListUpdate[l].Version = generalNotesListUpdate[l].Version + 1;
                }

                List<object> lstObj = generalNotesListUpdate.Cast<object>().ToList();
                XMLObj.GenerateXmlSave(lstObj, encounterid, "ROSGeneralNotes");
                //fillros.General_Notes_List = generalNotesListUpdate;
                fillros.ROS_GeneralNotes_List = generalNotesListUpdate;
            }*/

            return fillros;

        }



        public FillROS GetROSAndGeneralNotesByEncounterId(ulong encounter_ID, ulong human_ID, bool isFromArchive)
        {
            FillROS objROS = new FillROS();

            objROS.Ros_List = ROSByEncounterId(encounter_ID, isFromArchive);

            IList<GeneralNotes> objGeneralNotes = new List<GeneralNotes>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                GeneralNotesManager objGeneralNotesManager = new GeneralNotesManager();
                IList<GeneralNotes> lstGeneral = new List<GeneralNotes>();
                objROS.General_Notes_List = new List<GeneralNotes>();
                objROS.ROS_GeneralNotes_List = new List<GeneralNotes>();
                lstGeneral = objGeneralNotesManager.GetGeneralNotesList(encounter_ID, new string[] { "SYSTEM", "ROS GENERAL NOTES" });
                if (lstGeneral.Count > 0)
                {
                    objROS.General_Notes_List = (from obj in lstGeneral where obj.Parent_Field.ToUpper() == "SYSTEM" select obj).ToList<GeneralNotes>();
                    objROS.ROS_GeneralNotes_List = (from obj in lstGeneral where obj.Parent_Field.ToUpper() == "ROS GENERAL NOTES" select obj).ToList<GeneralNotes>();
                }
                iMySession.Close();
            }
            return objROS;
        }

        public FillROS GetRosAndGeneralNotesForPastEncounter(ulong encounterId, ulong humanId, ulong physicianId)
        {
            ulong previousEncounterId = 0;
            bool isPhysicianProcess = false;

            FillROS objROS = new FillROS();

            EncounterManager encManager = new EncounterManager();
            WFObjectManager objWFObjectManager = new WFObjectManager();

            bool isFromArchive = false;

            IList<Encounter> ilstEncounter = encManager.GetPreviousEncounterDetails(encounterId, humanId, physicianId, out isPhysicianProcess, out isFromArchive);

            if (ilstEncounter.Count > 0)
            {
                previousEncounterId = ilstEncounter[0].Id;

                objROS.PreviousEnc = previousEncounterId;
                objROS.Physician_Process = isPhysicianProcess;

                if (isPhysicianProcess)
                {
                    var fillROS = GetROSAndGeneralNotesByEncounterId(previousEncounterId, humanId, isFromArchive);

                    objROS.Ros_List = fillROS.Ros_List;
                    objROS.General_Notes_List = fillROS.General_Notes_List;
                    objROS.ROS_GeneralNotes_List = fillROS.ROS_GeneralNotes_List;
                }
            }

            return objROS;
        }

        public void BatchOperationsinCopyPreviousEncounterToRosAndGeneralNotes(IList<ROS> ListToInsertRos, IList<ROS> ListToUpdateRos, IList<GeneralNotes> ListToInsertGeneralNotes, IList<GeneralNotes> ListToUpdateGeneralNotes, GeneralNotes rosGeneralNotes, ulong EncounterId, string sMacAddress)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            GeneralNotesManager generalNotesMngr = new GeneralNotesManager();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (ListToInsertRos != null && ListToInsertRos.Count > 0)
                {
                    IList<ROS> insertlst = new List<ROS>();
                    IList<ROS> Deletelst = new List<ROS>();
                    ICriteria crit = iMySession.CreateCriteria(typeof(ROS)).Add(Expression.Eq("Encounter_Id", ListToInsertRos[0].Encounter_Id)).Add(Expression.Eq("Human_ID", ListToInsertRos[0].Human_ID));
                    Deletelst = crit.List<ROS>();
                    if (Deletelst != null && Deletelst.Count > 0)
                        SaveUpdateDeleteWithTransaction(ref insertlst, null, Deletelst, sMacAddress);
                }

                if (ListToInsertGeneralNotes != null && ListToInsertGeneralNotes.Count > 0)
                {
                    IList<GeneralNotes> insertlst = new List<GeneralNotes>();//System
                    IList<GeneralNotes> Deletelst = new List<GeneralNotes>();
                    ICriteria crit = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Parent_Field", "System")).Add(Expression.Eq("Encounter_ID", ListToInsertGeneralNotes[0].Encounter_ID)).Add(Expression.Eq("Human_ID", ListToInsertGeneralNotes[0].Human_ID));
                    Deletelst = crit.List<GeneralNotes>();
                    if (Deletelst != null && Deletelst.Count > 0)
                        generalNotesMngr.SaveUpdateDeleteWithTransaction(ref insertlst, null, Deletelst, sMacAddress);
                }
                // iMySession.Close();
            }
            //if (rosGeneralNotes != null)
            //{
            //    //Parent_Field  ROS GENERAL NOTES
            //    IList<GeneralNotes> insertlst = new List<GeneralNotes>();
            //    IList<GeneralNotes> Deletelst = new List<GeneralNotes>();
            //    ICriteria crit = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Parent_Field", "ROS GENERAL NOTES")).Add(Expression.Eq("Encounter_ID", rosGeneralNotes.Encounter_ID)).Add(Expression.Eq("Human_ID", rosGeneralNotes.Human_ID));
            //    Deletelst = crit.List<GeneralNotes>();
            //    if (Deletelst != null && Deletelst.Count > 0)
            //       generalNotesMngr.SaveUpdateDeleteWithTransaction(ref insertlst, null, Deletelst, sMacAddress);
            //}




            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            ulong humanId = 0;
            using (ISession MySession = Session.GetISession())
            {
                // ITransaction trans = null;

                try
                {
                    using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            //trans = MySession.BeginTransaction();
                            IList<ROS> ListToInsertROS = new List<ROS>();
                            ListToInsertROS = ListToInsertRos;

                            if ((ListToInsertROS != null) && (ListToUpdateRos != null))
                            {
                                if ((ListToInsertROS.Count > 0) || (ListToUpdateRos.Count > 0))
                                {
                                    if (ListToInsertROS.Count == 0)
                                    {
                                        ListToInsertROS = null;
                                    }
                                    else if (ListToUpdateRos.Count == 0)
                                    {
                                        ListToUpdateRos = null;
                                    }
                                    if (ListToInsertRos != null && ListToInsertRos.Count > 0)
                                    {
                                        humanId = ListToInsertRos[0].Human_ID;
                                    }
                                    else if (ListToUpdateRos != null && ListToUpdateRos.Count > 0)
                                    {
                                        humanId = ListToUpdateRos[0].Human_ID;
                                    }
                                    iResult = SaveUpdateDeleteWithoutTransaction(ref ListToInsertROS, ListToUpdateRos, null, MySession, sMacAddress);
                                    //if bResult = false then, the deadlock is occured 
                                    if (iResult == 2)
                                    {
                                        if (iTryCount < 5)
                                        {
                                            iTryCount++;
                                            goto TryAgain;
                                        }
                                        else
                                        {

                                            trans.Rollback();
                                            // MySession.Close();
                                            throw new Exception("Deadlock is occured. Transaction failed");

                                        }
                                    }
                                    else if (iResult == 1)
                                    {

                                        trans.Rollback();
                                        // MySession.Close();
                                        throw new Exception("Exception is occured. Transaction failed");

                                    }

                                }
                            }

                            if ((ListToInsertGeneralNotes != null) && (ListToUpdateGeneralNotes != null))
                            {
                                if ((ListToInsertGeneralNotes.Count > 0) || (ListToUpdateGeneralNotes.Count > 0))
                                {

                                    generalNotesMngr = new GeneralNotesManager();
                                    //iResult = generalNotesMngr.SaveUpdateDeleteGeneralNotes(ListToInsertGeneralNotes, ListToUpdateGeneralNotes, MySession, sMacAddress);
                                    //if bResult = false then, the deadlock is occured 
                                    if (iResult == 2)
                                    {
                                        if (iTryCount < 5)
                                        {
                                            iTryCount++;
                                            goto TryAgain;
                                        }
                                        else
                                        {

                                            trans.Rollback();
                                            // MySession.Close();
                                            throw new Exception("Deadlock is occured. Transaction failed");

                                        }
                                    }
                                    else if (iResult == 1)
                                    {

                                        trans.Rollback();
                                        //  MySession.Close();
                                        throw new Exception("Exception is occured. Transaction failed");

                                    }

                                }
                            }

                            if (rosGeneralNotes != null)
                            {
                                GeneralNotesManager generalNotesManager = new GeneralNotesManager();

                                IList<GeneralNotes> generalNotesListInsert = new List<GeneralNotes>();
                                IList<GeneralNotes> generalNotesListUpdate = new List<GeneralNotes>();

                                if (rosGeneralNotes.Id == 0)
                                    generalNotesListInsert.Add(rosGeneralNotes);
                                else
                                    generalNotesListUpdate.Add(rosGeneralNotes);

                                //iResult = generalNotesManager.SaveUpdateDeleteGeneralNotes(generalNotesListInsert, generalNotesListUpdate, MySession, sMacAddress);

                                if (iResult == 2)
                                {
                                    if (iTryCount < 5)
                                    {
                                        iTryCount++;
                                        goto TryAgain;
                                    }
                                    else
                                    {
                                        trans.Rollback();
                                        throw new Exception("Deadlock occurred. Transaction failed.");
                                    }
                                }
                                else if (iResult == 1)
                                {
                                    trans.Rollback();
                                    throw new Exception("Exception occurred. Transaction failed.");
                                }
                            }

                            MySession.Flush();
                            trans.Commit();
                        }
                        catch (NHibernate.Exceptions.GenericADOException ex)
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception(ex.Message);
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception(e.Message);
                        }
                        finally
                        {
                            MySession.Close();
                        }
                    }
                }
                catch (Exception ex1)
                {
                    //MySession.Close();
                    throw new Exception(ex1.Message);
                }

            }
        }
        #endregion
    }
}
