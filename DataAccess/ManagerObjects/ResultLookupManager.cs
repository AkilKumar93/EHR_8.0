using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IResultLookupManager : IManagerBase<ResultLookup, ulong>
    {
        IList<ResultLookup> GetResultLookup();
    }

    public partial class ResultLookupManager : ManagerBase<ResultLookup, ulong>, IResultLookupManager
    {
        #region Constructors
        public ResultLookupManager()
            : base()
        {

        }
        public ResultLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<ResultLookup> GetResultLookup()
        {
            IList<ResultLookup> listResult = new List<ResultLookup>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ResultLookup));
                listResult = criteria.List<ResultLookup>();
                iMySession.Close();
            }
            return listResult;
        }
    }
}

