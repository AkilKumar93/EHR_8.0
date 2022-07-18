using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ICDSRuleMasterManager : IManagerBase<CDSRuleMaster, uint>
    {
        IList<CDSRuleMaster> getCDSRuleMasterByFieldName();
        IList<CDSRuleMaster> GellCDSRuleMaster();
    }
    public partial class CDSRuleMasterManager : ManagerBase<CDSRuleMaster, uint>, ICDSRuleMasterManager
    {
        #region Constructors

        public CDSRuleMasterManager()
            : base()
        {

        }
        public CDSRuleMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        public IList<CDSRuleMaster> getCDSRuleMasterByFieldName()
        {
            IList<CDSRuleMaster> staticList = new List<CDSRuleMaster>();
            //using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            //{
            //    ICriteria criteria = iMySession.CreateCriteria(typeof(CDSRuleMaster)).Add(Expression.Eq("Is_Manage_CDS_Allowed", "Y")).Add(Expression.Eq("Status", "Active"));
            //    staticList = criteria.List<CDSRuleMaster>();
            //    iMySession.Close();
            //}


            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlquery = iMySession.CreateSQLQuery("SELECT * FROM cds_rule_master where Is_Manage_CDS_Allowed='y' and Status='Active'").AddEntity(typeof(CDSRuleMaster));
                staticList = sqlquery.List<CDSRuleMaster>();
                iMySession.Close();
            }


            return staticList;
        }

        public IList<CDSRuleMaster> GellCDSRuleMaster()
        {
            IList<CDSRuleMaster> staticList = new List<CDSRuleMaster>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlquery = iMySession.CreateSQLQuery("Select * from cds_rule_master where status='Active' order by sort_order").AddEntity(typeof(CDSRuleMaster));
                staticList = sqlquery.List<CDSRuleMaster>();
                iMySession.Close();
            }
            return staticList;
        }

    }
}
