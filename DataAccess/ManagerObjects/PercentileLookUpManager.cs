using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPercentileLookUpManager : IManagerBase<PercentileLookUp, ulong>
    {
        IList<PercentileLookUp> GetPercentileLookUpByAgeAndSex(int ageList, string Sex, string Category);
    }
    public partial class PercentileLookUpManager : ManagerBase<PercentileLookUp, ulong>, IPercentileLookUpManager
    {
        #region Constructors

        public PercentileLookUpManager()
            : base()
        {

        }
        public PercentileLookUpManager
            (INHibernateSession session)
            : base(session)
        {
        }

        #endregion

        #region IPercentileLookUpManager Members

        public IList<PercentileLookUp> GetPercentileLookUpByAgeAndSex(int age, string Sex, string Category)
        {
            // ISession SessionObj = NHibernateSessionManager.Instance.CreateISession();
            IList<PercentileLookUp> returnList = new List<PercentileLookUp>();

            //ICriteria crit = session.GetISession().CreateCriteria(typeof(PercentileLookUp)).Add(Expression.Like("Age_In_Months", age.ToString() + "%")).Add(Expression.Eq("Sex", Sex)).Add(Expression.Eq("Category", Category));
            //foreach (PercentileLookUp obj in crit.List<PercentileLookUp>())
            //{
            //    returnList.Add(obj);
            //}

            //ICriteria crit1 = session.GetISession().CreateCriteria(typeof(PercentileLookUp)).Add(Expression.Like("Age_In_Months", (age+1).ToString() + "%")).Add(Expression.Eq("Sex", Sex)).Add(Expression.Eq("Category", Category));
            //foreach (PercentileLookUp obj in crit1.List<PercentileLookUp>())
            //{
            //    returnList.Add(obj);
            //}
            //return returnList;
            using (ISession SessionObj = NHibernateSessionManager.Instance.CreateISession())
            {
                if (Category == "")
                {
                    ISQLQuery sql = SessionObj.CreateSQLQuery("SELECT * FROM percentile_lookup where (age_in_months like " + "'" + age + "%' or age_in_months like " + "'" + (age + 1) + "%') and sex='" + Sex + "' and Category in ('" + Category + "') order by Age_In_Months desc").AddEntity("p", typeof(PercentileLookUp));
                    returnList = sql.List<PercentileLookUp>();
                }
                else
                {
                    ISQLQuery sql = SessionObj.CreateSQLQuery("SELECT * FROM percentile_lookup where (age_in_months like " + "'" + age + "%' or age_in_months like " + "'" + (age + 1) + "%') and sex='" + Sex + "' and Category in (" + Category + ") order by Age_In_Months desc").AddEntity("p", typeof(PercentileLookUp));
                    returnList = sql.List<PercentileLookUp>();
                }
                SessionObj.Close();
            }
            return returnList;
        }

        #endregion
    }
}
