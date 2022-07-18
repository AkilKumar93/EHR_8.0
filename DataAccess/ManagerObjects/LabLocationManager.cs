using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ILabLocationManager : IManagerBase<LabLocation, long>
    {
        IList<LabLocation> GetLabLocationUsinglabID(ulong labID);
        IList<LabLocation> GetLabLocationUsinglablocID(ulong lablocID);
        //object[] SearchLabLocation(ulong LabID,string Address, string City, string State, string Zip, string NPI,int PageNumber,int MaxResult);
        object[] SearchLabLocation(ulong LabID, string Address, string City, string State, string Zip, string NPI);
        object[] SearchLabLocationByLimit(ulong LabID, string Address, string City, string State, string Zip, string NPI,int PageNumber,int maxResults);
        void ImportCDCLablocation(IList<LabLocation> ilstLabLocation, string MACAddress,bool Istruncate);
        int LabLocationCount(ulong LabID, string Address, string City, string State, string Zip, string NPI);
    }


    public partial class LabLocationManager : ManagerBase<LabLocation, long>, ILabLocationManager
    {

        #region Constructors

        public LabLocationManager()
            : base()
        {

        }
        public LabLocationManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

        public IList<LabLocation> GetLabLocationUsinglabID(ulong labID)
        {
            IList<LabLocation> ilstLabLocation = new List<LabLocation>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(LabLocation)).Add(Expression.Like("Lab_ID", labID));
                ilstLabLocation = criteria.List<LabLocation>();
                iMySession.Close();
            }
           // return criteria.List<LabLocation>();
            return ilstLabLocation;
        }
        public IList<LabLocation> GetLabLocationUsinglablocID(ulong lablocID)
        {
            IList<LabLocation> ilstLabLocation = new List<LabLocation>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(LabLocation)).Add(Expression.Like("Id", lablocID));
                ilstLabLocation = criteria.List<LabLocation>();
                iMySession.Close();
            }
            // return criteria.List<LabLocation>();
            return ilstLabLocation;
        }

        public object[] SearchLabLocationByLimit(ulong LabID, string Address, string City, string State, string Zip, string NPI, int PageNumber, int maxResults)
        {
            int startIndex = (PageNumber - 1) * maxResults;
            object[] obj = new object[2];
            string sNewZip = string.Empty;
            if (Zip.Replace("-", "").Length > 5)
                sNewZip = Zip;
            else
                sNewZip = Zip.Replace("-", "");
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(LabLocation))
                    .Add(Expression.Eq("Lab_ID", LabID))
                    .Add(Expression.Or(
                    Expression.Like("Street_Address1", Address, MatchMode.Anywhere),
                    Expression.Like("Street_Address2", Address, MatchMode.Anywhere)))
                    .Add(Expression.Like("City", City, MatchMode.Anywhere))
                    .Add(Expression.Like("State", State, MatchMode.Anywhere))
                    .Add(Expression.Like("ZipCode", sNewZip, MatchMode.Anywhere))
                    .Add(Expression.Like("Lab_NPI", NPI, MatchMode.Anywhere)).SetFirstResult(startIndex).SetMaxResults(maxResults);
                obj[0] = criteria.List<LabLocation>();
                iMySession.Close();
            }
            return obj;
        }

        public object[] SearchLabLocation(ulong LabID, string Address, string City, string State, string Zip, string NPI)
        {
            object[] obj = new object[2];
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(LabLocation))
                    .Add(Expression.Eq("Lab_ID", LabID))
                    .Add(Expression.Or(
                    Expression.Like("Street_Address1", Address, MatchMode.Anywhere),
                    Expression.Like("Street_Address2", Address, MatchMode.Anywhere)))
                    .Add(Expression.Like("City", City, MatchMode.Anywhere))
                    .Add(Expression.Like("State", State, MatchMode.Anywhere))
                    .Add(Expression.Like("ZipCode", Zip, MatchMode.Anywhere))
                    .Add(Expression.Like("Lab_NPI", NPI, MatchMode.Anywhere));
                obj[0] = criteria.List<LabLocation>();
                iMySession.Close();
            }
            //IList<LabLocation> list = GetByCriteria(MaxResult,PageNumber, criteria);
            //obj[1] = list;
            return obj;
        }
        public void ImportCDCLablocation(IList<LabLocation> ilstLabLocation,string MACAddress,bool IsTruncate)
        {
            IList<LabLocation> deletelist = new List<LabLocation>();
            IList<LabLocation> templist = new List<LabLocation>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria critLabName = iMySession.CreateCriteria(typeof(Lab)).Add(Expression.Eq("Lab_Name", "Quest Diagnostics")).Add(Expression.Eq("Lab_Type", "LAB"));
                IList<Lab> ilslab = critLabName.List<Lab>();

                ICriteria crit = iMySession.CreateCriteria(typeof(LabLocation)).Add(Expression.Eq("Lab_ID", ilslab[0].Id));
                deletelist = crit.List<LabLocation>();
                iMySession.Close();
            }
            //Commented by vaishali on 23-03-2016 not used anywhere
            //if (IsTruncate)
            //    SaveUpdateDeleteWithTransaction(ref templist, null, deletelist, MACAddress);

            //SaveUpdateDeleteWithTransaction(ref ilstLabLocation, null, deletelist,MACAddress);


        }
        public int LabLocationCount(ulong LabID, string Address, string City, string State, string Zip, string NPI)
        {
            int returnvalue = 0;
            string sNewZip = string.Empty;
            if (Zip.Replace("-", "").Length > 5)
                sNewZip = Zip;
            else
                sNewZip = Zip.Replace("-", "");
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(LabLocation))
                     .Add(Expression.Eq("Lab_ID", LabID))
                     .Add(Expression.Or(
                     Expression.Like("Street_Address1", Address, MatchMode.Anywhere),
                     Expression.Like("Street_Address2", Address, MatchMode.Anywhere)))
                     .Add(Expression.Like("City", City, MatchMode.Anywhere))
                     .Add(Expression.Like("State", State, MatchMode.Anywhere))
                     .Add(Expression.Like("ZipCode", sNewZip, MatchMode.Anywhere))
                     .Add(Expression.Like("Lab_NPI", NPI, MatchMode.Anywhere)).SetProjection(Projections.RowCount());
                 returnvalue = criteria.List<int>()[0];
                iMySession.Close();
            }
            return returnvalue;

            //IList<LabLocation> list = GetByCriteria(MaxResult,PageNumber, criteria);
            //obj[1] = list;
        }
        #endregion
    }
}
