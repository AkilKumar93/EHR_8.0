using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public interface IVisitPaymentHistoryArcManager : IManagerBase<VisitPaymentHistoryArc, ulong>
    {        
        int SaveVisitPaymentWithoutTransaction(IList<VisitPaymentHistoryArc> ListToInsert, ISession MySession, string MACAddress);
        
    }
    public partial class VisitPaymentHistoryArcManager : ManagerBase<VisitPaymentHistoryArc, ulong>, IVisitPaymentHistoryArcManager
    {
        #region Constructors

        public VisitPaymentHistoryArcManager()
            : base()
        {

        }
        public VisitPaymentHistoryArcManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods        

        //int iTryCount = 0;
       

        public int SaveVisitPaymentWithoutTransaction(IList<VisitPaymentHistoryArc> ListToInsert, ISession MySession, string MACAddress)
        {
            int iResult = 0;
            GenerateXml ObjXML = null;
            IList<VisitPaymentHistoryArc> VisitPaymentTemp = null;
            if ((ListToInsert != null))
            {
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref VisitPaymentTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
            }
            return iResult;
        }
       

     
       
        #endregion
    }            
}
