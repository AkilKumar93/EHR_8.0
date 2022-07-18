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
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections.Generic;
using Telerik.Web.UI;

namespace Acurus.Capella.UI
{
    public partial class frmSearchAllResults : System.Web.UI.Page
    {
        IList<AcurusResultsMapping> lstAcurusResultsMapping = new List<AcurusResultsMapping>();
        AcurusResultsMappingManager objAcurusResultsMappingMngr = new AcurusResultsMappingManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                btnOk.Enabled = false;
                txtDescription.Focus();
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            hdnSearchResults.Value = string.Empty;
            string sResultList = string.Empty;

            if (chkSearchDescription.Items.Count == 0)
            {
                return;
            }

            List<string> lstSelectedValues = new List<string>();

            for (int i = 0; i < chkSearchDescription.Items.Count; i++)
            {
                if(chkSearchDescription.Items[i].Selected==true)
                {
                   
                    lstSelectedValues.Add(chkSearchDescription.Items[i].Value + "_" + chkSearchDescription.Items[i].Text);
                }
              
            }

            hdnSearchResults.Value = string.Join("|", lstSelectedValues.ToArray());

            btnOk.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "CloseSearchAll();", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('640008'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                txtDescription.Focus();
                txtDescription.Text = string.Empty;
                return;
            }
            else
            {                
                lstAcurusResultsMapping = objAcurusResultsMappingMngr.GetFlowsheetMapResults(txtDescription.Text);                
                decimal tempDouble = ((decimal)lstAcurusResultsMapping.Count / (decimal)12);
                int columns = (int)(Math.Ceiling(tempDouble));
                chkSearchDescription.Items.Clear();
                if (lstAcurusResultsMapping.Count > 12)
                {
                    chkSearchDescription.RepeatColumns = columns;
                    chkSearchDescription.RepeatLayout = RepeatLayout.Table;
                }
                else
                {
                    chkSearchDescription.RepeatLayout = RepeatLayout.Flow;
                    chkSearchDescription.RepeatColumns = 0;
                }
                foreach (var obj in lstAcurusResultsMapping)
                {
                    System.Web.UI.WebControls.ListItem lstItem = new System.Web.UI.WebControls.ListItem();
                    lstItem.Text = obj.Acurus_Result_Description;
                    lstItem.Value = obj.Acurus_Result_Code;
                    chkSearchDescription.Items.Add(lstItem);
                }
                if (chkSearchDescription.Items.Count == 0)
                {
                    lblMessage.Text = "No Result(s) Found  ";
                }
                else
                {
                    lblMessage.Text = chkSearchDescription.Items.Count + " Result(s) Found  ";
                }
                lblMessage.Visible = true;
                btnOk.Enabled = true;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }
        //protected void chkSearchDescription_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(((RadListBox)sender).SelectedItem.Checked == true)
        //    {
        //        ((RadListBox)sender).SelectedItem.Checked = false;
        //    }
        //    else
        //    {
        //        ((RadListBox)sender).SelectedItem.Checked = true;
        //    }
        //}
    }
}
