using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IMasterVitalsManager : IManagerBase<MasterVitals, ulong>
    {
         string GetMasterVitalsDetails(string sVitalName);
         IList<MasterVitals> GetMasterVitalsList();
         
    }
    public partial class MasterVitalsManager : ManagerBase<MasterVitals, ulong>, IMasterVitalsManager
    {
        #region Constructors

        public MasterVitalsManager()
            : base()
        {

        }
        public MasterVitalsManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion


        public string GetMasterVitalsDetails(string sVitalName)
        {
            string masterVitals = string.Empty;

            try
            {
                using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                {
                    ICriteria crit = iMySession.CreateCriteria(typeof(MasterVitals)).Add(Expression.Eq("Vital_Name", sVitalName)).Add(Expression.Eq("Vital_Type", "Standard"));
                    masterVitals = crit.List<MasterVitals>()[0].Vital_Unit;
                    iMySession.Close();
                }
            }
            catch
            {
 
            }

            return masterVitals;
        }
        public IList<MasterVitals> GetMasterVitalsList()
        {          
            IList<MasterVitals> VitalsList = new List<MasterVitals>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(MasterVitals));
                VitalsList = crit.List<MasterVitals>();
                iMySession.Close();
            }
            return VitalsList;
        }

         
    }
}
