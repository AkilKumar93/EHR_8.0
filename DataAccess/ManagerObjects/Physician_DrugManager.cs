using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPhysician_DrugManager : IManagerBase<Physician_Drug, ulong>
    {
        IList<Physician_Drug> GetUniqueDrugNameUsingPhysician_ID(ulong ulPhy_ID);
        IList<Physician_Drug> BatchOperationsToPhysicianDrug(IList<Physician_Drug> saveList, IList<Physician_Drug> updtList, IList<Physician_Drug> delList, ulong PhyID, string MACAddress);
    }

    public partial class Physician_DrugManager : ManagerBase<Physician_Drug, ulong>, IPhysician_DrugManager
    {

        #region Constructors

        public Physician_DrugManager()
            : base()
        {

        }
        public Physician_DrugManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        # region userDefinedMethods

        public IList<All_Drug> GetDrugDetailsByPhyID(ulong ulPhyID)
        {
            IList<All_Drug> lstDrug_dtls = new List<All_Drug>();
            ISQLQuery sqlqry = session.GetISession().CreateSQLQuery("Select a.* from all_drug a where a.drug_name in (select distinct(pd.drug_name) from physician_drug pd where pd.physician_id='" + ulPhyID + "')").AddEntity("a", typeof(All_Drug));
            lstDrug_dtls = sqlqry.List<All_Drug>();
            return lstDrug_dtls;
        }
        public IList<Physician_Drug> GetUniqueDrugNameUsingPhysician_ID(ulong ulPhy_ID)
        {
            IList<Physician_Drug> listPhyDrug =new List<Physician_Drug>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Physician_Drug)).Add(Expression.Eq("Physician_ID", ulPhy_ID)).AddOrder(Order.Asc("Drug_Name"));
                listPhyDrug = criteria.List<Physician_Drug>();
                iMySession.Close();
            }
            return listPhyDrug;
        }
       


        public IList<Physician_Drug> BatchOperationsToPhysicianDrug(IList<Physician_Drug> saveList, IList<Physician_Drug> updtList, IList<Physician_Drug> delList, ulong PhyID, string MACAddress)
        {
            //Commented by vaishali on 23-03-2016 not used anywhere
            //SaveUpdateDeleteWithTransaction(ref saveList, updtList, delList, MACAddress);
            return GetUniqueDrugNameUsingPhysician_ID(PhyID);
        }

        #endregion
    }
}
