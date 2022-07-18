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
    public partial class frmOrdersQuestionSetsBloodLead : System.Web.UI.Page
    {
        
        OrdersQuestionSetBloodLeadManager objOrdersQuestionSetBloodLeadManager = new OrdersQuestionSetBloodLeadManager();
        ArrayList errList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StaticLookupManager objStaticLookupManager = new StaticLookupManager();
                OrdersQuestionSetBloodLead objBloodLead = new OrdersQuestionSetBloodLead();
                IList<StaticLookup> FieldLookUpList;
                List<string> BloodCPT = new List<string>();
                FieldLookUpList = objStaticLookupManager.getStaticLookupByFieldName("BLOOD LEAD TYPE");
                if (FieldLookUpList != null)
                {
                    for (int i = 0; i < FieldLookUpList.Count; i++)
                    {
                        this.cboBloodLeadType.Items.Add(new RadComboBoxItem(FieldLookUpList[i].Value.ToString()));
                    }
                }
                FieldLookUpList = objStaticLookupManager.getStaticLookupByFieldName("BLOOD LEAD PURPOSE");
                if (FieldLookUpList != null)
                {
                    for (int i = 0; i < FieldLookUpList.Count; i++)
                    {
                        this.cboBloodLeadPurpose.Items.Add(new RadComboBoxItem(FieldLookUpList[i].Value.ToString()));
                    }
                }
                cboBloodLeadType.Items.Insert(0,new RadComboBoxItem(""));
                cboBloodLeadPurpose.Items.Insert(0, new RadComboBoxItem(""));
                cboBloodLeadPurpose.SelectedIndex = 0;
                cboBloodLeadType.SelectedIndex = 0;
                if (Request["OrderSubmitID"] != null)// && objBloodLead.Id!=0)
                {
                    objBloodLead = objOrdersQuestionSetBloodLeadManager.GetQuestionSetBloodLead(Convert.ToUInt32(Request["OrderSubmitID"]));
                    cboBloodLeadPurpose.SelectedIndex = cboBloodLeadPurpose.Items.IndexOf(cboBloodLeadPurpose.Items.FindItemByText(objBloodLead.Blood_Lead_Type_Purpose));
                    cboBloodLeadType.SelectedIndex = cboBloodLeadType.Items.IndexOf(cboBloodLeadType.Items.FindItemByText(objBloodLead.Blood_Lead_Type));
                    //cboBloodLeadPurpose.Text = objBloodLead.Blood_Lead_Type_Purpose;
                    //cboBloodLeadType.Text = objBloodLead.Blood_Lead_Type;
                }
                else
                {
                    objBloodLead = new OrdersQuestionSetBloodLead();
                }
                btnQuestionOk.Enabled = false;
            }
            else if (Request.Form["__EVENTTARGET"] == "btnQuestionOk")
            {
                btnQuestionOk_Click(new object(), new EventArgs());
            }
        }

        //protected void btnClearAll_Click(object sender, EventArgs e)
        //{
        //    //int iMsg = ApplicationObject.erroHandler.DisplayErrorMessage("852001", this.Title,this);
        //    //if (iMsg == 2)
        //    //{
        //    //    return;
        //    //}
        //    cboBloodLeadPurpose.Text = string.Empty;
        //    cboBloodLeadType.Text = string.Empty;
        //    btnOK.Enabled = false;
        //}

        protected void cboBloodLeadType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            btnQuestionOk.Enabled = true;
        }

        protected void cboBloodLeadPurpose_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            btnQuestionOk.Enabled = true;
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "QuestionSetBloodLead", "self.close();", true);
        //}    

        protected void btnQuestionOk_Click(object sender, EventArgs e)
        {
            if (hdnYesClick.Value != "" && hdnYesClick.Value == "Yes")
            {
                if (cboBloodLeadType.Text == string.Empty)
                {
                    errList = new ArrayList();
                    errList.Add(lblBloodLeadType.Text.Replace('*', ' '));
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), string.Empty, "DisplayErrorMessage('230106');", true);
                    cboBloodLeadType.Focus();
                    return;
                }
                if (cboBloodLeadPurpose.Text == string.Empty)
                {
                    errList = new ArrayList();
                    errList.Add(lblBloodLeadType.Text.Replace('*', ' '));
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), string.Empty, "DisplayErrorMessage('230106');", true);

                    cboBloodLeadPurpose.Focus();
                    return;
                }
                OrdersQuestionSetBloodLead objBloodLead = new OrdersQuestionSetBloodLead();
                objBloodLead = new OrdersQuestionSetBloodLead();
                objBloodLead.Blood_Lead_Type = cboBloodLeadType.Text;
                objBloodLead.Blood_Lead_Type_HL7_Value = cboBloodLeadType.Text.ToUpper().Substring(0, 1);
                objBloodLead.Blood_Lead_Type_Purpose = cboBloodLeadPurpose.Text;
                objBloodLead.Blood_Lead_Type_Purpose_HL7_Value = cboBloodLeadPurpose.Text.ToUpper().Substring(0, 1);
                objOrdersQuestionSetBloodLeadManager.SaveUpdateOrdersQuestionSetBloodLead(Request["OrderSubmitID"], objBloodLead, ClientSession.UserName, hdnLocalTime.Value);
                btnQuestionOk.Enabled = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Question Set Blood Lead", "CloseBloodLead();", true);
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('230101');", true);
            }
        }
    }
}
