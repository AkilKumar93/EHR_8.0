using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPPHeaderArcManager : IManagerBase<PPHeaderArc, ulong>
    {
        //PPHeaderArc GetPPHeaderArcRecord(ulong HumanId, ulong CheckId);
        //PPHeaderArc GetPPHeaderArcById(ulong Id);
        //PPHeaderArc SavePPHeaderArcWithTransaction(IList<PPHeaderArc> PPHeaderArcList, string MACAddress);
        //int SavePPHeaderArcWithoutTransaction(IList<PPHeaderArc> InsertList, ISession MySession, string MACAddress);
        //IList<decimal> GetTotalandAppliedForPatient(ulong HumanId, ulong CarrierID, string PaymentID,ulong BatchID);
    }
    public partial class PPHeaderArcManager : ManagerBase<PPHeaderArc, ulong>, IPPHeaderArcManager
    {
        #region Constructors

        public PPHeaderArcManager()
            : base()
        {

        }
        public PPHeaderArcManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //#region Methods

        //public int SavePPHeaderArcWithoutTransaction(IList<PPHeaderArc> InsertList, ISession MySession, string MACAddress)
        //{
        //    int iResult = 0;

        //    if ((InsertList != null))
        //    {
        //        //iResult = SaveUpdateDeleteWithoutTransaction(ref InsertList, null, null, MySession, MACAddress);
        //    }
        //    return iResult;

        //}

        //public PPHeaderArc GetPPHeaderArcRecord(ulong HumanId, ulong CheckId)
        //{
        //    PPHeaderArc objPPHeaderArc = new PPHeaderArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(PPHeaderArc)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Check_Table_Int_ID", CheckId));
        //        if (crit.List<PPHeaderArc>().Count != 0)
        //            objPPHeaderArc = crit.List<PPHeaderArc>()[0];
        //        iMySession.Close();
        //    }

        //    return objPPHeaderArc;
        //}

        //public PPHeaderArc GetPPHeaderArcById(ulong Id)
        //{
        //    PPHeaderArc objPPHeaderArc = new PPHeaderArc();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(PPHeaderArc)).Add(Expression.Eq("Id", Id));
        //        if (crit.List<PPHeaderArc>().Count != 0)
        //            objPPHeaderArc = crit.List<PPHeaderArc>()[0];
        //        iMySession.Close();
        //    }

        //    return objPPHeaderArc;
        //}

        //public PPHeaderArc SavePPHeaderArcWithTransaction(IList<PPHeaderArc> PPHeaderArcList, string MACAddress)
        //{
        //    //SaveUpdateDeleteWithTransaction(ref PPHeaderArcList, null, null, MACAddress);
        //    return GetPPHeaderArcById(PPHeaderArcList[0].Id);
        //}
        //public IList<decimal> GetTotalandAppliedForPatient(ulong HumanId, ulong CarrierID, string PaymentID,ulong BatchID) //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //{
        //    decimal deTotalPaymentAmountForPatient = 0;
        //    CheckManager CheckMngr = new CheckManager();
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    objPaymentPostingDTO.CheckRecord = CheckMngr.GetCheckRecord(CarrierID, PaymentID,BatchID); //Added the BatchId as Additional parameter to get the check details on 20140521 Reported by Ekambaram
        //    PPHeaderArc objPPHeaderArc = new PPHeaderArc();
        //    decimal deTotalAppliedAmount = 0;
        //    decimal dSum = 0;
        //    IList<decimal> listTotalAndApplied = null;
        //    if (objPaymentPostingDTO.CheckRecord.Id != 0)
        //    {
        //        using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //        {
        //            ICriteria crit = iMySession.CreateCriteria(typeof(PPHeaderArc)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Check_Table_Int_ID", objPaymentPostingDTO.CheckRecord.Id));
        //            if (crit.List<PPHeaderArc>().Count != 0)
        //            {
        //                objPPHeaderArc = crit.List<PPHeaderArc>()[0];
        //                //applied amount= sumoffrow from acccount trans where acct.PPHeaderArc id=objPPHeaderArc.id and source type=pp line and linetye <>writeoff
        //                //if(transaction amount>objPPHeaderArc.Total_Payment-appliedAmount)
        //                //{
        //                //}
        //                object Sum = iMySession.CreateCriteria(typeof(AccountTransaction)).Add(Expression.Eq("PP_Header_ID", objPPHeaderArc.Id))
        //           .Add(Expression.Eq("Source_Type", "PP_LINE_ITEM")).Add(!Expression.Eq("Line_Type", "WRITEOFF")).
        //               SetProjection(Projections.Sum("Amount")).List<object>()[0];

        //                dSum = objPPHeaderArc.Total_Payment - ((0 - Convert.ToDecimal(Sum)));

        //                deTotalAppliedAmount = dSum;
        //                deTotalPaymentAmountForPatient = objPPHeaderArc.Total_Payment;
        //                listTotalAndApplied = new List<decimal>();
        //                listTotalAndApplied.Add(deTotalPaymentAmountForPatient);
        //                listTotalAndApplied.Add(deTotalAppliedAmount);

        //            }
        //            iMySession.Close();
        //        }

        //    }
        //    return listTotalAndApplied;
        //}

        //#endregion
    }
}
