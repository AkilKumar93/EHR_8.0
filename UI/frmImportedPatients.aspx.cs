using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace Acurus.Capella.UI
{
    public partial class frmImportedPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         [System.Web.Services.WebMethod(EnableSession = true)]
        
        public static string LoadPatient()
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            IList<Human> lstHuman = new List<Human>();
            HumanManager objhuman = new HumanManager();
            string[] AppointmentStatus = { "WAITING FOR CALL" };
            lstHuman = objhuman.GetHumanbyAppointmentStatus(AppointmentStatus);
            HttpContext.Current.Session.Add("importedPatient", lstHuman);
          
            return JsonConvert.SerializeObject(lstHuman);
     
        
        }
         [System.Web.Services.WebMethod(EnableSession = true)]

         public static string LoadPatientshowall()
         {
             if (ClientSession.UserName == string.Empty)
             {
                 HttpContext.Current.Response.StatusCode = 999;
                 HttpContext.Current.Response.Status = "999 Session Expired";
                 HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                 return "Session Expired";
             }
             IList<Human> lstHuman = new List<Human>();
             IList<Human> lstHumantemp = new List<Human>();
             HumanManager objhuman = new HumanManager();

             lstHuman = objhuman.GetHumanbyAppointmentStatusshowall();
             if (HttpContext.Current.Session["importedPatient"] != null)
             {
                 lstHumantemp = (IList<Human>)(HttpContext.Current.Session["importedPatient"]);
                 lstHumantemp = (lstHumantemp.Union(lstHuman)).ToList<Human>();
                 HttpContext.Current.Session.Add("importedPatient", lstHumantemp);
             }
             else
             {
                 HttpContext.Current.Session.Add("importedPatient", lstHuman);
             }

             return JsonConvert.SerializeObject(lstHuman);


         }
         [System.Web.Services.WebMethod(EnableSession = true)]

         public static string GetEncounterId(string human_id)
         {
             if (ClientSession.UserName == string.Empty)
             {
                 HttpContext.Current.Response.StatusCode = 999;
                 HttpContext.Current.Response.Status = "999 Session Expired";
                 HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                 return "Session Expired";
             }
             EncounterManager obj = new EncounterManager();
             IList<Encounter> lstencounter = new List<Encounter>();
           lstencounter=  obj.GetrecentEncounterByhumanandProcess(Convert.ToUInt32(human_id), "DOCUMENTATION", "BILLING_COMPLETE");
           string encounterid = "0";
           if (lstencounter.Count > 0)
               encounterid = lstencounter[0].Id.ToString(); ;

           return encounterid;

         }
    
        [System.Web.Services.WebMethod(EnableSession = true)]
      
        public static string SaveAppointmentStatus(string HumanDetails)
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            IList<Human> lstinsert = new List<Human>();
             IList<Human> lstHuman = new List<Human>();
             HumanManager objhumanmanager = new HumanManager();
             if (HttpContext.Current.Session["importedPatient"] != null)
                 lstHuman =(IList<Human>)( HttpContext.Current.Session["importedPatient"]);
         
            string[] human=  HumanDetails.Split('|');
            
          for (int i = 0; i < human.Length; i++)
          {
              string FileName = "Human" + "_" + human[i].Split('~')[0] + ".xml";

              IList<Human>  lstupdate = (from m in lstHuman where m.Id == Convert.ToUInt32(human[i].Split('~')[0]) select m).ToList<Human>();
            
              if (lstupdate.Count > 0)
              {
                  lstupdate[0].Appointment_Status = human[i].Split('~')[1];
                  lstupdate[0].Modified_Date_And_Time = DateTime.Now;
              }

              objhumanmanager.SaveUpdateDelete_DBAndXML_WithTransaction(ref lstinsert, ref lstupdate, null, string.Empty, true, false, Convert.ToUInt32(human[i].Split('~')[0]), string.Empty);
         
          }
          string[] humantemp = (from m in human select m.Split('~')[0]).ToArray(); 
          for (int i = 0; i < lstHuman.Count; i++)
          {

              if (humantemp.Contains(lstHuman[i].Id.ToString()))
              {
                  lstHuman[i].Version = lstHuman[i].Version + 1;
              }
          }
          HttpContext.Current.Session.Add("importedPatient", lstHuman);
            return JsonConvert.SerializeObject(lstHuman);
        }
    }
}