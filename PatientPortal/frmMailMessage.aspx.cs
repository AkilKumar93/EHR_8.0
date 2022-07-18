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
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace Acurus.Capella.PatientPortal
{
    public partial class frmMailMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["controlID"] != null)
                //{
                //    Session["Content"] = Session["controlID"];
                //    txtMessage.Text = Session["Content"].ToString();
                //    Session.Remove("controlID");
                //}
                hdnRole.Value = Request["Role"].ToString();
                if (Request["BodyMessage"] != null)
                {
                    byte[] btArrayASCII = Convert.FromBase64String(Request["BodyMessage"].ToString());
                    //txtMessage.Text=  ASCIIEncoding.ASCII.GetString(btArrayASCII).Replace("&amp;","&");

                    string strContent1 = ASCIIEncoding.ASCII.GetString(btArrayASCII).Replace("&amp;", "&");
                    //string[] tokens = strContent1.Split(new string[] { "Body : " }, 2, 0);

                    string[] tokens = strContent1.Split(new string[] { "Body : " }, Regex.Matches(strContent1, "Body : ").Count + 1, 0);


                    string strContent = tokens[tokens.Count() - 1].ToString();

                    //string strContent = strContent1.Substring(strContent1.LastIndexOf("Body"), strContent1.Length - strContent1.LastIndexOf("Body"));
                    string[] sOutput = strContent1.Split('\n');
                    string sValue = string.Empty;
                    string sFinalvalue = string.Empty;
                    for (int i = 0; i < sOutput.Count(); i++)
                    {
                        sValue = string.Empty;
                        string[] sSplit = sOutput[i].ToString().Split(new string[] { "Body : " }, Regex.Matches(sOutput[i].ToString(), "Body : ").Count + 1, 0);
                        if (sSplit.Count() > 0)
                        {
                            for (int j = 0; j < sSplit.Count(); j++)
                            {
                                sValue = string.Empty;
                                if (sSplit[j].ToString().TrimEnd() != "Body :")
                                {
                                    var vv = (from p in sSplit[j].Split(' ') where p.ToString().TrimStart().StartsWith("www.") || p.ToString().TrimStart().StartsWith("https:") || p.ToString().TrimStart().StartsWith("http:") || p.ToString().TrimStart().StartsWith("ftp:") select p).ToArray();
                                    if (vv.Length > 0)
                                    {
                                        string sURL = string.Empty;
                                        sValue = sSplit[j].ToString();
                                        for (int k = 0; k < vv.Length; k++)
                                        {
                                            if (vv[k].ToString() != "")
                                            {
                                                sURL = getUrl(vv[k].ToString());
                                                sValue = sValue.Replace(vv[k].ToString(), sURL);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sValue = getUrl(sSplit[j].ToString());
                                        if (sValue == "")
                                        {
                                            if (sSplit[j] == "" && j == 0 && sSplit.Count() > 1)
                                            {
                                                sValue = "Body : ";
                                            }
                                            else
                                                sValue = sSplit[j].ToString();
                                        }
                                    }


                                    sFinalvalue += sValue + "\n";
                                }
                                else
                                {
                                    sFinalvalue += sSplit[j].ToString();
                                }
                            }

                        }
                        else
                        {
                            sFinalvalue += sOutput[i].ToString() + "\n";
                        }


                    }

                    //string[] sSplit = strContent.Split('\n');
                    //string sValue = string.Empty;
                    //string sFinalvalue = string.Empty;
                    //foreach(string sval in sSplit)
                    //{
                    //    sValue = string.Empty;
                    //    if(sval.TrimStart().StartsWith("www."))
                    //    {
                    //        Regex urlregex = new Regex(@"(www.([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                    //        sValue = urlregex.Replace(sval, "<a href=\"//$1\" target=\"_blank\">$1</a>");
                    //    }
                    //    else if (sval.TrimStart().StartsWith("https:"))
                    //    {
                    //        Regex urlregex = new Regex(@"(https:\/\/([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                    //        sValue = urlregex.Replace(sval, "<a href=\"$1\" target=\"_blank\">$1</a>");
                    //    }
                    //    else if (sval.TrimStart().StartsWith("http:"))
                    //    {
                    //        Regex urlregex = new Regex(@"(http:\/\/([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                    //        sValue = urlregex.Replace(sval, "<a href=\"$1\" target=\"_blank\">$1</a>");
                    //    }
                    //    else if (sval.TrimStart().StartsWith("ftp:"))
                    //    {
                    //        Regex urlregex = new Regex(@"(ftp:\/\/([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                    //        sValue = urlregex.Replace(sval, "<a href=\"$1\" target=\"_blank\">$1</a>");
                    //    }
                    //    else
                    //    {
                    //        sValue = sval;
                    //    }
                    //    sFinalvalue += sValue+"\n";
                    //}
                    //string svalfirst = string.Empty;
                    //foreach (string sval in tokens.Take(tokens.Length-1))
                    //{
                    //    svalfirst += sval + "Body : ";
                    //}

                    //lblcontent.Text = tokens[0].ToString().Replace("\n", "<br>") + "Body : " + sFinalvalue.Replace("\n", "<br>");//strContent.ToString().Replace("\n", "<br>");

                    //lblcontent.Text = svalfirst.Replace("\n", "<br>") + sFinalvalue.Replace("\n", "<br>");

                    lblcontent.Text = sFinalvalue.Replace("\n", "<br>");

                    Session["Content"] = strContent1;

                }
                if (Request["PatientID"] != null && Request["EmailID"] != "" && Request["EncounterID"] != "0")
                {
                    hdnPatientID.Value = Request["PatientID"].ToString();
                    hdnEmailID.Value = Request["EmailID"].ToString();
                    hdnEncounterID.Value = Request["EncounterID"].ToString();

                }
                else if (Request["EmailID"] != null)
                {
                    hdnEncounterID.Value = Request["EncounterID"].ToString();
                    hdnPatientID.Value = "0";
                    hdnEmailID.Value = Request["EmailID"].ToString();
                }
                else
                {
                    hdnPatientID.Value = "0";
                    hdnEmailID.Value = string.Empty;
                    hdnEncounterID.Value = "0";
                }
                if (Request["IS_Patient_Portal"] != null)
                {
                    hdnIsPatientPortal.Value = Request["IS_Patient_Portal"].ToString();
                }

                if (Request["FileName"] != null && Request["FileName"].Trim() != string.Empty && Request["FileName"].Trim() != "&nbsp;")
                {

                    hdnmailPath.Value = Request["FileName"].ToString();
                    string[] filename = Request["FileName"].Split('|');
                    for (int i = 0; i < filename.Length; i++)
                    {
                        Label lbl = new Label();
                        lbl.Text = Path.GetFileName(filename[i]) + "<br/>";
                        lbl.Attributes.Add("class", "Labellink");
                        lbl.Attributes.Add("onclick", "DownloadFile(this)");
                        lbl.Attributes.Add("path", filename[i]);
                        dvattachment.Controls.Add(lbl);

                    }
                }
            }

        }
        public string getUrl(string sURL)
        {
            string sValue = string.Empty;
            if (sURL.ToString().TrimStart().StartsWith("www."))
            {
                Regex urlregex = new Regex(@"(www.([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                sValue = urlregex.Replace(sURL.ToString(), "<a href=\"//$1\" target=\"_blank\">$1</a>");
            }
            else if (sURL.ToString().TrimStart().StartsWith("https:"))
            {
                Regex urlregex = new Regex(@"(https:\/\/([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                sValue = urlregex.Replace(sURL.ToString(), "<a href=\"$1\" target=\"_blank\">$1</a>");
            }
            else if (sURL.ToString().TrimStart().StartsWith("http:"))
            {
                Regex urlregex = new Regex(@"(http:\/\/([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                sValue = urlregex.Replace(sURL.ToString(), "<a href=\"$1\" target=\"_blank\">$1</a>");
            }
            else if (sURL.ToString().TrimStart().StartsWith("ftp:"))
            {
                Regex urlregex = new Regex(@"(ftp:\/\/([\w.]+\/?)\S*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                sValue = urlregex.Replace(sURL.ToString(), "<a href=\"$1\" target=\"_blank\">$1</a>");
            }
            return sValue;
        }

        protected void btndownload_Click(object sender, EventArgs e)
        {
            string localPath = string.Empty;
            string ftpServerIP = string.Empty;
            string ftpUserName = string.Empty;
            string ftpPassword = string.Empty;
            string simagePathname = string.Empty;
            string source = string.Empty;
            string file_path = string.Empty;
            string _fileName = string.Empty;




            localPath = System.Configuration.ConfigurationSettings.AppSettings["LocalPath"];
            ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"].ToString();
            //+"//" + System.Configuration.ConfigurationSettings.AppSettings["ftpMailpath"].ToString();

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

            FTPImageProcess ftpImage = new FTPImageProcess();


            // DirectoryInfo childDir = new DirectoryInfo(new FileInfo(files[i]).DirectoryName);
            string[] sDirName = hdnpath.Value.Split('/');
            string ftpip = Path.Combine(ftpServerIP, sDirName[sDirName.Length - 2]);
            ftpImage.DownloadFromImageServer("0", ftpip, ftpUserName, ftpPassword, Path.GetFileName(hdnpath.Value), localpath);
            string orig_image = localpath + "\\" + Path.GetFileName(hdnpath.Value);




            // Append cookie
            HttpCookie cookie = new HttpCookie("ExcelDownloadFlag");
            cookie.Value = "Flag";
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.AppendCookie(cookie);
            // end
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;

            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(hdnpath.Value));
            byte[] data = req.DownloadData(orig_image);
            response.BinaryWrite(data);
            response.End();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Downloaded", "{ sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }", true);
            Response.End();


        }
    }
}
