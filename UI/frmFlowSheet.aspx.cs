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
using System.Runtime.Serialization;
using Acurus.Capella.UI;
using System.IO;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Services;
using System.Globalization;

namespace Acurus.Capella.UI
{
    public partial class frmFlowSheet : System.Web.UI.Page
    {
        FlowSheetTemplateManager objFlowSheetTemplateManager = new FlowSheetTemplateManager();
        UIManager objUIManager = new UIManager();
        PhysicianManager objPhysicianManager = new PhysicianManager();
        StaticLookupManager objStaticLookupManager = new StaticLookupManager();
        MasterVitalsManager objMasterVitalsManager = new MasterVitalsManager();
        MapVitalsPhysicianManager objMapVitalsPhysicianManager = new MapVitalsPhysicianManager();

        bool _IsPhysician;
        bool _IsMA;
        string _facilityName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            fromDate.Enabled = rdRange.Checked;
            todate.Enabled = rdRange.Checked;

            radiobtnvalidation();

            _IsPhysician = string.Compare(ClientSession.UserRole, "PHYSICIAN", true) == 0 ||
                            string.Compare(ClientSession.UserRole, "PHYSICIAN ASSISTANT", true) == 0;

            _IsMA = string.Compare(ClientSession.UserRole, "MEDICAL ASSISTANT", true) == 0;

            if (!IsPostBack)
            {

                SecurityServiceUtility objSecurity = new SecurityServiceUtility();
                objSecurity.ApplyUserPermissions(this.Page);

                pbLibraryCondition.Enabled = _IsPhysician;
                cboPhysician.Enabled = !_IsPhysician;
                chkShowallPhysician.Enabled = !_IsPhysician;

                fromDate.Enabled = rdRange.Checked;
                todate.Enabled = rdRange.Checked;

                IsFromClear.Value = string.Empty;

                if (_IsPhysician)
                {
                    pbLibraryCondition.ImageUrl = "~/Resources/Database Inactive.jpg";
                }
                else if (_IsMA)
                {
                    pbLibraryCondition.ImageUrl = "~/Resources/Database Disable.png";
                    pbLibraryCondition.ToolTip = string.Empty;
                    _facilityName = ClientSession.FacilityName;
                }

                pbLibraryCondition.Enabled = _IsPhysician;
                pbLibraryCondition.Style[HtmlTextWriterStyle.Cursor] = _IsPhysician ? "pointer" : "default";
                rdAll.Checked = true;
                hdnPhyId.Value = string.Empty;

                LoadPhysicianDetailsXML(_IsPhysician);
            }
            else if (_IsPhysician)
            {
                LoadTemplates(SelectedItem.Value, _IsPhysician, ClientSession.PhysicianId);
            }

            if (!string.IsNullOrEmpty(IsFromClear.Value.Trim()))
            {
                IsFromClear.Value = string.Empty;
                cboFlowSheet.SelectedIndex = -1;
            }
        }

        List<string> GetPhysicianDetails(string facilityName)
        {
            List<string> lstDetails = new List<string>();

            XDocument xmlDocumentType = XDocument.Load(Server.MapPath(@"ConfigXML\PhysicianFacilityMapping.xml"));

            foreach (XElement elements in xmlDocumentType.Elements("ROOT").Elements("PhyList").Elements())
            {
                string xmlValue = elements.Attribute("name").Value;

                foreach (XElement phyItems in elements.Elements())
                {
                    string phyName = string.Empty;

                    string userName = phyItems.Attribute("username").Value;
                    string prefix = phyItems.Attribute("prefix").Value;
                    string firstName = phyItems.Attribute("firstname").Value;
                    string middleName = phyItems.Attribute("middlename").Value;
                    string lastName = phyItems.Attribute("lastname").Value;
                    string suffix = phyItems.Attribute("suffix").Value;
                    string physicianId = phyItems.Attribute("ID").Value;

                    if (prefix != "")
                    {
                        phyName += prefix + " ";
                    }
                    if (firstName != "")
                    {
                        phyName += firstName + " ";
                    }
                    if (middleName != "")
                    {
                        phyName += middleName + " ";
                    }
                    if (lastName != "")
                    {
                        phyName += lastName + " ";
                    }
                    if (suffix != "")
                    {
                        phyName += suffix;
                    }

                    if ((string.IsNullOrEmpty(facilityName) || string.Compare(facilityName, xmlValue, true) == 0) && elements.Attribute("Legal_Org").Value == ClientSession.LegalOrg)
                    {
                        if (userName != string.Empty)
                        {
                            lstDetails.Add(userName + " - " + phyName + "~" + physicianId);
                        }
                    }
                }
            }
            return lstDetails.Distinct().OrderBy(a => a).ToList();
        }

        void LoadPhysicianDetailsXML(bool isOnLoad)
        {
            cboPhysician.Items.Clear();
            cboPhysician.Items.Add(new RadComboBoxItem(""));

            if (_IsMA)
                _facilityName = ClientSession.FacilityName;

            if (chkShowallPhysician.Checked)
                _facilityName = string.Empty;

            var lstPhysicianDetails = GetPhysicianDetails(_facilityName);


            for (int i = 0; i < lstPhysicianDetails.Count; i++)
            {
                var arrDetails = lstPhysicianDetails[i].Split('~');

                string physicianName = arrDetails[0];

                cboPhysician.Items.Add(new RadComboBoxItem(physicianName));

                cboPhysician.Items[i + 1].Value = arrDetails[1];
                cboPhysician.Items[i + 1].ToolTip = cboPhysician.Items[i + 1].Text;

                if (isOnLoad)
                {
                    if (Convert.ToUInt32(cboPhysician.Items[i + 1].Value) == Convert.ToInt32(ClientSession.PhysicianId))
                    {
                        cboPhysician.Text = ClientSession.UserName;
                        cboPhysician.SelectedIndex = i + 1;
                        chkShowallPhysician.Checked = true;
                    }
                }
            }

            if (chkShowallPhysician.Checked)
            {
                var objPhysicianLibrary = (from p in lstPhysicianDetails
                                           where (string.Compare(p.Split('~')[1], Convert.ToString(ClientSession.PhysicianId), true) == 0)
                                           select p).FirstOrDefault();

                if (objPhysicianLibrary != null)
                {

                    var arrDetails = objPhysicianLibrary.Split('~');
                    string PhysicianName = arrDetails[0];

                    if (_IsPhysician)
                    {
                        cboPhysician.Text = ClientSession.UserName + " - " + PhysicianName;
                    }
                }
            }

            if (isOnLoad)
            {
                LoadTemplates(string.Empty, true, ClientSession.PhysicianId);
            }
            if (_IsMA)
            {
                cboPhysician.SelectedIndex = 0;
                ClearGridValues();
            }
        }

        #region Commented for Bug_Id = 37300

        /*****************************************************************************
            *                                                                           *
            *         Commented for Bug_Id = 37300   ~ Ponmozhi Vendan T                *
            *                                                                           *
            * *************************************************************************** 
        void LoadPhysicainDetails(bool isOnLoad)
        {
            FillPhysicianUser PhyUserList = new FillPhysicianUser();

            cboPhysician.Items.Clear();
            cboPhysician.Items.Add(new RadComboBoxItem(""));

            if (_IsMA)
                _facilityName = ClientSession.FacilityName;

            if (chkShowallPhysician.Checked)
                _facilityName = string.Empty;

            PhyUserList = objPhysicianManager.GetPhysicianUser(_facilityName);

            for (int i = 0; i < PhyUserList.PhyList.Count; i++)
            {
                string physicianName = PhyUserList.UserList[i].user_name + " - " +
                                       PhyUserList.PhyList[i].PhyPrefix + " " +
                                       PhyUserList.PhyList[i].PhyFirstName + " " +
                                       PhyUserList.PhyList[i].PhyMiddleName + " " +
                                       PhyUserList.PhyList[i].PhyLastName + " " +
                                       PhyUserList.PhyList[i].PhySuffix;

                cboPhysician.Items.Add(new RadComboBoxItem(physicianName));

                cboPhysician.Items[i + 1].Value = PhyUserList.PhyList[i].Id.ToString();
                cboPhysician.Items[i + 1].ToolTip = cboPhysician.Items[i + 1].Text;

                if (isOnLoad)
                {
                    if (Convert.ToUInt32(cboPhysician.Items[i + 1].Value) == Convert.ToInt32(ClientSession.PhysicianId))
                    {
                        cboPhysician.Text = ClientSession.UserName;
                        cboPhysician.SelectedIndex = i + 1;
                        chkShowallPhysician.Checked = true; // string.IsNullOrEmpty(cboPhysician.Text); //comment by baljai.TJ
                    }
                }
            }

            if (chkShowallPhysician.Checked)
            {
                var objPhysicianLibrary = (from p in PhyUserList.PhyList
                                           where (p.Id == ClientSession.PhysicianId)
                                           select p).FirstOrDefault();

                if (objPhysicianLibrary != null)
                {
                    string PhysicianName = objPhysicianLibrary.PhyPrefix + " " +
                                           objPhysicianLibrary.PhyFirstName + " " +
                                           objPhysicianLibrary.PhyMiddleName + " " +
                                           objPhysicianLibrary.PhyLastName + " " +
                                           objPhysicianLibrary.PhySuffix;
                    if (_IsPhysician)
                    {
                        cboPhysician.Text = ClientSession.UserName + " - " + PhysicianName;
                    }
                }
            }
            if (isOnLoad)
            {
                LoadTemplates(string.Empty, true, ClientSession.PhysicianId);
            }
            if (_IsMA)
            {
                cboPhysician.SelectedIndex = 0;
                ClearGridValues();
            }
        }*/

        #endregion

        void ClearGridValues()
        {
            grdFlowSheet.DataSource = null;
            grdFlowSheet.DataBind();
        }

        void LoadTemplates(string flowSheetTemplateName, bool isCheck, ulong physicianId)
        {
            cboFlowSheet.Items.Clear();

            IList<FlowSheetTemplate> flowList = new List<FlowSheetTemplate>();

            flowList = objFlowSheetTemplateManager.GetFlowSheetTemplate(physicianId);

            var flow = from f in
                           flowList
                       group f by f.Template_Name
                           into g
                           select new { Temp = g.Key };

            cboFlowSheet.Items.Add(new RadComboBoxItem(" "));

            foreach (var g in flow)
            {
                cboFlowSheet.Items.Add(new RadComboBoxItem(g.Temp.Trim()));
            }

            if (!string.IsNullOrEmpty(flowSheetTemplateName))
            {
                cboFlowSheet.Text = flowSheetTemplateName.ToUpper();
                cboFlowSheet.SelectedIndex = cboFlowSheet.Items.Cast<RadComboBoxItem>()
                                                         .Where(a => a.Text == SelectedItem.Value.ToUpper())
                                                         .Select(b => b.Index)
                                                         .SingleOrDefault();
            }

            if (chkShowallPhysician.Checked)
            {
                cboPhysician.SelectedIndex = cboPhysician.Items.
                                             IndexOf(cboPhysician.Items.FindItemByValue(physicianId.ToString()));// +1; 
            }

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            grdFlowSheet.DataSource = null;
            grdFlowSheet.DataBind();

            IList<PatientResults> lstPatientResults = new List<PatientResults>();
            IList<ResultOBX> lstResults = new List<ResultOBX>();

            var physicianId = string.IsNullOrEmpty(hdnPhyId.Value) ?
                                    ClientSession.PhysicianId :
                                    Convert.ToUInt32(hdnPhyId.Value);

            DateTime From = DateTime.MinValue;
            DateTime To = UtilityManager.ConvertToUniversal(DateTime.Today);
            DateTime dt = DateTime.MinValue;

            if (rdAll.Checked)
            {
                lstPatientResults = objFlowSheetTemplateManager.GetFlowSheetDetails(ClientSession.HumanId,
                                                                                cboFlowSheet.Text,
                                                                                physicianId);
                lstResults = objFlowSheetTemplateManager.GetFlowSheetDetailsForResults(ClientSession.HumanId,
                                                                                cboFlowSheet.Text,
                                                                                physicianId);
            }
            else
            {
                if (rdLast3Month.Checked)
                    dt = UtilityManager.ConvertToUniversal(DateTime.Today.AddMonths(-3));

                else if (rdLast6Month.Checked)
                    dt = UtilityManager.ConvertToUniversal(DateTime.Today.AddMonths(-6));

                else if (rdLast12Month.Checked)
                    dt = UtilityManager.ConvertToUniversal(DateTime.Today.AddMonths(-12));
                else
                {
                    try
                    {
                        string fromValue = fromDate.SelectedDate.Value.ToString();
                        string toValue = todate.SelectedDate.Value.ToString();

                        dt = UtilityManager.ConvertToUniversal(Convert.ToDateTime(fromValue));
                        To = UtilityManager.ConvertToUniversal(Convert.ToDateTime(toValue));

                        dt = Convert.ToDateTime(fromValue);
                        To = Convert.ToDateTime(toValue);
                    }
                    catch
                    {
                        // Error Message for invalid dates
                    }
                }

                From = dt;
                TimeSpan ts = new TimeSpan(00, 00, 0);
                From = dt.Date + ts;

                lstPatientResults = objFlowSheetTemplateManager.
                                 GetFlowSheetDetailsByDate(ClientSession.HumanId,
                                                           cboFlowSheet.Text,
                                                           From.ToString("yyyy-MM-dd HH:mm:ss"),
                                                           To.AddDays(2).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"),
                                                           physicianId);

                IList<PatientResults> tempList = new List<PatientResults>();
                //Convert to local
                foreach (PatientResults pt in lstPatientResults)
                {
                    pt.Captured_date_and_time = UtilityManager.ConvertToLocal(pt.Captured_date_and_time);
                    
                    tempList.Add(pt);
                }


                tempList = tempList.Where(a => a.Captured_date_and_time >= From && a.Captured_date_and_time <= To.AddDays(1).AddSeconds(-1)).ToList<PatientResults>();
                lstPatientResults = tempList;

                //Convert to utc 
                tempList = new List<PatientResults>();
                foreach (PatientResults pt in lstPatientResults)
                {
                    pt.Captured_date_and_time = UtilityManager.ConvertToUniversal(pt.Captured_date_and_time);
                    tempList.Add(pt);
                }
                lstPatientResults = tempList;

                lstResults = objFlowSheetTemplateManager.
                                GetFlowSheetDetailsByDateForResults(ClientSession.HumanId,
                                                          cboFlowSheet.Text,
                                                          From.ToString("yyyy-MM-dd HH:mm:ss"),
                                                          To.AddDays(2).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"),
                                                          physicianId);

                //IList<ResultOBX> tempOBXList = new List<ResultOBX>();
                ////Convert to local
                ////foreach (ResultOBX pt in lstResults)
                ////{
                ////    DateTime dtTemp = DateTime.ParseExact(pt.OBX_Date_And_Time_Of_Observation.Substring(0, 12), "yyyyMMddHHmm", CultureInfo.InvariantCulture);
                ////    pt.OBX_Date_And_Time_Of_Observation = UtilityManager.ConvertToLocal(dtTemp);
                ////    tempOBXList.Add(pt);
                ////}

                //tempList = tempOBXList.Where(a => a.Captured_date_and_time >= From && a.Captured_date_and_time <= To.AddDays(1).AddSeconds(-1)).ToList<PatientResults>();
                //lstPatientResults = tempList;

                ////Convert to utc 
                //tempList = new List<PatientResults>();
                //foreach (PatientResults pt in lstPatientResults)
                //{
                //    pt.Captured_date_and_time = UtilityManager.ConvertToUniversal(pt.Captured_date_and_time);
                //    tempList.Add(pt);
                //}
                //lstPatientResults = tempList;
            }

            if (lstPatientResults.Count == 0 && lstResults.Count==0)
            {
                lblMessage.Visible = true;
                grdFlowSheet.Columns[0].Visible = false;
            }
            else
            {
                lblMessage.Visible = false;
                grdFlowSheet.Columns[0].Visible = true;
                BindGridValues(lstPatientResults,lstResults);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }

        #region Old_Code
        /* void BindGridValues_Old(IList<PatientResults> lstVitals)
        {
            DataTable dtFlowSheet = new DataTable();

            dtFlowSheet.Columns.Add("Category", typeof(string));

            IList<DateTime> DOSList = new List<DateTime>();
            DataRow dtNewRow;

            UIManager UIMngr = new UIManager();
            FlowSheetTemplateManager objFlowSheetMngr = new FlowSheetTemplateManager();

            if (lstVitals.Count != 0)
            {
                IList<DateTime> TempDOSList = new List<DateTime>();

                var enc = (from en in lstVitals orderby en.Captured_date_and_time select en.Captured_date_and_time);
                TempDOSList = enc.ToList<DateTime>();

                for (int j = 0; j < TempDOSList.Count; j++)
                {
                    if (j != 0)
                    {
                        if (TempDOSList[j] == TempDOSList[j - 1])
                        {
                            continue;
                        }
                    }
                    DOSList.Add(UtilityManager.ConvertToLocal(TempDOSList[j]));
                }
            }

            var DOSAsendingList = DOSList.OrderByDescending(c => c.Date).ThenByDescending(n => n.TimeOfDay);

            DOSList = DOSAsendingList.ToList<DateTime>();


            for (int i = 0; i < DOSList.Count; i++)
            {

                GridBoundColumn d = new GridBoundColumn();
                d.HeaderText = DOSList[i].ToString("dd-MMM-yyyy hh:mm tt");
                var Result = (from c in dtFlowSheet.Columns.Cast<DataColumn>() where c.ColumnName == d.HeaderText select c);
                if (Result.Count() == 0)
                {
                    dtFlowSheet.Columns.Add(d.HeaderText, typeof(string));
                }
            }

            string sRowIndex = string.Empty;

            IList<FlowSheetTemplate> flowList = objFlowSheetMngr.GetFlowSheetTemplateByTemplateName(cboFlowSheet.Text.ToUpper());

            string[] strVitalList = null;
            IList<string> vitalList = new List<string>();
            for (int j = 0; j < flowList.Count; j++)
            {
                strVitalList = flowList[j].Acurus_Result_Code.Split('|');
                for (int i = 0; i < strVitalList.Length; i++)
                {
                    vitalList.Add(strVitalList[i].ToString());
                }
            }

            IList<PatientResults> FlowsheetListForVitals = new List<PatientResults>();
            for (int k = 0; k < vitalList.Count; k++)
            {
                var query1 = from p in lstVitals where p.Acurus_Result_Code == vitalList[k] select p;
                IList<PatientResults> patientResultList = query1.ToList<PatientResults>();
                FlowsheetListForVitals = FlowsheetListForVitals.Concat(patientResultList).ToList<PatientResults>();
            }
            for (int i = 0; i < FlowsheetListForVitals.Count; i++)
            {
                bool bNewRow = true;

                if (FlowsheetListForVitals[i].Value != string.Empty)
                {
                    for (int j = 0; j < dtFlowSheet.Rows.Count; j++)
                    {
                        DataRow dtRow = dtFlowSheet.Rows[j];
                        if (dtRow["Category"].ToString() == FlowsheetListForVitals[i].Acurus_Result_Description)
                        {
                            sRowIndex = j.ToString();
                            break;
                        }
                    }
                    if (sRowIndex == string.Empty)
                    {
                        dtNewRow = dtFlowSheet.NewRow();
                    }
                    else
                    {
                        bNewRow = false;
                        dtNewRow = dtFlowSheet.Rows[Convert.ToInt32(sRowIndex)];
                    }
                    sRowIndex = string.Empty;
                    dtNewRow["Category"] = FlowsheetListForVitals[i].Acurus_Result_Description;
                    // dtNewRow["Unit"] = FlowsheetListForVitals[i].Units;
                    string sVitalValue = FlowsheetListForVitals[i].Value;

                    switch (FlowsheetListForVitals[i].Units)
                    {
                        case "CM":
                            sVitalValue = UIMngr.ConvertInchesToCM(FlowsheetListForVitals[i].Value);
                            break;

                        case "Kg":
                            sVitalValue = UIMngr.ConvertLbsToKg(FlowsheetListForVitals[i].Value);
                            break;

                        case "Celsius":
                            sVitalValue = UIMngr.ConvertFarenheitToCelsius(FlowsheetListForVitals[i].Value);
                            break;

                        case "Ft Inch":
                            //sVitalValue = UIMngr.ConvertInchtoFeetInch(FlowsheetListForVitals[i].Value); //changed for bug id 28382,27914
                            if (sVitalValue.Contains("'") == true && sVitalValue.Contains("''") == true)
                            {
                                sVitalValue = FlowsheetListForVitals[i].Value;
                                break;
                            }
                            else
                            {
                                sVitalValue = UIMngr.ConvertInchtoFeetInch(FlowsheetListForVitals[i].Value);
                                break;
                            }
                    }
                    dtNewRow[UtilityManager.ConvertToLocal(FlowsheetListForVitals[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")] = sVitalValue + "  " + FlowsheetListForVitals[i].Units;
                    if (bNewRow == true)
                    {
                        dtFlowSheet.Rows.Add(dtNewRow);
                    }
                }
            }

            grdFlowSheet.DataSource = dtFlowSheet;
            grdFlowSheet.DataBind();

            fromDate.Enabled = rdRange.Checked;
            todate.Enabled = rdRange.Checked;
        } */
        #endregion
        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            grdFlowSheet.MasterTableView.HeaderStyle.Width = Unit.Pixel(95);
            grdFlowSheet.MasterTableView.HeaderStyle.Wrap = true;
        }
        void BindGridValues(IList<PatientResults> lstVitals, IList<ResultOBX> lstResults)
        {
            DataTable dtFlowSheet = new DataTable();

            var rowValues = lstVitals.GroupBy(a => a.Acurus_Result_Description)
                                     .Select(a => new
                                     {
                                         Vitals_Name = a.Key,
                                         Vital_List = a.GroupBy(f => f.Captured_date_and_time)
                                                       .Select(m => new
                                                       {
                                                           Date_Time = m.Key,
                                                           VitalValue = GetValueUnits(m.ToList().FirstOrDefault().Value,
                                                                                     m.ToList().FirstOrDefault().Units),

                                                       }).OrderBy(D => D.Date_Time)
                                     }).ToList();

            var rowValuesResults = lstResults.GroupBy(a => a.OBX_Observation_Text)
                                    .Select(a => new
                                    {
                                        Vitals_Name = a.Key,
                                        Vital_List = a.GroupBy(f => f.OBX_Date_And_Time_Of_Observation)
                                                      .Select(m => new
                                                      {
                                                          Date_Time = m.Key,
                                                           VitalValue =  m.ToList().FirstOrDefault().OBX_Observation_Value,
                                                      }).OrderBy(D => D.Date_Time)
                                    }).ToList();

            var distinctDates = lstVitals.GroupBy(a => a.Captured_date_and_time)
                                         .Select(a => a.Key)
                                         .OrderBy(a => a).ToList();

            var distinctDatesResults = lstResults.GroupBy(a => a.OBX_Date_And_Time_Of_Observation)
                                       .Select(a => a.Key)
                                       .OrderBy(a => a).ToList();

            ArrayList objDataColumn = new ArrayList();

            if (lstVitals.Count() > 0 || lstResults.Count()>0)
            {
                objDataColumn.Add("Category");

                for (int i = 0; i < distinctDates.Count; i++)
                {
                    var columnName = UtilityManager.ConvertToLocal(distinctDates[i]).ToString("dd-MMM-yyyy hh:mm tt");

                    while (objDataColumn.Contains(columnName))
                    {
                        columnName += " ";
                    }

                    objDataColumn.Add(columnName);
                }

                for (int i = 0; i < distinctDatesResults.Count; i++)
                {
                    var columnName = DateTime.ParseExact(distinctDatesResults[i].Substring(0, 12), "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy hh:mm tt");

                    while (objDataColumn.Contains(columnName))
                    {
                        columnName += " ";
                    }

                    objDataColumn.Add(columnName);
                }
            }

            for (int i = 0; i < objDataColumn.Count; i++)
            {
                StringBuilder ColumnName = new StringBuilder(Convert.ToString(objDataColumn[i]));

                try
                {
                    dtFlowSheet.Columns.Add(ColumnName.ToString());
                }
                catch (System.Data.DuplicateNameException)
                {
                    ColumnName.Append(" ");
                    dtFlowSheet.Columns.Add(ColumnName.ToString());
                }
            }

            for (int i = 0; i < rowValues.Count; i++)
            {
                List<string> tempList = new List<string>();

                tempList.Add(rowValues[i].Vitals_Name);

                var res = rowValues[i].Vital_List;

                for (int d = 0; d < distinctDates.Count; d++)
                {
                    var curDate = distinctDates[d];
                    var VitalValue = res.Where(a => a.Date_Time == curDate).Select(a => a.VitalValue).FirstOrDefault();
                    tempList.Add(Convert.ToString(VitalValue));
                }

                dtFlowSheet.Rows.Add(tempList.ToArray<string>());
            }

            for (int i = 0; i < rowValuesResults.Count; i++)
            {
                List<string> tempList = new List<string>();

                tempList.Add(rowValuesResults[i].Vitals_Name);

                var res = rowValuesResults[i].Vital_List;

                for (int d = 0; d < distinctDatesResults.Count; d++)
                {
                    string curDate = DateTime.ParseExact(distinctDatesResults[d].Substring(0, 12), "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("yyyyMMddHHmm");
                    var VitalValue = res.Where(a => a.Date_Time == curDate).Select(a => a.VitalValue).FirstOrDefault();
                    tempList.Add(Convert.ToString(VitalValue));
                }

                dtFlowSheet.Rows.Add(tempList.ToArray<string>());
            }

            grdFlowSheet.DataSource = dtFlowSheet;
            grdFlowSheet.DataBind();

            fromDate.Enabled = rdRange.Checked;
            todate.Enabled = rdRange.Checked;
        }

        string GetValueUnits(string vitalValues, string vitalUnits)
        {
            var returnString = string.Empty;

            switch (vitalUnits)
            {
                case "CM":
                    returnString = objUIManager.ConvertInchesToCM(vitalValues);
                    break;

                case "Kg":
                    returnString = objUIManager.ConvertLbsToKg(vitalValues);
                    break;

                case "Celsius":
                    returnString = objUIManager.ConvertFarenheitToCelsius(vitalValues);
                    break;

                case "Ft Inch":

                    returnString = (vitalValues.Contains("'") &&
                                    vitalValues.Contains("''")) ?
                                         vitalValues :
                                         objUIManager.ConvertInchtoFeetInch(vitalValues);
                    break;
                default:
                    returnString = vitalValues;
                    break;
            }
            return returnString + " " + vitalUnits;
        }

        protected void chkShowallPhysician_CheckedChanged(object sender, EventArgs e)
        {
            LoadPhysicianDetailsXML(_IsPhysician);
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }

        protected void cboPhysician_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            hdnPhyId.Value = string.Empty;

            var physicianId = cboPhysician.SelectedValue;

            if(physicianId != null && physicianId != string.Empty)
            LoadTemplates(string.Empty, true, Convert.ToUInt32(physicianId));

            hdnPhyId.Value = physicianId;

            ClearGridValues();
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, " {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
        }

        protected void InvisibleButton_Click(object sender, EventArgs e)
        {
            cboFlowSheet.Text = string.Empty;
            SelectedItem.Value = string.Empty;

            DataTable dt = new DataTable();

            grdFlowSheet.DataSource = dt;
            grdFlowSheet.DataBind();

            fromDate.SelectedDate = null;
            todate.SelectedDate = null;
        }

        protected void pbLibraryCondition_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = new DataTable();
            grdFlowSheet.DataSource = dt;
            grdFlowSheet.DataBind();
            grdFlowSheet.Columns[0].Visible = false;
        }

        private void radiobtnvalidation()
        {
            if (rdAll.Checked || rdLast3Month.Checked ||
                rdLast6Month.Checked || rdLast12Month.Checked)
            {
                DisableRangeControls();
            }
        }

        void DisableRangeControls()
        {
            rdRange.Checked = false;
            fromDate.SelectedDate = null;
            fromDate.Enabled = false;
            todate.SelectedDate = null;
            todate.Enabled = false;
        }
    }
}
