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
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Runtime.Serialization;
using System.IO;

namespace Acurus.Capella.UI
{
    public partial class frmMedicationManager : SessionExpired
    {
        #region Declaration

        //IList<string> ilstproblem = new List<string>();
        IList<string> iLoincList = new List<string>();
        //IList<string> iProblemList = new List<string>();
        IList<string> iFreqIcdList = new List<string>();

        string sAllIcdlist = string.Empty;
        string sFrequenIcd = string.Empty;
        string sSearchType = string.Empty;
        string strRule = string.Empty;
        string sFinalproblemlist = string.Empty;

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            sSearchType = Request["SearchType"].ToString();

            if (!IsPostBack)
            {
                btnClear.Attributes.Add("OnClick", "btnClear('" + btnClear.ID + ",ProblemList" + "')");
                btnCancel.Attributes.Add("OnClick", "btnCancel('" + btnCancel.ID + "')");
                if (sSearchType == "GenerateListMedication")
                {
                    lblMedicationName.Attributes.Add("descName", sSearchType);
                    grdMedicationList.Columns[2].HeaderText = "Medicine";
                }
                else
                    if (sSearchType == "MedicationAllergy")
                    {
                        lblMedicationName.Attributes.Add("descName", sSearchType);
                        grdMedicationList.Columns[2].HeaderText = "Allergy";
                    }
            }
            //btnUncheckAll.Visible = false;

            if (sSearchType == "ProblemList")
            {
                this.Title = "Problem List";
                tblMedication.Visible = false;
                grdMedicationList.Height = Unit.Pixel(540);
                pnlMedication.Controls.Add(pnlGrid);
                FillGrid();
                btnClear.Text = "Clear All";

                StaticLookupManager objStaticLookupMgr = new StaticLookupManager();
                IList<StaticLookup> staticList = objStaticLookupMgr.getStaticLookupByFieldName("ICD VERSION");
                if (staticList != null && staticList.Count > 0)
                {
                    for (int i = 0; i < staticList.Count; i++)
                        cboICD910.Items.Add(new RadComboBoxItem(staticList[i].Value));
                    cboICD910.SelectedValue = staticList[0].Default_Value;
                }
            }

            else if (sSearchType == "Medication_Aler")
            {
                form1.Style.Add(HtmlTextWriterStyle.Width, "600px");
                Title = "Medication Manager";
                searchTable.Visible = false;
                pnlGrid.GroupingText = "Medication List";
                grdMedicationList.Columns[1].Visible = false;
                if (!IsPostBack)
                {
                    grdMedicationList.DataSource = new string[] { };
                    grdMedicationList.DataBind();
                }
            }
            else if (sSearchType == "Medication")
            {
                form1.Style.Add(HtmlTextWriterStyle.Width, "600px");
                Title = "Medication Manager";
                searchTable.Visible = false;
                pnlGrid.GroupingText = "Medication List";
                grdMedicationList.Columns[1].Visible = false;
                if (!IsPostBack)
                {
                    grdMedicationList.DataSource = new string[] { };
                    grdMedicationList.DataBind();
                }
            }
            else if (sSearchType == "LabResult")
            {
                form1.Style.Add(HtmlTextWriterStyle.Width, "600px");
                Title = "Lab Result Manager";
                searchTable.Visible = false;
                pnlGrid.GroupingText = "Lab Result";
                lblMedicationName.Text = "Enter a Lab Result Name";
                grdMedicationList.Columns[1].HeaderText = "Loinc Number";
                (grdMedicationList.Columns[1] as GridBoundColumn).DataField = "Loinc Number";
                grdMedicationList.Columns[2].HeaderText = "Lab Result Name";
                (grdMedicationList.Columns[2] as GridBoundColumn).DataField = "Lab Result Name";
                if (!IsPostBack)
                {
                    grdMedicationList.DataSource = new string[] { };
                    grdMedicationList.DataBind();
                }
            }
            else if (sSearchType == "Rule")
            {
                form1.Style.Add(HtmlTextWriterStyle.Width, "600px");
                Title = "Find Rule";
                searchTable.Visible = false;
                pnlGrid.GroupingText = "Rule List";
                grdMedicationList.Columns[1].HeaderText = "Rule Name";
                (grdMedicationList.Columns[1] as GridBoundColumn).DataField = "Rule Name";
                lblMedicationName.Text = "Enter Rule Name";


                grdMedicationList.Columns[0].Display = false;

                if (!IsPostBack)
                {
                    grdMedicationList.DataSource = new string[] { };
                    grdMedicationList.DataBind();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (sSearchType == "ProblemList")
            {
                chklstSearchICD.Items.Clear();

                AllICD_9Manager objAllICDMgr = new AllICD_9Manager();

                IList<AllICD_9> listAfterSearch = new List<AllICD_9>();

                string descrp = txtEnterDescription.Text;

                if (txtEnterDescription.Text.Contains(' '))
                    descrp = txtEnterDescription.Text.Replace(' ', '%');

                string icdVersion = string.Empty;
                if (cboICD910.Items.Count > 0)
                    icdVersion = cboICD910.Text;

                if ((txtICDCode.Text != string.Empty) || (descrp != string.Empty))
                    listAfterSearch = objAllICDMgr.GetAllSearchByCODEAndSearchICD_9ForChild("%" + txtICDCode.Text + "%", "%" + descrp + "%", icdVersion);
                else if ((txtICDCode.Text == string.Empty) && (txtEnterDescription.Text == string.Empty))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7040002');", true);
                    lblError.Visible = false;
                    return;
                }

                FillAssesmentList(listAfterSearch);

                lblError.Text = listAfterSearch.Count > 0 ? listAfterSearch.Count + " Result(s) Found" : "No Result(s) Found";
                lblError.Visible = true;
            }
            else
            {
                //if (string.IsNullOrEmpty(txtMedicationName.Text.Trim()))
                // return;

                //mpnMedicationManager.PageNumber = 1;
                //mpnMedicationManager.MaxResultPerPage = 25;

                loadMedicationManager();

                //mpnMedicationManager_Load(sender, e);
            }
            divLoading.Style.Add("display", "none");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string labres = string.Empty;
            string ilistproblem = string.Empty;
            string selectedMedicationsAllergy = string.Empty;

            if (sSearchType == "ProblemList")
            {
                string iProbList = string.Empty;
                for (int i = 0; i < chklstSelectedICD.Items.Count; i++)
                {
                    sFinalproblemlist += chklstSelectedICD.Items[i].ToString() + ";" + Environment.NewLine;
                    if (grdMedicationList.Items.Cast<GridDataItem>().Any(g => g.Cells[1].Text == chklstSelectedICD.Items[i].ToString().Split('-')[0]))
                        ilistproblem += chklstSelectedICD.Items[i].ToString().Split('-')[0] + "|";
                    else
                        //iProblemList.Add(chklstSelectedICD.Items[i].ToString().Split('-')[0]);
                        iProbList += chklstSelectedICD.Items[i].ToString().Split('-')[0] + "|";
                }
                iProblemList.Value = iProbList;
            }
            else if (sSearchType == "Rule")
            {
                //for (int i = 0; i < grdMedicationList.Items.Count; i++)
                //{
                if (grdMedicationList.SelectedItems != null)
                    strRule = grdMedicationList.SelectedItems[0].Cells[5].Text;
                //}
            }

            else
            {
                if (grdMedicationList.Items.Count == 0)
                    return;

                if (grdMedicationList.Columns[0].Visible == true)
                {
                    string selectedMedications = string.Empty;

                    for (int i = 0; i < grdMedicationList.Items.Count; i++)
                    {
                        if (sSearchType == "ProblemList")
                        {
                            if (Convert.ToString(grdMedicationList.Items[i].Cells[0].Text).ToUpper() == "TRUE")
                            {
                                if (iProblemList.Value.Contains(grdMedicationList.Items[i].Cells[1].Text) == false)
                                {
                                    //iProblemList.Add(grdMedicationList.Rows[i].Cells["ICD"].Value.ToString());
                                    ilistproblem += grdMedicationList.Items[i].Cells[1].Text + "|";
                                }
                                sFrequenIcd += grdMedicationList.Items[i].Cells[1].Text + "-" + grdMedicationList.Items[i].Cells[2].Text + ";";
                                iFreqIcdList.Add(sFrequenIcd);
                            }
                        }
                        else if (sSearchType == "Medication" || sSearchType == "Medication_Aler")
                        {
                            if ((grdMedicationList.Items[i].FindControl("chkSelect") as CheckBox).Checked)
                                selectedMedications += grdMedicationList.Items[i].Cells[5].Text + ";";
                        }
                        else if (sSearchType == "LabResult")
                        {
                            if ((grdMedicationList.Items[i].FindControl("chkSelect") as CheckBox).Checked)
                            {
                                iLoincList.Add(grdMedicationList.Items[i].Cells[3].Text + "|" + grdMedicationList.Items[i].Cells[4].Text);

                                if (labres == string.Empty)
                                    labres = grdMedicationList.Items[i].Cells[3].Text + "|" + grdMedicationList.Items[i].Cells[4].Text;
                                else
                                    labres += "+" + grdMedicationList.Items[i].Cells[3].Text + "|" + grdMedicationList.Items[i].Cells[4].Text;
                            }
                        }
                        else if (sSearchType == "GenerateListMedication")
                        {
                            if ((grdMedicationList.Items[i].FindControl("chkSelect") as CheckBox).Checked)
                                selectedMedications += grdMedicationList.Items[i].Cells[4].Text + ";";
                        }
                        else if (sSearchType == "MedicationAllergy")
                        {
                            if ((grdMedicationList.Items[i].FindControl("chkSelect") as CheckBox).Checked)
                                selectedMedications += grdMedicationList.Items[i].Cells[4].Text + ";";
                        }

                    }

                    selectedMedicationList.Value = selectedMedications;
                }


                sFinalproblemlist = sAllIcdlist + sFrequenIcd;
            }

            finalProblemList.Value = sFinalproblemlist;

            ilstproblem.Value = ilistproblem;
            hdnRule.Value = strRule.ToString();
            hdnLabResult.Value = labres.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "closeMedication", "closeMedication()", true);
            //this.Close();
        }

        protected void btnUncheckAll_Click(object sender, EventArgs e)
        {
            int yes = 1;//ApplicationObject.erroHandler.DisplayErrorMessage("7040004", this.Text);

            if (yes == 1)
            {
                chklstSelectedICD.Items.Clear();

                for (int j = 0; j < chklstSearchICD.Items.Count; j++)
                    chklstSearchICD.Items[j].Selected = false;

                for (int g = 0; g < grdMedicationList.Items.Count; g++)
                    (grdMedicationList.Items[g].FindControl("chkSelect") as CheckBox).Checked = false;
            }
        }

        protected void chklstSearchICD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sSearchType == "ProblemList")
            {
                CheckBoxList clbICD = (CheckBoxList)sender;

                if (clbICD == null)
                    return;

                string value = string.Empty;
                string result = Request.Form["__EVENTTARGET"];
                string[] checkedBox = result.Split('$');
                int index = int.Parse(checkedBox[checkedBox.Length - 1]);

                if (chklstSelectedICD.Items.Count > 3 && clbICD.Items[index].Selected)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7040003');", true);

                    if (clbICD.Items[index].Selected)
                        clbICD.Items[index].Selected = false;

                    return;
                }

                if (clbICD.Items[index].Selected && !chklstSelectedICD.Items.Cast<ListItem>().Select(s => s.Text.Split('-')[0]).ToList().Contains(clbICD.Items[index].ToString().Split('-')[0]))
                    chklstSelectedICD.Items.Add(clbICD.Items[index]);
                else if (!clbICD.Items[index].Selected && chklstSelectedICD.Items.Cast<ListItem>().Select(s => s.Text.Split('-')[0]).ToList().Contains(clbICD.Items[index].ToString().Split('-')[0]))
                    chklstSelectedICD.Items.RemoveAt(chklstSelectedICD.Items.Cast<ListItem>().Select((val, idx) => new { item = val, index = idx }).First(s => s.item.Text.Split('-')[0] == clbICD.Items[index].ToString().Split('-')[0]).index);

                for (int j = 0; j < grdMedicationList.Items.Count; j++)
                {
                    if (grdMedicationList.Items[j].Cells[2].Text == clbICD.Items[index].ToString().Split('-')[0])
                    {
                        (grdMedicationList.Items[j].FindControl("chkSelect") as CheckBox).Checked = false;
                        break;
                    }
                }
            }
        }

        protected void chklstSelectedICD_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList clbSelectedICD = (CheckBoxList)sender;

            if (clbSelectedICD == null)
                return;

            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (!clbSelectedICD.Items[index].Selected)
            {
                int yes = 1;// ApplicationObject.erroHandler.DisplayErrorMessage("7040001", this.Text);

                if (yes == 1)
                {
                    for (int i = 0; i < chklstSearchICD.Items.Count; i++)
                    {
                        if (chklstSearchICD.Items[i].ToString().Split('-')[0] == clbSelectedICD.Items[index].Value.ToString().Split('-')[0])
                        {
                            chklstSearchICD.Items[i].Selected = false;
                            break;
                        }
                    }

                    for (int j = 0; j < grdMedicationList.Items.Count; j++)
                    {
                        if (grdMedicationList.Items[j].Cells[3].Text == clbSelectedICD.Items[index].Value.ToString().Split('-')[0])
                        {
                            (grdMedicationList.Items[j].FindControl("chkSelect") as CheckBox).Checked = false;
                            break;
                        }
                    }

                    clbSelectedICD.Items.RemoveAt(index);
                }
                else
                    chklstSearchICD.Items[index].Selected = true;
            }
        }

        protected void chkSelect_checkedChanged(object sender, EventArgs e)
        {
            if (sSearchType == "ProblemList")
            {
                CheckBox chkBox = sender as CheckBox;

                if (chkBox.Checked && chklstSelectedICD.Items.Count >= 4)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7040003');", true);
                    chkBox.Checked = false;
                    return;
                }

                GridDataItem dataItem = (GridDataItem)chkBox.NamingContainer;

                ListItem lstItem = new ListItem();
                lstItem.Text = dataItem.Cells[3].Text + "-" + dataItem.Cells[4].Text;
                lstItem.Selected = chkBox.Checked;

                if (chkBox.Checked && !chklstSelectedICD.Items.Cast<ListItem>().Select(s => s.Text.Split('-')[0]).ToList().Contains(dataItem.Cells[3].Text))
                    chklstSelectedICD.Items.Add(lstItem);
                else if (!chkBox.Checked && chklstSelectedICD.Items.Cast<ListItem>().Select(s => s.Text.Split('-')[0]).ToList().Contains(dataItem.Cells[3].Text))
                    chklstSelectedICD.Items.RemoveAt(chklstSelectedICD.Items.Cast<ListItem>().Select((val, idx) => new { item = val, index = idx }).First(s => s.item.Text.Split('-')[0] == dataItem.Cells[3].Text).index);

                for (int i = 0; i < chklstSearchICD.Items.Count; i++)
                {
                    if (chklstSearchICD.Items[i].ToString().Split('-')[0] == dataItem.Cells[3].Text)
                    {
                        chklstSearchICD.Items[i].Selected = false;
                        break;
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "closeMedicationManager", "window.close()", true);
        }

        #endregion

        #region Methods

        private void loadMedicationManager()
        {
            var serializer = new NetDataContractSerializer();

            if (sSearchType == "Medication")
            {
                All_DrugManager objAll_DrugManager = new All_DrugManager();

                Stream objMedicationListStream = objAll_DrugManager.SearchMedication(txtMedicationName.Text, 1, 25);

                object objMedicationListStreamMgr = (object)serializer.ReadObject(objMedicationListStream);

                Hashtable hsFindMedication = (Hashtable)objMedicationListStreamMgr;

                IList<string> MedicationList = (IList<string>)hsFindMedication["MedicationList"];

                //if (hsFindMedication.ContainsKey("TotalCount") == true)
                //    mpnMedicationManager.TotalNoofDBRecords = (int)hsFindMedication["TotalCount"];

                LoadGrid(MedicationList);
            }
            if (sSearchType == "Medication_Aler")
            {
                All_DrugManager objAll_DrugManager = new All_DrugManager();

                Stream objMedicationListStream = objAll_DrugManager.SearchMedication_Alerg(txtMedicationName.Text, 1, 25);

                object objMedicationListStreamMgr = (object)serializer.ReadObject(objMedicationListStream);

                Hashtable hsFindMedication = (Hashtable)objMedicationListStreamMgr;

                IList<string> MedicationList = (IList<string>)hsFindMedication["MedicationList"];

                //if (hsFindMedication.ContainsKey("TotalCount") == true)
                //    mpnMedicationManager.TotalNoofDBRecords = (int)hsFindMedication["TotalCount"];

                LoadGrid(MedicationList);

            }

            else if (sSearchType == "GenerateListMedication")
            {
                All_DrugManager objAll_DrugManager = new All_DrugManager();

                Stream objMedicationList = objAll_DrugManager.SearchMedicationList(txtMedicationName.Text, 1, 25);

                object objMedicationListMgr = (object)serializer.ReadObject(objMedicationList);

                Hashtable hsFindMedicationList = (Hashtable)objMedicationListMgr;

                IList<string> MedicationList = (IList<string>)hsFindMedicationList["MedicationList"];

                //if (hsFindMedication.ContainsKey("TotalCount") == true)
                //    mpnMedicationManager.TotalNoofDBRecords = (int)hsFindMedication["TotalCount"];

                LoadGridForList(MedicationList);
            }
            else if (sSearchType == "MedicationAllergy")
            {
                All_DrugManager objAll_DrugManager = new All_DrugManager();

                Stream objMedicationAllergy = objAll_DrugManager.SearchMedicationAllergy(txtMedicationName.Text, 1, 25);

                object objMedicationAllergyMgr = (object)serializer.ReadObject(objMedicationAllergy);

                Hashtable hsFindMedicationAllergy = (Hashtable)objMedicationAllergyMgr;

                IList<string> MedicationAllergy = (IList<string>)hsFindMedicationAllergy["MedicationList"];

                //if (hsFindMedication.ContainsKey("TotalCount") == true)
                //    mpnMedicationManager.TotalNoofDBRecords = (int)hsFindMedication["TotalCount"];

                LoadGridForAllergy(MedicationAllergy);
            }
            else if (sSearchType == "LabResult")
            {
                // LoincManager objLoincManager = new LoincManager();
                ResultOBXManager objResultOBXManager = new ResultOBXManager();

                Stream objPatientReminderStream = objResultOBXManager.GetLoincValuesForLongName(txtMedicationName.Text, 1, 25);

                object objPatientReminderStreamMgr = (object)serializer.ReadObject(objPatientReminderStream);

                Hashtable hsFindLoinc = (Hashtable)objPatientReminderStreamMgr;

                IList<ResultOBX> LoincList = (IList<ResultOBX>)hsFindLoinc["LoincList"];

                //   LoincList=  LoincList.Distinct();
                //if (hsFindLoinc.ContainsKey("TotalCount") == true)
                //mpnMedicationManager.TotalNoofDBRecords = (int)hsFindLoinc["TotalCount"];

                LoadGridForLoinc(LoincList);
            }
            else if (sSearchType == "Rule")
            {
                RuleMasterManager objRuleMasterManager = new RuleMasterManager();

                Stream objPatientReminderStream = objRuleMasterManager.SearchRuleName(txtMedicationName.Text, 1, 25,ClientSession.LegalOrg);

                object objPatientReminderStreamMgr = (object)serializer.ReadObject(objPatientReminderStream);

                Hashtable hsFindRule = (Hashtable)objPatientReminderStreamMgr;

                IList<string> ruleList = (IList<string>)hsFindRule["RuleList"];

                //if (hsFindRule.ContainsKey("TotalCount") == true)
                //    mpnMedicationManager.TotalNoofDBRecords = (int)hsFindRule["TotalCount"];

                LoadGridForRule(ruleList);
            }
        }

        public void FillAssesmentList(IList<AllICD_9> assList)
        {
            if (assList != null && assList.Count > 0)
            {
                for (int i = 0; i < assList.Count; i++)
                {
                    ListItem lvItem = new ListItem();
                    lvItem.Text = assList[i].ICD_9.ToString() + "-" + assList[i].ICD_9_Description.ToString();

                    if (!chklstSearchICD.Items.Contains(lvItem))
                        chklstSearchICD.Items.Add(assList[i].ICD_9.ToString() + "-" + assList[i].ICD_9_Description.ToString());
                }
            }
        }

        private void FillGrid()
        {
            IList<StaticLookup> ilstFieldLookup = new List<StaticLookup>();

            StaticLookupManager objStaticLookupMgr = new StaticLookupManager();
            ilstFieldLookup = objStaticLookupMgr.getStaticLookupByFieldName("Frequently Used Icds", "Sort_Order");

            var ilst = (from k in ilstFieldLookup orderby k.Value ascending select k);

            IList<StaticLookup> listFreqIcd = ilst.ToList<StaticLookup>();

            if (listFreqIcd.Count > 0)
            {
                DataTable objDataTable = new DataTable();

                objDataTable.Columns.Add(new DataColumn("ICD", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("Tag", typeof(string)));

                for (int i = 0; i < listFreqIcd.Count; i++)
                {
                    DataRow objDataRow = objDataTable.NewRow();
                    objDataRow["ICD"] = listFreqIcd[i].Value.ToString();
                    objDataRow["Description"] = listFreqIcd[i].Description;
                    objDataRow["Tag"] = listFreqIcd[i];
                    objDataTable.Rows.Add(objDataRow);
                }

                grdMedicationList.DataSource = objDataTable;
                grdMedicationList.DataBind();
            }
        }

        public void View(ref IList<string> MedicationList)
        {
            //ShowDialog();
            //MedicationList = SelectedMedicationList;
        }

        public void ViewLab(ref IList<string> Loinc)
        {
            //ShowDialog();
            //Loinc = iLoincList;
        }

        public void ViewRule(ref string sRule)
        {
            //ShowDialog();
            //sRule = strRule;
        }

        private void LoadGridForRule(IList<string> SearchResult)
        {
            if (SearchResult == null || SearchResult.Count == 0)
            {
                lblResult.Text = "0 Result(s) found   ";
                return;
            }

            lblResult.Text = SearchResult.Count.ToString() + " Result(s) found  ";

            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add(new DataColumn("Rule Name", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Tag", typeof(string)));

            for (int i = 0; i < SearchResult.Count; i++)
            {
                string[] split = SearchResult[i].ToString().Split('|');

                DataRow objDataRow = objDataTable.NewRow();
                objDataRow["Rule Name"] = split[1].ToString();
                objDataRow["Description"] = split[2].ToString();
                objDataRow["Tag"] = SearchResult[i];
                objDataTable.Rows.Add(objDataRow);
            }

            grdMedicationList.DataSource = objDataTable;
            grdMedicationList.DataBind();
        }

        private void LoadGridForLoinc(IList<ResultOBX> LoincLst)
        {
            IList<string> lsttemp = LoincLst.Select(a => a.OBX_Loinc_Identifier).Distinct().ToList();


            if (lsttemp == null || lsttemp.Count == 0)
            {
                lblResult.Text = "0 Result(s) found  ";
                return;
            }

            lblResult.Text = lsttemp.Count.ToString() + " Result(s) found  ";

            DataTable objDataTable = new DataTable();

            objDataTable.Columns.Add(new DataColumn("Loinc Number", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Lab Result Name", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Tag", typeof(string)));

            for (int i = 0; i < lsttemp.Count; i++)
            {
                ResultOBX lst = LoincLst.Where(a => a.OBX_Loinc_Identifier == lsttemp[i]).First();
                DataRow objDataRow = objDataTable.NewRow();
                objDataRow["Loinc Number"] = lst.OBX_Loinc_Identifier;
                objDataRow["Lab Result Name"] = lst.OBX_Observation_Text;
                objDataRow["Tag"] = lst.Id;
                objDataTable.Rows.Add(objDataRow);
            }

            grdMedicationList.DataSource = objDataTable;
            grdMedicationList.DataBind();
        }

        private void LoadGrid(IList<string> MedicationList)
        {
            if (MedicationList == null || MedicationList.Count == 0)
            {
                lblResult.Text = "0 Result(s) found  ";
                return;
            }

            lblResult.Text = MedicationList.Count.ToString() + " Result(s) found  ";

            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add(new DataColumn("Select", typeof(bool)));
            objDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Tag", typeof(string)));

            for (int i = 0; i < MedicationList.Count; i++)
            {
                string[] split = MedicationList[i].ToString().Split('+');

                DataRow objDataRow = objDataTable.NewRow();
                objDataRow["Description"] = split[1].ToString();
                objDataRow["Tag"] = MedicationList[i];
                objDataTable.Rows.Add(objDataRow);
            }

            grdMedicationList.DataSource = objDataTable;
            grdMedicationList.DataBind();
        }

        private void LoadGridForList(IList<string> MedicationList)
        {
            if (MedicationList == null || MedicationList.Count == 0)
            {
                lblResult.Text = "0 Result(s) found  ";
                return;
            }

            lblResult.Text = MedicationList.Count.ToString() + " Result(s) found  ";

            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add(new DataColumn("Select", typeof(bool)));
            objDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Tag", typeof(string)));



            for (int i = 0; i < MedicationList.Count; i++)
            {
                //string[] split = MedicationList[i].ToString().Split('+');

                DataRow objDataRow = objDataTable.NewRow();
                objDataRow["Description"] = MedicationList[i].ToString();
                objDataRow["Tag"] = "";
                objDataTable.Rows.Add(objDataRow);
            }

            grdMedicationList.DataSource = objDataTable;
            grdMedicationList.DataBind();
            (grdMedicationList.MasterTableView.GetColumn("Tag") as GridBoundColumn).Display = false;
            (grdMedicationList.MasterTableView.GetColumn("ICD") as GridBoundColumn).Display = false;
            (grdMedicationList.MasterTableView.GetColumn("Description") as GridBoundColumn).HeaderText = "Medicine";

        }



        private void LoadGridForAllergy(IList<string> MedicationList)
        {
            if (MedicationList == null || MedicationList.Count == 0)
            {
                lblResult.Text = "0 Result(s) found  ";
                return;
            }

            lblResult.Text = MedicationList.Count.ToString() + " Result(s) found  ";

            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            objDataTable.Columns.Add(new DataColumn("Tag", typeof(string)));


            for (int i = 0; i < MedicationList.Count; i++)
            {
                //string[] split = MedicationList[i].ToString().Split('+');

                DataRow objDataRow = objDataTable.NewRow();
                objDataRow["Description"] = MedicationList[i].ToString();
                objDataRow["Tag"] = "";
                objDataTable.Rows.Add(objDataRow);
            }

            grdMedicationList.DataSource = objDataTable;
            grdMedicationList.DataBind();
            (grdMedicationList.MasterTableView.GetColumn("Tag") as GridBoundColumn).Display = false;
            (grdMedicationList.MasterTableView.GetColumn("ICD") as GridBoundColumn).Display = false;
            (grdMedicationList.MasterTableView.GetColumn("Description") as GridBoundColumn).HeaderText = "Allergy";
        }

        public void FindProblemList(ref string sProblemlist, ref IList<string> ilstICD, ref IList<string> ilstRetunProblem)
        {
            //ShowDialog();
            //sProblemlist = sFinalproblemlist;
            //ilstICD = iProblemList;
            //ilstRetunProblem = ilstproblem;
        }

        #endregion
    }
}
