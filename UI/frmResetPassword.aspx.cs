using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections;

namespace Acurus.Capella.UI
{
    public partial class frmResetPassword : System.Web.UI.Page
    {
        UserManager objUserMngr = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<User> ilstUser = new List<User>();
            Hashtable loginhash = new Hashtable();
          
            if(!IsPostBack)
            {
                ilstUser = objUserMngr.GetUserList(ClientSession.LegalOrg);
                if(ilstUser.Count>0)
                {
                    cboUserName.Items.Add(new Telerik.Web.UI.RadComboBoxItem());
                    for (int i = 0; i < ilstUser.Count; i++)
                    {
                        cboUserName.Items.Add(new Telerik.Web.UI.RadComboBoxItem(ilstUser[i].user_name));
                        loginhash.Add(ilstUser[i].user_name, ilstUser[i].password);
                    }
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            IList<User> login;
            login = objUserMngr.GetUser(cboUserName.Text);
           
            login[0].password = "Password1!";
            if (hdnLocalTime.Value != "")
                login[0].Password_Changed_Date = Convert.ToDateTime(hdnLocalTime.Value);
            objUserMngr.UpdatePassword(login, string.Empty);
            ClientScript.RegisterStartupScript(this.Page.GetType(), "Error", "DisplayErrorMessage('40001')", true);
        }
    }
}