using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Data;
using System.IO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
     public partial interface IRequestSentLogManager : IManagerBase<Request_Sent_Log, ulong>
    {
        void SaveToRequestSentLog(ref IList<Request_Sent_Log> Req_Sent_Log);
    }
     public partial class RequestSentLogManager : ManagerBase<Request_Sent_Log, ulong>, IRequestSentLogManager
     {
         #region Constructors

         public RequestSentLogManager()
             : base()
         {

         }
         public RequestSentLogManager
             (INHibernateSession session)
             : base(session)
         {

         }
         #endregion

         public void SaveToRequestSentLog(ref IList<Request_Sent_Log> Req_Sent_Log)
         {
             IList<Request_Sent_Log> SaveListTemp = null;
             IList<Request_Sent_Log> saveList = Req_Sent_Log;
             IList<Request_Sent_Log> UpdateList = null;
             IList<Request_Sent_Log> DeleteList = null;
             ulong EncorHumanID = 0;
             SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref UpdateList, DeleteList, string.Empty, false, false, EncorHumanID, string.Empty);
             for(int iNumber=0;iNumber<saveList.Count;iNumber++)
             {
                 saveList[iNumber].Request_Sent_Log_Group_ID = saveList[0].Id;
             }
             SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveListTemp, ref saveList, DeleteList, string.Empty, false, false, EncorHumanID, string.Empty);
         }
     }
}
