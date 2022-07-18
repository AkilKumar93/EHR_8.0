using System;
using System.Data;
using System.Configuration;
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
    public class SessionExpired : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Context.Session != null)
            {
                if (ClientSession.UserName==string.Empty)
                {
                    string cookie = Request.Headers["Cookie"];
                    if (( cookie!=null) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        Server.Transfer("~/frmSessionExpired.aspx");
                    }
                }
            }
        }
    }
}
