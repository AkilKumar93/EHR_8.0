using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ISocialHistoryMasterManager : IManagerBase<SocialHistoryMaster, ulong>
    {
        //SocialHistoryDTO SaveUpdateDeleteSocialHistoryMaster(IList<SocialHistoryMaster> insertList, IList<SocialHistoryMaster> updateList, IList<SocialHistoryMaster> deleteList, ulong HumanID, GeneralNotes generalNotesObject, string macAddress);
        //SocialHistoryDTO GetSocialHistoryMasterByHumanID(ulong humanID, ulong encounterID, string medicalInfo, bool From);
        //void SaveSocialHistoryMasterforSummary(IList<SocialHistoryMaster> lstsocial);
        //IList<SocialHistoryMaster> GetSocHisByHumanID(ulong ulHumanID);
    }
    public partial class SocialHistoryMasterManager : ManagerBase<SocialHistoryMaster, ulong>, ISocialHistoryMasterManager
    {
        #region Constructors

        public SocialHistoryMasterManager()
            : base()
        {

        }
        public SocialHistoryMasterManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //#region Get Methods       

        //public SocialHistoryDTO GetSocialHistoryMasterByHumanID(ulong HumanID, ulong encounterID, string medicalInfo, bool From)
        //{
        //    //SocialHistoryMasterDTO problemDTOObject = new SocialHistoryMasterDTO();
        //    //ICriteria criteria = session.GetISession().CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", humanID));
        //    //problemDTOObject.SocialList = criteria.List<SocialHistoryMaster>();
        //    //criteria = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", humanID)).Add(Expression.Eq("Parent_Field", medicalInfo));
        //    //IList<GeneralNotes> ge = criteria.List<GeneralNotes>();
        //    //if (ge.Count > 0)
        //    //{
        //    //    problemDTOObject.GeneralNotesObject = ge[0];
        //    //}
        //    //return problemDTOObject;
        //    //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //    SocialHistoryDTO problemDTOObject = new SocialHistoryDTO();
        //    EncounterManager encMngr = new EncounterManager();
        //    ulong getGenID = 0;
        //    //DetachedCriteria subcrit = DetachedCriteria.For<SocialHistoryMaster>().SetProjection(Projections.Max(Projections.Property("Encounter_ID"))).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Le("Encounter_ID", encounterID)).AddOrder(Order.Desc("Encounter_ID"));Commented for Bug Id:33627
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //Commented for Bug Id:33627
        //        //ICriteria criteria = iMySession.CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", HumanID)).Add(Subqueries.PropertyIn("Encounter_ID", subcrit));
        //        ////ICriteria criteria = session.GetISession().CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Encounter_ID", encounterID));
        //        //problemDTOObject.SocialList = criteria.List<SocialHistoryMaster>();
        //        //subcrit = DetachedCriteria.For<GeneralNotes>().SetProjection(Projections.Max(Projections.Property("Encounter_ID"))).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Le("Encounter_ID", encounterID)).AddOrder(Order.Desc("Encounter_ID"));
        //        IQuery query = iMySession.GetNamedQuery("Get.Social.History.And.Encounter.Details");
        //        query.SetParameter(0, HumanID);
        //        IList<SocialHistoryMaster> lstSocial = new List<SocialHistoryMaster>();
        //        ArrayList resultList = new ArrayList(query.List());
        //        Dictionary<ulong, DateTime> dictEnc = new Dictionary<ulong, DateTime>();
        //        foreach (object objResult in resultList)
        //        {
        //            SocialHistoryMaster objSoc = new SocialHistoryMaster();
        //            object[] lstObj = (object[])objResult;
        //            objSoc.Id = Convert.ToUInt32(lstObj[0]);
        //            objSoc.Human_ID = Convert.ToUInt32(lstObj[1]);
        //            objSoc.Social_Info = Convert.ToString(lstObj[2]);
        //            objSoc.Is_Present = Convert.ToString(lstObj[3]);
        //            objSoc.Description = Convert.ToString(lstObj[4]);
        //            objSoc.Value = Convert.ToString(lstObj[5]);
        //            objSoc.Recodes = Convert.ToString(lstObj[6]);
        //            objSoc.Is_Mandatory = Convert.ToString(lstObj[7]);
        //            objSoc.Created_By = Convert.ToString(lstObj[8]);
        //            objSoc.Created_Date_And_Time = Convert.ToDateTime(lstObj[9].ToString());
        //            objSoc.Modified_By = Convert.ToString(lstObj[10]);
        //            objSoc.Modified_Date_And_Time = Convert.ToDateTime(lstObj[11]);
        //            objSoc.Version = Convert.ToInt32(lstObj[12]);
        //            //objSoc.Encounter_ID = Convert.ToUInt32(lstObj[13]);
        //            if (!dictEnc.ContainsKey(Convert.ToUInt32(lstObj[14])))
        //            dictEnc.Add(Convert.ToUInt32(lstObj[14]), Convert.ToDateTime(lstObj[15]));
        //            lstSocial.Add(objSoc);
        //        }
        //        lstSocial = lstSocial.GroupBy(x => x.Id).Select(x => x.First()).ToList<SocialHistoryMaster>();
        //        if (lstSocial.Count > 0)
        //            problemDTOObject.SocialList = (from obj in lstSocial where obj.Encounter_ID == encounterID select obj).ToList<SocialHistoryMaster>();

        //        ICriteria criteria = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", encounterID));
        //        IList<GeneralNotes> ge = criteria.List<GeneralNotes>();
        //        ge = ge.OrderByDescending(item => item.Modified_Date_And_Time).ToList();
        //        if (ge.Count > 0)
        //        {
        //            problemDTOObject.GeneralNotesObject = ge[0];
        //        }
        //        #region Commented
        //        //<<<<<<< SocialHistoryManager.cs
        //        //<<<<<<< SocialHistoryManager.cs
        //        //            bool Is_PreviousEnc = false;
        //        //            if (problemDTOObject.SocialList.Count == 0)
        //        //            {
        //        //                IList<Encounter> EncLst = new List<Encounter>();
        //        //                EncLst = encMngr.GetEncounterUsingHumanID(HumanID);

        //        //                if (EncLst.Count > 0)
        //        //                {
        //        //                    foreach (Encounter item in EncLst)
        //        //                    {
        //        //                        criteria = session.GetISession().CreateCriteria(typeof(SocialHistory)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Encounter_ID", item.Id));
        //        //                        problemDTOObject.SocialList = criteria.List<SocialHistory>();
        //        //                        if (problemDTOObject.SocialList != null && problemDTOObject.SocialList.Count > 0)
        //        //                        {
        //        //                            Is_PreviousEnc = true;

        //        //                            criteria = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", item.Encounter_ID));
        //        //                            IList<GeneralNotes> geNotest = criteria.List<GeneralNotes>();
        //        //                            if (problemDTOObject.GeneralNotesObject == null && geNotest.Count > 0)
        //        //                                problemDTOObject.GeneralNotesObject = geNotest[0];
        //        //                            break;
        //        //                        }
        //        //                    }
        //        //                }

        //        //                if (!Is_PreviousEnc)
        //        //                {

        //        //                    criteria = session.GetISession().CreateCriteria(typeof(SocialHistory)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Encounter_ID", Convert.ToUInt64(0)));
        //        //                    problemDTOObject.SocialList = criteria.List<SocialHistory>();
        //        //                    criteria = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
        //        //                    if (problemDTOObject.GeneralNotesObject == null && ge.Count > 0)
        //        //                        problemDTOObject.GeneralNotesObject = ge[0];

        //        //                }
        //        //            }

        //        //=======
        //        #endregion
        //        bool Is_PreviousEnc = false;
        //        bool Is_PreviousEnc_GeneralNotes = false;
        //        DateTime curr_DOS=DateTime.MinValue;
        //        if (dictEnc.Count != 0 && dictEnc.Keys.Contains(encounterID))
        //            curr_DOS = Convert.ToDateTime(dictEnc[encounterID]);
        //        //IList<Encounter> EncLst = new List<Encounter>();
        //        /*** commented for perfomance tuning
        //            * It should be called only if socialhistorylist is empty
        //            * added inside the condition  if (problemDTOObject.SocialList.Count == 0)
        //            *   by Jisha   ***/
        //        //  EncLst = encMngr.GetEncounterUsingHumanID(HumanID);
        //        if (problemDTOObject.SocialList != null)
        //        {
        //        if (problemDTOObject.SocialList.Count == 0 )
        //        {
        //            #region Commented for Bug ID: 33627
        //            //EncLst = encMngr.GetEncounterUsingHumanID(HumanID);
        //            //Encounter currentObj = (from objEnc in EncLst where objEnc.Id == encounterID select objEnc).ToList<Encounter>()[0];
        //            //if (EncLst.Count > 0)
        //            //{
        //            //    foreach (Encounter item in EncLst)
        //            //    {
        //            //        //if (encounterID >= item.Id)//Commented for Bug ID: 33627
        //            //        if (DateTime.Compare(item.Date_of_Service, currentObj.Date_of_Service) < 0)
        //            //        {
        //            //            criteria = iMySession.CreateCriteria(typeof(SocialHistory)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Encounter_ID", item.Id));
        //            //            problemDTOObject.SocialList = criteria.List<SocialHistory>();
        //            //            if (problemDTOObject.SocialList != null && problemDTOObject.SocialList.Count > 0)
        //            //            {
        //            //                Is_PreviousEnc = true;
        //            //                //criteria = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", item.Id));
        //            //                //IList<GeneralNotes> geNotest = criteria.List<GeneralNotes>();
        //            //                //if (problemDTOObject.GeneralNotesObject == null && geNotest.Count > 0)
        //            //                //    problemDTOObject.GeneralNotesObject = geNotest[0];
        //            //                break;
        //            //            }
        //            //        }
        //            //    }
        //            //}
        //            #endregion
        //            foreach (KeyValuePair<ulong,DateTime> entry in dictEnc)
        //            {
        //                if (DateTime.Compare(Convert.ToDateTime(entry.Value), curr_DOS) < 0)
        //                {
        //                    if (lstSocial.Count > 0)
        //                    {
        //                        problemDTOObject.SocialList = (from obj in lstSocial where obj.Encounter_ID == Convert.ToUInt32(entry.Key) select obj).ToList<SocialHistoryMaster>();
        //                        getGenID = entry.Key;
        //                        Is_PreviousEnc = true;
        //                        break;
        //                    }

        //                }
        //            }

        //            if (!Is_PreviousEnc)
        //            {

        //                criteria = iMySession.CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Encounter_ID", Convert.ToUInt64(0)));
        //                problemDTOObject.SocialList = criteria.List<SocialHistoryMaster>();
        //                //criteria = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
        //                //if (problemDTOObject.GeneralNotesObject == null && ge.Count > 0)
        //                //    problemDTOObject.GeneralNotesObject = ge[0];

        //            }
        //        }
        //    }
            


        //        if (problemDTOObject.GeneralNotesObject == null)
        //        {
        //            if (getGenID > 0)
        //            {
        //                criteria = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", getGenID));
        //                IList<GeneralNotes> geNotest = criteria.List<GeneralNotes>();
        //                if (geNotest.Count > 0)
        //                {
        //                    problemDTOObject.GeneralNotesObject = geNotest[0];
        //                    Is_PreviousEnc_GeneralNotes = true;
        //                }
        //            }
        //            //foreach (Encounter item in EncLst)
        //            //{
        //            //    if (encounterID >= item.Id)
        //            //    {
        //            //        criteria = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", item.Id));
        //            //        IList<GeneralNotes> geNotest = criteria.List<GeneralNotes>();
        //            //        if (problemDTOObject.GeneralNotesObject == null && geNotest.Count > 0)
        //            //        {
        //            //            problemDTOObject.GeneralNotesObject = geNotest[0];
        //            //            Is_PreviousEnc_GeneralNotes = true;

        //            //            break;
        //            //        }

        //            //    }
        //            //}


        //            if (!Is_PreviousEnc_GeneralNotes)
        //            {
        //                criteria = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", Convert.ToUInt64(0)));
        //                if (problemDTOObject.GeneralNotesObject == null && ge.Count > 0)
        //                    problemDTOObject.GeneralNotesObject = ge[0];


        //            }
        //        }


        //        /***  added for perfomance tuning
        //                 * StaticList only for Social History, not required for Move to button
        //                 *   by Jisha  ***/
        //        //commented by vaishali on 18-11-2015
        //        //if (From)
        //        //{
        //        //    ICriteria criteriastatic = iMySession.CreateCriteria(typeof(StaticLookup)).Add(Expression.Like("Field_Name", "%SOCIAL HISTORY OPTION FOR TOBACCO USE AND EXPOSURE%"));
        //        //    problemDTOObject.StaticList = criteriastatic.List<StaticLookup>();

        //        //}
        //        iMySession.Close();
        //    }
        //    return problemDTOObject;
        //}

        //int iTryCount = 0;

        //public SocialHistoryMasterDTO SaveUpdateDeleteSocialHistoryMaster(IList<SocialHistoryMaster> insertList, IList<SocialHistoryMaster> updateList, IList<SocialHistoryMaster> deleteList, ulong HumanID, GeneralNotes generalNotesObject, string macAddress)
        //{
        //    HumanManager objHumanManager = null;
        //    IList<Human> UpdateHumanList = new List<Human>();
        //    IList<GeneralNotes> generalNotesListInsert = new List<GeneralNotes>();
        //    IList<GeneralNotes> generalNotesListUpdate = new List<GeneralNotes>();
        //    SocialHistoryMasterDTO socHisDTO = new SocialHistoryMasterDTO();
        //    GeneralNotesManager generalNotesManager = new GeneralNotesManager();

        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        if (insertList != null && insertList.Any(a => a.Social_Info == "Marital Status"))
        //        {
        //            UpdateHumanList = iMySession.CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", HumanID)).List<Human>();
        //            UpdateHumanList[0].Marital_Status = insertList.Where(a => a.Social_Info == "Marital Status").Select(a => a.Value).ToArray<string>()[0];
        //        }
        //        else if (updateList != null && updateList.Any(a => a.Social_Info == "Marital Status"))
        //        {
        //            UpdateHumanList = iMySession.CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", HumanID)).List<Human>();
        //            UpdateHumanList[0].Marital_Status = updateList.Where(a => a.Social_Info == "Marital Status").Select(a => a.Value).ToArray<string>()[0];
        //        }
        //        //changed by vaishali on 17-11-2015
        //        if (generalNotesObject != null && generalNotesObject.Id > 0)
        //        {
        //            generalNotesObject.Notes = generalNotesObject.Notes;
        //            generalNotesObject.Modified_By = generalNotesObject.Modified_By;
        //            generalNotesObject.Modified_Date_And_Time = generalNotesObject.Modified_Date_And_Time;
        //            generalNotesListUpdate.Add(generalNotesObject);
        //            generalNotesListInsert = null;
        //        }
        //        else
        //        {
        //            generalNotesListInsert.Add(generalNotesObject);
        //            generalNotesListUpdate = null;
        //        }

        //        iMySession.Close();
        //    }
        //    bool bSocialHistoryMaster = false;
        //    bool bGeneralNotes = false;
        //    IList<SocialHistoryMaster> FinalSocialList = new List<SocialHistoryMaster>();
        //    IList<GeneralNotes> FinalGeneralNotes = new List<GeneralNotes>();
        //    iTryCount = 0;
        //TryAgain:
        //    int iResult = 0;
        //GenerateXml ObjXML = new GenerateXml();
        //    ISession MySession = Session.GetISession();
        //    try
        //    {
        //        using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
        //        {
        //            try
        //            {
        //                if (insertList != null && insertList.Count == 0)
        //                {
        //                    insertList = null;
        //                }
        //                if (updateList != null && updateList.Count == 0)
        //                {
        //                    updateList = null;
        //                }
        //                if (deleteList != null && deleteList.Count == 0)
        //                {
        //                    deleteList = null;
        //                }
        //                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref insertList, ref updateList, deleteList, MySession, macAddress, true, true, HumanID, string.Empty, ref ObjXML);
        //                if (insertList == null)
        //                    insertList = new List<SocialHistoryMaster>();
        //                if (updateList == null)
        //                    updateList = new List<SocialHistoryMaster>();
        //                FinalSocialList = insertList.Concat(updateList).ToList<SocialHistoryMaster>();
        //                bSocialHistoryMaster = ObjXML.CheckDataConsistency(insertList.Concat(updateList).Cast<object>().ToList(), false, "");   
        //                if (iResult == 2)
        //                {
        //                    if (iTryCount < 5)
        //                    {
        //                        iTryCount++;
        //                        goto TryAgain;
        //                    }
        //                    else
        //                    {
        //                        trans.Rollback();
        //                        //MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {
        //                    trans.Rollback();
        //                    //MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");
        //                }

        //                if (UpdateHumanList != null && UpdateHumanList.Count > 0)
        //                {
        //                    objHumanManager = new HumanManager();
        //                    //changed by vaishali on 17-11-2015
        //                    IList<Human> insertHumanList = null;
        //                    iResult = objHumanManager.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref insertHumanList, ref UpdateHumanList, null, MySession, macAddress, true, false, UpdateHumanList[0].Id, "", ref ObjXML);

        //                    if (iResult == 2)
        //                    {
        //                        if (iTryCount < 5)
        //                        {
        //                            iTryCount++;
        //                            goto TryAgain;
        //                        }
        //                        else
        //                        {

        //                            trans.Rollback();
        //                            // MySession.Close();
        //                            throw new Exception("Deadlock is occured. Transaction failed");
        //                        }
        //                    }
        //                    else if (iResult == 1)
        //                    {

        //                        trans.Rollback();
        //                        //MySession.Close();
        //                        throw new Exception("Exception is occured. Transaction failed");

        //                    }
        //                }

        //                if (generalNotesObject != null)
        //                {
        //                    iResult = generalNotesManager.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref generalNotesListInsert, ref generalNotesListUpdate, null, MySession, macAddress, true, true, HumanID, "SocialHistoryMaster", ref ObjXML);
        //                    if (generalNotesListInsert == null)
        //                        generalNotesListInsert = new List<GeneralNotes>();
        //                    if (generalNotesListUpdate == null)
        //                        generalNotesListUpdate = new List<GeneralNotes>();
        //                    FinalGeneralNotes = generalNotesListInsert.Concat(generalNotesListUpdate).ToList<GeneralNotes>();
        //                    bGeneralNotes = ObjXML.CheckDataConsistency(generalNotesListInsert.Concat(generalNotesListUpdate).Cast<object>().ToList(), false, "SocialHistoryMaster");
        //                    if (iResult == 2)
        //                    {
        //                        if (iTryCount < 5)
        //                        {
        //                            iTryCount++;
        //                            goto TryAgain;
        //                        }
        //                        else
        //                        {

        //                            trans.Rollback();
        //                            // MySession.Close();
        //                            throw new Exception("Deadlock is occured. Transaction failed");

        //                        }
        //                    }
        //                    else if (iResult == 1)
        //                    {

        //                        trans.Rollback();
        //                        //MySession.Close();
        //                        throw new Exception("Exception is occured. Transaction failed");

        //                    }
        //                }
        //                if (bSocialHistoryMaster && bGeneralNotes)
        //                {
        //                    trans.Commit();
        //                    ObjXML.itemDoc.Save(ObjXML.strXmlFilePath);
        //                }
        //                else
        //                    throw new Exception("Data inconsistency detected while saving. Please try again or notify support.");
        //                //trans.Commit();
        //            }
        //            catch (NHibernate.Exceptions.GenericADOException ex)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception(ex.Message);
        //            }
        //            catch (Exception e)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception(e.Message);
        //            }
        //            finally
        //            {
        //                MySession.Close();
        //            }                 
        //        }
        //        //IList<SocialHistoryMaster> CombinedList = new List<SocialHistoryMaster>();
        //        //if (insertList != null && insertList.Count > 0)
        //        //{
        //        //    CombinedList = CombinedList.Concat(insertList).ToList<SocialHistoryMaster>();
        //        //}
        //        //if (updateList != null && updateList.Count > 0)
        //        //{
        //        //    CombinedList = CombinedList.Concat(updateList).ToList<SocialHistoryMaster>();
        //        //}
        //        //if (CombinedList.Any(a => a.Social_Info == "Marital Status"))
        //        //    CarePlanSaveOrUpdate(CombinedList, macAddress);

        //    }

        //    catch (Exception ex1)
        //    {
        //        //MySession.Close();
        //        throw new Exception(ex1.Message);
        //    }
        //    if (FinalGeneralNotes.Count > 0)
        //        socHisDTO.GeneralNotesObject = FinalGeneralNotes[0];
        //    socHisDTO.SocialList = FinalSocialList;
        //    return socHisDTO;
        //}

        //public SocialHistoryMasterDTO CreateDTOForSocialHistoryMaster(ulong HumanID, string medicalInfo, ulong Encounter_Id)
        //{
        //    //SocialHistoryMasterDTO objpro = new SocialHistoryMasterDTO();
        //    //ICriteria criteria = session.GetISession().CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", HumanID));
        //    //objpro.SocialList = criteria.List<SocialHistoryMaster>();
        //    //criteria = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo));
        //    //IList<GeneralNotes> ge = criteria.List<GeneralNotes>();
        //    //if (ge.Count > 0)
        //    //{
        //    //    objpro.GeneralNotesObject = ge[0];
        //    //}
        //    //return objpro;
        //    //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();

        //    SocialHistoryMasterDTO objpro = new SocialHistoryMasterDTO();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria criteria = iMySession.CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Encounter_ID", Encounter_Id));
        //        objpro.SocialList = criteria.List<SocialHistoryMaster>();
        //        criteria = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Parent_Field", medicalInfo)).Add(Expression.Eq("Encounter_ID", Encounter_Id));
        //        IList<GeneralNotes> ge = criteria.List<GeneralNotes>();
        //        if (ge.Count > 0)
        //        {
        //            objpro.GeneralNotesObject = ge[0];
        //        }
        //        iMySession.Close();
        //    }
        //    return objpro;
        //}

        //public void SaveSocialHistoryMasterforSummary(IList<SocialHistoryMaster> lstsocial)
        //{
        //    IList<SocialHistoryMaster> SocHisTemp = null;
        //    SaveUpdateDelete_DBAndXML_WithTransaction(ref lstsocial, ref SocHisTemp, null, string.Empty, false, false, 0, "");
        //}

        //public void CarePlanSaveOrUpdate(IList<SocialHistoryMaster> SocialHistoryMasterLst, string MacAddress)
        //{
        //    CarePlanManager objCarePlanManager = new CarePlanManager();
        //    IList<CarePlan> lstSave = new List<CarePlan>();
        //    IList<CarePlan> lstUpdate = new List<CarePlan>();
        //    IList<CarePlan> lstDelete = new List<CarePlan>();
        //    ulong uHuman_id = SocialHistoryMasterLst[0].Human_ID;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //        IList<CarePlan> lst = iMySession.CreateCriteria(typeof(CarePlan)).Add(Expression.Eq("Care_Name_Value", "Marital Status")).Add(Expression.Eq("Encounter_ID", SocialHistoryMasterLst[0].Encounter_ID)).Add(Expression.Eq("Human_ID", SocialHistoryMasterLst[0].Human_ID)).List<CarePlan>();
        //        if (lst != null && lst.Count > 0)
        //        {
        //            lstUpdate = lst;
        //            lstUpdate[0].Status = SocialHistoryMasterLst.Where(a => a.Social_Info == "Marital Status").Select(a => a.Value).ToArray<string>()[0];
        //            lstUpdate[0].Care_Plan_Notes = SocialHistoryMasterLst.Where(a => a.Social_Info == "Marital Status").Select(a => a.Description).ToArray<string>()[0];
        //        }
        //        else
        //        {

        //            CarePlan objCarePlan = new CarePlan ();
        //            objCarePlan.Human_ID = SocialHistoryMasterLst[0].Human_ID;
        //            objCarePlan.Care_Name = "Patient Details";
        //            objCarePlan.Care_Name_Value = "Marital Status";
        //            objCarePlan.Encounter_ID = SocialHistoryMasterLst[0].Encounter_ID;
        //            objCarePlan.Status = SocialHistoryMasterLst.Where(a => a.Social_Info == "Marital Status").Select(a => a.Value).ToArray<string>()[0];
        //            objCarePlan.Care_Plan_Notes = SocialHistoryMasterLst.Where(a => a.Social_Info == "Marital Status").Select(a => a.Description).ToArray<string>()[0];
        //            lstSave.Add(objCarePlan);
        //        }
        //        iMySession.Close();
        //    }
        //    //objSocialHistoryMasterManager.SaveUpdateDeleteWithTransaction(ref lstSave, lstUpdate, lstDelete, MacAddress);
        //    objCarePlanManager.SaveUpdateDelete_DBAndXML_WithTransaction(ref lstSave, ref lstUpdate, lstDelete, string.Empty, true, false, SocialHistoryMasterLst[0].Encounter_ID, string.Empty);

        //}

        //public IList<SocialHistoryMaster> GetSocHisByHumanID(ulong ulHumanID)
        //{
        //    IList<SocialHistory> SocHistoryList = new List<SocialHistoryMaster>();
        //    using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //ISession mySession = NHibernateSessionManager.Instance.CreateISession();
        //        //  ISQLQuery sql = session.GetISession().CreateSQLQuery("select m.* from rcopia_medication m where m.Human_ID='"+ulHumanID+"' group by m.last_modified_date").AddEntity("m",typeof(Rcopia_Medication));
        //        ICriteria crit = mySession.CreateCriteria(typeof(SocialHistoryMaster)).Add(Expression.Eq("Human_ID", ulHumanID));
        //        SocHistoryList = crit.List<SocialHistoryMaster>();
        //        mySession.Close();
        //    }
        //    return SocHistoryList;
        //}
        //#endregion
    }
}
