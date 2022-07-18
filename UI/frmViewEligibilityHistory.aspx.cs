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
using Acurus.Capella.Core;
using Acurus.Capella.DataAccess;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections.Generic;
namespace Acurus.Capella.UI
{
    public partial class frmViewEligibilityHistory : System.Web.UI.Page
    {
        Eligibility_VerficationManager EligibilityMngr = new Eligibility_VerficationManager();
        InsurancePlanManager InsMngr = new InsurancePlanManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["HumanID"] != null)
                {
                    ulong ulHumanID = Convert.ToUInt64(Request["HumanID"]);
                    txtAccountNO.Text = Request["HumanId"];
                    txtExternalAccountNO.Text = Request["ExAccountNo"];
                    txtFirstName.Text = Request["FirstName"];
                    txtLastName.Text = Request["LastName"];
                    txtPatientDOB.Text = Request["DOB"];
                    txtPatientSex.Text = Request["PatientSex"];
                    ulong InsPlanID = 0;
                    if (Request["InsPlanID"] != null)
                    {
                        InsPlanID = Convert.ToUInt64(Request["InsPlanID"]);
                        hdnInsPlanID.Value = InsPlanID.ToString();
                    }
                    IList<Eligibility_Verification> EligibilityList = EligibilityMngr.GetEligibilityDetails(ulHumanID, InsPlanID);
                    FillGrid(EligibilityList);
                }
            }
        }
        protected void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll.Checked == true)
            {
                if (txtAccountNO.Text != string.Empty)
                {
                    ulong ulHumanID = Convert.ToUInt64(txtAccountNO.Text);
                    IList<Eligibility_Verification> EligibilityList = EligibilityMngr.GetPatientDetailsUsingPatientInformattion(ulHumanID);
                    FillGrid(EligibilityList);
                }
            }
            else
            {
                if (hdnInsPlanID.Value != string.Empty && txtAccountNO.Text != string.Empty)
                {
                    ulong ulHumanID = Convert.ToUInt64(txtAccountNO.Text);

                    IList<Eligibility_Verification> EligibilityList = EligibilityMngr.GetEligibilityDetails(ulHumanID, Convert.ToUInt64(hdnInsPlanID.Value));
                    FillGrid(EligibilityList);
                }
            }
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }
        public void FillGrid(IList<Eligibility_Verification> EligibilityList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Policy Holder ID", typeof(string));
            dt.Columns.Add("Plan ID", typeof(string));
            dt.Columns.Add("Plan Name", typeof(string));
            dt.Columns.Add("Group No", typeof(string));
            dt.Columns.Add("Effective Start Date", typeof(string));
            dt.Columns.Add("Termination Date", typeof(string));
            dt.Columns.Add("PCP Copay", typeof(string));
            dt.Columns.Add("SPC Copay", typeof(string));
            dt.Columns.Add("Eligibility Verified By", typeof(string));
            dt.Columns.Add("Eligibility Verified Date", typeof(string));
            if (EligibilityList.Count > 0)
            {
                for (int i = 0; i < EligibilityList.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Policy Holder ID"] = EligibilityList[i].Policy_Holder_ID.ToString();
                    dr["Plan ID"] = EligibilityList[i].Insurance_Plan_ID.ToString();
                    if (EligibilityList[i].Insurance_Plan_Name == string.Empty)
                    {
                        IList<InsurancePlan> insList = InsMngr.GetInsurancebyID(EligibilityList[i].Insurance_Plan_ID);
                        if (insList.Count > 0)
                        {
                            dr["Plan Name"] = insList[0].Ins_Plan_Name;
                        }
                    }
                    else
                    {
                        dr["Plan Name"] = EligibilityList[i].Insurance_Plan_Name.ToString();
                    }
                    dr["Group No"] = EligibilityList[i].Group_Number.ToString();
                    if (EligibilityList[i].Effective_Date != DateTime.MinValue)
                        dr["Effective Start Date"] = EligibilityList[i].Effective_Date.ToString("dd-MMM-yyyy");
                    if (EligibilityList[i].Termination_Date != DateTime.MinValue)
                        dr["Termination Date"] = EligibilityList[i].Termination_Date.ToString("dd-MMM-yyyy");
                    dr["PCP Copay"] = EligibilityList[i].PCP_Copay.ToString();
                    dr["SPC Copay"] = EligibilityList[i].SPC_Copay.ToString();
                    dr["Eligibility Verified By"] = EligibilityList[i].Eligibility_Verified_By;
                    if (EligibilityList[i].Eligibility_Verified_Date != DateTime.MinValue)
                        dr["Eligibility Verified Date"] = EligibilityList[i].Eligibility_Verified_Date.ToString("dd-MMM-yyyy");
                    dt.Rows.Add(dr);
                }
                grdEligibilityHIstory.DataSource = dt;
                grdEligibilityHIstory.DataBind();
            }
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                grdEligibilityHIstory.DataSource = dt;
                grdEligibilityHIstory.DataBind();
                if (grdEligibilityHIstory.Rows.Count > 0)
                {
                    int colcount = grdEligibilityHIstory.Rows[0].Cells.Count;
                    grdEligibilityHIstory.Rows[0].Cells.Clear();
                    grdEligibilityHIstory.Rows[0].Cells.Add(new TableCell());
                    grdEligibilityHIstory.Rows[0].Cells[0].ColumnSpan = colcount;
                    grdEligibilityHIstory.Rows[0].Cells[0].Text = "No Records Found";
                    grdEligibilityHIstory.HeaderRow.Height = 20;
                    grdEligibilityHIstory.FooterRow.Height = 20;
                    grdEligibilityHIstory.RowStyle.Height = 20;
                    grdEligibilityHIstory.ControlStyle.Height = 20;
                    return;
                }
            }

        }


    }
}
