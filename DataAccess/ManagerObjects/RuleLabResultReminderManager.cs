using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRuleLabResultReminderManager : IManagerBase<RuleLabResultReminder, ulong>
    {
        int SaveRuleLabResult(IList<RuleLabResultReminder> objRuleLabResultManager, string MacAddress, ISession Mysession);
        int DeleteRuleLabResult(IList<RuleLabResultReminder> objRuleLabResultManager, string MacAddress, ISession Mysession);

    }

    public partial class RuleLabResultReminderManager : ManagerBase<RuleLabResultReminder, ulong>, IRuleLabResultReminderManager
    {

        #region Constructors

        public RuleLabResultReminderManager()
            : base()
        {

        }
        public RuleLabResultReminderManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

        public int SaveRuleLabResult(IList<RuleLabResultReminder> objRuleLabResultManager, string MacAddress, ISession Mysession)
        {
            IList<RuleLabResultReminder> objRuleLabResultManagernull = null;
            GenerateXml XMLObj = new GenerateXml();
            //return SaveUpdateDeleteWithoutTransaction(ref objRuleLabResultManager, null, null, Mysession, MacAddress);
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref objRuleLabResultManager, ref objRuleLabResultManagernull, null, Mysession, MacAddress, false, true, 0, string.Empty, ref XMLObj);           
        }

        public int DeleteRuleLabResult(IList<RuleLabResultReminder> objRuleLabResultManager, string MacAddress, ISession Mysession)
        {
            IList<RuleLabResultReminder> save=new List<RuleLabResultReminder>();
            GenerateXml XMLObj = new GenerateXml();
            IList<RuleLabResultReminder> savenull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref save, ref savenull, objRuleLabResultManager, Mysession, MacAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref save, null, objRuleLabResultManager, Mysession, MacAddress);
        }

        #endregion

    }
    
}
