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
using System.Drawing;
using System.Reflection;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using AjaxControlToolkit;
using Telerik.Web.UI;
using System.Runtime.Serialization;
using Acurus.Capella.UI.UserControls;
using System.IO;
using EMRDirect.phiMail;
using Ionic.Zip;


namespace Acurus.Capella.UI
{
    public partial class frmPatientdata : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dtTable = new DataTable();
        DataRow dr = null;
        IList<Human> lsthumanID = new List<Human>();
      
        IList<ActivityLog> ActivityLogList = new List<ActivityLog>();
        ActivityLogManager ActivitylogMngr = new ActivityLogManager();
      
       // ArrayList aryAttachmentList = new ArrayList();
        IList<String> aryAttachmentList = new List<String>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientSession.FlushSession();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Added  by Saravanakumar on 06-09-2014
            IList<Human> lsthumanID = new List<Human>();
            HumanManager objHumanMngr = new HumanManager();
            Human objHuman = new Human();
            txtPatientname.Text = hdnAccountNo.Value;
            if (txtPatientname.Text == string.Empty)
            {
                return;
               
            }
            if (Session["lsthumanID"] != null)
                lsthumanID = (IList<Human>)Session["lsthumanID"];
            objHuman = objHumanMngr.GetById(Convert.ToUInt32(txtPatientname.Text));
            if (objHuman != null)
            {
                lsthumanID.Add(objHuman);
            }



            //IList<Human> lsthumanID = new List<Human>();
            if (dtTable.Rows.Count > 0)
                dtTable.Rows.Clear();
            if (dtTable.Columns.Count == 0)
            {
                dtTable.Columns.Add("Patient Account No");
                dtTable.Columns.Add("Patient Name");
                dtTable.Columns.Add("Patient DOB");
                dtTable.Columns.Add("Patient Gender");
            }
            //if (Session["lsthumanID"] != null)
            //    lsthumanID = (IList<Human>)Session["lsthumanID"];


            if (lsthumanID.Count>0)
            {
                Session["lsthumanID"] = lsthumanID;
                for (int i = 0; i < lsthumanID.Count; i++)
                {
                    dr = dtTable.NewRow();
                    dr["Patient Account No"] = lsthumanID[i].Id;
                    dr["Patient Name"] = lsthumanID[i].Last_Name + ", " + lsthumanID[i].First_Name;
                    dr["Patient DOB"] = lsthumanID[i].Birth_Date.ToString("dd-MMM-yyyy");
                    dr["Patient Gender"] = lsthumanID[i].Sex;
                    dtTable.Rows.Add(dr);
                }
                if (ds.Tables.Count == 0)
                    ds.Tables.Add(dtTable);

                grdHuman.DataSource = ds.Tables[0];
                grdHuman.DataBind();
                txtPatientname.Text = string.Empty;
                hdnAccountNo.Value = string.Empty;
            }



            //if (hdnAccountNo.Value != string.Empty && !lsthumanID.Any(a => a.Id == Convert.ToUInt64(hdnAccountNo.Value)))
            //{
                
            //    Human objhuman = new Human();
            //    objhuman.Id = Convert.ToUInt64(hdnAccountNo.Value);
            //    objhuman.Last_Name = hdnPatientName.Value;
                 
            //    objhuman.Birth_Date = Convert.ToDateTime(hdnPatientDOB.Value);
            //    objhuman.Sex = hdnPatientGender.Value;
            //    lsthumanID.Add(objhuman);
            //    Session["lsthumanID"] = lsthumanID;
               
                
            //    for (int i = 0; i < lsthumanID.Count; i++)
            //    {
            //        dr = dtTable.NewRow();
            //        dr["Patient Account No"] = lsthumanID[i].Id;
            //        dr["Patient Name"] = lsthumanID[i].Last_Name;
            //        dr["Patient DOB"] = lsthumanID[i].Birth_Date.ToString("dd-MMM-yyyy");
            //        dr["Patient Gender"] = lsthumanID[i].Sex;
            //        dtTable.Rows.Add(dr);
            //    }
            //    if (ds.Tables.Count == 0)
            //        ds.Tables.Add(dtTable);

            //    grdHuman.DataSource = ds.Tables[0];
            //    grdHuman.DataBind();
            //    txtPatientname.Text = string.Empty;
               
            //}

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            hdnSelectedPath.Value = string.Empty; 
            IList<ulong> lsthuman = new List<ulong>();
           // IList<ulong> lstEncounter = new List<ulong>();
            IList<Encounter> lstEncounter = new List<Encounter>();
            EncounterManager encMngr = new EncounterManager();

            if (Session["lsthumanID"] != null)
                lsthumanID = (IList<Human>)Session["lsthumanID"];

            

            if (lsthumanID.Count > 0)
            {
                for (int i = 0; i < lsthumanID.Count; i++)
                {
                    lsthuman.Add(lsthumanID[i].Id);
                }
            }
            if (lsthuman.Count > 0)
                lstEncounter = encMngr.GetEncounterUsingHumanIDlist(lsthuman);
            string sMyPath = string.Empty;
            ArrayList aryPrint = new ArrayList();
            //FileStream fs = null;
            frmClinicalSummary frmClin = new frmClinicalSummary();
            ArrayList aryPrintNew = new ArrayList();

            if (lstEncounter.Count > 0 && lsthuman.Count > 0)
            {
                for (int i = 0; i < lstEncounter.Count; i++)
                {
                    //aryPrint = frmClin.PrintClinicalSummary(lstEncounter[i], lsthuman[i], false, ref sMyPath, string.Empty, true, false);
                    aryPrint = frmClin.PrintClinicalSummary(lstEncounter[i].Id, lstEncounter[i].Human_ID, false, ref sMyPath, string.Empty, true, false);

                    if (aryPrint != null && aryPrint.Count > 0)
                    {
                        for (int j = 0; j < aryPrint.Count; j++)
                        {
                            aryPrintNew.Add(aryPrint[j]);
                        }
                        ActivityLog objActivityLog = new ActivityLog();

                        if (lstEncounter[i].Id>0)
                            objActivityLog.Encounter_ID = Convert.ToUInt32(lstEncounter[i].Id);
                        if (lstEncounter[i].Human_ID>0)
                            objActivityLog.Human_ID = Convert.ToUInt32(lstEncounter[i].Human_ID);
                        ActivityLogList.Add(objActivityLog);
                        Session["ActivityLog"] = ActivityLogList;
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "", "DisplayErrorMessage('1007011');", true);
                return;
            }
            string PDFPath = string.Empty;
            string XMlPath = string.Empty;
            if (aryPrintNew.Count > 0)
            {
                //PDFPath = aryPrintNew[1].ToString();
                XMlPath = aryPrintNew[0].ToString();
            }
            string listallfiles = string.Empty;
            for (int i = 0; i < aryPrintNew.Count; i++)
            {
                string[] Split = new string[] { Server.MapPath("Documents\\" + Session.SessionID) };
               // string[] fileName = aryPrintNew[i].ToString().Split(Split, StringSplitOptions.RemoveEmptyEntries);
                
               // if ( fileName[0].ToUpper().Contains(".XML"))
               // {
               // string sPath = "Documents\\" + Session.SessionID.ToString() + fileName[0].ToString();                   
               // Response.ContentType = "Application/xml";
               // string fPath = sPath.Substring(sPath.LastIndexOf("\\") + 1);
               // Response.AppendHeader("Content-Disposition", "attachment; filename=" + fPath);
               //// Response.TransmitFile(Server.MapPath(sPath));
               //}
               
                //if (aryPrintNew[i].ToString().EndsWith(".pdf") == true)
                //{
                //    string sPrintPathName = aryPrintNew[i].ToString();
                //    string[] FileName = sPrintPathName.Split(Split, StringSplitOptions.RemoveEmptyEntries);
                //    if (hdnSelectedPath.Value == string.Empty)
                //    {
                //        hdnSelectedPath.Value ="Documents\\" + Session.SessionID.ToString() + "\\" + FileName[0].ToString();
                //    }
                //    else
                //    {
                //        hdnSelectedPath.Value += "|"+ "Documents\\" + Session.SessionID.ToString() + "\\" + FileName[0].ToString();
                //    }

                //}
                if (aryPrintNew[i].ToString().EndsWith(".xml") == true)
                {
                    
                    string sPrintPathName = aryPrintNew[i].ToString();
                    string[] FileName = sPrintPathName.Split(Split, StringSplitOptions.RemoveEmptyEntries);
                    //LinkButton lblattachments = new LinkButton();
                    //lblattachments.ID = "lblAttachment" + i;
                    //lblattachments.Text = "Documents\\" + Session.SessionID.ToString() +  FileName[0].ToString();
                    //pnlAttachments.Controls.Add(lblattachments);
                    //aryAttachmentList.Add(lblattachments.Text);
                    string Filenm = "Documents\\" + Session.SessionID.ToString() + FileName[0].ToString();
                    aryAttachmentList.Add(Filenm);
                    if (i == 0)
                    {
                        //listallfiles = lblattachments.Text;
                        listallfiles = Filenm;
                    }
                    else
                    {
                        //listallfiles += "~"+lblattachments.Text ;
                        listallfiles = "~" + Filenm;

                    }
                    pnlAttachments.Controls.Add(new LiteralControl("<br />"));
                    Session["aryAttachmentList"] = aryAttachmentList;
                }
                
            }
            
            if (listallfiles != string.Empty)
            {
                string path = "Documents//" + Session.SessionID.ToString() +"//"+ System.Configuration.ConfigurationSettings.AppSettings["ClinicalSummaryPathName"] + "/stylesheet";
                DirectoryInfo ObjSearchDir = new DirectoryInfo(Server.MapPath(path));
                if (!ObjSearchDir.Exists)
                    ObjSearchDir.Create();
                ObjSearchDir.Parent.CreateSubdirectory("stylesheet");
                
                System.IO.File.Copy(Server.MapPath("SampleXML/CDA.xsl"), Server.MapPath(path+ "/CDA.xsl"), true);
                System.IO.File.Copy(Server.MapPath("SampleXML/CCR.xsl"), Server.MapPath(path + "/CCR.xsl"), true);
                hdnFileList.Value = listallfiles;
                DownLoadZIPFormateCATII(aryAttachmentList[0], (IList<string>)Session["aryAttachmentList"]);
            }
            
        }

        protected void btnSendSummary_Click(object sender, EventArgs e)
        {
            aryAttachmentList=(IList<string>)Session["aryAttachmentList"];
            IList<string> sRecList = new List<string>();
            string[] sListRec = txtRecAdd.Text.Split(new char[] { ',' });
            foreach(string element in sListRec)
            {
                sRecList.Insert(sRecList.Count, element);
                
            }
            ComposeEmail(sRecList, aryAttachmentList, txtMailText.Text, ClientSession.HumanId.ToString());
        }

        protected void btnClearall_Click(object sender, EventArgs e)
        {
            grdHuman.DataSource = null;
            grdHuman.DataBind();
            lsthumanID.Clear();
            ClientSession.FlushSession();
          
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            grdHuman.DataSource = null;
            grdHuman.DataBind();
            lsthumanID.Clear();
        }

        public void ComposeEmail(IList<string> sRecipient, IList<string> sAttachmentList, string sContent, string sSub)
        {
            PhiMailConnector pcConnection;

            try
            {
                PhiMailConnector.SetTrustAnchor((System.Configuration.ConfigurationSettings.AppSettings["phiMailCertficatepath"].ToString()));
                PhiMailConnector.SetCheckRevocation(false);
                pcConnection = new PhiMailConnector(System.Configuration.ConfigurationSettings.AppSettings["phiMailServer"].ToString(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["phiMailPortNo"]));
            }
            catch
            {
                // ex.Message;
                return;
            }
            try
            {
                bool send = true;
                pcConnection.AuthenticateUser(System.Configuration.ConfigurationSettings.AppSettings["phiMailUsername"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["phiMailPassword"].ToString());
                if (send)
                {
                    try
                    {
                        foreach (string rec_adderess in sRecipient)
                        {
                            pcConnection.AddRecipient(rec_adderess);
                        }
                    }
                    catch
                    {
                        //throw ex;
                    }
                    pcConnection.SetSubject(sSub);
                    if (sContent != string.Empty)
                    {
                        pcConnection.AddText(sContent);
                    }
                    foreach (string file in sAttachmentList) // To Attach All The Files With This MailMessage
                    {
                        FileInfo filename = new FileInfo(file);
                        pcConnection.AddCDA(File.ReadAllText(Server.MapPath(file)), filename.Name);
                    }
                    pcConnection.SetDeliveryNotification(true);
                    List<PhiMailConnector.SendResult> sendRes = pcConnection.Send();


                    if (sendRes[0].Succeeded)
                    {
                        
                        Activity_Log_Entry(sRecipient, sSub, sContent);
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Orders", "DisplayErrorMessage('1007007','','" + sendRes[0].Recipient + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMsg", "ShowFailure(" + sendRes[0].Recipient + "Description :" + sendRes[0].ErrorText.ToString() + ");", true);
                        pcConnection.Clear();
                    }
                }
            }
            catch 
            {
            }
            pcConnection.Close();

        }

        public void Activity_Log_Entry(IList<string> sRec, string sSub, string sMsg)
        {
            IList<ActivityLog> ilstActivityLogList = new List<ActivityLog>();
            ActivityLogList = (List<ActivityLog>)Session["ActivityLog"];
            if (ActivityLogList.Count > 0)
            {
                for (int i = 0; i < ActivityLogList.Count; i++)
                {
                    ActivityLog activity = new ActivityLog();
                    activity = (ActivityLog)ActivityLogList[i];
                    activity.Sent_To = sRec[0];
                    activity.Role = "Provider";
                    activity.Subject = sSub;
                    activity.Activity_Date_And_Time = Convert.ToDateTime(ClientSession.LocalTime);
                    activity.Message = sMsg;
                    activity.Activity_Type = "CCD Export";
                    activity.Activity_By = ClientSession.UserName;
                    ilstActivityLogList.Add(activity);
                }
                
            }
            ActivitylogMngr.SaveActivityLogManager(ilstActivityLogList, string.Empty);
        }

        public void DownLoadZIPFormateCATII(string DirName,IList<string> filelist)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;


                DirectoryInfo directorySelected = new DirectoryInfo(Server.MapPath(DirName));
                //DirectoryInfo[] diArr = directorySelected.GetDirectories();


                //zip.AddDirectoryByName(directorySelected.FullName.Substring(directorySelected.FullName.LastIndexOf("\\") + 1));

                foreach (FileInfo fileToCompress in directorySelected.Parent.GetFiles("*.xml"))
                {
                    foreach (string filename in filelist)
                    {
                        if (Server.MapPath(filename) == fileToCompress.FullName)
                        {
                            string filePath = fileToCompress.FullName;
                            zip.AddFile(filePath, "");
                        }
                    }
                }

                Response.Clear();
                Response.BufferOutput = false;
                //string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                string zipName = "CCD.zip"; //String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }


        }

        protected void btnViewXML_Click(object sender, EventArgs e)
        {
            string concat_names = string.Empty;
            IList<string> filelist_local = new List<string>();
            filelist_local = (IList<string>)Session["aryAttachmentList"];
            if (filelist_local == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('1007010');", true);
                return;
            }
            for(int i=0;i< filelist_local.Count;i++)
            {
                if (i==0)
                {
                    concat_names = filelist_local[i];
                }
                else
                {
                    concat_names += "~" + filelist_local[i];
                }
            }
            hdnFileList.Value = concat_names;
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "OpenPDF();", true);
        }
      
    }
}
