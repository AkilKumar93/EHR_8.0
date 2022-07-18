using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRuleMedicationManager : IManagerBase<RuleMedication, ulong>
    {
        IList<RuleMedication> GetAllMedicationRules();

    }
    public partial class RuleMedicationManager : ManagerBase<RuleMedication, ulong>, IRuleMedicationManager
    {
        #region Constructors

        public RuleMedicationManager()
            : base()
        {

        }
        public RuleMedicationManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods
        public IList<RuleMedication> GetAllMedicationRules()
        {
            IList<RuleMedication> lstRule = new List<RuleMedication>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = session.GetISession().CreateCriteria(typeof(RuleMedication)).Add(Expression.Eq("Status", "Y"));
                lstRule =crt.List<RuleMedication>();
            }
            return lstRule;
        }


        #endregion
    }
}
