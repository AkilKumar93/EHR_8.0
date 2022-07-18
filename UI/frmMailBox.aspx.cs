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
using Acurus.Capella.UI;
using Telerik.Web.UI;

using OpenPop.Pop3;
using OpenPop.Mime;





namespace Acurus.Capella.UI
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
                //if (grdMailBox.DataSource == null)
                //{
                //    grdMailBox.DataSource = new string[] { };
                //    grdMailBox.DataBind();
                //}
                if (hdnEmailID.Value != string.Empty)
                {
                    //IList<ActivityLog> activityList = new List<ActivityLog>();
                    //activityList = activityMngr.GetInboxEntries(hdnEmailID.Value);
                    //if (activityList.Count > 0)
                    //{
                    //    fillMailBoxGrid(activityList, "INBOX");
                    //}


                    //Pop3Client connection = new Pop3Client();   start here...


                    ////if(connection.Connected)
                    ////{
                    ////    connection.Disconnect();
                    ////}
                    //string serverURL = "pop.bizmail.yahoo.com";

                    //int port = 995;
                    //bool ssl = true;

                    //connection.Connect(serverURL, port, ssl);

                    //if (ilstPhysicianLibrary.Count > 0)
                    //{
                    //    string userName = ilstPhysicianLibrary[0].PhyEMail.ToString();
                    //    string password = ilstPhysicianLibrary[0].Physician_EMail_Password.ToString();

                    //   //CredentialCache credentialCache = new CredentialCache
                    //   //{
                    //   // new Uri($serverURL), "Basic";
                    //   // new NetworkCredential("userName", "password");
                    //   //};

                    //    connection.Authenticate(userName, password);

                    //    int messageCount = connection.GetMessageCount();

                    //    IList<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>();
                    //    for (int iCount = messageCount; iCount > 0; iCount--)
                    //    {
                    //        allMessages.Add(connection.GetMessage(iCount));
                    //    }

                    //}...

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
                            if (ClientSession.PhysicainDetails[0].Physician_MDoffice_EMail_Username.Trim() != "")
                            {
                                if (sPhyEmail != string.Empty)
                                    sPhyEmail += "','" + ClientSession.PhysicainDetails[0].Physician_MDoffice_EMail_Username;
                                else
                                    sPhyEmail = ClientSession.PhysicainDetails[0].Physician_MDoffice_EMail_Username;

                            }
                        }
                        activityList = activityMngr.GetInboxEntries(sPhyEmail);
                    }
                    //if (activityList!=null && activityList.Count > 0) //BugID : 65961
                    //{
                        fillMailBoxGrid(activityList, "INBOX");
                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "stopload", "{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                }
            }


        }


        public void fillMailBoxGrid(IList<ActivityLog> activityList, string MailType)
        {
            //   grdMailBox.DataSource = null;
            //DataTable dt = new DataTable();
            //dt.Columns.Add("From", typeof(string));
            //dt.Columns.Add("Subject", typeof(string));
            //dt.Columns.Add("Date", typeof(string));
            //dt.Columns.Add("ToAddress", typeof(string));
            //dt.Columns.Add("Body", typeof(string));
            //dt.Columns.Add("DateTime", typeof(string));


            // DataRow dr;
            //if (MailType == "INBOX")
            //{
            //    grdMailBox.Columns[0].HeaderText = "From";
            //    hdnInboxCnt.Value = activityList.Count.ToString();//BugID:48547
            //}
            //else
            //    grdMailBox.Columns[0].HeaderText = "To";

            //for (int i = 0; i < activityList.Count; i++)
            //{

            //    dr = dt.NewRow();
            //    if (MailType == "INBOX")
            //    {
            //        dr["From"] = activityList[i].From_Address;
            //        dr["ToAddress"] = activityList[i].Sent_To;
            //    }
            //    else
            //    {
            //        dr["From"] = activityList[i].Sent_To;
            //        dr["ToAddress"] = activityList[i].From_Address;
            //    }
            //    dr["Subject"] = activityList[i].Subject;
            //    dr["Date"] = UtilityManager.ConvertToLocal(activityList[i].Activity_Date_And_Time).ToString("dd-MMM-yyyy hh:mm tt");

            //    dr["Body"] = activityList[i].Message;
            //    dr["DateTime"] = UtilityManager.ConvertToLocal(activityList[i].Activity_Date_And_Time).ToString("dd-MMM-yyyy hh:mm tt");
            //    dt.Rows.Add(dr);

            //}
            //grdMailBox.DataSource = dt;
            //grdMailBox.DataBind();
            try
            {
                Pop3Client pop3Client;
                ArrayList mesagecontent = new ArrayList();


                PhysicianLibrary lstphysician = new PhysicianLibrary();
                PhysicianManager obj = new PhysicianManager();
                lstphysician = obj.GetById(Convert.ToUInt64(ClientSession.PhysicianId));
                if (lstphysician != null)
                {
                    string ispop = System.Configuration.ConfigurationSettings.AppSettings["IsPop3Client"].ToString();
                    if (ispop.Trim().ToUpper() == "N")
                    {
                        grdMailBox.DataSource = null;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("From", typeof(string));
                        dt.Columns.Add("Subject", typeof(string));
                        dt.Columns.Add("Date", typeof(string));
                        dt.Columns.Add("ToAddress", typeof(string));
                        dt.Columns.Add("Message", typeof(string));
                        dt.Columns.Add("DateSent", typeof(string));
                        dt.Columns.Add("MessageNumber");
                        dt.Columns.Add("MsgId");
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

                            dr["Message"] = activityList[i].Message;
                            dr["DateSent"] = UtilityManager.ConvertToLocal(activityList[i].Activity_Date_And_Time).ToString("dd-MMM-yyyy hh:mm tt");

                            dr["MessageNumber"] = "0";


                            dr["MsgId"] = "0";
                            dr["Filename"] = activityList[i].Fax_File_Path;

                            dt.Rows.Add(dr);

                        }
                        grdMailBox.DataSource = dt;
                        grdMailBox.DataBind();
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "stopload", "{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    }
                    else
                    {
                        if (MailType == "INBOX")
                        {
                            if (Session["Pop3Client"] == null)
                            {
                                pop3Client = new Pop3Client();
                                if (lstphysician.Mail_Server_Address != "")
                                {
                                    pop3Client.Connect(lstphysician.Mail_Server_Address.Split('|')[0], Convert.ToInt32(lstphysician.Mail_Server_Address.Split('|')[1]), true);//"pop.mail.yahoo.com", 995, true);
                                    if (lstphysician.PhyEMail.Trim() != "" && lstphysician.Physician_EMail_Password.Trim() != "")
                                    {
                                        pop3Client.Authenticate(lstphysician.PhyEMail, lstphysician.Physician_EMail_Password);//"opsnbjvjqwiltctu");
                                        Session["Pop3Client"] = pop3Client;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                pop3Client = (Pop3Client)Session["Pop3Client"];
                            }
                            int count = pop3Client.GetMessageCount();
                          
                            DataTable dtMessages = new DataTable();
                            dtMessages.Columns.Add("MessageNumber");
                            dtMessages.Columns.Add("From");
                            dtMessages.Columns.Add("Subject");
                            dtMessages.Columns.Add("DateSent");
                            dtMessages.Columns.Add("Date");
                            dtMessages.Columns.Add("Message");
                            dtMessages.Columns.Add("MsgId");
                            dtMessages.Columns.Add("ToAddress", typeof(string));
                            dtMessages.Columns.Add("Filename", typeof(string));
                            int counter = 0;
                            for (int i = count; i >= 1; i--)
                            {

                                OpenPop.Mime.Message message = pop3Client.GetMessage(i, null);

                                dtMessages.Rows.Add();
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["From"] = message.Headers.From;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["ToAddress"] = lstphysician.PhyEMail;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["MessageNumber"] = i;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["Subject"] = message.Headers.Subject;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["DateSent"] = message.Headers.DateSent;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["Date"] = message.Headers.DateSent;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["MsgId"] = message.Headers.MessageId.ToString();
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["Message"] = string.Empty;
                                dtMessages.Rows[dtMessages.Rows.Count - 1]["Filename"] = string.Empty;
                               

                                counter++;
                                int MailCount = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["MailCount"].ToString());
                                if (counter > MailCount)
                                {
                                    break;
                                }
                                // }
                            }
                            grdMailBox.DataSource = dtMessages;
                            grdMailBox.DataBind();

                            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "stopload", "{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                        }
                        else
                        {
                            grdMailBox.DataSource = null;
                            DataTable dt = new DataTable();
                            dt.Columns.Add("From", typeof(string));
                            dt.Columns.Add("Subject", typeof(string));
                            dt.Columns.Add("Date", typeof(string));
                            dt.Columns.Add("ToAddress", typeof(string));
                            dt.Columns.Add("Message", typeof(string));
                            dt.Columns.Add("DateSent", typeof(string));
                            dt.Columns.Add("MessageNumber");
                            dt.Columns.Add("MsgId");
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

                                dr["Message"] = activityList[i].Message;
                                dr["DateSent"] = UtilityManager.ConvertToLocal(activityList[i].Activity_Date_And_Time).ToString("dd-MMM-yyyy hh:mm tt");

                                dr["MessageNumber"] = "0";


                                dr["MsgId"] = "0";


                                dt.Rows.Add(dr);

                            }
                            grdMailBox.DataSource = dt;
                            grdMailBox.DataBind();
                            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "stopload", "{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                        }
                    }
                }
            }
            catch 
            {

            }
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
                        if (ClientSession.PhysicainDetails[0].Physician_MDoffice_EMail_Username.Trim() != "")
                        {
                            if (sPhyEmail != string.Empty)
                                sPhyEmail += "','" + ClientSession.PhysicainDetails[0].Physician_MDoffice_EMail_Username;
                            else
                                sPhyEmail = ClientSession.PhysicainDetails[0].Physician_MDoffice_EMail_Username;

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
            if (Request["PatientID"] != null && Request["EmailID"] != null)
            {
                sPhysicianMail = Request["EmailID"].ToString();
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
            ifrmCompose.Attributes.Add("src", "frmSendHealthRecord.aspx?Encounter_ID=" + hdnEncounterID.Value + "&LoginEmailID=" + sPhysicianMail + "&HumanEmailID=" + sHumanMail + "&Role=" + hdnRole.Value + "&IS_Patient_Portal=" + sPatientPortal);
            ifrmCompose.Attributes.Add("height", "100%");
            ifrmCompose.Attributes.Add("width", "100%");
        }
        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public static string CreateSessionViaJavascript(string Message)
        //{
        //    Page objp = new Page();
        //    objp.Session["controlID"] = Message;
        //    return Message;
        //}
    }
}
