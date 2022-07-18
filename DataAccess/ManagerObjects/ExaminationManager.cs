using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IExaminationManager : IManagerBase<Examination, ulong>
    {
        IList<Examination> AppendExamination(IList<Examination> ExamList, string MACAddress);
        IList<Examination> GetExamList(ulong ulEncID, string category, bool isFromArchive);
        IList<Examination> GetExamOtherThanNotExamined(ulong EncounterId);
        int GetExamEntries(string Category, ulong ulEncID);
        IList<FillExaminationScreen> UpdateExamination(IList<Examination> ExamList, string MACAddress, string sSex);
        IList<Examination> UpdateExams(IList<Examination> ExamList, string MACAddress);
        IList<FillExaminationScreen> UpdateExaminationForCopyPrevious(IList<Examination> ExamList, string MACAddress, string sSex, string category, ulong Encounter_Id, string UserName);

    }

    public partial class ExaminationManager : ManagerBase<Examination, ulong>, IExaminationManager
    {
        #region Constructors

        public ExaminationManager()
            : base()
        {

        }
        public ExaminationManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

        public IList<Examination> AppendExamination(IList<Examination> ExamList, string MACAddress)
        {
            IList<Examination> examScreenList = new List<Examination>();
            IList<Examination> nullList = null;
            string ExamTabName = string.Empty;
            if (ExamList.Count > 0)
            {
                if (ExamList[0].Category.ToUpper() == "GENERAL WITH SPECIALTY")
                    ExamTabName = "General";
                else if (ExamList[0].Category.ToUpper() == "FOCUSED")
                    ExamTabName = "Focused";
                SaveUpdateDelete_DBAndXML_WithTransaction(ref ExamList, ref nullList, null, MACAddress, true, true, ExamList[0].Encounter_ID, ExamTabName);
                examScreenList = ExamList;
            }
            return examScreenList;
        }

        public IList<FillExaminationScreen> UpdateExamination(IList<Examination> ExamList, string MACAddress, string sSex)
        {
            IList<FillExaminationScreen> examScreenList = new List<FillExaminationScreen>();
            ExamLookupManager examMngr = new ExamLookupManager();
            if (ExamList.Count > 0)
                examScreenList = examMngr.GetExamLookupListFromServer(ExamList[0].Category, ExamList[0].Modified_By, ExamList[0].Encounter_ID, sSex);
            return examScreenList;
        }

        public IList<Examination> UpdateExams(IList<Examination> ExamList, string MACAddress)
        {
            IList<Examination> addList = null;
            IList<Examination> deletelist = null;
            IList<Examination> examScreenList = new List<Examination>();
            string ExamTabName = string.Empty;
            if (ExamList.Count > 0)
            {
                if (ExamList[0].Category.ToUpper() == "GENERAL WITH SPECIALTY")
                    ExamTabName = "General";
                else if (ExamList[0].Category.ToUpper() == "FOCUSED")
                    ExamTabName = "Focused";

                SaveUpdateDelete_DBAndXML_WithTransaction(ref addList, ref ExamList, deletelist, MACAddress, true, false, ExamList[0].Encounter_ID, ExamTabName);
                for (int j = 0; j < ExamList.Count; j++)
                {
                    examScreenList.Add(ExamList[j]);
                }
            }
            return examScreenList;
        }

        public IList<FillExaminationScreen> GetExamforPastEncounter(ulong humanId, ulong encounterId, ulong physicianId, string examCategory)
        {
            FillExaminationScreen objFillExaminationScreen = new FillExaminationScreen();
            EncounterManager objEncounterManager = new EncounterManager();  

            IList<FillExaminationScreen> lstFillExaminationScreen = new List<FillExaminationScreen>();

            ulong previousEncounterId = 0;
            bool isPhysicianProcess = false;
            bool isFromArchive = false;                      

            var lstEncounter = objEncounterManager.GetPreviousEncounterDetails(encounterId, humanId, physicianId, out isPhysicianProcess, out isFromArchive);

            if (lstEncounter.Count > 0)
            {
                previousEncounterId = lstEncounter[0].Id;
                objFillExaminationScreen.PEnc = previousEncounterId;
                objFillExaminationScreen.Physician_Process = isPhysicianProcess;
                if (isPhysicianProcess)
                    objFillExaminationScreen.CopypreviousEncounterList = GetExamList(previousEncounterId, examCategory, isFromArchive);
                lstFillExaminationScreen.Add(objFillExaminationScreen);                
            }

            return lstFillExaminationScreen;
        }

        public IList<Examination> GetExamList(ulong encounterId, string category, bool isFromArchive)
        {
            IList<Examination> lstExamination = new List<Examination>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var querySQL = string.Format(@"SELECT E.* 
                                               FROM   {0} E 
                                               WHERE  E.ENCOUNTER_ID = :ENCOUNTER_ID 
                                               AND CATEGORY = :CATEGORY",
                                               isFromArchive ? "EXAMINATION_ARC" : "EXAMINATION");

                var SQLQuery = iMySession.CreateSQLQuery(querySQL)
                       .AddEntity("E", typeof(Examination));

                SQLQuery.SetParameter("ENCOUNTER_ID", encounterId);
                SQLQuery.SetParameter("CATEGORY", category);

                lstExamination = SQLQuery.List<Examination>();

                iMySession.Close();
            }
            return lstExamination;
        }

        public int GetExamEntries(string Category, ulong ulEncID)
        {
            ICriteria crit;
            int count = 0;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                crit = iMySession.CreateCriteria(typeof(Examination)).Add(Expression.Eq("Encounter_ID", ulEncID)).Add(Expression.Eq("Category", Category));
                count = crit.List<Examination>().Count;
                iMySession.Close();
            }
            return count;
        }

        public IList<Examination> GetExamOtherThanNotExamined(ulong EncounterId)
        {
            ArrayList arrList = null;
            IList<Examination> examList = new List<Examination>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Examination.GetExamExceptNotExamined");
                query.SetInt32(0, Convert.ToInt32(EncounterId)); ;

                arrList = new ArrayList(query.List());

                Examination ex = null;

                //added by Ginu on 2-Aug-2010
                if (arrList != null)
                {
                    for (int i = 0; i < arrList.Count; i++)
                    {
                        ex = new Examination();
                        object[] obj = (object[])arrList[i];


                        ex.Id = Convert.ToUInt64(obj[0]);
                        // ex.Condition_Name = obj[1].ToString();
                        ex.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
                        examList.Add(ex);
                    }
                }
                iMySession.Close();
            }
            return examList;
        }

        public IList<FillExaminationScreen> UpdateExaminationForCopyPrevious(IList<Examination> ExamList, string MACAddress, string sSex, string category, ulong Encounter_Id, string UserName)
        {
            // UpdateExamination(ExamList, MACAddress);

            IList<Examination> DeleteExamList = new List<Examination>();
            IList<Examination> UpdateExamList =null;
            IList<FillExaminationScreen> examScreenList = new List<FillExaminationScreen>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Examination)).Add(Expression.Eq("Category", category)).Add(Expression.Eq("Encounter_ID", Encounter_Id)).Add(Expression.Eq("Human_ID", ExamList[0].Human_ID));
                DeleteExamList = crit.List<Examination>();
                iMySession.Close();
               // SaveUpdateDeleteWithTransaction(ref ExamList, null, DeleteExamList, MACAddress);
                SaveUpdateDelete_DBAndXML_WithTransaction(ref ExamList, ref UpdateExamList, DeleteExamList, MACAddress, false, false, ExamList[0].Encounter_ID, string.Empty);

                ExamLookupManager examMngr = new ExamLookupManager();
                if (ExamList.Count > 0)
                {
                    // examScreenList = examMngr.GetExamLookupListFromServer(ExamList[0].Encounter_ID);
                    examScreenList = examMngr.GetExamLookupListFromServer(category, UserName, Encounter_Id, sSex);
                }
            }
            return examScreenList;
        }

        #endregion
    }
}
