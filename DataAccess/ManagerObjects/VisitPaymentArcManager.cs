using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public interface IVisitPaymentArcManager : IManagerBase<VisitPaymentArc, ulong>
    {        
        //IList<VisitPaymentDTO> SaveVisitPaymentArc(ulong EncounterID, IList<VisitPaymentArc> VisitPaymentArcList, IList<Check> SaveCheckList, IList<PPHeader> SavePPHeaderList, IList<PPLineItem> SavePPLineItemList, IList<AccountTransaction> SaveAccountList, string MACAddress);
        //int SaveVisitPaymentArcWithoutTransaction(IList<VisitPaymentArc> ListToInsert, ISession MySession, string MACAddress);IList<VisitPaymentDTO> UpdateVisitPaymentArc(IList<VisitPaymentArc> UpdateVisit, IList<CheckArc> UpdateCheck, IList<PPHeaderArc> UpdatePPHeader, IList<PPLineItemArc> UpdatePPLine, IList<AccountTransactionArc> UpdateAccTrans, IList<AccountTransactionArc> SaveAccTrans, ulong EncounterID);IList<VisitPaymentDTO> UpdateVisitPaymentArc(IList<VisitPaymentArc> UpdateVisit, IList<CheckArc> UpdateCheck, IList<PPHeaderArc> UpdatePPHeader, IList<PPLineItemArc> UpdatePPLine, IList<AccountTransactionArc> UpdateAccTrans, IList<AccountTransactionArc> SaveAccTrans, ulong EncounterID);
        //IList<VisitPaymentDTO> UpdateVisitPaymentArc(IList<VisitPaymentArc> UpdateVisit, IList<Check> UpdateCheck, IList<PPHeader> UpdatePPHeader, IList<PPLineItem> UpdatePPLine, IList<AccountTransaction> UpdateAccTrans,IList<AccountTransaction> SaveAccTrans, ulong EncounterID);
        IList<VisitPaymentDTO> SaveVisitPaymentArc(ulong EncounterID, IList<VisitPaymentArc> VisitPaymentList, IList<CheckArc> SaveCheckList, IList<PPHeaderArc> SavePPHeaderList, IList<PPLineItemArc> SavePPLineItemList, IList<AccountTransactionArc> SaveAccountList, IList<VisitPaymentHistoryArc> SaveVisitPaymentHistoryArcList, string MACAddress);
        IList<VisitPaymentDTO> UpdateVisitPaymentArc(IList<VisitPaymentArc> UpdateVisit, IList<CheckArc> UpdateCheck, IList<PPHeaderArc> UpdatePPHeader, IList<PPLineItemArc> UpdatePPLine, IList<AccountTransactionArc> UpdateAccTrans, IList<AccountTransactionArc> SaveAccTrans, IList<VisitPaymentHistoryArc> SaveVisitPaymentHistoryArcList, ulong EncounterID);
    }
    public partial class VisitPaymentArcManager : ManagerBase<VisitPaymentArc, ulong>, IVisitPaymentArcManager
    {
        #region Constructors

        public VisitPaymentArcManager()
            : base()
        {

        }
        public VisitPaymentArcManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //#region Methods        

        int iTryCount = 0;
        //public IList<VisitPaymentDTO> SaveVisitPaymentArc(ulong EncounterID, IList<VisitPaymentArc> VisitPaymentArcList, IList<Check> SaveCheckList, IList<PPHeader> SavePPHeaderList, IList<PPLineItem> SavePPLineItemList, IList<AccountTransaction> SaveAccountList, string MACAddress)
        //{
        //    iTryCount = 0;

        //TryAgain:
        //    int iResult = 0;

        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    GenerateXml ObjXML = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();                
        //        if (VisitPaymentArcList != null && VisitPaymentArcList.Count > 0)
        //        {
        //            IList<VisitPaymentArc> VisitPaymentArcTemp = null;
        //            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref VisitPaymentArcList, ref VisitPaymentArcTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);                    

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
        //                  //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");

        //                }
        //            }
        //            else if (iResult == 1)
        //            {

        //                trans.Rollback();
        //             //   MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");

        //            }


        //            CheckManager objCheck = new CheckManager();
        //            IList<Check> CheckTemp = null;
        //            iResult = objCheck.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveCheckList, ref CheckTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
        //            //iResult = objCheck.SaveCheckWithoutTransaction(SaveCheckList, MySession, MACAddress);

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
        //                  //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");

        //                }
        //            }
        //            else if (iResult == 1)
        //            {

        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");

        //            }


        //            SavePPHeaderList[0].Payment_ID = SaveCheckList[0].Payment_ID;
        //            SavePPHeaderList[0].Check_Table_Int_ID = SaveCheckList[0].Id;

        //            PPHeaderManager objPPHeader = new PPHeaderManager();
        //            //iResult = objPPHeader.SavePPHeaderWithoutTransaction(SavePPHeaderList, MySession, MACAddress);
        //            IList<PPHeader> PPHeaderTemp = null;
        //            iResult = objPPHeader.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SavePPHeaderList, ref PPHeaderTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
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
        //                   // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");

        //                }
        //            }
        //            else if (iResult == 1)
        //            {

        //                trans.Rollback();
        //              //  MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");

        //            }


        //            SavePPLineItemList[0].PP_Header_ID = SavePPHeaderList[0].Id;
        //            SavePPLineItemList[0].Payment_ID = SaveCheckList[0].Payment_ID;
        //            SavePPLineItemList[0].Check_Table_Int_ID = SaveCheckList[0].Id;
        //            SavePPLineItemList[0].Visit_Payment_ID = VisitPaymentArcList[0].Id;
        //            PPLineItemManager objPPLineItem = new PPLineItemManager();
        //            //iResult = objPPLineItem.SavePPLineItemWithoutTransaction(SavePPLineItemList,null, MySession, MACAddress);
        //            IList<PPLineItem> PPLineTemp = null;
        //            iResult = objPPLineItem.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SavePPLineItemList, ref PPLineTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
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
        //                  //  MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");

        //                }
        //            }
        //            else if (iResult == 1)
        //            {

        //                trans.Rollback();
        //              //  MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");

        //            }


        //            if (SaveAccountList.Count > 0)
        //            {
        //                for (int i = 0; i < SaveAccountList.Count; i++)
        //                {
        //                    SaveAccountList[i].Bill_To_PP_Line_Item_ID = SavePPLineItemList[0].Id;
        //                    SaveAccountList[i].PP_Header_ID = SavePPHeaderList[0].Id;
        //                    SaveAccountList[i].Payment_ID = SaveCheckList[0].Payment_ID;
        //                    SaveAccountList[i].Check_Table_Int_ID = SaveCheckList[0].Id;
        //                    AccountTransactionManager objAccount = new AccountTransactionManager();
        //                    //iResult = objAccount.SaveAccountWithoutTransaction(SaveAccountList, MySession, MACAddress);
        //                    IList<AccountTransaction> AccTranTemp = null;
        //                    iResult = objAccount.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveAccountList, ref AccTranTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
        //                }

        //            }

        //            //SaveAccountList[0].Bill_To_PP_Line_Item_ID = SavePPLineItemList[0].Id;
        //            //SaveAccountList[0].PP_Header_ID = SavePPHeaderList[0].Id;
        //            //SaveAccountList[0].Payment_ID = SaveCheckList[0].Payment_ID;
        //            //SaveAccountList[0].Check_Table_Int_ID = SaveCheckList[0].Id;

        //            //AccountTransactionManager objAccount = new AccountTransactionManager();
        //            //iResult = objAccount.SaveAccountWithoutTransaction(SaveAccountList, MySession, MACAddress);

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
        //                   // MySession.Close();
        //                    throw new Exception("Deadlock is occured. Transaction failed");

        //                }
        //            }
        //            else if (iResult == 1)
        //            {

        //                trans.Rollback();
        //               // MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");

        //            }

        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }
        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }
        //    ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //    IList<VisitPaymentDTO> ilistVisitPaymentDTO = new List<VisitPaymentDTO>();
        //    IList<object> ilistObj = iMySession.CreateSQLQuery("select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N' order by v.created_date_and_time").List<object>();
        //    if (ilistObj != null)
        //    {
        //        foreach (IList<object> obj in ilistObj)
        //        {
        //            VisitPaymentDTO objVisitPaymentDTO = new VisitPaymentDTO();
        //            objVisitPaymentDTO.Method_of_Payment = obj[0].ToString();
        //            objVisitPaymentDTO.Check_Card_No = obj[1].ToString();
        //            objVisitPaymentDTO.Auth_No = obj[2].ToString();
        //            if (obj[3].ToString() != "")
        //                objVisitPaymentDTO.Patient_Payment = Convert.ToDecimal(obj[3]);
        //            if (obj[4].ToString() != "")
        //                objVisitPaymentDTO.Refund_Amount = Convert.ToDecimal(obj[4]);
        //            if (obj[5].ToString() != "")
        //                objVisitPaymentDTO.Rec_On_Acc = Convert.ToDecimal(obj[5]);
        //            if (obj[6].ToString() != "")
        //                objVisitPaymentDTO.Check_Date = Convert.ToDateTime(obj[6]);
        //            objVisitPaymentDTO.Payment_Note = obj[7].ToString();
        //            objVisitPaymentDTO.Visit_Payment_Id = Convert.ToUInt32(obj[8]);
        //            if (obj[9] != null)
        //                objVisitPaymentDTO.PP_Line_Item_Id = Convert.ToUInt32(obj[9]);
        //            if (obj[10] != null)
        //                objVisitPaymentDTO.PP_Header_Id = Convert.ToUInt32(obj[10]);
        //            if (obj[11] != null)
        //                objVisitPaymentDTO.Check_Table_Int_Id = Convert.ToUInt32(obj[11]);

        //            if (obj[12] != null)
        //                objVisitPaymentDTO.Relationship = Convert.ToString(obj[12]);
        //            if (obj[13] != null)
        //                objVisitPaymentDTO.Amount_Paid_By = Convert.ToString(obj[13]);
        //            if (obj[14] != null)
        //                objVisitPaymentDTO.Created_Date_and_Time = Convert.ToDateTime(obj[14]);

        //            ilistVisitPaymentDTO.Add(objVisitPaymentDTO);
        //        }
        //    }
        //    return ilistVisitPaymentDTO;
        //}

        //public int SaveVisitPaymentArcWithoutTransaction(IList<VisitPaymentArc> ListToInsert, ISession MySession, string MACAddress)
        //{
        //    int iResult = 0;
        //    GenerateXml ObjXML = null;
        //    IList<VisitPaymentArc> VisitPaymentArcTemp = null;
        //    if ((ListToInsert != null))
        //    {
        //        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref VisitPaymentArcTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
        //    }
        //    return iResult;
        //}
        //public IList<VisitPaymentDTO> UpdateVisitPaymentArc(IList<VisitPaymentArc> UpdateVisit, IList<Check> UpdateCheck, IList<PPHeader> UpdatePPHeader, IList<PPLineItem> UpdatePPLine, IList<AccountTransaction> UpdateAccTrans, IList<AccountTransaction> SaveAccTrans, ulong EncounterID)
        //{
        //    iTryCount = 0;

        //TryAgain:
        //    int iResult = 0;

        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    GenerateXml ObjXML = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();

        //        if (UpdateVisit != null && UpdateVisit.Count > 0)
        //        {
        //            IList<VisitPaymentArc> ilistVisitTemp = null;
        //            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ilistVisitTemp, ref UpdateVisit, null, MySession, "", false, false, 0, "", ref ObjXML);
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
        //                //   MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //            if (UpdateCheck != null && UpdateCheck.Count > 0)
        //            {
        //                CheckManager objCheck = new CheckManager();
        //                IList<Check> CheckTemp = null;
        //                iResult = objCheck.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref CheckTemp, ref UpdateCheck, null, MySession, "", false, false, 0, "", ref ObjXML);
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
        //                        //  MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //            }
        //            else if (iResult == 1)
        //            {

        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Exception is occured. Transaction failed");
        //            }
        //            if (UpdatePPHeader != null && UpdatePPHeader.Count > 0)
        //            {
        //                PPHeaderManager objPPHeader = new PPHeaderManager();
        //                IList<PPHeader> PPHeaderTemp = null;
        //                iResult = objPPHeader.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref PPHeaderTemp, ref UpdatePPHeader, null, MySession, "", false, false, 0, "", ref ObjXML);
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
        //                        // MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");
        //                }
        //            }
        //            if (UpdatePPLine != null && UpdatePPLine.Count > 0)
        //            {
        //                PPLineItemManager objPPLineItem = new PPLineItemManager();
        //                IList<PPLineItem> PPLineTemp = null;
        //                iResult = objPPLineItem.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref PPLineTemp, ref UpdatePPLine, null, MySession, "", false, false, 0, "", ref ObjXML);

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
        //                        //  MySession.Close();
        //                        throw new Exception("Deadlock is occured. Transaction failed");
        //                    }
        //                }
        //                else if (iResult == 1)
        //                {

        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Exception is occured. Transaction failed");

        //                }
        //            }
        //            if (UpdateAccTrans != null && UpdateAccTrans.Count > 0)
        //            {
        //                AccountTransactionManager objAccount = new AccountTransactionManager();
        //                IList<AccountTransaction> ilistAccTranTemp = null;
        //                iResult = objAccount.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ilistAccTranTemp, ref UpdateAccTrans, null, MySession, "", false, false, 0, "", ref ObjXML);
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
        //                        // MySession.Close();
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
        //            if (SaveAccTrans != null && SaveAccTrans.Count > 0)
        //            {
        //                AccountTransactionManager objAccount = new AccountTransactionManager();
        //                if (UpdatePPLine != null && UpdatePPLine.Count > 0)
        //                    SaveAccTrans[0].Bill_To_PP_Line_Item_ID = UpdatePPLine[0].Id;
        //                if (UpdatePPHeader != null && UpdatePPHeader.Count > 0)
        //                {
        //                    SaveAccTrans[0].PP_Header_ID = UpdatePPHeader[0].Id;
        //                    SaveAccTrans[0].Payment_ID = UpdatePPHeader[0].Payment_ID;
        //                }
        //                if (UpdateCheck != null && UpdateCheck.Count > 0)
        //                    SaveAccTrans[0].Check_Table_Int_ID = UpdateCheck[0].Id;
        //                IList<AccountTransaction> AccTranTemp = null;
        //                iResult = objAccount.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveAccTrans, ref AccTranTemp, null, MySession, "", false, false, 0, "", ref ObjXML);
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
        //                        // MySession.Close();
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
        //        //MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }
        //    ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //    IList<VisitPaymentDTO> ilistVisitPaymentDTO = new List<VisitPaymentDTO>();
        //    IList<object> ilistObj = iMySession.CreateSQLQuery("select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N' order by v.created_date_and_time").List<object>();
        //    if (ilistObj != null)
        //    {
        //        foreach (IList<object> obj in ilistObj)
        //        {
        //            VisitPaymentDTO objVisitPaymentDTO = new VisitPaymentDTO();
        //            objVisitPaymentDTO.Method_of_Payment = obj[0].ToString();
        //            objVisitPaymentDTO.Check_Card_No = obj[1].ToString();
        //            objVisitPaymentDTO.Auth_No = obj[2].ToString();
        //            if (obj[3].ToString() != "")
        //                objVisitPaymentDTO.Patient_Payment = Convert.ToDecimal(obj[3]);
        //            if (obj[4].ToString() != "")
        //                objVisitPaymentDTO.Refund_Amount = Convert.ToDecimal(obj[4]);
        //            if (obj[5].ToString() != "")
        //                objVisitPaymentDTO.Rec_On_Acc = Convert.ToDecimal(obj[5]);
        //            if (obj[6].ToString() != "")
        //                objVisitPaymentDTO.Check_Date = Convert.ToDateTime(obj[6]);
        //            objVisitPaymentDTO.Payment_Note = obj[7].ToString();
        //            objVisitPaymentDTO.Visit_Payment_Id = Convert.ToUInt32(obj[8]);
        //            if (obj[9] != null)
        //                objVisitPaymentDTO.PP_Line_Item_Id = Convert.ToUInt32(obj[9]);
        //            if (obj[10] != null)
        //                objVisitPaymentDTO.PP_Header_Id = Convert.ToUInt32(obj[10]);
        //            if (obj[11] != null)
        //                objVisitPaymentDTO.Check_Table_Int_Id = Convert.ToUInt32(obj[11]);

        //            if (obj[12] != null)
        //                objVisitPaymentDTO.Relationship = Convert.ToString(obj[12]);
        //            if (obj[13] != null)
        //                objVisitPaymentDTO.Amount_Paid_By = Convert.ToString(obj[13]);
        //            if (obj[14] != null)
        //                objVisitPaymentDTO.Created_Date_and_Time = Convert.ToDateTime(obj[14]);


        //            ilistVisitPaymentDTO.Add(objVisitPaymentDTO);
        //        }
        //    }
        //    return ilistVisitPaymentDTO;
        //}
        //#endregion
        public IList<VisitPaymentDTO> SaveVisitPaymentArc(ulong EncounterID, IList<VisitPaymentArc> VisitPaymentList, IList<CheckArc> SaveCheckList, IList<PPHeaderArc> SavePPHeaderList, IList<PPLineItemArc> SavePPLineItemList, IList<AccountTransactionArc> SaveAccountList, IList<VisitPaymentHistoryArc> SaveVisitPaymentHistoryArcList, string MACAddress)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            GenerateXml ObjXML = null;
            try
            {
                trans = MySession.BeginTransaction();
                if (VisitPaymentList != null && VisitPaymentList.Count > 0)
                {
                    IList<VisitPaymentArc> VisitPaymentTemp = null;
                    VisitPaymentList[0].Batch_Status = "OPEN";
                    iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref VisitPaymentList, ref VisitPaymentTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);

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
                        //   MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }

                    VisitPaymentHistoryArcManager objVisitPaymentHistory = new VisitPaymentHistoryArcManager();
                    IList<VisitPaymentHistoryArc> VisHisTemp = null;
                    SaveVisitPaymentHistoryArcList[0].Visit_Payment_ID = VisitPaymentList[0].Id;

                    iResult = objVisitPaymentHistory.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveVisitPaymentHistoryArcList, ref VisHisTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
                    //iResult = objCheck.SaveCheckWithoutTransaction(SaveCheckList, MySession, MACAddress);

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
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }


                    CheckArcManager objCheck = new CheckArcManager();
                    IList<CheckArc> CheckTemp = null;
                    iResult = objCheck.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveCheckList, ref CheckTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
                    //iResult = objCheck.SaveCheckWithoutTransaction(SaveCheckList, MySession, MACAddress);

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
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }


                    SavePPHeaderList[0].Payment_ID = SaveCheckList[0].Payment_ID;
                    SavePPHeaderList[0].Check_Table_Int_ID = SaveCheckList[0].Id;

                    PPHeaderArcManager objPPHeader = new PPHeaderArcManager();
                    //iResult = objPPHeader.SavePPHeaderWithoutTransaction(SavePPHeaderList, MySession, MACAddress);
                    IList<PPHeaderArc> PPHeaderTemp = null;
                    iResult = objPPHeader.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SavePPHeaderList, ref PPHeaderTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
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
                        //  MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }


                    SavePPLineItemList[0].PP_Header_ID = SavePPHeaderList[0].Id;
                    SavePPLineItemList[0].Payment_ID = SaveCheckList[0].Payment_ID;
                    SavePPLineItemList[0].Check_Table_Int_ID = SaveCheckList[0].Id;
                    SavePPLineItemList[0].Visit_Payment_ID = VisitPaymentList[0].Id;
                    PPLineItemArcManager objPPLineItem = new PPLineItemArcManager();
                    //iResult = objPPLineItem.SavePPLineItemWithoutTransaction(SavePPLineItemList,null, MySession, MACAddress);
                    IList<PPLineItemArc> PPLineTemp = null;
                    iResult = objPPLineItem.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SavePPLineItemList, ref PPLineTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
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
                        //  MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }


                    if (SaveAccountList.Count > 0)
                    {
                        for (int i = 0; i < SaveAccountList.Count; i++)
                        {
                            SaveAccountList[i].Bill_To_PP_Line_Item_ID = SavePPLineItemList[0].Id;
                            SaveAccountList[i].PP_Header_ID = SavePPHeaderList[0].Id;
                            SaveAccountList[i].Payment_ID = SaveCheckList[0].Payment_ID;
                            SaveAccountList[i].Check_Table_Int_ID = SaveCheckList[0].Id;
                            AccountTransactionArcManager objAccount = new AccountTransactionArcManager();
                            //iResult = objAccount.SaveAccountWithoutTransaction(SaveAccountList, MySession, MACAddress);
                            IList<AccountTransactionArc> AccTranTemp = null;
                            iResult = objAccount.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveAccountList, ref AccTranTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
                        }

                    }

                    //SaveAccountList[0].Bill_To_PP_Line_Item_ID = SavePPLineItemList[0].Id;
                    //SaveAccountList[0].PP_Header_ID = SavePPHeaderList[0].Id;
                    //SaveAccountList[0].Payment_ID = SaveCheckList[0].Payment_ID;
                    //SaveAccountList[0].Check_Table_Int_ID = SaveCheckList[0].Id;

                    //AccountTransactionManager objAccount = new AccountTransactionManager();
                    //iResult = objAccount.SaveAccountWithoutTransaction(SaveAccountList, MySession, MACAddress);

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
                //MySession.Close();
                //CAP-1942
                throw new Exception(ex.Message,ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                // MySession.Close();
                //CAP-1942
                throw new Exception(e.Message,e);
            }
            finally
            {
                MySession.Close();
            }
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VisitPaymentDTO> ilistVisitPaymentDTO = new List<VisitPaymentDTO>();
            IList<object> ilistObj = iMySession.CreateSQLQuery("(select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) as myDate from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N') union all (select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) as MyDate from visit_payment_arc v left join pp_line_item_arc p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N') order by MyDate").List<object>();
            if (ilistObj != null)
            {
                foreach (IList<object> obj in ilistObj)
                {
                    VisitPaymentDTO objVisitPaymentDTO = new VisitPaymentDTO();
                    objVisitPaymentDTO.Method_of_Payment = obj[0].ToString();
                    objVisitPaymentDTO.Check_Card_No = obj[1].ToString();
                    objVisitPaymentDTO.Auth_No = obj[2].ToString();
                    if (obj[3].ToString() != "")
                        objVisitPaymentDTO.Patient_Payment = Convert.ToDecimal(obj[3]);
                    if (obj[4].ToString() != "")
                        objVisitPaymentDTO.Refund_Amount = Convert.ToDecimal(obj[4]);
                    if (obj[5].ToString() != "")
                        objVisitPaymentDTO.Rec_On_Acc = Convert.ToDecimal(obj[5]);
                    if (obj[6].ToString() != "")
                        objVisitPaymentDTO.Check_Date = Convert.ToDateTime(obj[6]);
                    objVisitPaymentDTO.Payment_Note = obj[7].ToString();
                    objVisitPaymentDTO.Visit_Payment_Id = Convert.ToUInt32(obj[8]);
                    if (obj[9] != null)
                        objVisitPaymentDTO.PP_Line_Item_Id = Convert.ToUInt32(obj[9]);
                    if (obj[10] != null)
                        objVisitPaymentDTO.PP_Header_Id = Convert.ToUInt32(obj[10]);
                    if (obj[11] != null)
                        objVisitPaymentDTO.Check_Table_Int_Id = Convert.ToUInt32(obj[11]);

                    if (obj[12] != null)
                        objVisitPaymentDTO.Relationship = Convert.ToString(obj[12]);
                    if (obj[13] != null)
                        objVisitPaymentDTO.Amount_Paid_By = Convert.ToString(obj[13]);
                    if (obj[14] != null)
                        objVisitPaymentDTO.Created_Date_and_Time = Convert.ToDateTime(obj[14]);

                    ilistVisitPaymentDTO.Add(objVisitPaymentDTO);
                }
            }
            return ilistVisitPaymentDTO;
        }


        public IList<VisitPaymentDTO> UpdateVisitPaymentArc(IList<VisitPaymentArc> UpdateVisit, IList<CheckArc> UpdateCheck, IList<PPHeaderArc> UpdatePPHeader, IList<PPLineItemArc> UpdatePPLine, IList<AccountTransactionArc> UpdateAccTrans, IList<AccountTransactionArc> SaveAccTrans, IList<VisitPaymentHistoryArc> SaveVisitPaymentHistoryArcList, ulong EncounterID)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            GenerateXml ObjXML = null;
            try
            {
                trans = MySession.BeginTransaction();

                if (UpdateVisit != null && UpdateVisit.Count > 0)
                {
                    IList<VisitPaymentArc> ilistVisitTemp = null;
                    UpdateVisit[0].Batch_Status="OPEN";
                    iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ilistVisitTemp, ref UpdateVisit, null, MySession, "", false, false, 0, "", ref ObjXML);
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
                        //   MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }

                    VisitPaymentHistoryArcManager objVisitPaymentArcHistory = new VisitPaymentHistoryArcManager();
                    IList<VisitPaymentHistoryArc> VisHisArcTemp = null;
                    iResult = objVisitPaymentArcHistory.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveVisitPaymentHistoryArcList, ref VisHisArcTemp, null, MySession, "", false, false, 0, "", ref ObjXML);
                    //iResult = objCheck.SaveCheckWithoutTransaction(SaveCheckList, MySession, MACAddress);

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
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");

                    }

                    if (UpdateCheck != null && UpdateCheck.Count > 0)
                    {
                        CheckArcManager objCheck = new CheckArcManager();
                        IList<CheckArc> CheckTemp = null;
                        iResult = objCheck.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref CheckTemp, ref UpdateCheck, null, MySession, "", false, false, 0, "", ref ObjXML);
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
                    }
                    else if (iResult == 1)
                    {

                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                    if (UpdatePPHeader != null && UpdatePPHeader.Count > 0)
                    {
                        PPHeaderArcManager objPPHeader = new PPHeaderArcManager();
                        IList<PPHeaderArc> PPHeaderTemp = null;
                        iResult = objPPHeader.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref PPHeaderTemp, ref UpdatePPHeader, null, MySession, "", false, false, 0, "", ref ObjXML);
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
                            //  MySession.Close();
                            throw new Exception("Exception is occured. Transaction failed");
                        }
                    }
                    if (UpdatePPLine != null && UpdatePPLine.Count > 0)
                    {
                        PPLineItemArcManager objPPLineItem = new PPLineItemArcManager();
                        IList<PPLineItemArc> PPLineTemp = null;
                        iResult = objPPLineItem.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref PPLineTemp, ref UpdatePPLine, null, MySession, "", false, false, 0, "", ref ObjXML);

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
                            //  MySession.Close();
                            throw new Exception("Exception is occured. Transaction failed");

                        }
                    }
                    if (UpdateAccTrans != null && UpdateAccTrans.Count > 0)
                    {
                        AccountTransactionArcManager objAccount = new AccountTransactionArcManager();
                        IList<AccountTransactionArc> ilistAccTranTemp = null;
                        iResult = objAccount.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ilistAccTranTemp, ref UpdateAccTrans, null, MySession, "", false, false, 0, "", ref ObjXML);
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
                    if (SaveAccTrans != null && SaveAccTrans.Count > 0)
                    {
                        AccountTransactionArcManager objAccount = new AccountTransactionArcManager();
                        if (UpdatePPLine != null && UpdatePPLine.Count > 0)
                            SaveAccTrans[0].Bill_To_PP_Line_Item_ID = UpdatePPLine[0].Id;
                        if (UpdatePPHeader != null && UpdatePPHeader.Count > 0)
                        {
                            SaveAccTrans[0].PP_Header_ID = UpdatePPHeader[0].Id;
                            SaveAccTrans[0].Payment_ID = UpdatePPHeader[0].Payment_ID;
                        }
                        if (UpdateCheck != null && UpdateCheck.Count > 0)
                            SaveAccTrans[0].Check_Table_Int_ID = UpdateCheck[0].Id;
                        IList<AccountTransactionArc> AccTranTemp = null;
                        iResult = objAccount.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveAccTrans, ref AccTranTemp, null, MySession, "", false, false, 0, "", ref ObjXML);
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
                }

                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                //MySession.Close();
                //CAP-1942
                throw new Exception(ex.Message,ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                // MySession.Close();
                //CAP-1942
                throw new Exception(e.Message,e);
            }
            finally
            {
                MySession.Close();
            }
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VisitPaymentDTO> ilistVisitPaymentDTO = new List<VisitPaymentDTO>();
           // IList<object> ilistObj = iMySession.CreateSQLQuery("(select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),cast(v.created_date_and_time as char(50)) as MyDate 'Main' from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N') union all (select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),cast(v.created_date_and_time as char(50)) as MyDate,'Arc' from visit_payment_arc v left join pp_line_item_arc p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N') order by MyDate").List<object>();
            IList<object> ilistObj = iMySession.CreateSQLQuery("(select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) as myDate from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N') union all (select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) as MyDate from visit_payment_arc v left join pp_line_item_arc p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N') order by MyDate").List<object>();
             
            if (ilistObj != null)
            {
                foreach (IList<object> obj in ilistObj)
                {
                    VisitPaymentDTO objVisitPaymentDTO = new VisitPaymentDTO();
                    objVisitPaymentDTO.Method_of_Payment = obj[0].ToString();
                    objVisitPaymentDTO.Check_Card_No = obj[1].ToString();
                    objVisitPaymentDTO.Auth_No = obj[2].ToString();
                    if (obj[3].ToString() != "")
                        objVisitPaymentDTO.Patient_Payment = Convert.ToDecimal(obj[3]);
                    if (obj[4].ToString() != "")
                        objVisitPaymentDTO.Refund_Amount = Convert.ToDecimal(obj[4]);
                    if (obj[5].ToString() != "")
                        objVisitPaymentDTO.Rec_On_Acc = Convert.ToDecimal(obj[5]);
                    if (obj[6].ToString() != "")
                        objVisitPaymentDTO.Check_Date = Convert.ToDateTime(obj[6]);
                    objVisitPaymentDTO.Payment_Note = obj[7].ToString();
                    objVisitPaymentDTO.Visit_Payment_Id = Convert.ToUInt32(obj[8]);
                    if (obj[9] != null)
                        objVisitPaymentDTO.PP_Line_Item_Id = Convert.ToUInt32(obj[9]);
                    if (obj[10] != null)
                        objVisitPaymentDTO.PP_Header_Id = Convert.ToUInt32(obj[10]);
                    if (obj[11] != null)
                        objVisitPaymentDTO.Check_Table_Int_Id = Convert.ToUInt32(obj[11]);

                    if (obj[12] != null)
                        objVisitPaymentDTO.Relationship = Convert.ToString(obj[12]);
                    if (obj[13] != null)
                        objVisitPaymentDTO.Amount_Paid_By = Convert.ToString(obj[13]);
                    if (obj[14] != null)
                        objVisitPaymentDTO.Created_Date_and_Time = Convert.ToDateTime(obj[14]);


                    ilistVisitPaymentDTO.Add(objVisitPaymentDTO);
                }
            }
            return ilistVisitPaymentDTO;
        }
    }            
}
