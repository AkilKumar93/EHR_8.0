using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IVaccineInfoStatementProcedureManager : IManagerBase<VaccineInfoStatementProcedure, ulong>
    {
        IList<VaccineInfoStatement> GetVaccineInfoStatementForSelectedprocedure(string CPT);
    }
   public partial class VaccineInfoStatementProcedureManager:ManagerBase<VaccineInfoStatementProcedure,ulong>,IVaccineInfoStatementProcedureManager
    {
        #region Constructors

        public VaccineInfoStatementProcedureManager()
            : base()
        {

        }
        public VaccineInfoStatementProcedureManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        #region IVaccineInfoStatementProcedureManager Members

        public IList<VaccineInfoStatement> GetVaccineInfoStatementForSelectedprocedure(string CPT)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VaccineInfoStatementProcedure> list = new List<VaccineInfoStatementProcedure>();
            IList<VaccineInfoStatement> returnList = new List<VaccineInfoStatement>();
             
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(VaccineInfoStatementProcedure)).Add(Expression.Eq("CPT", CPT));
                list = crit.List<VaccineInfoStatementProcedure>();
                IList<ulong> VaccID = (from obj in list select obj.Vaccine_Info_Statement_ID).ToList<ulong>();
                if (VaccID.Count > 0)
                {
                    VaccineInfoStatementManager objMnger = new VaccineInfoStatementManager();
                    returnList = objMnger.GetVaccineInfoByVaccineInfoId(VaccID);
                }
                iMySession.Close();
            }
            return returnList;
        }

        #endregion
    }
}
