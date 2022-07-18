using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using System.Net;
using System.IO;
using Acurus.Capella.Core.DTO;
using System.Collections;
using System.Runtime.Serialization;
using System.Data;
using System.Drawing;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Text;
using Acurus.Capella.PatientPortal;
using Telerik.Web.UI;
using Ionic.Zip;


namespace Acurus.Capella.PatientPortal
{
    public partial class frmMailBox : System.Web.UI.Page
    {
        IList<PhysicianLibrary> ilstPhysicianLibrary = new List<PhysicianLibrary>();
        string sPatientPortal = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["PatientID"] != null && Request["EmailID"] != null)
            {
                hdnEmailID.Value = Request["EmailID"].ToString();
                hdnPatientID.Value = Request["PatientID"].ToString();
                hdnEncounterID.Value = Request["EncounterID"].ToString();
                sPatientPortal = "YES";
                hdnIsPatientPortal.Value = sPatientPortal;
            }
            else
            {
                sPatientPortal = "NO";
                hdnIsPatientPortal.Value = sPatientPortal;
            }

            if (!IsPostBack)
            {
                if (Request["Role"] != null && Request["Role"] != "")
                {
                    hdnRole.Value = Request["Role"].ToString();
                }
                ActivityLogManager activityMngr = new ActivityLogManager();

                IList<Human> ilstHuman = new List<Human>();
                ulong HumanID = ClientSession.HumanId;
                ulong EncounterID = ClientSession.PhysicianId;

                //if (Request["PatientID"] != null && Request["EmailID"] != null)
                //{
                //    hdnEmailID.Value = Request["EmailID"].ToString();
                //    hdnPatientID.Value = Request["PatientID"].ToString();
                //    hdnEncounterID.Value = Request["EncounterID"].ToString();
                //}

                //                else if (ClientSession.PhysicianId != 0)
                if (ClientSession.PhysicianId != 0)
                {
                    ilstPhysicianLibrary = activityMngr.ilstPhysicianLibraryforGetMailID(ClientSession.PhysicianId);
                    if (ilstPhysicianLibrary.Count > 0)
                    {
                        ClientSession.PhysicainDetails = ilstPhysicianLibrary;
                        hdnEmailID.Value = ilstPhysicianLibrary[0].PhyEMail.ToString();
                        hdnPatientID.Value = string.Empty;
                        hdnEncounterID.Value = Convert.ToString(ClientSession.EncounterId);
                    }

                }
                rdbtnInbox.Checked = true;
                if (grdMailBox.DataSource == null)
                {
                    grdMailBox.DataSource = new string[] { };
                    grdMailBox.DataBind();
                }
                if (hdnEmailID.Value != string.Empty)
                {
                    //IList<ActivityLog> activityList = new List<ActivityLog>();
                    //activityList = activityMngr.GetInboxEntries(hdnEmailID.Value);
                    //if (activityList.Count > 0)
                    //{
                    //    fillMailBoxGrid(activityList, "INBOX");
                    //}
                    IList<ActivityLog> activityList = new List<ActivityLog>();
                    if (sPatientPortal == "YES")
                        activityList = activityMngr.GetInboxEntries(hdnEmailID.Value);
                    else
                    {
                        string sPhyEmail = hdnEmailID.Value;
                        if (ClientSession.PhysicainDetails != null && ClientSession.PhysicainDetails.Count > 0)
                        {
                            if (ClientSession.PhysicainDetails[0].PhyEMail.Trim() != "")
                                sPhyEmail += "','" + ClientSession.PhysicainDetails[0].PhyEMail;
                            if (ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username.Trim() != "")
                            {
                                if (sPhyEmail != string.Empty)
                                    sPhyEmail += "','" + ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username;
                                else
                                    sPhyEmail = ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username;

                            }
                        }
                        activityList = activityMngr.GetInboxEntries(sPhyEmail);
                    }
                    if (activityList.Count > 0)
                    {
                        fillMailBoxGrid(activityList, "INBOX");
                    }
                }
            }

            
        }

        public void fillMailBoxGrid(IList<ActivityLog> activityList, string MailType)
        {
            grdMailBox.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("From", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("ToAddress", typeof(string));
            dt.Columns.Add("Body", typeof(string));
            dt.Columns.Add("DateTime", typeof(string));
            dt.Columns.Add("Filename", typeof(string));


            DataRow dr;
            if (MailType == "INBOX")
            {
                grdMailBox.Columns[0].HeaderText = "From";
                hdnInboxCnt.Value = activityList.Count.ToString();//BugID:48547
            }
            else
                grdMailBox.Columns[0].HeaderText = "To";

            for (int i = 0; i < activityList.Count; i++)
            {

                dr = dt.NewRow();
                if (MailType == "INBOX")
                {
                    dr["From"] = activityList[i].From_Address;
                    dr["ToAddress"] = activityList[i].Sent_To;
                }
                else
                {
                    dr["From"] = activityList[i].Sent_To;
                    dr["ToAddress"] = activityList[i].From_Address;
                }
                dr["Subject"] = activityList[i].Subject;
                dr["Date"] = UtilityManager.ConvertToLocal(activityList[i].Activity_Date_And_Time).ToString("dd-MMM-yyyy hh:mm tt");

                dr["Body"] = activityList[i].Message;
                dr["DateTime"] = UtilityManager.ConvertToLocal(activityList[i].Activity_Date_And_Time).ToString("dd-MMM-yyyy hh:mm tt");
                dr["Filename"] = activityList[i].Fax_File_Path;
                dt.Rows.Add(dr);

            }
            grdMailBox.DataSource = dt;
            grdMailBox.DataBind();

        }

        protected void rdbtnSentitems_CheckedChanged(object sender, EventArgs e)
        {
            grdMailBox.Visible = true;
            ifrmCompose.Visible = false;
            ActivityLogManager activityMngr = new ActivityLogManager();
            if (hdnEmailID.Value != string.Empty)
            {
                IList<ActivityLog> activityList = new List<ActivityLog>();
                if (sPatientPortal == "YES")
                    activityList = activityMngr.GetSentBoxEntries(hdnEmailID.Value);
                else
                {
                    string sPhyEmail = hdnEmailID.Value;
                    if (ClientSession.PhysicainDetails != null && ClientSession.PhysicainDetails.Count > 0)
                    {
                        if (ClientSession.PhysicainDetails[0].PhyEMail.Trim() != "")
                            sPhyEmail += "','" + ClientSession.PhysicainDetails[0].PhyEMail;
                        if (ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username.Trim() != "")
                        {
                            if (sPhyEmail != string.Empty)
                                sPhyEmail += "','" + ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username;
                            else
                                sPhyEmail = ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username;

                        }
                    }
                    activityList = activityMngr.GetSentBoxEntries(sPhyEmail);
                }
                fillMailBoxGrid(activityList, "SENTBOX");


            }
        }

        protected void rdbtnInbox_CheckedChanged(object sender, EventArgs e)
        {
            grdMailBox.Visible = true;
            ifrmCompose.Visible = false;
            ActivityLogManager activityMngr = new ActivityLogManager();
            if (hdnEmailID.Value != string.Empty)
            {

                IList<ActivityLog> activityList = new List<ActivityLog>();
                if (sPatientPortal == "YES")
                    activityList = activityMngr.GetInboxEntries(hdnEmailID.Value);
                else
                {
                    string sPhyEmail = hdnEmailID.Value;
                    if (ClientSession.PhysicainDetails != null && ClientSession.PhysicainDetails.Count > 0)
                    {
                        if (ClientSession.PhysicainDetails[0].PhyEMail.Trim() != "")
                            sPhyEmail += "','" + ClientSession.PhysicainDetails[0].PhyEMail;
                        if (ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username.Trim() != "")
                        {
                            if (sPhyEmail != string.Empty)
                                sPhyEmail += "','" + ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username;
                            else
                                sPhyEmail = ClientSession.PhysicainDetails[0].Physician_Other_EMail_Username;

                        }
                    }
                    activityList = activityMngr.GetInboxEntries(sPhyEmail);
                }
                fillMailBoxGrid(activityList, "INBOX");


            }
        }

        protected void rdbtnCompose_CheckedChanged(object sender, EventArgs e)
        {
            string sHumanMail = string.Empty;
            string sPhysicianMail = string.Empty;
            string HumaID = "";
            if (Request["PatientID"] != null && Request["EmailID"] != null)
            {
                sPhysicianMail = Request["EmailID"].ToString();
                HumaID = Request["PatientID"].ToString();
            }
            else if (ClientSession.PhysicianId != 0 || ClientSession.HumanId != 0)
            {
                ActivityLogManager activityMngr = new ActivityLogManager();
                if (ClientSession.PhysicianId != 0 && ClientSession.HumanId == 0)
                {
                    IList<PhysicianLibrary> ilstPhysicianLibrary = new List<PhysicianLibrary>();
                    ilstPhysicianLibrary = activityMngr.ilstPhysicianLibraryforGetMailID(ClientSession.PhysicianId);
                    if (ilstPhysicianLibrary.Count > 0)
                    {
                        sPhysicianMail = ilstPhysicianLibrary[0].PhyEMail.ToString();
                    }
                }
                else if (ClientSession.HumanId != 0 && ClientSession.PhysicianId != 0)
                {
                    IList<PhysicianLibrary> ilstPhysicianLibrary = new List<PhysicianLibrary>();
                    ilstPhysicianLibrary = activityMngr.ilstPhysicianLibraryforGetMailID(ClientSession.PhysicianId);
                    if (ilstPhysicianLibrary.Count > 0)
                    {
                        sPhysicianMail = ilstPhysicianLibrary[0].PhyEMail.ToString();
                    }
                    IList<Human> ilstHuman = new List<Human>();
                    ilstHuman = activityMngr.ilstHumanMail(ClientSession.HumanId);
                    if (ilstHuman.Count > 0)
                    {
                        sHumanMail = ilstHuman[0].EMail.ToString();

                    }
                }
            }
            grdMailBox.Visible = false;
            ifrmCompose.Visible = true;
            ifrmCompose.Attributes.Add("src", "frmSendHealthRecord.aspx?Encounter_ID=" + hdnEncounterID.Value + "&Human_ID=" + HumaID + "&LoginEmailID=" + sPhysicianMail + "&HumanEmailID=" + sHumanMail + "&Role=" + hdnRole.Value + "&IS_Patient_Portal=" + sPatientPortal);
            ifrmCompose.Attributes.Add("height", "100%");
            ifrmCompose.Attributes.Add("width", "100%");
        }

        protected void grdMailBox_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                GridDataItem item = (GridDataItem)e.Item;

                String fileName = item["Filename"].Text;
                if (fileName.Trim() != "" && fileName != "&nbsp;")
                {
                    string localPath = string.Empty;
                    string ftpServerIP = string.Empty;
                    string ftpUserName = string.Empty;
                    string ftpPassword = string.Empty;
                    string simagePathname = string.Empty;
                    string source = string.Empty;
                    string file_path = string.Empty;
                    string _fileName = string.Empty;

                    List<string> FilePaths = new List<string>();


                    localPath = System.Configuration.ConfigurationSettings.AppSettings["LocalPath"];
                    ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"].ToString()+ "//"  + System.Configuration.ConfigurationSettings.AppSettings["ftpMailpath"].ToString();
                       
                    ftpUserName = System.Configuration.ConfigurationSettings.AppSettings["ftpUserID"];
                    ftpPassword = System.Configuration.ConfigurationSettings.AppSettings["ftpPassword"];
                  

                    string localpath = Server.MapPath("atala-capture-download//" + Session.SessionID + "//MAILINBOX");
                    DirectoryInfo virdir = new DirectoryInfo(Server.MapPath("atala-capture-download//" + Session.SessionID + "//MAILINBOX"));
                    if (!virdir.Exists)
                    {
                        virdir.Create();
                    }
                    FileInfo[] file = virdir.GetFiles();
                    for (int i = 0; i < file.Length; i++)
                    {
                        File.Delete(file[i].FullName);
                    }
                    string[] files = fileName.Split('|');
                    FTPImageProcess ftpImage = new FTPImageProcess();

                    for (int i = 0; i < files.Length; i++)
                    {
                       // DirectoryInfo childDir = new DirectoryInfo(new FileInfo(files[i]).DirectoryName);
                        string[] sDirName = files[i].Split('/');
                        string ftpip = Path.Combine(ftpServerIP, sDirName[sDirName.Length-2]);
                        ftpImage.DownloadFromImageServer("0", ftpip, ftpUserName, ftpPassword, Path.GetFileName(files[i]), localpath);
                        string orig_image = localpath + "\\" + Path.GetFileName(files[i]);

                        FilePaths.Add(orig_image);
                    }

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                        zip.AddDirectoryByName("Files");
                        for (int filecount = 0; filecount < FilePaths.Count; filecount++)
                        {

                            zip.AddFile(FilePaths[filecount].ToString(), "Files");


                        }

                        // Append cookie
                        HttpCookie cookie = new HttpCookie("ExcelDownloadFlag");
                        cookie.Value = "Flag";
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.AppendCookie(cookie);
                        // end
                        Response.Clear();
                        Response.BufferOutput = false;
                        string zipName = String.Format("Attachment_{0}.zip", DateTime.Now.ToString("yyyyMMMddHHmmss"));
                        Response.ContentType = "application/zip";
                        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);

                        zip.Save(Response.OutputStream);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Downloaded", "{ sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }", true);
                        Response.End();
                    }



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Downloadedalert", "alert('No Files Available to download');{ sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }", true);
                }
            }

        }
        //[System.Web.Services.WebMethod]
        //public static string CreateSessionViaJavascript(string Message)
        //{
        //    Page objp = new Page();
        //    objp.Session["controlID"] = Message;
        //    return Message;
        //}
    }
}
