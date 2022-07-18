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
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.IO;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DTO;
using Telerik.Web.UI;
using System.Diagnostics;

namespace Acurus.Capella.UI
{
    public partial class frmResultLab : System.Web.UI.Page
    {
        LabManager objLabManager = new LabManager();
        ResultMasterManager objResultMasterManager = new ResultMasterManager();
        FillResultDTO ObjFillResultDTO = null;
        //{
        //    get
        //    {
        //        return (FillResultDTO)ViewState["ObjFillResultDTO"];
        //    }

        //    set
        //    {
        //        ViewState["ObjFillResultDTO"] = value;
        //    }
        //}
        //ulong Order_ID = 18360;
        ulong Order_ID = 0;
        ulong Result_Master_ID = 0;
        string strScreenName = string.Empty;
        FillPatientChart objPatChart = new FillPatientChart();
        string bMovetonextprocess = string.Empty;

        //vince to find Status Flag 20-06-2014//
        public IList<string> _Flag = new List<string>();
        //vince to find Status Flag//

        public int CalculateAge(DateTime birthDate)
        {
            // cache the current time
            DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
            // get the difference in years
            int years = now.Year - birthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                --years;

            return years;
        }
     
        string sPriPlan = string.Empty;
        string sSecPlan = string.Empty;
        string sPriCarrier = string.Empty;
        string sSecCarrier = string.Empty;
        EncounterManager objEncounterManager = new EncounterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Result_Master_ID"] != null)
            {
                Result_Master_ID = Convert.ToUInt64(Request["Result_Master_ID"]);
            }
            if (!IsPostBack)
            {
                PDFGenerator objPDFGenerator = new PDFGenerator();
                string filepath = Server.MapPath("Documents/" + Session.SessionID);
                hdnSelectedItem.Value = String.Empty;
                string filename = objPDFGenerator.GenerateRequestionForLabcorp(Result_Master_ID, filepath);
                string[] Split = new string[] { Server.MapPath("Documents\\" + Session.SessionID) };
                string[] FileName = filename.Split(Split, StringSplitOptions.RemoveEmptyEntries);
                string file = "Documents\\" + Session.SessionID.ToString() + FileName[0].ToString();
               // string loc = "DYNAMIC";
                if (hdnSelectedItem.Value == string.Empty)
                {
                    hdnSelectedItem.Value = "Documents\\" + Session.SessionID.ToString() + FileName[0].ToString();
                }
                else
                {
                    hdnSelectedItem.Value += "|" + FileName[0].ToString();
                }
                RadPageView1.ContentUrl = hdnSelectedItem.Value.ToString();
                RadPageView1.Selected = true;
            }
        }
        
        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "Closepage", "RadWindowClose();", true);
        }
    }
}
