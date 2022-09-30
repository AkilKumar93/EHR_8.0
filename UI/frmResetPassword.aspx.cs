using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections;
using Telerik.Web.UI;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Acurus.Capella.UI
{
    public partial class frmResetPassword : System.Web.UI.Page
    {
        UserManager objUserMngr = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<User> ilstUser = new List<User>();
            //Hashtable loginhash = new Hashtable();
          
            if(!IsPostBack)
            {
                //Old Code
                //ilstUser = objUserMngr.GetUserList(ClientSession.LegalOrg);
                //if(ilstUser.Count>0)
                //{
                //    cboUserName.Items.Add(new Telerik.Web.UI.RadComboBoxItem());
                //    for (int i = 0; i < ilstUser.Count; i++)
                //    {
                //        cboUserName.Items.Add(new Telerik.Web.UI.RadComboBoxItem(ilstUser[i].user_name));
                //        loginhash.Add(ilstUser[i].user_name, ilstUser[i].password);
                //    }
                //}
                //Gitlab# 2485 - Physician Name Display Change
                IList<string> phyList = new List<string>();
                PatientNotesManager objPatNotesMngr = new PatientNotesManager();
                phyList = objPatNotesMngr.MapPhysicianUserListForFacility("SHOW ALL", ClientSession.LegalOrg);

                SortedDictionary<string, string> hashphyList = new SortedDictionary<string, string>();
                for (int iCount = 0; iCount < phyList.Count; iCount++)
                {
                    if (hashphyList.ContainsKey(phyList[iCount].ToString().Split('|')[1]) == false)
                    {
                        hashphyList.Add(phyList[iCount].ToString().Split('|')[1], phyList[iCount].ToString().Split('|')[0]);
                    }
                }

                foreach (var item in hashphyList)
                {
                    cboUserName.Items.Add(new Telerik.Web.UI.RadComboBoxItem(item.Key, item.Value));
                }

                //    for (int iCount=0;iCount<patientlst.Count;iCount++)
                //{
                //    cboUserName.Items.Add(new Telerik.Web.UI.RadComboBoxItem(patientlst[iCount].ToString().Split('|')[1], patientlst[iCount].ToString().Split('|')[0]));
                //    //loginhash.Add(ilstUser[i].user_name, ilstUser[i].password);
                //}
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            IList<User> login;
            //Old Code
            //login = objUserMngr.GetUser(cboUserName.Text);
            //Gitlab# 2485 - Physician Name Display Change
            login = objUserMngr.GetUser(((RadComboBoxItem)cboUserName.SelectedItem).Value);
            login[0].password = "Password1!";
            if (hdnLocalTime.Value != "")
                login[0].Password_Changed_Date = Convert.ToDateTime(hdnLocalTime.Value);
            objUserMngr.UpdatePassword(login, string.Empty);
            ClientScript.RegisterStartupScript(this.Page.GetType(), "Error", "DisplayErrorMessage('40001')", true);
        }
    }
}