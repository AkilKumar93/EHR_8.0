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

using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.UI;
namespace Acurus.Capella.UI
{
    public partial class frmViewMessage : System.Web.UI.Page
    {
        PatientNotesManager patientnotesmngr = new PatientNotesManager();
        DataTable dttable = new DataTable();        
        DataTable dttableforMessageTask = new DataTable();        
        HumanManager objhumanmngr = new HumanManager();        
        DataRow drowforMessageTask;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "View Message" + "-" + ClientSession.UserName;
            if (!IsPostBack)
            {                
                lblGridCount.Visible = false;
                if (ClientSession.HumanId > 0)
                {                    
                    txtAccount.Text = ClientSession.HumanId.ToString();
                    IList<Human> patientdetail = objhumanmngr.patientdetails(txtAccount.Text);
                    if (patientdetail.Count != 0)
                    {
                        txtPatientName.Text = patientdetail[0].First_Name;
                        txtDOB.Text = patientdetail[0].Birth_Date.ToString("dd-MMM-yyyy");
                        txtPatientStatus.Text = patientdetail[0].Patient_Status;
                        txtPatientType.Text = patientdetail[0].Human_Type;
                    }
                }
                else if ((Request["AccountNum"] != "")&&(Request["AccountNum"]!="undefined"))
                {
                    txtAccount.Text = Convert.ToString(Convert.ToUInt64(Request["AccountNum"]));
                    IList<Human> patientdetail = objhumanmngr.patientdetails(txtAccount.Text);
                    if (patientdetail.Count != 0)
                    {
                        txtPatientName.Text = patientdetail[0].First_Name;
                        txtDOB.Text = patientdetail[0].Birth_Date.ToString("dd-MMM-yyyy");
                        txtPatientStatus.Text = patientdetail[0].Patient_Status;
                        txtPatientType.Text = patientdetail[0].Human_Type;
                    }
                }                
                fillMessageTask();                
                fillGridMessageTask();                           
            }            
        }
        void PatientDetails()
        {            
            fillMessageTask();            
            lblGridCount.Text = string.Empty;
            IList<Human> patientdetail = objhumanmngr.patientdetails(txtAccount.Text);
            if (patientdetail.Count != 0)
            {
                txtPatientName.Text = patientdetail[0].First_Name;
                txtDOB.Text = patientdetail[0].Birth_Date.ToString("dd-MMM-yyyy");
                txtPatientStatus.Text = patientdetail[0].Patient_Status;
                txtPatientType.Text = patientdetail[0].Human_Type;                
                fillGridMessageTask();                
            }
        }
        
        void fillMessageTask()
        {
            dttableforMessageTask.Columns.Add("Created Date And Time", typeof(string));
            dttableforMessageTask.Columns.Add("Source", typeof(string));
            dttableforMessageTask.Columns.Add("SourceID", typeof(string));
            dttableforMessageTask.Columns.Add("Message Description", typeof(string));
            dttableforMessageTask.Columns.Add("Notes", typeof(string));
            dttableforMessageTask.Columns.Add("Priority", typeof(string));
            dttableforMessageTask.Columns.Add("Created By", typeof(string));
            dttableforMessageTask.Columns.Add("Modified By", typeof(string));
            dttableforMessageTask.Columns.Add("Modified Date and Time", typeof(string));
        }        
        void fillGridMessageTask()
        {
            grdMessageTask.DataSource = null;
            grdMessageTask.DataBind();
            if (txtAccount.Text != null)
            {
                IList<PatientNotes> patientdetails = patientnotesmngr.GetMessageTask(txtAccount.Text);
                if (patientdetails.Count != 0)
                {
                    for (int i = 0; i < patientdetails.Count; i++)
                    {
                        drowforMessageTask = dttableforMessageTask.NewRow();
                        drowforMessageTask["Message Description"] = patientdetails[i].Message_Description;
                        drowforMessageTask["Notes"] = patientdetails[i].Notes;                        
                        DateTime dtCreatedDate = UtilityManager.ConvertToLocal(patientdetails[i].Created_Date_And_Time);
                        if (dtCreatedDate.ToString("yyyy-MM-dd") == "0001-01-01")
                        {
                            drowforMessageTask["Created Date And Time"] = "";
                        }
                        else
                        {
                            drowforMessageTask["Created Date And Time"] = dtCreatedDate.ToString("dd-MMM-yyyy hh:mm tt");// patientdetails[i].Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                        }                        
                        drowforMessageTask["Created By"] = patientdetails[i].Created_By;
                        drowforMessageTask["Source"] = patientdetails[i].Source;
                        drowforMessageTask["SourceID"] = patientdetails[i].SourceID;
                        drowforMessageTask["Priority"] = patientdetails[i].Priority;
                        drowforMessageTask["Modified By"] = patientdetails[i].Modified_By;                                                
                        DateTime dtModifiedDate = UtilityManager.ConvertToLocal(patientdetails[i].Modified_Date_And_Time);
                        if (dtModifiedDate.ToString("yyyy-MM-dd") == "0001-01-01")
                        {
                            drowforMessageTask["Modified Date and Time"] = "";
                        }
                        else
                        {
                            drowforMessageTask["Modified Date and Time"] = dtModifiedDate.ToString("dd-MMM-yyyy hh:mm tt");// patientdetails[i].Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                        }                     
                        dttableforMessageTask.Rows.Add(drowforMessageTask);
                    }
                    lblGridCount.Visible = true;
                    hdnTotalCount.Value = patientdetails.Count.ToString();
                    if (hdnTotalCount.Value != string.Empty)
                    {
                        lblGridCount.Text = hdnTotalCount.Value + " Record(s) Found";
                    }
                    grdMessageTask.DataSource = dttableforMessageTask;
                    grdMessageTask.DataBind();
                }
                else
                {
                    lblGridCount.Text = "0" + " Record(s) Found";             
                    DataRow dr = dttableforMessageTask.NewRow();                    
                    dttableforMessageTask.Rows.Add(dr);
                    grdMessageTask.DataSource = dttableforMessageTask;
                    grdMessageTask.DataBind();
                    grdMessageTask.Rows[0].Visible = false;
                }
            }
            else
            {
                DataRow dr = dttableforMessageTask.NewRow();
                dttableforMessageTask.Rows.Add(dr);
                grdMessageTask.DataSource = dttableforMessageTask;
                grdMessageTask.DataBind();
                grdMessageTask.Rows[0].Visible = false;
            }
        }        

        protected void btnGetAccNo_Click(object sender, EventArgs e)
        {
            txtAccount.Text = hdnAccNo.Value;
            PatientDetails();
        }
    }
}
