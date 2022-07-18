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
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections.Generic;
using Telerik.Web.UI;

namespace Acurus.Capella.UI
{
    public partial class frmPQRI : System.Web.UI.Page
    {
        PQRIDTO resultList;
        IList<StaticLookup> TobaccoUseList = null;
        IList<StaticLookup> SmokingHabitList = null;
        IList<StaticLookup> BmiLIst = null;
        IList<StaticLookup> TobaccoCessationLIst = null;
        IList<StaticLookup> SmokingCessationList = null;
        IList<StaticLookup> BMIFollowupList = null;
        IList<PQRI> UpdateResultlist = null;
        PQRIManager objPQRIMngr = new PQRIManager();
        UtilityManager utilityMngr = new UtilityManager();
        PQRI objUpdateTobaccoUse = null;
        PQRI objUpdateSmokinguse = null;
        PQRI objUpdateBmi = null;
        PQRIDTO PqriDto;
        ulong Encouter_Id = 0;
        ulong Human_Id = 0;
        ulong Physician_Id = 0;
        string sTobacco = "TobaccoUseOptions";
        StaticLookupManager staticlookupMngr = new StaticLookupManager();
        bool bPQRISave = false;
        bool saveCheckingFlag = false, bSaveCompleted = true;
        
        #region for PageLoad
        StaticLookupManager objStaticLookupManager = new StaticLookupManager();
        IList<StaticLookup> TobaccoUseListstat = new List<StaticLookup>();

        public void LoadTobacco(bool bValue)
        {
            string[] ary = new string[] { "SOCIAL HISTORY OPTION FOR TOBACCO USE AND EXPOSURE YES", "SOCIAL HISTORY OPTION FOR TOBACCO USE AND EXPOSURE NO" };
            if (bValue == true)
            {
                TobaccoUseListstat = objStaticLookupManager.getStaticLookupByFieldName(ary[0]);
            }
            else
            {
                TobaccoUseListstat = objStaticLookupManager.getStaticLookupByFieldName(ary[1]);
            }

            if (TobaccoUseListstat.Count > 0)
            {
                cboTobaccoUse.Items.Clear();
                cboTobaccoUse.Items.Add(new ListItem(" "));
                for (int j = 0; j < TobaccoUseListstat.Count; j++)
                {
                    ListItem item = new ListItem();
                    item.Text = TobaccoUseListstat[j].Value;
                    cboTobaccoUse.Items.Add(item);
                }
                
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            Physician_Id = ClientSession.PhysicianId;
            Human_Id = Convert.ToUInt32(Request["MyHumanID"].ToString());
            Encouter_Id = Convert.ToUInt32(Request["MyEncounterID"].ToString());
            if ((!IsPostBack))
            {
                hdnCheckedChangeFlag.Value="false";
                ClientSession.processCheck = true;
                SecurityServiceUtility objSecurityServiceUtility = new SecurityServiceUtility();
                objSecurityServiceUtility.ApplyUserPermissions(this);           
                btnSave.Attributes.Add("disabled", "disabled");
                LoadTobacco(true);
                LoadSmokingoptions();


                TobaccoCessationLIst = staticlookupMngr.getStaticLookupByFieldName("TOBACCO CESSATION COMMENTS");
                if (TobaccoCessationLIst.Count > 0)
                {
                    cboTobaccoCessationComments.Items.Clear();
                    cboTobaccoCessationComments.Items.Add(new ListItem(" "));
                    for (int i = 0; i < TobaccoCessationLIst.Count; i++)
                    {
                        ListItem item = new ListItem();
                        item.Text = TobaccoCessationLIst[i].Value;
                        cboTobaccoCessationComments.Items.Add(item);
                    }
                   
                }

                SmokingCessationList = staticlookupMngr.getStaticLookupByFieldName("SMOKING CESSATION COMMENTS");
                if (SmokingCessationList != null)
                {
                    if (SmokingCessationList.Count > 0)
                    {
                        cboSmokingCessationComments.Items.Clear();
                        cboSmokingCessationComments.Items.Add(new ListItem(" "));
                        for (int i = 0; i < SmokingCessationList.Count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Text = SmokingCessationList[i].Value;
                            cboSmokingCessationComments.Items.Add(item);
                        }
                        
                    }
                }

                BMIFollowupList = staticlookupMngr.getStaticLookupByFieldName("BMIComments");
                if (BMIFollowupList != null)
                {
                    if (BMIFollowupList.Count > 0)
                    {
                        cboFollowUpComments.Items.Clear();
                        cboFollowUpComments.Items.Add(new ListItem(" "));
                        for (int i = 0; i < BMIFollowupList.Count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Text = BMIFollowupList[i].Value;
                            cboFollowUpComments.Items.Add(item);
                        }
                      
                    }
                }

                if (chkTobaccoUseNo.Checked == false && chkTobaccoUseYes.Checked == false)
                {
                    cboTobaccoUse.Enabled = false;
                    cboTobaccoUse.SelectedIndex = -1;
                }
                if (chkTobaccoCessation.Checked == false)
                {
                    cboTobaccoCessationComments.Enabled = false;
                    cboTobaccoCessationComments.SelectedIndex = -1;
                }


                cboTobaccoCessationComments.Enabled = false;
                cboSmokingCessationComments.Enabled = false;
                cboFollowUpComments.Enabled = false;
                resultList = objPQRIMngr.GetSocialHistoryDetails(Human_Id, sTobacco, Physician_Id, Encouter_Id, "VITALS LIMIT LEVEL", true);
                Session["PQRIList"] = resultList;
                bPQRISave = true;
                LoadValuesFromSocialHistory(resultList, bPQRISave);
                saveCheckingFlag = false;
                btnSave.Attributes.Add("disabled", "disabled");
                cboTobaccoUse.Enabled = true;


            }
            else
            {
               
                if (Client_saveCheckingFlag.Value == "true")
                {
                    saveCheckingFlag = true;
                    
                }
                else
                {
                    saveCheckingFlag = false;
                }
                
                if (chkTobaccoUseYes.Checked == true || chkTobaccoUseNo.Checked==true)
                {
                    cboTobaccoUse.Enabled = true;
                    cboTobaccoUse.Items[0].Enabled = false;
                }


                if (chkTobaccoUseNo.Checked == false && chkTobaccoUseYes.Checked == false)
                {
                    cboTobaccoUse.Enabled = false;
                    cboTobaccoUse.SelectedIndex = -1;
                }


                if (chkSmokingCessation.Checked == false)
                {
                    cboSmokingCessationComments.SelectedIndex = -1;
                    cboSmokingCessationComments.Enabled = false;
                }


                if (chkBMIFollowUp.Checked == false)
                {
                    cboFollowUpComments.SelectedIndex = -1;
                    cboFollowUpComments.Enabled = false;
                }

                if (chkTobaccoCessation.Checked == false)
                {
                    cboTobaccoCessationComments.Enabled = false;
                    cboTobaccoCessationComments.SelectedIndex = -1;
                }

                if (chkSmokingHabitYes.Checked == true)
                {
                    cboSmokingHabit.Enabled = true;
                    
                }
                else
                {
                    cboSmokingHabit.Enabled = false;
                  
                }
                if (chkTobaccoCessation.Checked == true)
                {
                    cboTobaccoCessationComments.Enabled = true;
                    
                }
                else
                {
                    cboTobaccoCessationComments.Enabled = false;
                    cboTobaccoCessationComments.SelectedIndex = -1;
                }
                if (chkSmokingCessation.Checked == true)
                {
                    cboSmokingCessationComments.Enabled = true;
                    
                }
                else
                {  
                    cboSmokingCessationComments.Enabled = false;
                    cboSmokingCessationComments.SelectedIndex = -1;
                }
                if (chkBMIFollowUp.Checked == true)
                {
                    cboFollowUpComments.Enabled = true;
                    
                }
                else
                {
                    cboFollowUpComments.Enabled = false;
                    cboFollowUpComments.SelectedIndex = -1;
                }

                if (chkSmokingHabitNo.Checked == true)
                {
                    cboSmokingHabit.Enabled = false;
                    cboSmokingHabit.SelectedIndex = -1;
                }
                if (chkBMIFollowUp.Checked == false && chkSmokingCessation.Checked == false && chkTobaccoCessation.Checked == false && chkTobaccoUseYes.Checked == false && chkSmokingHabitYes.Checked == false)
                {
                    btnSave.Enabled = false;
                    btnSave.Attributes.Add("disabled", "disabled");
                }
                if (Session["BMI"] != null)
                    txtBmi.Text = Session["BMI"].ToString();
                btnSave.Enabled = true;
                btnSave.Attributes.Remove("disabled");
                btnSave.Enabled = true;
            }
             
        }

        private void LoadSmokingoptions()
        {
            IList<StaticLookup> SmokingoptionsListstat = new List<StaticLookup>();

            SmokingoptionsListstat = objStaticLookupManager.getStaticLookupByFieldName("SOCIAL HISTORY OPTION FOR SMOKING HABIT");

            if (SmokingoptionsListstat.Count > 0)
            {
                cboSmokingHabit.Items.Clear();
                cboSmokingHabit.Items.Add(new ListItem(" "));
                for (int k = 0; k < SmokingoptionsListstat.Count; k++)
                {
                    ListItem item = new ListItem();
                    item.Text = SmokingoptionsListstat[k].Value;
                    cboSmokingHabit.Items.Add(item);


                }

            }
           
        }
        private void LoadControlValues(string strCase, PQRI objPQRI, bool bCheckSave)
        {

            string tobaccoTag = string.Empty;
            string smokingYes = string.Empty;
            string BmiTag = string.Empty;
            strCase = strCase.ToUpper().Replace("AND EXPOSURE","").Trim();

            switch (strCase)
            {
                case "TOBACCO USE":
                    {
                        chkTobaccoUseYesTag.Value = Convert.ToString(objPQRI.Id);
                        tobaccoTag = Convert.ToString(objPQRI.Id);
                        if (objPQRI.PQRI_Value == "Y")
                        {
                            
                            if (bCheckSave == true)
                            {
                                chkTobaccoUseNo.Checked = false;
                                chkTobaccoUseYes.Checked = true;
                                cboTobaccoUse.Enabled = true;
                                LoadTobacco(true);
                                if (objPQRI.Options.Trim() != "")
                                    cboTobaccoUse.Text = objPQRI.Options;
                                else
                                {
                                    cboTobaccoUse.SelectedIndex = 0;
                                }
                                                                                                                            
                            }
                            
                        }
                        else if (objPQRI.PQRI_Value == "N")
                        {

                            if (bCheckSave == true)
                            {

                                LoadTobacco(false);
                                if (objPQRI.Options.Trim() != "")
                                    cboTobaccoUse.Text = objPQRI.Options;


                                chkTobaccoUseYes.Checked = false;
                                chkTobaccoUseNo.Checked = true;
                                cboTobaccoUse.Enabled = true;
                            }
                        }
                        else
                        {
                            chkTobaccoUseYes.Checked = false;
                            chkTobaccoUseNo.Checked = false;
                            cboTobaccoUse.SelectedIndex=-1;
                        }

                        if (objPQRI.Is_Done == "Y")
                        {
                              if (objPQRI.Additional_Measure_Value.Trim() != "")
                                cboTobaccoCessationComments.Text = objPQRI.Additional_Measure_Value;   
                                chkTobaccoCessation.Checked = true;
                                cboTobaccoCessationComments.Enabled = true;
                        }
                        else
                        {
                            if (objPQRI.Additional_Measure_Value.Trim() != "")
                            {
                                cboTobaccoCessationComments.SelectedIndex = 0;
                                chkTobaccoCessation.Checked = false;
                                cboTobaccoCessationComments.Enabled = false;
                            }
                       }

                        break;
                    }
                case "SMOKING HABIT":
                    {
                        chkSmokingHabbitYesTag.Value = Convert.ToString(objPQRI.Id);
                        smokingYes = Convert.ToString(objPQRI.Id);
                        if (bCheckSave == true)
                        {
                            if (objPQRI.Options.Trim() != "")
                                cboSmokingHabit.Text = objPQRI.Options;
                            else
                            {
                                cboSmokingHabit.SelectedIndex = 0;
                            }
                            
                                                                                  
                        }
                        if (objPQRI.PQRI_Value == "Y")
                        {
                            if (bCheckSave == true)
                            {
                                    chkSmokingHabitNo.Checked = false;
                                    chkSmokingHabitYes.Checked = true;
                                    cboSmokingHabit.Enabled = true;
                            }
                        }
                        else if (objPQRI.PQRI_Value == "N")
                        {
                            if (bCheckSave == true)
                            {
                                chkSmokingHabitYes.Checked = false;
                                chkSmokingHabitNo.Checked = true;
                                cboSmokingHabit.Enabled = false;
                            }
                        }
                        else
                        {
                            chkSmokingHabitYes.Checked = false;
                            chkSmokingHabitNo.Checked = false;
                            cboSmokingHabit.SelectedIndex=-1;
                        }

                        if (objPQRI.Is_Done == "Y")
                        {

                            if (objPQRI.Additional_Measure_Value.Trim() != "")
                                cboSmokingCessationComments.Text = objPQRI.Additional_Measure_Value; 

                            chkSmokingCessation.Checked = true;
                            cboSmokingCessationComments.Enabled = true;
                        }
                        else
                        {
                            if (objPQRI.Additional_Measure_Value.Trim() != "")
                                cboSmokingCessationComments.Text = objPQRI.Additional_Measure_Value; 

                            chkSmokingCessation.Checked = false;
                            cboSmokingCessationComments.Enabled = false;
                        }
                        break;
                    }

                case "BMI":
                    {
                        chkBMIFollowUpTag.Value = Convert.ToString(objPQRI.Id);
                        BmiTag = Convert.ToString(objPQRI.Id);
                        if (bCheckSave == true)
                        {
                            lblBMIStatus.Text = objPQRI.Options;
                           
                            txtBmi.Text = objPQRI.PQRI_Value;
                        }

                        if (objPQRI.Is_Done == "Y")
                        {
                            if (objPQRI.Additional_Measure_Value.Trim() != "")
                                cboFollowUpComments.Text = objPQRI.Additional_Measure_Value;
                            
                            chkBMIFollowUp.Checked = true;
                            cboFollowUpComments.Enabled = true;
                        }
                        else
                        {
                            if (objPQRI.Additional_Measure_Value.Trim() != "")
                                cboFollowUpComments.Text = objPQRI.Additional_Measure_Value;
                            
                            chkBMIFollowUp.Checked = false;
                            cboFollowUpComments.Enabled = false;
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        public void LoadValuesFromSocialHistory(PQRIDTO PqriDto, bool bPqridtoSave)
        {
            if (PqriDto.PQRIList.Count != 0)
            {
                for (int iNumber = 0; iNumber < PqriDto.PQRIList.Count; iNumber++)
                {
                    if (Convert.ToUInt64(PqriDto.PQRIList[iNumber].Encounter_ID) == Encouter_Id)
                    {
                        LoadControlValues(PqriDto.PQRIList[iNumber].PQRI_Name, PqriDto.PQRIList[iNumber], bPqridtoSave);
                    }
                }
            }
            if (bPqridtoSave != true)
            {
                if (PqriDto.Tobacco_Is_Present == "Y")
                {
                    chkTobaccoUseYes.Checked = true;
                    chkTobaccoUseNo.Checked = false;
                    cboTobaccoUse.Enabled = true;                    
                    foreach (ListItem item in cboTobaccoUse.Items)
                    {
                        if (item.Text.ToUpper() == PqriDto.Tobacco_Social_Info.ToUpper())
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            item.Selected = false;
                        }                        
                    }               
                }
                else
                {
                    cboTobaccoUse.Enabled = false;
                    chkTobaccoUseNo.Checked = true;
                }
                if (PqriDto.Smoking_Is_Present == "Y")
                {
                    chkSmokingHabitNo.Checked = false;
                    chkSmokingHabitYes.Checked = true;
                    cboSmokingHabit.Enabled = true;                    
                    foreach (ListItem item in cboSmokingHabit.Items)
                    {
                        if (item.Text.ToUpper() == PqriDto.SmokingHabit_Social_Info.ToUpper())
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }     
                }
                else
                {
                    cboSmokingHabit.Enabled = false;
                    chkSmokingHabitNo.Checked = true;
                 
                }
             }
            if (PqriDto.Bmi != "")
            {
                txtBmi.Text = PqriDto.Bmi;
                Session["BMI"] = PqriDto.Bmi;
            }
            if (PqriDto.Bmi_Status != "")
            {
                lblBMIStatus.Text = PqriDto.Bmi_Status;
            }

        }
        #endregion

        #region Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sForCancel = hdnMessageType.Value;
            hdnMessageType.Value = string.Empty;
            IList<PQRI> Save = new List<PQRI>();
            PQRI objTobaccolist = null;
            PQRI objSmoking = null;
            PQRI objBmi = null;            
            objTobaccolist = new PQRI();
            objSmoking = new PQRI();
            objBmi = new PQRI();
            int tobaccoTag = 0;
            int smokingYes = 0;
            int BmiTag = 0;
            if (chkTobaccoUseYesTag.Value != "")
            {
                tobaccoTag = Convert.ToInt32(chkTobaccoUseYesTag.Value);
            }
            if (chkSmokingHabbitYesTag.Value != "")
            {
                smokingYes = Convert.ToInt32(chkSmokingHabbitYesTag.Value);
            }
            if (chkBMIFollowUpTag.Value != "")
            {
                BmiTag = Convert.ToInt32(chkBMIFollowUpTag.Value);
            }
            if ((tobaccoTag == 0) && (smokingYes == 0) && (BmiTag == 0))
            { 
                objTobaccolist.PQRI_Name = lblTobaccoUse.Text;
                if (chkTobaccoUseYes.Checked == true)
                {
                    objTobaccolist.PQRI_Value = "Y";
                }
                else if (chkTobaccoUseNo.Checked == true)
                    
                    {
                        objTobaccolist.PQRI_Value = "N";
                    }
                else if (chkTobaccoUseNo.Checked == false && chkTobaccoUseYes.Checked == false)
                {
                    objTobaccolist.PQRI_Value ="";
                }
                if (chkTobaccoCessation.Checked == true)
                {
                    objTobaccolist.Is_Done = "Y";
                }
                else
                {
                    objTobaccolist.Is_Done = "N";
                }

                objTobaccolist.Created_By = ClientSession.UserName;
                objTobaccolist.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                objTobaccolist.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objTobaccolist.Human_ID = Convert.ToInt32(Human_Id);
                objTobaccolist.Physician_ID = Convert.ToInt32(Physician_Id);
                objTobaccolist.Encounter_ID = Convert.ToInt32(Encouter_Id);
                objTobaccolist.Additional_Measure_Name = chkTobaccoCessation.Text;
                objTobaccolist.Additional_Measure_Value = cboTobaccoCessationComments.Text; 
                objTobaccolist.Options = cboTobaccoUse.Text;
                Save.Add(objTobaccolist);

                //Saving Smoking list
                objSmoking.PQRI_Name = lblSmokingHabit.Text;
                if (chkSmokingHabitYes.Checked == true)
                {
                    objSmoking.PQRI_Value = "Y";
                }
                else if (chkSmokingHabitNo.Checked == true)
                {
                    objSmoking.PQRI_Value = "N";
                }
                else if (chkSmokingHabitNo.Checked == false && chkSmokingHabitNo.Checked == false)
                {
                    objSmoking.PQRI_Value ="";
                }
                if (chkSmokingCessation.Checked == true)
                {
                    objSmoking.Is_Done = "Y";
                }
                else
                {
                    objSmoking.Is_Done = "N";
                }
                objSmoking.Created_By = ClientSession.UserName;
                objSmoking.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                objSmoking.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objSmoking.Human_ID = Convert.ToInt32(Human_Id);
                objSmoking.Physician_ID = Convert.ToInt32(Physician_Id);
                objSmoking.Encounter_ID = Convert.ToInt32(Encouter_Id);
                objSmoking.Additional_Measure_Name = chkSmokingCessation.Text;
                objSmoking.Additional_Measure_Value = cboSmokingCessationComments.Text; 
                objSmoking.Options = cboSmokingHabit.Text;
                Save.Add(objSmoking);

                //Saving BMI
                objBmi.PQRI_Name = lblBMI.Text;
                objBmi.PQRI_Value = txtBmi.Text;
                if (chkBMIFollowUp.Checked == true)
                {
                    objBmi.Is_Done = "Y";
                }
                else
                {
                    objBmi.Is_Done = "N";
                }
                objBmi.Created_By = ClientSession.UserName;
                objBmi.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                objBmi.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objBmi.Human_ID = Convert.ToInt32(Human_Id);
                objBmi.Physician_ID = Convert.ToInt32(Physician_Id);
                objBmi.Encounter_ID = Convert.ToInt32(Encouter_Id);
                objBmi.Additional_Measure_Name = chkBMIFollowUp.Text;
                objBmi.Additional_Measure_Value = cboFollowUpComments.Text;
                objBmi.Options = lblBMIStatus.Text;
                Save.Add(objBmi);
                string strfrom = "PQRI";
                resultList = objPQRIMngr.SavePQRIData(Save.ToArray<PQRI>(), null, strfrom);
                bPQRISave = true;
                LoadValuesFromSocialHistory(resultList, bPQRISave);
                saveCheckingFlag = false;
                if (sForCancel == "Yes")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003');close();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003');", true);
                }
                btnSave.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003');", true);
                btnSave.Attributes.Add("disabled", "disabled");
            }
            else
            {
                UpdateResultlist = new List<PQRI>();
                objUpdateTobaccoUse = new PQRI();
                objUpdateSmokinguse = new PQRI();
                objUpdateBmi = new PQRI();

                resultList = (PQRIDTO)Session["PQRIList"];
                if (chkTobaccoUseYesTag.Value != "")
                {
                    objUpdateTobaccoUse = (from UpdatePqrilist in resultList.PQRIList
                                           where UpdatePqrilist.Id == Convert.ToInt32(chkTobaccoUseYesTag.Value)
                                           select UpdatePqrilist).ToList<PQRI>()[0];
                }
                objUpdateTobaccoUse.PQRI_Name = lblTobaccoUse.Text;
                if (chkTobaccoUseYes.Checked == true)
                {
                    objUpdateTobaccoUse.PQRI_Value = "Y";
                }
                else if (chkTobaccoUseNo.Checked == true)
                {
                    objUpdateTobaccoUse.PQRI_Value = "N";
                }
                else if (chkTobaccoUseNo.Checked == false && chkTobaccoUseYes.Checked == false)
                {
                    objUpdateTobaccoUse.PQRI_Value = "";
                }
                if (chkTobaccoCessation.Checked == true)
                {
                    objUpdateTobaccoUse.Is_Done = "Y";
                }
                else
                {
                    objUpdateTobaccoUse.Is_Done = "N";
                
                }
                objUpdateTobaccoUse.Modified_By = ClientSession.UserName;
                objUpdateTobaccoUse.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objUpdateTobaccoUse.Human_ID = Convert.ToInt32(Human_Id);
                objUpdateTobaccoUse.Physician_ID = Convert.ToInt32(Physician_Id);
                objUpdateTobaccoUse.Encounter_ID = Convert.ToInt32(Encouter_Id);
                objUpdateTobaccoUse.Additional_Measure_Name = chkTobaccoCessation.Text;
                objUpdateTobaccoUse.Additional_Measure_Value = cboTobaccoCessationComments.Text; 
                objUpdateTobaccoUse.Options = cboTobaccoUse.Text;
                UpdateResultlist.Add(objUpdateTobaccoUse); 
 
                //Update smoking list
                if (chkSmokingHabbitYesTag.Value != "")
                {
                    objUpdateSmokinguse = (from UpdatePqrilist in resultList.PQRIList
                                           where UpdatePqrilist.Id == Convert.ToInt32(chkSmokingHabbitYesTag.Value)
                                           select UpdatePqrilist).ToList<PQRI>()[0];
                }
                
                objUpdateSmokinguse.PQRI_Name = lblSmokingHabit.Text;
                if (chkSmokingHabitYes.Checked == true)
                {
                    objUpdateSmokinguse.PQRI_Value = "Y";
                }
                else if (chkSmokingHabitNo.Checked == true)
                {
                    objUpdateSmokinguse.PQRI_Value = "N";
                }
                else if (chkSmokingHabitNo.Checked == false && chkSmokingHabitNo.Checked == false)
                {
                    objUpdateSmokinguse.PQRI_Value = "";
                }
                if (chkSmokingCessation.Checked == true)
                {
                    objUpdateSmokinguse.Is_Done = "Y";
                }
                else
                {
                    objUpdateSmokinguse.Is_Done = "N";
                }
                objUpdateSmokinguse.Modified_By = ClientSession.UserName;
                objUpdateSmokinguse.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objUpdateSmokinguse.Human_ID = Convert.ToInt32(Human_Id);
                objUpdateSmokinguse.Physician_ID = Convert.ToInt32(Physician_Id);
                objUpdateSmokinguse.Encounter_ID = Convert.ToInt32(Encouter_Id);
                objUpdateSmokinguse.Additional_Measure_Name = chkSmokingCessation.Text;
                objUpdateSmokinguse.Additional_Measure_Value = cboSmokingCessationComments.Text; 
                objUpdateSmokinguse.Options = cboSmokingHabit.Text;
                UpdateResultlist.Add(objUpdateSmokinguse);

                //Update BMI
                if (chkBMIFollowUpTag.Value!="")
                {
                    objUpdateBmi = (from UpdatePqrilist in resultList.PQRIList
                                    where UpdatePqrilist.Id == Convert.ToInt32(chkBMIFollowUpTag.Value)
                                    select UpdatePqrilist).ToList<PQRI>()[0];
                }
                              
                objUpdateBmi.PQRI_Name = lblBMI.Text;
                objUpdateBmi.PQRI_Value = txtBmi.Text;
                if (chkBMIFollowUp.Checked == true)
                {
                    objUpdateBmi.Is_Done = "Y";

                }
                else
                {
                    objUpdateBmi.Is_Done = "N";
                }
                objUpdateBmi.Modified_By = ClientSession.UserName;
                objUpdateBmi.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objUpdateBmi.Human_ID = Convert.ToInt32(Human_Id);
                objUpdateBmi.Physician_ID = Convert.ToInt32(Physician_Id);
                objUpdateBmi.Encounter_ID = Convert.ToInt32(Encouter_Id);
                objUpdateBmi.Additional_Measure_Name = chkBMIFollowUp.Text;
                objUpdateBmi.Additional_Measure_Value = cboFollowUpComments.Text;
                objUpdateBmi.Options = lblBMIStatus.Text;
                UpdateResultlist.Add(objUpdateBmi);
                string strfrom = "PQRI";
                resultList = objPQRIMngr.SavePQRIData(null, UpdateResultlist.ToArray<PQRI>(), strfrom);
                Session["PQRIList"] = resultList;
                bPQRISave = true;
                LoadValuesFromSocialHistory(resultList, bPQRISave);
                if (sForCancel == "Yes")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003');close();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003');", true);
                }
                btnSave.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003');", true);
                btnSave.Attributes.Add("disabled", "disabled");
                bSaveCompleted = true;
                saveCheckingFlag = false;
            }

        }
        #endregion   

        protected void chkTobaccoUseYes_CheckedChanged(object sender, EventArgs e)
        {
            if (hdnCheckedChangeFlag.Value != "true")
            {
                if (chkTobaccoUseYes.Checked == true)
                {
                    LoadTobacco(true);
                }
            }
         }

        protected void chkTobaccoUseNo_CheckedChanged(object sender, EventArgs e)
        {

            if (hdnCheckedChangeFlag.Value != "true")
            {
                if (chkTobaccoUseNo.Checked == true)
                {
                    LoadTobacco(false);
                }
            }

          
         }
    }
}
