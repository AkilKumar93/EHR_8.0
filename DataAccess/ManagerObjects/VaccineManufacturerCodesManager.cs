using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IVaccineManufacturerCodesManager : IManagerBase<VaccineManufacturerCodes, ulong>
    {
        IList<VaccineManufacturerCodes> GetManufacturerList();
    }
    public partial class VaccineManufacturerCodesManager : ManagerBase<VaccineManufacturerCodes, ulong>, IVaccineManufacturerCodesManager
    {
        #region Constructors


        public VaccineManufacturerCodesManager()
            : base()
        {

        }
        public VaccineManufacturerCodesManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region IVaccineManufacturerCodesManager Members

        public IList<VaccineManufacturerCodes> GetManufacturerList()
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<VaccineManufacturerCodes> list = new List<VaccineManufacturerCodes>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(VaccineManufacturerCodes)).Add(Expression.Eq("Status", "Active"))
                    .AddOrder(Order.Asc("Sort_Order"));             
                list = crit.List<VaccineManufacturerCodes>();
                iMySession.Close();
            }
            return list;
           // return crit.List<VaccineManufacturerCodes>();
        }

        #endregion
    }
}
