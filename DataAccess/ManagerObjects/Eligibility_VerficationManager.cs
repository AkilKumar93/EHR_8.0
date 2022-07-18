using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IEligibility_VerficationManager : IManagerBase<Eligibility_Verification, ulong>
    {
        IList<Eligibility_Verification> GetPatientDetailsUsingPatientInformattion(ulong iHumanId);
        IList<Eligibility_Verification> GetEligibilityDetails(ulong iHumanId,ulong insPlanId);        
        int SaveEligWithoutTransaction(IList<Eligibility_Verification> ListToInsert, ISession MySession, string MACAddress);        
        void UpdateEligibilityVerificationInformatnion(Eligibility_Verification objEligibilityVerification, string MACAddress);
        IList<Eligibility_Verification> GetEligDetailsUsingHumanandPolicyHolderID(ulong iHumanId, string PolicyHolderId);
        IList<Eligibility_Verification> GetEligDetailsUsingHumanandPolicyHolderIDandInsPlanID(ulong iHumanId, string PolicyHolderId, ulong InsPlanId);
        IList<Eligibility_Verification> GetDateUsingEligibilityVerification(ulong uHumanId);
    }

    public class Eligibility_VerficationManager : ManagerBase<Eligibility_Verification, ulong>, IEligibility_VerficationManager
    {
         #region Constructors

        public Eligibility_VerficationManager()
            : base()
        {

        }
        public Eligibility_VerficationManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Method
        public IList<Eligibility_Verification> GetDateUsingEligibilityVerification(ulong uHumanId )
        {

            IList<Eligibility_Verification> lstPlanList = new List<Eligibility_Verification>();

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                ////ICriteria criteria = iMySession.CreateCriteria(typeof(Eligibility_Verification)).Add(Expression.Eq("Human_ID", uHumanId)).AddOrder();

                //if (criteria.List<Eligibility_Verification>() != null && criteria.List<Eligibility_Verification>().Count > 0)
                //{
                //    lstPlanList = criteria.List<Eligibility_Verification>();
                //}

              //  ISQLQuery sql = iMySession.CreateSQLQuery("SELECT  h.* from eligibility_verification as h  where human_id ='" + uHumanId + "'  order by h.created_date_and_time desc limit 1 ").AddEntity("h", typeof(Eligibility_Verification)); ;

                //ISQLQuery sql = iMySession.CreateSQLQuery("  SELECT f.* FROM ( select insurance_plan_id,max(created_date_and_time) as created_date_and_time  from eligibility_verification  where human_id= '" + uHumanId + " '  group by insurance_plan_id ) Z INNER JOIN eligibility_verification f USING (insurance_plan_id,created_date_and_time)order by created_date_and_time desc").AddEntity("f", typeof(Eligibility_Verification));

                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT f.* FROM ( select insurance_plan_id,max(created_date_and_time) as created_date_and_time  from eligibility_verification  where human_id='" + uHumanId + " ' group by insurance_plan_id )Z INNER JOIN eligibility_verification f USING (insurance_plan_id,created_date_and_time)order by created_date_and_time desc").AddEntity("f", typeof(Eligibility_Verification));
                
                lstPlanList = sql.List<Eligibility_Verification>();
                iMySession.Close();
            }

            return lstPlanList;
        }

        public static IList EligibilityVerificationDetails;
        public IList<Eligibility_Verification> GetPatientDetailsUsingPatientInformattion(ulong iHumanId)
        {
            IList<Eligibility_Verification> ilstEligibility_Verification = new List<Eligibility_Verification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Eligibility_Verification)).Add(Expression.Eq("Human_ID", iHumanId));
                ilstEligibility_Verification = criteria.List<Eligibility_Verification>();
                iMySession.Close();
            }
            return ilstEligibility_Verification;
            //return criteria.List<Eligibility_Verification>();
        }

        public IList<Eligibility_Verification> GetEligibilityDetails(ulong iHumanId, ulong insPlanId)
        {
            IList<Eligibility_Verification> ilstEligibility_Verification = new List<Eligibility_Verification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Eligibility_Verification)).Add(Expression.Eq("Human_ID", iHumanId)).Add(Expression.Eq("Insurance_Plan_ID", insPlanId));
                ilstEligibility_Verification = criteria.List<Eligibility_Verification>();
                iMySession.Close();
            }
            return ilstEligibility_Verification;
            //return criteria.List<Eligibility_Verification>();
        }

        public int SaveEligWithoutTransaction(IList<Eligibility_Verification> ListToInsert, ISession MySession, string MACAddress)
        {
            int iResult = 0;
            IList<Eligibility_Verification> EVTemp = null;
              GenerateXml ObjXML = null;
            if ((ListToInsert != null) )
            {
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref EVTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
            }
            return iResult;
        }
        
        public void UpdateEligibilityVerificationInformatnion(Eligibility_Verification objEligibilityVerification, string MACAddress)
        {
            IList<Eligibility_Verification> EligAddList = null;
            IList<Eligibility_Verification> eliglist = new List<Eligibility_Verification>();
            eliglist.Add(objEligibilityVerification);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref EligAddList, ref eliglist, null, MACAddress, false, false, 0, "");
        }

        public IList<Eligibility_Verification> GetEligDetailsUsingHumanandPolicyHolderID(ulong iHumanId, string PolicyHolderId)
        {
            IList<Eligibility_Verification> ilstEligibility_Verification = new List<Eligibility_Verification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Eligibility_Verification)).Add(Expression.Eq("Human_ID", iHumanId)).Add(Expression.Eq("Policy_Holder_ID", PolicyHolderId)).AddOrder(Order.Desc("Created_Date_And_Time"));
                ilstEligibility_Verification = criteria.List<Eligibility_Verification>();
                iMySession.Close();
            }
            return ilstEligibility_Verification;
            // return criteria.List<Eligibility_Verification>();
        }

        public IList<Eligibility_Verification> GetEligDetailsUsingHumanandPolicyHolderIDandInsPlanID(ulong iHumanId, string PolicyHolderId,ulong InsPlanId)
        {
            IList<Eligibility_Verification> ilstEligibility_Verification = new List<Eligibility_Verification>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Eligibility_Verification)).Add(Expression.Eq("Human_ID", iHumanId)).Add(Expression.Eq("Policy_Holder_ID", PolicyHolderId)).Add(Expression.Eq("Insurance_Plan_ID", InsPlanId)).AddOrder(Order.Desc("Created_Date_And_Time"));
                ilstEligibility_Verification = criteria.List<Eligibility_Verification>();
                iMySession.Close();
            }
            return ilstEligibility_Verification;
            //return criteria.List<Eligibility_Verification>();
        }
        public void SaveEligibilityVerificationAndInsuranceRCM(Eligibility_Verification objEligibilityVerification, InsurancePlan objInsPlan, string MACAddress,PatientNotes PatientNotesRecord)
        {
            IList<Eligibility_Verification> eliglist = new List<Eligibility_Verification>();
            eliglist.Add(objEligibilityVerification);
            IList<Eligibility_Verification> EVTemp = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref eliglist, ref EVTemp, null, MACAddress, false, false, 0, "");

            if (objInsPlan != null)
            {
                InsurancePlanManager objInsPlanMngr = new InsurancePlanManager();
                objInsPlanMngr.updateInsurancePlan(objInsPlan, 0, 0, string.Empty);
            }

            //srividhya added on 03-Feb-2014
            if (PatientNotesRecord != null)
            {
                PatientNotesManager PatNotMngr = new PatientNotesManager();
                IList<PatientNotes> patnoteslist = new List<PatientNotes>();
                patnoteslist.Add(PatientNotesRecord);
                IList<PatientNotes> PatNotesTemp = null;
                PatNotMngr.SaveUpdateDelete_DBAndXML_WithTransaction(ref patnoteslist, ref PatNotesTemp, null, MACAddress, false, false, 0, "");
            }
        }

        public ArrayList GetEvDetails(ulong Human_ID)
        {
            IList<ModifierLibrary> ilistModifier = new List<ModifierLibrary>();
            ModifierLibrary objstat = new ModifierLibrary();
            ArrayList aryModifier = new ArrayList();
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("get.EV.Details");
                //query.SetString(0, Field_Name);
                query.SetParameter(0, Human_ID);
                query.SetParameter(1, Human_ID);
                 aryModifier = new ArrayList();
                aryModifier = new ArrayList(query.List());
               
                iMySession.Close();
            }
            return aryModifier;
        }
        public ArrayList GetEvDetailsshowall(ulong Human_ID)
        {
            IList<ModifierLibrary> ilistModifier = new List<ModifierLibrary>();
            ModifierLibrary objstat = new ModifierLibrary();
            ArrayList aryModifier = new ArrayList();
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("get.EV.Details.showall");
                //query.SetString(0, Field_Name);
                query.SetParameter(0, Human_ID);
                query.SetParameter(1, Human_ID);
                aryModifier = new ArrayList();
                aryModifier = new ArrayList(query.List());

                iMySession.Close();
            }
            return aryModifier;
        }
        public ArrayList GetEvhumnaPlanResponseFile(ulong Human_ID,ulong planID, string PolicyHolderID)
        {
            IList<ModifierLibrary> ilistModifier = new List<ModifierLibrary>();
            ModifierLibrary objstat = new ModifierLibrary();
            ArrayList aryModifier = new ArrayList();
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("get.EV.Human.ResponseFile");
                //query.SetString(0, Field_Name);
                query.SetParameter(0, Human_ID);
                query.SetParameter(1, planID);
                query.SetParameter(2, PolicyHolderID);
                aryModifier = new ArrayList();
                aryModifier = new ArrayList(query.List());

                iMySession.Close();
            }
            return aryModifier;
        }
        #endregion

    }
}
