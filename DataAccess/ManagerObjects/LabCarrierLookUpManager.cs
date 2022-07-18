using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate.Criterion;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ILabCarrierLookUpManager : IManagerBase<LabCarrierLookUp, ulong>
    {
        LabCarrierLookUp GetLabCarrierDetailsForInsPlanID(ulong InsPlanID, ulong Lab_ID);
        void ImportCDCLabCarrierLookUp(IList<LabCarrierLookUp> ilstLabCarrierLookUp, string MACAddress,bool IsTruncate);
    }
    public partial class LabCarrierLookUpManager:ManagerBase<LabCarrierLookUp,ulong>,ILabCarrierLookUpManager
    {
        #region Constructors

        public LabCarrierLookUpManager()
            : base()
        {

        }
        public LabCarrierLookUpManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        #region ILabCarrierLookUpManager Members

        public LabCarrierLookUp GetLabCarrierDetailsForInsPlanID(ulong InsPlanID, ulong Lab_ID)
        {
            LabCarrierLookUp obj=new LabCarrierLookUp();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(LabCarrierLookUp)).Add(Expression.Eq("Ins_Plan_ID", InsPlanID)).Add(Expression.Eq("Lab_ID", Lab_ID));
                if (crit.List<LabCarrierLookUp>().Count > 0)
                {
                    obj = crit.List<LabCarrierLookUp>()[0];
                }
                mySession.Close();
            }
            return obj;

        }

        #endregion
        public void ImportCDCLabCarrierLookUp(IList<LabCarrierLookUp> ilstLabCarrierLookUp, string MACAddress,bool IsTruncate)
        {
            IList<LabCarrierLookUp> deletelist =new List<LabCarrierLookUp>();
          
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria critLabName = mySession.CreateCriteria(typeof(Lab)).Add(Expression.Eq("Lab_Name", "Quest Diagnostics")).Add(Expression.Eq("Lab_Type", "LAB"));
                IList<Lab> ilslab = critLabName.List<Lab>();

                ICriteria crit = mySession.CreateCriteria(typeof(LabCarrierLookUp)).Add(Expression.Eq("Lab_ID", ilslab[0].Id));
               deletelist = crit.List<LabCarrierLookUp>();
                mySession.Close();
            }
            foreach (LabCarrierLookUp obj in ilstLabCarrierLookUp)
            {
                obj.Lab_ID = 2;
                obj.Sort_Order = 0;
            }
            IList<LabCarrierLookUp> templist = new List<LabCarrierLookUp>();
            //Commented by vaishali on 23-03-2016 not used anywhere
            //if(IsTruncate)                
                //SaveUpdateDeleteWithTransaction(ref templist, null, deletelist, MACAddress);
            //SaveUpdateDeleteWithTransaction(ref ilstLabCarrierLookUp, null, deletelist, MACAddress);

        }
    }
}
