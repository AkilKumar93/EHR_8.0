using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;

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
    public class TestService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string LoadTestTab()
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            string sCategory = string.Empty;
            IList<string> categoryList = new List<string>();
            TestLookupManager testMngr = new TestLookupManager();
             categoryList = testMngr.GetTestCategoryList(ClientSession.PhysicianUserName);
             if (categoryList != null)
             {
                 for (int i = 0; i < categoryList.Count; i++)
                 {
                     if (i == 0)
                         sCategory = categoryList[i].ToString().Replace("/","");
                     else
                         sCategory += "^" + categoryList[i].ToString().Replace("/","");
                 }
             }
            return sCategory;
        }
    }
}
