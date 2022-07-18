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
using Acurus.Capella.Core.DTO;
using System.IO;
using System.Runtime.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;

namespace Acurus.Capella.UI
{
    public partial class frmGeneratePatientLists : SessionExpired
    {
        #region Declaration

        IList<string> SelectedMedicationList = new List<string>();
        IList<string> SelectedMedicationAllrgyList = new List<string>();
        //IList<string> FrequentProblemlist = new List<string>();
        IList<string> ProblemListDescription = new List<string>();
        HumanManager objHumanManager = new HumanManager();
        //IList<string> iProblemList = new List<string>();
        iTextSharp.text.Font normalFont = iTextSharp.text.FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        iTextSharp.text.Font reducedFont = iTextSharp.text.FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
        static IList<GeneratePatientListsDTO> PatientListResult = new List<GeneratePatientListsDTO>();
        DataView dv = new DataView();
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnSortOrder.Value = "ASC";
                rdtpToDate.SelectedDate = DateTime.Now;
                rdtpFromDate.SelectedDate = DateTime.Now.Subtract(TimeSpan.FromDays(90));

                chkAge.Attributes.Add("OnClick", "chkAgeCheckBoxChecked('" + chkAge.ID + "')");
                chkAgeRange.Attributes.Add("OnClick", "chkAgeRangeCheckBoxChecked('" + chkAgeRange.ID + "')");
                chkGender.Attributes.Add("OnClick", "chkGenderCheckBoxChecked('" + chkGender.ID + "')");

                LoadLookUp();
                mpnOrderManagement.Reset();
              //  DisableControl();
                txtProblemList.Enabled = true;
                txtMedication.Enabled = true;
                if (grdConditionReport.DataSource == null)
                    grdConditionReport.DataBind();
                    grdConditionReport.DataSource = new string[] { };
                PatientListResult.Clear();
            }
            else
            {
                if (grdConditionReport.DataSource == null)
                    grdConditionReport.DataSource = new string[] { };
                PatientListResult.Clear();

                if (chkAge.Checked == true)
                {
                    cboAge.Enabled = true;
                    txtAgeLevel.Enabled = true;
                    
                }
                if (chkAgeRange.Checked == true)
                {
                    txtAgeRangeFrom.Enabled = true;
                    txtAgeRangeTo.Enabled = true;

                }
                if (chkGender.Checked == true)
                {
                   cboGender.Enabled = true;         

                }

                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnExportToExcel);
            }
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            //if (ApplicationObject.erroHandler.DisplayErrorMessage("7030012", this.Text) == 1)
            if(isClearAll.Value == "true")
            {
                ClearAll(this);
                grdConditionReport.DataSource = null;
                grdConditionReport.DataBind();
                mpnOrderManagement.TotalNoofDBRecords = 0;
                //mpnGeneratePatientList.PageNumber = 1;
                //mpnGeneratePatientList.TotalNoofDBRecords = 0;
            }
            divLoading.Style.Add("display", "none");
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            mpnOrderManagement.Reset(); //for bug id 29240
            //using (new WaitCursor())
            {

                if (Validation() == false)
                {

                    return;
                }

                string[] sTestResultname = new string[4];

                if (txtTestResultName1.Text != string.Empty)
                {

                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName1.Text);
                    if (cboTestResultName1Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName1Units.Text + Convert.ToString(cboTestResultName1Range.Items[cboTestResultName1Range.SelectedIndex].Value) + txtbetween1.Text;
                    }
                    else if (cboTestResultName1Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName1Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName1Range.Items[cboTestResultName1Range.SelectedIndex].Value) + txtTestResultName1Units.Text;
                    }
                    sTestResultname[0] = scondtion;
                }
               // if (cboTestResultName1Condition.Text != string.Empty)
                if (txtTestResultName2.Text != string.Empty)
                {

                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName2.Text);
                    if (cboTestResultName2Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName2Units.Text + Convert.ToString(cboTestResultName2Range.Items[cboTestResultName2Range.SelectedIndex].Value) + txtbetween2.Text;
                    }
                    else if (cboTestResultName2Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName2Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName2Range.Items[cboTestResultName2Range.SelectedIndex].Value) + txtTestResultName2Units.Text;
                    }
                    sTestResultname[1] = scondtion;
                }
               // if (cboTestResultName2Condition.Text != string.Empty)
                if (txtTestResultName3.Text != string.Empty)
                {
                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName3.Text);
                    if (cboTestResultName3Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName3Units.Text + Convert.ToString(cboTestResultName3Range.Items[cboTestResultName3Range.SelectedIndex].Value) + txtbetween3.Text;
                    }
                    else if (cboTestResultName3Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName3Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName3Range.Items[cboTestResultName3Range.SelectedIndex].Value) + txtTestResultName3Units.Text;
                    }
                    sTestResultname[2] = scondtion;
                }

                //if (cboTestResultName3Condition.Text != string.Empty)
                if (txtTestResultName4.Text != string.Empty)
                {
                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName4.Text);
                    if (cboTestResultName4Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName4Units.Text + Convert.ToString(cboTestResultName4Range.Items[cboTestResultName4Range.SelectedIndex].Value) + txtbetween4.Text;
                    }
                    else if (cboTestResultName4Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName4Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName4Range.Items[cboTestResultName4Range.SelectedIndex].Value) + txtTestResultName4Units.Text;
                    }
                    sTestResultname[3] = scondtion;

                }

                string[] sCombination = new string[3];
                if (txtTestResultName2.Text != string.Empty)
                    sCombination[0] ="OR";
                if (txtTestResultName3.Text != string.Empty)
                    sCombination[1] = "OR";
                if (txtTestResultName4.Text != string.Empty)
                    sCombination[2] = "OR";

                string sImmunDescription = string.Empty;
                //if (cboProcedure.Text != string.Empty && cboDescriptiontaken.Text != string.Empty)
                //{
                //    sImmunDescription = Convert.ToString(cboProcedure.Items[cboProcedure.SelectedIndex].Text) + "+" + Convert.ToString(cboDescriptiontaken.Items[cboDescriptiontaken.SelectedIndex].Value);
                //}

                IList<string> ilstNdc = new List<string>();
              
              // if (SelectedMedicationList.Count > 0)
                //{
                //    for (int i = 0; i < SelectedMedicationList.Count; i++)
                //    {
                //        string[] splitval = SelectedMedicationList[i].ToString().Split('+');
                //        ilstNdc.Add(splitval[0].ToString());
                //    }
                //}    
                IList<string> ilstNdc_allergy = new List<string>();
             
                if (txtMedication.Text == "")
                {
                    searchedMedications.Value="";
                }
                if (!searchedMedications.Value.Equals(""))
                {
                    SelectedMedicationList = searchedMedications.Value.Split(';');
                    for (int i = 0; i < SelectedMedicationList.Count; i++)
                    {
                        if (SelectedMedicationList[i].ToString() != "")
                        {
                            string[] splitval = SelectedMedicationList[i].ToString().Split('+');
                            ilstNdc.Add(splitval[0].ToString());
                        }
                    }

                }
                
                if (txtMedicationAllergy.Text == "")
                {
                    hdnMedAllergy.Value = "";
                }
                if (!hdnMedAllergy.Value.Equals(""))
                {
                    SelectedMedicationAllrgyList = hdnMedAllergy.Value.Split(';');
                    for (int i = 0; i < SelectedMedicationAllrgyList.Count; i++)
                    {
                        if (SelectedMedicationAllrgyList[i].ToString() != "")
                        {
                            string[] splitval = SelectedMedicationAllrgyList[i].ToString().Split('+');
                            ilstNdc_allergy.Add(splitval[0].ToString());
                        }


                    }

                }
               

                loadGeneratedPatientList(ilstNdc_allergy,ilstNdc, sImmunDescription, sTestResultname, sCombination);
                divLoading.Style.Add("display", "none");     
                  ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnExportToExcel);
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
                    
            string strtime = hdnLocalTime.Value.ToString().Split('G').ElementAt(0).ToString();
           // DateTime utc = Convert.ToDateTime(strtime);           
            DateTime utc = new DateTime();
            if (strtime.ToString() != string.Empty)
                utc = Convert.ToDateTime(strtime); 


            if (grdConditionReport.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7300005');", true);
                return;
            }
            else
            {
                string[] sTestResultname = new string[4];
                string[] sCombination = new string[3];
                IList<string> ilstNdc = new List<string>();
                IList<string> ilstNdc_allergy = new List<string>();
                IList<string> FrequentProblemlist = new List<string>();
                IList<string> problemList = new List<string>();
                if (ViewState["Med"] != null)
                {
                    ilstNdc = (IList<string>)ViewState["Med"];
                }
                if (ViewState["Med_Allergy"] != null)
                {
                    ilstNdc_allergy = (IList<string>)ViewState["Med_Allergy"];
                }
                if (ViewState["ProblemList"] != null)
                {
                    problemList = (IList<string>)ViewState["Med_Allergy"]; 
                }
                if (ViewState["TestResult"] != null)
                {
                    sTestResultname =(string[]) ViewState["TestResult"];
                }
                if (ViewState["Combination"] != null)
                {
                    sCombination = (string[])ViewState["Combination"];
                }
                if (ViewState["ProbList"] != null)
                {
                    problemList = (IList<string>)ViewState["ProbList"]; 
                }
                if (ViewState["FreqProbList"] != null)
                {
                    FrequentProblemlist = (IList<string>)ViewState["FreqProbList"]; 
                }

                int strAgeLevel;
                var serializer = new NetDataContractSerializer();
                if (txtAgeLevel.Text == "")
                {
                    strAgeLevel = 0;
                }
                else
                {
                    strAgeLevel = Convert.ToInt32(txtAgeLevel.Text);
                }

                DateTime enddate = rdtpToDate.SelectedDate.Value;
                enddate = enddate.AddDays(+1);
                Stream objPatientListStream = objHumanManager.ExportPatientLists(Convert.ToString(cboAge.Items[cboAge.SelectedIndex].Value), strAgeLevel, ConvertToInt(txtAgeRangeFrom.Text), ConvertToInt(txtAgeRangeTo.Text), cboGender.Text, cboRace.Text, cboEthnicity.Text, cboCommPreference.Text, ilstNdc.ToArray<string>(), ilstNdc_allergy.ToArray<string>(), problemList.ToArray<string>(), sTestResultname, sCombination, FrequentProblemlist.ToArray<string>(), rdtpFromDate.SelectedDate.Value.ToString("yyyy-MM-dd hh:mm:ss"), enddate.ToString("yyyy-MM-dd hh:mm:ss"));

                Session["Patientlist"] = (Stream)objPatientListStream;

                object objPatientListMgr = (object)serializer.ReadObject(objPatientListStream);

                Hashtable hsFindPatient = (Hashtable)objPatientListMgr;

                PatientListResult = (IList<GeneratePatientListsDTO>)hsFindPatient["GeneratedPatientList"];

                LoadGrid(PatientListResult);

                DataSet ds = new DataSet();
                DataTable dt = (DataTable)ViewState["PatientList"];
                ds.Tables.Add(dt);
                string sDirPath = Server.MapPath("Documents/" + Session.SessionID);
                //string sFileName = "Patient_Lists_Report_" + DateTime.Now.ToString("yyyyMMdd hh mm ss tt") + ".xls";

                string sFileName = "Patient_Lists_Report_" + UtilityManager.ConvertToLocal(utc).ToString("yyyyMMdd hh mm ss tt") + ".xls";
                
                DataView dv = new DataView(ds.Tables[0]);
                if (dv.Table.Rows.Count > 0)
                {
                    Response.Charset = "UTF-8";
                    Response.ContentType = "application/x-msexcel";
                    Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
                    StringBuilder sResponseMessage = new StringBuilder();
                    sResponseMessage.Append("<table  border=\"1\" width=\"50%\">");
                    int col;
                    sResponseMessage.Append("<tr align=\"center\" >");
                    for (col = 0; col < dv.Table.Columns.Count; col++)
                    {
                        sResponseMessage.Append("<td width=\"20%\"><strong>" + dv.Table.Columns[col].ColumnName + "</strong></td>");
                    }
                    sResponseMessage.Append("</tr>");
                    foreach (DataRowView drv in dv)
                    {

                        sResponseMessage.Append("<tr>");
                        for (col = 0; col < dv.Table.Columns.Count; col++)
                        {
                            sResponseMessage.Append("<td width='50%'>" + drv[col].ToString() + "</td>");
                        }
                        sResponseMessage.Append("</tr>");
                    }
                    sResponseMessage.Append("</table>");
                    Response.Write(sResponseMessage);
                    Response.Flush();
                    Response.End();
                }
            }
          
        }

        //protected void pbFindProblemList_Click(object sender, ImageClickEventArgs e)
        //{
        //    IList<string> ilstFreqUsedIcd = new List<string>();
        //    //FrequentProblemlist.Clear();
        //    frequentProblemlist.Value = string.Empty;
        //    ilstFreqUsedIcd.Clear();
        //    txtProblemList.Text = string.Empty;
        //    //iProblemList.Clear();            
        //    iProblemList.Value = string.Empty;
        //    ProblemListDescription.Clear();
        //    string sProbList = string.Empty;
        //    //frmMedicationManager objMedication = new frmMedicationManager("ProblemList");
        //    //objMedication.FindProblemList(ref sProbList, ref iProblemList, ref FrequentProblemlist);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "openProblemList", "openProblemList();", true);
        //    //txtProblemList.Text = string.IsNullOrEmpty(sProbList) ? txtProblemList.Text : sProbList;
        //}

        //protected void pbFindMedication_Click(object sender, ImageClickEventArgs e)
        //{
        //    SelectedMedicationList.Clear();
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "openMedicationList", "openMedicationList();", true);

        //    //frmMedicationManager objMedicationManager = new frmMedicationManager("Medication");
        //    //objMedicationManager.View(ref SelectedMedicationList);

        //    //if (SelectedMedicationList == null || SelectedMedicationList.Count == 0)
        //    //    return;

        //    //for (int i = 0; i < SelectedMedicationList.Count; i++)
        //    //{
        //    //    string[] splitvalue = SelectedMedicationList[i].ToString().Split('+');

        //    //    txtMedication.Text += splitvalue[1].ToString() + ";";
        //    //}
        //}       

        //protected void pbFindMedicationAllergy_Click(object sender, ImageClickEventArgs e)
        //{
        //    SelectedMedicationList.Clear();
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "openMedicationAllergyList", "openMedicationAllergyList();", true);
        //}

        protected void cboTestResultName1Range_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cboTestResultName1Range.Text.ToUpper() == "BETWEEN")
                
                txtbetween1.Enabled = true;
            else
            {
                txtbetween1.Text = string.Empty;
                txtbetween1.Enabled = false;
            }
        }

        protected void cboTestResultName2Range_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cboTestResultName2Range.Text.ToUpper() == "BETWEEN")
                txtbetween2.Enabled = true;
            else
            {
                txtbetween2.Text = string.Empty;
                txtbetween2.Enabled = false;
            }
        }

        protected void cboTestResultName3Range_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cboTestResultName3Range.Text.ToUpper() == "BETWEEN")
                txtbetween3.Enabled = true;
            else
            {
                txtbetween3.Text = string.Empty;
                txtbetween3.Enabled = false;
            }
        }

        protected void cboTestResultName4Range_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cboTestResultName4Range.Text.ToUpper() == "BETWEEN")
                txtbetween4.Enabled = true;
            else
            {
                txtbetween4.Text = string.Empty;
                txtbetween4.Enabled = false;
            }
        }

        protected void cboTestResultName1Condition_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if (cboTestResultName1Condition.Text != string.Empty)
            //{
            //    txtTestResultName2.Enabled = true;
            //    cboTestResultName2Range.Enabled = true;
            //    txtTestResultName2Units.Enabled = true;
            //    cboTestResultName2Condition.Enabled = true;
            //}
            //else
            //{
            //    txtTestResultName2.Enabled = false;
            //    cboTestResultName2Range.Enabled = false;
            //    txtTestResultName2Units.Enabled = false;
            //    txtTestResultName2.Text = string.Empty;
            //    cboTestResultName2Range.Text = string.Empty;
            //    txtTestResultName2Units.Text = string.Empty;
            //    cboTestResultName2Condition.Enabled = false;
            //    txtbetween2.Text = string.Empty;
            //    txtbetween2.Enabled = false;
            //}
        }

        protected void cboTestResultName2Condition_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if (cboTestResultName2Condition.Text != string.Empty)
            //{
            //    txtTestResultName3.Enabled = true;
            //    cboTestResultName3Range.Enabled = true;
            //    txtTestResultName3Units.Enabled = true;
            //    cboTestResultName3Condition.Enabled = true;
            //}
            //else
            //{
            //    txtTestResultName3.Enabled = false;
            //    cboTestResultName3Range.Enabled = false;
            //    txtTestResultName3Units.Enabled = false;
            //    txtTestResultName3.Text = string.Empty;
            //    cboTestResultName3Range.Text = string.Empty;
            //    txtTestResultName3Units.Text = string.Empty;
            //   // cboTestResultName3Condition.Enabled = false;
            //    txtbetween3.Text = string.Empty;
            //    txtbetween3.Enabled = false;
            //}
        }

        protected void cboTestResultName3Condition_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if (cboTestResultName3Condition.Text != string.Empty)
            //{
            //    txtTestResultName4.Enabled = true;
            //    cboTestResultName4Range.Enabled = true;
            //    txtTestResultName4Units.Enabled = true;
            //}
            //else
            //{
            //    txtTestResultName4.Enabled = false;
            //    cboTestResultName4Range.Enabled = false;
            //    txtTestResultName4Units.Enabled = false;
            //    txtTestResultName4.Text = string.Empty;
            //    cboTestResultName4Range.Text = string.Empty;
            //    txtTestResultName4Units.Text = string.Empty;
            //    txtbetween4.Text = string.Empty;
            //    txtbetween4.Enabled = false;
            //}
        }

        protected void grdConditionReport_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            var serializer = new NetDataContractSerializer();
            if (Session["Patientlist"] != null)
            {
                Stream objPatientListStream = (Stream)Session["Patientlist"];
                objPatientListStream.Position = 0;

                object objPatientListMgr = (object)serializer.ReadObject(objPatientListStream);

                Hashtable hsFindPatient = (Hashtable)objPatientListMgr;

                PatientListResult = (IList<GeneratePatientListsDTO>)hsFindPatient["GeneratedPatientList"];

                var temp = PatientListResult.OrderBy(d => e.NewSortOrder).ToList();

                LoadGrid(temp);
            }        
        }

        #endregion

        #region Methods

        private void FillColumnHeaders(Microsoft.Office.Interop.Excel.Worksheet ws, string[] ColumnNames)
        {
            string nextItem = string.Empty;
            int colcount = 1;
            foreach (string sName in ColumnNames)
            {
                nextItem = sName;
                AddItemToSpreadsheet(1, colcount, ws, nextItem);
                AutoFitColumn(ws, colcount);
                SetColumnWidth(ws, colcount, 40);
                colcount++;
            }

            BoldRow(1, ws);
        }
        private void BoldRow(int row, Microsoft.Office.Interop.Excel.Worksheet ws)
        {
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[row, 1]).EntireRow.Font.Bold = true;
        }

        private void AddItemToSpreadsheet(int row, int column, Microsoft.Office.Interop.Excel.Worksheet ws, string item)
        {
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[row, 3]).NumberFormat = "dd-mmm-yyyy";
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[row, column]).Value2 = item;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[row, column]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[row, column]).WrapText = true;
        }

        private void AutoFitColumn(Microsoft.Office.Interop.Excel.Worksheet ws, int col)
        {
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).EntireColumn.AutoFit();
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).EntireColumn.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).EntireColumn.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).EntireColumn.Borders.Weight = 2;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
        }

        private void SetColumnWidth(Microsoft.Office.Interop.Excel.Worksheet ws, int col, int width)
        {
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, col]).EntireColumn.ColumnWidth = width;
        }

        private void FillDataRows(Microsoft.Office.Interop.Excel.Worksheet ws)
        {
            int rowcount = 2;
            int colcount = 1;

            for (int i = 0; i < PatientListResult.Count; i++)
            {
                colcount = 1;
                string nextItem = Convert.ToString(PatientListResult[i].PatientAccountNo);
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].PatientName;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].DOB;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = Convert.ToString(PatientListResult[i].Age);
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].Gender;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].Race;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].Ethnicity;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].CommunicationPreference;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].Medication;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].MedicationAllergy;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                nextItem = PatientListResult[i].ProblemList;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                //nextItem = patientListResult[i].Immunization;
                //AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                //colcount++;
                nextItem = PatientListResult[i].LabResult;
                AddItemToSpreadsheet(rowcount, colcount, ws, nextItem);
                colcount++;
                rowcount++;
            }
        }

        private void PrintResult(IList<GeneratePatientListsDTO> patientListResult)
        {
            string strtime = hdnLocalTime.Value.ToString().Split('G').ElementAt(0).ToString();
            //DateTime utc = Convert.ToDateTime(strtime);    
            DateTime utc = new DateTime();
            if (strtime.ToString() != string.Empty)
                utc = Convert.ToDateTime(strtime); 


            string sDirPath = Server.MapPath("Documents/" + Session.SessionID);
           // string sFileName = "Patient_List_Report_" + DateTime.Now.ToString("yyyyMMdd hh mm ss tt") + ".pdf";

            string sFileName = "Patient_List_Report_" + UtilityManager.ConvertToLocal(utc).ToString("yyyyMMdd hh mm ss tt") + ".pdf";
            string sPrintPathName = sDirPath + "\\" + sFileName;

            DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);
            if (!ObjSearchDir.Exists)
                ObjSearchDir.Create();
            
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 100, 100, 50, 50);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream(sPrintPathName, FileMode.Create));
            //iTextSharp.text.Rectangle pageSize = doc.PageSize;
            HeaderEventGenerate headerEvent = new HeaderEventGenerate();
            doc.Open();
          //  wr.PageEvent = headerEvent;
           // headerEvent.OnStartPage(wr, doc);
            //headerEvent.OnEndPage(wr, doc);

            Paragraph par = new Paragraph("Patient List Report", iTextSharp.text.FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
            par.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            doc.Add(par);
            par.Clear();

            string ConditionSummary = "Patient List report for the patients";
            if (chkAge.Checked == true)
                ConditionSummary += " of age " + cboAge.Text + " " + txtAgeLevel.Text + " years";
            else
                ConditionSummary += " of age ranging from " + txtAgeRangeFrom.Text + " years to " + txtAgeRangeTo.Text + " years";

            if (chkGender.Checked == true)
                ConditionSummary += ", of " + cboGender.Text + " Gender";

            if (ProblemListDescription != null && ProblemListDescription.Count != 0)
            {
                ConditionSummary += ", with ";
                for (int i = 0; i < ProblemListDescription.Count; i++)
                {
                    if (i + 1 == ProblemListDescription.Count)
                        ConditionSummary += ProblemListDescription[i] + " problem";
                    else
                        ConditionSummary += ProblemListDescription[i] + ",";
                }
            }

            if (SelectedMedicationList != null && SelectedMedicationList.Count != 0)
            {
                ConditionSummary += ", taking ";
                for (int i = 0; i < SelectedMedicationList.Count; i++)
                {
                    string[] split = SelectedMedicationList[i].ToString().Split('+');
                    if (i + 1 == SelectedMedicationList.Count)
                        ConditionSummary += split[1].ToString() + " medication";
                    else
                        ConditionSummary += split[1].ToString() + ",";
                }
            }

            if (txtTestResultName1.Text != string.Empty)
                ConditionSummary += " and the following selected Lab Test/Results -" + Environment.NewLine + txtTestResultName1.Text;

            if (txtTestResultName2.Text != string.Empty)
                ConditionSummary += Environment.NewLine + " " + " or " + " " + txtTestResultName2.Text;

            if (txtTestResultName3.Text != string.Empty)
                ConditionSummary += Environment.NewLine + " " + " or " + " " + txtTestResultName3.Text;

            if (txtTestResultName4.Text != string.Empty)
                ConditionSummary += Environment.NewLine + " " + " or " + " " + txtTestResultName4.Text;

            //if (cboProcedure.Text != string.Empty)
            //    ConditionSummary += " with " + cboProcedure.Text;

            //if (dtpFrom_Date.SelectedDate != DateTime.MinValue)
            //    ConditionSummary += " taken from " + dtpFrom_Date.SelectedDate.ToString("dd-MMM-yyyy");

            //if (dtpTo_Date.SelectedDate != DateTime.MinValue)
            //    ConditionSummary += " to " + dtpTo_Date.SelectedDate.ToString("dd-MMM-yyyy");

            ConditionSummary += " is shown below.";

            doc.Add(new Paragraph("\n"));
            Paragraph par1 = new Paragraph(ConditionSummary, iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
            par1.Alignment = iTextSharp.text.Element.ALIGN_LEFT;
            doc.Add(par1);

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            PdfPTable patTable = new PdfPTable(new float[] { 5, 12, 9, 5, 9, 10, 10, 10, 10, 10, 10, 10 ,10 ,10 });//, 15 });
            patTable.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Acc #", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Patient Name", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("DOB", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Age", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Gender", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Race", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Ethnicity", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Communication Preference", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Medication", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Medication Date", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);


            cell = new PdfPCell(new Phrase("Medication Allergy", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Medication Allergy Date", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Problem List", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Problem List Date", reducedFont));
            cell.Colspan = 1;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            patTable.AddCell(cell);

            //cell = new PdfPCell(new Phrase("Immunization", reducedFont));
            //cell.Colspan = 1;
            //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            //patTable.AddCell(cell);

            //cell = new PdfPCell(new Phrase("Lab Result", reducedFont));
            //cell.Colspan = 1;
            //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            //patTable.AddCell(cell);

            //cell = new PdfPCell(new Phrase("Lab Result Date", reducedFont));
            //cell.Colspan = 1;
            //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            //patTable.AddCell(cell);

            for (int i = 0; i < patientListResult.Count; i++)
            {
                cell = new PdfPCell(new Phrase(Convert.ToString(patientListResult[i].PatientAccountNo), normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].PatientName, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].DOB, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(Convert.ToString(patientListResult[i].Age), normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].Gender, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].Race, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].Ethnicity, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].CommunicationPreference, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].Medication, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].Medication_Date, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].MedicationAllergy, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].Medication_Date, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].ProblemList, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(patientListResult[i].ProblemList_Date, normalFont));
                cell.Colspan = 1;
                patTable.AddCell(cell);

                //cell = new PdfPCell(new Phrase(PatientListResult[i].Immunization, normalFont));
                //cell.Colspan = 1;
                //patTable.AddCell(cell);

                //cell = new PdfPCell(new Phrase(patientListResult[i].LabResult, normalFont));
                //cell.Colspan = 1;
                //patTable.AddCell(cell);

                //cell = new PdfPCell(new Phrase(patientListResult[i].LabResult_Date, normalFont));
                //cell.Colspan = 1;
                //patTable.AddCell(cell);
            }

            doc.Add(patTable);
            doc.Close();

            hdnFilePath.Value = "Documents\\" + Session.SessionID + "\\" + sFileName;
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "openform();", true);                
        }

        private bool Validation()
        {
            if (chkAge.Checked == false && chkAgeRange.Checked == false && chkGender.Checked == false && txtProblemList.Text == string.Empty && txtMedication.Text == string.Empty && txtMedicationAllergy.Text == string.Empty
            && cboRace.Text == string.Empty && cboEthnicity.Text == string.Empty && cboCommPreference.Text == string.Empty && txtTestResultName1.Text == string.Empty && txtTestResultName2.Text == string.Empty && txtTestResultName3.Text == string.Empty && txtTestResultName4.Text == string.Empty)
            //&& cboProcedure.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030001');", true);
                chkAge.Focus();
                return false;
            }

            if (chkAge.Checked == true)
            {
                if (cboAge.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030002');", true);
                    cboAge.Focus();
                    return false;
                }
                if (txtAgeLevel.Text.Trim() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030003');", true);
                    txtAgeLevel.Focus();
                    return false;
                }
            }

            if (chkAgeRange.Checked == true)
            {
                if (txtAgeRangeFrom.Text.Trim() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030004');", true);
                    txtAgeRangeFrom.Focus();
                    return false;
                }
                if (txtAgeRangeTo.Text.Trim() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030005');", true);
                    txtAgeRangeTo.Focus();
                    return false;
                }
            }

            if (chkGender.Checked == true)
            {
                if (cboGender.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030006');", true);
                    cboGender.Focus();
                    return false;
                }
            }

            //if (dtpFrom_Date.ComboBoxDate != null && dtpFrom_Date.ComboBoxDate != string.Empty)
            //{
            //    if (dtpFrom_Date.ComboBoxDate.Length == 4 && dtpFrom_Date.ComboBoxDate.Contains('-'))
            //    {
            //        ApplicationObject.erroHandler.DisplayErrorMessage("7030007", this.Text);
            //        dtpFrom_Date.Focus();
            //        return false;
            //    }
            //    int h = dtpFrom_Date.SelectedDate.Date.CompareTo(DateTime.Now.Date);
            //    if (h > 0)
            //    {
            //        ApplicationObject.erroHandler.DisplayErrorMessage("7030008", this.Text);
            //        dtpFrom_Date.Focus();
            //        return false;
            //    }
            //}

            //if (dtpTo_Date.ComboBoxDate != null && dtpTo_Date.ComboBoxDate != string.Empty)
            //{
            //    if (dtpTo_Date.ComboBoxDate.Length == 4 && dtpTo_Date.ComboBoxDate.Contains('-'))
            //    {
            //        ApplicationObject.erroHandler.DisplayErrorMessage("7030007", this.Text);
            //        dtpTo_Date.Focus();
            //        return false;
            //    }
            //    int h = dtpTo_Date.SelectedDate.Date.CompareTo(DateTime.Now.Date);
            //    if (h > 0)
            //    {
            //        ApplicationObject.erroHandler.DisplayErrorMessage("7030008", this.Text);
            //        dtpTo_Date.Focus();
            //        return false;
            //    }
            //    h = dtpTo_Date.SelectedDate.Date.CompareTo(dtpFrom_Date.SelectedDate);
            //    if (h < 0)
            //    {
            //        ApplicationObject.erroHandler.DisplayErrorMessage("7030009", this.Text);
            //        dtpTo_Date.Focus();
            //        return false;
            //    }
            //}

            //if (dtpFrom_Date.ComboBoxDate == string.Empty)
            //    dtpFrom_Date.SelectedDate = DateTime.MinValue;

            //if (dtpTo_Date.ComboBoxDate == string.Empty)
            //    dtpTo_Date.SelectedDate = DateTime.MinValue;


            if (txtTestResultName1.Text != string.Empty || cboTestResultName1Range.Text != string.Empty || txtTestResultName1Units.Text != string.Empty)
            {
                bool bResultName1return = CheckcboTestResultName1Condition();
                if (bResultName1return == false)
                    return false;
            }

            //if (cboTestResultName1Condition.Text != string.Empty)
            //{
            //    bool bResultName1return = CheckcboTestResultName1Condition();
            //    if (bResultName1return == true)
            //    {
            //        bool bResultName2return = CheckcboTestResultName2Condition();
            //        if (bResultName2return == false)
            //            return false;
            //    }
            //    return bResultName1return;
            //}

            if (txtTestResultName2.Text != string.Empty || cboTestResultName2Range.Text != string.Empty || txtTestResultName2Units.Text != string.Empty)
            {
                bool bResultName2return = CheckcboTestResultName2Condition();
                if (bResultName2return == false)
                {
                   // bool bResultName3return = CheckcboTestResultName3Condition();
                   // if (bResultName3return == false)
                        return false;
                }
                return bResultName2return;
            }

            if (txtTestResultName3.Text != string.Empty || cboTestResultName3Range.Text != string.Empty || txtTestResultName3Units.Text != string.Empty)
            {
                bool bResultName3return = CheckcboTestResultName3Condition();
                if (bResultName3return == false)
                {
                   // bool bResultName4return = CheckcboTestResultName4Condition();
                   // if (bResultName4return == false)
                        return false;
                }
                return bResultName3return;
            }

            if (txtTestResultName4.Text != string.Empty || cboTestResultName4Range.Text != string.Empty || txtTestResultName4Units.Text != string.Empty)
            {
                bool bResultName1return = CheckcboTestResultName4Condition();
                if (bResultName1return == false)
                    return false;
            }

            return true;
        }

        private void loadGeneratedPatientList(IList<string> ilstNdc_allergy, IList<string> ilstNdc, string sImmunDescription, string[] sTestResultname, string[] sCombination)
        {
            IList<string> problemList = new List<string>();
            if (txtProblemList.Text == "")
            {
                iProblemList.Value = "";
            }
            if (!iProblemList.Value.Equals(""))
            {
                
                problemList = iProblemList.Value.Split('|');
                problemList = problemList.Where(d => !string.IsNullOrEmpty(d)).ToList();
            }
            IList<string> FrequentProblemlist = new List<string>();
            FrequentProblemlist = string.IsNullOrEmpty(frequentProblemlist.Value) ? new string[] { } : frequentProblemlist.Value.Split('|');
            FrequentProblemlist = FrequentProblemlist.Where(d => !string.IsNullOrEmpty(d)).ToList();
            int strAgeLevel;
            var serializer = new NetDataContractSerializer();

          
            if (txtAgeLevel.Text == "")
            {
                strAgeLevel = 0;
            }
            else
            {
                strAgeLevel = Convert.ToInt32(txtAgeLevel.Text);
            }
             
            DateTime enddate = rdtpToDate.SelectedDate.Value;
            enddate = enddate.AddDays(+1);
            //ilstNdc.ToArray<string>(), ilstNdc_allergy.ToArray<string>(), problemList.ToArray<string>(), sTestResultname, sCombination, FrequentProblemlist.ToArray<string>()
            ViewState["Med"] = ilstNdc;
            ViewState["Med_Allergy"] = ilstNdc_allergy;
            ViewState["ProblemList"] = problemList;
            ViewState["TestResult"] = sTestResultname;
            ViewState["Combination"] = sCombination;
            ViewState["ProbList"] = problemList;
            ViewState["FreqProbList"] = FrequentProblemlist;

            try
            {
                Stream objPatientListStream = objHumanManager.SearchGeneratePatientLists(Convert.ToString(cboAge.Items[cboAge.SelectedIndex].Value), strAgeLevel, ConvertToInt(txtAgeRangeFrom.Text), ConvertToInt(txtAgeRangeTo.Text), cboGender.Text, cboRace.Text, cboEthnicity.Text, cboCommPreference.Text, ilstNdc.ToArray<string>(), ilstNdc_allergy.ToArray<string>(), problemList.ToArray<string>(), sTestResultname, sCombination, FrequentProblemlist.ToArray<string>(), rdtpFromDate.SelectedDate.Value.ToString("yyyy-MM-dd hh:mm:ss"), enddate.ToString("yyyy-MM-dd hh:mm:ss"), mpnOrderManagement.PageNumber, mpnOrderManagement.MaxResultPerPage);

                Session["Patientlist"] = (Stream)objPatientListStream;

                object objPatientListMgr = (object)serializer.ReadObject(objPatientListStream);

                Hashtable hsFindPatient = (Hashtable)objPatientListMgr;

                PatientListResult = (IList<GeneratePatientListsDTO>)hsFindPatient["GeneratedPatientList"];

                LoadGrid(PatientListResult);

                if (mpnOrderManagement.PageNumber == 1 && PatientListResult.Count > 0)
                    mpnOrderManagement.TotalNoofDBRecords = Convert.ToInt32(PatientListResult[0].Total_Record_Found);


                if (PatientListResult == null || PatientListResult.Count == 0)
                {
                    mpnOrderManagement.Reset();
                }

            }
            catch
            { }
           divLoading.Style.Add("display", "none");    

            //if (grdConditionReport.Items.Count != 0)
            //    PrintResult(PatientListResult);
        }

        private int ConvertToInt(string sText)
        {
            int deResult = 0;
            int.TryParse(sText, out deResult);
            return deResult;
        }

        public void FirstPageNavigator(object sender, EventArgs e)
        {
            //btnGenerateReport_Click(sender, e);  //for bug id 29240
            InvisibleGenerateReport_Click(sender, e);
        }

        private void LoadGrid(IList<GeneratePatientListsDTO> PatientList)
        {
            if (PatientList.Count > 0)
            {
                DataTable objDataTable = new DataTable();

                objDataTable.Columns.Add(new DataColumn("PatientAccountNo", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("PatientName", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("DOB", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("Age", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("Gender", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("Race", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("Ethnicity", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("CommunicationPreference", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("EncounterDate", typeof(DateTime)));
                objDataTable.Columns.Add(new DataColumn("Medication", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("MedicationDate", typeof(DateTime)));
                objDataTable.Columns.Add(new DataColumn("MedicationAllergy", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("MedicationAllergyDate", typeof(DateTime)));
                objDataTable.Columns.Add(new DataColumn("ProblemList", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("ProblemListDate", typeof(DateTime)));
               // objDataTable.Columns.Add(new DataColumn("Immunization", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("LabResult", typeof(string)));
                objDataTable.Columns.Add(new DataColumn("LabResultDate", typeof(DateTime)));

                foreach (var item in PatientList)
                {
                    DataRow objDataRow = objDataTable.NewRow();

                    objDataRow["PatientAccountNo"] = item.PatientAccountNo.ToString();
                    objDataRow["PatientName"] = item.PatientName;
                    objDataRow["DOB"] = item.DOB;
                    objDataRow["Age"] = item.Age;
                    objDataRow["Gender"] = item.Gender;
                    objDataRow["Race"] = item.Race;
                    objDataRow["Ethnicity"] = item.Ethnicity;
                    objDataRow["CommunicationPreference"] = item.CommunicationPreference;
                    if (item.Encounter_Date != null)
                    {
                        if (item.Encounter_Date != "")
                        {
                            objDataRow["EncounterDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.Encounter_Date))).ToString());
                        }
                        else
                        {
                            //objDataRow["EncounterDate"] = item.Encounter_Date;
                            //objDataRow["EncounterDate"] = DateTime.MinValue;

                        }
                    }
                    else
                    {
                        //objDataRow["EncounterDate"] = item.Encounter_Date;
                        //objDataRow["EncounterDate"] = DateTime.MinValue;
                    }
                    objDataRow["Medication"] = item.Medication;

                   // string utcdiff = System.Configuration.ConfigurationSettings.AppSettings["UTCDiff"];
                   //Double diff = Convert.ToDouble(utcdiff);

                    if (item.Medication_Date != null)
                    {
                        if (item.Medication_Date != "")
                        {
                            //objDataRow["MedicationDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.Medication_Date).AddMinutes(diff))).ToString());
                            objDataRow["MedicationDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.Medication_Date))));
                           // objDataRow["MedicationDate"] = Convert.ToDateTime(item.Medication_Date).ToString();
                        }
                        else
                        {
                           // objDataRow["MedicationDate"] =  item.Medication_Date;
                           // objDataRow["MedicationDate"] = DateTime.MinValue;
                        }

                    }
                    else
                    {
                       // objDataRow["MedicationDate"] = item.Medication_Date;
                       // objDataRow["MedicationDate"] = DateTime.MinValue;
                    }
                    objDataRow["MedicationAllergy"] = item.MedicationAllergy;
                    if (item.Medication_Allergy_Date != null)
                    {
                        if (item.Medication_Allergy_Date != "")
                        {
                            //objDataRow["MedicationAllergyDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.Medication_Allergy_Date).AddMinutes(-diff))).ToString());
                            objDataRow["MedicationAllergyDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.Medication_Allergy_Date))));
                            //objDataRow["MedicationAllergyDate"] = Convert.ToDateTime(item.Medication_Allergy_Date).ToString();
                        }
                        else
                        {
                           // objDataRow["MedicationAllergyDate"] = item.Medication_Allergy_Date;
                           // objDataRow["MedicationAllergyDate"] = DateTime.MinValue;
                        }

                    }
                    else
                    {
                       // objDataRow["MedicationAllergyDate"] = item.Medication_Allergy_Date;
                       //objDataRow["MedicationAllergyDate"] = DateTime.MinValue;
                    }
                    objDataRow["ProblemList"] = item.ProblemList;
                    if (item.ProblemList_Date != null)
                    {
                        if (item.ProblemList_Date != "")
                        {
                            objDataRow["ProblemListDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.ProblemList_Date))).ToString());
                        }
                        else
                        {
                           // objDataRow["ProblemListDate"] = item.ProblemList_Date;
                          // objDataRow["ProblemListDate"] = DateTime.MinValue;
                        }
                    }                   
                    else
                    {
                        //objDataRow["ProblemListDate"] = item.ProblemList_Date;
                        //objDataRow["ProblemListDate"] = DateTime.MinValue;
                    }
                    //objDataRow["Immunization"] = item.Immunization;
                    objDataRow["LabResult"] = item.LabResult;
                    if ( item.LabResult_Date != null)
                    { 
                        if(item.LabResult_Date != "" )
                        {
                         objDataRow["LabResultDate"] = Convert.ToDateTime((UtilityManager.ConvertToLocal(Convert.ToDateTime(item.LabResult_Date))).ToString());
                        }
                        else
                        {
                            // objDataRow["LabResultDate"] = item.LabResult_Date;
                           // objDataRow["LabResultDate"] = DateTime.MinValue;
                        }
                    }
                    else
                    {
                        //objDataRow["LabResultDate"] = item.LabResult_Date;
                       // objDataRow["LabResultDate"] = DateTime.MinValue;
                    }


                    objDataTable.Rows.Add(objDataRow);
                }
               
                grdConditionReport.DataSource = objDataTable;     
                ViewState["PatientList"]= objDataTable;
                if (grdConditionReport.MasterTableView.Columns.Count > 0)
                {
                    foreach (GridColumn col in grdConditionReport.MasterTableView.Columns)
                    {                       
                        col.Resizable = true;                       
                        col.ItemStyle.Wrap = true;
                    }
                }
                grdConditionReport.DataBind();
            }
            else
            {
                grdConditionReport.DataSource = new string[] { };
                grdConditionReport.DataBind();
            }
        }

        private void ClearAll(Control C)
        {
            foreach (Control Ctrl in C.Controls)
            {
                if ((object.ReferenceEquals(Ctrl.GetType(), typeof(RadGrid))))
                {
                    RadGrid grd = (RadGrid)Ctrl;
                    grd.DataSource = null;
                }
                //else if ((object.ReferenceEquals(Ctrl.GetType(), typeof(RadDateTimePicker))))
                //{
                //    RadDateTimePicker dtp = (RadDateTimePicker)Ctrl;
                //    dtp.Value = DateTime.MinValue;
                //}
                else if (object.ReferenceEquals(Ctrl.GetType(), typeof(RadTextBox)))
                {
                    ((RadTextBox)Ctrl).Text = string.Empty;
                }
                //else if (object.ReferenceEquals(Ctrl.GetType(), typeof(Label)))
                //{
                //    ((Label)Ctrl).Text = string.Empty;
                //}
                else if (object.ReferenceEquals(Ctrl.GetType(), typeof(CheckBox)))
                {
                    CheckBox chk = (CheckBox)Ctrl;
                    chk.Checked = false;
                }
                else if (object.ReferenceEquals(Ctrl.GetType(), typeof(RadComboBox)))
                {
                    RadComboBox cbo = (RadComboBox)Ctrl;
                    cbo.SelectedIndex = 0;
                }
                //else if (object.ReferenceEquals(Ctrl.GetType(), typeof(CustomControlLibrary.CustomDateTimePicker)))
                //{
                //    CustomControlLibrary.CustomDateTimePicker Custom = (CustomControlLibrary.CustomDateTimePicker)Ctrl;
                //    Custom.ClearAll();
                //}
                else
                {
                    if (Ctrl.Controls.Count > 0)
                    {
                        ClearAll(Ctrl);
                    }
                }
            }
        }

        private void LoadLookUp()
        {
            //iFieldLookupList = AllLookups.Instance.GetStaticLookup("Immunization Range");
            //if (iFieldLookupList.Count > 0)
            //{
            //    for (int u = 0; u < iFieldLookupList.Count; u++)
            //    {
            //        cboDescriptiontaken.Items.Add(new RadComboBoxItem(iFieldLookupList[u].Value));
            //        cboDescriptiontaken.Items[u].Tag = iFieldLookupList[u].Description;
            //    }
            //}
            //cboDescriptiontaken.SelectedIndex = 0;
            //iFieldLookupList.Clear();

            IList<StaticLookup> iFieldLookupList = new List<StaticLookup>();
            IList<StaticLookup> iFieldValues = new List<StaticLookup>();


            StaticLookupManager objStaticLookupMgr = new StaticLookupManager();
            iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName(new string[]{"Sex","RACE","ETHNICITY","COMMUNICATION TYPE","Condition Report Order","RESULT RANGE","REPORT CONDITION"});
            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "SEX").OrderBy(a => a.Sort_Order).ToList();
            for (int i = 0; i < iFieldValues.Count; i++)
            {
                cboGender.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
                cboGender.Sort = RadComboBoxSort.Ascending;
                cboGender.SelectedIndex = 0;
            }

            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("Sex", "Sort_Order");

            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //    cboGender.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //cboGender.Sort = RadComboBoxSort.Ascending;
            //cboGender.SelectedIndex = 0;

            iFieldValues.Clear();
            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "RACE").OrderBy(a => a.Sort_Order).ToList();
            cboRace.Items.Add(new RadComboBoxItem(""));
            for (int i = 0; i < iFieldValues.Count; i++)
            {
                cboRace.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));               
            }
            iFieldValues.Clear();


            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("RACE", "Sort_Order");
            //cboRace.Items.Add(new RadComboBoxItem(""));
            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //    cboRace.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
         
            //iFieldLookupList.Clear();

            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "ETHNICITY").OrderBy(a => a.Sort_Order).ToList();
            cboEthnicity.Items.Add(new RadComboBoxItem(""));
            for (int i = 0; i < iFieldValues.Count; i++)
            {
                cboEthnicity.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
            }
            iFieldValues.Clear();

            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("ETHNICITY", "Sort_Order");
            //cboEthnicity.Items.Add(new RadComboBoxItem(""));
            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //    cboEthnicity.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
         
            //iFieldLookupList.Clear();
            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "COMMUNICATION TYPE").OrderBy(a => a.Sort_Order).ToList();
            cboCommPreference.Items.Add(new RadComboBoxItem(""));
            for (int i = 0; i < iFieldValues.Count; i++)
            {
                cboCommPreference.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
            }
            iFieldValues.Clear();

            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("COMMUNICATION TYPE", "Sort_Order");
            //cboCommPreference.Items.Add(new RadComboBoxItem(""));
            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //    cboCommPreference.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
         
            //iFieldLookupList.Clear();

            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "CONDITION REPORT ORDER").ToList();
            cboAge.Items.Add(new RadComboBoxItem(""));
            for (int i = 0; i < iFieldValues.Count; i++)
            {
                cboAge.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
                cboAge.Items[cboAge.Items.Count - 1].Value = iFieldValues[i].Description;
            }
            iFieldValues.Clear();

            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("Condition Report Order");
            //cboAge.Items.Add(new RadComboBoxItem(""));

            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //{
            //    cboAge.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboAge.Items[cboAge.Items.Count - 1].Value = iFieldLookupList[i].Description;
            //}

            cboTestResultName1Range.Items.Add(new RadComboBoxItem(""));
            cboTestResultName2Range.Items.Add(new RadComboBoxItem(""));
            cboTestResultName3Range.Items.Add(new RadComboBoxItem(""));
            cboTestResultName4Range.Items.Add(new RadComboBoxItem(""));

            //iFieldLookupList.Clear();
            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "RESULT RANGE").ToList();          
            for (int i = 0; i < iFieldValues.Count; i++)
            {
                cboTestResultName1Range.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
                cboTestResultName1Range.Items[i + 1].Value = iFieldValues[i].Description;
                cboTestResultName2Range.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
                cboTestResultName2Range.Items[i + 1].Value = iFieldValues[i].Description;
                cboTestResultName3Range.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
                cboTestResultName3Range.Items[i + 1].Value = iFieldValues[i].Description;
                cboTestResultName4Range.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
                cboTestResultName4Range.Items[i + 1].Value = iFieldValues[i].Description;
            }
            iFieldValues.Clear();

            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("RESULT RANGE"); 
            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //{
            //    cboTestResultName1Range.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboTestResultName1Range.Items[i + 1].Value = iFieldLookupList[i].Description;
            //    cboTestResultName2Range.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboTestResultName2Range.Items[i + 1].Value = iFieldLookupList[i].Description;
            //    cboTestResultName3Range.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboTestResultName3Range.Items[i + 1].Value = iFieldLookupList[i].Description;
            //    cboTestResultName4Range.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboTestResultName4Range.Items[i + 1].Value = iFieldLookupList[i].Description;
            //}

            //iFieldLookupList.Clear();
            cboAge.SelectedIndex = 0;
            cboTestResultName1Range.SelectedIndex = 0;
            cboTestResultName2Range.SelectedIndex = 0;
            cboTestResultName3Range.SelectedIndex = 0;
            cboTestResultName4Range.SelectedIndex = 0;

            iFieldValues = iFieldLookupList.Where(a => a.Field_Name == "REPORT CONDITION").ToList();
            //cboTestResultName1Condition.Items.Add(new RadComboBoxItem(""));
           // cboTestResultName2Condition.Items.Add(new RadComboBoxItem(""));
           // cboTestResultName3Condition.Items.Add(new RadComboBoxItem(""));
            for (int i = 0; i < iFieldValues.Count; i++)
            {
               // cboTestResultName1Condition.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
               // cboTestResultName2Condition.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
               // cboTestResultName3Condition.Items.Add(new RadComboBoxItem(iFieldValues[i].Value));
            }
            iFieldValues.Clear();

           // cboTestResultName1Condition.SelectedIndex = 0;
           // cboTestResultName2Condition.SelectedIndex = 0;
          //  cboTestResultName3Condition.SelectedIndex = 0;
            
            //iFieldLookupList = objStaticLookupMgr.getStaticLookupByFieldName("REPORT CONDITION"); 
            //cboTestResultName1Condition.Items.Add(new RadComboBoxItem(""));
            //cboTestResultName2Condition.Items.Add(new RadComboBoxItem(""));
            //cboTestResultName3Condition.Items.Add(new RadComboBoxItem(""));
            //for (int i = 0; i < iFieldLookupList.Count; i++)
            //{
            //    cboTestResultName1Condition.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboTestResultName2Condition.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //    cboTestResultName3Condition.Items.Add(new RadComboBoxItem(iFieldLookupList[i].Value));
            //}

            //cboTestResultName1Condition.SelectedIndex = 0;
            //cboTestResultName2Condition.SelectedIndex = 0;
            //cboTestResultName3Condition.SelectedIndex = 0;

            //iFieldLookupList.Clear();

            //cboProcedure.Items.Add(new RadComboBoxItem(""));
            //IList<ProcedureCodeLibrary> ProcedureCodeList = AllLibraries.Instance.GetProcedureCodeDescription();
            //for (int i = 0; i < ProcedureCodeList.Count; i++)
            //    cboProcedure.Items.Add(new RadComboBoxItem(ProcedureCodeList[i].Procedure_Description));

            //cboProcedure.SelectedIndex = 0;
            //cboTestResultName1.Items.Add(new RadComboBoxItem(""));
            //cboTestResultName2.Items.Add(new RadComboBoxItem(""));
            //cboTestResultName3.Items.Add(new RadComboBoxItem(""));
            //cboTestResultName4.Items.Add(new RadComboBoxItem(""));

            //GeneratePatientListsDTO objGeneratePatientListsDTO = new GeneratePatientListsDTO();
            //ProcedureCodeLibraryManager objProCodeMngr = new ProcedureCodeLibraryManager();

            //var serializer = new NetDataContractSerializer();
            //Stream objStream = objProCodeMngr.GetGeneratePatientListLookup();
            //object objProcCode = (object)serializer.ReadObject(objStream);         
            //objGeneratePatientListsDTO = (GeneratePatientListsDTO)objProcCode;

            //if (objGeneratePatientListsDTO == null)
            //    return;

            //IList<Loinc> orderedLoincList = objGeneratePatientListsDTO.LoincCodeList.OrderBy(d => d.Long_Common_Name).ToList();

            //for (int i = 0; i < orderedLoincList.Count; i++)
            //{
            //    cboTestResultName1.Items.Add(new RadComboBoxItem(orderedLoincList[i].Long_Common_Name));
            //    cboTestResultName1.Items[i + 1].Value = orderedLoincList[i].Loinc_Num;
            //    cboTestResultName2.Items.Add(new RadComboBoxItem(orderedLoincList[i].Long_Common_Name));
            //    cboTestResultName2.Items[i + 1].Value = orderedLoincList[i].Loinc_Num;
            //    cboTestResultName3.Items.Add(new RadComboBoxItem(orderedLoincList[i].Long_Common_Name));
            //    cboTestResultName3.Items[i + 1].Value = orderedLoincList[i].Loinc_Num;
            //    cboTestResultName4.Items.Add(new RadComboBoxItem(orderedLoincList[i].Long_Common_Name));
            //    cboTestResultName4.Items[i + 1].Value = orderedLoincList[i].Loinc_Num;
            //}

            //cboTestResultName1.SelectedIndex = 0;
            //cboTestResultName2.SelectedIndex = 0;
            //cboTestResultName3.SelectedIndex = 0;
            //cboTestResultName4.SelectedIndex = 0;
        }

        //public void DisableControl()
        //{
        //    cboTestResultName2.Enabled = false;
        //    cboTestResultName2Range.Enabled = false;
        //    txtTestResultName2Units.Enabled = false;
        //    cboTestResultName3.Enabled = false;
        //    cboTestResultName3Range.Enabled = false;
        //    txtTestResultName3Units.Enabled = false;
        //    cboTestResultName4.Enabled = false;
        //    cboTestResultName4Range.Enabled = false;
        //    txtTestResultName4Units.Enabled = false;
        //    txtbetween1.Enabled = false;
        //    txtbetween2.Enabled = false;
        //    txtbetween3.Enabled = false;
        //    txtbetween4.Enabled = false;
        //    cboTestResultName2Condition.Enabled = false;
        //    cboTestResultName3Condition.Enabled = false;
        //}

        private bool CheckcboTestResultName1Condition()
        {
            if (txtTestResultName1.Text != string.Empty && cboTestResultName1Range.Text != string.Empty
                && txtTestResultName1Units.Text != string.Empty)
            {
                if (cboTestResultName1Range.Text.ToUpper() == "BETWEEN")
                {
                    if (txtbetween1.Text == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030010');", true);
                        return false;
                    }

                }
                return true;
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030011');", true);

            return false;
        }

        private bool CheckcboTestResultName2Condition()
        {
            if (txtTestResultName2.Text != string.Empty && cboTestResultName2Range.Text != string.Empty && txtTestResultName2Units.Text != string.Empty)
            {
                if (cboTestResultName2Range.Text.ToUpper() == "BETWEEN")
                {
                    if (txtbetween2.Text == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030010');", true);
                        return false;
                    }
                }
                return true;
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030011');", true);

            return false;
        }

        private bool CheckcboTestResultName3Condition()
        {
            if (txtTestResultName3.Text != string.Empty && cboTestResultName3Range.Text != string.Empty && txtTestResultName3Units.Text != string.Empty)
            {
                if (cboTestResultName3Range.Text.ToUpper() == "BETWEEN")
                {
                    if (txtbetween3.Text == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030010');", true);
                        return false;
                    }
                }
                return true;
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030011');", true);

            return false;
        }

        private bool CheckcboTestResultName4Condition()
        {
            if (txtTestResultName4.Text != string.Empty && cboTestResultName4Range.Text != string.Empty && txtTestResultName4Units.Text != string.Empty)
            {
                if (cboTestResultName4Range.Text.ToUpper() == "BETWEEN")
                {
                    if (txtbetween4.Text == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030010');", true);
                        return false;
                    }
                }
                return true;
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030011');", true);
            
            return false;
        }


        #endregion

        #region Class

        public class HeaderEventGenerate : PdfPageEventHelper
        {
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
                PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.Rectangle pageSize = document.PageSize;
                cb.BeginText();
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 10);
                cb.SetTextMatrix(pageSize.GetRight(220), pageSize.GetTop(40));
                //cb.ShowText(frmRxOrder.patientInfo);
                cb.EndText();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.Rectangle pageSize = document.PageSize;
                cb.BeginText();
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 10);
                cb.SetTextMatrix(pageSize.GetRight(70), pageSize.GetBottom(40));
                cb.ShowText("Page " + writer.PageNumber.ToString());
                cb.EndText();
            }
        }

        #endregion         

        protected void btnPrintPDF_Click(object sender, EventArgs e)
        {
            string strtime = hdnLocalTime.Value.ToString().Split('G').ElementAt(0).ToString();
            DateTime utc = new DateTime();
            if (strtime.ToString() != string.Empty)
                utc = Convert.ToDateTime(strtime);    
            IList<Documents> SaveList = new List<Documents>();
            IList<Documents> Updatelist = new List<Documents>();
            IList<Documents> Deletelist = new List<Documents>();
            Documents objDocument = new Documents();
            DocumentManager DocumentMngr = new DocumentManager();
            Encounter EncRecord = new Encounter();
            FillDocuments objdocument = null;
            var serializer = new NetDataContractSerializer();
            string[] sTestResultname = new string[4];
            string[] sCombination = new string[3];
            IList<string> ilstNdc = new List<string>();
            IList<string> ilstNdc_allergy = new List<string>();
            IList<string> FrequentProblemlist = new List<string>();
            IList<string> problemList = new List<string>();


            if (grdConditionReport.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7300005');", true);
                return;
            }
            else
            {
                if (ViewState["Med"] != null)
                {
                    ilstNdc = (IList<string>)ViewState["Med"];
                }
                if (ViewState["Med_Allergy"] != null)
                {
                    ilstNdc_allergy = (IList<string>)ViewState["Med_Allergy"];
                }
                if (ViewState["ProblemList"] != null)
                {
                    problemList = (IList<string>)ViewState["Med_Allergy"];
                }
                if (ViewState["TestResult"] != null)
                {
                    sTestResultname = (string[])ViewState["TestResult"];
                }
                if (ViewState["Combination"] != null)
                {
                    sCombination = (string[])ViewState["Combination"];
                }
                if (ViewState["ProbList"] != null)
                {
                    problemList = (IList<string>)ViewState["ProbList"];
                }
                if (ViewState["FreqProbList"] != null)
                {
                    FrequentProblemlist = (IList<string>)ViewState["FreqProbList"];
                }

                int strAgeLevel;
                if (txtAgeLevel.Text == "")
                {
                    strAgeLevel = 0;
                }
                else
                {
                    strAgeLevel = Convert.ToInt32(txtAgeLevel.Text);
                }

                DateTime enddate = rdtpToDate.SelectedDate.Value;
                enddate = enddate.AddDays(+1);
                Stream objPatientListStream = objHumanManager.ExportPatientLists(Convert.ToString(cboAge.Items[cboAge.SelectedIndex].Value), strAgeLevel, ConvertToInt(txtAgeRangeFrom.Text), ConvertToInt(txtAgeRangeTo.Text), cboGender.Text, cboRace.Text, cboEthnicity.Text, cboCommPreference.Text, ilstNdc.ToArray<string>(), ilstNdc_allergy.ToArray<string>(), problemList.ToArray<string>(), sTestResultname, sCombination, FrequentProblemlist.ToArray<string>(), rdtpFromDate.SelectedDate.Value.ToString("yyyy-MM-dd hh:mm:ss"), enddate.ToString("yyyy-MM-dd hh:mm:ss"));

                Session["Patientlist"] = (Stream)objPatientListStream;

                if (objPatientListStream != null)
                {
                    objDocument.Encounter_ID = 0;
                    objDocument.Human_ID = 0;
                    if (ClientSession.UserRole.ToUpper() == "PHYSICIAN" || ClientSession.UserRole.ToUpper() == "PHYSICIAN ASSISTANT")
                    {
                        objDocument.Physician_ID = ClientSession.PhysicianId;
                    }
                    else
                    {
                        objDocument.Physician_ID = Convert.ToUInt64(ClientSession.PhysicianId);
                    }
                    objDocument.Relationship = "";
                    objDocument.Created_By = ClientSession.UserName;
                    objDocument.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                    objDocument.Document_Type = "PatientList";
                    objDocument.Given_To = "";
                    objDocument.Given_By = ClientSession.UserName;
                    objDocument.Given_Date = UtilityManager.ConvertToUniversal();
                    SaveList.Add(objDocument);
                    ulong Encounter_ID = 0;
                    EncRecord = null;
                    objdocument = DocumentMngr.SaveUpdateDeleteDocument(SaveList.ToArray<Documents>(), Updatelist.ToArray<Documents>(), Deletelist.ToArray<Documents>(), EncRecord, Encounter_ID, string.Empty, false);




                    objPatientListStream.Position = 0;
                    object objPatientListMgr = (object)serializer.ReadObject(objPatientListStream);

                    Hashtable hsFindPatient = (Hashtable)objPatientListMgr;

                    PatientListResult = (IList<GeneratePatientListsDTO>)hsFindPatient["GeneratedPatientList"];

                    PrintResult(PatientListResult);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('7030013');", true);
                }
            }

        }
        //for bug id 29240 
        protected void InvisibleGenerateReport_Click(object sender, EventArgs e)  
        {
            if (Validation() == false)
                {
                    return;
                }
                string[] sTestResultname = new string[4];

                if (txtTestResultName1.Text != string.Empty)
                {

                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName1.Text);
                    if (cboTestResultName1Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName1Units.Text + Convert.ToString(cboTestResultName1Range.Items[cboTestResultName1Range.SelectedIndex].Value) + txtbetween1.Text;
                    }
                    else if (cboTestResultName1Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName1Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName1Range.Items[cboTestResultName1Range.SelectedIndex].Value) + txtTestResultName1Units.Text;
                    }
                    sTestResultname[0] = scondtion;
                }
                // if (cboTestResultName1Condition.Text != string.Empty)
                if (txtTestResultName2.Text != string.Empty)
                {

                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName2.Text);
                    if (cboTestResultName2Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName2Units.Text + Convert.ToString(cboTestResultName2Range.Items[cboTestResultName2Range.SelectedIndex].Value) + txtbetween2.Text;
                    }
                    else if (cboTestResultName2Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName2Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName2Range.Items[cboTestResultName2Range.SelectedIndex].Value) + txtTestResultName2Units.Text;
                    }
                    sTestResultname[1] = scondtion;
                }
                // if (cboTestResultName2Condition.Text != string.Empty)
                if (txtTestResultName3.Text != string.Empty)
                {
                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName3.Text);
                    if (cboTestResultName3Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName3Units.Text + Convert.ToString(cboTestResultName3Range.Items[cboTestResultName3Range.SelectedIndex].Value) + txtbetween3.Text;
                    }
                    else if (cboTestResultName3Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName3Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName3Range.Items[cboTestResultName3Range.SelectedIndex].Value) + txtTestResultName3Units.Text;
                    }
                    sTestResultname[2] = scondtion;
                }

                //if (cboTestResultName3Condition.Text != string.Empty)
                if (txtTestResultName4.Text != string.Empty)
                {
                    string scondtion = string.Empty;
                    scondtion = Convert.ToString(txtTestResultName4.Text);
                    if (cboTestResultName4Range.Text.ToUpper() == "BETWEEN")
                    {
                        scondtion = scondtion + "@" + txtTestResultName4Units.Text + Convert.ToString(cboTestResultName4Range.Items[cboTestResultName4Range.SelectedIndex].Value) + txtbetween4.Text;
                    }
                    else if (cboTestResultName4Range.Text.ToUpper() == "GREATER THAN" || cboTestResultName4Range.Text.ToUpper() == "LESS THAN")
                    {
                        scondtion = scondtion + "@" + Convert.ToString(cboTestResultName4Range.Items[cboTestResultName4Range.SelectedIndex].Value) + txtTestResultName4Units.Text;
                    }
                    sTestResultname[3] = scondtion;
                }

                string[] sCombination = new string[3];
                if (txtTestResultName2.Text != string.Empty)
                    sCombination[0] = "OR";
                if (txtTestResultName3.Text != string.Empty)
                    sCombination[1] = "OR";
                if (txtTestResultName4.Text != string.Empty)
                    sCombination[2] = "OR";

                string sImmunDescription = string.Empty;
                //if (cboProcedure.Text != string.Empty && cboDescriptiontaken.Text != string.Empty)
                //{
                //    sImmunDescription = Convert.ToString(cboProcedure.Items[cboProcedure.SelectedIndex].Text) + "+" + Convert.ToString(cboDescriptiontaken.Items[cboDescriptiontaken.SelectedIndex].Value);
                //}

                IList<string> ilstNdc = new List<string>();

                // if (SelectedMedicationList.Count > 0)
                //{
                //    for (int i = 0; i < SelectedMedicationList.Count; i++)
                //    {
                //        string[] splitval = SelectedMedicationList[i].ToString().Split('+');
                //        ilstNdc.Add(splitval[0].ToString());
                //    }
                //}    
                IList<string> ilstNdc_allergy = new List<string>();

                if (txtMedication.Text == "")
                {
                    searchedMedications.Value = "";
                }
                if (!searchedMedications.Value.Equals(""))
                {
                    SelectedMedicationList = searchedMedications.Value.Split(';');
                    for (int i = 0; i < SelectedMedicationList.Count; i++)
                    {
                        if (SelectedMedicationList[i].ToString() != "")
                        {
                            string[] splitval = SelectedMedicationList[i].ToString().Split('+');
                            ilstNdc.Add(splitval[0].ToString());
                        }
                    }
                }

                if (txtMedicationAllergy.Text == "")
                {
                    hdnMedAllergy.Value = "";
                }
                if (!hdnMedAllergy.Value.Equals(""))
                {
                    SelectedMedicationAllrgyList = hdnMedAllergy.Value.Split(';');
                    for (int i = 0; i < SelectedMedicationAllrgyList.Count; i++)
                    {
                        if (SelectedMedicationAllrgyList[i].ToString() != "")
                        {
                            string[] splitval = SelectedMedicationAllrgyList[i].ToString().Split('+');
                            ilstNdc_allergy.Add(splitval[0].ToString());
                        }
                    }
                }
                loadGeneratedPatientList(ilstNdc_allergy, ilstNdc, sImmunDescription, sTestResultname, sCombination);
                divLoading.Style.Add("display", "none");
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnExportToExcel);
        }
           
    }
}
