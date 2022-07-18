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
    public partial interface ICheckManager : IManagerBase<Check, ulong>
    {
        //PaymentPostingDTO GetCheckDetailsForPP(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanId,string PaymentType);
        Check GetCheckRecord(ulong CarrierId, string PaymentId, ulong BatchId);
        IList<Check> GetCheckRecordByBatchID(ulong BatchId);
        decimal GetSumOfExistingChecks(ulong BatchId);
        //PaymentPostingDTO GetCheckDetailsandSumofExistChecks(ulong CarrierId, string PaymentId, ulong BatchId);
        ulong SaveCheckWithTransaction(IList<Check> InsertList, string MacAddress);
        //PaymentPostingDTO LoadCheckAndPPHeaderRecord(ulong CarrierId, string PaymentId, ulong HumanId, ulong BatchID);
        Check GetCheckbyId(ulong CheckId);
        //PaymentPostingDTO SaveCheckAndLoadPPHeader(IList<Check> CheckList, ulong HumanId, string MACAddress);
        int SaveCheckWithoutTransaction(IList<Check> InsertList, ISession MySession, string MACAddress);                
        IList<Check> GetCheckListByBatchName(string BatchName);
        IList<Check> GetCheckRecordUsingPaymentAndBatchID(string PaymentId, ulong BatchId);
        //PaymentPostingDTO GetCarrierNameWithAmount(string PaymentId, ulong BatchId, ulong HumanID);
        IList<Check> GetCheckByCheckId(ulong CheckId);                
        Check GetCheckRecordByCarrierIdAndPaymentType(ulong CarrierId, string PaymentId, ulong BatchId, string PaymentType);
        //PaymentPostingDTO GetCheckDetailsForPaymentPosting(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanID);
        IList<Check> GetCheckInformationByCarrierIdAndPaymentId(ulong CarrierId, string PaymentId, ulong BatchId);
    }
    public partial class CheckManager : ManagerBase<Check, ulong>, ICheckManager
    {
        #region Constructors

        public CheckManager()
            : base()
        {

        }
        public CheckManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public int SaveCheckWithoutTransaction(IList<Check> InsertList, ISession MySession, string MACAddress)
        {
            int iResult = 0;
            IList<Check> CheckTemp = null;
            GenerateXml ObjXML = null;
            if ((InsertList != null))
            {
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref InsertList, ref CheckTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
            }
            return iResult;

        }
        public Check GetCheckRecord(ulong CarrierId, string PaymentId, ulong BatchId)
        {
            Check objCheck = new Check();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Carrier_ID", CarrierId))
                    .Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId));//

                if (crit.List<Check>().Count != 0)
                    objCheck = crit.List<Check>()[0];
                iMySession.Close();
            }
            return objCheck;
        }

        public Check GetCheckbyId(ulong CheckId)
        {
            Check objCheck = new Check();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Id", CheckId));
                if (crit.List<Check>().Count != 0)
                    objCheck = crit.List<Check>()[0];
                iMySession.Close();
            }

            return objCheck;
        }

        //public PaymentPostingDTO GetCheckDetailsForPP(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanID,string PaymentType)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //    if (PaymentType != string.Empty)
        //    {
        //        objPaymentPosting.CheckRecord = GetCheckRecordByCarrierIdAndPaymentType(CarrierId, PaymentId, BatchId,PaymentType);
        //    }
        //    else
        //    {
        //    objPaymentPosting.CheckRecord = GetCheckRecord(CarrierId, PaymentId, BatchId);
        //    }

        //    AccountTransactionManager objAccount = new AccountTransactionManager();
        //    if (CarrierId != 41)
        //        objPaymentPosting.AmountAppliedInCheck = objAccount.GetSumOfAmountAppliedForPatientsInCheck(CarrierId, PaymentId, BatchId);
        //    else
        //        objPaymentPosting.AmountAppliedInCheck = objAccount.GetSumOfAmountAppliedForPatientsInCheck(0, PaymentId, BatchId);
        //    //Added the  for Messages
        //    if (objPaymentPosting.CheckRecord.Id != 0)
        //    {
        //        PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //        objPaymentPosting.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanID, objPaymentPosting.CheckRecord.Id);
        //    }
        //    //Added the for Messages
        //    return objPaymentPosting;
        //}

        //public PaymentPostingDTO GetCheckDetailsandSumofExistChecks(ulong CarrierId, string PaymentId, ulong BatchId)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    objPaymentPosting.CheckRecord = GetCheckRecord(CarrierId, PaymentId, BatchId); //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //    objPaymentPosting.AmountAppliedInCheck = GetSumOfExistingChecks(BatchId);
        //    return objPaymentPosting;
        //}

        public decimal GetSumOfExistingChecks(ulong BatchId)
        {
            decimal dSum = 0;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                object Sum = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Batch_ID", BatchId))
                   .SetProjection(Projections.Sum("Payment_Amount")).List<object>()[0];

                dSum = Convert.ToDecimal(Sum);
                iMySession.Close();
            }
            return dSum;
        }

        public ulong SaveCheckWithTransaction(IList<Check> InsertList, string MacAddress)
        {
            IList<Check> CheckTemp = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref CheckTemp, null, MacAddress, false, false, 0, "");
            return InsertList[0].Id;
        }

        //public PaymentPostingDTO LoadCheckAndPPHeaderRecord(ulong CarrierId, string PaymentId, ulong HumanId, ulong BatchID) //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //{
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    objPaymentPostingDTO.CheckRecord = GetCheckRecord(CarrierId, PaymentId, BatchID); //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram

        //    if (objPaymentPostingDTO.CheckRecord.Id != 0)
        //    {
        //        PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //        objPaymentPostingDTO.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanId, objPaymentPostingDTO.CheckRecord.Id);
        //    }

        //    return objPaymentPostingDTO;
        //}

        //public PaymentPostingDTO SaveCheckAndLoadPPHeader(IList<Check> CheckList, ulong HumanId, string MacAddress)
        //{
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    ulong Id = SaveCheckWithTransaction(CheckList, MacAddress);
        //    objPaymentPostingDTO.CheckRecord = GetCheckbyId(Id);
        //    if (objPaymentPostingDTO.CheckRecord.Id != 0)
        //    {
        //        PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //        objPaymentPostingDTO.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanId, objPaymentPostingDTO.CheckRecord.Id);
        //    }

        //    return objPaymentPostingDTO;
        //}
        public Check GetCheckRecordForException(string sBatchName, ulong PaymentId, string sDOOS)
        {
            Check objCheck = new Check();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Batch_Name", sBatchName))
                    .Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("DOOS", sDOOS));

                if (crit.List<Check>().Count != 0)
                    objCheck = crit.List<Check>()[0];
                iMySession.Close();
            }

            return objCheck;
        }        
        public IList<Check> GetCheckRecordByBatchID(ulong BatchId)
        {
            IList<Check> ilstCheckList = new List<Check>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Batch_ID", BatchId));

                if (crit.List<Check>().Count != 0)
                {
                    ilstCheckList = crit.List<Check>();
                }

                if (ilstCheckList != null && ilstCheckList.Count != 0)
                {
                    ilstCheckList = ilstCheckList.Where(a => a.Is_Delete != "Y").ToList<Check>();
                }
                iMySession.Close();
            }
            return ilstCheckList;
        }

        public IList<Check> GetCheckListByBatchName(string BatchName)
        {
            IList<Check> ilstCheckList = new List<Check>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Batch_Name", BatchName));
                ilstCheckList= crit.List<Check>();
                iMySession.Close();
            }
            return ilstCheckList;
        }
        //public PaymentPostingDTO GetCarrierNameWithAmount(string PaymentId, ulong BatchId, ulong HumanID)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //    objPaymentPosting.CheckList = GetCheckRecordUsingPaymentAndBatchID(PaymentId, BatchId);
        //    if (objPaymentPosting.CheckList.Count > 0 && objPaymentPosting.CheckList.Count == 1)
        //    {
        //        AccountTransactionManager objAccount = new AccountTransactionManager();
        //        if (objPaymentPosting.CheckList[0].Carrier_ID != 41)
        //            objPaymentPosting.AmountAppliedInCheck = objAccount.GetSumOfAmountAppliedForPatientsInCheck(objPaymentPosting.CheckList[0].Carrier_ID, PaymentId, BatchId);
        //        else
        //            objPaymentPosting.AmountAppliedInCheck = objAccount.GetSumOfAmountAppliedForPatientsInCheck(0, PaymentId, BatchId);
        //        //Added the  for Messages
        //        if (objPaymentPosting.CheckRecord.Id != 0)
        //        {
        //            PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //            objPaymentPosting.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanID, objPaymentPosting.CheckRecord.Id);
        //        }
        //    }
        //    //Added the for Messages
        //    return objPaymentPosting;
        //}
        public IList<Check> GetCheckRecordUsingPaymentAndBatchID(string PaymentId, ulong BatchId)
        {
            IList<Check> ilstCheckList = new List<Check>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId));
                ilstCheckList= crit.List<Check>();
                iMySession.Close();
            }
            return ilstCheckList;
        }
        public IList<Check> GetCheckByCheckId(ulong CheckId)
        {
            IList<Check> ilstCheckList = new List<Check>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Id", CheckId));
                ilstCheckList= crit.List<Check>();
                iMySession.Close();
            }
            return ilstCheckList;
        }                        
        public Check GetCheckRecordByCarrierIdAndPaymentType(ulong CarrierId, string PaymentId, ulong BatchId,string PaymentType)
        {
            Check objCheck = new Check();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Carrier_ID", CarrierId)).Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId)).Add(Expression.Eq("Payment_Type", PaymentType));
                if (crit.List<Check>().Count != 0)
                    objCheck = crit.List<Check>()[0];
                iMySession.Close();
            }

            return objCheck;
        }
        //public PaymentPostingDTO GetCheckDetailsForPaymentPosting(ulong CarrierId, string PaymentId, ulong BatchId, ulong HumanID)
        //{
        //    PaymentPostingDTO objPaymentPosting = new PaymentPostingDTO();
        //    objPaymentPosting.CheckList = GetCheckInformationByCarrierIdAndPaymentId(CarrierId, PaymentId, BatchId);
        //    AccountTransactionManager objAccount = new AccountTransactionManager();
        //    objPaymentPosting.AmountAppliedInCheck = objAccount.GetSumOfPostedAmountAppliedForPatientsInCheck(CarrierId, PaymentId, BatchId);
        //    /* Commanded By manimaran for here getting multiple check so we cannot able to pass correct check Id 
        //    //if (objPaymentPosting.CheckRecord.Id != 0)
        //    //{
        //    //    PPHeaderManager objPPHeaderManager = new PPHeaderManager();
        //    //    objPaymentPosting.PPHeaderRecord = objPPHeaderManager.GetPPHeaderRecord(HumanID, objPaymentPosting.CheckRecord.Id);
        //    //}
        //     */
        //    return objPaymentPosting;
        //}
        public IList<Check> GetCheckInformationByCarrierIdAndPaymentId(ulong CarrierId, string PaymentId, ulong BatchId)
        {
            IList<Check> ilstCheckList = new List<Check>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Check)).Add(Expression.Eq("Carrier_ID", CarrierId)).Add(Expression.Eq("Payment_ID", PaymentId)).Add(Expression.Eq("Batch_ID", BatchId));
                ilstCheckList= crit.List<Check>();
                iMySession.Close();
            }
            return ilstCheckList;
        }

        #endregion
    }
}

