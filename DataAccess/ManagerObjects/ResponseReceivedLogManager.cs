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
    public partial interface IResponseReceivedLogManager : IManagerBase<Response_Received_Log, ulong>
    {
        void SaveToResponseReceivedLog(ref IList<Response_Received_Log> Req_Sent_Log);
    }
    public partial class ResponseReceivedLogManager : ManagerBase<Response_Received_Log, ulong>, IResponseReceivedLogManager
    {
        #region Constructors

        public ResponseReceivedLogManager()
            : base()
        {

        }
        public ResponseReceivedLogManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public void SaveToResponseReceivedLog(ref IList<Response_Received_Log> Req_Sent_Log)
        {
            IList<Response_Received_Log> SaveListTemp = null;
            IList<Response_Received_Log> saveList = Req_Sent_Log;
            IList<Response_Received_Log> UpdateList = null;
            IList<Response_Received_Log> DeleteList = null;
            ulong EncorHumanID = 0;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref UpdateList, DeleteList, string.Empty, false, false, EncorHumanID, string.Empty);
            for (int iNumber = 0; iNumber < saveList.Count; iNumber++)
            {
                saveList[iNumber].Response_Received_Log_Group_ID = saveList[0].Id;
            }
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveListTemp, ref saveList, DeleteList, string.Empty, false, false, EncorHumanID, string.Empty);
        }
    }
}
