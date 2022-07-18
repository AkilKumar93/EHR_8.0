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

namespace Acurus.Capella.UI
{
    public partial class frmOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pgViewDiagnosticorder.ContentUrl = "frmImageAndLabOrder.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"] + "&ScreenMode=Menu";
                if (ClientSession.SetSelectedTab.Contains('*'))
                {
                    string sChildTab = string.Empty;
                    if (ClientSession.SetSelectedTab.Contains('#'))
                        sChildTab = ClientSession.SetSelectedTab.Split('*')[1].Split('#')[0].ToUpper();
                    else
                        sChildTab = "DIAGNOSTIC ORDER";
                    if (sChildTab.ToUpper() == "DIAGNOSTIC ORDER")
                    {
                        pgViewDiagnosticorder.ContentUrl = "frmImageAndLabOrder.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"] + "&ScreenMode="+Request["ScreenMode"];
                        pgViewDiagnosticorder.Selected = true;
                        tabOrders.SelectedIndex = pgViewDiagnosticorder.Index;
                    }
                    else if (sChildTab.ToUpper() == "REFERRAL ORDER")
                    {
                        pgViewReferralOrder.ContentUrl = "frmReferralOrder.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"] + "&ScreenMode=" + Request["ScreenMode"];
                        pgViewReferralOrder.Selected = true;
                        tabOrders.SelectedIndex = pgViewReferralOrder.Index;
                    }
                    else if (sChildTab.ToUpper() == "PROCEDURES")
                    {
                        pgViewProcedures.ContentUrl = "frmInhouseProcedure.aspx";
                        pgViewProcedures.Selected = true;
                        tabOrders.SelectedIndex = pgViewProcedures.Index;
                    }
                    else if (sChildTab.ToUpper() == "IMMUNIZATION/INJECTION")
                    {
                        pgViewImmunizationInjection.ContentUrl = "frmImmunization.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"] + "&ScreenMode=" + Request["ScreenMode"];
                        pgViewImmunizationInjection.Selected = true;
                        tabOrders.SelectedIndex = pgViewImmunizationInjection.Index;
                    }
                }
                else
                {
                    pgViewDiagnosticorder.ContentUrl = "frmImageAndLabOrder.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"] + "&ScreenMode="+Request["ScreenMode"];//for bug ID=28592
                    pgViewDiagnosticorder.Selected = true;
                    tabOrders.SelectedIndex = pgViewDiagnosticorder.Index;
                    if (ClientSession.SetSelectedTab.Contains('#'))
                    {
                        ClientSession.SetSelectedTab = ClientSession.SetSelectedTab.Split('#')[0] + "*" + "DIAGNOSTIC ORDER";
                    }
                    else
                    {
                        ClientSession.SetSelectedTab = ClientSession.SetSelectedTab + "*" + "DIAGNOSTIC ORDER";
                    }
                }
            }
            //this.Page.Title = this.Page.Title +ClientSession.UserName;
        }

        protected void tabOrders_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            ClientSession.SetSelectedTab = ClientSession.SetSelectedTab.Split('*')[0] + "*" + e.Tab.Text.ToUpper();
            if (e.Tab.Text.ToUpper() == "IMMUNIZATION/INJECTION")
            {
                pgViewImmunizationInjection.ContentUrl = "frmImmunization.aspx?HumanID=" + Request["HumanID"]+ "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"]+"&ScreenMode="+Request["ScreenMode"];
            }
            else if (e.Tab.Text.ToUpper() == "PROCEDURES")
            {
                 pgViewProcedures.ContentUrl = "frmInhouseProcedure.aspx";
            }
            else if (e.Tab.Text.ToUpper() == "DIAGNOSTIC ORDER")
            {
                pgViewDiagnosticorder.ContentUrl= "frmImageAndLabOrder.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID="+Request["PhysicianID"];
            }
            else if (e.Tab.Text.ToUpper() == "REFERRAL ORDER")
            {
                pgViewReferralOrder.ContentUrl = "frmReferralOrder.aspx?HumanID=" + Request["HumanID"] + "&EncounterID=" + Request["EncounterID"] + "&PhysicianID=" + Request["PhysicianID"] + "&ScreenMode=" + Request["ScreenMode"];
            }
            
        }
    }
}
