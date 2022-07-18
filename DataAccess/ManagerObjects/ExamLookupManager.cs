
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IExamLookupManager : IManagerBase<Exam_Lookup, ulong>
    {
        //IList<FillExaminationScreen> GetExamLookupListFromServer(ulong ulEncID);
        IList<FillExaminationScreen> GetExamLookupListFromServer(string Category, string UserName, ulong ulEncID, string sSex);
        IList<FillExaminationScreen> GetExamLookupListFromLocal(string Category, string UserName, ulong ulEncID, string sSex, string sSystemOrCondition);
      // IList<Exam_Lookup> BatchOperationsToExamLookup(IList<Exam_Lookup> addList, IList<Exam_Lookup> updateList, IList<Exam_Lookup> deleteList, string sMACAddress, string sUserName, string sSystemOrCondition);
       IList<Exam_Lookup> GetExamLookup(string UserName);
       IList<string> GetExamCategoryList(string UserName);
       IList<FillExaminationScreen> GetExamLookupPastListFromServerfollowUp(ulong ulEncID, ulong human_ID, string sMyCategory,ulong Physician_ID);
    }
    public partial class ExamLookupManager : ManagerBase<Exam_Lookup, ulong>, IExamLookupManager
    {
         #region Constructors

        public ExamLookupManager()
            : base()
        {

        }
        public ExamLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Implementation

        //public IList<FillExaminationScreen> GetExamLookupListFromServer( ulong ulEncID)
        //{
        //    ArrayList arylstExamLookup = null;
        //    object[] objArrExamLookup = null;
        //    IQuery query;

        //    IList<FillExaminationScreen> fillExamScreenList = new List<FillExaminationScreen>();
        //    FillExaminationScreen fillExamScreen;

        //    query = session.GetISession().GetNamedQuery("Get.Exam.Lookup.Old");
        //    query.SetParameter(0, ulEncID);

        //    arylstExamLookup = new ArrayList(query.List());

        //    for (int i = 0; i < arylstExamLookup.Count; i++)
        //    {
        //        objArrExamLookup = (object[])arylstExamLookup[i];

        //        fillExamScreen = new FillExaminationScreen();

        //        //fillExamScreen.ExamDetails = objArrExamLookup[0].ToString();
        //        //fillExamScreen.ExaminationID = Convert.ToUInt64(objArrExamLookup[1].ToString());
        //        //fillExamScreen.Version = Convert.ToInt32(objArrExamLookup[3].ToString());
        //        //fillExamScreen.CreatedBy = objArrExamLookup[4].ToString();
        //        //fillExamScreen.CreatedDateTime = Convert.ToDateTime(objArrExamLookup[5].ToString());
        //        //fillExamScreenList.Add(fillExamScreen);
        //        fillExamScreen.System = objArrExamLookup[0].ToString();
        //        fillExamScreen.Condition = objArrExamLookup[1].ToString();
        //        fillExamScreen.Status = objArrExamLookup[2].ToString();
        //        fillExamScreen.Notes = objArrExamLookup[3].ToString();
        //        fillExamScreen.StatusOptions = objArrExamLookup[4].ToString();
        //        fillExamScreen.ExamLookupID = Convert.ToUInt64(objArrExamLookup[5].ToString());
        //        fillExamScreen.NormalSystemStatus = objArrExamLookup[7].ToString();
        //        fillExamScreen.ExaminationID = Convert.ToUInt64(objArrExamLookup[8].ToString());
        //        fillExamScreen.Version = Convert.ToInt32(objArrExamLookup[10].ToString());
        //        fillExamScreen.DefaultValue = objArrExamLookup[11].ToString();
        //        fillExamScreen.DependingType = objArrExamLookup[12].ToString();
        //        fillExamScreen.DependingValue = objArrExamLookup[13].ToString();
        //        fillExamScreen.CreatedBy = objArrExamLookup[14].ToString();
        //        fillExamScreen.CreatedDateTime = Convert.ToDateTime(objArrExamLookup[15].ToString());
        //        fillExamScreen.Short_Description = objArrExamLookup[16].ToString();
        //        fillExamScreen.Default_System_Color = objArrExamLookup[17].ToString();
        //        fillExamScreenList.Add(fillExamScreen);

        //    }

        //    return fillExamScreenList;
        //}
        public IList<FillExaminationScreen> GetExamLookupListFromServer(string Category, string UserName, ulong ulEncID, string sSex)
        {
            ArrayList arylstExamLookup = null;
            object[] objArrExamLookup = null;
            IQuery query;
           
            IList<FillExaminationScreen> fillExamScreenList = new List<FillExaminationScreen>();
            FillExaminationScreen fillExamScreen;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query = iMySession.GetNamedQuery("Get.Exam.Lookup.Old");
                query.SetParameter(0, ulEncID);
                query.SetParameter(1, Category);

                arylstExamLookup = new ArrayList(query.List());

                for (int i = 0; i < arylstExamLookup.Count; i++)
                {
                    objArrExamLookup = (object[])arylstExamLookup[i];

                    fillExamScreen = new FillExaminationScreen();

                    fillExamScreen.System = objArrExamLookup[0].ToString();
                    fillExamScreen.Condition = objArrExamLookup[1].ToString();
                    fillExamScreen.Status = objArrExamLookup[2].ToString();
                    fillExamScreen.Notes = objArrExamLookup[3].ToString();
                    //fillExamScreen.StatusOptions = objArrExamLookup[4].ToString();
                   // fillExamScreen.ExamLookupID = Convert.ToUInt64(objArrExamLookup[5].ToString());
                   // fillExamScreen.NormalSystemStatus = objArrExamLookup[7].ToString();
                    fillExamScreen.ExaminationID = Convert.ToUInt64(objArrExamLookup[4].ToString());
                    fillExamScreen.Version = Convert.ToInt32(objArrExamLookup[6].ToString());
                   // fillExamScreen.DefaultValue = objArrExamLookup[7].ToString();
                   // fillExamScreen.DependingType = objArrExamLookup[8].ToString();
                   // fillExamScreen.DependingValue = objArrExamLookup[9].ToString();
                    fillExamScreen.CreatedBy = objArrExamLookup[7].ToString();
                    fillExamScreen.CreatedDateTime = Convert.ToDateTime(objArrExamLookup[8].ToString());
                    //fillExamScreen.Short_Description = objArrExamLookup[12].ToString();
                   // fillExamScreen.Default_System_Color = objArrExamLookup[17].ToString();
                   // fillExamScreen.Other_Description = objArrExamLookup[18].ToString();
                    fillExamScreenList.Add(fillExamScreen);

                }
                iMySession.Close();
            }
            return fillExamScreenList;
        }
        public IList<FillExaminationScreen> GetExamLookupListFromLocal(string Category, string UserName, ulong ulEncID, string sSex, string sSystemOrCondition)
        {
            ArrayList arylstExamLookup = null;
            object[] objArrExamLookup = null;
            IQuery query;
            
            IList<FillExaminationScreen> fillExamScreenList = new List<FillExaminationScreen>();
            FillExaminationScreen fillExamScreen;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query = iMySession.GetNamedQuery("Get.Exam.Lookup.New");
                query.SetString(0, Category);
                query.SetString(1, UserName);

                arylstExamLookup = new ArrayList(query.List());

                for (int i = 0; i < arylstExamLookup.Count; i++)
                {
                    objArrExamLookup = (object[])arylstExamLookup[i];

                    fillExamScreen = new FillExaminationScreen();

                    fillExamScreen.System = objArrExamLookup[0].ToString();
                    fillExamScreen.Condition = objArrExamLookup[1].ToString();
                    fillExamScreen.Status = objArrExamLookup[2].ToString();
                    fillExamScreen.Notes = objArrExamLookup[3].ToString();
                  //  fillExamScreen.StatusOptions = objArrExamLookup[4].ToString();
                  //  fillExamScreen.ExamLookupID = Convert.ToUInt64(objArrExamLookup[5].ToString());
                 //   fillExamScreen.NormalSystemStatus = objArrExamLookup[7].ToString();
                    fillExamScreen.ExaminationID = Convert.ToUInt64(objArrExamLookup[4].ToString());
                    fillExamScreen.Version = Convert.ToInt32(objArrExamLookup[6].ToString());
                    //fillExamScreen.DefaultValue = objArrExamLookup[11].ToString();
                   // fillExamScreen.DependingType = objArrExamLookup[12].ToString();
                   // fillExamScreen.DependingValue = objArrExamLookup[13].ToString();
                    fillExamScreen.CreatedBy = objArrExamLookup[7].ToString();
                    fillExamScreen.CreatedDateTime = Convert.ToDateTime(objArrExamLookup[8].ToString());
                   // fillExamScreen.Short_Description = objArrExamLookup[16].ToString();
                  //  fillExamScreen.Default_System_Color = objArrExamLookup[17].ToString();
                  //  fillExamScreen.Other_Description = objArrExamLookup[18].ToString();
                    fillExamScreenList.Add(fillExamScreen);

                }
                iMySession.Close();
            }
            if (sSex.ToUpper() != "ALL")
            {
                //var finalList = from f in fillExamScreenList where f.DependingType.ToUpper() == "SEX" && (f.DependingValue == "ALL" || f.DependingValue == sSex.ToUpper()) select f;
                //return finalList.ToList<FillExaminationScreen>();
            }
            if (sSex.ToUpper() == "ALL")
            {
                var finalList = from f in fillExamScreenList select f;
                return finalList.ToList<FillExaminationScreen>();
            }
            return fillExamScreenList;
        }


        //public IList<Exam_Lookup> BatchOperationsToExamLookup(IList<Exam_Lookup> addList,IList<Exam_Lookup> updateList,IList<Exam_Lookup> deleteList,  string sMACAddress,string sUserName,string sSystemOrCondition)
        //{
        //    SaveUpdateDeleteWithTransaction(ref addList,updateList,deleteList, sMACAddress);

        //    return GetExamLookup(sUserName);
        //}

        public IList<Exam_Lookup> GetExamLookup(string UserName)
        {
            IList<Exam_Lookup> examList = new List<Exam_Lookup>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Exam_Lookup)).Add(Expression.Eq("User_Name", UserName));
                examList = crit.List<Exam_Lookup>();
                iMySession.Close();
            }
            return examList;
        }

        public IList<string> GetExamCategoryList(string UserName)
        {
            IList<string> examList = new List<string>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery crit = iMySession.CreateSQLQuery("Select distinct e.Category from exam_lookup e where e.user_name='" + UserName + "' order by e.Exam_Lookup_Id "); //.AddEntity("e", typeof(Exam_Lookup));
                examList = crit.List<string>();
                iMySession.Close();
            }
            return examList;
        }
        public IList<FillExaminationScreen> GetExamLookupPastListFromServerfollowUp(ulong ulEncID, ulong human_ID, string sMyCategory, ulong Physician_ID)
        {
            ArrayList arylstExamLookup = null;
            object[] objArrExamLookup = null;
            IQuery query;
            ulong Encounter_Id = ulEncID;
            ulong encID=0;
            ulong physicianId = Physician_ID;
            IList<FillExaminationScreen> fillExamScreenList = new List<FillExaminationScreen>();
            FillExaminationScreen fillExamScreen;
            //FillExaminationScreen fillExamScreenPreEnc;
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            WFObjectManager objWFObjectManager = new WFObjectManager(); 
            try
            {
                EncounterManager encManager = new EncounterManager();
                IList<Encounter> encounter = encManager.GetEncounterByEncounterID(ulEncID);
                
                EncounterManager enc = new EncounterManager();

                string sDOS = enc.GetEncounterByEncounterID(ulEncID)[0].Date_of_Service.ToString("yyyy-MM-dd hh:mm:ss ");

                ISQLQuery ResultList = iMySession.CreateSQLQuery("SELECT e.* FROM encounter e WHERE e.Human_ID='" + human_ID + "' and e.Encounter_Provider_ID='" + Convert.ToInt32(physicianId) + "' and e.Date_of_Service <>'0001-01-01 00:00:00' and e.Date_of_Service<(select e.Date_of_Service from encounter e where e.Encounter_ID=" + ulEncID + ")and e.Encounter_ID<>" + ulEncID + " and e.Is_Phone_Encounter <> 'Y'  Order By e.Date_of_Service desc").AddEntity("e", typeof(Encounter));
                encID = ResultList.List<Encounter>()[0].Id;

                if (ResultList.List<Encounter>().Count == 1)
                {
                    fillExamScreen = new FillExaminationScreen();
                    if (!objWFObjectManager.IsPreviousEncounterPhysicianProcess(encID))
                    {
                        
                        fillExamScreen.Physician_Process = false;
                        fillExamScreen.PEnc = encID;
                        fillExamScreenList.Add(fillExamScreen);
                        return fillExamScreenList;
                    }
                    else
                    {
                        fillExamScreen.Physician_Process = true;
                        fillExamScreen.PEnc = encID;
                    }
                }
                else
                {
                    bool phy_process = false;
                    for (int i = 0; i < ResultList.List<Encounter>().Count; i++)
                    {
                        phy_process = objWFObjectManager.IsPreviousEncounterPhysicianProcess(ResultList.List<Encounter>()[i].Id);
                        if (phy_process == true)
                        {
                            fillExamScreen = new FillExaminationScreen();
                            encID = ResultList.List<Encounter>()[i].Id;
                            fillExamScreen.Physician_Process = true;
                            fillExamScreen.PEnc = encID;
                            break;
                        }
                    }
                    if (phy_process == false)
                    {
                        fillExamScreen = new FillExaminationScreen();
                        fillExamScreen.Physician_Process = false;
                        fillExamScreen.PEnc = encID;
                        fillExamScreenList.Add(fillExamScreen);
                        return fillExamScreenList;
                    }
                }
            }
            catch (Exception)
            {
                ulEncID = 0;
            }
            if (encID != 0)
            {
                ulEncID = encID;
               

            }
            query =iMySession.GetNamedQuery("Get.Exam.Lookup.Old");
            query.SetParameter(0, ulEncID);
            query.SetParameter(1, sMyCategory);

            arylstExamLookup = new ArrayList(query.List());

            for (int i = 0; i < arylstExamLookup.Count; i++)
            {
                objArrExamLookup = (object[])arylstExamLookup[i];

                fillExamScreen = new FillExaminationScreen();

                fillExamScreen.System = objArrExamLookup[0].ToString();
                fillExamScreen.Condition = objArrExamLookup[1].ToString();
                fillExamScreen.Status = objArrExamLookup[2].ToString();
                fillExamScreen.Notes = objArrExamLookup[3].ToString();
              //  fillExamScreen.StatusOptions = objArrExamLookup[4].ToString();
              //  fillExamScreen.ExamLookupID = Convert.ToUInt64(objArrExamLookup[5].ToString());
             ///  fillExamScreen.NormalSystemStatus = objArrExamLookup[7].ToString();
              //  fillExamScreen.ExaminationID = Convert.ToUInt64(objArrExamLookup[8].ToString());
                fillExamScreen.Version = Convert.ToInt32(objArrExamLookup[6].ToString());
               // fillExamScreen.DefaultValue = objArrExamLookup[11].ToString();
               // fillExamScreen.DependingType = objArrExamLookup[12].ToString();
                //fillExamScreen.DependingValue = objArrExamLookup[13].ToString();
                fillExamScreen.CreatedBy = objArrExamLookup[7].ToString();
                fillExamScreen.CreatedDateTime = Convert.ToDateTime(objArrExamLookup[8].ToString());
               // fillExamScreen.Short_Description = objArrExamLookup[16].ToString();
             //   fillExamScreen.Default_System_Color = objArrExamLookup[17].ToString();
              //  fillExamScreen.Other_Description = objArrExamLookup[18].ToString();
                fillExamScreen.PEnc = ulEncID;
                fillExamScreen.Physician_Process = true;
                fillExamScreenList.Add(fillExamScreen);

            }
            iMySession.Close();
            if (fillExamScreenList != null && fillExamScreenList.Count > 0)
            {
                //IList<Encounter> enclst = new List<Encounter>();
                //ICriteria crit = session.GetISession().CreateCriteria(typeof(Encounter)).Add(Expression.Eq("Id", Encounter_Id));
                //enclst = crit.List<Encounter>();

                //if (enclst.Count != 0)
                //{
                //    if (enclst[0].Is_Previous_Encounter_Copied == "N")
                //    {
                //        ChiefComplaintsManager chiefcomplaint = new ChiefComplaintsManager();
                //        chiefcomplaint.UpdateEncounter(Encounter_Id, "Y", string.Empty);
                //    }

                //}
            }

            return fillExamScreenList;
        }
        #endregion
    }
}
