using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Security.Cryptography;
using System.Text;
using Acurus.Capella.Core.DTO;
using System.Collections;
using System.Web;
using System.IO;
using System.DirectoryServices;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IClientManager : IManagerBase<Client, ulong>
    {
        IList<Client> GetClientList();
    }

    public partial class ClientManager : ManagerBase<Client, ulong>, IClientManager
    {
        #region Constructors

        public ClientManager()
            : base()
        {

        }
        public ClientManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region GetMethods

        public IList<Client> GetClientList()
        {
            return GetAll();
        }

        #endregion


    }
}
