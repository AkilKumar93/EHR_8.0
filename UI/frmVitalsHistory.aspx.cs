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
using Acurus.Capella.Core.DTO;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using System.Text.RegularExpressions;
using System.Drawing;
using Acurus.Capella.DataAccess.ManagerObjects;
namespace Acurus.Capella.UI
{
    public partial class frmVitalsHistory : System.Web.UI.Page
    {
        //ulong MyHumanID=0;
        FlowSheetTemplateManager flowsheetmngr = new FlowSheetTemplateManager();
        EncounterManager encMngr = new EncounterManager();
        IList<PatientResults> vitalHistory = null;
        IList<PatientPane> patientPane;
        bool Panelbar = true;
        bool Is_NewRow = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //MyHumanID = ClientSession.HumanId;
            patientPane = new List<PatientPane>();
            vitalHistory = new List<PatientResults>();
            if (!IsPostBack)
            {
                //ClientSession.processCheck = true;
                //SecurityServiceUtility objSecurityServiceUtility = new SecurityServiceUtility();
                //objSecurityServiceUtility.ApplyUserPermissions(this);//Commented for Bug ID:28986
                //ClientSession.FlushSession();
                vitalHistory = flowsheetmngr.GetPatientResultsforFlowSheet(ClientSession.HumanId,ClientSession.PhysicianId);
                //Srividhya added the last parameter as set as true
                //patientPane = encMngr.FillPatientPane(ClientSession.HumanId, string.Empty, ClientSession.UserName,true);
            }
            string sPriPlan = string.Empty;
            string sSecPlan = string.Empty;
            string sPriCarrier = string.Empty;
            string sSecCarrier = string.Empty;

            if (patientPane != null && patientPane.Count > 0)
            {
                if (patientPane[patientPane.Count - 1].Insurance_Plan_ID != null)
                {

                    for (int i = 0; i < patientPane[patientPane.Count - 1].Insurance_Plan_ID.Count; i++)
                    {
                        if (patientPane[patientPane.Count - 1].Insurance_Type[i].ToString() == "PRIMARY")
                        {
                            sPriPlan = patientPane[patientPane.Count - 1].Ins_Plan_Name[i].ToString();
                            sPriCarrier = patientPane[patientPane.Count - 1].CarrierName[i].ToString();
                        }

                        if (patientPane[patientPane.Count - 1].Insurance_Type[i].ToString() == "SECONDARY")
                        {
                            sSecPlan = patientPane[patientPane.Count - 1].Ins_Plan_Name[i].ToString();
                            sSecCarrier = patientPane[patientPane.Count - 1].CarrierName[i].ToString();
                        }
                    }
                }
             //   lblPatientStrip.Items[0].Text = FillPatientSummaryBarforPatientChart(patientPane[0].Last_Name, patientPane[0].First_Name, patientPane[0].MI, patientPane[0].Suffix, patientPane[0].Birth_Date, patientPane[0].Human_Id, patientPane[0].Medical_Record_Number, patientPane[0].HomePhoneNo, patientPane[0].Sex, patientPane[0].Patient_Status, patientPane[0].SSN, patientPane[0].Patient_Type, sPriPlan, sPriCarrier, sSecPlan, sSecCarrier);
              //  string PanelToolTip = lblPatientStrip.Items[0].Text;

                //int indexPri = PanelToolTip.IndexOf("Pri Plan:");
                //int indexSec = PanelToolTip.IndexOf("Sec Plan:");
                //int indexSSN = PanelToolTip.IndexOf("SSN:");
                //if (indexPri != -1)
                //{
                //    lblPatientStrip.ToolTip = PanelToolTip.Insert(indexPri, "\n");
                //}
                //else if (indexSec != -1)
                //{
                //    lblPatientStrip.ToolTip = PanelToolTip.Insert(indexSec, "\n");
                //}
                //else if (indexSSN != -1)
                //{
                //    lblPatientStrip.ToolTip = PanelToolTip.Insert(indexSSN, "\n");
                //}
                //else
                //{
                //    lblPatientStrip.ToolTip = lblPatientStrip.Items[0].Text;
                //}
            }

            DataSet ds = new DataSet();
            DataTable dtTable = new DataTable();
            DataRow dr = null;

            //GridViewDataColumn v = new GridViewDataColumn();
            //BoundField v = new BoundField(); 
            dtTable.Columns.Add("Category");// v.HeaderText = "Category";
            //v.Width = 100;
            //v.MinWidth = 80;
            //v.MaxWidth = 110;
            //v.WrapText = true;
            //grdPastVitals.Columns.Add(v);


            // 
            if (!Panelbar)
            {
                //pnlbarPatientDetail.Visible = false;
                //tblPastvitalsHistory.SetRow(gbPastVitals, 0);
                //tblPastvitalsHistory.SetRowSpan(gbPastVitals, 2);
            }
            //StaticLookupManager staticLookupManager = new StaticLookupManager();
            // IList<StaticLookup> iFieldLookupList =new List<StaticLookup>();
            //if (ClientSession.VitalLimitLookup.Count > 0)
            //    iFieldLookupList = ClientSession.VitalLimitLookup;
            //else
            //{
            //    iFieldLookupList = staticLookupManager.getStaticLookupByFieldName("VITALS LIMIT LEVEL");
            //    ClientSession.VitalLimitLookup = iFieldLookupList;
            //}
            //GridViewDataRowInfo row;
            //GridViewRow row; 
            IList<DateTime> DOSList = new List<DateTime>();

            if (vitalHistory.Count != 0)
            {
                IList<DateTime> TempDOSList = new List<DateTime>();
                IList<string> catlist = new List<string>();

                var enc = (from en in vitalHistory orderby en.Captured_date_and_time descending select en.Captured_date_and_time);//.Distinct();

                TempDOSList = enc.ToList<DateTime>();

                var category = (from en in vitalHistory orderby en.Loinc_Observation select en.Loinc_Observation).Distinct();
                catlist = category.ToList<string>();

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

            var DOSAsendingList = from c in DOSList orderby c.Date descending select c;
            DOSList = DOSAsendingList.ToList<DateTime>();

            for (int i = 0; i < DOSList.Count; i++)
            {
                //GridViewDataColumn d = new GridViewDataColumn();
                //BoundField d = new BoundField();
                //d.DataField = DOSList[i].ToString("dd-MMM-yyyy hh:mm:ss tt");
                if (!DOSList[0].ToString().Contains("0001-01-01"))
                dtTable.Columns.Add(DOSList[i].ToString("dd-MMM-yyyy hh:mm:ss tt"));//.HeaderText = DOSList[i].ToString("dd-MMM-yyyy hh:mm:ss tt");
                //d.Width = 100;
                //d.MinWidth = 50;
                //d.MaxWidth = 120;
                //d.WrapText = true;
                //foreach (DataColumn item in dtTable.Columns)
                //{
                //    if (item.ColumnName != d.ColumnName)
                //    {
                //        dtTable.Columns.Add(d);
                //        break;
                //    }
                //}
                //commented for thinclient
                //if (grdPastVitals.Columns.FindAllByDataField((a => a.HeaderText != d.HeaderText)))
                //{
                //    grdPastVitals.Columns.Add(d);
                //}
            }
            //commented for thinclient
            //for (int i = 0; i < grdPastVitals.Columns.Count; i++)
            //{
            //    grdPastVitals.Columns[i].WrapText = true;
            //}

            string sRowIndex = string.Empty;


            for (int i = 0; i < vitalHistory.Count; i++)
            {
                if (vitalHistory[i].Loinc_Observation.Contains("Second"))
                {
                    vitalHistory[i].Loinc_Observation = vitalHistory[i].Loinc_Observation.Replace("Second", "");
                }

                if (vitalHistory.Count != null)
                {
                    for (int j = 0; j < dtTable.Rows.Count; j++)
                    {
                        if (dtTable.Rows[j].ItemArray[0].ToString() == vitalHistory[i].Loinc_Observation)
                        {
                            sRowIndex = j.ToString();
                            break;
                        }
                    }

                    if (sRowIndex == string.Empty)
                    {
                        dr = dtTable.NewRow();
                        Is_NewRow = true;
                    }
                    else
                    {
                        dr = dtTable.Rows[Convert.ToInt32(sRowIndex)];
                        Is_NewRow = false;
                    }
                    // sRowIndex = string.Empty;


                    dr[0] = vitalHistory[i].Loinc_Observation;
                    //IList<string> sList = (from h in iFieldLookupList where h.Value.ToUpper() == vitalHistory[i].Loinc_Observation.ToUpper() select h.Description).ToList<string>();

                    //string sColor = Color.Black.Name;
                    //if (sList.Count != 0)

                    //    sColor = ValidateVitalUnits(vitalHistory[i].Loinc_Observation, vitalHistory[i].Value, sList[0]);

                    if (!vitalHistory[i].Loinc_Observation.Contains("Status"))
                    {

                        if (vitalHistory[i].Loinc_Observation == "Height")
                        {
                            if (vitalHistory[i].Value.Contains("'") == false)
                            {
                                string sValue = ConversionOnRetrieval(vitalHistory[i].Loinc_Observation, vitalHistory[i].Value);
                                vitalHistory[i].Value = sValue;
                            }
                            else
                            {
                                vitalHistory[i].Value = vitalHistory[i].Value;
                            }

                        }

                        //grdPartVitals.SelectedRows[i].Cells[i].CellElement.BackColor = sColor;
                        //Text = Text + VitalsList[i].Loinc_Observation + " - " + VitalsList[i].Value + AddVitalUnits(VitalsList[i].Loinc_Observation) + "\n";

                        string sVitalValue = vitalHistory[i].Value;
                        if (vitalHistory[i].Loinc_Observation == "Height" && vitalHistory[i].Value != string.Empty)
                        {
                            string[] d = vitalHistory[i].Value.Split('\'');
                            sVitalValue = d[0] + " Ft" + d[1] + " Inch" + "\n";
                        }
                        else
                        {
                            if (i != vitalHistory.Count - 1)
                            {
                                if (vitalHistory[i + 1].Loinc_Observation.Contains("Status"))
                                {
                                    if (vitalHistory[i].Value != string.Empty)
                                    {
                                        if (vitalHistory[i + 1].Value != string.Empty)
                                            sVitalValue = vitalHistory[i].Value + " " + vitalHistory[i].Units + " (" + vitalHistory[i + 1].Value + ")";
                                        else
                                            sVitalValue = vitalHistory[i].Value + " " + vitalHistory[i].Units;
                                    }
                                }
                                else
                                {
                                    if (vitalHistory[i].Value != string.Empty)
                                    {
                                        sVitalValue = vitalHistory[i].Value + " " + vitalHistory[i].Units;
                                    }
                                }

                            }
                            else
                            {
                                if (vitalHistory[i].Value != string.Empty)
                                {
                                    sVitalValue = vitalHistory[i].Value + " " + vitalHistory[i].Units;
                                }
                            }
                        }



                        string sVitalNotes = vitalHistory[i].Notes;
                        if (sVitalValue == string.Empty)
                        {
                            // row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].Value = sVitalNotes;

                            // row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].CellElement.ForeColor = Color.FromName(sColor); 
                            if (!vitalHistory[i].Loinc_Observation.Contains("Status"))
                            {
                                for (int j = 0; j < dtTable.Columns.Count; j++)
                                {
                                    if (dtTable.Columns[j].ColumnName != "Category")
                                    {

                                        if (Convert.ToDateTime(dtTable.Columns[j].ColumnName) == Convert.ToDateTime(UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")))
                                        {
                                            if (dr[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")].ToString() == string.Empty)
                                            {
                                                dr[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")] = sVitalNotes;
                                                break;
                                            }
                                            else
                                            {
                                                dr[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")] += ", " + sVitalNotes;
                                                break;
                                            }
                                        }
                                        //else
                                        //{
                                        //    row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].Value = sVitalValue;
                                        //    break;
                                        //}
                                    }
                                }
                            }
                        }
                        else if (!vitalHistory[i].Loinc_Observation.Contains("Status"))
                        {
                            for (int j = 0; j < dtTable.Columns.Count; j++)
                            {
                                if (dtTable.Columns[j].ColumnName != "Category")
                                {

                                    if (Convert.ToDateTime(dtTable.Columns[j].ColumnName) == Convert.ToDateTime(UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")))
                                    {
                                        if (dr[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")].ToString() == string.Empty)
                                        {
                                            dr[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")] = sVitalValue;
                                            break;
                                        }
                                        else
                                        {
                                            dr[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm:ss tt")] += ", " + sVitalValue;
                                            break;
                                        }
                                    }
                                    //else
                                    //{
                                    //    row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].Value = sVitalValue;
                                    //    break;
                                    //}
                                }


                            }

                            // grdPartVitals.Columns[0].
                            //   grdPartVitals.Columns[2].HeaderText

                            // row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].Value = sVitalValue;


                            //ConditionalFormattingObject colorFormat = new ConditionalFormattingObject();
                            //colorFormat.ApplyToRow = true;
                            //colorFormat.TValue1 = sVitalValue;
                            //colorFormat.ConditionType = ConditionTypes.Equal;
                            //colorFormat.RowForeColor = Color.FromName(sColor);
                            //grdPartVitals.Columns[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].ConditionalFormattingObjectList.Add(colorFormat);




                            // row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].CellElement.ForeColor = Color.FromName(sColor); 
                        }
                        //else if(vitalHistory[i].Loinc_Observation.Contains("Status"))
                        //{
                        //    row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].Value = "("+vitalHistory[i].Value+")";
                        //   // row.Cells[UtilityManager.ConvertToLocal(vitalHistory[i].Captured_date_and_time).ToString("dd-MMM-yyyy hh:mm tt")].CellElement.ForeColor = Color.FromName(sColor); 
                        //}
                        if (Is_NewRow)
                            dtTable.Rows.Add(dr);
                        sRowIndex = string.Empty;

                    }
                    else
                    {
                        if (Is_NewRow)
                            dtTable.Rows.Add(dr);
                        dtTable.Rows[dtTable.Rows.Count - 1].Delete();
                        sRowIndex = string.Empty;
                    }

                }

            }

            //for (int i = 0; i < dtTable.Columns.Count; i++)
            //{
            //    dtTable.Columns[i].MaxLength = 100;
            //}
            ds.Tables.Add(dtTable);
            grdPastVitals.DataSource = ds.Tables[0];
            grdPastVitals.DataBind();
            grdPastVitals.HeaderStyle.Wrap = true;
            grdPastVitals.HeaderStyle.Width = new Unit(100, UnitType.Pixel);
            if (grdPastVitals.Columns.Count > 0)
            {
                for (int i = 0; i < grdPastVitals.Columns.Count; i++)
                {
                    grdPastVitals.Columns[i].HeaderStyle.Width = new Unit(100, UnitType.Pixel);
                }
            }
            foreach (GridColumn col in grdPastVitals.MasterTableView.AutoGeneratedColumns)
            {
                col.FilterControlWidth = Unit.Pixel(100);//for changing the width of the column
                col.HeaderStyle.Width = new Unit(100, UnitType.Pixel);
            }
            //bug id:21741
            var visibleColumnCount = grdPastVitals.MasterTableView.AutoGeneratedColumns.Cast<GridColumn>().Count(column => column.Visible);
            if (visibleColumnCount != 0)
            {
                var tempWidth = 1.0 / (double)visibleColumnCount;
                if (tempWidth > 0.2)
                {
                    int i = 0;
                    foreach (GridColumn column1 in grdPastVitals.MasterTableView.AutoGeneratedColumns)
                    {
                        if (i == 0)
                        {
                            column1.ItemStyle.Width = new Unit("100px");
                            column1.HeaderStyle.Width = new Unit("100px");
                            column1.FilterControlWidth = new Unit("100px");
                        }
                        else
                        {
                            column1.ItemStyle.Width = new Unit("130px");
                            column1.HeaderStyle.Width = new Unit("130px");
                            column1.FilterControlWidth = new Unit("130px");
                        }
                        i++;
                        if (i == grdPastVitals.MasterTableView.AutoGeneratedColumns.Cast<GridColumn>().Count(column => column.Visible))
                        {
                            int LastWidth = (750) - (((i - 1) * 130) + 100);//750 - panel width
                            string sLast = LastWidth.ToString() + "px";
                            column1.ItemStyle.Width = new Unit(sLast);
                            column1.HeaderStyle.Width = new Unit(sLast);
                            column1.FilterControlWidth = new Unit(sLast);
                        }
                    }
                }
            }
        }
        public string ConversionOnRetrieval(string vitalName, string vitalValue)
        {
            UIManager objui = new UIManager(); 
            int j = 0;
            string MethdName = objui.ConvertInchtoFeetInch(vitalValue.ToString());
            string[] Splitter = { ".", "(", ",", ")" };
            string[] MthdInfo = MethdName.Split(Splitter, StringSplitOptions.RemoveEmptyEntries);
            if (MethdName.Length > 0)
            {

                string[] Arguments = new string[MthdInfo.Length];
                string ClassName = string.Empty;
                //string MethodName = MthdInfo[1];
                Arguments[j] = vitalValue;
                j++;
                return MethdName;
            }
            else
                return string.Empty;
        }
        public int CalculateAge(DateTime birthDate)
        {
            // cache the current time
            DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
            // get the difference in years
            int years = now.Year - birthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                --years;

            return years;
        }
        public string FillPatientSummaryBarforPatientChart(string LastName, string FirstName, string MI, string Suffix, DateTime DOB, ulong ulHumanID, string MedRecNo, string HomePhoneNo, string CellPhoneNo, string Sex, string PatientStatus, string SSN, string PatientType, string sPriPlan, string sPriCarrier, string sSecPlan, string sSecCarrier)
        {

            string sMySummary;
            string phoneno = "";
            if(HomePhoneNo.Length == 14)
            {
                phoneno = HomePhoneNo;
            }
            else
            {
                phoneno = CellPhoneNo;
            }
            string sSex = string.Empty;
            if (Sex != null && Sex.Trim() != "")
                sSex = Sex.Substring(0, 1);

            if (PatientStatus == "DECEASED")
            {
                sMySummary = LastName + "," + FirstName +
                   "  " + MI + "  " + Suffix + "   |   " +
                   DOB.ToString("dd-MMM-yyyy") + "   |   " +
                   (CalculateAge(DOB)).ToString() +
                   "  year(s)    |   " + sSex + "   |   " + PatientStatus + "   |   Acc #:" + ulHumanID +
                   "   |   " + "Med Rec #:" + MedRecNo + "   |   " +
                   "Phone #:" + phoneno + "   |   ";
            }
            else
            {
                sMySummary = LastName + "," + FirstName +
               "  " + MI + "  " + Suffix + "   |   " +
               DOB.ToString("dd-MMM-yyyy") + "   |   " +
               (CalculateAge(DOB)).ToString() +
               "  year(s)    |   " + sSex + "   |   Acc #:" + ulHumanID +
               "   |   " + "Med Rec #:" + MedRecNo + "   |   " +
               "Phone #:" + phoneno + "   |   ";

            }

            if (sPriPlan != string.Empty)
            {
                sMySummary += "Pri Plan:" + sPriCarrier + " - " + sPriPlan + "   |   ";
            }
            if (sSecPlan != string.Empty)
            {
                sMySummary += "Sec Plan:" + sSecCarrier + " - " + sSecPlan + "   |   ";
            }
            if (SSN != string.Empty)
            {
                sMySummary += "SSN:" + SSN + "   |   ";
            }
            if (PatientType != string.Empty)
            {
                sMySummary += "Patient Type:" + PatientType + "   |   ";
            }
            return sMySummary;
        }
        public string ValidateVitalUnits(string Name, string Value, string AbnormalValue)
        {
            if (Value != string.Empty)
            {
                switch (Name)
                {
                    case "Body Temperature":
                        {
                            string[] Split = AbnormalValue.Split('-');
                            if (Convert.ToDecimal(Value) < Convert.ToDecimal(Split[0]) || Convert.ToDecimal(Value) > Convert.ToDecimal(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "BP-Sitting Sys/Dia":
                        {
                            string[] SplitNormal = Value.Split('/');
                            string[] Split = AbnormalValue.Split('/');
                            if (Convert.ToInt16(SplitNormal[0]) < Convert.ToInt16(Split[0]) || Convert.ToInt16(SplitNormal[1]) > Convert.ToInt16(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "BP-Standing Sys/Dia":
                        {
                            string[] SplitNormal = Value.Split('/');
                            string[] Split = AbnormalValue.Split('/');
                            if (Convert.ToInt16(SplitNormal[0]) < Convert.ToInt16(Split[0]) || Convert.ToInt16(SplitNormal[1]) > Convert.ToInt16(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "BP-Lying Sys/Dia":
                        {
                            string[] SplitNormal = Value.Split('/');
                            string[] Split = AbnormalValue.Split('/');
                            if (Convert.ToInt16(SplitNormal[0]) < Convert.ToInt16(Split[0]) || Convert.ToInt16(SplitNormal[1]) > Convert.ToInt16(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "Respiratory Rate":
                        {
                            string[] Split = AbnormalValue.Split('-');
                            if (Convert.ToDecimal(Value) < Convert.ToDecimal(Split[0]) || Convert.ToDecimal(Value) > Convert.ToDecimal(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "Heart Rate":
                        {
                            string[] Split = AbnormalValue.Split('-');
                            if (Convert.ToDecimal(Value) < Convert.ToDecimal(Split[0]) || Convert.ToDecimal(Value) > Convert.ToDecimal(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "Pulse Oximetry":
                        {
                            string[] Split = AbnormalValue.Split('-');
                            if (Convert.ToDecimal(Value) < Convert.ToDecimal(Split[0]) || Convert.ToDecimal(Value) > Convert.ToDecimal(Split[1]))
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "BMI Status":
                        {
                            if (Value.Contains(AbnormalValue) == false)
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "HbA1C Status":
                        {
                            if (Value != AbnormalValue)
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "eGFR Status":
                        {
                            if (Value != AbnormalValue)
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "Blood Sugar-Post Prandial Status":
                        {
                            if (Value.Contains(AbnormalValue) == false)
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }
                    case "Blood Sugar-Fasting Status":
                        {
                            if (Value.Contains(AbnormalValue) == false)
                                return Color.Red.Name;
                            else
                                return Color.Black.Name;
                        }

                    default:
                        {
                            return Color.Black.Name;
                        }
                }
            }
            else
            {
                return Color.Black.Name;
            }
        }
    }
}
