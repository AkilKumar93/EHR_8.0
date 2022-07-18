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
using System.IO;
using Telerik.Web.UI;
using System.Net;

namespace Acurus.Capella.PatientPortal
{
    public partial class frmPrintPDF : System.Web.UI.Page
    {
        public RadTab tab1 = null;
        ulong Human_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //divLoading.Style.Add(HtmlTextWriterStyle.Display, "block");

            if (Request["PageTitle"] != null)
            {
                Page.Title = Request["PageTitle"].ToString();
            }
            if (!IsPostBack)
            {

                
                if (Request["SI"] != null)
                {
                    SelectedItems.Value = Request["SI"].ToString();
                }
                if (Request["Human_ID"] != null)
                {
                    Human_id = Convert.ToUInt64(Request["Human_ID"]);

                }
                else
                {
                    Human_id = ClientSession.HumanId;
                }
                if (Request["FromOrder"] != null)
                    btnprint.Text = "Print";
                else if (Request["ButtonName"] != null && Request["ButtonName"] != "")
                {
                    btnprint.Text = Request["ButtonName"].ToString();
                    if (Request["PDFLOADHeight"] != null && Request["PDFLOADHeight"] != "")
                        PDFLOAD.Style.Add(HtmlTextWriterStyle.Height, Request["PDFLOADHeight"].ToString());
                }
                else
                    btnprint.Text = "Print Chart";

                if (ClientSession.UserPermissionDTO != null && ClientSession.UserPermissionDTO.Scntab != null)
                {
                    var scn_id = (from p in ClientSession.UserPermissionDTO.Scntab where p.SCN_Name == "frmEFax" select p).ToList();
                    if (scn_id.Count() > 0)
                    {
                        var EnableEFax = from p in ClientSession.UserPermissionDTO.Screens where p.SCN_ID == Convert.ToInt32(scn_id[0].SCN_ID) && p.Permission == "U" select p;
                        if (EnableEFax.Count() > 0)
                            btnSendfax.Enabled = true;
                        else
                            btnSendfax.Enabled = false;
                    }
                   
                }


                if (SelectedItems.Value.Trim() != string.Empty)
                {
                    if (SelectedItems.Value.Contains('|') == true)
                    {
                        string[] strSplit = SelectedItems.Value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in strSplit)
                        {
                            if (Request["Location"].ToUpper() == "DYNAMIC")
                            {
                                string[] index = null;
                                tab1 = new RadTab();
                                index = s.ToString().Split('\\');
                                //string[] index = SelectedItems.Value.Split('\\');
                                string name = index[index.Length - 1];
                                tab1.Text = name;
                                RadTabStrip2.Tabs.Add(tab1);
                                tab1.PageViewID = RadPageView1.ID;
                            }
                            else if (Request["Location"].ToUpper() == "STATIC")
                            {
                                tab1 = new RadTab();
                                if (SelectedItems.Value.Contains("Vaccination Information Statement"))
                                {
                                    string[] tabname = s.ToString().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                                    tab1.Text = tabname[tabname.Count() - 1];
                                    tab1.Value = s.ToString();
                                }
                                else
                                {
                                    tab1.Text = s.ToString();
                                }
                                RadTabStrip2.Tabs.Add(tab1);
                                tab1.PageViewID = RadPageView1.ID;
                            }

                            else if (Request["Location"].ToString().ToUpper() == "EV")
                            {
                                string[] index = null;
                                tab1 = new RadTab();
                                index = s.ToString().Split('\\');
                                string name = index[index.Length - 1];
                                tab1.Text = Path.GetFileName(s); ;
                                tab1.Value = s;
                                RadTabStrip2.Tabs.Add(tab1);
                                tab1.PageViewID = RadPageView1.ID;
                                tab1.Attributes.Add("HumanID", Human_id.ToString());
                            }
                        }
                        if (Request["Location"] != null)
                        {
                            if (Request["Location"].ToString().ToUpper() == "STATIC")
                            {
                                if (SelectedItems.Value.Contains("Vaccination Information Statement"))
                                {
                                    PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + strSplit[0].ToString() + "&SI=" + SelectedItems.Value.ToString() + "&Location=" + Request["Location"].ToString());
                                    FaxCurrentFileName.Value = strSplit[0].ToString();
                                }
                                else
                                {
                                    PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("Documents\\Physician_Specific_Documents\\Patient Education\\" + strSplit[0].ToString() + ".pdf") + "&SI=" + strSplit[0].ToString() + "&Location=" + Request["Location"].ToString());
                                    FaxCurrentFileName.Value = Server.MapPath("Documents\\Physician_Specific_Documents\\Patient Education\\" + strSplit[0].ToString() + ".pdf");
                                }
                            }

                            else if (Request["Location"].ToString().ToUpper() == "EV")
                            {

                                string ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
                                string ftpUserName = System.Configuration.ConfigurationSettings.AppSettings["ftpUserID"];
                                string ftpPassword = System.Configuration.ConfigurationSettings.AppSettings["ftpPassword"];
                                string grouplocalPath = Server.MapPath("atala-capture-download//" + Session.SessionID + "//EV");
                                DirectoryInfo dir = new DirectoryInfo(grouplocalPath);
                                if (!dir.Exists)
                                {
                                    dir.Create();
                                }
                                FileInfo[] file = dir.GetFiles();
                                for (int i = 0; i < file.Length; i++)
                                {
                                    File.Delete(file[i].FullName);
                                }
                                string[] files = Directory.GetFiles(grouplocalPath);
                                FTPImageProcess ftpImage = new FTPImageProcess();
                                if (Human_id == 0)
                                    Human_id = ClientSession.HumanId;

                                ftpImage.DownloadFromImageServer(Human_id.ToString(), ftpServerIP, ftpUserName, ftpPassword, Path.GetFileName(strSplit[0]), grouplocalPath);
                                string orig_image = grouplocalPath + "\\" + Path.GetFileName(strSplit[0]);
                                string FileLocalPath = orig_image;
                                PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + FileLocalPath + "&SI=" + strSplit[0].ToString() + "&Location=" + Request["Location"].ToString() + "&Human_ID=" + Human_id + "&PageTitle=Eligibility Verification - Response File");
                                FaxCurrentFileName.Value = FileLocalPath;
                            }
                            else if (Request["Location"].ToString().ToUpper() == "DYNAMIC")
                            {
                                PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("~" + strSplit[0].ToString()) + "&SI=" + Request["SI"].ToString() + "&Location=" + Request["Location"].ToString());
                                FaxCurrentFileName.Value = Server.MapPath("~" + strSplit[0].ToString());
                            }

                        }
                    }
                    else
                    {
                        if (Request["Location"] != null)
                        {
                            if (Request["Location"].ToString().ToUpper() == "STATIC")
                            {
                                tab1 = new RadTab();
                                if (SelectedItems.Value.Contains("Vaccination Information Statement"))
                                {
                                    string[] tabname = SelectedItems.Value.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                                    tab1.Text = tabname[tabname.Count() - 1];
                                    tab1.Value = SelectedItems.Value;
                                }
                                else
                                {
                                    tab1.Text = SelectedItems.Value;
                                }
                                RadTabStrip2.Tabs.Add(tab1);
                                tab1.PageViewID = RadPageView1.ID;
                                if (SelectedItems.Value.Contains("Vaccination Information Statement"))
                                {
                                    PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + SelectedItems.Value + "&SI=" + SelectedItems.Value.ToString() + "&Location=" + Request["Location"].ToString());
                                    FaxCurrentFileName.Value = SelectedItems.Value;
                                }
                                else
                                {
                                    PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("Documents\\Physician_Specific_Documents\\Patient Education\\" + SelectedItems.Value + ".pdf") + "&SI=" + SelectedItems.Value.ToString() + "&Location=" + Request["Location"].ToString());
                                    FaxCurrentFileName.Value = Server.MapPath("Documents\\Physician_Specific_Documents\\Patient Education\\" + SelectedItems.Value + ".pdf");
                                }
                            }
                            else if (Request["Location"].ToString().ToUpper() == "DYNAMIC")
                            {

                                tab1 = new RadTab();
                                string[] index = SelectedItems.Value.Split('\\');
                                string name = index[index.Length - 1];
                                tab1.Text = name;
                                RadTabStrip2.Tabs.Add(tab1);
                                tab1.PageViewID = RadPageView1.ID;
                                if (Request["SI"].ToString().ToUpper().Contains("SUMMARY"))
                                {
                                    tab1.Visible = false;
                                    btnprint.Visible = false;
                                }

                                PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("~" + SelectedItems.Value) + "&SI=" + SelectedItems.Value.ToString() + "&Location=" + Request["Location"].ToString());
                                FaxCurrentFileName.Value = Server.MapPath("~" + SelectedItems.Value);

                            }

                            else if (Request["Location"].ToString().ToUpper() == "EV")
                            {

                                tab1 = new RadTab();
                                string[] index = SelectedItems.Value.Split('\\');
                                string name = index[index.Length - 1];
                                tab1.Text = Path.GetFileName(SelectedItems.Value);
                                RadTabStrip2.Tabs.Add(tab1);
                                tab1.PageViewID = RadPageView1.ID;
                                if (Request["SI"].ToString().ToUpper().Contains("SUMMARY"))
                                {
                                    tab1.Visible = false;
                                    btnprint.Visible = false;
                                }

                                string ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
                                string ftpUserName = System.Configuration.ConfigurationSettings.AppSettings["ftpUserID"];
                                string ftpPassword = System.Configuration.ConfigurationSettings.AppSettings["ftpPassword"];
                                string grouplocalPath = Server.MapPath("atala-capture-download//" + Session.SessionID + "//EV");
                                DirectoryInfo dir = new DirectoryInfo(grouplocalPath);
                                if (!dir.Exists)
                                {
                                    dir.Create();
                                }
                                FileInfo[] file = dir.GetFiles();
                                for (int i = 0; i < file.Length; i++)
                                {
                                    File.Delete(file[i].FullName);
                                }
                                string[] files = Directory.GetFiles(grouplocalPath);
                                FTPImageProcess ftpImage = new FTPImageProcess();
                                if (Human_id == 0)
                                    Human_id = ClientSession.HumanId;
                                ftpImage.DownloadFromImageServer(Human_id.ToString(), ftpServerIP, ftpUserName, ftpPassword, Path.GetFileName(Request["SI"].ToString()), grouplocalPath);
                                string orig_image = grouplocalPath + "\\" + Path.GetFileName(SelectedItems.Value);
                                string FileLocalPath = orig_image;
                                PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + FileLocalPath + "&SI=" + Request["SI"].ToString() + "&Location=" + Request["Location"].ToString() + "&Human_ID=" + Human_id + "&PageTitle=Eligibility Verification - Response File");
                                FaxCurrentFileName.Value = FileLocalPath;

                            }

                            else if (Request["Location"].ToUpper() == "CHART")
                            {
                                PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("Documents\\" + Session.SessionID + "\\" + SelectedItems.Value) + "&SI=" + SelectedItems.Value.ToString() + "&Location=" + Request["Location"].ToString());
                                FaxCurrentFileName.Value = Server.MapPath("Documents\\" + Session.SessionID + "\\" + SelectedItems.Value);
                                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                            }
                        }

                    }
                    if (Request.QueryString["pdf"] != null)
                    {

                        string strPdf = Request.QueryString["pdf"].ToString();
                        FileStream fs = null;
                        BinaryReader br = null;
                        byte[] data = null;

                        try
                        {

                            fs = new FileStream(strPdf.Replace("~", ""), FileMode.Open, FileAccess.Read, FileShare.Read);
                            br = new BinaryReader(fs, System.Text.Encoding.Default);
                            data = new byte[Convert.ToInt32(fs.Length)];
                            br.Read(data, 0, data.Length);
                            Response.Clear();
                            if (Request["Location"] == "CHART")
                            {
                                Response.ContentType = "image/png";
                            }
                            else
                            {
                                Response.ContentType = "application/pdf";
                            }
                            Response.AddHeader("Content-Length", fs.Length.ToString());

                            Response.BinaryWrite(data);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                        finally
                        {
                            if (fs != null)
                            {
                                fs.Close();
                                fs.Dispose();
                            }
                            br.Close();
                            data = null;
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "RadAlertScript", "ShowMessage('" + Request.QueryString["pdf"] + "');", true);
                    }

                }

                #region Summary Of Care

                if (Request["ParentForm"] != null && Request["ParentForm"] == "PatientChart")
                {
                    this.Title = "Summary Of Care";
                    string localPath = System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"];
                    string ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
                    string ftpUserName = System.Configuration.ConfigurationSettings.AppSettings["ftpUserID"];
                    string ftpPassword = System.Configuration.ConfigurationSettings.AppSettings["ftpPassword"];
                    FTPImageProcess _ftpImageProcess = new FTPImageProcess();
                    string file_path = Request.QueryString["FilePath"].ToString().Replace("HASHSYMBOL", "#");

                    if (file_path != string.Empty)
                    {
                        string simagePathname = file_path;
                        string _fileName = Path.GetFileName(file_path);
                        bool Is_Exist_In_Local = false;
                        DirectoryInfo localDirInfo = new DirectoryInfo(localPath + "\\Summary_Of_Care");
                        if (!localDirInfo.Exists)
                        {
                            localDirInfo.Create();
                        }
                        FileInfo[] pdfFiles = localDirInfo.GetFiles("*.pdf");
                        if (pdfFiles.Length > 0)
                        {
                            foreach (FileInfo tempFile in pdfFiles)
                            {
                                if (tempFile.Name == _fileName)
                                {
                                    Is_Exist_In_Local = true;
                                    simagePathname = localPath + "\\Summary_Of_Care\\" + _fileName;
                                    break;
                                }
                            }
                        }

                        if (!Is_Exist_In_Local)
                        {
                            if (_ftpImageProcess.DownloadFromImageServer(ClientSession.HumanId.ToString(), ftpServerIP, ftpUserName, ftpPassword, _fileName, localPath + "\\Summary_Of_Care"))
                            {
                                simagePathname = localPath + "\\Summary_Of_Care\\" + _fileName;
                            }

                        }
                        if (simagePathname != string.Empty)
                        {

                            DirectoryInfo virdir = new DirectoryInfo(Page.MapPath("atala-capture-download/" + Session.SessionID + "/Summary_Of_Care"));
                            if (!virdir.Exists)
                            {
                                virdir.Create();
                            }
                            FileInfo[] file = virdir.GetFiles();
                            for (int i = 0; i < file.Length; i++)
                            {
                                File.Delete(file[i].FullName);
                            }
                            string filename = "atala-capture-download/" + Session.SessionID + "/Summary_Of_Care/" + _fileName;
                            string filepath = Page.MapPath(filename);
                            File.Copy(simagePathname, filepath, true);
                            PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?ParentForm=PatientChart" + "&FilePath=" + Request.QueryString["FilePath"] + "&PdfPath=" + filepath);
                            FaxCurrentFileName.Value = filepath;
                            if (Request["PdfPath"] != null && Request["PdfPath"] != string.Empty)
                            {
                                string strPdf = Request.QueryString["PdfPath"].ToString();
                                FileStream fs = null;
                                BinaryReader br = null;
                                byte[] data = null;
                                try
                                {

                                    fs = new FileStream(strPdf, FileMode.Open, FileAccess.Read, FileShare.Read);
                                    br = new BinaryReader(fs, System.Text.Encoding.Default);
                                    data = new byte[Convert.ToInt32(fs.Length)];
                                    br.Read(data, 0, data.Length);
                                    Response.Clear();
                                    Response.ContentType = "application/pdf";
                                    Response.BinaryWrite(data);
                                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                                }
                                catch (Exception ex)
                                {
                                    Response.Write(ex.Message);
                                }
                                finally
                                {
                                    fs.Close();
                                    fs.Dispose();
                                    br.Close();
                                    data = null;
                                }
                            }
                        }
                    }
                }

                #endregion
                RadTabStrip2.Enabled = true;
            }


        }

        protected void RadTabStrip2_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (Request["Location"] != null)
            {
                if (Request["Location"].ToString().ToUpper() == "STATIC")
                {
                    if (Request["SI"].Contains("Vaccination Information Statement"))
                    {
                        PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + e.Tab.Value + "&SI=" + e.Tab.Value + "&Location=" + Request["Location"].ToString());
                        FaxCurrentFileName.Value = e.Tab.Value;
                    }
                    else
                    {
                        PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("Documents\\Physician_Specific_Documents\\Patient Education\\" + e.Tab.Text + ".pdf") + "&SI=" + e.Tab.Text + "&Location=" + Request["Location"].ToString());
                        FaxCurrentFileName.Value = Server.MapPath("Documents\\Physician_Specific_Documents\\Patient Education\\" + e.Tab.Text + ".pdf");
                    }
                }
                else if (Request["Location"].ToString().ToUpper() == "DYNAMIC")
                {
                    PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + Server.MapPath("Documents\\" + Session.SessionID + "\\" + e.Tab.Text) + "&SI=" + e.Tab.Text + "&Location=" + Request["Location"].ToString());
                    FaxCurrentFileName.Value = Server.MapPath("Documents\\" + Session.SessionID + "\\" + e.Tab.Text);
                }

                else if (Request["Location"].ToString().ToUpper() == "EV")
                {

                    string ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
                    string ftpUserName = System.Configuration.ConfigurationSettings.AppSettings["ftpUserID"];
                    string ftpPassword = System.Configuration.ConfigurationSettings.AppSettings["ftpPassword"];
                    string grouplocalPath = Server.MapPath("atala-capture-download//" + Session.SessionID + "//EV");
                    DirectoryInfo dir = new DirectoryInfo(grouplocalPath);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    FileInfo[] file = dir.GetFiles();
                    for (int i = 0; i < file.Length; i++)
                    {
                        File.Delete(file[i].FullName);
                    }
                    string[] files = Directory.GetFiles(grouplocalPath);
                    FTPImageProcess ftpImage = new FTPImageProcess();
                    if (Human_id == 0)
                        Human_id = Convert.ToUInt64(e.Tab.Attributes["HumanID"]);

                    ftpImage.DownloadFromImageServer(Human_id.ToString(), ftpServerIP, ftpUserName, ftpPassword, Path.GetFileName(e.Tab.Value), grouplocalPath);
                    string orig_image = grouplocalPath + "\\" + Path.GetFileName(e.Tab.Value);
                    string FileLocalPath = orig_image;
                    PDFLOAD.Attributes.Add("src", "frmPrintPDF.aspx?pdf=" + FileLocalPath + "&SI=" + e.Tab.Text.ToString() + "&Location=" + Request["Location"].ToString() + "&Human_ID=" + Human_id + "&PageTitle=Eligibility Verification - Response File");
                    FaxCurrentFileName.Value = FileLocalPath;
                }
            }
            if (Request.QueryString["pdf"] != null)
            {
                string strPdf = Request.QueryString["pdf"].ToString();
                // System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("Documents\\PatientEducationMaterials\\" + strPdf + ".pdf"), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                FileStream fs = null;
                BinaryReader br = null;
                byte[] data = null;
                try
                {

                    fs = new FileStream(strPdf, FileMode.Open, FileAccess.Read, FileShare.Read);
                    br = new BinaryReader(fs, System.Text.Encoding.Default);
                    data = new byte[Convert.ToInt32(fs.Length)];
                    br.Read(data, 0, data.Length);
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(data);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                    }
                    br.Close();
                    data = null;
                }
            }
        }


    }
}
