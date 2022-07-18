using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IOrdersProblemListManager : IManagerBase<OrdersProblemList, ulong>
    {
        int BatchOperationsToOrdersProblemList(IList<OrdersProblemList> savelist, IList<OrdersProblemList> updtList, IList<OrdersProblemList> delList, ISession MySession, string MACAddress);
    }
    public partial class OrdersProblemListManager:ManagerBase<OrdersProblemList,ulong>,IOrdersProblemListManager
    {
          #region Constructors

          public OrdersProblemListManager()
            : base()
        {

        }
          public OrdersProblemListManager
              (INHibernateSession session)
              : base(session)
          {
          }

        #endregion

          #region IOrdersProblemListManager Members

          public int BatchOperationsToOrdersProblemList(IList<OrdersProblemList> savelist, IList<OrdersProblemList> updtList, IList<OrdersProblemList> delList, ISession MySession, string MACAddress)
          {
              GenerateXml XMLObj = new GenerateXml();
              //return SaveUpdateDeleteWithoutTransaction(ref savelist, updtList, delList, MySession, MACAddress);
              return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref savelist, ref updtList, delList, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
          }

          #endregion
    }
}
