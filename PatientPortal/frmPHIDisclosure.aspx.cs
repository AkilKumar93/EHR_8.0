using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.MobileControls.Adapters;
using System.Web.UI.WebControls;

namespace Acurus.Capella.PatientPortal
{
    public partial class frmPHIDisclosure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static string OnPageLoad(string sHumanId)
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }

            //HumanManager humanManager = new HumanManager();
            //Human objHuman = new Human();
            Human_PHI_DisclosureManager HumanPhiDisclosuremngr = new Human_PHI_DisclosureManager();
            IList<Human_Phi_Disclosure> ilsthuman_Phi_Disclosure = new List<Human_Phi_Disclosure>();
            if (sHumanId != "")
            {
                //objHuman = humanManager.GetById(Convert.ToUInt64(sHumanId));
                ilsthuman_Phi_Disclosure = HumanPhiDisclosuremngr.GetHumanPhiDisclosureByHumanID(Convert.ToUInt64(sHumanId));


                if (ilsthuman_Phi_Disclosure.Count > 0)
                {
                    var result = new { PHIDetails = ilsthuman_Phi_Disclosure.FirstOrDefault() };
                    return JsonConvert.SerializeObject(result);
                }
            }

            
            return JsonConvert.SerializeObject(new { PHIDetails = "" });
        }
        
        [WebMethod(EnableSession = true)]
        public static string SavePHIDetails(string sHumanId,string sIsSigned,string sSignedText,string sIs_Disclose_All_Information, string sSeletedPhiDetails)
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }

            HumanManager humanManager = new HumanManager();
            Human objHuman = new Human();
            Human_PHI_DisclosureManager HumanPhiDisclosuremngr = new Human_PHI_DisclosureManager();
            IList<Human_Phi_Disclosure> ilsthuman_Phi_Disclosure = new List<Human_Phi_Disclosure>();
            if (sHumanId != "")
            {
                objHuman = humanManager.GetById(Convert.ToUInt64(sHumanId));
                ilsthuman_Phi_Disclosure = HumanPhiDisclosuremngr.GetHumanPhiDisclosureByHumanID(Convert.ToUInt64(sHumanId));

                string sFullSignedText = sSignedText + " residing at " + objHuman.Street_Address1 + ", " + objHuman.City + ", " + objHuman.State + ", " + objHuman.ZipCode;

                if (ilsthuman_Phi_Disclosure.Count > 0)
                {
                    ilsthuman_Phi_Disclosure[0].Is_Disclose_All_Information = sIs_Disclose_All_Information;
                    ilsthuman_Phi_Disclosure[0].Disclosure_Details = sSeletedPhiDetails;
                    ilsthuman_Phi_Disclosure[0].PHI_Disclosure_Signed_By = sFullSignedText;
                    ilsthuman_Phi_Disclosure[0].PHI_Disclosure_Signed_Date_Time = DateTime.UtcNow;
                    ilsthuman_Phi_Disclosure[0].Modified_By = ClientSession.UserName;
                    ilsthuman_Phi_Disclosure[0].Modified_Date_And_Time = DateTime.UtcNow;
                    HumanPhiDisclosuremngr.SaveHumanPhiDisclosureWithTransaction(null, ilsthuman_Phi_Disclosure, string.Empty);
                }
                else
                {
                    IList<Human_Phi_Disclosure> ilstInserthuman_Phi_Disclosure = new List<Human_Phi_Disclosure>();
                    ilstInserthuman_Phi_Disclosure.Add(new Human_Phi_Disclosure());
                    ilstInserthuman_Phi_Disclosure[0].Human_ID = Convert.ToUInt64(sHumanId);
                    ilstInserthuman_Phi_Disclosure[0].Is_Disclose_All_Information = sIs_Disclose_All_Information;
                    ilstInserthuman_Phi_Disclosure[0].Disclosure_Details = sSeletedPhiDetails;
                    ilstInserthuman_Phi_Disclosure[0].PHI_Disclosure_Signed_By = sFullSignedText;
                    ilstInserthuman_Phi_Disclosure[0].PHI_Disclosure_Signed_Date_Time = DateTime.UtcNow;
                    ilstInserthuman_Phi_Disclosure[0].Created_By = ClientSession.UserName;
                    ilstInserthuman_Phi_Disclosure[0].Created_Date_And_Time = DateTime.UtcNow;
                    HumanPhiDisclosuremngr.SaveHumanPhiDisclosureWithTransaction(ilstInserthuman_Phi_Disclosure, null, string.Empty);
                }
            }

            
            return JsonConvert.SerializeObject(new { PHIDetails = "" });
        }
    }
}