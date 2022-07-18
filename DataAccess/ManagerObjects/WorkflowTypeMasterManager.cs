using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Collections;
using System;
using MySql.Data.MySqlClient;
using System.IO;
using System.Web;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IWorkFlowTypeMasterManager : IManagerBase<WorkFlowTypeMaster, ulong>
    {
        
    }
    public partial class WorkFlowTypeMasterManager : ManagerBase<WorkFlowTypeMaster, ulong>, IWorkFlowTypeMasterManager
    {
        #region Constructors

        public WorkFlowTypeMasterManager()
            : base()
        {

        }
        public WorkFlowTypeMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods


        #endregion
    }
}