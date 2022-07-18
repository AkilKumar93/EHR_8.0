using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IProviderReviewTrackerManager : IManagerBase<ProviderReviewTracker, ulong>
    {
        IList<ProviderReviewTracker> GetReviewTrackerInfobyEncounterID(ulong Encounter_ID);
        void SaveUpdateProviderReviewTracker(ProviderReviewTracker SaveProvReviewTracker, ProviderReviewTracker UpdateProvReviewTracker);
    }
    public partial class ProviderReviewTrackerManager : ManagerBase<ProviderReviewTracker, ulong>, IProviderReviewTrackerManager
    {
         #region Constructors

        public ProviderReviewTrackerManager()
            : base()
        {

        }
        public ProviderReviewTrackerManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion 
        #region Methods

        public IList<ProviderReviewTracker> GetReviewTrackerInfobyEncounterID(ulong Encounter_ID)
        {
            IList<ProviderReviewTracker> lstProvRevTracker = new List<ProviderReviewTracker>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria icrit = iMySession.CreateCriteria(typeof(ProviderReviewTracker)).Add(Expression.Eq("Encounter_ID", Encounter_ID)).Add(Expression.Eq("Status","Active"));
                lstProvRevTracker = icrit.List<ProviderReviewTracker>();
                iMySession.Close();
            }
            return lstProvRevTracker;
        }

        public void SaveUpdateProviderReviewTracker(ProviderReviewTracker SaveProvReviewTracker,ProviderReviewTracker UpdateProvReviewTracker)
        {
            IList<ProviderReviewTracker> lstSave=new List<ProviderReviewTracker>();
             IList<ProviderReviewTracker> lstUpdate=new List<ProviderReviewTracker>();
             ulong HumanorEncID = 0;
             if (SaveProvReviewTracker!=null)
             lstSave.Add(SaveProvReviewTracker);
            if(UpdateProvReviewTracker!=null)
             lstUpdate.Add(UpdateProvReviewTracker);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref lstSave, ref lstUpdate, null, string.Empty, false, false, HumanorEncID, string.Empty);
        }
        #endregion
    }
}
