using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.UI.RCopia;

namespace Acurus.Capella.UI
{
    public partial class frmRCopiaStatusBar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEmail.Value = Request["Email"]?.ToString() ?? "";
            hdnLegalOrg.Value = Request["LegalOrg"]?.ToString() ?? "";
        }

        [WebMethod]
        public static string LoadRCopiaNotification(string email, string legalOrg)
        {
            UserManager UserMngr = new UserManager();
            IList<User> objUser = UserMngr.GetUserByEmailAddress(email);
            string Is_RCopia_Notification_Required = string.Empty;
            string RCopiaUserName = string.Empty;
            string UserName = string.Empty;
            string FacilityName = string.Empty;
            string LegalOrg = string.Empty;
            if (objUser != null && objUser.Any())
            {
                objUser = objUser.Where(a => a.Legal_Org == legalOrg).ToList();
                if (objUser != null && objUser.Any())
                {
                    Is_RCopia_Notification_Required = objUser[0].Is_RCopia_Notification_Required;
                    RCopiaUserName = objUser[0].RCopia_User_Name;
                    UserName = objUser[0].user_name;
                    FacilityName = objUser[0].Default_Facility;
                    LegalOrg = objUser[0].Legal_Org;
                }
            }

            if (Is_RCopia_Notification_Required != "Y" || RCopiaUserName == string.Empty)
            { return ""; }

            RCopiaGenerateXML objrcopGenXML = new RCopiaGenerateXML();
            string sInputXML = string.Empty;
            sInputXML = objrcopGenXML.CreateGetNotificationCountXMLForAkido(LegalOrg, RCopiaUserName);
            string sOutputXML = string.Empty;
            RCopiaSessionManager rcopiaSessionMngr = new RCopiaSessionManager(LegalOrg);
            sOutputXML = rcopiaSessionMngr.HttpPostForAkido(rcopiaSessionMngr.DownloadAddress + sInputXML, 1, UserName);
            if (sOutputXML != null && sOutputXML.StartsWith("HttpPostError") == true)
            {
                return sOutputXML;
            }
            RCopia.RCopiaXMLResponseProcess objRcopResponseXML = new RCopiaXMLResponseProcess();
            IList<Rcopia_NotificationDTO> ilstNotification;
            objRcopResponseXML.ReadXMLResponseForAkido(sOutputXML, out ilstNotification, UserName, FacilityName);
            string returnText = "";
            try
            {
                returnText = FillRCopiaNotification(ilstNotification);
            }
            catch
            {
            }
            return returnText;
        }

        public static string FillRCopiaNotification(IList<Rcopia_NotificationDTO> ilstnotification)
        {
            string RcopiaRefill = string.Empty;
            string Rcopiarx_pending = string.Empty;
            string Rcopiarx_need_signing = string.Empty;
            string Rcopiarx_change = string.Empty;
            if (ilstnotification != null)
            {
                for (int i = 0; i < ilstnotification.Count; i++)
                {
                    if (ilstnotification[i].Type.ToLower() == "refill")
                    {
                        RcopiaRefill = ilstnotification[i].Type.ToUpper() + " : " + ilstnotification[i].Number;
                    }
                    else if (ilstnotification[i].Type.ToLower() == "rx_pending")
                    {
                        Rcopiarx_pending = ilstnotification[i].Type.ToUpper() + " : " + ilstnotification[i].Number;
                    }
                    else if (ilstnotification[i].Type.ToLower() == "rx_need_signing")
                    {
                        Rcopiarx_need_signing = ilstnotification[i].Type.ToUpper() + " : " + ilstnotification[i].Number;
                    }
                    else if (ilstnotification[i].Type.ToLower() == "rxchange")
                    {
                        Rcopiarx_change = ilstnotification[i].Type.ToUpper() + " : " + ilstnotification[i].Number;
                    }
                }
            }
            return (RcopiaRefill + "#$%" + Rcopiarx_pending + "#$%" + Rcopiarx_need_signing + "#$%" + Rcopiarx_change + "#$%");
        }
    }
}