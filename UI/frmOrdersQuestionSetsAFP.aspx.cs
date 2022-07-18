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
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Globalization;

namespace Acurus.Capella.UI
{
    public partial class frmOrdersQuestionSetsAFP : System.Web.UI.Page
    {
        OrdersQuestionSetAfp objAFP = new OrdersQuestionSetAfp();
        OrdersQuestionSetAfpManager objOrdersQuestionSetAfpMngr = new OrdersQuestionSetAfpManager();
        IList<StaticLookup> FieldLookUpList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request["OrderSubmitID"]!=null)
                {
                    FieldLookUpList = objOrdersQuestionSetAfpMngr.GetStaticLookup("GA CALCULATION METHOD");
                    if (FieldLookUpList.Count > 0)
                    {
                        for (int i = 0; i < FieldLookUpList.Count; i++)
                        {
                            cboGACalculationMethod.Items.Add(new RadComboBoxItem(FieldLookUpList[i].Value.ToString()));
                        }
                    }
                    dtpGADate.DateInput.DateFormat = "dd-MMM-yyyy";
                    dtpGADate.SelectedDate = DateTime.Now;
                    dtpGADateofCalculation.DateInput.DateFormat = "dd-MMM-yyyy";
                    dtpGADateofCalculation.SelectedDate = DateTime.Now;
                    dtpUltrasoundCRLLengthDate.DateInput.DateFormat = "dd-MMM-yyyy";
                    dtpUltrasoundCRLLengthDate.SelectedDate = DateTime.Now;
                    objAFP = objOrdersQuestionSetAfpMngr.GetOrderID(Convert.ToUInt32(Request["OrderSubmitID"]));
                    if (objAFP.Id != null)
                    {
                        FillOrdersQuestionSetAfp(objAFP);
                    }
                    else
                    {
                        objAFP = new OrdersQuestionSetAfp();
                    }
                }
                btnOK.Enabled = false;
            }
        }
        public void FillOrdersQuestionSetAfp(OrdersQuestionSetAfp objAFP)
        {
            if (objAFP.Gestational_Age_Date_Of_Calculation != string.Empty)
            {
                DateTime dtGA = DateTime.ParseExact(objAFP.Gestational_Age_Date_Of_Calculation, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                dtpGADateofCalculation.DateInput.DateFormat = "dd-MMM-yyyy";
                dtpGADateofCalculation.SelectedDate = dtGA;
            }

            if (objAFP.GA_Calculation_Method_LMP == "Y")
            {
                cboGACalculationMethod.Text = "LMP";
                lblGADate.Text = "LMP Date";
                if (objAFP.LMP_Date != string.Empty)
                {
                    DateTime dt = DateTime.ParseExact(objAFP.LMP_Date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    dtpGADate.DateInput.DateFormat = "dd-MMM-yyyy";
                    dtpGADate.SelectedDate = dt;
                }
            }
            else if (objAFP.GA_Calculation_Method_Ultrasound == "Y")
            {
                cboGACalculationMethod.Text = "Ultrasound";
                lblGADate.Text = "Ultrasound Date";
                if (objAFP.Ultrasound_Date != string.Empty)
                {
                    DateTime dt = DateTime.ParseExact(objAFP.Ultrasound_Date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    dtpGADate.DateInput.DateFormat = "dd-MMM-yyyy";
                    dtpGADate.SelectedDate = dt;
                }
            }
            else if (objAFP.GA_Calculation_Method_EDD_EDC == "Y")
            {
                cboGACalculationMethod.Text = "EDD/EDC";
                lblGADate.Text = "EDD/EDC Date";
                if (objAFP.EDD_EDC_Date != string.Empty)
                {
                    DateTime dt = DateTime.ParseExact(objAFP.EDD_EDC_Date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    dtpGADate.DateInput.DateFormat = "dd-MMM-yyyy";
                    dtpGADate.SelectedDate = dt;
                }
            }
            txtGADays.Text = objAFP.Gestational_Age_Days;
            txtGAWeeks.Text = objAFP.Gestational_Age_Weeks;
            SetCheckedValues(chkYesInsDependent, chkNoInsDependent, objAFP.Insulin_Dependent);
            SetCheckedValues(chkYesOtherIndications, chkNoOtherIndications, objAFP.Other_Indications);
            SetCheckedValues(chkYesFHXNTD, chkNoFHXNTD, objAFP.FHX_NTD);
            txtAdditionalInfo.Text = objAFP.Additional_Information;
            txtNumberofFetuses.Text = objAFP.Number_Of_Fetuses;
            SetCheckedValues(chkYesDonorEgg, chkNoDonorEgg, objAFP.Donor_Egg);
            txtAgeofEggDonor.Text = objAFP.Age_Of_Egg_Donor;
            txtUltrasoundCRLLength.Text = objAFP.Ultrasound_Measurement_Crown_Rump_Length;
            txtUltrasoundCRLLengthTwinB.Text = objAFP.Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B;
            if (objAFP.Ultrasound_Measurement_Crown_Rump_Length_Date != string.Empty)
            {
                DateTime dt1 = DateTime.ParseExact(objAFP.Ultrasound_Measurement_Crown_Rump_Length_Date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                dtpUltrasoundCRLLengthDate.DateInput.DateFormat = "dd-MMM-yyyy";
                dtpUltrasoundCRLLengthDate.SelectedDate = dt1;
            }
            txtNuchalTranslucency.Text = objAFP.Nuchal_Translucency;
            txtNuchalTranslucencyTwinB.Text = objAFP.Nuchal_Translucency_For_Twin_B;
            SetCheckedValues(chkYesPriorDownSyndromeCurrentPregnancy, chkNoPriorDownSyndromeCurrentPregnancy, objAFP.Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy);
            SetCheckedValues(chkYesPriorFirstTrimesterTesting, chkNoPriorFirstTrimesterTesting, objAFP.Prior_First_Trimester_Testing);
            SetCheckedValues(chkYesPriorSecondTrimesterTesting, chkNoPriorSecondTrimesterTesting, objAFP.Prior_Second_Trimester_Testing);
            SetCheckedValues(chkNoPriorPregnancyDownSyndrome, chkNoPriorPregnancyDownSyndrome, objAFP.Prior_Pregnancy_With_Down_Syndrome);
            SetCheckedValues(chkYesPreviouslyElevatedAFP, chkNoPreviouslyElevatedAFP, objAFP.Previously_Elevated_AFP);
            SetCheckedValues(chkYesMonochorionic, chkNoMonochorionic, objAFP.Chorionicity_Monochorionic);
            SetCheckedValues(chkYesDichorionic, chkNoDichorionic, objAFP.Chorionicity_Dichorionic);
            SetCheckedValues(chkYesUnknown, chkNoUnknown, objAFP.Chorionicity_Unknown);
            txtSonographerFirstName.Text = objAFP.Sonographer_First_Name;
            txtSonographerLastName.Text = objAFP.Sonographer_Last_Name;
            txtSonographerIDNumber.Text = objAFP.Sonographer_ID_Number;
            SetCheckedValues(chkYesCredentialedbyFMF, chkNoCredentialedbyFMF, objAFP.Credentialed_By_FMF);
            SetCheckedValues(chkYesCredentialedbyNTQR, chkNoCredentialedbyNTQR, objAFP.Credentialed_By_NTQR);
            SetCheckedValues(chkYesCredentialedbyOther, chkNoCredentialedbyOther, objAFP.Credentialed_By_Other_Organization);
            txtSiteNumber.Text = objAFP.Site_Number;
            txtReadingPhysicianID.Text = objAFP.Reading_Physician_ID;


        }
        public void SetCheckedValues(CheckBox ChkYes,CheckBox ChkNo,string Value)
        {
            if(Value == "Y")
            {
                ChkYes.Checked = true;
            }
            else if(Value=="N")
            {
                ChkNo.Checked = true;
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (cboGACalculationMethod.Text.ToUpper() == "LMP")
            {
                objAFP.GA_Calculation_Method_LMP = "Y";
                objAFP.GA_Calculation_Method_Ultrasound = string.Empty;
                objAFP.GA_Calculation_Method_EDD_EDC = string.Empty;
                if (dtpGADate.DateInput.DateFormat == "dd-MMM-yyyy")
                {
                    objAFP.LMP_Date = dtpGADate.SelectedDate.Value.ToString("yyyyMMdd");
                }
                else
                    objAFP.LMP_Date = string.Empty;
                objAFP.Ultrasound_Date = string.Empty;
                objAFP.EDD_EDC_Date = string.Empty;

            }
            else if (cboGACalculationMethod.Text.ToUpper() == "ULTRASOUND")
            {
                objAFP.GA_Calculation_Method_LMP = string.Empty;
                objAFP.GA_Calculation_Method_Ultrasound = "Y";
                objAFP.GA_Calculation_Method_EDD_EDC = string.Empty;
                objAFP.LMP_Date = string.Empty;
                if (dtpGADate.DateInput.DateFormat == "dd-MMM-yyyy")
                {
                    objAFP.Ultrasound_Date = dtpGADate.SelectedDate.Value.ToString("yyyyMMdd");
                }
                else
                    objAFP.Ultrasound_Date = string.Empty;
                objAFP.EDD_EDC_Date = string.Empty;

            }
            else if (cboGACalculationMethod.Text.ToUpper() == "EDD/EDC")
            {
                objAFP.GA_Calculation_Method_LMP = string.Empty;
                objAFP.GA_Calculation_Method_Ultrasound = string.Empty;
                objAFP.GA_Calculation_Method_EDD_EDC = "Y";
                objAFP.LMP_Date = string.Empty;
                objAFP.Ultrasound_Date = string.Empty;
                if (dtpGADate.DateInput.DateFormat == "dd-MMM-yyyy")
                {
                    objAFP.EDD_EDC_Date = dtpGADate.SelectedDate.Value.ToString("yyyyMMdd");
                }
                else
                    objAFP.EDD_EDC_Date = string.Empty;
            }
            objAFP.Additional_Information = txtAdditionalInfo.Text;
            if (txtAgeofEggDonor.Text != string.Empty)
            {
                objAFP.Age_Of_Egg_Donor = txtAgeofEggDonor.Text;
            }
            objAFP.Chorionicity_Dichorionic = GetCheckedValues(chkYesDichorionic, chkNoDichorionic);
            objAFP.Chorionicity_Monochorionic = GetCheckedValues(chkYesMonochorionic, chkNoMonochorionic);
            objAFP.Chorionicity_Unknown = GetCheckedValues(chkYesUnknown, chkNoUnknown);
            objAFP.Credentialed_By_FMF = GetCheckedValues(chkYesCredentialedbyFMF, chkNoCredentialedbyFMF);
            objAFP.Credentialed_By_NTQR = GetCheckedValues(chkYesCredentialedbyNTQR, chkNoCredentialedbyNTQR);
            objAFP.Credentialed_By_Other_Organization = GetCheckedValues(chkYesCredentialedbyOther, chkNoCredentialedbyOther);
            objAFP.Donor_Egg = GetCheckedValues(chkYesDonorEgg, chkNoDonorEgg);
            objAFP.FHX_NTD = GetCheckedValues(chkYesFHXNTD, chkNoFHXNTD);
            if (dtpGADateofCalculation.DateInput.DateFormat == "dd-MMM-yyyy")
            {
                objAFP.Gestational_Age_Date_Of_Calculation = dtpGADateofCalculation.SelectedDate.Value.ToString("yyyyMMdd");
            }
            if (txtGADays.Text != string.Empty)
                objAFP.Gestational_Age_Days = txtGADays.Text;
            if (txtGAWeeks.Text != string.Empty)
                objAFP.Gestational_Age_Weeks = txtGAWeeks.Text;
            objAFP.Insulin_Dependent = GetCheckedValues(chkYesInsDependent, chkNoInsDependent);
            if (txtNuchalTranslucency.Text != string.Empty)
            {

                objAFP.Nuchal_Translucency = String.Format("{0:00.0}", Convert.ToDouble(txtNuchalTranslucency.Text));
            }
            if (txtNuchalTranslucencyTwinB.Text != string.Empty)
                objAFP.Nuchal_Translucency_For_Twin_B = String.Format("{0:00.0}", Convert.ToDouble(txtNuchalTranslucencyTwinB.Text));
            if (txtNumberofFetuses.Text != string.Empty)
                objAFP.Number_Of_Fetuses = txtNumberofFetuses.Text;
            objAFP.Other_Indications = GetCheckedValues(chkYesOtherIndications, chkNoOtherIndications);
            objAFP.Previously_Elevated_AFP = GetCheckedValues(chkYesPreviouslyElevatedAFP, chkNoPreviouslyElevatedAFP);
            objAFP.Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy = GetCheckedValues(chkYesPriorDownSyndromeCurrentPregnancy, chkNoPriorDownSyndromeCurrentPregnancy);
            objAFP.Prior_First_Trimester_Testing = GetCheckedValues(chkYesPriorFirstTrimesterTesting, chkNoPriorFirstTrimesterTesting);
            objAFP.Prior_Second_Trimester_Testing = GetCheckedValues(chkYesPriorSecondTrimesterTesting, chkNoPriorSecondTrimesterTesting);
            objAFP.Reading_Physician_ID = txtReadingPhysicianID.Text;
            objAFP.Prior_Pregnancy_With_Down_Syndrome = GetCheckedValues(chkYesPriorPregnancyDownSyndrome, chkNoPriorPregnancyDownSyndrome);
            objAFP.Site_Number = txtSiteNumber.Text;
            objAFP.Sonographer_First_Name = txtSonographerFirstName.Text;
            objAFP.Sonographer_ID_Number = txtSonographerIDNumber.Text;
            objAFP.Sonographer_Last_Name = txtSonographerLastName.Text;
            objAFP.Created_By = ClientSession.UserName;
            if (hdnLocalTime.Value!=null)
                objAFP.Created_Date_And_Time = DateTime.ParseExact(hdnLocalTime.Value, "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
            if (txtUltrasoundCRLLength.Text != string.Empty)
                objAFP.Ultrasound_Measurement_Crown_Rump_Length = String.Format("{0:00.0}", Convert.ToDouble(txtUltrasoundCRLLength.Text));
            if (txtUltrasoundCRLLengthTwinB.Text != string.Empty)
                objAFP.Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B = String.Format("{0:00.0}", Convert.ToDouble(txtUltrasoundCRLLengthTwinB.Text));
            if (dtpUltrasoundCRLLengthDate.DateInput.DateFormat == "dd-MMM-yyyy")
            {
                objAFP.Ultrasound_Measurement_Crown_Rump_Length_Date = dtpUltrasoundCRLLengthDate.SelectedDate.Value.ToString("yyyyMMdd");
            }
            OrdersQuestionSetAfp obj = new OrdersQuestionSetAfp();
            obj = objOrdersQuestionSetAfpMngr.SaveAFP(Convert.ToUInt32(Request["OrderSubmitID"]), objAFP);
            btnOK.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('230101');", true);
        }
        private string GetCheckedValues(CheckBox chkYes, CheckBox chkNo)
        {
            if (chkYes.Checked)
            {
                return "Y";
            }
            else if (chkNo.Checked)
            {
                return "N";
            }
            else
            {
                return string.Empty;
            }
        }
        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            //int iMsg = ApplicationObject.erroHandler.DisplayErrorMessage("851001","", this.Page);
            //if (iMsg == 1)
            //{
            //    objAFP = new OrdersQuestionSetAfp();
            //    foreach (Control chkCtrl in pnlChorionicity.Controls)
            //    {
            //        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
            //        {
            //            CheckBox chk = (CheckBox)chkCtrl;
            //            chk.Checked = false;
            //        }
            //    }
            //    foreach (Control chkCtrl in Panel1.Controls)
            //    {
            //        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
            //        {
            //            CheckBox chk = (CheckBox)chkCtrl;
            //            chk.Checked = false;
            //        }
            //    }
            //    foreach (Control chkCtrl in pnlSonographerDetails.Controls)
            //    {
            //        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
            //        {
            //            CheckBox chk = (CheckBox)chkCtrl;
            //            chk.Checked = false;
            //        }
            //    }
            //    cboGACalculationMethod.Text = string.Empty;
            //    dtpGADate.SelectedDate = DateTime.Now;
            //    dtpGADateofCalculation.SelectedDate = DateTime.Now;
            //    dtpUltrasoundCRLLengthDate.SelectedDate = DateTime.Now;
            //    txtAdditionalInfo.Text=string.Empty;
            //    txtAgeofEggDonor.Text = string.Empty;
            //    txtGADays.Text = string.Empty;
            //    txtGAWeeks.Text = string.Empty;
            //    txtNuchalTranslucency.Text = string.Empty;
            //    txtNuchalTranslucencyTwinB.Text = string.Empty;
            //    txtNumberofFetuses.Text = string.Empty;
            //    txtReadingPhysicianID.Text = string.Empty;
            //    txtSiteNumber.Text = string.Empty;
            //    txtSonographerFirstName.Text = string.Empty;
            //    txtSonographerIDNumber.Text = string.Empty;
            //    txtSonographerLastName.Text = string.Empty;
            //    txtUltrasoundCRLLength.Text = string.Empty;
            //    txtUltrasoundCRLLengthTwinB.Text = string.Empty;
            //    btnOK.Attributes.Add("disabled", "disabled");
            //}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this,this.GetType(), "Close QuestionSet", "window.close();", true);
        }

        protected void cboGACalculationMethod_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cboGACalculationMethod.Text.ToUpper() == "LMP")
            {
                lblGADate.Text = "LMP Date";
            }
            else if (cboGACalculationMethod.Text.ToUpper() == "ULTRASOUND")
            {
                lblGADate.Text = "Ultrasound Date";
            }
            else if (cboGACalculationMethod.Text.ToUpper() == "EDD/EDC")
            {
                lblGADate.Text = "EDD/EDC Date";
            }
            btnOK.Enabled = true;
        }

        protected void dtpGADate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (dtpGADate.DateInput.DateFormat == "dd-MMM-yyyy" && dtpGADateofCalculation.DateInput.DateFormat == "dd-MMM-yyyy")
            {
                if (dtpGADate.SelectedDate.Value.Date < DateTime.Now.Date)
                {
                    DateTime edd = (dtpGADate.SelectedDate.Value.AddDays(-7)).AddMonths(-9);
                    TimeSpan ts = dtpGADateofCalculation.SelectedDate.Value.Date - edd;
                    int weeks = Convert.ToInt16(ts.TotalDays / 7);
                    int days = Convert.ToInt16(ts.TotalDays % 7);
                    if (cboGACalculationMethod.Text.ToUpper() == "LMP")
                    {
                        ts = dtpGADateofCalculation.SelectedDate.Value.Date - dtpGADate.SelectedDate.Value.Date;
                        weeks = Convert.ToInt16(ts.TotalDays / 7);
                        days = Convert.ToInt16(ts.TotalDays % 7);
                        txtGADays.Text = days.ToString();
                        txtGAWeeks.Text = weeks.ToString();
                    }
                    else if (cboGACalculationMethod.Text.ToUpper() == "ULTRASOUND")
                    {
                        //ts = dtpGADate.Value.Date-dtpGADateofCalculation.Value.Date;
                        //weeks = Convert.ToInt16(ts.TotalDays / 7);
                        //days = Convert.ToInt16(ts.TotalDays % 7);
                        //txtGADays.Text = days.ToString();
                        //txtGAWeeks.Text = weeks.ToString();
                    }
                    else if (cboGACalculationMethod.Text.ToUpper() == "EDD/EDC")
                    {
                        //lblGADate.Text = "EDD/EDC Date";
                    }

                }
            }
            btnOK.Enabled = true;
        }

        protected void txtGADays_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        protected void dtpUltrasoundCRLLengthDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            btnOK.Enabled = true;
        }

        protected void dtpGADateofCalculation_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            RadDateTimePicker dtp = (RadDateTimePicker)sender;
            if (dtp.SelectedDate.Value == dtp.MinDate)
            {
                dtp.SelectedDate = DateTime.Now;
            }
            btnOK.Enabled = true;
        }

        protected void chkYesInsDependent_CheckedChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }
    }
}
