using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
        public partial interface IAOELookUpManager : IManagerBase<AOELookUp, ulong>
        {
            IList<AOELookUp> GetAOELookUpList(string Order_Code);
            IList<AOELookUp> GetAOELookUpList(IList<string> Order_Code);
            void ImportCDCAOELookUp(IList<AOELookUp> ilstAOELookUp, string MACAddress,bool Istruncate);
            IList<AOELookUp> GetAOELookUpList();
        }

        public partial class AOELookUpManager : ManagerBase<AOELookUp, ulong>, IAOELookUpManager
        {
            #region Constructors


            public AOELookUpManager()
                : base()
            {

            }
            public AOELookUpManager
                (INHibernateSession session)
                : base(session)
            {

            }
            #endregion


            #region Get Methods

            public IList<AOELookUp> GetAOELookUpList(string Order_Code)
            {
                IList<AOELookUp> ilstAOELookUp = new List<AOELookUp>();
                using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                {
                    ICriteria criteria = iMySession.CreateCriteria(typeof(AOELookUp)).Add(Expression.Eq("Order_Code", Order_Code));
                    ilstAOELookUp= criteria.List<AOELookUp>();
                    iMySession.Close();
                }
                return ilstAOELookUp;
            }
            public IList<AOELookUp> GetAOELookUpList(IList<string> Order_Code)
            {
                IList<AOELookUp> ilstAOELookUp = new List<AOELookUp>();
                using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                {
                    ICriteria criteria = iMySession.CreateCriteria(typeof(AOELookUp)).Add(Expression.In("Order_Code", Order_Code.ToList<string>()));
                    ilstAOELookUp = criteria.List<AOELookUp>();
                    iMySession.Close();
                }
                return ilstAOELookUp;

            }
            public void ImportCDCAOELookUp(IList<AOELookUp> ilstAOELookUp, string MACAddress,bool IsTruncate)
            {
                using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                {
                    ICriteria critLabName = iMySession.CreateCriteria(typeof(Lab)).Add(Expression.Eq("Lab_Name", "Quest Diagnostics")).Add(Expression.Eq("Lab_Type", "LAB"));
                    IList<Lab> ilslab = critLabName.List<Lab>();
                   // IList<AOELookUp> updateList = null;
                  //  IList<AOELookUp> DeleteList1 = null;
                    ICriteria crit = iMySession.CreateCriteria(typeof(AOELookUp)).Add(Expression.Eq("Lab_ID", ilslab[0].Id));
                    IList<AOELookUp> deletelist = crit.List<AOELookUp>();
                    foreach (AOELookUp obj in ilstAOELookUp)
                    {
                        obj.Lab_ID = 2;
                        obj.Sort_Order = 0;
                    }
                   // ulong HumanId=0;
                    IList<AOELookUp> templist = new List<AOELookUp>();
                    if (IsTruncate)
                        //This method is not used in entire solution. Nijanthan commented the below line on 22-3-16.
                        //SaveUpdateDeleteWithTransaction(ref templist, null, deletelist, MACAddress);
                    //SaveUpdateDeleteWithTransaction(ref ilstAOELookUp, null, null, MACAddress);
                    iMySession.Close();
                }

            }

            public IList<AOELookUp> GetAOELookUpList()
            {
                 IList<AOELookUp> ilstAOELookUp = new List<AOELookUp>();
                 using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                 {
                     ISQLQuery sql = iMySession.CreateSQLQuery("Select a.* from aoe_lookup a").AddEntity("a", typeof(AOELookUp));
                     ilstAOELookUp = sql.List<AOELookUp>();
                     if (ilstAOELookUp.Count > 0)
                         return ilstAOELookUp;
                     else
                         return ilstAOELookUp;
                 }
            }
            #endregion
        }

}
