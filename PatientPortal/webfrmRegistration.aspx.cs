using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using System.IO;
using System.Runtime.Serialization;

namespace Acurus.Capella.PatientPortal
{
    public partial class webfrmRegistration : System.Web.UI.Page
    {
        ulong ulMyHumanID = 0;
        HumanManager hnProxy = new HumanManager();
        IList<Human> humanList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
          


            if (Request.QueryString["PatientID"] != null)
            {
                ulMyHumanID = Convert.ToUInt64(Request.QueryString["PatientID"]);
                // Added by manimozhi on jan 18th 2012
                var serializer = new NetDataContractSerializer();
                humanList = hnProxy.GetPatientDetailsUsingPatientInformattion(ulMyHumanID);
                //object objHumanMgr = (object)serializer.ReadObject(objStream);
                //humanList = (List<Human>)objHumanMgr;
                //humanList = hnProxy.GetPatientInformationUsingHumanId(ulMyHumanID);
            }

           
            if (EMail.Text == string.Empty)
            {
                lblAlertText.Text = "Enter the EMail";
                EMail.Focus();
                return;
            }

            if (DateofBirth.Text == string.Empty)
            {
                lblAlertText.Text = "Enter the DateofBirth";
                DateofBirth.Focus();
                return;
            }

            if (PIN.Text == string.Empty)
            {
                lblAlertText.Text = "Enter the PIN";
                PIN.Focus();
                return;
            }

             if ( Password.Text == string.Empty)
            {
                lblAlertText.Text = "Enter the Password";
                Password.Focus();
                return;
            }

             if (ConfirmPassword.Text == string.Empty)
             {
                 lblAlertText.Text = "Enter the Confirm Password";
                 ConfirmPassword.Focus();
                 return;
             }

             if (Password.Text != ConfirmPassword.Text)
             {
                 lblAlertText.Text = "Password and Confirm Password does not match";
                 Password.Focus();
                 return;
             }

             if (DateTime.Now.Subtract(humanList[0].Mail_Sent_Date).TotalDays > 7)
             {
                 lblAlertText.Text = "Cannot Register. Validity is expired.";
                 return;
             }

            Human hnRecord = humanList[0];

            if (EMail.Text != hnRecord.EMail)
            {
                lblAlertText.Text = "Invalid EMail";
                EMail.Focus();
                return;
            }

            if (DateofBirth.Text != hnRecord.Birth_Date.ToString("dd-MMM-yyyy"))
            {
                lblAlertText.Text = "Invalid Date of Birth";
                DateofBirth.Focus();
                return;
            }

            if (hnRecord.SSN.EndsWith(PIN.Text)==false)
            {
                lblAlertText.Text = "Invalid SSN Pin";
                PIN.Focus();
                return;
            }

            HumanManager hnproxys = new HumanManager();

            hnproxys.SaveHumanPatientPortal(Convert.ToInt32(ulMyHumanID), Password.Text);

            Response.Redirect("webfrmLogin.aspx");
        }


        protected void BasicDatePicker1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
