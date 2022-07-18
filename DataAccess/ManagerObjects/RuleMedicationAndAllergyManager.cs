using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRuleMedicationAndAllergyManager : IManagerBase<RuleMedicationAndAllergy, ulong>
    {
        int SaveRuleMedicationAllergy(IList<RuleMedicationAndAllergy> objRuleMedicationManager, string MacAddress, ISession Mysession);
        int DeleteRuleMedicationAllergy(IList<RuleMedicationAndAllergy> objRuleMedicationManager, string MacAddress, ISession Mysession);

    }

    public partial class RuleMedicationAndAllergyManager : ManagerBase<RuleMedicationAndAllergy, ulong>, IRuleMedicationAndAllergyManager
    {

        #region Constructors

        public RuleMedicationAndAllergyManager()
            : base()
        {

        }
        public RuleMedicationAndAllergyManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods


        public int SaveRuleMedicationAllergy(IList<RuleMedicationAndAllergy> objRuleMedicationManager, string MacAddress, ISession Mysession)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<RuleMedicationAndAllergy> objRuleMedicationManagernull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref objRuleMedicationManager, ref objRuleMedicationManagernull, null, Mysession, MacAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref objRuleMedicationManager, null, null, Mysession, MacAddress);
        }

        public int DeleteRuleMedicationAllergy(IList<RuleMedicationAndAllergy> objRuleMedicationManager, string MacAddress, ISession Mysession)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<RuleMedicationAndAllergy> save=new List<RuleMedicationAndAllergy>();
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref save, ref objRuleMedicationManager, null, Mysession, MacAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref save, null, objRuleMedicationManager, Mysession, MacAddress);
        }
        #endregion

    }
   
}
