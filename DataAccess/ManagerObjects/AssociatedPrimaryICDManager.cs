using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAssociatedPrimaryICDManager : IManagerBase<AssociatedPrimaryICD, ulong>
    {
        IList<AssociatedPrimaryICD> GetQuestionMasterRecord(string parentID, string RParent, ulong physician_ID, ref string mutuallyExclusive, ref string sourceTable);
        IList<AssociatedPrimaryICD> GetAllAssociatedICDCodes();
        IList<AssociatedPrimaryICD> GetAssociatedICDCodes(string ICD);

        IList<AssociatedPrimaryICD> GetAllAssociatedICDCodes(string[] ICD);
    }
    public partial class AssociatedPrimaryICDManager : ManagerBase<AssociatedPrimaryICD, ulong>, IAssociatedPrimaryICDManager
    {
        #region Constructors


        public AssociatedPrimaryICDManager()
            : base()
        {

        }
        public AssociatedPrimaryICDManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        public IList<AssociatedPrimaryICD> GetQuestionMasterRecord(string parentID, string RParent, ulong physician_ID, ref string mutuallyExclusive, ref string sourceTable)
        {
            IList<AssociatedPrimaryICD> AssociatedList =new List<AssociatedPrimaryICD>();
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(AssociatedPrimaryICD)).Add(Expression.Eq("ICD_9", parentID)).Add(Expression.Eq("Associated_ICD9", RParent)).AddOrder(Order.Asc("Associated_ICD9"));
                AssociatedList = criteria.List<AssociatedPrimaryICD>();
                iMySession.Close();
            }
            return AssociatedList;
        }
        public IList<AssociatedPrimaryICD> GetAllAssociatedICDCodes()
        {
            IList<AssociatedPrimaryICD> AssociatedList = new List<AssociatedPrimaryICD>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
                ICriteria criteria = iMySession.CreateCriteria(typeof(AssociatedPrimaryICD));
                AssociatedList = criteria.List<AssociatedPrimaryICD>();
                iMySession.Close();
            }
            return AssociatedList;
        }

        public IList<AssociatedPrimaryICD> GetAssociatedICDCodes(string ICD)
        {
            IList<AssociatedPrimaryICD> AssociatedList = new List<AssociatedPrimaryICD>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
                ICriteria criteria = iMySession.CreateCriteria(typeof(AssociatedPrimaryICD)).Add(Expression.Eq("ICD_9", ICD));
                 AssociatedList = criteria.List<AssociatedPrimaryICD>();
                iMySession.Close();
            }
            return AssociatedList;
        }

        public IList<AssociatedPrimaryICD> GetAllAssociatedICDCodes(string[] ICD)
        {
            IList<AssociatedPrimaryICD> AssociatedList = new List<AssociatedPrimaryICD>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
                ICriteria criteria = iMySession.CreateCriteria(typeof(AssociatedPrimaryICD)).Add(Expression.In("ICD_9", ICD));
                AssociatedList = criteria.List<AssociatedPrimaryICD>();
                iMySession.Close();
            }
            return AssociatedList;
        }
    }
}


