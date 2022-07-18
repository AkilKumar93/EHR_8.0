using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PatientPortal
{
    public partial class webfrmLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string redirectUrl = "webfrmLogin.aspx"; 
            FormsAuthentication.SignOut();
            Response.Redirect(redirectUrl);  
        }
    }
}
