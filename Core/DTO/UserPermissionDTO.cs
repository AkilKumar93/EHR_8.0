using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;
using System.Collections;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class UserPermissionDTO
    {
        public UserPermissionDTO()
        {


        }

        IList<ScnTab> screens;
       IList<ScnTab> scntab;
        IList<ProcessScnTab> processScnTab;
        //IList<role_scn_tab> rolescntab;
        ArrayList listProc;
        //IList<RoleExceptionScnTab> roleExceptionScnTab;
        IList<user_scn_tab> userscntab;


        [DataMember]
        public IList<ScnTab> Screens
        {
            get { return screens; }
            set { screens = value; }
        }
        [DataMember]
        public IList<ScnTab> Scntab
        {
            get { return scntab; }
            set { scntab = value; }
        }
       
        [DataMember]
        public IList<ProcessScnTab> ProcessScnTabList
        {
            get { return processScnTab; }
            set { processScnTab = value; }
        }
      
        [DataMember]
        public IList<user_scn_tab> Userscntab
        {
            get { return userscntab; }
            set { userscntab = value; }

        }
        [DataMember]
        public ArrayList ListProc
        {
            get { return listProc; }
            set { listProc = value; }

        }
        //[DataMember]
        //public IList<RoleExceptionScnTab> RoleExceptionScnTab
        //{
        //    get { return roleExceptionScnTab; }
        //    set { roleExceptionScnTab = value; }

        //}
     


    }
}
