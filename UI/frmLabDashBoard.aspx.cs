using System;
using System.Collections;
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
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.UI
{
    public partial class frmLabDashBoard : System.Web.UI.Page
    {
        PhysicianManager objPhysicianMngr = new PhysicianManager();
        OrdersManager objOrdersManager = new OrdersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // PhysicianManager objPhysicianMngr = new PhysicianManager(); //code comment by balaji.TJ 2015-12-09
                dtpFromDate.Disabled = true;
                dtpToDate.Disabled = true;
                dtpFromDate.Value = "";
                dtpToDate.Value = "";
                cboProviderName.Items.Clear();
                FillPhysicianUser PhyUserList;
                if (ClientSession.UserRole == "Physician" || ClientSession.UserRole == "Physician Assistant")
                PhyUserList = objPhysicianMngr.GetPhysicianandUser(false, ClientSession.FacilityName,ClientSession.LegalOrg);
                else
                    PhyUserList = objPhysicianMngr.GetPhysicianandUser(true, ClientSession.FacilityName, ClientSession.LegalOrg);
                if (PhyUserList != null && PhyUserList.PhyList.Count > 0) //code added by balaji.Tj 2015-12-09
                {
                    for (int i = 0; i < PhyUserList.PhyList.Count; i++)
                    {
                        string sPhyName = PhyUserList.PhyList[i].PhyPrefix + " " + PhyUserList.PhyList[i].PhyFirstName + " " + PhyUserList.PhyList[i].PhyMiddleName + " " + PhyUserList.PhyList[i].PhyLastName + " " + PhyUserList.PhyList[i].PhySuffix;
                        cboProviderName.Items.Add(PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName);
                        cboProviderName.Items[i].Value = PhyUserList.PhyList[i].Id.ToString();
                        cboProviderName.ToolTip = cboProviderName.SelectedItem.Text;

                        if (ClientSession.UserRole == "Physician" || ClientSession.UserRole == "Physician Assistant")
                        {
                            cboProviderName.Enabled = false;
                            //added by balaji.T
                            if (PhyUserList.UserList[i].user_name.ToString() == ClientSession.UserName)
                            {
                                cboProviderName.Text = ClientSession.UserName;
                                cboProviderName.SelectedIndex = i;
                            }
                                                  
                            chkShowActive.Visible = false;
                        }
                    }
                }
                grdLab.DataSource = new string[] { };
                grdLab.DataBind();
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboProviderName.Text.Trim() == string.Empty)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103002'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                cboProviderName.Focus();
                return;
            }
            if (chkDateRange.Checked == true)
            {
                dtpFromDate.Disabled = false;
                dtpToDate.Disabled = false;
                if (dtpFromDate.Value == string.Empty)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103003'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
                if (dtpToDate.Value == string.Empty)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103004'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
                if (dtpFromDate.Value == string.Empty && dtpToDate.Value != string.Empty)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103003'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }

                if (dtpFromDate.Value != string.Empty && dtpToDate.Value == string.Empty)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103004'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
                if (Convert.ToDateTime(dtpToDate.Value) < Convert.ToDateTime(dtpFromDate.Value))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103005'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
                if (Convert.ToDateTime(dtpFromDate.Value) > Convert.ToDateTime(hdnLocalTime.Value).Date)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103008'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
                if (Convert.ToDateTime(dtpToDate.Value) > Convert.ToDateTime(hdnLocalTime.Value).Date)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "LabDashBordErrorMessage", "DisplayErrorMessage('103009'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
            }
            else
            {
                dtpFromDate.Disabled = true;
                dtpToDate.Disabled = true;
            }
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Category";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Description";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Total";
            dt.Columns.Add(dc);

            Dictionary<string, string> ilstlab = new Dictionary<string, string>();
            if (chkDateRange.Checked == false)
                ilstlab = objOrdersManager.GetLabDashboard(Convert.ToUInt32(cboProviderName.Items[cboProviderName.SelectedIndex].Value), Convert.ToDateTime("0001-01-01"), Convert.ToDateTime(hdnLocalTime.Value));
            else
                //ilstlab = objOrdersManager.GetLabDashboard(Convert.ToUInt32(cboProviderName.Items[cboProviderName.SelectedIndex].Value), dtpFromDate.DateInput.SelectedDate ?? new DateTime(), dtpToDate.DateInput.SelectedDate ?? new DateTime());               
                ilstlab = objOrdersManager.GetLabDashboard(Convert.ToUInt32(cboProviderName.Items[cboProviderName.SelectedIndex].Value), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value));

            DataRow dr = dt.NewRow();
            foreach (KeyValuePair<string, string> item in ilstlab)
            {
                dr = dt.NewRow();
                if (item.Key.Contains("LabCorp") == true)
                    dr["Category"] = "LabCorp";
                else if (item.Key.Contains("Quest") == true)
                    dr["Category"] = "Quest";
                dr["Description"] = item.Key;
                dr["Total"] = item.Value;
                dt.Rows.Add(dr);
            }
            grdLab.DataSource = dt;
            grdLab.DataBind();
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            chkDateRange.Checked = false;
            chkShowActive.Checked = false;
            if (ClientSession.UserRole == "Physician" || ClientSession.UserRole == "Physician Assistant")
            { }
            else
            { cboProviderName.SelectedIndex = -1; }
            grdLab.DataSource = new string[] { };
            grdLab.DataBind();
            dtpFromDate.Value = string.Empty;
            dtpToDate.Value = string.Empty;


            dtpFromDate.Disabled = true;
            dtpToDate.Disabled = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }

        protected void chkShowActive_CheckedChanged(object sender, EventArgs e)
        {
            FillPhysicianUser PhyUserList;
            cboProviderName.Items.Clear();
            if (chkShowActive.Checked == true)
                PhyUserList = objPhysicianMngr.GetPhysicianandUser(false, string.Empty, ClientSession.LegalOrg);         
            else
                PhyUserList = objPhysicianMngr.GetPhysicianandUser(true, ClientSession.FacilityName, ClientSession.LegalOrg);
            if (PhyUserList != null && PhyUserList.PhyList.Count > 0) //code added by balaji.tj 2015-12-09
            {
                for (int i = 0; i < PhyUserList.PhyList.Count; i++)
                {
                    string sPhyName = PhyUserList.PhyList[i].PhyPrefix + " " + PhyUserList.PhyList[i].PhyFirstName + " " + PhyUserList.PhyList[i].PhyMiddleName + " " + PhyUserList.PhyList[i].PhyLastName + " " + PhyUserList.PhyList[i].PhySuffix;
                    cboProviderName.Items.Add(PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName);
                    cboProviderName.Items[i].Value = PhyUserList.PhyList[i].Id.ToString();
                    cboProviderName.ToolTip = cboProviderName.Items[i].Text;

                    if (Convert.ToUInt64(cboProviderName.Items[i].Value) == ClientSession.PhysicianId)                    
                        cboProviderName.SelectedIndex = i;                   
                    else
                    { }
                }
            }
            if (chkShowActive.Checked == true)
            {
                var phyName = from p in PhyUserList.PhyList where (p.Id == ClientSession.PhysicianId) select p;
                if (phyName.Count() != 0)
                {
                    string PhysicianName = phyName.ToList<PhysicianLibrary>()[0].PhyPrefix + " " + phyName.ToList<PhysicianLibrary>()[0].PhyFirstName + " " + phyName.ToList<PhysicianLibrary>()[0].PhyMiddleName + " " + phyName.ToList<PhysicianLibrary>()[0].PhyLastName + " " + phyName.ToList<PhysicianLibrary>()[0].PhySuffix;
                    cboProviderName.Text = ClientSession.UserName + " - " + PhysicianName;
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }
    }
}
