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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using log4net;
using System.Reflection;
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Acurus.Capella.PatientPortal
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("Error");

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create safe error messages.
            string generalErrorMsg = "A problem has occurred on this web site. Please try again. If this error continues, please contact support.";
            string httpErrorMsg = "An HTTP error occurred. Page Not found. Please try again.";
            string unhandledErrorMsg = "The error was unhandled by application code.";
            //
            if (Request.RawUrl.Contains("ErrorPage.aspx"))
            {
                btnLogin.Visible = true;
            }

            // Display safe error message.

            friendlyErrorMsg.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt") + ": " + generalErrorMsg;

            // Determine where error was handled.
            string errHandler = Request.QueryString["handler"];
            if (errHandler == null)
                errHandler = "Error Page";

            // Get the last error from the server.
            Exception ex = null;
            if (Server.GetLastError() != null)
                ex = Server.GetLastError().GetBaseException();

            // If the exception no longer exists, create a generic exception.
            if (ex == null)
                ex = UIManager.UnhandledException;
            //ex = (Exception)Session["Unhandled_Exception"];
            if (ex == null)
                ex = new Exception(unhandledErrorMsg);


            string sMessage = Request.QueryString["Message"];
            if (sMessage == "XmlBeingUsedByAnotherProcess")
            {
                sMessage = "This patient XML is being used by another user. Please try again later." + "<br/>" + "<br/>";
                if (ex.InnerException != null)
                {
                    sMessage += "Exception type   : " + ex.InnerException.GetType() + "<br/>" + "<br/>" +
                                 "Exception message: " + ex.InnerException.Message + "<br/>" + "<br/>" +
                                 "Stack trace      : " + ex.InnerException.StackTrace + "<br/>" + "<br/>";
                }
                btnLogin.Visible = true;
            }
            // Show error details to only you (developer). LOCAL ACCESS ONLY.
            //if (Request.IsLocal)
            {
                detailedErrorPanel.Visible = true;

                string message = "Exception type   : " + ex.GetType() + "<br/>" + "<br/>" +
                                 "Exception message: " + ex.Message + "<br/>" + "<br/>" +
                                 "Stack trace      : " + ex.StackTrace + "<br/>" + "<br/>";

                innerMessage.Text = message;
                if (sMessage != "" && sMessage != null)
                    innerMessage.Text = sMessage;
                else if (ex.InnerException != null)
                {
                    message += "---BEGIN InnerException--- " + "<br/>" +
                               "Exception type   : " + ex.InnerException.GetType() + "<br/>" + "<br/>" +
                               "Exception message: " + ex.InnerException.Message + "<br/>" + "<br/>" +
                               "Stack trace      : " + ex.InnerException.StackTrace + "<br/>" + "<br/>" +
                               "---END Inner Exception----";

                    innerMessage.Text = message;
                }

                //---- to log exception details
                try
                {
                    string log_message = System.Environment.NewLine + System.Environment.NewLine + "------------------------------BEGINNING OF THIS EXCEPTION------------------------------------" + System.Environment.NewLine + System.Environment.NewLine +
                      "MESSAGE: " + ex.Message + System.Environment.NewLine +
                      "TYPE: " + Convert.ToString(ex.GetType()) + System.Environment.NewLine +
                      "TIME: " + DateTime.Now.ToString() + " . UTC TIME: " + DateTime.UtcNow.ToString() + System.Environment.NewLine +
                      "SOURCE: " + Convert.ToString(ex.Source) + System.Environment.NewLine +
                        //"FORM: " + Request.Form.ToString() + System.Environment.NewLine +
                        //"QUERYSTRING: " + Request.QueryString.ToString() + System.Environment.NewLine +
                      "TARGETSITE: " + Convert.ToString(ex.TargetSite) + System.Environment.NewLine +
                      "CURRENT USER: " + Convert.ToString(ClientSession.UserName) + System.Environment.NewLine +
                      "ENCOUNTER ID: " + Convert.ToString(ClientSession.EncounterId) + System.Environment.NewLine +
                      "HUMAN ID: " + Convert.ToString(ClientSession.HumanId) + System.Environment.NewLine +
                      "PHYSICIAN ID: " + Convert.ToString(ClientSession.PhysicianId) + System.Environment.NewLine +
                      "STACKTRACE: " + Convert.ToString(ex.StackTrace);
                    Exception baseException = ex;
                    for (; ; )
                    {
                        if (baseException.InnerException != null)
                        {
                            log_message += System.Environment.NewLine + System.Environment.NewLine + "----------------------------------------------------------------" + System.Environment.NewLine + "NEXT LEVEL INNER EXCEPTION DETAILS :" + System.Environment.NewLine +
                                "MESSAGE: " + Convert.ToString(baseException.InnerException.Message) + System.Environment.NewLine +
                                "\nTYPE: " + Convert.ToString(baseException.InnerException.GetType()) + System.Environment.NewLine +
                          "SOURCE: " + Convert.ToString(baseException.InnerException.Source) + System.Environment.NewLine +
                          "TARGETSITE: " + Convert.ToString(baseException.InnerException.TargetSite) + System.Environment.NewLine +
                          "STACKTRACE: " + Convert.ToString(baseException.InnerException.StackTrace);
                            baseException = baseException.InnerException;
                        }
                        else
                        {
                            break;
                        }
                    }

                    long totalSessionBytes = 0;
                    BinaryFormatter b = new BinaryFormatter();
                    MemoryStream m;
                    try
                    {
                        foreach (var obj in Session)
                        {
                            m = new MemoryStream();
                            b.Serialize(m, obj);
                            totalSessionBytes += m.Length;
                        }


                        log_message += System.Environment.NewLine + System.Environment.NewLine + "SIZE OF CURRENT SESSION: " + totalSessionBytes.ToString() + " bytes" + System.Environment.NewLine;
                    }
                    catch
                    {
                        log_message += System.Environment.NewLine + System.Environment.NewLine + "SIZE OF CURRENT SESSION: Unable to calculate since Session is unavailable in this context." + System.Environment.NewLine;
                    }
                    log_message += System.Environment.NewLine + System.Environment.NewLine + "------------------------------END OF THIS EXCEPTION------------------------------------" + System.Environment.NewLine + System.Environment.NewLine;
                    log.Error(log_message, ex);
                }
                catch
                {
                    log.Error("Unable to log details of Exception", ex);
                }
            }

            // Clear the error from the server.
            Server.ClearError();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "jQuery(top.window.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').css('display')='none'", true);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
         if (Request.RawUrl.Contains(".aspx"))
            {
                //Clear all session Folders 
                UtilityManager.DeleteUserSessionFile(string.Empty, Session.SessionID);
                ClientSession.SavedSession = "DELETED";
                if (Directory.Exists(Server.MapPath("Documents\\" + Session.SessionID)) == true) // Handled To Delete Isolated Temp directory Created For Logged in users
                {
                    try
                    {
                        System.IO.Directory.Delete(Server.MapPath("Documents\\" + Session.SessionID), true);
                    }
                    catch
                    {
                    }
                }

                if (Directory.Exists(Server.MapPath("atala-capture-download\\" + Session.SessionID)) == true)
                {
                    try
                    {
                        System.IO.Directory.Delete(Server.MapPath("atala-capture-download\\" + Session.SessionID), true);

                        foreach (string filename in Directory.GetFiles(Server.MapPath("atala-capture-download")))
                        {

                            FileInfo file = new FileInfo(filename);
                            if (file.Name.StartsWith(Session.SessionID))
                            {
                                file.Delete();
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (Directory.Exists(Server.MapPath("atala-capture-upload\\" + Session.SessionID)) == true)
                {
                    try
                    {
                        System.IO.Directory.Delete(Server.MapPath("atala-capture-upload\\" + Session.SessionID), true);
                    }
                    catch
                    {
                    }
                }

                HttpContext.Current.Application.Remove("user");
                Session["ShowAllState"] = null;
                Session["GeneralQShowAll"] = null;

                //Redirect to login Page 

                string Url = Request.RawUrl;
                string[] Url1 = Url.Split('/');
                string Link = Url1[Url1.Length - 1].ToString();

                string UrlReferrer = HttpContext.Current.Request.UrlReferrer.ToString();
                string[] UrlReferrer1 = UrlReferrer.Split('/');
                string LinkReferrer = UrlReferrer1[UrlReferrer1.Length - 1].ToString();

                if (Link.ToUpper().Contains("EMAIL") == true)
                {
                    string[] SplitLink = Link.Split('?');
                    if (Convert.ToString(SplitLink[1]) != string.Empty)
                        Response.Write("<script> window.top.location.href=\" webfrmLogin.aspx?" + SplitLink[1].ToString() + "\"; </script>");
                }
                else if (LinkReferrer.ToUpper().Contains("EMAIL") == true)
                {
                    string[] SplitLink = LinkReferrer.Split('?');
                    if (Convert.ToString(SplitLink[1]) != string.Empty)
                        Response.Write("<script> window.top.location.href=\" webfrmLogin.aspx?" + SplitLink[1].ToString() + "\"; </script>");
                }
                else
                {
                    Response.Write("<script> window.top.location.href=\" frmLogin.aspx\"; </script>");
                }
            }
        }
    }
}
