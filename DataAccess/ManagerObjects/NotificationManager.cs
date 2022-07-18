using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface INotificationManager : IManagerBase<Notification, ulong>
    {
        IList<Notification> GetNotificationForHumanID(ulong ulHumanID, ulong uEncounterID);
        IList<Notification> SaveUpdateDeleteNotification(IList<Notification> SaveNotification, IList<Notification> UpdateNotification, IList<Notification> DeleteNotification, ulong ulHumanID, ulong ulEncounterID);
        IList<Notification> GetNotificationForHumanIDandEncounterIDwithActiveSatus(ulong ulHumanID, ulong uEncounterID);
    }

    public partial class NotificationManager : ManagerBase<Notification, ulong>, INotificationManager
    {
        #region Constructors

        public NotificationManager()
            : base()
        {

        }
        public NotificationManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<Notification> GetNotificationForHumanID(ulong ulHumanID,ulong uEncounterID)
        {
            IList<Notification> NotificationList = new List<Notification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlqueryHuman = iMySession.CreateSQLQuery("select h.* from notifications h   where h.Human_ID='" + ulHumanID + "' and h.encounter_id in ('" + uEncounterID + "','0')").AddEntity("h", typeof(Notification));
                NotificationList = sqlqueryHuman.List<Notification>();
                iMySession.Close();
            }
            return NotificationList;
        }

        public IList<Notification> GetNotificationForHumanIDandEncounterIDwithActiveSatus(ulong ulHumanID, ulong uEncounterID)
        {
            IList<Notification> NotificationList = new List<Notification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlqueryHuman = iMySession.CreateSQLQuery("select h.* from notifications h   where h.Human_ID='" + ulHumanID + "' and h.encounter_id in ('" + uEncounterID + "') and status='active'" ).AddEntity("h", typeof(Notification));
                NotificationList = sqlqueryHuman.List<Notification>();
                iMySession.Close();
            }
            return NotificationList;
        }


        public IList<Notification> SaveUpdateDeleteNotification(IList<Notification> SaveNotification, IList<Notification> UpdateNotification, IList<Notification> DeleteNotification, ulong ulHumanID, ulong ulEncounterID)
        {
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveNotification, ref UpdateNotification, DeleteNotification, string.Empty, false, false, 0, string.Empty);

            IList<Notification> NotificationList = new List<Notification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlqueryHuman = iMySession.CreateSQLQuery("select h.* from notifications h   where h.Human_ID='" + ulHumanID + "' and h.Encounter_ID in ('" + ulEncounterID + "','0')").AddEntity("h", typeof(Notification));
                NotificationList = sqlqueryHuman.List<Notification>();
                iMySession.Close();
            }
            return NotificationList;
        }
    }
}
