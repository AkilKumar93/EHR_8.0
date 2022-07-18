using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public interface IVisitPaymentHistoryManager : IManagerBase<VisitPaymentHistory, ulong>
    {        
        int SaveVisitPaymentWithoutTransaction(IList<VisitPaymentHistory> ListToInsert, ISession MySession, string MACAddress);
        
    }
    public partial class VisitPaymentHistoryManager : ManagerBase<VisitPaymentHistory, ulong>, IVisitPaymentHistoryManager
    {
        #region Constructors

        public VisitPaymentHistoryManager()
            : base()
        {

        }
        public VisitPaymentHistoryManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods        

       // int iTryCount = 0;
       

        public int SaveVisitPaymentWithoutTransaction(IList<VisitPaymentHistory> ListToInsert, ISession MySession, string MACAddress)
        {
            int iResult = 0;
            GenerateXml ObjXML = null;
            IList<VisitPaymentHistory> VisitPaymentTemp = null;
            if ((ListToInsert != null))
            {
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref VisitPaymentTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
            }
            return iResult;
        }
       

     
       
        #endregion
    }            
}
