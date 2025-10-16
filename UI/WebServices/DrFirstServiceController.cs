using Acurus.Capella.DataAccess;
using Acurus.Capella.DataAccess.ManagerObjects;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace Acurus.Capella.UI.WebServices.API
{
    //CAP-3524
    public class DrFirstServiceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult DownloadDrFirstData(string sHumanID, string sFacilityName, string sLegalOrg)
        {
            try
            {
                if (!VerifyToken())
                {
                    return Json(new { status = "Unauthorized", ErrorDescription = "The remote server returned an error: (403) Forbidden." });
                }
                if (string.IsNullOrEmpty(sLegalOrg))
                {
                    return Json(new { HumanID = sHumanID, status = "ValidationError", ErrorDescription = "LegalOrg is not valid. Cannot download DrFirst data." });
                }
                if (string.IsNullOrEmpty(sHumanID) || sHumanID == "0")
                {
                    return Json(new { HumanID = sHumanID, status = "ValidationError", ErrorDescription = "HumanID is not valid. Cannot download DrFirst data." });
                }

                string sErrorMessage = string.Empty;
                Rcopia_Update_InfoManager objUpdateInfoMngr = new Rcopia_Update_InfoManager();
                RCopiaSessionManager rcopiaSessionMngr = new RCopiaSessionManager(sLegalOrg);

                string downloadAddress = "";
                sErrorMessage = objUpdateInfoMngr.DownloadRCopiaInfo(downloadAddress, "AcurusAPI", string.Empty, DateTime.UtcNow, sFacilityName, 0, Convert.ToUInt64(sHumanID), sLegalOrg);
            }
            catch (Exception ex)
            {
                //CAP-3727
                LogError(ex, sHumanID);
                return Json(new { HumanID = sHumanID, status = "Error", ErrorDescription = "Error in processing the request. " + ex.Message });
            }
            return Json(new { HumanID = sHumanID, status = "Acknowledged" });
        }
        //CAP-3700
        [HttpGet]
        public IHttpActionResult UploadPatientDatatoDrFirst(string sHumanID, string sUploadType, string sLegalOrg)
        {
            try
            {
                if (!VerifyToken())
                {
                    return Json(new { status = "Unauthorized", ErrorDescription = "The remote server returned an error: (403) Forbidden." });
                }
                if (string.IsNullOrEmpty(sLegalOrg))
                {
                    return Json(new { HumanID = sHumanID, status = "ValidationError", ErrorDescription = "LegalOrg is not valid. Cannot download DrFirst data." });
                }
                if (string.IsNullOrEmpty(sHumanID) || sHumanID == "0")
                {
                    return Json(new { HumanID = sHumanID, status = "ValidationError", ErrorDescription = "HumanID is not valid. Cannot download DrFirst data." });
                }
                if (string.IsNullOrEmpty(sUploadType))
                {
                    return Json(new { HumanID = sHumanID, status = "ValidationError", ErrorDescription = "UploadType is not valid. Cannot download DrFirst data." });
                }

                switch (sUploadType)
                {
                    case "send_patient":
                        RCopiaTransactionManager objRcopiaMngr = new RCopiaTransactionManager();
                        objRcopiaMngr.SendPatientToRCopia(Convert.ToUInt64(sHumanID), string.Empty, sLegalOrg);
                        break;
                }
            }
            catch (Exception ex)
            {
                //CAP-3727
                LogError(ex, sHumanID);
                return Json(new { HumanID = sHumanID, status = "Error", ErrorDescription = "Error in processing the request. " + ex.Message });
            }
            return Json(new { HumanID = sHumanID, status = "Acknowledged" });
        }

        private bool VerifyToken()
        {
            var authorization = Request.Headers.GetValues("Authorization");
            string token = authorization.Any() ? authorization.FirstOrDefault() : "";
            token = token.Replace("Bearer ", "");
            var endPointToken = ConfigurationSettings.AppSettings["EndPointToken"] ?? "";
            if (token == null || string.IsNullOrEmpty(token.ToString()) || string.IsNullOrEmpty(endPointToken) || token.ToString() != endPointToken)
            {
                return false;
            }
            return true;
        }
        //CAP-3727
        private void LogError(Exception exc, string sHumanID)
        {
            string version = "";
            if (ConfigurationSettings.AppSettings["VersionConfiguration"] != null)
            {
                version = ConfigurationSettings.AppSettings["VersionConfiguration"].ToString();
            }

            string[] server = version.Split('|');
            string serverno = "";
            if (server.Length > 1)
                serverno = server[1].Trim();

            string sMessage = "";
            string statserrorlogstacktrace = "";

            if (exc != null && exc.Message != null)
                sMessage = exc.Message;

            if (exc != null && exc.StackTrace != null)
                statserrorlogstacktrace = exc.StackTrace;
            if (exc != null && exc.InnerException != null && exc.InnerException.Message != null && sMessage == string.Empty)
            {
                sMessage += exc.InnerException.Message;
            }
            if (exc != null && exc.InnerException != null && exc.InnerException.StackTrace != null && sMessage == string.Empty)
            {
                statserrorlogstacktrace += exc.InnerException.StackTrace;
            }

            if (exc != null && exc.Message != null)
            {
                string userName = string.Empty;
                ulong physicianId = 0;
                string insertQuery = "insert into stats_apperrorlog values(0,'" + sMessage.Replace(@"\\", @"\\\\").Replace(@"\", @"\\").Replace(@"\\\\\\\\", @"\\\\").Replace("'", "") + "', '" + serverno + "','" + DateTime.Now + "','" + userName + "','" + 0 + "','" + sHumanID + "','" + physicianId + "','" + statserrorlogstacktrace.Replace("'", "") + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                DBConnector.WriteData(insertQuery);
            }
        }
    }
}