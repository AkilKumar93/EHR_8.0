using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Collections;
using System.Threading;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface INonDrugAllergyMasterManager : IManagerBase<NonDrugAllergyMaster, uint>
    {
        NonDrugHistoryDTO SaveUpdateDeleteNonDrugHistoryMaster(IList<NonDrugAllergyMaster> ExisList, IList<NonDrugAllergyMaster> insertList, IList<NonDrugAllergyMaster> updateList, IList<NonDrugAllergyMaster> deleteList, ulong HumanID, GeneralNotes generalNotesobject, string macAddress, ulong Encounter_Id);
        
    }

    public partial class NonDrugAllergyMasterManager : ManagerBase<NonDrugAllergyMaster, uint>, INonDrugAllergyMasterManager
    {
        #region Constructors

        public NonDrugAllergyMasterManager(): base()
        {

        }
        public NonDrugAllergyMasterManager(INHibernateSession session): base(session)
        {

        }
        #endregion

        #region Get Methods

        //Ginu

      

        int iTryCount = 0;

        public NonDrugHistoryDTO SaveUpdateDeleteNonDrugHistoryMaster(IList<NonDrugAllergyMaster> ExisList, IList<NonDrugAllergyMaster> insertList, IList<NonDrugAllergyMaster> updateList, IList<NonDrugAllergyMaster> deleteList, ulong HumanID, GeneralNotes generalNotesObject, string macAddress, ulong Encounter_Id)
        {
            NonDrugHistoryDTO nonDrugDTO = new NonDrugHistoryDTO();
            List<GeneralNotes> combGnrlLst = new List<GeneralNotes>();
            IList<NonDrugAllergyMaster> comblst = new List<NonDrugAllergyMaster>();
            GeneralNotesManager generalNotesManager = new GeneralNotesManager();
            IList<GeneralNotes> generalNotesListInsert = new List<GeneralNotes>();
            IList<GeneralNotes> generalNotesListUpdate = new List<GeneralNotes>();
            GenerateXml XMLObj = new GenerateXml();
            IList<NonDrugAllergyMaster> lstSaveUpdateNDA = new List<NonDrugAllergyMaster>();
            IList<GeneralNotes> lstSaveUpdateNotes = new List<GeneralNotes>();
            bool bDataNDA = true, bDataNotes = true;

            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            if (generalNotesObject != null)
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", "Non Drug Allergy History Master")).Add(Expression.Eq("Encounter_ID", Encounter_Id));
                IList<GeneralNotes> ResultLst = crit.List<GeneralNotes>();
                iMySession.Close();
                if (ResultLst != null && ResultLst.Count > 0)
                {
                    ResultLst[0].Encounter_ID = Encounter_Id;
                    ResultLst[0].Notes = generalNotesObject.Notes;
                    ResultLst[0].Modified_By = generalNotesObject.Created_By;
                    ResultLst[0].Modified_Date_And_Time = generalNotesObject.Created_Date_And_Time;
                    generalNotesListUpdate.Add(ResultLst[0]);
                }
                else
                {
                    generalNotesObject.Id = 0;
                    generalNotesObject.Encounter_ID = Encounter_Id;
                    generalNotesObject.Version = 0;
                    generalNotesListInsert.Add(generalNotesObject);
                }
            }

            iTryCount = 0;
        TryAgain:
            int iResult = 0;

            ISession MySession = Session.GetISession();
            try
            {
                using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {

                    try
                    {
                        if (insertList.Count == 0)
                        {
                            insertList = null;
                        }
                        if (updateList.Count == 0)
                        {
                            updateList = null;
                        }
                        
                        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref insertList, ref updateList, deleteList, MySession, macAddress, true, true, HumanID, string.Empty, ref XMLObj);
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
                                throw new Exception("Ddeadlock occurred. Transaction failed.");
                            }
                        }
                        else if (iResult == 1)
                        {
                            trans.Rollback();
                            throw new Exception("Exception occurred. Transaction failed.");
                        }
                        if (insertList != null)
                            lstSaveUpdateNDA = lstSaveUpdateNDA.Concat<NonDrugAllergyMaster>(insertList).ToList();
                        if (updateList != null)
                            lstSaveUpdateNDA = lstSaveUpdateNDA.Concat<NonDrugAllergyMaster>(updateList).ToList();
                        bDataNDA = XMLObj.CheckDataConsistency(lstSaveUpdateNDA.Cast<object>().ToList(), true, string.Empty);

                        if (generalNotesObject != null && generalNotesObject.Notes != string.Empty)
                        {
                            iResult = generalNotesManager.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref generalNotesListInsert, ref generalNotesListUpdate, null, MySession, macAddress, true, true, HumanID, "NonDrugAllergyMaster", ref XMLObj);
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
                            if (generalNotesListInsert != null)
                                lstSaveUpdateNotes = lstSaveUpdateNotes.Concat<GeneralNotes>(generalNotesListInsert).ToList();
                            if (generalNotesListUpdate != null)
                                lstSaveUpdateNotes = lstSaveUpdateNotes.Concat<GeneralNotes>(generalNotesListUpdate).ToList();
                            bDataNotes = XMLObj.CheckDataConsistency(lstSaveUpdateNotes.Cast<object>().ToList(), true, "NonDrugAllergyMaster");
                        }
                        if (bDataNDA && bDataNotes)
                        {  
                            //XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
                            int trycount = 0;
                        trytosaveagain:
                            try
                            {
                                WriteBlob(HumanID, XMLObj.itemDoc, MySession, insertList, updateList, deleteList, XMLObj, false);
                                trans.Commit();

                                //XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
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

                        nonDrugDTO.NonDrugMasterList= lstSaveUpdateNDA;
                        if (lstSaveUpdateNotes != null && lstSaveUpdateNotes.Count > 0)
                            nonDrugDTO.GeneralNotesObject = lstSaveUpdateNotes[0];
                    }
                    catch (NHibernate.Exceptions.GenericADOException ex)
                    {
                        trans.Rollback();
                        throw new Exception(ex.Message);
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
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
                throw new Exception(ex1.Message);
            }
            
            return nonDrugDTO;
           
        }



       
        #endregion
    }
}
