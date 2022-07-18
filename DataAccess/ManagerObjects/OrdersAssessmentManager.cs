using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IOrdersAssessmentManager : IManagerBase<OrdersAssessment, ulong>
    {
        int BatchOperationsToOrdersAssessment(IList<OrdersAssessment> savelist, IList<OrdersAssessment> updtList, IList<OrdersAssessment> delList, ISession MySession, string MACAddress);
        IList<OrdersAssessment> GetOrderAssessmentByOrderSubmitID(ulong OrdersSubmitID);

    }
    public partial class OrdersAssessmentManager:ManagerBase<OrdersAssessment,ulong>,IOrdersAssessmentManager
    {

        #region Constructors

          public OrdersAssessmentManager()
            : base()
        {

        }
          public OrdersAssessmentManager
              (INHibernateSession session)
              : base(session)
          {
          }

        #endregion


        #region IOrdersAssessmentManager Members

          public int BatchOperationsToOrdersAssessment(IList<OrdersAssessment> savelist, IList<OrdersAssessment> updtList, IList<OrdersAssessment> delList, ISession MySession, string MACAddress)
        {
            GenerateXml xmlobj = new GenerateXml();
             return SaveUpdateDeleteWithoutTransaction(ref savelist, updtList, delList, MySession,MACAddress);
        }
          public IList<OrdersAssessment> GetOrderAssessmentByOrderSubmitID(ulong OrdersSubmitID)
          {
              IList<OrdersAssessment> tempOrdersAssessment = new List<OrdersAssessment>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
                  //ISQLQuery sq = iMySession.CreateSQLQuery("select oa.* from orders_assessment oa where oa.order_id in(select order_id from orders where order_submit_id='" + OrdersSubmitID + "')")
                  ISQLQuery sq = iMySession.CreateSQLQuery("select oa.* from orders_assessment oa where oa.order_submit_id in('" + OrdersSubmitID + "')")
                   .AddEntity("oa", typeof(OrdersAssessment));
                 
                  tempOrdersAssessment = sq.List<OrdersAssessment>();
                  iMySession.Close();
              }
              return tempOrdersAssessment;
          }
          public IList<Orders> GetOrders(ulong OrdersSubmitID)
          {
              IList<Orders> tempOrders = new List<Orders>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
                  ISQLQuery sq = iMySession.CreateSQLQuery("select oa.* from orders oa where oa.order_submit_id ='" + OrdersSubmitID + "'")
                   .AddEntity("oa", typeof(Orders));
                  
                  tempOrders = sq.List<Orders>();
                  iMySession.Close();
              }
              return tempOrders;
          }
        #endregion
    }
}
