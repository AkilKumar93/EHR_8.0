using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IPhysicianResultsManager : IManagerBase<PhysicianResults, ulong>
    {
        IList<PhysicianResults> GetPhysicianResults(ulong PhysicianID, string sLegalOrg);
        //IList<PhysicianResults> GetLoincCodes(string LoincDescription);
    }
    public partial class PhysicianResultsManager : ManagerBase<PhysicianResults, ulong>, IPhysicianResultsManager
    {
        #region Constructors

        public PhysicianResultsManager()
            : base()
        {

        }
        public PhysicianResultsManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methodsa
        public IList<PhysicianResults> GetPhysicianResults(ulong PhysicianID,string sLegalOrg)
        {
            IList<PhysicianResults> physicianResultsList = new List<PhysicianResults>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var query = @"SELECT * 
                              FROM   PHYSICIAN_RESULTS 
                              WHERE  (PHYSICIAN_ID = :PHYSICIANID 
                                      OR PHYSICIAN_ID = '0')
                                    AND LEGAL_ORG = '" + sLegalOrg + "' ORDER  BY SORT_ORDER ";

                ISQLQuery sq = iMySession.CreateSQLQuery(query).AddEntity(typeof(PhysicianResults));
                sq.SetParameter("PHYSICIANID", PhysicianID);
                physicianResultsList = sq.List<PhysicianResults>();

                iMySession.Close();
            }
            return physicianResultsList;
        }

        //public IList<PhysicianResults> GetLoincCodes(string LoincDescription)
        //{
        //    IList<PhysicianResults> physicianResultsList = new List<PhysicianResults>();
        //    physicianResultsList = GetAll();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ISQLQuery sq = iMySession.CreateSQLQuery("Select * from physician_results where Result_Description in ( " + LoincDescription + " ) order by Result_Code ").AddEntity(typeof(PhysicianResults));
        //        physicianResultsList = sq.List<PhysicianResults>();

        //        iMySession.Close();
        //    }
        //    return physicianResultsList;
        //}

        #endregion
    }
}
