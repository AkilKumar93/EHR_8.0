using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface ILabInsurancePlanManager : IManagerBase<LabInsurancePlan, ulong>
    {
        IList<ulong> GetLabIDBasedOnInsPlanID(IList<ulong> InsPlanIDList, string strLabType, string sLegalOrg);
    }
    public partial class LabInsurancePlanManager:ManagerBase<LabInsurancePlan,ulong>, ILabInsurancePlanManager
    {
           #region Constructors

        public LabInsurancePlanManager()
            : base()
        {

        }
        public LabInsurancePlanManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion


        #region ILabInsurancePlanManager Members

        public IList<ulong> GetLabIDBasedOnInsPlanID(IList<ulong> InsPlanIDList, string strLabType, string sLegalOrg)
        {          
            IList<ulong> ulList = new List<ulong>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.Orders.GetLabIDBasedOnInsPlan");
                query.SetString(0, strLabType);
                query.SetString(1, sLegalOrg);
                query.SetParameterList("InsList", InsPlanIDList.ToArray<ulong>());

                ArrayList list = new ArrayList(query.List());
                if (list.Count > 0)
                {
                    foreach (object obj in list)
                    {
                        ulList.Add(Convert.ToUInt64(obj));
                    }
                }
                iMySession.Close();
            }
            return ulList;
        }
        public ulong  GetLabIDBasedOnPhyID(ulong uPhysicianID, string sLegalOrg)
        {
            ulong ulList = 0;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery query1 = session.GetISession().CreateSQLQuery("select u.* FROM lab_insurance_plan u where u.Physician_ID='"+uPhysicianID +"' and u.Legal_Org ='"+sLegalOrg+"'").AddEntity("u", typeof(LabInsurancePlan));
                IList<LabInsurancePlan> lstGetList = new List<LabInsurancePlan>();
                lstGetList = query1.List<LabInsurancePlan>();
                if (lstGetList.Count>0)
                {
                    ulList=lstGetList[0].Lab_ID;
                }
                iMySession.Close();
            }
            return ulList;
        }

        #endregion
    }
}
