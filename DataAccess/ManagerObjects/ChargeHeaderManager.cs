using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Collections;
using System.Data;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IChargeHeaderManager : IManagerBase<ChargeHeader, ulong>
    {
        //AddorViewMessageDTO LoadChargeDetails(ulong MyHumanId, int PageNumber, int MaxResultSet);
        //AddorViewMessageDTO LoadAddorViewMessage(ulong MyHumanId, int PageNumber, int MaxResultSet);

        //ChargePostingDTO GetChargeHeaderForChargePosting(ulong ChargeHeaderID, ulong[] ChargeLineItemID, ulong[] BillToID, ulong[] AccountTransactionID);

        IList<ChargeHeader> AddChargeHeaderRecord(ChargeHeader objChargeHeader, string MacAddress);
        IList<ChargeHeader> GetChargeHeaderValuesUsingEncounterID(ulong encounterId);
        //ChargePostingDTO BatchSaveChargeHeaderLineItem(object[] ObjList, IList<ChargeHeader> ChargeHeaderUpdateList, IList<ChargeLineItem> ChargeLineItemUpdateList
        //     , IList<BillTo> BillToUpdateList, IList<AccountTransaction> AccountTransactionUpdateList, IList<Message> MessageSaveList, string MacAddress);
        //ChargePostingDTO MoveToNextProcessForChargeLineItem(string objType, ulong WfObjId, string Username, DateTime StartTime, WFObjectBilling wfObj, ulong EncounterID, string MacAddress, string sParentScreen, string sBatchType, ulong ulAccNo, ulong ulEncID, IList<ulong> ChargeLineItemIDList, string sBillDestination, ulong ulChargeHeaderID);
        //IList<object> CloseWorksetForChargePosting(ulong WfObjectID, ulong DemosReceived, DateTime dt_DOPStarted, DateTime dt_DOPCompleted, string s_UserName, int us_CloseType, string MacAddress, bool bPerformValidation, ulong usTotalProcessed, string sBatchType, ulong ulAccNo, ulong ulEncID, IList<ulong> ChargeLineItemIDList, string sBillDestination, ulong ulChargeHeaderID);
        //ChargePostingDTO SaveCodingAndChargePosting(IList<ChargeHeader> ChargeHeaderSaveList, IList<ChargeLineItem> ChargeLineItemSaveList, IList<ChargeHeader> ChargeHeaderUpdateList, IList<ChargeLineItem> ChargeLineItemUpdateList, IList<BillTo> BillToSaveList, IList<BillTo> BillToUpdateList,
        //     IList<AccountTransaction> AccountTransactionSaveList, IList<AccountTransaction> AccountTrasactionUpdateList, object[] ObjList, IList<ulong> DeleteLineItemList, IList<ulong> EncounterIDList, IList<WFObjectBilling> WfObjectBillingSaveList, IList<WFObjectBilling> WFEncounterList, IList<PPLineItem> PPLineItemCopayList, IList<AccountTransaction> AccountTransactionCopayList
        //     , IList<PPLineItem> PPLineItemUpdateCopayList, IList<string> CPTCopay, string MacAddress, IList<AuthorizationProcedure> AuthorizationProcedureList, IList<Encounter> EncounterSaveList, IList<WFObjectBilling> WFObjectBillingSaveList, string sParentScreen, string sBatchType, ulong ulAccNo, ulong ulEncID, IList<ulong> ChargeLineItemIDList, string sBillDestination, ulong ulChargeHeaderID, IList<PatientNotes> PatientNotesSaveList, IList<Authorization> AuthorizationSaveList, IList<Authorization> AuthorizationUpdateList, IList<AuthorizationEncounter> AuthorizationEncSaveList, IList<AuthorizationEncounter> AuthorizationEncUpdateList, IList<AuthorizationEncounter> AuthorizationEncNewSaveList, IList<AuthorizationProcedure> AuthorizationProcedureUpdateList);
        //Added by srividhya on 02-Apr-2013
        //ulong CPBatchMoveToNextProcess(ulong ulWFObjectID, IList<ulong> ChargeLineItemIDList, string MacAddress, ulong ulIntRefID, string sDOOS, string sBatchName, string sObjectType, string sUserName, string sBillDestination, ulong ulAccNo, string sDOS, IList<ObjectProcessHistoryBillingTemp> ObjectProcessHistoryBillingTempList, DateTime dtStartTime, DateTime dtEndTime, ulong ulBatchID, IList<ObjectProcessHistoryBillingTemp> ObjectProcessHistoryBillingTempUpdateList, IList<ObjectProcessHistoryBilling> ObjectProcessHistoryBillingUpdateList, string sCurrProcess);
        //ulong CPManualBatchMoveToNextProcess(ulong ulWFObjectID, IList<ulong> ChargeLineItemIDList, string MacAddress, string sDOS, string sDOOS, string sBatchName, string sObjectType, string sUserName, string sBillDestination, ulong ulAccNo, IList<ObjectProcessHistoryBillingTemp> ObjectProcessHistoryBillingTempList, ulong ulRendProvID, ulong ulBatchID, DateTime dtStartTime, DateTime dtEndTime);
        //IList<ChargeHeaderDTO> ilstChargeHeader(ulong Human_ID);
        IList<ChargeHeader> GetChargeHeaderbyChargeHeaderID(ulong ulChargeHeaderID);
        IList<ChargeHeader> GetChargeHeaderbyBatchID(ulong ulBatchID);
        IList<ChargeHeader> GetChargeAmount(ulong ulChargeHeaderID);
        IList<ChargeHeader> GetChargeHeaderListbyUniqueIdentifier(ulong ulBatchID, ulong ulEncounterID, ulong ulHumanID, string sChargeHeaderIdentifier);
        IList<ChargeLineItem> GetChargeLineItembyChargeInternalReferenceID(ulong ulInternal_Reference_ID);
        IList<ChargeLineItem> GetChargeLineItembyChargeHeaderID(ulong ulHeaderID);
    }

    public partial class ChargeHeaderManager : ManagerBase<ChargeHeader, ulong>, IChargeHeaderManager
    {
        #region Constructors

        public ChargeHeaderManager()
            : base()
        {

        }
        public ChargeHeaderManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        //public AddorViewMessageDTO LoadChargeDetails(ulong MyHumanId, int PageNumber, int MaxResultSet)
        //{
        //    AddorViewMessageDTO objAddViewMessage = new AddorViewMessageDTO();
        //    ChargeHeader objChargeHeader;
        //    ChargeLineItem objChargeLineItem;
        //    int iPagenumber = PageNumber - 1;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Count = iMySession.CreateSQLQuery("SELECT count(*) FROM Charge_Header a, Charge_line_Item b WHERE a.Charge_Header_Id=b.Charge_Header_ID AND a.Human_ID =" + MyHumanId + " ORDER BY b.Charge_Line_Item_ID ").List<object>()[0];
        //        objAddViewMessage.TotalCount = Convert.ToInt32(Count);

        //        ISQLQuery sql = iMySession.CreateSQLQuery("SELECT a.*,b.* FROM Charge_Header a, Charge_line_Item b WHERE a.Charge_Header_Id=b.Charge_Header_ID AND a.Human_ID =" + MyHumanId + " ORDER BY b.Charge_Line_Item_ID limit " + (iPagenumber * MaxResultSet) + "," + MaxResultSet + "")
        //           .AddEntity("a", typeof(ChargeHeader))
        //         .AddEntity("b", typeof(ChargeLineItem));

        //        foreach (IList<Object> l in sql.List())
        //        {
        //            objChargeHeader = new ChargeHeader();
        //            ChargeHeader objChargeHead = (ChargeHeader)l[0];
        //            objChargeHeader.Human_ID = objChargeHead.Human_ID;
        //            //objChargeHeader.Voucher_No = objChargeHead.Voucher_No;
        //            objChargeHeader.Id = objChargeHead.Id;
        //            objAddViewMessage.ChargeHeaderList.Add(objChargeHeader);

        //            objChargeLineItem = new ChargeLineItem();
        //            ChargeLineItem objChargeLine = (ChargeLineItem)l[1];
        //            //objChargeLineItem.Primary_Payer_Name = objChargeLine.Primary_Payer_Name;
        //            objChargeLineItem.From_DOS = objChargeLine.From_DOS;
        //            objChargeLineItem.Rendering_Provider_ID = objChargeLine.Rendering_Provider_ID;
        //            objChargeLineItem.Procedure_Code = objChargeLine.Procedure_Code;
        //            objChargeLineItem.Modifier1 = objChargeLine.Modifier1;
        //            objChargeLineItem.Units = objChargeLine.Units;
        //            //Srividhya commented this - Need to get the Diagnosis Pointer values
        //            //objChargeLineItem.Diagnosis1 = objChargeLine.Diagnosis1;
        //            //objChargeLineItem.Diagnosis2 = objChargeLine.Diagnosis2;
        //            //objChargeLineItem.Diagnosis3 = objChargeLine.Diagnosis3;
        //            //objChargeLineItem.Diagnosis4 = objChargeLine.Diagnosis4;       


        //            if (objChargeLine.Diagnosis_Pointer != "")
        //            {
        //                string[] strSplitCLIDiagPointer = objChargeLine.Diagnosis_Pointer.Split(',');
        //                string[] strSplitCHDiag = objChargeHead.Diagnosis1.Split(',');
        //                //string sDiagPointer = "";

        //                //    for (int j = 0; j < strSplitCLIDiagPointer.Length; j++)
        //                //    {
        //                //        for (int i = 0; i < strSplitCHDiag.Length; i++)
        //                //        {
        //                //            if (strSplitCHDiag[i].Split('-')[0].ToString() == strSplitCLIDiagPointer[j].ToString())
        //                //            {
        //                //                if (sDiagPointer == "")
        //                //                {
        //                //                    sDiagPointer = strSplitCHDiag[i].ToString();
        //                //                }
        //                //                else
        //                //                {
        //                //                    sDiagPointer =sDiagPointer+","+ strSplitCHDiag[i].ToString();
        //                //                }
        //                //            }
        //                //        }
        //                //    }

        //                //    objChargeLineItem.Diagnosis_Pointer = sDiagPointer;
        //            }

        //            objChargeLineItem.Diagnosis_Pointer = objChargeLine.Diagnosis_Pointer;
        //            objChargeLineItem.Charge_Amount = objChargeLine.Charge_Amount;
        //            objChargeLineItem.Id = objChargeLine.Id;
        //            objAddViewMessage.ChargeLineItemList.Add(objChargeLineItem);
        //        }
        //        iMySession.Close();
        //    }
        //    return objAddViewMessage;
        //}
        //priya
        //public IList<ChargeHeaderDTO> ilstChargeHeader(ulong Human_ID)
        //{
        //    IList<ChargeHeaderDTO> ilstCharge = new List<ChargeHeaderDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery query = iMySession.GetNamedQuery("Fill.ChargeHeader");
        //        query.SetString(0, Human_ID.ToString());
        //        ArrayList arr = new ArrayList();
        //        arr = new ArrayList(query.List());
        //        //IList<ChargeHeader> ilstChargeHeader = new List<ChargeHeader>();
        //        //IList<Human> ilstHuman = new List<Human>();
        //        //IList<ChargeLineItem> ilstChargeLineItem = new List<ChargeLineItem>();
               
        //        foreach (object[] obj in arr)
        //        {
        //            //object[] obj = (object[])arr[i];
        //            //ChargeHeader chargeheadervalues = new ChargeHeader();
        //            //ChargeLineItem chargelineitem = new ChargeLineItem();
        //            //Human humanvalues = new Human();
        //            ChargeHeaderDTO objchargeheader = new ChargeHeaderDTO();
        //            objchargeheader.Human_ID = Convert.ToUInt32(obj[0]);
        //            objchargeheader.Patient_Name = obj[1].ToString();
        //            objchargeheader.Primary_Payer_ID = Convert.ToUInt32(obj[2]);
        //            objchargeheader.Encounter_ID = Convert.ToUInt32(obj[3]);
        //            objchargeheader.From_DOS = Convert.ToDateTime(obj[4].ToString());
        //            objchargeheader.Procedure_Code = obj[5].ToString();
        //            objchargeheader.Modifier1 = obj[6].ToString();
        //            objchargeheader.Units = Convert.ToInt32(obj[7]);
        //            objchargeheader.Diagnosis1 = obj[8].ToString();
        //            objchargeheader.Diagnosis2 = obj[9].ToString();
        //            objchargeheader.Diagnosis3 = obj[10].ToString();
        //            objchargeheader.Diagnosis4 = obj[11].ToString();
        //            objchargeheader.Charge_Amount = Convert.ToDouble(obj[12]);
        //            //ilstChargeHeader.Add(chargeheadervalues);
        //            //ilstHuman.Add(humanvalues);
        //            //ilstChargeLineItem.Add(chargelineitem);
        //            ilstCharge.Add(objchargeheader);
        //        }
        //        iMySession.Close();
        //    }
        //    return ilstCharge;
        //}
        

        //public AddorViewMessageDTO LoadAddorViewMessage(ulong MyHumanId, int PageNumber, int MaxResultSet)
        //{
        //    AddorViewMessageDTO objAddViewMessage = new AddorViewMessageDTO();
        //    objAddViewMessage = LoadChargeDetails(MyHumanId, PageNumber, MaxResultSet);
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", MyHumanId));
        //        objAddViewMessage.objHuman = crit.List<Human>()[0];

        //        ISQLQuery sql = iMySession.CreateSQLQuery("SELECT M.* FROM message M WHERE M.Human_ID = " + MyHumanId + " GROUP BY M.Message_Type ORDER BY M.Message_Date DESC,M.Created_Date_And_Time DESC")
        //           .AddEntity("M", typeof(Message));
        //        objAddViewMessage.MessageList = sql.List<Message>();
        //        iMySession.Close();
        //    }

        //    return objAddViewMessage;
        //}


        //public ChargePostingDTO GetChargeHeaderForChargePosting(ulong ChargeHeaderID, ulong[] ChargeLineItemID, ulong[] BillToID, ulong[] AccountTransactionID)
        //{
        //    ChargePostingDTO objChargePostingDTO = new ChargePostingDTO();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(ChargeHeader)).Add(Expression.Eq("Id", ChargeHeaderID));
        //        //objChargePostingDTO.ChargeHeader = crit.List<ChargeHeader>()[0];

        //        for (int i = 0; i < ChargeLineItemID.Length; i++)
        //        {
        //            crit = iMySession.CreateCriteria(typeof(ChargeLineItem)).Add(Expression.Eq("Id", ChargeLineItemID[i]));
        //            ChargeLineItem objChargeLine = crit.List<ChargeLineItem>()[0];
        //            objChargePostingDTO.ChargeLineItemList.Add(objChargeLine);

        //            crit = iMySession.CreateCriteria(typeof(BillTo)).Add(Expression.Eq("Id", BillToID[i]));
        //            BillTo objBillToID = crit.List<BillTo>()[0];
        //            objChargePostingDTO.BillToList.Add(objBillToID);

        //            crit = iMySession.CreateCriteria(typeof(AccountTransaction)).Add(Expression.Eq("Id", AccountTransactionID[i]));
        //            AccountTransaction objAccountTransaction = crit.List<AccountTransaction>()[0];
        //            objChargePostingDTO.AccountTransactionList.Add(objAccountTransaction);
        //        }
        //        iMySession.Close();
        //    }

        //    return objChargePostingDTO;
        //}

        //public ChargePostingDTO MoveToNextProcessForChargeLineItem(string objType, ulong WfObjId, string Username, DateTime StartTime, WFObjectBilling wfObj, ulong EncounterID, string MacAddress, string sParentScreen, string sBatchType, ulong ulAccNo, ulong ulEncID, IList<ulong> ChargeLineItemIDList, string sBillDestination, ulong ulChargeHeaderID,DateTime dtEndTime)
        //{
        //    int CloseType = 1;
        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    trans = MySession.BeginTransaction();
        //    WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();
        //    WorksetProcAllocManager objWorksetProcMgr = new WorksetProcAllocManager();

        //    if (objType.ToUpper() == "EXCEPTION" || objType.ToUpper() == "CALL" || objType.ToUpper() == "QC_ERROR")
        //    {
        //        //WFObjectBilling objWfObj = objWfObjManager.GetByWFObjectID(WfObjId);
        //        //if (objWfObj == null)
        //        //    return;

        //        //IList<WFObjectBilling> WfObjList = objWfObjManager.GetByParentObjectSystemId(objWfObj.Obj_System_Id, objWfObj.Obj_Type);
        //        //IList<WFObjectBilling> ExCallQcList = (from h in WfObjList
        //        //                                       where h.Obj_Type.ToUpper() == "EXCEPTION" ||
        //        //                                           h.Obj_Type.ToUpper() == "CALL" || h.Obj_Type.ToUpper() == "QC_ERROR"
        //        //                                       select h).ToList<WFObjectBilling>();
        //        //if (ExCallQcList == null || ExCallQcList.Count != 0)
        //        //    CloseType = 2;
        //        //else
        //        //    CloseType = 1;

        //        //bool bProcessResult = objWfObjManager.MoveToNextProcess(new[] { objWfObj.Obj_System_Id }, new[] { objWfObj.Obj_Type },
        //        //        CloseType, Username, StartTime, MySession);

        //        //IList<WFObjectBilling> wfOwnerUpdateList = new List<WFObjectBilling>();

        //        //Workset_proc_alloc objWorksetExCallQc = objWorksetProcMgr.GetUserName(objWfObj.DOOS, objWfObj.Batch_Name, objWfObj.Current_Process);

        //        //if (objWorksetExCallQc != null)
        //        //{
        //        //    objWfObj.Current_Owner = objWorksetExCallQc.Allocated_To;
        //        //    wfOwnerUpdateList.Add(objWfObj);
        //        //    objWfObjManager.UpdateCurrentOwnerInWfobj(wfOwnerUpdateList, MySession);
        //        //}
        //    }
        //    else
        //    {
        //        IList<WFObjectBilling> WfObjList = objWfObjManager.GetByParentObjectSystemId(wfObj.Obj_System_Id, wfObj.Obj_Type);

        //        IList<WFObjectBilling> WfObjExceptionList = (from h in WfObjList
        //                                                     where h.Obj_Type.ToUpper() == "EXCEPTION" ||
        //                                                         h.Obj_Type.ToUpper() == "CALL" || h.Obj_Type.ToUpper() == "QC_ERROR"
        //                                                     select h).ToList<WFObjectBilling>();

        //        if (WfObjExceptionList == null || WfObjExceptionList.Count != 0)
        //            CloseType = 2;
        //        else
        //            CloseType = 1;

        //        IList<WFObjectBilling> WfObjChargeLineItemList = (from h in WfObjList where h.Obj_Type.ToUpper() == "CHARGE_LINE_ITEM" select h).ToList<WFObjectBilling>();

        //        if (WfObjChargeLineItemList != null)
        //        {
        //            ulong[] ulChargeLineItemId = new ulong[WfObjChargeLineItemList.Count];
        //            string[] sObjType = new string[WfObjChargeLineItemList.Count];
        //            for (int i = 0; i < WfObjChargeLineItemList.Count; i++)
        //            {
        //                ulChargeLineItemId[i] = WfObjChargeLineItemList[i].Obj_System_Id;
        //                sObjType[i] = WfObjChargeLineItemList[i].Obj_Type;
        //            }
        //            string sNextProcess = "";

        //            //srividhya - Need to check whether rendprovid and dos is passed here. now it is hardcoded as 0 and 0
        //            objWfObjManager.MoveToNextProcess(ulChargeLineItemId, sObjType, CloseType, Username, StartTime, MySession,0, 0, MacAddress, "", 0, 0, "N","Y",dtEndTime,ref sNextProcess);
                    
        //        }
        //    }

        //    MySession.Flush();
        //    trans.Commit();

        //    if (EncounterID != 0)
        //    {
        //        //srividhya analyse the third parameter and put the chargeheaderid. now it is passed as 0.
        //        ChargeLineItemManager objChargeManager = new ChargeLineItemManager();
        //        return objChargeManager.LoadChargePosting(EncounterID, WfObjId,0);
        //    }

        //    return null;
        //}

        public IList<ChargeHeader> AddChargeHeaderRecord(ChargeHeader objChargeHeader, string MacAddress)
        {
            IList<ChargeHeader> ChargeHeaderList = new List<ChargeHeader>();
            ChargeHeaderList.Add(objChargeHeader);

            //SaveUpdateDeleteWithTransaction(ref ChargeHeaderList, null, null, MacAddress);

            return GetChargeHeaderValuesUsingEncounterID(objChargeHeader.Encounter_ID);

        }

        public IList<ChargeHeader> GetChargeHeaderValuesUsingEncounterID(ulong encounterId)
        {
            IList<ChargeHeader> ilstChargeHeader = new List<ChargeHeader>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ChargeHeader)).Add(Expression.Eq("Encounter_ID", encounterId));
                ilstChargeHeader= criteria.List<ChargeHeader>();
                iMySession.Close();
            }
            return ilstChargeHeader;
        }

        public ulong AddChargeHeaderRecordWithoutTransaction(ChargeHeader objChargeHeader, ISession MySession, Boolean update, string MacAddress)
        {
            IList<ChargeHeader> ChargeHeaderList = new List<ChargeHeader>();
            ChargeHeaderList.Add(objChargeHeader);
            int iResult = 0;

            ulong ChargeHeaderID = 0;
           // IList<ChargeHeader> ChargeHeaderLists = null;
            if (update == true)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderLists, ChargeHeaderList, null, MySession, MacAddress);
            }
            else
                //iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderList, null, null, MySession, MacAddress);
            if (iResult == 0)
            {
                ChargeHeaderID = ChargeHeaderList[0].Id;
            }
            return ChargeHeaderID;

        }

        int iTryCount = 0;
        //public ChargePostingDTO BatchSaveChargeHeaderLineItem(object[] ObjList, IList<ChargeHeader> ChargeHeaderUpdateList, IList<ChargeLineItem> ChargeLineItemUpdateList
        //    , IList<BillTo> BillToUpdateList, IList<AccountTransaction> AccountTransactionUpdateList, IList<Message> MessageSaveList, string MacAddress)
        //{
        //    ulong EncounterID = Convert.ToUInt64(ObjList[0]);
        //    ulong WfObjectID = Convert.ToUInt64(ObjList[1]);
        //    int iResult = 0;
        //    iTryCount = 0;
        //TryAgain:
        //    Boolean bResult = false;

        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();
        //        if (ChargeHeaderUpdateList != null && ChargeHeaderUpdateList.Count > 0)
        //        {
        //            IList<ChargeHeader> ChargeHeaderList = null;
        //            iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderList, ChargeHeaderUpdateList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (ChargeLineItemUpdateList != null && ChargeLineItemUpdateList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItem = new ChargeLineItemManager();
        //            iResult = objChargeLineItem.UpdateChargeLineItemWithoutTransaction(ChargeLineItemUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (BillToUpdateList != null && BillToUpdateList.Count > 0)
        //        {
        //            Bill_ToManager objBill_To = new Bill_ToManager();
        //            iResult = objBill_To.UpdateobjBill_ToWithoutTransaction(BillToUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        if (AccountTransactionUpdateList != null && AccountTransactionUpdateList.Count > 0)
        //        {
        //            AccountTransactionManager objAccountTransaction = new AccountTransactionManager();
        //            iResult = objAccountTransaction.UpdateAccountWithoutTransaction(AccountTransactionUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        if (MessageSaveList != null && MessageSaveList.Count > 0)
        //        {
        //            MessageManager objMessage = new MessageManager();
        //            iResult = objMessage.SaveMessageWithoutTransaction(MessageSaveList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }
        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }

        //    //srividhya analyse the 3rd parameter and put the value as 0.
        //    ChargeLineItemManager objChargeManager = new ChargeLineItemManager();
        //    return objChargeManager.LoadChargePosting(EncounterID, WfObjectID);
        //}

        //public ChargePostingDTO SaveCodingAndChargePosting(IList<ChargeHeader> ChargeHeaderSaveList, IList<ChargeLineItem> ChargeLineItemSaveList, IList<ChargeHeader> ChargeHeaderUpdateList, IList<ChargeLineItem> ChargeLineItemUpdateList, IList<BillTo> BillToSaveList, IList<BillTo> BillToUpdateList,
        //  IList<AccountTransaction> AccountTransactionSaveList, IList<AccountTransaction> AccountTrasactionUpdateList, object[] ObjList, IList<ulong> DeleteLineItemList, IList<ulong> EncounterIDList, IList<WFObjectBilling> WfObjectBillingSaveList, IList<WFObjectBilling> WFEncounterList, IList<PPLineItem> PPLineItemCopayList, IList<AccountTransaction> AccountTransactionCopayList
        //  , IList<PPLineItem> PPLineItemUpdateCopayList, IList<string> CPTCopay, string MacAddress)
        //{
        //    iTryCount = 0;
        //    ulong EncounterID = Convert.ToUInt64(ObjList[0]);
        //    ulong WfObjectID = Convert.ToUInt64(ObjList[1]);
        //    string UserName = Convert.ToString(ObjList[2]);
        //    DateTime StartTime = Convert.ToDateTime(ObjList[3]);
        //    string ObjType = Convert.ToString(ObjList[4]);

        //    int iResult = 0;
        //TryAgain:
        //    Boolean bResult = false;

        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();
        //        if (ChargeHeaderSaveList != null && ChargeHeaderSaveList.Count > 0)
        //        {
        //            iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //                {
        //                    IList<ChargeHeader> ChargeHeaderList = (from h in ChargeHeaderSaveList where h.Encounter_ID == EncounterIDList[i] select h).ToList<ChargeHeader>();
        //                    if (ChargeHeaderList != null && ChargeHeaderList.Count != 0)
        //                        ChargeLineItemSaveList[i].Charge_Header_ID = ChargeHeaderList[0].Id;
        //                }
        //            }
        //        }

        //        if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItemManager = new ChargeLineItemManager();
        //            iResult = objChargeLineItemManager.SaveUpdateDeleteWithoutTransaction(ref ChargeLineItemSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (BillToSaveList != null && BillToSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //                {
        //                    BillToSaveList[i].Charge_Line_Item_ID = ChargeLineItemSaveList[i].Id;
        //                    AccountTransactionSaveList[i].Charge_Line_Item_ID = ChargeLineItemSaveList[i].Id;
        //                    WfObjectBillingSaveList[i].Obj_System_Id = ChargeLineItemSaveList[i].Id;
        //                }
        //            }

        //            for (int i = 0; i < CPTCopay.Count; i++)
        //            {
        //                IList<ChargeLineItem> ChargeList = (from h in ChargeLineItemSaveList where h.Procedure_Code == CPTCopay[i] select h).ToList<ChargeLineItem>();
        //                if (ChargeList != null && ChargeList.Count != 0)
        //                {
        //                    //added by srividhya on 13-feb-2012.
        //                    //If below count is zero, then no need to add the balnk rows in both the tables(accounttransaction & pplineitem tables)
        //                    if (PPLineItemCopayList.Count > 0 && AccountTransactionCopayList.Count > 0)
        //                    {
        //                        PPLineItemCopayList[i].Charge_Line_Item_ID = ChargeList[0].Id;
        //                        AccountTransactionCopayList[i].Charge_Line_Item_ID = ChargeList[0].Id;
        //                    }
        //                }
        //            }

        //        }
        //        if (ChargeHeaderUpdateList != null && ChargeHeaderUpdateList.Count > 0)
        //        {
        //            IList<ChargeHeader> ChargeHeaderList = null;
        //            iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderList, ChargeHeaderUpdateList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (ChargeLineItemUpdateList != null && ChargeLineItemUpdateList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItem = new ChargeLineItemManager();
        //            iResult = objChargeLineItem.UpdateChargeLineItemWithoutTransaction(ChargeLineItemUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (BillToSaveList != null && BillToSaveList.Count > 0)
        //        {
        //            Bill_ToManager objBill_ToManager = new Bill_ToManager();
        //            iResult = objBill_ToManager.SaveUpdateDeleteWithoutTransaction(ref BillToSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (AccountTransactionSaveList != null && AccountTransactionSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < BillToSaveList.Count; i++)
        //                {
        //                    AccountTransactionSaveList[i].Bill_To_PP_Line_Item_ID = BillToSaveList[i].Id;
        //                    ChargeLineItemSaveList[i].Bill_To_ID = BillToSaveList[i].Id;
        //                }
        //            }
        //        }
        //        if (AccountTransactionSaveList != null && AccountTransactionSaveList.Count > 0)
        //        {
        //            AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
        //            iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionSaveList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < AccountTransactionSaveList.Count; i++)
        //                {
        //                    ChargeLineItemSaveList[i].Account_Transaction_ID = AccountTransactionSaveList[i].Id;
        //                }
        //            }
        //        }
        //        if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //        {
        //            IList<ChargeLineItem> DummyList = null;
        //            ChargeLineItemManager objChargeLineItemManager = new ChargeLineItemManager();
        //            iResult = objChargeLineItemManager.SaveUpdateDeleteWithoutTransaction(ref DummyList, ChargeLineItemSaveList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //    MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        if (WfObjectBillingSaveList != null && WfObjectBillingSaveList.Count > 0)
        //        {
        //            WFObjectBillingManager objWFObjectBillingManager = new WFObjectBillingManager();

        //            for (int i = 0; i < WfObjectBillingSaveList.Count; i++)
        //            {
        //                WfObjectBillingSaveList[i].Id = objWFObjectBillingManager.InsertToWorkFlowObject(WfObjectBillingSaveList[i], MySession, MacAddress);
        //                //commenetd by srividhya on 04-feb-2012 - to not to update the current_process for CHARGE_LINE_ITEM
        //                //It is done by the workflow itself.
        //                WFObjectBilling EncounterList = objWFObjectBillingManager.GetByObjectSystemId(EncounterIDList[i], "BILLING_ENCOUNTER");
        //                WfObjectBillingSaveList[i].Current_Process = EncounterList.Current_Process;
        //                objWFObjectBillingManager.UpdateToWorkFlowObject(WfObjectBillingSaveList[i], MySession, MacAddress);
        //            }
        //        }
        //        if (PPLineItemCopayList != null && PPLineItemCopayList.Count > 0)
        //        {
        //            PPLineItemManager objPPLineItemManager = new PPLineItemManager();
        //            iResult = objPPLineItemManager.SaveUpdateDeleteWithoutTransaction(ref PPLineItemCopayList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //            if (AccountTransactionCopayList != null && AccountTransactionCopayList.Count > 0)
        //            {
        //                for (int i = 0; i < PPLineItemCopayList.Count; i++)
        //                    AccountTransactionCopayList[i].Bill_To_PP_Line_Item_ID = PPLineItemCopayList[i].Id;
        //            }
        //        }
        //        if (AccountTransactionCopayList != null && AccountTransactionCopayList.Count > 0)
        //        {
        //            AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
        //            iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionCopayList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //  MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        if (PPLineItemUpdateCopayList != null && PPLineItemUpdateCopayList.Count > 0)
        //        {
        //            PPLineItemManager objPPLineItemManager = new PPLineItemManager();
        //            IList<PPLineItem> PPDummyList = null;
        //            iResult = objPPLineItemManager.SaveUpdateDeleteWithoutTransaction(ref PPDummyList, PPLineItemUpdateCopayList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        //added by srividhya
        //        if (AccountTrasactionUpdateList != null && AccountTrasactionUpdateList.Count > 0)
        //        {
        //            AccountTransactionManager AccMngr = new AccountTransactionManager();
        //            iResult = AccMngr.UpdateAccountWithoutTransaction(AccountTrasactionUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        IList<ChargeLineItem> ChargeLineItemList = new List<ChargeLineItem>();

        //        if (DeleteLineItemList != null && DeleteLineItemList.Count > 0)
        //        {
        //            ulong[] objSystemId = new ulong[DeleteLineItemList.Count];
        //            string[] objType = new string[DeleteLineItemList.Count];
        //            ChargeLineItem ChargeLineRecord = null;

        //            for (int g = 0; g < DeleteLineItemList.Count; g++)
        //            {
        //                objSystemId[g] = DeleteLineItemList[g];
        //                objType[g] = "CHARGE_LINE_ITEM";

        //                //========added by srividhya on 18-apr-2012=========
        //                ChargeLineItemManager ChargeLineItemMngr = new ChargeLineItemManager();
        //                ChargeLineRecord = new ChargeLineItem();

        //                ChargeLineRecord = ChargeLineItemMngr.GetChargeLineItemUsingChargeLineID(objSystemId[g]);

        //                if (ChargeLineRecord.Id == DeleteLineItemList[g])
        //                {
        //                    ChargeLineRecord.Deleted = "Y";
        //                }
        //                else
        //                {
        //                    ChargeLineRecord.Deleted = "N";
        //                }
        //                ChargeLineItemList.Add(ChargeLineRecord);
        //                //========added by srividhya on 18-apr-2012=========
        //            }
        //            WFObjectBillingManager objWFObjectBillingManager = new WFObjectBillingManager();
        //            bool bProcessResult = objWFObjectBillingManager.MoveToNextProcess(objSystemId, objType, 3, "UNKNOWN", StartTime, MySession, false, 0, 0, MacAddress, "", "", "", "", 0, 0);
        //        }

        //        //========added by srividhya on 18-apr-2012=========
        //        if (ChargeLineItemList != null && ChargeLineItemList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItem = new ChargeLineItemManager();
        //            iResult = objChargeLineItem.UpdateChargeLineItemWithoutTransaction(ChargeLineItemList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        //========added by srividhya on 18-apr-2012=========

        //        if (ObjType.ToUpper() == "WORKSET")
        //        {
        //            for (int i = 0; i < WFEncounterList.Count; i++)
        //            {
        //                WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();
        //                int CloseType;
        //                IList<WFObjectBilling> WfObjList = objWfObjManager.GetByParentObjectSystemId(WFEncounterList[i].Obj_System_Id, WFEncounterList[i].Obj_Type);

        //                IList<WFObjectBilling> WfObjExceptionList = (from h in WfObjList
        //                                                             where h.Obj_Type.ToUpper() == "EXCEPTION" ||
        //                                                                 h.Obj_Type.ToUpper() == "CALL" || h.Obj_Type.ToUpper() == "QC_ERROR"
        //                                                             select h).ToList<WFObjectBilling>();
        //                if (WfObjExceptionList == null || WfObjExceptionList.Count != 0)
        //                    CloseType = 2;
        //                else
        //                    CloseType = 1;

        //                IList<WFObjectBilling> WfObjChargeLineItemList = (from h in WfObjList where h.Obj_Type.ToUpper() == "CHARGE_LINE_ITEM" && h.Current_Process != "DELETED" select h).ToList<WFObjectBilling>();
        //                if (WfObjChargeLineItemList != null)
        //                {
        //                    ulong[] ulChargeLineItemId = new ulong[WfObjChargeLineItemList.Count];
        //                    string[] sObjType = new string[WfObjChargeLineItemList.Count];
        //                    bool bValue = false;

        //                    for (int j = 0; j < WfObjChargeLineItemList.Count; j++)
        //                    {
        //                        ulChargeLineItemId[j] = WfObjChargeLineItemList[j].Obj_System_Id;
        //                        sObjType[j] = WfObjChargeLineItemList[j].Obj_Type;

        //                        ////if the wfobjchargelist.id is present in deletelist, then remove the id from the list.
        //                        //bValue = false;
        //                        //for (int k = 0; k < DeleteLineItemList.Count; k++)
        //                        //{                                    
        //                        //    if (WfObjChargeLineItemList[j].Obj_System_Id == DeleteLineItemList[k])
        //                        //    {
        //                        //        bValue = true;
        //                        //        break;
        //                        //    }
        //                        //    if (bValue == false)
        //                        //    {
        //                        //        ulChargeLineItemId[j] = WfObjChargeLineItemList[j].Obj_System_Id;
        //                        //        sObjType[j] = WfObjChargeLineItemList[j].Obj_Type;
        //                        //    }
        //                        //}                                
        //                    }

        //                    objWfObjManager.MoveToNextProcess(ulChargeLineItemId, sObjType, CloseType, UserName, StartTime, MySession, false, 0, 0, MacAddress, "", "", "", "", 0, 0);
        //                }
        //            }
        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }
        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }

        //    if (EncounterID != 0)
        //    {
        //        ChargeLineItemManager objChargeManager = new ChargeLineItemManager();
        //        return objChargeManager.LoadChargePosting(EncounterID, WfObjectID);
        //    }
        //    return null;
        //}

        //public ChargePostingDTO SaveCodingAndChargePosting(IList<ChargeHeader> ChargeHeaderSaveList, IList<ChargeLineItem> ChargeLineItemSaveList, IList<ChargeHeader> ChargeHeaderUpdateList, IList<ChargeLineItem> ChargeLineItemUpdateList, IList<BillTo> BillToSaveList, IList<BillTo> BillToUpdateList,
        //IList<AccountTransaction> AccountTransactionSaveList, IList<AccountTransaction> AccountTrasactionUpdateList, object[] ObjList, IList<ulong> DeleteLineItemList, IList<ulong> EncounterIDList, IList<WFObjectBilling> WfObjectBillingSaveList, IList<WFObjectBilling> WFEncounterList, IList<PPLineItem> PPLineItemCopayList, IList<AccountTransaction> AccountTransactionCopayList
        //, IList<PPLineItem> PPLineItemUpdateCopayList, IList<string> CPTCopay, string MacAddress, IList<AuthorizationProcedure> AuthorizationProcedureList, IList<Encounter> EncounterSaveList, IList<WFObjectBilling> WFObjBillSaveList, string sParentScreen, string sBatchType, ulong ulAccNo, ulong ulEncID, IList<ulong> ChargeLineItemIDList, string sBillDestination, ulong ulChargeHeaderID,
        //    IList<PatientNotes> PatientNotesSaveList, IList<Authorization> AuthorizationSaveList, IList<Authorization> AuthorizationUpdateList, IList<AuthorizationEncounter> AuthorizationEncSaveList, IList<AuthorizationEncounter> AuthorizationEncUpdateList, IList<AuthorizationEncounter> AuthorizationEncNewSaveList, IList<AuthorizationProcedure> AuthorizationProcedureUpdateList)
        //{
        //    iTryCount = 0;
        //    ulong EncounterID = Convert.ToUInt64(ObjList[0]);
        //    ulong WfObjectID = Convert.ToUInt64(ObjList[1]);
        //    string UserName = Convert.ToString(ObjList[2]);
        //    DateTime StartTime = Convert.ToDateTime(ObjList[3]);
        //    string ObjType = Convert.ToString(ObjList[4]);
        //    //newly added on 19-feb-2014
        //    DateTime EndTime = Convert.ToDateTime(ObjList[5]);
        //    ChargePostingDTO CPDTO = new ChargePostingDTO();

        //    int iResult = 0;
        //TryAgain:
        //    Boolean bResult = false;

        //    ISession MySession = session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();

        //        //======================Added by srividhya==========================
        //        //if (EncounterSaveList != null && EncounterSaveList.Count > 0)
        //        //{
        //        //    EncounterManager EncMngr = new EncounterManager();
        //        //    iResult = EncMngr.SaveUpdateDeleteWithoutTransaction(ref EncounterSaveList, null, null, MySession, MacAddress);
        //        //    if (iResult == 2)
        //        //    {
        //        //        if (iTryCount < 5)
        //        //        {
        //        //            iTryCount++;
        //        //            goto TryAgain;
        //        //        }
        //        //        else
        //        //        {

        //        //            trans.Rollback();
        //        //            //  MySession.Close();
        //        //            throw new Exception("Deadlock is occured. Transaction failed");

        //        //        }
        //        //    }
        //        //    else if (iResult == 1)
        //        //    {

        //        //        trans.Rollback();
        //        //        // MySession.Close();
        //        //        throw new Exception("Exception is occured. Transaction failed");

        //        //    }
        //        //    if (WFObjBillSaveList != null && WFObjBillSaveList.Count > 0)
        //        //    {
        //        //        for (int i = 0; i < EncounterSaveList.Count; i++)
        //        //        {
        //        //            WFObjBillSaveList[i].Obj_System_Id = WFObjBillSaveList[i].Id;
        //        //        }
        //        //    }
        //        //    if (WfObjectBillingSaveList != null && WfObjectBillingSaveList.Count > 0)
        //        //    {
        //        //        for (int i = 0; i < WfObjectBillingSaveList.Count; i++)
        //        //        {
        //        //            WfObjectBillingSaveList[i].Parent_Obj_System_Id = WFObjBillSaveList[0].Obj_System_Id;
        //        //        }
        //        //    }

        //        //    if (ChargeHeaderSaveList != null && ChargeHeaderSaveList.Count > 0)
        //        //    {
        //        //        for (int i = 0; i < ChargeHeaderSaveList.Count; i++)
        //        //        {
        //        //            ChargeHeaderSaveList[i].Encounter_ID = WFObjBillSaveList[0].Obj_System_Id;
        //        //        }
        //        //    }
        //        //}

        //        //if (WFObjBillSaveList != null && WFObjBillSaveList.Count > 0)
        //        //{
        //        //    for (int i = 0; i < WFObjBillSaveList.Count; i++)
        //        //    {
        //        //        WFObjectBillingManager objWfobjMngr = new WFObjectBillingManager();
        //        //        ulong wf_obj_id = objWfobjMngr.InsertToWorkFlowObject(WFObjBillSaveList[i], MySession, MacAddress);
        //        //    }
        //        //}

        //        //================================================
        //        if (ChargeHeaderSaveList != null && ChargeHeaderSaveList.Count > 0)
        //        {
        //            //iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //            {
        //                //for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //                //{
        //                //    //Added by srividhya
        //                //    if (EncounterIDList.Count > 0)
        //                //    {
        //                //        IList<ChargeHeader> ChargeHeaderList = (from h in ChargeHeaderSaveList where h.Encounter_ID == EncounterIDList[i] select h).ToList<ChargeHeader>();
        //                //        if (ChargeHeaderList != null && ChargeHeaderList.Count != 0)
        //                //        {
        //                //            ChargeLineItemSaveList[i].Charge_Header_ID = ChargeHeaderList[0].Id;
        //                //            CPDTO.Charge_Header_ID = ChargeHeaderList[0].Id;
        //                //        }
        //                //    }
        //                //    else
        //                //    {
        //                //        ChargeLineItemSaveList[i].Charge_Header_ID = ChargeHeaderSaveList[0].Id;
        //                //        CPDTO.Charge_Header_ID = ChargeHeaderSaveList[0].Id;
        //                //    }
        //                //}
        //                for (int k = 0; k < ChargeHeaderSaveList.Count; k++)
        //                {
        //                    for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //                    {
        //                        if (ChargeHeaderSaveList[k].Charge_Header_Identifier == ChargeLineItemSaveList[i].Charge_Header_Identifier)
        //                        {
        //                            ChargeLineItemSaveList[i].Charge_Header_ID = ChargeHeaderSaveList[k].Id;
        //                            CPDTO.Charge_Header_ID = ChargeHeaderSaveList[k].Id;
        //                        }
        //                    }
        //                }
        //            }

        //            //if (PatientNotesSaveList != null && PatientNotesSaveList.Count > 0)
        //            //{
        //            //    for (int i = 0; i < PatientNotesSaveList.Count; i++)
        //            //    {
        //            //        //Added by srividhya
        //            //        if (EncounterIDList.Count > 0)
        //            //        {
        //            //            IList<ChargeHeader> ChargeHeaderList = (from h in ChargeHeaderSaveList where h.Encounter_ID == EncounterIDList[i] select h).ToList<ChargeHeader>();
        //            //            if (ChargeHeaderList != null && ChargeHeaderList.Count != 0)
        //            //            {
        //            //                PatientNotesSaveList[i].SourceID =Convert.ToInt32(ChargeHeaderList[0].Id);
        //            //            }
        //            //        }
        //            //        else
        //            //        {
        //            //            PatientNotesSaveList[i].SourceID = Convert.ToInt32(ChargeHeaderSaveList[0].Id);
        //            //        }
        //            //    }
        //            //}
        //        }

        //        if (ChargeHeaderUpdateList != null && ChargeHeaderUpdateList.Count > 0)
        //        {
        //            IList<ChargeHeader> ChargeHeaderList = null;
        //            //iResult = SaveUpdateDeleteWithoutTransaction(ref ChargeHeaderList, ChargeHeaderUpdateList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //            {
        //                for (int k = 0; k < ChargeHeaderUpdateList.Count; k++)
        //                {
        //                    for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //                    {
        //                        if (ChargeHeaderUpdateList[k].Charge_Header_Identifier == ChargeLineItemSaveList[i].Charge_Header_Identifier)
        //                        {
        //                            ChargeLineItemSaveList[i].Charge_Header_ID = ChargeHeaderUpdateList[k].Id;
        //                            //CPDTO.Charge_Header_ID = ChargeHeaderUpdateList[k].Id;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (ChargeLineItemUpdateList != null && ChargeLineItemUpdateList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItem = new ChargeLineItemManager();
        //            iResult = objChargeLineItem.UpdateChargeLineItemWithoutTransaction(ChargeLineItemUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //            //newly added on 6-Aug-2014
        //            for (int i = 0; i < ChargeLineItemUpdateList.Count; i++)
        //            {
        //                CPDTO.ChargeLineItemList.Add(ChargeLineItemUpdateList[i]);
        //            }
        //        }

        //        if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItemManager = new ChargeLineItemManager();
        //            //iResult = objChargeLineItemManager.SaveUpdateDeleteWithoutTransaction(ref ChargeLineItemSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (BillToSaveList != null && BillToSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //                {
        //                    BillToSaveList[i].Charge_Line_Item_ID = ChargeLineItemSaveList[i].Id;
        //                    AccountTransactionSaveList[i].Charge_Line_Item_ID = ChargeLineItemSaveList[i].Id;
        //                    WfObjectBillingSaveList[i].Obj_System_Id = ChargeLineItemSaveList[i].Id;
        //                    CPDTO.Charge_Line_Item_ID.Add(ChargeLineItemSaveList[i].Id);
        //                }
        //            }

        //            //if (PatientNotesSaveList != null && PatientNotesSaveList.Count > 0)
        //            //{
        //            //    for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //            //    {
        //            //        PatientNotesSaveList[i].Line_ID =Convert.ToUInt64(ChargeLineItemSaveList[0].Id);                          
        //            //    }
        //            //}

        //            for (int i = 0; i < CPTCopay.Count; i++)
        //            {
        //                IList<ChargeLineItem> ChargeList = (from h in ChargeLineItemSaveList where h.Procedure_Code == CPTCopay[i] select h).ToList<ChargeLineItem>();
        //                if (ChargeList != null && ChargeList.Count != 0)
        //                {
        //                    //added by srividhya on 13-feb-2012.
        //                    //If below count is zero, then no need to add the balnk rows in both the tables(accounttransaction & pplineitem tables)
        //                    if (PPLineItemCopayList.Count > 0 && AccountTransactionCopayList.Count > 0)
        //                    {
        //                        PPLineItemCopayList[i].Charge_Line_Item_ID = ChargeList[0].Id;
        //                        AccountTransactionCopayList[i].Charge_Line_Item_ID = ChargeList[0].Id;
        //                    }
        //                }
        //            }

        //            //newly added on 6-Aug-2014
        //            for (int i = 0; i < ChargeLineItemSaveList.Count; i++)
        //            {
        //                CPDTO.ChargeLineItemList.Add(ChargeLineItemSaveList[i]);
        //            }
        //        }

        //        if (BillToSaveList != null && BillToSaveList.Count > 0)
        //        {
        //            Bill_ToManager objBill_ToManager = new Bill_ToManager();
        //            //iResult = objBill_ToManager.SaveUpdateDeleteWithoutTransaction(ref BillToSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (AccountTransactionSaveList != null && AccountTransactionSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < BillToSaveList.Count; i++)
        //                {
        //                    AccountTransactionSaveList[i].Bill_To_PP_Line_Item_ID = BillToSaveList[i].Id;
        //                    ChargeLineItemSaveList[i].Bill_To_ID = BillToSaveList[i].Id;
        //                }
        //            }
        //        }
        //        if (AccountTransactionSaveList != null && AccountTransactionSaveList.Count > 0)
        //        {
        //            AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
        //            iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionSaveList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < AccountTransactionSaveList.Count; i++)
        //                {
        //                    ChargeLineItemSaveList[i].Account_Transaction_ID = AccountTransactionSaveList[i].Id;
        //                }
        //            }
        //        }

        //        //newly added on 9-Aug-2014                
        //        IList<ChargeLineItem> ChargeLineItemSortedList = new List<ChargeLineItem>();
        //        IEnumerable<ChargeLineItem> sortedEnum = CPDTO.ChargeLineItemList.OrderBy(f => f.Charge_Header_Identifier);
        //        ChargeLineItemSortedList = sortedEnum.ToList();
        //        CPDTO.ChargeLineItemList = new List<ChargeLineItem>();
        //        ChargeLineItemUpdateList = new List<ChargeLineItem>();

        //        for (int i = 0; i < ChargeLineItemSortedList.Count; i++)
        //        {
        //            ChargeLineItemSortedList[i].Sort_Order = i + 1;
        //            ChargeLineItemUpdateList.Add(ChargeLineItemSortedList[i]);

        //            CPDTO.ChargeLineItemList.Add(ChargeLineItemSortedList[i]);
        //        }

        //        if (ChargeLineItemSaveList != null && ChargeLineItemSaveList.Count > 0)
        //        {
        //            IList<ChargeLineItem> DummyList = null;
        //            ChargeLineItemManager objChargeLineItemManager = new ChargeLineItemManager();
        //            //iResult = objChargeLineItemManager.SaveUpdateDeleteWithoutTransaction(ref DummyList, ChargeLineItemSaveList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //    MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        //newly added
        //        if (ChargeLineItemUpdateList != null && ChargeLineItemUpdateList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItem = new ChargeLineItemManager();
        //            iResult = objChargeLineItem.UpdateChargeLineItemWithoutTransaction(ChargeLineItemUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (WfObjectBillingSaveList != null && WfObjectBillingSaveList.Count > 0)
        //        {
        //            WFObjectBillingManager objWFObjectBillingManager = new WFObjectBillingManager();

        //            for (int i = 0; i < WfObjectBillingSaveList.Count; i++)
        //            {
        //                WfObjectBillingSaveList[i].Id = objWFObjectBillingManager.InsertToWorkFlowObject(WfObjectBillingSaveList[i], MySession, MacAddress, StartTime, EndTime,1);
        //                //commenetd by srividhya on 04-May-2012 - to not to update the current_process for CHARGE_LINE_ITEM
        //                //It is done by the workflow itself.
        //                //if (EncounterIDList.Count > 0)
        //                //{                            
        //                //    WFObjectBilling EncounterList = objWFObjectBillingManager.GetByObjectSystemId(EncounterIDList[i], "BILLING_ENCOUNTER");
        //                //    WfObjectBillingSaveList[i].Current_Process = EncounterList.Current_Process;
        //                //}

        //                WfObjectBillingSaveList[i].Current_Process = WFObjBillSaveList[0].Current_Process;

        //                objWFObjectBillingManager.UpdateToWorkFlowObject(WfObjectBillingSaveList[i], MySession, MacAddress);
        //            }
        //        }
        //        if (PPLineItemCopayList != null && PPLineItemCopayList.Count > 0)
        //        {
        //            PPLineItemManager objPPLineItemManager = new PPLineItemManager();
        //            //iResult = objPPLineItemManager.SaveUpdateDeleteWithoutTransaction(ref PPLineItemCopayList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //            if (AccountTransactionCopayList != null && AccountTransactionCopayList.Count > 0)
        //            {
        //                for (int i = 0; i < PPLineItemCopayList.Count; i++)
        //                    AccountTransactionCopayList[i].Bill_To_PP_Line_Item_ID = PPLineItemCopayList[i].Id;
        //            }
        //        }
        //        if (AccountTransactionCopayList != null && AccountTransactionCopayList.Count > 0)
        //        {
        //            AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
        //            iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionCopayList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //  MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        if (PPLineItemUpdateCopayList != null && PPLineItemUpdateCopayList.Count > 0)
        //        {
        //            PPLineItemManager objPPLineItemManager = new PPLineItemManager();
        //            IList<PPLineItem> PPDummyList = null;
        //            //iResult = objPPLineItemManager.SaveUpdateDeleteWithoutTransaction(ref PPDummyList, PPLineItemUpdateCopayList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }
        //        //added by srividhya
        //        if (AccountTrasactionUpdateList != null && AccountTrasactionUpdateList.Count > 0)
        //        {
        //            AccountTransactionManager AccMngr = new AccountTransactionManager();
        //            iResult = AccMngr.UpdateAccountWithoutTransaction(AccountTrasactionUpdateList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        IList<ChargeLineItem> ChargeLineItemList = new List<ChargeLineItem>();

        //        if (DeleteLineItemList != null && DeleteLineItemList.Count > 0)
        //        {
        //            ulong[] objSystemId = new ulong[DeleteLineItemList.Count];
        //            string[] objType = new string[DeleteLineItemList.Count];
        //            ChargeLineItem ChargeLineRecord = null;

        //            for (int g = 0; g < DeleteLineItemList.Count; g++)
        //            {
        //                objSystemId[g] = DeleteLineItemList[g];
        //                objType[g] = "CHARGE_LINE_ITEM";

        //                //========added by srividhya on 18-apr-2012=========
        //                ChargeLineItemManager ChargeLineItemMngr = new ChargeLineItemManager();
        //                ChargeLineRecord = new ChargeLineItem();

        //                ChargeLineRecord = ChargeLineItemMngr.GetChargeLineItemUsingChargeLineID(objSystemId[g]);

        //                if (ChargeLineRecord.Id == DeleteLineItemList[g])
        //                {
        //                    ChargeLineRecord.Deleted = "Y";
        //                }
        //                else
        //                {
        //                    ChargeLineRecord.Deleted = "N";
        //                }
        //                ChargeLineItemList.Add(ChargeLineRecord);
        //                //========added by srividhya on 18-apr-2012=========
        //            }
        //            WFObjectBillingManager objWFObjectBillingManager = new WFObjectBillingManager();
        //            string sNextProcess = "";

        //            //bool bProcessResult = objWFObjectBillingManager.MoveToNextProcess(objSystemId, objType, 3, "UNKNOWN", StartTime, MySession, false, 0, 0, MacAddress, "", 0, 0, sParentScreen, sBatchType, ulAccNo, ulEncID, ChargeLineItemIDList, sBillDestination, ulChargeHeaderID);
        //            sNextProcess = objWFObjectBillingManager.MoveToNextProcessChargeLineItem(objSystemId, objType, 4, "UNKNOWN", StartTime, MySession,MacAddress,ref sNextProcess, EndTime);
        //        }

        //        //========added by srividhya on 18-apr-2012=========
        //        if (ChargeLineItemList != null && ChargeLineItemList.Count > 0)
        //        {
        //            ChargeLineItemManager objChargeLineItem = new ChargeLineItemManager();
        //            iResult = objChargeLineItem.UpdateChargeLineItemWithoutTransaction(ChargeLineItemList, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //   MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (PatientNotesSaveList != null && PatientNotesSaveList.Count > 0)
        //        {
        //            PatientNotesManager PatientNotMngr = new PatientNotesManager();
        //            //iResult = PatientNotMngr.SaveUpdateDeleteWithoutTransaction(ref PatientNotesSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (AuthorizationSaveList != null && AuthorizationSaveList.Count > 0)
        //        {
        //            AuthorizationManager AuthMngr = new AuthorizationManager();

        //            //iResult = AuthMngr.SaveUpdateDeleteWithoutTransaction(ref AuthorizationSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }

        //            if (AuthorizationEncSaveList != null && AuthorizationEncSaveList.Count > 0)
        //            {
        //                for (int i = 0; i < AuthorizationEncSaveList.Count; i++)
        //                {
        //                    AuthorizationEncSaveList[i].Authorization_ID = AuthorizationSaveList[0].Id;
        //                }
        //            }
        //        }

        //        if (AuthorizationEncSaveList != null && AuthorizationEncSaveList.Count > 0)
        //        {
        //            AuthorizationEncounterManager AuthEncMngr = new AuthorizationEncounterManager();
        //            IList<AuthorizationEncounter> AuthEncList = null;
        //            //iResult = AuthEncMngr.SaveUpdateDeleteWithoutTransaction(ref AuthorizationEncSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (AuthorizationEncNewSaveList != null && AuthorizationEncNewSaveList.Count > 0)
        //        {
        //            AuthorizationEncounterManager AuthEncMngr = new AuthorizationEncounterManager();
        //            IList<AuthorizationEncounter> AuthEncList = null;
        //            //iResult = AuthEncMngr.SaveUpdateDeleteWithoutTransaction(ref AuthorizationEncNewSaveList, null, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (AuthorizationUpdateList != null && AuthorizationUpdateList.Count > 0)
        //        {
        //            AuthorizationManager AuthMngr = new AuthorizationManager();

        //            IList<Authorization> AuthList = null;
        //            //iResult = AuthMngr.SaveUpdateDeleteWithoutTransaction(ref AuthList, AuthorizationUpdateList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (AuthorizationEncUpdateList != null && AuthorizationEncUpdateList.Count > 0)
        //        {
        //            AuthorizationEncounterManager AuthEncMngr = new AuthorizationEncounterManager();
        //            IList<AuthorizationEncounter> AuthEncList = null;
        //            //iResult = AuthEncMngr.SaveUpdateDeleteWithoutTransaction(ref AuthEncList, AuthorizationEncUpdateList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        if (AuthorizationProcedureUpdateList != null && AuthorizationProcedureUpdateList.Count > 0)
        //        {
        //            AuthorizationProcedureManager AuthProcMngr = new AuthorizationProcedureManager();

        //            IList<AuthorizationProcedure> AuthProcList = null;
        //            //iResult = AuthProcMngr.SaveUpdateDeleteWithoutTransaction(ref AuthProcList, AuthorizationProcedureUpdateList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        //if (AuthorizationList != null && AuthorizationList.Count > 0)
        //        //{
        //        //    AuthorizationManager AuthMngr = new AuthorizationManager();
        //        //    IList<Authorization> AuthList = null;
        //        //    iResult =AuthMngr.SaveUpdateDeleteWithoutTransaction(ref AuthList, AuthorizationList, null, MySession, MacAddress);
        //        //    if (iResult == 2)
        //        //    {
        //        //        if (iTryCount < 5)
        //        //        {
        //        //            iTryCount++;
        //        //            goto TryAgain;
        //        //        }
        //        //        else
        //        //        {
        //        //            trans.Rollback();
        //        //            //  MySession.Close();
        //        //            throw new Exception("Deadlock is occured. Transaction failed");
        //        //        }
        //        //    }
        //        //    else if (iResult == 1)
        //        //    {
        //        //        trans.Rollback();
        //        //        // MySession.Close();
        //        //        throw new Exception("Exception is occured. Transaction failed");
        //        //    }
        //        //}

        //        if (AuthorizationProcedureList != null && AuthorizationProcedureList.Count > 0)
        //        {
        //            AuthorizationProcedureManager AuthProcMngr = new AuthorizationProcedureManager();
        //            IList<AuthorizationProcedure> AuthProcList = null;
        //            //iResult = AuthProcMngr.SaveUpdateDeleteWithoutTransaction(ref AuthProcList, AuthorizationProcedureList, null, MySession, MacAddress);
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //        }

        //        //========added by srividhya on 18-apr-2012=========

        //        //if (ObjType.ToUpper() == "WORKSET")
        //        //{
        //        //    for (int i = 0; i < WFEncounterList.Count; i++)
        //        //    {
        //        //        WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();
        //        //        int CloseType;
        //        //        IList<WFObjectBilling> WfObjList = objWfObjManager.GetByParentObjectSystemId(WFEncounterList[i].Obj_System_Id, WFEncounterList[i].Obj_Type);

        //        //        IList<WFObjectBilling> WfObjExceptionList = (from h in WfObjList
        //        //                                                     where h.Obj_Type.ToUpper() == "EXCEPTION" ||
        //        //                                                         h.Obj_Type.ToUpper() == "CALL" || h.Obj_Type.ToUpper() == "QC_ERROR"
        //        //                                                     select h).ToList<WFObjectBilling>();
        //        //        if (WfObjExceptionList == null || WfObjExceptionList.Count != 0)
        //        //            CloseType = 2;
        //        //        else
        //        //            CloseType = 1;

        //        //        IList<WFObjectBilling> WfObjChargeLineItemList = (from h in WfObjList where h.Obj_Type.ToUpper() == "CHARGE_LINE_ITEM" && h.Current_Process != "DELETED" select h).ToList<WFObjectBilling>();
        //        //        if (WfObjChargeLineItemList != null)
        //        //        {
        //        //            ulong[] ulChargeLineItemId = new ulong[WfObjChargeLineItemList.Count];
        //        //            string[] sObjType = new string[WfObjChargeLineItemList.Count];
        //        //            bool bValue = false;

        //        //            for (int j = 0; j < WfObjChargeLineItemList.Count; j++)
        //        //            {
        //        //                ulChargeLineItemId[j] = WfObjChargeLineItemList[j].Obj_System_Id;
        //        //                sObjType[j] = WfObjChargeLineItemList[j].Obj_Type;

        //        //                ////if the wfobjchargelist.id is present in deletelist, then remove the id from the list.
        //        //                //bValue = false;
        //        //                //for (int k = 0; k < DeleteLineItemList.Count; k++)
        //        //                //{                                    
        //        //                //    if (WfObjChargeLineItemList[j].Obj_System_Id == DeleteLineItemList[k])
        //        //                //    {
        //        //                //        bValue = true;
        //        //                //        break;
        //        //                //    }
        //        //                //    if (bValue == false)
        //        //                //    {
        //        //                //        ulChargeLineItemId[j] = WfObjChargeLineItemList[j].Obj_System_Id;
        //        //                //        sObjType[j] = WfObjChargeLineItemList[j].Obj_Type;
        //        //                //    }
        //        //                //}                                
        //        //            }

        //        //            objWfObjManager.MoveToNextProcess(ulChargeLineItemId, sObjType, CloseType, UserName, StartTime, MySession, false, 0, 0, MacAddress, "", "", "", "", 0, 0);
        //        //        }
        //        //    }
        //        //}

        //        MySession.Flush();
        //        trans.Commit();
        //    }
        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }

        //    //if (EncounterID != 0)
        //    //{
        //    //    ChargeLineItemManager objChargeManager = new ChargeLineItemManager();
        //    //    return objChargeManager.LoadChargePosting(EncounterID, WfObjectID);
        //    //}
        //    return CPDTO;
        //}

        //public ulong CPBatchMoveToNextProcess(ulong ulWFObjectID, IList<ulong> ChargeLineItemIDList, string MacAddress, ulong ulIntRefID, string sDOOS, string sBatchName, string sObjectType, string sUserName, string sBillDestination, ulong ulAccNo, string sDOS, IList<ObjectProcessHistoryBillingTemp> ObjectProcessHistoryBillingTempList, DateTime dtStartTime, DateTime dtEndTime, ulong ulBatchID, IList<ObjectProcessHistoryBillingTemp> ObjectProcessHistoryBillingTempUpdateList, IList<ObjectProcessHistoryBilling> ObjectProcessHistoryBillingUpdateList, string sCurrProcess)
        //{
        //    iTryCount = 0;
        //    //ulong ulEncounterID =0;// Convert.ToUInt64(ObjList[0]);          
        //    //string ObjType = Convert.ToString(ObjList[0]);
        //    //string UserName = Convert.ToString(ObjList[1]);
        //    //DateTime StartTime = Convert.ToDateTime(ObjList[2]);
        //    //ulong ulWFObjectID=Convert.ToUInt32(ObjList[4]);
            
        //    //WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();                    

        //    ISession MySession = session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();
                               
        //        //============Newly added
        //        WorkFlowManager WFMngr = new WorkFlowManager();
        //        BatchHumanMapManager BatchHumanMapMngr = new BatchHumanMapManager();
        //        IList<BatchHumanMap> BatchHumanMapList = new List<BatchHumanMap>();                
        //        WFObject WFObjectRecord = new WFObject();
        //        WFObjectManager WFObjManager = new WFObjectManager();
        //        ulong ulWFID=0;

        //        if (sObjectType=="WORKSET")
        //        {
        //            int iExceptionCount = 0;
        //            int iCallCount = 0;
        //            int iQCCount = 0;

        //            ICriteria crit = session.GetISession().CreateCriteria(typeof(AddException)).Add(Expression.Eq("Parent_Object_ID", ulWFObjectID)).Add(Expression.Eq("Internal_Reference_ID", ulIntRefID)).Add(Expression.Eq("Account_Number", ulAccNo)).Add(Expression.Eq("DOS", sDOS)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName)).Add(Expression.Eq("Exc_Sub_Category", "EXCEPTION"));
        //            iExceptionCount = crit.List<AddException>().Count;
                  
        //            if (iExceptionCount == 0)
        //            {
        //                ICriteria crit1 = session.GetISession().CreateCriteria(typeof(CallLog)).Add(Expression.Eq("Parent_Object_ID", ulWFObjectID)).Add(Expression.Eq("Internal_Reference_ID", ulIntRefID)).Add(Expression.Eq("Account_Number", ulAccNo)).Add(Expression.Eq("DOS", sDOS)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName));
        //                iCallCount = crit1.List<CallLog>().Count;

        //                if (iCallCount == 0)
        //                {
        //                    ICriteria crit2 = session.GetISession().CreateCriteria(typeof(Qc_Err)).Add(Expression.Eq("Parent_Object_ID", ulWFObjectID)).Add(Expression.Eq("Internal_Reference_ID", ulIntRefID)).Add(Expression.Eq("Account_Number", ulAccNo)).Add(Expression.Eq("DOS", sDOS)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName));
        //                    iQCCount = crit2.List<Qc_Err>().Count;
        //                }
        //            }

        //            int CloseType;
        //            if (iExceptionCount != 0 || iCallCount != 0 || iQCCount != 0)
        //            {
        //                CloseType = 2;
        //            }
        //            else
        //            {
        //                CloseType = 1;
        //            }

        //            //if (CloseType != 2) //If there is no Exc/Call/QCError, then move hte chargelineitem to either BILL_TO_PRIMARY or TRANSFER_TO_PATIENT
        //            //{
        //            //    if (sBillDestination == "PRIMARY_INSURANCE")    //If Insurance send Chargelineitem to BILL_TO_PRIMARY
        //            //        CloseType = 1;
        //            //    else if (sBillDestination == "PATIENT") //If Patient send Chargelineitem to TRANSFER_TO_PATIENT
        //            //        CloseType = 3;
        //            //}

        //            //int iReturn=0;

        //            //ICriteria criteria = session.GetISession().CreateCriteria(typeof(BatchHumanMap)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName)).Add(Expression.Eq("Encounter_ID", ulEncounterID));
        //            //BatchHumanMapList = criteria.List<BatchHumanMap>();

        //            //for (int i = 0; i < BatchHumanMapList.Count; i++)
        //            //{
        //            //    WFObjectRecord = new WFObject();
        //            //    WFObjectRecord = WFObjManager.GetByObjectSystemId(BatchHumanMapList[i].Encounter_ID, BatchHumanMapList[i].Object_Type);

        //            //    if (WFObjectRecord != null && WFObjectRecord.Obj_Type != "")
        //            //    {
        //            //        iReturn = WFObjManager.MoveToNextProcess(WFObjectRecord.Obj_System_Id, WFObjectRecord.Obj_Type, CloseType, "UNKNOWN",dtStartTime, "", null, MySession);
        //            //    }                   
        //            //}

        //            //if (iReturn == 0)
        //            //{
        //                //if (ChargeLineItemIDList != null)
        //                //{
        //                //    if (CloseType != 2) //If there is no Exc/Call/QCError, then move hte chargelineitem to either BILL_TO_PRIMARY or TRANSFER_TO_PATIENT
        //                //    {
        //                //        if (sBillDestination == "PRIMARY_INSURANCE")    //If Insurance send Chargelineitem to BILL_TO_PRIMARY
        //                //            CloseType = 1;
        //                //        else if (sBillDestination == "PATIENT") //If Patient send Chargelineitem to TRANSFER_TO_PATIENT
        //                //            CloseType = 3;
        //                //    }

        //                //    ulong[] ulChargeLineItemId = new ulong[ChargeLineItemIDList.Count];
        //                //    string[] sObjType = new string[ChargeLineItemIDList.Count];

        //                //    for (int j = 0; j < ChargeLineItemIDList.Count; j++)
        //                //    {
        //                //        ulChargeLineItemId[j] = ChargeLineItemIDList[j];// ChargeLineItemIDList[j].Obj_System_Id;
        //                //        sObjType[j] = "CHARGE_LINE_ITEM";// ChargeLineItemIDList[j].Obj_Type;
        //                //    }
        //                //    string sNextProcess = "";

        //                //    WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();
        //                //    objWfObjManager.MoveToNextProcessChargeLineItem(ulChargeLineItemId, sObjType, CloseType, sUserName, dtStartTime, MySession, 0, 0, MacAddress, "", 0, 0, ref sNextProcess,dtEndTime);
        //                //}
        //                if (ChargeLineItemIDList != null)
        //                {
        //                    if (CloseType != 2) //If there is no Exc/Call/QCError, then move hte chargelineitem to either BILL_TO_PRIMARY or TRANSFER_TO_PATIENT
        //                    {
        //                        if (sBillDestination == "PRIMARY_INSURANCE")    //If Insurance send Chargelineitem to BILL_TO_PRIMARY
        //                            CloseType = 1;
        //                        else if (sBillDestination == "PATIENT") //If Patient send Chargelineitem to TRANSFER_TO_PATIENT
        //                            CloseType = 3;
        //                    }

        //                    //Newly added
        //                    ISQLQuery sql = session.GetISession().CreateSQLQuery("select {c.*},{l.*},{w.*} from charge_header c,charge_line_item l,wf_object_billing w where c.charge_header_id=l.charge_header_id and w.obj_system_id=l.charge_line_item_id and w.obj_type='CHARGE_LINE_ITEM' and w.current_process='" + sCurrProcess + "' and c.batch_id='" + ulBatchID + "' and c.internal_reference_id='" + ulIntRefID + "' and c.human_id='" + ulAccNo + "' and l.from_dos='" + sDOS + "' and l.Deleted='N'").AddEntity("c", typeof(ChargeHeader)).AddEntity("l", typeof(ChargeLineItem)).AddEntity("w", typeof(WFObjectBilling));

        //                    ChargeLineItem ChargeLineItemRecord = new ChargeLineItem();
        //                    IList<ulong> ChargeLineItemIDRealList = new List<ulong>();

        //                    if (sql.List().Count > 0)
        //                    {
        //                        //commented by srividhya
        //                        foreach (IList<Object> l in sql.List())
        //                        {
        //                            ChargeLineItemRecord = (ChargeLineItem)l[1];
        //                            ChargeLineItemIDRealList.Add(ChargeLineItemRecord.Id);
        //                        }

        //                        ulong[] ulChargeLineItemId = new ulong[ChargeLineItemIDRealList.Count];
        //                        string[] sObjType = new string[ChargeLineItemIDRealList.Count];

        //                        for (int j = 0; j < ChargeLineItemIDRealList.Count; j++)
        //                        {
        //                            ulChargeLineItemId[j] = ChargeLineItemIDRealList[j];// ChargeLineItemIDList[j].Obj_System_Id;
        //                            sObjType[j] = "CHARGE_LINE_ITEM";// ChargeLineItemIDList[j].Obj_Type;
        //                        }
        //                        string sNextProcess = "";

        //                        WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();
        //                        objWfObjManager.MoveToNextProcessChargeLineItem(ulChargeLineItemId, sObjType, CloseType, sUserName, dtStartTime, MySession,MacAddress,ref sNextProcess, dtEndTime);
        //                    }
        //                }
        //                ulWFID = ulWFObjectID;
        //            //}
        //        }

        //        if (ObjectProcessHistoryBillingTempList.Count > 0)
        //        {
        //            int iResult = 0;
        //            if (ObjectProcessHistoryBillingTempList != null && ObjectProcessHistoryBillingTempList.Count > 0)
        //            {
        //                ObjectProcessHistoryBillingTempManager ObjProcHisBillTempMngr = new ObjectProcessHistoryBillingTempManager();
        //                //iResult = ObjProcHisBillTempMngr.SaveUpdateDeleteWithoutTransaction(ref ObjectProcessHistoryBillingTempList, null, null, MySession, "");
        //                if (iResult == 2)
        //                {
        //                    if (iTryCount < 5)
        //                    {
        //                        iTryCount++;
        //                        //goto TryAgain;
        //                    }
        //                    else
        //                    {
        //                        trans.Rollback();
        //                        //  MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");
        //                }
        //            }
        //        }

        //        if (ObjectProcessHistoryBillingTempUpdateList.Count > 0)
        //        {
        //            int iResult = 0;
        //            if (ObjectProcessHistoryBillingTempUpdateList != null && ObjectProcessHistoryBillingTempUpdateList.Count > 0)
        //            {
        //                ObjectProcessHistoryBillingTempManager ObjProcHisBillTempMngr = new ObjectProcessHistoryBillingTempManager();
        //                IList<ObjectProcessHistoryBillingTemp> ObjProcHistBillTempDummyList = new List<ObjectProcessHistoryBillingTemp>();
        //                //iResult = ObjProcHisBillTempMngr.SaveUpdateDeleteWithoutTransaction(ref ObjProcHistBillTempDummyList, ObjectProcessHistoryBillingTempUpdateList, null, MySession, "");
        //                if (iResult == 2)
        //                {
        //                    if (iTryCount < 5)
        //                    {
        //                        iTryCount++;
        //                        //goto TryAgain;
        //                    }
        //                    else
        //                    {
        //                        trans.Rollback();
        //                        //  MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");
        //                }
        //            }
        //        }

        //        if (ObjectProcessHistoryBillingUpdateList.Count > 0)
        //        {
        //            int iResult = 0;
        //            if (ObjectProcessHistoryBillingUpdateList != null && ObjectProcessHistoryBillingUpdateList.Count > 0)
        //            {
        //                ObjectProcessHistoryBillingManager ObjProcHisBillMngr = new ObjectProcessHistoryBillingManager();
        //                IList<ObjectProcessHistoryBilling> ObjProcHistBillDummyList = new List<ObjectProcessHistoryBilling>();
        //                //iResult = ObjProcHisBillMngr.SaveUpdateDeleteWithoutTransaction(ref ObjProcHistBillDummyList, ObjectProcessHistoryBillingUpdateList, null, MySession, "");
        //                if (iResult == 2)
        //                {
        //                    if (iTryCount < 5)
        //                    {
        //                        iTryCount++;
        //                        //goto TryAgain;
        //                    }
        //                    else
        //                    {
        //                        trans.Rollback();
        //                        //  MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");
        //                }
        //            }
        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }

        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }

        //    return ulWFObjectID;
        //}

        //public ulong CPManualBatchMoveToNextProcess(ulong ulWFObjectID, IList<ulong> ChargeLineItemIDList, string MacAddress, string sDOS, string sDOOS, string sBatchName, string sObjectType, string sUserName, string sBillDestination, ulong ulAccNo, IList<ObjectProcessHistoryBillingTemp> ObjectProcessHistoryBillingTempList, ulong ulRendProvID, ulong ulBatchID, DateTime dtStartTime, DateTime dtEndTime)
        //{
        //    iTryCount = 0;
        //    //ulong ulEncounterID =0;// Convert.ToUInt64(ObjList[0]);          
        //    //string ObjType = Convert.ToString(ObjList[0]);
        //    //string UserName = Convert.ToString(ObjList[1]);
        //    //DateTime StartTime = Convert.ToDateTime(ObjList[2]);
        //    //ulong ulWFObjectID=Convert.ToUInt32(ObjList[4]);

        //    WFObjectBillingManager objWfObjManager = new WFObjectBillingManager();

        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();

        //        //============Newly added
        //        WorkFlowManager WFMngr = new WorkFlowManager();
        //        BatchHumanMapManager BatchHumanMapMngr = new BatchHumanMapManager();
        //        IList<BatchHumanMap> BatchHumanMapList = new List<BatchHumanMap>();
        //        WFObject WFObjectRecord = new WFObject();
        //        WFObjectManager WFObjManager = new WFObjectManager();
        //        ulong ulWFID = 0;

        //        if (sObjectType == "WORKSET")
        //        {
        //            int iExceptionCount = 0;
        //            int iCallCount = 0;
        //            int iQCCount = 0;

        //            ICriteria crit = session.GetISession().CreateCriteria(typeof(AddException)).Add(Expression.Eq("Parent_Object_ID", ulWFObjectID)).Add(Expression.Eq("Account_Number", ulAccNo)).Add(Expression.Eq("Sub_Batch_Range", ulRendProvID.ToString())).Add(Expression.Eq("DOS", sDOS)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName)).Add(Expression.Eq("Exc_Sub_Category", "EXCEPTION"));
        //            iExceptionCount = crit.List<AddException>().Count;

        //            if (iExceptionCount == 0)
        //            {
        //                ICriteria crit1 = session.GetISession().CreateCriteria(typeof(CallLog)).Add(Expression.Eq("Parent_Object_ID", ulWFObjectID)).Add(Expression.Eq("Account_Number", ulAccNo)).Add(Expression.Eq("Sub_Batch_Range", ulRendProvID.ToString())).Add(Expression.Eq("DOS", sDOS)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName));
        //                iCallCount = crit1.List<CallLog>().Count;

        //                if (iCallCount == 0)
        //                {
        //                    ICriteria crit2 = session.GetISession().CreateCriteria(typeof(Qc_Err)).Add(Expression.Eq("Parent_Object_ID", ulWFObjectID)).Add(Expression.Eq("Account_Number", ulAccNo)).Add(Expression.Eq("Sub_Batch_Range", ulRendProvID.ToString())).Add(Expression.Eq("DOS", sDOS)).Add(Expression.Eq("DOOS", sDOOS)).Add(Expression.Eq("Batch_Name", sBatchName));
        //                    iQCCount = crit2.List<Qc_Err>().Count;
        //                }
        //            }

        //            int CloseType;
        //            if (iExceptionCount != 0 || iCallCount != 0 || iQCCount != 0)
        //            {
        //                CloseType = 2;
        //            }
        //            else
        //            {
        //                CloseType = 1;
        //            }

        //            if (CloseType != 2) //If there is no Exc/Call/QCError, then move hte chargelineitem to either BILL_TO_PRIMARY or TRANSFER_TO_PATIENT
        //            {
        //                if (sBillDestination == "PRIMARY_INSURANCE")    //If Insurance send Chargelineitem to BILL_TO_PRIMARY
        //                    CloseType = 1;
        //                else if (sBillDestination == "PATIENT") //If Patient send Chargelineitem to TRANSFER_TO_PATIENT
        //                    CloseType = 3;
        //            }
                   
        //            if (ChargeLineItemIDList != null)
        //            {
        //                if (CloseType != 2) //If there is no Exc/Call/QCError, then move hte chargelineitem to either BILL_TO_PRIMARY or TRANSFER_TO_PATIENT
        //                {
        //                    if (sBillDestination == "PRIMARY_INSURANCE")    //If Insurance send Chargelineitem to BILL_TO_PRIMARY
        //                        CloseType = 1;
        //                    else if (sBillDestination == "PATIENT") //If Patient send Chargelineitem to TRANSFER_TO_PATIENT
        //                        CloseType = 3;
        //                }

        //                //Newly added
        //                ISQLQuery sql = session.GetISession().CreateSQLQuery("select {c.*},{l.*} from charge_header c,charge_line_item l where c.charge_header_id=l.charge_header_id and c.batch_id='" + ulBatchID + "' and c.human_id='" + ulAccNo + "' and l.rendering_provider_id='" + ulRendProvID + "' and l.from_dos='" + sDOS+"' ").AddEntity("c", typeof(ChargeHeader)).AddEntity("l", typeof(ChargeLineItem));

        //                ChargeLineItem ChargeLineItemRecord = new ChargeLineItem();
        //                IList<ulong> ChargeLineItemIDRealList = new List<ulong>();

        //                //commented by srividhya
        //                foreach (IList<Object> l in sql.List())
        //                {
        //                    ChargeLineItemRecord = (ChargeLineItem)l[1];
        //                    ChargeLineItemIDRealList.Add(ChargeLineItemRecord.Id);
        //                }

        //                ulong[] ulChargeLineItemId = new ulong[ChargeLineItemIDRealList.Count];
        //                string[] sObjType = new string[ChargeLineItemIDRealList.Count];

        //                for (int j = 0; j < ChargeLineItemIDRealList.Count; j++)
        //                {
        //                    ulChargeLineItemId[j] = ChargeLineItemIDRealList[j];// ChargeLineItemIDList[j].Obj_System_Id;
        //                    sObjType[j] = "CHARGE_LINE_ITEM";// ChargeLineItemIDList[j].Obj_Type;
        //                }
        //                string sNextProcess = "";

        //                objWfObjManager.MoveToNextProcessChargeLineItem(ulChargeLineItemId, sObjType, CloseType, sUserName, dtStartTime, MySession, MacAddress, ref sNextProcess,dtEndTime);
        //            }
        //            ulWFID = ulWFObjectID;
        //        }

        //        if (ObjectProcessHistoryBillingTempList.Count > 0)
        //        {
        //            int iResult = 0;
        //            if (ObjectProcessHistoryBillingTempList != null && ObjectProcessHistoryBillingTempList.Count > 0)
        //            {
        //                ObjectProcessHistoryBillingTempManager ObjProcHisBillTempMngr = new ObjectProcessHistoryBillingTempManager();
        //                //iResult = ObjProcHisBillTempMngr.SaveUpdateDeleteWithoutTransaction(ref ObjectProcessHistoryBillingTempList, null, null, MySession, "");
        //                if (iResult == 2)
        //                {
        //                    if (iTryCount < 5)
        //                    {
        //                        iTryCount++;
        //                        //goto TryAgain;
        //                    }
        //                    else
        //                    {
        //                        trans.Rollback();
        //                        //  MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {
        //                    trans.Rollback();
        //                    // MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");
        //                }
        //            }
        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }

        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }

        //    return ulWFObjectID;
        //}

        public IList<ChargeHeader> GetChargeHeaderbyChargeHeaderID(ulong ulChargeHeaderID)
        {
            IList<ChargeHeader> ChargeHeaderList = new List<ChargeHeader>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select c.* from Charge_Header c where c.Charge_Header_ID =" + ulChargeHeaderID + " ")
                      .AddEntity("c", typeof(ChargeHeader));

                ChargeHeaderList = sql.List<ChargeHeader>();
                iMySession.Close();
            }
            return ChargeHeaderList;
        }
        //Added By balaji.TJ
        public IList<ChargeLineItem> GetChargeLineItembyChargeInternalReferenceID(ulong ulInternal_Reference_ID)
        {
            IList<ChargeLineItem> ChargeLineItemlist = new List<ChargeLineItem>();
            IList<ChargeHeader> ChargeHeaderList = new List<ChargeHeader>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select c.* from Charge_Header c where c.Internal_Reference_ID =" + ulInternal_Reference_ID + " ")
                      .AddEntity("c", typeof(ChargeHeader));

                string[] array = sql.List<ChargeHeader>().Select(a => a.Id.ToString()).ToArray();
                string ChargeHeader = string.Join(",", array);
                
                if (ChargeHeader != string.Empty && ChargeHeader != null)
                {
                    ISQLQuery sql1 = iMySession.CreateSQLQuery("Select l.* from charge_line_item l where l.charge_header_id IN (" + ChargeHeader + ") ")
                          .AddEntity("l", typeof(ChargeLineItem));
                    ChargeLineItemlist = sql1.List<ChargeLineItem>();
                }
                iMySession.Close();
            }
            return ChargeLineItemlist;
        }
        //Added By balaji.TJ
        public IList<ChargeLineItem> GetChargeLineItembyChargeHeaderID(ulong ulHeaderID)
        {                     
            IList<ChargeLineItem> ChargeLineItemlist = new List<ChargeLineItem>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql1 = iMySession.CreateSQLQuery("Select l.* from charge_line_item l where l.charge_header_id =" + ulHeaderID + " ")
                .AddEntity("l", typeof(ChargeLineItem));
                ChargeLineItemlist = sql1.List<ChargeLineItem>();
                iMySession.Close();
            }
            return ChargeLineItemlist;
        }
        //Added By Suresh on 23-dec-2013
        public int SaveChargeHeaderWithoutTransaction(IList<ChargeHeader> InsertList, ISession MySession, string MACAddress)
        {
            int iResult = 0;

            if ((InsertList != null))
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref InsertList, null, null, MySession, MACAddress);
            }
            return iResult;

        }


        public IList<ChargeHeader> GetChargeHeaderbyBatchID(ulong ulBatchID)
        {
            IList<ChargeHeader> ChargeHeaderList = new List<ChargeHeader>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select c.* from Charge_Header c where c.Batch_ID =" + ulBatchID + " order by c.charge_header_id ")
                      .AddEntity("c", typeof(ChargeHeader));

                ChargeHeaderList = sql.List<ChargeHeader>();
                iMySession.Close();
            }
            return ChargeHeaderList;
        }

         public IList<ChargeHeader> GetChargeAmount(ulong ulChargeHeaderID)
        {
            IList<ChargeHeader> GetChargeAmount = new List<ChargeHeader>();
            ChargeHeader objChargeHeader = new ChargeHeader();
            ArrayList arylstChargeAmtDetail = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query1 = iMySession.GetNamedQuery("Get.ChargeAmount");
                query1.SetString(0, ulChargeHeaderID.ToString());
                arylstChargeAmtDetail = new ArrayList(query1.List());
                if (arylstChargeAmtDetail.Count != 0)
                {

                    objChargeHeader = new ChargeHeader();
                    object[] objList = (object[])arylstChargeAmtDetail[0];
                    objChargeHeader.Lab_Charge_Amount = Convert.ToDouble(objList[1]);

                    GetChargeAmount.Add(objChargeHeader);



                }
                iMySession.Close();
            }
            return GetChargeAmount;
        }

         public IList<ChargeHeader> GetChargeHeaderListbyUniqueIdentifier(ulong ulBatchID, ulong ulEncounterID, ulong ulHumanID, string sChargeHeaderIdentifier)
         {
             IList<ChargeHeader> ChargeHeaderList = new List<ChargeHeader>();
             using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
             {
                 ICriteria crit = iMySession.CreateCriteria(typeof(ChargeHeader)).Add(Expression.Eq("Batch_ID", ulBatchID)).Add(Expression.Eq("Encounter_ID", ulEncounterID)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Charge_Header_Identifier", sChargeHeaderIdentifier)).AddOrder(Order.Asc("Id"));
                 ChargeHeaderList = crit.List<ChargeHeader>();
                 iMySession.Close();
             }
             return ChargeHeaderList;
         }


        #endregion
    }
}
