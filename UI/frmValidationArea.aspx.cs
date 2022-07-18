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
    public partial class frmValidationArea : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ScreenName"] != null && Request["ScreenName"] == "TestArea")
            {
                btncancel.Visible = false;
                btnYes.Text = "Ok";
                btnNo.Text = "Cancel";
            }

            if (Request["ScreenName"] != null && Request["ScreenName"] == "TestArea")
            {
                btncancel.Visible = false;
                btnYes.Text = "Ok";
                btnNo.Text = "Cancel";
            }

            if (Request["Title"] != null && Request["Title"] == "ManageProblemListMessage")
            {
                Label1.Text = "Please enter the date diagnosed in the Format yyyyMMMdd or yyyyMMM or yyyy";
                Label1.Width = 400;
                btncancel.Visible = false;
                btnYes.Text = "Ok";
                btnNo.Visible = false;
                Page.Title = "Message";
            }

            if (Request["ScreenName"] != null && Request["ScreenName"] == "BodyImage")
            {
                Label1.Text = "Do You Want To Clear All Images ?";
                btncancel.Text = "Cancel";
                btncancel.Width = Unit.Pixel(60);
                btnNo.Text = "All Images";
                btnNo.Width = Unit.Pixel(77);
                //btnNo.Visible = false;
                btnYes.Text = "This Image";
                btnYes.Width = Unit.Pixel(75);
                this.Title = "Select An Option";
            }
            else
            {
                if (Request["Title"] != "ManageProblemListMessage")
                {

                    if (Request["Title"] != null)
                        this.Title = Request["Title"].ToString();
                    if (Request["ErrorMessages"] != null)
                        Label1.Text = Request["ErrorMessages"].ToString();


                    btncancel.Visible = true;
                    btnYes.Text = "Yes";
                    btnNo.Text = "No";
                }
            }


        }


    }
}
