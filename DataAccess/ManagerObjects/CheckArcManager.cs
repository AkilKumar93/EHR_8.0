using System;
using System.Data;
using System.Data.Linq;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;
using NHibernate.Criterion;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ICheckArcManager : IManagerBase<CheckArc, ulong>
    {
        //PaymentPostingDTO GetCheckArcDetailsForPP(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanId,string PaymentType);
        //CheckArc GetCheckArcRecord(ulong CarrierId, string PaymentId, ulong BatchId);
        //IList<CheckArc> GetCheckArcRecordByBatchID(ulong BatchId);
        //decimal GetSumOfExistingCheckArcs(ulong BatchId);
        //PaymentPostingDTO GetCheckArcDetailsandSumofExistCheckArcs(ulong CarrierId, string PaymentId, ulong BatchId);
        //ulong SaveCheckArcWithTransaction(IList<CheckArc> InsertList, string MacAddress);
        //PaymentPostingDTO LoadCheckArcAndPPHeaderRecord(ulong CarrierId, string PaymentId, ulong HumanId, ulong BatchID);
        //CheckArc GetCheckArcbyId(ulong CheckArcId);
        //PaymentPostingDTO SaveCheckArcAndLoadPPHeader(IList<CheckArc> CheckArcList, ulong HumanId, string MACAddress);
        //int SaveCheckArcWithoutTransaction(IList<CheckArc> InsertList, ISession MySession, string MACAddress);                
        //IList<CheckArc> GetCheckArcListByBatchName(string BatchName);
        //IList<CheckArc> GetCheckArcRecordUsingPaymentAndBatchID(string PaymentId, ulong BatchId);
        //PaymentPostingDTO GetCarrierNameWithAmount(string PaymentId, ulong BatchId, ulong HumanID);
        //IList<CheckArc> GetCheckArcByCheckArcId(ulong CheckArcId);                
        //CheckArc GetCheckArcRecordByCarrierIdAndPaymentType(ulong CarrierId, string PaymentId, ulong BatchId, string PaymentType);
        //PaymentPostingDTO GetCheckArcDetailsForPaymentPosting(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanID);
        //IList<CheckArc> GetCheckArcInformationByCarrierIdAndPaymentId(ulong CarrierId, string PaymentId, ulong BatchId);
    }
    public partial class CheckArcManager : ManagerBase<CheckArc, ulong>, ICheckArcManager
    {
        #region Constructors

        public CheckArcManager()
            : base()
        {

        }
        public CheckArcManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //#region Methods

        //public int SaveCheckArcWithoutTransaction(IList<CheckArc> InsertList, ISession MySession, string MACAddress)
        //{
        //    int iResult = 0;
        //    IList<CheckArc> CheckArcTemp = null;
        //    GenerateXml ObjXML = null;
        //    if ((InsertList != null))
        //    {
        //        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref InsertList, ref CheckArcTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
        //    }
        //    return iResult;

        //}
        //public CheckArc GetCheckArcRecord(ulong CarrierId, string PaymentId, ulong BatchId)
        //{
        //    CheckArc objCheckArc = new CheckArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Carrier_ID", CarrierId))
        //            .Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId));//

        //        if (crit.List<CheckArc>().Count != 0)
        //            objCheckArc = crit.List<CheckArc>()[0];
        //        iMySession.Close();
        //    }
        //    return objCheckArc;
        //}

        //public CheckArc GetCheckArcbyId(ulong CheckArcId)
        //{
        //    CheckArc objCheckArc = new CheckArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Id", CheckArcId));
        //        if (crit.List<CheckArc>().Count != 0)
        //            objCheckArc = crit.List<CheckArc>()[0];
        //        iMySession.Close();
        //    }

        //    return objCheckArc;
        //}

        //public PaymentPostingDTO GetCheckArcDetailsForPP(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanID,string PaymentType)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    //Added the BatchId as Additional parameter to get the CheckArc details on 20140521 Reported by Ekambaram
        //    if (PaymentType != string.Empty)
        //    {
        //        objPaymentPosting.CheckArcRecord = GetCheckArcRecordByCarrierIdAndPaymentType(CarrierId, PaymentId, BatchId,PaymentType);
        //    }
        //    else
        //    {
        //    objPaymentPosting.CheckArcRecord = GetCheckArcRecord(CarrierId, PaymentId, BatchId);
        //    }

        //    AccountTransactionManager objAccount = new AccountTransactionManager();
        //    if (CarrierId != 41)
        //        objPaymentPosting.AmountAppliedInCheckArc = objAccount.GetSumOfAmountAppliedForPatientsInCheckArc(CarrierId, PaymentId, BatchId);
        //    else
        //        objPaymentPosting.AmountAppliedInCheckArc = objAccount.GetSumOfAmountAppliedForPatientsInCheckArc(0, PaymentId, BatchId);
        //    //Added the  for Messages
        //    if (objPaymentPosting.CheckArcRecord.Id != 0)
        //    {
        //        PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //        objPaymentPosting.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanID, objPaymentPosting.CheckArcRecord.Id);
        //    }
        //    //Added the for Messages
        //    return objPaymentPosting;
        //}

        //public PaymentPostingDTO GetCheckArcDetailsandSumofExistCheckArcs(ulong CarrierId, string PaymentId, ulong BatchId)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    objPaymentPosting.CheckArcRecord = GetCheckArcRecord(CarrierId, PaymentId, BatchId); //Added the BatchId as Additional parameter to get the CheckArc details on 20140521 Reported by Ekambaram
        //    objPaymentPosting.AmountAppliedInCheckArc = GetSumOfExistingCheckArcs(BatchId);
        //    return objPaymentPosting;
        //}

        //public decimal GetSumOfExistingCheckArcs(ulong BatchId)
        //{
        //    decimal dSum = 0;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Sum = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Batch_ID", BatchId))
        //           .SetProjection(Projections.Sum("Payment_Amount")).List<object>()[0];

        //        dSum = Convert.ToDecimal(Sum);
        //        iMySession.Close();
        //    }
        //    return dSum;
        //}

        //public ulong SaveCheckArcWithTransaction(IList<CheckArc> InsertList, string MacAddress)
        //{
        //    IList<CheckArc> CheckArcTemp = null;
        //    SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref CheckArcTemp, null, MacAddress, false, false, 0, "");
        //    return InsertList[0].Id;
        //}

        //public PaymentPostingDTO LoadCheckArcAndPPHeaderRecord(ulong CarrierId, string PaymentId, ulong HumanId, ulong BatchID) //Added the BatchId as Additional parameter to get the CheckArc details on 20140521 Reported by Ekambaram
        //{
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    objPaymentPostingDTO.CheckArcRecord = GetCheckArcRecord(CarrierId, PaymentId, BatchID); //Added the BatchId as Additional parameter to get the CheckArc details on 20140521 Reported by Ekambaram

        //    if (objPaymentPostingDTO.CheckArcRecord.Id != 0)
        //    {
        //        PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //        objPaymentPostingDTO.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanId, objPaymentPostingDTO.CheckArcRecord.Id);
        //    }

        //    return objPaymentPostingDTO;
        //}

        //public PaymentPostingDTO SaveCheckArcAndLoadPPHeader(IList<CheckArc> CheckArcList, ulong HumanId, string MacAddress)
        //{
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    ulong Id = SaveCheckArcWithTransaction(CheckArcList, MacAddress);
        //    objPaymentPostingDTO.CheckArcRecord = GetCheckArcbyId(Id);
        //    if (objPaymentPostingDTO.CheckArcRecord.Id != 0)
        //    {
        //        PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //        objPaymentPostingDTO.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanId, objPaymentPostingDTO.CheckArcRecord.Id);
        //    }

        //    return objPaymentPostingDTO;
        //}
        //public CheckArc GetCheckArcRecordForException(string sBatchName, ulong PaymentId, string sDOOS)
        //{
        //    CheckArc objCheckArc = new CheckArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Batch_Name", sBatchName))
        //            .Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("DOOS", sDOOS));

        //        if (crit.List<CheckArc>().Count != 0)
        //            objCheckArc = crit.List<CheckArc>()[0];
        //        iMySession.Close();
        //    }

        //    return objCheckArc;
        //}        
        //public IList<CheckArc> GetCheckArcRecordByBatchID(ulong BatchId)
        //{
        //    IList<CheckArc> ilstCheckArcList = new List<CheckArc>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Batch_ID", BatchId));

        //        if (crit.List<CheckArc>().Count != 0)
        //        {
        //            ilstCheckArcList = crit.List<CheckArc>();
        //        }

        //        if (ilstCheckArcList != null && ilstCheckArcList.Count != 0)
        //        {
        //            ilstCheckArcList = ilstCheckArcList.Where(a => a.Is_Delete != "Y").ToList<CheckArc>();
        //        }
        //        iMySession.Close();
        //    }
        //    return ilstCheckArcList;
        //}

        //public IList<CheckArc> GetCheckArcListByBatchName(string BatchName)
        //{
        //    IList<CheckArc> ilstCheckArcList = new List<CheckArc>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Batch_Name", BatchName));
        //        ilstCheckArcList= crit.List<CheckArc>();
        //        iMySession.Close();
        //    }
        //    return ilstCheckArcList;
        //}
        //public PaymentPostingDTO GetCarrierNameWithAmount(string PaymentId, ulong BatchId, ulong HumanID)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    //Added the BatchId as Additional parameter to get the CheckArc details on 20140521 Reported by Ekambaram
        //    objPaymentPosting.CheckArcList = GetCheckArcRecordUsingPaymentAndBatchID(PaymentId, BatchId);
        //    if (objPaymentPosting.CheckArcList.Count > 0 && objPaymentPosting.CheckArcList.Count == 1)
        //    {
        //        AccountTransactionManager objAccount = new AccountTransactionManager();
        //        if (objPaymentPosting.CheckArcList[0].Carrier_ID != 41)
        //            objPaymentPosting.AmountAppliedInCheckArc = objAccount.GetSumOfAmountAppliedForPatientsInCheckArc(objPaymentPosting.CheckArcList[0].Carrier_ID, PaymentId, BatchId);
        //        else
        //            objPaymentPosting.AmountAppliedInCheckArc = objAccount.GetSumOfAmountAppliedForPatientsInCheckArc(0, PaymentId, BatchId);
        //        //Added the  for Messages
        //        if (objPaymentPosting.CheckArcRecord.Id != 0)
        //        {
        //            PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //            objPaymentPosting.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanID, objPaymentPosting.CheckArcRecord.Id);
        //        }
        //    }
        //    //Added the for Messages
        //    return objPaymentPosting;
        //}
        //public IList<CheckArc> GetCheckArcRecordUsingPaymentAndBatchID(string PaymentId, ulong BatchId)
        //{
        //    IList<CheckArc> ilstCheckArcList = new List<CheckArc>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId));
        //        ilstCheckArcList= crit.List<CheckArc>();
        //        iMySession.Close();
        //    }
        //    return ilstCheckArcList;
        //}
        //public IList<CheckArc> GetCheckArcByCheckArcId(ulong CheckArcId)
        //{
        //    IList<CheckArc> ilstCheckArcList = new List<CheckArc>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Id", CheckArcId));
        //        ilstCheckArcList= crit.List<CheckArc>();
        //        iMySession.Close();
        //    }
        //    return ilstCheckArcList;
        //}                        
        //public CheckArc GetCheckArcRecordByCarrierIdAndPaymentType(ulong CarrierId, string PaymentId, ulong BatchId,string PaymentType)
        //{
        //    CheckArc objCheckArc = new CheckArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Carrier_ID", CarrierId)).Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId)).Add(Expression.Eq("Payment_Type", PaymentType));
        //        if (crit.List<CheckArc>().Count != 0)
        //            objCheckArc = crit.List<CheckArc>()[0];
        //        iMySession.Close();
        //    }

        //    return objCheckArc;
        //}
        //public PaymentPostingDTO GetCheckArcDetailsForPaymentPosting(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanID)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    objPaymentPosting.CheckArcList = GetCheckArcInformationByCarrierIdAndPaymentId(CarrierId, PaymentId, BatchId);
        //    AccountTransactionManager objAccount = new AccountTransactionManager();
        //    objPaymentPosting.AmountAppliedInCheckArc = objAccount.GetSumOfPostedAmountAppliedForPatientsInCheckArc(CarrierId, PaymentId, BatchId);
        //    /* Commanded By manimaran for here getting multiple CheckArc so we cannot able to pass correct CheckArc Id 
        //    //if (objPaymentPosting.CheckArcRecord.Id != 0)
        //    //{
        //    //    PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //    //    objPaymentPosting.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanID, objPaymentPosting.CheckArcRecord.Id);
        //    //}
        //     */
        //    return objPaymentPosting;
        //}
        //public IList<CheckArc> GetCheckArcInformationByCarrierIdAndPaymentId(ulong CarrierId, string PaymentId, ulong BatchId)
        //{
        //    IList<CheckArc> ilstCheckArcList = new List<CheckArc>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(CheckArc)).Add(Expression.Eq("Carrier_ID", CarrierId)).Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId));
        //        ilstCheckArcList= crit.List<CheckArc>();
        //        iMySession.Close();
        //    }
        //    return ilstCheckArcList;
        //}

        //#endregion
    }
}

