using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Xml;
using Acurus.Capella.DataAccess;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace DownloadRCopia
{
    class Program
    {
        static XmlWriterSettings wSettings = new XmlWriterSettings();
        static MemoryStream ms;
        static XmlWriter xmlWriter;
        static IList<Rcopia_Settings> ilstRcopSett;
        static Rcopia_Settings objRcopSettings;
        static CultureInfo culture = new CultureInfo("en-US");

        static void Main(string[] args)
        {
            DownloadRCopiaInfo(string.Empty, "Acurus", string.Empty, DateTime.Now, string.Empty, 0);
        }



        public static void DownloadRCopiaInfo(string sDownloadAddress, string sUserName, string sMACAddress, DateTime dtClientDate, string sFacilityName, ulong EncID)
        {
            RCopiaSessionManager rcopiaSessionMngr = new RCopiaSessionManager();
            Rcopia_Update_InfoManager objUpdateInfoMngr = new Rcopia_Update_InfoManager();

            RCopiaTransactionManager tranMngr = new RCopiaTransactionManager();
            RCopiaXMLResponseProcess rcopiaResponseXML = new RCopiaXMLResponseProcess();
            string sInputXML = string.Empty;
            string sOutputXML = string.Empty;
           
            //BugID:51252  Changed uploadAddress to downloadAddress
            WorkFlowManager obj = new WorkFlowManager();

            sInputXML = CreateUpdateAllergyXML();
            if (rcopiaSessionMngr.DownloadAddress != null)
            {

                sOutputXML = rcopiaSessionMngr.HttpPost(rcopiaSessionMngr.DownloadAddress + sInputXML, 1);

                rcopiaResponseXML.ReadXMLResponse(sOutputXML, sUserName, sMACAddress, dtClientDate, sFacilityName, EncID,true);
                XmlDocument XMLDoc = new XmlDocument();
                if (sOutputXML != null)
                {
                    XMLDoc.LoadXml(sOutputXML);

                    XmlNodeList xmlReqNode = XMLDoc.GetElementsByTagName("LastUpdateDate");
                    string CmdElementText1 = ((XmlElement)xmlReqNode[1]).InnerText;
                    xmlReqNode = XMLDoc.GetElementsByTagName("Command");
                    string CmdElementText2 = ((XmlElement)xmlReqNode[0]).InnerText;

                    objUpdateInfoMngr.InsertinToRcopia_Update_info(CmdElementText2, Convert.ToDateTime(CmdElementText1, culture), string.Empty, sMACAddress);

                }
            }

            sInputXML = CreateUpdateMedicationXML();

            if (rcopiaSessionMngr.DownloadAddress != null)
            {

                sOutputXML = rcopiaSessionMngr.HttpPost(rcopiaSessionMngr.DownloadAddress + sInputXML, 1);

                rcopiaResponseXML.ReadXMLResponse(sOutputXML, sUserName, sMACAddress, dtClientDate, sFacilityName, EncID, true);

                XmlDocument XMLDoc = new XmlDocument();
                if (sOutputXML != null)
                {
                    XMLDoc.LoadXml(sOutputXML);
                    XmlNodeList xmlReqNode = XMLDoc.GetElementsByTagName("LastUpdateDate");
                    string CmdElementText1 = ((XmlElement)xmlReqNode[1]).InnerText;
                    xmlReqNode = XMLDoc.GetElementsByTagName("Command");
                    string CmdElementText2 = ((XmlElement)xmlReqNode[0]).InnerText;

                    objUpdateInfoMngr.InsertinToRcopia_Update_info(CmdElementText2, Convert.ToDateTime(CmdElementText1, culture), string.Empty, sMACAddress);

                }
            }
            //sInputXML = rcopiaXML.CreateUpdateProblemXML();
            //if (RCopiaSessionManager.UploadAddress != null)
            //{
            //    sOutputXML = rcopiaSessionMngr.HttpPost(RCopiaSessionManager.UploadAddress + sInputXML, 1);
            //    rcopiaResponseXML.ReadXMLResponse(sOutputXML, sMACAddress);
            //}


            sInputXML = CreateUpdatePrescriptionXML();

            if (rcopiaSessionMngr.DownloadAddress != null)
            {

                sOutputXML = rcopiaSessionMngr.HttpPost(rcopiaSessionMngr.DownloadAddress + sInputXML, 1);

                rcopiaResponseXML.ReadXMLResponse(sOutputXML, sUserName, sMACAddress, dtClientDate, sFacilityName, EncID,true);

                XmlDocument XMLDoc = new XmlDocument();
                if (sOutputXML != null)
                {
                    XMLDoc.LoadXml(sOutputXML);
                    XmlNodeList xmlReqNode = XMLDoc.GetElementsByTagName("LastUpdateDate");
                    string CmdElementText1 = ((XmlElement)xmlReqNode[1]).InnerText;
                    xmlReqNode = XMLDoc.GetElementsByTagName("Command");
                    string CmdElementText2 = ((XmlElement)xmlReqNode[0]).InnerText;

                    objUpdateInfoMngr.InsertinToRcopia_Update_info(CmdElementText2, Convert.ToDateTime(CmdElementText1, culture), string.Empty, sMACAddress);

                }
            }

        }

        public static string CreateUpdateMedicationXML()
        {
            FillRequiredInfo("update_medication");
            Rcopia_Update_InfoManager rcopiaUpdatemngr = new Rcopia_Update_InfoManager();
            //IList<Rcopia_Update_info> ilstRcopUpdateInfo = rcopiaUpdatemngr.GetRcopiaUpdateInfo();

            string ilstRcopUpdateInfoDate = rcopiaUpdatemngr.GetRcopiaUpdateInfoCommandName("update_medication");
            if (ilstRcopUpdateInfoDate != "")
                xmlWriter.WriteElementString("LastUpdateDate", ilstRcopUpdateInfoDate.Replace("-", "/"));

            //if (ilstRcopUpdateInfo.Count > 0)
            //{
            //    Rcopia_Update_info objupdateInfo = (from j in ilstRcopUpdateInfo where j.Command == "update_medication" select j).ToList<Rcopia_Update_info>()[0];
            //    xmlWriter.WriteElementString("LastUpdateDate", objupdateInfo.Last_Updated_Date_Time.ToString("MM/dd/yyyy hh:mm:ss").Replace("-", "/"));
            //}
            xmlWriter.WriteStartElement("Patient");
            xmlWriter.WriteElementString("RcopiaID", string.Empty);
            xmlWriter.WriteElementString("ExternalID", string.Empty);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            Byte[] buffer = new Byte[ms.Length];
            buffer.DefaultIfEmpty();
            buffer = ms.ToArray();
            string xmlOutput = System.Text.Encoding.UTF8.GetString(buffer);

            return xmlOutput;

        }


        public static string CreateUpdatePrescriptionXML()
        {
            FillRequiredInfo("update_prescription");
            Rcopia_Update_InfoManager rcopiaUpdatemngr = new Rcopia_Update_InfoManager();

            string ilstRcopUpdateInfoDate = rcopiaUpdatemngr.GetRcopiaUpdateInfoCommandName("update_prescription");
            if (ilstRcopUpdateInfoDate != "")
                xmlWriter.WriteElementString("LastUpdateDate", ilstRcopUpdateInfoDate.Replace("-", "/"));
            xmlWriter.WriteStartElement("Patient");
            xmlWriter.WriteElementString("RcopiaID", string.Empty);
            xmlWriter.WriteElementString("ExternalID", string.Empty);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("Status", "all");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            Byte[] buffer = new Byte[ms.Length];
            buffer = ms.ToArray();
            string xmlOutput = System.Text.Encoding.UTF8.GetString(buffer);

            return xmlOutput;

        }

        public static string CreateUpdateAllergyXML()
        {
            FillRequiredInfo("update_allergy");
            Rcopia_Update_InfoManager rcopiaUpdatemngr = new Rcopia_Update_InfoManager();
            string ilstRcopUpdateInfoDate = rcopiaUpdatemngr.GetRcopiaUpdateInfoCommandName("update_allergy");
            if (ilstRcopUpdateInfoDate != "")
                xmlWriter.WriteElementString("LastUpdateDate", ilstRcopUpdateInfoDate.Replace("-", "/"));
            xmlWriter.WriteElementString("ReturnAllNDCIDs", "y");
            xmlWriter.WriteStartElement("Patient");
            xmlWriter.WriteElementString("RcopiaID", string.Empty);
            xmlWriter.WriteElementString("ExternalID", string.Empty);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            Byte[] buffer = new Byte[ms.Length];
            buffer = ms.ToArray();
            string xmlOutput = System.Text.Encoding.UTF8.GetString(buffer);

            return xmlOutput;
        }

        public static void FillRequiredInfo(string sXMLName)
        {
            ms = new MemoryStream();
            wSettings.Indent = true;
            xmlWriter = XmlWriter.Create(ms, wSettings);
            xmlWriter.WriteStartDocument();

            Rcopia_SettingsManager rcopiaSettingsMngr = new Rcopia_SettingsManager();
            ilstRcopSett = rcopiaSettingsMngr.GetRcopia_Settings();
            if (ilstRcopSett.Count > 0)
            {

                objRcopSettings = (from g in ilstRcopSett where g.Command == sXMLName select g).ToList<Rcopia_Settings>()[0];
                if (sXMLName == "get_review_status" || sXMLName == "update_patient_office_visits")
                {
                    xmlWriter.WriteStartElement("RCExtRequest");
                    xmlWriter.WriteAttributeString("version", "2.35");//changed version from 2.13 to 2.19 as per Dr.First's instructions[RajeevMotwani] as Assessment data were not getting uploaded(under Problem section) to Dr.First
                    xmlWriter.WriteStartElement("TraceInformation");
                    xmlWriter.WriteElementString("RequestMessageID", objRcopSettings.Request_Message_ID);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Caller");
                    PropertyInfo[] propertyInfoColl = typeof(Rcopia_Settings).GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfoColl)
                    {
                        string sreturn = FillObject(propertyInfo.Name);
                        if (sreturn != string.Empty && sreturn != "ExternalID")
                        {
                            PropertyInfo o = objRcopSettings.GetType().GetProperty(propertyInfo.Name);
                            var v = (o.GetValue(objRcopSettings, null));
                            xmlWriter.WriteElementString(sreturn, v.ToString());
                        }
                    }
                }
                else
                {

                    xmlWriter.WriteStartElement("RCExtRequest");
                    xmlWriter.WriteAttributeString("version", "2.35");//changed version from 2.13 to 2.19 as per Dr.First's instructions[RajeevMotwani] as Assessment data were not getting uploaded(under Problem section) to Dr.First
                    xmlWriter.WriteStartElement("TraceInformation");
                    xmlWriter.WriteElementString("RequestMessageID", objRcopSettings.Request_Message_ID);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Caller");
                    PropertyInfo[] propertyInfoColl = typeof(Rcopia_Settings).GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfoColl)
                    {
                        string sreturn = FillObject(propertyInfo.Name);
                        if (sreturn != string.Empty)
                        {
                            PropertyInfo o = objRcopSettings.GetType().GetProperty(propertyInfo.Name);
                            var v = (o.GetValue(objRcopSettings, null));
                            xmlWriter.WriteElementString(sreturn, v.ToString());
                        }
                    }
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteElementString("SystemName", objRcopSettings.System_Name);
                xmlWriter.WriteElementString("RcopiaPracticeUsername", objRcopSettings.Rcopia_Practice_User_name);
                xmlWriter.WriteStartElement("Request");
                xmlWriter.WriteElementString("Command", objRcopSettings.Command);
            }
        }

        public static string FillObject(string sPropname)
        {
            string ReturnString = string.Empty;
            switch (sPropname)
            {
                case "Id":
                    ReturnString = "ExternalID";
                    break;
                case "Street_Address1":
                    ReturnString = "Address1";
                    break;
                case "Street_Address2":
                    ReturnString = "Address2";
                    break;
                case "City":
                    ReturnString = "City";
                    break;
                case "Birth_Date":
                    ReturnString = "DOB";
                    break;
                case "First_Name":
                    ReturnString = "FirstName";
                    break;
                case "Last_Name":
                    ReturnString = "LastName";
                    break;
                case "MI":
                    ReturnString = "MiddleName";
                    break;
                case "Sex":
                    ReturnString = "Sex";
                    break;
                case "Home_Phone_No":
                    ReturnString = "HomePhone";
                    break;
                case "SSN":
                    ReturnString = "SSN";
                    break;
                case "State":
                    ReturnString = "State";
                    break;
                case "ZipCode":
                    ReturnString = "Zip";
                    break;
                case "Vendor_Name":
                    ReturnString = "VendorName";
                    break;
                case "Vendor_Password":
                    ReturnString = "VendorPassword";
                    break;
                case "Application":
                    ReturnString = "Application";
                    break;
                case "Rcopia_Version":
                    ReturnString = "Version";
                    break;
                case "Practice_Name":
                    ReturnString = "PracticeName";
                    break;
                case "Station":
                    ReturnString = "Station";
                    break;
            }
            return ReturnString;
        }

    }
}
