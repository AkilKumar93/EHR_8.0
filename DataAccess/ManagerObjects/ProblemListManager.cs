
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
    public partial interface IProblemListManager : IManagerBase<ProblemList, ulong>
    {
        IList<ProblemList> GetProblemDescriptionList(ulong ulHumanID);
        IList<ProblemList> GetProblemList(ulong Problem_List_ID, string ICD);
        IList<ProblemList> GetProblemDescription(ulong ulHumanID);
        IList<ProblemList> GetProblemDescriptionByReferenceIdAndReferenceSource(ulong referenceId, string referenceSource);
        //int BatchOperationsToProblem(IList<ProblemList> ListToInsert, IList<ProblemList> ListToUpdate, IList<ProblemList> ListToDelete, ISession MySession, string sMacAddress, bool bIs_Rcopia);
        IList<ProblemList> GetProblemListUsingProblemListId(ulong ProblemListId);
        IList<ProblemList> GetProblemDescriptionByHumanIdAndReferenceSource(string referenceSource, ulong Human_ID);
        IList<ProblemList> GetProblemDescriptionByReferenceIdAndReferenceSourceList(string[] referenceId, string referenceSource);
        IList<ProblemList> GetProblemDescriptionByHumanId(ulong ulHumanID);
        IList<ProblemList> GetFromProblemList(ulong ulHumanID, string sMacAddress, bool sSatus);
        IList<ProblemList> InsertIntoProblemList(IList<ProblemList> objProblemList, ulong ulHumanID, string sMacAddress, bool sSatus, string sLegalOrg);
        IList<ProblemList> DeleteProblemListDetails(IList<ProblemList> objProblemList, ulong ulHumanID, string sMacAddress, bool sStatus);
        IList<ProblemList> UpdateProblemListDetails(IList<ProblemList> objProblemList, ulong ulHumanID, string sMacAddress, bool sStatus, string sLegalOrg);
        IList<ProblemList> GetICDByHumanId(ulong ulHumanID);
        IList<ProblemList> GetProblemList(ulong ulHumanID);
        IList<ProblemList> GetProblemListByICD(ulong EncID, ulong HumanID, IList<string> ICD);
        //Added By Muthu on 02-02-2013
        IList<ProblemList> InsertorUpdateIntoProblemList(IList<ProblemList> AddProblemList, IList<ProblemList> UpdateProblemList, ulong ulHumanID, string sMacAddress, bool sSatus, string sLegalOrg);


        void InsertOrUpdateProblemList(IList<ProblemList> ilstProblem, string MACAddress, DateTime dtClientDate);
        IList<ProblemList> GetProblemListForRecommendedMaterials(ulong ulEncounterId, ulong ulHumanId);
        //IList<ProblemList> SaveUpdateDeleteProblemList(IList<ProblemList> AddProblemList,IList<ProblemList> AddProblemList,IList<ProblemList> AddProblemList, ulong ulHumanID, string sMacAddress, bool sSatus)
        void SaveProblemListforSummary(IList<ProblemList> lstproblem);
    }

    public partial class ProblemListManager : ManagerBase<ProblemList, ulong>, IProblemListManager
    {
        #region Constructors

        public ProblemListManager()
            : base()
        {

        }
        public ProblemListManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<ProblemList> GetProblemDescription(ulong ulHumanID)
        {
            IList<ProblemList> listPrb = new List<ProblemList>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList))
                                               .Add(Expression.Eq("Human_ID", ulHumanID))
                                               .AddOrder(Order.Desc("Created_Date_And_Time"));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }

        //test method:velmurugan
        public IList<ProblemList> GetProblemList(ulong Problem_List_ID, string ICD)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Human_ID", Problem_List_ID)).Add(Expression.Eq("ICD_Code", ICD)).Add(Expression.Eq("Reference_Source", "AHA Questionnaire"));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }
        //test method

        public IList<ProblemList> GetProblemDescriptionByReferenceIdAndReferenceSource(ulong referenceId, string referenceSource)
        {
            //   ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Reference_ID", referenceId)).Add(Expression.Eq("Reference_Source", referenceSource));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }

        public IList<ProblemList> GetProblemDescriptionList(ulong ulHumanID)
        {
            //ICriteria crt = session.GetISession().CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Is_Active", "Y")).Add(Expression.Eq("Status", "Active"));
            //return crt.List<ProblemList>();
            //added by pravin-29-aug-2012
            IList<ProblemList> list = new List<ProblemList>();
            ProblemList prob = null;
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.ProblemList.GetICDByHumanIDforPatientsummary");
                query.SetString(0, ulHumanID.ToString());
                ArrayList arrlist = new ArrayList(query.List());
                for (int i = 0; i < arrlist.Count; i++)
                {
                    prob = new ProblemList();
                    object[] obj = (object[])arrlist[i];
                    prob.Id = Convert.ToUInt32(obj[0].ToString());
                    prob.Encounter_ID = Convert.ToUInt32(obj[1].ToString());
                    prob.Physician_ID = Convert.ToUInt32(obj[2].ToString());
                    prob.Reference_Source = obj[3].ToString();
                    prob.ICD = obj[4].ToString();
                    prob.Problem_Description = obj[5].ToString();
                    prob.Created_By = obj[6].ToString();
                    prob.Created_Date_And_Time = Convert.ToDateTime(obj[7]);
                    prob.Modified_By = obj[8].ToString();
                    prob.Modified_Date_And_Time = Convert.ToDateTime(obj[9]);
                    prob.Version = Convert.ToInt32(obj[10].ToString());
                    prob.Status = obj[11].ToString();
                    if (obj[12].ToString() != string.Empty)
                    {
                        string[] DateDiagnosed = null;
                        string diagnosed = string.Empty;
                        DateDiagnosed = obj[12].ToString().Split('-');
                        if (DateDiagnosed.Length == 3)
                        {
                            string date = DateDiagnosed[2].ToString() + "-" + DateDiagnosed[1].ToString() + "-" + DateDiagnosed[0].ToString();
                            // prob.Date_Diagnosed = date.ToString();
                            prob.Date_Diagnosed = Convert.ToDateTime(obj[12]).ToString("yyyy-MM-dd");
                        }
                        else if (DateDiagnosed.Length == 2)
                        {
                            //   string date="00-" + obj[12].ToString();

                            DateTime month = DateTime.ParseExact(obj[12].ToString(), "MMM-yyyy", null);
                            int d = month.Month;
                            if (d < 10)
                            {
                                string date = DateDiagnosed[1].ToString() + "-0" + d.ToString();

                                prob.Date_Diagnosed = date.ToString();
                            }
                            else
                            {
                                string date = DateDiagnosed[1].ToString() + "-" + d.ToString();

                                prob.Date_Diagnosed = date.ToString();
                            }
                            //  prob.Date_Diagnosed = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            //string date = "00-" + "MMM-" + obj[12].ToString();
                            prob.Date_Diagnosed = obj[12].ToString();
                            //Convert.ToDateTime(date).ToString("dd-MMM-yyyy");
                        }

                        // prob.Date_Diagnosed = Convert.ToDateTime(obj[12]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        prob.Date_Diagnosed = obj[12].ToString();
                    }
                    prob.Rcopia_ID = Convert.ToUInt32(obj[13].ToString());
                    prob.Is_Active = obj[14].ToString();
                    list.Add(prob);
                }
                // added for bug id 27947

                list = (from p in list where p.ICD != "" select p).ToList<ProblemList>();
                iMySession.Close();
            }
            return list;

        }
        //not in use
        //public int BatchOperationsToProblem(IList<ProblemList> ListToInsert, IList<ProblemList> ListToUpdate, IList<ProblemList> ListToDelete, ISession MySession, string sMacAddress, bool bIs_Rcopia)
        //{
        //    ulong ulhumanID = 0;
        //    ulong EncounterORHumanId = 0;
        //    int iResult = 0;
        //    GenerateXml xmlobj = new GenerateXml();
        //    ProblemListManager pm = new ProblemListManager();
        //    if ((ListToInsert.Count > 0) || (ListToUpdate.Count > 0) || (ListToDelete.Count > 0))
        //    {
        //        if (ListToInsert.Count == 0)
        //        {
        //            ListToInsert = null;
        //        }
        //        else if (ListToUpdate.Count == 0)
        //        {
        //            ListToUpdate = null;
        //        }
        //        else if (ListToDelete.Count == 0)
        //        {
        //            ListToDelete = null;
        //        }
        //        if (ListToInsert.Count > 0)
        //            EncounterORHumanId = ListToInsert[0].Human_ID;
        //        else if (ListToUpdate.Count > 0)
        //            EncounterORHumanId = ListToUpdate[0].Human_ID;
        //        else
        //            EncounterORHumanId = ListToDelete[0].Human_ID;
                
        //        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref ListToUpdate, ListToDelete, MySession, sMacAddress, true, true, EncounterORHumanId, string.Empty, ref xmlobj);
        //        // iResult = SaveUpdateDeleteWithoutTransaction(ref ListToInsert, ListToUpdate, ListToDelete, MySession, sMacAddress);

        //        //**********************************************************************//
        //        //Added by velmurugan for Rcopia on 14.05.11

        //        if (bIs_Rcopia == true)
        //        {
        //            RCopiaTransactionManager objrcoptranMngr = new RCopiaTransactionManager();
        //            if (ListToInsert != null && ListToInsert.Count > 0)
        //            {
        //                IList<ulong> ilstinsertId = new List<ulong>();
        //                IList<Assessment> ilstassessment = null;
        //                for (int x = 0; x < ListToInsert.Count; x++)
        //                {
        //                    ilstinsertId.Add(ListToInsert[x].Id);
        //                }
        //                if (ilstinsertId != null && ilstinsertId.Count > 0)
        //                {
        //                    // objrcoptranMngr.SendProblemToRCopia(ilstinsertId, "Assesment", false, ilstassessment);
        //                }
        //            }
        //            if (ListToUpdate != null && ListToUpdate.Count > 0)
        //            {
        //                IList<ulong> ilstUpdateId = new List<ulong>();
        //                IList<Assessment> ilstassessment = null;
        //                for (int y = 0; y < ListToUpdate.Count; y++)
        //                {
        //                    ilstUpdateId.Add(ListToUpdate[y].Id);
        //                }
        //                if (ilstUpdateId != null && ilstUpdateId.Count > 0)
        //                {
        //                    //objrcoptranMngr.SendProblemToRCopia(ilstUpdateId, "Assesment", false, ilstassessment);
        //                }
        //            }
        //            if (ListToDelete != null && ListToDelete.Count > 0)
        //            {

        //                IList<ulong> ilstDeleteId = new List<ulong>();
        //                IList<Assessment> ilstassessment = null;
        //                for (int z = 0; z < ListToDelete.Count; z++)
        //                {
        //                    ilstDeleteId.Add(ListToDelete[z].Id);
        //                }
        //                if (ilstDeleteId != null && ilstDeleteId.Count > 0)
        //                {
        //                    // objrcoptranMngr.SendProblemToRCopia(ilstDeleteId, "Assesment", false, ilstassessment);
        //                }
        //            }
        //        }
        //        //**********************************************************************//
        //    }
        //    return iResult;
        //}

        public IList<ProblemList> GetProblemListUsingProblemListId(ulong ProblemListId)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Id", ProblemListId));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }

        public IList<ProblemList> GetProblemDescriptionByReferenceIdAndReferenceSourceList(string[] referenceId, string referenceSource)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.In("Reference_ID", referenceId)).Add(Expression.Eq("Reference_Source", referenceSource));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }
        public IList<ProblemList> GetProblemDescriptionByHumanIdAndReferenceSource(string referenceSource, ulong Human_ID)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Human_ID", Human_ID)).Add(Expression.Eq("Reference_Source", referenceSource));//.Add(NHibernate.Criterion.Restrictions.NotEqProperty("Reference_ID", referenceId));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }

        public IList<ProblemList> GetProblemDescriptionByHumanId(ulong ulHumanID)
        {
            IList<ProblemList> list = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlquery = iMySession.CreateSQLQuery("select Problem_List_ID, ICD,Problem_Description,reference_source,Is_Active from problem_list where human_id='" + ulHumanID + "' and Is_Active='Y' group by ICD").AddEntity("v", typeof(ProblemList));
                list = sqlquery.List<ProblemList>();
                //IList<ProblemList> list = new List<ProblemList>();
                //ProblemList prob = null;
                //IQuery query = session.GetISession().GetNamedQuery("Get.ProblemList.GetProblemDescriptionByHumanID");
                //query.SetString(0, ulHumanID.ToString());
                //ArrayList arrlist = new ArrayList(query.List());

                //for (int i = 0; i < arrlist.Count; i++)
                //{
                //    prob = new ProblemList();
                //    object[] obj = (object[])arrlist[i];
                //    prob.Id = Convert.ToUInt64(obj[0]);
                //    prob.ICD_Code = obj[1].ToString();
                //    prob.Problem_Description = obj[2].ToString();
                //    prob.Reference_Source = obj[3].ToString();
                //    prob.Is_Active = obj[4].ToString();
                //    list.Add(prob);
                //}
                iMySession.Close();
            }
            return list;
        }
        public IList<ProblemList> GetFromProblemList(ulong ulHumanID, string sMacAddress, bool sSatus)
        {
            IList<ProblemList> list = new List<ProblemList>();
            ProblemList prob = null;
            IQuery query;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (sSatus == true)
                {
                    query = iMySession.GetNamedQuery("Get.ProblemList.GetICDByHumanID");
                    query.SetString(0, ulHumanID.ToString());
                    // query.SetString(1, "Active");
                }
                else
                {
                    query = iMySession.GetNamedQuery("Get.ProblemList.GetICDByHumanID");
                    query.SetString(0, ulHumanID.ToString());
                    // query.SetString(1, "%");

                }
                ArrayList arrlist = new ArrayList(query.List());
                for (int i = 0; i < arrlist.Count; i++)
                {
                    prob = new ProblemList();
                    object[] obj = (object[])arrlist[i];
                    prob.Id = Convert.ToUInt32(obj[0].ToString());
                    prob.Encounter_ID = Convert.ToUInt32(obj[1].ToString());
                    prob.Physician_ID = Convert.ToUInt32(obj[2].ToString());
                    prob.Reference_Source = obj[3].ToString();
                    prob.ICD = obj[4].ToString();
                    prob.Problem_Description = obj[5].ToString();
                    prob.Created_By = obj[6].ToString();
                    prob.Created_Date_And_Time = Convert.ToDateTime(obj[7]);
                    prob.Modified_By = obj[8].ToString();
                    prob.Modified_Date_And_Time = Convert.ToDateTime(obj[9]);
                    prob.Version = Convert.ToInt32(obj[10].ToString());
                    prob.Version_Year = obj[11].ToString();
                    prob.Status = obj[12].ToString();

                    prob.Date_Diagnosed = obj[13].ToString();
                    prob.Rcopia_ID = Convert.ToUInt32(obj[14].ToString());
                    prob.Is_Active = obj[15].ToString();
                    prob.Resolved_Date = obj[16].ToString();
                    prob.Human_ID = ulHumanID;
                    prob.Is_Health_Concern = obj[17].ToString();
                    list.Add(prob);
                }
                iMySession.Close();
            }
            return list;

        }

        public IList<ProblemList> GetFromProblemListClinicalInformation(ulong ulHumanID, string sMacAddress, bool sSatus)
        {
            IList<ProblemList> list = new List<ProblemList>();
            ProblemList prob = null;
            IQuery query;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (sSatus == true)
                {
                    query = iMySession.GetNamedQuery("Get.ProblemList.GetICDByHumanIDforClinicalInformation");
                    query.SetString(0, ulHumanID.ToString());
                    // query.SetString(1, "Active");
                }
                else
                {
                    query = iMySession.GetNamedQuery("Get.ProblemList.GetICDByHumanIDforClinicalInformation");
                    query.SetString(0, ulHumanID.ToString());
                    // query.SetString(1, "%");

                }
                ArrayList arrlist = new ArrayList(query.List());
                for (int i = 0; i < arrlist.Count; i++)
                {
                    prob = new ProblemList();
                    object[] obj = (object[])arrlist[i];
                    prob.Id = Convert.ToUInt32(obj[0].ToString());
                    prob.Encounter_ID = Convert.ToUInt32(obj[1].ToString());
                    prob.Physician_ID = Convert.ToUInt32(obj[2].ToString());
                    prob.Reference_Source = obj[3].ToString();
                    prob.ICD = obj[4].ToString();
                    prob.Problem_Description = obj[5].ToString();
                    prob.Created_By = obj[6].ToString();
                    prob.Created_Date_And_Time = Convert.ToDateTime(obj[7]);
                    prob.Modified_By = obj[8].ToString();
                    prob.Modified_Date_And_Time = Convert.ToDateTime(obj[9]);
                    prob.Version = Convert.ToInt32(obj[10].ToString());
                    prob.Status = obj[11].ToString();

                    prob.Date_Diagnosed = obj[12].ToString();
                    prob.Rcopia_ID = Convert.ToUInt32(obj[13].ToString());
                    prob.Is_Active = obj[14].ToString();
                    prob.Human_ID = ulHumanID;
                    list.Add(prob);
                }
                iMySession.Close();
            }
            return list;

            //ICriteria critGetProblemList = session.GetISession().CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Human_ID", ulHumanID)).AddOrder(Order.Desc("Date_Diagnosed"));
            //IList<ProblemList> listProblemListDetails = new List<ProblemList>();
            //listProblemListDetails = critGetProblemList.List<ProblemList>();
            //return listProblemListDetails;


        }


        public IList<ProblemList> InsertIntoProblemList(IList<ProblemList> objProblemList, ulong ulHumanID, string sMacAddress, bool sSatus, string sLegalOrg)
        {


            IList<ProblemList> saveProblemList = new List<ProblemList>();
            //saveProblemList.Add(objProblemList);
            //SaveUpdateDeleteWithTransaction(ref objProblemList, null, null, sMacAddress);
            //Insert into RcopiaServer
            RCopiaTransactionManager objmngr = new RCopiaTransactionManager();

            HumanManager hManager = new HumanManager();
            Human humanRecord = hManager.GetById(ulHumanID);
            if (humanRecord.Is_Sent_To_Rcopia == "N")
            {
                objmngr.SendPatientToRCopia(ulHumanID, sMacAddress,sLegalOrg);
            }
            for (int i = 0; i < objProblemList.Count; i++)
            {
                IList<Assessment> ilstassesment = null;
                IList<ulong> ilstinsertIds = new List<ulong>();
                ilstinsertIds.Add(objProblemList[0].Id);
                objmngr.SendProblemToRCopia(ilstinsertIds, "problemlist", false, ilstassesment,sLegalOrg);
            }

            return GetFromProblemList(ulHumanID, sMacAddress, sSatus);

        }
        public IList<ProblemList> DeleteProblemListDetails(IList<ProblemList> objProblemList, ulong ulHumanID, string sMacAddress, bool sStatus)
        {
            //IList<ProblemList> Ulist = null;
            //IList<ProblemList> DList = null;
            IList<ProblemList> DeleteProblemList = new List<ProblemList>();
            //DeleteProblemList.Add(objProblemList);
            // SaveUpdateDeleteWithTransaction(ref DList, Ulist, objProblemList, sMacAddress);
            return GetFromProblemList(ulHumanID, sMacAddress, sStatus);

        }
        public IList<ProblemList> UpdateProblemListDetails(IList<ProblemList> objProblemList, ulong ulHumanID, string sMacAddress, bool sStatus, string sLegalOrg)
        {
           // IList<ProblemList> SaveList = null;
            IList<ProblemList> UpdateProblemList = new List<ProblemList>();
            //UpdateProblemList.Add(objProblemList);
            // SaveUpdateDeleteWithTransaction(ref SaveList, objProblemList, null, sMacAddress);
            //Insert into RcopiaServer
            RCopiaTransactionManager objmngr = new RCopiaTransactionManager();


            for (int i = 0; i < objProblemList.Count; i++)
            {
                IList<Assessment> ilstassesment = null;
                IList<ulong> ilstinsertIds = new List<ulong>();
                ilstinsertIds.Add(objProblemList[0].Id);
                objmngr.SendProblemToRCopia(ilstinsertIds, "problemlist", false, ilstassesment,sLegalOrg);
            }

            return GetFromProblemList(ulHumanID, sMacAddress, sStatus);
            //return GetICDByHumanId(ulHumanID);//(objProblemList, ulHumanID, sMacAddress);

        }


        public void InsertOrUpdateProblemList(IList<ProblemList> ilstProblem, string MACAddress, DateTime dtClientDate)
        {
            if (ilstProblem.Count > 0)
            {
                IList<ProblemList> Rcopia_ProblemList = new List<ProblemList>();
                IList<ProblemList> Rcopia_ProblemListUpdateList = new List<ProblemList>();
                for (int i = 0; i < ilstProblem.Count; i++)
                {
                    if (ilstProblem[i].Human_ID != 0)
                    {
                        ProblemList objProblemList = GetRcopiaProblemRecords(ilstProblem[i].Rcopia_ID);
                        if (objProblemList == null)
                        {
                            Rcopia_ProblemList.Add(ilstProblem[i]);
                        }
                        else
                        {
                            ProblemList objUpdateProblemList = UpdateProblemListObject(objProblemList, ilstProblem[i]);
                            Rcopia_ProblemListUpdateList.Add(objUpdateProblemList);
                        }
                    }
                }
                // SaveUpdateDeleteWithTransaction(ref Rcopia_ProblemList, Rcopia_ProblemListUpdateList, null, MACAddress);
            }
        }

        public ProblemList UpdateProblemListObject(ProblemList objproblist, ProblemList updateProblemList)
        {
            objproblist.Human_ID = updateProblemList.Human_ID;
            objproblist.ICD = updateProblemList.ICD;
            objproblist.Date_Diagnosed = updateProblemList.Date_Diagnosed;
            objproblist.Problem_Description = updateProblemList.Problem_Description;
            objproblist.Rcopia_ID = updateProblemList.Rcopia_ID;
            objproblist.Status = updateProblemList.Status;
            objproblist.Last_Modified_By = updateProblemList.Last_Modified_By;
            objproblist.Last_Modified_Date = updateProblemList.Last_Modified_Date;
            return objproblist;
        }

        public IList<ProblemList> GetICDByHumanId(ulong ulHumanID)
        {
            IList<ProblemList> list = new List<ProblemList>();
            ProblemList prob = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.ProblemList.GetICDByHumanID");
                query.SetString(0, ulHumanID.ToString());
                ArrayList arrlist = new ArrayList(query.List());
                for (int i = 0; i < arrlist.Count; i++)
                {
                    prob = new ProblemList();
                    object[] obj = (object[])arrlist[i];
                    prob.Id = Convert.ToUInt32(obj[0].ToString());
                    prob.Encounter_ID = Convert.ToUInt32(obj[1].ToString());
                    prob.Physician_ID = Convert.ToUInt32(obj[2].ToString());
                    prob.Reference_Source = obj[3].ToString();
                    prob.ICD = obj[4].ToString();
                    prob.Problem_Description = obj[5].ToString();
                    prob.Created_By = obj[6].ToString();
                    prob.Created_Date_And_Time = Convert.ToDateTime(obj[7]);
                    prob.Modified_By = obj[8].ToString();
                    prob.Modified_Date_And_Time = Convert.ToDateTime(obj[9]);
                    prob.Version = Convert.ToInt32(obj[10].ToString());
                    prob.Status = obj[11].ToString();
                    prob.Date_Diagnosed = obj[12].ToString();
                    prob.Rcopia_ID = Convert.ToUInt32(obj[13].ToString());

                    list.Add(prob);
                }
                iMySession.Close();
            }
            return list;
        }



        public ProblemList GetRcopiaProblemRecords(ulong ulRcopia_ID)
        {
            ProblemList objMedication = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Rcopia_ID", ulRcopia_ID));
                IList<ProblemList> listPrb = crit.List<ProblemList>();
                if (listPrb.Count > 0)
                {
                    objMedication = listPrb[0];
                }
                iMySession.Close();
            }
            return objMedication;
        }

        public IList<ProblemList> GetProblemList(ulong ulHumanID)
        {
            IList<ProblemList> ilstProblemList = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Status", "Active")).Add(Expression.Eq("Is_Active", "Y"));
                //return crt.List<ProblemList>();
                ilstProblemList = crt.List<ProblemList>();
                iMySession.Close();
            }
            return ilstProblemList;
        }

        //int iTryCount = 0;
        //Added By Muthu on 02-02-2013
        public IList<ProblemList> InsertorUpdateIntoProblemList(IList<ProblemList> AddProblemList, IList<ProblemList> UpdateProblemList, ulong ulHumanID, string sMacAddress, bool sSatus, string sLegalOrg)
        {
            IList<ProblemList> saveProblemList = new List<ProblemList>();
        TryAgain:
            //int iResult = 0;
            GenerateXml xmlobjEncounter = new GenerateXml();
            ProblemListManager pm = new ProblemListManager();
            //bool objProblistConsistent = true;
            // SaveUpdateDeleteWithTransaction(ref AddProblemList, UpdateProblemList, null, sMacAddress);
            ulong EncounterORHumanId = 0;
            if (AddProblemList.Count > 0)
                EncounterORHumanId = AddProblemList[0].Human_ID;
            else
                EncounterORHumanId = UpdateProblemList[0].Human_ID;
            // SaveUpdateDelete_DBAndXML_WithTransaction(ref AddProblemList, ref UpdateProblemList, null, sMacAddress, true, true, EncounterORHumanId, string.Empty);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref AddProblemList, ref UpdateProblemList, null, sMacAddress, true, true, EncounterORHumanId,string.Empty);
            #region oldsave
            //using (ISession MySession = Session.GetISession())
            //{
            //    try
            //    {
            //        using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            //        {
            //            try
            //            {

            //                iResult = pm.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref AddProblemList, ref UpdateProblemList, null, MySession, sMacAddress, true, true, EncounterORHumanId, string.Empty, ref xmlobjEncounter);
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
            //                        throw new Exception("Deadlock occurred. Transaction failed.");
            //                    }
            //                }
            //                else if (iResult == 1)
            //                {
            //                    trans.Rollback();
            //                    // MySession.Close();
            //                    throw new Exception("Exception occurred. Transaction failed.");
            //                }
            //                objProblistConsistent = xmlobjEncounter.CheckDataConsistency(AddProblemList.Concat(UpdateProblemList).Cast<object>().ToList(), true, string.Empty);
            //                if (objProblistConsistent)
            //                {
            //                    trans.Commit();
            //                    xmlobjEncounter.itemDoc.Save(xmlobjEncounter.strXmlFilePath);
            //                }
            //                else
            //                    throw new Exception("Data inconsistency detected while saving. Please try again or notify support.");

            //            }
            //            catch (NHibernate.Exceptions.GenericADOException ex)
            //            {
            //                trans.Rollback();
            //                // MySession.Close();
            //                throw new Exception(ex.Message);
            //            }
            //            catch (Exception e)
            //            {
            //                trans.Rollback();
            //                //MySession.Close();
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
            //}
            #endregion

            //Insert into RcopiaServer
            RCopiaTransactionManager objmngr = new RCopiaTransactionManager();

            HumanManager hManager = new HumanManager();
            Human humanRecord = hManager.GetById(ulHumanID);
            if (humanRecord.Is_Sent_To_Rcopia == "N")
            {
                objmngr.SendPatientToRCopia(ulHumanID, sMacAddress,sLegalOrg);
            }
            IList<Assessment> ilstassesment = null;
            //foreach (ProblemList pr in AddProblemList)
            //{
            //    pr.Version = pr.Version ;
            //}
            //foreach (ProblemList pr in UpdateProblemList)
            //{
            //    pr.Version = pr.Version + 1;
            //}
            IList<ProblemList> ResultList = AddProblemList.Concat(UpdateProblemList).ToList<ProblemList>();
            IList<ulong> ilstinsertIds = new List<ulong>();
            ResultList.ToList().ForEach(a => ilstinsertIds.Add(a.Id));

            if (ilstinsertIds.Count > 0 && ilstinsertIds != null)
            {
                objmngr.SendProblemToRCopia(ilstinsertIds, "problemlist", false, ilstassesment,sLegalOrg);
            }
            //GenerateXml XMLObj = new GenerateXml();
            //if (AddProblemList != null && AddProblemList.Count > 0)
            //{
            //    ulong humanid = AddProblemList[0].Human_ID;
            //    List<object> lstObj = AddProblemList.Cast<object>().ToList();
            //    XMLObj.GenerateXmlSaveStatic(lstObj, humanid, string.Empty);
            //}
            //if (UpdateProblemList != null && UpdateProblemList.Count > 0)
            //{
            //    ulong humanid = UpdateProblemList[0].Human_ID;
            //    List<object> lstObj = UpdateProblemList.Cast<object>().ToList();
            //    XMLObj.GenerateXmlUpdate(lstObj, humanid, string.Empty);
            //}
            return ResultList;
        }

        //Added By ThiyagarajanM 16-05-2013



        public IList<ProblemList> ICDByHumanID(ulong ulHumanID)
        {
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Human_ID", ulHumanID));
                listPrb = crt.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;

        }

        public IList<ProblemList> GetProblemListForRecommendedMaterials(ulong ulEncounterId, ulong ulHumanId)
        {
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Encounter_ID", ulEncounterId)).Add(Expression.Eq("Human_ID", ulHumanId)).Add(Expression.Eq("Reference_Source", "Assessment")).Add(Expression.Eq("Status", "Active"));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }

        public IList<ProblemList> GetProblemListByICD(ulong EncID, ulong HumanID, IList<string> ICD)
        {
            IList<ProblemList> listPrb = new List<ProblemList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.Eq("Encounter_ID", EncID)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.In("ICD_Code", ICD.ToArray()));
                listPrb = criteria.List<ProblemList>();
                iMySession.Close();
            }
            return listPrb;
        }


        public void SaveProblemListforSummary(IList<ProblemList> lstproblem)
        {
            IList<ProblemList> ilstProblemList = new List<ProblemList>();
            SaveUpdateDelete_DBAndXML_WithTransaction(ref lstproblem, ref ilstProblemList, null, string.Empty, false, false, 0, string.Empty);
            //SaveUpdateDeleteWithTransaction(ref lstproblem, null, null, string.Empty);
        }

        public IList<ProblemList> GetFromProblemList(ulong encounterId)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProblemList))
                                    .Add(Expression.Eq("Encounter_ID", encounterId));
                IList<ProblemList> ilstProblemList = criteria.List<ProblemList>();
                iMySession.Close();
                return ilstProblemList;
            }
        }

        #endregion
    }
}