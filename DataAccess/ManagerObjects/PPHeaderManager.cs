using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPPHeaderManager : IManagerBase<PPHeader, ulong>
    {
        PPHeader GetPPHeaderRecord(ulong HumanId, ulong CheckId);
        PPHeader GetPPHeaderById(ulong Id);
        PPHeader SavePPHeaderWithTransaction(IList<PPHeader> PPHeaderList, string MACAddress);
        int SavePPHeaderWithoutTransaction(IList<PPHeader> InsertList, ISession MySession, string MACAddress);
        //IList<decimal> GetTotalandAppliedForPatient(ulong HumanId, ulong CarrierID, string PaymentID,ulong BatchID);
    }
    public partial class PPHeaderManager : ManagerBase<PPHeader, ulong>, IPPHeaderManager
    {
        #region Constructors

        public PPHeaderManager()
            : base()
        {

        }
        public PPHeaderManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public int SavePPHeaderWithoutTransaction(IList<PPHeader> InsertList, ISession MySession, string MACAddress)
        {
            int iResult = 0;

            if ((InsertList != null))
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref InsertList, null, null, MySession, MACAddress);
            }
            return iResult;

        }

        public PPHeader GetPPHeaderRecord(ulong HumanId, ulong CheckId)
        {
            PPHeader objPPHeader = new PPHeader();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(PPHeader)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Check_Table_Int_ID", CheckId));
                if (crit.List<PPHeader>().Count != 0)
                    objPPHeader = crit.List<PPHeader>()[0];
                iMySession.Close();
            }

            return objPPHeader;
        }

        public PPHeader GetPPHeaderById(ulong Id)
        {
            PPHeader objPPHeader = new PPHeader();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(PPHeader)).Add(Expression.Eq("Id", Id));
                if (crit.List<PPHeader>().Count != 0)
                    objPPHeader = crit.List<PPHeader>()[0];
                iMySession.Close();
            }

            return objPPHeader;
        }

        public PPHeader SavePPHeaderWithTransaction(IList<PPHeader> PPHeaderList, string MACAddress)
        {
            //SaveUpdateDeleteWithTransaction(ref PPHeaderList, null, null, MACAddress);
            return GetPPHeaderById(PPHeaderList[0].Id);
        }
        //public IList<decimal> GetTotalandAppliedForPatient(ulong HumanId, ulong CarrierID, string PaymentID,ulong BatchID) //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //{
        //    decimal deTotalPaymentAmountForPatient = 0;
        //    CheckManager CheckMngr = new CheckManager();
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    objPaymentPostingDTO.CheckRecord = CheckMngr.GetCheckRecord(CarrierID, PaymentID,BatchID); //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //    PPHeader objPPHeader = new PPHeader();
        //    decimal deTotalAppliedAmount = 0;
        //    decimal dSum = 0;
        //    IList<decimal> listTotalAndApplied = null;
        //    if (objPaymentPostingDTO.CheckRecord.Id != 0)
        //    {
        //        using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //        {
        //            ICriteria crit = iMySession.CreateCriteria(typeof(PPHeader)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Check_Table_Int_ID", objPaymentPostingDTO.CheckRecord.Id));
        //            if (crit.List<PPHeader>().Count != 0)
        //            {
        //                objPPHeader = crit.List<PPHeader>()[0];
        //                //applied amount= sumoffrow from acccount trans where acct.ppheader id=objppheader.id and source type=pp line and linetye <>writeoff
        //                //if(transaction amount>objPPHeader.Total_Payment-appliedAmount)
        //                //{
        //                //}
        //                object Sum = iMySession.CreateCriteria(typeof(AccountTransaction)).Add(Expression.Eq("PP_Header_ID", objPPHeader.Id))
        //           .Add(Expression.Eq("Source_Type", "PP_LINE_ITEM")).Add(!Expression.Eq("Line_Type", "WRITEOFF")).
        //               SetProjection(Projections.Sum("Amount")).List<object>()[0];

        //                dSum = objPPHeader.Total_Payment - ((0 - Convert.ToDecimal(Sum)));

        //                deTotalAppliedAmount = dSum;
        //                deTotalPaymentAmountForPatient = objPPHeader.Total_Payment;
        //                listTotalAndApplied = new List<decimal>();
        //                listTotalAndApplied.Add(deTotalPaymentAmountForPatient);
        //                listTotalAndApplied.Add(deTotalAppliedAmount);

        //            }
        //            iMySession.Close();
        //        }

        //    }
        //    return listTotalAndApplied;
        //}

        #endregion
    }
}
