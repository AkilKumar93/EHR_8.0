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
    public partial interface IAuthorizationICDManager : IManagerBase<AuthorizationICD,ulong>
    {
        IList<AuthorizationICD> GetAuthICDDetailsUsingAuthID(ulong ulAuthID);
        IList<AuthorizationICD> AddlsttoAuthICD(IList<AuthorizationICD> Addlst);
        IList<AuthorizationICD> GetAuthICDDetailsUsingAuthicdID(ulong ulAuthID);
       void  UpdateIsDelete(IList<AuthorizationICD> AuthICDlst, string MacAddress);
    }

    public partial class AuthorizationICDManager : ManagerBase<AuthorizationICD, ulong>, IAuthorizationICDManager
    {
        #region Constructors

        public AuthorizationICDManager()
            : base()
        {

        }
        public AuthorizationICDManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<AuthorizationICD> GetAuthICDDetailsUsingAuthID(ulong ulAuthID)
        {
            IList<AuthorizationICD> ilstAuthorizationICD = new List<AuthorizationICD>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(AuthorizationICD)).Add(Expression.Eq("Authorization_ID", ulAuthID));
                ilstAuthorizationICD= criteria.List<AuthorizationICD>();
                iMySession.Close();
            }
            return ilstAuthorizationICD;
           
        }
        public IList<AuthorizationICD> GetAuthICDDetailsUsingAuthicdID(ulong ulAuthID)
        {
            IList<AuthorizationICD> ilstAuthorizationICD = new List<AuthorizationICD>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(AuthorizationICD)).Add(Expression.Eq("Id", ulAuthID));
                ilstAuthorizationICD= criteria.List<AuthorizationICD>();
                iMySession.Close();
            }
            return ilstAuthorizationICD;
        }

        public IList<AuthorizationICD> AddlsttoAuthICD(IList<AuthorizationICD> Addlst)
        {
            IList<AuthorizationICD> SaveList = new List<AuthorizationICD>();
            AuthorizationICD objAuthorizationIcd = null;

            for (int i = 0; i < Addlst.Count; i++)
            {

                objAuthorizationIcd = new AuthorizationICD();
                objAuthorizationIcd.Authorization_ID = Addlst[i].Authorization_ID;
                objAuthorizationIcd.ICD = Addlst[i].ICD;
                objAuthorizationIcd.Human_ID = Addlst[i].Human_ID;

                SaveList.Add(objAuthorizationIcd);


            }
            ISession MySession = Session.GetISession();

            //SaveUpdateDeleteWithoutTransaction(ref SaveList, null, null, MySession, string.Empty);
            return SaveList;

        }
        int iTryCount = 0;
        public void UpdateIsDelete(IList<AuthorizationICD> AuthICDlst, string MacAddress)
        {
            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            trans = MySession.BeginTransaction();
            bool bResult = false;
           // ulong ReturnID = 0;
            int iResult = 0;
        TryAgain:
            try
            {
                //IList<CallLog> iListCallLog = new List<CallLog>();
                //iListCallLog.Add(objCallLog);
                IList<AuthorizationICD> PatientDummy = new List<AuthorizationICD>();
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
    }
}
