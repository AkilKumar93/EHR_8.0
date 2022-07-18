using System;
using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;
using NHibernate.Criterion;
using System.Web;
using System.IO;


namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IScnTabManager : IManagerBase<ScnTab, int>
    {
        IList<ScnTab> GetAllScreens(string username);
        IList<ScnTab> GetAllScreensUsingPatent_ID();
        ArrayList GetProcessNameByUserName(string userName);
        UserPermissionDTO GetUserPermisssions(string userName, Boolean bIsScnTabLoad);
    }

    public partial class ScnTabManager : ManagerBase<ScnTab, int>, IScnTabManager
    {

        #region Constructors

        public ScnTabManager()
            : base()
        {

        }
        public ScnTabManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

        public IList<ScnTab> GetAllScreens(string username)
        {

            IList<ScnTab> list = new List<ScnTab>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query1 = iMySession.GetNamedQuery("UserTab.GetAllScreensUsingUserName");
                query1.SetString(0, username);
                ArrayList listArray = new ArrayList(query1.List());
                ScnTab tab;
                if (listArray.Count > 0)
                {
                    foreach (object[] obj in listArray)
                    {
                        tab = new ScnTab();
                        tab.SCN_ID = Convert.ToInt32(obj[0]);
                        tab.SCN_Name = obj[1].ToString();
                        tab.Parent_SCN_ID = Convert.ToInt32(obj[2]);

                        tab.Permission = obj[3].ToString();
                        if (obj[4] != null)
                        {
                            tab.Assigned_Physician_Editable = obj[4].ToString();
                        }

                        list.Add(tab);
                    }
                }
                iMySession.Close();
            }
            return list;

        }

        public IList<ScnTab> GetAllScreensUsingPatent_ID()
        {
            IList<ScnTab> list = new List<ScnTab>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query1 = iMySession.GetNamedQuery("UBAC.GetAllScreensUsingPatentID");

                ArrayList listArray = new ArrayList(query1.List());
                ScnTab tab;

                if (listArray.Count > 0)
                {
                    foreach (object[] obj in listArray)
                    {
                        tab = new ScnTab();
                        tab.SCN_ID = Convert.ToInt32(obj[0]);
                        tab.SCN_Name = obj[1].ToString();
                        tab.Is_UBAC_Or_PBAC = obj[3].ToString();
                        list.Add(tab);
                    }
                }
                iMySession.Close();
            }
            return list;

        }

        public ArrayList GetProcessNameByUserName(string userName)
        {
            IList<ProcessMaster> list = new List<ProcessMaster>();
            ArrayList listArray = new ArrayList();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query1 = iMySession.GetNamedQuery("Get.ProcUser.ProcessName");
                query1.SetString(0, userName);
                listArray = new ArrayList(query1.List());
                ProcessMaster tab;
                //if (listArray.Count > 0)
                //{
                //    foreach (object[] obj in listArray)
                //    {
                //        tab = new ProcessMaster();
                //        tab.Process_Name = obj[0].ToString();
                //       // tab.Is_Addendum_Allowed = obj[1].ToString();
                //        list.Add(tab);
                //    }
                //}

                iMySession.Close();
            }
            return listArray;

        }
        public UserPermissionDTO GetUserPermisssions(string userName, Boolean bIsScnTabLoad)
        {
            UserPermissionDTO objDTO = new UserPermissionDTO();
            objDTO.ListProc = GetProcessNameByUserName(userName);
            objDTO.Screens = GetAllScreens(userName);
            if (bIsScnTabLoad == true)
                objDTO.Scntab = GetAllScreensUsingPatent_ID();
            UserScnTabManager userScnMngr = new UserScnTabManager();
            objDTO.Userscntab = userScnMngr.GetAllScreensUsingscreenid(userName);
            ProcessScnTabManager procScnTab = new ProcessScnTabManager();
            objDTO.ProcessScnTabList = procScnTab.GetAllProcessScnTab(userName);
            return objDTO;
        }
        #endregion


    }
}
