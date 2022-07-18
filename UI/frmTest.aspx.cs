using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using System.Net;
using System.IO;
using Acurus.Capella.Core.DTO;
using System.Collections;
using System.Runtime.Serialization;
using System.Data;
using System.Drawing;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Text;
using Acurus.Capella.UI;
using Telerik.Web.UI;
using Acurus.Capella.UI.UserControls;
using System.Web.UI.HtmlControls;

namespace Acurus.Capella.UI
{
    public partial class frmTest : SessionExpired
    {

        IList<FillTestScreen> testScreenList;
        Hashtable HashTestID = new Hashtable();
        Hashtable HashVersion = new Hashtable();
        Hashtable HashTestLookupID = new Hashtable();
        TestManager testMngr = new TestManager();
        string sMyCategory = string.Empty;


        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        if (Session["TestTable"] != null)
        //        {
        //            Table testTable = (Table)Session["TestTable"];
        //            try
        //            {
        //                divTest.Controls.Add(testTable);

        //            }
        //            catch
        //            {

        //            }
        //        }
        //    }

        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientSession.FlushSession();
                TestLookupManager testlookupMngr = new TestLookupManager();

                btnSave.Enabled = false;
                if (Request["TabName"]!=null)
                    sMyCategory = Request["TabName"].ToString();
                testScreenList = testlookupMngr.GetTestLookupListFromServer(sMyCategory, ClientSession.PhysicianUserName, ClientSession.EncounterId);
                Session["testScreenList"] = testScreenList;
                Session["CategoryName"] = sMyCategory;
            }
            testScreenList = (IList<FillTestScreen>)Session["testScreenList"];
            if (!IsPostBack)
                FillMyTestList(testScreenList);

            else
            {

                FillMyTestList(testScreenList);

                HashVersion = (Hashtable)Session["Version"];
                HashTestID = (Hashtable)Session["HashTestID"];
                HashTestLookupID = (Hashtable)Session["HashTestLookupID"];


            }

            if (!IsPostBack)
            {
                ClientSession.processCheck = true;
                SecurityServiceUtility objSecurity = new SecurityServiceUtility();
                objSecurity.ApplyUserPermissions(this.Page);
                btnSave.Enabled = false;
            }

        }

        private void FillMyTestList(IList<FillTestScreen> testScreenList)
        {
            if (testScreenList == null)
            {
                return;
            }
            FillMyEncounterWithCondition(testScreenList);
        }
        private void FillMyEncounterWithCondition(IList<FillTestScreen> testScreenList)
        {
            string sOldSystem = string.Empty;
            string sNewSystem = string.Empty;
            Table tbltest = new Table();
            for (int i = 0; i < testScreenList.Count; i++)
            {

                if (testScreenList[i].Question.Contains('"') || testScreenList[i].Question.Contains(':') || testScreenList[i].Question.Contains("."))
                {
                    testScreenList[i].Question = testScreenList[i].Question.Replace('"', ' ').Replace(":", "").Replace(".", "");
                }

                sNewSystem = testScreenList[i].Test;
                TableCell tc = new TableCell();
                TableRow tr1 = new TableRow();
                TableRow tr2 = new TableRow();
                TableRow tr3 = new TableRow();


                HtmlInputText lbl = new HtmlInputText();
                if (sOldSystem != sNewSystem)
                {
                    tc.ColumnSpan = 12;
                    lbl.Value = testScreenList[i].Test;
                    lbl.EnableViewState = false;
                    ////lbl.Style.Add("font-size", "small");
                    ////lbl.Style.Add("color", "Black");
                    ////lbl.Style.Add("font-weight", "bold");
                    ////lbl.Style.Add("background-color", "#BFDBFF");
                    ////lbl.Style.Add("font-family", "Serif");
                    lbl.Attributes.Add("class", "Headergroupstyle");
                    //lbl.Style.Add("Width", "100%");
                    //lbl.Style.Add("border-width", "1px");
                    //lbl.Style.Add("border-color", "black");
                    lbl.Attributes.Add("readonly", "readonly");




                    //lbl.ForeColor = Color.Black;
                    //
                    //lbl.BackColor = Color.FromArgb(191, 219, 255);
                    //lbl.Width = 940;
                    //lbl.Height = 19;
                    //lbl.BorderWidth = 1;
                    //lbl.Font.Bold = true;
                    tc.Controls.Add(lbl);
                    tr1.Cells.Add(tc);
                    tbltest.Rows.Add(tr1);
                }

                HtmlGenericControl lbltest = new HtmlGenericControl();
                tc = new TableCell();
                lbltest.ID = "lbl" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString();
                // lbltest.ForeColor = Color.Black;
                lbltest.EnableViewState = false;
                lbltest.InnerHtml = testScreenList[i].Question;
                //lbltest.Style.Add("font-size", "small");
                //lbltest.Style.Add("color", "Black");
                //lbltest.Style.Add("background-color", "White");
                //lbltest.Style.Add("font-family", "Serif");
                lbltest.Attributes.Add("class", "Editabletxtbox");
                lbltest.Style.Add("Width", "200px");
                lbltest.Style.Add("wrap", "hard");
                lbltest.Style.Add("overflow", "hidden");
                lbltest.Style.Add("resize", "none");
                lbltest.Style.Add("ReadOnly", "true");
                //lbltest.Width = 400;
                tc.Controls.Add(lbltest);
                tr2.Cells.Add(tc);


                if (HashVersion.Contains(lbltest.ID.Replace("lbl", "")) == false)
                {
                    HashVersion.Add(lbltest.ID.Replace("lbl", ""), testScreenList[i].Version);
                    HashTestID.Add(lbltest.ID.Replace("lbl", ""), testScreenList[i].TestID);
                    HashTestLookupID.Add(lbltest.ID.Replace("lbl", ""), testScreenList[i].TestLookupId);
                }


                if (testScreenList[i].Is_Status == "Y")
                {
                    HtmlSelect cbotest = new HtmlSelect();
                    tc = new TableCell();
                   // cbotest = new RadComboBox();
                    cbotest.ID = "cbo" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString();
                    string[] straryStatus = testScreenList[i].StatusOptions.ToString().Split('|');
                    if (straryStatus != null)
                    {
                        for (int j = 0; j < straryStatus.Count(); j++)
                            cbotest.Items.Add(new ListItem(straryStatus[j]));
                    }
                    if (testScreenList[i].Status != string.Empty)
                    {
                        for (int k = 0; k < cbotest.Items.Count; k++)
                        {
                            if (cbotest.Items[k].Text.ToUpper() == testScreenList[i].Status.ToUpper())
                                cbotest.SelectedIndex = k;
                        }

                    }
                    //cbotest.Style.Add("font-family", "Serif");
                    //cbotest.Style.Add("font-size", "small");
                    cbotest.Attributes.Add("class", "Editabletxtbox");
                    cbotest.Style.Add("position", "static");
                    cbotest.Attributes.Add("onchange", "EnableSave();");
                    cbotest.Style.Add("Width", "150px");
                    //cbotest.Style.Add("background-color", "White");
                   
                    tc.Controls.Add(cbotest);
                    tr2.Cells.Add(tc);


                }


                if (testScreenList[i].Is_Score == "Y")
                {
                    RadNumericTextBox txtScore = new RadNumericTextBox();
                    tc = new TableCell();
                    txtScore.ID = "txtScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString();
                    txtScore.Text = testScreenList[i].Score;
                    txtScore.Attributes.Add("onkeypress", "EnableSave();");
                    txtScore.Attributes.Add("onchange", "EnableSave();");
                    txtScore.EnableViewState = false;
                    txtScore.NumberFormat.DecimalDigits = 0;
                    txtScore.NumberFormat.DecimalSeparator = " ";
                    txtScore.NumberFormat.KeepNotRoundedValue = true;
                    txtScore.NumberFormat.KeepTrailingZerosOnFocus = true;

                    txtScore.NumberFormat.ZeroPattern = "n";
                    txtScore.Width = 100;
                    txtScore.IncrementSettings.InterceptMouseWheel = false;
                    txtScore.IncrementSettings.InterceptArrowKeys = false;
                  //  txtScore.Attributes.Add("onkeyup", "return textboxLeave('" + txtScore.ID + "');");
                    tc.Controls.Add(txtScore);
                    tr2.Cells.Add(tc);

                    HtmlGenericControl lblScore = new HtmlGenericControl();
                    lblScore.ID = "lblScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString();
                    lblScore.Style.Add("color", "Black");
                    //lblScore.ForeColor = Color.Black;
                    lblScore.EnableViewState = false;
                    lblScore.InnerHtml = "/" + testScreenList[i].Maximum_Score;
                    lblScore.Style.Add("Width", "50px");
                   // lblScore.Width = 50;
                    tc.Controls.Add(lblScore);
                    tr2.Cells.Add(tc);
                }
                if (testScreenList[i].Is_Status == "N" && testScreenList[i].Is_Score == "N")
                {
                    HtmlSelect cbo = new HtmlSelect();
                    tc = new TableCell();
                    cbo.ID = "cbo1" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString();
                    cbo.Attributes.Add("onchange", "EnableSave();");
                    cbo.Attributes.Add("class", "Editabletxtbox");
                    cbo.Style.Add("position", "static");
                    cbo.Style.Add("Width", "150px");
                    //cbo.Style.Add("background-color", "White");
                    //cbo.Style.Add("font-size", "small");
                    //cbo.Style.Add("font-family", "Serif");
                   
                   // cbo.OnClientSelectedIndexChanged = "EnableSave();";
                    //cbo.Style["position"] = "static";
                    //cbo.Width = 150;
                    cbo.Visible = false;
                    //cbo.BackColor = Color.White;
                    tc.Controls.Add(cbo);
                    tr2.Cells.Add(tc);
                }
                //if (testScreenList[i].Is_Notes == "Y")
                {
                    CustomDLCNew userCtrl = (CustomDLCNew)LoadControl("~/UserControls/customDLCNew.ascx");
                    tc = new TableCell();
                    userCtrl.txtDLC.Text = testScreenList[i].Notes;
                    userCtrl.ID = "DLC" + (testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString()).Replace(" ", "").Replace("?", "").Replace("(", "").Replace(")", "").Replace(",", "");
                    userCtrl.TextboxHeight = new Unit("40px");
                    userCtrl.txtDLC.Attributes.Add("onkeypress", "EnableSave();");
                    userCtrl.txtDLC.Attributes.Add("onchange", "EnableSave();");
                    userCtrl.TextboxWidth = new Unit("400px");
                    userCtrl.Value = "TEST_NOTES-" + (testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString());//.Replace(" ", "").Replace("?", "").Replace("(", "").Replace(")", "").Replace(",", "");
                    userCtrl.txtDLC.Attributes.Add("UserRole", ClientSession.UserRole);
                    tc.Controls.Add(userCtrl);
                    tr2.Cells.Add(tc);
                }

                //tc = new TableCell();
                //HtmlGenericControl lblLine = new HtmlGenericControl();
                //lblLine.ID = "lbl" + i.ToString();
                //lblLine.EnableViewState = false;
                //lblLine.InnerHtml = "___________________________________________________________________________________________________________________________________";
                //tc.ColumnSpan = 12;
                //tc.Controls.Add(lblLine);
                //tr3.Cells.Add(tc);

                sOldSystem = sNewSystem;


                tbltest.Rows.Add(tr2);
                tbltest.Rows.Add(tr3);



            }
           // Session["TestTable"] = tbltest;
            Session["Version"] = HashVersion;
            Session["HashTestID"] = HashTestID;
            Session["HashTestLookupID"] = HashTestLookupID;
            divTest.Controls.Add(tbltest);

        }

        void pbDropdown_Click(object sender, ImageClickEventArgs e)
        {
            if (Hidden1.Value == "True")
                btnSave.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            hdnSave.Value = "";
            IList<FillTestScreen> TemptestScreen = new List<FillTestScreen>();
            if (Convert.ToInt32(HashVersion[testScreenList[0].Test + "-" + testScreenList[0].Question]) == 0)
            {
                testScreenList = AppendTest();
            }
            else
            {
                TemptestScreen = UpdateTest();
                if (TemptestScreen.Count > 0)
                {
                    testScreenList = TemptestScreen;
                }
            }
            if (hdnSave!=null && hdnSave.Value != "true")
            {
               // RadScriptManager1.AsyncPostBackErrorMessage = "true";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('1180001');top.window.document.getElementById('ctl00_Loading').style.display = 'none';", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "SavedSuccessfully();", true);
                // ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('1180001');", true);
                btnSave.Enabled = false;
            }
            else { btnSave.Enabled = true; }
            if (testScreenList!=null)
            {
                for (int i = 0; i < testScreenList.Count; i++)
                {
                    HashTestID[testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString()] = testScreenList[i].TestID;
                    HashTestLookupID[testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString()] = testScreenList[i].TestLookupId;
                    HashVersion[testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString()] = testScreenList[i].Version;
                }
            }
           
            Session["testScreenList"] = testScreenList;
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);                      

        }

        private IList<FillTestScreen> AppendTest()
        {
            IList<Test> testList = new List<Test>();
            for (int i = 0; i < testScreenList.Count; i++)
            {
                if (Session["CategoryName"]!=null)
                    sMyCategory = (string)Session["CategoryName"];
                Test test = new Test();
                test.Encounter_ID = ClientSession.EncounterId;
                test.Created_By = ClientSession.UserName;
                //if (hdnLocalTime.Value != string.Empty)
                //    test.Created_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                test.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                test.Human_ID = ClientSession.HumanId;
                test.Physician_ID = ClientSession.PhysicianId;
                test.Test_Name = testScreenList[i].Test;
                test.Question_Name = testScreenList[i].Question;
                test.Category = sMyCategory;
                testScreenList[i].CreatedBy = test.Created_By;
                testScreenList[i].CreatedDateTime = test.Created_Date_And_Time;
                //if (testScreenList[i].Is_Notes == "Y")
                test.Test_Notes = ((CustomDLCNew)pnlTest.FindControl("DLC" + (testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString()).Replace(" ", "").Replace("?", "").Replace("(", "").Replace(")", "").Replace(",", ""))).txtDLC.Text;
                if (testScreenList[i].Is_Score == "Y")
                    test.Score = ((RadNumericTextBox)pnlTest.FindControl("txtScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString())).Text;
                if (testScreenList[i].Is_Status == "Y")
                    test.Status = ((HtmlSelect)pnlTest.FindControl("cbo" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString())).Value;
                test.Version = Convert.ToInt32(HashVersion[test.Test_Name.Trim().ToString() + "-" + test.Question_Name.Trim().ToString()]);
                test.Test_Lookup_Id = Convert.ToUInt64(HashTestLookupID[test.Test_Name.Trim().ToString() + "-" + test.Question_Name.Trim().ToString()]);
                if (test.Score != "")
                {
                    string ResultScore = ((HtmlGenericControl)pnlTest.FindControl("lblScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString())).InnerHtml;
                    if (Convert.ToInt32(test.Score) > Convert.ToInt32(ResultScore.Replace("/", "")))
                    {
                        RadNumericTextBox txtNumeric = (RadNumericTextBox)pnlTest.FindControl("txtScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString());
                        txtNumeric.Focus();
                        hdnSave.Value = "true";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('240008'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);     
                        break;

                    }
                }
                testList.Add(test);

            }
            if (hdnSave.Value != "true")
                return testMngr.AppendTest(testList.ToArray(), string.Empty, testScreenList);
            else
                return testScreenList;
                                                                                                                                                                                                                    
        }
        private IList<FillTestScreen> UpdateTest()
        {
            IList<Test> testList = new List<Test>();
            if (testScreenList!=null)
            {
                for (int i = 0; i < testScreenList.Count; i++)
                {
                    if (Session["CategoryName"] != null)
                        sMyCategory = (string)Session["CategoryName"];
                    Test test = new Test();
                    test.Encounter_ID = ClientSession.EncounterId;
                    test.Modified_By = ClientSession.UserName;
                    //if (hdnLocalTime.Value != string.Empty)
                    //    test.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                    test.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                    test.Human_ID = ClientSession.HumanId;
                    test.Physician_ID = ClientSession.PhysicianId;
                    test.Test_Name = testScreenList[i].Test;
                    test.Question_Name = testScreenList[i].Question;
                    test.Category = sMyCategory;
                    test.Created_Date_And_Time = testScreenList[i].CreatedDateTime;
                    test.Created_By = testScreenList[i].CreatedBy;
                    testScreenList[i].ModifiedBy = test.Modified_By;
                    testScreenList[i].ModifiedDateTime = test.Modified_Date_And_Time;
                    //if (testScreenList[i].Is_Notes == "Y")
                    test.Test_Notes = ((CustomDLCNew)pnlTest.FindControl("DLC" + (testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString()).Replace(" ", "").Replace("?", "").Replace("(", "").Replace(")", "").Replace(",", ""))).txtDLC.Text;
                    if (testScreenList[i].Is_Score == "Y")
                        test.Score = ((RadNumericTextBox)pnlTest.FindControl("txtScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString())).Text;
                    if (testScreenList[i].Is_Status == "Y")
                        test.Status = ((HtmlSelect)pnlTest.FindControl("cbo" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString())).Value;
                    test.Version = Convert.ToInt32(HashVersion[test.Test_Name.Trim().ToString() + "-" + test.Question_Name.Trim().ToString()]);
                    test.Test_Lookup_Id = Convert.ToUInt64(HashTestLookupID[test.Test_Name.Trim().ToString() + "-" + test.Question_Name.Trim().ToString()]);
                    test.Id = Convert.ToUInt64(HashTestID[test.Test_Name.Trim().ToString() + "-" + test.Question_Name.Trim().ToString()]);

                    if (test.Score != "")
                    {
                        string ResultScore = ((HtmlGenericControl)pnlTest.FindControl("lblScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString())).InnerHtml;
                        if (Convert.ToInt32(test.Score) > Convert.ToInt32(ResultScore.Replace("/", "")))
                        {
                            RadNumericTextBox txtNumeric = (RadNumericTextBox)pnlTest.FindControl("txtScore" + testScreenList[i].Test.Trim().ToString() + "-" + testScreenList[i].Question.Trim().ToString());
                            txtNumeric.Focus();
                            hdnSave.Value = "true";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('240008'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);   
                            break;

                        }
                    }
                    testList.Add(test);

                }
            }
          
            if (hdnSave.Value != "true")
            {
                return testMngr.UpdateTest(testList.ToArray(), string.Empty, testScreenList);

            }
            else
                return testScreenList;

        }

    }
}
