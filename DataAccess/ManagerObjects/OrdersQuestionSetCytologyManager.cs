using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IOrdersQuestionSetCytologyManager : IManagerBase<OrdersQuestionSetCytology, ulong>
    {
        int BatchOperationsToOrdersQuestionSetCytology(IList<OrdersQuestionSetCytology> saveList, IList<OrdersQuestionSetCytology> updtList, IList<OrdersQuestionSetCytology> delList, ISession MySession, string MACAddress);
        OrdersQuestionSetCytology GetQuestionSetCytology(ulong OrderSubmitID);
        OrdersQuestionSetCytology SaveCytology(ulong OrderSubmitID, OrdersQuestionSetCytology objCytology);
    }
    public partial class OrdersQuestionSetCytologyManager : ManagerBase<OrdersQuestionSetCytology, ulong>, IOrdersQuestionSetCytologyManager
    {
        #region Constructors

        public OrdersQuestionSetCytologyManager()
            : base()
        {

        }
        public OrdersQuestionSetCytologyManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion
        #region IOrdersQuestionSetCytologyManager Members

        public int BatchOperationsToOrdersQuestionSetCytology(IList<OrdersQuestionSetCytology> saveList, IList<OrdersQuestionSetCytology> updtList, IList<OrdersQuestionSetCytology> delList, ISession MySession, string MACAddress)
        {
            //return SaveUpdateDeleteWithoutTransaction(ref saveList, updtList, delList, MySession, MACAddress);
            GenerateXml XMLObj = new GenerateXml();
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref saveList, ref updtList, delList, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
            
        }

        public OrdersQuestionSetCytology GetQuestionSetCytology(ulong OrderSubmitID)
        {           
            OrdersQuestionSetCytology objOrdersQuestionSetCytology = new OrdersQuestionSetCytology();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select o.* from Orders o where o.Order_Submit_ID='" + OrderSubmitID + "'").AddEntity("o", typeof(Orders));
                IList<Orders> ilstOrderID = sql.List<Orders>();
                IList<OrdersQuestionSetCytology> ilstOrdersQuestionSetCytology = new List<OrdersQuestionSetCytology>();
                if (ilstOrderID.Count > 0)
                {
                    if (ilstOrderID[0].Id != null)
                    {
                        ISQLQuery sqlCytology = session.GetISession().CreateSQLQuery("Select c.* from orders_question_set_cytology c where c.Order_Id='" + ilstOrderID[0].Id + "'").AddEntity("c", typeof(OrdersQuestionSetCytology));
                        ilstOrdersQuestionSetCytology = sqlCytology.List<OrdersQuestionSetCytology>();
                        if (ilstOrdersQuestionSetCytology.Count > 0)
                        {
                            objOrdersQuestionSetCytology = ilstOrdersQuestionSetCytology.ToList()[0];
                        }

                    }
                }
                iMySession.Close();
            }
            return objOrdersQuestionSetCytology;
        }

        public OrdersQuestionSetCytology SaveCytology(ulong OrderSubmitID, OrdersQuestionSetCytology objCytology)
        {            
            OrdersQuestionSetCytology objOrdersQuestionSetCytology = new OrdersQuestionSetCytology();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select o.* from orders o where o.Order_Submit_ID='" + OrderSubmitID + "' and o.orders_question_set_segment='zcy'").AddEntity("o", typeof(Orders));
                IList<Orders> ilstOrderID = sql.List<Orders>();
                if (ilstOrderID.Count > 0)
                {
                    foreach (Orders orderid in ilstOrderID)
                    {
                        ISQLQuery sqlcytology = session.GetISession().CreateSQLQuery("Select c.* from orders_question_set_cytology c where c.order_id='" + orderid.Id + "'").AddEntity("c", typeof(OrdersQuestionSetCytology));
                        IList<OrdersQuestionSetCytology> ilstOrdersQuestionSetCytology = sqlcytology.List<OrdersQuestionSetCytology>();
                        IList<OrdersQuestionSetCytology> savelistnull = null;
                        if (ilstOrdersQuestionSetCytology.Count > 0)
                        {
                            IList<OrdersQuestionSetCytology> savelist = new List<OrdersQuestionSetCytology>();                            
                            //SaveUpdateDeleteWithTransaction(ref savelist, null, ilstOrdersQuestionSetCytology, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelist, ref savelistnull, ilstOrdersQuestionSetCytology, string.Empty, false, false, 0, string.Empty);
                            objCytology.Order_ID = orderid.Id;
                            savelist.Add(objCytology);
                            SaveUpdateDeleteWithTransaction(ref savelist, null, null, string.Empty);
                        }
                        else
                        {
                            IList<OrdersQuestionSetCytology> savelist = new List<OrdersQuestionSetCytology>();
                            objCytology.Order_ID = orderid.Id;
                            savelist.Add(objCytology);
                            //SaveUpdateDeleteWithTransaction(ref savelist, null, null, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelist, ref savelistnull, null, string.Empty, false, false, 0, string.Empty);
                        }
                    }
                }
                iMySession.Close();
            }
            return objOrdersQuestionSetCytology;
        }

        #endregion
    }
}




