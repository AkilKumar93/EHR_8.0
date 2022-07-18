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
using Telerik.Web.UI;
using Acurus.Capella.Core.DTO;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.UI
{
    public partial class frmSpecialityDiagnosis : SessionExpired
    {
        #region Declaration
        AllICD_9Manager objAllICD_9Manager = new AllICD_9Manager();
        AssociatedPrimaryICDManager objAssessmentQuestionsMgr = new AssociatedPrimaryICDManager();      
        IList<RadTreeNode> selectedNodesDTO = new List<RadTreeNode>();
        IList<AllICD_9> listAfterSearch = new List<AllICD_9>();
        IList<AssociatedPrimaryICD> listAssociatedCodes = new List<AssociatedPrimaryICD>();
        string sourceScreen = string.Empty;
        IDictionary<string, string> IDictionaryICDs = new Dictionary<string, string>();
        StaticLookupManager objStaticLookupMgr = new StaticLookupManager();        
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {         
            //this.Title += "-" + ClientSession.UserName;
            if (Request["sourceScreen"] != null)
                sourceScreen = Request["sourceScreen"].ToString();
            int treeviewHgt = 0;
            int treeviewWdt = 0;
            if (Request.Cookies["trvCodeLibHgt"] != null && int.TryParse(Request.Cookies["trvCodeLibHgt"].Value, out treeviewHgt))
                trvCodeLibrary.Height = Unit.Pixel(treeviewHgt);
            if (Request.Cookies["trvCodeLibWdt"] != null && int.TryParse(Request.Cookies["trvCodeLibWdt"].Value, out treeviewWdt))
                trvCodeLibrary.Width = Unit.Pixel(treeviewWdt);
            if (!IsPostBack)
            {
                ClientSession.processCheck = false;
                SecurityServiceUtility objSecurityServiceUtility = new SecurityServiceUtility();
                objSecurityServiceUtility.ApplyUserPermissions(this);
                lblError1.Visible = false;
                txtDescription.Focus();

                if (sourceScreen.ToUpper() == "SELECTED")
                    btnMoveToSelectedAssessment.Text = "Move to Selected Assessment";
                else if (sourceScreen.ToUpper() == "RULED OUT")
                    btnMoveToSelectedAssessment.Text = "Move to Ruled Out Assessment";
                else if (sourceScreen.ToUpper() == "GENERATE PATIENT LISTS" || sourceScreen.ToUpper() == "E AND M CODE" || sourceScreen == "PATIENT REMINDER" || sourceScreen == "ORDERS" || sourceScreen.ToUpper() == "ICD10" || sourceScreen.ToUpper() == "MEDICATION")
                {
                    btnMoveToSelectedAssessment.Text = "OK";
                    hdnEandMCode.Value = "EandMCode";
                }
                else if (sourceScreen.ToUpper() == "MANAGE PROBLEM LIST")              
                    btnMoveToSelectedAssessment.Text = "Move to manage problem list";               
                Session.Add("Selected_ICDs", new List<string>());              
                btnMoveToSelectedAssessment.Enabled = false;
            }
        }
        protected void btnMoveToSelectedAssessment_Click(object sender, EventArgs e)
        {
            Session.Remove("IsRefresh");
            Session.Remove("lblQueryString");
            Session.Remove("CheckedItem");
            Session.Remove("MutualExclusive");
            Session.Remove("PreviousData");
            Session.Remove("CheckExclusive");
            Session.Remove("questionCheck");
            Session.Remove("ContinueList");
            Session.Remove("lblQuestionList");
            Session.Remove("sDiplayQuestionList");
            Session.Remove("sDisplayLabel");
            Session.Remove("cDisplayQuestion");
            Session.Remove("sDiplayQuestionList");
            Session.Remove("sDiplayQuestionList");
            Session.Remove("sDisplayLabel");
            Session.Remove("CheckDisplayMutilSelect");
            Session.Remove("MultiDisplayCheckedItem");
            Session.Remove("sDisplayDatatable");
            Session.Remove("iDisplayCountDataTable");

            bool isClose = false;
            IList<string> selectedNodes = new List<string>();
            IList<string> ReferToAssociatedICD = new List<string>();
            bool nodesMsg = false;
            //using (new WaitCursor())
            {
                btnMoveToSelectedAssessment.Enabled = false;
                IList<QuestionsDTO> Selected_ICDs = new List<QuestionsDTO>();
                QuestionsDTO selectedQuestion = null;
                Questions question = new Questions();

                foreach (var item in trvCodeLibrary.CheckedNodes)
                {
                    if (item.Nodes.Count == 0 && checkingForTheAssociatedCodes(item.Text))
                    {
                        var exist = (from codeIcd in ReferToAssociatedICD where codeIcd.Contains(item.Text) select codeIcd);
                        if (exist.Count() == 0)
                            ReferToAssociatedICD.Add(item.Text + "|" + item.Value);
                    }
                    else
                    {
                        var exist = (from code in selectedNodes where code.Contains(item.Text) select code);
                        if (exist.Count() == 0)
                            selectedNodes.Add(item.Text + "|" + item.Value);
                    }
                }              
                if (ReferToAssociatedICD.Count == 0 && selectedNodes.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('220203'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    return;
                }

                IList<string> icdToUnCheck = new List<string>();
                IList<string> temp = new List<string>();
                Questions.inc = 0;
               // if (ReferToAssociatedICD != null)
               // {
                if (ReferToAssociatedICD != null && ReferToAssociatedICD.Count > 0) //modified by balaji.TJ 2015-12-08
                {
                    if (sourceScreen.ToUpper() == "SELECTED" || sourceScreen == "E AND M CODE" || sourceScreen == "ORDERS" || sourceScreen == "MANAGE PROBLEM LIST" || sourceScreen.ToUpper() == "ICD10")
                    {
                        IList<QuestionsDTO> selectedQuestionList = new List<QuestionsDTO>();
                        IList<string> SourceTableList = new List<string>();
                        bool bFlag = false;
                        for (int i = 0; i < ReferToAssociatedICD.Count; i++)
                        {
                            IDictionaryICDs.Add(ReferToAssociatedICD[i].ToString().Split('-')[0], "AssociateIcd-True");
                            selectedQuestion = new QuestionsDTO();
                            string sourceTable = "ASSOCIATEDPRIMARYICD";
                            //  frmAssessment.form_Cancelled = false;
                            SourceTableList.Add(sourceTable);
                            IList<string> selectedICD = new List<string>();
                            if (Session["Selected_ICDs"] != null)
                                selectedICD = (IList<string>)Session["Selected_ICDs"];
                            if (!selectedICD.Any(s => s.Split('-')[0] == ReferToAssociatedICD[i].Split('|')[0].Split('-')[0]))
                                selectedICD.Add(ReferToAssociatedICD[i].Split('|')[0] + '|' + ReferToAssociatedICD[i].Split('|')[1].Split('/')[0]);                           
                            Session["Selected_ICDs"] = selectedICD;
                            selectedQuestion.ICD_9 = ReferToAssociatedICD[i].Split('|')[0].Split('-')[0];
                            selectedQuestion.Diagnosis_Description = ReferToAssociatedICD[i].Split('|')[0].Split('-')[1];
                            selectedQuestion.Leaf_Node = ReferToAssociatedICD[i].Split('|')[1].Split('/')[0];
                            selectedQuestionList.Add(selectedQuestion);                            
                            if (selectedNodes.Contains(ReferToAssociatedICD[i]) == false)
                                selectedNodes.Add(ReferToAssociatedICD[i]);
                            icdToUnCheck.Add(ReferToAssociatedICD[i].Split('|')[0]);
                           
                        }

                        Session["AllAndAssociateICDs"] = IDictionaryICDs;
                        if (Request["sourceScreen"].ToUpper().Trim() == "E AND M CODE")
                            hdnEandMIcd.Value = "EandMIcd";
                        question.DisplayQuestionsList(this, ReferToAssociatedICD, ref bFlag, ref Selected_ICDs, selectedQuestionList, ref SourceTableList, ReferToAssociatedICD);
                        isClose = true;                       
                    }                   
                }
              

                if (selectedNodes != null)
                {
                    if (selectedNodes.Count > 0)
                    {
                        if (Session["Selected_ICDs"]!=null && ((IList<string>)Session["Selected_ICDs"]).Count > 0) //code modified by balaji.TJ 2015-12-07
                        {
                            IList<string> selectedICD = ((IList<string>)Session["Selected_ICDs"]).ToList();
                            foreach (var item in selectedNodes)
                            {
                                if (!selectedICD.Any(s => s.Split('-')[0] == item.Split('|')[0].Split('-')[0]))
                                    selectedICD.Add(item);
                                    //selectedICD.Add(item.Split('/')[0]);                                
                            }
                            Session["Selected_ICDs"] = selectedICD;
                            if (((IList<string>)Session["Selected_ICDs"]).Count > 0)
                                foreach (string s in selectedICD)
                                {
                                    if (!((IList<string>)Session["Selected_ICDs"]).Contains(s))                                    
                                        ((IList<string>)Session["Selected_ICDs"]).Add(s);                                   
                                }
                        }
                        else                        
                            Session.Add("Selected_ICDs", selectedNodes);                         
                        if (Session["Selected_ICDs"] != null)
                        {
                            if (Request["sourceScreen"].ToUpper().Trim() == "E AND M CODE")
                                hdnEandMIcd.Value = "EandMIcd";
                        }
                        if (sourceScreen.ToUpper() == "GENERATE PATIENT LISTS" || sourceScreen == "PATIENT REMINDER")
                        {
                            IList<string> selectedICDs = (IList<string>)Session["Selected_ICDs"];
                            if (selectedICDs!=null && selectedICDs.Count > 0) //code modified by balaji.TJ 2015-12-07
                            {
                                foreach (var item in ReferToAssociatedICD)
                                {
                                    if (!selectedICDs.Any(s => s.Split('-')[0] == item.Split('|')[0].Split('-')[0]))
                                        selectedICDs.Add(item.Split('|')[item.Split('|').Count() - 1]);
                                }
                                Session["Selected_ICDs"] = selectedICDs;
                            }                        
                        }
                    }
                }
                for (int i = 0; i < selectedNodes.Count; i++)
                {
                    string[] leaf = selectedNodes[i].ToString().Split('|')[1].Split('/');
                    if (leaf[0] == "Y")
                        nodesMsg = true;
                }
                foreach (var item in icdToUnCheck)
                {
                    RadTreeNode a = trvCodeLibrary.Nodes.FindNodeByText(item, true);
                    if (a != null)
                    {
                        a.Checked = false;
                        a.Selected = false;
                    }
                }
            }
            if (sourceScreen == "PATIENT REMINDER")
            {
                if (Session["Selected_ICDs"] != null) //code added by balaji.TJ 2015-12-07
                {
                    IList<string> selectedICDs = (IList<string>)Session["Selected_ICDs"];
                    //IList<string> lsttempstring = new List<string>(); //code comment by balaji.TJ 2015-12-08
                    foreach (string st in selectedICDs)
                    {
                        if (!finalProblemList.Value.Contains(st.Split('|')[0] + ";"))
                            finalProblemList.Value += st.Split('|')[0] + ";";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "ParentHiddenField();", true);
                    }
                }
            }

            if (nodesMsg == true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "DisplayErrorMessage('220205'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);           
            else if ((nodesMsg == false) && (selectedNodes.Count >= 1))
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('220207'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);           
            //if (!frmAssessment.form_Cancelled)
            //{
            if (ReferToAssociatedICD!=null && ReferToAssociatedICD.Count == 0) //modified by balaji.TJ
                    uncheckTheCheckBoxes(trvCodeLibrary);
            //}
            btnMoveToSelectedAssessment.Enabled = trvCodeLibrary.Nodes.Cast<RadTreeNode>().Any(t => t.Checked) ? true : false;          
            btnMoveToSelectedAssessment.Enabled = false;
            divLoading.Style.Add("display", "none");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //using (new WaitCursor())
            {
                //if (ViewState["ReferToAssociatedICD"] != null)
                //    ((IList<string>)ViewState["ReferToAssociatedICD"]).Clear();

                //if (ViewState["selectedNodes"] != null)
                //    ((IList<string>)ViewState["selectedNodes"]).Clear();
                string icdVersion = string.Empty;
                if (ClientSession.FillEncounterandWFObject.EncRecord.Date_of_Service >= Convert.ToDateTime("01-OCT-2015"))
                {
                    //icdVersion = cboICD910.Items[1].Text;//code comment by balaji.TJ 2015-12-08
                    icdVersion = "ICD_10"; //code added by balaji.TJ 2015-12-08
                }
                else if (ClientSession.FillEncounterandWFObject.EncRecord.Date_of_Service == DateTime.MinValue)
                {
                    if (DateTime.Now >= Convert.ToDateTime("01-OCT-2015"))
                    {
                        //icdVersion = cboICD910.Items[1].Text; //code comment by balaji.TJ 2015-12-08
                        icdVersion = "ICD_10"; //code added by balaji.TJ 2015-12-08
                    }
                    else
                    {
                        // icdVersion = cboICD910.Items[0].Text; //code comment by balaji.TJ 2015-12-08
                        icdVersion = "ICD_9"; //code added by balaji.TJ 2015-12-08
                    }
                }
                else
                {
                    //icdVersion = cboICD910.Items[0].Text; //code comment by balaji.TJ 2015-12-08
                    icdVersion = "ICD_9"; //code added by balaji.TJ 2015-12-08
                }
                btnMoveToSelectedAssessment.Enabled = false;
                int c = 0;
                trvCodeLibrary.Nodes.Clear();
                string code = txtICDCode.Text;
                string descrp = txtDescription.Text;
                if (txtDescription.Text.Contains(' '))               
                    descrp = txtDescription.Text.Replace(' ', '%');               
                if ((code != string.Empty) || (descrp != string.Empty))
                {                    
                    //if (cboICD910.Items.Count > 0)
                    //    icdVersion = cboICD910.Items[0].Text;
                    //icdVersion = cboICD910.Text; // Commented this for internal release refer #25354, #
                    listAfterSearch = objAllICD_9Manager.GetAllSearchByCODEAndSearchICD_9ForChild("%" + code + "%", "%" + descrp + "%", icdVersion);
                }
                else if ((txtICDCode.Text == string.Empty) && (txtDescription.Text == string.Empty))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('220202'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                    lblError1.Visible = false;
                    return;
                }
                c = fillTree(listAfterSearch);
                if (trvCodeLibrary.Nodes.Count > 0)
                    lblError1.Text = trvCodeLibrary.Nodes.Count + " Result(s) Found";
                else
                    lblError1.Text = "No Result(s) Found";
                lblError1.Visible = true;
                if (btnMoveToSelectedAssessment.Enabled)
                    btnMoveToSelectedAssessment.Focus();
                else
                    btnMoveToSelectedAssessment.Enabled = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                divLoading.Style.Add("display", "none");
            }
        }
        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            //if (ViewState["ReferToAssociatedICD"] != null)
            //    ((IList<string>)ViewState["ReferToAssociatedICD"]).Clear();

            //if (ViewState["selectedNodes"] != null)
            //    ((IList<string>)ViewState["selectedNodes"]).Clear();
            trvCodeLibrary.Nodes.Clear();
            lblError1.Visible = false;
            txtDescription.Text = string.Empty;
            txtICDCode.Text = string.Empty;
        }        
        protected void trvCodeLibrary_NodeCheck(object sender, RadTreeNodeEventArgs e)
        {           
            btnMoveToSelectedAssessment.Enabled = true;           
        }      
        //code comment by balaji.TJ 2015-12-08
        //protected void trvCodeLibrary_NodeClick(object sender, RadTreeNodeEventArgs e)
        //{            
        //    btnMoveToSelectedAssessment.Enabled = true;          
        //}
        #endregion
        #region Methods
        private int fillTree(IList<AllICD_9> list1)
        {
            RadTreeNode ProotNode = new RadTreeNode();
            if (list1 != null && list1.Count > 0)
            {
                foreach (var item in list1)
                {
                    RadTreeNode rootNode = new RadTreeNode();
                    string temp = string.Empty;
                    if (!string.IsNullOrEmpty(item.ICD_9_Description_Synonyms) && item.ICD_9_Description_Synonyms.Split('|').Count() > 0)
                    {
                        foreach (var itemTemp in item.ICD_9_Description_Synonyms.Split('|'))
                        {
                            if (itemTemp.ToUpper().Contains(txtDescription.Text.ToUpper()))
                                temp += "(" + itemTemp + ")";
                        }
                    }
                    rootNode.Text = item.ICD_9 + "-" + item.ICD_9_Description + temp;
                    //rootNode.ID = item.ICD_9 + "-" + item.ICD_9_Description;
                    rootNode.Value = item.Leaf_Node + "/" + item.HCC_Category + "|" + item.ICD_9 + "-" + item.ICD_9_Description;
                    rootNode.ToolTip = rootNode.Text;
                    if (item.Leaf_Node.ToUpper() == "Y")
                        trvCodeLibrary.Nodes.Add(rootNode);
                }
            }
            return list1.Count;
        }
        public void uncheckTheCheckBoxes(RadTreeView trv)
        {
            foreach (RadTreeNode node in trv.Nodes)
            {
                node.Checked = false;
                node.Selected = false;
            }
        }
        private bool checkingForTheAssociatedCodes(string condition)
        {
            if (listAssociatedCodes.Count == 0)
                listAssociatedCodes = objAssessmentQuestionsMgr.GetAllAssociatedICDCodes();
            var rootNodes = (from node in listAssociatedCodes where node.ICD_9 == condition.Split('-')[0] select new { ICD = node.ICD_9 }).ToList();
            if (rootNodes.Count() > 0)
                return true;
            return false;
        }
        #endregion
        protected void btnQuit_Click(object sender, EventArgs e)
        {
            if (Session["Selected_ICDs"] != null && Session["Selected_ICDs"]!="")
            {
                IList<string> lst = (IList<string>)Session["Selected_ICDs"];
                foreach (string st in lst)
                {
                    if (!finalProblemList.Value.Contains(st.Split('|')[0] + ";"))
                        finalProblemList.Value += st.Split('|')[0] + ";";
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "closeMedicationManager", "CloseWindow(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
            //divLoading.Style.Add("display", "none");
        }
        protected void btnInvisible_Click(object sender, EventArgs e)
        {
            if (Session["Selected_ICDs"] != null)
            {
                IList<string> lst = (IList<string>)Session["Selected_ICDs"];
                if (lst.Count > 0)
                {
                    trvCodeLibrary.UncheckAllNodes();
                }
                else
                    btnMoveToSelectedAssessment.Enabled = true;
            }
        }
    }
}
