using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DTO;
using iTextSharp.text;
using System.IO;
using System.Xml;
using System.Net;
using System.Configuration;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Acurus.Capella.GenerateCCD
{
    class Program
    {
        static void Main(string[] args)
        {
            string sMode = ConfigurationSettings.AppSettings["Mode"];
            if (sMode.ToUpper() == "CERNER")
            {
                try
                {

                    string sCurrentArrivalDate = Convert.ToDateTime(DateTime.UtcNow.AddDays(-7)).ToString("yyyy-MM-dd");
                    LogWrite("Generate CCD current arrival time : ", sCurrentArrivalDate);
                    string Provider_Id = ConfigurationSettings.AppSettings["Provider_Id"];
                    //string query = "select e.human_id,e.encounter_id,e.Appointment_Provider_ID  from encounter e, wf_object w where  date(w.Current_Arrival_Time)<='" + sCurrentArrivalDate + "' and w.obj_system_id=e.encounter_id and w.current_process='REVIEW_CODING' and e.Appointment_Provider_ID in " + Provider_Id + " union all " +
                    //"select ea.human_id,ea.encounter_id,ea.Appointment_Provider_ID  from encounter_arc ea, wf_object_arc wa where  date(wa.Current_Arrival_Time)<='" + sCurrentArrivalDate + "' and wa.obj_system_id=ea.encounter_id and wa.current_process='REVIEW_CODING' and ea.Appointment_Provider_ID in " + Provider_Id + "";

                    string query = "select e.human_id,e.encounter_id,e.Appointment_Provider_ID  from encounter e, wf_object w where  date(w.Current_Arrival_Time)='" + sCurrentArrivalDate + "' and w.obj_system_id=e.encounter_id and w.current_process='REVIEW_CODING' and e.Appointment_Provider_ID in " + Provider_Id + "";

                    DataSet dsReturn = DBConnector.ReadData(query);
                    DataTable dtEnc = dsReturn.Tables[0];
                    if (dtEnc.Rows.Count == 0)
                    {
                        LogWrite("Generate CCD", "No Records to found in encounter table.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Records to found in wf_object table.");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    else
                    {
                        string sMyPath = string.Empty;
                        for (int i = 0; i < dtEnc.Rows.Count; i++)
                        {
                            string sFolderPath = ConfigurationSettings.AppSettings["Cerner_CCDXML"];
                            if (!Directory.Exists(sFolderPath))
                            {
                                Directory.CreateDirectory(sFolderPath);
                            }
                            ArrayList aryPrint = new ArrayList();
                            ArrayList aryPrintNew = new ArrayList();


                            aryPrint = PrintClinicalSummary(Convert.ToUInt32(dtEnc.Rows[i][1]), Convert.ToUInt32(dtEnc.Rows[i][0]), false, ref sMyPath, sFolderPath, true, false, dtEnc.Rows[i][2].ToString());

                            if (aryPrint != null && aryPrint.Count > 0)
                            {
                            }



                        }
                    }

                }
                catch (Exception ex){
                    LogWrite("Cerner CCD Generate", "InnerException : " + ex.InnerException + Environment.NewLine + "Message : " + ex.Message + "StackTrace : " + ex.StackTrace);
                
                }

            }
            else
            {
                Console.WriteLine("CCD Generate Process Started");
                //============Generate Button Start============
                IList<String> aryAttachmentList = new List<String>();
                //string s = AppDomain.CurrentDomain.BaseDirectory;// System.Reflection.Assembly.GetExecutingAssembly().Location;
                //string s ="SampleXML\\CCD_Sample.xml"; //Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "SampleXML" + "\\CCD_Sample.xml");
                //if (System.IO.File.Exists("D:\\Himaja\\CMG_20171219_New\\EHR-Capella5.0\\GenerateCCD\\SampleXML\\CCD_Sample.xml") == true)
                //{
                //}
                //else
                //{
                //}
                XmlDocument xmlDoc = new XmlDocument();
                XmlNodeList xmlReqNode = null;
                string frequency = "";
                string nonrecdatetime = "";
                string startdate = "";
                string Enddate = "";
                string fromdos = "", toDOs = "";
                string phy_id = "";
                string serverpath = "";
                string path = System.Configuration.ConfigurationSettings.AppSettings["Input_XML"];

                xmlDoc.Load(path);

                xmlReqNode = xmlDoc.GetElementsByTagName("Scheduler");
                string datefolder = System.DateTime.Now.ToString("yyyyMMMddhhmmss");
                for (int k = 0; k < xmlReqNode.Count; k++)
                {
                    frequency = xmlReqNode[k].Attributes["Frequency"].Value;
                    if (frequency.ToUpper() == "ONE TIME")
                    {
                        nonrecdatetime = xmlReqNode[k].Attributes["NonRecurringDate"].Value;
                    }
                    else if (frequency.ToUpper() == "EVERY DAY" || frequency.ToUpper() == "EVERY MONTH")
                    {
                        nonrecdatetime = xmlReqNode[k].Attributes["RecurringDate"].Value;

                    }
                    serverpath = xmlReqNode[k].Attributes["Path"].Value;
                    fromdos = xmlReqNode[k].Attributes["DOS_From_Date"].Value;
                    toDOs = xmlReqNode[k].Attributes["DOS_To_Date"].Value;
                    phy_id = xmlReqNode[k].Attributes["PhyID"].Value;

                    //if ((Convert.ToDateTime(nonrecdatetime).ToLocalTime().Date == System.DateTime.Now.Date &&
                    //   Convert.ToDateTime(nonrecdatetime).ToLocalTime().Hour == System.DateTime.Now.Hour &&
                    //   Convert.ToDateTime(nonrecdatetime).ToLocalTime().Minute == System.DateTime.Now.Minute))
                    if ((Convert.ToDateTime(nonrecdatetime).Date == System.DateTime.Now.Date &&
                       Convert.ToDateTime(nonrecdatetime).Hour == System.DateTime.Now.Hour &&
                       Convert.ToDateTime(nonrecdatetime).Minute == System.DateTime.Now.Minute))
                    {
                        Console.WriteLine("condition satisfied");
                        IList<Encounter> lstEncounter = new List<Encounter>();
                        EncounterManager encMngr = new EncounterManager();
                        string sFromDate = Convert.ToDateTime(fromdos).ToString("yyyy-MM-dd HH:mm:ss");// "2017-12-10";//Himaja UtilityManager.ConvertToUniversal(Convert.ToDateTime(System.Configuration.ConfigurationSettings.AppSettings["Start_Date"])).ToString("yyyy-MM-dd HH:mm:ss");
                        string sToDate = Convert.ToDateTime(toDOs).ToString("yyyy-MM-dd HH:mm:ss"); //"2017-12-20";//HimajaUtilityManager.ConvertToUniversal(Convert.ToDateTime(System.Configuration.ConfigurationSettings.AppSettings["To_Date"])).ToString("yyyy-MM-dd HH:mm:ss");
                        lstEncounter = encMngr.GetEncounterListForBulkExport(Convert.ToInt32(phy_id), sFromDate, sToDate);

                        string sMyPath = string.Empty;
                        string sFolderPath = System.Configuration.ConfigurationSettings.AppSettings["CCD_XML_Location"];// Server.MapPath("Documents/" + Session.SessionID);
                        sFolderPath = sFolderPath + "\\" + phy_id + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ClinicalSummaryPathName"] + "\\" + DateTime.Now.ToString("yyyyMMdd");
                        if (Directory.Exists(sFolderPath)==false)
                        {
                            Directory.CreateDirectory(sFolderPath);
                        }
                        ArrayList aryPrint = new ArrayList();
                        //frmClinicalSummary frmClin = new frmClinicalSummary();
                        ArrayList aryPrintNew = new ArrayList();

                        ulong ulHumanID = 0;

                        if (lstEncounter.Count > 0)
                        {
                            for (int i = 0; i < lstEncounter.Count; i++)
                            {
                                ulHumanID = lstEncounter[i].Human_ID;

                                //aryPrint = frmClin.PrintClinicalSummary(lstEncounter[i], lsthuman[i], false, ref sMyPath, string.Empty, true, false);
                                aryPrint = PrintClinicalSummary(lstEncounter[i].Id, lstEncounter[i].Human_ID, false, ref sMyPath, sFolderPath, true, false, phy_id);

                                if (aryPrint != null && aryPrint.Count > 0)
                                {
                                    for (int j = 0; j < aryPrint.Count; j++)
                                    {
                                        aryPrintNew.Add(aryPrint[j]);
                                    }
                                }
                            }
                        }

                        string PDFPath = string.Empty;
                        string XMlPath = string.Empty;
                        if (aryPrintNew.Count > 0)
                        {
                            XMlPath = aryPrintNew[0].ToString();
                        }
                        string listallfiles = string.Empty;
                        for (int i = 0; i < aryPrintNew.Count; i++)
                        {
                            string[] Split = new string[] { System.Configuration.ConfigurationSettings.AppSettings["CCD_XML_Location"] };//Himaja{ Server.MapPath("Documents\\" + Session.SessionID) };

                            if (aryPrintNew[i].ToString().EndsWith(".xml") == true)
                            {
                                string sPrintPathName = aryPrintNew[i].ToString();
                                string[] FileName = sPrintPathName.Split(Split, StringSplitOptions.RemoveEmptyEntries);

                                string Filenm = System.Configuration.ConfigurationSettings.AppSettings["CCD_XML_Location"] + "\\" + FileName[0].ToString(); //Himaja "Documents\\" + Session.SessionID.ToString() + FileName[0].ToString();
                                aryAttachmentList.Add(Filenm);
                                if (i == 0)
                                {
                                    listallfiles = Filenm;
                                }
                                else
                                {
                                    listallfiles = "~" + Filenm;
                                }

                                //HimajaSession["aryAttachmentList"] = aryAttachmentList;
                            }
                        }
                        //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "ShowFile();", true);
                        //HimajaScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "Downloadfile();", true);

                        AuditLogManager alManager = new AuditLogManager();
                        string TransactionType = "GENERATE";
                        alManager.InsertIntoAuditLog("BULK EXPORT", TransactionType, Convert.ToInt32(ulHumanID), "Acurus-Daemon");//BugID:49685

                        if (frequency.ToUpper() == "ONE TIME")
                        {
                            xmlReqNode[k].Attributes["NonRecurringDate"].Value = "";
                            xmlReqNode[k].ParentNode.RemoveChild(xmlReqNode[k]);
                        }
                        else if (frequency.ToUpper() == "EVERY DAY")
                        {
                            xmlReqNode[k].Attributes["RecurringDate"].Value = Convert.ToDateTime(nonrecdatetime).AddDays(1).ToString("yyyy-MM-dd hh:mm:ss");


                        }
                        else if (frequency.ToUpper() == "EVERY MONTH")
                        {
                            xmlReqNode[k].Attributes["RecurringDate"].Value = Convert.ToDateTime(nonrecdatetime).AddMonths(1).ToString("yyyy-MM-dd hh:mm:ss");


                        }
                        xmlDoc.Save(path);
                        if (path != "")
                        {

                            if (!Directory.Exists(serverpath + "\\" + phy_id))
                                Directory.CreateDirectory(serverpath + "\\" + phy_id);
                            string TargetFileDirectory = System.Configuration.ConfigurationSettings.AppSettings["CCD_XML_Location"];// Server.MapPath("Documents/" + Session.SessionID);
                            TargetFileDirectory = TargetFileDirectory + "\\" + phy_id + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ClinicalSummaryPathName"] + "\\" + DateTime.Now.ToString("yyyyMMdd");
                            if (Directory.Exists(TargetFileDirectory))
                            {
                                string[] fileEntries = Directory.GetFiles(TargetFileDirectory);
                                foreach (string fileName in fileEntries)
                                {
                                    File.Copy(fileName, serverpath + "\\" + phy_id + "\\" + Path.GetFileName(fileName), true);
                                }
                            }
                        }
                    }


                }
                //============Generate Button End============

                XmlNodeList xmlCaseReport = null;
                xmlCaseReport = xmlDoc.GetElementsByTagName("CaseReport");
                DateTime currDt = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"));
                DateTime dt = currDt;
                if (xmlCaseReport != null && xmlCaseReport.Count > 0)
                {
                    dt = Convert.ToDateTime(xmlCaseReport[0].Attributes.GetNamedItem("LastModifiedDate").Value);
                }

                if (currDt > dt)
                {
                    bool EligibleEncPresent = false;
                    bool Is_GenerationCompleted = false;



                    #region BILLING_WAIT Encounters

                    bool BillingNtSubmittedEnc_Present = false;
                    EncounterManager em = new EncounterManager();
                    IList<string> EncDetails = new List<string>();
                    BillingNtSubmittedEnc_Present = em.GetEligibleEncCaseReporting(out EncDetails);
                    IList<ulong> BillingWaitEncIDs = EncDetails.Select(a => Convert.ToUInt64(a.Split('^')[0])).ToList<ulong>();
                    string EncounterIDlst = string.Empty;
                    #endregion
                    if (BillingNtSubmittedEnc_Present)
                    {
                        //   CaseReportingLookupManager crLookupMngr = new CaseReportingLookupManager();
                        // EligibleEncPresent = crLookupMngr.GetCaseEligibleEnc(out EncounterIDlst, BillingWaitEncIDs);
                        IList<string> Enclst = EncounterIDlst.Split(',').ToList<string>();
                        #region UpdateCASEREPORT_DATE
                        if (EligibleEncPresent)
                        {
                            EncDetails = (from encIdsset in EncDetails where Enclst.Any(a => a == encIdsset.Split('^')[0]) select encIdsset).ToList<string>();
                            Is_GenerationCompleted = GenerateCCDXMLCaseReporting(EncDetails);
                            if (Is_GenerationCompleted)
                            {
                                xmlCaseReport[0].Attributes.GetNamedItem("LastModifiedDate").Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                                xmlDoc.Save(path);

                            }
                        }

                        #endregion
                    }
                    Console.WriteLine("CCD Xml Generate Process Completed");
                }
                else
                {
                    Console.WriteLine("Today's process already Completed...");
                }
            }
        }

        private static ArrayList PrintClinicalSummary(ulong ulEncounterId, ulong ulHumanId, Boolean bOpen, ref string sMyPathName, string sFolderPathName, bool isExport, bool isPatientPortal, string phy_id)
        {
            FillClinicalSummary WellnessNotes = null;
            ChiefComplaintsManager ClinicalMngr = new ChiefComplaintsManager();
            Encounter Enc = null;
            IList<PhysicianLibrary> PhysicianList = new List<PhysicianLibrary>();
            InsurancePlanManager InsurancePlanMngr = new InsurancePlanManager();

            ArrayList result = new ArrayList();

            if (ulEncounterId == 0)
            {
                //HimajaScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('110035');", true);
                return result;
            }

            //*************************************************************
            //To print the patient details
            WellnessNotes = ClinicalMngr.GetClinicalSummary(ulEncounterId, ulHumanId);
            //hn = EncounterManager.Instance.GetHumanByHumanID(ulHumanId);
            // Enc = EncounterManager.Instance.GetEncounterByEncID(ulEncounterId);
            if (WellnessNotes != null && WellnessNotes.Encounter[0] != null)
            {
                Enc = WellnessNotes.Encounter[0];
            }

            PhysicianList = WellnessNotes.phyList;

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 50, 50, 50, 50);
            //doc.SetPageSize(new iTextSharp.text.Rectangle(800, 800));

            //Commented for cerner
            //string sDirPath = System.Configuration.ConfigurationSettings.AppSettings["CCD_XML_Location"];//HimajaServer.MapPath("Documents/" + Session.SessionID);

            //DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

            //if (!ObjSearchDir.Exists)
            //{
            //    ObjSearchDir.Create();
            //}

            //string TargetFileDirectory = System.Configuration.ConfigurationSettings.AppSettings["CCD_XML_Location"];// Server.MapPath("Documents/" + Session.SessionID);
            //sFolderPathName = TargetFileDirectory + "\\" + phy_id + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ClinicalSummaryPathName"] + "\\" + DateTime.Now.ToString("yyyyMMdd");


            //sFolderPathName = sFolderPathName + "\\" + phy_id;
            //Directory.CreateDirectory(sFolderPathName);

            //To find the Primary Plan Name
            string PriPlan = string.Empty;
            IList<PatientInsuredPlan> PatInsList = new List<PatientInsuredPlan>();
            if (WellnessNotes != null && WellnessNotes.Pat_Ins_Plan != null)
                PatInsList = WellnessNotes.Pat_Ins_Plan;// Proxy.Util.EncounterManager.Instance.getPatientInsuredDetailsUsingPatHumanId(ulHumanId);
            for (int i = 0; i < PatInsList.Count; i++)
            {
                if (PatInsList[i].Insurance_Type.ToUpper() == "PRIMARY")
                {
                    IList<InsurancePlan> InsPlan = InsurancePlanMngr.GetInsurancebyID(PatInsList[i].Insurance_Plan_ID);
                    //PriPlan = InsPlan.Ins_Plan_Name;
                    PriPlan = InsPlan[0].External_Plan_Number;
                }
            }


            //if (sFolderPathName == string.Empty)
            //{
            //    sPrintPathName = System.Configuration.ConfigurationSettings.AppSettings["CapellaConfigurationSetttings"] + "\\" + System.Configuration.ConfigurationSettings.AppSettings["ClinicalSummaryPathName"] + "\\" + WellnessNotes.Last_Name + "_" + WellnessNotes.First_Name + "_" +
            //     PriPlan + "_" + Enc.Facility_Name + ".pdf";
            //}
            //else
            //{
            //    sPrintPathName = sFolderPathName + "\\" + WellnessNotes.Last_Name + "_" + WellnessNotes.First_Name + "_" +
            //     PriPlan + "_" + Enc.Facility_Name + ".pdf";
            //}
            string sPrintPathName = string.Empty;

            //sPrintPathName = sFolderPathName + "\\" + WellnessNotes.Last_Name + "_" + WellnessNotes.First_Name + "_" +
            //       PriPlan + "_" + Enc.Facility_Name.Replace("#", "") + "_" + ulHumanId + "_" + ulEncounterId + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf";

            sPrintPathName = sFolderPathName + "\\" + "CCD_" + ulEncounterId + ".xml";

            //*************************************************************HL7
            Hashtable hashCheckList = new Hashtable();

            if (isExport)
            {
                hashCheckList.Add("chkReasonOfVisit", true);
                hashCheckList.Add("chkCarePlan", true);
                hashCheckList.Add("chkProcedures", true);
                hashCheckList.Add("chkClinicalInstruction", true);
                hashCheckList.Add("chkSmokingStatus", true);
                hashCheckList.Add("chkLaboratoryResultValues", true);
                hashCheckList.Add("chkImmunization", true);
                hashCheckList.Add("chkAllergies", true);
                hashCheckList.Add("chkEncounter", true);
                hashCheckList.Add("chkMedicationAdministrative", true);
                hashCheckList.Add("chkMedication", true);
                hashCheckList.Add("chkReasonforReferral", true);
                hashCheckList.Add("chkProblemList", true);
                hashCheckList.Add("chkVitals", true);
                hashCheckList.Add("chkChiefComplaints", true);
                hashCheckList.Add("chkImplant", true);
                hashCheckList.Add("chkMentalStatus", true);
                hashCheckList.Add("chkFunctionalStatus", true);
                hashCheckList.Add("chkHealthConcern", true);
                hashCheckList.Add("chkTreatmentPlan", true);
                hashCheckList.Add("chkGoals", true);


            }
            else
            {
                //Himaja
                //for (int i = 0; i < pnlEncounterDetails.Controls.Count; i++)
                //{
                //    if (pnlEncounterDetails.Controls[i] is CheckBox)
                //    {
                //        hashCheckList.Add(((CheckBox)pnlEncounterDetails.Controls[i]).ID, ((CheckBox)pnlEncounterDetails.Controls[i]).Checked);
                //    }

                //}
            }

            UtilityManager umanger = new UtilityManager();
            string sValue = string.Empty;
            IList<CarePlan> cpFinalList = new List<CarePlan>();
            for (int i = 0; i < WellnessNotes.Care_Plan_Cognitive_Function_MentalStatus.Count; i++)
            {
                sValue = umanger.GetFieldNameForSnomedCodefromStaticLookup("FollowupList", WellnessNotes.Care_Plan_Cognitive_Function_MentalStatus[i].Snomed_Code);
                if (sValue != string.Empty)
                {
                    if (sValue.Contains(','))
                    {
                        string[] ccObject = (string[])sValue.Split(',');
                        foreach (string s in ccObject)
                        {
                            CarePlan obj = new CarePlan();
                            obj.Snomed_Code = s.Split('~')[0];
                            obj.Care_Name_Value = s.Split('~')[1];
                            obj.Plan_Date = WellnessNotes.Care_Plan_Cognitive_Function_MentalStatus[i].Plan_Date;
                            cpFinalList.Add(obj);
                        }
                    }
                    else
                    {
                        CarePlan obj = new CarePlan();
                        obj.Snomed_Code = sValue.Split('~')[0];
                        obj.Care_Name_Value = sValue.Split('~')[1];
                        obj.Plan_Date = WellnessNotes.Care_Plan_Cognitive_Function_MentalStatus[i].Plan_Date;
                        cpFinalList.Add(obj);
                    }
                }
            }
            WellnessNotes.Care_Plan_Cognitive_Function_MentalStatus = cpFinalList;

            sValue = string.Empty;
            IList<CarePlan> cpFunctionalFinalList = new List<CarePlan>();
            for (int i = 0; i < WellnessNotes.Care_Plan_FunctionalStatus.Count; i++)
            {
                sValue = umanger.GetFieldNameForSnomedCodefromStaticLookup("FollowupList", WellnessNotes.Care_Plan_FunctionalStatus[i].Snomed_Code);
                if (sValue != string.Empty)
                {
                    if (sValue.Contains(','))
                    {
                        string[] ccObject = (string[])sValue.Split(',');
                        foreach (string s in ccObject)
                        {
                            CarePlan obj = new CarePlan();
                            obj.Snomed_Code = s.Split('~')[0];
                            obj.Care_Name_Value = s.Split('~')[1];
                            obj.Plan_Date = WellnessNotes.Care_Plan_FunctionalStatus[i].Plan_Date;
                            cpFunctionalFinalList.Add(obj);
                        }
                    }
                    else
                    {
                        CarePlan obj = new CarePlan();
                        obj.Snomed_Code = sValue.Split('~')[0];
                        obj.Care_Name_Value = sValue.Split('~')[1];
                        obj.Plan_Date = WellnessNotes.Care_Plan_FunctionalStatus[i].Plan_Date;
                        cpFunctionalFinalList.Add(obj);
                    }
                }
            }
            WellnessNotes.Care_Plan_FunctionalStatus = cpFunctionalFinalList;
            if (PhysicianList.Count == 0)
            {
                PhysicianLibrary obj = new PhysicianLibrary();
                obj.PhyFirstName = "Acurus";
                obj.PhyLastName = " Capella EHR v5.4";
                PhysicianList.Add(obj);
            }

            HL7Generator hl7Gen = new HL7Generator();
            XmlDocument xmlDoc = hl7Gen.CreateCCDXML(PhysicianList[0], WellnessNotes, sPrintPathName, hashCheckList);
            result.Add(sPrintPathName);


            // string readText = File.ReadAllText(sPrintPathName.Replace(".pdf", ".xml"));
            // var encoding = new UnicodeEncoding();
            // string str = Convert.ToBase64String(encoding.GetBytes(readText));
            // File.WriteAllText(sPrintPathName.Replace(".xml", ".txt"), str);
            ////Delete Original xml file after encode to base 64.
            // if (File.Exists(sPrintPathName))
            //     File.Delete(sPrintPathName);

            // /*/To decode Xml*/
            // var base64EncodedBytes = System.Convert.FromBase64String(str);
            // File.WriteAllText(sPrintPathName.Replace("CCD_","Decode_"), System.Text.Encoding.UTF8.GetString(base64EncodedBytes));
            return result;
        }

        private static bool GenerateCCDXMLCaseReporting(IList<string> EncDetails)//EncDetails is a list of string with each string of format EncounterID^HumanID^PhysicianID
        {
            bool Is_generated = false;
            ChiefComplaintsManager objChiefComplaintsMngr = new ChiefComplaintsManager();
            InsurancePlanManager InsurancePlanMngr = new InsurancePlanManager();
            foreach (string Enc_Hum_ID in EncDetails)
            {
                Encounter Enc = new Encounter();
                ulong uEncounterID = Convert.ToUInt64(Enc_Hum_ID.Split('^')[0]);
                ulong uHumanID = Convert.ToUInt64(Enc_Hum_ID.Split('^')[1]);
                FillClinicalSummary CaseReport = objChiefComplaintsMngr.GetClinicalSummaryCaseReporting(uEncounterID, uHumanID);


                if (CaseReport != null && CaseReport.Encounter[0] != null)
                {
                    Enc = CaseReport.Encounter[0];
                }
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 50, 50, 50, 50);

                string sFolderPathName = System.Configuration.ConfigurationSettings.AppSettings["CaseReportingXML"] + "//" + CaseReport.phyList[0].Id;
                if (!Directory.Exists(sFolderPathName))
                {
                    Directory.CreateDirectory(sFolderPathName);

                }
                string sXslPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleXML\\CDA.xsl");
                if (!File.Exists(sFolderPathName + "//CDA.xsl"))
                {
                    File.Copy(sXslPath, sFolderPathName + "//CDA.xsl");
                }

                //To find the Primary Plan Name
                string PriPlan = string.Empty;
                IList<PatientInsuredPlan> PatInsList = new List<PatientInsuredPlan>();
                if (CaseReport != null && CaseReport.Pat_Ins_Plan != null)
                    PatInsList = CaseReport.Pat_Ins_Plan;
                for (int i = 0; i < PatInsList.Count; i++)
                {
                    if (PatInsList[i].Insurance_Type.ToUpper() == "PRIMARY")
                    {
                        IList<InsurancePlan> InsPlan = InsurancePlanMngr.GetInsurancebyID(PatInsList[i].Insurance_Plan_ID);
                        PriPlan = InsPlan[0].External_Plan_Number;
                    }
                }


                string sPrintPathName = string.Empty;
                string File_Name = CaseReport.Last_Name + "_" + CaseReport.First_Name + "_" + PriPlan + "_" + Enc.Facility_Name.Replace("#", "") + "_" + uHumanID + "_" + uEncounterID + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xml";
                sPrintPathName = sFolderPathName + "\\" + File_Name;

                HL7Generator hl7Gen = new HL7Generator();
                XmlDocument xmlDoc = hl7Gen.GenerateCaseReportingXML(CaseReport.phyList[0], CaseReport, sPrintPathName);
                #region REGISTRY_LOG
                RegistryLogManager rlManager = new RegistryLogManager();
                IList<RegistryLog> ImmSubLoglst = new List<RegistryLog>();
                IList<RegistryLog> ImmSubLogUpdtlst = new List<RegistryLog>();
                RegistryLog ImmSubLog = new RegistryLog();
                ImmSubLog.Human_ID = uHumanID;
                ImmSubLog.Encounter_ID = uEncounterID;
                ImmSubLog.Physician_ID = CaseReport.phyList[0].Id;
                ImmSubLog.Created_By = "Acurus";
                ImmSubLog.Created_Date_And_Time = System.DateTime.UtcNow;
                ImmSubLog.Submission_Result_Type = "Success";
                ImmSubLog.Result_Message = "";
                ImmSubLog.Response_Message = "";
                ImmSubLog.Control_ID = "";
                ImmSubLog.Registry_Type = "E_Case_Reporting";
                ImmSubLog.Status = "Generated";
                ImmSubLog.FileName = File_Name;
                ImmSubLoglst.Add(ImmSubLog);
                RegistryLogManager ImmSubLogManager = new RegistryLogManager();
                ImmSubLogManager.SaveUpdateDelete_DBAndXML_WithTransaction(ref ImmSubLoglst, ref ImmSubLogUpdtlst, null, string.Empty, false, false, 0, String.Empty);
                #endregion
                xmlDoc.Save(Path.Combine(sFolderPathName, sPrintPathName));

            }
            Is_generated = true;//After Generation of CCDs for All Encounters
            return Is_generated;
        }

        public static string LogWrite(string sAPIName, string logMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Environment.NewLine + logMessage + Environment.NewLine);

            string sLogFileName = ConfigurationManager.AppSettings["LogTxt"];
            if (!File.Exists(sLogFileName))
            {
                File.Create(sLogFileName);
            }
            try
            {
                using (StreamWriter txtWriter = File.AppendText(sLogFileName))
                {

                    txtWriter.WriteLine(Environment.NewLine);
                    txtWriter.WriteLine("-------------------------------");
                    txtWriter.WriteLine("{0}", sAPIName + " - " + DateTime.Now + " - " + logMessage);
                    txtWriter.WriteLine("-------------------------------");
                }
            }
            catch (Exception ex)
            {
                LogWrite("LogFunction", "Exception InnerException: " + ex.InnerException + Environment.NewLine +
                                              "Exception StackTrace: " + ex.StackTrace + Environment.NewLine +
                                              "Exception Message: " + ex.Message + Environment.NewLine +
                                              "Exception Source: " + ex.Source + Environment.NewLine);
            }
            return "";
        }

        public static class DBConnector
        {
            static MySqlDataAdapter MyDataAdap = null;
            private static string ReadConnection()
            {
                string ConnectionData;
                ConnectionData = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                return ConnectionData;
            }
            public static DataSet ReadData(string Query)
            {
                DataSet dsReturn = new DataSet();
                MyDataAdap = new MySqlDataAdapter(Query, ReadConnection());
                MyDataAdap.Fill(dsReturn);
                return dsReturn;
            }
            public static string createFile()
            {
                string OutputDir = ConfigurationManager.AppSettings["Output"];
                if (!Directory.Exists(OutputDir))
                    Directory.CreateDirectory(OutputDir);
                return OutputDir;
            }
        }
    }
}
