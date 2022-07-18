using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Globalization;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IOrdersQuestionSetBloodLeadManager : IManagerBase<OrdersQuestionSetBloodLead, ulong>
    {
        int BatchoperationsToOrdersQuestionSetBloodLead(IList<OrdersQuestionSetBloodLead> saveList, IList<OrdersQuestionSetBloodLead> updtList, IList<OrdersQuestionSetBloodLead> delList, ISession MySession, string MACAddress);
        //void SaveOrderQuestionSetBloodLead(ulong OrderID, OrdersQuestionSetBloodLead objOrdersQuestionSetBloodLead);
        OrdersQuestionSetBloodLead GetQuestionSetBloodLead(ulong OrderSubmitID);
        void SaveUpdateOrdersQuestionSetBloodLead(string OrderSubmitID, OrdersQuestionSetBloodLead objOrdersQuestionSetBloodLead, string UserName, string DateAndTime);
    }
    public partial class OrdersQuestionSetBloodLeadManager : ManagerBase<OrdersQuestionSetBloodLead, ulong>, IOrdersQuestionSetBloodLeadManager
    {
        #region Constructors

        public OrdersQuestionSetBloodLeadManager()
            : base()
        {

        }
        public OrdersQuestionSetBloodLeadManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion

        #region IOrdersQuestionSetBloodLeadManager Members

        public int BatchoperationsToOrdersQuestionSetBloodLead(IList<OrdersQuestionSetBloodLead> saveList, IList<OrdersQuestionSetBloodLead> updtList, IList<OrdersQuestionSetBloodLead> delList, ISession MySession, string MACAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
           // return SaveUpdateDeleteWithoutTransaction(ref saveList, updtList, delList, MySession, MACAddress);
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref saveList, ref updtList, delList, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        #endregion

        #region IOrdersQuestionSetBloodLeadManager Members


        public OrdersQuestionSetBloodLead GetQuestionSetBloodLead(ulong OrdersSubmitID)
        {
            IList<OrdersQuestionSetBloodLead> returnList =new List<OrdersQuestionSetBloodLead>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("select q.* from orders_question_set_blood_lead q where q.order_id in (select order_id from orders where order_submit_id='" + OrdersSubmitID + "')").AddEntity("q", typeof(OrdersQuestionSetBloodLead));
                 returnList = sql.List<OrdersQuestionSetBloodLead>();
                iMySession.Close();
            }
            if (returnList.Count > 0)
                return returnList[0];
            else
                return new OrdersQuestionSetBloodLead();


        }

        #endregion

        #region IOrdersQuestionSetBloodLeadManager Members


        public void SaveUpdateOrdersQuestionSetBloodLead(string OrderSubmitID, OrdersQuestionSetBloodLead objOrdersQuestionSetBloodLead, string UserName, string DateAndTime)
        {
            GenerateXml XMLObj = new GenerateXml();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                ISQLQuery sql = iMySession.CreateSQLQuery("select q.* from orders_question_set_blood_lead q where q.order_id in (select order_id from orders where order_submit_id='" + OrderSubmitID.ToString() + "')").AddEntity("q", typeof(OrdersQuestionSetBloodLead));
                IList<OrdersQuestionSetBloodLead> returnList = sql.List<OrdersQuestionSetBloodLead>();

                if (returnList.Count > 0)
                {
                    foreach (OrdersQuestionSetBloodLead obj in returnList)
                    {
                        IList<OrdersQuestionSetBloodLead> SaveList = new List<OrdersQuestionSetBloodLead>();
                        IList<OrdersQuestionSetBloodLead> UpdateList = new List<OrdersQuestionSetBloodLead>();
                        objOrdersQuestionSetBloodLead.Id = obj.Id;
                        objOrdersQuestionSetBloodLead.Version = obj.Version;
                        objOrdersQuestionSetBloodLead.Order_ID = obj.Order_ID;
                        objOrdersQuestionSetBloodLead.Created_By = obj.Created_By;
                        objOrdersQuestionSetBloodLead.Created_Date_And_Time = obj.Created_Date_And_Time;
                        objOrdersQuestionSetBloodLead.Modified_By = UserName;
                        objOrdersQuestionSetBloodLead.Modified_Date_And_Time = Convert.ToDateTime(DateAndTime);// DateTime.ParseExact(DateAndTime, "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                        UpdateList.Add(objOrdersQuestionSetBloodLead);
                        //SaveUpdateDeleteWithTransaction(ref SaveList, UpdateList, null, string.Empty);
                        SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref UpdateList, null, string.Empty, false, false, 0, string.Empty);
                    }


                }
                else
                {
                    ISQLQuery sqlOrderCode = iMySession.CreateSQLQuery("SELECT O.* FROM `order_code_library` O where O.order_code_question_set_segment='ZBL'").AddEntity("O", typeof(OrderCodeLibrary));
                    IList<string> BloodLeadLookup = new List<string>();
                    BloodLeadLookup = sqlOrderCode.List<OrderCodeLibrary>().Select(a => a.Order_Code).ToList<string>();
                    ISQLQuery sqlOne = session.GetISession().CreateSQLQuery("select o.* from orders o where o.order_submit_id='" + OrderSubmitID.ToString() + "'").AddEntity("o", typeof(Orders));
                    IList<Orders> TargetOrders = new List<Orders>();
                    TargetOrders = sqlOne.List<Orders>();
                    TargetOrders = TargetOrders.Where(a => BloodLeadLookup.Contains(a.Lab_Procedure)).ToList<Orders>();

                    foreach (Orders obj in TargetOrders)
                    {
                        IList<OrdersQuestionSetBloodLead> SaveList = new List<OrdersQuestionSetBloodLead>();
                        objOrdersQuestionSetBloodLead.Order_ID = obj.Id;
                        objOrdersQuestionSetBloodLead.Created_By = UserName;
                        objOrdersQuestionSetBloodLead.Created_Date_And_Time = Convert.ToDateTime(DateAndTime);// DateTime.ParseExact(DateAndTime, "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                        SaveList.Add(objOrdersQuestionSetBloodLead);
                        //SaveUpdateDeleteWithTransaction(ref SaveList, null, null, string.Empty);\
                        IList<OrdersQuestionSetBloodLead> SaveListnull = null;
                        SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref SaveListnull, null, string.Empty, false, false, 0, string.Empty);

                    }

                }

                iMySession.Close();
            }

        }

        #endregion
    }
}
