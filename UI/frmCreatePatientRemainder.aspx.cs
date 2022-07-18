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


using Telerik.Web;
using Telerik.Web.UI;
using Acurus.Capella.DataAccess.ManagerObjects;

using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Acurus.Capella.UI
{
    public partial class frmCreatePatientRemainder : System.Web.UI.Page
    {
        string strStatus = string.Empty;
        string strDefault = string.Empty;

        IList<RuleDTO> objRuleDTO = null;
        RuleMaster objRule = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlCreateAlert.Visible = false;
           
            if (!IsPostBack)
            {
                IList<StaticLookup> iFieldLookup = new List<StaticLookup>();
                StaticLookupManager objLookupManager = new StaticLookupManager();

                iFieldLookup = objLookupManager.getStaticLookupByFieldName("REMINDER STATUS");

                chkActiveRule.Checked = true;
                Session["Status"] = "Active";
                if (iFieldLookup != null && iFieldLookup.Count > 0)
                {
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        cboStatus.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }
                    strDefault = iFieldLookup[0].Default_Value;
                    cboStatus.Text = iFieldLookup[0].Default_Value;
                }

                iFieldLookup = objLookupManager.getStaticLookupByFieldName("AGEVALUE");
                if (iFieldLookup != null)
                {
                    cboAgeRange.Items.Add(new RadComboBoxItem(""));
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        cboAgeRange.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }
                }

                iFieldLookup = objLookupManager.getStaticLookupByFieldName("LAB RESULT VALUE");
                if (iFieldLookup != null)
                {
                    cboRange.Items.Add(new RadComboBoxItem(""));
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        cboRange.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }
                }
                iFieldLookup = objLookupManager.getStaticLookupByFieldName("SEX");

                if (iFieldLookup != null)
                {
                    cboGender.Items.Add(new RadComboBoxItem(""));
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        if (iFieldLookup[i].Value != "")
                            cboGender.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }


                }

                //Added By ThiyagarajanM

                iFieldLookup = objLookupManager.getStaticLookupByFieldName("RACE");
                if (iFieldLookup != null && iFieldLookup.Count > 0)
                {

                    cboRace.Items.Add(new RadComboBoxItem(""));
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        cboRace.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }
                }

                iFieldLookup = objLookupManager.getStaticLookupByFieldName("COMMUNICATION TYPE");
                if (iFieldLookup != null && iFieldLookup.Count > 0)
                {


                    cboCommunication.Items.Add(new RadComboBoxItem(""));
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        cboCommunication.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }

                }

                iFieldLookup = objLookupManager.getStaticLookupByFieldName("ETHNICITY");
                if (iFieldLookup != null && iFieldLookup.Count > 0)
                {


                    cboEthnicity.Items.Add(new RadComboBoxItem(""));
                    for (int i = 0; i < iFieldLookup.Count; i++)
                    {
                        cboEthnicity.Items.Add(new RadComboBoxItem(iFieldLookup[i].Value));
                    }

                }


                RuleMasterManager objRuleMasterManager = new RuleMasterManager();
                objRuleDTO = new List<RuleDTO>();
                objRuleDTO = objRuleMasterManager.GetAllRule("Active",ClientSession.LegalOrg);
                LoadGrid(objRuleDTO);
                Session["objRuleDTO"] = objRuleDTO;
                //  this.Text = UtilityManager.aAssignScreenTitle(this, this.Text);

                //lstExpectedAction = new RadListBox();
                //this.Controls.Add(lstExpectedAction);
                //this.lstExpectedAction.Visible = false;
                //lstExpectedAction.SelectedIndexChanged += new EventHandler(lstExpectedAction_SelectedIndexChanged);
                //lstExpectedAction.Click += new EventHandler(lstExpectedAction_Click);
                //lstExpectedAction.KeyDown += new KeyEventHandler(lstExpectedAction_KeyDown);

              btnAdd.Enabled = false;

              PnlValue.Enabled = false;

            }
            if (txtRuleName.Text != string.Empty)
            {
                btnAdd.Enabled = true;
            }
        }
        private void LoadGrid(IList<RuleDTO> RuleDto)
        {
            if (RuleDto != null)
            {
                Session["objRuleDTO"] = RuleDto;
                grdPatientRemainder.DataSource = null;
                grdPatientRemainder.DataBind();


                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("RuleID", typeof(string)));
                dt.Columns.Add(new DataColumn("RuleName", typeof(string)));
                dt.Columns.Add(new DataColumn("Description", typeof(string)));
                dt.Columns.Add(new DataColumn("ExpectedAction", typeof(string)));
                dt.Columns.Add(new DataColumn("Alert", typeof(string)));
                dt.Columns.Add(new DataColumn("Freq.Interval", typeof(string)));
                dt.Columns.Add(new DataColumn("PrimaryKey", typeof(string)));

                for (int i = 0; i < RuleDto.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["RuleID"] = RuleDto[i].Rule_Master.Id.ToString();
                    dr["RuleName"] = RuleDto[i].Rule_Master.Rule_Name.ToString();
                    dr["Description"] = RuleDto[i].Rule_Master.Rule_Description.ToString();
                    dr["ExpectedAction"] = RuleDto[i].Rule_Master.Expected_Action.ToString();
                    dr["Alert"] = RuleDto[i].Rule_Master.Alert.ToString();
                    dr["Freq.Interval"] = RuleDto[i].Rule_Master.Frequency.ToString();
                    dr["PrimaryKey"] = RuleDto[i].Rule_Master.Id.ToString();
                    dt.Rows.Add(dr);

                }

                grdPatientRemainder.DataSource = dt;
                grdPatientRemainder.DataBind();

            }

        }
         

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string YesNoCancel = hdnMessageType.Value;
            hdnMessageType.Value = string.Empty;
            if (txtRuleName.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('7410006');", true);
                txtRuleName.Focus();
                return;
            }
            if (cboStatus.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('7410008');", true);
                cboStatus.Focus();
                return;



            }
            if ((cboRange.Text != string.Empty && txtValueFrom.Text == string.Empty) || (cboRange.Text == string.Empty && txtValueFrom.Text != string.Empty))
            { 
                PnlValue.Enabled=true;
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('7410004');", true);
                return;


            }
            if ((cboAgeRange.Text != string.Empty && txtAgeFrom.Text == string.Empty && txtAgeTo.Text == string.Empty) || (cboAgeRange.Text == string.Empty && (txtAgeFrom.Text != string.Empty || txtAgeTo.Text != string.Empty)))
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('7410005');", true);
                return;


            }
            if (txtAlertDay.Text != string.Empty && txtFrequency.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('7410007');", true);
                return;


            }
            if (chkActiveRule.Checked)
                strStatus = "Active";
            else
                strStatus = "Inactive";

            // if((txtAgeFrom.Text!=string.e)
            RuleProblem objRuleProblem = null;
            RuleMedicationAndAllergy objRuleMedication = null;
            RuleMaster objRuleMaster = new RuleMaster();
            RuleLabResultReminder objRuleLabResult = null;
            IList<RuleProblem> RuleProblemList = new List<RuleProblem>();
            IList<RuleMedicationAndAllergy> objMedication = new List<RuleMedicationAndAllergy>();
            IList<RuleMedicationAndAllergy> objAllergy = new List<RuleMedicationAndAllergy>();
            IList<RuleLabResultReminder> objLabResult = new List<RuleLabResultReminder>();

            if (Session["UpdateItem"] != null)
            {
                objRuleMaster = ((IList<RuleMaster>)Session["UpdateItem"])[0];
            }

            //if (objRule != null)
            //objRuleMaster = objRule;
            objRuleMaster.Rule_Name = txtRuleName.Text;
            objRuleMaster.Rule_Description = txtDescription.Text;
            objRuleMaster.Is_Status = cboStatus.Text;
            //objRuleMaster.Last_Run_Date = UtilityManager.ConvertToUniversal();
            if (txtAlertDay.Text != string.Empty)
                objRuleMaster.Alert = Convert.ToInt32(txtAlertDay.Text);
            if (txtFrequency.Text != string.Empty)
                objRuleMaster.Frequency = Convert.ToInt32(txtFrequency.Text);
            objRuleMaster.Gender = cboGender.Text;

            if (txtAgeFrom.Text != string.Empty)
            {
                string str = Convert.ToString(DateConversion(Convert.ToInt32(txtAgeFrom.Text), cboAgeRange.Text));
                if (str != "0")
                    objRuleMaster.From_Age = str;
            }
            else
                objRuleMaster.From_Age = txtAgeFrom.Text;
            if (txtAgeTo.Text != string.Empty)
            {
                string str = Convert.ToString(DateConversion(Convert.ToInt32(txtAgeTo.Text), cboAgeRange.Text));
                if (str != "0")
                    objRuleMaster.To_Age = str;
            }
            else
                objRuleMaster.To_Age = txtAgeTo.Text;
            objRuleMaster.Expected_Action = txtExpectedResult.txtDLC.Text;
            objRuleMaster.Age_In = cboAgeRange.Text;
            objRuleMaster.Legal_Org = ClientSession.LegalOrg;
            //New Require
            objRuleMaster.Ethnicity = cboEthnicity.Text;
            objRuleMaster.Race = cboRace.Text;
            objRuleMaster.Communication = cboCommunication.Text;
            //End




            if (txtProblem.Text != string.Empty)
            {
                string[] strSplit = txtProblem.Text.Split(';');
                for (int i = 0; i < strSplit.Length; i++)
                {
                    if (strSplit[i] != string.Empty)
                    {
                        objRuleProblem = new RuleProblem();
                        string[] strText = strSplit[i].Split('-');
                        objRuleProblem.ICD = strText[0];
                        objRuleProblem.Description = strText[1];
                        objRuleProblem.Created_By = ClientSession.UserName;
                        objRuleProblem.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                        RuleProblemList.Add(objRuleProblem);
                    }
                }
            }
            if (txtMedication.Text != string.Empty)
            {
                //                string[] SplitMedication = Convert.ToString(txtMedication.Tag).Split('|');
                string[] SplitMedication = Convert.ToString(txtMedicationTag.Value).Split(';');
                for (int j = 0; j < SplitMedication.Length; j++)
                {
                    if (SplitMedication[j] != string.Empty)
                    {
                        objRuleMedication = new RuleMedicationAndAllergy();
                        string[] splitMed = SplitMedication[j].Split('+');
                        objRuleMedication.NDC = splitMed[2];
                        objRuleMedication.Drug_Name = splitMed[1];
                        objRuleMedication.Rx_Norm_ID = splitMed[0];
                        objRuleMedication.Type = "MEDICATION";
                        objRuleMedication.Created_By = ClientSession.UserName;
                        objRuleMedication.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                        objMedication.Add(objRuleMedication);
                    }
                }
            }
            if (txtMedicationAllergy.Text != string.Empty)
            {

                string[] SplitAllergy = Convert.ToString(txtMedicationAllergyTag.Value).Split(';');
                // string[] SplitAllergy = Convert.ToString(txtMedicationAllergy.Tag).Split('|');
                for (int k = 0; k < SplitAllergy.Length; k++)
                {
                    if (SplitAllergy[k] != string.Empty)
                    {
                        objRuleMedication = new RuleMedicationAndAllergy();
                        string[] splitAll = SplitAllergy[k].Split('+');
                        objRuleMedication.NDC = splitAll[2];
                        objRuleMedication.Drug_Name = splitAll[1];
                        objRuleMedication.Rx_Norm_ID = " ";
                        objRuleMedication.Type = "MEDICATION ALLERGY";
                        objRuleMedication.Created_By = ClientSession.UserName;
                        objRuleMedication.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                        objMedication.Add(objRuleMedication);
                    }
                }
            }

            if (txtLabTestResult.Text != string.Empty)
            {
                // string[] splitLab = Convert.ToString(txtLabTestResult.Tag).Split('+');
                string[] splitLab = Convert.ToString(txtLabTestResultTag.Value).Split('+');
                for (int h = 0; h < splitLab.Length; h++)
                {
                    if (splitLab[h] != string.Empty)
                    {
                        objRuleLabResult = new RuleLabResultReminder();
                        //string[] strLoinc = splitLab[h].Split('|');
                        string[] strLoinc = splitLab[h].Split('|');
                        objRuleLabResult.Loinc = strLoinc[0];
                        if (strLoinc.Length > 1)
                            objRuleLabResult.Lab_Result_Name = strLoinc[1];
                        else
                            objRuleLabResult.Lab_Result_Name = "";

                        objRuleLabResult.Lab_Result_Operator = cboRange.Text;
                        objRuleLabResult.Value = txtValueFrom.Text;
                        objRuleLabResult.Created_By = ClientSession.UserName;
                        objRuleLabResult.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                        objLabResult.Add(objRuleLabResult);
                    }
                }
            }
            RuleMasterManager objPatientRemainderProxy = new RuleMasterManager();

            strStatus = Session["Status"].ToString();
            if (btnAdd.Text == "Update")
            {

                objRuleMaster.Modified_By = ClientSession.UserName;
                objRuleMaster.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objRuleDTO = objPatientRemainderProxy.SaveRuleDTO(objRuleMaster, RuleProblemList.ToArray<RuleProblem>(), objMedication.ToArray<RuleMedicationAndAllergy>(), objLabResult.ToArray<RuleLabResultReminder>(), string.Empty, strStatus,ClientSession.LegalOrg);
                Session["UpdateItem"] = null;
            }
            else
            {
                objRuleMaster.Physician_ID = (int)ClientSession.PhysicianId;
                objRuleMaster.Created_By = ClientSession.UserName;
                objRuleMaster.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                objRuleMaster.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objRuleDTO = objPatientRemainderProxy.SaveRuleDTO(objRuleMaster, RuleProblemList.ToArray<RuleProblem>(), objMedication.ToArray<RuleMedicationAndAllergy>(), objLabResult.ToArray<RuleLabResultReminder>(), string.Empty, strStatus,ClientSession.LegalOrg);
            }
 

          

            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "AutoSave", "AutoSaveButtonStatus('false');", true);


            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SaveSuccessfully", "DisplayErrorMessage('7410002');", true);

            


            Clear();
            Session["objRuleDTO"] = objRuleDTO;
            LoadGrid(objRuleDTO);
            btnAdd.Enabled = false;


          
        }

        private int DateConversion(int iDate, string strFormat)
        {
            int iMonth = 0;
            if (strFormat == "Months")
                iMonth = iDate;
            else if (strFormat == "Years")
                iMonth = iDate * 12;
            return iMonth;
        }

        private void Clear()
        {
            btnAdd.Text = "Add";
            btnClearAll.Text = "Clear All";
            txtRuleName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtProblemTag.Value = string.Empty;
            //txtProblem.Tag = "";
            txtProblem.Text = string.Empty;
            txtMedicationTag.Value = string.Empty;
            // txtMedication.Tag = "";
            txtMedication.Text = string.Empty;
            //  txtMedicationAllergy.Tag = "";
            txtMedicationAllergyTag.Value = string.Empty;
            txtMedicationAllergy.Text = string.Empty;
            //txtLabTestResult.Tag = "";
            txtLabTestResultTag.Value = string.Empty;
            txtLabTestResult.Text = string.Empty;
            cboAgeRange.SelectedIndex = -1;
            cboGender.SelectedIndex = -1;
            cboRange.SelectedIndex = -1;
            txtAgeFrom.Text = string.Empty;
            txtAgeTo.Text = string.Empty;
            txtAlertDay.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            txtExpectedResult.txtDLC.Text = string.Empty;
            txtValueFrom.Text = string.Empty;
            cboStatus.Text = strDefault;

            cboAgeRange.SelectedIndex = -1;
            cboEthnicity.SelectedIndex = -1;
            cboRange.SelectedIndex = -1;
            cboRace.SelectedIndex = -1;
            cboCommunication.SelectedIndex = -1;
            PnlValue.Enabled = false;
        }

        protected void chkActiveRule_CheckedChanged(object sender, EventArgs e)
        {
            RuleMasterManager objRuleMasterManager = new RuleMasterManager();
            if (chkActiveRule.Checked)
            {
                Session["Status"] = "Active";
                objRuleDTO = objRuleMasterManager.GetAllRule("Active",ClientSession.LegalOrg);
            }
            else
            {
                Session["Status"] = "Inactive";
                objRuleDTO = objRuleMasterManager.GetAllRule("Inactive",ClientSession.LegalOrg);
            }
            LoadGrid(objRuleDTO);
        }

        protected void grdPatientRemainder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //LoadGrid(objRuleDTO);
                Session["PrimaryId"] = Convert.ToUInt32(e.Item.Cells[10].Text);
                //Mohan
                txtProblem.Text = string.Empty;
                // txtProblem.Tag = null;
                txtProblemTag.Value = string.Empty;
                txtMedication.Text = string.Empty;
                //  txtMedication.Tag = null;
                txtMedicationTag.Value = string.Empty;
                txtMedicationAllergy.Text = string.Empty;
                // txtMedicationAllergy.Tag = null;
                txtMedicationAllergyTag.Value = string.Empty;
                txtLabTestResult.Text = string.Empty;
                // txtLabTestResult.Tag = null;
                txtLabTestResultTag.Value = string.Empty;
                //Mohan
                objRuleDTO = (IList<RuleDTO>)Session["objRuleDTO"];
                btnAdd.Text = "Update";
                btnClearAll.Text = "Cancel";
                IList<RuleMaster> objMaster = (from m in objRuleDTO where m.Rule_Master.Id == Convert.ToUInt64(Session["PrimaryId"]) select m.Rule_Master).ToList<RuleMaster>();

                Session["UpdateItem"] = objMaster;
                if (objMaster != null)
                {
                    objRule = objMaster[0];
                    txtExpectedResult.txtDLC.Text = objMaster[0].Expected_Action;
                    txtRuleName.Text = objMaster[0].Rule_Name;
                    txtDescription.Text = objMaster[0].Rule_Description;


                    if (cboGender.Items.FindItemByText(objMaster[0].Gender) != null)
                        cboGender.Items.FindItemByText(objMaster[0].Gender).Selected = true;

                    if (objMaster[0].Alert != 0)
                        txtAlertDay.Text = Convert.ToString(objMaster[0].Alert);
                    if (objMaster[0].Frequency != 0)
                        txtFrequency.Text = Convert.ToString(objMaster[0].Frequency);
                    if (objMaster[0].From_Age != string.Empty)
                    {
                        string str = Convert.ToString(DateConversionForUpdate(Convert.ToInt32(objMaster[0].From_Age), objMaster[0].Age_In));
                        if (str != "0")
                            txtAgeFrom.Text = str;

                    }
                    if (objMaster[0].To_Age != string.Empty)
                    {
                        string str = Convert.ToString(DateConversionForUpdate(Convert.ToInt32(objMaster[0].To_Age), objMaster[0].Age_In));
                        if (str != "0")
                            txtAgeTo.Text = str;
                    }

                    cboStatus.Text = objMaster[0].Is_Status;

                    if (cboEthnicity.Items.FindItemByText(objMaster[0].Ethnicity) != null)
                        cboEthnicity.Items.FindItemByText(objMaster[0].Ethnicity).Selected = true;


                    if (cboRace.Items.FindItemByText(objMaster[0].Race) != null)
                        cboRace.Items.FindItemByText(objMaster[0].Race).Selected = true;

                    if (cboAgeRange.Items.FindItemByText(objMaster[0].Age_In) != null)
                        cboAgeRange.Items.FindItemByText(objMaster[0].Age_In).Selected = true;


                    if (cboCommunication.Items.FindItemByText(objMaster[0].Communication) != null)
                        cboCommunication.Items.FindItemByText(objMaster[0].Communication).Selected = true;

                    IList<RuleDTO> objRuleDto = (from m in objRuleDTO where m.Rule_Master.Id == Convert.ToUInt64(Session["PrimaryId"]) select m).ToList<RuleDTO>();
                    if (objRuleDto != null && objRuleDto.Count > 0)
                    {
                        RuleDTO RuleDt = objRuleDto[0];
                        if (RuleDt.Rule_Problem != null && RuleDt.Rule_Problem.Count > 0)
                        {
                            for (int i = 0; i < RuleDt.Rule_Problem.Count; i++)
                            {
                                txtProblem.Text += RuleDt.Rule_Problem[i].ICD + "-" + RuleDt.Rule_Problem[i].Description + ";";
                            }
                        }
                        if (RuleDt.Rule_Medication_And_Allergy != null && RuleDt.Rule_Medication_And_Allergy.Count > 0)
                        {
                            for (int j = 0; j < RuleDt.Rule_Medication_And_Allergy.Count; j++)
                            {
                                if (RuleDt.Rule_Medication_And_Allergy[j].Type == "MEDICATION")
                                {
                                    txtMedication.Text += RuleDt.Rule_Medication_And_Allergy[j].Drug_Name + ";";
                                    txtMedicationTag.Value += Convert.ToString(RuleDt.Rule_Medication_And_Allergy[j].Rx_Norm_ID + "+" + RuleDt.Rule_Medication_And_Allergy[j].Drug_Name + "+" + RuleDt.Rule_Medication_And_Allergy[j].NDC + "|");
                                    // txtMedication.Tag += Convert.ToString(RuleDt.Rule_Medication_And_Allergy[j].Rx_Norm_ID + "+" + RuleDt.Rule_Medication_And_Allergy[j].Drug_Name + "+" + RuleDt.Rule_Medication_And_Allergy[j].NDC + "|");
                                }
                                else
                                {
                                    txtMedicationAllergy.Text += RuleDt.Rule_Medication_And_Allergy[j].Drug_Name + ";";
                                    txtLabTestResultTag.Value += Convert.ToString(RuleDt.Rule_Medication_And_Allergy[j].Rx_Norm_ID + "+" + RuleDt.Rule_Medication_And_Allergy[j].Drug_Name + "+" + RuleDt.Rule_Medication_And_Allergy[j].NDC + "|");
                                    //txtMedicationAllergy.Tag += Convert.ToString(RuleDt.Rule_Medication_And_Allergy[j].Rx_Norm_ID + "+" + RuleDt.Rule_Medication_And_Allergy[j].Drug_Name + "+" + RuleDt.Rule_Medication_And_Allergy[j].NDC + "|");
                                }
                            }
                        }
                        if (RuleDt.Rule_lab_Result_Reminder != null && RuleDt.Rule_lab_Result_Reminder.Count > 0)
                        {
                            txtValueFrom.Text = RuleDt.Rule_lab_Result_Reminder[0].Value;
                            if (cboRange.Items.FindItemByText(RuleDt.Rule_lab_Result_Reminder[0].Lab_Result_Operator) != null)
                                cboRange.Items.FindItemByText(RuleDt.Rule_lab_Result_Reminder[0].Lab_Result_Operator).Selected = true;

                            for (int k = 0; k < RuleDt.Rule_lab_Result_Reminder.Count; k++)
                            {
                                PnlValue.Enabled = true;
                                cboRange.Enabled = true;
                                txtValueFrom.Enabled = true;

                                txtLabTestResult.Text += RuleDt.Rule_lab_Result_Reminder[k].Lab_Result_Name + ";";
                                txtLabTestResultTag.Value += Convert.ToString(RuleDt.Rule_lab_Result_Reminder[k].Loinc + "|" + RuleDt.Rule_lab_Result_Reminder[k].Lab_Result_Name + "+");
                                // Session["txtLabTestResultTag"] += Convert.ToString(RuleDt.Rule_lab_Result_Reminder[k].Loinc + "|" + RuleDt.Rule_lab_Result_Reminder[k].Lab_Result_Name + "+");
                                //txtLabTestResult.Tag += Convert.ToString(RuleDt.Rule_lab_Result_Reminder[k].Loinc + "|" + RuleDt.Rule_lab_Result_Reminder[k].Lab_Result_Name + "+");
                            }
                        }


                    }

                }
                btnAdd.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "AutoSave", "AutoSaveButtonStatus('true');", true);
            }
            else if (e.CommandName == "DeleteRow")
            {

                Session["PrimaryId"] = Convert.ToUInt32(e.Item.Cells[10].Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Delete", "DeleteGrid();", true);


            }
        }
        private int DateConversionForUpdate(int iDate, string strFormat)
        {
            int iMonth = 0;
            try
            {
                if (strFormat == "Months")
                    iMonth = iDate;
                else if (strFormat == "Years")
                    iMonth = iDate / 12;
            }
            catch
            { }
            return iMonth;
        }
        protected void btnInvisible_Click(object sender, EventArgs e)
        {
            objRuleDTO = (IList<RuleDTO>)Session["objRuleDTO"];
            Clear();
            IList<RuleMaster> objMaster = (from m in objRuleDTO where m.Rule_Master.Id == Convert.ToUInt64(Session["PrimaryId"]) select m.Rule_Master).ToList<RuleMaster>();
            if (objMaster != null && objMaster.Count>0)
            {
                RuleMaster Rules = new RuleMaster();
                Rules = objMaster[0];
                Rules.Is_Status = "Inactive";
                Rules.Modified_By = ClientSession.UserName;
                Rules.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                RuleMasterManager objRuleMasterManager = new RuleMasterManager();
                strStatus = Session["Status"].ToString();
                objRuleDTO = objRuleMasterManager.DeleteRuleDTO(Rules, string.Empty, strStatus,ClientSession.LegalOrg);
                //   ApplicationObject.erroHandler.DisplayErrorMessage("7410003", this.Text);
                LoadGrid(objRuleDTO);
            }

        }

        protected void btnFindDx_Click(object sender, EventArgs e)
        {
            // txtProblem.Text = Session["Selected_ICDs"].ToString();
        }

        protected void btnInvisibleDx_Click(object sender, EventArgs e)
        {

            if (Session["Selected_ICDs"] != null)
            {
                IList<string> lst = (IList<string>)Session["Selected_ICDs"];

                foreach (string st in lst)
                    txtProblem.Text += st + ";";
            }
            btnAdd.Enabled = true;
        }





    }
}
