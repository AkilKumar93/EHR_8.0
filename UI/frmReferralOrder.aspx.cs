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
using Telerik.Web.UI;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DTO;
using System.IO;
using System.Drawing;
using System.Globalization;


namespace Acurus.Capella.UI
{
    public partial class frmReferralOrder : System.Web.UI.Page
    {
        StaticLookupManager objStaticLookupManager = new StaticLookupManager();
        ReferralOrderManager objReferralOrderManager = new ReferralOrderManager();
        FacilityManager objFacilityManager = new FacilityManager();
    
        public Dictionary<string, ulong> dAssessment
        {
            get
            {
                return (Dictionary<string, ulong>)ViewState["dAssessment"] ?? new Dictionary<string, ulong>();
            }
            set
            {
                ViewState["dAssessment"] = value;

            }
        }
        ReferralOrderDTO objRefOrdDTO = null;
        IList<string> SelectedAssessment = null;
        public IList<ProblemList> problemList = null;
        ReferralOrder delUpdtObj = null;
        DateTime dtEncounterDate = DateTime.MinValue;
        //FillHumanDTO humanRecord = null;
        //DateTime utc = DateTime.MinValue;

        string Process = string.Empty;
        public Dictionary<string, string> KeyVlauePairs
        {
            get
            {
                return (Dictionary<string, string>)ViewState["KeyVlauePairs"] ?? new Dictionary<string, string>();
            }
            set
            {
                ViewState["KeyVlauePairs"] = value;

            }
        }
        public ulong HumanID
        {
            get
            {
                return ViewState["HumanID"] == null ? 0 : Convert.ToUInt32(ViewState["HumanID"]);
            }
            set
            {
                ViewState["HumanID"] = value;
            }
        }
        public ulong EncounterID
        {
            get
            {

                return ViewState["EncounterID"] == null ? 0 : Convert.ToUInt32(ViewState["EncounterID"]);
            }
            set
            {
                ViewState["EncounterID"] = value;
            }
        }
        public ulong PhysicianID
        {
            get
            {
                return ViewState["PhysicianID"] == null ? 0 : Convert.ToUInt32(ViewState["PhysicianID"]);
            }
            set
            {
                ViewState["PhysicianID"] = value;
            }
        }
        public string ScreenMode
        {
            get
            {
                return ViewState["ScreenMode"] == null ? string.Empty : Convert.ToString(ViewState["ScreenMode"]);
            }
            set
            {
                ViewState["ScreenMode"] = value;
            }
        }
        //Added by Saravanakumar
        public ulong ulMyReferralOrderGroupID
        {
            get
            {
                return ViewState["OrderSubmitId"] == null ? 0 : Convert.ToUInt32(ViewState["OrderSubmitId"]);
            }
            set
            {
                ViewState["OrderSubmitId"] = value;
            }
        }
        public Dictionary<string, string> LookUpPerRequest = new Dictionary<string, string>();
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            KeyVlauePairs = LookUpPerRequest;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LookUpPerRequest = KeyVlauePairs;
            
            if (!IsPostBack)
            {
                try
                {
                    ClientSession.processCheck = false;
                    SecurityServiceUtility objSecurity = new SecurityServiceUtility();
                    objSecurity.ApplyUserPermissions(this.Page);

                    txtReasonForReferral.DName = "pbReasonDrop";

                    rbtnYes.Checked = true;

                    if (Request["HumanID"] != null && Request["HumanID"].Trim() != string.Empty)
                    {
                        HumanID = Convert.ToUInt32(Request["HumanID"]);
                        hdnhumanid.Value = HumanID.ToString();
                    }
                    else
                    {
                        HumanID = ClientSession.HumanId;
                    }
                    if (Request["EncounterID"] != null && Request["EncounterID"].Trim() != string.Empty)
                    {
                        EncounterID = Convert.ToUInt32(Request["EncounterID"]);
                        hdnEncID.Value = EncounterID.ToString();
                    }
                    else
                    {
                        EncounterID = ClientSession.EncounterId;
                    }
                    if (Request["PhysicianID"] != null && Request["PhysicianID"].Trim() != string.Empty)
                    {
                        PhysicianID = Convert.ToUInt32(Request["PhysicianID"]);
                        hdnPhyId.Value = PhysicianID.ToString();
                        ClientSession.PhysicianId = Convert.ToUInt32(Request["PhysicianID"]);//added for Bug ID:27478
                    }
                    else
                    {
                        PhysicianID = ClientSession.PhysicianId;
                    }

                    if (Request["ScreenMode"] != null)
                    {
                        ScreenMode = Convert.ToString(Request["ScreenMode"]);
                    }
                    if (ScreenMode == string.Empty)
                    {
                        btnMoveToNextProcess.Visible = false;
                    }
                    else
                    {
                        btnMoveToNextProcess.Visible = true;
                    }

                    if (Request["OrderSubmitId"] != null)
                    {
                        ulMyReferralOrderGroupID = Convert.ToUInt32(Request["OrderSubmitId"]);
                    }


                    //grdReferralOrders.MasterGridViewInfo.TableHeaderRow.Height += 5;
                    if (ClientSession.UserRole.ToUpper() == "MEDICAL ASSISTANT")
                    {
                        chkMoveToMA.Visible = false;
                    }

                    LoadComboBoxValues();
                    objRefOrdDTO = new ReferralOrderDTO();
                    delUpdtObj = new ReferralOrder();
                    objRefOrdDTO = objReferralOrderManager.LoadReferralOrder(HumanID, EncounterID, PhysicianID);
                    Session["objRefOrdDTO"] = objRefOrdDTO;
                    //Commented by vaishali on 13-01-2016
                    //if (objRefOrdDTO != null)
                    //{
                    //    humanRecord = objRefOrdDTO.objHuman;
                    //}
                    if (dtEncounterDate.Date.ToString("dd-MM-yyyy") == "01-01-0001")
                    {
                        // txtReferralDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                        //Commented as exception occured
                        //DateTime now = Convert.ToDateTime(ClientSession.LocalDate);
                        DateTime now = DateTime.ParseExact(ClientSession.LocalDate, "M'/'d'/'yyyy", null);
                        txtReferralDate.Text = now.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        txtReferralDate.Text = UtilityManager.ConvertToLocal(dtEncounterDate).ToString("dd-MMM-yyyy");
                    }
                    problemList = objRefOrdDTO.MedAdvProbList;
                    LoadAssessmentAndProblemList(objRefOrdDTO.AssessmentList, problemList);
                    FillReferralOrders(objRefOrdDTO);
                    dtpValidTill.MinDate = DateTime.Today.Date;
                    if (ClientSession.UserCurrentProcess.ToUpper() == "MA_REVIEW" || ClientSession.UserCurrentProcess == "PHYSICIAN_VERIFY" && ScreenMode == "Myqueue")// && ClientSession.UserPermission.Trim().ToUpper()=="R")
                    {
                        pnlDiagnosis.Enabled = false;
                        pnlReferredTo.Enabled = false;
                        //pnlReferredDetails.Enabled = false;
                        txtReasonForReferral.Enable = false;
                        txtReasonForReferral.txtDLC.Enabled = false;
                        txtReasonForReferral.pbDropdown.Disabled = true;

                        txtServiceRequested.Enable = false;
                        txtServiceRequested.txtDLC.Enabled = false;
                        txtServiceRequested.pbDropdown.Disabled = true;

                        txtSpecialNeeds.Enable = false;
                        txtSpecialNeeds.txtDLC.Enabled = false;
                        txtSpecialNeeds.pbDropdown.Disabled = true;

                        txtOtherComments.Enable = false;
                        txtOtherComments.txtDLC.Enabled = false;
                        txtOtherComments.pbDropdown.Disabled = true;

                        imgDiagnosis.ImageUrl = "~/Resources/Database Disable.png";
                        btnClearAllRefOrder.Enabled = false;
                        btnPlan.Enabled = false;
                        //btnPrint.Enabled = false;
                        //pnlbtn.Enabled = false;
                    }
                    else
                    {
                        pnlbtn.Enabled = true;
                    }

                    btnAddRefOrder.Enabled = false;
                    hdnUserName.Value = ClientSession.UserName;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Refferal Order Load", "setTimeout(function () { {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();} }, 0);", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Refferal Order", "alert('" + ex.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                }
            }
            else
            {
                objRefOrdDTO = objReferralOrderManager.LoadReferralOrder(HumanID, EncounterID, PhysicianID);
                //btnAddRefOrder.Enabled = true;
                if (rbtnNo.Checked == true)
                {
                    txtAuthorizationNumber.Style.Add("background-color", "rgb(191, 219, 255)");
                    txtAuthorizationNumber.Enabled = false;
                }
                else
                {
                    txtAuthorizationNumber.Style.Add("background-color", "White");
                    txtAuthorizationNumber.Enabled = true;
                }
            }
            txtReasonForReferral.txtDLC.Attributes.Add("onclick", "EnableSaveReferralOrder(event);");
            txtOtherComments.txtDLC.Attributes.Add("onkeypress", "EnableSaveReferralOrder(event);");
            txtReasonForReferral.txtDLC.Attributes.Add("onkeypress", "EnableSaveReferralOrder(event);");
            txtServiceRequested.txtDLC.Attributes.Add("onkeypress", "EnableSaveReferralOrder(event);");
            txtSpecialNeeds.txtDLC.Attributes.Add("onkeypress", "EnableSaveReferralOrder(event);");
            txtOtherComments.txtDLC.Attributes.Add("onchange", "EnableSaveReferralOrder(event);");
            txtReasonForReferral.txtDLC.Attributes.Add("onchange", "EnableSaveReferralOrder(event);");
            txtServiceRequested.txtDLC.Attributes.Add("onchange", "EnableSaveReferralOrder(event);");
            txtSpecialNeeds.txtDLC.Attributes.Add("onchange", "EnableSaveReferralOrder(event);");
            //if (ClientSession.UserRole.ToUpper() == "CODER")
            //{
            //    btnFindPhysician.Enabled = false;
            //    cboFacilityName.Enabled = false;
            //}
        }

        private void LoadComboBoxValues()
        {
            IList<StaticLookup> LookupList = new List<StaticLookup>();
            XDocument xmlSpeciality = XDocument.Load(Server.MapPath(@"ConfigXML\Speciality.xml"));
            cboSpecialty.Items.Add(new RadComboBoxItem("", "0"));
            foreach (XElement elements in xmlSpeciality.Descendants("specialitylist"))
            {
                foreach (XElement SpecialityElement in elements.Elements())
                {
                    string xmlValue = SpecialityElement.Attribute("name").Value;
                    cboSpecialty.Items.Add(new RadComboBoxItem(xmlValue, xmlValue));
                }
            }

            //XDocument xmlDocumentType = XDocument.Load(Server.MapPath(@"ConfigXML\Facility_Library.xml"));
            //cboFacilityName.Items.Add(new RadComboBoxItem("", "0"));
            //RadComboBoxItem lstComboItem = null;
            //foreach (XElement elements in xmlDocumentType.Descendants("FacilityList"))
            //{
            //    foreach (XElement FacilityElement in elements.Elements())
            //    {
            //        string xmlValue = FacilityElement.Attribute("Name").Value;
            //        lstComboItem = new RadComboBoxItem(xmlValue, xmlValue);
            //        lstComboItem.ToolTip = xmlValue;
            //        cboFacilityName.Items.Add(lstComboItem);
            //    }
                
            //}
            IList<FacilityLibrary> facilityList = ApplicationObject.facilityLibraryList;
            cboFacilityName.Items.Add(new RadComboBoxItem("", "0"));
            RadComboBoxItem lstComboItem = null;
            if (facilityList != null && facilityList.Count > 0)
            {
                for (int iIndex = 0; iIndex < facilityList.Count; iIndex++)
                {
                    string FacilityName = facilityList[iIndex].Fac_Name;
                    lstComboItem = new RadComboBoxItem(FacilityName, FacilityName);
                    lstComboItem.ToolTip = FacilityName;
                    cboFacilityName.Items.Add(lstComboItem);
                }

            }
            txtNumberofVisit.Text = "1";
            txtNumberofVisit.Attributes.Add("Tag", "1");
            /*
            string[] FieldName = { "REFERRAL VISIT", "SPECIALTY" };
            LookupList = objStaticLookupManager.getStaticLookupByFieldName(FieldName);
            //IList<StaticLookup> StaticLst = objStaticLookupManager.getStaticLookupByFieldName("REFERRAL VISIT");
            IList<StaticLookup> StaticLst = null;
            StaticLst = LookupList.Where(l => l.Field_Name == "REFERRAL VISIT").ToList<StaticLookup>();
            if (StaticLst != null && StaticLst.Count > 0)
            {
                txtNumberofVisit.Text = StaticLst[0].Value;
                txtNumberofVisit.Attributes.Add("Tag", StaticLst[0].Value);
            }
            IList<FacilityLibrary> facilityList = new List<FacilityLibrary>();
            facilityList = objFacilityManager.GetFacilityList();
            if (facilityList != null)
            {

                cboFacilityName.Items.Add(new RadComboBoxItem());
                for (int j = 0; j < facilityList.Count; j++)
                {
                    tempAddObj = new RadComboBoxItem(facilityList[j].Fac_Name);
                    tempAddObj.ToolTip = facilityList[j].Fac_Name;
                    cboFacilityName.Items.Add(tempAddObj);

                }
            }
            
            //StaticLst = objStaticLookupManager.getStaticLookupByFieldName("SPECIALTY", "Sort_Order");
            StaticLst = LookupList.Where(l => l.Field_Name == "SPECIALTY").ToList<StaticLookup>();
            if (StaticLst != null)
            {
                cboSpecialty.Items.Add(new RadComboBoxItem());
                for (int k = 0; k < StaticLst.Count; k++)
                {
                    tempAddObj = new RadComboBoxItem(StaticLst[k].Value);
                    tempAddObj.ToolTip = StaticLst[k].Value;
                    cboSpecialty.Items.Add(tempAddObj);
                }
            }
            */
        }
        public void LoadAssessmentAndProblemList(IList<Assessment> assList, IList<ProblemList> probList)
        {

            this.chklstAssessment.Items.Clear();
            this.chklstAssessment.AutoPostBack = false;
            dAssessment = new Dictionary<string, ulong>();
            SelectedAssessment = new List<string>();
            Hashtable hAssessment = new Hashtable();
            if (assList != null && assList.Count > 0)
            {
                for (int i = 0; i < assList.Count; i++)
                {
                    if (chklstAssessment.Items.Contains(new ListItem(assList[i].ICD.ToString().ToUpper() + "-" + assList[i].ICD_Description.ToString().ToUpper())) == false)
                    {
                        if (dAssessment.ContainsKey(assList[i].ICD + "-" + assList[i].ICD_Description) == false)
                        {

                            ListItem listItem = new ListItem(assList[i].ICD.ToString() + "-" + assList[i].ICD_Description.ToString());
                            listItem.Attributes.Add("title", assList[i].ICD.ToString() + "-" + assList[i].ICD_Description.ToString());
                            this.chklstAssessment.Items.Add(listItem);
                            chklstAssessment.Attributes.Add("onclick", "onSplInstructionChecked();");

                            dAssessment.Add(assList[i].ICD + "-" + assList[i].ICD_Description, assList[i].Id);
                            SelectedAssessment.Add(assList[i].ICD + "-" + assList[i].ICD_Description);
                            hAssessment.Add(assList[i].ICD, assList[i].Id);
                        }
                    }
                }
                for (int j = 0; j < chklstAssessment.Items.Count; j++)
                {
                    chklstAssessment.Items[j].Selected = false;
                }
            }
            if (probList != null && probList.Count > 0)
            {
                for (int i = 0; i < probList.Count; i++)
                {
                    if (!hAssessment.ContainsKey(probList[i].ICD) && chklstAssessment.Items.Contains(new ListItem(probList[i].ICD.ToString() + "-" + probList[i].Problem_Description.ToString())) == false && probList[i].ICD != string.Empty)//&& probList[i].ICD_Code != string.Empty
                    {

                        ListItem listItem = new ListItem(probList[i].ICD.ToString() + "-" + probList[i].Problem_Description.ToString());
                        listItem.Attributes.Add("title", probList[i].ICD.ToString() + "-" + probList[i].Problem_Description.ToString());
                        this.chklstAssessment.Items.Add(listItem);


                        dAssessment.Add(probList[i].ICD + "-" + probList[i].Problem_Description, probList[i].Id);
                        SelectedAssessment.Add(probList[i].ICD + "-" + probList[i].Problem_Description);
                        hAssessment.Add(probList[i].ICD, probList[i].Id);
                    }

                }
                for (int j = 0; j < chklstAssessment.Items.Count; j++)
                {
                    chklstAssessment.Items[j].Selected = false;
                }
                foreach (ListItem lstitem in chklstAssessment.Items)
                {
                    lstitem.Attributes.Add("onclick", "onCheckListBoxClick(this);");

                }
            }

        }
        public void FillReferralOrders(ReferralOrderDTO objRefOrdDTO)
        {
            if (objRefOrdDTO != null)
            {
                //Commented by vaishali on 13-1-2016 for performance
                //IList<TreatmentPlan> Treatment_Plan = new List<TreatmentPlan>();
                //Treatment_Plan = objRefOrdDTO.Treatment_Plan;
                if (grdReferralOrders.DataSource != null)
                    grdReferralOrders.DataSource = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("Edit", typeof(Bitmap));
                dt.Columns.Add("Del", typeof(Bitmap));
                dt.Columns.Add("ReferringToProvider", typeof(string));//4
                dt.Columns.Add("ReferringToFacility", typeof(string));//5
                dt.Columns.Add("Speciality", typeof(string));//6
                dt.Columns.Add("Diagnosis", typeof(string));//7
                dt.Columns.Add("AuthReq", typeof(string));//8
                dt.Columns.Add("NoOfVisit", typeof(string));//9
                dt.Columns.Add("ReasonForReferral", typeof(string));//10
                dt.Columns.Add("RefDate", typeof(string));//11
                dt.Columns.Add("ServiceRequested", typeof(string));//12
                dt.Columns.Add("SpecialNeeds", typeof(string));//13
                dt.Columns.Add("OtherComments", typeof(string));//14
                dt.Columns.Add("ID", typeof(string));//15

                foreach (ReferralOrder obj in objRefOrdDTO.RefOrdList)
                {
                    string sAssessment = string.Empty;
                    //GridViewDataRowInfo row = this.grdReferralOrders.Rows.AddNew();
                    //row.Cells["Edit"].Value = global::Acurus.Capella.UI.Properties.Resources.edit;
                    //row.Cells["Del"].Value = global::Acurus.Capella.UI.Properties.Resources.close_small_pressed;
                    IList<ReferralOrdersAssessment> refordAssessment = (from obj1 in objRefOrdDTO.RefOrdAssList where obj1.Referral_Order_ID == obj.Id select obj1).ToList<ReferralOrdersAssessment>();
                    for (int i = 0; i < refordAssessment.Count; i++)
                    {
                        if (sAssessment != string.Empty)
                        {
                            sAssessment += ";" + refordAssessment[i].ICD + "-" + refordAssessment[i].Assessment_Description;
                        }
                        else
                            sAssessment = refordAssessment[i].ICD + "-" + refordAssessment[i].Assessment_Description;

                    }
                    DataRow dr = dt.NewRow();
                    dr["Diagnosis"] = sAssessment;
                    dr["Speciality"] = obj.Referral_Specialty;
                    dr["ReferringToProvider"] = obj.To_Physician_Name;
                    dr["ReferringToFacility"] = obj.To_Facility_Name;
                    dr["ServiceRequested"] = obj.Service_Requested;
                    dr["OtherComments"] = obj.Referral_Notes;
                    dr["SpecialNeeds"] = obj.Special_Needs;
                    dr["ReasonForReferral"] = obj.Reason_For_Referral;
                    if (obj.Number_of_Visit != 0)
                        dr["NoOfVisit"] = obj.Number_of_Visit;
                    dr["AuthReq"] = obj.Authorization_Required;
                    dr["RefDate"] = Convert.ToDateTime(obj.Referral_Date).ToString("dd-MMM-yyyy");
                    dr["ID"] = obj.Id;
                    dt.Rows.Add(dr);
                }
                grdReferralOrders.DataSource = dt;                
                grdReferralOrders.DataBind();

            }
        }

        protected void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSelectAll.Checked == true)
            {
                if (chklstAssessment.Items.Count > 0)
                {
                    for (int i = 0; i < chklstAssessment.Items.Count; i++)
                    {
                        chklstAssessment.Items[i].Selected = true;
                    }
                    btnAddRefOrder.Enabled = true;
                }
            }
            else
            {
                if (chklstAssessment.Items.Count > 0)
                {
                    for (int i = 0; i < chklstAssessment.Items.Count; i++)
                    {
                        chklstAssessment.Items[i].Selected = false;
                    }
                }
            }
        }

        protected void btnAddRefOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string strtime = hdnLocalTime.Value.ToString().Split('G').ElementAt(0).ToString();
                //utc = Convert.ToDateTime(strtime);
                if (!chklstAssessment.Items.Cast<ListItem>().Any(a => a.Selected == true))
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "top.window.document.getElementById('ctl00_Loading').style.display = 'none';Order_SaveUnsuccessful();DisplayErrorMessage('720006', '','');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}Order_SaveUnsuccessful();DisplayErrorMessage('720006', '',''); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    //ApplicationObject.erroHandler.DisplayErrorMessage("720006", this.Text);
                    btnAddRefOrder.Enabled = true;
                    //bSave = true;
                    return;
                }
                bool bValid = false;
                string sReplace = string.Empty;
                sReplace = msktxtFacilityPhoneNumber.Text.Replace(" ", "");
                if (sReplace.Length < 13)
                {
                    bValid = false;
                }
                else
                {
                    bValid = true;
                }

                if (btnAddRefOrder.Text == "Add")
                {
                    AddReferralOrders();
                    //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "Autosave();", true);
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "AddedSuccessfully", "Autosave(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    btnAddRefOrder.Enabled = false;

                }
                else
                {
                    UpdateReferralOrders();
                    //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "Autosave();", true);
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "UpdatedSuccessfully", "Autosave(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    btnAddRefOrder.Enabled = false;

                }
            }
            catch (Exception RefExc)
            {

                throw RefExc;
            }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + RefExc.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
            //divLoading.Style.Add("display", "none");
            //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "top.window.document.getElementById('ctl00_Loading').style.display = 'none';", true);
        }
        public Boolean PhNoValid(string sPhno, string sReplace)
        {
            sReplace = sPhno.Replace(" ", "");

            if (sReplace.Length < 13)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void UpdateReferralOrders()
        {
            delUpdtObj = (from ord in objRefOrdDTO.RefOrdList where ord.Id == Convert.ToUInt32(LookUpPerRequest["delUpdtId"]) select ord).ToList<ReferralOrder>()[0];
            ReferralOrder objRefOrder = delUpdtObj;
            IList<ReferralOrder> refOrdUpdtList = new List<ReferralOrder>();
            IList<ReferralOrdersAssessment> ordAssessmentlist = (from obj in objRefOrdDTO.RefOrdAssList where obj.Referral_Order_ID == delUpdtObj.Id select obj).ToList<ReferralOrdersAssessment>();
            IList<ReferralOrdersAssessment> delOrdAssList = new List<ReferralOrdersAssessment>();
            IList<ReferralOrdersAssessment> savOrdAssList = new List<ReferralOrdersAssessment>();
            IList<ulong> assIDList = new List<ulong>();
            string sOldText = ReferralText(objRefOrder.To_Physician_Name, objRefOrder.Referral_Specialty, objRefOrder.Reason_For_Referral, objRefOrder.Referral_Date.ToString("dd-MMM-yyyy"));
            string sNewText = ReferralText(txtProviderName.Text, cboSpecialty.Text, txtReasonForReferral.txtDLC.Text.Replace("\r\n", "\n"), (Convert.ToDateTime(txtReferralDate.Text)).ToString("dd-MMM-yyyy"));
            objRefOrder.Encounter_ID = EncounterID;

            objRefOrder.From_Physician_ID = PhysicianID;
            objRefOrder.To_Physician_Name = txtProviderName.Text;
            if (txtAuthorizationNumber.Text != string.Empty)
            {
                objRefOrder.Authorization_Number = txtAuthorizationNumber.Text;
            }
            if (rbtnYes.Checked == true)
            {
                objRefOrder.Authorization_Required = "Y";
            }
            else
            {
                objRefOrder.Authorization_Required = "N";
                objRefOrder.Authorization_Number = "";
            }
            if (chkMoveToMA.Checked)
            {
                objRefOrder.Move_To_MA = "Y";
            }
            else
            {
                objRefOrder.Move_To_MA = "N";
            }
            if (dtpValidTill.SelectedDate != null)
            {
                if (dtpValidTill.SelectedDate.Value != null)
                {
                    objRefOrder.Valid_Till = dtpValidTill.SelectedDate.Value;
                }
            }
            else
            {
                objRefOrder.Valid_Till = System.DateTime.MinValue;
            }
            objRefOrder.To_Facility_Name = cboFacilityName.Text;
            objRefOrder.Referral_Specialty = cboSpecialty.Text;
            objRefOrder.Referral_Date = Convert.ToDateTime(txtReferralDate.Text);
            objRefOrder.Referral_Notes = txtOtherComments.txtDLC.Text;
            objRefOrder.Special_Needs = txtSpecialNeeds.txtDLC.Text;
            objRefOrder.Service_Requested = txtServiceRequested.txtDLC.Text;
            objRefOrder.To_Facility_Street_Address = txtReferredToFacilityAddress.Text;
            objRefOrder.To_Facility_City = txtReferredToFacilityCity.Text;
            objRefOrder.To_Facility_State = txtReferredToFacilityState.Text;
            objRefOrder.Modified_By = ClientSession.UserName;
            //objRefOrder.Modified_Date_And_Time = utc;
            objRefOrder.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
            objRefOrder.Reason_For_Referral = txtReasonForReferral.txtDLC.Text.Replace("\r\n", "\n");
            objRefOrder.From_Facility = ClientSession.FacilityName;
            if (txtNumberofVisit.Text != string.Empty)
                objRefOrder.Number_of_Visit = Convert.ToInt32(txtNumberofVisit.Text);
            else
                objRefOrder.Number_of_Visit = 0;
            if (msktxtFacilityFaxNumber.Text != "(   )    -")
            {
                string[] Split = Convert.ToString(msktxtFacilityFaxNumber.Text.Trim()).Split(new char[] { '(', ')', '-' });
                string FaxNumber = string.Empty;
                for (int i = 0; i < Split.Length; i++)
                {
                    //if (i != 0)
                        FaxNumber = Split[i].Trim();
                }
                objRefOrder.To_Facility_Fax_Number = FaxNumber;
            }
            else
            {
                objRefOrder.To_Facility_Fax_Number = string.Empty;
            }
            if (msktxtFacilityPhoneNumber.Text != "(   )    -")
            {
                string[] Split = Convert.ToString(msktxtFacilityPhoneNumber.Text.Trim()).Split(new char[] { '(', ')', '-' });
                string homephno = string.Empty;
                for (int i = 0; i < Split.Length; i++)
                {
                   // if (i != 0)
                        homephno = Split[i].Trim();
                }
                objRefOrder.To_Facility_Phone_Number = homephno;
            }
            else
            {
                objRefOrder.To_Facility_Phone_Number = string.Empty;
            }
            objRefOrder.To_Facility_State = txtReferredToFacilityState.Text;
            if (msktxtFacilityZipCode.Text != "     -")
            {
                if (msktxtFacilityZipCode.Text.Length == 6 && msktxtFacilityZipCode.Text.Length < 10)
                {
                    string[] Split = Convert.ToString(msktxtFacilityZipCode.Text).Split('-');
                    if (Split.Length == 2 && Split[1] == string.Empty)
                    {
                        objRefOrder.To_Facility_Zip = Split[0].ToString();
                    }
                }
                else
                {
                    string[] Split = Convert.ToString(msktxtFacilityZipCode.Text).Split('-');
                    string ZipCode = string.Empty;
                    if (Split.Length == 2)
                    {
                        ZipCode = Split[0] + Split[1];
                    }
                    objRefOrder.To_Facility_Zip = msktxtFacilityZipCode.Text;
                }
            }
            else
            {
                objRefOrder.To_Facility_Zip = string.Empty;
            }
            if (LookUpPerRequest.ContainsKey("delUpdtId"))
                objRefOrder.Id = Convert.ToUInt32(LookUpPerRequest["delUpdtId"]);
            refOrdUpdtList.Add(objRefOrder);
            IList<ListItem> CheckedItems = chklstAssessment.Items.Cast<ListItem>().Where(a => a.Selected == true).ToList<ListItem>();
            if (CheckedItems != null && CheckedItems.Count > 0)
            {
                dAssessment = new Dictionary<string, ulong>();
                foreach (ReferralOrdersAssessment obj in ordAssessmentlist)
                {
                    dAssessment.Add(obj.ICD + "-" + obj.Assessment_Description, obj.Assessment_ID);
                }

                for (int i = 0; i < chklstAssessment.Items.Count; i++)
                {
                    if (CheckedItems.Contains(chklstAssessment.Items[i]))
                    {
                        if (dAssessment.ContainsKey(chklstAssessment.Items[i].ToString()))
                            continue;
                        else
                        {

                            ReferralOrdersAssessment objOrdAss = CreateOrderAssObj(chklstAssessment.Items[i].ToString(), dAssessment.ContainsKey(chklstAssessment.Items[i].ToString()) ? dAssessment[chklstAssessment.Items[i].ToString()] : 0);

                            if (LookUpPerRequest.ContainsKey("delUpdtId"))
                            {
                                objOrdAss.Referral_Order_ID = Convert.ToUInt32(LookUpPerRequest["delUpdtId"]);
                            }
                            savOrdAssList.Add(objOrdAss);

                        }
                    }
                    else
                    {
                        if (dAssessment.ContainsKey(chklstAssessment.Items[i].ToString()))
                        {
                            ReferralOrdersAssessment obj = (from ordAss in ordAssessmentlist where ordAss.ICD == chklstAssessment.Items[i].ToString().Split('-')[0] select ordAss).ToList<ReferralOrdersAssessment>()[0];
                            delOrdAssList.Add(obj);
                        }
                        else
                            continue;
                    }
                }
            }
            else
            {
                if (ordAssessmentlist.Count > 0)
                    delOrdAssList = ordAssessmentlist;
            }
            objRefOrdDTO = new ReferralOrderDTO();
            objRefOrdDTO = objReferralOrderManager.UpdateToReferralOrders(refOrdUpdtList.ToArray<ReferralOrder>(), savOrdAssList.ToArray<ReferralOrdersAssessment>(), delOrdAssList.ToArray<ReferralOrdersAssessment>(), EncounterID, string.Empty, sOldText, sNewText,HumanID);
            Session["objRefOrdDTO"]=objRefOrdDTO;
            ClearText();
            FillReferralOrders(objRefOrdDTO);
            //ApplicationObject.erroHandler.DisplayErrorMessage("720002", this.Text);
            if (ClientSession.UserCurrentProcess.ToUpper() == "MA_REVIEW" || ClientSession.UserCurrentProcess == "PHYSICIAN_VERIFY" && ScreenMode == "Myqueue")
            {
                pnlDiagnosis.Enabled = false;
                pnlReferredTo.Enabled = false;
                //pnlReferredDetails.Enabled = false;
                txtReasonForReferral.Enable = false;
                txtReasonForReferral.txtDLC.Enabled = false;
                txtReasonForReferral.pbDropdown.Disabled = true;             

                txtServiceRequested.Enable = false;
                txtServiceRequested.txtDLC.Enabled = false;
                txtServiceRequested.pbDropdown.Disabled = true;

                txtSpecialNeeds.Enable = false;
                txtSpecialNeeds.txtDLC.Enabled = false;
                txtSpecialNeeds.pbDropdown.Disabled = true;

                txtOtherComments.Enable = false;
                txtOtherComments.txtDLC.Enabled = false;
                txtOtherComments.pbDropdown.Disabled = true;

                txtSpecialNeeds.Enable = false;
                txtOtherComments.Enable = false;
                imgDiagnosis.ImageUrl = "~/Resources/Database Disable.png";
                btnClearAllRefOrder.Enabled = false;
                btnPlan.Enabled = false;
                //btnPrint.Enabled = false;
                //pnlbtn.Enabled = false; ;
            }
            //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "UpdatedSuccessfully", "Autosave();", true);
        }
        public void AddReferralOrders()
        {
            IList<ReferralOrdersAssessment> refOrdAssSaveList = null;
            ReferralOrder objRefOrder = new ReferralOrder();
            IList<ReferralOrder> refOrdSaveList = new List<ReferralOrder>();
            string sLocalTime = string.Empty;
            refOrdAssSaveList = new List<ReferralOrdersAssessment>();
            objRefOrder.Encounter_ID = EncounterID;
            objRefOrder.Human_ID = HumanID;
            objRefOrder.From_Physician_ID = PhysicianID;
            objRefOrder.Referral_Notes = txtOtherComments.txtDLC.Text;
            objRefOrder.Service_Requested = txtServiceRequested.txtDLC.Text;
            objRefOrder.Special_Needs = txtSpecialNeeds.txtDLC.Text;
            objRefOrder.Reason_For_Referral = txtReasonForReferral.txtDLC.Text.Replace("\r\n", "\n");
            objRefOrder.Referral_Date = Convert.ToDateTime(txtReferralDate.Text);
            if (txtAuthorizationNumber.Text != string.Empty)
            {
                objRefOrder.Authorization_Number = txtAuthorizationNumber.Text;
            }
            if (txtNumberofVisit.Text != string.Empty)
                objRefOrder.Number_of_Visit = Convert.ToInt32(txtNumberofVisit.Text);
            else
                objRefOrder.Number_of_Visit = 0;
            objRefOrder.Created_By = ClientSession.UserName;
            //objRefOrder.Created_Date_And_Time = utc;
            objRefOrder.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
            sLocalTime = UtilityManager.ConvertToUniversal(objRefOrder.Created_Date_And_Time).ToString("yyyy-MM-dd hh:mm:ss tt");
            objRefOrder.Referral_Specialty = cboSpecialty.Text;
            objRefOrder.To_Physician_Name = txtProviderName.Text;
            objRefOrder.To_Facility_Name = cboFacilityName.Text;
            objRefOrder.To_Facility_Street_Address = txtReferredToFacilityAddress.Text;
            objRefOrder.To_Facility_City = txtReferredToFacilityCity.Text;
            objRefOrder.From_Facility = ClientSession.FacilityName;
            if (dtpValidTill.SelectedDate != null)
            {
                if (dtpValidTill.SelectedDate.Value != null)
                {
                    objRefOrder.Valid_Till = dtpValidTill.SelectedDate.Value;
                }
            }
            
            if (chkMoveToMA.Checked)
            {
                objRefOrder.Move_To_MA = "Y";
            }
            else
            {
                objRefOrder.Move_To_MA = "N";
            }
            if (msktxtFacilityFaxNumber.Text != "(   )    -")
            {
                string[] Split = Convert.ToString(msktxtFacilityFaxNumber.Text.Trim()).Split(new char[] { '(', ')', '-' });
                string FaxNumber = string.Empty;
                for (int i = 0; i < Split.Length; i++)
                {
                   // if (i != 0)
                        FaxNumber = Split[i].Trim();
                }
                objRefOrder.To_Facility_Fax_Number = FaxNumber;
            }
            else
            {
                objRefOrder.To_Facility_Fax_Number = string.Empty;
            }
            if (msktxtFacilityPhoneNumber.Text != "(   )    -")
            {
                string[] Split = Convert.ToString(msktxtFacilityPhoneNumber.Text.Trim()).Split(new char[] { '(', ')', '-' });
                string homephno = string.Empty;
                for (int i = 0; i < Split.Length; i++)
                {
                  //  if (i != 0)
                        homephno = Split[i].Trim();
                }
                objRefOrder.To_Facility_Phone_Number = homephno;
            }
            else
            {
                objRefOrder.To_Facility_Phone_Number = string.Empty;
            }
            objRefOrder.To_Facility_State = txtReferredToFacilityState.Text;
            if (msktxtFacilityZipCode.Text != "     -")
            {
                if (msktxtFacilityZipCode.Text.Length == 6 && msktxtFacilityZipCode.Text.Length < 10)
                {
                    string[] Split = Convert.ToString(msktxtFacilityZipCode.Text).Split('-');
                    if (Split.Length == 2 && Split[1] == string.Empty)
                    {
                        objRefOrder.To_Facility_Zip = Split[0].ToString();
                    }
                }
                else
                {
                    string[] Split = Convert.ToString(msktxtFacilityZipCode.Text).Split('-');
                    string ZipCode = string.Empty;
                    if (Split.Length < 0)
                    {
                        ZipCode = Split[0] + Split[1];
                    }
                    objRefOrder.To_Facility_Zip = msktxtFacilityZipCode.Text;
                }
            }
            //if (msktxtFacilityZipCode.Text != "     -" && (msktxtFacilityZipCode.Text.Replace(" ", "").Length != 6 && msktxtFacilityZipCode.Text.Replace(" ", "").Length != 10))
            //{
            //    //ApplicationObject.erroHandler.DisplayErrorMessage("420050", this.Text);
            //    msktxtFacilityZipCode.Focus();
            //    return;
            //}

            if (chklstAssessment.Items.Count > 0)
            {
                for (int j = 0; j < chklstAssessment.Items.Count; j++)
                {
                    if (chklstAssessment.Items[j].Selected)
                    {
                        ReferralOrdersAssessment objOrdAss = CreateOrderAssObj(chklstAssessment.Items[j].ToString(), dAssessment.ContainsKey(chklstAssessment.Items[j].ToString()) ? dAssessment[chklstAssessment.Items[j].ToString()] : 0);
                        refOrdAssSaveList.Add(objOrdAss);
                    }
                }
            }
            if (rbtnYes.Checked == true)
                objRefOrder.Authorization_Required = "Y";
            else
                objRefOrder.Authorization_Required = "N";

            refOrdSaveList.Add(objRefOrder);
            string sFinalText = ReferralText(txtProviderName.Text, cboSpecialty.Text, txtReasonForReferral.txtDLC.Text.Replace("\r\n", "\n"), (Convert.ToDateTime(txtReferralDate.Text)).ToString("dd-MMM-yyyy"));
            objRefOrdDTO = objReferralOrderManager.InsertToReferralOrders(refOrdSaveList.ToArray<ReferralOrder>(), refOrdAssSaveList.ToArray<ReferralOrdersAssessment>(), EncounterID, string.Empty, sFinalText,HumanID,sLocalTime);
            Session["objRefOrdDTO"]=objRefOrdDTO;
            ClearText();
            FillReferralOrders(objRefOrdDTO);
            //divLoading.Style.Add("display", "none");
            //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "AddedSuccessfully", "Autosave();", true);
            //ApplicationObject.erroHandler.DisplayErrorMessage("720001", this.Text);
        }
        private string ReferralText(string sProviderName, string sSpecialityName, string sReferralReason, string sReferralDate)
        {
            string sFinalText = string.Empty;
            IList<StaticLookup> StaticLst = objStaticLookupManager.getStaticLookupByFieldName("REFERRAL ORDER TEXT");
            if (StaticLst != null && StaticLst.Count > 0)
            {
                string sReferralText = string.Empty;
                sReferralText = StaticLst[0].Value;
                if (sProviderName != string.Empty)
                {
                    sFinalText = sReferralText.Replace("[Speciality_Name]", sProviderName + "," + sSpecialityName).Replace("[Referral_Reason]", sReferralReason).Replace("[Referral_Date]", sReferralDate);
                }
                else
                {
                    sFinalText = sReferralText.Replace("[Speciality_Name]", sSpecialityName).Replace("[Referral_Reason]", sReferralReason).Replace("[Referral_Date]", sReferralDate);
                }

            }
            return sFinalText;
        }
        public void ClearText()
        {
            chklstAssessment.ClearSelection();
            ChkSelectAll.Checked = false;
            txtServiceRequested.txtDLC.Text = string.Empty;
            txtOtherComments.txtDLC.Text = "";
            txtSpecialNeeds.txtDLC.Text = "";
            msktxtFacilityFaxNumber.Text = "";
            txtNumberofVisit.Text = txtNumberofVisit.Attributes["Tag"].ToString();
            txtReferredToFacilityAddress.Text = "";
            cboFacilityName.Text = "";
            txtProviderName.Text = "";
            txtReasonForReferral.txtDLC.Text = "";
            if (dtEncounterDate.Date.ToString("dd-MM-yyyy") == "01-01-0001")
            {
                // txtReferralDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                //commented as exception occured
                //DateTime now = Convert.ToDateTime(ClientSession.LocalDate);
                DateTime now = DateTime.ParseExact(ClientSession.LocalDate, "M'/'d'/'yyyy", null);
                txtReferralDate.Text = now.ToString("dd-MMM-yyyy");


            }
            else
            {
                txtReferralDate.Text = UtilityManager.ConvertToLocal(dtEncounterDate).ToString("dd-MMM-yyyy");
            }
            dtpValidTill.SelectedDate =null ;
            cboSpecialty.Text = "";
            chkMoveToMA.Checked = false;
            rbtnNo.Checked = false;
            rbtnYes.Checked = true;
            //rbtnYes.Checked = false; for bug-id 28819
            // chkAuthorizationRequired.Checked = false;
            msktxtFacilityPhoneNumber.Text = "";
            txtReferredToFacilityCity.Text = "";
            txtReferredToFacilityState.Text = "";
            msktxtFacilityZipCode.Text = "";
            cboFacilityName.SelectedIndex = 0;
            cboSpecialty.SelectedIndex = 0;
            txtAuthorizationNumber.Text = "";
            //btnAddRefOrder.Text = "Add";
            btnAddRefOrder.Text = "Add";
            btnAddRefOrder.AccessKey = "a";
            System.Web.UI.HtmlControls.HtmlGenericControl text1 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnAddRefOrder.FindControl("SpanAdd");
            text1.InnerText = "A";
            System.Web.UI.HtmlControls.HtmlGenericControl text2 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnAddRefOrder.FindControl("SpanAdditionalword");
            text2.InnerText = "dd";
            btnAddRefOrder.Enabled = false;
            //btnClearAllRefOrder.Text = "Clear All";
            btnClearAllRefOrder.Text = "Clear All";
            System.Web.UI.HtmlControls.HtmlGenericControl text3 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnClearAllRefOrder.FindControl("SpanClear");
            text3.InnerText = "C";
            System.Web.UI.HtmlControls.HtmlGenericControl text4 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnClearAllRefOrder.FindControl("SpanClearAdditional");
            text4.InnerText = "lear All";
            
            //lstServiceRequested.Items.Text = "";
            //lstSpecialNeeds.Items.Text="";
            if ((Process.ToUpper() == "MA_REVIEW") || (Process.ToUpper() == "PHYSICIAN_VERIFY"))
            {
                //gbDiagnosis.Enabled = false;
                //gbReferredDetails.Enabled = false;
                //gbReferredTo.Enabled = false;
                //pbOtherCommentsDrop.Image = global::Acurus.Capella.UI.Properties.Resources.plus_new_disabled;
                //pbOtherCommentsClear.Image = global::Acurus.Capella.UI.Properties.Resources.close_disabled;
                //pbOtherCommentsLibrary.Image = global::Acurus.Capella.UI.Properties.Resources.Database_Disable;
                //pbReasonClear.Image = global::Acurus.Capella.UI.Properties.Resources.close_disabled;
                //pbReasonDrop.Image = global::Acurus.Capella.UI.Properties.Resources.plus_new_disabled;
                //pbReasonLibrary.Image = global::Acurus.Capella.UI.Properties.Resources.Database_Disable;
                //pbSeriviceRequestedDrop.Image = global::Acurus.Capella.UI.Properties.Resources.plus_new_disabled;
                //pbServiceClear.Image = global::Acurus.Capella.UI.Properties.Resources.close_disabled;
                //pbServiceRequestedLibrary.Image = global::Acurus.Capella.UI.Properties.Resources.Database_Disable;
                //pbSpecialNeedsDrop.Image = global::Acurus.Capella.UI.Properties.Resources.plus_new_disabled;
                //pbSpecialClear.Image = global::Acurus.Capella.UI.Properties.Resources.close_disabled;
                //pbSpecialNeedsLibrary.Image = global::Acurus.Capella.UI.Properties.Resources.Database_Disable;
                //pbICDLibrary.Image = global::Acurus.Capella.UI.Properties.Resources.Database_Disable;

            }
            //localchk = false;

        }
        private ReferralOrdersAssessment CreateOrderAssObj(string ICD, ulong AssID)
        {
            ReferralOrdersAssessment objOrdAss = new ReferralOrdersAssessment();
            string assText = ICD;
            string[] split = assText.Split('-');
            if (split.Length > 0)
            {
                objOrdAss.Assessment_ID = AssID;
                objOrdAss.ICD = split[0];
                for (int i = 1; i < split.Count(); i++)
                {
                    if (objOrdAss.Assessment_Description == string.Empty)
                        objOrdAss.Assessment_Description = split[i];
                    else
                        objOrdAss.Assessment_Description += "-" + split[i];
                }
                objOrdAss.Encounter_ID = EncounterID;
                objOrdAss.Human_ID = HumanID;//BugID:50206
                objOrdAss.Created_By = ClientSession.UserName;
                objOrdAss.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
            }
            return objOrdAss;

        }
         protected void btnDelete_Click(object sender, EventArgs e)
        {
            objRefOrdDTO = new ReferralOrderDTO();
            if (Session["objRefOrdDTO"] != null) { objRefOrdDTO = (ReferralOrderDTO)Session["objRefOrdDTO"]; }

            GridDataItem drv1 = grdReferralOrders.MasterTableView.Items[Convert.ToInt32(hdnRowIndex.Value)];
            string sdelupdtid = drv1["ID"].Text;
          
            if (!LookUpPerRequest.ContainsKey("delUpdtId"))
            {
                LookUpPerRequest.Add("delUpdtId", sdelupdtid);
            }
            //LookUpPerRequest.Add("delUpdtId", drv["ID"].ToString());
            else
            {
                LookUpPerRequest["delUpdtId"] = sdelupdtid;
                //LookUpPerRequest["delUpdtId"] = drv["ID"].ToString();
            }
            ulong delUpdtId = 0;
            if (LookUpPerRequest.ContainsKey("delUpdtId"))
                delUpdtId = Convert.ToUInt32(LookUpPerRequest["delUpdtId"]);
            delUpdtObj = (from ord in objRefOrdDTO.RefOrdList where ord.Id == delUpdtId select ord).ToList<ReferralOrder>()[0];
           
                //int del = ApplicationObject.erroHandler.DisplayErrorMessage("720005", this.Text);
                //if (del == 1)
                //{
                GridDataItem drv = grdReferralOrders.MasterTableView.Items[Convert.ToInt32(hdnRowIndex.Value)];
                ClearText();
                IList<ReferralOrdersAssessment> ordAssessmentlist = (from obj in objRefOrdDTO.RefOrdAssList where obj.Referral_Order_ID == Convert.ToUInt32(LookUpPerRequest["delUpdtId"]) select obj).ToList<ReferralOrdersAssessment>();
                if (ordAssessmentlist != null)
                {
                    for (int i = 0; i < ordAssessmentlist.Count; i++)
                    {
                        ordAssessmentlist[i].Modified_By = ClientSession.UserName;
                    }
                }
                delUpdtObj.Modified_By = ClientSession.UserName;
                string sOldText = ReferralText(delUpdtObj.To_Physician_Name, delUpdtObj.Referral_Specialty, delUpdtObj.Reason_For_Referral, delUpdtObj.Referral_Date.ToString("dd-MMM-yyyy"));
                objRefOrdDTO = objReferralOrderManager.DeleteReferralorders(delUpdtObj, ordAssessmentlist.ToArray<ReferralOrdersAssessment>(), EncounterID, string.Empty, sOldText, HumanID);
                FillReferralOrders(objRefOrdDTO);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Delete referral Order", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
           
           
        }
        protected void grdReferralOrders_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                objRefOrdDTO = new ReferralOrderDTO();
                if (Session["objRefOrdDTO"] != null) { objRefOrdDTO = (ReferralOrderDTO)Session["objRefOrdDTO"]; }

                if (e.CommandName == "Sort")
                {
                    FillReferralOrders(objRefOrdDTO);
                }
                else
                {
                    if (e.CommandArgument != string.Empty)
                    {
                        GridDataItem drv1 = grdReferralOrders.MasterTableView.Items[Convert.ToInt32(e.CommandArgument)];
                        string sdelupdtid = drv1["ID"].Text;
                        TableCellCollection CurrentCell = ((GridDataItem)e.Item).Cells;
                        if (!LookUpPerRequest.ContainsKey("delUpdtId"))
                        {
                            LookUpPerRequest.Add("delUpdtId", sdelupdtid);
                        }
                        //LookUpPerRequest.Add("delUpdtId", drv["ID"].ToString());
                        else
                        {
                            LookUpPerRequest["delUpdtId"] = sdelupdtid;
                            //LookUpPerRequest["delUpdtId"] = drv["ID"].ToString();
                        }
                        ulong delUpdtId = 0;
                        if (LookUpPerRequest.ContainsKey("delUpdtId"))
                            delUpdtId = Convert.ToUInt32(LookUpPerRequest["delUpdtId"]);
                        delUpdtObj = (from ord in objRefOrdDTO.RefOrdList where ord.Id == delUpdtId select ord).ToList<ReferralOrder>()[0];
                        if (e.CommandName == "Del")
                        {
                            //int del = ApplicationObject.erroHandler.DisplayErrorMessage("720005", this.Text);
                            //if (del == 1)
                            //{
                            GridDataItem drv = grdReferralOrders.MasterTableView.Items[Convert.ToInt32(e.CommandArgument)];
                            ClearText();
                            IList<ReferralOrdersAssessment> ordAssessmentlist = (from obj in objRefOrdDTO.RefOrdAssList where obj.Referral_Order_ID == Convert.ToUInt32(LookUpPerRequest["delUpdtId"]) select obj).ToList<ReferralOrdersAssessment>();
                            if (ordAssessmentlist != null)
                            {
                                for (int i = 0; i < ordAssessmentlist.Count; i++)
                                {
                                    ordAssessmentlist[i].Modified_By = ClientSession.UserName;
                                }
                            }
                            delUpdtObj.Modified_By = ClientSession.UserName;
                            string sOldText = ReferralText(delUpdtObj.To_Physician_Name, delUpdtObj.Referral_Specialty, delUpdtObj.Reason_For_Referral, delUpdtObj.Referral_Date.ToString("dd-MMM-yyyy"));
                            objRefOrdDTO = objReferralOrderManager.DeleteReferralorders(delUpdtObj, ordAssessmentlist.ToArray<ReferralOrdersAssessment>(), EncounterID, string.Empty, sOldText, HumanID);
                            FillReferralOrders(objRefOrdDTO);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                            //}
                        }
                        else if (e.CommandName == "EditC")
                        {
                            //ClearText();
                            //if ((Process.ToUpper() == "MA_REVIEW") || (Process.ToUpper() == "PHYSICIAN_VERIFY"))
                            //{

                            //}
                            //chklstAssessment.ClearSelection();

                            //IList<ReferralOrdersAssessment> list1 = (from obj in objRefOrdDTO.RefOrdAssList where obj.Referral_Order_ID == delUpdtObj.Id select obj).ToList<ReferralOrdersAssessment>();
                            //foreach (ReferralOrdersAssessment ob in list1)
                            //{
                            //    ListItem itemsToBeChecked = new ListItem();

                            //    itemsToBeChecked = chklstAssessment.Items.FindByText(ob.ICD + "-" + ob.Assessment_Description);
                            //    if(itemsToBeChecked!=null)
                            //    itemsToBeChecked.Selected = true;
                            //    else
                            //    {
                            //        chklstAssessment.Items.Add(ob.ICD + "-" + ob.Assessment_Description);
                            //        itemsToBeChecked = chklstAssessment.Items.FindByText(ob.ICD + "-" + ob.Assessment_Description);
                            //    }
                            //}

                            //PhysicianSpecialtyManager objPhysicianSpecialtyManager = new PhysicianSpecialtyManager();
                            //PhysicianManager objPhysicianManager = new PhysicianManager();
                            //PhysicianLibrary objPhysician = new PhysicianLibrary();
                            //objPhysician = objPhysicianManager.GetphysiciannameByPhyID(delUpdtObj.From_Physician_ID)[0];
                            //IList<PhysicianSpecialty> PhysplList = objPhysicianSpecialtyManager.GetAllPhysicianSpecialty();
                            //txtSpecialNeeds.txtDLC.Text = CurrentCell[13].Text;
                            //txtServiceRequested.txtDLC.Text = CurrentCell[12].Text;
                            //if (CurrentCell[8].Text == "Y")
                            //    chkAuthorizationRequired.Checked = true;
                            //else
                            //    chkAuthorizationRequired.Checked = false;
                            //if (delUpdtObj.Move_To_MA == "Y")
                            //    chkMoveToMA.Checked = true;
                            //else
                            //    chkMoveToMA.Checked = false;
                            //txtReferralDate.Text = (Convert.ToDateTime(CurrentCell[11].Text)).ToString("dd-MMM-yyyy");
                            //txtNumberofVisit.Text = CurrentCell[9].Text;
                            //txtReasonForReferral.txtDLC.Text = delUpdtObj.Reason_For_Referral;
                            //if (cboFacilityName.FindItemByText(CurrentCell[5].Text)!=null)
                            //cboFacilityName.SelectedIndex = cboFacilityName.FindItemByText(CurrentCell[5].Text).Index;
                            //txtReferredToFacilityAddress.Text = delUpdtObj.To_Facility_Street_Address;//.Split('|');                  
                            //txtReferredToFacilityAddress.Text = delUpdtObj.To_Facility_Street_Address;
                            //txtReferredToFacilityCity.Text = delUpdtObj.To_Facility_City;
                            //txtReferredToFacilityState.Text = delUpdtObj.To_Facility_State;
                            //msktxtFacilityZipCode.Text = delUpdtObj.To_Facility_Zip;
                            //msktxtFacilityPhoneNumber.Text = delUpdtObj.To_Facility_Phone_Number;
                            //msktxtFacilityFaxNumber.Text = delUpdtObj.To_Facility_Fax_Number;
                            //txtProviderName.Text = CurrentCell[4].Text;
                            //cboSpecialty.SelectedIndex = cboSpecialty.FindItemIndexByText(CurrentCell[6].Text);
                            //txtOtherComments.txtDLC.Text = delUpdtObj.Referral_Notes;
                            //btnAddRefOrder.Text = "Update";
                            //btnClearAllRefOrder.Text = "Cancel";
                            //btnAddRefOrder.Enabled=true;

                            // GridDataItem drv = grdReferralOrders.MasterTableView.Items[Convert.ToInt32(e.Item.DataSetIndex)];
                            GridDataItem drv = grdReferralOrders.MasterTableView.Items[Convert.ToInt32(e.CommandArgument)];
                            ClearText();
                            if ((Process.ToUpper() == "MA_REVIEW") || (Process.ToUpper() == "PHYSICIAN_VERIFY"))
                            {

                            }
                            chklstAssessment.ClearSelection();

                            IList<ReferralOrdersAssessment> list1 = (from obj in objRefOrdDTO.RefOrdAssList where obj.Referral_Order_ID == Convert.ToUInt32(LookUpPerRequest["delUpdtId"]) select obj).ToList<ReferralOrdersAssessment>();
                            foreach (ReferralOrdersAssessment ob in list1)
                            {
                                ListItem itemsToBeChecked = new ListItem();

                                itemsToBeChecked = chklstAssessment.Items.FindByText(ob.ICD + "-" + ob.Assessment_Description);
                                if (itemsToBeChecked != null)
                                    itemsToBeChecked.Selected = true;
                                else
                                {
                                    ListItem listItem = new ListItem(ob.ICD + "-" + ob.Assessment_Description);
                                    listItem.Attributes.Add("title", ob.ICD + "-" + ob.Assessment_Description);
                                    this.chklstAssessment.Items.Add(listItem);
                                    itemsToBeChecked = chklstAssessment.Items.FindByText(ob.ICD + "-" + ob.Assessment_Description);
                                    itemsToBeChecked.Selected = true;
                                }
                            }

                            PhysicianSpecialtyManager objPhysicianSpecialtyManager = new PhysicianSpecialtyManager();
                            PhysicianManager objPhysicianManager = new PhysicianManager();
                            PhysicianLibrary objPhysician = new PhysicianLibrary();
                            IList<PhysicianLibrary> lstPhylib = new List<PhysicianLibrary>();
                            lstPhylib = objPhysicianManager.GetphysiciannameByPhyID(delUpdtObj.From_Physician_ID);
                            if (lstPhylib != null && lstPhylib.Count > 0)
                                objPhysician = lstPhylib[0];
                            IList<PhysicianSpecialty> PhysplList = objPhysicianSpecialtyManager.GetAllPhysicianSpecialty(ClientSession.LegalOrg);
                            if (drv["SpecialNeeds"].Text != string.Empty && drv["SpecialNeeds"].Text != "&ns")
                                txtSpecialNeeds.txtDLC.Text = drv["SpecialNeeds"].Text.Replace("&nbsp;", "");
                            txtServiceRequested.txtDLC.Text = drv["ServiceRequested"].Text.Replace("&nbsp;", "");
                            if (drv["AuthReq"].Text.ToString() == "Y" || delUpdtObj.Authorization_Number != "")
                            {
                                rbtnYes.Checked = true;
                                rbtnNo.Checked = false;
                            }
                            else
                            {
                                rbtnNo.Checked = true;
                                rbtnYes.Checked = false;
                                txtAuthorizationNumber.Enabled = false;
                            }
                            if (delUpdtObj.Move_To_MA == "Y")
                                chkMoveToMA.Checked = true;
                            else
                                chkMoveToMA.Checked = false;
                            txtReferralDate.Text = (Convert.ToDateTime(drv["RefDate"].Text.Replace("&nbsp;", ""))).ToString("dd-MMM-yyyy");
                            if (delUpdtObj.Valid_Till != DateTime.MinValue)
                            {
                                dtpValidTill.SelectedDate = delUpdtObj.Valid_Till;
                            }
                            txtNumberofVisit.Text = drv["NoofVisit"].Text.Replace("&nbsp;", "");
                            txtReasonForReferral.txtDLC.Text = delUpdtObj.Reason_For_Referral;
                            if (cboFacilityName.FindItemByText(drv["ReferringToFacility"].Text.Replace("&nbsp;", "")) != null)
                                cboFacilityName.SelectedIndex = cboFacilityName.FindItemByText(drv["ReferringToFacility"].Text.Replace("&nbsp;", "")).Index;
                            txtReferredToFacilityAddress.Text = delUpdtObj.To_Facility_Street_Address;//.Split('|');                  
                            txtReferredToFacilityAddress.Text = delUpdtObj.To_Facility_Street_Address;
                            txtReferredToFacilityCity.Text = delUpdtObj.To_Facility_City;
                            txtReferredToFacilityState.Text = delUpdtObj.To_Facility_State;
                            msktxtFacilityZipCode.Text = delUpdtObj.To_Facility_Zip;
                            msktxtFacilityPhoneNumber.Text = delUpdtObj.To_Facility_Phone_Number;
                            msktxtFacilityFaxNumber.Text = delUpdtObj.To_Facility_Fax_Number;
                            txtProviderName.Text = drv["ReferringToProvider"].Text.Replace("&nbsp;", "");
                            //cboSpecialty.SelectedIndex = cboSpecialty.FindItemIndexByText(drv["Speciality"].Text.Replace("&nbsp;", ""));
                            int SelectedIndex = 0;
                            SelectedIndex=cboFacilityName.FindItemIndexByText(delUpdtObj.To_Facility_Name.ToString());
                            if (SelectedIndex > 0)
                            {
                                cboFacilityName.SelectedIndex = SelectedIndex;
                            }
                            else
                            {
                                cboFacilityName.Items.Add(new RadComboBoxItem(delUpdtObj.To_Facility_Name.ToString()));
                                cboFacilityName.SelectedIndex = (cboFacilityName.FindItemIndexByText(delUpdtObj.To_Facility_Name.ToString()));
                            }
                            SelectedIndex = cboSpecialty.FindItemIndexByText(delUpdtObj.Referral_Specialty.ToString());
                            if (SelectedIndex > 0)
                            {
                                cboSpecialty.SelectedIndex = SelectedIndex;
                            }
                            else
                            {
                                cboSpecialty.Items.Add(new RadComboBoxItem(delUpdtObj.Referral_Specialty.ToString()));
                                cboSpecialty.SelectedIndex = cboSpecialty.FindItemIndexByText(delUpdtObj.Referral_Specialty.ToString());
                            }
                            txtOtherComments.txtDLC.Text = delUpdtObj.Referral_Notes;
                            txtAuthorizationNumber.Text = delUpdtObj.Authorization_Number;
                            //if (delUpdtObj.Authorization_Number != "")
                            //{                           
                            //   rbtnYes.Checked = true;
                            //   rbtnNo.Checked = false;

                            //}


                            btnAddRefOrder.Text = "Update";
                            btnAddRefOrder.AccessKey = "u";
                            btnClearAllRefOrder.Text = "Cancel";
                            System.Web.UI.HtmlControls.HtmlGenericControl text1 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnAddRefOrder.FindControl("SpanAdd");
                            text1.InnerText = "U";
                            System.Web.UI.HtmlControls.HtmlGenericControl text2 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnAddRefOrder.FindControl("SpanAdditionalword");
                            text2.InnerText = "pdate";
                            System.Web.UI.HtmlControls.HtmlGenericControl text3 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnClearAllRefOrder.FindControl("SpanClear");
                            text3.InnerText = "C";
                            System.Web.UI.HtmlControls.HtmlGenericControl text4 = (System.Web.UI.HtmlControls.HtmlGenericControl)btnClearAllRefOrder.FindControl("SpanClearAdditional");
                            text4.InnerText = "ancel";
                            //btnAddRefOrder.Text = "Update";
                            //btnClearAllRefOrder.Text = "Cancel";
                            btnAddRefOrder.Enabled = true;
                            if (ClientSession.UserCurrentProcess.ToUpper() == "MA_REVIEW" || ClientSession.UserCurrentProcess == "PHYSICIAN_VERIFY" && ScreenMode != string.Empty)
                            {
                                if (btnAddRefOrder.Text == "Update")
                                {
                                    pnlDiagnosis.Enabled = true;
                                    pnlReferredTo.Enabled = true;
                                    //pnlReferredDetails.Enabled = true;
                                    txtReasonForReferral.txtDLC.Enabled = true;
                                    txtReasonForReferral.pbDropdown.Disabled = false;
                                    txtReasonForReferral.Enable = true;

                                    txtServiceRequested.Enable = true;
                                    txtServiceRequested.txtDLC.Enabled = true;
                                    txtServiceRequested.pbDropdown.Disabled = false;

                                    txtSpecialNeeds.Enable = true;
                                    txtSpecialNeeds.txtDLC.Enabled = true;
                                    txtSpecialNeeds.pbDropdown.Disabled = false;

                                    txtOtherComments.Enable = true;
                                    txtOtherComments.txtDLC.Enabled = true;
                                    txtOtherComments.pbDropdown.Disabled = false;

                                    imgDiagnosis.ImageUrl = "~/Resources/Database Inactive.jpg";
                                    btnAddRefOrder.Enabled = true;
                                    btnClearAllRefOrder.Enabled = true;
                                    btnPrint.Enabled = true;
                                    btnPlan.Enabled = true;
                                    pnlbtn.Enabled = true;

                                    txtServiceRequested.Enable = true;
                                    txtServiceRequested.txtDLC.Enabled = true;
                                    txtServiceRequested.pbDropdown.Disabled = false;

                                    txtSpecialNeeds.Enable = true;
                                    txtSpecialNeeds.txtDLC.Enabled = true;
                                    txtSpecialNeeds.pbDropdown.Disabled = false;

                                    txtOtherComments.Enable = true;
                                    txtOtherComments.txtDLC.Enabled = true;
                                    txtOtherComments.pbDropdown.Disabled = false;
                                }
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Edit Referral Order", "EnableAddorder();{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                        }
                    }
                }
            }
            catch (Exception ItemCommend) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Referral Order Command", "alert('" + ItemCommend.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
        }

      


        protected void btnClear_Click(object sender, EventArgs e)
        {

            try
            {
                ClearText();
                if (ClientSession.UserCurrentProcess.ToUpper() == "MA_REVIEW" || ClientSession.UserCurrentProcess == "PHYSICIAN_VERIFY" && ScreenMode == "Myqueue")
                {
                    pnlDiagnosis.Enabled = false;
                    pnlReferredTo.Enabled = false;
                    //pnlReferredDetails.Enabled = false;
                    txtReasonForReferral.Enable = false;
                    txtReasonForReferral.txtDLC.Enabled = false;
                    txtReasonForReferral.pbDropdown.Disabled = true;
                    
                    txtServiceRequested.Enable = false;
                    txtServiceRequested.txtDLC.Enabled = false;
                    txtServiceRequested.pbDropdown.Disabled = true;

                    txtSpecialNeeds.Enable = false;
                    txtSpecialNeeds.txtDLC.Enabled = false;
                    txtSpecialNeeds.pbDropdown.Disabled = true;

                    txtOtherComments.Enable = false;
                    txtOtherComments.txtDLC.Enabled = false;
                    txtOtherComments.pbDropdown.Disabled = true;

                    imgDiagnosis.ImageUrl = "~/Resources/Database Disable.png";
                    btnClearAllRefOrder.Enabled = false;
                    btnPlan.Enabled = false;
                   // btnPrint.Enabled = false;
                    //pnlbtn.Enabled = false; ;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Clear All", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}disableAutoSave();", true);
            }
            catch (Exception ClearExc) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + ClearExc.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}disableAutoSave();", true); }
        }

        protected void cboFacilityName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                btnAddRefOrder.Enabled = true;
                if (cboFacilityName.Text != string.Empty)
                {
                    IList<FacilityLibrary> facilityList = new List<FacilityLibrary>();
                    IList<FacilityLibrary> objFacility = new List<FacilityLibrary>();
                    facilityList = objFacilityManager.GetFacilityList();
                    objFacility = (from obj in facilityList where obj.Fac_Name == cboFacilityName.Text select obj).ToList<FacilityLibrary>();
                    if (objFacility != null && objFacility.Count > 0)
                    {
                        txtReferredToFacilityAddress.Text = objFacility[0].Fac_Address1;
                        msktxtFacilityPhoneNumber.Text = objFacility[0].Fac_Telephone;
                        txtReferredToFacilityCity.Text = objFacility[0].Fac_City;
                        txtReferredToFacilityState.Text = objFacility[0].Fac_State;
                        msktxtFacilityZipCode.Text = objFacility[0].Fac_Zip;
                        msktxtFacilityFaxNumber.Text = objFacility[0].Fac_Fax;
                    }
                }
                else
                {
                    txtReferredToFacilityAddress.Text = "";
                    msktxtFacilityPhoneNumber.Text = "";
                    txtReferredToFacilityCity.Text = "";
                    txtReferredToFacilityState.Text = "";
                    msktxtFacilityZipCode.Text = "";
                    msktxtFacilityFaxNumber.Text = "";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
            }
            catch (Exception ExcpFacChange) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + ExcpFacChange.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
        }

        protected void imgDiagnosis_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["Selected_ICDs"] != null && Session["Selected_ICDs"].ToString().Trim() != string.Empty)
                {
                    IList<string> ItemsToBeAdded = (IList<string>)Session["Selected_ICDs"];
                    if (ItemsToBeAdded.Count > 0)
                    {
                        foreach (string str in ItemsToBeAdded)
                        {
                            string strtxt = string.Empty;
                            if (str.Split('|').Count() > 2)
                            {
                                strtxt = str.Split('|')[2].ToString();
                            }
                            else
                            {
                                strtxt = str;
                            }
                            ListItem itm = chklstAssessment.Items.FindByText(strtxt);
                            if (itm != null)
                            {
                                itm.Selected = true;
                                continue;
                            }
                            else
                            {
                                itm = new ListItem();
                                itm.Text = strtxt;
                                itm.Selected = true;
                                itm.Attributes.Add("title", str);
                                chklstAssessment.Items.Add(itm);
                            }

                        }
                    }
                    Session["Selected_ICDs"] = "";
                    btnAddRefOrder.Enabled = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "ImageEnableSaveReferralOrder(event); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);

                }
            }
            catch (Exception ExcpImgDiag) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + ExcpImgDiag.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
            //if (hdnTransferVaraible.Value != null && hdnTransferVaraible.Value.ToString() != string.Empty)
            //{
            //    string[] ItemsToBeAdded = hdnTransferVaraible.Value.ToString().Split('$');
            //    foreach (string str in ItemsToBeAdded)
            //    {
            //        ListItem itm = chklstAssessment.Items.FindByText(str);
            //        if (itm != null)
            //        {
            //            itm.Selected = true;
            //            continue;
            //        }
            //        else
            //        {
            //            itm = new ListItem();
            //            itm.Text = str;
            //            itm.Selected = true;
            //            chklstAssessment.Items.Add(itm);
            //        }

            //    }
            //    hdnTransferVaraible.Value = "";
            //}
        }

        protected void btnFindPhysician_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnTransferVaraible.Value != null && hdnTransferVaraible.Value.ToString() != string.Empty)
                {
                    string[] PassedObjects = hdnTransferVaraible.Value.ToString().Split('$');
                    string sPhyName = PassedObjects[0].Split('=')[1];
                    string sPhySpecialty = PassedObjects[1].Split('=')[1].Replace("&amp;", "&");
                    string sPhyFacility = PassedObjects[2].Split('=')[1];
                    if (sPhyName != string.Empty)
                    {
                        txtProviderName.Text = sPhyName;
                        cboSpecialty.SelectedIndex = cboSpecialty.Items.FindItemIndexByText(sPhySpecialty.ToUpper());
                        if (cboSpecialty.SelectedIndex==-1)
                            cboSpecialty.SelectedIndex = cboSpecialty.Items.FindItemIndexByText(sPhySpecialty);

                        //cboSpecialty.Text = sPhySpecialty.ToUpper();
                        cboFacilityName.SelectedIndex = cboFacilityName.Items.FindItemIndexByText(sPhyFacility);

                        if (sPhyFacility != string.Empty)
                        {
                            IList<FacilityLibrary> facilityList = new List<FacilityLibrary>();
                            facilityList = objFacilityManager.GetFacilityList();
                            IList<FacilityLibrary> objFacility = new List<FacilityLibrary>();

                            var Fac = (from obj in facilityList where obj.Fac_Name == sPhyFacility select obj);
                            if (Fac.Count() > 0)
                            {
                                objFacility = Fac.ToList<FacilityLibrary>();
                                txtReferredToFacilityAddress.Text = objFacility[0].Fac_Address1;
                                msktxtFacilityPhoneNumber.Text = objFacility[0].Fac_Telephone;
                                txtReferredToFacilityCity.Text = objFacility[0].Fac_City;
                                txtReferredToFacilityState.Text = objFacility[0].Fac_State;
                                msktxtFacilityZipCode.Text = objFacility[0].Fac_Zip;
                                msktxtFacilityFaxNumber.Text = objFacility[0].Fac_Fax;
                            }

                        }
                        else
                        {
                            txtReferredToFacilityAddress.Text = string.Empty;
                            msktxtFacilityPhoneNumber.Text = string.Empty;
                            txtReferredToFacilityCity.Text = string.Empty;
                            txtReferredToFacilityState.Text = string.Empty;
                            msktxtFacilityZipCode.Text = string.Empty;
                            msktxtFacilityFaxNumber.Text = string.Empty;
                        }
                    }
                }
                btnAddRefOrder.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
            }
            catch (Exception ExcpFindPhy) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + ExcpFindPhy.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdReferralOrders.Items.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "DisplayErrorMessage('720007', '',''); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    //ApplicationObject.erroHandler.DisplayErrorMessage("720007", this.Text);
                    return;
                }
                else
                {
                    SelectedItem.Value = string.Empty;
                    //IList<ReferralOrder> distinctPhyList = //(from obj in objRefOrdDTO.RefOrdList.Distinct select new { obj.Referral_Specialty }).Distinct().ToList<ReferralOrder>();
                    foreach (string PhyID in objRefOrdDTO.RefOrdList.Select(a => a.Referral_Specialty).Distinct())
                    {
                        IList<ReferralOrder> refList = (from obj in objRefOrdDTO.RefOrdList where obj.Referral_Specialty == PhyID select obj).ToList<ReferralOrder>();
                        //humanRecord = EncounterManager.Instance.GetHumanByHumanID(ulMyHumanID);
                        PrintOrders print = new PrintOrders();
                        string sDirPath = Server.MapPath("Documents/" + Session.SessionID);

                        DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

                        if (!ObjSearchDir.Exists)
                        {
                            ObjSearchDir.Create();
                        }

                        string TargetFileDirectory = Server.MapPath("Documents\\" + Session.SessionID);

                        if (Request["HumanID"] != null && Request["HumanID"].Trim() != string.Empty)
                        {
                            HumanID = Convert.ToUInt32(Request["HumanID"]);
                            hdnhumanid.Value = HumanID.ToString();
                        }
                        else
                        {
                            HumanID = ClientSession.HumanId;
                        }
                        //HumanManager HumanMngr=new HumanManager();
                        //Human ObjHuman = HumanMngr.GetHumanFromHumanID(HumanID);
                        OrdersManager objOrdersManager = new OrdersManager();
                        FillHumanDTO objFillHumnaDTO = new FillHumanDTO();
                        objFillHumnaDTO = objOrdersManager.PatientInsuredBag(HumanID);

                        //string FileLocation = print.PrintInReferralOrder(refList, PhysicianID, objRefOrdDTO, ObjHuman, PhyID, TargetFileDirectory);

                        string FileLocation = print.PrintInReferralOrder(refList, PhysicianID, objRefOrdDTO, objFillHumnaDTO, PhyID, TargetFileDirectory);


                        string[] Split = new string[] { Server.MapPath("Documents\\" + Session.SessionID) };
                        string[] FileName = FileLocation.Split(Split, StringSplitOptions.RemoveEmptyEntries);
                        if (SelectedItem.Value == string.Empty)
                        {
                            SelectedItem.Value = "Documents\\" + Session.SessionID.ToString() + "\\" + FileName[0].ToString();
                        }
                        else
                        {
                            SelectedItem.Value += "|" + FileName[0].ToString();
                        }


                    }
                    //RadWindow1.NavigateUrl = "frmPrintPDF.aspx?SI=" + SelectedItem.Value + "&Location=" + "DYNAMIC";
                    //RadWindow1.Height = 650;
                    //RadWindow1.VisibleOnPageLoad = true;
                    //RadWindow1.Width = 900;
                    //RadWindow1.CenterIfModal = true;
                    //RadWindow1.VisibleTitlebar = true;
                    //RadWindow1.VisibleStatusbar = false;

                    //RadWindow1.Behaviors = WindowBehaviors.Close;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "OpenPDF();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Print Order", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}PrintReferralOrderPDF();", true);
                }
            }
            catch  { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
        }

        protected void btnPlan_Click(object sender, EventArgs e)
        {

        }

        protected void InvisibleButton_Click(object sender, EventArgs e)
        {
            try
            {
                PhysicianSpecialtyManager objPhysicianSpecialtyManager = new PhysicianSpecialtyManager();

                if (hdnTransferVaraible.Value != null && hdnTransferVaraible.Value.ToString() != string.Empty)
                {
                    string[] PassedObjects = hdnTransferVaraible.Value.ToString().Split('$');
                    string sPhyName = PassedObjects[0].Split('=')[1];
                    string sPhySpecialty = PassedObjects[1].Split('=')[1];
                    string sPhyFacility = PassedObjects[2].Split('=')[1];
                    if (sPhyName != string.Empty)
                    {
                        txtProviderName.Text = sPhyName;
                        cboSpecialty.SelectedIndex = cboSpecialty.Items.FindItemIndexByText(sPhySpecialty.ToUpper());
                        if (cboSpecialty.SelectedIndex == -1)
                            cboSpecialty.SelectedIndex = cboSpecialty.Items.FindItemIndexByText(sPhySpecialty);
                        cboFacilityName.SelectedIndex = cboFacilityName.Items.FindItemIndexByText(sPhyFacility);

                        if (sPhyFacility != string.Empty)
                        {
                            IList<PhysicianSpecialty> PhysplList = objPhysicianSpecialtyManager.GetAllPhysicianSpecialty(ClientSession.LegalOrg);
                            var Speciality = from c in PhysplList where c.Physician_ID == Convert.ToUInt64(ViewState["EncounterID"]) select c;
                            if (Speciality.ToList<PhysicianSpecialty>().Count > 0)
                            {
                                string SpecialityName = Speciality.ToList<PhysicianSpecialty>()[0].Specialty;

                                // cboSpecialty
                            }

                            IList<FacilityLibrary> facilityList = new List<FacilityLibrary>();
                            facilityList = objFacilityManager.GetFacilityList();
                            IList<FacilityLibrary> objFacility = new List<FacilityLibrary>();
                            var Fac = (from obj in facilityList where obj.Fac_Name == sPhyFacility select obj);
                            if (Fac != null && Fac.Count() > 0)
                            {
                                objFacility = Fac.ToList<FacilityLibrary>();
                                txtReferredToFacilityAddress.Text = objFacility[0].Fac_Address1;
                                msktxtFacilityPhoneNumber.Text = objFacility[0].Fac_Telephone;
                                txtReferredToFacilityCity.Text = objFacility[0].Fac_City;
                                txtReferredToFacilityState.Text = objFacility[0].Fac_State;
                                msktxtFacilityZipCode.Text = objFacility[0].Fac_Zip;
                                msktxtFacilityFaxNumber.Text = objFacility[0].Fac_Fax;
                            }
                        }
                        else
                        {
                            txtReferredToFacilityAddress.Text = string.Empty;
                            msktxtFacilityPhoneNumber.Text = string.Empty;
                            txtReferredToFacilityCity.Text = string.Empty;
                            txtReferredToFacilityState.Text = string.Empty;
                            msktxtFacilityZipCode.Text = string.Empty;
                            msktxtFacilityFaxNumber.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ExcpInvisible) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + ExcpInvisible.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
        }


        protected void btnMoveToNextProcess_Click(object sender, EventArgs e)
        {
            try
            {
                bool SubmitOrNot;
                string MedicalAssistance = string.Empty;
                WFObjectManager objWFobjectMngr = new WFObjectManager();
                UserManager objUserMngr = new UserManager();
                if (ClientSession.UserRole == "Physician" || ClientSession.UserRole == "Physician Assistant")
                {
                    MedicalAssistance = "UNKNOWN";
                }
                IList<string> lstOrderType = new List<string>();
                if (ScreenMode.ToString().ToUpper().Trim() == "MENU")
                {
                    OrdersManager objOrdersManager = new OrdersManager();
                    SubmitOrNot = objOrdersManager.SubmitOrdersWithOutEncounter(HumanID, 0, "ReferralOrder", string.Empty, ClientSession.UserName, DateTime.Now, MedicalAssistance, lstOrderType.ToArray<string>(), ClientSession.FacilityName);
                    if (SubmitOrNot)
                    {
                        //ApplicationObject.erroHandler.DisplayErrorMessage("8507001", this.Text);
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SaveSuccessfully", "DisplayErrorMessage('8507001'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SaveSuccessfully", "DisplayErrorMessage('8507002'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);

                        //ApplicationObject.erroHandler.DisplayErrorMessage("8507002", this.Text);
                    }
                }
                else
                {
                    if (ulMyReferralOrderGroupID != 0)
                    {
                        //IList<ulong> GroupID = (from o in objOtherProDTO.OtherProcedure select o.In_House_Procedure_Group_ID).Distinct().ToList<ulong>();
                        if (ClientSession.UserCurrentProcess == "PHYSICIAN_VERIFY")
                        {
                            objWFobjectMngr.MoveToNextProcess(ulMyReferralOrderGroupID, "REFERRAL ORDER", 1, "UNKNOWN", UtilityManager.ConvertToUniversal(), null, null, null);
                        }
                        else
                        {

                            IList<User> UserList = objUserMngr.GetUserList(ClientSession.LegalOrg);
                            IList<User> userName = (from user in UserList where user.Physician_Library_ID == PhysicianID select user).ToList<User>();

                            // Commented by Manimozhi on jan 19th 2012 - To Remove GetByObjectSystemId() call

                            // WFObject TempWF = new WFObject();
                            //  TempWF = WFProxy.GetByObjectSystemId(ulMyInHouseSubmitID, "INTERNAL ORDER");

                            // Modified by Manimozhi on jan 19th 2012 - To Remove GetByObjectSystemId() call
                            objWFobjectMngr.MoveToNextProcess(ulMyReferralOrderGroupID, "REFERRAL ORDER", 1, userName[0].user_name, UtilityManager.ConvertToUniversal(Convert.ToDateTime(hdnLocalTime.Value)), null, null, null);

                        }
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SaveSuccessfully", "DisplayErrorMessage('280013'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "WindowClose();", true);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.close()", true);
                        //ApplicationObject.erroHandler.DisplayErrorMessage("280013", this.Text);
                        //this.Close();
                    }

                    else
                    {
                        if (ulMyReferralOrderGroupID != 0)
                        {
                            //IList<ulong> GroupID = (from o in objOtherProDTO.OtherProcedure select o.In_House_Procedure_Group_ID).Distinct().ToList<ulong>();
                            if (ClientSession.UserCurrentProcess == "PHYSICIAN_VERIFY")
                            {
                                objWFobjectMngr.MoveToNextProcess(ulMyReferralOrderGroupID, "REFERRAL ORDER", 1, "UNKNOWN", UtilityManager.ConvertToUniversal(Convert.ToDateTime(hdnLocalTime.Value)), null, null, null);
                            }
                            else
                            {

                                IList<User> UserList = objUserMngr.GetUserList(ClientSession.LegalOrg);
                                IList<User> userName = (from user in UserList where user.Physician_Library_ID == PhysicianID select user).ToList<User>();

                                // Commented by Manimozhi on jan 19th 2012 - To Remove GetByObjectSystemId() call

                                // WFObject TempWF = new WFObject();
                                //  TempWF = WFProxy.GetByObjectSystemId(ulMyInHouseSubmitID, "INTERNAL ORDER");

                                // Modified by Manimozhi on jan 19th 2012 - To Remove GetByObjectSystemId() call
                                objWFobjectMngr.MoveToNextProcess(ulMyReferralOrderGroupID, "REFERRAL ORDER", 1, userName[0].user_name, UtilityManager.ConvertToUniversal(), null, null, null);

                            }
                            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SaveSuccessfully", "DisplayErrorMessage('280013'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "WindowClose();", true);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.close()", true);
                            //ApplicationObject.erroHandler.DisplayErrorMessage("280013", this.Text);
                            //this.Close();
                        }
                    }
                }
            }
            catch (Exception ExcpMoveToNext) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Exception", "alert('" + ExcpMoveToNext.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
            
        }

        protected void grdReferralOrders_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                e.Item.ToolTip = "";
                if (e.Item is GridDataItem)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    foreach (GridColumn column in grdReferralOrders.MasterTableView.RenderColumns)
                    {
                        if (column.UniqueName == "Del")
                        {
                            gridItem[column.UniqueName].ToolTip = "Delete";
                        }
                        if (column.UniqueName == "Edit")
                        {
                            gridItem[column.UniqueName].ToolTip = "Edit";
                        }


                    }
                }
            }
            catch (Exception ItemCreated) { ScriptManager.RegisterStartupScript(this, this.GetType(), "Referral Orders", "alert('" + ItemCreated.Message.Replace("'", " ") + "'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true); }
        }

    }
}
