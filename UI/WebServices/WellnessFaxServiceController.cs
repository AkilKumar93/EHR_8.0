using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.Core.DTOJson;
using Acurus.Capella.DataAccess;
using Acurus.Capella.DataAccess.ManagerObjects;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;

namespace Acurus.Capella.UI.WebServices.API
{
    public class WellnessFaxServiceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPhysicianNameByPhyId(ulong phyId)
        {
            try
            {
                if (!VerifyToken())
                {
                    return Json(new { status = "Unauthorized", ErrorDescription = "The remote server returned an error: (403) Forbidden." });
                }

                if (phyId == 0)
                {
                    return Json(new { status = "ValidationError", ErrorDescription = "phyId is not present in the request." });
                }

                PhysicianManager objphyMngr = new PhysicianManager();
                var result = objphyMngr.GetphysiciannameByPhyID(phyId);
                return Json(new { status = "Success", Data = result });
            }
            catch (Exception ex)
            {
                LogError(ex, "0");
                return Json(new { status = "Error", ErrorDescription = "Error in processing the request. " + ex.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult GetInsurancePoliciesByHumanId(ulong ulHumanId)
        {
            try
            {
                if (!VerifyToken())
                {
                    return Json(new { status = "Unauthorized", ErrorDescription = "The remote server returned an error: (403) Forbidden." });
                }
                if (ulHumanId == 0)
                {
                    return Json(new { status = "ValidationError", ErrorDescription = "ulHumanId is not present in the request." });
                }

                PatientInsuredPlanManager objPatInsuredplanMngr = new PatientInsuredPlanManager();
                var result = objPatInsuredplanMngr.getInsurancePoliciesByHumanId(ulHumanId);
                return Json(new { status = "Success", Data = result });
            }
            catch (Exception ex)
            {
                LogError(ex, "0");
                return Json(new { status = "Error", ErrorDescription = "Error in processing the request. " + ex.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult GetInsuranceById(ulong uInsurance_Plan_ID)
        {
            try
            {
                if (!VerifyToken())
                {
                    return Json(new { status = "Unauthorized", ErrorDescription = "The remote server returned an error: (403) Forbidden." });
                }
                if (uInsurance_Plan_ID == 0)
                {
                    return Json(new { status = "ValidationError", ErrorDescription = "uInsurance_Plan_ID is not present in the request." });
                }

                InsurancePlanManager objInsPlanMngr = new InsurancePlanManager();
                var result = objInsPlanMngr.GetInsurancebyID(uInsurance_Plan_ID);
                return Json(new { status = "Success", Data = result });
            }
            catch (Exception ex)
            {
                LogError(ex, "0");
                return Json(new { status = "Error", ErrorDescription = "Error in processing the request. " + ex.Message });
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePhysicianEFax(UpdatePhysicianLibrary physicianLibrary)
        {
            try
            {
                if (!VerifyToken())
                {
                    return Json(new { status = "Unauthorized", ErrorDescription = "The remote server returned an error: (403) Forbidden." });
                }
                if(physicianLibrary.PhyID == 0)
                {
                    return Json(new { status = "ValidationError", ErrorDescription = "PhyID is not present in the request." });
                }
                if (string.IsNullOrEmpty(physicianLibrary.PhyFax))
                {
                    return Json(new { status = "ValidationError", ErrorDescription = "PhyFax is not present in the request." });
                }
                if (!string.IsNullOrEmpty(physicianLibrary.PhyFax)
                    && !Regex.IsMatch(physicianLibrary.PhyFax, @"^\d+$"))
                {
                    return Json(new { status = "ValidationError", ErrorDescription = "PhyFax is invalid in the request." });
                }

                PhysicianManager objPhyMngr = new PhysicianManager();
                IList<PhysicianLibrary> phyList = objPhyMngr.GetphysiciannameByPhyID(physicianLibrary.PhyID);
                if (phyList.Count > 0 && phyList[0] != null)
                {
                    phyList[0].PhyFax = physicianLibrary.PhyFax;
                    phyList[0].ChangedDateAndTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    objPhyMngr.UpdatePhysicians(phyList[0], string.Empty);
                }
                return Json(new { status = "Success" });
            }
            catch (Exception ex)
            {
                LogError(ex, "0");
                return Json(new { status = "Error", ErrorDescription = "Error in processing the request. " + ex.Message });
            }
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

    public class UpdatePhysicianLibrary
    {
        public ulong PhyID { get; set; }
        public string PhyFax { get; set; }
    }
}