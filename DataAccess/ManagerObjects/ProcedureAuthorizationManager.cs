using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System;
namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IProcedureAuthorizationManager : IManagerBase<ProcedureAuthorization,string>
    {
        bool CheckAuthorizationRequiredOrNot(string Procedure,ulong InsPlanID);
    }
    public partial class ProcedureAuthorizationManager:ManagerBase<ProcedureAuthorization,string>,IProcedureAuthorizationManager
    {
        #region Constructors

        public ProcedureAuthorizationManager()
            : base()
        {

        }
        public ProcedureAuthorizationManager(INHibernateSession session)
            : base(session)
        {

        }

        #endregion

        public bool CheckAuthorizationRequiredOrNot(string Procedure,ulong InsPlanID)
        {
            //try
            //{
            bool authRequired = false;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ProcedureAuthorization)).Add(Expression.Eq("Procedure_Code", Procedure)).Add(Expression.Eq("Insurance_Plan_ID", InsPlanID));
                IList<ProcedureAuthorization> list = criteria.List<ProcedureAuthorization>();            
                if (list.Count > 0)
                {
                    if (list[0].Is_Auth_Required == "Y")
                        authRequired = true;
                    else
                        authRequired = false;
                }
                iMySession.Close();
            }
                return authRequired;
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}

            
            
        }
    }
}
