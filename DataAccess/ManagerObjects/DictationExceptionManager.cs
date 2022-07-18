using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Data;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IDictationExceptionManager : IManagerBase<DictationException, ulong>
    {
        IList<MyQ> GetEncounterDetailsForDictation(ulong PhysicianID);
        void UpdateDictationException(ulong Exception_ID, ulong Encounter_ID, string macAddress);
        IList<DictationException> LoadDictationException(ulong ExceptionID);
        IList<MyQ> GetSearchResultsForDictation(ulong PhysicianID, string DOS, string Patinet_Name, ulong ACNo, string DOB);
        //IList<FillDictationOrderDTO> GetDictationOrders(ulong uProviderID, ulong ACNo, string Order_Status, string dtpSpecimenCollectionDate);
        void AddOrUpdateForResultMaster(ulong uOrder_Submit_ID, string macAddress, string[] order_ExceptionID);
        //void SaveOrUpdateResultMaster(ulong exceptionID, ulong order_ID, DateTime dtCurrentDateTime, string macAddress, string fileName);
    }

    public partial class DictationExceptionManager : ManagerBase<DictationException, ulong>, IDictationExceptionManager
    {
        #region Constructor

        public DictationExceptionManager()
            : base()
        {
        }

        public DictationExceptionManager(INHibernateSession session)
            : base(session)
        {
        }

        #endregion

        #region Methods

        public IList<MyQ> GetEncounterDetailsForDictation(ulong PhysicianID)
        {
            MyQ objMyQ;
            IList<MyQ> resultList = new List<MyQ>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query1 = iMySession.GetNamedQuery("FillDictationObject.ExistEncounter");
                query1.SetParameter(0, PhysicianID);
                string[] ObjType = new string[2] { "PROVIDER_PROCESS", "DICTATION_WAIT" };
                query1.SetParameterList("ObjList", ObjType);
                ArrayList arrayList = new ArrayList(query1.List());


                if (arrayList != null && arrayList.Count > 0)
                {
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        objMyQ = new MyQ();

                        object[] oj = (object[])arrayList[i];
                        objMyQ.Date_of_Service = Convert.ToDateTime(oj[0].ToString());
                        objMyQ.Medical_Record_Number = oj[1].ToString();
                        objMyQ.Human_ID = Convert.ToUInt64(oj[2]);
                        objMyQ.Encounter_ID = Convert.ToUInt64(oj[3]);
                        objMyQ.Physician_ID = Convert.ToUInt64(oj[4]);
                        objMyQ.Type_Of_Visit = oj[5].ToString();
                        objMyQ.DOB = Convert.ToDateTime(oj[6].ToString());
                        objMyQ.Appt_Date_Time = Convert.ToDateTime(oj[7].ToString());
                        objMyQ.External_Account_Number = oj[8].ToString();
                        //objMyQ.Exam_Room = oj[9].ToString();
                        objMyQ.Facility_Name = oj[10].ToString();
                        objMyQ.Patient_Status = oj[11].ToString();
                        objMyQ.Last_Name = oj[12].ToString();
                        objMyQ.First_Name = oj[13].ToString();
                        objMyQ.MI = oj[14].ToString();
                        objMyQ.Current_Process = oj[15].ToString();
                        if (oj[16] != null)
                            objMyQ.AssignedPhysician = oj[16].ToString();

                        objMyQ.Current_Owner = oj[17].ToString();


                        resultList.Add(objMyQ);
                    }
                }
                iMySession.Close();
            }
            return resultList;

        }

        public void UpdateDictationException(ulong Exception_ID, ulong Encounter_ID, string macAddress)
        {
            IList<DictationException> lst =new List<DictationException>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = session.GetISession().CreateCriteria(typeof(DictationException)).Add(Expression.Eq("Exception_ID", Exception_ID));
                lst = crit.List<DictationException>();
                if (lst != null)
                    lst[0].Encounter_ID = Encounter_ID;
                iMySession.Close();
            }
            IList<DictationException> addLst = new List<DictationException>();

            SaveUpdateDeleteWithTransaction(ref addLst, lst, null, macAddress);


        }
        public IList<DictationException> LoadDictationException(ulong ExceptionID)
        {
             IList<DictationException> lst =new List<DictationException>();
             using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
             {
                 ICriteria crit = session.GetISession().CreateCriteria(typeof(DictationException)).Add(Expression.Eq("Exception_ID", ExceptionID));
                 lst = crit.List<DictationException>();
                 iMySession.Close();
             }

            return lst;
        }
        public IList<DictationException> GetDictationExceptionOrders(ulong ExceptionID)
        {
             IList<DictationException> lst =new List<DictationException>();
             using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
             {
                 ICriteria crit = session.GetISession().CreateCriteria(typeof(DictationException)).Add(Expression.Eq("Exception_ID", ExceptionID));
                 lst = crit.List<DictationException>();
                 iMySession.Close();
             }

            return lst;
        }

        public IList<MyQ> GetSearchResultsForDictation(ulong PhysicianID, string DOS, string Patinet_Name, ulong ACNo, string DOB)
        {
            MyQ objMyQ;
            IList<MyQ> resultList = new List<MyQ>();
            string[] ObjType = new string[3] { "PROVIDER_PROCESS", "DICTATION_WAIT", "MA_PROCESS" };
            string sCondition = string.Empty;
            string sObject_Type = " and  w.Current_Process in('PROVIDER_PROCESS','DICTATION_WAIT','MA_PROCESS');";

            string sHql = "SELECT  cast(e.Date_of_Service as char(100)) as d,h.Medical_Record_Number,h.Human_ID,e.Encounter_ID,e.Encounter_Provider_ID,e.Visit_Type,cast(h.Birth_Date as char(100)) as b,cast(e.Appointment_Date as char(100)) as a, h.Patient_Account_External,e.Exam_Room,e.Facility_Name,h.Patient_Status,h.Last_Name,h.First_Name,h.MI,w.Current_Process,concat(p.Physician_Prefix,' ',p.Physician_First_Name,' ',p.Physician_Middle_Name,' ',p.Physician_Last_Name,' ',p.Physician_Suffix),w.Current_Owner  FROM wf_object w left join encounter e on (w.Obj_System_Id=e.Encounter_ID) left join human h on (e.Human_ID=h.Human_ID) left join physician_library p on (e.Encounter_Provider_ID=p.Physician_Library_ID)  where  ";

            if (PhysicianID > 0)
            {
                sCondition = "e.Encounter_Provider_ID ='" + PhysicianID + "'";
            }
            if (DOS.Trim() != string.Empty)
            {
                if (sCondition.Trim() == string.Empty)
                    sCondition = "Date_Format(e.Date_of_Service,'%Y-%m-%d')='" + DOS + "'";
                else
                    sCondition += " and Date_Format(e.Date_of_Service,'%Y-%m-%d')='" + DOS + "'";
            }
            if (ACNo > 0)
            {
                if (sCondition.Trim() == string.Empty)
                    sCondition = "h.Human_ID='" + ACNo + "'";
                else
                    sCondition += " and " + " h.Human_ID='" + ACNo + "'";
            }


            string sFinal_Query = sHql + sCondition + sObject_Type;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                ISQLQuery query = iMySession.CreateSQLQuery(sFinal_Query);

                ArrayList arrayList = new ArrayList(query.List());


                if (arrayList != null && arrayList.Count > 0)
                {
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        objMyQ = new MyQ();
                        object[] oj = (object[])arrayList[i];
                        objMyQ.Date_of_Service = Convert.ToDateTime(oj[0].ToString());
                        objMyQ.Medical_Record_Number = oj[1].ToString();
                        objMyQ.Human_ID = Convert.ToUInt64(oj[2]);
                        objMyQ.Encounter_ID = Convert.ToUInt64(oj[3]);
                        objMyQ.Physician_ID = Convert.ToUInt64(oj[4]);
                        objMyQ.Type_Of_Visit = oj[5].ToString();
                        objMyQ.DOB = Convert.ToDateTime(oj[6].ToString());
                        objMyQ.Appt_Date_Time = Convert.ToDateTime(oj[7].ToString());
                        objMyQ.External_Account_Number = oj[8].ToString();
                        //objMyQ.Exam_Room = oj[9].ToString();
                        objMyQ.Facility_Name = oj[10].ToString();
                        objMyQ.Patient_Status = oj[11].ToString();
                        objMyQ.Last_Name = oj[12].ToString();
                        objMyQ.First_Name = oj[13].ToString();
                        objMyQ.MI = oj[14].ToString();
                        objMyQ.Current_Process = oj[15].ToString();
                        if (oj[16] != null)
                            objMyQ.AssignedPhysician = oj[16].ToString();

                        objMyQ.Current_Owner = oj[17].ToString();


                        resultList.Add(objMyQ);
                    }
                }
                iMySession.Close();
            }
            return resultList;


        }
        //public IList<FillDictationOrderDTO> GetDictationOrders(ulong uProviderID, ulong ACNo, string Order_Status, string dtpSpecimenCollectionDate)
        //{
        //    IList<FillDictationOrderDTO> resultlst = new List<FillDictationOrderDTO>();
        //    FillDictationOrderDTO objDictationOrder;

        //    string sHql = "SELECT cast(r.Specimen_Collection_Date_And_Time as char(100)) as d,r.Order_Submit_ID,w.Current_Process,r.Physician_ID,r.Human_ID  FROM  wf_object as w left join orders_submit as r on (w.Obj_System_Id=r.Order_Submit_ID) where  ";

        //    string Current_Process = string.Empty;
        //    string sCondition = string.Empty;


        //    if (uProviderID > 0)
        //    {
        //        sCondition = "r.Physician_ID='" + uProviderID + "'";
        //    }
        //    if (ACNo > 0)
        //    {
        //        if (sCondition.Trim() == string.Empty)
        //            sCondition = "r.Human_ID='" + ACNo + "'";
        //        else
        //            sCondition += "  and  r.Human_ID='" + ACNo + "'";
        //    }
        //    if (dtpSpecimenCollectionDate.Trim() != string.Empty)
        //    {
        //        if (sCondition.Trim() == string.Empty)
        //            sCondition = "Date_Format(r.Specimen_Collection_Date_And_Time,'%Y-%m-%d')='" + dtpSpecimenCollectionDate + "'";
        //        else
        //            sCondition += "  and Date_Format(r.Specimen_Collection_Date_And_Time,'%Y-%m-%d')='" + dtpSpecimenCollectionDate + "'";
        //    }

        //    if (Order_Status.Trim() == string.Empty)
        //    {
        //        if (sCondition.Trim() == string.Empty)
        //            Current_Process = " w.Current_Process in('ORDER_GENERATE','RESULT_REVIEW','MA_REVIEW');";
        //        else
        //            Current_Process += " and  w.Current_Process in('ORDER_GENERATE','RESULT_REVIEW','MA_REVIEW');";
        //    }
        //    else
        //    {
        //        if (sCondition.Trim() == string.Empty)
        //            Current_Process = " w.Current_Process='" + Order_Status.Trim() + "';";
        //        else
        //            Current_Process += " and  w.Current_Process='" + Order_Status.Trim() + "';";
        //    }


        //    string sFinal_Query = sHql + sCondition + Current_Process;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {

        //        ISQLQuery query = iMySession.CreateSQLQuery(sFinal_Query);

        //        ArrayList arrayList = new ArrayList(query.List());
        //        if (arrayList != null && arrayList.Count > 0)
        //        {
        //            for (int i = 0; i < arrayList.Count; i++)
        //            {
        //                objDictationOrder = new FillDictationOrderDTO();
        //                object[] obj = (object[])arrayList[i];
        //                objDictationOrder.Speciman_Collection_Date = (obj[0] != null && obj[0].ToString() != string.Empty) ? Convert.ToDateTime(obj[0].ToString()) : DateTime.MinValue;
        //                objDictationOrder.Order_Submit_Id = (obj[1] != null && obj[1].ToString() != string.Empty) ? Convert.ToUInt32(obj[1]) : 0;
        //                objDictationOrder.Current_Process = (obj[2] != null && obj[2].ToString() != string.Empty) ? obj[2].ToString() : string.Empty;
        //                if (obj[3] != null && obj[3].ToString().Trim() != string.Empty)
        //                {
        //                    ICriteria critPhy = session.GetISession().CreateCriteria(typeof(PhysicianLibrary)).Add(Expression.Eq("Id", Convert.ToUInt64(obj[3].ToString())));
        //                    IList<PhysicianLibrary> Phy_lst = critPhy.List<PhysicianLibrary>();
        //                    if (Phy_lst != null && Phy_lst.Count > 0)
        //                        objDictationOrder.Physician_Name = Phy_lst[0].PhyPrefix + " " + Phy_lst[0].PhyFirstName + " " + Phy_lst[0].PhyMiddleName + " " + Phy_lst[0].PhyLastName;

        //                }

        //                if (obj[4] != null && obj[4].ToString().Trim() != string.Empty)
        //                {
        //                    ICriteria critHuman = session.GetISession().CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", Convert.ToUInt64(obj[4].ToString())));
        //                    IList<Human> Human_lst = critHuman.List<Human>();

        //                    if (Human_lst != null && Human_lst.Count > 0)
        //                    {
        //                        objDictationOrder.Human_Id = Human_lst[0].Id;
        //                        objDictationOrder.Patient_External_Id = Human_lst[0].Patient_Account_External;
        //                        objDictationOrder.Patient_Name = Human_lst[0].Last_Name + " " + Human_lst[0].First_Name + " " + Human_lst[0].MI;
        //                        objDictationOrder.Patient_DOB = Human_lst[0].Birth_Date.ToString("dd-MMM-yyyy");


        //                    }
        //                }


        //                if (obj[1] != null)
        //                {
        //                    ICriteria crit = session.GetISession().CreateCriteria(typeof(Orders)).Add(Expression.Eq("Order_Submit_ID", Convert.ToUInt64(obj[1])));
        //                    IList<Orders> lst = crit.List<Orders>();

        //                    string value = string.Empty;

        //                    if (lst != null && lst.Count > 0)
        //                    {
        //                        foreach (Orders item in lst)
        //                        {
        //                            if (value.Trim() == string.Empty)
        //                                value = item.Lab_Procedure + "-" + item.Lab_Procedure_Description;
        //                            else
        //                                value += ", " + item.Lab_Procedure + "-" + item.Lab_Procedure_Description;
        //                        }
        //                    }
        //                    objDictationOrder.Procedure = value;
        //                }
        //                resultlst.Add(objDictationOrder);
        //            }
        //        }
        //        iMySession.Close();
        //    }
        //    return resultlst;
        //}

        public void AddOrUpdateForResultMaster(ulong uOrder_Submit_ID, string macAddress, string[] order_ExceptionID)
        {
            IList<DictationException> DictationExceptionUpdateList = new List<DictationException>();
            IList<DictationException> DictationExceptionAddList = new List<DictationException>();
            IList<DictationException> lst =new List<DictationException>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                for (int i = 0; i < order_ExceptionID.Length; i++)
                {
                    if (order_ExceptionID[i] != null && order_ExceptionID[i].Trim() != string.Empty)
                    {
                        ICriteria crit = iMySession.CreateCriteria(typeof(DictationException)).Add(Expression.Eq("Data", "Result Mismatch")).Add(Expression.Eq("Id", Convert.ToUInt64(order_ExceptionID[i])));
                        lst = crit.List<DictationException>();
                        lst[0].Encounter_ID = uOrder_Submit_ID;
                        DictationExceptionUpdateList.Add(lst[0]);
                    }
                }
                iMySession.Close();
            }

            if (DictationExceptionUpdateList.Count > 0)
                SaveUpdateDelete_DBAndXML_WithTransaction(ref DictationExceptionAddList, ref DictationExceptionUpdateList, null, macAddress, false, false, 0, string.Empty);
                //SaveUpdateDeleteWithTransaction(ref DictationExceptionAddList, DictationExceptionUpdateList, null, macAddress);
        }

        int iTryCount = 0;

        //public void SaveOrUpdateResultMaster(ulong exceptionID, ulong order_ID, DateTime dtCurrentDateTime, string macAddress, string fileName)
        //{
        //    IList<DictationException> DictationExceptionUpdateList = new List<DictationException>();
        //    IList<DictationException> DictationExceptionAddList = new List<DictationException>();

        //    ICriteria critDictationException = session.GetISession().CreateCriteria(typeof(DictationException)).Add(Expression.Eq("Id", exceptionID));
        //    IList<DictationException> dictationExceptionList = critDictationException.List<DictationException>();

        //    if (dictationExceptionList.Count > 0)
        //    {
        //        ResultMasterManager objResultMasterManager = new ResultMasterManager();

        //        IList<ResultMaster> resultMasterAddList = new List<ResultMaster>();

        //        ICriteria crit = session.GetISession().CreateCriteria(typeof(ResultMaster)).Add(Expression.Eq("Order_ID", order_ID));
        //        IList<ResultMaster> resultMasterList = crit.List<ResultMaster>();

        //        string userName = string.Empty;
        //        ulong humanId = 0;

        //        ICriteria critOrdersSubmit = session.GetISession().CreateCriteria(typeof(OrdersSubmit)).Add(Expression.Eq("Id", order_ID));
        //        IList<OrdersSubmit> OrdersSubmitList = critOrdersSubmit.List<OrdersSubmit>();

        //        if (OrdersSubmitList != null && OrdersSubmitList.Count > 0)
        //        {
        //            humanId = OrdersSubmitList[0].Human_ID;
        //            PhysicianManager objPhysicianManager = new PhysicianManager();
        //            FillPhysicianUser objFillPhysicianManager = objPhysicianManager.GetPhysicianandUser(false, string.Empty);
        //            userName = objFillPhysicianManager.UserList.Where(s => s.Physician_Library_ID == OrdersSubmitList[0].Physician_ID).Select(f => f.user_name).FirstOrDefault();
        //        }

        //        if (resultMasterList != null && resultMasterList.Count > 0)
        //        {
        //            resultMasterList[0].Result_Review_Comments += dictationExceptionList[0].Sub_Header;
        //            //objResultMasterManager.SaveUpdateDeleteWithTransaction(ref resultMasterAddList, resultMasterList, null, macAddress);                    
        //            objResultMasterManager.SaveUpdateDelete_DBAndXML_WithTransaction(ref resultMasterAddList, ref resultMasterList, null, macAddress, false, false, 0, string.Empty);
        //        }
        //        else
        //        {
        //            ResultMaster objResultMaster = new ResultMaster();
        //            objResultMaster.Order_ID = order_ID;
        //            objResultMaster.PID_Alternate_Patient_ID = humanId.ToString();
        //            objResultMaster.Result_Review_Comments = dictationExceptionList[0].Sub_Header;
        //            resultMasterAddList.Add(objResultMaster);

        //            //objResultMasterManager.SaveUpdateDeleteWithTransaction(ref resultMasterAddList, null, null, macAddress);                   
        //            IList<ResultMaster> resultMasterAddListnull = new List<ResultMaster>();
        //            objResultMasterManager.SaveUpdateDelete_DBAndXML_WithTransaction(ref resultMasterAddList, ref resultMasterAddListnull, null, macAddress, false, false, 0, string.Empty);
        //        }

        //        iTryCount = 0;

        //    TryAgain:

        //        int iResult = 0;

        //        ISession MySession = Session.GetISession();
        //        ITransaction trans = null;
        //        try
        //        {
        //            trans = MySession.BeginTransaction();


        //            IList<DictationException> dictationExceptionExistList = new List<DictationException>();
        //            ICriteria critDictationExceptionExist = session.GetISession().CreateCriteria(typeof(DictationException)).Add(Expression.Eq("File_Name", fileName)).Add(Expression.Eq("Data", "Result Mismatch"));
        //            dictationExceptionExistList = critDictationExceptionExist.List<DictationException>();

        //            if (dictationExceptionExistList.Count > 0 && dictationExceptionExistList.All(s => s.Encounter_ID != 0))
        //            {
        //                foreach (var item in dictationExceptionExistList.GroupBy(g => g.Encounter_ID).ToList())
        //                {
        //                    ICriteria critWF = session.GetISession().CreateCriteria(typeof(WFObject)).Add(Expression.Eq("Obj_System_Id", item.Key)).Add(Expression.Eq("Obj_Type", "DIAGNOSTIC ORDER"));
        //                    IList<WFObject> wfList = critWF.List<WFObject>();

        //                    int closeType = 2;
        //                    if (wfList != null && wfList.Count > 0)
        //                    {
        //                        if (wfList[0].Current_Process.ToUpper() == "ORDER_GENERATE")
        //                            closeType = 2;
        //                        else if (wfList[0].Current_Process.ToUpper() == "RESULT_REVIEW")
        //                            closeType = 3;
        //                        else if (wfList[0].Current_Process.ToUpper() == "MA_REVIEW")
        //                            closeType = 7;
        //                    }

        //                    WFObjectManager objWFObjMgr = new WFObjectManager();
        //                    iResult = objWFObjMgr.MoveToNextProcess(item.Key, "DIAGNOSTIC ORDER", closeType, userName, dtCurrentDateTime, macAddress, null, MySession);

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
        //                            throw new Exception("Deadlock occurred. Transaction failed.");
        //                        }
        //                    }
        //                    else if (iResult == 1)
        //                    {
        //                        trans.Rollback();
        //                        throw new Exception("Exception occurred. Transaction failed.");
        //                    }
        //                }
        //            }

        //            MySession.Flush();
        //            trans.Commit();

        //        }
        //        catch (NHibernate.Exceptions.GenericADOException ex)
        //        {
        //            trans.Rollback();
        //            throw new Exception(ex.Message);
        //        }
        //        catch (Exception e)
        //        {
        //            trans.Rollback();
        //            throw new Exception(e.Message);
        //        }
        //        finally
        //        {
        //            MySession.Close();
        //        }
        //    }
        //}

        #endregion
    }
}
