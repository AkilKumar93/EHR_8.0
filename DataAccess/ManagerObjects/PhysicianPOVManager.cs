using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPhysicianPOVManager : IManagerBase<PhysicianPOV, ulong>
    {
        //IList<PhysicianPOV> GetPhysicianInterListbyPhysicianID(ulong phyID);
        //IList<PhysicianPOV> GetPhysicianInterListbyPrimaryID(ulong phyID);
        //void UpdateIntermediates(PhysicianPOV intermediates);
        //void DeleteIntermediates(PhysicianPOV intermediates);
        //ulong SaveIntermediates(PhysicianPOV intermediates);//vinoth 15/04
        string GetBlockCategory(string Purposeofvisit, string LegalOrg);
        //IList<PhysicianPOV> SaveUpdateDeletePhysician_POV(IList<PhysicianPOV> SaveList, IList<PhysicianPOV> UpdateList, IList<PhysicianPOV> DeleteList, string MACAddress);
    }

    public partial class PhysicianPOVManager : ManagerBase<PhysicianPOV, ulong>, IPhysicianPOVManager
    {
        #region Constructors

        public PhysicianPOVManager()
            : base()
        {

        }
        public PhysicianPOVManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

       

        //public IList<PhysicianPOV> GetPhysicianInterListbyPrimaryID(ulong phyID)
        //{
        //    IList<PhysicianPOV> listPhysicianPOV = new List<PhysicianPOV>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(PhysicianPOV)).Add(Expression.Eq("Id", phyID));
        //        listPhysicianPOV = crit.List<PhysicianPOV>();
        //        iMySession.Close();
        //    }
        //    return listPhysicianPOV;
        //}

        //public IList<PhysicianPOV> GetPhysicianInterListbyPhysicianID(ulong phyID)
        //{
        //    IList<PhysicianPOV> listPhysicianPOV = new List<PhysicianPOV>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ISQLQuery sql = iMySession.CreateSQLQuery("Select * from physician_pov p where p.Physician_ID='" + phyID.ToString() + "' order by p.Sort_Order").AddEntity("p", typeof(PhysicianPOV));
        //        //ICriteria crit = iMySession.CreateCriteria(typeof(PhysicianPOV)).Add(Expression.Eq("Phy_ID", phyID));
        //        //return crit.List<PhysicianPOV>();
        //        listPhysicianPOV = sql.List<PhysicianPOV>();
        //        iMySession.Close();
        //    }
        //    return listPhysicianPOV;
        //}

        //public void UpdateIntermediates(PhysicianPOV intermediates)
        //{

        //    session.BeginTransaction();
        //    session.GetISession().Update(intermediates);
        //    session.CommitTransaction();

        //}
        //public void DeleteIntermediates(PhysicianPOV intermediates)
        //{

        //    session.BeginTransaction();
        //    session.GetISession().Delete(intermediates);
        //    session.CommitTransaction();

        //}

        ////vinoth 15/04
        //public ulong SaveIntermediates(PhysicianPOV intermediates)
        //{

        //    session.BeginTransaction();
        //    session.GetISession().Save(intermediates);
        //    session.CommitTransaction();
        //    return intermediates.Id;

        //}


        //public IList<PhysicianPOV> SaveUpdateDeletePhysician_POV(IList<PhysicianPOV> SaveList, IList<PhysicianPOV> UpdateList, IList<PhysicianPOV> DeleteList, string MACAddress)
        //{
        //  //  SaveUpdateDeleteWithTransaction(ref SaveList, UpdateList, DeleteList, string.Empty);//Changed for Xml changes
        //    IList<PhysicianPOV> getid = new List<PhysicianPOV>();
        //    if (SaveList != null)
        //    {
        //        for (int i = 0; i < SaveList.Count; i++)
        //        {
        //            getid.Add(SaveList[i]);

        //        }
        //    }
        //    return getid;
            
        //}
        public string GetBlockCategory(string Purposeofvisit, string LegalOrg)
        {
            string sBlockCategory = string.Empty;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                IQuery query = iMySession.GetNamedQuery("Get.Typeofvist.Getvisittype");
                query.SetString(0, Purposeofvisit);
                query.SetString(1, LegalOrg);
                ArrayList arrList = new ArrayList(query.List());
                if (arrList.Count > 0)
                {
                    sBlockCategory = arrList[0].ToString();

                }
                iMySession.Close();
            }
            return sBlockCategory;
        }
        #endregion
    }
}
