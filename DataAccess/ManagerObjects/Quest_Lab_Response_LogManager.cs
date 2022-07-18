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

    public partial interface IQuest_Lab_Response_LogManager : IManagerBase<Quest_Lab_Response_Log, uint>
    {
        IList<Quest_Lab_Response_Log> GetQuestResponseUsingOrderSubmitID(ulong ObjSystemID);
    }

    public partial class Quest_Lab_Response_LogManager : ManagerBase<Quest_Lab_Response_Log, uint>, IQuest_Lab_Response_LogManager
    {
        #region Constructors

        public Quest_Lab_Response_LogManager()
            : base()
        {

        }
        public Quest_Lab_Response_LogManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods
        public IList<Quest_Lab_Response_Log> GetQuestResponseUsingOrderSubmitID(ulong ObjSystemID)
        {
            IList<Quest_Lab_Response_Log> lstQuestLabResponseLog = new List<Quest_Lab_Response_Log>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Quest_Lab_Response_Log)).Add(Expression.Eq("Order_Submit_ID", ObjSystemID));
                lstQuestLabResponseLog = criteria.List<Quest_Lab_Response_Log>();
                iMySession.Close();
            }

            return lstQuestLabResponseLog;
        }
        #endregion
    }
}
