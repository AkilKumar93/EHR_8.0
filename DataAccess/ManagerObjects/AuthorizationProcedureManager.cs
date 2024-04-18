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
    public partial interface IAuthorizationProcedureManager : IManagerBase<AuthorizationProcedure, ulong>
    {
        IList<AuthorizationProcedure> GetAuthProcDetailsUsingAuthID(ulong ulAuthID);
        IList<AuthorizationProcedure> DeleteAuthProcDetailsByAuthID(ulong DeleteID, string susername,DateTime mDt);
        IList<AuthorizationProcedure> GetAuthProcDetailsUsingAuthProID(ulong ulAuthID);
        IList<AuthorizationProcedure> GetAuthProcDetailsByCPT(string sCPT, ulong ulHumanID);
        IList<AuthorizationProcedure> GetAuthProcDetailsByCPTAndAuthID(string sCPT, ulong ulHumanID, ulong ulAuthID);
        void UpdateIsDelete(IList<AuthorizationProcedure> AuthICDlst, string MacAddress);
        IList<AuthorizationProcedure> SaveUpdateDeleteAuthorization(IList<AuthorizationProcedure> SaveAuthorization, IList<AuthorizationProcedure> UpdateAuthorization, IList<AuthorizationProcedure> DeleteAuthorization, ulong ulHumanId, ulong ulEncounterID, bool bIsShowall);
        IList<AuthorizationProcedure> GetAuthProcedureByAuthorizationID(ulong Authorization_ID, bool bIsShowall);
    }

    public partial class AuthorizationProcedureManager : ManagerBase<AuthorizationProcedure, ulong>, IAuthorizationProcedureManager
    {
        #region Constructors

        public AuthorizationProcedureManager()
            : base()
        {

        }
        public AuthorizationProcedureManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<AuthorizationProcedure> GetAuthProcDetailsUsingAuthID(ulong ulAuthID)
        {
            IList<AuthorizationProcedure> ilstAuthorizationProcedure = new List<AuthorizationProcedure>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("Authorization_ID", ulAuthID));
                ilstAuthorizationProcedure = criteria.List<AuthorizationProcedure>();
                iMySession.Close();
            }
            return ilstAuthorizationProcedure;
        }

        public IList<AuthorizationProcedure> GetAuthProcDetailsUsingAuthProID(ulong ulAuthID)
        {
            IList<AuthorizationProcedure> ilstAuthorizationProcedure = new List<AuthorizationProcedure>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("Id", ulAuthID));
                ilstAuthorizationProcedure = criteria.List<AuthorizationProcedure>();
                iMySession.Close();
            }
            return ilstAuthorizationProcedure;
        }
        public IList<AuthorizationProcedure> GetAuthProcDetailsByCPT(string sCPT, ulong ulHumanID)
        {
            IList<AuthorizationProcedure> AuthList = new List<AuthorizationProcedure>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("From_Procedure_Code", sCPT)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Is_Delete", "N"));
                AuthList = criteria.List<AuthorizationProcedure>();
                iMySession.Close();

            }
            return AuthList;
        }
        public IList<AuthorizationProcedure> DeleteAuthProcDetailsByAuthID(ulong DeleteID,string susername,DateTime mDt)
        {
            IList<AuthorizationProcedure> ilstAuthorization = new List<AuthorizationProcedure>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                AuthorizationProcedureManager objAuth = new AuthorizationProcedureManager();
                AuthorizationProcedure objAuthPro = new AuthorizationProcedure();
                objAuthPro = objAuth.GetById(DeleteID);
                ilstAuthorization.Add(objAuthPro);
                if (ilstAuthorization != null && ilstAuthorization.Count > 0)
                {
                    ilstAuthorization[0].Is_Delete = "Y";
                    ilstAuthorization[0].Modified_By = susername;

                    ilstAuthorization[0].Modified_Date_And_Time = mDt;
                }
                IList<AuthorizationProcedure> SaveAuthorization = new List<AuthorizationProcedure>();
                IList<AuthorizationProcedure> deleteAuthorization = new List<AuthorizationProcedure>();
                SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveAuthorization, ref ilstAuthorization, deleteAuthorization, string.Empty, false, false, 0, string.Empty);

                iMySession.Close();
            }
            return ilstAuthorization;
        }

        public IList<AuthorizationProcedure> GetAuthProcDetailsByCPTAndAuthID(string sCPT, ulong ulHumanID, ulong ulAuthID)
        {
            IList<AuthorizationProcedure> AuthList = new List<AuthorizationProcedure>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("From_Procedure_Code", sCPT)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Authorization_ID", ulAuthID)).Add(Expression.Eq("Is_Delete", "N"));
                AuthList = criteria.List<AuthorizationProcedure>();
                iMySession.Close();
            }
            return AuthList;
        }
        int iTryCount = 0;
        public void UpdateIsDelete(IList<AuthorizationProcedure> AuthICDlst, string MacAddress)
        {
            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            trans = MySession.BeginTransaction();
            bool bResult = false;
            //ulong ReturnID = 0;
            int iResult = 0;
        TryAgain:
            try
            {
                //IList<CallLog> iListCallLog = new List<CallLog>();
                //iListCallLog.Add(objCallLog);
                IList<AuthorizationProcedure> PatientDummy = new List<AuthorizationProcedure>();
                //iResult = SaveUpdateDeleteWithoutTransaction(ref PatientDummy, AuthICDlst, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Deadlock is occured. Transaction failed");
                    }
                }
                else if (iResult == 1)
                {
                    trans.Rollback();
                    //MySession.Close();
                    throw new Exception("Exception is occured. Transaction failed");
                }

                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                //CAP-1942
                throw new Exception(ex.Message,ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                //CAP-1942
                throw new Exception(e.Message, e);
            }
            finally
            {
                MySession.Close();
            }
            // return iListAuth[0].Id;
        }

        public IList<AuthorizationProcedure> SaveUpdateDeleteAuthorization(IList<AuthorizationProcedure> SaveAuthorization, IList<AuthorizationProcedure> UpdateAuthorization, IList<AuthorizationProcedure> DeleteAuthorization, ulong ulHumanId, ulong ulEncounterID, bool bIsShowall)
        {
            IList<AuthorizationProcedure> ilstAuthorization = new List<AuthorizationProcedure>();
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveAuthorization, ref UpdateAuthorization, DeleteAuthorization, string.Empty, false, false, 0, string.Empty);
            ulong Authorization_ID = 0;
            if (SaveAuthorization != null && SaveAuthorization.Count > 0)
                Authorization_ID = SaveAuthorization[0].Authorization_ID;
            else
                Authorization_ID = UpdateAuthorization[0].Authorization_ID;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = null;

                if (bIsShowall != true)
                    criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("Authorization_ID", Authorization_ID)).Add(Expression.Eq("Is_Delete", "N")).AddOrder(Order.Desc("Created_Date_And_Time"));
                else
                    criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("Authorization_ID", Authorization_ID)).AddOrder(Order.Desc("Created_Date_And_Time"));
                ilstAuthorization = criteria.List<AuthorizationProcedure>();
                iMySession.Close();
            }
            return ilstAuthorization;
        }


        public IList<AuthorizationProcedure> GetAuthProcedureByAuthorizationID(ulong Authorization_ID, bool bIsShowall)
        {
            IList<AuthorizationProcedure> ilstAuthorization = new List<AuthorizationProcedure>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = null;

                if (bIsShowall != true)
                    criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("Authorization_ID", Authorization_ID)).Add(Expression.Eq("Is_Delete", "N")).AddOrder(Order.Desc("Created_Date_And_Time"));
                else
                    criteria = iMySession.CreateCriteria(typeof(AuthorizationProcedure)).Add(Expression.Eq("Authorization_ID", Authorization_ID)).AddOrder(Order.Desc("Created_Date_And_Time"));
                ilstAuthorization = criteria.List<AuthorizationProcedure>();
                iMySession.Close();
            }
            return ilstAuthorization;
        }

    }
}
