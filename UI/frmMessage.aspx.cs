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
using Acurus.Capella.DataAccess.ManagerObjects;

namespace Acurus.Capella.UI
{
    public partial class frmMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ScreenMode"] != null && Request["ScreenMode"].ToString().ToUpper() == "ABOUT")
            {
                string strConfiguration = string.Empty;
                string strLocalConfiguration = string.Empty;
                string strHibernateConfig = string.Empty;
                UserManager userMngr = new UserManager();
                strHibernateConfig = userMngr.GetConnectionStringDetails();
                if (strHibernateConfig != string.Empty)
                {
                    string[] strConfigSplit = strHibernateConfig.Split('=');
                    string[] strSchemaSplit = strConfigSplit[1].Split(';');
                    string[] strDBSplit = strConfigSplit[2].Split(';');

                    StringBuilder strConcat = new StringBuilder();
                    strConcat.Append(strSchemaSplit[0]);
                    this.Page.Title = "About";
                    strConfiguration = "Version - " + ConfigurationSettings.AppSettings["VersionConfiguration"].ToString() + "<br/> " + "Schema - " + strConcat + "<br/> " + "IP Address - " + strDBSplit[0];//Added V to version tag for BugID:45768
                }
                lblMessage.Text = strConfiguration;
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "SetIntervalTime(10000);", true);

            }


        }

    }
}
