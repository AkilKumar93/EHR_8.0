using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acurus.Capella.UI
{
    public partial class frmPatientDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod(EnableSession = true)]
        public static string FillPatientDocuments(string sUsername)
        {
            
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "";
            }
          
            //ClientSession.UserName;
            IList<UserLookup> lstUserLookup = new List<UserLookup>();
            UserLookupManager usermg = new UserLookupManager();
            if (sUsername != "")
                lstUserLookup = usermg.GetFieldLookupList(sUsername, "PATIENT EDUCATION DOCUMENTS");  
            else
                lstUserLookup = usermg.GetFieldLookupList(ClientSession.UserName, "PATIENT EDUCATION DOCUMENTS"); 
            //if (ClientSession.HumanId == 0 && ClientSession.EncounterId==0)
            //{
               IList<string> lstUnloadFiles=new List<string>{"PROGRESS NOTE","CONSULTATION NOTE","WELLNESS NOTE","CLINICAL SUMMARY"};
               lstUserLookup = lstUserLookup.Where(aa => !lstUnloadFiles.Any(bb => bb==aa.Value.ToString().ToUpper())).ToList();
           
            //}
           
            var Result = new { UserLookup = lstUserLookup };
            return JsonConvert.SerializeObject(Result);
        }
        [WebMethod(EnableSession = true)]
        public static string FindPatientDocument(string[] data)
        {

            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "";
            }
            IList<string> SelectedItems = new List<string>();
            string Checked_Docs = string.Empty;
            if (data.Count() > 0)
            {
                Checked_Docs = data[0].ToString();
            }
            for (int i = 0; i < Checked_Docs.Split(':').Count(); i++)
            {
                SelectedItems.Add(Checked_Docs.Split(':')[i].ToString());
            }

            string[] GetFiles = Directory.GetFiles(HostingEnvironment.ApplicationPhysicalPath + "Documents\\Physician_Specific_Documents\\Patient Education\\");

            string[] Separator = new string[] { HostingEnvironment.ApplicationPhysicalPath + "Documents\\Physician_Specific_Documents\\Patient Education\\" };

            IList<string> FilesNotFound = new List<string>();
            string filesNotFound = string.Empty;
            string selectedFile =string.Empty;

            foreach (string s in GetFiles)
            {
                string[] SplitedDocName = s.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

                FilesNotFound.Add(SplitedDocName[0].ToString());
            }
            for (int i = 0; i < SelectedItems.Count; i++)
            {
                if (!FilesNotFound.Any(a => a.ToString() == SelectedItems[i].ToString()))
                {
                    if (filesNotFound == string.Empty)
                    {
                        filesNotFound = SelectedItems[i].ToString();
                    }
                    else
                    {
                        filesNotFound += " , " + SelectedItems[i].ToString();
                    }
                    continue;
                }
                else
                {
                    if (selectedFile == string.Empty)
                    {
                        selectedFile = SelectedItems[i].ToString();
                    }
                    else
                    {
                        selectedFile += "," + SelectedItems[i].ToString();
                    }
                }
            }
            var result = new { Files = filesNotFound, SelectedFile = selectedFile };
            //  var result = new { SelectedItem = strselectedItem, Screen = screen, Summary = summary };
            return JsonConvert.SerializeObject(result);
        }
        [WebMethod(EnableSession = true)]
        public static string downloadPatientDocuments(string sdocuments)
        {
            string jsonStringList = "";
            try
            {
                if (ClientSession.UserName == string.Empty)
                {
                    HttpContext.Current.Response.StatusCode = 999;
                    HttpContext.Current.Response.Status = "999 Session Expired";
                    HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                    return "";
                }
                for (int i = 0; i < sdocuments.Split('|').Count(); i++)
                {
                    string path = HostingEnvironment.ApplicationPhysicalPath + "Documents\\Physician_Specific_Documents\\Patient Education\\" + sdocuments.Split('|')[i];
                    System.IO.FileStream fs = null;
                    fs = System.IO.File.Open(path , System.IO.FileMode.Open);
                    byte[] btFile = new byte[fs.Length];
                    fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" + sdocuments.Split('|')[i]);
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.BinaryWrite(btFile);
                    //HttpContext.Current.Response.End();
                    fs = null;
                }
            }
            catch 
            {

            }
           
            return jsonStringList;
        }
    }
}