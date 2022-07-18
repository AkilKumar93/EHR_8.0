using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IMeasuresRuleMasterManager : IManagerBase<MeasuresRuleMaster, string>
    {
    }
    public partial class MeasuresRuleMasterManager : ManagerBase<MeasuresRuleMaster, string>, IMeasuresRuleMasterManager
    {

        #region Constructors

        public MeasuresRuleMasterManager()
            : base()
        {

        }
        public MeasuresRuleMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
    }
}
