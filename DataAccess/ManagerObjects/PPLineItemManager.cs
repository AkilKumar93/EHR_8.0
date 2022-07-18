using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;
using NHibernate.Criterion;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPPLineItemManager : IManagerBase<PPLineItem, ulong>
    {
        PPLineItem GetPPLineItemFromId(ulong PPLineItemID, ulong EncounterId, bool ChargePosting);
        void BatchOperationsToApplyCopay(IList<PPLineItem> UpdatePPList, IList<PPLineItem> SavePPList, IList<AccountTransaction> SaveAccountList, decimal AccAmount, string Username, string MacAddress);
        PPLineItem GetPPLineItem(ulong PPLineID);
        //PaymentPostingDTO LoadPPLineAndAccountTransaction(ulong PPLineItemId);
        int UpdatePPLineItemAccountTransaction(IList<PPLineItem> PPLineItemList, IList<AccountTransaction> AccountTransactionList, ISession MySession, string MacAddress);
        int SavePaymentPostingPPLineTransactions(IList<PPLineItem> PPLineItemPositiveList, IList<AccountTransaction> AccountTransactionPositiveList,
            IList<PPLineItem> PPLineItemNegativeList, IList<AccountTransaction> AccountTransactionNegativeList,
            IList<PPLineItem> PPLineItemNegativeList2, IList<AccountTransaction> AccountTransactionNegativeList2,
            IList<PPLineItem> PPLineItemWriteOff1List, IList<AccountTransaction> AccountTransactionWriteOff1List,
            IList<PPLineItem> PPLineItemWriteOff2List, IList<AccountTransaction> AccountTransactionWriteOff2List, ISession MySession, string MacAddress);
        int SavePPLineItemWithoutTransaction(IList<PPLineItem> InsertList, IList<PPLineItem> UpdateList, ISession MySession, string MACAddress);
        void AppendUnappliedTransactions(Check objCheck, PPHeader objPPHeader, IList<Check> CheckList, IList<PPHeader> PPHeaderList, IList<PPLineItem> PPlineItemList, IList<AccountTransaction> AccountTransactionList, string ClaimType, ulong ChargeLineId, decimal TransactionAmount, string MacAddress, IList<PPLineItem> PPLineItemUpdateList, IList<AccountTransaction> AccTransUpdateList);
        //void AppendInterestTransactions(Check objCheck, PPHeader objPPHeader, IList<EOB> EobList, IList<Check> CheckList, IList<PPHeader> PPHeaderList, IList<PPLineItem> PPlineItemList, IList<AccountTransaction> AccountTransactionList, string ClaimType, ulong ChargeLineId, decimal TransactionAmount, string MacAddress, IList<ChargeLineItem> chargeLIist, IList<ChargeHeader> ChargeHeaderList, IList<BillTo> BillToList, IList<AccountTransaction> BillToAccTransLIst);
        //ChargePostingDTO GetPPLineItemList(ulong ulEncounterID, ulong ulHumanID);
        decimal GetPPLineItemAmount(ulong ulChargeLineItemID);
    }
    public partial class PPLineItemManager : ManagerBase<PPLineItem, ulong>, IPPLineItemManager
    {
        #region Constructors

        public PPLineItemManager()
            : base()
        {

        }
        public PPLineItemManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public int SavePPLineItemWithoutTransaction(IList<PPLineItem> InsertList, IList<PPLineItem> UpdateList, ISession MySession, string MACAddress)
        {
            int iResult = 0;

            if (InsertList != null)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref InsertList, UpdateList, null, MySession, MACAddress);
            }
            return iResult;
        }

        public PPLineItem GetPPLineItemFromId(ulong PPLineItemID, ulong EncounterId, bool ChargePosting)
        {
            PPLineItem objPP = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (ChargePosting == false)
                {
                    ICriteria crit = iMySession.CreateCriteria(typeof(PPLineItem)).Add(Expression.Eq("Id", PPLineItemID));
                    if (crit.List<PPLineItem>().Count > 0)
                        objPP = crit.List<PPLineItem>()[0];
                    iMySession.Close();
                    return objPP;
                }
                else
                {
                    ICriteria crit = iMySession.CreateCriteria(typeof(PPLineItem)).Add(Expression.Eq("Encounter_ID", EncounterId))
                        .Add(Expression.Eq("Charge_Line_Item_ID", 0)).AddOrder(Order.Asc("Id"));
                    if (crit.List<PPLineItem>().Count > 0)
                        objPP = crit.List<PPLineItem>()[0];
                    iMySession.Close();
                    return objPP;
                }
                
            }
            return objPP;
        }

        int iTryCount = 0;
        public void BatchOperationsToApplyCopay(IList<PPLineItem> UpdatePPList, IList<PPLineItem> SavePPList, IList<AccountTransaction> SaveAccountList, decimal AccAmount, string Username, string MacAddress)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            Boolean bResult = false;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            try
            {
                trans = MySession.BeginTransaction();
                if (UpdatePPList != null && UpdatePPList.Count > 0)
                {
                    iResult = SavePPLineItemWithoutTransaction(null, UpdatePPList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            //  MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                }

                if (SavePPList != null && SavePPList.Count > 0)
                {
                    iResult = SavePPLineItemWithoutTransaction(SavePPList, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                }

                if (SaveAccountList != null && SaveAccountList.Count > 0)
                {
                    AccountTransactionManager ObjAcc = new AccountTransactionManager();
                    iResult = ObjAcc.SaveAccountWithoutTransaction(SaveAccountList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                }
                AccountTransactionManager ObjAccMgr = new AccountTransactionManager();
                AccountTransaction objAccount = ObjAccMgr.GetAccountTransactionUsingPPIDAndSourceType(UpdatePPList[0].Id, "PP_LINE_ITEM");
                if (objAccount != null)
                {
                    objAccount.Amount = -AccAmount;
                    objAccount.Modified_By = Username;
                    objAccount.Modified_Date_And_Time = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);// DateTime.Now.ToUniversalTime();
                    IList<AccountTransaction> UpdateList = new List<AccountTransaction>();
                    UpdateList.Add(objAccount);
                    iResult = ObjAccMgr.UpdateAccountWithoutTransaction(UpdateList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                }

                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                MySession.Close();
            }
        }

        public PPLineItem GetPPLineItem(ulong PPLineItemID)
        {
            PPLineItem objPP = new PPLineItem();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(PPLineItem)).Add(Expression.Eq("Id", PPLineItemID));
                if (crit.List<PPLineItem>().Count > 0)
                    objPP = crit.List<PPLineItem>()[0];
                iMySession.Close();
            }
            return objPP;
        }

        //public PaymentPostingDTO LoadPPLineAndAccountTransaction(ulong PPLineItemId)
        //{
        //    PaymentPostingDTO objPaymentPostingDTO = new PaymentPostingDTO();
        //    objPaymentPostingDTO.PPLineItemList.Add(GetPPLineItem(PPLineItemId));

        //    if (objPaymentPostingDTO.PPLineItemList.Count == 0 || objPaymentPostingDTO.PPLineItemList[0].Id == 0)
        //        return objPaymentPostingDTO;

        //    AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
        //    objPaymentPostingDTO.AccountTransList.Add(objAccountTransactionManager.GetAccountTransactionUsingPPIDAndSourceType(objPaymentPostingDTO.PPLineItemList[0].Id, "PP_LINE_ITEM"));

        //    return objPaymentPostingDTO;
        //}

        public int UpdatePPLineItemAccountTransaction(IList<PPLineItem> PPLineItemList, IList<AccountTransaction> AccountTransactionList, ISession MySession, string MacAddress)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            Boolean bResult = false;

            //ISession MySession = Session.GetISession();
            //ITransaction trans = null;
            //try
            //{
            //    trans = MySession.BeginTransaction();
            if (PPLineItemList != null && PPLineItemList.Count > 0)
            {
                //IList<PPLineItem> SavePPLineList = null;
                //iResult = SaveUpdateDeleteWithoutTransaction(ref SavePPLineList, PPLineItemList, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }

            if (AccountTransactionList != null && AccountTransactionList.Count > 0)
            {
                AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                iResult = objAccountTransactionManager.UpdateAccountWithoutTransaction(AccountTransactionList, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }

            //    MySession.Flush();
            //    trans.Commit();
            //}
            //catch (NHibernate.Exceptions.GenericADOException ex)
            //{
            //    trans.Rollback();
            //    throw;
            //}
            //finally
            //{
            //    MySession.Close();
            //}
            return iResult;
        }

        public int SavePaymentPostingPPLineTransactions(IList<PPLineItem> PPLineItemPositiveList, IList<AccountTransaction> AccountTransactionPositiveList,
            IList<PPLineItem> PPLineItemNegativeList, IList<AccountTransaction> AccountTransactionNegativeList,
            IList<PPLineItem> PPLineItemNegativeList2, IList<AccountTransaction> AccountTransactionNegativeList2,
            IList<PPLineItem> PPLineItemWriteOff1List, IList<AccountTransaction> AccountTransactionWriteOff1List,
            IList<PPLineItem> PPLineItemWriteOff2List, IList<AccountTransaction> AccountTransactionWriteOff2List, ISession MySession, string MacAddress)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            Boolean bResult = false;

            //ISession MySession = Session.GetISession();
            //ITransaction trans = null;
            //try
            //{
            //    trans = MySession.BeginTransaction();
            if (PPLineItemPositiveList != null && PPLineItemPositiveList.Count > 0)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref PPLineItemPositiveList, null, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }

                if (AccountTransactionPositiveList != null && AccountTransactionPositiveList.Count > 0)
                {
                    AccountTransactionPositiveList[0].Bill_To_PP_Line_Item_ID = PPLineItemPositiveList[0].Id;
                    AccountTransactionPositiveList[0].PP_Header_ID = PPLineItemPositiveList[0].PP_Header_ID;
                    AccountTransactionPositiveList[0].Check_Table_Int_ID = PPLineItemPositiveList[0].Check_Table_Int_ID;
                }
            }
            if (AccountTransactionPositiveList != null && AccountTransactionPositiveList.Count > 0)
            {
                AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionPositiveList, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }
            if (PPLineItemNegativeList != null && PPLineItemNegativeList.Count > 0)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref PPLineItemNegativeList, null, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }

                if (AccountTransactionNegativeList != null && AccountTransactionNegativeList.Count > 0)
                {
                    AccountTransactionNegativeList[0].Bill_To_PP_Line_Item_ID = PPLineItemNegativeList[0].Id;
                    AccountTransactionNegativeList[0].PP_Header_ID = PPLineItemNegativeList[0].PP_Header_ID;
                    AccountTransactionNegativeList[0].Check_Table_Int_ID = PPLineItemNegativeList[0].Check_Table_Int_ID;
                }
            }
            if (AccountTransactionNegativeList != null && AccountTransactionNegativeList.Count > 0)
            {
                AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionNegativeList, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }
            if (PPLineItemNegativeList2 != null && PPLineItemNegativeList2.Count > 0)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref PPLineItemNegativeList2, null, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }

                if (AccountTransactionNegativeList2 != null && AccountTransactionNegativeList2.Count > 0)
                {
                    AccountTransactionNegativeList2[0].Bill_To_PP_Line_Item_ID = PPLineItemNegativeList2[0].Id;
                    AccountTransactionNegativeList2[0].PP_Header_ID = PPLineItemNegativeList2[0].PP_Header_ID;
                    AccountTransactionNegativeList2[0].Check_Table_Int_ID = PPLineItemNegativeList2[0].Check_Table_Int_ID;
                }
            }
            if (AccountTransactionNegativeList2 != null && AccountTransactionNegativeList2.Count > 0)
            {
                AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionNegativeList2, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }
            if (PPLineItemWriteOff1List != null && PPLineItemWriteOff1List.Count > 0)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref PPLineItemWriteOff1List, null, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }

                if (AccountTransactionWriteOff1List != null && AccountTransactionWriteOff1List.Count > 0)
                {
                    AccountTransactionWriteOff1List[0].Bill_To_PP_Line_Item_ID = PPLineItemWriteOff1List[0].Id;
                    AccountTransactionWriteOff1List[0].PP_Header_ID = PPLineItemWriteOff1List[0].PP_Header_ID;
                    AccountTransactionWriteOff1List[0].Check_Table_Int_ID = PPLineItemWriteOff1List[0].Check_Table_Int_ID;
                }
            }
            if (AccountTransactionWriteOff1List != null && AccountTransactionWriteOff1List.Count > 0)
            {
                AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionWriteOff1List, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }
            if (PPLineItemWriteOff2List != null && PPLineItemWriteOff2List.Count > 0)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref PPLineItemWriteOff2List, null, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }

                if (AccountTransactionWriteOff2List != null && AccountTransactionWriteOff2List.Count > 0)
                {
                    AccountTransactionWriteOff2List[0].Bill_To_PP_Line_Item_ID = PPLineItemWriteOff2List[0].Id;
                    AccountTransactionWriteOff2List[0].PP_Header_ID = PPLineItemWriteOff2List[0].PP_Header_ID;
                    AccountTransactionWriteOff2List[0].Check_Table_Int_ID = PPLineItemWriteOff2List[0].Check_Table_Int_ID;
                }
            }
            if (AccountTransactionWriteOff2List != null && AccountTransactionWriteOff2List.Count > 0)
            {
                AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionWriteOff2List, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        return iResult; ;
                    }
                }
                else if (iResult == 1)
                {
                    return iResult;
                }
            }
            //    MySession.Flush();
            //    trans.Commit();
            //}
            //catch (NHibernate.Exceptions.GenericADOException ex)
            //{
            //    trans.Rollback();
            //    throw;
            //}
            //finally
            //{
            //    MySession.Close();
            //}
            return iResult;
        }
        public void AppendUnappliedTransactions(Check objCheck, PPHeader objPPHeader, IList<Check> CheckList, IList<PPHeader> PPHeaderList, IList<PPLineItem> PPlineItemList, IList<AccountTransaction> AccountTransactionList, string ClaimType, ulong ChargeLineId, decimal TransactionAmount, string MacAddress, IList<PPLineItem> PPLineItemUpdateList, IList<AccountTransaction> AccTransUpdateList)//added   IList<Check> CheckList,IList<PPHeader> PPHeaderList on 20-dec-2013 for saving new check and payment details as per the 2.0 pseudo document
        {

            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            Boolean bResult = false;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            try
            {
                trans = MySession.BeginTransaction();
                //Added on 20-dec-2013 for saving the Payment Details if no previous record is found
                if (CheckList != null && CheckList.Count > 0)
                {
                    CheckManager CheckMngr = new CheckManager();
                    iResult = CheckMngr.SaveCheckWithoutTransaction(CheckList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            //  MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                    if (PPHeaderList != null && PPHeaderList.Count > 0)
                    {
                        PPHeaderList[0].Check_Table_Int_ID = CheckList[0].Id;
                    }
                    if (PPlineItemList != null && PPlineItemList.Count > 0)
                    {
                        PPlineItemList[0].Check_Table_Int_ID = CheckList[0].Id;
                    }
                    if (AccountTransactionList != null && AccountTransactionList.Count > 0)
                    {
                        AccountTransactionList[0].Check_Table_Int_ID = CheckList[0].Id;
                    }

                }
                if (PPHeaderList != null && PPHeaderList.Count > 0)
                {
                    PPHeaderManager PPHeaderMngr = new PPHeaderManager();
                    iResult = PPHeaderMngr.SavePPHeaderWithoutTransaction(PPHeaderList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            //  MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                    if (PPlineItemList != null && PPlineItemList.Count > 0)
                    {
                        PPlineItemList[0].PP_Header_ID = PPHeaderList[0].Id;
                    }
                }
                //Added on 20-dec-2013 for saving the Payment Details if no previous record is found
                if (PPlineItemList != null && PPlineItemList.Count > 0)
                {
                    iResult = SavePPLineItemWithoutTransaction(PPlineItemList, null, MySession, MacAddress);
                    if (PPlineItemList.Count > 0 && PPlineItemList != null)
                    {
                        AccountTransactionList[0].Bill_To_PP_Line_Item_ID = PPlineItemList[0].Id;
                    }
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                }

                if (AccountTransactionList != null && AccountTransactionList.Count > 0)
                {
                    AccountTransactionManager ObjAcc = new AccountTransactionManager();
                    iResult = ObjAcc.SaveAccountWithoutTransaction(AccountTransactionList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {

                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");

                        }
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }
                    if (PPHeaderList != null && PPHeaderList.Count > 0)
                    {
                        AccountTransactionList[0].PP_Header_ID = PPHeaderList[0].Id;
                    }
                }
                if (PPLineItemUpdateList != null && PPLineItemUpdateList.Count > 0)
                {
                    PPLineItemManager objPPLineItemManager = new PPLineItemManager();
                    iResult = objPPLineItemManager.UpdatePPLineItemAccountTransaction(PPLineItemUpdateList, AccTransUpdateList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                MySession.Close();
            }
        }
        //public void AppendInterestTransactions(Check objCheck, PPHeader objPPHeader, IList<EOB> EOBList, IList<Check> CheckList, IList<PPHeader> PPHeaderList, IList<PPLineItem> PPlineItemList, IList<AccountTransaction> AccountTransactionList, string ClaimType, ulong ChargeLineId, decimal TransactionAmount, string MacAddress, IList<ChargeLineItem> chargeLIist, IList<ChargeHeader> ChargeHeaderList, IList<BillTo> BillToList, IList<AccountTransaction> BillToAccTransLIst)//added  IList<EOB> EOBList, IList<Check> CheckList,IList<PPHeader> PPHeaderList on 20-dec-2013 for saving new check,eob and payment details as per the 2.0 pseudo document
        //{

        //    iTryCount = 0;

        //TryAgain:
        //    int iResult = 0;
        //    Boolean bResult = false;

        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();
        //        //Added on 20-dec-2013 for saving the Payment Details if no previous record is found as per the Document
        //        if (ChargeHeaderList != null && ChargeHeaderList.Count > 0)
        //        {
        //            ChargeHeaderManager ChargeHeaderMngr = new ChargeHeaderManager();
        //            iResult = ChargeHeaderMngr.SaveChargeHeaderWithoutTransaction(ChargeHeaderList, MySession, MacAddress);
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
        //            if (chargeLIist != null && chargeLIist.Count > 0)
        //            {
        //                chargeLIist[0].Charge_Header_ID = ChargeHeaderList[0].Id;
        //            }
        //        }


        //        if (CheckList != null && CheckList.Count > 0)
        //        {
        //            CheckManager CheckMngr = new CheckManager();
        //            iResult = CheckMngr.SaveCheckWithoutTransaction(CheckList, MySession, MacAddress);
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
        //            if (PPHeaderList != null && PPHeaderList.Count > 0)
        //            {
        //                PPHeaderList[0].Check_Table_Int_ID = CheckList[0].Id;
        //            }
        //            if (PPlineItemList != null && PPlineItemList.Count > 0)
        //            {
        //                PPlineItemList[0].Check_Table_Int_ID = CheckList[0].Id;
        //            }
        //            if (AccountTransactionList != null && AccountTransactionList.Count > 0)
        //            {
        //                AccountTransactionList[0].Check_Table_Int_ID = CheckList[0].Id;
        //            }

        //        }
        //        if (PPHeaderList != null && PPHeaderList.Count > 0)
        //        {
        //            PPHeaderManager PPHeaderMngr = new PPHeaderManager();
        //            iResult = PPHeaderMngr.SavePPHeaderWithoutTransaction(PPHeaderList, MySession, MacAddress);
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
        //            if (PPlineItemList != null && PPlineItemList.Count > 0)
        //            {
        //                PPlineItemList[0].PP_Header_ID = PPHeaderList[0].Id;
        //            }
        //             if (AccountTransactionList != null && AccountTransactionList.Count > 0)
        //            {
        //                AccountTransactionList[0].PP_Header_ID = PPHeaderList[0].Id;
        //            }
                    
        //        }
        //        //Added on 20-dec-2013 for saving the Payment Details if no previous record is found
        //        if (chargeLIist != null && chargeLIist.Count > 0)
        //        {
        //            ChargeLineItemManager objChargemgr = new ChargeLineItemManager();
        //            iResult = objChargemgr.SaveChargeLineItemWithoutTransactionforPP(ref chargeLIist, null, MySession, MacAddress);
        //            if (chargeLIist.Count > 0)
        //            {
        //                if (PPlineItemList != null && PPlineItemList.Count > 0)
        //                {
        //                    PPlineItemList[0].Charge_Line_Item_ID = chargeLIist[0].Id;
        //                }
        //                if (EOBList != null && EOBList.Count > 0)
        //                {
        //                    EOBList[0].Charge_Line_Item_ID = chargeLIist[0].Id;
        //                }
        //                if (BillToList != null && BillToList.Count > 0)
        //                {
        //                    BillToList[0].Charge_Line_Item_ID = chargeLIist[0].Id;
        //                    if (BillToAccTransLIst != null && BillToAccTransLIst.Count > 0)
        //                    {
        //                        BillToAccTransLIst[0].Charge_Line_Item_ID = BillToList[0].Charge_Line_Item_ID;
        //                    }
        //                }


        //            }
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
        //        if (BillToList != null && BillToList.Count > 0)
        //        {
        //            Bill_ToManager BillToMngr = new Bill_ToManager();
        //            iResult = BillToMngr.SaveVisitCoInsDedTransaction(BillToList, BillToAccTransLIst, null, null, MySession, MacAddress);
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
        //            if (chargeLIist != null && chargeLIist.Count > 0)
        //            {
        //                chargeLIist[0].Charge_Header_ID = ChargeHeaderList[0].Id;
        //            }
        //        }
        //        if (EOBList != null && EOBList.Count > 0)
        //        {
        //            EOBManager EobMngr = new EOBManager();
        //            iResult = EobMngr.SaveEOBWithoutTransaction(EOBList, MySession, MacAddress);
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
        //                // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");

        //            }
        //        }

        //        if (PPlineItemList != null && PPlineItemList.Count > 0)
        //        {
        //            iResult = SavePPLineItemWithoutTransaction(PPlineItemList, null, MySession, MacAddress);
        //            if (PPlineItemList.Count > 0 && PPlineItemList != null)
        //            {
        //                AccountTransactionList[0].Bill_To_PP_Line_Item_ID = PPlineItemList[0].Id;
        //                AccountTransactionList[0].Charge_Line_Item_ID = PPlineItemList[0].Charge_Line_Item_ID;
        //            }

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
        //        }

        //        if (AccountTransactionList != null && AccountTransactionList.Count > 0)
        //        {
        //            AccountTransactionManager ObjAcc = new AccountTransactionManager();
        //            iResult = ObjAcc.SaveAccountWithoutTransaction(AccountTransactionList, MySession, MacAddress);
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
        //}
        public void SavePPLineItemAccountTransactionReverse(IList<PPLineItem> PPLineItemList, IList<AccountTransaction> AccountTransactionList, IList<PPLineItem> ReversePPLineItemList, IList<AccountTransaction> ReverseAccountTransactionItemList, string MacAddress)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;
            Boolean bResult = false;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            try
            {
                trans = MySession.BeginTransaction();
                if (PPLineItemList != null && PPLineItemList.Count > 0)
                {
                    //IList<PPLineItem> SavePPLineList = null;
                    //iResult = SaveUpdateDeleteWithoutTransaction(ref PPLineItemList, null, null, MySession, MacAddress);
                    if (PPLineItemList.Count > 0 && PPLineItemList != null)
                    {
                        AccountTransactionList[0].Bill_To_PP_Line_Item_ID = PPLineItemList[0].Id;
                    }

                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }

                if (AccountTransactionList != null && AccountTransactionList.Count > 0)
                {
                    AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                    iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(AccountTransactionList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Exception is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (ReversePPLineItemList != null && ReversePPLineItemList.Count > 0)
                {
                    //IList<PPLineItem> SavePPLineList = null;
                    //iResult = SaveUpdateDeleteWithoutTransaction(ref ReversePPLineItemList, null, null, MySession, MacAddress);
                    if (ReversePPLineItemList.Count > 0 && ReversePPLineItemList != null)
                    {
                        ReverseAccountTransactionItemList[0].Bill_To_PP_Line_Item_ID = ReversePPLineItemList[0].Id;
                    }

                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Exception is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (ReverseAccountTransactionItemList != null && ReverseAccountTransactionItemList.Count > 0)
                {
                    AccountTransactionManager objAccountTransactionManager = new AccountTransactionManager();
                    iResult = objAccountTransactionManager.SaveAccountWithoutTransaction(ReverseAccountTransactionItemList, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Exception is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }

                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                MySession.Close();
            }
        }
        //public IList<PaymentPostingDTO> LoadUnAppliedTransactionAmount(int human_id)
        //{

        //    ArrayList UnAppliedLIst;
        //    IList<PaymentPostingDTO> UnappliedList = new List<PaymentPostingDTO>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery UnAppliedquery = iMySession.GetNamedQuery("Get.UnAppliedAmount");
        //        UnAppliedquery.SetString(0, human_id.ToString());
        //        UnAppliedLIst = new ArrayList(UnAppliedquery.List());
               
        //        for (int i = 0; i < UnAppliedLIst.Count; i++)
        //        {
        //            PaymentPostingDTO objPayment = new PaymentPostingDTO();
        //            object[] obj = (object[])UnAppliedLIst[i];
        //            if (obj[0] != null)
        //                objPayment.PPLineItemRecord.Created_Date_And_Time = Convert.ToDateTime(obj[0]);
        //            if (obj[1] != null)
        //                objPayment.sCarrierName = obj[1].ToString();
        //            if (obj[4] != null)
        //                objPayment.PPLineItemRecord.Batch_Name = obj[4].ToString();
        //            if (obj[2] != null)
        //                objPayment.PPLineItemRecord.Unapplied_DOS = Convert.ToDateTime(obj[2]);
        //            if (obj[3] != null)
        //                objPayment.sPhyName = obj[3].ToString();
        //            if (obj[5] != null)
        //                objPayment.PPLineItemRecord.Comments = obj[5].ToString();
        //            if (obj[6] != null)
        //                objPayment.PPLineItemRecord.Payment_ID = Convert.ToString(obj[6]);
        //            if (obj[7] != null)
        //                objPayment.PPLineItemRecord.Amount = Convert.ToDecimal(obj[7]);
        //            if (obj[8] != null)
        //                objPayment.PPLineItemRecord.Id = Convert.ToUInt64(obj[8]);
        //            if (obj[9] != null)
        //                objPayment.PPLineItemRecord.Check_Table_Int_ID = Convert.ToUInt64(obj[9]);
        //            if (obj[10] != null)
        //                objPayment.PPLineItemRecord.Batch_ID = Convert.ToUInt64(obj[10]);
        //            if (obj[11] != null)
        //                objPayment.PPLineItemRecord.Carrier_ID = Convert.ToUInt64(obj[11]);
        //            UnappliedList.Add(objPayment);
        //        }
        //        CheckManager objCheckMngr = new CheckManager();
        //        // objCheckMngr.GetCheckbyId()
        //        iMySession.Close();
        //    }
        //    return UnappliedList;
        //}

        //public ChargePostingDTO GetPPLineItemList(ulong ulEncounterID, ulong ulHumanID)
        //{
        //    //IList<PPLineItem> PPLineItemList = new List<PPLineItem>();
        //    //ICriteria crit;
        //    ulong ulChargeLineItemID = 0;

        //    //if (ulEncounterID > 0)
        //    //{
        //    //    crit = session.GetISession().CreateCriteria(typeof(PPLineItem)).Add(Expression.Eq("Encounter_ID", ulEncounterID)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Charge_Line_Item_ID", ulChargeLineItemID));
        //    //}
        //    //else
        //    //{
        //    //    crit = session.GetISession().CreateCriteria(typeof(PPLineItem)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Charge_Line_Item_ID", ulChargeLineItemID));
        //    //}

        //    //PPLineItemList = crit.List<PPLineItem>();

        //    //return PPLineItemList;

        //    ChargePostingDTO objChargePostingDTO = new ChargePostingDTO();
        //    ISQLQuery sql;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        if (ulEncounterID > 0)
        //        {
        //            sql = iMySession.CreateSQLQuery("select p.*,v.* from pp_line_item p,visit_payment v where p.encounter_id=v.encounter_id and p.human_id=v.human_id and p.visit_payment_id=v.visit_payment_id and p.encounter_id=" + ulEncounterID + " and p.human_id=" + ulHumanID + " and p.charge_line_item_id=" + ulChargeLineItemID + " and p.amount>0;")
        //              .AddEntity("p", typeof(PPLineItem)).AddEntity("v", typeof(VisitPayment));
        //        }
        //        else
        //        {
        //            sql = iMySession.CreateSQLQuery("select p.*,v.* from pp_line_item p,visit_payment v where p.human_id=v.human_id and p.visit_payment_id=v.visit_payment_id and p.human_id=" + ulHumanID + " and p.charge_line_item_id=" + ulChargeLineItemID + " and p.amount>0;")
        //              .AddEntity("p", typeof(PPLineItem)).AddEntity("v", typeof(VisitPayment));
        //        }

        //        if (sql.List().Count > 0)
        //        {
        //            foreach (IList<Object> l in sql.List())
        //            {
        //                PPLineItem PPLineItemRecord = (PPLineItem)l[0];
        //                VisitPayment VisitPmtRecord = (VisitPayment)l[1];

        //                objChargePostingDTO.PP_Line_Item_List.Add(PPLineItemRecord);
        //                objChargePostingDTO.Visit_Payment_List.Add(VisitPmtRecord);
        //            }
        //        }
        //        iMySession.Close();
        //    }

        //    return objChargePostingDTO;
        //}

        public decimal GetPPLineItemAmount(ulong ulChargeLineItemID)
        {
            ArrayList arylst = new ArrayList();
            decimal deAppliedAmount = 0;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query1 = iMySession.GetNamedQuery("Get.ChargeLineItems.With.Balance");
                query1.SetInt32(0, Convert.ToInt32(ulChargeLineItemID));

                arylst.AddRange(query1.List());

                for (int i = 0; i < arylst.Count; i++)
                {
                    deAppliedAmount = Convert.ToUInt32(arylst[i]);                   
                }
                iMySession.Close();
            }

            return deAppliedAmount;
        }
        #endregion
    }
}
