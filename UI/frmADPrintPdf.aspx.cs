using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acurus.Capella.UI
{
    public partial class frmADPrintPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ADFilePAth"] != null)
            {
                try
                {
                        string sPDFpath = Session["ADFilePAth"].ToString();
                        var bytes = System.IO.File.ReadAllBytes(sPDFpath);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-disposition", "filename=" + Session["ADFilePAth"].ToString());
                        Response.BinaryWrite(bytes.ToArray());
                        PDFLOAD.Attributes.Add("src", bytes.ToString());
                    
                    //For direct dowload from Image Server
                    //string uri = Session["ADFilePAth"].ToString();//Give Full path
                    //string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
                    //string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
                    //string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
                    //string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
                    //string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
                    //string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
                    //using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                    //{
                    //    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    //    {
                    //        var bytes = System.IO.File.ReadAllBytes(uri.Replace(ftpIP, UNCPath));
                    //        Response.ContentType = "application/pdf";
                    //        Response.AddHeader("Content-disposition", "filename=" + Path.GetFileName(uri.Replace(ftpIP, UNCPath)));
                    //        Response.BinaryWrite(bytes.ToArray());
                    //        PDFLOAD.Attributes.Add("src", bytes.ToString());
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
    }
}