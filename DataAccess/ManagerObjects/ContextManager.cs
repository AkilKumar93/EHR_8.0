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

    public partial interface IContextManager : IManagerBase<Context, uint>
    {
        IList<Context> SearchFAX(string FaxSearchCriteria);
        
    }


    public partial class ContextManager : ManagerBase<Context, uint>, IContextManager
    {
        #region Constructors

        public ContextManager()
            : base()
        {

        }
        public ContextManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods
        public IList<Context> SearchFAX(string FaxSearchCriteria)
        {
            IList<Context> ilstContext = new List<Context>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Context))
                    .Add(Expression.Like("Context_Name", "%" + FaxSearchCriteria + "%"));
                ilstContext = crit.List<Context>();
                iMySession.Close();
            }
            return ilstContext;
        }
        #endregion
    }
}
