using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Acurus.Capella.Core.DTO;
using System.Collections;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.DataAccess.ManagerObjects;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
//using Atalasoft.Imaging.WebControls.Annotations;
//using Atalasoft.Imaging.WebControls;


namespace Acurus.Capella.PatientPortal
{
    public class SecurityServiceUtility
    {

        #region Private Variables
        private ArrayList listMenus = new ArrayList();
        private ArrayList listAllowedControls = new ArrayList();
        private ArrayList listTabNames = new ArrayList();
        private ArrayList listGridButtons = new ArrayList();
        private string permission = string.Empty;
        private ArrayList listToolStrip = new ArrayList();
        private bool checkUser = false;
        private ArrayList listPictureBoxD = new ArrayList();
        private ArrayList listPictureBoxL = new ArrayList();
        private ArrayList listPictureBoxC = new ArrayList();
        private ArrayList listPictureBoxP = new ArrayList();
        private IList<ScnTab> MyScnTab;
        private IList<Element> MyElement;
        private IList<user_scn_tab> MyuserScnTab;

        private IList<ProcessScnTab> MYProcessScnTab;
        int ScreenId;
        string screenName;
        string sBACType;
        int iPBACCount = 0;
        int iRBACTotalCount = 0;

        string sUserCurrentProcess = string.Empty;
        ulong uAssignedPhysician_ID;
        ArrayList UserCurrentList = new ArrayList();
        string UserCurrentOwner = string.Empty;
        #endregion


        #region Methods
        //Vinoth Branch 18-Jun-2011
        //public static void minimizeMemory()
        //{
        //    GC.Collect(GC.MaxGeneration);
        //    GC.WaitForPendingFinalizers();
        //    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, (UIntPtr)0xFFFFFFFF, (UIntPtr)0xFFFFFFFF);
        //}
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, UIntPtr minimumWorkingSetSize, UIntPtr maximumWorkingSetSize);
        //Vinoth Branch 18-Jun-2011

        public void ApplyUserPermissions(Page form)
        {
            //minimizeMemory();
            ClientSession.UserPermission = string.Empty;
            ClientSession.CheckUser = true;

            IList<ScnTab> TempCheckScnTab = new List<ScnTab>();

            string sFormName = string.Empty;
            string screenName = string.Empty;

            if (form.Items["Title"] == null)
            {
                sFormName = form.AppRelativeVirtualPath;
                string[] formname = sFormName.Split('/');
                screenName = formname[1].Substring(0, formname[1].IndexOf('.'));
            }
            else
            {
                sFormName = form.Items["Title"].ToString();
                string[] formname = sFormName.Split('/');
                screenName = sFormName;// formname[1].Substring(0, formname[1].IndexOf('.'));
            }

            if (ClientSession.UserPermissionDTO == null)
            {
                return;
            }
            if (ClientSession.UserPermissionDTO.Scntab != null && ClientSession.UserPermissionDTO.Scntab.Count != 0)
            {
                var ScnTabCheck = from c in ClientSession.UserPermissionDTO.Scntab where c.SCN_Name.ToUpper() == screenName.ToUpper() select c;
                if (ScnTabCheck != null)
                {
                    TempCheckScnTab = ScnTabCheck.ToList<ScnTab>();
                    if (TempCheckScnTab.Count != 0)
                    {
                        sBACType = TempCheckScnTab[0].Is_UBAC_Or_PBAC;
                        ScreenId = TempCheckScnTab[0].SCN_ID;
                    }
                }
            }
            bool check = false;
            iPBACCount = 0;



            //if (sBACType == "RBAC")
            //{
            //    var Screen = from s in ClientSession.UserPermissionDTO.Rolescntab where s.Scn_ID == Convert.ToUInt64(ScreenId) select s;
            //    MyRoleScnTab = Screen.ToList<role_scn_tab>();
            //    var Elem = from e in ApplicationObject.elementList where e.SCN_ID == Convert.ToInt64(ScreenId) select e;
            //    MyElement = Elem.ToList<Element>();
            //    var RoleException = from e in ClientSession.UserPermissionDTO.RoleExceptionScnTab where e.Scn_ID == Convert.ToInt32(ScreenId) select e;

            //    check = true;
            //    if (MyRoleScnTab.Count != 0)
            //    {
            //        permission = MyRoleScnTab[0].Status;
            //    }
            //    ClientSession.UserPermission = permission;

            //    int iRBACExceptionCount = 0;

            //    if (RoleException.ToList<RoleExceptionScnTab>().Count > 0)
            //    {
            //        iRBACExceptionCount = RoleException.ToList<RoleExceptionScnTab>().Count;
            //    }
            //    iRBACTotalCount = MyRoleScnTab.Count + iRBACExceptionCount;


            //}
            if (sBACType == "UBAC")
            {

                var Screen = from s in ClientSession.UserPermissionDTO.Scntab where s.SCN_Name.ToUpper() == screenName.ToUpper() select s;
                MyScnTab = Screen.ToList<ScnTab>();
                if (MyScnTab.Count != 0)
                {
                    var MyuserScnTab = from c in ClientSession.UserPermissionDTO.Userscntab where c.scn_id == Convert.ToUInt64(MyScnTab[0].SCN_ID) select c;
                    var Elem = from e in ApplicationObject.elementList where e.SCN_ID == ScreenId select e;
                    MyElement = Elem.ToList<Element>();

                    check = true;
                    if (MyuserScnTab.ToList<user_scn_tab>().Count > 0)
                    {
                        permission = MyuserScnTab.ToList<user_scn_tab>()[0].Permission;
                        ClientSession.UserPermission = permission;
                    }

                }
            }
            else if (sBACType == "PBAC")
            {
                ApplyPBACPermissions(form);

                var Screen = from s in ClientSession.UserPermissionDTO.ProcessScnTabList where Convert.ToUInt64(s.Scn_ID) == Convert.ToUInt64(ScreenId) select s;
                MYProcessScnTab = Screen.ToList<ProcessScnTab>();
                check = true;

                //var Elem = from e in ApplicationObject.elementList where e.SCN_ID == Convert.ToInt64(MYProcessScnTab[0].Scn_ID) select e;
                //MyElement = Elem.ToList<Element>();
                var process = from p in ClientSession.UserPermissionDTO.ProcessScnTabList where p.Process_Name == ClientSession.UserCurrentProcess && p.Scn_ID == ScreenId select p;
                // var Role = from r in ClientSession.UserPermissionDTO.Rolescntab where r.Role_Name == ClientSession.UserRole && r.Scn_ID == Convert.ToUInt64(ScreenId) select r;

                if (MYProcessScnTab.Count != 0)
                {
                    permission = MYProcessScnTab[0].Permission;
                    ClientSession.UserPermission = permission;

                    if (process.ToList<ProcessScnTab>().Count > 0)
                    {
                        iPBACCount = process.ToList<ProcessScnTab>().Count;

                    }
                }

            }

            if (check == true)
            {
                GetControlsToBeEnabled(ScreenId);
                if (form.Master != null)
                {
                    if (form.Master.AppRelativeVirtualPath.ToUpper().Contains("C5PO") == true)
                    {
                        GetControlsToBeEnabledInMasterPage(1000);
                    }
                }
                //commented by nijanthan 18-1-16 bug id 37251
                listTabNames = GetlistTabNames(screenName);
                List<Control> availControls = GetControls(form);
                if (sBACType == "PBAC")
                {
                    checkUser = checkPBACUserRole(ScreenId);
                    if (checkUser == false)
                    {
                        ClientSession.CheckUser = false;
                    }
                }

                if (checkUser == false)
                {
                    ClientSession.CheckUser = false;
                }

                if (sBACType == "UBAC" && ClientSession.UserCurrentProcess != string.Empty && !checkProcessEncounter() && ClientSession.processCheck)
                {
                    ClientSession.processCheck = false;
                    permission = "R";
                    ClientSession.UserPermission = "R";
                    checkUser = false;
                    ClientSession.CheckUser = false;
                }
                if (sBACType == "PBAC" && (iPBACCount == 0 || ClientSession.UserCurrentList.Contains(ClientSession.UserName) == false || ClientSession.UserCurrentOwner != ClientSession.UserName))
                {
                    ClientSession.processCheck = false;
                    permission = "R";
                    ClientSession.UserPermission = "R";
                    checkUser = false;
                    ClientSession.CheckUser = false;
                }
                //else if (sBACType == "RBAC" && iRBACTotalCount == 0)
                //{

                //    // ClientSession.UserRole= false;
                //    permission = "R";
                //    ClientSession.UserPermission = "R";
                //    checkUser = false;
                //    ClientSession.CheckUser = false;
                //}




                foreach (Control c in availControls)
                {

                    if (c is RadTextBox || c is RadListBox || c is GridView || c is RadComboBox || c is CheckBox || c is CheckBoxList || c is ListBox || c is ListView || c is RadDateTimePicker || c is RadDatePicker || c is RadioButton || c is RadNumericTextBox || c is TextBox || c is DropDownList || c is MKB.TimePicker.TimeSelector || c is HtmlSelect || c is HtmlInputText || c is RadAsyncUpload || c is RadMaskedTextBox || c is HtmlInputCheckBox || c is HtmlInputButton)

                    {
                        if (c.ID != null)
                        {
                            if (c.ID != string.Empty)
                            {
                                Control[] ctButton;
                                if (permission == "R")
                                {
                                    var webControl = c as WebControl;
                                    if (webControl != null)
                                        webControl.Enabled = false;
                                    else
                                    {
                                        var htmlControl = c as HtmlControl;
                                        htmlControl.Disabled = true;
                                    }
                                    if (c is MKB.TimePicker.TimeSelector)
                                    {
                                        MKB.TimePicker.TimeSelector dtptime = (MKB.TimePicker.TimeSelector)c;
                                        dtptime.ReadOnly = true;
                                    }

                                }
                                else
                                {
                                    var webControl = c as WebControl;
                                    if (webControl != null)
                                        webControl.Enabled = true;
                                    else
                                    {
                                        var htmlControl = c as HtmlControl;
                                        htmlControl.Disabled = false;
                                    }
                                    if (c is MKB.TimePicker.TimeSelector)
                                    {
                                        MKB.TimePicker.TimeSelector dtptime = (MKB.TimePicker.TimeSelector)c;
                                        dtptime.ReadOnly = false;
                                    }
                                }

                            }
                        }
                    }

                    else if (c is RadButton)
                    {
                        if (permission == "R")
                        {
                            if (c.ClientID != null)
                            {
                                if (c.ClientID.Contains("DLC") == true)
                                {
                                    var webControl = c as WebControl;
                                    webControl.Enabled = false;
                                }
                            }
                            bool result = listAllowedControls.Contains(c.ClientID);
                            if (result == true)
                            {
                                var webControl = c as WebControl;
                                webControl.Enabled = false;
                            }
                        }
                        else
                        {
                            //if (checkUser == false)
                            //{
                            bool result = listAllowedControls.Contains(c.ClientID);
                            if (result == true)
                            {
                                var webControl = c as WebControl;
                                webControl.Enabled = true;
                                //}
                            }
                        }

                    }
                    //else if (c is RadListBox)
                    //{
                    //    if (permission == "R")
                    //    {
                    //        if (c.ClientID != string.Empty)
                    //        {
                    //            if (c.ClientID.Contains("DLC") == true)
                    //            {
                    //                var webControl = c as WebControl;
                    //                webControl.Enabled = false;
                    //            }
                    //        }
                    //    }
                    //    bool result = listAllowedControls.Contains(c.ClientID);
                    //    if (result == true)
                    //    {
                    //        var webControl = c as WebControl;
                    //        webControl.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        if (checkUser == false)
                    //        {
                    //            var webControl = c as WebControl;
                    //            webControl.Enabled = true;
                    //        }

                    //    }

                    //}
                    else if (c is Button)
                    {
                        if (permission == "R")
                        {
                            bool result = listAllowedControls.Contains(c.ID);
                            if (result == true)
                            {

                                var webControl = (WebControl)c;
                                webControl.Enabled = false;
                            }

                        }
                        else
                        {
                            //if (checkUser == false)
                            //{
                            bool result = listAllowedControls.Contains(c.ID);
                            if (result == true)
                            {
                                var webControl = c as WebControl;
                                webControl.Enabled = true;
                                //}
                            }
                        }
                        //<<<<<<< SecurityServiceUtility.cs
                        //                        if (permission == "R")
                        //                        {
                        //                            if (c.ID.ToUpper() == "PBLIBRARY" || c.ID.ToUpper() == "PBDROPDOWN" || c.ID.ToUpper() == "PBCLEAR")
                        //                            {
                        //                                var webControl = c as WebControl;
                        //                                webControl.Enabled = false;
                        //                            }
                        //                        }
                        //                        else
                        //                        {

                        //                            if (c.ID.ToUpper() == "PBLIBRARY")
                        //                            {
                        //                                if (ClientSession.UserRole == "Medical Assistant" || ClientSession.UserRole == "Coder" || ClientSession.UserRole == "Office Manager" || ClientSession.UserRole == "Front Office")
                        //                                {

                        //                                    var webControl = c as WebControl;
                        //                                    webControl.Enabled = false;
                        //                                }
                        //                            }

                        //                        }
                        //=======
                        if (permission == "R")
                        {
                            if (c.ID != null)
                            {
                                if (c.ID.ToUpper() == "PBLIBRARY" || c.ID.ToUpper() == "PBDROPDOWN" || c.ID.ToUpper() == "PBCLEAR")
                                {
                                    var webControl = c as WebControl;
                                    webControl.Enabled = false;
                                }
                            }
                        }
                        else
                        {

                            if (c.ID != null && c.ID.ToUpper() == "PBLIBRARY")
                            {
                                if (ClientSession.UserRole == "Medical Assistant" || ClientSession.UserRole == "Coder" || ClientSession.UserRole == "Office Manager" || ClientSession.UserRole == "Front Office")
                                {

                                    var webControl = c as WebControl;
                                    webControl.Enabled = false;
                                }
                            }

                        }
                        //>>>>>>> 1.30.4.5

                    }

                    else if (c is TextBox)
                    {
                        if (permission == "R")
                        {
                            bool result = listAllowedControls.Contains(c.ID);
                            if (result == true)
                            {
                                var webControl = c as WebControl;
                                webControl.Enabled = false;
                            }
                        }
                        else
                        {
                            //if (checkUser == false)
                            //{
                            bool result = listAllowedControls.Contains(c.ID);
                            if (result == true)
                            {
                                var webControl = c as WebControl;
                                webControl.Enabled = true;
                                //}
                            }
                        }

                    }
                    else if (c is GridView)
                    {
                        if (permission == "R")
                        {
                            if (c.ClientID != string.Empty)
                            {

                                var webControl = c as WebControl;
                                webControl.Enabled = false;
                                if (checkUser == false)
                                {
                                    if (listGridButtons.Count > 0)
                                    {
                                        for (int i = 0; i < listGridButtons.Count; i++)
                                        {
                                            
                                            string[] grid = listGridButtons[i].ToString().Split('.');
                                            if (grid.Length == 2)
                                            {
                                                if (grid[0] == c.ClientID)
                                                {
                                                    for (int j = 0; j < ((GridView)webControl).Columns.Count; j++)
                                                    {
                                                        if (((GridView)webControl).Columns[j].HeaderText == grid[1])
                                                        {
                                                            ((GridView)webControl).Columns[j].Visible = false;


                                                        }
                                                    }

                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }


                    }

                    else if (c is RadTabStrip)
                    {


                        if (listTabNames.Count > 0)
                        {
                            Control ctt = c;
                            //ctt = form.FindControl(c.ID);

                            if (ctt != null)
                            {
                                for (int k = 0; k < ((RadTabStrip)ctt).Tabs.Count; k++)
                                {
                                    if (((RadTabStrip)ctt).Tabs[k].Attributes["labelname"] != null)
                                    {
                                        string s = c.ID + "." + ((RadTabStrip)ctt).Tabs[k].Attributes["labelname"].ToString();
                                        bool result = listTabNames.Contains(s);
                                        if (result == true)
                                        {
                                            ((RadTabStrip)ctt).Tabs[k].Enabled = true;
                                        }
                                        else
                                        {
                                            ((RadTabStrip)ctt).Tabs[k].Enabled = false;
                                        }
                                    }

                                }
                            }
                        }

                    }

                     //else if (c is ToolStrip)
                    //{

                     //    if (listToolStrip.Count > 0)
                    //    {
                    //        Control[] ctt;
                    //        ctt = form.Controls.Find(c.Name, true);
                    //        for (int k = 0; k < ((ToolStrip)ctt[0]).Items.Count; k++)
                    //        {

                     //            string s = c.Name + "." + ((ToolStrip)ctt[0]).Items[k].Name.ToString();
                    //            bool result = listToolStrip.Contains(s);
                    //            if (result == true)
                    //            {
                    //                ((ToolStrip)ctt[0]).Items[k].Enabled = true;
                    //            }
                    //            else
                    //            {
                    //                ((ToolStrip)ctt[0]).Items[k].Enabled = false;
                    //            }
                    //        }
                    //    }


                     //}
                    else if (c is Panel)
                    {
                        HtmlGenericControl ct2, subct2, subct3, subct4;
                        if (c.ID == "pnlScroll")
                        {
                           // ct2 = form.Master.FindControl("mnuC5PO");
                            for (int i = 0; i < c.Controls.Count; i++)
                            {
                                if (c.Controls[i].GetType().Name == "HtmlGenericControl")
                                {
                                    ct2 = (System.Web.UI.HtmlControls.HtmlGenericControl)c.Controls[i];
                                    if (listMenus.Contains(ct2.ID))
                                    {
                                        ct2.Disabled = false;                                        
                                    }
                                    else
                                    {
                                        ct2.Disabled = true;
                                       // ct2.Style.Add("background-color", "#6D7777");
                                    }
                                    if(ct2.Controls.Count>0)
                                    {
                                        for (int j = 0; j < ct2.Controls.Count; j++)
                                        {
                                            if (ct2.Controls[j].GetType().Name == "HtmlGenericControl")
                                            {
                                                subct2 = (System.Web.UI.HtmlControls.HtmlGenericControl)ct2.Controls[j];
                                                if (listMenus.Contains(subct2.ID))
                                                {
                                                    subct2.Disabled = false;

                                                }
                                                else
                                                {
                                                    subct2.Disabled = true;
                                                   

                                                }
                                                if (subct2.Controls.Count > 0)
                                                {
                                                    for (int k = 0; k < subct2.Controls.Count; k++)
                                                    {
                                                        if (subct2.Controls[k].GetType().Name == "HtmlGenericControl")
                                                        {
                                                            subct3 = (System.Web.UI.HtmlControls.HtmlGenericControl)subct2.Controls[k];
                                                            if (listMenus.Contains(subct3.ID))
                                                            {
                                                                subct3.Disabled = false;

                                                            }
                                                            else
                                                            {
                                                                subct3.Disabled = true;
                                                               

                                                            }
                                                            if (subct3.Controls.Count > 0)
                                                            {
                                                                for (int l = 0; l < subct3.Controls.Count; l++)
                                                                {
                                                                    if (subct3.Controls[l].GetType().Name == "HtmlGenericControl")
                                                                    {
                                                                        subct4 = (System.Web.UI.HtmlControls.HtmlGenericControl)subct2.Controls[k];
                                                                        if (listMenus.Contains(subct3.ID))
                                                                        {
                                                                            subct4.Disabled = false;

                                                                        }
                                                                        else
                                                                        {
                                                                            subct4.Disabled = true;


                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        if (c.ID == "pnlEncScroll")
                        {
                            for (int i = 0; i < c.Controls.Count; i++)
                            {
                                if (c.Controls[i].GetType().Name == "HtmlGenericControl")
                                {
                                    ct2 = (System.Web.UI.HtmlControls.HtmlGenericControl)c.Controls[i];
                                    if (listTabNames.Contains(ct2.ID))
                                    {
                                        ct2.Disabled = false;
                                    }
                                    else
                                    {
                                        ct2.Disabled = true;
                                        // ct2.Style.Add("background-color", "#6D7777");
                                    }
                                }
                            }
                        }
                        //foreach (RadMenuItem mainMenu in ((RadMenu)ct2).Items)
                        //{
                        //    bool firstMenuCheck = listMenus.Contains(mainMenu.Value);
                        //    if (firstMenuCheck == true)
                        //    {
                        //        mainMenu.Enabled = true;
                        //        foreach (RadMenuItem subItem in mainMenu.Items)
                        //        {
                        //            bool secondMenuCheck = listMenus.Contains(mainMenu.Value + "." + subItem.Value);
                        //            if (secondMenuCheck == true)
                        //            {
                        //                subItem.Enabled = true;
                        //                foreach (RadMenuItem subsubItem in subItem.Items)
                        //                {
                        //                    bool thirdMenuCheck = listMenus.Contains(mainMenu.Value + "." + subItem.Value + "." + subsubItem.Value);
                        //                    if (thirdMenuCheck == true)
                        //                    {
                        //                        subsubItem.Enabled = true;
                        //                        foreach (RadMenuItem subsubsubItem in subsubItem.Items)
                        //                        {
                        //                            bool fourthMenuCheck = listMenus.Contains(mainMenu.Value + "." + subItem.Value + "." + subsubItem.Value + "." + subsubsubItem.Value);
                        //                            if (fourthMenuCheck == true)
                        //                            {
                        //                                subsubsubItem.Enabled = true;
                        //                            }
                        //                            else
                        //                            {
                        //                                subsubsubItem.Enabled = false;
                        //                            }
                        //                        }
                        //                    }
                        //                    else
                        //                    {
                        //                        subsubItem.Enabled = false;
                        //                    }
                        //                }
                        //            }
                        //            else
                        //            {
                        //                subItem.Enabled = false;
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mainMenu.Enabled = false;
                        //    }
                        //}

                    }
                    else if (c is RadGrid)
                    {
                        if (permission == "R")
                        {
                            if (c.ClientID != string.Empty)
                            {

                                var webControl = c as WebControl;
                                //webControl.Enabled = false;  //for bug_id 26403
                                if (checkUser == false)
                                {
                                    if (listGridButtons.Count > 0)
                                    {
                                        for (int i = 0; i < listGridButtons.Count; i++)
                                        {
                                            string[] grid = listGridButtons[i].ToString().Split('.');
                                            if (grid.Length == 2)
                                            {
                                                if (grid[0] == c.ClientID)
                                                {
                                                    for (int j = 0; j < ((RadGrid)webControl).Columns.Count; j++)
                                                    {
                                                        if (((RadGrid)webControl).Columns[j].HeaderText == grid[1])
                                                        {
                                                            ((RadGrid)webControl).Columns[j].Visible = false;
                                                        }
                                                        //if (grid[0] == "grdSelectedAssessment")//commented by naveena for bug_id 26166 on 16.10.2014
                                                        //{
                                                        //    string sDLC = "Notes/Source          D            L            C ";
                                                        //    char[] ary = new char[] { ' ' };
                                                        //    sDLC = sDLC.Trim(ary);
                                                        //    if (((RadGrid)webControl).Columns[j].HeaderText.ToString().Contains(sDLC) == true)
                                                        //    {
                                                        //        ((RadGrid)webControl).Columns[j].Visible=false;                                                               
                                                        //    }
                                                        //}

                                                    }

                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }

                    }
                    else if (c is ImageButton)
                    {
                        if (checkUser == false)
                        {
                            if (c.Parent is PatientPortal.UserControls.CustomPhrases)
                            {
                                PatientPortal.UserControls.CustomPhrases cus = (PatientPortal.UserControls.CustomPhrases)c.Parent;

                                bool result = listPictureBoxP.Contains(cus.ClientID);
                                if (result == true)
                                {
                                    //commented by viji on 30/6/2014
                                    //cus.pbCustomPhrases.Enabled=false;
                                }
                            }

                            else
                            {
                                if (permission == "R")
                                {
                                    if (checkUser == false)
                                    {
                                        bool result2 = listPictureBoxC.Contains(c.ClientID);
                                        if (result2 == true)
                                        {
                                            var webControl = c as WebControl;
                                            ImageButton pb = (ImageButton)webControl;
                                            pb.ImageUrl = "~/Resources/close_disabled.png";
                                            webControl.Enabled = false;
                                        }
                                    }
                                }
                            }
                            if (permission == "R")
                            {
                                if (checkUser == false)
                                {
                                    bool result2 = listPictureBoxL.Contains(c.ClientID);
                                    if (result2 == true)
                                    {
                                        var webControl = c as WebControl;
                                        ImageButton pb = (ImageButton)webControl;
                                        pb.ImageUrl = "~/Resources/Database Disable.png";
                                        webControl.Enabled = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool result2 = listPictureBoxP.Contains(c.ClientID);
                            if (result2 == true)
                            {
                                //Control[] ctButton1;
                                //ctButton1 = form.Controls.Find(c.Name, true);
                                //PictureBox pb = (PictureBox)ctButton1[0];
                                var webControl = c as WebControl;
                                ImageButton pb = (ImageButton)webControl;
                                pb.ImageUrl = "~/Resources/Letter-P-blue-icon_16.png";
                                webControl.Enabled = true;
                            }
                        }




                    }
                    //Added by Srividhya on 25-Jun-2014
                    else if (c is HtmlAnchor)
                    {
                        if (checkUser == false)
                        {
                            if (c.Parent is PatientPortal.UserControls.CustomDLCNew)
                            {
                                PatientPortal.UserControls.CustomDLCNew cus = (PatientPortal.UserControls.CustomDLCNew)c.Parent;

                               

                               // bool result = 
                                //if (result == true)
                                //{

                                //}
                            }
                        }
                        else
                        {
                            //bool result = listPictureBoxL.Contains(c.ClientID.Replace("_pbLibrary", ""));
                            //if (result == true)
                            //{

                            //}
                        }

                        if (permission == "R")
                        {
                            //if (checkUser == false)
                            //{
                            //    if (c.Parent is UI.UserControls.CustomDLCNew)
                            //    {
                            //        UI.UserControls.CustomDLCNew cus = (UI.UserControls.CustomDLCNew)c.Parent;

                            //        bool result = listPictureBoxD.Contains(cus.LName);
                            //        if (result == true)
                            //        {
                            //           // ((HtmlAnchor)cus.Controls[3]).Attributes.Add("UBACDrop", "false");
                            //            cus.pbDropdown.Disabled = true;
                            //        }
                            //    }

                            //    if (c.Parent is UI.UserControls.CustomDLCNew)
                            //    {
                            //        UI.UserControls.CustomDLCNew cus = (UI.UserControls.CustomDLCNew)c.Parent;

                            //        bool result = listPictureBoxC.Contains(cus.LName);
                            //        if (result == true)
                            //        {
                                      
                            //        }
                            //    }

                            //    if (c.Parent is UI.UserControls.CustomDLCNew)
                            //    {
                            //        UI.UserControls.CustomDLCNew cus = (UI.UserControls.CustomDLCNew)c.Parent;

                            //        bool result = listPictureBoxP.Contains(cus.LName);
                            //        if (result == true)
                            //        {
                            //            ((HtmlAnchor)cus.Controls[3]).Attributes.Add("UBACCustomPhrase", "false");
                            //        }
                            //    }

                            //    ////Added by srividhya on 4-Jul-2014
                            //    //if (c.Parent is UI.UserControls.CustomDLCNew)
                            //    //{
                            //    //    UI.UserControls.CustomDLCNew cus = (UI.UserControls.CustomDLCNew)c.Parent;

                            //    //    bool result = listPictureBoxP.Contains(cus.PName);
                            //    //    if (result == true)
                            //    //    {
                            //    //       // ((HtmlAnchor)cus.Controls[9]).Attributes.Add("UBACCustomPhrase", "false");
                                      
                            //    //    }
                            //    //}
                            //}
                        }
                        else
                        {
                            //Newly Added by Selvaraman - 14 Dec - Start
                            bool result1 = listPictureBoxD.Contains(c.ClientID.Replace("_pbDropdown", ""));
                            if (result1 == true)
                            {
                                //HtmlAnchor pb = (HtmlAnchor)c;
                                //pb.Disabled = false;

                                HtmlAnchor htmlControl = (HtmlAnchor)c;
                                //htmlControl.Attributes.Add("UBAC", "false");

                                //htmlControl.Disabled = true;                                                        
                                //htmlControl.Attributes.Remove("disabled");                                                               
                            }

                            bool result2 = listPictureBoxC.Contains(c.ClientID.Replace("_pbClear", ""));
                            if (result2 == true)
                            {
                                //HtmlAnchor pb = (HtmlAnchor)c;
                                //pb.Disabled = false;
                                var htmlControl = c as HtmlControl;
                                htmlControl.Disabled = false;
                            }
                            bool result3 = listPictureBoxP.Contains(c.ClientID.Replace("_pbCustomPhrases", ""));
                            if (result3 == true)
                            {
                                //HtmlAnchor pb = (HtmlAnchor)c;
                                //pb.Disabled = false;
                                var htmlControl = c as HtmlControl;
                                htmlControl.Disabled = false;
                            }


                            //Newly Added by Selvaraman - 14 Dec - End

                            //if (checkUser == false)
                            //{
                            //    bool result = CheckControlExists(c.Name, "PictureBox");
                            //    if (result == true)
                            //    {
                            //        Control[] ctButton;
                            //        ctButton = form.Controls.Find(c.Name, true);
                            //        PictureBox pb = (PictureBox)ctButton[0];
                            //        pb.Image = global::Acurus.Capella.UI.Properties.Resources.Database_Disable;
                            //        ctButton[0].Enabled = false;
                            //    }
                            //}
                        }
                    }
                    else
                    {




                    }
                    //if (c is WebAnnotationViewer)
                    //{
                    //    if (permission == "R")
                    //    {
                    //            WebAnnotationViewer atalasoftControl = (WebAnnotationViewer)c;
                    //            atalasoftControl.InteractMode = Atalasoft.Imaging.WebControls.Annotations.WebAnnotationInteractMode.None;
                    //            atalasoftControl.Annotations.InteractMode = Atalasoft.Imaging.WebControls.Annotations.WebAnnotationInteractMode.None;
                    //    }
                    //}
                    if (c is ImageButton)
                    {
                        if (permission == "R")
                        {
                            ImageButton atalasoftToolsControl = (ImageButton)c;
                            atalasoftToolsControl.Enabled = false;

                        }
                    }

                }
                
            }
            else
            {
                try
                {
                    // form
                }
                catch
                {
                }



            }
            //  }
        }

        private void GetControlsToBeEnabledInMasterPage(int ScreenId)
        {
            var Elem = from e in ApplicationObject.elementList where e.SCN_ID == ScreenId select e;
            MyElement = Elem.ToList<Element>();
            for (int i = 0; i < MyElement.Count; i++)
            {
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "menu")
                {
                    bool result = CheckMenuAccessable(MyElement[i].Target_SCN_ID);
                    if (result == true)
                    {
                        listMenus.Add(MyElement[i].Element_Name);
                    }
                }
            }
        }

        private void GetControlsToBeEnabled(int ScreenId)
        {

            var Elem = from e in ApplicationObject.elementList where e.SCN_ID == ScreenId select e;
            MyElement = Elem.ToList<Element>();
            for (int i = 0; i < MyElement.Count; i++)
            {
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "Button" && MyElement[i].SCN_ID == MyElement[i].Target_SCN_ID)
                {
                    listAllowedControls.Add(MyElement[i].Element_Name);
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "TextBox" && MyElement[i].SCN_ID == MyElement[i].Target_SCN_ID)
                {
                    listAllowedControls.Add(MyElement[i].Element_Name);
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "menu")
                {
                    bool result = CheckMenuAccessable(MyElement[i].Target_SCN_ID);
                    if (result == true)
                    {
                        listMenus.Add(MyElement[i].Element_Name);
                    }
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "GridViewBoxChange")
                {
                    listGridButtons.Add(MyElement[i].Element_Name);
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "ToolStrip")
                {
                    bool result = CheckMenuAccessable(MyElement[i].Target_SCN_ID);
                    if (result == true)
                    {
                        listToolStrip.Add(MyElement[i].Element_Name);
                    }
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "PictureBoxD")
                {
                    listPictureBoxD.Add(MyElement[i].Element_Name);
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "PictureBoxL")
                {
                    listPictureBoxL.Add(MyElement[i].Element_Name);
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "PictureBoxC")
                {
                    listPictureBoxC.Add(MyElement[i].Element_Name);
                }
                if (MyElement[i].SCN_ID == ScreenId && MyElement[i].Element_Type == "PictureBoxP")
                {
                    listPictureBoxP.Add(MyElement[i].Element_Name);
                }
            }
        }

        private static List<Control> GetControls(Control form)
        {
            var controlList = new List<Control>();

            foreach (Control childControl in form.Controls)
            {
                // Recurse child controls.
                controlList.AddRange(GetControls(childControl));
                controlList.Add(childControl);
            }
            return controlList;
        }

        private bool checkProcessEncounter()
        {
            bool check = false;
            if (ClientSession.ListProcEncounter != null && ClientSession.ListProcEncounter.Count > 0)
            {
                for (int i = 0; i < ClientSession.ListProcEncounter.Count; i++)
                {
                    if (ClientSession.UserCurrentProcess == ClientSession.ListProcEncounter[i].ToString())
                    {
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }

        private bool checkFormExists(string formName)
        {

            bool result = false;
            for (int i = 0; i < MyScnTab.Count; i++)
            {
                if (formName == MyScnTab[i].SCN_Name)
                {
                    result = true;
                    permission = MyScnTab[i].Permission;
                    ClientSession.UserPermission = permission;
                    break;

                }

            }
            return result;
        }

        //private bool checkUserRole(Page form)
        private bool checkPBACUserRole(int ScreenId)
        {

            bool result = false;
            //Added by Selvaraman

            if (ClientSession.PhysicianId == Convert.ToUInt64(ClientSession.FillEncounterandWFObject.EncRecord.Encounter_Provider_ID) && (ClientSession.UserRole == "Physician" || ClientSession.UserRole == "Physician Assistant"))
            {
                result = true;

            }
            else
            {
                result = false;
            }

            return result;



        }

        //public UserPermissionDTO GetUserPermisssions(string userName, string RoleName)
        //{
        //    ScnTabManager objScnMngr = new ScnTabManager();
        //    return objScnMngr.GetUserPermisssions(userName, RoleName);
        //    //SecurityServicesPro obj = new SecurityServicesProxy();
        //    //return obj.GetUserPermisssions(userName);
        //}

        private bool CheckMenuAccessable(int screenID)
        {
            bool result = false;
            var scn = from s in ClientSession.UserPermissionDTO.Userscntab where s.scn_id == Convert.ToUInt64(screenID) && s.user_name.ToUpper() == ClientSession.UserName.ToUpper() && s.Permission == "U" select s;
            if (scn.ToList<user_scn_tab>().Count > 0)
            {
                result = true;
            }
            return result;

        }
        //commented by nijanthan 18-1-16 bug id 37251
        private ArrayList GetlistTabNames(string screenName)
        {
            IList<ScnTab> list = ClientSession.UserPermissionDTO.Screens;
            ArrayList listTabNames = new ArrayList();
            int scn_id = -1;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i].SCN_Name == screenName)
                    {
                        scn_id = list[i].SCN_ID;
                        break;
                    }

                }
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].Parent_SCN_ID == scn_id && list[j].Permission == "U")
                    {

                        listTabNames.Add(list[j].SCN_Name);
                    }

                }
            }
            return listTabNames;
        }

        #endregion
        public void ApplyPBACPermissions(Page form)
        {
            //minimizeMemory();
            UserCurrentList = new ArrayList();
            sUserCurrentProcess = string.Empty;
            uAssignedPhysician_ID = new ulong();
            UserCurrentOwner = string.Empty;
            UserCurrentList.AddRange(ClientSession.UserCurrentList);
            sUserCurrentProcess = ClientSession.UserCurrentProcess;
            uAssignedPhysician_ID = ClientSession.PhysicianId; //EncounterManager.assignedPhysician_ID;
            UserCurrentOwner = ClientSession.UserCurrentOwner;

            if (sUserCurrentProcess == string.Empty)
            {
                if (ClientSession.UserRole.ToUpper() == "MEDICAL ASSISTANT")
                {
                    ClientSession.UserCurrentProcess = "MA_PROCESS";
                }
                else if (ClientSession.UserRole.ToUpper().StartsWith("PHYSICIAN") == true)
                {
                    ClientSession.UserCurrentProcess = "PROVIDER_PROCESS";
                }
                else if (ClientSession.ListProcEncounter.Contains("MA_PROCESS"))
                {
                    ClientSession.UserCurrentProcess = "MA_PROCESS";
                }
                else if (ClientSession.ListProcEncounter.Contains("MA_PROCESS"))
                {
                    ClientSession.UserCurrentProcess = "MA_PROCESS";
                }
                else if (ClientSession.ListProcEncounter.Contains("TECHNICIAN_PROCESS"))
                {
                    ClientSession.UserCurrentProcess = "TECHNICIAN_PROCESS";//BugID:52846
                }
                else if (ClientSession.ListProcEncounter.Contains("FO_PROCESS"))
                {
                    ClientSession.UserCurrentProcess = "MA_PROCESS";
                }
                else
                {
                    ClientSession.UserCurrentOwner = string.Empty;
                }
            }
            
            ClientSession.PhysicianId = ClientSession.PhysicianId;
            ClientSession.UserCurrentList.Add(ClientSession.UserName.ToUpper());
            ClientSession.UserCurrentOwner = ClientSession.UserName;

            form.Disposed += new EventHandler(window_Disposed);
        }

        void window_Disposed(object sender, EventArgs e)
        {

            ClientSession.UserCurrentList = UserCurrentList;
            ClientSession.UserCurrentOwner = sUserCurrentProcess;
            ClientSession.UserCurrentOwner = UserCurrentOwner;
            ClientSession.PhysicianId = uAssignedPhysician_ID;

        }
        public IList<string> GetListTabtoDisable(string screenName)
        {
            IList<ScnTab> list = ClientSession.UserPermissionDTO.Screens;
            IList<string> listTabNames = new List<string>();
            int scn_id = -1;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i].SCN_Name == screenName)
                    {
                        scn_id = list[i].SCN_ID;
                        break;
                    }

                }
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].Parent_SCN_ID == scn_id && list[j].Permission == "R")
                    {

                        listTabNames.Add(list[j].SCN_Name);
                    }

                }
            }
            return listTabNames;
        }
    }
}