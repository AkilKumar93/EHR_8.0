using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using Ionic.Zip;
using Telerik.Web.UI;

namespace Acurus.Capella.PatientPortal
{
    public partial class webfrmBulkAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnfromdate.Value = "";
            hdntodate.Value = "";
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string fromDate =dtpFromDt.Value;
            string toDate = dtpToDt.Value;
            EncounterManager encManager = new EncounterManager();
            string From_Date = Convert.ToDateTime(fromDate).ToUniversalTime().AddHours(-7).ToString();//BugID:49615
           string To_Date = Convert.ToDateTime(toDate).ToUniversalTime().AddHours(24).AddSeconds(-1).ToString();
           ArrayList EncIds = encManager.GetEncounterListByDOSRange(ClientSession.HumanId, From_Date, To_Date);
            Dictionary<string, string> PDFpaths = new Dictionary<string, string>();
            Dictionary<string, string> XMLpaths = new Dictionary<string, string>();
            if (EncIds!=null)// && EncIds.Count > 0)
            {
                //if (SummaryList.Items.Count > 0)
                //{
                    
                //    for (int i = 0; i < SummaryList.Items.Count; i++)
                //    {
                //        SummaryList.Items.Remove(SummaryList.Items[i]);
                //    }
                //}
                SummaryList.Items.Clear();
                foreach (var strEncID in EncIds)
                {
                        frmClinicalSummary objClinicalSummary = new frmClinicalSummary();
                        frmSummaryOfCare objSummaryofCare = new frmSummaryOfCare();
                        string path = string.Empty;
                        string sMyPath = string.Empty;
                        string PDFPath = string.Empty;
                        string XMlPath = string.Empty;
                        string sFilePathPDF = string.Empty;
                        var filepath = string.Empty;
                        ArrayList FilePath = new ArrayList();
                       
                        if (strEncID != null)
                        {
                            FilePath = objClinicalSummary.PrintClinicalSummary(Convert.ToUInt32(strEncID.ToString().Split('|')[0]), ClientSession.HumanId, false, ref sMyPath, "", true, true);
                            if (FilePath != null)
                            {
                                sFilePathPDF = objSummaryofCare.PrintPDF(FilePath[0].ToString(), "PatientPortal", DateTime.MinValue);
                                for (int i = 0; i < FilePath.Count; i++)
                                {
                                    string[] Split = new string[] { System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath };
                                    string[] fileName = FilePath[i].ToString().Split(Split, StringSplitOptions.RemoveEmptyEntries);

                                    if (fileName[0].ToUpper().Contains(".XML"))
                                    {
                                        XMlPath = fileName[0].ToString();
                                    }

                                    if (fileName[0].ToUpper().Contains(".PDF"))
                                    {
                                        PDFPath = fileName[0].ToString();
                                    }
                                }
                                if (sFilePathPDF != string.Empty)
                                {
                                    string[] SplitPdf = new string[] { System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath };
                                    string[] FileName = sFilePathPDF.Split(SplitPdf, StringSplitOptions.RemoveEmptyEntries);

                                    PDFPath = FileName[0].ToString();
                                }
                                PDFpaths.Add(strEncID.ToString().Split('|')[0], PDFPath);
                                XMLpaths.Add(strEncID.ToString().Split('|')[0], XMlPath);
                                IList<ActivityLog> ActivityLogList = new List<ActivityLog>();
                                ActivityLogManager ActivitylogMngr = new ActivityLogManager();
                                ActivityLog activity = new ActivityLog();
                                activity.Human_ID = Convert.ToUInt64(ClientSession.HumanId);
                                activity.Encounter_ID = Convert.ToUInt32(strEncID.ToString().Split('|')[0]);
                                activity.Activity_Type = "View";
                                activity.Role = "";

                                activity.Activity_Date_And_Time = System.DateTime.UtcNow;
                                ActivityLogList.Add(activity);
                                ActivitylogMngr.SaveActivityLogManager(ActivityLogList, string.Empty);
                                ListItem chkbx = new ListItem();
                                chkbx.Text = "Summary_of_Care_" + UtilityManager.ConvertToLocal(Convert.ToDateTime(strEncID.ToString().Split('|')[1])).ToString("dd_MMM_yyyy hh_mm tt");
                                chkbx.Attributes.Add("hdnpath", PDFPath);
                                chkbx.Attributes.Add("hdnId", strEncID.ToString().Split('|')[0]);
                                //chkbx.Attributes.Add("onclick", "addItem()");
                                SummaryList.Items.Add(chkbx);
                            }
                        }
                        
                        //fileThumbs.Controls.Add(new LiteralControl("<br/>"));
                }
                HttpContext.Current.Session["Zip_PdfPath"] = PDFpaths;
                HttpContext.Current.Session["Zip_xmlPath"] = XMLpaths;
            }
            hdnfromdate.Value = fromDate;
            hdntodate.Value = toDate;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Load", "sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart();", true);
        }

        //protected void btnSend_ServerClick(object sender, EventArgs e)
        //{
        //    string files = hdnFilesList.Value;
        //    if (files != null && files.Trim() != string.Empty)
        //    {
        //        string[] filesList = files.Split(',');
        //        using (ZipFile zip = new ZipFile())
        //        {
        //            zip.AlternateEncodingUsage = ZipOption.AsNecessary;

        //            DirectoryInfo directorySelected = new DirectoryInfo(Server.MapPath(filesList[0]));

        //            foreach (FileInfo fileToCompress in directorySelected.Parent.GetFiles("*.pdf"))
        //            {
        //                foreach (string filename in filesList)
        //                {
        //                    if (Server.MapPath(filename) == fileToCompress.FullName)
        //                    {
        //                        string filePath = fileToCompress.FullName;
        //                        zip.AddFile(filePath, "");
        //                    }
        //                }
        //            }
        //            string zipName = String.Format("Bulk_Acess_SOC_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //            DirectoryInfo dirSave = new DirectoryInfo(Server.MapPath("atala-capture-download//" + Session.SessionID));
        //            if (!dirSave.Exists)
        //            {
        //                dirSave.Create();
        //            }
        //            zip.Save(Server.MapPath("atala-capture-download//" + Session.SessionID + "//" + zipName));
        //            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "", "downloadURI('" + Page.ResolveClientUrl("atala-capture-download//" + Session.SessionID + "//" + zipName) + "');", true);
        //        }
        //    }
            
        //}

    }
}