using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using Telerik.Web.Design;
using Telerik.Web.UI;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;


namespace Acurus.Capella.UI
{
    public partial class frmManageCDSS : System.Web.UI.Page
    {

        //StaticLookupManager objStaticLookupManager = new StaticLookupManager();
        CDSRuleMasterManager objCDSRuleMaster = new CDSRuleMasterManager();
        UserLookupManager objUserLookupManager = new UserLookupManager();
        IList<StaticLookup> stFieldLook = new List<StaticLookup>();
        PhysicianManager objPhysicianManager = new PhysicianManager();
        UserManager objUserManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cboValue = string.Empty;
                IList<User> lstUser = new List<User>();
                XmlDocument xmldocUser = new XmlDocument();
                string strXmlFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\User.xml");
                if (File.Exists(strXmlFilePath) == true)
                {
                    xmldocUser.Load(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "ConfigXML\\" + "User" + ".xml");
                    XmlNodeList xmlUserList = xmldocUser.GetElementsByTagName("User");
                    if (xmlUserList.Count > 0)
                    {
                        foreach (XmlNode item in xmlUserList)
                        {
                            XmlSerializer xmlserializer = new XmlSerializer(typeof(User));
                            User UserList = xmlserializer.Deserialize(new XmlNodeReader(item)) as User;
                            IEnumerable<PropertyInfo> propInfo = null;
                            if (UserList != null)
                            {
                                propInfo = from obji in ((User)UserList).GetType().GetProperties() select obji;

                                for (int i = 0; i < item.Attributes.Count; i++)
                                {
                                    XmlNode nodevalue = item.Attributes[i];
                                    {
                                        foreach (PropertyInfo property in propInfo)
                                        {
                                            if (property.Name.ToLower() == nodevalue.Name.ToLower())
                                            {
                                                if (property.PropertyType.Name.ToUpper() == "UINT64")
                                                    property.SetValue(UserList, Convert.ToUInt64(nodevalue.Value), null);
                                                else if (property.PropertyType.Name.ToUpper() == "STRING")
                                                    property.SetValue(UserList, Convert.ToString(nodevalue.Value), null);
                                                else if (property.PropertyType.Name.ToUpper() == "DATETIME")
                                                    property.SetValue(UserList, Convert.ToDateTime(nodevalue.Value), null);
                                                else if (property.PropertyType.Name.ToUpper() == "INT32")
                                                    property.SetValue(UserList, Convert.ToInt32(nodevalue.Value), null);
                                                else
                                                    property.SetValue(UserList, nodevalue.Value, null);
                                            }
                                        }
                                    }
                                }
                                lstUser.Add(UserList);
                            }
                        }
                    }
                }
                IList<User> cboLst = null;
                if (lstUser == null || lstUser.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SavedSuccessfully", "DisplayErrorMessage('1007012');", true);
                    divLoading.Style.Add("display", "none");
                    btnAdd.Disabled = true;
                }
                else
                {
                    cboLst = lstUser.Where(a => a.role.Trim() == "Medical Assistant" || a.role.Trim() == "Physician Assistant" || a.role.Trim() == "Physician" || a.role.Trim() == "Coder" || a.role.Trim() == "Front Office").ToList<User>();
                    if (cboLst != null && cboLst.Count > 0)
                    {
                        cboPhysicianName.Items.Add(new RadComboBoxItem(""));
                        foreach (var item in cboLst)
                        {
                            if (item.person_name.Trim() != string.Empty)
                                cboPhysicianName.Items.Add(new RadComboBoxItem(item.user_name + " - " + item.person_name));
                            else
                                cboPhysicianName.Items.Add(new RadComboBoxItem(item.user_name));
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SavedSuccessfully", "DisplayErrorMessage('1007012');", true);
                        divLoading.Style.Add("display", "none");
                        btnAdd.Disabled = true;
                    }

                    if (ClientSession.UserRole != null && ClientSession.UserRole.Trim().ToUpper() == "OFFICE MANAGER")
                    {
                        cboPhysicianName.Enabled = true;
                    }
                    else
                    {
                        if (ClientSession.UserName != null)
                        {
                            var s = cboPhysicianName.Items.Select((v, i) => new { value = v, Index = i }).Where(a => a.value.Text.Split('-')[0].ToUpper().Trim() == ClientSession.UserName.Trim().ToUpper()).ToList().First();
                            cboPhysicianName.SelectedIndex = s.Index;
                            cboPhysicianName.Enabled = false;
                        }
                    }
                    LoadValues();
                }
                if (hdnMessageType.Value == "Cancel")
                {
                    btnAdd.Disabled = false;
                    hdnMessageType.Value = string.Empty;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string YesNoCancel = hdnMessageType.Value;
            hdnMessageType.Value = string.Empty;
            if (cboPhysicianName.Items.Count > 0 && cboPhysicianName.SelectedItem.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SavedSuccessfully", "StopLoadingImage();DisplayErrorMessage('1007003');", true);
                divLoading.Style.Add("display", "none");
                return;
            }
            SaveUpdateDeleteManage();
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SavedSuccessfully", "StopLoadingImage();DisplayErrorMessage('1007001');RefreshNotification('ALL');", true);
            divLoading.Style.Add("display", "none");
            ClientSession.NotificationUserLookup = null;
        }


        UserLookup GetObject(string value)
        {
            UserLookup objUserLookup = new UserLookup();
            objUserLookup.Field_Name = "MANAGE CCDS";
            if (cboPhysicianName.SelectedItem.Text != null)
            {
                objUserLookup.User_Name = cboPhysicianName.SelectedItem.Text.Split('-')[0].Trim().ToUpper();
            }
            objUserLookup.Value = value;
            objUserLookup.Created_By = ClientSession.UserName.Trim();
            objUserLookup.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
            objUserLookup.Physician_ID = ClientSession.PhysicianId;
            return objUserLookup;
        }

        void SaveUpdateDeleteManage()
        {

            IList<UserLookup> SaveUserLookup = new List<UserLookup>();
            IList<UserLookup> UpdateUserLookup = new List<UserLookup>();
            IList<UserLookup> DeleteUserLookup = new List<UserLookup>();
            if (ViewState["UserLookupList"] != null)
            {
                IList<UserLookup> objList = (IList<UserLookup>)ViewState["UserLookupList"];
                for (int i = 0; i < chklstFrequentlyUsedProcedures.Items.Count; i++)
                {
                    if (objList.Any(a => a.Value.Trim() == chklstFrequentlyUsedProcedures.Items[i].Text.Split('-')[0].Trim().Replace("<b>", "").Replace("</b>", "")))
                    {
                        if (chklstFrequentlyUsedProcedures.Items[i].Selected)
                        {
                            UserLookup objlst = objList.Where(a => a.Value.Trim() == chklstFrequentlyUsedProcedures.Items[i].Text.Split('-')[0].Trim().Replace("<b>", "").Replace("</b>", "")).ToList<UserLookup>()[0];
                            objlst.Modified_By = ClientSession.UserName;
                            objlst.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                            UpdateUserLookup.Add(objlst);
                        }
                        else
                            DeleteUserLookup.Add(objList.Where(a => a.Value.Trim() == chklstFrequentlyUsedProcedures.Items[i].Text.Split('-')[0].Trim().Replace("<b>", "").Replace("</b>", "")).ToList<UserLookup>()[0]);
                    }
                    else
                    {
                        if (chklstFrequentlyUsedProcedures.Items[i].Selected)
                        {
                            UserLookup objUserLookup = GetObject(chklstFrequentlyUsedProcedures.Items[i].Text.Split('-')[0].Trim().Replace("<b>", "").Replace("</b>", ""));
                            SaveUserLookup.Add(objUserLookup);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < chklstFrequentlyUsedProcedures.Items.Count; i++)
                {
                    if (chklstFrequentlyUsedProcedures.Items[i].Selected)
                    {
                        UserLookup objUserLookup = GetObject(chklstFrequentlyUsedProcedures.Items[i].Text.Split('-')[0].Trim().Replace("<b>","").Replace("</b>",""));
                        SaveUserLookup.Add(objUserLookup);
                    }
                }
            }
            ViewState["UserLookupList"] = objUserLookupManager.SaveUpdateDeleteManageCDSS(SaveUserLookup, UpdateUserLookup, DeleteUserLookup, cboPhysicianName.SelectedItem.Text.Split('-')[0].Trim().ToUpper(), "MANAGE CCDS");

            if (ViewState["UserLookupList"] != null && ((IList<UserLookup>)ViewState["UserLookupList"]).Count > 0)
                btnAdd.Value = "Update";
            else
                btnAdd.Value = "Save";

            btnAdd.Disabled = true;
        }

        protected void cboPhysicianName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "StartLoad", "StartLoadingImage();", true);
            LoadValues();
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "StopLoad", "StopLoadingImage();", true);
        }

        void LoadValues()
        {
            IList<UserLookup> lstUserLookup = null;
            ViewState["UserLookupList"] = objUserLookupManager.GetFieldLookupList(cboPhysicianName.SelectedItem.Text.Split('-')[0].Trim().ToUpper(), "MANAGE CCDS");

            if (ViewState["UserLookupList"] != null)
            {
                lstUserLookup = (IList<UserLookup>)ViewState["UserLookupList"];
            }

            //ViewState["FieldLookupList"] = objStaticLookupManager.getStaticLookupByFieldName("MANAGE CCDS").ToArray();
            // IList<FieldLookup> lstFieldLookup = (IList<FieldLookup>)ViewState["FieldLookupList"];
            //code modified by balaji
            ViewState["CDSRuleMasterLookupList"] = objCDSRuleMaster.getCDSRuleMasterByFieldName().ToArray();
            IList<CDSRuleMaster> CDSRuleLookup = (IList<CDSRuleMaster>)ViewState["CDSRuleMasterLookupList"];
            if (CDSRuleLookup == null || CDSRuleLookup.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SavedSuccessfully", "DisplayErrorMessage('1007013');", true);
                divLoading.Style.Add("display", "none");
                btnAdd.Disabled = true;
            }
            else
            {
                chklstFrequentlyUsedProcedures.Items.Clear();
                for (int i = 0; i < CDSRuleLookup.Count; i++)
                {
                    ListItem obj = new ListItem();
                    obj.Text = "<b>" + CDSRuleLookup[i].Clinincal_Decision_Name + "</b>" + " - " + CDSRuleLookup[i].Rules_Description;
                    if (lstUserLookup != null && lstUserLookup.Count > 0 && lstUserLookup.Any(a => a.Value.Trim() == CDSRuleLookup[i].Clinincal_Decision_Name.Trim()))
                        obj.Selected = true;
                    else
                        obj.Selected = false;

                    chklstFrequentlyUsedProcedures.Items.Add(obj);
                }
            }
            //else
            //{
            //    chklstFrequentlyUsedProcedures.Items.Clear();
            //    for (int i = 0; i < lstFieldLookup.Count; i++)
            //    {
            //        ListItem obj = new ListItem();
            //        //obj.Text = lstFieldLookup[i].Value.ToUpper()+" -" + lstFieldLookup[i].Description;
            //        //obj.Text = "<span style=font-weight:bold;>" + lstFieldLookup[i].Value + "</span>" + " - " + lstFieldLookup[i].Description;
            //        obj.Text = "<b>" + lstFieldLookup[i].Value + "</b>" + " - " + lstFieldLookup[i].Description;
            //        if (lstUserLookup != null && lstUserLookup.Count > 0 && lstUserLookup.Any(a => a.Value.Trim() == lstFieldLookup[i].Value.Trim()))
            //            obj.Selected = true;
            //        else
            //            obj.Selected = false;

            //        chklstFrequentlyUsedProcedures.Items.Add(obj);
            //    }
            //}
            btnAdd.Value = lstUserLookup.Count > 0 ? "Update" : "Save";
            btnAdd.Disabled = true;
        }
    }
}
