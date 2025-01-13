using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.Core.DTOJson;
using Acurus.Capella.DataAccess.ManagerObjects;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Acurus.Capella.PatientPortal
{
    public partial class frmGenerateLink : System.Web.UI.Page
    {
        string origialpath = "";
        string requststring = "";
        ulong indexid = 0;
        string Document = "";
        string DocumentSubType = "";
        DateTime dtScanreceivedDate = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            //btngenerate.Enabled = false;
            if (Request.QueryString["path"] != null)
            {
                requststring = Request.QueryString["path"].ToString();
                //  origialpath = requststring.Split('@')[0];
                //  if (requststring.Split('@').Length > 1355)
                // indexid = Convert.ToUInt64(requststring.Split('@')[1]);
            }
            if (Request.QueryString["Document"] != null)
            {
                Document = Request.QueryString["Document"].ToString();
            }
            if (Request.QueryString["DocumentSubType"] != null)
            {
                DocumentSubType = Request.QueryString["DocumentSubType"].ToString();

            }
            if (Request.QueryString["DocumentDate"] != null)
            {
                dtScanreceivedDate = Convert.ToDateTime(Request.QueryString["DocumentDate"]);

            }
        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            try
            {
                FTPImageProcess objfrp = new FTPImageProcess();
                //  string ftpServerIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
                //string file_location = System.Configuration.ConfigurationSettings.AppSettings["XMLPath"];
                //  DirectoryInfo virdir = new DirectoryInfo(Server.MapPath("atala-capture-download//" + Session.SessionID + "//Advance_Directive"));
                //  if (!virdir.Exists)
                //  {
                // virdir.Create();
                // }
                //   string file_location = virdir.ToString();
                //  bool status = objfrp.DownloadFromImageServer(ClientSession.HumanId.ToString(), ftpServerIP, "", "", Path.GetFileName(origialpath), file_location);
                //   string SourcePath = file_location + "\\" + Path.GetFileName(origialpath);
                PdfReader reader = new PdfReader(requststring);


                //Get the file Information of the source file            
                //FileInfo finfo = new FileInfo(origialpath);

                string path = Path.GetFullPath(requststring.Replace(Path.GetFileName(requststring), "")) + "\\" + "test1.pdf";

                //Apply the Password            
                PdfStamper stamper = new PdfStamper(reader, new FileStream(path, FileMode.Create));
                stamper.SetEncryption(PdfWriter.STANDARD_ENCRYPTION_128, txtsetpassword.Text, txtsetpassword.Text,
                PdfWriter.AllowCopy | PdfWriter.AllowPrinting);
                stamper.Close();
                reader.Close();
                File.Copy(path, requststring, true);

                //Delete the Intermediate file            
                File.Delete(path);
                // string filedirectorypath = objfrp.UploadToADfiletoServer(ClientSession.HumanId.ToString(), SourcePath);







                IList<Scan> ScanSavelist = ((IList<Scan>)HttpContext.Current.Session["BrowseLoadList"]);
                if (ScanSavelist == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "FileAlert", "alert('Please choose any file.');", true);
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "StopLoadingImage", "StopLoadOnUploadFile();", true);
                    return;
                }
                if (ScanSavelist != null && Document.Trim() != "" && DocumentSubType.Trim() != "")
                {
                    //if (ScanSavelist.Count > 0)
                    //{
                    //    if (cboDocumentType.SelectedValue.Trim().ToUpper() == "LEGAL DOCUMENTS")
                    //    {
                    //        if ((cboDocumentSubType.SelectedValue.Trim().ToUpper() == "ADVANCE DIRECTIVE" || cboDocumentSubType.SelectedValue.Trim().ToUpper() == "BIRTH PLAN") && Path.GetExtension(ScanSavelist[0].Scanned_File_Name).ToUpper() != ".PDF")
                    //        {
                    //            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "ADAlert", "alert('Selected Subdocument type allows only PDF files.');", true);
                    //            return;
                    //        }
                    //    }
                    //}
                    IList<Scan> insertSavelist = new List<Scan>();

                    int pageCount = 0;
                    string file_name = string.Empty;
                    DateTime dtDocDate = UtilityManager.ConvertToUniversal();
                    string ChoosedFilename = string.Empty;


                    //Getting total no of  page count 
                    string sDirPath = Server.MapPath("~/atala-capture-upload/Indexing_Files/");
                    if (ScanSavelist.Count > 0)
                    {
                        FileInfo item = new FileInfo(Path.Combine(sDirPath, ScanSavelist[0].Scanned_File_Name));
                        ChoosedFilename = ScanSavelist[0].Scanned_File_Name;

                        if (Path.GetExtension(ChoosedFilename).ToUpper() != ".PDF")
                        {
                            using (System.Drawing.Image imgbg = System.Drawing.Image.FromFile(item.FullName))
                            {
                                pageCount = imgbg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                                imgbg.Dispose();
                            }
                        }
                        else
                        {
                            using (FileStream fs = new FileStream(item.FullName, FileMode.Open, FileAccess.Read))
                            {
                                StreamReader sr = new StreamReader(fs);
                                string pdf = sr.ReadToEnd();
                                Regex rx = new Regex(@"/Type\s*/Page[^s]");
                                MatchCollection match = rx.Matches(pdf);
                                pageCount = match.Count;
                                if (pageCount == 0)
                                {

                                    PdfReader pdfReader = new PdfReader(item.FullName);
                                    pageCount = pdfReader.NumberOfPages;

                                }
                                sr.Dispose();
                                fs.Dispose();
                            }
                        }
                    }

                    //File Name creation
                    string lastNumToAdd = string.Empty;
                    int prevNum = 0;
                    Scan_IndexManager objScanIndexMngr = new Scan_IndexManager();
                    IList<scan_index> ilstScanindex = new List<scan_index>();

                    ilstScanindex = objScanIndexMngr.GetScanIndexForHuman(ClientSession.HumanId);
                    if (ilstScanindex != null && ilstScanindex.Count > 0)
                    {
                        int[] sortIndexNum = new int[ilstScanindex.Count];
                        for (int i = 0; i < ilstScanindex.Count; i++)
                        {
                            file_name = Path.GetFileName(ilstScanindex[i].Indexed_File_Path);
                            prevNum = Convert.ToInt32(file_name.Substring(file_name.LastIndexOf("_") + 1, (file_name.LastIndexOf(".") - 1) - file_name.LastIndexOf("_")));
                            sortIndexNum[i] = prevNum;
                        }
                        prevNum = sortIndexNum.Max();
                        hdnNo.Value = Convert.ToString(prevNum + 1);
                        lastNumToAdd = Convert.ToString(prevNum + 1);
                        if (lastNumToAdd.Length == 1)
                            lastNumToAdd = "0" + lastNumToAdd;
                    }
                    else
                    {
                        hdnNo.Value = 1.ToString();
                        lastNumToAdd = hdnNo.Value;
                        if (lastNumToAdd.Length == 1)
                            lastNumToAdd = "0" + lastNumToAdd;

                    }
                    file_name = "Patient_portal_ONLINE_" + dtDocDate.ToString("yyyyMMdd") + "_" + ClientSession.HumanId.ToString() + "_" + lastNumToAdd + Path.GetExtension(ChoosedFilename);

                    //Move to local folder 
                    string sourceFile = Server.MapPath("~/atala-capture-upload/Indexing_Files/") + ChoosedFilename;
                    string drt_path = Server.MapPath("~/atala-capture-upload/Indexing_Files/Patient_Portal") + "\\" + ClientSession.HumanId.ToString();
                    string filePath = Server.MapPath("~/atala-capture-upload/Indexing_Files/Patient_Portal") + "\\" + ClientSession.HumanId.ToString() + "\\" + Path.GetFileName(file_name);
                    string LocalfilePath = "~/atala-capture-upload/Indexing_Files/Patient_Portal" + "\\" + ClientSession.HumanId.ToString() + "\\" + Path.GetFileName(file_name);
                    DirectoryInfo dirt = new DirectoryInfo(drt_path);
                    if (!dirt.Exists)
                    {
                        dirt.Create();
                    }
                    System.IO.File.Copy(sourceFile, filePath, true);

                    //Scan index  conversion save
                    scan_index scanIndexObject = new scan_index();
                    IList<scan_index> ScanConversionInserlist = new List<scan_index>();
                    objScanIndexMngr = new Scan_IndexManager();
                    Scan_IndexDTO AddedListOfScanIndex = null;


                    scanIndexObject.Indexed_File_Path = LocalfilePath;
                    scanIndexObject.Page_Selected = pageCount.ToString();
                    scanIndexObject.Document_Type = Document;
                    scanIndexObject.Document_Sub_Type = DocumentSubType;
                    scanIndexObject.Document_Date = dtDocDate;
                    scanIndexObject.Created_By = ClientSession.UserName;
                    scanIndexObject.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                    scanIndexObject.Human_ID = ClientSession.HumanId;
                    ScanConversionInserlist.Add(scanIndexObject);

                    //For Patient portal there is no facility to get the Close_type from workflow ,So get any facility from config Xml

                    string facility = string.Empty;
                    //Cap - 2769 - XML to JSON
                    //XmlDocument xmldoc = new XmlDocument();
                    //string strXmlFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\Facility_Library.xml");
                    //if (File.Exists(strXmlFilePath) == true)
                    //{
                    //    xmldoc.Load(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "ConfigXML\\" + "Facility_Library" + ".xml");
                    //    XmlNodeList xmlFacilityList = xmldoc.GetElementsByTagName("Facility");
                    //    if (xmlFacilityList.Count > 0)
                    //    {
                    //        facility = xmlFacilityList[0].Attributes["Name"].Value.ToString();

                    //    }
                    //}
                    IList<FacilityList> ilistFacilityList = new List<FacilityList>();
                    Facility_Library ilistFacility_Library = new Facility_Library();
                    ilistFacility_Library = ConfigureBase<Facility_Library>.ReadJson("Facility_Library.json");
                    if (ilistFacility_Library != null)
                    {
                        ilistFacilityList = ilistFacility_Library.FacilityList;
                    }
                    if ((ilistFacilityList?.Count ?? 0) > 0)
                    {
                        facility = ilistFacilityList[0].Name.ToString();
                    }



                    //Save Scan_Index_Conversion table, Scan table ,WorkFlow table 
                    AddedListOfScanIndex = objScanIndexMngr.SaveUpdateDeleteOnlineDocuments(ScanConversionInserlist, null, null, ClientSession.HumanId, 0, string.Empty, string.Empty, facility, LocalfilePath, pageCount, ChoosedFilename, dtScanreceivedDate, "Online Chart - LOCAL");

                    //Move to Next process

                    string uri = string.Empty;
                    IList<FileManagementIndex> fileManagementIndexList = new List<FileManagementIndex>();
                    IList<WFObject> lstWF_object = new List<WFObject>();
                    FileManagementIndexManager fileManagementIndexmanager = new FileManagementIndexManager();
                    IList<scan_index> scanIndexList = ScanConversionInserlist;

                    ulong scan_ID = 0;
                    if (scanIndexList.Count > 0)
                    {
                        scan_ID = scanIndexList[0].Scan_ID;
                    }
                    ulong[] uScanID = new ulong[scanIndexList.Count];



                    #region FTP Transfer
                    string ftpServerIP = System.Configuration.ConfigurationManager.AppSettings["ftpServerIP"];
                    string ftpUserName = System.Configuration.ConfigurationManager.AppSettings["ftpUserID"];
                    string ftpPassword = System.Configuration.ConfigurationManager.AppSettings["ftpPassword"];
                    FTPImageProcess _ftpImageProcess = new FTPImageProcess();
                    string serverPath = string.Empty;
                    string serverPathAD = string.Empty;

                    if (_ftpImageProcess.CreateDirectory(ClientSession.HumanId.ToString(), ftpServerIP, ftpUserName, ftpPassword))
                    {
                        for (int i = 0; i < scanIndexList.Count; i++)
                        {
                            serverPath = _ftpImageProcess.UploadToImageServer(ClientSession.HumanId.ToString(), ftpServerIP, ftpUserName, ftpPassword, Server.MapPath(scanIndexList[i].Indexed_File_Path), string.Empty);
                            serverPathAD = _ftpImageProcess.UploadToADfiletoServerIndexing(ClientSession.HumanId.ToString(), Server.MapPath(scanIndexList[i].Indexed_File_Path));

                            if (serverPath != string.Empty)
                            {
                                FileManagementIndex filemanagementIndex = new FileManagementIndex();
                                filemanagementIndex.Created_By = scanIndexList[i].Created_By;
                                filemanagementIndex.Created_Date_And_Time = UtilityManager.ConvertToUniversal();
                                filemanagementIndex.Document_Date = scanIndexList[i].Document_Date;
                                filemanagementIndex.Document_Type = scanIndexList[i].Document_Type;
                                filemanagementIndex.Document_Sub_Type = scanIndexList[i].Document_Sub_Type;
                                filemanagementIndex.Source = "SCAN";
                                filemanagementIndex.Human_ID = scanIndexList[i].Human_ID;
                                filemanagementIndex.Order_ID = scanIndexList[i].Order_ID;
                                filemanagementIndex.Scan_Index_Conversion_ID = scanIndexList[i].Id;
                                filemanagementIndex.File_Path = serverPath;
                                filemanagementIndex.Encounter_ID = scanIndexList[i].Encounter_ID;
                                filemanagementIndex.Generate_Link_File_Path = serverPathAD;
                                uScanID[i] = scanIndexList[i].Scan_ID;
                                fileManagementIndexList.Add(filemanagementIndex);
                                txtlink.Text = serverPathAD;

                            }



                            #region "Scanned File Trashing"
                            try
                            {
                                File.Delete(Server.MapPath(scanIndexList[i].Indexed_File_Path));
                            }
                            catch
                            {

                            }
                            #endregion
                        }
                    }
                    #endregion
                    fileManagementIndexmanager.SaveUpdateDeleteFileManagementIndexForOnline_and_Wfobject(fileManagementIndexList.ToArray(), uScanID, ApplicationObject.macAddress, UtilityManager.ConvertToUniversal());
                    //  ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "DisplayAlert", "clickClearAll();alert('Files are uploaded successfully.');", true);
                    // btnSaveOnline.Enabled = false;
                    //string filedirectorypath = "";
                    //if (fileManagementIndexList.Count > 0)
                    //{
                    //    filedirectorypath = objfrp.UploadToADfiletoServer(ClientSession.HumanId.ToString(), fileManagementIndexList[0].File_Path);



                    //    IList<FileManagementIndex> lstfile = new List<FileManagementIndex>();
                    //    IList<FileManagementIndex> lstfileinsert = new List<FileManagementIndex>();

                    //    FileManagementIndex objFileManagementIndex = new FileManagementIndex();

                    //    FileManagementIndexManager objIFileManagementIndexManager = new FileManagementIndexManager();

                    //    objFileManagementIndex = objIFileManagementIndexManager.GetById(Convert.ToUInt64(fileManagementIndexList[0].Id));
                    //    if (objFileManagementIndex != null)
                    //    {
                    //        objFileManagementIndex.Generate_Link_File_Path = filedirectorypath;

                    //        lstfile.Add(objFileManagementIndex);

                    //        objIFileManagementIndexManager.SaveUpdateDeleteWithTransaction(ref lstfileinsert, lstfile, null, "");

                    //    }
                    //}
                    btngenerate.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "unload", "disablebtnGenerate();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "btnUploadClick", "alert(Please selecr file to upload);", true);
                    return;
                }

                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "StopLoadingImage", "StopLoadOnUploadFile();", true);
            }
            catch (BadPasswordException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "unload", " alert('Password was already set for this file.');unloadwaitcursor();", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "unload", "unloadwaitcursor();", true);
            }
        }
    }
}