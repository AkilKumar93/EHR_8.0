using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Linq;
using System.Xml.Serialization;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    

    public partial interface IUserSessionManager : IManagerBase<UserSession, string>
    {
        //int InsertUserSession(UserSession userSession, string MACAddress);

        //void DeleteUserSessionUsingUserSessionIED(string userName);

        //IList<UserSession> GetAllUsersInSession();

        //void UpdateUserSession(UserSession userSession, string userName, string MACAddress);

        //IList<UserSession> GetCurrentSessionByUserName(string sUserName);

       // void DeleteUserSessionAtSessionEnd(string sSessionID);

        //void DeleteUserSessionFromXml(string CurrentSessionId);
        //void InsertUpdateDeleteUserSessionXml(UserSession userSession, string MACAddress, string Process);
        //IList<UserSession> GetUserSessionFromXml(string UserName);
       // IList<UserSession> GetUserSessionFromXmlBySessionID(string SessionId);
    }
    public partial class UserSessionManager : ManagerBase<UserSession, string>, IUserSessionManager
    {
        //int iCount = 0;

        #region Constructors

        public UserSessionManager()
            : base()
        {

        }
        public UserSessionManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

        //public int InsertUserSession(UserSession userSession, string MACAddress)
        //{
        //    IList<UserSession> userSessionList = null;
        //    userSessionList = new List<UserSession>();
        //    userSessionList.Add(userSession);

        //    SaveUpdateDeleteWithTransaction(ref userSessionList, null, null,MACAddress);
        //    return 0;
        //}

        //public void DeleteUserSessionUsingUserSessionIED(string userName)
        //{

        //    //IQuery query = session.GetISession().GetNamedQuery("Delete.UserSession");
        //    //query.SetString(0, userName);

        //    //query.ExecuteUpdate();

        //    //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //ICriteria criteria = iMySession.CreateCriteria(typeof(UserSession)).Add(Expression.Like("User_Name", userName));
        //        ArrayList arList = new ArrayList();
        //        //listUser = criteria.List<UserSession>();
        //        IQuery query = iMySession.GetNamedQuery("Get.User.Sessions").SetString(0, Convert.ToString(userName));
        //        arList = new ArrayList(query.List());
        //        IList<UserSession> listUser = new List<UserSession>();
        //        for (int i = 0; i < arList.Count; i++)
        //        {
        //            object[] ob = (object[])arList[i];
        //            UserSession lstModObj = new UserSession();
        //            lstModObj.Id = ob[0].ToString();
        //            lstModObj.User_Name = ob[0].ToString();
        //            lstModObj.Last_Logged_Time = Convert.ToDateTime(ob[1].ToString().Trim());
        //            lstModObj.MacAddress = ob[2].ToString();
        //            lstModObj.Version = Convert.ToInt32(ob[3].ToString());
        //            lstModObj.Current_Session_ID = ob[4].ToString();
        //            listUser.Add(lstModObj);
        //        }
        //        if (listUser != null && listUser.Count > 0)
        //        {
        //            IList<UserSession> listUser1 = null;
        //            SaveUpdateDeleteWithTransaction(ref listUser1, null, listUser, listUser[0].MacAddress);
        //        }
        //        iMySession.Close();
        //    }
        //}

        //public IList<UserSession> GetAllUsersInSession()
        //{

        //    IList<UserSession> IUserSessionList = new List<UserSession>();

        //    //IQuery query1 = session.GetISession().GetNamedQuery("Session.GetAllUserSessions");
        //    //ArrayList listArray = new ArrayList(query1.List());
        //    //UserSession tab;
        //    //if (listArray.Count > 0)
        //    //{
        //    //    foreach (object[] obj in listArray)
        //    //    {
        //    //        tab = new UserSession();
        //    //        tab.User_Name = obj[0].ToString();
        //    //        tab.Last_Logged_Time = Convert.ToDateTime(obj[1].ToString());
        //    //        list.Add(tab);
        //    //    }
        //    //}

        //    //return list;

        //    IUserSessionList = GetAll();
        //    //ICriteria criteria = session.GetISession().CreateCriteria(typeof(UserSession));
        //    return IUserSessionList;

        //}

        //public void UpdateUserSession(UserSession userSession, string userName, string MACAddress)
        //{
        //    IList<UserSession> userSessionList = null;
        //    userSessionList = new List<UserSession>();
        //    userSessionList.Add(userSession);

        //    IList<UserSession> addList = null;

        //    SaveUpdateDeleteWithTransaction(ref addList, userSessionList, null,MACAddress);
        //}

        //public IList<UserSession> GetCurrentSessionByUserName(string sUserName)
        //{
        //    IList<UserSession> lstUser = new List<UserSession>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //ICriteria criteria = iMySession.CreateCriteria(typeof(UserSession)).Add(Expression.Like("User_Name", sUserName));
        //        //lstUser = criteria.List<UserSession>();
        //        //iMySession.Close();
        //        ArrayList arList = new ArrayList();
        //        //listUser = criteria.List<UserSession>();
        //        IQuery query = iMySession.GetNamedQuery("Get.User.Sessions").SetString(0, Convert.ToString(sUserName));
        //        arList = new ArrayList(query.List());
        //        for (int i = 0; i < arList.Count; i++)
        //        {
        //            object[] ob = (object[])arList[i];
        //            UserSession lstModObj = new UserSession();
        //            lstModObj.Id = ob[0].ToString();
        //            lstModObj.User_Name = ob[0].ToString();
        //            lstModObj.Last_Logged_Time = Convert.ToDateTime(ob[1].ToString().Trim());
        //            lstModObj.MacAddress = ob[2].ToString();
        //            lstModObj.Version = Convert.ToInt32(ob[3].ToString());
        //            lstModObj.Current_Session_ID = ob[4].ToString();
        //            lstUser.Add(lstModObj);
        //        }
        //        iMySession.Close();
        //    }
        //    return lstUser;
        //}

        //public void DeleteUserSessionAtSessionEnd(string sSessionID)
        //{
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        //ICriteria criteria = iMySession.CreateCriteria(typeof(UserSession)).Add(Expression.Like("Current_Session_ID", sSessionID));
        //        ArrayList arList = new ArrayList();
        //        IList<UserSession> listUser = new List<UserSession>();
        //        //listUser = criteria.List<UserSession>();
        //        IQuery query = iMySession.GetNamedQuery("Get.User.Sessions.By.Id").SetString(0, Convert.ToString(sSessionID));
        //        arList = new ArrayList(query.List());
        //        for (int i = 0; i < arList.Count; i++)
        //        {
        //            object[] ob = (object[])arList[i];
        //            UserSession lstModObj = new UserSession();
        //            lstModObj.Id = ob[0].ToString();
        //            lstModObj.User_Name = ob[0].ToString();
        //            lstModObj.Last_Logged_Time = Convert.ToDateTime(ob[1].ToString().Trim());
        //            lstModObj.MacAddress = ob[2].ToString();
        //            lstModObj.Version = Convert.ToInt32(ob[3].ToString());
        //            lstModObj.Current_Session_ID = ob[4].ToString();
        //            listUser.Add(lstModObj);
        //        }
        //        if (listUser != null && listUser.Count > 0)
        //        {
        //            IList<UserSession> listUser1 = null;
        //            SaveUpdateDeleteWithTransaction(ref listUser1, null, listUser, listUser[0].MacAddress);
        //        }
        //        iMySession.Close();
        //    }
        //}

        /**Managing UserSession from Xml**/

        //public void InsertUpdateDeleteUserSessionXml(UserSession userSession, string MACAddress,string Process)
        //{
        //    UserSession objUSerSession = null;
        //    IEnumerable<PropertyInfo> propInfo = null;
        //    object obj = null;
        //    string strPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\UserSession_XML.xml");       
        //    if (File.Exists(strPath))
        //    {
        //        try
        //        {
        //            XmlDocument itemDoc = new XmlDocument();
        //            XmlTextReader XmlText = new XmlTextReader(strPath);
        //            itemDoc.Load(XmlText);
        //            XmlText.Close();
        //            XmlNodeList xmlNodeList = itemDoc.GetElementsByTagName(userSession.User_Name.ToUpper());
        //            XmlNodeList xmlSectionList = null;
        //            if (xmlNodeList.Count > 0)
        //            {
        //                if (Process == "UPDATE")
        //                {
        //                    if (xmlNodeList[0].Attributes.Count > 0)
        //                    {
        //                        for (int l = 0; l < xmlNodeList[0].Attributes.Count; l++)
        //                        {
        //                            if (xmlNodeList[0].Attributes[l].Name == "MacAddress")
        //                                xmlNodeList[0].Attributes[l].Value = userSession.MacAddress;
        //                            if (xmlNodeList[0].Attributes[l].Name == "Last_Logged_Time")
        //                                xmlNodeList[0].Attributes[l].Value = userSession.Last_Logged_Time.ToString();
        //                            if (xmlNodeList[0].Attributes[l].Name == "Version")
        //                                xmlNodeList[0].Attributes[l].Value = (userSession.Version + 1).ToString();
        //                            if (xmlNodeList[0].Attributes[l].Name == "Current_Session_ID")
        //                                xmlNodeList[0].Attributes[l].Value = userSession.Current_Session_ID;
        //                        }

        //                    }
        //                }
        //                else if (Process == "DELETE")
        //                {
        //                    if (xmlNodeList[0].Attributes.Count > 0)
        //                    {
        //                        xmlNodeList[0].ParentNode.RemoveChild(xmlNodeList[0]);
        //                    }
        //                }
        //                itemDoc.Save(strPath);

        //            }
        //            else if (Process == "INSERT")
        //            {
        //                XmlNode Newnode = null;
        //                Newnode = itemDoc.CreateNode(XmlNodeType.Element, userSession.User_Name.ToUpper(), "");
        //                objUSerSession = (UserSession)userSession;
        //                propInfo = from obji in (objUSerSession).GetType().GetProperties() select obji;
        //                XmlAttribute attlabel = null;
        //                foreach (PropertyInfo property in propInfo)
        //                {
        //                    if (property.Name != "Id" && property.Name != "User_Name")
        //                    {

        //                        attlabel = itemDoc.CreateAttribute(property.Name);

        //                        if (property.Name == "MacAddress")
        //                            attlabel.Value = objUSerSession.MacAddress;
        //                        if (property.Name == "Last_Logged_Time")
        //                            attlabel.Value = objUSerSession.Last_Logged_Time.ToString();
        //                        if (property.Name == "Version")
        //                            attlabel.Value = objUSerSession.Version.ToString();
        //                        if (property.Name == "Current_Session_ID")
        //                            attlabel.Value = objUSerSession.Current_Session_ID;
        //                        Newnode.Attributes.Append(attlabel);

        //                    }
        //                }

        //                xmlSectionList = itemDoc.GetElementsByTagName("UserSession");
        //                xmlSectionList[0].AppendChild(Newnode);
        //                itemDoc.Save(strPath);
        //            }
               
        //        }
        //        catch (Exception ex)
        //        {
        //            iCount = iCount + 1;
        //            if (iCount <= 8)
        //            {
        //                InsertUpdateDeleteUserSessionXml(userSession, MACAddress, Process);
        //            }
        //        }
        //    }
        //}

        

        //public IList<UserSession> GetUserSessionFromXml(string UserName)
        //{
        //    IList<UserSession> UserSessionList = new List<UserSession>();
        //    string strXmlFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\UserSession_XML.xml"); 
        //    if (File.Exists(strXmlFilePath) == true)
        //    {
        //        try
        //        {
        //        XmlDocument itemDoc = new XmlDocument();
        //            XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
        //            itemDoc.Load(XmlText);
        //            XmlText.Close();
        //            XmlNodeList xmlTagName;

        //            xmlTagName = itemDoc.GetElementsByTagName(UserName.ToUpper().ToString());

        //            if (xmlTagName.Count > 0)
        //            {
        //                for (int j = 0; j < xmlTagName.Count; j++)
        //                {
        //                    string TagName = xmlTagName[j].Name;
        //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(UserSession));
        //                    UserSession objUserSession = new UserSession();
        //                    //xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as UserSession;
        //                    IEnumerable<PropertyInfo> propInfo = null;
        //                    if (objUserSession != null)
        //                        objUserSession = (UserSession)objUserSession;
        //                    propInfo = from obji in ((UserSession)objUserSession).GetType().GetProperties() select obji;

        //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
        //                    {
        //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
        //                        {
        //                            foreach (PropertyInfo property in propInfo)
        //                            {
        //                                if (property.Name == nodevalue.Name)
        //                                {
        //                                    if (property.PropertyType.Name.ToUpper() == "UINT64")
        //                                        property.SetValue(objUserSession, Convert.ToUInt64(nodevalue.Value), null);
        //                                    else if (property.PropertyType.Name.ToUpper() == "STRING")
        //                                        property.SetValue(objUserSession, Convert.ToString(nodevalue.Value), null);
        //                                    else if (property.PropertyType.Name.ToUpper() == "DATETIME")
        //                                        property.SetValue(objUserSession, Convert.ToDateTime(nodevalue.Value), null);
        //                                    else if (property.PropertyType.Name.ToUpper() == "INT32")
        //                                        property.SetValue(objUserSession, Convert.ToInt32(nodevalue.Value), null);
        //                                    else if (property.PropertyType.Name.ToUpper() == "BOOLEAN")
        //                                        property.SetValue(objUserSession, Convert.ToBoolean(nodevalue.Value), null);
        //                                    else
        //                                        property.SetValue(objUserSession, nodevalue.Value, null);
        //                                }
        //                            }
        //                        }

        //                    }
        //                    UserSessionList.Add(objUserSession);
        //                }
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            iCount = iCount + 1;
        //            if (iCount<=8)
        //            {
        //                GetUserSessionFromXml(UserName);
        //            }
        //        }
        //    }
        //    return UserSessionList;
        //}
        //public IList<UserSession> GetUserSessionFromXmlBySessionID(string SessionId)
        //{
        //    IList<UserSession> UserSessionList = new List<UserSession>();
        //    string strXmlFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\UserSession_XML.xml");
        //    if (File.Exists(strXmlFilePath) == true)
        //    {
        //        XmlDocument itemDoc = new XmlDocument();
        //        XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
        //        itemDoc.Load(XmlText);
        //        XmlText.Close();
        //        XmlNodeList xmlTagName;
        //        string UserName = string.Empty;
            
        //            XmlNodeList xmlNodeList = itemDoc.GetElementsByTagName("UserSession");
        //            if (xmlNodeList.Count > 0)
        //            {
        //                for (int j = 0; j < xmlNodeList[0].ChildNodes.Count; j++)
        //                {
        //                    if (xmlNodeList[0].ChildNodes[j].Attributes[3].Value == SessionId)
        //                    {
        //                        UserName = xmlNodeList[0].ChildNodes[j].Name;
        //                    }
        //                }
        //            }
                
        //        xmlTagName = itemDoc.GetElementsByTagName(UserName.ToUpper().ToString());

        //        if (xmlTagName.Count > 0)
        //        {
        //            for (int j = 0; j < xmlTagName.Count; j++)
        //            {
        //                string TagName = xmlTagName[j].Name;
        //                XmlSerializer xmlserializer = new XmlSerializer(typeof(UserSession));
        //                UserSession objUserSession = new UserSession();
        //                //xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as UserSession;
        //                IEnumerable<PropertyInfo> propInfo = null;
        //                objUserSession = (UserSession)objUserSession;
        //                propInfo = from obji in ((UserSession)objUserSession).GetType().GetProperties() select obji;

        //                for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
        //                {
        //                    XmlNode nodevalue = xmlTagName[j].Attributes[i];
        //                    {
        //                        foreach (PropertyInfo property in propInfo)
        //                        {
        //                            if (property.Name == nodevalue.Name)
        //                            {
        //                                if (property.PropertyType.Name.ToUpper() == "UINT64")
        //                                    property.SetValue(objUserSession, Convert.ToUInt64(nodevalue.Value), null);
        //                                else if (property.PropertyType.Name.ToUpper() == "STRING")
        //                                    property.SetValue(objUserSession, Convert.ToString(nodevalue.Value), null);
        //                                else if (property.PropertyType.Name.ToUpper() == "DATETIME")
        //                                    property.SetValue(objUserSession, Convert.ToDateTime(nodevalue.Value), null);
        //                                else if (property.PropertyType.Name.ToUpper() == "INT32")
        //                                    property.SetValue(objUserSession, Convert.ToInt32(nodevalue.Value), null);
        //                                else if (property.PropertyType.Name.ToUpper() == "BOOLEAN")
        //                                    property.SetValue(objUserSession, Convert.ToBoolean(nodevalue.Value), null);
        //                                else
        //                                    property.SetValue(objUserSession, nodevalue.Value, null);
        //                            }
        //                        }
        //                    }

        //                }
        //                UserSessionList.Add(objUserSession);
        //            }
        //        }
        //    }
        //    return UserSessionList;
        //}


        //public void DeleteUserSessionFromXml(string CurrentSessionId)
        //{
        //     IList<UserSession> UserSessionList = new List<UserSession>();
        //     string strXmlFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\UserSession_XML.xml");   
        //    if (File.Exists(strXmlFilePath) == true)
        //    {
        //        XmlDocument itemDoc = new XmlDocument();
        //        XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
        //        itemDoc.Load(XmlText);
        //        XmlText.Close();
        //        XmlNodeList xmlNodeList = itemDoc.GetElementsByTagName("UserSession");                
        //        if(xmlNodeList.Count > 0 )
        //        {
        //            for (int j = 0; j < xmlNodeList[0].ChildNodes.Count; j++)
        //            {
        //                if (xmlNodeList[0].ChildNodes[j].Attributes[3].Value == CurrentSessionId)
        //                {
        //                    xmlNodeList[0].RemoveChild(xmlNodeList[0].ChildNodes[j]);
        //                    itemDoc.Save(strXmlFilePath);
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
