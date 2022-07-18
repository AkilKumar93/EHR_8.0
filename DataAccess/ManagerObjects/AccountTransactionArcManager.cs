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

    public partial interface IAccountTransactionArcManager : IManagerBase<AccountTransactionArc, ulong>
    {            
        //ChargeLineItemTransactionDTO GetPatientBalDueUnapplied(ulong MyHumanId);
        //AccountTransactionArc GetAccountTransactionArcUsingPPIDAndSourceType(ulong BillToPPLineId, string SourceType);
        //int UpdateAccountWithoutTransaction(IList<AccountTransactionArc> UpdateList, ISession MySession, string MacAddress);
        ////IList<ChargeLineItemTransactionDTO> LoadChargeLineForPP(ulong HumanId);
        ////IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalance(ulong HumanId);
        //PaymentPostingDTO LoadPPLineItemsForPP(ulong ChargeLineItemID);
        //decimal GetSumOfAmountAppliedForPatientsInCheck(ulong CarrierId, string PaymentId, ulong BatchId);
        //decimal GetPaymentsForBatch(ulong BatchId);
        //decimal GetAdjustmentsForBatch(ulong BatchId);
        //decimal ReceiptsForChargeLineItem(ulong ChargeLineItemId);
        //IList<AccountTransactionArc> GetAccountTransactionArcUsingChargeLineItemID(ulong ChargeLineItemID);                        
        //int SaveAccountWithoutTransaction(IList<AccountTransactionArc> InsertList, ISession MySession, string MACAddress);        
        //AccountTransactionArc GetAccTransUsingChargeLineID(ulong ulChargeLineItemID);
        //decimal GetWorkSetPostedAmount(ulong WfObjectID);
        ////Gopal(20120229)
        //IList<ChargeLineItemTransactionDTO> LoadChargeLineForDC(ulong HumanId);
        //IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithAdjust(ulong HumanId);        
        //IList<AccountTransactionArc> GetTotalbalance(string HumanId, string EncounterId, string BatchId, string[] ChargeLineid);
        //decimal GetTotalbalanceByChargeLineId(string ChargeLineId);       
        ////Added by Gopal_20140725
        ////IList<ChargeLineItemTransactionDTO> LoadChargeLineForPPForTrasaction(ulong HumanId, ulong ChargeId);
        ////IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceForTrasaction(ulong HumanId, ulong ChargeID);                
        //IList<ChargeLineItemTransactionDTO> GetInsuranceChargeLineItem(ulong HumanId, ulong ChargeID);
        //IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceForSortOrder(ulong HumanId, int PageNumber, int MaxResultSet, bool bShowAll, string SortCommand);        
        //IList<ChargeLineItemTransactionDTO> LoadChargeLineForPaymentPostingGridSortOrder(ulong HumanId, bool bShowAll);
        //IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceForGridSortOrder(ulong HumanId, bool bShowAll);
        //AccountTransactionArc GetAccountTransactionArcByPPLineID(ulong PPLineID);
        //decimal GetRefundAmount(string BatchName);
        //decimal GetSumOfPostedAmountAppliedForPatientsInCheck(ulong CarrierId, string PaymentId, ulong BatchId);
        //IList<ChargeLineItemTransactionDTO> GetChargeLineItemsByHumanIDOrChargeID(string ChargeLineId, ulong HumanId, bool bValue);
        //IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceByHumanID(ulong ChrageID, ulong HumanId);

    }
    public partial class AccountTransactionArcManager : ManagerBase<AccountTransactionArc, ulong>, IAccountTransactionArcManager
    {
        #region Constructors

        public AccountTransactionArcManager()
            : base()
        {

        }
        public AccountTransactionArcManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //#region Methods                

        //public ChargeLineItemTransactionDTO GetPatientBalDueUnapplied(ulong MyHumanId)
        //{
        //    ChargeLineItemTransactionDTO objCharge = new ChargeLineItemTransactionDTO();
        //    ArrayList aryCharge = null;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery query1 = iMySession.GetNamedQuery("Get.PatientBalance");
        //        query1.SetString(0, MyHumanId.ToString());
        //        aryCharge = new ArrayList(query1.List());
        //        if (aryCharge[0] != null)
        //            objCharge.PatientBalance = (decimal)(aryCharge[0]);

        //        aryCharge.Clear();
        //        query1 = iMySession.GetNamedQuery("Get.PatientDue");
        //        query1.SetString(0, MyHumanId.ToString());
        //        aryCharge = new ArrayList(query1.List());
        //        if (aryCharge[0] != null)
        //            objCharge.PatientDue = (decimal)(aryCharge[0]);

        //        aryCharge.Clear();
        //        query1 = iMySession.GetNamedQuery("Get.PatientDue.ForCashPatients");
        //        query1.SetString(0, MyHumanId.ToString());
        //        aryCharge = new ArrayList(query1.List());
        //        if (aryCharge[0] != null)
        //            objCharge.PatientDue = objCharge.PatientDue + (decimal)(aryCharge[0]);

        //        aryCharge.Clear();
        //        query1 = iMySession.GetNamedQuery("Get.PatientUnapplied");
        //        query1.SetString(0, MyHumanId.ToString());
        //        aryCharge = new ArrayList(query1.List());
        //        if (aryCharge[0] != null)
        //            objCharge.PatientUnapplied = (decimal)(aryCharge[0]);
        //        iMySession.Close();
        //    }
        //    return objCharge;
        //}

        //public IList<AccountTransactionArc> GetAccountTransactionArcUsingChargeLineItemID(ulong ChargeLineItemID)
        //{
        //    IList<AccountTransactionArc> ilstAccountTransactionArc = new List<AccountTransactionArc>(); 
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Charge_Line_Item_ID", ChargeLineItemID)).AddOrder(Order.Asc("Id"));
        //        ilstAccountTransactionArc= crit.List<AccountTransactionArc>();
        //        iMySession.Close();
        //    }
        //    return ilstAccountTransactionArc;
        //}

        //public int SaveAccountWithoutTransaction(IList<AccountTransactionArc> InsertList, ISession MySession, string MACAddress)
        //{
        //    int iResult = 0;
        //    GenerateXml ObjXML = null;
        //    IList<AccountTransactionArc> AccTransTemp = null;
        //    if ((InsertList != null))
        //    {
        //        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref InsertList, ref AccTransTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
        //    }
        //    return iResult;
        //}

        //public AccountTransactionArc GetAccountTransactionArcUsingPPIDAndSourceType(ulong BillToPPLineId, string SourceType)
        //{
        //    AccountTransactionArc objAcc = new AccountTransactionArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Bill_To_PP_Line_Item_ID", BillToPPLineId))
        //            .Add(Expression.Eq("Source_Type", SourceType)).AddOrder(Order.Asc("Id"));
        //        if (crit.List<AccountTransactionArc>().Count > 0)
        //            return crit.List<AccountTransactionArc>()[0];
        //        iMySession.Close();
        //    }
        //    return objAcc;
        //}

        //public int UpdateAccountWithoutTransaction(IList<AccountTransactionArc> UpdateList, ISession MySession, string MacAddress)
        //{
        //    int iResult = 0;
        //    IList<AccountTransactionArc> AccList = null;
        //    GenerateXml ObjXML = null;
        //    if (UpdateList != null)
        //    {
        //        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref AccList, ref UpdateList, null, MySession, MacAddress, false, false, 0, "", ref ObjXML);
        //    }
        //    return iResult;
        //}

        ////public IList<ChargeLineItemTransactionDTO> LoadChargeLineForPP(ulong HumanId)
        ////{
        ////    IList<ChargeLineItemTransactionDTO> ChargeList;
        ////    ChargeList = GetChargeLineItemsWithBalance(HumanId);
        ////    ChargeList.Add(GetPatientBalDueUnapplied(HumanId));
        ////    return ChargeList;
        ////}

        ////public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalance(ulong HumanId)
        ////{
        ////    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        ////    ChargeLineItemTransactionDTO objCharge;

        ////    string sWhereCriteria = "WHERE c.Charge_Line_Item_ID=a.Charge_Line_ITem_ID AND a.Human_ID=" + HumanId + " AND a.Source_Type= 'BILL_TO' AND a.CLAIM_TYPE <> 'TRANSFER' order by charge_line_item_id,bill_to_pp_line_item_id";
        ////    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        ////    {
        ////        IList<object> objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(c.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, a.Bill_To_PP_Line_Item_ID,a.Claim_Type, a.Line_Type,c.Modifier1,c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID FROM charge_line_item c, account_transaction a " + sWhereCriteria).List<object>();

        ////        for (int i = 0; i < objLst.Count; i++)
        ////        {
        ////            object[] obj = (object[])objLst[i];
        ////            objCharge = new ChargeLineItemTransactionDTO();
        ////            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        ////            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        ////            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        ////            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        ////            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        ////            objCharge.NDC_Code = Convert.ToString(obj[5]);
        ////            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        ////            objCharge.Bill_To_PP_Line_Item_ID = Convert.ToUInt64(obj[7]);
        ////            objCharge.Claim_Type = Convert.ToString(obj[8]);
        ////            objCharge.Line_Type = Convert.ToString(obj[9]);
        ////            objCharge.Modifier1 = Convert.ToString(obj[10]);
        ////            objCharge.Modifier2 = Convert.ToString(obj[11]);
        ////            objCharge.Modifier3 = Convert.ToString(obj[12]);
        ////            objCharge.Modifier4 = Convert.ToString(obj[13]);
        ////            objCharge.NDC_Units = Convert.ToString(obj[14]);
        ////            objCharge.To_DOS = Convert.ToDateTime(obj[15]);
        ////            objCharge.Place_of_Service = Convert.ToString(obj[16]);
        ////            objCharge.EMG = Convert.ToString(obj[17]);
        ////            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[18]);
        ////            IQuery query1 = session.GetISession().GetNamedQuery("Get.ChargeLineIems.From.AccountTransactionArc");
        ////            query1.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        ////            ArrayList arySum;
        ////            arySum = new ArrayList(query1.List());
        ////            objCharge.Sum_Amount = Convert.ToDecimal(arySum[0]);

        ////            ICriteria crit = iMySession.CreateCriteria(typeof(BillTo)).Add(Expression.Eq("Id", objCharge.Bill_To_PP_Line_Item_ID));
        ////            if (crit.List<BillTo>().Count != 0)
        ////            {
        ////                BillTo objBillTo = crit.List<BillTo>()[0];
        ////                objCharge.Bill_To_Amount = objBillTo.Bill_To_Amount;
        ////                objCharge.Insurance_Plan_ID = objBillTo.Insurance_Plan_ID;
        ////            }

        ////            crit = iMySession.CreateCriteria(typeof(EOB)).Add(Expression.Eq("Charge_Line_Item_ID", objCharge.Charge_Line_Item_Id)).AddOrder(Order.Asc("Created_Date_And_Time"));//changed from Order.Desc Order.Asc
        ////            if (crit.List<EOB>().Count != 0)
        ////            {
        ////                EOB objEob = crit.List<EOB>()[0];
        ////                objCharge.EOB_Allowed_Amount = objEob.Allowed_Amount;
        ////            }
        ////            //Added by suresh 0n 21-march-2012
        ////            IQuery PaidAmount = iMySession.GetNamedQuery("Get.AccountTransactionArc.PaidAmount");
        ////            PaidAmount.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        ////            ArrayList aryPaid;
        ////            aryPaid = new ArrayList(PaidAmount.List());
        ////            objCharge.Paid_Amount = Convert.ToDecimal(aryPaid[0]);
        ////            //Added by suresh 0n 21-march-2012
        ////            ChargeList.Add(objCharge);
        ////        }
        ////        iMySession.Close();
        ////    }
        ////    return ChargeList;
        ////}

        //public PaymentPostingDTO LoadPPLineItemsForPP(ulong ChargeLineItemID)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    //objPaymentPosting.AccountTransList = GetAccountTransactionArcUsingChargeLineItemID(ChargeLineItemID);
        //    return objPaymentPosting;
        //}

        //public decimal GetSumOfAmountAppliedForPatientsInCheck(ulong CarrierId, string PaymentId, ulong BatchId)
        //{
        //    decimal dSum = 0;
        //    if (CarrierId == 0 || PaymentId == string.Empty || BatchId == 0)
        //        return dSum;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Batch_ID", BatchId))
        //            .Add(Expression.Eq("Carrier_ID", CarrierId)).Add(Expression.Eq("Payment_ID", PaymentId))
        //            .Add(Expression.Eq("Source_Type", "PP_LINE_ITEM")).Add(!Expression.Eq("Line_Type", "WRITEOFF")).Add(!Expression.Eq("Reversal_Refund_Category", "REFUND")).
        //                SetProjection(Projections.Sum("Amount")).List<object>()[0];

        //        dSum = 0 - Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }
        //    return dSum;
        //}

        //public decimal GetPaymentsForBatch(ulong BatchId)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE (a.Source_Type = 'PP_LINE_ITEM') AND (a.Batch_Id =" + BatchId + " ) AND (a.Claim_Type= 'PATIENT' OR a.Claim_Type= 'PRIMARY_INSURANCE' OR a.Claim_Type= 'SECONDARY_INSURANCE' OR a.Claim_Type= 'TERTIARY_INSURANCE' OR a.Claim_Type= 'OLD PRIMARY' OR a.Claim_Type= 'OLD SECONDARY' OR a.Claim_Type= 'OLD TERTIARY') and reversal_refund_category<>'REFUND' ORDER BY a.Account_Transaction_ID").List<object>()[0];
        //        dSum = 0 - Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }

        //    return dSum;
        //}
        //public decimal GetPaid(ulong humanid)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE (a.Source_Type = 'PP_LINE_ITEM') AND (a.Human_ID =" + humanid + " ) AND (a.Claim_Type= 'PATIENT' OR a.Claim_Type= 'PRIMARY_INSURANCE' OR a.Claim_Type= 'SECONDARY_INSURANCE' OR a.Claim_Type= 'TERTIARY_INSURANCE' OR a.Claim_Type= 'OLD PRIMARY' OR a.Claim_Type= 'OLD SECONDARY' OR a.Claim_Type= 'OLD TERTIARY') ORDER BY a.Account_Transaction_ID").List<object>()[0];
        //        dSum = 0 - Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }
        //    return dSum;
        //}

        //public decimal GetAdjustmentsForBatch(ulong BatchId)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE (a.Source_Type = 'PP_LINE_ITEM') AND (a.Batch_Id = " + BatchId + ") AND (a.Line_Type= 'WRITEOFF') ORDER BY a.Account_Transaction_ID").List<object>()[0];
        //        dSum = 0 - Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }

        //    return dSum;
        //}

        //public decimal ReceiptsForChargeLineItem(ulong ChargeLineItemId)
        //{
        //    decimal dValue = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE a.Charge_Line_Item_ID = " + ChargeLineItemId + " AND a.Source_Type = 'PP_LINE_ITEM' ORDER BY a.Charge_Line_Item_ID").List<object>()[0];
        //        dValue = Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }
        //    return dValue;
        //}

        //public AccountTransactionArc GetAccTransUsingChargeLineID(ulong ulChargeLineItemID)
        //{
        //    AccountTransactionArc AccTransRecord = new AccountTransactionArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ISQLQuery sql = iMySession.CreateSQLQuery("Select c.* from account_transaction c where c.Charge_Line_Item_ID ='" + ulChargeLineItemID + "' ")
        //                .AddEntity("c", typeof(AccountTransactionArc));

        //        AccTransRecord = sql.List<AccountTransactionArc>()[0];
        //        iMySession.Close();
        //    }
        //    return AccTransRecord;

        //}

        ////Added By suresh on 30-march-2012 for Exception POsted Amount
        //public decimal GetWorkSetPostedAmount(ulong WfObjectID)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE (a.Source_Type = 'PP_LINE_ITEM') AND (a.WF_Object_ID =" + WfObjectID + " ) AND (a.Claim_Type= 'PATIENT' OR a.Claim_Type= 'PRIMARY_INSURANCE' OR a.Claim_Type= 'SECONDARY_INSURANCE' OR a.Claim_Type= 'TERTIARY_INSURANCE' OR a.Claim_Type= 'OLD PRIMARY' OR a.Claim_Type= 'OLD SECONDARY' OR a.Claim_Type= 'OLD TERTIARY') and reversal_refund_category<>'REFUND' ORDER BY a.Account_Transaction_ID").List<object>()[0];
        //        dSum = 0 - Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }

        //    return dSum;
        //}
        ////Added By suresh on 30-march-2012 for Exception POsted Amount

        ////Added By suresh on 05-april-2012 for RefundAmount
        //public decimal GetWorkSetRefundAmount(ulong BatchID)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE (a.Source_Type = 'PP_LINE_ITEM') AND (a.Batch_Id =" + BatchID + " ) and (a.Reversal_refund_category= 'REFUND' ) ORDER BY a.Account_Transaction_ID").List<object>()[0];
        //        dSum = Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }

        //    return dSum;
        //}

        //public IList<ChargeLineItemTransactionDTO> LoadChargeLineForDC(ulong HumanId)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList;
        //    ChargeList = GetChargeLineItemsWithAdjust(HumanId);
        //    return ChargeList;
        //}

        ////Gopal(20120229)
        //public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithAdjust(ulong HumanId)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    ChargeLineItemTransactionDTO objCharge;

        //    string sWhereCriteria = "WHERE a.Human_ID=" + HumanId + " AND a.Source_Type= 'BILL_TO' AND a.CLAIM_TYPE <> 'TRANSFER'AND a.CLAIM_TYPE <> 'Patient' group by Charge_line_item_id";
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IList<object> objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id,concat(c.Diagnosis1,',',c.Diagnosis2,',',c.Diagnosis3,',',c.Diagnosis4,',',c.Diagnosis5,',',c.Diagnosis6,',',c.Diagnosis7,',',c.Diagnosis8), cast(c.From_DOS as char(100)) as From_DOS, c.Charge_Amount,c.Procedure_Code FROM charge_line_item c inner join account_transaction a on (c.Charge_Line_Item_ID=a.Charge_Line_ITem_ID) " + sWhereCriteria).List<object>();

        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            object[] obj = (object[])objLst[i];
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        //            objCharge.Diagnosis = obj[1].ToString();
        //            objCharge.From_DOS = Convert.ToDateTime(obj[2]);
        //            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        //            objCharge.Charge_Amount = Convert.ToDouble(obj[3]);
        //            IQuery query1 = iMySession.GetNamedQuery("Get.ChargeLineIems.From.AccountTransactionArc");
        //            query1.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        //            ArrayList arySum;
        //            arySum = new ArrayList(query1.List());
        //            if (arySum[0] != null && arySum.Count != 0)
        //            {
        //                objCharge.Sum_Amount = Convert.ToDecimal(arySum[0]);
        //            }
        //            IQuery query2 = iMySession.GetNamedQuery("Get.ChargeLineIemsPaid.From.AccountTransactionArc");
        //            query2.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        //            ArrayList aryPaid;
        //            aryPaid = new ArrayList(query2.List());

        //            if (aryPaid.Count != 0 && aryPaid[0] != null)
        //            {
        //                objCharge.paid = aryPaid[0].ToString();
        //            }
        //            IQuery query3 = iMySession.GetNamedQuery("Get.ChargeLineIemsWriteoff.From.AccountTransactionArc");
        //            query3.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        //            ArrayList aryWriteoff;
        //            aryWriteoff = new ArrayList(query3.List());
        //            if (aryWriteoff != null && aryWriteoff.Count != 0)
        //            {
        //                objCharge.Writeoff = aryWriteoff[0].ToString();
        //            }
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //    return ChargeList;
        //}                
        //public AccountTransactionDTO GetAccountTransactionArcUsingAccountTransactionArcID(ulong AccountTransactionArcID)
        //{
        //    AccountTransactionDTO objAccountDTO = new AccountTransactionDTO();

        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Id", AccountTransactionArcID)).AddOrder(Order.Asc("Id"));
        //        objAccountDTO.AccountTransList = crit.List<AccountTransactionArc>();

        //        if (objAccountDTO.AccountTransList.Count > 0)
        //        {
        //            decimal dSum = 0;
        //            object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM account_transaction a WHERE (a.Source_Type =" + "'" + objAccountDTO.AccountTransList[0].Source_Type + "'" + ") AND (a.Claim_Type =" + "'" + objAccountDTO.AccountTransList[0].Claim_Type + "'" + ") AND (a.Line_type= " + "'" + objAccountDTO.AccountTransList[0].Line_Type + "'" + ") and( a.Batch_ID= " + objAccountDTO.AccountTransList[0].Batch_ID + ") and( a.DOOS=" + objAccountDTO.AccountTransList[0].DOOS + ") and ( a.Batch_Name= " + "'" + objAccountDTO.AccountTransList[0].Batch_Name + "'" + ") and( a.Check_Table_Int_ID= " + objAccountDTO.AccountTransList[0].Check_Table_Int_ID + ") and( a.Carrier_ID= " + objAccountDTO.AccountTransList[0].Carrier_ID + ") and( a.Human_ID= " + objAccountDTO.AccountTransList[0].Human_ID + ")and (a.Payment_ID=" + "'" + objAccountDTO.AccountTransList[0].Payment_ID + "'" + ") and (a.Charge_Line_Item_ID=" + objAccountDTO.AccountTransList[0].Charge_Line_Item_ID + ") and  (a.Amount > 0) ORDER BY a.Account_Transaction_ID").List<object>()[0];
        //            objAccountDTO.deAmount = Convert.ToDecimal(Sum);
        //        }
        //        PPLineItemManager objPPLineItemMngr = new PPLineItemManager();
        //        objAccountDTO.PPLineItemRecord = objPPLineItemMngr.GetPPLineItemFromId(objAccountDTO.AccountTransList[0].Bill_To_PP_Line_Item_ID, 0, false);
        //        iMySession.Close();
        //    }
        //    return objAccountDTO;
        //}       
        //public IList<AccountTransactionArc> GetTotalbalance(string HumanId, string EncounterId, string BatchId, string[] ChargeLineid)
        //{

        //    IList<AccountTransactionArc> ReturnBalance = new List<AccountTransactionArc>();
        //    AccountTransactionArc a = null;
        //    ArrayList TotalBalance = null;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery query = iMySession.GetNamedQuery("Get.Totalbalance");
        //        query.SetString(0, HumanId);
        //        query.SetString(1, EncounterId);
        //        query.SetString(2, BatchId);
        //        query.SetParameterList("ChargeLineid", ChargeLineid);

        //        TotalBalance = new ArrayList(query.List());


        //        if (TotalBalance != null)
        //        {
        //            for (int i = 0; i < TotalBalance.Count; i++)
        //            {
        //                object[] oj = (object[])TotalBalance[i];
        //                a = new AccountTransactionArc();
        //                a.Amount = Convert.ToDecimal(oj[1].ToString());

        //                ReturnBalance.Add(a);
        //            }

        //        }
        //        iMySession.Close();
        //    }
        //    return ReturnBalance;
        //}
        //public decimal GetTotalbalanceByChargeLineId(string ChargeLineId)
        //{
        //    decimal dValue = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateSQLQuery("SELECT sum(a.Amount) FROM .account_transaction a WHERE a.Charge_Line_Item_ID = " + ChargeLineId + " ").List<object>()[0];
        //        dValue= Convert.ToDecimal(Sum);
        //    }
        //    return dValue;
        //}        

        ////public IList<ChargeLineItemTransactionDTO> LoadChargeLineForPPForTrasaction(ulong HumanId, ulong ChargeId)
        ////{
        ////    IList<ChargeLineItemTransactionDTO> ChargeList;
        ////    ChargeList = GetChargeLineItemsWithBalanceForTrasaction(HumanId, ChargeId);
        ////    ChargeList.Add(GetPatientBalDueUnappliedForTrasaction(HumanId, ChargeId));
        ////    return ChargeList;
        ////}
        //public ChargeLineItemTransactionDTO GetPatientBalDueUnappliedForTrasaction(ulong MyHumanId, ulong ChargeID)
        //{
        //    ChargeLineItemTransactionDTO objCharge = new ChargeLineItemTransactionDTO();
        //    ArrayList aryCharge = null;

        //    //IQuery query1 = session.GetISession().GetNamedQuery("Get.PatientBalance.ForTransaction");
        //    //query1.SetString(0, MyHumanId.ToString());
        //    //query1.SetString(1, ChargeID.ToString());
        //    //aryCharge = new ArrayList(query1.List());
        //    //if (aryCharge[0] != null)
        //    //    objCharge.PatientBalance = (decimal)(aryCharge[0]);

        //    //aryCharge.Clear();
        //    //query1 = session.GetISession().GetNamedQuery("Get.PatientDue.ForTransaction");
        //    //query1.SetString(0, MyHumanId.ToString());
        //    //query1.SetString(1, ChargeID.ToString());
        //    //aryCharge = new ArrayList(query1.List());
        //    //if (aryCharge[0] != null)
        //    //    objCharge.PatientDue = (decimal)(aryCharge[0]);

        //    //aryCharge.Clear();
        //    //query1 = session.GetISession().GetNamedQuery("Get.PatientDue.ForCashPatients.ForTransaction");
        //    //query1.SetString(0, MyHumanId.ToString());
        //    //query1.SetString(1, ChargeID.ToString());
        //    //aryCharge = new ArrayList(query1.List());
        //    //if (aryCharge[0] != null)
        //    //    objCharge.PatientDue = objCharge.PatientDue + (decimal)(aryCharge[0]);

        //    //aryCharge.Clear();
        //    //query1 = session.GetISession().GetNamedQuery("Get.PatientUnapplied.ForTransaction");
        //    //query1.SetString(0, MyHumanId.ToString());
        //    //query1.SetString(1, ChargeID.ToString());
        //    //aryCharge = new ArrayList(query1.List());
        //    //if (aryCharge[0] != null)
        //    //    objCharge.PatientUnapplied = (decimal)(aryCharge[0]);

        //    return objCharge;
        //}
        ////public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceForTrasaction(ulong HumanId, ulong ChargeID)
        ////{
        ////    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        ////    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        ////    {
        ////        ChargeLineItemTransactionDTO objCharge;

        ////        string sWhereCriteria = "WHERE c.Charge_Line_Item_ID=a.Charge_Line_ITem_ID AND a.Human_ID=" + HumanId + " AND a.Source_Type= 'BILL_TO' AND a.CLAIM_TYPE <> 'TRANSFER' order by charge_line_item_id,bill_to_pp_line_item_id";

        ////        IList<object> objLst = session.GetISession().CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(c.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, a.Bill_To_PP_Line_Item_ID,a.Claim_Type, a.Line_Type,c.Modifier1,c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID FROM charge_line_item c, account_transaction a " + sWhereCriteria).List<object>();

        ////        string sWhereCriteria = "WHERE c.Charge_Line_Item_ID=" + ChargeID + " AND a.Charge_Line_ITem_ID=" + ChargeID + " AND a.Human_ID=" + HumanId + " AND a.Source_Type= 'BILL_TO' AND a.CLAIM_TYPE <> 'TRANSFER' and a.Insurance_Plan_Id=i.Insurance_Plan_Id order by charge_line_item_id,bill_to_pp_line_item_id";
            
        ////        IList<object> objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(c.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, a.Bill_To_PP_Line_Item_ID,a.Claim_Type, a.Line_Type,c.Modifier1,c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, i.Insurance_Plan_Name FROM charge_line_item c, account_transaction a, Insurance_plan i " + sWhereCriteria).List<object>();


        ////        for (int i = 0; i < objLst.Count; i++)
        ////        {
        ////            object[] obj = (object[])objLst[i];
        ////            objCharge = new ChargeLineItemTransactionDTO();
        ////            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        ////            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        ////            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        ////            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        ////            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        ////            objCharge.NDC_Code = Convert.ToString(obj[5]);
        ////            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        ////            objCharge.Bill_To_PP_Line_Item_ID = Convert.ToUInt64(obj[7]);
        ////            objCharge.Claim_Type = Convert.ToString(obj[8] + "- " + obj[19]);
        ////            objCharge.Line_Type = Convert.ToString(obj[9]);
        ////            objCharge.Modifier1 = Convert.ToString(obj[10]);
        ////            objCharge.Modifier2 = Convert.ToString(obj[11]);
        ////            objCharge.Modifier3 = Convert.ToString(obj[12]);
        ////            objCharge.Modifier4 = Convert.ToString(obj[13]);
        ////            objCharge.NDC_Units = Convert.ToString(obj[14]);
        ////            objCharge.To_DOS = Convert.ToDateTime(obj[15]);
        ////            objCharge.Place_of_Service = Convert.ToString(obj[16]);
        ////            objCharge.EMG = Convert.ToString(obj[17]);
        ////            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[18]);
        ////            IQuery query1 = iMySession.GetNamedQuery("Get.ChargeLineIems.From.AccountTransactionArc");
        ////            query1.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        ////            ArrayList arySum;
        ////            arySum = new ArrayList(query1.List());
        ////            objCharge.Sum_Amount = Convert.ToDecimal(arySum[0]);

        ////            ICriteria crit = iMySession.CreateCriteria(typeof(BillTo)).Add(Expression.Eq("Id", objCharge.Bill_To_PP_Line_Item_ID));
        ////            if (crit.List<BillTo>().Count != 0)
        ////            {
        ////                BillTo objBillTo = crit.List<BillTo>()[0];
        ////                objCharge.Bill_To_Amount = objBillTo.Bill_To_Amount;
        ////                objCharge.Insurance_Plan_ID = objBillTo.Insurance_Plan_ID;
        ////            }
        ////            ICriteria critInsurancePlan = iMySession.CreateCriteria(typeof(InsurancePlan)).Add(Expression.Eq("Id", objCharge.Insurance_Plan_ID));
        ////            if (critInsurancePlan.List<InsurancePlan>().Count != 0)
        ////            {
        ////                InsurancePlan objInsurance = critInsurancePlan.List<InsurancePlan>()[0];
        ////                objCharge.InsurancePlan = objInsurance.Ins_Plan_Name;
        ////            }
        ////            crit = iMySession.CreateCriteria(typeof(EOB)).Add(Expression.Eq("Charge_Line_Item_ID", objCharge.Charge_Line_Item_Id)).AddOrder(Order.Asc("Created_Date_And_Time"));//changed from Order.Desc Order.Asc
        ////            if (crit.List<EOB>().Count != 0)
        ////            {
        ////                EOB objEob = crit.List<EOB>()[0];
        ////                objCharge.EOB_Allowed_Amount = objEob.Allowed_Amount;
        ////            }
        ////            Added by suresh 0n 21-march-2012
        ////            IQuery PaidAmount = iMySession.GetNamedQuery("Get.AccountTransactionArc.PaidAmount");
        ////            PaidAmount.SetString(0, objCharge.Charge_Line_Item_Id.ToString());
        ////            ArrayList aryPaid;
        ////            aryPaid = new ArrayList(PaidAmount.List());
        ////            objCharge.Paid_Amount = Convert.ToDecimal(aryPaid[0]);
        ////            Added by suresh 0n 21-march-2012
        ////            ChargeList.Add(objCharge);
        ////        }
        ////        iMySession.Close();
        ////    }
        ////    return ChargeList;
        ////}        
        //public IList<ChargeLineItemTransactionDTO> GetInsuranceChargeLineItem(ulong HumanId, ulong ChargeID)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    ChargeLineItemTransactionDTO objCharge;
        //    string sWhereCriteria = "WHERE c.Charge_Line_Item_ID=" + ChargeID + " AND a.Charge_Line_ITem_ID=" + ChargeID + " AND a.Human_ID=" + HumanId + " AND a.Source_Type= 'BILL_TO' AND a.CLAIM_TYPE <> 'TRANSFER' and a.Insurance_Plan_Id=i.Insurance_Plan_Id  order by a.Created_Date_And_Time desc limit 1";
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IList<object> objLst = iMySession.CreateSQLQuery("SELECT i.Insurance_Plan_Name FROM charge_line_item c, account_transaction a, Insurance_plan i " + sWhereCriteria).List<object>();
        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.Claim_Type = Convert.ToString(objLst[0]);
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //    return ChargeList;
        //}
        ////Added By Manimaran For Sort Order on 08/09/2014
        //public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceForSortOrder(ulong HumanId,int PageNumber,int MaxResultSet,bool bShowAll,string SortCommand)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ChargeLineItemTransactionDTO objCharge;
        //        string sWhereCriteria = "WHERE  ch.Human_ID=" + HumanId + " group by c.charge_line_item_id having sum(a.amount)<>0.00 order by " + SortCommand + "";
        //        IList<object> objLst = null;
        //        if (bShowAll == true)
        //        {
        //            sWhereCriteria = "WHERE  ch.Human_ID=" + HumanId + " group by c.charge_line_item_id  order by " + SortCommand + "";
        //        }
           
        //        objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount) ,(select i.Insurance_Plan_Name from  account_transaction at, Insurance_plan i where at.Human_ID=" + HumanId + " AND at.Source_Type= 'BILL_TO' AND  at.CLAIM_TYPE <> 'TRANSFER' and at.Insurance_Plan_Id=i.Insurance_Plan_Id and at.charge_line_item_id=506421 order by at.Created_Date_And_Time desc limit 1 ) as ins_name from charge_header ch join charge_line_item c on(ch.charge_header_id= c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id)" + sWhereCriteria).List<object>();
        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            object[] obj = (object[])objLst[i];
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.TotalCount = objLst.Count;
        //            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        //            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        //            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        //            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        //            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        //            objCharge.NDC_Code = Convert.ToString(obj[5]);
        //            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        //            if (Convert.ToString(obj[7]).Trim() != string.Empty)
        //            {
        //                objCharge.Procedure_Code = objCharge.Procedure_Code + "-" + Convert.ToString(obj[7]);
        //            }
        //            objCharge.Modifier1 = Convert.ToString(obj[7]);
        //            objCharge.Modifier2 = Convert.ToString(obj[8]);
        //            objCharge.Modifier3 = Convert.ToString(obj[9]);
        //            objCharge.Modifier4 = Convert.ToString(obj[10]);
        //            objCharge.NDC_Units = Convert.ToString(obj[11]);
        //            objCharge.To_DOS = Convert.ToDateTime(obj[12]);
        //            objCharge.Place_of_Service = Convert.ToString(obj[13]);
        //            objCharge.EMG = Convert.ToString(obj[14]);
        //            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[15]);
        //            if (Convert.ToString(obj[16]).Trim() != string.Empty)
        //            {
        //                objCharge.DoctorName = Convert.ToString(obj[16]);
        //            }
        //            objCharge.Sum_Amount = Convert.ToDecimal(obj[17]);
        //            objCharge.Claim_Type = Convert.ToString(obj[18]);
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //     int start = ((PageNumber - 1) * MaxResultSet);
        //     int end = (PageNumber * MaxResultSet);
        //     ChargeList = ChargeList.Skip(start).Take(end - start).ToList<ChargeLineItemTransactionDTO>();
        //     return ChargeList;
        //}       
        ////Added By Manimaran For Grid Order Sorting on 12-09-2014
        //public IList<ChargeLineItemTransactionDTO> LoadChargeLineForPaymentPostingGridSortOrder(ulong HumanId, bool bShowAll)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList;
        //    ChargeList = GetChargeLineItemsWithBalanceForGridSortOrder(HumanId, bShowAll);
        //    ChargeList.Add(GetPatientBalDueUnapplied(HumanId));
        //    return ChargeList;
        //}
        //public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceForGridSortOrder(ulong HumanId, bool bShowAll)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ChargeLineItemTransactionDTO objCharge;
        //        string sWhereCriteria = "WHERE  ch.Human_ID=" + HumanId + " and w.Obj_Type='CHARGE_LINE_ITEM' and (w.Current_Process='TRANSFER_TO_PATIENT' or w.Current_Process='BILL_TO_PRIMARY' or w.Current_Process='TRANSFER_TO_PRIMARY' or w.Current_Process='TRANSFER_TO_SECONDARY' or w.Current_Process='BILL_TO_PATIENT' or w.Current_Process='TRANSFER_TO_TERTIARY'or w.Current_Process='CLOSED'or  w.Current_Process='OVER_PAID'or w.Current_Process='DENIED') group by c.charge_line_item_id having sum(a.amount)<>0.00";
        //        // string sWhereCriteria = "WHERE  ch.Human_ID=" + HumanId + " group by c.charge_line_item_id having sum(a.amount)<>0.00";
        //        IList<object> objLst = null;
        //        if (bShowAll == true)
        //        {
        //            //sWhereCriteria = "WHERE  ch.Human_ID=" + HumanId + " group by c.charge_line_item_id";
        //            sWhereCriteria = "WHERE  ch.Human_ID=" + HumanId + " and w.Obj_Type='CHARGE_LINE_ITEM' and (w.Current_Process='TRANSFER_TO_PATIENT' or w.Current_Process='BILL_TO_PRIMARY' or w.Current_Process='TRANSFER_TO_PRIMARY' or w.Current_Process='TRANSFER_TO_SECONDARY' or w.Current_Process='BILL_TO_PATIENT' or w.Current_Process='TRANSFER_TO_TERTIARY'or w.Current_Process='CLOSED'or  w.Current_Process='OVER_PAID'or w.Current_Process='DENIED') group by c.charge_line_item_id";
        //        }
           
        //        objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount)from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id) join wf_object_billing w on (c.charge_line_item_id=w.Obj_System_Id) " + sWhereCriteria).List<object>();
        //        //objLst = session.GetISession().CreateSQLQuery("SELECT c.Charge_Line_Item_Id,cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount)from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id) " + sWhereCriteria).List<object>();
        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            object[] obj = (object[])objLst[i];
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.TotalCount = objLst.Count;
        //            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        //            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        //            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        //            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        //            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        //            objCharge.NDC_Code = Convert.ToString(obj[5]);
        //            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        //            if (Convert.ToString(obj[7]).Trim() != string.Empty)
        //            {
        //                objCharge.Procedure_Code = objCharge.Procedure_Code + "-" + Convert.ToString(obj[7]);
        //            }
        //            objCharge.Modifier1 = Convert.ToString(obj[7]);
        //            objCharge.Modifier2 = Convert.ToString(obj[8]);
        //            objCharge.Modifier3 = Convert.ToString(obj[9]);
        //            objCharge.Modifier4 = Convert.ToString(obj[10]);
        //            objCharge.NDC_Units = Convert.ToString(obj[11]);
        //            objCharge.To_DOS = Convert.ToDateTime(obj[12]);
        //            objCharge.Place_of_Service = Convert.ToString(obj[13]);
        //            objCharge.EMG = Convert.ToString(obj[14]);
        //            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[15]);
        //            if (Convert.ToString(obj[16]).Trim() != string.Empty)
        //            {
        //                objCharge.DoctorName = Convert.ToString(obj[16]);
        //            }
        //            objCharge.Sum_Amount = Convert.ToDecimal(obj[17]);
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //    return ChargeList;
        //}        
        //public decimal GetRefundAmount(string BatchName)
        //{
        //    decimal RefundAmount = 0;
        //    Batch BatchList = new Batch();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(Batch)).Add(Expression.Eq("Batch_Name", BatchName));
        //        if (crit.List<Batch>()[0].Id > 0)
        //        {
        //            ulong BatchID = crit.List<Batch>()[0].Id;
        //            RefundAmount = GetWorkSetRefundAmount(BatchID);
        //        }
        //        iMySession.Close();
        //    }
        //    return RefundAmount;
        //}
        //public AccountTransactionArc GetAccountTransactionArcByPPLineID(ulong PPLineID)
        //{
        //    AccountTransactionArc AccRecord = new AccountTransactionArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria Criteria = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Bill_To_PP_Line_Item_ID", PPLineID));
        //        AccRecord = Criteria.List<AccountTransactionArc>()[0];
        //        iMySession.Close();
        //    }
        //    return AccRecord;
        //}
        ////Added By Manimaran This Method is used to all developer for getting ChargeLineItems

        //public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsWithBalanceByHumanID(ulong ChargeId, ulong HumanId)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ChargeLineItemTransactionDTO objCharge;
        //        string sWhereCriteria = "WHERE  c.Charge_Line_Item_Id=" + ChargeId + " and ch.Human_ID=" + HumanId + " group by c.Charge_Line_Item_Id ";
        //        IList<object> objLst = null;
           
        //        objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount),c.Units,c.Created_By,ch.Encounter_ID,ch.Diagnosis1,ch.Diagnosis2,ch.Diagnosis3,ch.Diagnosis4,ch.Diagnosis5,ch.Diagnosis6,ch.Diagnosis7,ch.Diagnosis8,ch.Diagnosis9,ch.Diagnosis10,ch.Diagnosis11,ch.Diagnosis12,ch.Internal_Reference_ID,ch.Batch_ID from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id)" + sWhereCriteria).List<object>();
        //        //objLst = session.GetISession().CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount),c.Units,c.Created_By,ch.Encounter_ID,ch.Diagnosis1,ch.Diagnosis2,ch.Diagnosis3,ch.Diagnosis4,ch.Diagnosis5,ch.Diagnosis6,ch.Diagnosis7,ch.Diagnosis8,ch.Diagnosis9,ch.Diagnosis10,ch.Diagnosis11,ch.Diagnosis12,ch.Internal_Reference_ID,ch.Batch_ID from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id) " + sWhereCriteria).List<object>();
        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            object[] obj = (object[])objLst[i];
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.TotalCount = objLst.Count;
        //            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        //            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        //            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        //            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        //            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        //            objCharge.NDC_Code = Convert.ToString(obj[5]);
        //            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        //            if (Convert.ToString(obj[7]).Trim() != string.Empty)
        //            {
        //                objCharge.Procedure_Code = objCharge.Procedure_Code + "-" + Convert.ToString(obj[7]);
        //            }
        //            objCharge.Modifier1 = Convert.ToString(obj[7]);
        //            objCharge.Modifier2 = Convert.ToString(obj[8]);
        //            objCharge.Modifier3 = Convert.ToString(obj[9]);
        //            objCharge.Modifier4 = Convert.ToString(obj[10]);
        //            objCharge.NDC_Units = Convert.ToString(obj[11]);
        //            objCharge.To_DOS = Convert.ToDateTime(obj[12]);
        //            objCharge.Place_of_Service = Convert.ToString(obj[13]);
        //            objCharge.EMG = Convert.ToString(obj[14]);
        //            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[15]);
        //            if (Convert.ToString(obj[16]).Trim() != string.Empty)
        //            {
        //                objCharge.DoctorName = Convert.ToString(obj[16]);
        //            }
        //            objCharge.Sum_Amount = Convert.ToDecimal(obj[17]);
        //            objCharge.Units = Convert.ToDecimal(obj[18]);
        //            objCharge.Created_By = obj[19].ToString();
        //            objCharge.Encounter_ID = Convert.ToInt32(obj[20]);
        //            for (int j = 21; j < obj.Count(); j++)
        //            {
        //                if (Convert.ToString(obj[j]).Trim() != string.Empty)
        //                {
        //                    if (objCharge.Diagnosis.Contains(','))
        //                    {
        //                        objCharge.Diagnosis = objCharge.Diagnosis + "," + obj[j].ToString();
        //                    }
        //                    else
        //                    {
        //                        objCharge.Diagnosis = obj[j].ToString();
        //                    }
        //                }
        //            }
        //            objCharge.Internal_Reference_ID = Convert.ToUInt32(obj[33]);
        //            objCharge.Batch_ID = Convert.ToInt32(obj[34]);
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //    return ChargeList;
        //}
        //public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsByHumanID(bool bShowAll, ulong HumanId,string chargeLineItemID)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ChargeLineItemTransactionDTO objCharge;
        //        string sWhereCriteria = string.Empty;
        //        if (chargeLineItemID == "")
        //        {
        //            sWhereCriteria = "WHERE ch.Human_ID=" + HumanId + " group by c.charge_line_item_id having sum(a.amount)<>0.00 order by charge_line_item_id asc";
        //            if (bShowAll == true)
        //            {
        //                sWhereCriteria = "WHERE ch.Human_ID=" + HumanId + " group by c.charge_line_item_id order by charge_line_item_id asc";
        //            }
        //        }
        //        else
        //        {
        //            sWhereCriteria = "WHERE  c.Charge_Line_Item_Id in (" + chargeLineItemID + ") and ch.Human_ID=" + HumanId + " group by c.charge_line_item_id order by charge_line_item_id asc";
        //        }
        //        IList<object> objLst = null;
          
        //        objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount),c.Units,c.Created_By,ch.Encounter_ID,ch.Diagnosis1,ch.Diagnosis2,ch.Diagnosis3,ch.Diagnosis4,ch.Diagnosis5,ch.Diagnosis6,ch.Diagnosis7,ch.Diagnosis8,ch.Diagnosis9,ch.Diagnosis10,ch.Diagnosis11,ch.Diagnosis12,ch.Internal_Reference_ID,ch.Batch_ID from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id)" + sWhereCriteria).List<object>();
        //        //objLst = session.GetISession().CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount),c.Units,c.Created_By,ch.Encounter_ID,ch.Diagnosis1,ch.Diagnosis2,ch.Diagnosis3,ch.Diagnosis4,ch.Diagnosis5,ch.Diagnosis6,ch.Diagnosis7,ch.Diagnosis8,ch.Diagnosis9,ch.Diagnosis10,ch.Diagnosis11,ch.Diagnosis12,ch.Internal_Reference_ID,ch.Batch_ID from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id) " + sWhereCriteria).List<object>();
        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            object[] obj = (object[])objLst[i];
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.TotalCount = objLst.Count;
        //            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        //            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        //            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        //            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        //            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        //            objCharge.NDC_Code = Convert.ToString(obj[5]);
        //            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        //            if (Convert.ToString(obj[7]).Trim() != string.Empty)
        //            {
        //                objCharge.Procedure_Code = objCharge.Procedure_Code + "-" + Convert.ToString(obj[7]);
        //            }
        //            objCharge.Modifier1 = Convert.ToString(obj[7]);
        //            objCharge.Modifier2 = Convert.ToString(obj[8]);
        //            objCharge.Modifier3 = Convert.ToString(obj[9]);
        //            objCharge.Modifier4 = Convert.ToString(obj[10]);
        //            objCharge.NDC_Units = Convert.ToString(obj[11]);
        //            objCharge.To_DOS = Convert.ToDateTime(obj[12]);
        //            objCharge.Place_of_Service = Convert.ToString(obj[13]);
        //            objCharge.EMG = Convert.ToString(obj[14]);
        //            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[15]);
        //            if (Convert.ToString(obj[16]).Trim() != string.Empty)
        //            {
        //                objCharge.DoctorName = Convert.ToString(obj[16]);
        //            }
        //            objCharge.Sum_Amount = Convert.ToDecimal(obj[17]);
        //            objCharge.Units = Convert.ToDecimal(obj[18]);
        //            objCharge.Created_By = obj[19].ToString();
        //            objCharge.Encounter_ID = Convert.ToInt32(obj[20]);
        //            for (int j = 21; j < obj.Count(); j++)
        //            {
        //                if (Convert.ToString(obj[j]).Trim() != string.Empty)
        //                {
        //                    if (objCharge.Diagnosis.Contains(','))
        //                    {
        //                        objCharge.Diagnosis = objCharge.Diagnosis + "," + obj[j].ToString();
        //                    }
        //                    else
        //                    {
        //                        objCharge.Diagnosis = obj[j].ToString();
        //                    }
        //                }
        //            }
        //            objCharge.Internal_Reference_ID = Convert.ToUInt32(obj[33]);
        //            objCharge.Batch_ID = Convert.ToInt32(obj[34]);
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //    return ChargeList;
        //}
        //public decimal GetSumOfPostedAmountAppliedForPatientsInCheck(ulong CarrierId, string PaymentId, ulong BatchId)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        if (CarrierId == 0 || PaymentId == string.Empty)
        //            return dSum;
            
        //        object Sum = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Batch_ID", BatchId))
        //            .Add(Expression.Eq("Carrier_ID", CarrierId)).Add(Expression.Eq("Payment_ID", PaymentId))
        //            .Add(Expression.Eq("Source_Type", "PP_LINE_ITEM")).Add(!Expression.Eq("Line_Type", "WRITEOFF")).
        //                SetProjection(Projections.Sum("Amount")).List<object>()[0];

        //        dSum = 0 - Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }
        //    return dSum;
        //}
        //public IList<ChargeLineItemTransactionDTO> GetChargeLineItemsByHumanIDOrChargeID(string ChargeLineId, ulong HumanId,bool bValue)
        //{
        //    IList<ChargeLineItemTransactionDTO> ChargeList = new List<ChargeLineItemTransactionDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ChargeLineItemTransactionDTO objCharge;
        //         string sWhereCriteria=string.Empty;
        //             if (bValue == true)
        //             {
        //                 sWhereCriteria = "WHERE  c.Charge_Line_Item_Id in (" + ChargeLineId + ") and ch.Human_ID=" + HumanId + " group by c.Charge_Line_Item_Id ";
        //             }
        //             if (bValue == false)
        //             {
        //                 sWhereCriteria = "WHERE  c.Charge_Line_Item_Id=" + ChargeLineId + " and ch.Human_ID=" + HumanId + " group by c.Charge_Line_Item_Id ";
        //             }
        //        IList<object> objLst = null;
          
        //        objLst = iMySession.CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount),c.Units,c.Created_By,ch.Encounter_ID,ch.Diagnosis1,ch.Diagnosis2,ch.Diagnosis3,ch.Diagnosis4,ch.Diagnosis5,ch.Diagnosis6,ch.Diagnosis7,ch.Diagnosis8,ch.Diagnosis9,ch.Diagnosis10,ch.Diagnosis11,ch.Diagnosis12,ch.Internal_Reference_ID,ch.Batch_ID from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id)" + sWhereCriteria).List<object>();
        //        //objLst = session.GetISession().CreateSQLQuery("SELECT c.Charge_Line_Item_Id, cast(c.From_DOS as char(100)) as From_DOS,cast(a.Created_Date_And_Time as char(100)) as Created_Date_And_Time,c.Rendering_Provider_ID,c.Procedure_Code, c.NDC_Code, c.Charge_Amount, concat(c.Modifier1,' ',c.Modifier2,' ',c.Modifier3,' ',c.Modifier4),c.Modifier2,c.Modifier3,c.Modifier4,c.NDC_Units,cast(c.To_DOS as char(100)) as To_DOS,c.Place_of_Service,c.EMG,c.Charge_Header_ID, concat(p.Physician_first_name,' ',p.Physician_middle_name,' ',p.Physician_last_name,' ',p.physician_suffix),sum(a.Amount),c.Units,c.Created_By,ch.Encounter_ID,ch.Diagnosis1,ch.Diagnosis2,ch.Diagnosis3,ch.Diagnosis4,ch.Diagnosis5,ch.Diagnosis6,ch.Diagnosis7,ch.Diagnosis8,ch.Diagnosis9,ch.Diagnosis10,ch.Diagnosis11,ch.Diagnosis12,ch.Internal_Reference_ID,ch.Batch_ID from charge_header ch join charge_line_item c on(ch.charge_header_id=c.charge_header_id) join account_transaction a on(c.charge_line_item_id=a.charge_line_item_id) join physician_library p on(c.rendering_provider_id=p.physician_library_id) " + sWhereCriteria).List<object>();
        //        for (int i = 0; i < objLst.Count; i++)
        //        {
        //            object[] obj = (object[])objLst[i];
        //            objCharge = new ChargeLineItemTransactionDTO();
        //            objCharge.TotalCount = objLst.Count;
        //            objCharge.Charge_Line_Item_Id = Convert.ToUInt64(obj[0]);
        //            objCharge.From_DOS = Convert.ToDateTime(obj[1]);
        //            objCharge.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
        //            objCharge.Rendering_Provider_ID = Convert.ToUInt64(obj[3]);
        //            objCharge.Procedure_Code = Convert.ToString(obj[4]);
        //            objCharge.NDC_Code = Convert.ToString(obj[5]);
        //            objCharge.Charge_Amount = Convert.ToDouble(obj[6]);
        //            if (Convert.ToString(obj[7]).Trim() != string.Empty)
        //            {
        //                objCharge.Procedure_Code = objCharge.Procedure_Code + "-" + Convert.ToString(obj[7]);
        //            }
        //            objCharge.Modifier1 = Convert.ToString(obj[7]);
        //            objCharge.Modifier2 = Convert.ToString(obj[8]);
        //            objCharge.Modifier3 = Convert.ToString(obj[9]);
        //            objCharge.Modifier4 = Convert.ToString(obj[10]);
        //            objCharge.NDC_Units = Convert.ToString(obj[11]);
        //            objCharge.To_DOS = Convert.ToDateTime(obj[12]);
        //            objCharge.Place_of_Service = Convert.ToString(obj[13]);
        //            objCharge.EMG = Convert.ToString(obj[14]);
        //            objCharge.Charge_Header_ID = Convert.ToUInt64(obj[15]);
        //            if (Convert.ToString(obj[16]).Trim() != string.Empty)
        //            {
        //                objCharge.DoctorName = Convert.ToString(obj[16]);
        //            }
        //            objCharge.Sum_Amount = Convert.ToDecimal(obj[17]);
        //            objCharge.Units = Convert.ToDecimal(obj[18]);
        //            objCharge.Created_By = obj[19].ToString();
        //            objCharge.Encounter_ID = Convert.ToInt32(obj[20]);
        //            for (int j = 21; j < obj.Count(); j++)
        //            {
        //                if (Convert.ToString(obj[j]).Trim() != string.Empty)
        //                {
        //                    if (objCharge.Diagnosis.Contains(','))
        //                    {
        //                        objCharge.Diagnosis = objCharge.Diagnosis + "," + obj[j].ToString();
        //                    }
        //                    else
        //                    {
        //                        objCharge.Diagnosis = obj[j].ToString();
        //                    }
        //                }
        //            }
        //            objCharge.Internal_Reference_ID = Convert.ToUInt32(obj[33]);
        //            objCharge.Batch_ID = Convert.ToInt32(obj[34]);
        //            ChargeList.Add(objCharge);
        //        }
        //        iMySession.Close();
        //    }
        //    return ChargeList;
        //}
        //public IList<AccountTransactionArc> GetAccTranByPPLineID(ulong PPLineID)
        //{
        //    IList<AccountTransactionArc> AccTranList = new List<AccountTransactionArc>();
        //    ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //    ICriteria Crit = iMySession.CreateCriteria(typeof(AccountTransactionArc)).Add(Expression.Eq("Bill_To_PP_Line_Item_ID", PPLineID));
        //    AccTranList = Crit.List<AccountTransactionArc>();
        //    return AccTranList;
        //}
         
        //#endregion
    }
}
