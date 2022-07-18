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
    public partial interface IOrdersQuestionSetAfpManager : IManagerBase<OrdersQuestionSetAfp, ulong>
    {
        int BatchOperationsToOrdersQuestionSetAfp(IList<OrdersQuestionSetAfp> saveList, IList<OrdersQuestionSetAfp> updtList, IList<OrdersQuestionSetAfp> delList, ISession MySession, string MACAddress);
        OrdersQuestionSetAfp GetOrderID(ulong OrderSubmitID);
        IList<StaticLookup> GetStaticLookup(string FieldName);
        OrdersQuestionSetAfp SaveAFP(ulong OrderSubmitID, OrdersQuestionSetAfp objAFP);
    }
    public partial class OrdersQuestionSetAfpManager : ManagerBase<OrdersQuestionSetAfp, ulong>, IOrdersQuestionSetAfpManager
    {
         #region Constructors

        public OrdersQuestionSetAfpManager()
            : base()
        {

        }
        public OrdersQuestionSetAfpManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion
        #region IOrdersQuestionSetAfpManager Members

        public int BatchOperationsToOrdersQuestionSetAfp(IList<OrdersQuestionSetAfp> saveList, IList<OrdersQuestionSetAfp> updtList, IList<OrdersQuestionSetAfp> delList, ISession MySession, string MACAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            //return SaveUpdateDeleteWithoutTransaction(ref saveList, updtList, delList, MySession, MACAddress);
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref saveList, ref updtList, delList, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        public OrdersQuestionSetAfp GetOrderID(ulong OrderSubmitID)
        {           
            OrdersQuestionSetAfp objOrdersQuestionSetAfp = new OrdersQuestionSetAfp();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select o.* from orders o where o.order_submit_id='" + OrderSubmitID + "'").AddEntity("o", typeof(Orders));
                IList<Orders> ilstOrderID = sql.List<Orders>();
                if (ilstOrderID.Count > 0)
                {
                    if (ilstOrderID[0].Id != null)
                    {
                        ISQLQuery sqlAFP = session.GetISession().CreateSQLQuery("Select a.* from orders_question_set_afp a where a.Order_ID='" + ilstOrderID[0].Id + "'").AddEntity("a", typeof(OrdersQuestionSetAfp));
                        IList<OrdersQuestionSetAfp> ilstAFP = sqlAFP.List<OrdersQuestionSetAfp>();
                        if (ilstAFP.Count > 0)
                        {
                            objOrdersQuestionSetAfp = ilstAFP.ToList()[0];
                        }
                    }
                }
                iMySession.Close();
            }
            return objOrdersQuestionSetAfp;
        }

        public IList<StaticLookup> GetStaticLookup(string FieldName)
        {
            IList<StaticLookup> ilstStaticLookup =new List<StaticLookup>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select s.* from static_lookup s where s.field_name='" + FieldName + "'").AddEntity("s", typeof(StaticLookup));
               ilstStaticLookup = sql.List<StaticLookup>();
                iMySession.Close();
            }
            return ilstStaticLookup;
        }

        public OrdersQuestionSetAfp SaveAFP(ulong OrderSubmitID, OrdersQuestionSetAfp objAFP)
        {
            GenerateXml XMLObj = new GenerateXml();
            OrdersQuestionSetAfp objOrdersQuestionSetAfp = new OrdersQuestionSetAfp();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select o.* from orders o where o.Order_Submit_ID='" + OrderSubmitID + "' and o.orders_question_set_segment='ZSA'").AddEntity("o", typeof(Orders));
                IList<Orders> ilstOrderID = sql.List<Orders>();
                if (ilstOrderID.Count > 0)
                {
                    foreach (Orders orderid in ilstOrderID)
                    {
                        ISQLQuery sqlcytology = iMySession.CreateSQLQuery("Select a.* from orders_question_set_afp a where a.order_id='" + orderid.Id + "'").AddEntity("a", typeof(OrdersQuestionSetAfp));
                        IList<OrdersQuestionSetAfp> ilstOrdersQuestionSetAfp = sqlcytology.List<OrdersQuestionSetAfp>();
                        if (ilstOrdersQuestionSetAfp.Count > 0)
                        {
                            IList<OrdersQuestionSetAfp> savelist = new List<OrdersQuestionSetAfp>();
                            IList<OrdersQuestionSetAfp> savelistnull = null;
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelist, ref savelistnull, ilstOrdersQuestionSetAfp, string.Empty, false, false, 0, string.Empty);
                            //SaveUpdateDeleteWithTransaction(ref savelist, null, ilstOrdersQuestionSetAfp, string.Empty);
                            objAFP.Order_ID = orderid.Id;
                            savelist.Add(objAFP);
                            //SaveUpdateDeleteWithTransaction(ref savelist, null, null, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelist, ref savelistnull, null, string.Empty, false, false, 0, string.Empty);
                        }
                        else
                        {
                            IList<OrdersQuestionSetAfp> savelist = new List<OrdersQuestionSetAfp>();
                            objAFP.Order_ID = orderid.Id;
                            savelist.Add(objAFP);
                            IList<OrdersQuestionSetAfp> savelistnull = null;
                            //SaveUpdateDeleteWithTransaction(ref savelist, null, null, string.Empty);
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelist, ref savelistnull, null, string.Empty, false, false, 0, string.Empty);
                        }
                    }
                }
                iMySession.Close();
            }
            return objOrdersQuestionSetAfp;
        }

        #endregion
    }
}






