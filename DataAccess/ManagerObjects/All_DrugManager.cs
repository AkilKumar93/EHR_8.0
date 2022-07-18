using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IAll_DrugManager : IManagerBase<All_Drug, ulong>
    {
        //IList<All_Drug> GetUniqueDrugNameUsingPhysician_ID(ulong ulPhy_ID);
        IList<All_Drug> GetUniqueRouteOfAdministration(ulong ulPhy_ID, string StrDrugName);
        IList<All_Drug> GetUniqueStrength(ulong ulPhy_ID, string strDrugName, string strRouteOfAdmin);
        IList<All_Drug> GetStrengthDetailsForDrug(string strDrugName);
        IList<string> SearchDrug(string DrugSearchCriteria);
        Stream SearchMedication(string DrugName, int PageNumber, int MaxResultPerPage);
        Stream SearchMedication_Alerg(string DrugName, int PageNumber, int MaxResultPerPage);
        //IList<Physician_Drug> GetUniqueDrugNameUsingPhysician_ID(ulong ulPhy_ID);
    }

    public partial class All_DrugManager : ManagerBase<All_Drug, ulong>, IAll_DrugManager
    {
        #region Constructors

        public All_DrugManager()
            : base()
        {

        }
        public All_DrugManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        # region userDefinedMethods

        //public IList<All_Drug> GetUniqueDrugNameUsingPhysician_ID(ulong ulPhy_ID)
        //{
        //    ICriteria criteria = session.GetISession().CreateCriteria(typeof(All_Drug));
        //    criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
        //    .Add(Projections.Alias(Projections.Property("Drug_Name"), "Drug_Name"))))
        //    .Add(Expression.Eq("Physician_ID", ulPhy_ID)).AddOrder(Order.Asc("Drug_Name"));

        //    criteria.SetResultTransformer(
        //    new NHibernate.Transform.AliasToBeanResultTransformer(typeof(All_Drug)));
        //    return criteria.List<All_Drug>();

        //}

        //public IList<Physician_DrugManager> GetUniqueDrugNameUsingPhysician_ID(ulong ulPhy_ID)
        //{
        //    //ICriteria criteria = session.GetISession().CreateCriteria(typeof(Physician_Drug));
        //    //criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
        //    //.Add(Projections.Alias(Projections.Property("Drug_Name"), "Drug_Name"))))
        //    //.Add(Expression.Eq("Physician_ID", ulPhy_ID)).AddOrder(Order.Asc("Drug_Name"));

        //    //criteria.SetResultTransformer(
        //    //new NHibernate.Transform.AliasToBeanResultTransformer(typeof(Physician_Drug)));
        //    //return criteria.List<Physician_Drug>();

        //    ICriteria criteria = session.GetISession().CreateCriteria(typeof(Physician_DrugManager)).Add(Expression.Eq("Physician_ID", ulPhy_ID)).AddOrder(Order.Asc("Drug_Name"));
        //    return criteria.List<Physician_DrugManager>();


        //}

        public IList<All_Drug> SearchDrugForRxHistory(string DrugSearchCriteria)
        {
            IList<All_Drug> ilstSearchDrug = new List<All_Drug>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(All_Drug))
                    .Add(Expression.Like("Drug_Name", "%" + DrugSearchCriteria + "%"));
                ilstSearchDrug = crit.List<All_Drug>();
                iMySession.Close();
            }
            return ilstSearchDrug;
        }
        public IList<All_Drug> GetUniqueRouteOfAdministration(ulong ulPhy_ID, string StrDrugName)
        {
            //ICriteria criteria = session.GetISession().CreateCriteria(typeof(All_Drug));
            //criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
            //.Add(Projections.Alias(Projections.Property("Route_Of_Administration"), "Route_Of_Administration"))))
            //.Add(Expression.Eq("Physician_ID", ulPhy_ID))
            //.Add(Expression.Eq("Drug_Name", StrDrugName)).AddOrder(Order.Asc("Route_Of_Administration"));

            //criteria.SetResultTransformer(
            //new NHibernate.Transform.AliasToBeanResultTransformer(typeof(All_Drug)));
            //return criteria.List<All_Drug>();

            IList<All_Drug> ilstAll_Drug = new List<All_Drug>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(All_Drug));
                criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
                .Add(Projections.Alias(Projections.Property("Route_Of_Administration"), "Route_Of_Administration"))
                .Add(Projections.Alias(Projections.Property("Default_Value"), "Default_Value"))))
                .Add(Expression.Eq("Drug_Name", StrDrugName)).AddOrder(Order.Asc("Route_Of_Administration"));

                criteria.SetResultTransformer(
                new NHibernate.Transform.AliasToBeanResultTransformer(typeof(All_Drug)));
                ilstAll_Drug= criteria.List<All_Drug>();
                iMySession.Close();
            }
            return ilstAll_Drug;
        }


        public IList<All_Drug> GetUniqueStrength(ulong ulPhy_ID, string strDrugName, string strRouteOfAdmin)
        {
            //ICriteria criteria = session.GetISession().CreateCriteria(typeof(All_Drug));
            //criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
            //.Add(Projections.Alias(Projections.Property("Strength"), "Strength"))))
            //.Add(Expression.Eq("Physician_ID", ulPhy_ID))
            //.Add(Expression.Eq("Drug_Name", strDrugName))
            //.Add(Expression.Eq("Route_Of_Administration", strRouteOfAdmin)).AddOrder(Order.Asc("Strength"));

            //criteria.SetResultTransformer(
            //new NHibernate.Transform.AliasToBeanResultTransformer(typeof(All_Drug)));
            //return criteria.List<All_Drug>();

            IList<All_Drug> ilstAll_Drug = new List<All_Drug>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(All_Drug));
                criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
                .Add(Projections.Alias(Projections.Property("Strength"), "Strength"))
                .Add(Projections.Alias(Projections.Property("Default_Value"), "Default_Value"))))
                .Add(Expression.Eq("Drug_Name", strDrugName))
                .Add(Expression.Eq("Route_Of_Administration", strRouteOfAdmin)).AddOrder(Order.Asc("Strength"));

                criteria.SetResultTransformer(
                new NHibernate.Transform.AliasToBeanResultTransformer(typeof(All_Drug)));
                ilstAll_Drug = criteria.List<All_Drug>();
                iMySession.Close();
            }
            return ilstAll_Drug;

        }

        public IList<All_Drug> GetStrengthDetailsForDrug(string strDrugName)
        {
            IList<All_Drug> ilstAll_Drug = new List<All_Drug>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(All_Drug));
                criteria.SetProjection(Projections.Distinct(Projections.ProjectionList()
                .Add(Projections.Alias(Projections.Property("Strength"), "Strength"))
                 .Add(Projections.Alias(Projections.Property("Route_Of_Administration"), "Route_Of_Administration"))
                .Add(Projections.Alias(Projections.Property("Default_Value"), "Default_Value"))))
                .Add(Expression.Eq("Drug_Name", strDrugName));

                criteria.SetResultTransformer(
                new NHibernate.Transform.AliasToBeanResultTransformer(typeof(All_Drug)));
                ilstAll_Drug = criteria.List<All_Drug>();
                iMySession.Close();
            }
            return ilstAll_Drug;
        }


        public IList<string> SearchDrug(string DrugSearchCriteria)
        {
            IList<string> ilstSearchDrug = new List<string>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(All_Drug))
                    .SetProjection(Projections.Distinct(Projections.ProjectionList()
                    .Add(Projections.Alias(Projections.Property("Drug_Name"), "Drug_Name"))))
                    .Add(Expression.Like("Drug_Name", "%" + DrugSearchCriteria + "%"))
                    .AddOrder(Order.Asc("Drug_Name"));
                ilstSearchDrug = crit.List<string>();
                iMySession.Close();
            }
            return ilstSearchDrug;
        }

        public Stream SearchMedication(string DrugName, int PageNumber, int MaxResultPerPage)
        {
            var stream = new MemoryStream();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var serializer = new NetDataContractSerializer();

                PageNumber = PageNumber - 1;

                // string query = "SELECT concat(r.rxcui,'+',r.str,'+',s.atv) FROM rxnconso r join rxnsat s on (r.rxcui=s.rxcui)where s.sab='RXNORM'and s.atn='NDC' and str like " + "'%" + DrugName + "%'" + " group by r.str ";
          
                string query = "SELECT concat(Ndc_id ,'+', Generic_Name, '+', Ndc_id)  FROM rcopia_medication where Generic_Name like " + "'%" + DrugName + "%'" + " group by Generic_Name ";
                IList<string> ilstDruglist = iMySession.CreateSQLQuery(query).SetMaxResults(MaxResultPerPage).SetFirstResult(PageNumber * MaxResultPerPage).List<string>();

                Hashtable drugResult = new Hashtable();
                drugResult.Add("MedicationList", ilstDruglist);

                if (PageNumber == 0)
                    drugResult.Add("TotalCount", iMySession.CreateSQLQuery(query).List<string>().Count);

                serializer.WriteObject(stream, drugResult);
                stream.Seek(0L, SeekOrigin.Begin);
                iMySession.Close();
            }

            return stream;
        }

        public Stream SearchMedication_Alerg(string DrugName, int PageNumber, int MaxResultPerPage)
        {
            var stream = new MemoryStream();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var serializer = new NetDataContractSerializer();

                PageNumber = PageNumber - 1;

                // string query = "SELECT concat(r.rxcui,'+',r.str,'+',s.atv) FROM rxnconso r join rxnsat s on (r.rxcui=s.rxcui)where s.sab='RXNORM'and s.atn='NDC' and str like " + "'%" + DrugName + "%'" + " group by r.str ";
           
                string query = "SELECT concat(ndc_id,'+', Allergy_Name ,'+' ,ndc_id) FROM rcopia_allergy  where Allergy_Name like " + "'%" + DrugName + "%'" + " group by Allergy_Name ";
                IList<string> ilstDruglist = iMySession.CreateSQLQuery(query).SetMaxResults(MaxResultPerPage).SetFirstResult(PageNumber * MaxResultPerPage).List<string>();

                Hashtable drugResult = new Hashtable();
                drugResult.Add("MedicationList", ilstDruglist);

                if (PageNumber == 0)
                    drugResult.Add("TotalCount", iMySession.CreateSQLQuery(query).List<string>().Count);

                serializer.WriteObject(stream, drugResult);
                stream.Seek(0L, SeekOrigin.Begin);
                iMySession.Close();
            }

            return stream;
        }

        public Stream SearchMedicationList(string DrugName, int PageNumber, int MaxResultPerPage)
        {
            var stream = new MemoryStream();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var serializer = new NetDataContractSerializer();

                PageNumber = PageNumber - 1;
          
                // string query = "SELECT concat(r.rxcui,'+',r.str,'+',s.atv) FROM rxnconso r join rxnsat s on (r.rxcui=s.rxcui)where s.sab='RXNORM'and s.atn='NDC' and str like " + "'%" + DrugName + "%'" + " group by r.str ";
                string query = "SELECT distinct Generic_Name  FROM rcopia_medication where Generic_Name like " + "'%" + DrugName + "%'" + " group by Generic_Name ";
                IList<string> ilstDruglist = iMySession.CreateSQLQuery(query).SetMaxResults(MaxResultPerPage).SetFirstResult(PageNumber * MaxResultPerPage).List<string>();

                Hashtable drugResult = new Hashtable();
                drugResult.Add("MedicationList", ilstDruglist);

                if (PageNumber == 0)
                    drugResult.Add("TotalCount", iMySession.CreateSQLQuery(query).List<string>().Count);

                serializer.WriteObject(stream, drugResult);
                stream.Seek(0L, SeekOrigin.Begin);
                iMySession.Close();
            }

            return stream;
        }

        public Stream SearchMedicationAllergy(string DrugName, int PageNumber, int MaxResultPerPage)
        {
            var stream = new MemoryStream();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var serializer = new NetDataContractSerializer();

                PageNumber = PageNumber - 1;

           
                string query = "SELECT distinct  Allergy_Name FROM rcopia_allergy  where Allergy_Name like " + "'%" + DrugName + "%'" + " group by Allergy_Name ";
                IList<string> ilstDruglist = iMySession.CreateSQLQuery(query).SetMaxResults(MaxResultPerPage).SetFirstResult(PageNumber * MaxResultPerPage).List<string>();

                Hashtable drugResult = new Hashtable();
                drugResult.Add("MedicationList", ilstDruglist);

                if (PageNumber == 0)
                    drugResult.Add("TotalCount", iMySession.CreateSQLQuery(query).List<string>().Count);

                serializer.WriteObject(stream, drugResult);
                stream.Seek(0L, SeekOrigin.Begin);
                iMySession.Close();
            }

            return stream;
        }


        #endregion
    }
}
