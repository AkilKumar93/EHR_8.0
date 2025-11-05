using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IIndexingFileLookupManager : IManagerBase<IndexingFileLookup, ulong>
    {
        IList<IndexingFileLookup> GetIndexingFileLookup();
    }

    public partial class IndexingFileLookupManager : ManagerBase<IndexingFileLookup, ulong>, IIndexingFileLookupManager
    {
        #region Constructors
        public IndexingFileLookupManager()
            : base()
        {

        }
        public IndexingFileLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<IndexingFileLookup> GetIndexingFileLookup()
        {
            IList<IndexingFileLookup> listResult = new List<IndexingFileLookup>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(IndexingFileLookup));
                listResult = criteria.List<IndexingFileLookup>();
                iMySession.Close();
            }
            return listResult;
        }
    }
}

