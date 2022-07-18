using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public interface IVisitPaymentManager : IManagerBase<VisitPayment, ulong>
    {
        IList<VisitPaymentDTO> SaveVisitPayment(ulong EncounterID, IList<VisitPayment> VisitPaymentList, IList<Check> SaveCheckList, IList<PPHeader> SavePPHeaderList, IList<PPLineItem> SavePPLineItemList, IList<AccountTransaction> SaveAccountList, IList<VisitPaymentHistory> SaveVisitPaymentHistoryList, string MACAddress);
        int SaveVisitPaymentWithoutTransaction(IList<VisitPayment> ListToInsert, ISession MySession, string MACAddress);
        IList<VisitPaymentDTO> UpdateVisitPayment(IList<VisitPayment> UpdateVisit, IList<Check> UpdateCheck, IList<PPHeader> UpdatePPHeader, IList<PPLineItem> UpdatePPLine, IList<AccountTransaction> UpdateAccTrans, IList<AccountTransaction> SaveAccTrans, IList<VisitPaymentHistory> SaveVisitPaymentHistoryList, ulong EncounterID);
        ArrayList GetAutoIncreamentVoucherNo(ulong Human, string sFacilityName);
        int SaveVisitPaymentWithoutTransaction(ref IList<VisitPayment> ListToInsert, ISession MySession, string MACAddress);
    }
    public partial class VisitPaymentManager : ManagerBase<VisitPayment, ulong>, IVisitPaymentManager
    {
        #region Constructors

        public VisitPaymentManager()
            : base()
        {

        }
        public VisitPaymentManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        int iTryCount = 0;
        public IList<VisitPaymentDTO> SaveVisitPayment(ulong EncounterID, IList<VisitPayment> VisitPaymentList, IList<Check> SaveCheckList, IList<PPHeader> SavePPHeaderList, IList<PPLineItem> SavePPLineItemList, IList<AccountTransaction> SaveAccountList, IList<VisitPaymentHistory> SaveVisitPaymentHistoryList, string MACAddress)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            GenerateXml ObjXML = null;
            try
            {
                if (VisitPaymentList != null && VisitPaymentList.Count > 0)
                {
                    if (VisitPaymentList[0].Encounter_ID == 0 && VisitPaymentList[0].Voucher_No==0)
                    {
                        IList<object> grpId = new List<object>();
                        //ICriteria crit = MySession.(select max(voucherno) from (select voucher_no as voucherno from visit_payment union select voucher_no as voucherno from visit_payment_arc)a );
                        IQuery query = MySession.CreateSQLQuery("select max(voucherno) from (select voucher_no as voucherno from visit_payment union select voucher_no as voucherno from visit_payment_arc)a");
                        grpId = query.List<object>();

                        if (grpId.Count > 0)
                        {
                            VisitPaymentList[0].Voucher_No = Convert.ToUInt64(grpId[0]) + 1;
                            VisitPaymentList[0].Batch_Status = "OPEN";
                        }
                        else
                        {
                            VisitPaymentList[0].Voucher_No = 10000000;
                        }
                        
                        SaveVisitPaymentHistoryList[0].Voucher_No = VisitPaymentList[0].Voucher_No;
                    }
                    else
                    {
                        SaveVisitPaymentHistoryList[0].Voucher_No = VisitPaymentList[0].Voucher_No;
                    }
                }

                trans = MySession.BeginTransaction();
                if (VisitPaymentList != null && VisitPaymentList.Count > 0)
                {
                    IList<VisitPayment> VisitPaymentTemp = null;
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

                    VisitPaymentHistoryManager objVisitPaymentHistory = new VisitPaymentHistoryManager();
                    IList<VisitPaymentHistory> VisHisTemp = null;
                    if (SaveVisitPaymentHistoryList.Count>0)
                        SaveVisitPaymentHistoryList[0].Visit_Payment_ID = VisitPaymentList[0].Id;
                    iResult = objVisitPaymentHistory.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveVisitPaymentHistoryList, ref VisHisTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);

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


                    CheckManager objCheck = new CheckManager();
                    IList<Check> CheckTemp = null;
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

                    PPHeaderManager objPPHeader = new PPHeaderManager();
                    //iResult = objPPHeader.SavePPHeaderWithoutTransaction(SavePPHeaderList, MySession, MACAddress);
                    IList<PPHeader> PPHeaderTemp = null;
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
                    PPLineItemManager objPPLineItem = new PPLineItemManager();
                    //iResult = objPPLineItem.SavePPLineItemWithoutTransaction(SavePPLineItemList,null, MySession, MACAddress);
                    IList<PPLineItem> PPLineTemp = null;
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
                            AccountTransactionManager objAccount = new AccountTransactionManager();
                            //iResult = objAccount.SaveAccountWithoutTransaction(SaveAccountList, MySession, MACAddress);
                            IList<AccountTransaction> AccTranTemp = null;
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
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                trans.Rollback();
                // MySession.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                MySession.Close();
            }
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VisitPaymentDTO> ilistVisitPaymentDTO = new List<VisitPaymentDTO>();
            string sQuery = string.Empty;
            if (VisitPaymentList[0].Voucher_No == 0)
                sQuery = "select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)) as VisitID,cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,if(v.modified_date_and_time = '0001-01-01 00:00:00', cast(v.created_date_and_time as char(50)),cast(v.modified_date_and_time as char(50))) as MyDate, v.Voucher_No from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N' order by VisitID";
            else
                sQuery = "select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)) as VisitID,cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,if(v.modified_date_and_time = '0001-01-01 00:00:00', cast(v.created_date_and_time as char(50)),cast(v.modified_date_and_time as char(50))) as MyDate, v.Voucher_No from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.voucher_no=" + VisitPaymentList[0].Voucher_No + " and v.is_delete='N' order by VisitID";
            IList<object> ilistObj = iMySession.CreateSQLQuery(sQuery).List<object>();
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
                    if (obj[14].ToString() != "")
                        objVisitPaymentDTO.Created_Date_and_Time = Convert.ToDateTime(obj[14]);
                    if (obj[15].ToString() != "")
                        objVisitPaymentDTO.Voucher_No = Convert.ToUInt64(obj[15]);
                    ilistVisitPaymentDTO.Add(objVisitPaymentDTO);
                }
            }
            return ilistVisitPaymentDTO;
        }

        public int SaveVisitPaymentWithoutTransaction(IList<VisitPayment> ListToInsert, ISession MySession, string MACAddress)
        {
            int iResult = 0;
            GenerateXml ObjXML = null;
            IList<VisitPayment> VisitPaymentTemp = null;
            if ((ListToInsert != null))
            {
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref VisitPaymentTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
            }
            return iResult;
        }
        public int SaveVisitPaymentWithoutTransaction(ref IList<VisitPayment> ListToInsert, ISession MySession, string MACAddress)
        {
            int iResult = 0;
            GenerateXml ObjXML = null;
            IList<VisitPayment> VisitPaymentTemp = null;
            if ((ListToInsert != null))
            {
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref VisitPaymentTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
            }
            return iResult;
        }
        public IList<VisitPaymentDTO> UpdateVisitPayment(IList<VisitPayment> UpdateVisit, IList<Check> UpdateCheck, IList<PPHeader> UpdatePPHeader, IList<PPLineItem> UpdatePPLine, IList<AccountTransaction> UpdateAccTrans, IList<AccountTransaction> SaveAccTrans, IList<VisitPaymentHistory> SaveVisitPaymentHistoryList, ulong EncounterID)
        {
            iTryCount = 0;

        TryAgain:
            int iResult = 0;

            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            GenerateXml ObjXML = null;
            try
            {
                if (SaveVisitPaymentHistoryList != null && SaveVisitPaymentHistoryList.Count > 0)
                {
                    if (SaveVisitPaymentHistoryList[0].Is_Delete=="Y")
                    {
                        ISQLQuery sql = session.GetISession().CreateSQLQuery("select * from visit_payment_history where visit_payment_id='" + SaveVisitPaymentHistoryList[0].Visit_Payment_ID.ToString() + "' and visit_payment_history_id<>'"+SaveVisitPaymentHistoryList[0].Visit_Payment_History_ID.ToString()+"'").AddEntity(typeof(VisitPaymentHistory));
                        IList<VisitPaymentHistory> VisitPaymentHistoryList = sql.List<VisitPaymentHistory>();
                        for (int iCount = 0; iCount < VisitPaymentHistoryList.Count; iCount++)
                        {
                            VisitPaymentHistoryList[iCount].Is_Delete = "Y";
                            SaveVisitPaymentHistoryList.Add(VisitPaymentHistoryList[iCount]);
                        }
                    }
                }

                trans = MySession.BeginTransaction();

                if (UpdateVisit != null && UpdateVisit.Count > 0)
                {
                    IList<VisitPayment> ilistVisitTemp = null;
                    UpdateVisit[0].Batch_Status = "OPEN";
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

                    for (int iCount = 0; iCount < SaveVisitPaymentHistoryList.Count; iCount++)
                    {
                        SaveVisitPaymentHistoryList[iCount].Voucher_No = UpdateVisit[0].Voucher_No;
                    }

                    if(SaveVisitPaymentHistoryList != null && SaveVisitPaymentHistoryList.Count >0)
                    {
                        VisitPaymentHistoryManager objVisitPaymentHistory = new VisitPaymentHistoryManager();
                        IList<VisitPaymentHistory> VisHisTemp = null;
                        iResult = objVisitPaymentHistory.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref VisHisTemp, ref SaveVisitPaymentHistoryList, null, MySession, "", false, false, 0, "", ref ObjXML);
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
                                throw new Exception("Deadlock is occured. Transaction failed");
                            }
                        }
                        else if (iResult == 1)
                        {
                            trans.Rollback();
                            throw new Exception("Exception is occured. Transaction failed");
                        }
                    }
                    
                    if (UpdateCheck != null && UpdateCheck.Count > 0)
                    {
                        CheckManager objCheck = new CheckManager();
                        IList<Check> CheckTemp = null;
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
                        PPHeaderManager objPPHeader = new PPHeaderManager();
                        IList<PPHeader> PPHeaderTemp = null;
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
                        PPLineItemManager objPPLineItem = new PPLineItemManager();
                        IList<PPLineItem> PPLineTemp = null;
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
                        AccountTransactionManager objAccount = new AccountTransactionManager();
                        IList<AccountTransaction> ilistAccTranTemp = null;
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
                        AccountTransactionManager objAccount = new AccountTransactionManager();
                        if (UpdatePPLine != null && UpdatePPLine.Count > 0)
                            SaveAccTrans[0].Bill_To_PP_Line_Item_ID = UpdatePPLine[0].Id;
                        if (UpdatePPHeader != null && UpdatePPHeader.Count > 0)
                        {
                            SaveAccTrans[0].PP_Header_ID = UpdatePPHeader[0].Id;
                            SaveAccTrans[0].Payment_ID = UpdatePPHeader[0].Payment_ID;
                        }
                        if (UpdateCheck != null && UpdateCheck.Count > 0)
                            SaveAccTrans[0].Check_Table_Int_ID = UpdateCheck[0].Id;
                        IList<AccountTransaction> AccTranTemp = null;
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
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                trans.Rollback();
                // MySession.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                MySession.Close();
            }
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VisitPaymentDTO> ilistVisitPaymentDTO = new List<VisitPaymentDTO>();
            string sQuery = string.Empty;
            if (UpdateVisit[0].Voucher_No == 0)
                sQuery = "select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)) as VisitID,cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,if(v.modified_date_and_time = '0001-01-01 00:00:00', cast(v.created_date_and_time as char(50)),cast(v.modified_date_and_time as char(50))) as MyDate, v.Voucher_No from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N' order by VisitID";
            else
                sQuery = "select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)) as VisitID,cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,if(v.modified_date_and_time = '0001-01-01 00:00:00', cast(v.created_date_and_time as char(50)),cast(v.modified_date_and_time as char(50))) as MyDate, v.Voucher_No from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.voucher_no=" + UpdateVisit[0].Voucher_No + " and v.is_delete='N' order by VisitID";
            IList<object> ilistObj = iMySession.CreateSQLQuery(sQuery).List<object>();

            //IList<object> ilistObj = iMySession.CreateSQLQuery("select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N' order by v.created_date_and_time").List<object>();

            //IList<object> ilistObj = iMySession.CreateSQLQuery("select v.method_of_payment,v.check_card_no,v.auth_no,v.patient_payment,v.refund_amount,v.rec_on_acc,cast(v.check_date as char(50)),v.payment_note,cast(v.visit_payment_id as char(50)),cast(p.pp_line_item_id as char(50)),cast(p.pp_header_id as char(50)),cast(p.check_table_int_id as char(50)),v.Relationship,v.Amount_Paid_By,cast(v.created_date_and_time as char(50)) as myDate from visit_payment v left join pp_line_item p on (v.visit_payment_id=p.visit_payment_id) where v.encounter_id=" + EncounterID + " and v.is_delete='N' order by v.created_date_and_time").List<object>();

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
                    if (obj[14].ToString() != "")
                        objVisitPaymentDTO.Created_Date_and_Time = Convert.ToDateTime(obj[14]);


                    ilistVisitPaymentDTO.Add(objVisitPaymentDTO);
                }
            }
            return ilistVisitPaymentDTO;
        }

        public ArrayList GetAutoIncreamentVoucherNo(ulong ulHumanID,string sFacilityName)
        {
            ArrayList ilstVoucherNo = new ArrayList();
            ArrayList ilstVoucherNoVoucher = new ArrayList();
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ISQLQuery sqlquery = iMySession.CreateSQLQuery("select encounterid  from (select distinct concat('EN',e.encounter_id) as encounterid ,cast(e.created_date_and_time as char(30)) as created_date_and_time  from encounter e left join visit_payment v on (v.encounter_id=e.encounter_id)  where e.human_id='" + ulHumanID + "' and e.Facility_Name='" + sFacilityName + "' and e.batch_status !='CLOSED' and (v.is_delete is null or v.is_delete='N' ) union select distinct concat('VN',voucher_no) as encounterid ,cast(created_date_and_time as char(30)) as created_date_and_time from visit_payment where human_id='" + ulHumanID + "'and Facility_Name='" + sFacilityName + "' and voucher_no <>0 and is_delete='N' and batch_status!= 'CLOSED' )as a group by encounterid order by created_date_and_time desc");
           ilstVoucherNo = new ArrayList(sqlquery.List());

            //sqlquery = iMySession.CreateSQLQuery("select distinct concat('VN',voucher_no),created_date_and_time from visit_payment where human_id='" + ulHumanID + "' and voucher_no <>0 and is_delete='N' and batch_status!= 'CLOSED' order by voucher_no");
            //ilstVoucherNoVoucher = new ArrayList(sqlquery.List());

            //ilstVoucherNo.AddRange(ilstVoucherNoVoucher);

            return ilstVoucherNo;
        }



        #endregion
    }
}
