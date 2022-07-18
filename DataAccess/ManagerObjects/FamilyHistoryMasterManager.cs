using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IFamilyHistoryMasterManager : IManagerBase<FamilyHistoryMaster, uint>
    {
        //FamilyDTO GetFamilyHistoryManagerByPatient(ulong Human_ID, int pagenumber, int maxnumber);
        //FamilyDTO UpdateFamilyHistory(FamilyHistory famHis, IList<FamilyDisease> InsertFamilyDiseaseLst, IList<FamilyDisease> DeleteFamilyDiseaseLst, int pagenumber, int maxnumber, string macAddress);
        //FamilyDTO DeleteFamilyHistory(FamilyHistory objfamHis, int pagenumber, int maxnumber, string macAddress);
        //FamilyDTO SaveFamilyHistory(FamilyHistory famHis, IList<FamilyDisease> famDis, int pagenumber, int maxnumber, string macAddress);//prabu 13/04/10

        //FamilyDTO SaveUpdateDeleteFamilyHistoryMaster(ulong Human_Id, IList<FamilyHistoryMaster> SaveLst, IList<FamilyHistoryMaster> UpdateLst, IList<FamilyHistoryMaster> DeleteLst, IList<FamilyDisease> DiseaseSaveLst, IList<FamilyDisease> DiseaseUpdateLst, IList<FamilyDisease> DiseaseDeleteLst, GeneralNotes objGeneralNotes, string macAddress, ulong Encounter_Id);
        //FamilyDTO GetFamilyHistoryMaster(ulong HumanId, ulong Encounter_Id);
        //FamilyDTO GetAllLookUPDetails(string[] Field_Name, string sOrder);

    }
    public class FamilyHistoryMasterManager : ManagerBase<FamilyHistoryMaster, uint>, IFamilyHistoryMasterManager
    {
        #region Constructors

        public FamilyHistoryMasterManager()
            : base()
        {

        }
        public FamilyHistoryMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //#region Get Method


        //public FamilyDTO GetFamilyHistoryManager(ulong HumanId, ulong Encounter_Id)
        //{
        //    #region "Encounter Specific"

        //    FamilyDTO objFamilyDTO = new FamilyDTO();
        //    IList<GeneralNotes> generalnotes = new List<GeneralNotes>();
        //    ulong getGenID = 0;
        //    //DetachedCriteria subcrit = DetachedCriteria.For<FamilyHistoryMaster>().SetProjection(Projections.Max(Projections.Property("Encounter_Id"))).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Le("Encounter_Id", Encounter_Id)).AddOrder(Order.Desc("Encounter_Id"));
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //ICriteria Result1 = session.GetISession().CreateCriteria(typeof(FamilyHistoryMaster)).Add(Expression.Eq("Human_ID", HumanId)).Add(Subqueries.PropertyIn("Encounter_Id", subcrit));
        //        //ICriteria Result1 = iMySession.CreateCriteria(typeof(FamilyHistoryMaster)).Add(Expression.Eq("Human_ID", HumanId)).Add(Subqueries.PropertyIn("Encounter_Id", subcrit));


        //        ////ICriteria Result1 = session.GetISession().CreateCriteria(typeof(FamilyHistoryMaster)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Encounter_Id",Encounter_Id));
        //        //objFamilyDTO.Family_History = Result1.List<FamilyHistoryMaster>();
        //        //subcrit = DetachedCriteria.For<GeneralNotes>().SetProjection(Projections.Max(Projections.Property("Encounter_ID"))).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Parent_Field", "Family History")).Add(Expression.Le("Encounter_ID", Encounter_Id)).AddOrder(Order.Desc("Encounter_ID"));
        //        IQuery query1 = iMySession.GetNamedQuery("Get.Family.History.And.Encounter.Details");
        //        query1.SetParameter(0, HumanId);
        //        IList<FamilyHistoryMaster> lstFamily = new List<FamilyHistoryMaster>();
        //        ArrayList resultList = new ArrayList(query1.List());
        //        Dictionary<ulong, DateTime> dictEnc = new Dictionary<ulong, DateTime>();
        //        foreach (object objResult in resultList)
        //        {
        //            FamilyHistoryMaster objFmly = new FamilyHistoryMaster();
        //            object[] lstObj = (object[])objResult;
        //            objFmly.Id = Convert.ToUInt32(lstObj[0]);
        //            objFmly.Human_ID = Convert.ToUInt32(lstObj[1]);
        //            objFmly.RelationShip = Convert.ToString(lstObj[2]);
        //            objFmly.Age = Convert.ToInt32(lstObj[3]);
        //            objFmly.Status = Convert.ToString(lstObj[4]);
        //            objFmly.Cause_Of_Death = Convert.ToString(lstObj[5]);
        //            objFmly.Created_By = Convert.ToString(lstObj[6]);
        //            objFmly.Created_Date_And_Time = Convert.ToDateTime(lstObj[7].ToString());
        //            objFmly.Modified_By = Convert.ToString(lstObj[8]);
        //            objFmly.Modified_Date_And_Time = Convert.ToDateTime(lstObj[9]);
        //            objFmly.Version = Convert.ToInt32(lstObj[10]);
        //            //objFmly.Encounter_Id = Convert.ToUInt32(lstObj[11]);
        //            if (!dictEnc.ContainsKey(Convert.ToUInt32(lstObj[12])))
        //                dictEnc.Add(Convert.ToUInt32(lstObj[12]), Convert.ToDateTime(lstObj[13]));
        //            lstFamily.Add(objFmly);
        //        }
        //        lstFamily = lstFamily.GroupBy(x => x.Id).Select(x => x.First()).ToList<FamilyHistoryMaster>();
        //        DateTime curr_DOS = DateTime.MinValue;
        //        if (lstFamily.Count > 0)
        //        {
        //            //objFamilyDTO.Family_History = (from obj in lstFamily where obj.Encounter_Id == Encounter_Id select obj).ToList<FamilyHistoryMaster>();

        //            curr_DOS = Convert.ToDateTime(dictEnc[Encounter_Id]);
        //        }
        //        //ICriteria Result2 = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Parent_Field", "Family History")).Add(Subqueries.PropertyIn("Encounter_ID", subcrit));
        //        //ICriteria Result2 = iMySession.CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Parent_Field", "Family History")).Add(Subqueries.PropertyIn("Encounter_ID", subcrit));

        //        ICriteria Result2 = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Parent_Field", "Family History")).Add(Expression.Eq("Encounter_ID", Encounter_Id));
        //        generalnotes = Result2.List<GeneralNotes>();
        //        generalnotes = generalnotes.OrderByDescending(item => item.Modified_Date_And_Time).ToList();

        //        //curr_DOS = Convert.ToDateTime(dictEnc[Encounter_Id]);
        //        if (objFamilyDTO.Family_History.Count == 0)
        //        {
        //            foreach (KeyValuePair<ulong, DateTime> entry in dictEnc)
        //            {
        //                if (DateTime.Compare(Convert.ToDateTime(entry.Value), curr_DOS) < 0)
        //                {
        //                    if (lstFamily.Count > 0)
        //                    {
        //                        //objFamilyDTO.Family_History = (from obj in lstFamily where obj.Encounter_Id == Convert.ToUInt32(entry.Key) select obj).ToList<FamilyHistoryMaster>();
        //                        getGenID = entry.Key;
        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //        // ISQLQuery query = session.GetISession().CreateSQLQuery("SELECT d.* FROM family_history_disease as d WHERE d.Family_History_Id in(SELECT f.Family_History_Id FROM family_history as f Where f.Human_Id=" + HumanId + ")").AddEntity("d", typeof(FamilyDisease));
        //        ISQLQuery query = iMySession.CreateSQLQuery("SELECT d.* FROM family_history_disease as d WHERE d.Family_History_Id in(SELECT f.Family_History_Id FROM family_history as f Where f.Human_Id=" + HumanId + ")").AddEntity("d", typeof(FamilyDisease));
        //        objFamilyDTO.Family_Disease = query.List<FamilyDisease>();

        //        iMySession.Close();
        //    }
        //    if (generalnotes != null && generalnotes.Count > 0)
        //    {
        //        objFamilyDTO.objGeneralNotes = generalnotes[0];
        //    }
        //    else
        //    {
        //        if (getGenID > 0)
        //        {
        //            ICriteria Result2 = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Parent_Field", "Family History")).Add(Expression.Eq("Encounter_ID", getGenID));
        //            generalnotes = Result2.List<GeneralNotes>();
        //            generalnotes = generalnotes.OrderByDescending(item => item.Modified_Date_And_Time).ToList();
        //            if (generalnotes.Count > 0)
        //                objFamilyDTO.objGeneralNotes = generalnotes[0];
        //        }
        //    }
        //    return objFamilyDTO;

        //    #endregion

        //    #region "Human Specific"
        //    //bool IsPrevious = false;
        //    //ulong Enc_Id = 0;
        //    //FamilyDTO objFamilyDTO = new FamilyDTO();

        //    //ICriteria Result1 = session.GetISession().CreateCriteria(typeof(FamilyHistory)).Add(Expression.Eq("Human_ID", HumanId));//.Add(Expression.Eq("Encounter_Id", Encounter_Id));
        //    //objFamilyDTO.Family_History = Result1.List<FamilyHistory>();

        //    //IList<FamilyHistory> lst = objFamilyDTO.Family_History.ToList();
        //    //if (lst.Any(a => a.Encounter_Id == Encounter_Id))
        //    //{
        //    //    objFamilyDTO.Family_History = lst.Where(a => a.Encounter_Id == Encounter_Id).ToList<FamilyHistory>();
        //    //    Enc_Id = Encounter_Id;
        //    //}
        //    //else
        //    //{

        //    //    EncounterManager encMngr = new EncounterManager();
        //    //    IList<Encounter> EncLst = new List<Encounter>();
        //    //    EncLst = encMngr.GetEncounterUsingHumanID(HumanId);
        //    //    if (EncLst.Count > 0 && objFamilyDTO.Family_History.Count > 0)
        //    //    {
        //    //        foreach (Encounter item in EncLst)
        //    //        {
        //    //            if (Encounter_Id >= item.Id)
        //    //            {
        //    //                objFamilyDTO.Family_History = lst.Where(a => a.Encounter_Id == item.Id).ToList<FamilyHistory>();

        //    //                if (objFamilyDTO.Family_History.Count > 0)
        //    //                {
        //    //                    Enc_Id = item.Id;
        //    //                    IsPrevious = true;
        //    //                    break;
        //    //                }
        //    //            }
        //    //        }

        //    //    }

        //    //    if (!IsPrevious)
        //    //    {
        //    //        objFamilyDTO.Family_History = lst.Where(a => a.Encounter_Id == Convert.ToUInt16(0)).ToList<FamilyHistory>();
        //    //        Enc_Id = 0;
        //    //    }
        //    //}


        //    // IList<GeneralNotes> generalnotes=new List<GeneralNotes>();

        //    // ICriteria Result2 = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Encounter_ID", Enc_Id)).Add(Expression.Eq("Parent_Field", "Family History"));
        //    // generalnotes = Result2.List<GeneralNotes>();


        //    //if (generalnotes.Count==0)
        //    //{
        //    //    Result2 = session.GetISession().CreateCriteria(typeof(GeneralNotes)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Encounter_ID", Enc_Id)).Add(Expression.Eq("Parent_Field", "Family History"));
        //    //    generalnotes = Result2.List<GeneralNotes>();
        //    //}
        //    //ISQLQuery query = session.GetISession().CreateSQLQuery("SELECT d.* FROM family_history_disease as d WHERE d.Family_History_Id in(SELECT f.Family_History_Id FROM family_history as f Where f.Human_Id=" + HumanId + " and f.Encounter_ID=" + Enc_Id + ")").AddEntity("d", typeof(FamilyDisease));
        //    //objFamilyDTO.Family_Disease = query.List<FamilyDisease>();

        //    //if (generalnotes != null && generalnotes.Count > 0)
        //    //{
        //    //    objFamilyDTO.objGeneralNotes = generalnotes[0];
        //    //}
        //    //return objFamilyDTO;
        //    #endregion
        //}

        //public FamilyDTO SaveUpdateDeleteFamilyHistoryMaster(ulong Human_Id, IList<FamilyHistoryMaster> SaveLst, IList<FamilyHistoryMaster> UpdateLst, IList<FamilyHistoryMaster> DeleteLst, IList<FamilyDisease> DiseaseSaveLst, IList<FamilyDisease> DiseaseUpdateLst, IList<FamilyDisease> DiseaseDeleteLst, GeneralNotes objGeneralNotes, string macAddress, ulong Encounter_Id)
        //{
        //    IList<GeneralNotes> generalNotesListInsert = new List<GeneralNotes>();
        //    IList<GeneralNotes> generalNotesListUpdate = new List<GeneralNotes>();
        //    IList<FamilyDisease> FinalDiseaseSaveLst = new List<FamilyDisease>();
        //    GenerateXml XMLObj = new GenerateXml();
        //    int iTryCount = 0;
        //TryAgain:
        //    int iResult = 0;

        //    ISession MySession = Session.GetISession();
        //    // ITransaction trans = null;
        //    try
        //    {
        //        bool IsFamilyHistoryMaster = true, IsFamilyDiesease = true, isFinalNotesSaveLst = true;
        //        using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
        //        {
        //            try
        //            {
        //                if (SaveLst != null && UpdateLst != null && DeleteLst != null)
        //                {
        //                    if (SaveLst.Count > 0 || UpdateLst.Count > 0 || DeleteLst.Count > 0)
        //                    {
        //                        //iResult = SaveUpdateDeleteWithoutTransaction(ref SaveLst, UpdateLst, DeleteLst, MySession, macAddress);
        //                        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveLst, ref UpdateLst, DeleteLst, MySession, macAddress, true, true, Human_Id, string.Empty, ref XMLObj);
        //                        if (iResult == 2)
        //                        {
        //                            if (iTryCount < 5)
        //                            {
        //                                iTryCount++;
        //                                goto TryAgain;
        //                            }
        //                            else
        //                            {
        //                                trans.Rollback();
        //                                // MySession.Close();
        //                                throw new Exception("Deadlock occurred. Transaction failed.");
        //                            }
        //                        }
        //                        else if (iResult == 1)
        //                        {
        //                            trans.Rollback();
        //                            //MySession.Close();
        //                            throw new Exception("Exception occurred. Transaction failed.");
        //                        }
        //                        //IsFamilyHistoryMaster = XMLObj.CheckDataConsistency(SaveLst.Concat(UpdateLst).Cast<object>().ToList(), false);
        //                        if (SaveLst != null && SaveLst.Count > 0 && UpdateLst != null && UpdateLst.Count > 0)
        //                            IsFamilyHistoryMaster = XMLObj.CheckDataConsistency(SaveLst.Concat(UpdateLst).Cast<object>().ToList(), false, string.Empty);
        //                        else if ((SaveLst != null && SaveLst.Count > 0) || (UpdateLst != null && UpdateLst.Count > 0))
        //                        {
        //                            if (SaveLst != null && SaveLst.Count > 0)
        //                                IsFamilyHistoryMaster = XMLObj.CheckDataConsistency(SaveLst.Cast<object>().ToList(), false, string.Empty);
        //                            else if (UpdateLst != null && UpdateLst.Count > 0)
        //                                IsFamilyHistoryMaster = XMLObj.CheckDataConsistency(UpdateLst.Cast<object>().ToList(), false, string.Empty);
        //                        }
        //                    }
        //                }

        //                if (DiseaseSaveLst != null && DiseaseDeleteLst != null)
        //                {
        //                    if (DiseaseSaveLst != null && DiseaseSaveLst.Count > 0)
        //                    {
        //                        FamilyDisease objFamilyDisease;
        //                        IList<FamilyHistoryMaster> LstFamilyHistoryMaster = new List<FamilyHistoryMaster>();
        //                        LstFamilyHistoryMaster = LstFamilyHistoryMaster.Concat(SaveLst).Concat(UpdateLst).ToList();
        //                        for (int j = 0; j < DiseaseSaveLst.Count; j++)
        //                        {
        //                            objFamilyDisease = new FamilyDisease();
        //                            objFamilyDisease.Disease = DiseaseSaveLst[j].Disease;
        //                            objFamilyDisease.Family_History_ID = LstFamilyHistoryMaster.Where(a => a.RelationShip.Trim() == DiseaseSaveLst[j].Internal_Property_Relation.Trim()).ToList<FamilyHistoryMaster>()[0].Id;
        //                            objFamilyDisease.Human_ID = LstFamilyHistoryMaster.Where(a => a.RelationShip.Trim() == DiseaseSaveLst[j].Internal_Property_Relation.Trim()).ToList<FamilyHistoryMaster>()[0].Human_ID;//BugID:50199
        //                            objFamilyDisease.Recodes = DiseaseSaveLst[j].Recodes;
        //                            objFamilyDisease.Created_By = DiseaseSaveLst[j].Created_By;
        //                            objFamilyDisease.Created_Date_And_Time = DiseaseSaveLst[j].Created_Date_And_Time;
        //                            objFamilyDisease.Internal_Property_Relation = DiseaseSaveLst[j].Internal_Property_Relation;
        //                            //var d=LstFamilyHistoryMaster.Where(a=>a.RelationShip.Trim()==DiseaseSaveLst[j].Relation.Trim()).ToList<FamilyHistoryMaster>()[0].Id;
        //                            FinalDiseaseSaveLst.Add(objFamilyDisease);
        //                        }
        //                    }

        //                    FamilyDiseaseManager objManager = new FamilyDiseaseManager();
        //                    //iResult = objManager.SaveUpdateDeleteWithoutTransaction(ref FinalDiseaseSaveLst, DiseaseUpdateLst, DiseaseDeleteLst, MySession, macAddress);
        //                    IList<FamilyDisease> SaveFamilyDiseaseList = FinalDiseaseSaveLst.Concat(DiseaseUpdateLst).Concat(DiseaseDeleteLst).ToList();                           
        //                    iResult = objManager.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref FinalDiseaseSaveLst, ref DiseaseUpdateLst, DiseaseDeleteLst, MySession, macAddress, true, true, Human_Id, string.Empty, ref XMLObj);                            
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
        //                            //MySession.Close();
        //                            throw new Exception("Deadlock occurred. Transaction failed.");
        //                        }
        //                    }
        //                    else if (iResult == 1)
        //                    {
        //                        trans.Rollback();
        //                        //MySession.Close();
        //                        throw new Exception("Exception occurred. Transaction failed.");
        //                    }
        //                   // IsFamilyDiesease = XMLObj.CheckDataConsistency(FinalDiseaseSaveLst.Concat(DiseaseUpdateLst).Cast<object>().ToList(), false);
        //                    if (FinalDiseaseSaveLst != null && FinalDiseaseSaveLst.Count > 0 && DiseaseUpdateLst != null && DiseaseUpdateLst.Count > 0)
        //                        IsFamilyDiesease = XMLObj.CheckDataConsistency(FinalDiseaseSaveLst.Concat(DiseaseUpdateLst).Cast<object>().ToList(), false, string.Empty);
        //                    else if ((FinalDiseaseSaveLst != null && FinalDiseaseSaveLst.Count > 0) || (DiseaseUpdateLst != null && DiseaseUpdateLst.Count > 0))
        //                    {
        //                        if (FinalDiseaseSaveLst != null && FinalDiseaseSaveLst.Count > 0)
        //                            IsFamilyDiesease = XMLObj.CheckDataConsistency(FinalDiseaseSaveLst.Cast<object>().ToList(), false, string.Empty);
        //                        else if (DiseaseUpdateLst != null && DiseaseUpdateLst.Count > 0)
        //                            IsFamilyDiesease = XMLObj.CheckDataConsistency(DiseaseUpdateLst.Cast<object>().ToList(), false, string.Empty);
        //                    }
        //                }
        //                if (objGeneralNotes != null)
        //                {                           
        //                    //Added by balaji 2015-11-18
        //                    if (objGeneralNotes.Id != 0)
        //                    {
        //                        generalNotesListUpdate.Add(objGeneralNotes);
        //                    }
        //                    else { generalNotesListInsert.Add(objGeneralNotes); }
                         
        //                    GeneralNotesManager genMgr = new GeneralNotesManager();
        //                    iResult = genMgr.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref generalNotesListInsert, ref generalNotesListUpdate, null, MySession, macAddress, true, true, Human_Id, "FamilyHistoryMaster", ref XMLObj);                            
        //                    //iResult = genMgr.SaveUpdateDeleteGeneralNotes(generalNotesListInsert, generalNotesListUpdate, MySession, macAddress);
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
        //                            MySession.Close();
        //                            throw new Exception("Deadlock occurred. Transaction failed.");
        //                        }
        //                    }
        //                    else if (iResult == 1)
        //                    {
        //                        trans.Rollback();
        //                        MySession.Close();
        //                        throw new Exception("Exception occurred. Transaction failed.");
        //                    }

        //                    if (generalNotesListInsert != null && generalNotesListInsert.Count > 0 && generalNotesListUpdate != null && generalNotesListUpdate.Count > 0)
        //                        isFinalNotesSaveLst = XMLObj.CheckDataConsistency(generalNotesListInsert.Concat(generalNotesListUpdate).Cast<object>().ToList(), false, "FamilyHistoryMaster");
        //                    else if ((generalNotesListInsert != null && generalNotesListInsert.Count > 0) || (generalNotesListUpdate != null && generalNotesListUpdate.Count > 0))
        //                    {
        //                        if (generalNotesListInsert != null && generalNotesListInsert.Count > 0)
        //                            isFinalNotesSaveLst = XMLObj.CheckDataConsistency(generalNotesListInsert.Cast<object>().ToList(), true, "FamilyHistoryMaster");
        //                        else if (generalNotesListUpdate != null && generalNotesListUpdate.Count > 0)
        //                            isFinalNotesSaveLst = XMLObj.CheckDataConsistency(generalNotesListUpdate.Cast<object>().ToList(), false, "FamilyHistoryMaster");
        //                    }
        //                }
        //                if (IsFamilyHistoryMaster && IsFamilyDiesease && isFinalNotesSaveLst)
        //                {
        //                    trans.Commit();
        //                    XMLObj.itemDoc.Save(XMLObj.strXmlFilePath);
        //                }
        //                else
        //                    throw new Exception("Data inconsistency detected while saving. Please try again or notify support.");
        //                //MySession.Flush();
        //                //trans.Commit();
        //            }

        //            catch (NHibernate.Exceptions.GenericADOException ex)
        //            {
        //                trans.Rollback();
        //                throw new Exception(ex.Message);
        //            }
        //            catch (Exception e)
        //            {
        //                trans.Rollback();
        //                throw new Exception(e.Message);
        //            }
        //            finally
        //            {
        //                MySession.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex1)
        //    {
        //        //MySession.Close();
        //        throw new Exception(ex1.Message);
        //    }

        //    ulong encounterid = 0;
        //    //if ((SaveLst !=null && SaveLst.Count > 0) || (UpdateLst!=null && UpdateLst.Count > 0))
        //    //{
        //    //    if (SaveLst != null &&  SaveLst.Count > 0)               
        //    //        encounterid = SaveLst[0].Encounter_Id;              
        //    //    else               
        //    //        encounterid = UpdateLst[0].Encounter_Id;               
        //    //}
        //    //if (DeleteLst != null && DeleteLst.Count > 0)           
        //    //    encounterid = DeleteLst[0].Encounter_Id;
        //    if (generalNotesListInsert != null && generalNotesListInsert.Count > 0)            
        //        encounterid = generalNotesListInsert[0].Encounter_ID;
        //    else if (generalNotesListUpdate != null && generalNotesListUpdate.Count > 0)                         
        //        encounterid = generalNotesListUpdate[0].Encounter_ID;                         

        //    //GenerateXml XMLObj = new GenerateXml();
        //    //ulong encounterid = 0;
        //    //if (SaveLst.Count > 0 || UpdateLst.Count > 0)
        //    //{
        //    //    for (int l = 0; l < UpdateLst.Count; l++)
        //    //    {
        //    //        UpdateLst[l].Version = UpdateLst[l].Version + 1;
        //    //    }
        //    //    if (SaveLst.Count > 0)
        //    //    {

        //    //        encounterid = SaveLst[0].Encounter_Id;
        //    //    }
        //    //    else
        //    //    {
        //    //        encounterid = UpdateLst[0].Encounter_Id;
        //    //    }

        //    //    if (SaveLst.Count > 0)
        //    //        XMLObj.GenerateXmlSaveStatic(SaveLst.Cast<object>().ToList(), Human_Id, string.Empty);

        //    //    if (UpdateLst.Count > 0)
        //    //        XMLObj.GenerateXmlUpdate(UpdateLst.Cast<object>().ToList(), Human_Id, string.Empty);
        //    //}

        //    //if (DeleteLst.Count > 0)
        //    //{
        //    //    encounterid = DeleteLst[0].Encounter_Id;
        //    //    List<object> lstObj = DeleteLst.Cast<object>().ToList();
        //    //    XMLObj.DeleteXmlNode(Human_Id, lstObj, string.Empty);
        //    //}


        //    //if (FinalDiseaseSaveLst.Count > 0 || DiseaseUpdateLst.Count > 0)
        //    //{
        //    //    for (int l = 0; l < DiseaseUpdateLst.Count; l++)
        //    //    {
        //    //        DiseaseUpdateLst[l].Version = DiseaseUpdateLst[l].Version + 1;
        //    //    }
               
        //    //    if (FinalDiseaseSaveLst.Count > 0)
        //    //        XMLObj.GenerateXmlSaveStatic(FinalDiseaseSaveLst.Cast<object>().ToList(), Human_Id, string.Empty);

        //    //    if (DiseaseUpdateLst.Count > 0)
        //    //        XMLObj.GenerateXmlUpdate(DiseaseUpdateLst.Cast<object>().ToList(), Human_Id, string.Empty);

        //    //}
            
        //    //if (DiseaseDeleteLst.Count > 0)
        //    //{
        //    //    List<object> lstObj = DiseaseDeleteLst.Cast<object>().ToList();
        //    //    XMLObj.DeleteXmlNode(Human_Id, lstObj, string.Empty);
        //    //}

        //    //if (generalNotesListInsert.Count > 0)
        //    //{

        //    //    encounterid = generalNotesListInsert[0].Encounter_ID;
        //    //    List<object> lstObj = generalNotesListInsert.Cast<object>().ToList();
        //    //    XMLObj.GenerateXmlSaveStatic(lstObj, Human_Id, "FamilyHistoryMaster");
        //    //}
        //    //else if (generalNotesListUpdate.Count > 0)
        //    //{
        //    //    for (int l = 0; l < generalNotesListUpdate.Count; l++)
        //    //    {
        //    //        generalNotesListUpdate[l].Version = generalNotesListUpdate[l].Version + 1;
        //    //    }

        //    //    encounterid = generalNotesListUpdate[0].Encounter_ID;
        //    //    List<object> lstObj = generalNotesListUpdate.Cast<object>().ToList();
        //    //    XMLObj.GenerateXmlUpdate(lstObj, Human_Id, "FamilyHistoryMaster");
        //    //}
        //    //return GetFamilyHistoryMaster(Human_Id, Encounter_Id);           
        //}



        ////public FamilyDTO GetFamilyHistoryMasterManagerByPatient(ulong Human_ID, int pagenumber, int maxnumber)
        ////{
        ////    ArrayList ary = null;
        ////    int PageNumber = pagenumber - 1;
        ////    FamilyDTO FamDto = new FamilyDTO();
        ////    IList<FamilyDiseaseDTO> famDisdto = new List<FamilyDiseaseDTO>();
        ////    ICriteria crt = session.GetISession().CreateCriteria(typeof(FamilyHistoryMaster)).Add(Expression.Eq("Human_ID", Human_ID));
        ////    FamDto.iCount = crt.List<FamilyHistoryMaster>().Count;
        ////    IQuery query1 = session.GetISession().GetNamedQuery("Get.FamilyHistoryMaster.WithLimit").SetInt32(0, Convert.ToInt32(Human_ID)).SetInt32(1, PageNumber * maxnumber).SetInt32(2, maxnumber);
        ////    ary = new ArrayList(query1.List());
        ////    foreach (object[] obj in ary)
        ////    {
        ////        FamilyDiseaseDTO famdis = new FamilyDiseaseDTO();
        ////        famdis.Family_History_ID = Convert.ToUInt64(obj[0]);
        ////        famdis.Human_ID = Convert.ToUInt64(obj[1]);
        ////        famdis.RelationShip = Convert.ToString(obj[2]);
        ////        famdis.Age = Convert.ToInt32(obj[3]);
        ////        famdis.Status = obj[4].ToString();
        ////        famdis.Cause_Of_Death = obj[5].ToString();
        ////        famdis.Disease = Convert.ToString(obj[6]);
        ////        famdis.Version = Convert.ToInt32(obj[7]);
        ////        famdis.Created_By = Convert.ToString(obj[8]);
        ////        famdis.Created_Date_And_Time = Convert.ToDateTime(obj[9]);
        ////        famdis.Notes = Convert.ToString(obj[10]);
        ////        famDisdto.Add(famdis);
        ////    }
        ////    FamDto.Family_History = famDisdto;
        ////    return FamDto;
        ////}


        ////public FamilyDTO UpdateFamilyHistoryMaster(FamilyHistoryMaster famHis, IList<FamilyDisease> InsertFamilyDiseaseLst, IList<FamilyDisease> DeleteFamilyDiseaseLst, int pagenumber, int maxnumber, string macAddress)
        ////{
        ////    ulong famId = 0;
        ////    famId = famHis.Human_ID;
        ////    FamilyHistoryMaster famHis = (FamilyHistoryMaster)session.GetISession().Load(typeof(FamilyHistoryMaster), objfamHis.Id);
        ////    IList<FamilyHistoryMaster> listfamily = null;
        ////    IList<FamilyHistoryMaster> familyUpdate = new List<FamilyHistoryMaster>();
        ////    familyUpdate.Add(famHis);
        ////    int iTryCount = 0;
        ////TryAgain:
        ////    int iResult = 0;

        ////    ISession MySession = Session.GetISession();
        ////    ITransaction trans = null;
        ////    try
        ////    {
        ////        trans = MySession.BeginTransaction();
        ////        ICriteria crt1 = MySession.CreateCriteria(typeof(FamilyHistoryMaster)).Add(Expression.Eq("Id", objfamHis.Id));
        ////        familyDel = crt1.List<FamilyHistoryMaster>();
        ////        if (familyUpdate != null && familyUpdate.Count > 0)
        ////        {
        ////            iResult = SaveUpdateDeleteWithoutTransaction(ref listfamily, familyUpdate, null, MySession, macAddress);
        ////            if (iResult == 2)
        ////            {
        ////                if (iTryCount < 5)
        ////                {
        ////                    iTryCount++;
        ////                    goto TryAgain;
        ////                }
        ////                else
        ////                {
        ////                    trans.Rollback();
        ////                    MySession.Close();
        ////                    throw new Exception("Deadlock occurred. Transaction failed.");
        ////                }
        ////            }
        ////            else if (iResult == 1)
        ////            {
        ////                trans.Rollback();
        ////                MySession.Close();
        ////                throw new Exception("Exception occurred. Transaction failed.");
        ////            }
        ////        }

        ////        if (DeleteFamilyDiseaseLst != null && InsertFamilyDiseaseLst != null)
        ////        {
        ////            if (DeleteFamilyDiseaseLst.Count > 0 || InsertFamilyDiseaseLst.Count > 0)
        ////            {
        ////                FamilyDiseaseManager FamDisMgr = new FamilyDiseaseManager();
        ////                iResult = FamDisMgr.UpdateFamilyDiseaseList(InsertFamilyDiseaseLst, DeleteFamilyDiseaseLst, MySession, macAddress);
        ////                if (iResult == 2)
        ////                {
        ////                    if (iTryCount < 5)
        ////                    {
        ////                        iTryCount++;
        ////                        goto TryAgain;
        ////                    }
        ////                    else
        ////                    {
        ////                        trans.Rollback();
        ////                        MySession.Close();
        ////                        throw new Exception("Deadlock occurred. Transaction failed.");
        ////                    }
        ////                }
        ////                else if (iResult == 1)
        ////                {
        ////                    trans.Rollback();
        ////                    MySession.Close();
        ////                    throw new Exception("Exception occurred. Transaction failed.");
        ////                }
        ////            }
        ////        }
        ////        MySession.Flush();
        ////        trans.Commit();
        ////    }
        ////    catch (NHibernate.Exceptions.GenericADOException ex)
        ////    {
        ////        trans.Rollback();
        ////        MySession.Close();
        ////        throw new Exception(ex.Message);
        ////    }
        ////    catch (Exception e)
        ////    {
        ////        trans.Rollback();
        ////        MySession.Close();
        ////        throw new Exception(e.Message);
        ////    }

        ////    finally
        ////    {
        ////        MySession.Close();
        ////    }
        ////    return GetFamilyHistoryMasterManagerByPatient(famId, pagenumber, maxnumber);
        ////}

        ////public FamilyDTO DeleteFamilyHistoryMaster(FamilyHistoryMaster objfamHis, int pagenumber, int maxnumber, string macAddress)
        ////{
        ////    int famId = 0;
        ////    famId = Convert.ToInt32(objfamHis.Id);
        ////    FamilyHistoryMaster famHis = (FamilyHistoryMaster)session.GetISession().Load(typeof(FamilyHistoryMaster), objfamHis.Id);
        ////    IList<FamilyHistoryMaster> listfamily = null;
        ////    IList<FamilyHistoryMaster> familyDel = new List<FamilyHistoryMaster>();
        ////    familyDel.Add(objfamHis);
        ////    int iTryCount = 0;
        ////TryAgain:
        ////    int iResult = 0;

        ////    ISession MySession = Session.GetISession();
        ////    ITransaction trans = null;
        ////    try
        ////    {
        ////        trans = MySession.BeginTransaction();
        ////        ICriteria crt1 = MySession.CreateCriteria(typeof(FamilyHistoryMaster)).Add(Expression.Eq("Id", objfamHis.Id));
        ////        familyDel = crt1.List<FamilyHistoryMaster>();
        ////        if (familyDel != null && familyDel.Count > 0)
        ////        {
        ////            iResult = SaveUpdateDeleteWithoutTransaction(ref listfamily, null, familyDel, MySession, macAddress);
        ////            if (iResult == 2)
        ////            {
        ////                if (iTryCount < 5)
        ////                {
        ////                    iTryCount++;
        ////                    goto TryAgain;
        ////                }
        ////                else
        ////                {
        ////                    trans.Rollback();
        ////                    MySession.Close();
        ////                    throw new Exception("Deadlock occurred. Transaction failed.");
        ////                }
        ////            }
        ////            else if (iResult == 1)
        ////            {
        ////                trans.Rollback();
        ////                MySession.Close();
        ////                throw new Exception("Exception occurred. Transaction failed.");
        ////            }
        ////        }

        ////        if (famId != 0)
        ////        {
        ////            FamilyDiseaseManager FamDisMgr = new FamilyDiseaseManager();
        ////            iResult = FamDisMgr.DeleteFamilyDiseaseList(famId, MySession, macAddress);
        ////            if (iResult == 2)
        ////            {
        ////                if (iTryCount < 5)
        ////                {
        ////                    iTryCount++;
        ////                    goto TryAgain;
        ////                }
        ////                else
        ////                {
        ////                    trans.Rollback();
        ////                    MySession.Close();
        ////                    throw new Exception("Deadlock occurred. Transaction failed.");
        ////                }
        ////            }
        ////            else if (iResult == 1)
        ////            {
        ////                trans.Rollback();
        ////                MySession.Close();
        ////                throw new Exception("Exception occurred. Transaction failed.");
        ////            }
        ////        }
        ////        MySession.Flush();
        ////        trans.Commit();
        ////    }
        ////    catch (NHibernate.Exceptions.GenericADOException ex)
        ////    {
        ////        trans.Rollback();
        ////        MySession.Close();
        ////        throw new Exception(ex.Message);
        ////    }
        ////    catch (Exception e)
        ////    {
        ////        trans.Rollback();
        ////        MySession.Close();
        ////        throw new Exception(e.Message);
        ////    }

        ////    finally
        ////    {
        ////        MySession.Close();
        ////    }
        ////    return GetFamilyHistoryMasterManagerByPatient(objfamHis.Human_ID, pagenumber, maxnumber);
        ////}


        ////public FamilyDTO SaveFamilyHistoryMaster(FamilyHistoryMaster famHis, IList<FamilyDisease> famDis, int pagenumber, int maxnumber, string macAddress)
        ////{
        ////    int iTryCount = 0;
        ////TryAgain:
        ////    int iResult = 0;

        ////    ISession MySession = Session.GetISession();
        ////    ITransaction trans = null;
        ////    try
        ////    {
        ////        trans = MySession.BeginTransaction();
        ////        IList<FamilyHistoryMaster> famhislst = new List<FamilyHistoryMaster>();
        ////        famhislst.Add(famHis);
        ////        if (famhislst != null && famhislst.Count > 0)
        ////        {
        ////            iResult = SaveUpdateDeleteWithoutTransaction(ref famhislst, null, null, MySession, macAddress);
        ////            if (iResult == 2)
        ////            {
        ////                if (iTryCount < 5)
        ////                {
        ////                    iTryCount++;
        ////                    goto TryAgain;
        ////                }
        ////                else
        ////                {
        ////                    trans.Rollback();
        ////                    MySession.Close();
        ////                    throw new Exception("Deadlock occurred. Transaction failed.");
        ////                }
        ////            }
        ////            else if (iResult == 1)
        ////            {
        ////                trans.Rollback();
        ////                MySession.Close();
        ////                throw new Exception("Exception occurred. Transaction failed.");
        ////            }
        ////        }
        ////        if (famDis != null && famDis.Count > 0)
        ////        {
        ////            for (int i = 0; i < famDis.Count; i++)
        ////            {
        ////                famDis[i].Family_History_ID = Convert.ToInt32(famhislst[0].Id);
        ////            }
        ////            FamilyDiseaseManager FamDisMgr = new FamilyDiseaseManager();
        ////            iResult = FamDisMgr.SaveFamilyDiseaseList(famDis, MySession, macAddress);
        ////            if (iResult == 2)
        ////            {
        ////                if (iTryCount < 5)
        ////                {
        ////                    iTryCount++;
        ////                    goto TryAgain;
        ////                }
        ////                else
        ////                {
        ////                    trans.Rollback();
        ////                    MySession.Close();
        ////                    throw new Exception("Deadlock occurred. Transaction failed.");
        ////                }
        ////            }
        ////            else if (iResult == 1)
        ////            {
        ////                trans.Rollback();
        ////                MySession.Close();
        ////                throw new Exception("Exception occurred. Transaction failed.");
        ////            }
        ////        }
        ////        MySession.Flush();
        ////        trans.Commit();
        ////    }
        ////    catch (NHibernate.Exceptions.GenericADOException ex)
        ////    {
        ////        trans.Rollback();
        ////        MySession.Close();
        ////        throw new Exception(ex.Message);
        ////    }
        ////    catch (Exception e)
        ////    {
        ////        trans.Rollback();
        ////        MySession.Close();
        ////        throw new Exception(e.Message);
        ////    }
        ////    finally
        ////    {
        ////        MySession.Close();
        ////    }
        ////    return GetFamilyHistoryMasterManagerByPatient(famHis.Human_ID, pagenumber, maxnumber);
        ////}
        //#endregion

        //public FamilyDTO GetAllLookUPDetails(string[] Field_Name, string sOrder)
        //{
        //    //string[] staticFieldname = Field_Name.Where(a => a.ToString().ToUpper() != "FAMILY DISEASE").ToArray();
        //    //string[] UserFieldname = Field_Name.Where(a => a.ToString().ToUpper() == "FAMILY DISEASE").ToArray();            
        //    FamilyDTO objdto = new FamilyDTO();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria criteriastatic = iMySession.CreateCriteria(typeof(StaticLookup)).Add(Expression.In("Field_Name", Field_Name)).AddOrder(Order.Asc(sOrder));
        //        objdto.lStaticLookup = criteriastatic.List<StaticLookup>();

        //        //ICriteria criteria = iMySession.CreateCriteria(typeof(UserLookup)).Add(Expression.Eq("Physician_ID", Physician_ID)).Add(Expression.Eq("Field_Name", UserFieldname[0])).AddOrder(Order.Asc("Sort_Order"));
        //        //objdto.lstUserLookup = criteria.List<UserLookup>();

        //        iMySession.Close();
        //    }
        //    return objdto;
        //}

    }
}
