using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using System.Collections;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IOrdersQuestionSetAOEManager : IManagerBase<OrdersQuestionSetAOE, ulong>
    {
        int BatchOperationsToOrdersQuestionSetAOE(IList<OrdersQuestionSetAOE> saveList, IList<OrdersQuestionSetAOE> updtList, IList<OrdersQuestionSetAOE> delList, ISession MySession, string MACAddress);
        IList<OrdersQuestionSetAOE> GetAOEList(ulong OrderSubmitID);
        IList<OrdersQuestionSetAOE> SaveList(ulong OrderSubmitID, IList<OrdersQuestionSetAOE> ilstAOE);
    }
    public partial class OrdersQuestionSetAOEManager : ManagerBase<OrdersQuestionSetAOE, ulong>, IOrdersQuestionSetAOEManager
    {
          #region Constructors

        public OrdersQuestionSetAOEManager()
            : base()
        {

        }
        public OrdersQuestionSetAOEManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion
        #region IOrdersQuestionSetAOEManager Members

        public int BatchOperationsToOrdersQuestionSetAOE(IList<OrdersQuestionSetAOE> saveList, IList<OrdersQuestionSetAOE> updtList, IList<OrdersQuestionSetAOE> delList, ISession MySession, string MACAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref saveList, ref updtList, delList, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref saveList, updtList, delList, MySession, MACAddress);
        }

        public IList<OrdersQuestionSetAOE> GetAOEList(ulong OrderSubmitID)
        {
            IList<OrdersQuestionSetAOE> ilstAOE = new List<OrdersQuestionSetAOE>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlOrderID = iMySession.CreateSQLQuery("Select o.* from orders o where o.order_submit_id='" + OrderSubmitID + "'").AddEntity("o", typeof(Orders));
                IList<Orders> ilstOrderID = sqlOrderID.List<Orders>();               
                OrdersQuestionSetAOE objOrdersQuestionSetAOE = new OrdersQuestionSetAOE();
                if (ilstOrderID.Count > 0)
                {
                    for (int i = 0; i < ilstOrderID.Count; i++)
                    {
                        ISQLQuery sql = iMySession.CreateSQLQuery("Select a.* from orders_question_set_aoe a where a.Orders_ID='" + ilstOrderID[i].Id + "'").AddEntity("a", typeof(OrdersQuestionSetAOE));
                        ArrayList arr = new ArrayList(sql.List());
                        if (arr.Count > 0)
                        {
                            for (int j = 0; j < arr.Count; j++)
                            {
                                objOrdersQuestionSetAOE = (OrdersQuestionSetAOE)arr[j];
                                ilstAOE.Add(objOrdersQuestionSetAOE);
                            }

                        }
                    }
                }
                iMySession.Close();
            }
            return ilstAOE;
        }

        public IList<OrdersQuestionSetAOE> SaveList(ulong OrderSubmitID, IList<OrdersQuestionSetAOE> ilstAOE)
        {
            GenerateXml XMLObj = new GenerateXml();
            OrdersQuestionSetAOE objOrdersQuestionSetAOE = new OrdersQuestionSetAOE();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select o.* from orders o where o.Order_Submit_ID='" + OrderSubmitID + "'").AddEntity("o", typeof(Orders));
                IList<Orders> ilstOrderID = sql.List<Orders>();
                if (ilstOrderID.Count > 0)
                {
                    foreach (Orders orderid in ilstOrderID)
                    {
                        ISQLQuery sqlAOE = iMySession.CreateSQLQuery("Select a.* from orders_question_set_aoe a where a.orders_id='" + orderid.Id + "'").AddEntity("a", typeof(OrdersQuestionSetAOE));
                        IList<OrdersQuestionSetAOE> ilstOrdersQuestionSetAOE = sqlAOE.List<OrdersQuestionSetAOE>();
                        IList<OrdersQuestionSetAOE> savelistnull = null;
                        if (ilstOrdersQuestionSetAOE.Count > 0)
                        {
                            IList<OrdersQuestionSetAOE> savelist = new List<OrdersQuestionSetAOE>();                            
                            //SaveUpdateDeleteWithTransaction(ref savelist, null, ilstOrdersQuestionSetAOE, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelist, ref savelistnull, ilstOrdersQuestionSetAOE, string.Empty, false, false, 0, string.Empty);

                            IList<OrdersQuestionSetAOE> ilstSaveOrders = new List<OrdersQuestionSetAOE>();
                            ilstSaveOrders = (from aa in ilstAOE where aa.Order_Code == orderid.Lab_Procedure select aa).ToList<OrdersQuestionSetAOE>();
                            for (int i = 0; i < ilstSaveOrders.Count; i++)
                            {
                                if (ilstSaveOrders[i].Order_Code == orderid.Lab_Procedure)
                                {
                                    ilstSaveOrders[i].Orders_ID = orderid.Id;
                                }
                            }
                            //SaveUpdateDeleteWithTransaction(ref ilstSaveOrders, null, null, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref ilstSaveOrders, ref savelistnull, null, string.Empty, false, false, 0, string.Empty);
                        }
                        else
                        {
                            IList<OrdersQuestionSetAOE> ilstSaveOrders = new List<OrdersQuestionSetAOE>();
                            ilstSaveOrders = (from aa in ilstAOE where aa.Order_Code == orderid.Lab_Procedure select aa).ToList<OrdersQuestionSetAOE>();
                            for (int i = 0; i < ilstSaveOrders.Count; i++)
                            {
                                if (ilstSaveOrders[i].Order_Code == orderid.Lab_Procedure)
                                {
                                    ilstSaveOrders[i].Orders_ID = orderid.Id;
                                }
                            }
                            //SaveUpdateDeleteWithTransaction(ref ilstSaveOrders, null, null, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref ilstSaveOrders, ref savelistnull, null, string.Empty, false, false, 0, string.Empty);
                        }
                    }
                }
                iMySession.Close();
            }
            return ilstAOE;
        }

        #endregion
    }
}
