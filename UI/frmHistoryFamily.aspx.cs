using System;
using System.Collections;
using System.Collections.Generic;
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
using AjaxControlToolkit.Design;
using AjaxControlToolkit;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using Telerik.Web.Design;
using Telerik.Web.UI;
using Acurus.Capella.UI.UserControls;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Drawing;


namespace Acurus.Capella.UI
{
    public partial class frmHistoryFamily : System.Web.UI.Page
    {
        #region Declaration

        Table objTable = new Table();
        TableCell tc = null;
        Label objLabel = null;
        CheckBox objCheckBox = null;
        CustomDLCNew objTextBox = null;

        FamilyHistoryManager objFamilyHistoryManager = new FamilyHistoryManager();
        FamilyDiseaseManager objFamilyDiseaseManager = new FamilyDiseaseManager();
        StaticLookupManager objStaticLookupManager = new StaticLookupManager();
        UserLookupManager objUserLookupManager = new UserLookupManager();
        IList<StaticLookup> stFieldLook = new List<StaticLookup>();

        IList<string> lst = null;
        Dictionary<ulong, string> dictionary = null;
        ulong EncounterId = 0;
        ulong HumanId = 0;
        ulong PhysicianId = 0;
        bool bHistoryFromPrevEnc = false;

        bool IsHisLoadFromMasterTbl = false;

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            if (UIManager.PFSH_OpeingFrom == "Menu")
            {
                if (Request["HumanID"] != null && Request["HumanID"].ToString().Trim() != string.Empty)
                    HumanId = Convert.ToUInt32(Request["HumanID"]);

                if (Request["PhysicianID"] != null && Request["PhysicianID"].ToString().Trim() != string.Empty)
                    PhysicianId = Convert.ToUInt32(Request["PhysicianID"]);
                pnlGeneralNotes.Visible = false;
                MenuPanel.Style.Add("display", "inline");
            }
            else
            {
                EncounterId = ClientSession.EncounterId;
                HumanId = ClientSession.HumanId;
                PhysicianId = ClientSession.PhysicianId;
                pnlGeneralNotes.Visible = true;
                ScreenPanel.Style.Add("display", "inline");
            }

            objTable.ID = "tblTest";
            dictionary = new Dictionary<ulong, string>();

            if (!IsPostBack)
            {
                Session["userLookup"] = null;
                ClientSession.FlushSession();
                if (ClientSession.UserRole.StartsWith("Physician"))
                    hdnUserRole.Value = ClientSession.UserRole;
                else
                    hdnUserRole.Value = "";

                string[] strarray = new string[3];
                strarray[0] = "RELATION";
                strarray[1] = "RELATION STATUS";
                // strarray[2] = "FAMILY DISEASE";
                FamilyDTO objFamilyLookupDTO = new FamilyDTO();
                objFamilyLookupDTO = objFamilyHistoryManager.GetAllLookUPDetails(strarray, "Sort_Order");
                // Session["userLookup"] = objFamilyLookupDTO.lstUserLookup.ToList();
                Session["stFieldLook"] = objFamilyLookupDTO.lStaticLookup.ToList();
                //Session["stFieldLook"] = objStaticLookupManager.getStaticLookupByFieldName(strarray, "Sort_Order"); //2016 
                //Session["stFieldLook"] = objStaticLookupManager.getStaticLookupByFieldName("RELATION", "Sort_Order");//comment by balaji.TJ
            }
            FamilyDTO objFamilyDTO = new FamilyDTO();

            #region "Code Modified by Balaji.TJ 2023-01-05"

            IList<string> ilstFamilyHisList = new List<string>();
            ilstFamilyHisList.Add("FamilyHistoryList");
            ilstFamilyHisList.Add("FamilyHistoryMasterList");
            ilstFamilyHisList.Add("FamilyDiseaseList");
            ilstFamilyHisList.Add("FamilyDiseaseMasterList"); 
            ilstFamilyHisList.Add("GeneralNotesFamilyHistoryList");

            IList<object> ilstFamilyHisBlobFinal = new List<object>();
            ilstFamilyHisBlobFinal = UtilityManager.ReadBlob(ClientSession.HumanId, ilstFamilyHisList);
            IList<FamilyHistory> lstFmlyHis = new List<FamilyHistory>();
            IList<FamilyHistoryMaster> lstFmlyHisMasterTemp = new List<FamilyHistoryMaster>();
            IList<FamilyHistoryMaster> lstFmlyHisMaster = new List<FamilyHistoryMaster>();
            IList<FamilyDisease> lstFmlyDisease = new List<FamilyDisease>();
            IList<FamilyDiseaseMaster> lstFmlyDiseaseMaster = new List<FamilyDiseaseMaster>();
            IList<GeneralNotes> lstGenNotes = new List<GeneralNotes>();


            if (ilstFamilyHisBlobFinal != null && ilstFamilyHisBlobFinal.Count > 0)
            {
                if (ilstFamilyHisBlobFinal[0] != null && ((IList<object>)ilstFamilyHisBlobFinal[0]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[0]).Count; i++)
                    {
                        lstFmlyHis.Add((FamilyHistory)((IList<object>)ilstFamilyHisBlobFinal[0])[i]);                      
                    }                   
                }
                if (lstFmlyHis != null && lstFmlyHis.Count > 0)
                {
                    IList<FamilyHistory> lstHisCurrEnc = new List<FamilyHistory>();
                    lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == ClientSession.EncounterId select item).ToList<FamilyHistory>();
                    if (lstHisCurrEnc != null && lstHisCurrEnc.Count > 0)
                    {
                        objFamilyDTO.Family_History = lstHisCurrEnc;
                        bHistoryFromPrevEnc = false;
                    }
                }
                if (ilstFamilyHisBlobFinal[1] != null && ((IList<object>)ilstFamilyHisBlobFinal[1]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[1]).Count; i++)
                    {
                        lstFmlyHisMasterTemp.Add((FamilyHistoryMaster)((IList<object>)ilstFamilyHisBlobFinal[1])[i]);
                    }
                    if (lstFmlyHisMasterTemp.Count > 0)
                    {
                        lstFmlyHisMaster = lstFmlyHisMasterTemp.Where(p => p.Is_Deleted == "N").ToList();
                        Session["FamilyHistoryMaster"] = lstFmlyHisMaster;
                        objFamilyDTO.Family_History_Master = lstFmlyHisMaster;
                    }
                }
                
                if (ilstFamilyHisBlobFinal[2] != null && ((IList<object>)ilstFamilyHisBlobFinal[2]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[2]).Count; i++)
                    {
                        lstFmlyDisease.Add((FamilyDisease)((IList<object>)ilstFamilyHisBlobFinal[2])[i]);
                    }                    
                }

                if (lstFmlyDisease != null && lstFmlyDisease.Count > 0)
                {
                    IList<FamilyDisease> lstDisCurrEnc = new List<FamilyDisease>();
                    for (int i = 0; i < objFamilyDTO.Family_History.Count; i++)
                    {
                        lstDisCurrEnc = lstDisCurrEnc.Concat((from item in lstFmlyDisease where item.Family_History_ID == objFamilyDTO.Family_History[i].Id select item).ToList<FamilyDisease>()).ToList<FamilyDisease>();
                    }
                    if (lstDisCurrEnc != null && lstDisCurrEnc.Count > 0)
                        objFamilyDTO.Family_Disease = lstDisCurrEnc;
                    else
                        objFamilyDTO.Family_Disease = new List<FamilyDisease>();
                }
                else
                {
                    objFamilyDTO.Family_Disease = lstFmlyDisease;
                }

                if (ilstFamilyHisBlobFinal[3] != null && ((IList<object>)ilstFamilyHisBlobFinal[3]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[3]).Count; i++)
                    {
                        lstFmlyDiseaseMaster.Add((FamilyDiseaseMaster)((IList<object>)ilstFamilyHisBlobFinal[3])[i]);
                    }
                    objFamilyDTO.Family_Disease_Master = lstFmlyDiseaseMaster;
                }
                if (ilstFamilyHisBlobFinal[4] != null && ((IList<object>)ilstFamilyHisBlobFinal[4]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[4]).Count; i++)
                    {
                        lstGenNotes.Add((GeneralNotes)((IList<object>)ilstFamilyHisBlobFinal[4])[i]);
                    }                    
                }
                if (lstGenNotes != null && lstGenNotes.Count > 0)
                {
                    IList<GeneralNotes> lstGenCurrEnc = new List<GeneralNotes>();
                    lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == ClientSession.EncounterId select item).ToList<GeneralNotes>();
                    if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
                    {
                        objFamilyDTO.objGeneralNotes = lstGenCurrEnc[0];
                    }
                    else
                    {
                        ulong maxEncId = 0;
                        IList<ulong> lstEncId = (from item in lstGenNotes select item.Encounter_ID).Distinct().ToList<ulong>();
                        if (lstEncId.Count > 0)
                            maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
                        foreach (ulong item in lstEncId.ToList())
                            if (item > maxEncId && item < ClientSession.EncounterId)
                                maxEncId = item;
                        lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == maxEncId select item).ToList<GeneralNotes>();
                        if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
                        {
                            objFamilyDTO.objGeneralNotes = lstGenCurrEnc[0];
                        }
                    }
                }                
            }
            Session["FamilyDTO"] = objFamilyDTO;

            #endregion


            #region "Code comment by Balaji.TJ 2023-01-05"
            ////string FileName = "Base_XML" + "_" + "Encounter" + "_" + ClientSession.EncounterId + ".xml";
            ///**/
            //string FileName = "Human" + "_" + ClientSession.HumanId + ".xml";
            //string strXmlFilePath = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["XMLPath"], FileName);

            //if (File.Exists(strXmlFilePath) == true)
            //{
            //    IList<FamilyHistory> lstFmlyHis = new List<FamilyHistory>();
            //    IList<FamilyDisease> lstFmlyDisease = new List<FamilyDisease>();
            //    IList<FamilyDiseaseMaster> lstFmlyDiseaseMaster = new List<FamilyDiseaseMaster>();
            //    IList<GeneralNotes> lstGenNotes = new List<GeneralNotes>();
            //    IList<FamilyHistoryMaster> lstFmlyHisMaster = new List<FamilyHistoryMaster>();
            //    IList<FamilyHistoryMaster> lstFmlyHisMasterTemp = new List<FamilyHistoryMaster>();
            //    XmlDocument itemDoc = new XmlDocument();
            //    XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
            //    XmlNodeList xmlTagName = null;
            //    //   itemDoc.Load(XmlText);
            //    using (FileStream fs = new FileStream(strXmlFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //    {
            //        itemDoc.Load(fs);

            //        XmlText.Close();


            //        if (itemDoc.GetElementsByTagName("FamilyHistoryList")[0] != null)
            //        {
            //            xmlTagName = itemDoc.GetElementsByTagName("FamilyHistoryList")[0].ChildNodes;

            //            if (xmlTagName.Count > 0)
            //            {
            //                for (int j = 0; j < xmlTagName.Count; j++)
            //                {
            //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyHistory));
            //                    FamilyHistory objHistory = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyHistory;

            //                    IEnumerable<PropertyInfo> propInfo = null;
            //                    propInfo = from obji in ((FamilyHistory)objHistory).GetType().GetProperties() select obji;

            //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                    {
            //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                        {
            //                            if (propInfo != null && propInfo.Count() > 0) //added by balaji 2015-11-18
            //                            {
            //                                foreach (PropertyInfo property in propInfo)
            //                                {
            //                                    if (property.Name == nodevalue.Name)
            //                                    {

            //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                            property.SetValue(objHistory, Convert.ToUInt64(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                            property.SetValue(objHistory, Convert.ToString(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                            property.SetValue(objHistory, Convert.ToDateTime(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                            property.SetValue(objHistory, Convert.ToInt32(nodevalue.Value), null);
            //                                        else
            //                                            property.SetValue(objHistory, nodevalue.Value, null);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }

            //                    lstFmlyHis.Add(objHistory);
            //                }
            //            }
            //        }
            //        //if (lstFmlyHis != null && lstFmlyHis.Count() == 0)
            //        //{
            //        if (itemDoc.GetElementsByTagName("FamilyHistoryMasterList")[0] != null)
            //        {
            //            xmlTagName = itemDoc.GetElementsByTagName("FamilyHistoryMasterList")[0].ChildNodes;

            //            if (xmlTagName.Count > 0)
            //            {
            //                for (int j = 0; j < xmlTagName.Count; j++)
            //                {
            //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyHistoryMaster));
            //                    FamilyHistoryMaster objHistory = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyHistoryMaster;

            //                    IEnumerable<PropertyInfo> propInfo = null;
            //                    propInfo = from obji in ((FamilyHistoryMaster)objHistory).GetType().GetProperties() select obji;

            //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                    {
            //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                        {
            //                            if (propInfo != null && propInfo.Count() > 0) //added by balaji 2015-11-18
            //                            {
            //                                foreach (PropertyInfo property in propInfo)
            //                                {
            //                                    if (property.Name == nodevalue.Name)
            //                                    {

            //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                            property.SetValue(objHistory, Convert.ToUInt64(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                            property.SetValue(objHistory, Convert.ToString(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                            property.SetValue(objHistory, Convert.ToDateTime(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                            property.SetValue(objHistory, Convert.ToInt32(nodevalue.Value), null);
            //                                        else
            //                                            property.SetValue(objHistory, nodevalue.Value, null);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }

            //                    lstFmlyHisMasterTemp.Add(objHistory);
            //                    if (lstFmlyHisMasterTemp.Count > 0)
            //                    {
            //                        lstFmlyHisMaster = lstFmlyHisMasterTemp.Where(p => p.Is_Deleted == "N").ToList();
            //                        Session["FamilyHistoryMaster"] = lstFmlyHisMaster;
            //                        objFamilyDTO.Family_History_Master = lstFmlyHisMaster;

            //                    }

            //                }
            //            }
            //        }
            //        // }
            //        if (lstFmlyHis != null && lstFmlyHis.Count > 0)
            //        {
            //            IList<FamilyHistory> lstHisCurrEnc = new List<FamilyHistory>();
            //            lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == ClientSession.EncounterId select item).ToList<FamilyHistory>();
            //            if (lstHisCurrEnc != null && lstHisCurrEnc.Count > 0)
            //            {
            //                objFamilyDTO.Family_History = lstHisCurrEnc;
            //                bHistoryFromPrevEnc = false;
            //            }
            //            //else
            //            //{
            //            //    //ulong maxEncId = 0;
            //            //    //IList<ulong> lstEncId = (from item in lstFmlyHis select item.Encounter_Id).Distinct().ToList<ulong>();
            //            //    //if(lstEncId.Count>0)
            //            //    //maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
            //            //    //foreach (ulong item in lstEncId.ToList())
            //            //    //    if (item > maxEncId && item < ClientSession.EncounterId)
            //            //    //        maxEncId = item;
            //            //    //lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == maxEncId select item).ToList<FamilyHistory>();

            //            //    if (lstFmlyHisMaster != null && lstFmlyHisMaster.Count() > 0)
            //            //    {
            //            //        foreach (FamilyHistoryMaster objMaster in lstFmlyHisMaster)
            //            //        {
            //            //            FamilyHistory objtempFH = new FamilyHistory();
            //            //            objtempFH.Human_ID = objMaster.Human_ID;
            //            //            objtempFH.RelationShip = objMaster.RelationShip;
            //            //            objtempFH.Age = objMaster.Age;
            //            //            objtempFH.Status = objMaster.Status;
            //            //            objtempFH.Cause_Of_Death = objMaster.Cause_Of_Death;
            //            //            objtempFH.Created_By = ClientSession.UserName;
            //            //            objtempFH.Created_Date_And_Time = UtilityManager.ConvertToUniversal(); ;
            //            //            objtempFH.Encounter_Id = ClientSession.EncounterId;
            //            //            lstHisCurrEnc.Add(objtempFH);
            //            //        }
            //            //        objFamilyDTO.Family_History = lstHisCurrEnc;

            //            //    }
            //            //    bHistoryFromPrevEnc = true;
            //            //}
            //        }
            //        //else
            //        //{
            //        //    if (lstFmlyHisMaster != null && lstFmlyHisMaster.Count() > 0)
            //        //    {
            //        //        List<FamilyHistory> lstHisCurrEnc = new List<FamilyHistory>();
            //        //        foreach (FamilyHistoryMaster objMaster in lstFmlyHisMaster)
            //        //        {
            //        //            FamilyHistory objtempFH = new FamilyHistory();
            //        //            objtempFH.Human_ID = objMaster.Human_ID;
            //        //            objtempFH.RelationShip = objMaster.RelationShip;
            //        //            objtempFH.Age = objMaster.Age;
            //        //            objtempFH.Status = objMaster.Status;
            //        //            objtempFH.Cause_Of_Death = objMaster.Cause_Of_Death;
            //        //            objtempFH.Created_By = ClientSession.UserName;
            //        //            objtempFH.Created_Date_And_Time = UtilityManager.ConvertToUniversal(); ;
            //        //            objtempFH.Encounter_Id = ClientSession.EncounterId;
            //        //            lstHisCurrEnc.Add(objtempFH);
            //        //        }
            //        //        objFamilyDTO.Family_History = lstHisCurrEnc;

            //        //    }
            //        //    else
            //        //        objFamilyDTO.Family_History = lstFmlyHis;
            //        //}

            //        #region Commmented
            //        //else
            //        //{

            //        // Session["FamilyDTO"] = objFamilyHistoryManager.GetFamilyHistory(ClientSession.HumanId, ClientSession.EncounterId);

            //        //}
            //        //
            //        #endregion
            //        if (itemDoc.GetElementsByTagName("FamilyDiseaseList")[0] != null)
            //        {
            //            xmlTagName = itemDoc.GetElementsByTagName("FamilyDiseaseList")[0].ChildNodes;

            //            if (xmlTagName.Count > 0)
            //            {
            //                for (int j = 0; j < xmlTagName.Count; j++)
            //                {
            //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyDisease));
            //                    FamilyDisease objDisease = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyDisease;
            //                    IEnumerable<PropertyInfo> propInfo = null;

            //                    propInfo = from obji in ((FamilyDisease)objDisease).GetType().GetProperties() select obji;

            //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                    {
            //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                        {
            //                            if (propInfo != null && propInfo.Count() > 0)
            //                            {
            //                                foreach (PropertyInfo property in propInfo)
            //                                {
            //                                    if (property.Name == nodevalue.Name)
            //                                    {
            //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                            property.SetValue(objDisease, Convert.ToUInt64(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                            property.SetValue(objDisease, Convert.ToString(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                            property.SetValue(objDisease, Convert.ToDateTime(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                            property.SetValue(objDisease, Convert.ToInt32(nodevalue.Value), null);
            //                                        else
            //                                            property.SetValue(objDisease, nodevalue.Value, null);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                    lstFmlyDisease.Add(objDisease);
            //                }
            //            }
            //        }

            //        if (lstFmlyDisease != null && lstFmlyDisease.Count > 0)
            //        {
            //            IList<FamilyDisease> lstDisCurrEnc = new List<FamilyDisease>();
            //            for (int i = 0; i < objFamilyDTO.Family_History.Count; i++)
            //            {
            //                lstDisCurrEnc = lstDisCurrEnc.Concat((from item in lstFmlyDisease where item.Family_History_ID == objFamilyDTO.Family_History[i].Id select item).ToList<FamilyDisease>()).ToList<FamilyDisease>();
            //            }
            //            if (lstDisCurrEnc != null && lstDisCurrEnc.Count > 0)
            //                objFamilyDTO.Family_Disease = lstDisCurrEnc;
            //            else
            //                objFamilyDTO.Family_Disease = new List<FamilyDisease>();
            //        }
            //        else
            //        {
            //            objFamilyDTO.Family_Disease = lstFmlyDisease;
            //        }

            //        //if (lstFmlyDisease != null && lstFmlyDisease.Count == 0)
            //        //{
            //            //Disease Master
            //            if (itemDoc.GetElementsByTagName("FamilyDiseaseMasterList")[0] != null)
            //            {
            //                xmlTagName = itemDoc.GetElementsByTagName("FamilyDiseaseMasterList")[0].ChildNodes;

            //                if (xmlTagName.Count > 0)
            //                {
            //                    for (int j = 0; j < xmlTagName.Count; j++)
            //                    {
            //                        XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyDiseaseMaster));
            //                        FamilyDiseaseMaster objDisease = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyDiseaseMaster;
            //                        IEnumerable<PropertyInfo> propInfo = null;

            //                        propInfo = from obji in ((FamilyDiseaseMaster)objDisease).GetType().GetProperties() select obji;

            //                        for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                        {
            //                            XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                            {
            //                                if (propInfo != null && propInfo.Count() > 0)
            //                                {
            //                                    foreach (PropertyInfo property in propInfo)
            //                                    {
            //                                        if (property.Name == nodevalue.Name)
            //                                        {
            //                                            if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                                property.SetValue(objDisease, Convert.ToUInt64(nodevalue.Value), null);
            //                                            else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                                property.SetValue(objDisease, Convert.ToString(nodevalue.Value), null);
            //                                            else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                                property.SetValue(objDisease, Convert.ToDateTime(nodevalue.Value), null);
            //                                            else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                                property.SetValue(objDisease, Convert.ToInt32(nodevalue.Value), null);
            //                                            else
            //                                                property.SetValue(objDisease, nodevalue.Value, null);
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        lstFmlyDiseaseMaster.Add(objDisease);
            //                        objFamilyDTO.Family_Disease_Master = lstFmlyDiseaseMaster;
            //                    }
            //                }
            //            }
            //            //if (lstFmlyDiseaseMaster != null && lstFmlyDiseaseMaster.Count > 0)
            //            //{
            //            //    IList<FamilyDisease> lstDisCurrEnc = new List<FamilyDisease>();
            //            //    IList<FamilyDiseaseMaster> lstDisCurrEncMas = new List<FamilyDiseaseMaster>();
            //            //    //for (int i = 0; i < objFamilyDTO.Family_History.Count; i++)
            //            //    //{
            //            //    //    lstDisCurrEncMas = lstDisCurrEncMas.Concat((from item in lstFmlyDiseaseMaster where item.Family_History_ID == objFamilyDTO.Family_History[i].Id select item).ToList<FamilyDiseaseMaster>()).ToList<FamilyDiseaseMaster>();
            //            //    //}
            //            //    for (int i = 0; i < objFamilyDTO.Family_History_Master.Count; i++)
            //            //    {
            //            //        lstDisCurrEncMas = lstDisCurrEncMas.Concat((from item in lstFmlyDiseaseMaster where item.Family_History_Master_ID == objFamilyDTO.Family_History_Master[i].Id select item).ToList<FamilyDiseaseMaster>()).ToList<FamilyDiseaseMaster>();
            //            //    }
            //            //    if (lstDisCurrEncMas != null && lstDisCurrEncMas.Count > 0)
            //            //    {
            //            //        foreach (FamilyDiseaseMaster objMaster in lstDisCurrEncMas)
            //            //        {
            //            //            FamilyDisease objtempFH = new FamilyDisease();
            //            //            objtempFH.Human_ID = objMaster.Human_ID;
            //            //            objtempFH.Disease = objMaster.Disease;
            //            //            objtempFH.Created_By = ClientSession.UserName;
            //            //            objtempFH.Created_Date_And_Time = UtilityManager.ConvertToUniversal(); ;
            //            //            lstDisCurrEnc.Add(objtempFH);
            //            //        }
            //            //        objFamilyDTO.Family_Disease = lstDisCurrEnc;
            //            //    }
            //            //    else
            //            //        objFamilyDTO.Family_Disease = new List<FamilyDisease>();
            //            //}
            //            //else
            //            //{
            //            //    objFamilyDTO.Family_Disease = lstFmlyDisease;
            //            //}
            //        //}
            //        //
            //        if (itemDoc.GetElementsByTagName("GeneralNotesFamilyHistoryList")[0] != null)
            //        {
            //            xmlTagName = itemDoc.GetElementsByTagName("GeneralNotesFamilyHistoryList")[0].ChildNodes;

            //            if (xmlTagName.Count > 0)
            //            {

            //                for (int j = 0; j < xmlTagName.Count; j++)
            //                {
            //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(GeneralNotes));
            //                    GeneralNotes generalnotes = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as GeneralNotes;
            //                    IEnumerable<PropertyInfo> propInfo = null;

            //                    propInfo = from obji in ((GeneralNotes)generalnotes).GetType().GetProperties() select obji;

            //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                    {
            //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                        {
            //                            if (propInfo != null && propInfo.Count() > 0)
            //                            {
            //                                foreach (PropertyInfo property in propInfo)
            //                                {
            //                                    if (property.Name == nodevalue.Name)
            //                                    {
            //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                            property.SetValue(generalnotes, Convert.ToUInt64(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                            property.SetValue(generalnotes, Convert.ToString(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                            property.SetValue(generalnotes, Convert.ToDateTime(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                            property.SetValue(generalnotes, Convert.ToInt32(nodevalue.Value), null);
            //                                        else
            //                                            property.SetValue(generalnotes, nodevalue.Value, null);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                    lstGenNotes.Add(generalnotes);
            //                }
            //            }
            //        }
            //        fs.Close();
            //        fs.Dispose();
            //    }
            //    if (lstGenNotes != null && lstGenNotes.Count > 0)
            //    {
            //        IList<GeneralNotes> lstGenCurrEnc = new List<GeneralNotes>();
            //        lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == ClientSession.EncounterId select item).ToList<GeneralNotes>();
            //        if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
            //        {
            //            objFamilyDTO.objGeneralNotes = lstGenCurrEnc[0];
            //        }
            //        else
            //        {
            //            ulong maxEncId = 0;
            //            IList<ulong> lstEncId = (from item in lstGenNotes select item.Encounter_ID).Distinct().ToList<ulong>();
            //            if (lstEncId.Count > 0)
            //                maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
            //            foreach (ulong item in lstEncId.ToList())
            //                if (item > maxEncId && item < ClientSession.EncounterId)
            //                    maxEncId = item;
            //            lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == maxEncId select item).ToList<GeneralNotes>();
            //            if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
            //            {
            //                objFamilyDTO.objGeneralNotes = lstGenCurrEnc[0];
            //            }
            //        }
            //    }

            //    Session["FamilyDTO"] = objFamilyDTO;
            //}

            #endregion

            //


            // Session["FamilyDTO"] = objFamilyHistoryManager.GetFamilyHistory(ClientSession.HumanId, ClientSession.EncounterId);

            btnSave.Enabled = false;
            DLC.txtDLC.Attributes.Add("onkeypress", "CCTextChanged();");
            DLC.txtDLC.Attributes.Add("onChange", "CCTextChanged()");
            DLC.txtDLC.Attributes.Add("onkeyup", "CCTextChanged();");
            if (!IsPostBack)
            {
                //Added by srividhya on 3-Jul-2014
                if (UIManager.is_Menu_Level_PFSH)//(UIManager.PFSH_OpeingFrom == "Menu")
                {
                    this.Page.Items.Add("Title", "frmHistoryFamilyMenu");
                }
                ClientSession.processCheck = true;
                SecurityServiceUtility objSecurity = new SecurityServiceUtility();
                objSecurity.ApplyUserPermissions(this.Page);

                //if (UIManager.PFSH_OpeingFrom != "Menu")
                //{
                //    SecurityServiceUtility objSecurity = new SecurityServiceUtility();
                //    objSecurity.ApplyUserPermissions(this.Page);
                //}
            }
            Createcontrols();

            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "EndWaitCursor", "EndWaitCursor();", true);
        }

        void Createcontrols()
        {
            FamilyDTO FamDto = new FamilyDTO();
            if (Session["FamilyDTO"] != null)// = familyDTO;
                FamDto = (FamilyDTO)Session["FamilyDTO"];

            if (Session["stFieldLook"] != null)
                stFieldLook = (IList<StaticLookup>)Session["stFieldLook"];
            stFieldLook = stFieldLook.Where(a => a.Field_Name == "RELATION").ToList(); //added by balaji.TJ 2015-11-20
            dictionary = new Dictionary<ulong, string>();
            if (stFieldLook != null && stFieldLook.Count > 0) //added by balaji.TJ 2015-11-18
                for (int i = 0; i < stFieldLook.Count; i++)
                {
                    if (UIManager.PFSH_OpeingFrom == "Menu")
                    {
                        //Get Data from History Master
                        if (FamDto != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Any(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()))
                        {
                            IsHisLoadFromMasterTbl = true;
                            FamilyHistoryMaster objResult = FamDto.Family_History_Master.Where(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()).ToList()[0];
                            dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                            var ResultFamily = FamDto.Family_History_Master.Where(a => a.RelationShip.ToUpper() == stFieldLook[i].Value.ToUpper()).ToList<FamilyHistoryMaster>();
                            IList<FamilyDiseaseMaster> ResultDisease = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == ResultFamily[0].Id).ToList();
                            string Disease = string.Empty;

                            for (int j = 0; j < ResultDisease.Count; j++)
                            {
                                if (Disease.Trim() == string.Empty)
                                    Disease = ResultDisease[j].Disease;
                                else
                                    Disease += "," + ResultDisease[j].Disease;
                            }
                            TableAndControlCreation(stFieldLook[i].Value, ResultFamily[0].Age, Disease, ResultFamily[0].Status, ResultFamily[0].Cause_Of_Death, true, objResult.Id.ToString());
                        }
                        else
                        {
                            IsHisLoadFromMasterTbl = true;
                            dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                            TableAndControlCreation(stFieldLook[i].Value, 0, string.Empty, string.Empty, string.Empty, false, "0");
                        }

                    }
                    else
                    {
                        //My queue
                        if (FamDto != null && FamDto.Family_History.Count > 0)
                        {
                            IList<FamilyHistory> objCheckCurEnc = FamDto.Family_History.Where(a => a.Encounter_Id == ClientSession.EncounterId).ToList();
                            if (objCheckCurEnc.Count() > 0)
                            {
                                IsHisLoadFromMasterTbl = false;
                                if (FamDto != null && FamDto.Family_History.Count > 0 && FamDto.Family_History.Any(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()))
                                {
                                    FamilyHistory objResult = FamDto.Family_History.Where(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()).ToList()[0];
                                    dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                                    var ResultFamily = FamDto.Family_History.Where(a => a.RelationShip.ToUpper() == stFieldLook[i].Value.ToUpper()).ToList<FamilyHistory>();
                                    IList<FamilyDisease> ResultDisease = FamDto.Family_Disease.Where(a => a.Family_History_ID == ResultFamily[0].Id).ToList();
                                    string Disease = string.Empty;

                                    for (int j = 0; j < ResultDisease.Count; j++)
                                    {
                                        if (Disease.Trim() == string.Empty)
                                            Disease = ResultDisease[j].Disease;
                                        else
                                            Disease += "," + ResultDisease[j].Disease;
                                    }
                                    TableAndControlCreation(stFieldLook[i].Value, ResultFamily[0].Age, Disease, ResultFamily[0].Status, ResultFamily[0].Cause_Of_Death, true, objResult.Id.ToString());
                                }
                                else
                                {
                                    dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                                    TableAndControlCreation(stFieldLook[i].Value, 0, string.Empty, string.Empty, string.Empty, false, "0");
                                }
                            }
                            else
                            {
                                //Get Data from History Master
                                if (FamDto != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Any(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()))
                                {
                                    IsHisLoadFromMasterTbl = true;
                                    FamilyHistoryMaster objResult = FamDto.Family_History_Master.Where(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()).ToList()[0];
                                    dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                                    var ResultFamily = FamDto.Family_History_Master.Where(a => a.RelationShip.ToUpper() == stFieldLook[i].Value.ToUpper()).ToList<FamilyHistoryMaster>();
                                    IList<FamilyDiseaseMaster> ResultDisease = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == ResultFamily[0].Id).ToList();
                                    string Disease = string.Empty;

                                    for (int j = 0; j < ResultDisease.Count; j++)
                                    {
                                        if (Disease.Trim() == string.Empty)
                                            Disease = ResultDisease[j].Disease;
                                        else
                                            Disease += "," + ResultDisease[j].Disease;
                                    }
                                    TableAndControlCreation(stFieldLook[i].Value, ResultFamily[0].Age, Disease, ResultFamily[0].Status, ResultFamily[0].Cause_Of_Death, true, objResult.Id.ToString());
                                }
                                else
                                {
                                    dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                                    TableAndControlCreation(stFieldLook[i].Value, 0, string.Empty, string.Empty, string.Empty, false, "0");
                                }

                            }
                        }
                        else
                        {
                            //Get Data from History Master
                            if (FamDto != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Any(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()))
                            {
                                IsHisLoadFromMasterTbl = true;
                                FamilyHistoryMaster objResult = FamDto.Family_History_Master.Where(a => a.RelationShip.ToUpper().Trim() == stFieldLook[i].Value.ToUpper().Trim()).ToList()[0];
                                dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                                var ResultFamily = FamDto.Family_History_Master.Where(a => a.RelationShip.ToUpper() == stFieldLook[i].Value.ToUpper()).ToList<FamilyHistoryMaster>();
                                IList<FamilyDiseaseMaster> ResultDisease = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == ResultFamily[0].Id).ToList();
                                string Disease = string.Empty;

                                for (int j = 0; j < ResultDisease.Count; j++)
                                {
                                    if (Disease.Trim() == string.Empty)
                                        Disease = ResultDisease[j].Disease;
                                    else
                                        Disease += "," + ResultDisease[j].Disease;
                                }
                                TableAndControlCreation(stFieldLook[i].Value, ResultFamily[0].Age, Disease, ResultFamily[0].Status, ResultFamily[0].Cause_Of_Death, true, objResult.Id.ToString());
                            }
                            else
                            {
                                dictionary.Add(Convert.ToUInt16(i), stFieldLook[i].Value);
                                TableAndControlCreation(stFieldLook[i].Value, 0, string.Empty, string.Empty, string.Empty, false, "0");
                            }

                        }

                    }
                }

            if (!IsPostBack && FamDto != null && FamDto.objGeneralNotes != null)
                DLC.txtDLC.Text = FamDto.objGeneralNotes.Notes;
        }



        void TableAndControlCreation(string value, int Age, string FamilyDisease, string StatusValue, string CoughtOfDeathValue, bool Checked, string ID)
        {
            TableRow tr = new TableRow();

            objLabel = new Label();
            objLabel.EnableViewState = false;
            tc = new TableCell();
            objLabel.ID = "lbl" + value;
            objLabel.Text = value;
            objLabel.CssClass = "Editabletxtbox";
            // objLabel.Font.Size = new FontUnit("8.5pt");
            objLabel.Font.Bold = false;
            objLabel.Width = 130;
            tc.Controls.Add(objLabel);
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Width = 15;
            tr.Cells.Add(tc);

            tc = new TableCell();
            objCheckBox = new CheckBox();
            objCheckBox.EnableViewState = false;
            objCheckBox.Width = new Unit("41px");
            objCheckBox.ID = "chk" + value.Replace(" ", "");
            objCheckBox.Attributes.Add("onclick", "enableField('" + objCheckBox.ID + "');");
            tc.Controls.Add(objCheckBox);
            tr.Cells.Add(tc);

            if (Checked)
                objCheckBox.Checked = true;
            else
                objCheckBox.Checked = false;

            tc = new TableCell();
            tc.Width = 56;
            tr.Cells.Add(tc);

            tc = new TableCell();
            RadNumericTextBox objRadNumericTextBox = new RadNumericTextBox();
            objRadNumericTextBox.EnableViewState = false;
            objRadNumericTextBox.Width = new Unit("40px");
            objRadNumericTextBox.ID = "txtAge" + value.Replace(" ", "");
            objRadNumericTextBox.AutoPostBack = false;
            objRadNumericTextBox.MaxLength = 3;
            objRadNumericTextBox.NumberFormat.GroupSeparator = "";
            // Added for Bug id=28876
            objRadNumericTextBox.MinValue = 0;
            objRadNumericTextBox.NumberFormat.DecimalDigits = 0;
            objRadNumericTextBox.NumberFormat.AllowRounding = true;
            objRadNumericTextBox.NumberFormat.KeepNotRoundedValue = false;
            objRadNumericTextBox.Attributes.Add("onPaste", "return false");
            objRadNumericTextBox.Attributes.Add("onCopy", "return false");
            //objRadNumericTextBox.Attributes.Add("onkeypress", "EnableSave('" + objRadNumericTextBox.ID + "');");
            // Added for Bug id=28876
            objRadNumericTextBox.Attributes.Add("onClick", "EnableSave('" + objRadNumericTextBox.ID + "');");
            objRadNumericTextBox.ClientEvents.OnKeyPress = "RadNumericTextBoxkeypress";
            objRadNumericTextBox.ClientEvents.OnBlur = "KeyPressing";
            objRadNumericTextBox.DisabledStyle.BackColor = ColorTranslator.FromHtml("#EBEBE4");
            objRadNumericTextBox.BorderColor = ColorTranslator.FromHtml("#A9A9A9");
            tc.Controls.Add(objRadNumericTextBox);
            tr.Cells.Add(tc);

            if (Checked)
                objRadNumericTextBox.Text = Age == 0 ? string.Empty : Age.ToString();
            else
                objRadNumericTextBox.Text = string.Empty;

            tc = new TableCell();
            tc.Width = 20;
            tr.Cells.Add(tc);

            tc = new TableCell();
            Panel objPanel = new Panel();
            objPanel.Style.Add(HtmlTextWriterStyle.Width, "100%");
            objPanel.Style.Add(HtmlTextWriterStyle.Height, "100%");
            objPanel.Style.Add(HtmlTextWriterStyle.FontSize, "Small");
            tc.Controls.Add(objPanel);
            CustomDLCNew userCtrl = (CustomDLCNew)LoadControl("~/UserControls/customDLCNew.ascx");
            userCtrl.ID = "DLCFamilyDisease" + value.Replace(" ", "");
            userCtrl.TextboxHeight = new Unit("40px");
            userCtrl.TextboxWidth = new Unit("210px");
            userCtrl.txtDLC.Text = FamilyDisease;
            userCtrl.Value = "FAMILY DISEASE";
            //string ValuesItem = "FAMILY DISEASE";
            userCtrl.txtDLC.Attributes.Add("onkeypress", "EnableSave('" + userCtrl.ID + "');");
            userCtrl.txtDLC.Attributes.Add("onchange", "EnableSave('" + userCtrl.ID + "');");
            userCtrl.txtDLC.Attributes.Add("onChange", "CCTextChanged()");
            userCtrl.txtDLC.Attributes.Add("onkeyup", "CCTextChanged()");

            //userCtrl.pbDropdown.Attributes.Add("onclick", "return pbDropDownss('" + userCtrl.pbDropdown.ClientID + "','" + userCtrl.listDLC.ClientID + "','" + ValuesItem + "');");
            //userCtrl.pbLibrary.Attributes.Add("onclick", "return OpenAddorUpdates('" + ValuesItem + "','" + userCtrl.pbLibrary.ClientID + "');");
            //userCtrl.pbClear.Attributes.Add("onclick", "return pbClearAlls('" +userCtrl.pbClear.ClientID.Replace("_pbClear", "_txtDLC") + "');");
            userCtrl.ListboxHeight = (Unit)85;
            objPanel.Controls.Add(userCtrl);
            tr.Cells.Add(tc);
            //userCtrl.SetTheUBACorPBACForHistoryControls(this.Page);

            tc = new TableCell();
            tc.Width = 20;
            tr.Cells.Add(tc);

            tc = new TableCell();
            RadComboBox objCombobox = new RadComboBox();
            objCombobox.Width = new Unit("100px");
            objCombobox.ID = "cbo" + value.Replace(" ", "");
            objCombobox.DataSource = LoadStatus();
            objCombobox.DataBind();
            if (StatusValue.Trim() != string.Empty)
                objCombobox.SelectedIndex = objCombobox.FindItemIndexByText(StatusValue.Trim());
            else
                objCombobox.SelectedIndex = 0;
            objCombobox.Attributes.Add("onChange", "selectedChanged('" + value + "');");
            tc.Controls.Add(objCombobox);
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Width = 20;
            tr.Cells.Add(tc);

            tc = new TableCell();
            Panel objPanelCOD = new Panel();
            objPanelCOD.Style.Add(HtmlTextWriterStyle.Width, "100%");
            objPanelCOD.Style.Add(HtmlTextWriterStyle.Height, "100%");
            objPanelCOD.Style.Add(HtmlTextWriterStyle.FontSize, "Small");
            tc.Controls.Add(objPanelCOD);
            CustomDLCNew userCtrls = (CustomDLCNew)LoadControl("~/UserControls/customDLCNew.ascx");
            userCtrls.ID = "DLCCauseOfDeath" + value.Replace(" ", "");
            userCtrls.TextboxHeight = new Unit("40px");
            userCtrls.TextboxWidth = new Unit("215px");
            userCtrls.txtDLC.Text = CoughtOfDeathValue;
            userCtrls.Value = "CAUSE OF DEATH";
            userCtrls.txtDLC.Attributes.Add("onkeypress", "KeyPressing('" + userCtrls.ID + "');");
            userCtrls.txtDLC.Attributes.Add("onkeypress", "EnableSave('" + userCtrls.ID + "');");
            userCtrls.txtDLC.Attributes.Add("onchange", "EnableSave('" + userCtrls.ID + "');");
            userCtrls.txtDLC.Attributes.Add("onChange", "CCTextChanged()");
            userCtrls.txtDLC.Attributes.Add("onkeyup", "CCTextChanged()");
            //userCtrls.pbDropdown.Attributes.Add("onclick", "return pbDropDown('" + userCtrls.pbDropdown.ClientID + "','" + userCtrls.listDLC.ClientID + "','" + value + "');");
            //pbDropdown.Attributes.Add("onclick", "return pbDropDown('" +userCtrls.pbDropdown.ClientID + "','" + userCtrls.listDLC.ClientID + "','" + value + "');");
            //userCtrls.pbDropdown.Attributes.Add("onclick", "return pbDropDownss('" + userCtrls.pbDropdown.ClientID + "','" + userCtrls.listDLC.ClientID + "','" + userCtrls.Value + "');");
            //userCtrls.pbLibrary.Attributes.Add("onclick", "return OpenAddorUpdates('" + userCtrls.Value + "','" + userCtrls.pbLibrary.ClientID + "');");
            //userCtrls.pbClear.Attributes.Add("onclick", "return pbClearAlls('" + userCtrls.pbClear.ClientID.Replace("_pbClear", "_txtDLC") + "');");
            userCtrls.pbDropdown.Attributes.Add("onclick", "return pbDropDown('" + userCtrls.ID + "_pbDropdown','" + userCtrls.ID + "_listDLC','CAUSE OF DEATH','')");
            objPanelCOD.Controls.Add(userCtrls);
            tr.Cells.Add(tc);
            //userCtrls.SetTheUBACorPBACForHistoryControls(this.Page);

            if (StatusValue.Trim().ToUpper() == "DECEASED")
                userCtrls.Enable = true;
            else
                userCtrls.Enable = false;

            objLabel = new Label();
            objLabel.EnableViewState = false;
            tc = new TableCell();
            objLabel.ID = "lblID" + value;
            objLabel.Text = ID;
            objLabel.Visible = false;
            objLabel.Font.Size = new FontUnit("8.5pt");
            objLabel.Font.Bold = false;
            objLabel.Width = 10;
            tc.Controls.Add(objLabel);
            tr.Cells.Add(tc);

            // comment by balaji 2016-02-01 37669
            //TableRow tr1 = new TableRow();
            //objLabel = new Label();
            //objLabel.EnableViewState = false;
            //tc = new TableCell();
            //objLabel.Text = "______________________________________________________________________________________________________________";
            //tc.ColumnSpan = 5;
            //tc.Controls.Add(objLabel);
            //tr1.Cells.Add(tc);

            objTable.Rows.Add(tr);

            divFamilyHistory.Controls.Add(objTable);

            string chkRelationship = Request.Form["chk" + value.Replace(" ", "")];
            string cboRelationship = Request.Form["cbo" + value.Replace(" ", "")];

            if (ID == "0")
            {
                if (chkRelationship != null && chkRelationship == "on")
                {
                    userCtrl.Enable = true;
                    if (ClientSession.UserRole.StartsWith("Physician"))
                    {
                        //   userCtrl.pbLibrary.Style.Add("background-color", "#6DABF7");
                        objRadNumericTextBox.Enabled = true;
                        //objRadNumericTextBox.Style.Add("background-color", "#FFFFFF");
                    }
                    objCombobox.Enabled = true;
                    if (cboRelationship != null && cboRelationship == "Deceased")
                    {
                        userCtrls.Enable = true;
                    }
                }
                else
                {
                    userCtrl.Enable = true;
                    userCtrls.Enable = true;
                    objRadNumericTextBox.Enabled = false;
                    //objRadNumericTextBox.Style.Add("background-color", "#EBEBE4");
                    objRadNumericTextBox.Text = string.Empty;
                    objCombobox.Enabled = false;
                }
            }
            else
            {
                if (chkRelationship != null && chkRelationship == "on")
                {
                    objRadNumericTextBox.Enabled = true;
                    //objRadNumericTextBox.Style.Add("background-color", "#EBEBE4");
                    userCtrl.Enable = true;
                    if (ClientSession.UserRole.StartsWith("Physician"))
                        //  userCtrl.pbLibrary.Style.Add("background-color", "#6DABF7");
                        objCombobox.Enabled = true;

                    if (StatusValue == "Deceased")
                    {
                        userCtrls.Enable = true;
                        //if (ClientSession.UserRole.StartsWith("Physician"))
                        //  userCtrls.pbLibrary.Style.Add("background-color", "#6DABF7");
                    }
                    else
                        userCtrls.Enable = false;

                    if (cboRelationship != null && cboRelationship == "Deceased")
                    {
                        userCtrls.Enable = true;
                        //if (ClientSession.UserRole.StartsWith("Physician"))
                        //  userCtrls.pbLibrary.Style.Add("background-color", "#6DABF7");
                    }
                    else if (cboRelationship != null && cboRelationship != "Deceased")
                        userCtrls.Enable = false;

                    //userCtrl.pbLibrary.Style.Add("background-color", "CSS/style.csscol-6-btn margintop5px");#6DABF7
                    //userCtrl.pbLibrary.Style.Add("background-color", "col-6-btn margintop5px");
                    //userCtrl.pbLibrary.Style.Add("background-color", "#6DABF7");

                }
                else if (Checked)
                {
                    //userCtrl.pbLibrary.Style.Add("background-color", "col-6-btn margintop5px");
                    //userCtrl.pbLibrary.Style.Add("background-color", "#6DABF7");
                    if (!IsPostBack)
                    {
                        if (StatusValue == "Deceased")
                        {
                            userCtrls.Enable = true;

                        }
                        else
                            userCtrls.Enable = false;

                        if (cboRelationship != null && cboRelationship == "Deceased")
                        {
                            userCtrls.Enable = true;

                        }
                        else if (cboRelationship != null && cboRelationship != "Deceased")
                            userCtrls.Enable = false;
                    }
                    else
                    {
                        userCtrl.Enable = false;
                        userCtrls.Enable = false;
                        objRadNumericTextBox.Enabled = false;
                        // objRadNumericTextBox.Style.Add("background-color", "#EBEBE4");
                    }
                }
            }

            if (ClientSession.UserRole.Trim() == "Coder" || ClientSession.UserPermission == "R" || ClientSession.UserCurrentProcess == "CHECK_OUT" || ClientSession.UserCurrentProcess == "CHECK_OUT_WAIT" || (ClientSession.UserCurrentProcess.Trim() == string.Empty && ClientSession.UserCurrentOwner.Trim() == string.Empty))
            {
                objRadNumericTextBox.Enabled = false;
                // objRadNumericTextBox.Style.Add("background-color", "#EBEBE4");
                objCombobox.Enabled = false;
                objCheckBox.Enabled = false;
                userCtrl.Enable = false;
                userCtrls.Enable = false;
            }
        }


        public void UserControlEnableOrDisable(CustomDLCNew userCtrl, string value)
        {
            string chkRelationship = Request.Form["chk" + value.Replace(" ", "")];
            string cboRelationship = Request.Form["cbo" + value.Replace(" ", "")];
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<UserLookup> userLookup = new List<UserLookup>();
            string strtime = hdnLocalTime.Value.ToString().Split('G').ElementAt(0).ToString();
            DateTime utc = Convert.ToDateTime(strtime);

            if (DuplicateGeneralNotes())
            {
                //divLoading.Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "top.window.document.getElementById('ctl00_Loading').style.display = 'none';", true);
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "SaveSuccessfully", "PFSH_SaveUnsuccessful(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}DisplayErrorMessage('180307');", true);
                return;
            }

            FamilyHistory objFamilyHistory = null;
            FamilyDisease objFamilyDisease = null;

            FamilyHistoryMaster objFamilyHistoryMaster = null;
            FamilyDiseaseMaster objFamilyDiseaseMaster = null;

            IList<FamilyDTO> lstSave = new List<FamilyDTO>();
            FamilyDTO objSave = new FamilyDTO();

            IList<FamilyHistory> lstFamilyHistorySave = new List<FamilyHistory>();
            IList<FamilyHistory> lstFamilyHistoryUpdate = new List<FamilyHistory>();
            IList<FamilyHistory> lstFamilyHistoryDelete = new List<FamilyHistory>();

            IList<FamilyDisease> lstFamilyDiseaseSave = new List<FamilyDisease>();
            //   IList<FamilyDisease> lstFamilyDiseaseUpdate = new List<FamilyDisease>();
            IList<FamilyDisease> lstFamilyDiseaseDelete = new List<FamilyDisease>();

            IList<FamilyHistoryMaster> lstFamilyHistorySaveMaster = new List<FamilyHistoryMaster>();
            IList<FamilyHistoryMaster> lstFamilyHistoryUpdateMaster = new List<FamilyHistoryMaster>();
            IList<FamilyHistoryMaster> lstFamilyHistoryDeleteMaster = new List<FamilyHistoryMaster>();

            IList<FamilyDiseaseMaster> lstFamilyDiseaseSaveMaster = new List<FamilyDiseaseMaster>();
            // IList<FamilyDiseaseMaster> lstFamilyDiseaseUpdateMaster = new List<FamilyDiseaseMaster>();
            IList<FamilyDiseaseMaster> lstFamilyDiseaseDeleteMaster = new List<FamilyDiseaseMaster>();


            FamilyDTO FamDto = new FamilyDTO();
            if (Session["FamilyDTO"] != null)
            {
                FamDto = ((FamilyDTO)Session["FamilyDTO"]);
            }

            //if (Session["userLookup"] == null)
            //{
            //    userLookup = objUserLookupManager.GetFieldLookupList(PhysicianId, "FAMILY DISEASE");
            //    Session["userLookup"] = userLookup.ToList();               
            //}           
            //else if (Session["userLookup"] != null)
            //    userLookup = (List<UserLookup>)Session["userLookup"];           

            foreach (KeyValuePair<ulong, string> item in dictionary.ToArray())
            {

                objFamilyHistory = new FamilyHistory();
                objFamilyHistoryMaster = new FamilyHistoryMaster();
                CheckBox objChkBox = ((CheckBox)divFamilyHistory.FindControl("chk" + item.Value.Replace(" ", "")));
                RadNumericTextBox objRadTextBox = (RadNumericTextBox)divFamilyHistory.FindControl("txtAge" + item.Value.Replace(" ", ""));
                RadComboBox objRadComboBox = (RadComboBox)divFamilyHistory.FindControl("cbo" + item.Value.Replace(" ", ""));
                CustomDLCNew objCustomDLCCauseOfDeath = ((CustomDLCNew)divFamilyHistory.FindControl("DLCCauseOfDeath" + item.Value.Replace(" ", "")));
                CustomDLCNew objDLCFamilyDisease = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", "")));
                Label objlbl = ((Label)divFamilyHistory.FindControl("lblID" + item.Value));
                string[] Original = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Replace(", ", ",").Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (objlbl.Text.Trim() != "0")
                {
                    if (FamDto != null && FamDto.Family_History != null)
                    {
                        checked
                        {
                            if (objChkBox != null && objChkBox.Checked)
                            {
                                if (!IsHisLoadFromMasterTbl)
                                {
                                    objFamilyHistory.Id = Convert.ToUInt32(objlbl.Text.Trim());
                                    objFamilyHistory.Human_ID = ClientSession.HumanId;
                                    objFamilyHistory.RelationShip = item.Value;
                                    objFamilyHistory.Age = objRadTextBox.Text.Trim() != string.Empty ? Convert.ToInt32(objRadTextBox.Text) : 0;
                                    objFamilyHistory.Status = objRadComboBox.SelectedItem.Text;
                                    objFamilyHistory.Cause_Of_Death = objCustomDLCCauseOfDeath.txtDLC.Text;
                                    objFamilyHistory.Created_By = FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text.Trim())).ToList<FamilyHistory>()[0].Created_By;
                                    objFamilyHistory.Created_Date_And_Time = FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text.Trim())).ToList<FamilyHistory>()[0].Created_Date_And_Time;
                                    objFamilyHistory.Version = FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistory>()[0].Version;

                                    if (FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistory>()[0].Encounter_Id == ClientSession.EncounterId)
                                    {
                                        objFamilyHistory.Encounter_Id = ClientSession.EncounterId;
                                        objFamilyHistory.Modified_By = ClientSession.UserName;
                                        objFamilyHistory.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                                        lstFamilyHistoryUpdate.Add(objFamilyHistory);
                                    }
                                    else
                                    {
                                        objFamilyHistory.Id = 0;
                                        objFamilyHistory.Version = 0;
                                        objFamilyHistory.Encounter_Id = ClientSession.EncounterId;
                                        lstFamilyHistorySave.Add(objFamilyHistory);
                                    }
                                }
                                else
                                {
                                    //Set Master table 
                                    objFamilyHistoryMaster.Id = Convert.ToUInt32(objlbl.Text.Trim());
                                    objFamilyHistoryMaster.Human_ID = ClientSession.HumanId;
                                    objFamilyHistoryMaster.RelationShip = item.Value;
                                    objFamilyHistoryMaster.Age = objRadTextBox.Text.Trim() != string.Empty ? Convert.ToInt32(objRadTextBox.Text) : 0;
                                    objFamilyHistoryMaster.Status = objRadComboBox.SelectedItem.Text;
                                    objFamilyHistoryMaster.Cause_Of_Death = objCustomDLCCauseOfDeath.txtDLC.Text;
                                    objFamilyHistoryMaster.Created_By = FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text.Trim())).ToList<FamilyHistoryMaster>()[0].Created_By;
                                    objFamilyHistoryMaster.Created_Date_And_Time = FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text.Trim())).ToList<FamilyHistoryMaster>()[0].Created_Date_And_Time;
                                    objFamilyHistoryMaster.Version = FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistoryMaster>()[0].Version;

                                    if (FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistoryMaster>().Count() > 0)
                                    {
                                        objFamilyHistoryMaster.Modified_By = ClientSession.UserName;
                                        objFamilyHistoryMaster.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                                        lstFamilyHistoryUpdateMaster.Add(objFamilyHistoryMaster);
                                    }
                                    else
                                    {
                                        objFamilyHistoryMaster.Id = 0;
                                        objFamilyHistoryMaster.Version = 0;
                                        lstFamilyHistorySaveMaster.Add(objFamilyHistoryMaster);
                                    }

                                }
                            }
                        }


                        if (objChkBox != null && objChkBox.Checked && objDLCFamilyDisease != null && objDLCFamilyDisease.txtDLC.Text.Trim() != string.Empty)
                        {
                            if (Session["userLookup"] == null)
                            {
                                userLookup = objUserLookupManager.GetFieldLookupList(PhysicianId, "FAMILY DISEASE");
                                Session["userLookup"] = userLookup.ToList();
                            }
                            else if (Session["userLookup"] != null)
                                userLookup = (List<UserLookup>)Session["userLookup"];
                            if (!IsHisLoadFromMasterTbl)
                            {
                                if (objDLCFamilyDisease.txtDLC.Text.Contains(","))
                                {
                                    //string[] Values1 = objDLCFamilyDisease.txtDLC.Text.Trim().Split(',').Select(a => a.TrimStart()).ToArray();
                                    //string[] Values2 = new string[] { };
                                    //if (!bHistoryFromPrevEnc)
                                    //    Values2 = FamDto.Family_Disease.Where(a => a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).Select<FamilyDisease, string>(a => a.Disease.Trim()).ToArray<string>();
                                    //**********************************************
                                    string[] Values1 = objDLCFamilyDisease.txtDLC.Text.Replace(" ", "").Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                                    for (int m = 0; m < Values1.Count(); m++)
                                    {
                                        Values1[m] = Convert.ToString(Original.Where(O => O.Replace(" ", "").Trim() == Values1[m]).Select(O => O.ToString()).FirstOrDefault());
                                    }
                                    //string[] Values1 = objDLCFamilyDisease.txtDLC.Text.Replace(" ","").Trim().Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                                    string[] Values2 = new string[] { };
                                    if (!bHistoryFromPrevEnc)
                                        Values2 = FamDto.Family_Disease.Where(a => a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).Select<FamilyDisease, string>(a => a.Disease.Trim()).ToArray<string>();//.ToList<FamilyDisease>();
                                    //*********************************************
                                    //var SaveResult = Values1.Except(Values2);
                                    // var SaveResult = (from b in Values1 where !Values2.Any(a => a == b) select b).Distinct().ToList(); //2016 balaji
                                    var SaveResult = (from b in Values1 where !Values2.Any(a => a == b) select b).ToList();
                                    var UpdateResult = Values2;
                                    //if (UpdateResult != null && UpdateResult.Count() > 0) //added  by balaji.TJ 2015-11-18
                                    //    foreach (var items in UpdateResult.ToList())
                                    //    {
                                    //        objFamilyDisease = new FamilyDisease();
                                    //        //added by balaji.TJ 2015-11-18

                                    //        IList<FamilyDisease> famliyDiseaseList = FamDto.Family_Disease.OrderBy(a => a.Family_History_ID).ToList<FamilyDisease>();
                                    //        //var newList = new NHibernate.Mapping.List(famliyDiseaseList);
                                    //        objFamilyDisease = famliyDiseaseList.Where(a => a.Disease.Trim() == items && a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>()[0];

                                    //        //Commented by Srividhya 
                                    //        //objFamilyDisease.Family_History_ID = Convert.ToUInt32(objlbl.Text.Trim());
                                    //        objFamilyDisease.Disease = items;
                                    //        objFamilyDisease.Internal_Property_Relation = item.Value;
                                    //        objFamilyDisease.Human_ID = ClientSession.HumanId;
                                    //        if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == items.Trim().ToString()))
                                    //            objFamilyDisease.Recodes = userLookup.Where(a => a.Value == items.Trim()).ToList<UserLookup>()[0].Description;
                                    //        //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //        //if (hdnLocalTime.Value != string.Empty)
                                    //        // objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                    //        objFamilyDisease.Modified_By = ClientSession.UserName;
                                    //        objFamilyDisease.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //        lstFamilyDiseaseUpdate.Add(objFamilyDisease);
                                    //    }
                                    if (SaveResult != null && SaveResult.Count() > 0) //added  by balaji.TJ 2015-11-18
                                        foreach (var items in SaveResult.ToList())
                                        {
                                            objFamilyDisease = new FamilyDisease();
                                            objFamilyDisease.Disease = items;
                                            objFamilyDisease.Internal_Property_Relation = item.Value;
                                            objFamilyDisease.Created_By = ClientSession.UserName;
                                            objFamilyDisease.Human_ID = ClientSession.HumanId;
                                            if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == items.Trim().ToString()))
                                                objFamilyDisease.Recodes = userLookup.Where(a => a.Value == items.Trim()).ToList<UserLookup>()[0].Description;
                                            //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                            //if (hdnLocalTime.Value != string.Empty)
                                            // objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                            objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                            lstFamilyDiseaseSave.Add(objFamilyDisease);
                                        }
                                    var DeleteResult = (from b in Values2 where !Values1.Any(a => a == b) select b).ToList();
                                    //var DeleteResult = Values2.Except(Values1);
                                    if (DeleteResult != null && DeleteResult.Count() > 0)
                                    {
                                        //code  added by balaji.TJ 2015-11-18
                                        if (FamDto.Family_History != null && FamDto.Family_History.Count > 0 && FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistory>()[0].Encounter_Id == ClientSession.EncounterId)
                                        {
                                            foreach (var items in DeleteResult.ToList())
                                            {
                                                IList<FamilyDisease> DeleteList = FamDto.Family_Disease.Where(a => a.Disease.Trim() == items.Trim() && a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>();
                                                if (DeleteList != null && DeleteList.Count > 0)
                                                    lstFamilyDiseaseDelete.Add(DeleteList[0]);
                                            }
                                        }
                                    }
                                    //if (lstFamilyDiseaseUpdate != null && lstFamilyDiseaseUpdate.Count > 0 && lstFamilyDiseaseDelete != null && lstFamilyDiseaseDelete.Count > 0)
                                    //{
                                    //    lstFamilyDiseaseUpdate = lstFamilyDiseaseUpdate.Except(lstFamilyDiseaseDelete).ToList<FamilyDisease>();
                                    //}
                                }
                                else
                                {
                                    // string DiseaseValue = grdFamilyHistory.Rows[i].Cells[8].Value.ToString();
                                    string[] Values2 = new string[] { };
                                    if (!bHistoryFromPrevEnc)
                                        Values2 = FamDto.Family_Disease.Where(a => a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).Select(a => a.Disease.Trim()).ToArray<string>();//.ToList<FamilyDisease>();
                                    var Result = Values2.Any(a => a.ToString().Trim() == objDLCFamilyDisease.txtDLC.Text.Trim());

                                    if (!Result)
                                    {
                                        objFamilyDisease = new FamilyDisease();
                                        objFamilyDisease.Disease = objDLCFamilyDisease.txtDLC.Text;
                                        objFamilyDisease.Human_ID = ClientSession.HumanId;
                                        objFamilyDisease.Internal_Property_Relation = item.Value;//((RadTextBox)grdFamilyHistory.Items[i].FindControl("txtRelation")).Text;
                                        objFamilyDisease.Created_By = ClientSession.UserName;

                                        if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == objFamilyDisease.Disease.Trim().ToString()))
                                            objFamilyDisease.Recodes = userLookup.Where(a => a.Value == objFamilyDisease.Disease.Trim()).ToList<UserLookup>()[0].Description;
                                        //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();

                                        //if (hdnLocalTime.Value != string.Empty)
                                        //objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                        objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                        lstFamilyDiseaseSave.Add(objFamilyDisease);
                                    }
                                    //else
                                    //{
                                    //    objFamilyDisease = new FamilyDisease();
                                    //    //added by balaji.TJ 2015-11-18
                                    //    if (FamDto.Family_Disease.Where(a => a.Disease.Trim() == objDLCFamilyDisease.txtDLC.Text && a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>().Count > 0)
                                    //        objFamilyDisease = FamDto.Family_Disease.Where(a => a.Disease.Trim() == objDLCFamilyDisease.txtDLC.Text && a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>()[0];
                                    //    //commented by Srividhya
                                    //    //if (objlbl.Text != string.Empty) //added by balaji.TJ 2015-11-18
                                    //    //    objFamilyDisease.Family_History_ID = Convert.ToUInt32(objlbl.Text.Trim());
                                    //    objFamilyDisease.Disease = objDLCFamilyDisease.txtDLC.Text;
                                    //    objFamilyDisease.Human_ID = ClientSession.HumanId;
                                    //    objFamilyDisease.Internal_Property_Relation = item.Value;//((RadTextBox)grdFamilyHistory.Items[i].FindControl("txtRelation")).Text;
                                    //    objFamilyDisease.Modified_By = ClientSession.UserName;

                                    //    if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == objFamilyDisease.Disease.Trim().ToString()))
                                    //        objFamilyDisease.Recodes = userLookup.Where(a => a.Value == objFamilyDisease.Disease.Trim()).ToList<UserLookup>()[0].Description;
                                    //    //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();

                                    //    //if (hdnLocalTime.Value != string.Empty)
                                    //    //objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                    //    objFamilyDisease.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //    lstFamilyDiseaseUpdate.Add(objFamilyDisease);
                                    //}



                                    if (FamDto.Family_Disease != null && FamDto.Family_Disease.Count > 0)
                                    {
                                        IList<FamilyDisease> Values = FamDto.Family_Disease.Where(a => a.Disease.Trim() != objDLCFamilyDisease.txtDLC.Text.Trim() && a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>();
                                        if (Values != null && Values.Count > 0)
                                        {
                                            //added by balaji.TJ 2015-11-18
                                            if (FamDto.Family_History != null && FamDto.Family_History.Count > 0 && FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistory>()[0].Encounter_Id == ClientSession.EncounterId)
                                            {
                                                foreach (var items in Values.ToList())
                                                    lstFamilyDiseaseDelete.Add(items);
                                            }
                                        }
                                    }
                                    //if (lstFamilyDiseaseUpdate != null && lstFamilyDiseaseUpdate.Count > 0 && lstFamilyDiseaseDelete != null && lstFamilyDiseaseDelete.Count > 0)
                                    //{
                                    //    lstFamilyDiseaseUpdate = lstFamilyDiseaseUpdate.Except(lstFamilyDiseaseDelete).ToList<FamilyDisease>();
                                    //}
                                }
                            }
                            else
                            {
                                //for master table
                                if (objDLCFamilyDisease.txtDLC.Text.Contains(","))
                                {
                                    //string[] Values1 = objDLCFamilyDisease.txtDLC.Text.Trim().Split(',').Select(a => a.TrimStart()).ToArray();
                                    //string[] Values2 = new string[] { };
                                    //if (!bHistoryFromPrevEnc)
                                    //    Values2 = FamDto.Family_Disease.Where(a => a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).Select<FamilyDisease, string>(a => a.Disease.Trim()).ToArray<string>();
                                    //**********************************************
                                    string[] Values1 = objDLCFamilyDisease.txtDLC.Text.Replace(" ", "").Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                                    for (int m = 0; m < Values1.Count(); m++)
                                    {
                                        Values1[m] = Convert.ToString(Original.Where(O => O.Replace(" ", "").Trim() == Values1[m]).Select(O => O.ToString()).FirstOrDefault());
                                    }
                                    //string[] Values1 = objDLCFamilyDisease.txtDLC.Text.Replace(" ","").Trim().Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                                    string[] Values2 = new string[] { };
                                    if (!bHistoryFromPrevEnc)
                                        Values2 = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).Select<FamilyDiseaseMaster, string>(a => a.Disease.Trim()).ToArray<string>();//.ToList<FamilyDisease>();
                                    //*********************************************
                                    //var SaveResult = Values1.Except(Values2);
                                    // var SaveResult = (from b in Values1 where !Values2.Any(a => a == b) select b).Distinct().ToList(); //2016 balaji
                                    var SaveResult = (from b in Values1 where !Values2.Any(a => a == b) select b).ToList();
                                    var UpdateResult = Values2;
                                    //if (UpdateResult != null && UpdateResult.Count() > 0) //added  by balaji.TJ 2015-11-18
                                    //    foreach (var items in UpdateResult.ToList())
                                    //    {
                                    //        objFamilyDiseaseMaster = new FamilyDiseaseMaster();
                                    //        //added by balaji.TJ 2015-11-18

                                    //        IList<FamilyDiseaseMaster> famliyDiseaseList = FamDto.Family_Disease_Master.OrderBy(a => a.Family_History_Master_ID).ToList<FamilyDiseaseMaster>();
                                    //        //var newList = new NHibernate.Mapping.List(famliyDiseaseList);
                                    //        objFamilyDiseaseMaster = famliyDiseaseList.Where(a => a.Disease.Trim() == items && a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>()[0];

                                    //        //Commented by Srividhya 
                                    //        //objFamilyDisease.Family_History_ID = Convert.ToUInt32(objlbl.Text.Trim());
                                    //        objFamilyDiseaseMaster.Disease = items;
                                    //        objFamilyDiseaseMaster.Internal_Property_Relation = item.Value;
                                    //        objFamilyDiseaseMaster.Human_ID = ClientSession.HumanId;
                                    //        if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == items.Trim().ToString()))
                                    //            objFamilyDiseaseMaster.Recodes = userLookup.Where(a => a.Value == items.Trim()).ToList<UserLookup>()[0].Description;
                                    //        //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //        //if (hdnLocalTime.Value != string.Empty)
                                    //        // objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                    //        objFamilyDiseaseMaster.Modified_By = ClientSession.UserName;
                                    //        objFamilyDiseaseMaster.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //        lstFamilyDiseaseUpdateMaster.Add(objFamilyDiseaseMaster);
                                    //    }
                                    if (SaveResult != null && SaveResult.Count() > 0) //added  by balaji.TJ 2015-11-18
                                        foreach (var items in SaveResult.ToList())
                                        {
                                            objFamilyDiseaseMaster = new FamilyDiseaseMaster();
                                            objFamilyDiseaseMaster.Disease = items;
                                            objFamilyDiseaseMaster.Internal_Property_Relation = item.Value;
                                            objFamilyDiseaseMaster.Created_By = ClientSession.UserName;
                                            objFamilyDiseaseMaster.Human_ID = ClientSession.HumanId;
                                            if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == items.Trim().ToString()))
                                                objFamilyDiseaseMaster.Recodes = userLookup.Where(a => a.Value == items.Trim()).ToList<UserLookup>()[0].Description;
                                            //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                            //if (hdnLocalTime.Value != string.Empty)
                                            // objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                            objFamilyDiseaseMaster.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                            lstFamilyDiseaseSaveMaster.Add(objFamilyDiseaseMaster);
                                        }
                                    var DeleteResult = (from b in Values2 where !Values1.Any(a => a == b) select b).ToList();
                                    //var DeleteResult = Values2.Except(Values1);
                                    if (DeleteResult != null && DeleteResult.Count() > 0)
                                    {
                                        //code  added by balaji.TJ 2015-11-18
                                        if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistoryMaster>().Count() > 0)
                                        {
                                            foreach (var items in DeleteResult.ToList())
                                            {
                                                IList<FamilyDiseaseMaster> DeleteList = FamDto.Family_Disease_Master.Where(a => a.Disease.Trim() == items.Trim() && a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>();
                                                if (DeleteList != null && DeleteList.Count > 0)
                                                    lstFamilyDiseaseDeleteMaster.Add(DeleteList[0]);
                                            }
                                        }
                                    }
                                    //if (lstFamilyDiseaseUpdateMaster != null && lstFamilyDiseaseUpdateMaster.Count > 0 && lstFamilyDiseaseDeleteMaster != null && lstFamilyDiseaseDeleteMaster.Count > 0)
                                    //{
                                    //    lstFamilyDiseaseUpdateMaster = lstFamilyDiseaseUpdateMaster.Except(lstFamilyDiseaseDeleteMaster).ToList<FamilyDiseaseMaster>();
                                    //}
                                }
                                else
                                {
                                    // string DiseaseValue = grdFamilyHistory.Rows[i].Cells[8].Value.ToString();
                                    string[] Values2 = new string[] { };
                                    if (!bHistoryFromPrevEnc)
                                        Values2 = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).Select(a => a.Disease.Trim()).ToArray<string>();//.ToList<FamilyDisease>();
                                    var Result = Values2.Any(a => a.ToString().Trim() == objDLCFamilyDisease.txtDLC.Text.Trim());

                                    if (!Result)
                                    {
                                        objFamilyDiseaseMaster = new FamilyDiseaseMaster();
                                        objFamilyDiseaseMaster.Disease = objDLCFamilyDisease.txtDLC.Text;
                                        objFamilyDiseaseMaster.Human_ID = ClientSession.HumanId;
                                        objFamilyDiseaseMaster.Internal_Property_Relation = item.Value;//((RadTextBox)grdFamilyHistory.Items[i].FindControl("txtRelation")).Text;
                                        objFamilyDiseaseMaster.Created_By = ClientSession.UserName;

                                        if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == objFamilyDiseaseMaster.Disease.Trim().ToString()))
                                            objFamilyDiseaseMaster.Recodes = userLookup.Where(a => a.Value == objFamilyDiseaseMaster.Disease.Trim()).ToList<UserLookup>()[0].Description;
                                        //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();

                                        //if (hdnLocalTime.Value != string.Empty)
                                        //objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                        objFamilyDiseaseMaster.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                        lstFamilyDiseaseSaveMaster.Add(objFamilyDiseaseMaster);
                                    }
                                    //else
                                    //{
                                    //    objFamilyDiseaseMaster = new FamilyDiseaseMaster();
                                    //    //added by balaji.TJ 2015-11-18
                                    //    if (FamDto.Family_Disease_Master.Where(a => a.Disease.Trim() == objDLCFamilyDisease.txtDLC.Text && a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>().Count > 0)
                                    //        objFamilyDiseaseMaster = FamDto.Family_Disease_Master.Where(a => a.Disease.Trim() == objDLCFamilyDisease.txtDLC.Text && a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>()[0];
                                    //    //commented by Srividhya
                                    //    //if (objlbl.Text != string.Empty) //added by balaji.TJ 2015-11-18
                                    //    //    objFamilyDisease.Family_History_ID = Convert.ToUInt32(objlbl.Text.Trim());
                                    //    objFamilyDiseaseMaster.Disease = objDLCFamilyDisease.txtDLC.Text;
                                    //    objFamilyDiseaseMaster.Human_ID = ClientSession.HumanId;
                                    //    objFamilyDiseaseMaster.Internal_Property_Relation = item.Value;//((RadTextBox)grdFamilyHistory.Items[i].FindControl("txtRelation")).Text;
                                    //    objFamilyDiseaseMaster.Modified_By = ClientSession.UserName;

                                    //    if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == objFamilyDiseaseMaster.Disease.Trim().ToString()))
                                    //        objFamilyDiseaseMaster.Recodes = userLookup.Where(a => a.Value == objFamilyDiseaseMaster.Disease.Trim()).ToList<UserLookup>()[0].Description;
                                    //    //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();

                                    //    //if (hdnLocalTime.Value != string.Empty)
                                    //    //objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                    //    objFamilyDiseaseMaster.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //    lstFamilyDiseaseUpdateMaster.Add(objFamilyDiseaseMaster);
                                    //}



                                    if (FamDto.Family_Disease_Master != null && FamDto.Family_Disease_Master.Count > 0)
                                    {
                                        IList<FamilyDiseaseMaster> Values = FamDto.Family_Disease_Master.Where(a => a.Disease.Trim() != objDLCFamilyDisease.txtDLC.Text.Trim() && a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>();
                                        if (Values != null && Values.Count > 0)
                                        {
                                            //added by balaji.TJ 2015-11-18
                                            if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistoryMaster>().Count() > 0)
                                            {
                                                foreach (var items in Values.ToList())
                                                    lstFamilyDiseaseDeleteMaster.Add(items);
                                            }
                                        }
                                    }
                                    //if (lstFamilyDiseaseUpdateMaster != null && lstFamilyDiseaseUpdateMaster.Count > 0 && lstFamilyDiseaseDeleteMaster != null && lstFamilyDiseaseDeleteMaster.Count > 0)
                                    //{
                                    //    lstFamilyDiseaseUpdateMaster = lstFamilyDiseaseUpdateMaster.Except(lstFamilyDiseaseDeleteMaster).ToList<FamilyDiseaseMaster>();
                                    //}
                                }
                            }
                        }
                        //added by balaji.TJ 2015-11-18
                        else if (objChkBox != null && objChkBox.Checked && objDLCFamilyDisease != null && objDLCFamilyDisease.txtDLC.Text.Trim() == string.Empty)// && FamDto.Family_Disease != null && FamDto.Family_Disease.Count > 0)
                        {
                            //added by balaji.TJ 2015-11-18
                            if (!IsHisLoadFromMasterTbl)
                            {
                                if (FamDto.Family_Disease != null && FamDto.Family_Disease.Count > 0)
                                {
                                    IList<FamilyDisease> Values = FamDto.Family_Disease.Where(a => a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>();
                                    if (Values != null && Values.Count > 0 && FamDto.Family_History != null && FamDto.Family_History.Count > 0)
                                    {
                                        if (FamDto.Family_History != null && FamDto.Family_History.Count > 0 && FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistory>()[0].Encounter_Id == ClientSession.EncounterId)
                                        {
                                            foreach (var items in Values.ToList())
                                                lstFamilyDiseaseDelete.Add(items);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //For Master Table

                                if (FamDto.Family_Disease_Master != null && FamDto.Family_Disease_Master.Count > 0)
                                {
                                    IList<FamilyDiseaseMaster> Values = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>();
                                    if (Values != null && Values.Count > 0 && FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0)
                                    {
                                        if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistoryMaster>().Count() > 0)//[0].Encounter_Id == ClientSession.EncounterId)
                                        {
                                            foreach (var items in Values.ToList())
                                                lstFamilyDiseaseDeleteMaster.Add(items);
                                        }
                                    }
                                }

                            }
                        }

                        if (objChkBox != null && !objChkBox.Checked)//&& FamDto.Family_History != null && FamDto.Family_History.Count > 0)//Delete
                        {
                            if (!IsHisLoadFromMasterTbl)
                            {
                                if (FamDto.Family_History != null && FamDto.Family_History.Count > 0)
                                {
                                    if (objlbl.Text.Trim() != string.Empty)
                                    {
                                        FamilyHistory lstResult = FamDto.Family_History.Where(a => a.Id == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyHistory>()[0];
                                        if (FamDto.Family_History.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistory>()[0].Encounter_Id == ClientSession.EncounterId)
                                        {
                                            lstFamilyHistoryDelete.Add(lstResult);
                                            if (FamDto.Family_Disease != null && FamDto.Family_Disease.Count > 0)  //added by balaji.TJ 2015-11-18
                                            {
                                                IList<FamilyDisease> ResultDisease = FamDto.Family_Disease.Where(a => a.Family_History_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDisease>();
                                                for (int k = 0; k < ResultDisease.Count; k++)
                                                    lstFamilyDiseaseDelete.Add(ResultDisease[k]);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0)
                                {
                                    if (objlbl.Text.Trim() != string.Empty)
                                    {
                                        FamilyHistoryMaster lstResult = FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyHistoryMaster>()[0];
                                        if (FamDto.Family_History_Master.Where(a => a.Id == Convert.ToUInt64(objlbl.Text)).ToList<FamilyHistoryMaster>().Count() > 0)//[0].Encounter_Id == ClientSession.EncounterId)
                                        {
                                            lstFamilyHistoryDeleteMaster.Add(lstResult);
                                            if (FamDto.Family_Disease_Master != null && FamDto.Family_Disease_Master.Count > 0)  //added by balaji.TJ 2015-11-18
                                            {
                                                IList<FamilyDiseaseMaster> ResultDisease = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == Convert.ToUInt32(objlbl.Text.Trim())).ToList<FamilyDiseaseMaster>();
                                                for (int k = 0; k < ResultDisease.Count; k++)
                                                    lstFamilyDiseaseDeleteMaster.Add(ResultDisease[k]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Save
                    if (objChkBox != null && objChkBox.Checked)
                    {
                        if (!IsHisLoadFromMasterTbl)
                        {

                            objFamilyHistory.Human_ID = ClientSession.HumanId;
                            objFamilyHistory.RelationShip = item.Value;
                            objFamilyHistory.Age = objRadTextBox.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(objRadTextBox.Text);
                            objFamilyHistory.Status = objRadComboBox.SelectedItem.Text;
                            objFamilyHistory.Cause_Of_Death = objCustomDLCCauseOfDeath.txtDLC.Text;

                            objFamilyHistory.Created_By = ClientSession.UserName;
                            //objFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            //if (hdnLocalTime.Value != string.Empty)
                            // objFamilyHistory.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                            objFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            objFamilyHistory.Encounter_Id = ClientSession.EncounterId;
                            lstFamilyHistorySave.Add(objFamilyHistory);

                            //Disease Details
                            if (((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Trim() != string.Empty)
                            {
                                //2016-02-01 37669

                                if (Session["userLookup"] == null)
                                {
                                    userLookup = objUserLookupManager.GetFieldLookupList(PhysicianId, "FAMILY DISEASE");
                                    Session["userLookup"] = userLookup.ToList();
                                }
                                else if (Session["userLookup"] != null)
                                    userLookup = (List<UserLookup>)Session["userLookup"];

                                if (((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Contains(","))
                                {

                                    //string[] arr = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Split(',');
                                    //if (arr != null && arr.Length > 0)  //added by balaji.TJ 2015-11-18
                                    //    for (int k = 0; k < arr.Length; k++)
                                    //    {
                                    //        objFamilyDisease = new FamilyDisease();
                                    //        objFamilyDisease.Internal_Property_Relation = item.Value;
                                    //        objFamilyDisease.Disease = arr[k].ToString();
                                    //        objFamilyDisease.Created_By = ClientSession.UserName;
                                    //        if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == arr[k].Trim().ToString()))
                                    //            objFamilyDisease.Recodes = userLookup.Where(a => a.Value == arr[k].Trim().ToString()).ToList<UserLookup>()[0].Description;                                        
                                    //        objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //        lstFamilyDiseaseSave.Add(objFamilyDisease);
                                    //    }

                                    //2016 balaji.T
                                    string[] FilterValue = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Replace(" ", "").Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                                    if (FilterValue != null && FilterValue.Length > 0)  //added by balaji.TJ 2015-11-18

                                        for (int k = 0; k < FilterValue.Length; k++)
                                        {
                                            string Disease = Convert.ToString(Original.Where(O => O.Replace(" ", "").Trim() == FilterValue[k]).Select(O => O.ToString()).FirstOrDefault());
                                            objFamilyDisease = new FamilyDisease();
                                            objFamilyDisease.Internal_Property_Relation = item.Value;
                                            objFamilyDisease.Human_ID = ClientSession.HumanId;
                                            objFamilyDisease.Disease = Disease;
                                            objFamilyDisease.Created_By = ClientSession.UserName;
                                            if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == Disease.Trim().ToString()))
                                                objFamilyDisease.Recodes = userLookup.Where(a => a.Value == Disease.Trim().ToString()).ToList<UserLookup>()[0].Description;
                                            objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                            lstFamilyDiseaseSave.Add(objFamilyDisease);
                                        }
                                }
                                else
                                {
                                    objFamilyDisease = new FamilyDisease();
                                    objFamilyDisease.Internal_Property_Relation = item.Value;
                                    objFamilyDisease.Human_ID = ClientSession.HumanId;//Bugid:50199
                                    if (((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC != null)
                                        objFamilyDisease.Disease = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text;
                                    objFamilyDisease.Created_By = ClientSession.UserName;
                                    if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == objFamilyDisease.Disease.Trim().ToString()))
                                        objFamilyDisease.Recodes = userLookup.Where(a => a.Value == objFamilyDisease.Disease.Trim()).ToList<UserLookup>()[0].Description;
                                    //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //if (hdnLocalTime.Value != string.Empty)
                                    //objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                    objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    lstFamilyDiseaseSave.Add(objFamilyDisease);
                                }
                            }
                            //End Disease Details
                        }
                        else
                        {
                            //For Master Table
                            objFamilyHistoryMaster.Human_ID = ClientSession.HumanId;
                            objFamilyHistoryMaster.RelationShip = item.Value;
                            objFamilyHistoryMaster.Age = objRadTextBox.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(objRadTextBox.Text);
                            objFamilyHistoryMaster.Status = objRadComboBox.SelectedItem.Text;
                            objFamilyHistoryMaster.Cause_Of_Death = objCustomDLCCauseOfDeath.txtDLC.Text;

                            objFamilyHistoryMaster.Created_By = ClientSession.UserName;
                            //objFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            //if (hdnLocalTime.Value != string.Empty)
                            // objFamilyHistory.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                            objFamilyHistoryMaster.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            //objFamilyHistoryMaster.Encounter_Id = ClientSession.EncounterId;
                            lstFamilyHistorySaveMaster.Add(objFamilyHistoryMaster);

                            //Disease Details
                            if (((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Trim() != string.Empty)
                            {
                                //2016-02-01 37669

                                if (Session["userLookup"] == null)
                                {
                                    userLookup = objUserLookupManager.GetFieldLookupList(PhysicianId, "FAMILY DISEASE");
                                    Session["userLookup"] = userLookup.ToList();
                                }
                                else if (Session["userLookup"] != null)
                                    userLookup = (List<UserLookup>)Session["userLookup"];

                                if (((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Contains(","))
                                {

                                    //string[] arr = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Split(',');
                                    //if (arr != null && arr.Length > 0)  //added by balaji.TJ 2015-11-18
                                    //    for (int k = 0; k < arr.Length; k++)
                                    //    {
                                    //        objFamilyDisease = new FamilyDisease();
                                    //        objFamilyDisease.Internal_Property_Relation = item.Value;
                                    //        objFamilyDisease.Disease = arr[k].ToString();
                                    //        objFamilyDisease.Created_By = ClientSession.UserName;
                                    //        if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == arr[k].Trim().ToString()))
                                    //            objFamilyDisease.Recodes = userLookup.Where(a => a.Value == arr[k].Trim().ToString()).ToList<UserLookup>()[0].Description;                                        
                                    //        objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //        lstFamilyDiseaseSave.Add(objFamilyDisease);
                                    //    }

                                    //2016 balaji.T
                                    string[] FilterValue = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text.Replace(" ", "").Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                                    if (FilterValue != null && FilterValue.Length > 0)  //added by balaji.TJ 2015-11-18

                                        for (int k = 0; k < FilterValue.Length; k++)
                                        {
                                            string Disease = Convert.ToString(Original.Where(O => O.Replace(" ", "").Trim() == FilterValue[k]).Select(O => O.ToString()).FirstOrDefault());
                                            objFamilyDiseaseMaster = new FamilyDiseaseMaster();
                                            objFamilyDiseaseMaster.Internal_Property_Relation = item.Value;
                                            objFamilyDiseaseMaster.Human_ID = ClientSession.HumanId;
                                            objFamilyDiseaseMaster.Disease = Disease;
                                            objFamilyDiseaseMaster.Created_By = ClientSession.UserName;
                                            if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == Disease.Trim().ToString()))
                                                objFamilyDiseaseMaster.Recodes = userLookup.Where(a => a.Value == Disease.Trim().ToString()).ToList<UserLookup>()[0].Description;
                                            objFamilyDiseaseMaster.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                            lstFamilyDiseaseSaveMaster.Add(objFamilyDiseaseMaster);
                                        }
                                }
                                else
                                {
                                    objFamilyDiseaseMaster = new FamilyDiseaseMaster();
                                    objFamilyDiseaseMaster.Internal_Property_Relation = item.Value;
                                    objFamilyDiseaseMaster.Human_ID = ClientSession.HumanId;//Bugid:50199
                                    if (((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC != null)
                                        objFamilyDiseaseMaster.Disease = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", ""))).txtDLC.Text;
                                    objFamilyDiseaseMaster.Created_By = ClientSession.UserName;
                                    if (userLookup != null && userLookup.Count > 0 && userLookup.Any(a => a.Value == objFamilyDiseaseMaster.Disease.Trim().ToString()))
                                        objFamilyDiseaseMaster.Recodes = userLookup.Where(a => a.Value == objFamilyDiseaseMaster.Disease.Trim()).ToList<UserLookup>()[0].Description;
                                    //objFamilyDisease.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    //if (hdnLocalTime.Value != string.Empty)
                                    //objFamilyDisease.Created_Date_And_Time = utc; //Convert.ToDateTime(hdnLocalTime.Value);
                                    objFamilyDiseaseMaster.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                    lstFamilyDiseaseSaveMaster.Add(objFamilyDiseaseMaster);
                                }
                            }
                            //End Disease Details
                        }
                    }
                    //End Save
                }
                //
            }

            GeneralNotes objGeneralNotes = new GeneralNotes();
            if (FamDto != null && FamDto.objGeneralNotes != null)
            {
                if (FamDto.objGeneralNotes.Id == 0)
                {
                    objGeneralNotes.Created_By = ClientSession.UserName;
                    //objGeneralNotes.Created_Date_And_Time = utc;//Convert.ToDateTime(hdnLocalTime.Value);
                    objGeneralNotes.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                    objGeneralNotes.Encounter_ID = ClientSession.EncounterId;
                    objGeneralNotes.Human_ID = ClientSession.HumanId;
                    objGeneralNotes.Name_Of_The_Field = string.Empty;
                    objGeneralNotes.Parent_Field = "Family History";
                    objGeneralNotes.Notes = DLC.txtDLC.Text;
                }
                else if (FamDto.objGeneralNotes.Id == 0 && DLC.txtDLC.Text.Trim() == string.Empty)
                    objGeneralNotes = null;
                else if (FamDto.objGeneralNotes.Id != 0)
                {
                    objGeneralNotes = FamDto.objGeneralNotes; //Added by balaji 2015-11-18
                    objGeneralNotes.Human_ID = FamDto.objGeneralNotes.Human_ID;
                    objGeneralNotes.Name_Of_The_Field = FamDto.objGeneralNotes.Name_Of_The_Field;
                    objGeneralNotes.Parent_Field = FamDto.objGeneralNotes.Parent_Field;
                    objGeneralNotes.Notes = DLC.txtDLC.Text;

                    if (FamDto.objGeneralNotes.Encounter_ID == ClientSession.EncounterId)
                    {
                        objGeneralNotes.Id = FamDto.objGeneralNotes.Id;
                        objGeneralNotes.Version = FamDto.objGeneralNotes.Version;
                        objGeneralNotes.Encounter_ID = ClientSession.EncounterId;
                        objGeneralNotes.Modified_By = ClientSession.UserName;
                        //objGeneralNotes.Modified_Date_And_Time = utc;
                        objGeneralNotes.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                    }
                    else
                    {
                        objGeneralNotes.Encounter_ID = ClientSession.EncounterId;
                        objGeneralNotes.Id = 0;
                        objGeneralNotes.Version = 0;
                        objGeneralNotes.Created_By = ClientSession.UserName;
                        //objGeneralNotes.Created_Date_And_Time = utc;
                        objGeneralNotes.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                    }
                }
            }
            /* Changed Manager Call By Passing Genral Notes, To Avoid Database Call To get General Notes From DB */
            //FamilyDTO resultDto = objFamilyHistoryManager.SaveUpdateDeleteFamilyHistory(ClientSession.HumanId, lstFamilyHistorySave, lstFamilyHistoryUpdate, lstFamilyHistoryDelete, lstFamilyDiseaseSave, lstFamilyDiseaseUpdate, lstFamilyDiseaseDelete, objGeneralNotes, ApplicationObject.macAddress, ClientSession.EncounterId);
            #region GetMastertable
            IList<FamilyHistoryMaster> lstFamilyHisMaster = new List<FamilyHistoryMaster>();//(IList<FamilyHistoryMaster>)HttpContext.Current.Session["FamilyHistoryMaster"];
            IList<FamilyHistoryMaster> lstFamilyHisMasterTemp = new List<FamilyHistoryMaster>();
            IList<FamilyDiseaseMaster> lstFamilyDiseaseHisMaster = new List<FamilyDiseaseMaster>();

            #region "Code Modified by balaji.TJ - 2023-04-01"

            IList<string> ilstHsFyDrugTagList = new List<string>();
            ilstHsFyDrugTagList.Add("FamilyHistoryMasterList");
            ilstHsFyDrugTagList.Add("FamilyDiseaseMasterList");
           
                IList<object> ilstHsFyBlobFinal = new List<object>();
                ilstHsFyBlobFinal = UtilityManager.ReadBlob(ClientSession.HumanId, ilstHsFyDrugTagList);
            if (ilstHsFyBlobFinal != null && ilstHsFyBlobFinal.Count > 0)
            {
                if (ilstHsFyBlobFinal[0] != null && ((IList<object>)ilstHsFyBlobFinal[0]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstHsFyBlobFinal[0]).Count; i++)
                    {
                        lstFamilyHisMasterTemp.Add((FamilyHistoryMaster)((IList<object>)ilstHsFyBlobFinal[0])[i]);
                    }
                    if (lstFamilyHisMasterTemp.Count > 0)
                    {
                        lstFamilyHisMaster = lstFamilyHisMasterTemp.Where(p => p.Is_Deleted == "N").ToList();
                    }
                }
                if (ilstHsFyBlobFinal[1] != null && ((IList<object>)ilstHsFyBlobFinal[1]).Count > 0)
                {
                    for (int i = 0; i < ((IList<object>)ilstHsFyBlobFinal[1]).Count; i++)
                    {
                        lstFamilyDiseaseHisMaster.Add((FamilyDiseaseMaster)((IList<object>)ilstHsFyBlobFinal[1])[i]);
                    }

                }
            }

            #endregion

            #region "code comment by Balaji.TJ 2023-01-05"
            //string FileName = "Human" + "_" + ClientSession.HumanId + ".xml";
            //string strXmlFilePath = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["XMLPath"], FileName);
            //XmlDocument itemDoc = new XmlDocument();
            //XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
            //XmlNodeList xmlTagName = null;
            //try
            //{
            //    using (FileStream fs = new FileStream(strXmlFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //    {
            //        itemDoc.Load(fs);
            //        XmlText.Close();
            //        if (itemDoc.GetElementsByTagName("FamilyHistoryMasterList")[0] != null)
            //        {
            //            xmlTagName = itemDoc.GetElementsByTagName("FamilyHistoryMasterList")[0].ChildNodes;

            //            if (xmlTagName.Count > 0)
            //            {
            //                for (int j = 0; j < xmlTagName.Count; j++)
            //                {
            //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyHistoryMaster));
            //                    FamilyHistoryMaster objHistory = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyHistoryMaster;

            //                    IEnumerable<PropertyInfo> propInfo = null;
            //                    propInfo = from obji in ((FamilyHistoryMaster)objHistory).GetType().GetProperties() select obji;

            //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                    {
            //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                        {
            //                            if (propInfo != null && propInfo.Count() > 0)
            //                            {
            //                                foreach (PropertyInfo property in propInfo)
            //                                {
            //                                    if (property.Name == nodevalue.Name)
            //                                    {

            //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                            property.SetValue(objHistory, Convert.ToUInt64(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                            property.SetValue(objHistory, Convert.ToString(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                            property.SetValue(objHistory, Convert.ToDateTime(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                            property.SetValue(objHistory, Convert.ToInt32(nodevalue.Value), null);
            //                                        else
            //                                            property.SetValue(objHistory, nodevalue.Value, null);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                    lstFamilyHisMasterTemp.Add(objHistory);
            //                    if (lstFamilyHisMasterTemp.Count > 0)
            //                    {
            //                        lstFamilyHisMaster = lstFamilyHisMasterTemp.Where(p => p.Is_Deleted == "N").ToList();

            //                    }
            //                }
            //            }
            //        }
            //        //Family disease
            //        if (itemDoc.GetElementsByTagName("FamilyDiseaseMasterList")[0] != null)
            //        {
            //            xmlTagName = itemDoc.GetElementsByTagName("FamilyDiseaseMasterList")[0].ChildNodes;

            //            if (xmlTagName.Count > 0)
            //            {
            //                for (int j = 0; j < xmlTagName.Count; j++)
            //                {
            //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyDiseaseMaster));
            //                    FamilyDiseaseMaster objHistory = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyDiseaseMaster;

            //                    IEnumerable<PropertyInfo> propInfo = null;
            //                    propInfo = from obji in ((FamilyDiseaseMaster)objHistory).GetType().GetProperties() select obji;

            //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
            //                    {
            //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
            //                        {
            //                            if (propInfo != null && propInfo.Count() > 0)
            //                            {
            //                                foreach (PropertyInfo property in propInfo)
            //                                {
            //                                    if (property.Name == nodevalue.Name)
            //                                    {

            //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
            //                                            property.SetValue(objHistory, Convert.ToUInt64(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
            //                                            property.SetValue(objHistory, Convert.ToString(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
            //                                            property.SetValue(objHistory, Convert.ToDateTime(nodevalue.Value), null);
            //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
            //                                            property.SetValue(objHistory, Convert.ToInt32(nodevalue.Value), null);
            //                                        else
            //                                            property.SetValue(objHistory, nodevalue.Value, null);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                    lstFamilyDiseaseHisMaster.Add(objHistory);
            //                }
            //            }
            //        }
            //        fs.Close();
            //        fs.Dispose();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "Frmfamilyhistory.aspx.cs Line No - 1857 - XML Path -" + strXmlFilePath +" - "+ ex.Message, DateTime.Now, "0", "frmimageviewer");

            //}

            #endregion
            //  }
            #endregion
            //Save PastmedicalHistoryMaster table
            IList<FamilyHistoryMaster> SaveListMaster = new List<FamilyHistoryMaster>();
            IList<FamilyHistoryMaster> UpdateListMaster = new List<FamilyHistoryMaster>();
            IList<FamilyHistoryMaster> DeleteListMaster = new List<FamilyHistoryMaster>();
            IList<FamilyHistoryMaster> lstPMHmasterTemp = new List<FamilyHistoryMaster>();

            IList<FamilyDiseaseMaster> SaveListDisMaster = new List<FamilyDiseaseMaster>();
            IList<FamilyDiseaseMaster> UpdateListDisMaster = new List<FamilyDiseaseMaster>();
            IList<FamilyDiseaseMaster> DeleteListDisMaster = new List<FamilyDiseaseMaster>();
            IList<FamilyDiseaseMaster> lstDismasterTemp = new List<FamilyDiseaseMaster>();
            //Assign history table from master table
            if (UIManager.PFSH_OpeingFrom != "Menu")
            {
                if (lstFamilyHistorySave.Count() == 0 && lstFamilyHistoryUpdate.Count() == 0 && lstFamilyHistoryDelete.Count() == 0)
                {
                    if (lstFamilyHistorySaveMaster.Count() > 0 && lstFamilyHistoryUpdateMaster.Count() > 0)
                    {
                        IList<FamilyHistoryMaster> lstSaveUpdateFHMaster = lstFamilyHistorySaveMaster.Concat(lstFamilyHistoryUpdateMaster).ToList<FamilyHistoryMaster>();
                        FamilyHistory objAddFamilyHistory = new FamilyHistory();
                        foreach (FamilyHistoryMaster objFHM in lstSaveUpdateFHMaster)
                        {
                            objAddFamilyHistory = new FamilyHistory();
                            objAddFamilyHistory.Human_ID = objFHM.Human_ID;
                            objAddFamilyHistory.RelationShip = objFHM.RelationShip;
                            objAddFamilyHistory.Age = objFHM.Age;
                            objAddFamilyHistory.Status = objFHM.Status;
                            objAddFamilyHistory.Cause_Of_Death = objFHM.Cause_Of_Death;
                            objAddFamilyHistory.Encounter_Id = ClientSession.EncounterId;
                            objAddFamilyHistory.Created_By = ClientSession.UserName; ;
                            objAddFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            lstFamilyHistorySave.Add(objAddFamilyHistory);
                        }
                    }
                    else if (lstFamilyHistorySaveMaster.Count() > 0 && lstFamilyHistoryUpdateMaster.Count() == 0)
                    {
                        IList<FamilyHistoryMaster> lstSaveUpdateFHMaster = lstFamilyHistorySaveMaster;
                        FamilyHistory objAddFamilyHistory = new FamilyHistory();
                        foreach (FamilyHistoryMaster objFHM in lstSaveUpdateFHMaster)
                        {
                            objAddFamilyHistory = new FamilyHistory();
                            objAddFamilyHistory.Human_ID = objFHM.Human_ID;
                            objAddFamilyHistory.RelationShip = objFHM.RelationShip;
                            objAddFamilyHistory.Age = objFHM.Age;
                            objAddFamilyHistory.Encounter_Id = ClientSession.EncounterId;
                            objAddFamilyHistory.Status = objFHM.Status;
                            objAddFamilyHistory.Cause_Of_Death = objFHM.Cause_Of_Death;
                            objAddFamilyHistory.Created_By = ClientSession.UserName; ;
                            objAddFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            lstFamilyHistorySave.Add(objAddFamilyHistory);
                        }
                    }
                    else if (lstFamilyHistorySaveMaster.Count() == 0 && lstFamilyHistoryUpdateMaster.Count() > 0)
                    {
                        IList<FamilyHistoryMaster> lstSaveUpdateFHMaster = lstFamilyHistoryUpdateMaster;
                        FamilyHistory objAddFamilyHistory = new FamilyHistory();
                        foreach (FamilyHistoryMaster objFHM in lstSaveUpdateFHMaster)
                        {
                            objAddFamilyHistory = new FamilyHistory();
                            objAddFamilyHistory.Human_ID = objFHM.Human_ID;
                            objAddFamilyHistory.RelationShip = objFHM.RelationShip;
                            objAddFamilyHistory.Age = objFHM.Age;
                            objAddFamilyHistory.Encounter_Id = ClientSession.EncounterId;
                            objAddFamilyHistory.Status = objFHM.Status;
                            objAddFamilyHistory.Cause_Of_Death = objFHM.Cause_Of_Death;
                            objAddFamilyHistory.Created_By = ClientSession.UserName; ;
                            objAddFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                            lstFamilyHistorySave.Add(objAddFamilyHistory);
                        }
                    }
                    if (lstFamilyHistoryDeleteMaster.Count() > 0)
                    {
                        foreach (FamilyHistoryMaster objpmhDelete in lstFamilyHistoryDeleteMaster)
                        {
                            objpmhDelete.Is_Deleted = "Y";
                            objpmhDelete.Modified_By = ClientSession.UserName;
                            objpmhDelete.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                            UpdateListMaster.Add(objpmhDelete);
                        }
                    }

                    //History Disease save
                    if (lstFamilyDiseaseSave.Count() == 0 && lstFamilyDiseaseDelete.Count() == 0)
                    {
                        if (lstFamilyDiseaseSaveMaster.Count() > 0 )
                        {
                            IList<FamilyDiseaseMaster> lstSaveUpdateFHMaster = lstFamilyDiseaseSaveMaster.ToList<FamilyDiseaseMaster>();//;.Concat(lstFamilyDiseaseUpdateMaster).ToList<FamilyDiseaseMaster>();
                            FamilyDisease objAddFamilyHistory = new FamilyDisease();

                            foreach (FamilyDiseaseMaster objFHM in lstSaveUpdateFHMaster)
                            {
                                objAddFamilyHistory = new FamilyDisease();
                                objAddFamilyHistory.Human_ID = objFHM.Human_ID;
                                objAddFamilyHistory.Disease = objFHM.Disease;
                                objAddFamilyHistory.Internal_Property_Relation = objFHM.Internal_Property_Relation;
                                objAddFamilyHistory.Recodes = objFHM.Recodes;
                                objAddFamilyHistory.Created_By = ClientSession.UserName;
                                
                                objAddFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                lstFamilyDiseaseSave.Add(objAddFamilyHistory);
                            }
                        }
                        else if (lstFamilyDiseaseSaveMaster.Count() > 0 )
                        {
                            IList<FamilyDiseaseMaster> lstSaveUpdateFHMaster = lstFamilyDiseaseSaveMaster;
                            FamilyDisease objAddFamilyHistory = new FamilyDisease();

                            foreach (FamilyDiseaseMaster objFHM in lstSaveUpdateFHMaster)
                            {
                                objAddFamilyHistory = new FamilyDisease();
                                objAddFamilyHistory.Human_ID = objFHM.Human_ID;
                                objAddFamilyHistory.Disease = objFHM.Disease;
                                objAddFamilyHistory.Internal_Property_Relation = objFHM.Internal_Property_Relation;
                                objAddFamilyHistory.Recodes = objFHM.Recodes;
                                objAddFamilyHistory.Created_By = ClientSession.UserName; ;
                                objAddFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                lstFamilyDiseaseSave.Add(objAddFamilyHistory);
                            }
                        }
                        else if (lstFamilyDiseaseSaveMaster.Count() == 0 )
                        {
                            IList<FamilyDiseaseMaster> lstSaveUpdateFHMaster = lstFamilyDiseaseSaveMaster;
                            FamilyDisease objAddFamilyHistory = new FamilyDisease();

                            foreach (FamilyDiseaseMaster objFHM in lstSaveUpdateFHMaster)
                            {
                                objAddFamilyHistory = new FamilyDisease();
                                objAddFamilyHistory.Human_ID = objFHM.Human_ID;
                                objAddFamilyHistory.Disease = objFHM.Disease;
                                objAddFamilyHistory.Internal_Property_Relation = objFHM.Internal_Property_Relation;
                                objAddFamilyHistory.Recodes = objFHM.Recodes;
                                objAddFamilyHistory.Created_By = ClientSession.UserName; ;
                                objAddFamilyHistory.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                lstFamilyDiseaseSave.Add(objAddFamilyHistory);
                            }
                        }
                    }
                }
            }
            else
            {
                //family history save 
                SaveListMaster = lstFamilyHistorySaveMaster;
                UpdateListMaster = lstFamilyHistoryUpdateMaster;
                if (lstFamilyHistoryDeleteMaster.Count() > 0)
                {
                    foreach (FamilyHistoryMaster objpmhDelete in lstFamilyHistoryDeleteMaster)
                    {

                        objpmhDelete.Is_Deleted = "Y";
                        objpmhDelete.Modified_By = ClientSession.UserName;
                        objpmhDelete.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                        UpdateListMaster.Add(objpmhDelete);
                    }
                }


                ////family history disease save 
                SaveListDisMaster = lstFamilyDiseaseSaveMaster;
               // UpdateListDisMaster = lstFamilyDiseaseUpdateMaster;
                DeleteListDisMaster = lstFamilyDiseaseDeleteMaster;
                //if (lstFamilyDiseaseDeleteMaster.Count() > 0)
                //{
                //    foreach (FamilyDiseaseMaster objpmhDelete in lstFamilyDiseaseDeleteMaster)
                //    {
                //        objpmhDelete.Is_Deleted = "Y";
                //        objpmhDelete.Modified_By = ClientSession.UserName;
                //        objpmhDelete.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                //        UpdateListDisMaster.Add(objAddSHMaster);
                //    }
                //}
            }


            #region FamilyHistoryMasterTable

            if (lstFamilyHistorySave.Count > 0)
                foreach (FamilyHistory objpmh in lstFamilyHistorySave)
                {
                    FamilyHistoryMaster objAddSHMaster = new FamilyHistoryMaster();
                    if (lstFamilyHisMaster != null && lstFamilyHisMaster.Count() > 0)
                        lstPMHmasterTemp = lstFamilyHisMaster.Where(a => a.RelationShip.Trim().ToUpper() == objpmh.RelationShip.Trim().ToUpper()).ToList<FamilyHistoryMaster>();
                    if (lstPMHmasterTemp.Count() == 0)
                    {
                        objAddSHMaster.Human_ID = objpmh.Human_ID;
                        objAddSHMaster.RelationShip = objpmh.RelationShip;
                        objAddSHMaster.Age = objpmh.Age;
                        objAddSHMaster.Status = objpmh.Status;
                        objAddSHMaster.Cause_Of_Death = objpmh.Cause_Of_Death;
                        objAddSHMaster.Is_Deleted = "N";
                        objAddSHMaster.Created_By = objpmh.Created_By;
                        objAddSHMaster.Created_Date_And_Time = objpmh.Created_Date_And_Time;
                        objAddSHMaster.Modified_By = objpmh.Modified_By;
                        objAddSHMaster.Modified_Date_And_Time = objpmh.Modified_Date_And_Time;
                        SaveListMaster.Add(objAddSHMaster);
                    }
                    else
                    {
                        IList<FamilyHistoryMaster> tempSessionData = new List<FamilyHistoryMaster>();
                        tempSessionData = lstFamilyHisMaster.Where(a => a.RelationShip == objpmh.RelationShip).ToList();
                        foreach (FamilyHistoryMaster temp in tempSessionData)
                        {
                            objAddSHMaster = temp;
                        }
                        objAddSHMaster.Human_ID = objpmh.Human_ID;
                        objAddSHMaster.RelationShip = objpmh.RelationShip;
                        objAddSHMaster.Age = objpmh.Age;
                        objAddSHMaster.Status = objpmh.Status;
                        objAddSHMaster.Cause_Of_Death = objpmh.Cause_Of_Death;
                        objAddSHMaster.Is_Deleted = "N";
                        objAddSHMaster.Created_By = objpmh.Created_By;
                        objAddSHMaster.Created_Date_And_Time = objpmh.Created_Date_And_Time;
                        objAddSHMaster.Modified_By = objpmh.Modified_By;
                        objAddSHMaster.Modified_Date_And_Time = objpmh.Modified_Date_And_Time;
                        UpdateListMaster.Add(objAddSHMaster);
                    }
                }
            //update
            if (lstFamilyHistoryUpdate.Count() > 0)
            {
                foreach (FamilyHistory objpmhUpdate in lstFamilyHistoryUpdate)
                {
                    FamilyHistoryMaster objAddSHMaster = new FamilyHistoryMaster();
                    IList<FamilyHistoryMaster> tempSessionData = new List<FamilyHistoryMaster>();
                    tempSessionData = lstFamilyHisMaster.Where(a => a.RelationShip == objpmhUpdate.RelationShip).ToList();
                    foreach (FamilyHistoryMaster temp in tempSessionData)
                    {
                        objAddSHMaster = temp;
                    }
                    objAddSHMaster.Human_ID = objpmhUpdate.Human_ID;
                    objAddSHMaster.RelationShip = objpmhUpdate.RelationShip;
                    objAddSHMaster.Age = objpmhUpdate.Age;
                    objAddSHMaster.Status = objpmhUpdate.Status;
                    objAddSHMaster.Is_Deleted = "N";
                    objAddSHMaster.Cause_Of_Death = objpmhUpdate.Cause_Of_Death;
                    objAddSHMaster.Created_By = objpmhUpdate.Created_By;
                    objAddSHMaster.Created_Date_And_Time = objpmhUpdate.Created_Date_And_Time;
                    objAddSHMaster.Modified_By = objpmhUpdate.Modified_By;
                    objAddSHMaster.Modified_Date_And_Time = objpmhUpdate.Modified_Date_And_Time;
                    UpdateListMaster.Add(objAddSHMaster);
                }
            }

            //delete
            if (lstFamilyHistoryDelete.Count() > 0)
            {
                foreach (FamilyHistory objpmhDelete in lstFamilyHistoryDelete)
                {
                    FamilyHistoryMaster objAddSHMaster = new FamilyHistoryMaster();
                    IList<FamilyHistoryMaster> tempSessionData = new List<FamilyHistoryMaster>();
                    tempSessionData = lstFamilyHisMaster.Where(a => a.RelationShip == objpmhDelete.RelationShip).ToList();
                    foreach (FamilyHistoryMaster temp in tempSessionData)
                    {
                        objAddSHMaster = temp;
                    }
                    objAddSHMaster.Is_Deleted = "Y";
                    objAddSHMaster.Modified_By = ClientSession.UserName;
                    objAddSHMaster.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                    UpdateListMaster.Add(objAddSHMaster);
                    //DeleteListMaster.Add(objAddSHMaster);
                }
            }
            //Save Disease Master


            if (lstFamilyDiseaseSave.Count > 0)
                foreach (FamilyDisease objpmh in lstFamilyDiseaseSave)
                {
                    FamilyDiseaseMaster objAddSHMaster = new FamilyDiseaseMaster();
                    lstDismasterTemp = lstFamilyDiseaseHisMaster.Where(a => a.Disease.Trim().ToUpper() == objpmh.Disease.Trim().ToUpper()).ToList<FamilyDiseaseMaster>();
                    if (lstDismasterTemp.Count() == 0)
                    {
                        objAddSHMaster.Human_ID = objpmh.Human_ID;
                        objAddSHMaster.Disease = objpmh.Disease;
                        objAddSHMaster.Internal_Property_Relation = objpmh.Internal_Property_Relation;
                        objAddSHMaster.Family_History_ID = objpmh.Family_History_ID;
                        objAddSHMaster.Created_By = objpmh.Created_By;
                        objAddSHMaster.Created_Date_And_Time = objpmh.Created_Date_And_Time;
                        objAddSHMaster.Modified_By = objpmh.Modified_By;
                        objAddSHMaster.Modified_Date_And_Time = objpmh.Modified_Date_And_Time;
                        SaveListDisMaster.Add(objAddSHMaster);
                    }
                    else
                    {
                        IList<FamilyDiseaseMaster> tempSessionData = new List<FamilyDiseaseMaster>();
                        tempSessionData = lstFamilyDiseaseHisMaster.Where(a => a.Disease == objpmh.Disease).ToList();
                        foreach (FamilyDiseaseMaster temp in tempSessionData)
                        {
                            objAddSHMaster = temp;
                        }
                        objAddSHMaster.Human_ID = objpmh.Human_ID;
                        objAddSHMaster.Disease = objpmh.Disease;
                        objAddSHMaster.Family_History_ID = objpmh.Family_History_ID;
                        objAddSHMaster.Internal_Property_Relation = objpmh.Internal_Property_Relation;
                        objAddSHMaster.Created_By = objpmh.Created_By;
                        objAddSHMaster.Created_Date_And_Time = objpmh.Created_Date_And_Time;
                        objAddSHMaster.Modified_By = objpmh.Modified_By;
                        objAddSHMaster.Modified_Date_And_Time = objpmh.Modified_Date_And_Time;
                        UpdateListDisMaster.Add(objAddSHMaster);
                    }
                }
            //update
            //if (lstFamilyDiseaseUpdate.Count() > 0)
            //{
            //    foreach (FamilyDisease objpmhUpdate in lstFamilyDiseaseUpdate)
            //    {
            //        FamilyDiseaseMaster objAddSHMaster = new FamilyDiseaseMaster();
            //        IList<FamilyDiseaseMaster> tempSessionData = new List<FamilyDiseaseMaster>();
            //        tempSessionData = lstFamilyDiseaseHisMaster.Where(a => a.Disease == objpmhUpdate.Disease).ToList();
            //        foreach (FamilyDiseaseMaster temp in tempSessionData)
            //        {
            //            objAddSHMaster = temp;
            //        }
            //        objAddSHMaster.Internal_Property_Relation = objpmhUpdate.Internal_Property_Relation;
            //        objAddSHMaster.Human_ID = objpmhUpdate.Human_ID;
            //        objAddSHMaster.Disease = objpmhUpdate.Disease;
            //        objAddSHMaster.Family_History_ID = objpmhUpdate.Family_History_ID;
            //        objAddSHMaster.Created_By = objpmhUpdate.Created_By;
            //        objAddSHMaster.Created_Date_And_Time = objpmhUpdate.Created_Date_And_Time;
            //        objAddSHMaster.Modified_By = objpmhUpdate.Modified_By;
            //        objAddSHMaster.Modified_Date_And_Time = objpmhUpdate.Modified_Date_And_Time;
            //        UpdateListDisMaster.Add(objAddSHMaster);
            //    }
            //}

            //delete
            if (lstFamilyDiseaseDelete.Count() > 0)
            {
                foreach (FamilyDisease objpmhDelete in lstFamilyDiseaseDelete)
                {
                    FamilyDiseaseMaster objAddSHMaster = new FamilyDiseaseMaster();
                    IList<FamilyDiseaseMaster> tempSessionData = new List<FamilyDiseaseMaster>();
                    //tempSessionData = lstFamilyDiseaseHisMaster.Where(a => a.Disease == objpmhDelete.Disease).ToList();commented by viji
                    tempSessionData = lstFamilyDiseaseHisMaster.Where(a => a.Family_History_ID== objpmhDelete.Family_History_ID).ToList();
                    foreach (FamilyDiseaseMaster temp in tempSessionData)
                    {
                        objAddSHMaster = temp;
                    }

                    DeleteListDisMaster.Add(objAddSHMaster);
                }
            }
            #endregion

            FamilyDTO resultDto = objFamilyHistoryManager.SaveUpdateDeleteFamilyHistory(ClientSession.HumanId, lstFamilyHistorySave, lstFamilyHistoryUpdate, lstFamilyHistoryDelete, lstFamilyDiseaseSave, null, lstFamilyDiseaseDelete, objGeneralNotes, string.Empty, ClientSession.EncounterId, SaveListMaster, UpdateListMaster, DeleteListMaster, SaveListDisMaster, UpdateListDisMaster, DeleteListDisMaster);
            Session["FamilyDTO"] = resultDto;
            btnSave.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "FamilyHistoryPFSH", "SavedSuccessfully(); {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}EnablePFSH(" + ClientSession.EncounterId + ");", true);
            //divLoading.Style.Add("display", "none");
            //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "top.window.document.getElementById('ctl00_Loading').style.display = 'none';", true);
            ClientSession.bPFSHVerified = false;
            UIManager.IsPFSHVerified = true;
        }

        //void pbDropdown_Click(object sender, ImageClickEventArgs e) //comment by balaji.TJ 2015-11-18
        //{
        //    if (Hidden1.Value == "True")
        //        btnSave.Enabled = true;
        //}

        protected void InvisibleButton_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DLC.txtDLC.Text = string.Empty;

            FamilyDTO FamDto = new FamilyDTO();
            if (Session["FamilyDTO"] != null)
                FamDto = (FamilyDTO)Session["FamilyDTO"];
            else
            {
                #region "code Modified by balaji.TJ"
                IList<string> ilstFamilyHisList = new List<string>();
                ilstFamilyHisList.Add("FamilyHistoryList");               
                ilstFamilyHisList.Add("FamilyDiseaseList");
                ilstFamilyHisList.Add("GeneralNotesFamilyHistoryList");
                
                IList<object> ilstFamilyHisBlobFinal = new List<object>();
                ilstFamilyHisBlobFinal = UtilityManager.ReadBlob(ClientSession.HumanId, ilstFamilyHisList);

                IList<FamilyHistory> lstFmlyHis = new List<FamilyHistory>();
                IList<FamilyDisease> lstFmlyDisease = new List<FamilyDisease>();
                IList<GeneralNotes> lstGenNotes = new List<GeneralNotes>();
                if (ilstFamilyHisBlobFinal != null && ilstFamilyHisBlobFinal.Count > 0)
                {
                    if (ilstFamilyHisBlobFinal[0] != null && ((IList<object>)ilstFamilyHisBlobFinal[0]).Count > 0)
                    {
                        for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[0]).Count; i++)
                        {
                            lstFmlyHis.Add((FamilyHistory)((IList<object>)ilstFamilyHisBlobFinal[0])[i]);
                        }
                    }
                    if (lstFmlyHis != null && lstFmlyHis.Count > 0)
                    {
                        IList<FamilyHistory> lstHisCurrEnc = new List<FamilyHistory>();
                        lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == ClientSession.EncounterId select item).ToList<FamilyHistory>();
                        if (lstHisCurrEnc != null && lstHisCurrEnc.Count > 0)
                        {
                            FamDto.Family_History = lstHisCurrEnc;
                            bHistoryFromPrevEnc = false;
                        }
                        else
                        {
                            ulong maxEncId = 0;
                            IList<ulong> lstEncId = (from item in lstFmlyHis select item.Encounter_Id).Distinct().ToList<ulong>();
                            if (lstEncId.Count > 0)
                                maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
                            foreach (ulong item in lstEncId.ToList())
                                if (item > maxEncId && item < ClientSession.EncounterId)
                                    maxEncId = item;
                            lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == maxEncId select item).ToList<FamilyHistory>();
                            FamDto.Family_History = lstHisCurrEnc;
                            bHistoryFromPrevEnc = true;
                        }
                    }
                    else
                    {
                        FamDto.Family_History = lstFmlyHis;
                    }

                    if (ilstFamilyHisBlobFinal[1] != null && ((IList<object>)ilstFamilyHisBlobFinal[1]).Count > 0)
                    {
                        for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[1]).Count; i++)
                        {
                            lstFmlyDisease.Add((FamilyDisease)((IList<object>)ilstFamilyHisBlobFinal[1])[i]);
                        }
                    }
                    if (lstFmlyDisease != null && lstFmlyDisease.Count > 0)
                    {
                        IList<FamilyDisease> lstDisCurrEnc = new List<FamilyDisease>();
                        for (int i = 0; i < FamDto.Family_History.Count; i++)
                        {
                            lstDisCurrEnc = lstDisCurrEnc.Concat((from item in lstFmlyDisease where item.Family_History_ID == FamDto.Family_History[i].Id select item).ToList<FamilyDisease>()).ToList<FamilyDisease>();
                        }
                        if (lstDisCurrEnc != null && lstDisCurrEnc.Count > 0)
                            FamDto.Family_Disease = lstDisCurrEnc;
                        else
                            FamDto.Family_Disease = new List<FamilyDisease>();
                    }
                    else
                    {
                        FamDto.Family_Disease = lstFmlyDisease;
                    }

                    if (ilstFamilyHisBlobFinal[2] != null && ((IList<object>)ilstFamilyHisBlobFinal[2]).Count > 0)
                    {
                        for (int i = 0; i < ((IList<object>)ilstFamilyHisBlobFinal[2]).Count; i++)
                        {
                            lstGenNotes.Add((GeneralNotes)((IList<object>)ilstFamilyHisBlobFinal[2])[i]);
                        }
                    }
                    if (lstGenNotes != null && lstGenNotes.Count > 0)
                    {
                        IList<GeneralNotes> lstGenCurrEnc = new List<GeneralNotes>();
                        lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == ClientSession.EncounterId select item).ToList<GeneralNotes>();
                        if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
                        {
                            FamDto.objGeneralNotes = lstGenCurrEnc[0];
                        }
                        else
                        {
                            ulong maxEncId = 0;
                            IList<ulong> lstEncId = (from item in lstGenNotes select item.Encounter_ID).Distinct().ToList<ulong>();
                            if (lstEncId.Count > 0)
                                maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
                            foreach (ulong item in lstEncId.ToList())
                                if (item > maxEncId && item < ClientSession.EncounterId)
                                    maxEncId = item;
                            lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == maxEncId select item).ToList<GeneralNotes>();
                            if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
                            {
                                FamDto.objGeneralNotes = lstGenCurrEnc[0];
                            }
                        }
                    }

                }
                Session["FamilyDTO"] = FamDto;

                #endregion

                #region "Code comment By Balaji.TJ 2023-01-05"

                //string FileName = "Human" + "_" + ClientSession.HumanId + ".xml";
                //string strXmlFilePath = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["XMLPath"], FileName);
                //if (File.Exists(strXmlFilePath) == true)
                //{
                //    XmlDocument itemDoc = new XmlDocument();
                //    XmlTextReader XmlText = new XmlTextReader(strXmlFilePath);
                //    XmlNodeList xmlTagName = null;
                //    IList<FamilyHistory> lstFmlyHis = new List<FamilyHistory>();
                //    IList<FamilyDisease> lstFmlyDisease = new List<FamilyDisease>();
                //    IList<GeneralNotes> lstGenNotes = new List<GeneralNotes>();

                //    //itemDoc.Load(XmlText);
                //    using (FileStream fs = new FileStream(strXmlFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                //    {
                //        itemDoc.Load(fs);

                //        XmlText.Close();


                //        if (itemDoc.GetElementsByTagName("FamilyHistoryList")[0] != null)
                //        {
                //            xmlTagName = itemDoc.GetElementsByTagName("FamilyHistoryList")[0].ChildNodes;

                //            if (xmlTagName.Count > 0)
                //            {
                //                for (int j = 0; j < xmlTagName.Count; j++)
                //                {
                //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyHistory));
                //                    FamilyHistory objHistory = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyHistory;

                //                    IEnumerable<PropertyInfo> propInfo = null;
                //                    objHistory = (FamilyHistory)objHistory;
                //                    propInfo = from obji in ((FamilyHistory)objHistory).GetType().GetProperties() select obji;

                //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
                //                    {
                //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
                //                        {
                //                            if (propInfo != null && propInfo.Count() > 0) //added by balaji 2015-11-18
                //                            {
                //                                foreach (PropertyInfo property in propInfo)
                //                                {
                //                                    if (property.Name == nodevalue.Name)
                //                                    {

                //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
                //                                            property.SetValue(objHistory, Convert.ToUInt64(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
                //                                            property.SetValue(objHistory, Convert.ToString(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
                //                                            property.SetValue(objHistory, Convert.ToDateTime(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
                //                                            property.SetValue(objHistory, Convert.ToInt32(nodevalue.Value), null);
                //                                        else
                //                                            property.SetValue(objHistory, nodevalue.Value, null);
                //                                    }
                //                                }
                //                            }
                //                        }
                //                    }

                //                    lstFmlyHis.Add(objHistory);
                //                }
                //            }

                //        }

                //        if (lstFmlyHis != null && lstFmlyHis.Count > 0)
                //        {
                //            IList<FamilyHistory> lstHisCurrEnc = new List<FamilyHistory>();
                //            lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == ClientSession.EncounterId select item).ToList<FamilyHistory>();
                //            if (lstHisCurrEnc != null && lstHisCurrEnc.Count > 0)
                //            {
                //                FamDto.Family_History = lstHisCurrEnc;
                //                bHistoryFromPrevEnc = false;
                //            }
                //            else
                //            {
                //                ulong maxEncId = 0;
                //                IList<ulong> lstEncId = (from item in lstFmlyHis select item.Encounter_Id).Distinct().ToList<ulong>();
                //                if (lstEncId.Count > 0)
                //                    maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
                //                foreach (ulong item in lstEncId.ToList())
                //                    if (item > maxEncId && item < ClientSession.EncounterId)
                //                        maxEncId = item;
                //                lstHisCurrEnc = (from item in lstFmlyHis where item.Encounter_Id == maxEncId select item).ToList<FamilyHistory>();
                //                FamDto.Family_History = lstHisCurrEnc;
                //                bHistoryFromPrevEnc = true;
                //            }
                //        }
                //        else
                //        {
                //            FamDto.Family_History = lstFmlyHis;
                //        }
                //        if (itemDoc.GetElementsByTagName("FamilyDiseaseList")[0] != null)
                //        {
                //            xmlTagName = itemDoc.GetElementsByTagName("FamilyDiseaseList")[0].ChildNodes;

                //            if (xmlTagName.Count > 0)
                //            {
                //                for (int j = 0; j < xmlTagName.Count; j++)
                //                {
                //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(FamilyDisease));
                //                    FamilyDisease objDisease = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as FamilyDisease;
                //                    IEnumerable<PropertyInfo> propInfo = null;

                //                    propInfo = from obji in ((FamilyDisease)objDisease).GetType().GetProperties() select obji;

                //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
                //                    {
                //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
                //                        {
                //                            if (propInfo != null)
                //                            {
                //                                foreach (PropertyInfo property in propInfo)
                //                                {
                //                                    if (property.Name == nodevalue.Name)
                //                                    {
                //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
                //                                            property.SetValue(objDisease, Convert.ToUInt64(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
                //                                            property.SetValue(objDisease, Convert.ToString(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
                //                                            property.SetValue(objDisease, Convert.ToDateTime(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
                //                                            property.SetValue(objDisease, Convert.ToInt32(nodevalue.Value), null);
                //                                        else
                //                                            property.SetValue(objDisease, nodevalue.Value, null);
                //                                    }
                //                                }
                //                            }
                //                        }
                //                    }
                //                    lstFmlyDisease.Add(objDisease);
                //                }
                //            }
                //        }

                //        if (lstFmlyDisease != null && lstFmlyDisease.Count > 0)
                //        {
                //            IList<FamilyDisease> lstDisCurrEnc = new List<FamilyDisease>();
                //            for (int i = 0; i < FamDto.Family_History.Count; i++)
                //            {
                //                lstDisCurrEnc = lstDisCurrEnc.Concat((from item in lstFmlyDisease where item.Family_History_ID == FamDto.Family_History[i].Id select item).ToList<FamilyDisease>()).ToList<FamilyDisease>();
                //            }
                //            if (lstDisCurrEnc != null && lstDisCurrEnc.Count > 0)
                //                FamDto.Family_Disease = lstDisCurrEnc;
                //            else
                //                FamDto.Family_Disease = new List<FamilyDisease>();
                //        }
                //        else
                //        {
                //            FamDto.Family_Disease = lstFmlyDisease;
                //        }
                //        //
                //        if (itemDoc.GetElementsByTagName("GeneralNotesFamilyHistoryList")[0] != null)
                //        {
                //            xmlTagName = itemDoc.GetElementsByTagName("GeneralNotesFamilyHistoryList")[0].ChildNodes;

                //            if (xmlTagName.Count > 0)
                //            {

                //                for (int j = 0; j < xmlTagName.Count; j++)
                //                {
                //                    XmlSerializer xmlserializer = new XmlSerializer(typeof(GeneralNotes));
                //                    GeneralNotes generalnotes = xmlserializer.Deserialize(new XmlNodeReader(xmlTagName[j])) as GeneralNotes;
                //                    IEnumerable<PropertyInfo> propInfo = null;
                //                    generalnotes = (GeneralNotes)generalnotes;

                //                    propInfo = from obji in ((GeneralNotes)generalnotes).GetType().GetProperties() select obji;

                //                    for (int i = 0; i < xmlTagName[j].Attributes.Count; i++)
                //                    {
                //                        XmlNode nodevalue = xmlTagName[j].Attributes[i];
                //                        {
                //                            if (propInfo != null)
                //                            {
                //                                foreach (PropertyInfo property in propInfo)
                //                                {
                //                                    if (property.Name == nodevalue.Name)
                //                                    {

                //                                        if (property.PropertyType.Name.ToUpper() == "UINT64")
                //                                            property.SetValue(generalnotes, Convert.ToUInt64(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "STRING")
                //                                            property.SetValue(generalnotes, Convert.ToString(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "DATETIME")
                //                                            property.SetValue(generalnotes, Convert.ToDateTime(nodevalue.Value), null);
                //                                        else if (property.PropertyType.Name.ToUpper() == "INT32")
                //                                            property.SetValue(generalnotes, Convert.ToInt32(nodevalue.Value), null);
                //                                        else
                //                                            property.SetValue(generalnotes, nodevalue.Value, null);
                //                                    }
                //                                }
                //                            }
                //                        }
                //                    }
                //                    lstGenNotes.Add(generalnotes);
                //                }
                //            }
                //        }
                //        fs.Close();
                //        fs.Dispose();
                //    }
                //    if (lstGenNotes != null && lstGenNotes.Count > 0)
                //    {
                //        IList<GeneralNotes> lstGenCurrEnc = new List<GeneralNotes>();
                //        lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == ClientSession.EncounterId select item).ToList<GeneralNotes>();
                //        if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
                //        {
                //            FamDto.objGeneralNotes = lstGenCurrEnc[0];
                //        }
                //        else
                //        {
                //            ulong maxEncId = 0;
                //            IList<ulong> lstEncId = (from item in lstGenNotes select item.Encounter_ID).Distinct().ToList<ulong>();
                //            if (lstEncId.Count > 0)
                //                maxEncId = (lstEncId.Min() < ClientSession.EncounterId) ? lstEncId.Min() : 0;
                //            foreach (ulong item in lstEncId.ToList())
                //                if (item > maxEncId && item < ClientSession.EncounterId)
                //                    maxEncId = item;
                //            lstGenCurrEnc = (from item in lstGenNotes where item.Encounter_ID == maxEncId select item).ToList<GeneralNotes>();
                //            if (lstGenCurrEnc != null && lstGenCurrEnc.Count > 0)
                //            {
                //                FamDto.objGeneralNotes = lstGenCurrEnc[0];
                //            }
                //        }
                //    }

                //    Session["FamilyDTO"] = FamDto;
                //}
                #endregion
            }

            if (FamDto != null && FamDto.objGeneralNotes != null)
                DLC.txtDLC.Text = FamDto.objGeneralNotes.Notes;

            foreach (KeyValuePair<ulong, string> item in dictionary.ToArray())
            {
                CheckBox objChkBox = ((CheckBox)divFamilyHistory.FindControl("chk" + item.Value.Replace(" ", "")));
                RadNumericTextBox objRadTextBox = (RadNumericTextBox)divFamilyHistory.FindControl("txtAge" + item.Value.Replace(" ", ""));
                RadComboBox objRadComboBox = (RadComboBox)divFamilyHistory.FindControl("cbo" + item.Value.Replace(" ", ""));
                CustomDLCNew objCustomDLCCauseOfDeath = ((CustomDLCNew)divFamilyHistory.FindControl("DLCCauseOfDeath" + item.Value.Replace(" ", "")));
                CustomDLCNew objDLCFamilyDisease = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", "")));
                Label objlbl = ((Label)divFamilyHistory.FindControl("lblID" + item.Value));
                if (UIManager.PFSH_OpeingFrom == "Menu")
                {
                    if (FamDto.Family_History_Master != null && !FamDto.Family_History_Master.Any(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim())) //added by balaji.TJ 2015-11-18
                    {
                        if (objChkBox != null)
                            objChkBox.Checked = false;
                        objRadTextBox.Text = string.Empty;
                        objRadTextBox.Enabled = false;
                        objRadComboBox.SelectedIndex = 0;
                        objRadComboBox.Enabled = false;
                        objCustomDLCCauseOfDeath.Enable = false;
                        objCustomDLCCauseOfDeath.txtDLC.Text = string.Empty;
                        objDLCFamilyDisease.Enable = false;
                        objDLCFamilyDisease.txtDLC.Text = string.Empty;
                    }
                    else
                    {
                        if (objChkBox != null)
                            objChkBox.Checked = true;
                        objRadTextBox.Enabled = true;
                        if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0)
                            objRadComboBox.SelectedIndex = objRadComboBox.FindItemIndexByText(FamDto.Family_History_Master.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Status);
                        //code added by balaji.TJ
                        if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0 && FamDto.Family_History_Master.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Status.Trim().ToUpper() == "DECEASED")
                        {
                            objCustomDLCCauseOfDeath.Enable = true;
                            objCustomDLCCauseOfDeath.txtDLC.Text = FamDto.Family_History_Master.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Cause_Of_Death;
                        }
                        else
                        {
                            objCustomDLCCauseOfDeath.Enable = false;
                            objCustomDLCCauseOfDeath.txtDLC.Text = string.Empty;
                        }
                        objDLCFamilyDisease.Enable = true;
                        string value = string.Empty;
                        //code added by balaji.TJ 2015-11-18
                        ulong ID = 0;
                        if (FamDto.Family_History_Master != null && FamDto.Family_History_Master.Count > 0)
                            ID = FamDto.Family_History_Master.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Id;
                        if (ID > 0)
                        {
                            //string[] aryValue=FamDto.Family_Disease
                            //code added by balaji.TJ 2015-11-18
                            IList<FamilyDiseaseMaster> FamilyDiseaseMasterlst = new List<FamilyDiseaseMaster>();
                            if (FamDto.Family_Disease_Master != null && FamDto.Family_Disease_Master.Count > 0)
                                FamilyDiseaseMasterlst = FamDto.Family_Disease_Master.Where(a => a.Family_History_Master_ID == ID).ToList<FamilyDiseaseMaster>();

                            if (FamilyDiseaseMasterlst != null && FamilyDiseaseMasterlst.Count > 0)
                            {
                                foreach (FamilyDiseaseMaster items in FamilyDiseaseMasterlst.ToList())
                                {
                                    if (value.Trim() == string.Empty && items.Disease != string.Empty)
                                        value = items.Disease;
                                    else if (value.Trim() != string.Empty && items.Disease != string.Empty)
                                        value += "," + items.Disease;
                                }
                            }
                        }

                        objDLCFamilyDisease.txtDLC.Text = value;
                    }

                }

                else 
                {
                    if (FamDto.Family_History != null && !FamDto.Family_History.Any(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim())) //added by balaji.TJ 2015-11-18
                    {
                        if (objChkBox != null)
                            objChkBox.Checked = false;
                        objRadTextBox.Text = string.Empty;
                        objRadTextBox.Enabled = false;
                        objRadComboBox.SelectedIndex = 0;
                        objRadComboBox.Enabled = false;
                        objCustomDLCCauseOfDeath.Enable = false;
                        objCustomDLCCauseOfDeath.txtDLC.Text = string.Empty;
                        objDLCFamilyDisease.Enable = false;
                        objDLCFamilyDisease.txtDLC.Text = string.Empty;
                    }
                    else
                    {
                        if (objChkBox != null)
                            objChkBox.Checked = true;
                        objRadTextBox.Enabled = true;
                        if (FamDto.Family_History != null && FamDto.Family_History.Count > 0)
                            objRadComboBox.SelectedIndex = objRadComboBox.FindItemIndexByText(FamDto.Family_History.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Status);
                        //code added by balaji.TJ
                        if (FamDto.Family_History != null && FamDto.Family_History.Count > 0 && FamDto.Family_History.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Status.Trim().ToUpper() == "DECEASED")
                        {
                            objCustomDLCCauseOfDeath.Enable = true;
                            objCustomDLCCauseOfDeath.txtDLC.Text = FamDto.Family_History.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Cause_Of_Death;
                        }
                        else
                        {
                            objCustomDLCCauseOfDeath.Enable = false;
                            objCustomDLCCauseOfDeath.txtDLC.Text = string.Empty;
                        }
                        objDLCFamilyDisease.Enable = true;
                        string value = string.Empty;
                        //code added by balaji.TJ 2015-11-18
                        ulong ID = 0;
                        if (FamDto.Family_History != null && FamDto.Family_History.Count > 0)
                            ID = FamDto.Family_History.Where(a => a.RelationShip.Replace(" ", "").Trim() == item.Value.Replace(" ", "").Trim()).ToList()[0].Id;
                        if (ID > 0)
                        {
                            //string[] aryValue=FamDto.Family_Disease
                            //code added by balaji.TJ 2015-11-18
                            IList<FamilyDisease> FamilyDiseaselst = new List<FamilyDisease>();
                            if (FamDto.Family_Disease != null && FamDto.Family_Disease.Count > 0)
                                FamilyDiseaselst = FamDto.Family_Disease.Where(a => a.Family_History_ID == ID).ToList<FamilyDisease>();

                            if (FamilyDiseaselst != null && FamilyDiseaselst.Count > 0)
                            {
                                foreach (FamilyDisease items in FamilyDiseaselst.ToList())
                                {
                                    if (value.Trim() == string.Empty && items.Disease != string.Empty)
                                        value = items.Disease;
                                    else if (value.Trim() != string.Empty && items.Disease != string.Empty)
                                        value += "," + items.Disease;
                                }
                            }
                        }

                        objDLCFamilyDisease.txtDLC.Text = value;
                    }

                }
                
            }
        }

        protected void btnUnCheckCheckBox_Click(object sender, EventArgs e)
        {
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            foreach (KeyValuePair<ulong, string> item in dictionary.ToArray())
            {
                CheckBox objCheckBox = ((CheckBox)divFamilyHistory.FindControl("chk" + item.Value.Replace(" ", "")));
                CustomDLCNew DlcNew = ((CustomDLCNew)divFamilyHistory.FindControl("DLCFamilyDisease" + item.Value.Replace(" ", "")));
                CustomDLCNew DlcFamilyDeath = ((CustomDLCNew)divFamilyHistory.FindControl("DLCCauseOfDeath" + item.Value.Replace(" ", "")));
                RadComboBox objdropdown = ((RadComboBox)divFamilyHistory.FindControl("cbo" + item.Value.Replace(" ", "")));
                if (objCheckBox != null && !objCheckBox.Checked)
                {
                    // DlcNew.Enable = true;
                    if (DlcNew != null)
                    {
                        DlcNew.Enable = false;

                        DlcNew.txtDLC.Enabled = false;
                    }
                    if (DlcFamilyDeath != null)
                    {
                        DlcFamilyDeath.Enable = false;

                        DlcFamilyDeath.txtDLC.Enabled = false;

                        DlcFamilyDeath.pbDropdown.Disabled = true;
                        DlcFamilyDeath.pbDropdown.Style.Add("background", "#808080 !important");
                        DlcFamilyDeath.pbDropdown.Style.Add("background-color", "#808080 !important");
                    }

                }
                if (objdropdown != null && objdropdown.SelectedIndex != 2 && DlcFamilyDeath != null)
                {
                    DlcFamilyDeath.Enable = false;
                    DlcFamilyDeath.txtDLC.Enabled = false;
                    DlcFamilyDeath.pbDropdown.Disabled = true;
                    DlcFamilyDeath.pbDropdown.Style.Add("background", "#808080 !important");
                    DlcFamilyDeath.pbDropdown.Style.Add("background-color", "#808080 !important");


                }
            }
        }
        protected void btnUnCheckCheckBoxCancel_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region Methods

        public IList<string> LoadStatus()
        {
            //code added by balaji.TJ
            IList<StaticLookup> Staticlist = new List<StaticLookup>();
            if (Session["stFieldLook"] != null)
                Staticlist = (IList<StaticLookup>)Session["stFieldLook"];
            Staticlist = Staticlist.Where(a => a.Field_Name == "RELATION STATUS").ToList(); //added by balaji.TJ 2015-11-20
            //IList<StaticLookup> Staticlist = objStaticLookupManager.getStaticLookupByFieldName("RELATION STATUS", "Sort_Order"); //code comment by balaji.TJ
            lst = new List<string>();
            lst.Add(" ");
            if (Staticlist != null && Staticlist.Count > 0)
            {
                for (int j = 0; j < Staticlist.Count; j++)
                    lst.Add(Staticlist[j].Value);
            }
            return lst;
        }

        public bool DuplicateGeneralNotes()
        {
            string[] aryValue = DLC.txtDLC.Text.Split(',');
            HashSet<string> Hashset = new HashSet<string>(aryValue.Select(a => a.Trim()));
            if (aryValue.Length != Hashset.Count)
                return true;

            return false;
        }

        #endregion

    }
}
