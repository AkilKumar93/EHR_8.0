using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPhysicianICD_9Manager : IManagerBase<PhysicianICD_9, string>
    {
        IList<PhysicianICD_9> GetPhyICDsandCategory(ulong phyID, string sLegalOrg);
        IList<PhysicianICD_9> GetPhyLeafICDsandCategory(ulong phyID, string sLegalOrg);

    }

    public partial class PhysicianICD_9Manager : ManagerBase<PhysicianICD_9, string>, IPhysicianICD_9Manager
    {
        #region Constructors


        public PhysicianICD_9Manager()
            : base()
        {

        }
        public PhysicianICD_9Manager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

       
        #endregion


        #region IPhysicianICD_9Manager Members



        #endregion

        #region IPhysicianICD_9Manager Members






        #endregion

        #region IPhysicianICD_9Manager Members



        #endregion



        #region Methods
        public IList<PhysicianICD_9> GetPhyICDsandCategory(ulong phyID, string sLegalOrg)
        {
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<PhysicianICD_9> PhysicianICD9List = new List<PhysicianICD_9>();

            //ICriteria critPhyICD9List = iMySession.CreateCriteria(typeof(PhysicianICD_9)).Add(Expression.Eq("Physician_ID", phyID)).Add(Expression.Eq("Is_Ruled_Out", "N")).AddOrder(Order.Asc("Category_Sort_Order")).AddOrder(Order.Asc("ICD_9_Description"));
            ICriteria critPhyICD9List = iMySession.CreateCriteria(typeof(PhysicianICD_9)).Add(Expression.Eq("Physician_ID", phyID)).Add(Expression.Eq("Legal_Org", sLegalOrg)).Add(Expression.Eq("Is_Ruled_Out", "N")).AddOrder(Order.Asc("Category_Sort_Order"));

            PhysicianICD9List = critPhyICD9List.List<PhysicianICD_9>();

            iMySession.Close();

            return PhysicianICD9List;
        }
        public IList<PhysicianICD_9> GetPhyLeafICDsandCategory(ulong phyID, string sLegalOrg)
        {
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<PhysicianICD_9> PhysicianICD9List = new List<PhysicianICD_9>();

            //ICriteria critPhyICD9List = iMySession.CreateCriteria(typeof(PhysicianICD_9)).Add(Expression.Eq("Physician_ID", phyID)).Add(Expression.Eq("Leaf_Node", "Y")).Add(Expression.Eq("Is_Ruled_Out", "N")).Add(Expression.Eq("Version_Year", "ICD_10")).AddOrder(Order.Asc("Category_Sort_Order")).AddOrder(Order.Asc("ICD_9_Description"));
            ICriteria critPhyICD9List = iMySession.CreateCriteria(typeof(PhysicianICD_9)).Add(Expression.Eq("Physician_ID", phyID)).Add(Expression.Eq("Legal_Org", sLegalOrg)).Add(Expression.Eq("Leaf_Node", "Y")).Add(Expression.Eq("Is_Ruled_Out", "N")).Add(Expression.Eq("Version_Year", "ICD_10")).AddOrder(Order.Asc("Category_Sort_Order"));

            PhysicianICD9List = critPhyICD9List.List<PhysicianICD_9>();

            iMySession.Close();

            return PhysicianICD9List;
        }
        #endregion
    }
}
