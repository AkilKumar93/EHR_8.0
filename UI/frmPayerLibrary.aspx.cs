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
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.UI;

namespace Acurus.Capella.UI
{
    public partial class frmPayerLibrary : System.Web.UI.Page
    {
        StateManager StateMngr = new StateManager();
        FinancialClassesManager FinancialMngr = new FinancialClassesManager();
        StaticLookupManager StaticMngr = new StaticLookupManager();
        InsurancePlanManager insMngr = new InsurancePlanManager();
        CarrierManager CarrierMngr = new CarrierManager();
        bool bFormclose = false;
        protected int pageCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ClientSession.FlushSession();
                LoadComboBox();
                btnAdd.Enabled = false;
                btnFirst.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnPrevious.Enabled = false;
               
            }
            

        }
        Double myPageNumber;
        int iMyLastPageNo;
        int PageNumber = 1;
        int MaxResultPerPage = 25;
        int TotalNoofDBRecords;
        int TotalCount = 0;
        public void LoadComboBox()
        {
            // IList<Carrier> objCarrier = AllLibraries.Instance.GetCarrierList();
            IList<Carrier> Carrierlist = (insMngr.GetCarrierList().OrderBy(a => a.Carrier_Name)).ToList<Carrier>();
            ddlCarrierName.Items.Add("");
            if (Carrierlist != null)
            {
                for (int i = 0; i < Carrierlist.Count; i++)
                {
                    ListItem cboItem = new ListItem();
                    cboItem.Text = Carrierlist[i].Carrier_Name;
                    cboItem.Value = Carrierlist[i].Id.ToString();
                    // cboCarrierId.Items.Add(new RadComboBoxItem(Carrierlist[i].Id.ToString()));
                    ddlCarrierName.Items.Add(cboItem);

                }
            }

            IList<State> StateListAll = StateMngr.Getstate();// removed for preformance AllLibraries.Instance.GetStateList();

            var StateList = StateListAll.Select(aa => aa.State_Code).Distinct().ToList<string>();

            ddlState.Items.Add("");
            ddlClaimState.Items.Add("");
            if (StateList != null)
            {
                for (int i = 0; i < StateList.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = StateList[i].ToString();
                    item.Value = i.ToString();//StateList[i].Id.ToString();
                    ddlState.Items.Add(item);
                    ddlClaimState.Items.Add(item);
                }
            }

            IList<FinancialClasses> FinancialClassesList = FinancialMngr.GetFinancialClassesList();
            ddlFinancialClassId.Items.Add("");

            if (FinancialClassesList != null)
            {
                for (int i = 0; i < FinancialClassesList.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = FinancialClassesList[i].Financial_Class_Name;
                    item.Value = FinancialClassesList[i].Id.ToString();
                    ddlFinancialClassId.Items.Add(item);
                }
            }


            IList<StaticLookup> iStaticLookuplist = (StaticMngr.getStaticLookupByFieldName("GOVT TYPE").OrderBy(a => a.Sort_Order)).ToList<StaticLookup>();

            if (iStaticLookuplist != null)
            {
                for (int i = 0; i < iStaticLookuplist.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = iStaticLookuplist[i].Value;
                    item.Value = iStaticLookuplist[i].Id.ToString();
                    ddlGovtType.Items.Add(item);
                }
            }


        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }
        public double GetTotalNoofDBRecords()
        {


            if (TotalCount != 0)
            {
                myPageNumber = (double)(TotalCount) / (double)(MaxResultPerPage);
                iMyLastPageNo = Convert.ToInt32(Math.Ceiling(myPageNumber));
                //Session["iMyLastPageNo"] = iMyLastPageNo;
                hdnLastPageNo.Value = iMyLastPageNo.ToString();
            }
            LinkButtonLoad();
            return myPageNumber;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sForCancel = hdnMessageType.Value;
            hdnMessageType.Value = string.Empty;
            btnAdd.Enabled = false;

            if (Validation() == false)
            {
                goto End;
                return;
            }

            PayerLibraryDTO payerlist = new PayerLibraryDTO();

            if (btnAdd.Text == "Add")
            {

                InsurancePlan Payer = new InsurancePlan();
                Payer.Carrier_ID = Convert.ToInt32(ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value);
                Payer.Active = "Y";
                Payer.Ins_Plan_Name = txtInsPlanName.Text;
                Payer.Office_Number = msktxtOfficeNum.Text;
                Payer.Payer_Addrress1 = txtStreetAddress1.Text;
                Payer.Payer_Addrress2 = txtStreetAddress2.Text;
                Payer.Payer_City = txtCity.Text;
                Payer.Payer_Notes = txtPayerNotes.Text;
                Payer.Payer_Phone_Number = msktxtTelephone.Text;
                Payer.Financial_Class_Name = ddlFinancialClassId.SelectedItem.Text;
                if (ddlGovtType.SelectedItem.Text != null && ddlGovtType.SelectedItem.Text != "")
                {
                    Payer.Govt_Type = ddlGovtType.SelectedItem.Text;
                }
                if (ddlState.SelectedItem.Text != null && ddlState.SelectedItem.Text != "")
                {
                    Payer.Payer_State = ddlState.SelectedItem.Text;

                }
                if (msktxtZip.Text.Length == 6 && msktxtZip.Text.Length < 10)
                {
                    string[] Split = Convert.ToString(msktxtZip.Text).Split('-');
                    if (Split.Length == 2 && Split[1] == string.Empty)
                    {
                        Payer.Payer_Zip = Split[0].ToString();
                    }
                }
                else
                {
                    Payer.Payer_Zip = msktxtZip.Text;
                }

                Payer.External_Plan_Number = txtPlanNo.Text;
                
                Payer.Created_By = ClientSession.UserName;
                if (msktxtZip.Text.Length == 6 && msktxtZip.Text.Length < 10)
                {
                    string[] Split = Convert.ToString(msktxtZip.Text).Split('-');
                    if (Split.Length == 2 && Split[1] == string.Empty)
                    {
                        msktxtZip.Text = Split[0].ToString();
                    }
                }
                Payer.Claim_Address = txtClaimAddress.Text;
                Payer.Claim_Attention = txtClaimAttention.Text;
                Payer.Claim_City = txtClaimCity.Text;
                if (txtClaimZipCode.Text != "_____-____")
                {
                    Payer.Claim_ZipCode = txtClaimZipCode.Text;
                }
                Payer.Claim_State = ddlClaimState.Text;
                Payer.Created_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                Payer.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                //Payer.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                //Payer.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                payerlist = insMngr.SaveInsurancePlan(Payer, PageNumber, 25, string.Empty);
                // ApplicationObject.erroHandler.DisplayErrorMessage("660004", "Payer Library", this.Page);
                if (sForCancel == "Yes")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage(660004);window.close();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage(660004);document.getElementById('btnAdd').disabled= true", true);
                }

                LoadGrid(payerlist.InsurancePlanList);
                TotalNoofDBRecords = payerlist.InsurancePlanListCount;
                ClearAll();
                //  bFormclose = true;
                btnAdd.Enabled = false;
            }
            else
            {
                InsurancePlan Payer = new InsurancePlan();

                IList<InsurancePlan> insList = insMngr.GetInsurancebyID(Convert.ToUInt64(txtPayerId.Text));
                if (insList.Count > 0 && insList != null)
                {

                    Payer = insList[0];
                }
                //Payer = (from h in payerlist.InsurancePlanList where h.Id == Convert.ToUInt64(txtPayerId.Text) select h).ToList()[0];
                Payer.Carrier_ID = Convert.ToInt32(ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value);
                Payer.Active = "Y";
                Payer.Ins_Plan_Name = txtInsPlanName.Text;
                Payer.Office_Number = msktxtOfficeNum.Text;
                Payer.Payer_Addrress1 = txtStreetAddress1.Text;
                Payer.Payer_Addrress2 = txtStreetAddress2.Text;
                Payer.Payer_City = txtCity.Text;
                Payer.Payer_Notes = txtPayerNotes.Text;
                Payer.Payer_Phone_Number = msktxtTelephone.Text;
                Payer.Payer_State = ddlState.SelectedItem.Text;

                if (msktxtZip.Text.Length == 6 && msktxtZip.Text.Length < 10)
                {
                    string[] Split = Convert.ToString(msktxtZip.Text).Split('-');
                    if (Split.Length == 2 && Split[1] == string.Empty)
                    {
                        Payer.Payer_Zip = Split[0].ToString();
                    }
                }
                else
                {
                    Payer.Payer_Zip = msktxtZip.Text;
                }
                Payer.Claim_Address = txtClaimAddress.Text;
                Payer.Claim_Attention = txtClaimAttention.Text;
                Payer.Claim_City = txtClaimCity.Text;
                if (txtClaimZipCode.Text.Length == 6 && txtClaimZipCode.Text.Length < 10)
                {
                    string[] Split = Convert.ToString(txtClaimZipCode.Text).Split('-');
                    if (Split.Length == 2 && Split[1] == string.Empty)
                    {
                        Payer.Claim_ZipCode = Split[0].ToString();
                    }
                }
                else
                {
                    Payer.Claim_ZipCode = txtClaimZipCode.Text;
                }

                Payer.Claim_State = ddlClaimState.Text;
                Payer.External_Plan_Number = txtPlanNo.Text;
                Payer.Financial_Class_Name = ddlFinancialClassId.SelectedItem.Text;
                Payer.Govt_Type = ddlGovtType.SelectedItem.Text;
                Payer.Modified_By = ClientSession.UserName;
                Payer.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                //Payer.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                payerlist = insMngr.updateInsurancePlan(Payer, PageNumber, 25, string.Empty);
                //ApplicationObject.erroHandler.DisplayErrorMessage("660005", "Payer Library", this.Page);
                if (sForCancel == "Yes")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage(660005);window.close();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage(660005);document.getElementById('btnAdd').disabled = true;", true);
                }
                LoadGrid(payerlist.InsurancePlanList);
                TotalNoofDBRecords = payerlist.InsurancePlanListCount;
                btnAdd.Text = "Add";
                btnClearAll.Text = "Clear All";
                ClearAll();
                //bFormclose = true;
                btnAdd.Enabled = false;
            }

        End:
            if (bFormclose != true)
            {
                btnAdd.Enabled = true;
                return;
            }

        }
        public Boolean Validation()
        {
            if (txtInsPlanName.Text.Trim() == string.Empty)
            {
                //ApplicationObject.erroHandler.DisplayErrorMessage("660001", "Payer Library", this.Page);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage(660001);", true);
                txtInsPlanName.Focus();
                return false;
            }

            if (ddlCarrierName.Text.Trim() == string.Empty)
            {
                //ApplicationObject.erroHandler.DisplayErrorMessage("660002", "Payer Library", this.Page);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage(660002);", true);
                ddlCarrierName.Focus();
                //cboCarrierId.Focus();
                return false;
            }
            string strZip = string.Empty;
            if (msktxtZip.Text.Length == 6 && msktxtZip.Text.Length < 10)
            {
                string[] Split = Convert.ToString(msktxtZip.Text).Split('-');
                if (Split.Length == 2 && Split[1] == string.Empty)
                {
                    strZip = Split[0].ToString();
                }
            }
            else
            {
                strZip = msktxtZip.Text;//.Replace('-', ' ');
            }

            //if (msktxtZip.Text.Contains('-') && msktxtZip.Text.Length == 6)
            //{
            //    strZip = msktxtZip.Text.Remove(6);
            //}

            //if (Convert.ToInt32(txtPayerId.Text) == 0)
            //if (btnAdd.Text == "&Add")
            //{ 
            int count = 0;
            if (txtInsPlanName.Text.Trim() != string.Empty && ddlCarrierName.Text.Trim() != string.Empty)
            {
                if (txtPayerId.Text == string.Empty)
                {
                    count = insMngr.CheckInsuranceDuplicate(txtInsPlanName.Text.ToUpper().Trim(), ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value.ToString(), txtStreetAddress1.Text.ToUpper().Trim(), txtCity.Text.ToUpper().Trim(),ddlState.Text.ToUpper().Trim(), strZip, "0");
                }
                else
                {
                    count = insMngr.CheckInsuranceDuplicate(txtInsPlanName.Text, ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value.ToString(), txtStreetAddress1.Text, txtCity.Text, ddlState.Text, msktxtZip.Text, txtPayerId.Text);
                }
                if (count > 0)
                {
                    // ApplicationObject.erroHandler.DisplayErrorMessage("660003", "Payer Library", this.Page);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Payer Library", "DisplayErrorMessage('660003');", true);
                    txtInsPlanName.Focus();
                    return false;
                }
            }
            // }

            if (msktxtOfficeNum.Text != "(___) ___-____")
            {
                if (PhNoValid(msktxtOfficeNum.Text) == false)
                {
                    //ApplicationObject.erroHandler.DisplayErrorMessage("660008", "Payer Library", this.Page);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Payer Library", "DisplayErrorMessage('660008');", true);
                    msktxtOfficeNum.Focus();
                    return false;
                }
            }

            if (msktxtTelephone.Text != "(___) ___-____")
            {
                if (PhNoValid(msktxtTelephone.Text) == false)
                {
                    //ApplicationObject.erroHandler.DisplayErrorMessage("660009", "Payer Library", this.Page);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Payer Library", "DisplayErrorMessage('660009');", true);
                    msktxtTelephone.Focus();
                    return false;
                }
            }

            if (msktxtZip.Text != "_____-____")
            {
                if (msktxtZip.Text != "_____-____" && (msktxtZip.Text.Replace("_", "").Length != 6 && msktxtZip.Text.Replace("_", "").Length != 10))
                {
                    //ApplicationObject.erroHandler.DisplayErrorMessage("660013", "Payer Library", this.Page);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Payer Library", "DisplayErrorMessage('660013');", true);
                    msktxtZip.Focus();
                    return false;
                }




            }

            return true;
        }
        public void ClearAll()
        {
            txtStreetAddress1.Text = string.Empty;
            txtStreetAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPlanNo.Text = string.Empty;
            msktxtZip.Text = string.Empty;
            msktxtTelephone.Text = string.Empty;
            txtPayerNotes.Text = string.Empty;
            txtPayerId.Text = string.Empty;
            msktxtOfficeNum.Text = string.Empty;
            txtInsPlanName.Text = string.Empty;
            ddlFinancialClassId.SelectedIndex = 0;
            ddlFinancialClassId.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;

            ddlClaimState.SelectedIndex = 0;
            txtClaimAddress.Text = string.Empty;
            ddlGovtType.SelectedIndex = 0;
            txtClaimAttention.Text = string.Empty;
            txtClaimCity.Text = string.Empty;
            txtClaimZipCode.Text = string.Empty;
            btnAdd.Text = "Add";
        }
        //public void SavePayer()
        //{
        //     Payer.Carrier_ID = Convert.ToInt32(ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value);
        //    Payer.Active = "Y";
        //    Payer.Ins_Plan_Name = txtInsPlanName.Text;
        //    Payer.Office_Number = msktxtOfficeNum.Text;
        //    Payer.Payer_Addrress1 = txtStreetAddress1.Text;
        //    Payer.Payer_Addrress2 = txtStreetAddress2.Text;
        //    Payer.Payer_City = txtCity.Text;
        //    Payer.Payer_Notes = txtPayerNotes.Text;
        //    Payer.Payer_Phone_Number = msktxtTelephone.Text;
        //    Payer.Payer_State = ddlState.SelectedItem.Text;

        //    if (msktxtZip.Text.Length == 6 && msktxtZip.Text.Length < 10)
        //    {
        //        string[] Split = Convert.ToString(msktxtZip.Text).Split('-');
        //        if (Split.Length == 2 && Split[1] == string.Empty)
        //        {
        //            Payer.Payer_Zip = Split[0].ToString();
        //        }
        //    }
        //    else
        //    {
        //        Payer.Payer_Zip = msktxtZip.Text;
        //    }

        //    Payer.External_Plan_Number = txtPlanNo.Text;
        //    Payer.Financial_Class_Name = ddlFinancialClassId.SelectedItem.Text;
        //    Payer.Govt_Type = ddlGovtType.SelectedItem.Text;
        //}
        public Boolean PhNoValid(string sPhno)
        {
            string sReplace = string.Empty;
            sReplace = sPhno.Replace("_", "");

            if (sReplace.Length < 13)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void LoadGrid(IList<InsurancePlan> InsuranceList)
        {
            grdPayer.DataSource = null;
            grdPayer.DataBind();
            DataTable dt = new DataTable();
            dt.Columns.Add("PayerID", typeof(string));
            dt.Columns.Add("Carrier Name", typeof(string));
            dt.Columns.Add("Ins Plan Name", typeof(string));
            dt.Columns.Add("Address1", typeof(string));
            dt.Columns.Add("Address2", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Zip Code", typeof(string));
            dt.Columns.Add("Phone No", typeof(string));
            dt.Columns.Add("Financial Class", typeof(string));
            dt.Columns.Add("Carrier ID", typeof(string));
            dt.Columns.Add("InsTypeCode", typeof(string));
            if (InsuranceList != null)
            {
                for (int k = 0; k < InsuranceList.Count; k++)
                {

                    DataRow dr = dt.NewRow();

                    // dr["Edit"] = global::Acurus.Capella.UI.Properties.Resources.edit;
                    //  dr["Delete"] = global::Acurus.Capella.UI.Properties.Resources.close_small_pressed;
                    dr["Ins Plan Name"] = InsuranceList[k].Ins_Plan_Name.ToString();
                    dr["Address1"] = InsuranceList[k].Payer_Addrress1.ToString();
                    dr["Address2"] = InsuranceList[k].Payer_Addrress2.ToString();
                    dr["City"] = InsuranceList[k].Payer_City.ToString();
                    dr["State"] = InsuranceList[k].Payer_State.ToString();

                    dr["Zip Code"] = InsuranceList[k].Payer_Zip.ToString();
                    dr["PayerID"] = InsuranceList[k].Id.ToString();

                    dr["InsTypeCode"] = InsuranceList[k].External_Plan_Number.ToString();
                    dr["Carrier ID"] = InsuranceList[k].Carrier_ID.ToString();
                    dt.Rows.Add(dr);
                }
                grdPayer.DataSource = dt;
                grdPayer.DataBind();


            }
        }
        protected void PageChangeEventHandler(object sender, CommandEventArgs e)
        {


            switch (e.CommandArgument.ToString())
            {
                case "First":

                    Session["PageNumber"] = 1;

                    break;
                case "Previous":

                    if (Convert.ToInt32(Session["PageNumber"]) > 1)
                    {
                        PageNumber = Convert.ToInt32(Session["PageNumber"]) - 1;
                        Session["PageNumber"] = PageNumber;
                    }

                    break;
                case "Next":
                    if (btnFirst.Enabled == false && btnPrevious.Enabled == false)
                    {
                        Session["PageNumber"] = 1;
                    }
                    if (Convert.ToInt32(Session["PageNumber"]) < Convert.ToInt32((hdnLastPageNo.Value)))
                    {
                        PageNumber = Convert.ToInt32(Session["PageNumber"]) + 1;
                        Session["PageNumber"] = PageNumber;
                    }

                    break;

                case "Last":

                    PageNumber = Convert.ToInt32(hdnLastPageNo.Value);
                    break;
            }
            Session["PageNumber"] = PageNumber;
            FillPayer();
            RefreshPageButtons();
        }


        private void LinkButtonLoad()
        {
            int iStartPageNo = 0;
            int iEndPageNo = 0;

            if (TotalCount == 0)
            {
                iStartPageNo = 0;
            }
            else
            {
                if (hdnLastPageNo.Value != string.Empty)
                    iStartPageNo = ((Convert.ToInt32(hdnLastPageNo.Value) - 1) * MaxResultPerPage) + 1;
            }
            if (hdnLastPageNo.Value != string.Empty)
                iEndPageNo = (Convert.ToInt32((hdnLastPageNo.Value)) * MaxResultPerPage);


            if (iEndPageNo == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                return;
            }
            else
            {

            }

            if (PageNumber == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            if (iEndPageNo >= TotalCount)
            {
                iEndPageNo = TotalCount;

                if (iStartPageNo == 0 && iEndPageNo != 0)
                {
                    iStartPageNo = 1;
                }


                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }
        private void RefreshPageButtons()
        {

            int iStartPageNo = 0;
            int iEndPageNo = 0;
            if (hdnLastPageNo.Value != string.Empty)
            {

                if (Convert.ToInt32(hdnLastPageNo.Value) == 0)
                {
                    iStartPageNo = 0;
                }
                else
                {
                    iStartPageNo = ((PageNumber - 1) * MaxResultPerPage) + 1;
                }
            }

            iEndPageNo = (PageNumber * MaxResultPerPage);
            lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalCount.ToString();

            if (iEndPageNo == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                return;
            }
            else
            {
                // lblShowing.Show();
            }

            if (PageNumber == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            if (iEndPageNo >= Convert.ToInt32(hdnTotalCount.Value))
            {
                iEndPageNo = Convert.ToInt32(hdnTotalCount.Value);

                if (iStartPageNo == 0 && iEndPageNo != 0)
                {
                    iStartPageNo = 1;
                }
                lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalCount.ToString();
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        protected void ddlCarrierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PayerLibraryDTO payerlist = new PayerLibraryDTO();
            int CarrierId = 0;
            if (ddlCarrierName.Text != string.Empty)
            {
                CarrierId = Convert.ToInt32(ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value);
            }


            payerlist = insMngr.GetInsuranceList(CarrierId, PageNumber, 25);
            TotalCount = payerlist.InsurancePlanListCount;

            hdnTotalCount.Value = payerlist.InsurancePlanListCount.ToString();
            pageCount = Convert.ToInt32(GetTotalNoofDBRecords());
            LoadGrid(payerlist.InsurancePlanList);

            Session["PageCount"] = pageCount;
            RefreshPageButtons();
            btnAdd.Enabled = true;
        }

        protected void grdPayer_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "EditC")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                btnAdd.Text = "Update";
                btnClearAll.Text = "Cancel";
                IList<InsurancePlan> insList = new List<InsurancePlan>();
                InsurancePlan Payer = new InsurancePlan();

                int Rowindex = row.RowIndex;
                int CarrierID = Convert.ToInt32(grdPayer.Rows[Rowindex].Cells[10].Text);
                insList = insMngr.GetInsurancebyCarrierID(Convert.ToUInt64(CarrierID));
                if (insList != null && insList.Count > 0 && grdPayer.Rows[Rowindex].Cells[8].Text != null)
                {
                    Payer = (from h in insList where h.Id == Convert.ToUInt64(grdPayer.Rows[Rowindex].Cells[8].Text) select h).ToList()[0];
                }
                txtInsPlanName.Text = Payer.Ins_Plan_Name;
                txtStreetAddress1.Text = Payer.Payer_Addrress1;
                msktxtOfficeNum.Text = Payer.Office_Number;
                txtStreetAddress2.Text = Payer.Payer_Addrress2;
                Carrier objcarrier = CarrierMngr.GetCarrierUsingId(Convert.ToUInt64(Payer.Carrier_ID));
                if (objcarrier != null)
                {
                    for (int i = 0; i < ddlCarrierName.Items.Count; i++)
                    {
                        if (ddlCarrierName.Items[i].Text.ToUpper() == objcarrier.Carrier_Name.ToUpper())
                        {
                            ddlCarrierName.SelectedIndex = i;
                        }
                    }

                }
                //for (int i = 0; i < cboCarrierId.Items.Count; i++)
                //{
                //    if (cboCarrierId.Items[i].Text.ToUpper() == Payer.Carrier_ID.ToString().ToUpper())
                //    {
                //        cboCarrierId.Text = Payer.Carrier_ID.ToString();
                //        cboCarrierName.SelectedIndex = i;
                //    }
                //}
                //cboCarrierName.Text = Payer.Ins_Plan_Name;
                txtCity.Text = Payer.Payer_City;
                if (Payer.Payer_State!=string.Empty)
                {
                    for (int i = 0; i < ddlState.Items.Count; i++)
                    {
                        if (ddlState.Items[i].Text.ToUpper() == Payer.Payer_State.ToUpper())
                        {
                            ddlState.SelectedIndex = i;
                        }
                    }
                    //ddlState.Text = Payer.Payer_State;
                }
               
                txtPlanNo.Text = Payer.External_Plan_Number;
                msktxtZip.Text = Payer.Payer_Zip;
                for (int i = 0; i < ddlFinancialClassId.Items.Count; i++)
                {
                    if (ddlFinancialClassId.Items[i].Text.ToUpper() == Payer.Financial_Class_Name.ToUpper())
                    {
                        ddlFinancialClassId.SelectedIndex = i;
                    }
                }
                msktxtTelephone.Text = Payer.Payer_Phone_Number;
                txtPayerId.Text = Payer.Id.ToString();
                for (int i = 0; i < ddlGovtType.Items.Count; i++)
                {
                    if (ddlGovtType.Items[i].Text.ToUpper() == Payer.Govt_Type.ToUpper())
                    {
                        ddlGovtType.SelectedIndex = i;
                    }
                }

                txtPayerNotes.Text = Payer.Payer_Notes;
            }
            else if (e.CommandName == "DeleteRow")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                InsurancePlan Payer = new InsurancePlan();
                PayerLibraryDTO payerlist = new PayerLibraryDTO();
                int Rowindex = row.RowIndex;
                int CarrierID = Convert.ToInt32(grdPayer.Rows[Rowindex].Cells[10].Text);
                IList<InsurancePlan> insList = insMngr.GetInsurancebyCarrierID(Convert.ToUInt64(CarrierID));
                if (insList != null && insList.Count > 0 && grdPayer.Rows[Rowindex].Cells[8].Text != null)
                {
                    IList<InsurancePlan> DelList = (from h in insList where h.Id == Convert.ToUInt64(grdPayer.Rows[Rowindex].Cells[8].Text) select h).ToList<InsurancePlan>();
                    if (DelList.Count > 0 && DelList != null)
                    {
                        Payer = DelList[0];
                        Payer.Modified_By = ClientSession.UserName;
                        Payer.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                        //Payer.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                        //Payer.Id = Convert.ToUInt64(grdPayer.Rows[e.RowIndex].Cells["PayerID"].Value);
                        payerlist = insMngr.DeleteInsurancePlan(Payer, PageNumber, 25, string.Empty);
                        //ApplicationObject.erroHandler.DisplayErrorMessage("660006", "Payer LIbrary", this.Page);
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Payer Library", "DisplayErrorMessage('660006');", true);

                        TotalCount = payerlist.InsurancePlanListCount;

                        hdnTotalCount.Value = payerlist.InsurancePlanListCount.ToString();
                        pageCount = Convert.ToInt32(GetTotalNoofDBRecords());
                        LoadGrid(payerlist.InsurancePlanList);
                        RefreshPageButtons();
                        //ClearAll();
                        btnAdd.Text = "Add";
                        btnAdd.Enabled = false;

                    }
                }

            }
        }

        public void FillPayer()
        {
            PayerLibraryDTO payerlist = new PayerLibraryDTO();
            int CarrierId = 0;
            if (ddlCarrierName.Text != string.Empty)
            {
                CarrierId = Convert.ToInt32(ddlCarrierName.Items[ddlCarrierName.SelectedIndex].Value);
            }


            payerlist = insMngr.GetInsuranceList(CarrierId, PageNumber, 25);
            TotalCount = payerlist.InsurancePlanListCount;

            hdnTotalCount.Value = payerlist.InsurancePlanListCount.ToString();
            pageCount = Convert.ToInt32(GetTotalNoofDBRecords());
            LoadGrid(payerlist.InsurancePlanList);

            Session["PageCount"] = pageCount;
            RefreshPageButtons();
            btnAdd.Enabled = true;
        }

        protected void ddlClaimState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            if (btnClearAll.Text == "Clear All")
            {
                //if (iclearMsg == ApplicationObject.erroHandler.DisplayErrorMessage("660011", this.Text))
                //{
                ClearAll();
                btnAdd.Text = "Add";
                btnClearAll.Text = "Clear All";
                ddlCarrierName.SelectedIndex = 0;

                grdPayer.DataSource = null;
                grdPayer.DataBind();
                lblShowing.Text = string.Empty;
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                //mpnPayer.PageNumber = 1;
                //mpnPayer.TotalNoofDBRecords = 0;
                ddlClaimState.SelectedIndex = 0;
                txtClaimAddress.Text = string.Empty;
                ddlGovtType.SelectedIndex = 0;
                txtClaimAttention.Text = string.Empty;
                txtClaimCity.Text = string.Empty;
                txtClaimZipCode.Text = string.Empty;
                btnAdd.Enabled = false;

                //}
            }
            if (btnClearAll.Text == "Cancel")
            {
                //if (iclearMsg == ApplicationObject.erroHandler.DisplayErrorMessage("660012", this.Text))
                //{
                ClearAll();
                btnAdd.Text = "Add";
                btnClearAll.Text = "Clear All";
                // btnAdd.Enabled = false;
                //}
            }
        }

        //Commanted by Gopal T - 20140115

        protected void btnCarrierLibrary_Click(object sender, EventArgs e)
        {
            ddlCarrierName.Items.Clear();
            LoadComboBox();
            //  btnAdd.Enabled = false;
            btnFirst.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnPrevious.Enabled = false;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlCarrierName.Items.Clear();
            LoadComboBox();
            btnAdd.Enabled = false;//uncommented by Viji
            btnFirst.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnPrevious.Enabled = false;;
        }




    }
}
