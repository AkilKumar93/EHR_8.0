using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Acurus.Capella.Core.DTO;
using System.Xml;
using System.Xml.Serialization;

namespace Acurus.Capella.UI.WebServices
{
    /// <summary>
    /// Summary description for DrugAllergyService
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DrugAllergyService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string LoadDrugAllergies()
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            IList<Rcopia_Allergy> DrugAllergyList = new List<Rcopia_Allergy>();
            string FileName = "Human" + "_" + ClientSession.HumanId + ".xml";
            string strXmlFilePath = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["XMLPath"], FileName);
            if (File.Exists(strXmlFilePath) == true)
            {
                XmlDocument itemDoc = new XmlDocument();
                XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
                XmlNodeList xmlTagName = null;
                itemDoc.Load(XmlText);
                XmlText.Close();
                if (itemDoc.GetElementsByTagName("Rcopia_AllergyList")[0] != null && itemDoc.GetElementsByTagName("Rcopia_AllergyList").Count>0)
                {
                    xmlTagName = itemDoc.GetElementsByTagName("Rcopia_AllergyList")[0].ChildNodes;
                    if (xmlTagName != null && xmlTagName.Count > 0)
                    {
                            for (int j = 0; j < xmlTagName.Count; j++)
                            {
                                if (Convert.ToUInt64(xmlTagName[j].Attributes.GetNamedItem("Human_ID").Value) == ClientSession.HumanId && xmlTagName[j].Attributes.GetNamedItem("Deleted").Value.Equals("N"))
                                {
                                    string TagName = xmlTagName[j].Name;
                                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Rcopia_Allergy));
                                    Rcopia_Allergy DrugAllergy = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as Rcopia_Allergy;
                                    IEnumerable<PropertyInfo> propInfo = null;
                                    propInfo = from obji in ((Rcopia_Allergy)DrugAllergy).GetType().GetProperties() select obji;

                                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
                                    {
                                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
                                        {
                                            foreach (PropertyInfo property in propInfo)
                                            {
                                                if (propInfo != null)
                                                {
                                                    if (property.Name == nodevalue.Name)
                                                    {
                                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
                                                            property.SetValue(DrugAllergy, Convert.ToUInt64(nodevalue.Value), null);
                                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
                                                            property.SetValue(DrugAllergy, Convert.ToString(nodevalue.Value), null);
                                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
                                                            property.SetValue(DrugAllergy, Convert.ToDateTime(nodevalue.Value), null);
                                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
                                                            property.SetValue(DrugAllergy, Convert.ToInt32(nodevalue.Value), null);
                                                        else
                                                            property.SetValue(DrugAllergy, nodevalue.Value, null);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    DrugAllergyList.Add(DrugAllergy);
                                }
                        }
                    }
                }
            }
            HttpContext.Current.Session["DrugAllergyList"] = DrugAllergyList;
            var DrugAllergyLst = DrugAllergyList.Select(a => new
            {
                Drug_Allergy_Name = a.Allergy_Name,
                Reaction = a.Reaction,
                Notes = a.Notes,
                Id = a.Id,
                Status = a.Status
            });
            string UserCurrProcess = ClientSession.UserCurrentProcess;//BugID:44637
            //BugID:45456
            string[] strarray = new string[2];
            UtilityManager objmngr = new UtilityManager();
            FillPatientSummaryBarDTO fbpat = objmngr.FillPatientSummaryBar();
            var toolTipAllergy = string.Empty;
            string strAllergylist = objmngr.GetAllergyInfo(fbpat.NonDrugAllergyList, fbpat.AllergyList, out toolTipAllergy);
            strarray[0] = strAllergylist;
            strarray[1] = toolTipAllergy;

            var result = new
            {
                DrugAllergyList = DrugAllergyLst,
                CurrentProcess = UserCurrProcess,
                Tooltip = strarray
            };
            return JsonConvert.SerializeObject(result);
        }

        [WebMethod(EnableSession = true)]
        public string SaveDrugAllergies(string[] Drug_Data)
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            Rcopia_AllergyManager objDrugAllergyMngr = new Rcopia_AllergyManager();
            IList<Rcopia_Allergy> lst = objDrugAllergyMngr.GetMaxID();
            if (lst.Count > 0)
                Session["maxid"] = lst[0].Id;
            IList<Rcopia_Allergy> ilistDrugAllergyUpdate = new List<Rcopia_Allergy>();
            IList<Rcopia_Allergy> ilistDrugAllergySave = new List<Rcopia_Allergy>();
            IList<Rcopia_Allergy> ilistDrugAllergy = (IList<Rcopia_Allergy>)HttpContext.Current.Session["DrugAllergyList"];
            if (Drug_Data[0] != "" && Drug_Data[0] != "0")
            {
                if (ilistDrugAllergy != null && ilistDrugAllergy.Count > 0)
                {
                    ilistDrugAllergyUpdate = ilistDrugAllergy.Where(a => a.Id == Convert.ToUInt64(Drug_Data[0])).ToList<Rcopia_Allergy>();
                    if (ilistDrugAllergyUpdate != null && ilistDrugAllergyUpdate.Count > 0)
                    {
                        if (Drug_Data[1] != null)
                        ilistDrugAllergyUpdate[0].Allergy_Name = Drug_Data[1];
                        if (Drug_Data[2] != null)
                        ilistDrugAllergyUpdate[0].Status = Drug_Data[2];
                        if (Drug_Data[3] != null)
                        ilistDrugAllergyUpdate[0].Reaction = Drug_Data[3];
                        if (Drug_Data[4] != null)
                        ilistDrugAllergyUpdate[0].Notes = Drug_Data[4];
                        ilistDrugAllergyUpdate[0].Deleted = "N";
                        ilistDrugAllergyUpdate[0].Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                        ilistDrugAllergyUpdate[0].Modified_By = ClientSession.UserName;
                    }
                }
            }
            else
            {
                Rcopia_Allergy objDrugAllergy = new Rcopia_Allergy();
                objDrugAllergy.Id = Convert.ToUInt64(HttpContext.Current.Session["maxid"]) + 1;
                HttpContext.Current.Session["maxid"] = objDrugAllergy.Id;
                if (Drug_Data[1] != null)
                objDrugAllergy.Allergy_Name = Drug_Data[1];
                if (Drug_Data[2] != null)
                objDrugAllergy.Status = Drug_Data[2];
                if (Drug_Data[3] != null)
                objDrugAllergy.Reaction = Drug_Data[3];
                if (Drug_Data[4] != null)
                objDrugAllergy.Notes = Drug_Data[4];
                objDrugAllergy.Deleted = "N";
                objDrugAllergy.Human_ID = Convert.ToUInt32(ClientSession.HumanId);
                objDrugAllergy.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                objDrugAllergy.Created_By = ClientSession.UserName;
                ilistDrugAllergySave.Add(objDrugAllergy);
            }

            objDrugAllergyMngr.SaveUpdateDelete_DBAndXML_WithTransaction(ref ilistDrugAllergySave, ref ilistDrugAllergyUpdate, null, string.Empty, true, true, Convert.ToUInt32(ClientSession.HumanId), string.Empty);

            string sResult = LoadDrugAllergies();
            return sResult;
        }

        [WebMethod(EnableSession = true)]
        public string DeleteDrugAllergies(string DrugAllergyID)
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            if (DrugAllergyID != "" && DrugAllergyID != "0")
            {
                Rcopia_AllergyManager objDrugAllergyMngr = new Rcopia_AllergyManager();
                IList<Rcopia_Allergy> ilistDrugAllergySave = new List<Rcopia_Allergy>();
                IList<Rcopia_Allergy> InactiveAllergy = new List<Rcopia_Allergy>();
                IList<Rcopia_Allergy> ilistDrugAllergy = (IList<Rcopia_Allergy>)HttpContext.Current.Session["DrugAllergyList"];
                InactiveAllergy = ilistDrugAllergy.Where(a => a.Id == Convert.ToUInt64(DrugAllergyID)).ToList<Rcopia_Allergy>();
                InactiveAllergy[0].Status = "INACTIVE";
                InactiveAllergy[0].Deleted = "Y";
                InactiveAllergy[0].Modified_By = ClientSession.UserName;
                InactiveAllergy[0].Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                objDrugAllergyMngr.SaveUpdateDelete_DBAndXML_WithTransaction(ref ilistDrugAllergySave, ref InactiveAllergy, null, string.Empty, true, true, Convert.ToUInt32(ClientSession.HumanId), string.Empty);
            }
            string sResult = LoadDrugAllergies();
            return sResult;
        }
        [WebMethod(EnableSession = true)]
        public string LoadFrequencyDrugs()
        {
            if (ClientSession.UserName == string.Empty)
            {
                HttpContext.Current.Response.StatusCode = 999;
                HttpContext.Current.Response.Status = "999 Session Expired";
                HttpContext.Current.Response.StatusDescription = "frmSessionExpired.aspx";
                return "Session Expired";
            }
            IList<FieldLookup> FldLook = new List<FieldLookup>();
            UserLookupManager objUserLookupManager = new UserLookupManager();
            ulong PhysicianId = 0;
            PhysicianId = ClientSession.PhysicianId;
            FldLook = objUserLookupManager.GetFieldLookupList(PhysicianId, "Common Allergies", "Value").ToArray();
            string sResult = "";
            if (FldLook != null && FldLook.Count>0)
            {
                FldLook.Select(s => s.Value).ToList();
                sResult = new JavaScriptSerializer().Serialize(FldLook.Select(s => s.Value));
            }
            return sResult;
        }
    }
}
