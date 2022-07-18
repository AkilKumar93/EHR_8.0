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
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.UI
{
    public partial class frmPFSHVerficationYesNo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            bool IsPassedValidation = false;

            SocialHistoryManager objSocialHistoryManager = new SocialHistoryManager();

            IList<SocialHistory> SocialHistoryDetails = null;
            SocialHistoryDTO problemDTO = new SocialHistoryDTO();
            problemDTO = objSocialHistoryManager.GetSocialHistoryByHumanID(ClientSession.HumanId, ClientSession.EncounterId, "SOCIAL HISTORY", true);
            SocialHistoryDetails = problemDTO.SocialList;
            StaticLookupManager objStaticLookupMgr = new StaticLookupManager();
            IList<StaticLookup> objStaticLookup = new List<StaticLookup>();
            objStaticLookup = objStaticLookupMgr.getStaticLookupByFieldName("SOCIAL HISTORY", "Sort_Order");
            objStaticLookup = objStaticLookup.Where(a => a.Description == "MANDATORY").ToList<StaticLookup>();

            if (ClientSession.IsDirtySocialHistory)
            {
                foreach (StaticLookup obj in objStaticLookup)
                {
                    if (SocialHistoryDetails.Any(a => a.Social_Info == obj.Value))
                    {
                        IsPassedValidation = true;
                        break;
                    }

                }
            }
            else
            {
                IsPassedValidation = true;
            }
            if (IsPassedValidation)
            {
                ClientSession.bPFSHVerified = true;

                EncounterManager objEncounterManager = new EncounterManager();
                IList<Encounter> EncList = null;
                EncList = objEncounterManager.GetEncounterByEncounterID(ClientSession.EncounterId);
                if (EncList != null && EncList.Count > 0)
                {
                    Encounter currentEncounter = new Encounter();
                    currentEncounter = EncList[0];
                    currentEncounter.Is_PFSH_Verified = "Y";
                    currentEncounter.Modified_By = ClientSession.UserName;
                    currentEncounter.Modified_Date_and_Time = UtilityManager.ConvertToUniversal();
                    //btnPFSH.Enabled = false;
                    objEncounterManager.UpdateEncounter(currentEncounter, string.Empty, new object[] { "false" });
                }

            }
            string ScriptToBeInjected = string.Empty;
            //if (IsPassedValidation)
            //    ScriptToBeInjected = @"var PFSHYesNoObj=true;window.returnValue=PFSHYesNoObj;self.close(); ";
            //else
            //    ScriptToBeInjected = @"var PFSHYesNoObj=false;window.returnValue=PFSHYesNoObj;self.close(); ";
            //ScriptManager.RegisterStartupScript(this, typeof(frmPFSHVerficationYesNo), "WarningPFSH", ScriptToBeInjected, true);
            if (IsPassedValidation)
                ScriptManager.RegisterStartupScript(this, typeof(frmRoomIn), "CancelKeyDefault", "var o = new Object();o=true;returnToParent(o);", true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(frmRoomIn), "CancelKeyDefault", "var o = new Object();o=false;returnToParent(o);", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, typeof(frmRoomIn), "CancelKeyDefault", "var o = new Object();returnToParent(o);", true);

        }
    }
}
