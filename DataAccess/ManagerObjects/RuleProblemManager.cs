using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRuleProblemManager : IManagerBase<RuleProblem, ulong>
    {
        int SaveRuleProblem(IList<RuleProblem> objRuleProblemManager, string MacAddress, ISession Mysession);
        int DeleteRuleProblem(IList<RuleProblem> objRuleProblemManager, string MacAddress, ISession Mysession);

    }

    public partial class RuleProblemManager : ManagerBase<RuleProblem, ulong>, IRuleProblemManager
    {

        #region Constructors

        public RuleProblemManager()
            : base()
        {

        }
        public RuleProblemManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

        public int SaveRuleProblem(IList<RuleProblem> objRuleProblemManager, string MacAddress, ISession Mysession)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<RuleProblem> objRuleProblemManagernull = null;
            //return SaveUpdateDeleteWithoutTransaction(ref objRuleProblemManager, null, null, Mysession, MacAddress);
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref objRuleProblemManager, ref objRuleProblemManagernull, null, Mysession, MacAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        public int DeleteRuleProblem(IList<RuleProblem> objRuleProblemManager, string MacAddress, ISession Mysession)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<RuleProblem> objRuleProblemManagernull = null;
            IList<RuleProblem> save=new List<RuleProblem>();
            //return SaveUpdateDeleteWithoutTransaction(ref save, null, objRuleProblemManager, Mysession, MacAddress);
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref save, ref objRuleProblemManagernull, objRuleProblemManager, Mysession, MacAddress, false, true, 0, string.Empty, ref XMLObj);
        }
        #endregion

    }

   
}
