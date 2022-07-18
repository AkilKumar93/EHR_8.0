using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
   public partial interface  IProcedureCodeRuleMasterManager : IManagerBase<ProcedureCodeRuleMaster,ulong>
    {
    }
   public partial class ProcedureCodeRuleMasterManager : ManagerBase<ProcedureCodeRuleMaster, ulong>, IProcedureCodeRuleMasterManager 
   {
        #region Constructors

        public ProcedureCodeRuleMasterManager()
            : base()
        {

        }
        public ProcedureCodeRuleMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

       #region Methods

       #endregion

   }
}
