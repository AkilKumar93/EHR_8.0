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
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Acurus.Capella.UI;

namespace Acurus.Capella.UI
{
    public partial class frmViewGuarantor : System.Web.UI.Page
    {
        HumanManager humanMngr = new HumanManager();
        PatGuarantorManager patMngr = new PatGuarantorManager();
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in grdGuarantorDetails.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl00");
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl01");
                    //Page.ClientScript.RegisterForEventValidation
                    //       (r.UniqueID + "$ctl02");
                }
            }

            base.Render(writer);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ClientSession.FlushSession();
                IList<Human> HumanList = null;
                if (Request["HumanID"] != null)
                {
                    if (Request["Patype"] != null)
                    {
                        txtPatientType.Text = Request["Patype"].ToString();
                    }
                    ulong HumanID = Convert.ToUInt64(Request["HumanID"]);
                    HumanList = humanMngr.GetPatientDetailsUsingPatientInformattion(HumanID);
                    if (HumanList != null && HumanList.Count > 0)
                    {
                        txtAccountNO.Text = HumanList[0].Id.ToString();
                        txtPatientDOB.Text = HumanList[0].Birth_Date.ToString("dd-MMM-yyyy");
                        txtPatientSex.Text = HumanList[0].Sex;
                        txtPatinetFirstName.Text = HumanList[0].First_Name;
                        txtPatinetLastName.Text = HumanList[0].Last_Name;
                        txtExternalAccountNO.Text = HumanList[0].Patient_Account_External.ToString();
                    }
                    DataSet dsGuarantor = patMngr.GetHumanPatGuarantorDetails(Convert.ToInt32(Request["HumanID"]));
                    btnMakeActive.Enabled = false;
                    btnMakeInactive.Enabled = false;

                    if (dsGuarantor != null)
                    {
                        if (dsGuarantor.Tables[0].Rows.Count != 0)
                        {
                            grdGuarantorDetails.DataSource = dsGuarantor.Tables[0];
                            grdGuarantorDetails.DataBind();
                        }
                        else
                        {
                            DataTable dtblGuarantor = new DataTable();
                            dtblGuarantor.Columns.Add("GuarantorID", typeof(string));
                            dtblGuarantor.Columns.Add("GuarantorName", typeof(string));
                            dtblGuarantor.Columns.Add("GuarantorDOB", typeof(string));
                            dtblGuarantor.Columns.Add("HomePhone#", typeof(string));
                            dtblGuarantor.Columns.Add("WorkPhone#", typeof(string));
                            dtblGuarantor.Columns.Add("Cell Phone#", typeof(string));
                            dtblGuarantor.Columns.Add("RelationToPatient", typeof(string));
                            dtblGuarantor.Columns.Add("FromDate", typeof(string));
                            dtblGuarantor.Columns.Add("ToDate", typeof(string));
                            dtblGuarantor.Columns.Add("Active", typeof(string));
                            dtblGuarantor.Columns.Add("ID", typeof(string));

                            DataRow dr = dtblGuarantor.NewRow();
                            dtblGuarantor.Rows.Add(dr);
                            grdGuarantorDetails.DataSource = dtblGuarantor;
                            grdGuarantorDetails.DataBind();
                            grdGuarantorDetails.Rows[0].Visible = false;
                        }
                    }
                }
            }
        }

        protected void btnMakeActive_Click(object sender, EventArgs e)
        {
            if (grdGuarantorDetails.SelectedRow != null)
            {
                PatGuarantor objPatguarantor = patMngr.getPatHumanDetailsByID(Convert.ToInt32(grdGuarantorDetails.SelectedRow.Cells[11].Text));
                objPatguarantor.Modified_By = ClientSession.UserName;
                if (hdnLocalTime.Value != string.Empty)
                {
                    objPatguarantor.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                }
                objPatguarantor.Active = "YES";
                objPatguarantor.Created_By = "gurantor";
                if (objPatguarantor != null)
                    patMngr.UpdatePatGuarantor(objPatguarantor);
                DataSet dsGuarantor = patMngr.GetHumanPatGuarantorDetails(objPatguarantor.Human_ID);
                if (dsGuarantor != null)
                {
                    grdGuarantorDetails.DataSource = dsGuarantor.Tables[0];
                    grdGuarantorDetails.DataBind();
                }
                btnMakeInactive.Enabled = true;
                btnMakeActive.Enabled = false;
            }
        }

        protected void grdGuarantorDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdGuarantorDetails.SelectedRow.Cells[10].Text.ToUpper() == "NO")
            {
                btnMakeActive.Enabled = true;
                btnMakeInactive.Enabled = false;
            }
            else if (grdGuarantorDetails.SelectedRow.Cells[10].Text.ToUpper() == "YES")
            {
                btnMakeInactive.Enabled = true;
                btnMakeActive.Enabled = false;
            }
        }

        protected void btnMakeInactive_Click(object sender, EventArgs e)
        {
            if (grdGuarantorDetails.SelectedRow != null)
            {
                PatGuarantor objPatguarantor = patMngr.getPatHumanDetailsByID(Convert.ToInt32(grdGuarantorDetails.SelectedRow.Cells[11].Text));
                objPatguarantor.Modified_By = ClientSession.UserName;
                if (hdnLocalTime.Value != string.Empty)
                {
                    objPatguarantor.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                }

                objPatguarantor.Active = "NO";
                objPatguarantor.Created_By = "gurantor";
                if (objPatguarantor != null)
                    patMngr.UpdatePatGuarantor(objPatguarantor);
                DataSet dsGuarantor = patMngr.GetHumanPatGuarantorDetails(objPatguarantor.Human_ID);
                if (dsGuarantor != null)
                {
                    grdGuarantorDetails.DataSource = dsGuarantor.Tables[0];
                    grdGuarantorDetails.DataBind();
                }
                btnMakeActive.Enabled = true;
                btnMakeInactive.Enabled = false;
            }
        }

        protected void grdGuarantorDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Attributes.Add("style", "display:none");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("style", "display:none");
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[12].Controls[0];
                string _jsSingle =
                ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                _jsSingle = _jsSingle.Insert(11, "setTimeout(\"");
                _jsSingle += "\", 300)";
                e.Row.Attributes["onclick"] = _jsSingle;
                //LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[16].Controls[0];
                //string _jsDouble =
                //ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //e.Row.Attributes["ondblclick"] = _jsDouble;
            }
        }

        protected void grdGuarantorDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            // Get the selected index and the command name
            int _selectedIndex = int.Parse(e.CommandArgument.ToString());
            string _commandName = e.CommandName;
            switch (_commandName)
            {
                case ("SingleClick"):
                    _gridView.SelectedIndex = _selectedIndex;
                    if (grdGuarantorDetails.Rows[_selectedIndex].Cells[10].Text.ToUpper() == "NO")
                    {
                        btnMakeActive.Enabled = true;
                        btnMakeInactive.Enabled = false;
                    }
                    else if (grdGuarantorDetails.Rows[_selectedIndex].Cells[10].Text.ToUpper() == "YES")
                    {
                        btnMakeInactive.Enabled = true;
                        btnMakeActive.Enabled = false;
                    }
                    break;
                //case ("DoubleClick"):
                //    _gridView.SelectedIndex = _selectedIndex;
                //    hdnSelectedIndex.Value = _selectedIndex.ToString();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "CloseFindPatient();", true);
                //    break;
            }
        }
    }
}
