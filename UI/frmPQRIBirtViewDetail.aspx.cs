using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.UI
{
    public partial class frmPQRIBirtViewDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Den_Hum_IDs"] != null && Session["Den_Hum_IDs"] != "" && Session["Den_Hum_IDs"] != "0")
            {
                 Session["Den_Hum_IDs"].ToString();
            }
            if (Session["Num_Hum_IDs"] != null && Session["Num_Hum_IDs"] != "" && Session["Num_Hum_IDs"] != "0")
            {
                Session["Num_Hum_IDs"].ToString();
            }
            //added by Nithin for CQM Human Details
            string strDenID = Session["Den_Hum_IDs"].ToString();
            string strNumId = Session["Num_Hum_IDs"].ToString();
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration().Configure();
            //string[] conString = cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString).ToString().Split(';');
            string[] conString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString().Split(';');
            string sDataBase = string.Empty;
            string sDataSource = string.Empty;
            string sUserId = string.Empty;
            string sPassword = string.Empty;
            string sPort = "3306";
            for (int i = 0; i < conString.Length; i++)
            {
                if (conString[i].ToString().ToUpper().Contains("DATABASE=") == true)
                {
                    sDataBase = conString[i].ToString().Split('=')[1];
                }
                if (conString[i].ToString().ToUpper().Contains("DATA SOURCE") == true)
                {
                    sDataSource = conString[i].ToString().Split('=')[1];
                }
                if (conString[i].ToString().ToUpper().Contains("USER ID") == true)
                {
                    sUserId = conString[i].ToString().Split('=')[1];
                }
                if (conString[i].ToString().ToUpper().Contains("PASSWORD") == true)
                {
                    sPassword = conString[i].ToString().Split('=')[1];
                }
                if (conString[i].ToString().ToUpper().Contains("PORT") == true)
                {
                    sPort = conString[i].ToString().Split('=')[1];
                }
            }
            //string sodaURL = "jdbc:mysql://" + sDataSource + ":" + sPort + "/" + sDataBase;
            //string sodaUser = sUserId;
            //string sodaPassword = sPassword;
            string strPath = string.Empty;
            //string sBIRTReportUrl = System.Configuration.ConfigurationManager.AppSettings["BIRTReportUrl"].ToString();

            //strPath = sBIRTReportUrl + "Human_Details.rptdesign" + "&strDenID=" + strDenID + "&strNumId=" + strNumId + "&odaURL=" + sodaURL + "&odaUser=" + sodaUser + "&odaPassword=" + sodaPassword;
          
            string sodaURL = string.Empty;
            string sAzure = System.Configuration.ConfigurationManager.AppSettings["Azure"].ToString();
            if (sAzure == "Y")
                sodaURL = "jdbc:mysql://" + sDataSource + ":" + sPort + "/" + sDataBase + "?useSSL=true&requireSSL=false";
            else
                sodaURL = "jdbc:mysql://" + sDataSource + ":" + sPort + "/" + sDataBase;

            string sodaUser = sUserId;
            string sodaPassword = sPassword;
            string sDBConnection = "&odaURL=" + sodaURL + "&odaUser=" + sodaUser + "&odaPassword=" + sodaPassword;
            string sBIRTReportUrl = System.Configuration.ConfigurationManager.AppSettings["BIRTReportUrl_"+ClientSession.LegalOrg].ToString();
            strPath = sBIRTReportUrl + "Human_Details.rptdesign" +sDBConnection + "&strDenID=" + strDenID + "&strNumId=" + strNumId + "&odaURL=" + sodaURL + "&odaUser=" + sodaUser + "&odaPassword=" + sodaPassword + "&legal_org=" + ClientSession.LegalOrg;

            ProcessiFrame.Attributes.Add("src", strPath);

        }


    }
}