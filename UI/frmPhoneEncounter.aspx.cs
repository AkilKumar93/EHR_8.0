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
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using iTextSharp.text;

namespace Acurus.Capella.UI
{
    public partial class frmPhoneEncounter : System.Web.UI.Page
    {


        StaticLookupManager objStaticLookupManager = new StaticLookupManager();
        EncounterManager objEncounterManager = new EncounterManager();
        TreatmentPlanManager objTreatmentPlanManager = new TreatmentPlanManager();
        HumanManager objHumanManager = new HumanManager();
        IList<Human> objHuman = new List<Human>();
        IList<PhysicianLibrary> PhyList = new List<PhysicianLibrary>();
        PhysicianManager PhyMngr = new PhysicianManager();
        string OpeningFrom = string.Empty;
        Encounter objEnc = new Encounter();
        //ulong Human_ID = 0;
        //ulong Enc_ID = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OpeningFrom = Request["openingfrom"].ToString();
                DLC.txtDLC.Attributes.Add("onkeypress", "EnableSave();");
                DLC.txtDLC.Attributes.Add("onchange", "EnableSave();");
                if (Request["PatientGender"] != null && Request["PatientGender"].ToString().Trim() != string.Empty)
                    txtPatientSex.Text = Request["PatientGender"].ToString();
                if (Request["PatientName"] != null && Request["PatientName"].ToString().Trim() != string.Empty)
                    txtPatientName.Text = Request["PatientName"].ToString();
                if (Request["PatientDOB"] != null && Request["PatientDOB"].ToString().Trim() != string.Empty)
                    txtPatientDOB.Text = Request["PatientDOB"].ToString();
                if (OpeningFrom.Trim() == "Menu")
                {
                    lblcabture.Text = "Call Date*";
                    lblcabture.ForeColor = System.Drawing.Color.Red;
                    //lblCallSpokenTo.Text = "Call Spoken To*";
                    //lblCallSpokenTo.ForeColor = System.Drawing.Color.Red;
                    lblCallerName.Text = "Call Spoken To*";
                    lblCallerName.ForeColor = System.Drawing.Color.Red;
                    if (Request["MyHumanID"] != null && Request["MyHumanID"].ToString().Trim() != string.Empty)
                        txtAccountNumber.Text = Request["MyHumanID"].ToString();
                    else
                        txtAccountNumber.Text = Convert.ToString(ClientSession.HumanId);
                }
                else
                {

                    txtAccountNumber.Text = ClientSession.HumanId.ToString();
                    //if (Request["EncId"] != null && Request["EncId"].ToString().Trim() != string.Empty)
                    //    Enc_ID = Convert.ToUInt64(Request["EncId"].ToString());
                }

                //if (OpeningFrom.Trim() == "Menu")
                //{
                //    //LoadCallSpokenTo();
                //    LoadPatientDetails();
                //}
                if (OpeningFrom.Trim() != "Menu" && ClientSession.UserRole.ToUpper() != "FRONT OFFICE")
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisabledCall();", true);
                    txtCalldate.Value = "";
                    DLC.txtDLC.Enabled = false;
                    DLC.txtDLC.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFDBFF");
                    DLC.txtDLC.BorderColor = System.Drawing.Color.Black;
                    txtAccountNumber.ReadOnly = true;
                    txtCallerName.ReadOnly = true;
                    txtCallHrs.ReadOnly = true;
                    txtCallMins.ReadOnly = true;
                    txtExtension.ReadOnly = true;
                    cboCallSpokenTo.Disabled = true;
                    txtCallerName.Enabled = false;
                    txtPatientDOB.ReadOnly = true;
                    txtPatientName.ReadOnly = true;
                    txtPatientSex.ReadOnly = true;
                    mskCellPhone.ReadOnly = true;
                    mskWorkPhno.ReadOnly = true;
                    mskHomePhone.ReadOnly = true;
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;
                    btnSave.Visible = false;
                    //txtCallerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFDBFF");
                    //txtCallerName.BorderColor = System.Drawing.Color.Black;
                    txtCallHrs.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFDBFF");
                    txtCallHrs.BorderColor = System.Drawing.Color.Black;
                    txtCallMins.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFDBFF");
                    txtCallMins.BorderColor = System.Drawing.Color.Black;
                    DLC.pbDropdown.Disabled = true;
                    DLC.Enable = false;


                    IList<Encounter> objEncount = new List<Encounter>();
                    objEncount = objEncounterManager.GetEncounterByEncounterID(Convert.ToUInt32(Request["EncId"]));

                    if (objEncount.Count > 0)
                    {
                        if (objEncount[0].Call_Spoken_To != string.Empty)
                        {
                            txtCallerName.Text = objEncount[0].Call_Spoken_To;
                        }

                        //if (objEncount[0].Call_Duration != 0)
                        //    txtCallHrs.Text = Convert.ToString(objEncount[0].Call_Duration);
                        if (objEncount[0].Call_Duration != "")
                            txtCallHrs.Text = objEncount[0].Call_Duration;


                        if (objEncount[0].Duration_Minutes != 0)
                            txtCallMins.Text = Convert.ToString(objEncount[0].Duration_Minutes);

                        if (objEncount[0].Relationship != string.Empty)
                        {
                            for (int i = 0; i < cboCallSpokenTo.Items.Count; i++)
                            {
                                if (cboCallSpokenTo.Items[i].Text == objEncount[0].Relationship)
                                {
                                    cboCallSpokenTo.Items[i].Selected = true;
                                }
                            }
                        }
                        if (objEncount[0].Date_of_Service.ToString() != "0001-01-01")
                            txtCalldate.Value = UtilityManager.ConvertToLocal(objEncount[0].Date_of_Service).ToString("dd-MMM-yyyy hh:mm tt");
                        //if (objEncount[0].Appointment_Date.ToString() != "0001-01-01")
                        //    txtCalldate.Value = UtilityManager.ConvertToLocal(objEncount[0].Appointment_Date).ToString("dd-MMM-yyyy hh:mm tt");
                        //txtCalldate.Value = Convert.ToDateTime(objEncount[0].Call_Date).ToString("dd-MMM-yyyy hh:mm tt");
                        //txtCalldate.Value = objEncount[0].Call_Date.ToString("dd-MMM-yyyy");
                    }

                    if ((Request["EncId"] != null && Request["EncId"].ToString().Trim() != string.Empty) || (txtAccountNumber.Text != string.Empty))
                    {
                        IList<TreatmentPlan> TreatmentPlanlst = objTreatmentPlanManager.GetTreatmentPlanUsingEncounterId(Convert.ToUInt32(Request["EncId"]), Convert.ToUInt32(txtAccountNumber.Text));
                        if (TreatmentPlanlst != null && TreatmentPlanlst.Count > 0 && TreatmentPlanlst.Where(a => a.Plan_Type == "PLAN").ToList<TreatmentPlan>().Count > 0)
                        {
                            TreatmentPlan objTreatmentPlan = TreatmentPlanlst.Where(a => a.Plan_Type == "PLAN").ToList<TreatmentPlan>()[0];
                            DLC.txtDLC.Text = objTreatmentPlan.Plan;
                        }
                    }
                }
                else
                {
                    txtCalldate.Disabled = false;
                    txtCalldate.Value = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"); //UtilityManager.ConvertToLocal(DateTime.Now).ToString("dd-MMM-yyyy hh:mm tt");//DateTime.UtcNow.ToString("dd-MMM-yyyy");//UtilityManager.ConvertToUniversal().ToString("dd-MMM-yyyy");
                }
                LoadPatientDetails();
                ClientSession.processCheck = true;
                SecurityServiceUtility objSecurityServiceUtility = new SecurityServiceUtility();
                objSecurityServiceUtility.ApplyUserPermissions(this);


                if (OpeningFrom.Trim() != "Menu")
                {
                    DLC.pbDropdown.Disabled = true;
                    DLC.Enable = false;
                }

                if (OpeningFrom.Trim() == "PatientChart")
                {
                    //frmphoneencounters.style.add("height", request["height"].tostring());
                    //frmphoneencounters.style.add("width", request["width"].tostring());
                    //cboCallSpokenTo.Enabled = false;
                    cboCallSpokenTo.Disabled = true;
                    //Added for BugID:45808		
                    tdPhEnc.Attributes.Add("align", "left");
                    tblPhEnc.Style.Add("margin-left", "5%");
                    tblPhEnc.Style.Add("margin-top", "4%");
                    fldsetPhEnc.Style.Add("height", "315px");
                    tbl.Style.Add("height", "250px");
                    btnClose.Visible = false;
                }
                if (cboCallSpokenTo.Disabled == true)
                {
                    txtCallerName.Enabled = false;
                }

                btnSave.Enabled = false;
                //hdnEnableSave.Value = "false";
                if (cboCallSpokenTo != null && (cboCallSpokenTo.Value == "Self"))
                    txtCallerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFDBFF");
                else if (txtCallerName.Enabled == true)
                    txtCallerName.BackColor = System.Drawing.Color.White;
                else if (txtCallerName.Enabled == false)
                    txtCallerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFDBFF");


                if (txtCallerName.Text != string.Empty || txtCallHrs.Text != string.Empty || txtCallMins.Text != string.Empty || DLC.txtDLC.Text != string.Empty || cboCallSpokenTo.Value != string.Empty)
                {
                    btnSave.Enabled = true;
                }

            }
        }
        //public void LoadCallSpokenTo()
        //{
        //    IList<StaticLookup> Staticlst = objStaticLookupManager.getStaticLookupByFieldName("SOURCE OF INFORMATION");
        //    if (Staticlst != null && Staticlst.Count > 0)
        //    {
        //        cboCallSpokenTo.Items.Add(new RadComboBoxItem(""));
        //        for (int i = 0; i < Staticlst.Count; i++)
        //            cboCallSpokenTo.Items.Add(new RadComboBoxItem(Staticlst[i].Value));
        //    }

        //}
        public void LoadPatientDetails()
        {

            IList<string> ilstPhoneEncounterTagList = new List<string>();
            ilstPhoneEncounterTagList.Add("HumanList");

            IList<object> ilstPhoneBlob = new List<object>();
            ilstPhoneBlob = UtilityManager.ReadBlob(Convert.ToUInt64(txtAccountNumber.Text), ilstPhoneEncounterTagList);

            if(ilstPhoneBlob.Count>0 && ilstPhoneBlob!=null)
            {
                if (ilstPhoneBlob[0]!=null)
                {
                    for (int iCount = 0; iCount < ((IList<object>)ilstPhoneBlob[0]).Count; iCount++)
                    {
                        txtAccountNumber.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Id.ToString();
                        txtPatientName.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Last_Name + "," + ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).First_Name + "  " + ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).MI + "  " + ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Suffix;
                        hdnHumanDetails.Value = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Last_Name + "|" + ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).First_Name + "|" + ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).MI;

                        DateTime dt = Convert.ToDateTime(((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Birth_Date);
                        txtPatientDOB.Text = dt.ToString("dd-MMM-yyyy");
                        txtPatientSex.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Sex;
                        txtExtension.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Work_Phone_Ext;
                        mskHomePhone.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Work_Phone_No;
                        mskCellPhone.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Cell_Phone_Number;
                        mskWorkPhno.Text = ((Human)((IList<object>)ilstPhoneBlob[0])[iCount]).Work_Phone_No;
                    }

                }
            }


            //objHuman = new List<Human>();
            //if (txtAccountNumber.Text != string.Empty)
            //{


            //    string FileName = "Human" + "_" + txtAccountNumber.Text + ".xml";
            //    string strXmlFilePath = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["XMLPath"], FileName);
            //    if (File.Exists(strXmlFilePath) == true)
            //    {
            //        XmlDocument itemDoc = new XmlDocument();
            //        XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
            //        XmlNodeList xmlTagName = null;
            //        // itemDoc.Load(XmlText);
            //        using (FileStream fs = new FileStream(strXmlFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //        {
            //            itemDoc.Load(fs);
            //            XmlText.Close();



            //            if (itemDoc.GetElementsByTagName("HumanList") != null && itemDoc.GetElementsByTagName("HumanList").Count>0)
            //            {
            //                xmlTagName = itemDoc.GetElementsByTagName("HumanList")[0].ChildNodes;

            //                if (xmlTagName!= null)
            //                {
            //                    for (int j = 0; j < xmlTagName.Count; j++)
            //                    {
            //                        if (xmlTagName[j].Attributes["Id"].Value == txtAccountNumber.Text.ToString())
            //                        {
            //                            txtAccountNumber.Text = xmlTagName[j].Attributes["Id"].Value.ToString();
            //                            txtPatientName.Text = xmlTagName[j].Attributes["Last_Name"].Value + "," + xmlTagName[j].Attributes["First_Name"].Value + "  " + xmlTagName[j].Attributes["MI"].Value + "  " + xmlTagName[j].Attributes["Suffix"].Value;
            //                            hdnHumanDetails.Value = xmlTagName[j].Attributes["Last_Name"].Value + "|" + xmlTagName[j].Attributes["First_Name"].Value + "|" + xmlTagName[j].Attributes["MI"].Value;

            //                            DateTime dt = Convert.ToDateTime(xmlTagName[j].Attributes["Birth_Date"].Value);
            //                            txtPatientDOB.Text = dt.ToString("dd-MMM-yyyy");
            //                            txtPatientSex.Text = xmlTagName[j].Attributes["Sex"].Value;
            //                            txtExtension.Text = xmlTagName[j].Attributes["Work_Phone_Ext"].Value;
            //                            mskHomePhone.Text = xmlTagName[j].Attributes["Home_Phone_No"].Value;
            //                            mskCellPhone.Text = xmlTagName[j].Attributes["Cell_Phone_Number"].Value;
            //                            mskWorkPhno.Text = xmlTagName[j].Attributes["Work_Phone_No"].Value;

            //                        }
            //                    }
            //                }

            //            }
            //            fs.Close();
            //            fs.Dispose();
            //        }
            //    }
                //objHuman = objHumanManager.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt32(txtAccountNumber.Text));
                //if (objHuman.Count > 0)
                //{
                //    txtAccountNumber.Text = objHuman[0].Id.ToString();
                //    txtPatientName.Text = objHuman[0].Last_Name + "," + objHuman[0].First_Name + "  " + objHuman[0].MI + "  " + objHuman[0].Suffix;
                //    hdnHumanDetails.Value = objHuman[0].Last_Name + "|" + objHuman[0].First_Name + "|" + objHuman[0].MI;
                //    txtPatientDOB.Text = objHuman[0].Birth_Date.ToString("dd-MMM-yyyy");
                //    txtPatientSex.Text = objHuman[0].Sex;
                //    txtAccountNumber.Text = objHuman[0].Id.ToString();
                //    txtExtension.Text = objHuman[0].Work_Phone_Ext;
                //    mskHomePhone.Text = objHuman[0].Home_Phone_No;
                //    mskCellPhone.Text = objHuman[0].Cell_Phone_Number;
                //    mskWorkPhno.Text = objHuman[0].Work_Phone_No;
                //}

           // }
        }

        protected void InvisibleCloseButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            DateTime utc = new DateTime();
            if (hdnLocalTime.Value != string.Empty)
            {
                string strtime = hdnLocalTime.Value.ToString().Split('G').ElementAt(0).ToString();
                utc = Convert.ToDateTime(strtime);

            }

            if (txtCalldate.Disabled == false)
            {
                if (txtCalldate.Value.Trim() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisplayErrorMessage('7430008');datetime(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    btnSave.Enabled = true;
                    txtCalldate.Focus();
                    return;
                }
                //else if(Convert.ToDateTime(txtCalldate.Value) > DateTime.Now)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisplayErrorMessage('7430009'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                //    btnSave.Enabled = true;
                //    txtCalldate.Value = "";
                //    txtCalldate.Focus();
                //    return;
                //}
                if (Convert.ToDateTime(txtCalldate.Value) < Convert.ToDateTime(txtPatientDOB.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisplayErrorMessage('7430009'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    btnSave.Enabled = true;
                    txtCalldate.Value = "";
                    txtCalldate.Focus();
                    return;
                }
            }
            if (txtCallerName.ReadOnly == false)
            {
                if (txtCallerName.Text.Trim() == string.Empty)
                {
                    txtCallerName.Focus();
                    btnSave.Enabled = true;
                    txtCallerName.BackColor = System.Drawing.Color.White;
                    txtCallerName.BorderColor = System.Drawing.Color.Gray;
                    // hdnEnableSave.Value = "true";
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisplayErrorMessage('7430000'); datetime();{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisplayErrorMessage('7430004');datetime(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                txtPassword.Focus();
                return;
            }
            else
            {
                UserManager userManger = new UserManager();
                if (!(userManger.CheckIfValidPwd(ClientSession.UserName, UIManager.Encryptionbase64Encode(txtPassword.Text))))//BugID:54512
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Test", "DisplayErrorMessage('7430005'); datetime();{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
                    return;
                }
            }

            //if (txtAccountNumber.Text != string.Empty)
            //{
            //    objHuman = objHumanManager.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt32(txtAccountNumber.Text));

            //}

            IList<Encounter> EncounterLst = new List<Encounter>();
            IList<TreatmentPlan> PlanLst = new List<TreatmentPlan>();

            Encounter EncRecord = new Encounter();
            TreatmentPlan objTrtPlan = new TreatmentPlan();

            EncRecord.Created_By = ClientSession.UserName;
            EncRecord.Created_Date_and_Time = UtilityManager.ConvertToUniversal();
            objTrtPlan.Created_By = ClientSession.UserName;
            objTrtPlan.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
            objTrtPlan.Local_Time = UtilityManager.ConvertToLocal(objTrtPlan.Created_Date_And_Time).ToString("yyyy-MM-dd hh:mm:ss tt");
            EncRecord.Is_Phone_Encounter = "Y";
            if (txtAccountNumber.Text != string.Empty)
            {
                EncRecord.Human_ID = Convert.ToUInt32(txtAccountNumber.Text);
            }
            EncRecord.Facility_Name = ClientSession.FacilityName;
            //EncRecord.Date_of_Service = utc; //UtilityManager.ConvertToUniversal(utc);//UtilityManager.ConvertToUniversal();
            EncRecord.Encounter_Provider_ID = Convert.ToInt32(ClientSession.PhysicianId);
            EncRecord.Appointment_Provider_ID = Convert.ToInt32(ClientSession.PhysicianId);
            //EncRecord.Appointment_Date = UtilityManager.ConvertToUniversal();
            EncRecord.Encounter_Provider_Signed_Date = UtilityManager.ConvertToUniversal();

            if (txtCallHrs.Text != string.Empty && txtCallHrs.Text != "0")
                EncRecord.Call_Duration = txtCallHrs.Text;
                //EncRecord.Call_Duration = Convert.ToInt32(txtCallHrs.Text);
            if (txtCallMins.Text != string.Empty && txtCallMins.Text != "0")
                EncRecord.Duration_Minutes = Convert.ToInt32(txtCallMins.Text);

            EncRecord.Relationship = cboCallSpokenTo.Value;
            EncRecord.Call_Spoken_To = txtCallerName.Text;
            //code added by balaji
            if ((txtCalldate.Value != null) && txtCalldate.Value.Trim() != "" && (txtCalldate.Value.ToString() != "0001-01-01"))
            {
                EncRecord.Date_of_Service = UtilityManager.ConvertToUniversal(Convert.ToDateTime(txtCalldate.Value));
                EncRecord.Appointment_Date = Convert.ToDateTime(txtCalldate.Value.ToString().Split('G').ElementAt(0).ToString());
            }
            EncRecord.Local_Time = UtilityManager.ConvertToLocal(EncRecord.Date_of_Service).ToString("yyyy-MM-dd hh:mm:ss tt");
            //if ((txtCalldate.Value != null) && txtCalldate.Value.Trim() != "" && (txtCalldate.Value.ToString() != "0001-01-01"))
            //    EncRecord.Appointment_Date = UtilityManager.ConvertToUniversal(Convert.ToDateTime(txtCalldate.Value));                             
            EncounterLst.Add(EncRecord);
            if (txtAccountNumber.Text != string.Empty)
            {
                objTrtPlan.Human_ID = Convert.ToUInt32(txtAccountNumber.Text);
            }

            objTrtPlan.Physician_Id = Convert.ToUInt64(ClientSession.PhysicianId);
            objTrtPlan.Plan_Type = "PLAN";
            objTrtPlan.Plan = DLC.txtDLC.Text;

            PlanLst.Add(objTrtPlan);

            string strHumanDetails = string.Empty;
            string Age = string.Empty;
            if (txtPatientDOB.Text != string.Empty)
            {
                Age = UtilityManager.CalculateAge(Convert.ToDateTime(txtPatientDOB.Text)).ToString(); ;
            }

            if(hdnHumanDetails.Value!= null)
            strHumanDetails = hdnHumanDetails.Value + "|" + txtPatientDOB.Text + "|" + Age + "|" + txtPatientSex.Text + "|" + txtAccountNumber.Text + "|" + ClientSession.FacilityName + "|" + ClientSession.PhysicianId;

            if (ClientSession.PhysicianId > 0)
            {

                PhysicianLibrary objPhyLib = null;
                XmlDocument xmldoc = new XmlDocument();
                string strXmlFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\PhysicianFacilityMapping.xml");
                if (File.Exists(strXmlFilePath) == true)
                {
                    xmldoc.Load(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "ConfigXML\\" + "PhysicianFacilityMapping" + ".xml");
                    XmlNode nodeMatchingPhysician = xmldoc.SelectSingleNode("/ROOT/PhyList/Facility/Physician[@ID='" + ClientSession.PhysicianId.ToString() + "']");
                    if (nodeMatchingPhysician != null)
                    {
                        objPhyLib = new PhysicianLibrary();
                        objPhyLib.PhyPrefix = nodeMatchingPhysician.Attributes["prefix"].Value.ToString();
                        objPhyLib.PhyFirstName = nodeMatchingPhysician.Attributes["firstname"].Value.ToString();
                        objPhyLib.PhyMiddleName = nodeMatchingPhysician.Attributes["middlename"].Value.ToString();
                        objPhyLib.PhyLastName = nodeMatchingPhysician.Attributes["lastname"].Value.ToString();
                        objPhyLib.PhySuffix = nodeMatchingPhysician.Attributes["suffix"].Value.ToString();
                        objPhyLib.PhyId = Convert.ToUInt32(nodeMatchingPhysician.Attributes["ID"].Value.ToString());
                        objPhyLib.Id = Convert.ToUInt32(nodeMatchingPhysician.Attributes["ID"].Value.ToString());
                        objPhyLib.Is_Active = nodeMatchingPhysician.Attributes["status"].Value.ToString();
                    }
                }

                if (objPhyLib != null)
                {
                    strHumanDetails = strHumanDetails + "|" + objPhyLib.PhyPrefix + " " + objPhyLib.PhyFirstName + " " + objPhyLib.PhyMiddleName + " " + objPhyLib.PhyLastName + " " + objPhyLib.PhySuffix;
                }
                else
                {
                    strHumanDetails = strHumanDetails + "| ";
                }


                //PhyList = PhyMngr.GetphysiciannameByPhyID(ClientSession.PhysicianId);

                //if (PhyList.Count > 0)
                //{
                //    strHumanDetails = strHumanDetails + "|" + PhyList[0].PhyPrefix + " " + PhyList[0].PhyFirstName + " " + PhyList[0].PhyMiddleName + " " + PhyList[0].PhyLastName + " " + PhyList[0].PhySuffix;
                //}
                //else
                //{
                //    strHumanDetails = strHumanDetails + "| ";
                //}
            }
            else
            {
                strHumanDetails = strHumanDetails + "| ";
            }

            objEncounterManager.SaveUpdatePhoneEncounter(EncounterLst, PlanLst, strHumanDetails, string.Empty);

            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "FormClosing", "Close();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "DisplayErrorMessage('7060003'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
            btnSave.Enabled = false;
            //hdnEnableSave.Value = "false";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

    }
}
