using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;

namespace Acurus.Capella.UI.WebServices
{
    /// <summary>
    /// Summary description for TestService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LogService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string LogApplicationUsage(string sApplicationScreenName)
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            IList<ApplicationUsageLog> ilstApplicationUsageLog = new List<ApplicationUsageLog>();
            ilstApplicationUsageLog.Add(new ApplicationUsageLog()
            {
                Application_Screen_Name = sApplicationScreenName,
                Created_By = ClientSession.UserName,
                Legal_Org = ClientSession.LegalOrg,
                Created_Date_and_Time = DateTime.Now
            });
            ApplicationUsageLogManager applicationUsageLogManager = new ApplicationUsageLogManager();
            applicationUsageLogManager.SaveRcopia_deduplicate_logWithTransaction(ilstApplicationUsageLog, null, string.Empty);

            return "true";
        }
    }
}