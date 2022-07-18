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
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using System.Drawing;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.UI
{
    public partial class frmSearchOrders : System.Web.UI.Page
    {


        LabManager labMngr = new LabManager();
        PhysicianManager phyMngr = new PhysicianManager();
        public IList<string> ListViewHeader
        {
            get
            {
                return (IList<string>)ViewState["ListViewHeader"] ?? new List<string>();
            }
            set
            {
                ViewState["ListViewHeader"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region PhysicianComboFill
                if (ClientSession.UserRole == "Physician" || ClientSession.UserRole == "Physician Assistant")
                {

                    cboPhysician.Enabled = false;
                    chkShowAll.Enabled = false;

                }

                DefaultLabSelection();
                FillLabombo();

                LoadPhysicianCombo();
                if (Request["PhyId"] != null)
                {
                    if (Request["PhyId"].ToString() != string.Empty)
                    {
                        if (cboPhysician.FindItemByValue(Request["PhyId"].ToString()) != null)
                        {
                            cboPhysician.SelectedIndex = cboPhysician.FindItemByValue(Request["PhyId"].ToString()).Index;
                            cboPhysician.Text = cboPhysician.Items[cboPhysician.SelectedIndex].Text;
                        }
                    }
                }
                if (Request["LabName"] != null && Request["LabName"].ToString() != string.Empty && cboPhysician.Text != string.Empty)
                {
                    if (cboLab.FindItemByText(Request["LabName"]) != null)
                    {
                        cboLab.SelectedIndex = cboLab.FindItemByText(Request["LabName"].ToString()).Index;
                        btnGetProcedures_Click(sender, e);
                    }
                }
                /* while Lab name which contains escape sequence's as query string, URL truncated. So Passing Lab ID: Used in Indexing */
                else if (Request["LabID"] != null)
                {
                    cboLab.SelectedValue = Request["LabID"].ToString();
                    btnGetProcedures_Click(sender, e);
                }
                btnOk.Enabled = false;
                #endregion

                if (Request["Screen_Name"] != null)
                    hdnScreenMode.Value = Request["Screen_Name"].ToString();

                if (Request["Screen_Name"] != null && Request["Screen_Name"].ToString() == "Indexing")
                {
                    cboPhysician.Enabled = false;
                    cboLab.Enabled = false;
                    chkShowAll.Visible = false;
                    btnGetProcedures.Visible = false;
                    lblSelectPhysician.Text = "Physician";
                    lblSelectPhysician.ForeColor = Color.Black; 
                    lblLabName.ForeColor = Color.Black;
                    lblLabName.Text = "Lab Name";

                    
                }
            }
        }



        protected void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            FillPhysicianUser PhyUserList;
            cboPhysician.Items.Clear();
            cboPhysician.Items.Add(new RadComboBoxItem(""));
            int iIter = 0;
            if (chkShowAll.Checked == true)
            {
                PhyUserList = phyMngr.GetPhysicianandUser(false, string.Empty, ClientSession.LegalOrg);

            }
            else
            {
                PhyUserList = phyMngr.GetPhysicianandUser(true, ClientSession.FacilityName, ClientSession.LegalOrg);
            }

            for (int i = 0; i < PhyUserList.PhyList.Count; i++)
            {
                string sPhyName = PhyUserList.PhyList[i].PhyPrefix + " " + PhyUserList.PhyList[i].PhyFirstName + " " + PhyUserList.PhyList[i].PhyMiddleName + " " + PhyUserList.PhyList[i].PhyLastName + " " + PhyUserList.PhyList[i].PhySuffix;
                cboPhysician.Items.Add(new RadComboBoxItem(PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName));
                cboPhysician.Items[iIter].Value = PhyUserList.PhyList[i].Id.ToString();
                cboPhysician.Items[iIter].ToolTip = cboPhysician.Items[i].Text;

                if (Convert.ToUInt64(cboPhysician.Items[iIter].Value) == ClientSession.PhysicianId)
                {
                    cboPhysician.SelectedIndex = iIter + 1;
                }
                else
                {
                    cboPhysician.SelectedIndex = 0;
                }
                iIter = iIter + 1;

            }
            if (chkShowAll.Checked == true)
            {
                var phyName = from p in PhyUserList.PhyList where (p.Id == ClientSession.PhysicianId) select p;
                if (phyName.Count() != 0)
                {
                    string PhysicianName = phyName.ToList<PhysicianLibrary>()[0].PhyPrefix + " " + phyName.ToList<PhysicianLibrary>()[0].PhyFirstName + " " + phyName.ToList<PhysicianLibrary>()[0].PhyMiddleName + " " + phyName.ToList<PhysicianLibrary>()[0].PhyLastName + " " + phyName.ToList<PhysicianLibrary>()[0].PhySuffix;
                    if (ClientSession.UserRole.ToUpper() == "PHYSICIAN" || ClientSession.UserRole.ToUpper() == "PHYSICIAN ASSISTANT")
                    {
                        cboPhysician.Text = ClientSession.UserName + " - " + PhysicianName;
                    }
                    else if (ClientSession.UserRole.ToUpper() == "MEDICAL ASSISTANT")
                    {
                        cboPhysician.Text = (from c in PhyUserList.UserList where c.Physician_Library_ID == ClientSession.PhysicianId select c.user_name).ToList<string>()[0].ToString() + " - " + PhysicianName;
                    }
                }
            }
        }



        protected void btnGetProcedures_Click(object sender, EventArgs e)
        {
            if (cboPhysician.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('8407002');", true);
                // ApplicationObject.erroHandler.DisplayErrorMessage("8407002", this.Text);
                return;
            }
            else if (cboLab.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('8407003');", true);
                // ApplicationObject.erroHandler.DisplayErrorMessage("8407003", this.Text);
                return;
            }
            else
            {
                IList<PhysicianProcedure> procedureList = new List<PhysicianProcedure>();
                PhysicianProcedureManager phyProcMngr = new PhysicianProcedureManager();
                string ProcedureType = string.Empty;
                if (Request["OrderType"] != null)
                {
                    ProcedureType = "LAB PROCEDURE";
                }
                if (Request["PhyId"] == null)
                {
                    procedureList = phyProcMngr.GetProceduresUsingPhysicianIDAndLabID(Convert.ToUInt64(cboPhysician.Items[cboPhysician.SelectedIndex].Value), ProcedureType.ToUpper(), Convert.ToUInt64(cboLab.FindItemByText(cboLab.Text).Value),ClientSession.LegalOrg);
                }
                else if (Request["PhyId"].ToString() == string.Empty)
                {
                    procedureList = phyProcMngr.GetProceduresUsingPhysicianIDAndLabID(Convert.ToUInt64(cboPhysician.Items[cboPhysician.SelectedIndex].Value), ProcedureType.ToUpper(), Convert.ToUInt64(cboLab.FindItemByText(cboLab.Text).Value), ClientSession.LegalOrg);
                }
                else
                {
                    procedureList = phyProcMngr.GetProceduresUsingPhysicianIDAndLabID(Convert.ToUInt64(Request["PhyId"]), ProcedureType.ToUpper(), Convert.ToUInt64(cboLab.SelectedItem.Value), ClientSession.LegalOrg);
                }
                //Added by priyangha 0on 31/1/2013 Bugid:14092
                if (procedureList.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('8407005');", true);
                    //int i = ApplicationObject.erroHandler.DisplayErrorMessage("8407005", this.Text);
                }

                FillLabProcedure(procedureList, new List<string>());
            }
        }
        void DefaultLabSelection()
        {
            HumanManager humanMngr = new HumanManager();
            LabInsurancePlanManager labInsMngr = new LabInsurancePlanManager();
            string LabType = string.Empty;
            IList<ulong> LabIdBasedOnInsID = new List<ulong>();
            if (HttpUtility.HtmlDecode(Request.QueryString["OrderType"].ToUpper()) == "DIAGNOSTIC ORDER")
            {
                LabType = "LAB";
            }

            if (Request["MyHumanID"] != null)
            {

                IList<ulong> idList = (from pat in humanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(Request["MyHumanID"]))[0].PatientInsuredBag where pat.Insurance_Type.ToUpper() == "PRIMARY" && pat.Active.ToUpper() == "YES" select pat.Insurance_Plan_ID).ToList<ulong>();
                if (idList.Count > 0)
                    LabIdBasedOnInsID = labInsMngr.GetLabIDBasedOnInsPlanID(idList.ToArray<ulong>(), LabType, ClientSession.LegalOrg);
            }
        }
        void FillLabombo()
        {
            cboLab.Items.Clear();
            bool bIsLabSelected = false;
            string LabType = string.Empty;
            IList<Lab> labList = new List<Lab>();
            /* This Screen is being used by both MRE and Indexing, MRE allows to get procedures from Lab whereas Indexing allows to get procedures from all labs */
            if (Request["OrderType"].ToUpper() == "DIAGNOSTIC ORDER" && Request["LabName"] != null)
            {
                LabType = "LAB";
                labList = labMngr.GetLabList().Where(a => a.Lab_Type == LabType.ToUpper().ToString()).ToList<Lab>();
            }
            else
            {
                labList = labMngr.GetLabList().ToList<Lab>();
            }
            RadComboBoxItem cboItem = new RadComboBoxItem();          
            cboItem.Text = " ";
            cboLab.Items.Add(cboItem);
            
            if (labList != null)
            {
                if (labList.Count > 0)
                {
                    int IndexToBeSelected = 0;
                    for (int i = 0; i < labList.Count; i++)
                    {

                        cboItem = new RadComboBoxItem();
                        cboItem.Text = labList[i].Lab_Name;
                        cboItem.Value = labList[i].Id.ToString();
                        cboItem.ToolTip = labList[i].Lab_Name;
                        if (Request["LabName"] != null)
                        {
                            if (labList[i].Lab_Name == Request["LabName"].ToString() && bIsLabSelected == false)
                            {
                                IndexToBeSelected = i;
                                bIsLabSelected = true;
                            }
                        }
                        
                        cboLab.Items.Add(cboItem);
                        //LabOrderAndID.Add(labList[i].Lab_Name, labList[i].Id);
                    }
                    if (bIsLabSelected)
                    {
                        cboLab.SelectedIndex = IndexToBeSelected;
                        cboLab.Text = cboLab.Items[IndexToBeSelected].Text;
                    }
                }
            }
        }
        private void FillLabProcedure(IList<PhysicianProcedure> labProList, IList<string> lstChkeditem)
        {
            IList<PhysicianProcedure> templst = new List<PhysicianProcedure>();
            templst = labProList.Where(a => a.Sort_Order == 0).ToList<PhysicianProcedure>();
            labProList = (labProList.Where(a => a.Sort_Order != 0).OrderBy(a => a.Sort_Order).ToList<PhysicianProcedure>()).Concat(templst).ToList<PhysicianProcedure>();
            IList<string> groupedProce = (from rec in labProList select rec.Order_Group_Name).Distinct().ToList<string>();
            IList<string> ItemsToBeAdded = new List<string>();
            foreach (string str in groupedProce)
            {
                ItemsToBeAdded.Add("!!" + str);

                //ListViewItem objRadListViewItem;
                ////objRadListViewItem = new ListViewItem(ListViewItemType.);
                //objRadListViewItem.ForeColor = Color.Blue;
                //objRadListViewItem.Font = new Font("Arial", 10, FontStyle.Bold);
                //lstvFrequentlyUsedLabProcedures.Items.Add(objRadListViewItem);
                var underthisgroup = (from rec in labProList where rec.Order_Group_Name.ToUpper() == str.ToUpper() select rec).ToList<PhysicianProcedure>();
                foreach (var phypro in underthisgroup)
                {
                    ItemsToBeAdded.Add(phypro.Physician_Procedure_Code + "-" + phypro.Procedure_Description);
                    //    objRadListViewItem = new ListViewItem((phypro.Physician_Procedure_Code + "-" + phypro.Procedure_Description).ToString());
                    //    objRadListViewItem.ForeColor = Color.Black;
                    //    objRadListViewItem.Font = new Font("Arial", 8, FontStyle.Regular);
                    //    objRadListViewItem.ToolTipText = SetToolTipText((phypro.Physician_Procedure_Code + "-" + phypro.Procedure_Description).ToString());
                    //    lstvFrequentlyUsedLabProcedures.Items.Add(objRadListViewItem);

                    //    //lstvFrequentlyUsedLabProcedures.Items.Add((phypro.Physician_Procedure_Code + "-" + phypro.Procedure_Description).ToString());
                }

            }
            int ItemsPerRow = 20;
            decimal tempDouble = ((decimal)ItemsToBeAdded.Count / (decimal)ItemsPerRow);
            int coulumns = (int)(Math.Ceiling(tempDouble));

            ListViewHeader = new List<string>();
            lstvFrequentlyUsedLabProcedures.Items.Clear();
            lstvFrequentlyUsedLabProcedures.RepeatColumns = coulumns;
            IList<int> StringLengthColumn = new List<int>();
            IList<int> maxstringLengthColumnVies = new List<int>();
            string HeaderText = string.Empty;
            if (ItemsToBeAdded.Count < 20)
            {
                lstvFrequentlyUsedLabProcedures.RepeatDirection = RepeatDirection.Vertical;
                lstvFrequentlyUsedLabProcedures.RepeatLayout = RepeatLayout.Flow;
                lstvFrequentlyUsedLabProcedures.Style.Add("ItemHeight", "70");
            }
            else
            {
                lstvFrequentlyUsedLabProcedures.RepeatDirection = RepeatDirection.Vertical;
                lstvFrequentlyUsedLabProcedures.RepeatLayout = RepeatLayout.Table;
            }
            for (int i = 0; i < ItemsToBeAdded.Count; i++)
            {
                ListItem tempItem = new ListItem();

                if (ItemsToBeAdded[i].StartsWith("!!"))
                {
                    tempItem.Text = ItemsToBeAdded[i].ToString().Replace("!!", "");
                    //tempItem.Attributes.Add("Criteria","!!");
                    tempItem.Value = "HEADERROW";
                    //tempItem.Attributes.Add("IsHeader", "true");
                    HeaderText = tempItem.Text;
                    ListViewHeader.Add("IsHeader-true;RespectiveHeader-" + HeaderText);
                    tempItem.Attributes.Add("style", "color:blue");
                    tempItem.Attributes.CssStyle.Add("font-weight", "bold");
                }
                else
                {

                    tempItem.Text = ItemsToBeAdded[i].ToString();
                    if (lstChkeditem.Contains(ItemsToBeAdded[i].ToString()))
                        tempItem.Selected = true;
                    //tempItem.Attributes.Add("IsHeader", "false");
                    ListViewHeader.Add("IsHeader-false;RespectiveHeader-" + HeaderText);
                }

                lstvFrequentlyUsedLabProcedures.Items.Add(tempItem);

            }
        }
        void LoadPhysicianCombo()
        {
            bool IsPhysicianAvailable = false;
            PhysicianManager phyMngr = new PhysicianManager();
            FillPhysicianUser PhyUserList = phyMngr.GetPhysicianandUser(true, ClientSession.FacilityName, ClientSession.LegalOrg);
            cboPhysician.Items.Add(new RadComboBoxItem(""));
            for (int i = 0; i < PhyUserList.PhyList.Count; i++)
            {
                string sPhyName = PhyUserList.PhyList[i].PhyPrefix + " " + PhyUserList.PhyList[i].PhyFirstName + " " + PhyUserList.PhyList[i].PhyMiddleName + " " + PhyUserList.PhyList[i].PhyLastName + " " + PhyUserList.PhyList[i].PhySuffix;
                cboPhysician.Items.Add(new RadComboBoxItem(PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName));
                cboPhysician.Items[i+1].Value = PhyUserList.PhyList[i].Id.ToString();
                if (Request["PhyId"] != null && Request["PhyId"].ToString() != string.Empty)
                {
                    if (Convert.ToUInt64(Request["PhyId"]) == PhyUserList.PhyList[i].Id)
                    {
                        cboPhysician.SelectedIndex = i+1;
                        cboPhysician.SelectedItem.Text = PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName;
                        IsPhysicianAvailable = true;
                    }
                }
                else
                {
                    if (ClientSession.PhysicianId == PhyUserList.PhyList[i].Id && ClientSession.UserCurrentProcess!="MA_PROCESS")
                    {
                        cboPhysician.SelectedIndex = i+1;
                        cboPhysician.SelectedItem.Text = PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName;
                        IsPhysicianAvailable = true;
                    }
                }
            }
            if (Request["PhyId"] != null && Request["PhyId"].ToString() != string.Empty)
            {
                if (!IsPhysicianAvailable && Convert.ToUInt64(Request["PhyId"]) != 0)
                {
                    cboPhysician.Items.Add(new RadComboBoxItem(""));
                    PhyUserList = phyMngr.GetPhysicianandUser(false, string.Empty, ClientSession.LegalOrg);
                    for (int i = 0; i < PhyUserList.PhyList.Count; i++)
                    {
                        string sPhyName = PhyUserList.PhyList[i].PhyPrefix + " " + PhyUserList.PhyList[i].PhyFirstName + " " + PhyUserList.PhyList[i].PhyMiddleName + " " + PhyUserList.PhyList[i].PhyLastName + " " + PhyUserList.PhyList[i].PhySuffix;
                        cboPhysician.Items.Add(new RadComboBoxItem(PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName));
                        cboPhysician.Items[i+1].Value = PhyUserList.PhyList[i].Id.ToString();
                        if (Request["PhyId"] != null && Request["PhyId"].ToString() != string.Empty)
                        {
                            if (Convert.ToUInt64(Request["PhyId"]) == PhyUserList.PhyList[i].Id)
                            {
                                cboPhysician.SelectedIndex = i+1;
                                cboPhysician.SelectedItem.Text = PhyUserList.UserList[i].user_name.ToString() + " - " + sPhyName;

                            }
                        }
                    }
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string YesNoCancel = hdnMessageType.Value;
            hdnMessageType.Value = string.Empty;
            if (lstvFrequentlyUsedLabProcedures.SelectedItem != null)
            {


                foreach (ListItem itm in lstvFrequentlyUsedLabProcedures.Items)
                {
                    if (itm.Selected == true && !hdnSelectedItem.Value.Contains(itm.Text))
                    {
                        if (hdnSelectedItem.Value == string.Empty)
                        {
                            hdnSelectedItem.Value = itm.Text;
                        }
                        else
                        {
                            hdnSelectedItem.Value += "|" + itm.Text;
                        }
                    }
                }
                hdnLabName.Value = cboLab.Text;
                hdnPhyID.Value = cboPhysician.Items[cboPhysician.FindItemByText(cboPhysician.Text).Index].Value;
                hdnLabID.Value = cboLab.Items[cboLab.SelectedIndex].Value;
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "CloseWithOK();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "ValidateProc();;", true);
            }
        }
        protected void chklstFrequentlyUsedProcedures_PreRender(object sender, EventArgs e)
        {
            for (int i = 0; i < ListViewHeader.Count; i++)
            {
                lstvFrequentlyUsedLabProcedures.Items[i].Attributes.Add(ListViewHeader[i].Split(';')[0].Split('-')[0], ListViewHeader[i].Split(';')[0].Split('-')[1]);
                lstvFrequentlyUsedLabProcedures.Items[i].Attributes.Add(ListViewHeader[i].Split(';')[1].Split('-')[0], ListViewHeader[i].Split(';')[1].Split('-')[1]);

            }
        }


        protected void InvisibleButton_Click(object sender, EventArgs e)
        {
            if (hdnTransferVaraible.Value != null)
            {
                IList<string> lstChkeditem = new List<string>();
                for (int i = 0; i < lstvFrequentlyUsedLabProcedures.Items.Count; i++)
                {
                    if (lstvFrequentlyUsedLabProcedures.Items[i].Selected)
                        lstChkeditem.Add(lstvFrequentlyUsedLabProcedures.Items[i].Text.ToString());
                }
                IList<string> selectedCodes = new List<string>();
                IList<PhysicianProcedure> Originallist = new List<PhysicianProcedure>();
                string[] MovedProcedures = hdnTransferVaraible.Value.ToString().Split('|');
                ulong selectedLabID = Convert.ToUInt64(cboLab.Items[cboLab.FindItemByText(cboLab.Text).Index].Value);
                IList<PhysicianProcedure> procedureList = new List<PhysicianProcedure>();
                EAndMCodingManager objEAndMCodingManager = new EAndMCodingManager();

                procedureList = objEAndMCodingManager.GetPhysicianProcedure(Convert.ToUInt64(cboPhysician.FindItemByText(cboPhysician.Text).Value), "LAB PROCEDURE", selectedLabID, ClientSession.LegalOrg);
                foreach (string s in MovedProcedures)
                {
                    if (!selectedCodes.Contains(s))
                        selectedCodes.Add(s);

                }
                ListItem objListViewItem = new ListItem();
                objListViewItem.Text = "OTHER";
                if (lstvFrequentlyUsedLabProcedures.Items.Contains(objListViewItem) == false)
                    lstvFrequentlyUsedLabProcedures.Items.Add(objListViewItem);
                //sbtnAllProceduresClick = true;
                Originallist = new List<PhysicianProcedure>();
                Originallist = new List<PhysicianProcedure>(procedureList);
                PhysicianProcedure objPhysicianProcedure;
                foreach (string str in selectedCodes.Concat(lstChkeditem))
                {
                    string[] SplitStr = str.Split('-');
                    objPhysicianProcedure = new PhysicianProcedure();
                    objPhysicianProcedure.Physician_Procedure_Code = SplitStr[0].ToString();
                    for (int i = 1; i < SplitStr.Count(); i++)
                    {
                        if (i == 1)
                            objPhysicianProcedure.Procedure_Description = SplitStr[i];
                        else
                            objPhysicianProcedure.Procedure_Description += "-" + SplitStr[i];
                    }
                    objPhysicianProcedure.Order_Group_Name = "OTHER";
                    if (!Originallist.Any(a => a.Physician_Procedure_Code == str.Split('-')[0]))
                        Originallist.Add(objPhysicianProcedure);

                }
                FillLabProcedure(Originallist, selectedCodes.Concat(lstChkeditem).ToList<string>());
                hdnTransferVaraible.Value = string.Empty;
                btnOk.Enabled = true;
            }
        }
    }
}
