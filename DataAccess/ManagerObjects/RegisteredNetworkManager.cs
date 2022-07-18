using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.Web;
using System.IO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRegisteredNetworkManager:IManagerBase<RegisteredNetwork,ulong>
    {
        string GetFacilityByClientIPAddress(string sClientIPAddress);
    }
    public partial class RegisteredNetworkManager : ManagerBase<RegisteredNetwork, ulong>, IRegisteredNetworkManager
    {
        #region Constructors

        public RegisteredNetworkManager()
            : base()
        {

        }
        public RegisteredNetworkManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods
        public string GetFacilityByClientIPAddress(string sClientIPAddress)
        {
            string sFacilityName =string.Empty;
            //ISession mySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IList<object> objLst = mySession.CreateSQLQuery("SELECT Facility_Name FROM registered_network where primary_ip_address='" + sClientIPAddress + "' or secondary_ip_address='" + sClientIPAddress + "'").List<object>();

                for (int i = 0; i < objLst.Count; i++)
                {
                    sFacilityName = objLst[i].ToString();
                    break;
                }
                mySession.Close();
            }
            return sFacilityName;
        }
        #endregion
    }
}
