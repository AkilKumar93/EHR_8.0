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
//using Acurus.Capella.Proxy.LookupTables;
using System.Text;
using System.ComponentModel;
using System.IO;


namespace Acurus.Capella.UI
{
    public partial class frmImmunizationRegistry : System.Web.UI.Page
    {
        Human hn = null;
        IList<PhysicianLibrary> PhysicianList = new List<PhysicianLibrary>();
        Encounter Enc = null;
        FillClinicalSummary WellnessNotes = null;
        ArrayList content = new ArrayList();
        ChiefComplaintsManager ClinicalProxy = new ChiefComplaintsManager();
        EncounterManager EncMngr = new EncounterManager();
        PhysicianManager physicianManager = new PhysicianManager();
        InsurancePlanManager InsurancePlanMngr = new InsurancePlanManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TabName"]!=null && Request.QueryString["TabName"] == "ImmunizationRegistry")
            {
                string sMyPath = string.Empty;
                 content = GenerateImmunizationRegistry(ClientSession.Selectedencounterid, ClientSession.HumanId, false, ref sMyPath, string.Empty);
            }
            else if (Request.QueryString["TabName"] != null && Request.QueryString["TabName"] == "ImmunizationRegistryQuery")
            {
                ulong uHumanID = 0;
                if (Request.QueryString["HumanID"] != null && Request.QueryString["HumanID"] != "")
                {
                    uHumanID = Convert.ToUInt64(Request.QueryString["HumanID"].ToString());
                }
                string sMyPath = string.Empty;
                content = GenerateImmunizationRegistryQuery(uHumanID, false, ref sMyPath, string.Empty);
            }
            else if (Request.QueryString["TabName"] != null && Request.QueryString["TabName"].Contains("SyndromicSurveillance"))
            {
                string sFileName = string.Empty;
                sFileName = Request.QueryString["TabName"].ToString().Split('|')[1];
                content = GenerateHL7ForSyndromicSurveillance(ClientSession.Selectedencounterid, ClientSession.HumanId, ClientSession.PhysicianId, sFileName);
                if (content != null && content.Count > 0)
                {
                    if (content[0].ToString().Contains("Error"))
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Syndromic Survilence", "DisplayErrorMessage('9004'); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}", true);
                        return;
                    }
                }
            }

            if (content!=null && content.Count > 0)
            {
                Response.Clear();

                Response.ClearHeaders();

                Response.ClearContent();
                FileStream fs = null;
                fs = new FileStream(content[1].ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);

                //Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + content[1].ToString() + "\"");

                Response.AddHeader("Content-Length", fs.Length.ToString());

                Response.ContentType = "text/plain";
                fs.Close();
                fs.Dispose();
                Response.Flush();

                Response.TransmitFile(content[1].ToString());

                Response.End();
            }
          
        }
        public ArrayList GenerateImmunizationRegistryQuery(ulong ulHumanId, Boolean bOpen, ref string sMyPathName, string sFolderPathNames)
        {
            ArrayList aryResult = new ArrayList();

            WellnessNotes = ClinicalProxy.GetClinicalSummaryBulk(0, ulHumanId);
            hn = GetHumanByHumanID(ulHumanId);
           
            PhysicianList = WellnessNotes.phyList;


            string sDirPath = Server.MapPath("Documents/" + Session.SessionID);

            DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }

            string TargetFileDirectory = Server.MapPath("Documents/" + Session.SessionID);
            string sFolderPathName = TargetFileDirectory + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + DateTime.Now.ToString("yyyyMMdd");
            Directory.CreateDirectory(sFolderPathName);
            
            string PriPlan = string.Empty;
            IList<PatientInsuredPlan> PatInsList = new List<PatientInsuredPlan>();
            PatInsList = WellnessNotes.Pat_Ins_Plan;
            if (PatInsList != null)
            {
                for (int i = 0; i < PatInsList.Count; i++)
                {
                    if (PatInsList[i].Insurance_Type.ToUpper() == "PRIMARY")
                    {
                        IList<InsurancePlan> InsPlan = InsurancePlanMngr.GetInsurancebyID(PatInsList[i].Insurance_Plan_ID);
                        if (InsPlan != null && InsPlan.Count > 0)
                            PriPlan = InsPlan[0].External_Plan_Number;
                    }
                }
            }


            string sPrintPathName = string.Empty;
            if (sFolderPathName == string.Empty)
            {
                sPrintPathName = System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                 PriPlan + "_" + ulHumanId + ".er7";
            }
            else
            {
                sPrintPathName = sFolderPathName + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                 PriPlan + "_" + ulHumanId + ".er7";

            }

            //*************************************************************HL7
            string sResult = string.Empty;
            HL7Generator hl7Gen = new HL7Generator();
            sResult = hl7Gen.CreateImmunizationRegistryNISTQuery(hn, WellnessNotes, sPrintPathName);


            StreamWriter sr = new StreamWriter(sPrintPathName);
            sr.Write(sResult);
            sr.Close();
            sr.Dispose();

            aryResult.Add(sResult);
            aryResult.Add(sPrintPathName);

            return aryResult;
        }
        public ArrayList GenerateImmunizationRegistry(ulong ulEncounterId, ulong ulHumanId, Boolean bOpen, ref string sMyPathName, string sFolderPathNames)
        {
            ArrayList aryResult = new ArrayList();

            if (ClientSession.EncounterId == 0)
            {
                //ApplicationObject.erroHandler.DisplayErrorMessage("110035", this.Text);
                return aryResult;
            }

            //*************************************************************
            //To print the patient details
           // WellnessNotes = ClinicalProxy.GetClinicalSummary(ClientSession.EncounterId, ulHumanId);
            WellnessNotes = ClinicalProxy.GetClinicalSummaryBulk(ClientSession.EncounterId, ulHumanId);
            hn = GetHumanByHumanID(ClientSession.HumanId);
            if (WellnessNotes.Encounter != null)
            {
                Enc = WellnessNotes.Encounter[0];
            }
            PhysicianList = WellnessNotes.phyList;

            
          string sDirPath = Server.MapPath("Documents/" + Session.SessionID);

            DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }

            string TargetFileDirectory = Server.MapPath("Documents/" + Session.SessionID);
            string sFolderPathName = TargetFileDirectory + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + DateTime.Now.ToString("yyyyMMdd");
            Directory.CreateDirectory(sFolderPathName);
            //if (sFolderPathName == string.Empty)
            //{
            //    Directory.CreateDirectory(System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"]);
            //}
            //else
            //{
            //    Directory.CreateDirectory(sFolderPathName);
            //}

            //To find the Primary Plan Name
            string PriPlan = string.Empty;
            IList<PatientInsuredPlan> PatInsList = new List<PatientInsuredPlan>();
            PatInsList = WellnessNotes.Pat_Ins_Plan;
            if (PatInsList!=null)
            {
                for (int i = 0; i < PatInsList.Count; i++)
                {
                    if (PatInsList[i].Insurance_Type.ToUpper() == "PRIMARY")
                    {
                        IList<InsurancePlan> InsPlan = InsurancePlanMngr.GetInsurancebyID(PatInsList[i].Insurance_Plan_ID);
                        //PriPlan = InsPlan.Ins_Plan_Name;
                        if (InsPlan != null && InsPlan.Count>0)
                            PriPlan = InsPlan[0].External_Plan_Number;
                    }
                }
            }
           

            string sPrintPathName = string.Empty;
            if (sFolderPathName == string.Empty)
            {
                //sPrintPathName = System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                // PriPlan + "_" + Enc.Facility_Name + ".er7";
                sPrintPathName = System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                 PriPlan + "_" + Enc.Facility_Name + ".er7";
            }
            else
            {
                sPrintPathName = sFolderPathName + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                 PriPlan + "_" + Enc.Facility_Name + ".er7";

            }

            //*************************************************************HL7
            string sResult = string.Empty;
            HL7Generator hl7Gen = new HL7Generator();
            if (PhysicianList != null && PhysicianList.Count>0)
            {
                sResult = hl7Gen.CreateImmunizationRegistryNIST(hn, PhysicianList[0], WellnessNotes, sPrintPathName);
            }

            StreamWriter sr = new StreamWriter(sPrintPathName);
            sr.Write(sResult);
            sr.Close();
            sr.Dispose();          

            aryResult.Add(sResult);
            aryResult.Add(sPrintPathName);
           
            return aryResult;
        }
        public Human GetHumanByHumanID(ulong HumanID)
        {
            IList<Human> Humanlist = null;
            HumanManager objHumanManager = new HumanManager();
            Humanlist = objHumanManager.GetPatientDetailsUsingPatientInformattion(HumanID);
            if (Humanlist != null)
            {
                if (Humanlist.Count > 0)
                {
                    return Humanlist[0];
                }
            }
            return new Human();
        }
        public ArrayList GenerateHL7ForSyndromicSurveillance(ulong ulEncounterID, ulong ulHumanId, ulong PhysicianID,string sFileName)
        {
            ArrayList aryResult = new ArrayList();
            hn = GetHumanByHumanID(ClientSession.HumanId);
            if (ClientSession.EncounterId == 0)
            {
                //ApplicationObject.erroHandler.DisplayErrorMessage("110035", this.Text);
                return aryResult;
            }
            WellnessNotes = ClinicalProxy.GetSyndromicSurveillance(ClientSession.EncounterId, ulHumanId);
            if (sFileName == "DISCHARGE / END VISIT WITH ACKNOWLEDGEMENT" || sFileName == "DISCHARGE / END VISIT WITHOUT ACKNOWLEDGEMENT")
            {
                if (WellnessNotes.HospitalizationHistory.Count > 0)
                {
                    var Discharge_Date = (from h in WellnessNotes.HospitalizationHistory where h.To_Date != "" select h).ToList();
                    var Discharge_Date1 = (from h in Discharge_Date where h.To_Date != "Current" select h).ToList();
                    if (Discharge_Date1.Count == 0)
                    {
                        //var val = (from d in Discharge_Date1 orderby d.To_Date descending select new { dDate = d.To_Date }).ToArray();
                        aryResult.Add("Error");
                    }

                }
                else
                {
                    aryResult.Add("Error");
                }
                if (aryResult.Count > 0)
                    return aryResult;
            }
            //IList<Encounter> Enc = EncMngr.GetEncounterByEncounterID(ClientSession.EncounterId);
            if (WellnessNotes.Encounter != null)
            {
                Enc = WellnessNotes.Encounter[0];
            }
            string sDirPath = Server.MapPath("Documents/" + Session.SessionID);

            DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }

            string TargetFileDirectory = Server.MapPath("Documents/" + Session.SessionID);
            string sFolderPathName = TargetFileDirectory + "\\" + System.Configuration.ConfigurationSettings.AppSettings["SyndromicSurveillanceHL7Path"] + "\\" + DateTime.Now.ToString("yyyyMMdd");
            Directory.CreateDirectory(sFolderPathName);
            //string folderPath = System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["SyndromicSurveillanceHL7Path"] + "\\" + DateTime.Now.ToString("yyyyMMdd");
            //Directory.CreateDirectory(folderPath);
            string sPrintPathName = sFolderPathName + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" + Enc.Facility_Name + "_" + Enc.Id.ToString() +".hl7";
            IList<FacilityLibrary> facilityList = ApplicationObject.facilityLibraryList;// AllLibraries.Instance.GetFacilityList();
            FacilityLibrary objFacility = (from obj in facilityList where obj.Fac_Name == Enc.Facility_Name select obj).ToList<FacilityLibrary>()[0];
            string sResult = string.Empty;
            string sMSH = string.Empty;
            string sACK = string.Empty;
            if (sFileName == "ADMIT / VISIT NOTIFICATION WITH ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A01^ADT_A01";
                sACK = "PH_SS-Ack";
            }
            else if (sFileName == "DISCHARGE / END VISIT WITH ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A03^ADT_A03";
                sACK = "PH_SS-Ack";
            }
            else if (sFileName == "REGISTER PATIENT WITH ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A04^ADT_A01";
                sACK = "PH_SS-Ack";
            }
            else if (sFileName == "UPDATE PATIENT INFORMATION WITH ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A08^ADT_A01";
                sACK = "PH_SS-Ack";
            }
            if (sFileName == "ADMIT / VISIT NOTIFICATION WITHOUT ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A01^ADT_A01";
                sACK = "PH_SS-NoAck";
            }
            else if (sFileName == "DISCHARGE / END VISIT WITHOUT ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A03^ADT_A03";
                sACK = "PH_SS-NoAck";
            }
            else if (sFileName == "REGISTER PATIENT WITHOUT ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A04^ADT_A01";
                sACK = "PH_SS-NoAck";
            }
            else if (sFileName == "UPDATE PATIENT INFORMATION WITHOUT ACKNOWLEDGEMENT")
            {
                sMSH = "ADT^A08^ADT_A01";
                sACK = "PH_SS-NoAck";
            }

            HL7Generator hl7Gen = new HL7Generator();
            sResult = hl7Gen.CreateHL7ForSyndromicSurveillance(Enc, hn, objFacility, WellnessNotes, sMSH, sACK);

            StreamWriter sr = new StreamWriter(sPrintPathName);
            sr.Write(sResult);

            sr.Close();
            sr.Dispose();
            aryResult.Add(sResult);
            aryResult.Add(sPrintPathName);
            
            return aryResult;

        }
        //bulk
        public ArrayList GenerateImmunizationRegistryforBulk(ulong ulEncounterId, ulong ulHumanId, Boolean bOpen, ref string sMyPathName, string sFolderPathNames)
        {
            ArrayList aryResult = new ArrayList();

            if (ulEncounterId == 0)
            {
                //ApplicationObject.erroHandler.DisplayErrorMessage("110035", this.Text);
                return aryResult;
            }

            //*************************************************************
            //To print the patient details
            WellnessNotes = ClinicalProxy.GetClinicalSummaryBulk(ulEncounterId, ulHumanId);
            hn = GetHumanByHumanID(ulHumanId);
            if (WellnessNotes.Encounter != null)
            {
                Enc = WellnessNotes.Encounter[0];
            }
            PhysicianList = WellnessNotes.phyList;


            string sDirPath = Server.MapPath("Documents/" + Session.SessionID);

            DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }

            // string TargetFileDirectory = Server.MapPath("Documents/" + Session.SessionID);
            string sFolderPathName = System.Configuration.ConfigurationSettings.AppSettings["HL7ImmunizationPath"];
            // Directory.CreateDirectory(sFolderPathName);
            //if (sFolderPathName == string.Empty)
            //{
            //    Directory.CreateDirectory(System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"]);
            //}
            //else
            //{
            //    Directory.CreateDirectory(sFolderPathName);
            //}

            //To find the Primary Plan Name
            string PriPlan = string.Empty;
            IList<PatientInsuredPlan> PatInsList = new List<PatientInsuredPlan>();
            PatInsList = WellnessNotes.Pat_Ins_Plan;
            if (PatInsList != null)
            {
                for (int i = 0; i < PatInsList.Count; i++)
                {
                    if (PatInsList[i].Insurance_Type.ToUpper() == "PRIMARY")
                    {
                        IList<InsurancePlan> InsPlan = InsurancePlanMngr.GetInsurancebyID(PatInsList[i].Insurance_Plan_ID);
                        //PriPlan = InsPlan.Ins_Plan_Name;
                        if (InsPlan != null && InsPlan.Count > 0)
                            PriPlan = InsPlan[0].External_Plan_Number;
                    }
                }
            }


            string sPrintPathName = string.Empty;
            if (sFolderPathName == string.Empty)
            {
                //sPrintPathName = System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                // PriPlan + "_" + Enc.Facility_Name + ".er7";
                sPrintPathName = System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ImmunizationRegistriesPathName"] + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" +
                 PriPlan + "_" + Enc.Facility_Name + ".er7";
            }
            else
            {
                sPrintPathName = sFolderPathName + "\\" + hn.Last_Name + "_" + hn.First_Name + "_" + ulEncounterId + "_" + ulHumanId + "_" +
                 PriPlan + "_" + Enc.Facility_Name + ".er7";

            }

            //*************************************************************HL7
            string sResult = string.Empty;
            HL7Generator hl7Gen = new HL7Generator();
            sResult = hl7Gen.CreateImmunizationRegistry(hn, PhysicianList[0], WellnessNotes, sPrintPathName);


            StreamWriter sr = new StreamWriter(sPrintPathName);
            sr.Write(sResult);
            sr.Close();
            sr.Dispose();

            // aryResult.Add(sResult);
            aryResult.Add(sPrintPathName);

            return aryResult;
        }
    }
}
