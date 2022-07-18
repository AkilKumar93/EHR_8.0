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
    public partial interface IAuthorizationEncounterManager : IManagerBase<AuthorizationEncounter, ulong>
    {
        AuthorizationDTO GetAuthdetailsByEncIDAndHumanID(ulong EncounterID, ulong HumanID);
        IList<AuthorizationEncounter> GetAuthdetailsByAuthID(ulong ulAuthID);
        IList<AuthorizationEncounter> DeleteAuthEncDetailsByAuthID(ulong DeleteID, string susername, DateTime mDt);
        IList<AuthorizationEncounter> GetAuthdetailsByEncID(ulong ulEncounterID);

        AuthorizationDTO GetAuthDetailsByEncID(ulong EncounterID);
        IList<AuthorizationEncounter> GetAuthdetailsByEncIDAndAuthID(ulong ulEncounterID, ulong ulAuthID);
        IList<AuthorizationEncounter> AddlsttoAuthEncounter(IList<AuthorizationEncounter> Addlst);
        IList<AuthorizationEncounter> GetAuthdetailsByEncAndHumanID(ulong ulEncounterID, ulong ulHumanID, ulong ulAuthID);
        IList<AuthorizationEncounter> UpdateIsActive(IList<AuthorizationEncounter> Updatelst, string MacAddress);
        IList<AuthorizationEncounter> SaveUpdateDeleteAuthorizationEncounter(IList<AuthorizationEncounter> SaveAuthorization, IList<AuthorizationEncounter> UpdateAuthorization, IList<AuthorizationEncounter> DeleteAuthorization, ulong ulHumanId, ulong ulEncounterID, bool bIsShowall);
    }

    public partial class AuthorizationEncounterManager : ManagerBase<AuthorizationEncounter, ulong>, IAuthorizationEncounterManager
    {
        #region Constructors

        public AuthorizationEncounterManager()
            : base()
        {

        }
        public AuthorizationEncounterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<AuthorizationEncounter> SaveUpdateDeleteAuthorizationEncounter(IList<AuthorizationEncounter> SaveAuthorization, IList<AuthorizationEncounter> UpdateAuthorization, IList<AuthorizationEncounter> DeleteAuthorization, ulong ulHumanId, ulong ulEncounterID, bool bIsShowall)
        {
            IList<AuthorizationEncounter> ilstAuthorization = new List<AuthorizationEncounter>();
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveAuthorization, ref UpdateAuthorization, DeleteAuthorization, string.Empty, false, false, 0, string.Empty);
            //using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            //{
            //    ICriteria criteria = null;
            //    if (bIsShowall == true)
            //        criteria = iMySession.CreateCriteria(typeof(AuthorizationEncounter)).Add(Expression.Eq("Human_ID", ulHumanId)).AddOrder(Order.Desc("Created_Date_And_Time"));

            //    ilstAuthorization = criteria.List<AuthorizationEncounter>();
            //    iMySession.Close();
            //}
            //ISQLQuery sqlquery = session.GetISession().CreateSQLQuery("select * from authorization where Human_Id=" + ulHumanId + " and status='valid';").AddEntity(typeof(Authorization));
            //    ilstAuthorization = sqlquery.List<Authorization>();
            return ilstAuthorization;
        }

        public IList<AuthorizationEncounter> DeleteAuthEncDetailsByAuthID(ulong DeleteID, string susername, DateTime mDt)
        {
            IList<AuthorizationEncounter> ilstAuthorization = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                AuthorizationEncounterManager objAuth = new AuthorizationEncounterManager();

                ilstAuthorization = objAuth.GetAuthdetailsByAuthProID(DeleteID);
                if (ilstAuthorization != null && ilstAuthorization.Count > 0)
                {
                    ilstAuthorization[0].Is_Deleted = "Y";
                    ilstAuthorization[0].Modified_By = susername;
                    ilstAuthorization[0].Modified_Date_And_Time = mDt;
                }
                IList<AuthorizationEncounter> SaveAuthorization = new List<AuthorizationEncounter>();
                IList<AuthorizationEncounter> deleteAuthorization = new List<AuthorizationEncounter>();
                SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveAuthorization, ref ilstAuthorization, deleteAuthorization, string.Empty, false, false, 0, string.Empty);

                iMySession.Close();
            }
            return ilstAuthorization;
        }

        public AuthorizationDTO GetAuthdetailsByEncIDAndHumanID(ulong EncounterID, ulong HumanID)
        {
            AuthorizationDTO objAuthDTO = new AuthorizationDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT a.*,b.* FROM authorization_encounter a,authorization b where a.encounter_id=" + Convert.ToUInt32(EncounterID) + " and a.human_id=" + Convert.ToUInt32(HumanID) + " and a.is_active='Y' and a.authorization_id=b.authorization_id and a.human_id=b.human_id;")
                  .AddEntity("a", typeof(AuthorizationEncounter)).AddEntity("b", typeof(Authorization));

                if (sql.List().Count > 0)
                {
                    foreach (IList<Object> l in sql.List())
                    {
                        AuthorizationEncounter AuthEncRecord = (AuthorizationEncounter)l[0];
                        objAuthDTO.ilstAuthorizationEncounter.Add(AuthEncRecord);

                        Authorization AuthRecord = (Authorization)l[1];
                        objAuthDTO.ilstAuthorization.Add(AuthRecord);
                    }
                }
                iMySession.Close();
            }
            return objAuthDTO;
        }

        public IList<AuthorizationEncounter> GetAuthdetailsByAuthID(ulong ulAuthID)
        {
            IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(AuthorizationEncounter)).Add(Expression.Eq("Authorization_ID", ulAuthID));
                AuthEncList = criteria.List<AuthorizationEncounter>();
                iMySession.Close();
            }
            return AuthEncList;
        }


        public IList<AuthorizationEncounter> GetAuthdetailsByAuthProID(ulong ulAuthID)
        {
            IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(AuthorizationEncounter)).Add(Expression.Eq("Authorization_Procedure_ID", ulAuthID));
                AuthEncList = criteria.List<AuthorizationEncounter>();
                iMySession.Close();
            }
            return AuthEncList;
        }

        public IList<AuthorizationEncounter> GetAuthdetailsByEncID(ulong ulEncounterID)
        {
            IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = session.GetISession().CreateCriteria(typeof(AuthorizationEncounter)).Add(Expression.Eq("Encounter_ID", ulEncounterID));
                AuthEncList = criteria.List<AuthorizationEncounter>();
                iMySession.Close();
            }

            return AuthEncList;
        }

        public AuthorizationDTO GetAuthDetailsByEncID(ulong EncounterID)
        {
            AuthorizationDTO objAuthDTO = new AuthorizationDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT a.*,b.* FROM authorization_encounter a,authorization b where a.encounter_id=" + Convert.ToUInt32(EncounterID) + " and a.authorization_id=b.authorization_id and a.human_id=b.human_id;")
                  .AddEntity("a", typeof(AuthorizationEncounter)).AddEntity("b", typeof(Authorization));

                if (sql.List().Count > 0)
                {
                    foreach (IList<Object> l in sql.List())
                    {
                        AuthorizationEncounter AuthEncRecord = (AuthorizationEncounter)l[0];
                        objAuthDTO.ilstAuthorizationEncounter.Add(AuthEncRecord);

                        Authorization AuthRecord = (Authorization)l[1];
                        objAuthDTO.ilstAuthorization.Add(AuthRecord);
                    }
                }
                iMySession.Close();
            }
            return objAuthDTO;
        }

        public IList<AuthorizationEncounter> GetAuthdetailsByEncIDAndAuthID(ulong ulEncounterID, ulong ulAuthID)
        {
            IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT a.*,b.* FROM authorization_encounter a,authorization b where a.encounter_id=" + ulEncounterID + " and a.authorization_id=" + ulAuthID + " and  a.authorization_id=b.authorization_id and a.human_id=b.human_id and a.is_active='Y' and b.is_active='Y';")
                  .AddEntity("a", typeof(AuthorizationEncounter)).AddEntity("b", typeof(Authorization));

                if (sql.List().Count > 0)
                {
                    foreach (IList<Object> l in sql.List())
                    {
                        AuthorizationEncounter AuthEncRecord = (AuthorizationEncounter)l[0];
                        AuthEncList.Add(AuthEncRecord);
                    }
                }
                iMySession.Close();
            }

            return AuthEncList;
        }

        //public IList<AuthorizationEncounter> GetAuthdetailsByEncAndHumanID(ulong ulEncounterID, ulong ulHumanID,ulong ulAuthID)
        //{
        //    IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
        //    ICriteria criteria;

        //    criteria = session.GetISession().CreateCriteria(typeof(AuthorizationEncounter)).Add(Expression.Eq("Encounter_ID", ulEncounterID)).Add(Expression.Eq("Human_ID", ulEncounterID)).Add(Expression.Not(Expression.Eq("Authorization_ID",ulAuthID)));
        //    AuthEncList = criteria.List<AuthorizationEncounter>();

        //    return AuthEncList;
        //}

        public IList<AuthorizationEncounter> GetAuthdetailsByEncAndHumanID(ulong ulEncounterID, ulong ulHumanID, ulong ulAuthID)
        {
            IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("SELECT * FROM authorization_encounter a where a.encounter_id=" + ulEncounterID + " and a.Human_Id=" + ulHumanID + " and a.Authorization_ID<>" + ulAuthID + " and a.is_active='Y';").AddEntity("a", typeof(AuthorizationEncounter));
                AuthEncList = sql.List<AuthorizationEncounter>();
                iMySession.Close();
            }
            return AuthEncList;
        }
        public IList<AuthorizationEncounter> AddlsttoAuthEncounter(IList<AuthorizationEncounter> Addlst)
        {
            IList<AuthorizationEncounter> SaveList = new List<AuthorizationEncounter>();
            AuthorizationEncounter objAuthorization = null;

            for (int i = 0; i < Addlst.Count; i++)
            {
                objAuthorization = new AuthorizationEncounter();
                objAuthorization.Encounter_ID = Addlst[i].Encounter_ID;
                objAuthorization.Authorization_ID = Addlst[i].Authorization_ID;
                objAuthorization.Human_ID = Addlst[i].Human_ID;
                objAuthorization.Created_By = Addlst[i].Created_By;
                objAuthorization.Created_Date_And_Time = Addlst[i].Created_Date_And_Time;
                //objAuthorization.Is_Active = Addlst[i].Is_Active;
                // objAuthorization.Is_Tied_To_Encounter = Addlst[i].Is_Tied_To_Encounter;
                SaveList.Add(objAuthorization);
            }
            ISession MySession = Session.GetISession();

            //SaveUpdateDeleteWithoutTransaction(ref SaveList, null, null, MySession, string.Empty);
            return SaveList;
        }
        public IList<AuthorizationEncounter> GetAuthorizationEncounterRecords(UInt64 AuthId, ulong ulEncounterID)
        {
            IList<AuthorizationEncounter> AuthList = new List<AuthorizationEncounter>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(AuthorizationEncounter)).Add(Expression.Eq("Id", AuthId)).Add(Expression.Eq("Encounter_ID", ulEncounterID));
                AuthList = criteria.List<AuthorizationEncounter>();
                iMySession.Close();
            }
            return AuthList;
        }
        public IList<AuthorizationEncounter> UpdateIsActive(IList<AuthorizationEncounter> Updatelst, string MacAddress)
        {
            IList<AuthorizationEncounter> List = new List<AuthorizationEncounter>();

            SaveUpdateDeleteWithTransaction(ref List, Updatelst, null, MacAddress);
            return Updatelst;
        }
    }
}
