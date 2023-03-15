using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
     [DataContract]
    public partial class LoginDTO
    {
        public LoginDTO()
        {


        }
        IList<User> user;
        IList<UserSession> usersession;
        UserPermissionDTO objuserpermissionDTO;
        string sCarrier = string.Empty;
        int iDefaultServerCount = 0;
        //IList<LastModifiedLocalLookup> lstlookup;

        [DataMember]
        public IList<User> User
        {
            get { return user; }
            set { user = value; }
        }
        [DataMember]
        public IList<UserSession> UserSession
        {
            get { return usersession; }
            set { usersession = value; }
        }
        [DataMember]
        public UserPermissionDTO UserPermissionDTO
        {
            get { return objuserpermissionDTO; }
            set { objuserpermissionDTO = value; }
        }
        [DataMember]
        public string UserCarrier
        {
            get { return sCarrier; }
            set { sCarrier = value; }
        }

        [DataMember]
        public int DefaultServerCount
        {
            get { return iDefaultServerCount; }
            set { iDefaultServerCount = value; }
        }
        //[DataMember]
        //public IList<LastModifiedLocalLookup> lstLookUp
        //{
        //    get { return lstlookup; }
        //    set { lstlookup = value; }
        //}
    }
}
