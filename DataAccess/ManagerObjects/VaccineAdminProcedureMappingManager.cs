
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
    public partial interface IVaccineAdminProcedureMappingManager : IManagerBase<AuthorizationICD,ulong>
    {
      
    }

    public partial class VaccineAdminProcedureMappingManager : ManagerBase<AuthorizationICD, ulong>, IVaccineAdminProcedureMappingManager
    {
        #region Constructors

        public VaccineAdminProcedureMappingManager()
            : base()
        {

        }
        public VaccineAdminProcedureMappingManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        //public IList<VaccineAdminProcedureMapping> GetModifierbyCPTandVaccine(string CPT, string[] CPTList)
        //{
        //    IList<VaccineAdminProcedureMapping> lst = new List<VaccineAdminProcedureMapping>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria criteria = iMySession.CreateCriteria(typeof(VaccineAdminProcedureMapping)).Add(Expression.Eq("Admin_Procedure_Code", CPT)).Add(Expression.In("Vaccine_Procedure_Code", CPTList));
        //        lst = criteria.List<VaccineAdminProcedureMapping>();
        //        iMySession.Close();
        //    }
        //    return lst;



        //}

    }
}

