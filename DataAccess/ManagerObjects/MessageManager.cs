using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IMessageManager : IManagerBase<Message, ulong>
    {
        IList<Message> GetAllMailMessagesForPatient(int HumanID);
        void SaveMessage(IList<Message> SaveList, string MacAddress);
        //AddorViewMessageDTO GetMessageItemAllMessage(ulong MyHumanId, ulong ChargeLineItemId, string MessageType, int PageNumber, int MaxResultSet);


        //Boolean SaveMessageWithoutTransaction(IList<Message> ilistMessage, ISession MySession);
        int SaveMessageWithoutTransaction(IList<Message> SaveList, ISession MySession, string MacAddress);
        IList<Message> GetMessageByHumanIdChargePPLineID(ulong HumanID, ulong ChargePPID, string[] MessageType);
        //added by srividhya on 09-mar-2012
        void SaveMessageWithTransaction(IList<Message> SaveList, IList<Message> UpdateList, string MacAddress);
        Message GetMessageForChargeLineItem(ulong ulHumanID, ulong ulChargeLineID);
        IList<Message> GetMessageType(int HumanID);
        IList<Message> GetChargelineitem(int HumanID, string MessageType);
        IList<Message> GetMessageDetail(int HumanID);
        //Added by Gopal
        //IList<MessageDTO> GetMessageByHumanIdAndChargeLineItemID(string sHumanId, string sChargeLineItemID);

    }

    public partial class MessageManager : ManagerBase<Message, ulong>, IMessageManager
    {
        #region Constructors

        public MessageManager()
            : base()
        {

        }
        public MessageManager
            (INHibernateSession session)
            : base(session)
        {

        }

        #endregion

        public IList<Message> GetAllMailMessagesForPatient(int HumanID)
        {
            IList<Message> MessageList = new List<Message>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select m.* from message m where m.human_id = '" + HumanID.ToString() + "'")
                    .AddEntity("m", typeof(Message));

                MessageList = sql.List<Message>();
                iMySession.Close();
            }

            return MessageList;
        }

        public void SaveMessage(IList<Message> SaveList,string MacAddress)
        {
            //Commented by vaishali on 23-03-2016 not used anywhere
            //SaveUpdateDeleteWithTransaction(ref SaveList, null, null, MacAddress);
        }

        //public AddorViewMessageDTO GetMessageItemAllMessage(ulong MyHumanId, ulong ChargeLineItemId, string MessageType, int PageNumber, int MaxResultSet)
        //{
        //    AddorViewMessageDTO objAddViewMessage = new AddorViewMessageDTO();
        //    string sWhereCriteria = string.Empty;
        //    int iPagenumber = PageNumber - 1;
        //    Message objMessage;
        //    if (MyHumanId != 0 && MessageType != string.Empty)
        //        sWhereCriteria = "M.Human_ID =" + MyHumanId.ToString() + " AND M.Message_Type = '" + MessageType + "'";
        //    else if (ChargeLineItemId != 0 && MessageType != string.Empty)
        //        sWhereCriteria = "M.charge_pp_line_id =" + ChargeLineItemId.ToString() + " AND  M.Message_Type = '" + MessageType + "'";
        //    else if (MyHumanId != 0 && MessageType == string.Empty)
        //        sWhereCriteria = "M.Human_ID =" + MyHumanId.ToString();
        //    else if (ChargeLineItemId != 0 && MessageType == string.Empty)
        //        sWhereCriteria = "M.charge_pp_line_id =" + ChargeLineItemId.ToString();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        object Count = iMySession.CreateSQLQuery("SELECT count(*) FROM message M Left join statement_chargeline S on m.Statement_ChargeLine_ID = s.Statement_ChargeLine_ID WHERE " + sWhereCriteria + " Order BY M.Message_Date DESC,M.Created_Date_And_Time DESC").List<object>()[0];
        //        objAddViewMessage.TotalCount = Convert.ToInt32(Count);

        //        ISQLQuery sql = iMySession.CreateSQLQuery("SELECT M.*,S.* FROM message M Left join statement_chargeline S on m.Statement_ChargeLine_ID = s.Statement_ChargeLine_ID WHERE " + sWhereCriteria + " Order BY M.Message_Date DESC,M.Created_Date_And_Time DESC limit " + (iPagenumber * MaxResultSet) + "," + MaxResultSet + "")
        //           .AddEntity("M", typeof(Message)).AddEntity("S", typeof(Statement_Chargeline));

        //        foreach (IList<Object> l in sql.List())
        //        {
        //            objMessage = new Message();
        //            Message objMessageTemp = (Message)l[0];
        //            Statement_Chargeline objStmnt = (Statement_Chargeline)l[1];

        //            objMessage.Id = objMessageTemp.Id;
        //            objMessage.Human_ID = objMessageTemp.Human_ID;
        //            objMessage.Charge_PP_Line_ID = objMessageTemp.Charge_PP_Line_ID;
        //            objMessage.Message_Type = objMessageTemp.Message_Type;
        //            objMessage.Message_Text = objMessageTemp.Message_Text;
        //            objMessage.Created_By = objMessageTemp.Created_By;
        //            objMessage.Message_Date = objMessageTemp.Message_Date;
        //            objMessage.Created_Date_And_Time = objMessageTemp.Created_Date_And_Time;
        //            objMessage.Statement_ChargeLine_ID = Convert.ToInt32(objStmnt.Patient_Statement_ID);
        //            objAddViewMessage.MessageList.Add(objMessage);
        //        }
        //        iMySession.Close();
        //    }
        //    return objAddViewMessage;
        //}


        public int UpdateMessageWithoutTransaction(IList<Message> ilistMessage, ISession MySession, string MacAddress)
        {
            //IList<Message> InsertList = null;
            int iResult = 0;
            //Commented by vaishali on 23-03-2016 not used anywhere
            //iResult = SaveUpdateDeleteWithoutTransaction(ref ilistMessage, InsertList, null, MySession, MacAddress);
            return iResult;
        }

        public int SaveMessageWithoutTransaction(IList<Message> SaveList, ISession MySession, string MacAddress)
        {
            //Boolean bResult = false;
            int iResult = 0;
            //Commented by vaishali on 23-03-2016 not used anywhere
            //iResult = SaveUpdateDeleteWithoutTransaction(ref SaveList, null, null, MySession, MacAddress);
            return iResult;
        }

        public IList<Message> GetMessageByHumanIdChargePPLineID(ulong HumanID, ulong ChargePPID, string[] MessageType)
        {
            string sWhereCriteria = string.Empty;
            IList<Message> lstMsg = new List<Message>();
            if (MessageType.Length > 0)
            {
                sWhereCriteria = " AND (";
                for (int iTemp = 0; iTemp <= MessageType.Length - 1; iTemp++)
                {
                    sWhereCriteria = sWhereCriteria + "P.message_type = " + "\"" + MessageType[iTemp] + "\"";
                    if (iTemp != MessageType.Length - 1)
                    {
                        sWhereCriteria = sWhereCriteria + " OR ";
                    }
                }
                sWhereCriteria = sWhereCriteria + ")";
            }
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT P.* FROM message P WHERE P.human_id = " + HumanID + " AND P.charge_pp_line_id = " + ChargePPID + sWhereCriteria + " ORDER BY P.Created_Date_And_Time DESC")
                    .AddEntity("P", typeof(Message));
                lstMsg = sql.List<Message>();
                iMySession.Close();
            }
            return lstMsg;
        }

        public void SaveMessageWithTransaction(IList<Message> SaveList, IList<Message> UpdateList, string MacAddress)
        {
            //Commented by vaishali on 23-03-2016 not used anywhere
            if (SaveList != null)
            {
                //SaveUpdateDeleteWithTransaction(ref SaveList, null, null, MacAddress);
            }
            else
            {
                //IList<Message> MessageList = null;
                //SaveUpdateDeleteWithTransaction(ref MessageList, UpdateList, null, MacAddress);
            }
        }
        public Message GetMessageForChargeLineItem(ulong ulHumanID, ulong ulChargeLineID)
        {
            IList<Message> MessageList = new List<Message>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select m.* from message m where m.human_id = '" + ulHumanID.ToString() + "' and m.charge_pp_line_id='" + ulChargeLineID + "'")
                    .AddEntity("m", typeof(Message));

                MessageList = sql.List<Message>();
                iMySession.Close();
            }

            if (MessageList.Count > 0)
                return MessageList[0];
            else
                return null;
        }
        public IList<Message> GetMessageType(int HumanID)
        {
            IList<Message> MessageList = new List<Message>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery queryMessages = iMySession.GetNamedQuery("Get.MessageType.From.Message");
                //queryDenialAction.SetString(0, HumanID);
                queryMessages.SetString(0, Convert.ToString(HumanID));

                ArrayList aryMessage = new ArrayList();
                aryMessage = new ArrayList(queryMessages.List());
                foreach (Object obj in aryMessage)
                {
                    Message objmessage = new Message();
                    objmessage.Message_Type = Convert.ToString(obj);
                    MessageList.Add(objmessage);
                }
                iMySession.Close();
            }
            return MessageList;
        }

        public IList<Message> GetChargelineitem(int HumanID, string MessageType)
        {
            IList<Message> Message = new List<Message>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery chargelineitem = iMySession.GetNamedQuery("Get.chargelineitem");
                chargelineitem.SetString(0, Convert.ToString(HumanID));
                chargelineitem.SetString(1, Convert.ToString(MessageType));
                ArrayList arrymessage = new ArrayList();

                arrymessage = new ArrayList(chargelineitem.List());
                foreach (object[] obj in arrymessage)
                {
                    Message objmessage = new Message();
                    objmessage.Message_Date = Convert.ToDateTime(obj[0]);
                    objmessage.Created_By = Convert.ToString(obj[1]);
                    objmessage.Message_Type = Convert.ToString(obj[2]);
                    objmessage.Message_Text = Convert.ToString(obj[3]);
                    objmessage.Charge_PP_Line_ID = Convert.ToInt32(obj[4]);
                    objmessage.Statement_ChargeLine_ID = Convert.ToInt32(obj[5]);
                    Message.Add(objmessage);
                }
                iMySession.Close();
            }
            return Message;
        }

        public IList<Message> GetMessageDetail(int HumanID)
        {
            IList<Message> Message = new List<Message>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery queryMessagedetail = iMySession.GetNamedQuery("Get.MessageDetail");
                queryMessagedetail.SetString(0, Convert.ToString(HumanID));
                ArrayList arryMessage = new ArrayList();
                arryMessage = new ArrayList(queryMessagedetail.List());
                foreach (object[] obj in arryMessage)
                {
                    Message objmessage = new Message();
                    objmessage.Message_Date = Convert.ToDateTime(obj[0]);
                    objmessage.Created_By = Convert.ToString(obj[1]);
                    objmessage.Message_Type = Convert.ToString(obj[2]);
                    objmessage.Message_Text = Convert.ToString(obj[3]);
                    objmessage.Charge_PP_Line_ID = Convert.ToInt32(obj[4]);
                    objmessage.Statement_ChargeLine_ID = Convert.ToInt32(obj[5]);
                    Message.Add(objmessage);
                }
                iMySession.Close();
            }
            return Message;
        }
        //Added by Gopal - 20130405

        //public IList<MessageDTO> GetMessageByHumanIdAndChargeLineItemID(string sHumanId, string sChargeLineItemID)
        //{
        //    IList<MessageDTO> MessageList = new List<MessageDTO>();
        //    MessageDTO objDenialMessage;
        //    string sDenialId = string.Empty;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery queryMessage = iMySession.GetNamedQuery("Get.AllCommentsForLineItem.From.MessageAndDenial");
        //        queryMessage.SetString(0, sHumanId);
        //        queryMessage.SetString(1, sChargeLineItemID);
        //        queryMessage.SetString(2, sChargeLineItemID);
        //        ArrayList aryMessage = new ArrayList();
        //        aryMessage = new ArrayList(queryMessage.List());

        //        if (aryMessage.Count != 0)
        //        {

        //            for (int i = 0; i < aryMessage.Count; i++)
        //            {
        //                object[] obj = (object[])aryMessage[i];
        //                objDenialMessage = new MessageDTO();
        //                objDenialMessage.Created_By = obj[0].ToString();
        //                objDenialMessage.Created_Date = obj[1].ToString();
        //                objDenialMessage.Notes = obj[2].ToString();
        //                objDenialMessage.Origin = "ChargePosting/PaymentPosting/DenialCapture";
        //                sDenialId = obj[3].ToString();
        //                MessageList.Add(objDenialMessage);
        //            }
        //        }
        //        IQuery queryDenialAction = iMySession.GetNamedQuery("Get.AllCommentsForLineItem.From.DenialAction");
        //        queryDenialAction.SetString(0, sChargeLineItemID);
        //        ArrayList aryDenialAction = new ArrayList();
        //        aryDenialAction = new ArrayList(queryDenialAction.List());
        //        string sDenialActionNotes = string.Empty;
        //        for (int i = 0; i < aryDenialAction.Count; i++)
        //        {
        //            objDenialMessage = new MessageDTO();
        //            object[] obj = (object[])aryDenialAction[i];
        //            objDenialMessage.Created_By = obj[1].ToString();
        //            objDenialMessage.Created_Date = obj[2].ToString();
        //            objDenialMessage.Denial_Action = obj[3].ToString();
        //            objDenialMessage.Notes = obj[0].ToString();
        //            objDenialMessage.Origin = "Denial Action";
        //            MessageList.Add(objDenialMessage);
        //        }
        //        iMySession.Close();
        //    }
        //    return MessageList;
        //}
    }
}
