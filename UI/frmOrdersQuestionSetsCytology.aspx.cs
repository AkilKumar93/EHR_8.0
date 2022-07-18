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
using System.Globalization;

namespace Acurus.Capella.UI
{
    public partial class frmOrdersQuestionSetsCytology : System.Web.UI.Page
    {
        OrdersQuestionSetCytology objCytology = new OrdersQuestionSetCytology();
        OrdersQuestionSetCytologyManager objOrdersQuestionSetCytologyMngr = new OrdersQuestionSetCytologyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtpLMPDate.SelectedDate = DateTime.Now;
                //btnSave.Attributes.Add("disabled", "disabled");
                if (Request["OrderSubmitID"] != null)
                {
                    objCytology=objOrdersQuestionSetCytologyMngr.GetQuestionSetCytology(Convert.ToUInt32(Request["OrderSubmitID"]));
                    if (objCytology.Order_ID != 0)
                    {
                        FillCytologyValues(objCytology);
                    }
                    else
                    {
                        objCytology = new OrdersQuestionSetCytology();
                    }
                }
                btnSave.Enabled = false;
            }
        }
        

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            objCytology = new OrdersQuestionSetCytology();
            dtpLMPDate.SelectedDate = DateTime.Now;
            txtDatesResults.Text=string.Empty;
                    foreach (Control chkCtrl in pnlGynSource.Controls)
                    {
                        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
                        {
                            CheckBox chk = (CheckBox)chkCtrl;
                            chk.Checked = false;
                        }
                    }
               
                    foreach (Control chkCtrl in pnlCollectiontechnique.Controls)
                    {
                        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
                        {
                            CheckBox chk = (CheckBox)chkCtrl;
                            chk.Checked = false;
                        }
                    }
                
                    foreach (Control chkCtrl in pnlPreviousTreatment.Controls)
                    {
                        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
                        {
                            CheckBox chk = (CheckBox)chkCtrl;
                            chk.Checked = false;
                        }
                    }
                
                    foreach (Control chkCtrl in gbPreviousCytologyInformation.Controls)
                    {
                        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
                        {
                            CheckBox chk = (CheckBox)chkCtrl;
                            chk.Checked = false;
                        }
                    }
               
                    foreach (Control chkCtrl in pnlOtherPatientInformation.Controls)
                    {
                        if (chkCtrl.GetType().ToString().Contains("CheckBox"))
                        {
                            CheckBox chk = (CheckBox)chkCtrl;
                            chk.Checked = false;
                        }
                    }
                    btnSave.Attributes.Add("disabled", "disabled");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (dtpLMPDate.SelectedDate.Value.Date > DateTime.Now.Date)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Question Set Cytology", "DisplayErrorMessage('9093036');", true);
                dtpLMPDate.Focus();
                return;
            }
            objCytology = new OrdersQuestionSetCytology();
            objCytology.LMP_Meno_Date = dtpLMPDate.SelectedDate.Value;
            objCytology.Gyn_Source_Endocervical = GetCheckedValues(chkYesEndocervical, chkNoEndocervical);
            objCytology.Gyn_Source_Cervical = GetCheckedValues(chkYesCervical, chkNoCervical);
            objCytology.Gyn_Source_Endometrial = GetCheckedValues(chkYesEndometrial, chkNoEndometrial);
            objCytology.Gyn_Source_Hysterectomy_Supracervical = GetCheckedValues(chkYesHysterectomySupracervical, chkNoHysterectomySupracervical);
            objCytology.Gyn_Source_Labia_Vulva = GetCheckedValues(chkYesLabiaVulva, chkNoLabiaVulva);
            objCytology.Gyn_Source_Vaginal = GetCheckedValues(chkYesVaginal, chkNoVaginal);
            objCytology.Collection_Technique_Broom_Alone = GetCheckedValues(chkYesBroomAlone, chkNoBroomAlone);
            objCytology.Collection_Technique_Brush_Alone = GetCheckedValues(chkYesBrushAlone, chkNoBrushAlone);
            objCytology.Collection_Technique_Brush_Spatula = GetCheckedValues(chkYesBrushSpatula, chkNoBrushSpatula);
            objCytology.Collection_Technique_Other = GetCheckedValues(chkYesOtheCollectionTechnique, chkNoOtheCollectionTechnique);
            objCytology.Collection_Technique_Spatula_Alone = GetCheckedValues(chkYesSpatulaAlone, chkNoSpatulaAlone);
            objCytology.Collection_Technique_Swab_Spatula = GetCheckedValues(chkYesSwabSpatula, chkNoSwabSpatula);
            objCytology.Previous_Treatment_Colp_BX = GetCheckedValues(chkYesColpBX, chkNoColpBX);
            objCytology.Previous_Treatment_Coniza = GetCheckedValues(chkYesConiza, chkNoConiza);
            objCytology.Previous_Treatment_Cyro = GetCheckedValues(chkYesCyro, chkNoCyro);
            objCytology.Previous_Treatment_Hyst = GetCheckedValues(chkYesHyst, chkNoHyst);
            objCytology.Previous_Treatment_Laser_Vap = GetCheckedValues(chkYesLaserVap, chkNoLaserVap);
            objCytology.Previous_Treatment_None = GetCheckedValues(chkYesNone, chkNoNone);
            objCytology.Previous_Treatment_Radiation = GetCheckedValues(chkYesRadiation, chkNoRadiation);
            objCytology.Previous_Cytology_Info_Atypical = GetCheckedValues(chkyesAtypical, chkNoAtypical);
            objCytology.Previous_Cytology_Info_Ca_In_Situ = GetCheckedValues(chkYesCaInSitu, chkNoCaInSitu);
            objCytology.Previous_Cytology_Info_Dates_Results = txtDatesResults.Text;
            objCytology.Previous_Cytology_Info_Dysplasia = GetCheckedValues(chkYesDysplasia, chkNoDysplasia);
            objCytology.Previous_Cytology_Info_Invasive = GetCheckedValues(chkYesInvasive, chkNoInvasive);
            objCytology.Previous_Cytology_Info_Negative = GetCheckedValues(chkYesNegative, chkNoNegative);
            objCytology.Previous_Cytology_Info_Other = GetCheckedValues(chkYesOthePreviousInformation, chkNoOthePreviousInformation);
            objCytology.Other_Patient_Info_All_Other_Pat = GetCheckedValues(chkYesAllOtherPat, chkNoAllOtherPat);
            objCytology.Other_Patient_Info_Estro_RX = GetCheckedValues(chkYesEstroRX, chkNoEstroRX);
            objCytology.Other_Patient_Info_Lactating = GetCheckedValues(chkYesLactating, chkNoLactating);
            objCytology.Other_Patient_Info_Menopausal = GetCheckedValues(chkYesMenopausal, chkNoMenopausal);
            objCytology.Other_Patient_Info_Oral_Contraceptives = GetCheckedValues(chkYesOralContraceptives, chkNoOralContraceptives);
            objCytology.Other_Patient_Info_PMP_Bleeding = GetCheckedValues(chkYesPMPBleeding, chkNoPMPBleeding);
            objCytology.Other_Patient_Info_Post_Part = GetCheckedValues(chkYesPostPart, chkNoPostPart);
            objCytology.Other_Patient_Info_Pregnant = GetCheckedValues(chkYesPregnant, chkNoPregnant);
            objCytology.Other_Patient_Info_IUD = GetCheckedValues(chkYesIUD, chkNoIUD);
            objCytology.Created_By = ClientSession.UserName;
            objCytology.Created_Date_And_Time = DateTime.ParseExact(hdnLocalTime.Value, "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture); 
            OrdersQuestionSetCytology obj = new OrdersQuestionSetCytology();
            obj = objOrdersQuestionSetCytologyMngr.SaveCytology(Convert.ToUInt32(Request["OrderSubmitID"]), objCytology);
            btnSave.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('230101');", true);
            //btnSave.Attributes.Add("disabled", "disabled");
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
        private void FillCytologyValues(OrdersQuestionSetCytology objCyto)
        {
            if (objCyto.LMP_Meno_Date != DateTime.MinValue)
                dtpLMPDate.SelectedDate = objCyto.LMP_Meno_Date;
            else
                dtpLMPDate.SelectedDate = DateTime.Now;
            SetCheckedValues(chkYesCervical, chkNoCervical, objCyto.Gyn_Source_Cervical);
            SetCheckedValues(chkYesEndocervical, chkNoEndocervical, objCyto.Gyn_Source_Endocervical);
            SetCheckedValues(chkYesLabiaVulva, chkNoLabiaVulva, objCyto.Gyn_Source_Labia_Vulva);
            SetCheckedValues(chkYesVaginal, chkNoVaginal, objCyto.Gyn_Source_Vaginal);
            SetCheckedValues(chkYesEndometrial, chkNoEndometrial, objCyto.Gyn_Source_Endometrial);
            SetCheckedValues(chkYesSwabSpatula, chkNoSwabSpatula, objCyto.Collection_Technique_Swab_Spatula);
            SetCheckedValues(chkYesBrushSpatula, chkNoBrushSpatula, objCyto.Collection_Technique_Brush_Spatula);
            SetCheckedValues(chkYesSpatulaAlone, chkNoSpatulaAlone, objCyto.Collection_Technique_Spatula_Alone);
            SetCheckedValues(chkYesBrushAlone, chkNoBrushAlone, objCyto.Collection_Technique_Brush_Alone);
            SetCheckedValues(chkYesBroomAlone, chkNoBroomAlone, objCyto.Collection_Technique_Broom_Alone);
            SetCheckedValues(chkYesOtheCollectionTechnique, chkNoOtheCollectionTechnique, objCyto.Collection_Technique_Other);
            SetCheckedValues(chkYesNone, chkNoNone, objCyto.Previous_Treatment_None);
            SetCheckedValues(chkYesHyst, chkNoHyst, objCyto.Previous_Treatment_Hyst);
            SetCheckedValues(chkYesConiza, chkNoConiza, objCyto.Previous_Treatment_Coniza);
            SetCheckedValues(chkYesColpBX, chkNoColpBX, objCyto.Previous_Treatment_Colp_BX);
            SetCheckedValues(chkYesLaserVap, chkNoLaserVap, objCyto.Previous_Treatment_Laser_Vap);
            SetCheckedValues(chkYesCyro, chkNoCyro, objCyto.Previous_Treatment_Cyro);
            SetCheckedValues(chkYesRadiation, chkNoRadiation, objCyto.Previous_Treatment_Radiation);
            SetCheckedValues(chkYesPregnant, chkNoPregnant, objCyto.Other_Patient_Info_Pregnant);
            SetCheckedValues(chkYesLactating, chkNoLactating, objCyto.Other_Patient_Info_Lactating);
            SetCheckedValues(chkYesOralContraceptives, chkNoOralContraceptives, objCyto.Other_Patient_Info_Oral_Contraceptives);
            SetCheckedValues(chkYesMenopausal, chkNoMenopausal, objCyto.Other_Patient_Info_Menopausal);
            SetCheckedValues(chkYesEstroRX, chkNoEstroRX, objCyto.Other_Patient_Info_Estro_RX);
            SetCheckedValues(chkYesPMPBleeding, chkNoPMPBleeding, objCyto.Other_Patient_Info_PMP_Bleeding);
            SetCheckedValues(chkYesPostPart, chkNoPostPart, objCyto.Other_Patient_Info_Post_Part);
            SetCheckedValues(chkYesIUD, chkNoIUD, objCyto.Other_Patient_Info_IUD);
            SetCheckedValues(chkYesAllOtherPat, chkNoAllOtherPat, objCyto.Other_Patient_Info_All_Other_Pat);
            SetCheckedValues(chkYesNegative, chkNoNegative, objCyto.Previous_Cytology_Info_Negative);
            SetCheckedValues(chkyesAtypical, chkNoAtypical, objCyto.Previous_Cytology_Info_Atypical);
            SetCheckedValues(chkYesDysplasia, chkNoDysplasia, objCyto.Previous_Cytology_Info_Dysplasia);
            SetCheckedValues(chkYesCaInSitu, chkNoCaInSitu, objCyto.Previous_Cytology_Info_Ca_In_Situ);
            SetCheckedValues(chkYesInvasive, chkNoInvasive, objCyto.Previous_Cytology_Info_Invasive);
            SetCheckedValues(chkYesOthePreviousInformation, chkNoOthePreviousInformation, objCyto.Previous_Cytology_Info_Other);
            SetCheckedValues(chkYesHysterectomySupracervical, chkNoHysterectomySupracervical, objCyto.Gyn_Source_Hysterectomy_Supracervical);
            txtDatesResults.Text = objCyto.Previous_Cytology_Info_Dates_Results;


        }
        private void SetCheckedValues(CheckBox chkYes, CheckBox chkNo, string Value)
        {
            if (Value == "Y")
            {
                chkYes.Checked = true;
            }
            else if (Value == "N")
            {
                chkNo.Checked = true;
            }
        }

        protected void dtpLMPDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            //btnSave.Attributes.Add("disabled", "disabled");
            btnSave.Enabled = true;
        }

        protected void chkYesCervical_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
