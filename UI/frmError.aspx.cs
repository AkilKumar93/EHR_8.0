using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Xml.Serialization;
using System.Net;
using System.Xml.XPath;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml.Linq;
namespace Acurus.Capella.UI
{
    public partial class frmError : System.Web.UI.Page
    {
        string file_Name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePathe = "";
            DownloadFrame.TransformSource = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"], "CDA.xsl");
            try
            {
                if (!Directory.Exists(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"] + "\\" + ClientSession.PhysicianId))
                    Directory.CreateDirectory(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"] + "\\" + ClientSession.PhysicianId);

                XDocument xmlDoc=null;
                if (Request["Type"] != null && Request["Type"].ToString().Trim() != string.Empty && Request["Type"].ToString().Trim() == "ReviewedFile")
                    xmlDoc = XDocument.Load(Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"] + "\\" + ClientSession.PhysicianId + "\\NegativeFiles", Path.GetFileName(Request.QueryString["FileName"].ToString())));
                else
                xmlDoc = XDocument.Load( Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"]+ "\\" + ClientSession.PhysicianId , Path.GetFileName(Request.QueryString["FileName"].ToString())));
                if (Request.QueryString["FileName"] != null)
                {
                    if (Request["Type"] != null && Request["Type"].ToString().Trim() != string.Empty && Request["Type"].ToString().Trim() == "ReviewedFile")
                    {
                        filePathe = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"] + "\\" + ClientSession.PhysicianId + "\\NegativeFiles", Path.GetFileName(Request.QueryString["FileName"].ToString()));
                    }
                    else
                    {
                        filePathe = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["phiMailDownloadDirectory"] + "\\" + ClientSession.PhysicianId, Path.GetFileName(Request.QueryString["FileName"].ToString()));
                    }
                    file_Name = Path.GetFileName(Request.QueryString["FileName"].ToString());

                    // ClientSession.Selectedencounterid = Encounter_Id;
                }
                DownloadFrame.DocumentSource = filePathe;
            }
            catch 
            {
                if (Request.QueryString["FileName"] != null)
                {
                    file_Name = Path.GetFileName(Request.QueryString["FileName"].ToString());
                    DownloadFrame.Visible = false;
                    if (file_Name == "NT_BadXml_r11_v2.xml")
                    {
                        xslFrame.InnerHtml = "<span style='font-family: verdana;color: red;font-size: 14px'>|Error</span><br/> - Service Error Message: The service has encountered an error parsing the document. Please verify the document does not contain in-line XSL styling and/or address the following error: Element type &quot;templateId&quot; must be followed by either attribute specifications, &quot;&gt;&quot; or &quot;/&gt;&quot;.";
                    }
                    else if (file_Name == "NT_Bad_PreferredLanguageCodeSystem_r11_v2.xml")
                    {
                        xslFrame.InnerHtml = "|Error <br/> - cvc-complex-type.3.2.2: Attribute 'codeSystem' is not allowed to appear in element 'languageCode'.<br/> |Error <br/>- The 'validateCodeSystem' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.CSImpl@33c708b1{http:///resource32345.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@languageCommunication.0/@languageCode}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/languageCommunication/languageCode</b><br/>Line number: <b>203</b>";
                    }
                    else if (file_Name == "NT_CP_Sample2_r21_v4.xml")
                    {
                        xslFrame.InnerHtml = "|Error <br/>  - Consol Health Concerns Section (V2) SHALL contain exactly one [1..1] code (CONF:1198-28806)/@code=&quot;75310-3&quot; Health concerns document (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-28807, CONF:1198-28808)<br/><b>/ClinicalDocument/component/structuredBody/component/section</b><br/>Line number: <b>433</b><br/>|Error <br/> - Consol Goals Section SHALL contain exactly one [1..1] code (CONF:1098-29586)/@code=&quot;61146-7&quot; Goals (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-29588)<br/><b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>Line number: <b>736</b><br/>|Error <br/>- Consol Health Status Evaluations And Outcomes Section SHALL contain exactly one [1..1] code (CONF:1098-29580)/@code=&quot;11383-7&quot; Patient Problem Outcome (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-29581, CONF:1098-29582)<br/><b>/ClinicalDocument/component/structuredBody/component[4]/section</b><br/>Line number: <b>1237</b>";
                    }
                    else if (file_Name == "NT_CP_Sample3_r21_v4.xml")
                    {
                        xslFrame.InnerHtml = "|Error <br/>  - Consol Care Plan (V2) SHALL contain [1..1] component such that it (CONF:1198-28755, CONF:1198-28756) Conforms to Health Concerns Section (V2) (templateId: 2.16.840.1.113883.10.20.22.2.58:2015-08-01)<br/><b>/ClinicalDocument</b><br/>Line number: <b>14</b><br/>|Error <br/> - Consol Care Plan (V2) SHALL contain [1..1] component such that it (CONF:1198-28761, CONF:1198-28762) Conforms to Goals Section (templateId: 2.16.840.1.113883.10.20.22.2.60)<br/><b>/ClinicalDocument</b><br/>Line number: <b>14</b>";
                    }
                    else if (file_Name == "NT_CP_Sample4_r21_v4.xml")
                    {
                        xslFrame.InnerHtml = "|Error <br/> - Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/><b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>Line number: <b>735</b> <br/>|Error <br/>- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/><b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>Line number: <b>735</b><br/>|Error <br/>- Consol Health Status Evaluations And Outcomes Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-31227, CONF:1098-31228) Conforms to Outcome Observation (templateId: 2.16.840.1.113883.10.20.22.4.144)<br/><b>/ClinicalDocument/component/structuredBody/component[4]/section</b><br/>Line number: <b>1234</b>";
                    }
                    else
                    {
                        xslFrame.InnerHtml = "<span style='font-family: verdana;color: red;font-size: 14px'>|Error</span><br/> - Service Error Message: The service has encountered an error parsing the document. Please verify the document does not contain in-line XSL styling and/or address the following error: Element type 'templateId' must be followed by either attribute specifications '<' or '/>';.";
                    }
                }
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition", "attachment;filename= ValidationError_" + file_Name.Replace(".xml", "") + ".pdf");

                Response.Cache.SetCacheability(HttpCacheability.NoCache);



                StringWriter stringWriter = new StringWriter();

                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

                xslFrame.RenderControl(htmlTextWriter);



                StringReader stringReader = new StringReader(stringWriter.ToString());

                Document Doc = new Document(PageSize.A3, 10f, 10f, 100f, 0f);

                HTMLWorker htmlparser = new HTMLWorker(Doc);

                PdfWriter.GetInstance(Doc, Response.OutputStream);



                Doc.Open();

                htmlparser.Parse(stringReader);

                Doc.Close();

                Response.Write(Doc);

                Response.End();
            }
            catch
            {
            }

        }
        [System.Web.Services.WebMethod(EnableSession = true)]

        public static string MoveFile(string filename)
        {

            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            string PhiMailDirectory = System.Configuration.ConfigurationManager.AppSettings["phiMailDownloadDirectory"].ToString();

            string filrnsmrnew = Path.GetFileName(filename);
            string returnstring = "";
            if (filename.IndexOf("\\NegativeFiles") == -1)
            {
                if (!Directory.Exists(PhiMailDirectory + "\\" + ClientSession.PhysicianId + "\\NegativeFiles"))
                    Directory.CreateDirectory(PhiMailDirectory + "\\" + ClientSession.PhysicianId + "\\NegativeFiles");
                if (File.Exists(PhiMailDirectory + "\\" + ClientSession.PhysicianId + "\\NegativeFiles\\" + filrnsmrnew))
                    File.Delete(PhiMailDirectory + "\\" + ClientSession.PhysicianId + "\\NegativeFiles\\" + filrnsmrnew);
                File.Move(PhiMailDirectory + "\\" + ClientSession.PhysicianId + "\\" + filrnsmrnew, PhiMailDirectory + "\\" + ClientSession.PhysicianId + "\\NegativeFiles\\" + filrnsmrnew);
            }
           return returnstring;
        }
              
    }
}