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
    public partial interface IPhysicianSpecialtyManager : IManagerBase<PhysicianSpecialty, ulong>
    {
        IList<PhysicianSpecialty> GetAllPhysicianSpecialty(string sLegalOrg);
 
    }
    public partial class PhysicianSpecialtyManager : ManagerBase<PhysicianSpecialty, ulong>, IPhysicianSpecialtyManager
    {
        #region Constructors

        public PhysicianSpecialtyManager()
            : base()
        {

        }
        public PhysicianSpecialtyManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<PhysicianSpecialty> GetAllPhysicianSpecialty(string sLegalOrg)
        {
            IList<PhysicianSpecialty> ilstPhysicianSpecialty = new List<PhysicianSpecialty>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(PhysicianSpecialty)).Add(Expression.Eq("Legal_Org",sLegalOrg));
                ilstPhysicianSpecialty = crt.List<PhysicianSpecialty>();
                iMySession.Close();
            }
            return ilstPhysicianSpecialty;
        }
        public IList<PhysicianSpecialty> GetPhysicianSpecialtybyPhysicianID(ulong ulPhysicianID, IList<string> sSpecialty, string sLegalOrg)
        {
            IList<PhysicianSpecialty> ilstPhysicianSpecialty = new List<PhysicianSpecialty>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(PhysicianSpecialty)).Add(Expression.Eq("Physician_ID", ulPhysicianID)).Add(Expression.In("Specialty", sSpecialty.ToList())).Add(Expression.Eq("Legal_Org", sLegalOrg)); ;
                ilstPhysicianSpecialty = crt.List<PhysicianSpecialty>();
                iMySession.Close();
            }
            return ilstPhysicianSpecialty;
        }

        #endregion
    }
}
