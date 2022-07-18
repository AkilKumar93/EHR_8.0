using System;
using System.Collections;
using System.Collections.Generic;
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
using AjaxControlToolkit.Design;
using AjaxControlToolkit;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using Telerik.Web.Design;
using Telerik.Web.UI;


namespace Acurus.Capella.UI
{
    public partial class frmProviderValidation : System.Web.UI.Page
    {
        PhysicianManager objPhysicianManager = new PhysicianManager();
        bool IndividualFormClick = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                PhysicianLibrary objPhysicianLibraryEncID = objPhysicianManager.GetphysiciannameByPhyID(Convert.ToUInt32( ClientSession.FillEncounterandWFObject.EncRecord.Encounter_Provider_ID)).ToList<PhysicianLibrary>()[0];

                PhysicianLibrary objPhysicianLibraryAppID = objPhysicianManager.GetphysiciannameByPhyID(Convert.ToUInt32(ClientSession.FillEncounterandWFObject.EncRecord.Appointment_Provider_ID)).ToList<PhysicianLibrary>()[0];

                lblMsg.Text += objPhysicianLibraryAppID.PhyPrefix + objPhysicianLibraryAppID.PhyFirstName + " " + objPhysicianLibraryAppID.PhyMiddleName + " " + objPhysicianLibraryAppID.PhyLastName + "  " + objPhysicianLibraryAppID.PhySuffix + " kindly select an option for loading the  Previous  encounter data";
                btnOption1.Text += objPhysicianLibraryAppID.PhyPrefix + objPhysicianLibraryAppID.PhyFirstName + " " + objPhysicianLibraryAppID.PhyMiddleName + " " + objPhysicianLibraryAppID.PhyLastName + "  " + objPhysicianLibraryAppID.PhySuffix;
                btnOption2.Text += objPhysicianLibraryEncID.PhyPrefix + objPhysicianLibraryEncID.PhyFirstName + " " + objPhysicianLibraryEncID.PhyMiddleName + " " + objPhysicianLibraryEncID.PhyLastName + "  " + objPhysicianLibraryEncID.PhySuffix;
                UIManager.Is_Cancel = false;


                hdnButton1.Value = ClientSession.FillEncounterandWFObject.EncRecord.Appointment_Provider_ID.ToString();
                hdnButton2.Value = ClientSession.FillEncounterandWFObject.EncRecord.Encounter_Provider_ID.ToString();
                hdnButton3.Value = "";
            }
        }

        protected void btnOption1_Click(object sender, EventArgs e)
        {
            if (!IndividualFormClick)
                UIManager.select_physician_id = Convert.ToUInt32(ClientSession.FillEncounterandWFObject.EncRecord.Appointment_Provider_ID);
            else
                UIManager.Individual_select_physician_Id = Convert.ToUInt32(ClientSession.FillEncounterandWFObject.EncRecord.Appointment_Provider_ID);
        }

        protected void btnOption2_Click(object sender, EventArgs e)
        {

            if (!IndividualFormClick)
                UIManager.select_physician_id = Convert.ToUInt32(ClientSession.FillEncounterandWFObject.EncRecord.Encounter_Provider_ID);
            else
                UIManager.Individual_select_physician_Id = Convert.ToUInt32(ClientSession.FillEncounterandWFObject.EncRecord.Encounter_Provider_ID);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            if (!IndividualFormClick)
                UIManager.select_physician_id = 0;
            else
            {
                UIManager.Individual_select_physician_Id = 0;
                UIManager.Is_Cancel = true;
            }

        }
    }
}
