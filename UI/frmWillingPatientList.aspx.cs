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
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Telerik.Web.Design;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Drawing;
using System.Globalization;

namespace Acurus.Capella.UI
{
    public partial class frmWillingPatientList : System.Web.UI.Page
    {
        Encounter EncRecord = new Encounter();
        IList<string> lstOrdersID = new List<string>();
        FillNewEditAppointment fillneweditappt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sFacility = string.Empty;
            string sAppointmentDateandTime = string.Empty;
            string sProvider = string.Empty;
            if (!IsPostBack)
            {
                grdWillingPatientList.MasterTableView.GetColumn("EncounterID").Display = false;
                grdWillingPatientList.MasterTableView.GetColumn("PhysicianID").Display = false;
                grdWillingPatientList.MasterTableView.GetColumn("Time").Display = false;
                IList<FillWillingonCancel> objFillWillingonCancel = new List<FillWillingonCancel>();
                EncounterManager EncMngr = new EncounterManager();
                if (Request.QueryString["facility"] != null)
                {
                    sFacility = Request.QueryString["facility"].ToString();
                    txtFacility.Text = sFacility;
                }

                if (Request.QueryString["SelectedDate"] != null)
                {
                    sAppointmentDateandTime = Request.QueryString["SelectedDate"].ToString();
                    txtAppointmentDateandTime.Text = sAppointmentDateandTime;
                }
                if (Request.QueryString["PhysicianName"] != null)
                {
                    sProvider = Request.QueryString["PhysicianName"].ToString();
                    txtProviderName.Text = sProvider;
                }

                objFillWillingonCancel = EncMngr.GetWillingCancellationList();
                DataTable dtGrid = new DataTable();
                DataColumn dtCol = new DataColumn("AppointmentDateandTime", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("Facility", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("Provider", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("Account#", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("PatientName", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("Gender", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("PatientType", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("TypeOfVisit", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("CurrentProcess", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("EncounterID", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("PhysicianID", typeof(string));
                dtGrid.Columns.Add(dtCol);
                dtCol = new DataColumn("Time", typeof(string));
                dtGrid.Columns.Add(dtCol);
                
                for (int i = 0; i < objFillWillingonCancel.Count; i++)
                {
                    DataRow dr1 = dtGrid.NewRow();
                    dr1["AppointmentDateandTime"] = objFillWillingonCancel[i].Appointment_Date_Time.ToLocalTime().ToString("dd-MMM-yyyy HH:mm:ss tt");
                    dr1["Facility"] = objFillWillingonCancel[i].Facility_Name;
                    dr1["Provider"] = objFillWillingonCancel[i].Physician_Name;
                    dr1["Account#"] = objFillWillingonCancel[i].Human_ID;
                    dr1["PatientName"] = objFillWillingonCancel[i].Last_Name + " " + objFillWillingonCancel[i].First_Name + " " + objFillWillingonCancel[i].Mi +"" + objFillWillingonCancel[i].Suffix;
                    dr1["Gender"] = objFillWillingonCancel[i].Sex;
                    dr1["PatientType"] = objFillWillingonCancel[i].Human_Type;
                    dr1["TypeOfVisit"] = objFillWillingonCancel[i].Visit_Type;
                    dr1["CurrentProcess"] = objFillWillingonCancel[i].Current_Process;
                    dr1["EncounterID"] = objFillWillingonCancel[i].Encounter_ID;
                    dr1["PhysicianID"] = objFillWillingonCancel[i].Physician_ID;
                    dr1["Time"] = objFillWillingonCancel[i].Duration_Time;
                    dtGrid.Rows.Add(dr1);

                }
                grdWillingPatientList.DataSource = dtGrid;
                grdWillingPatientList.DataBind();
                if (grdWillingPatientList.DataSource == null)
                {
                    grdWillingPatientList.DataSource = new string[] { };
                }

            }
           
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (hdnEncounterID.Value!=null&&hdnEncounterID.Value!="")
            {
            EncounterManager EncMngr = new EncounterManager();
            WFObjectManager wfMngr = new WFObjectManager();
            ulong ulMyPhysicianID = 0;
            string sMyObjType = "ENCOUNTER";
            IList<AuthorizationEncounter> objAuth = new List<AuthorizationEncounter>();
            AuthorizationEncounterManager authMngr = new AuthorizationEncounterManager();
            string sAuthNo = string.Empty;
            objAuth = authMngr.GetAuthdetailsByEncID(Convert.ToUInt64(hdnEncounterID.Value));
            if (objAuth.Count > 0)
            {
                sAuthNo = objAuth[0].Authorization_ID.ToString();
            }
            fillneweditappt = EncMngr.GetEncounterAndHumanRecord(Convert.ToUInt64(hdnEncounterID.Value), Convert.ToUInt64(hdnHumanID.Value));
            
            foreach (string str in fillneweditappt.CptAndItsOrderId)
            {
                hdnOrderList.Value += str + "-";
                lstOrdersID.Add(str);
            }
            DateTime selectedDate = DateTime.Now;
            string[] sp = null;


            selectedDate = Convert.ToDateTime(hdnApptDate.Value);
            sp = selectedDate.ToString().Split(' ');
            
            DateTime MyCalendarDateTime = selectedDate;
            AppointmentPreChecks appointmentPreCheckList = EncMngr.CheckDuplicateAppointment(Convert.ToUInt64(hdnHumanID.Value), Convert.ToUInt64(hdnPhysicianID.Value), MyCalendarDateTime, hdnFacilityName.Value, selectedDate, selectedDate.ToString("HH:mm:ss"), Convert.ToInt32(hdnApptTime.Value), Convert.ToUInt64(hdnEncounterID.Value));

           
            WFObject WFObj = new WFObject();
            if (hdnEncounterID.Value.ToString() != "0")
            {
                EncRecord = appointmentPreCheckList.CurrentEncounter[0];
            }
            if (EncRecord.Id != 0)
            {
                EncRecord.Notes = EncRecord.Notes;
                EncRecord.Visit_Type = EncRecord.Visit_Type;
                EncRecord.Reason_for_Cancelation = "Other";
                EncRecord.Reschedule_Reason_Text = "Scheduled due to Cancellations";
                EncRecord.Willing_For_Prior_Appointment = "N";
                if (hdnLocalTime.Value != string.Empty)
                {
                    EncRecord.Modified_Date_and_Time = DateTime.ParseExact(hdnLocalTime.Value.ToString(), "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                }
                EncRecord.Modified_By = ClientSession.UserName;
                EncMngr.UpdateEncounterForRCM(EncRecord, null, false, string.Empty, sAuthNo, GenerateIsCMGOrderObject());
                //EncMngr.UpdateEncounterForRCM(EncRecord, string.Empty, sAuthNo, GenerateIsCMGOrderObject());


                wfMngr.MoveToNextProcess(EncRecord.Id, "ENCOUNTER", 4, "UNKNOWN", System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now), string.Empty, null, null);


                Encounter NewEnc = new Encounter();
                //NewEnc.Appointment_Date = selectedDate;
                NewEnc.Appointment_Date = Convert.ToDateTime(txtAppointmentDateandTime.Text);
                //sriivdhya
                //NewEnc.Appointment_Date = ToLoalTime.ToUniversal(Session["UniversalTime"].ToString(), NewEnc.Appointment_Date);
                NewEnc.Appointment_Date = UtilityManager.ConvertToUniversal(NewEnc.Appointment_Date);
                //EncRecord.Check_Date = UtilityManager.ConvertToUniversal(DateTime.MinValue);
                NewEnc.Duration_Minutes = Convert.ToInt32(hdnApptTime.Value);
                NewEnc.Purpose_of_Visit = EncRecord.Purpose_of_Visit;
                NewEnc.Appointment_Provider_ID = Convert.ToInt32(hdnPhysicianID.Value); //ulMyPhysicianID;
                ulMyPhysicianID = Convert.ToUInt64(NewEnc.Appointment_Provider_ID);
                NewEnc.Encounter_Provider_ID = Convert.ToInt32(ulMyPhysicianID);
                NewEnc.Visit_Type = EncRecord.Visit_Type;
                NewEnc.Human_ID = Convert.ToUInt64(hdnHumanID.Value);
                NewEnc.Facility_Name = hdnFacilityName.Value;
                NewEnc.Referring_Facility = EncRecord.Referring_Facility;
                NewEnc.Referring_Physician = EncRecord.Referring_Physician;
                NewEnc.Referring_Address = EncRecord.Referring_Address;
                NewEnc.Referring_Phone_No = EncRecord.Referring_Phone_No;
                NewEnc.Referring_Fax_No = EncRecord.Referring_Fax_No;
                NewEnc.Referring_Provider_NPI = EncRecord.Referring_Provider_NPI;
                NewEnc.Notes = EncRecord.Notes;
                NewEnc.Willing_For_Prior_Appointment = "N";
                //Added by Bala for ADD MESSAGES IN APPOINTMENTS in 20-12-2013
                if (EncRecord.Notes != string.Empty)
                {
                    PatientNotesManager patNotesMngr = new PatientNotesManager();
                    IList<PatientNotes> listPatientNotes = new List<PatientNotes>();
                    PatientNotes objPat = new PatientNotes();
                    objPat.Human_ID = Convert.ToUInt64(hdnHumanID.Value);
                    objPat.Message_Orign = "Appointment";
                    objPat.Message_Date_And_Time = DateTime.ParseExact(hdnLocalTime.Value.ToString(), "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                    objPat.Message_Description = "Appointment";
                    objPat.Notes = EncRecord.Notes;
                    objPat.Created_Date_And_Time = DateTime.ParseExact(hdnLocalTime.Value.ToString(), "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                    objPat.Created_By = ClientSession.UserName;
                    ///objPat.Modified_Date_And_Time = DateTime.ParseExact(hdnLocalTime.Value.ToString(), "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                    objPat.Is_PatientChart = "N";
                    objPat.Line_ID = 0;
                    objPat.Type = "MESSAGE";
                    objPat.Encounter_ID = Convert.ToInt32(hdnEncounterID.Value);
                    objPat.Statement_ChargeLine_ID = 0;
                    objPat.SourceID = Convert.ToInt32(hdnEncounterID.Value);
                    objPat.Source = "APPOINTMENT";
                    objPat.IsDelete = "N";
                    objPat.Is_PopupEnable = "N";
                    objPat.Priority = "NORMAL";
                    listPatientNotes.Add(objPat);
                    patNotesMngr.AddToPatientNotes(listPatientNotes);
                }
                WFObj.Obj_Type = sMyObjType;
                if (hdnLocalTime.Value != string.Empty)
                {
                    WFObj.Current_Arrival_Time = DateTime.ParseExact(hdnLocalTime.Value.ToString(), "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                }
                WFObj.Current_Owner = "UNKNOWN";
                WFObj.Fac_Name = hdnFacilityName.Value;
                WFObj.Obj_System_Id = NewEnc.Id;
                WFObj.Current_Process = "START";
                //WFObj.Id = WFProxy.InsertToWorkFlowObject(WFObj);

                if (NewEnc.Id == 0)
                {
                    if (hdnLocalTime.Value != string.Empty)
                    {
                        NewEnc.Created_Date_and_Time = DateTime.ParseExact(hdnLocalTime.Value.ToString(), "M/dd/yyyy H:mm:ss", CultureInfo.InvariantCulture);
                    }
                    NewEnc.Created_By = ClientSession.UserName;
                    NewEnc.Is_Physician_Asst_Process = "N";
                    NewEnc.Notes = EncRecord.Notes;
                    NewEnc.Id = EncMngr.CreateEncounterForRCM(NewEnc, WFObj, string.Empty, sAuthNo, GenerateIsCMGOrderObject());

                }
            }
          } 
        }
        object[] GenerateIsCMGOrderObject()
        {
            ulong ulMyHumanID = 0;
            
            string[] str = hdnOrderList.Value.Split('-').ToArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != string.Empty)
                {
                    lstOrdersID.Add(str[i]);
                }
            }
            if (hdnHumanID.Value != string.Empty)
            {
                ulMyHumanID = Convert.ToUInt64(hdnHumanID.Value);
            }
            var facAncillary = from f in ApplicationObject.facilityLibraryList where f.Fac_Name == hdnFacilityName.Value select f;
            IList<FacilityLibrary> ilstFacAncillary = facAncillary.ToList<FacilityLibrary>();
            if (EncRecord.Id != 0)
            {
                object[] temp = new object[] { "true", ulMyHumanID, string.Join(",", lstOrdersID.ToArray<string>()), EncRecord.Id };
                return temp;
            }
           // else if (hdnFacilityName.Value.ToUpper() == System.Configuration.ConfigurationSettings.AppSettings["CMGFacilityName"] && fillneweditappt.Test != string.Empty)
            else if (ilstFacAncillary.Count > 0 && ilstFacAncillary[0].Is_Ancillary == "Y" && fillneweditappt.Test != string.Empty)
            {
                object[] temp = new object[] { "true", ulMyHumanID, string.Join(",", lstOrdersID.ToArray<string>()) };
                return temp;
            }
            else
            {
                object[] temp = new object[] { "false" };
                return temp;
            }
        }
    }
}
