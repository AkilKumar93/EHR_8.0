using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IOrderComponentsManager : IManagerBase<OrderComponents, ulong>
    {
        IList<OrderComponents> GetByOrderCode(string OrderCode);
    }
    public partial class OrderComponentsManager : ManagerBase<OrderComponents, ulong>, IOrderComponentsManager
    {
         #region Constructors

        public OrderComponentsManager()
            : base()
        {

        }
        public OrderComponentsManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        public IList<OrderComponents> GetByOrderCode(string OrderCode)
        {
          
            IList<OrderComponents> ilstOrderComponents=new List<OrderComponents>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria cri = iMySession.CreateCriteria(typeof(OrderComponents)).Add(Expression.Eq("Order_Code", OrderCode));
                ilstOrderComponents = cri.List<OrderComponents>();
                iMySession.Close();
            }
            return ilstOrderComponents;
            
        }
        
    }
}
