//using System;
//using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.IO;
//using Acurus.Capella.Core.DomainObjects;
//using System.Xml;
//using Acurus.Capella.DataAccess.ManagerObjects;
//using System.Threading;

////Added by Selvaraman - 04-May-11
//namespace Acurus.Capella.UI.RCopia
//{
//    public partial class RCopiaSessionManager
//    {
//        public string UploadAddress = "DEFAULT";
//        public string DownloadAddress = "DEFAULT";
//        public string RCopiaSessionAddress = string.Empty;

//        private XmlDocument urlxmldoc = new XmlDocument();

//        public string sOldURL = string.Empty;
//        public string sRCopiaLog = string.Empty;

//        Rcopia_Update_info rcopiaUpdateInfoANS1 = null;
//        Rcopia_Update_info rcopiaUpdateInfoANS2 = null;
//        Rcopia_Update_info rcopiaUpdateInfoGETURL = null;
//        Rcopia_Update_info rcopiaCheckConnection = null;
//        Rcopia_Update_InfoManager rcopiaProxy = new Rcopia_Update_InfoManager();
//        IList<Rcopia_Update_info> rcopiaUpdateList = new List<Rcopia_Update_info>();

//        public RCopiaSessionManager()
//        {
//            if (System.Configuration.ConfigurationSettings.AppSettings["RCopiaLogPathName"] != null)
//            {
//                sRCopiaLog = System.Configuration.ConfigurationSettings.AppSettings["RCopiaLogPathName"];
//            }
//            rcopiaUpdateList = rcopiaProxy.GetRcopiaUpdateInfo();
//            if (rcopiaUpdateList.Count == 0)
//            {
//                return;
//            }
//            rcopiaUpdateInfoANS1 = (from g in rcopiaUpdateList where g.Command == "ANS1" select g).ToList<Rcopia_Update_info>()[0];
//            rcopiaUpdateInfoANS2 = (from g in rcopiaUpdateList where g.Command == "ANS2" select g).ToList<Rcopia_Update_info>()[0];
//            rcopiaUpdateInfoGETURL = (from g in rcopiaUpdateList where g.Command == "get_url" select g).ToList<Rcopia_Update_info>()[0];
//            //ClientSession.RCopiaConnection = (from g in rcopiaUpdateList where g.Command == "check_connection" select g).ToList<Rcopia_Update_info>()[0].Value;

//            GetURLAddressList(rcopiaUpdateInfoANS1.Value, false);
//        }

//        //Added by Selvaraman
//        //BugID:51252 --switch between uploadAddress and downloadAddress acc. to uri
//        public string HttpPost(string uri, int iAttempt)
//        {
//            //if (Proxy.Util.NetworkUtil.CheckRCopiaInternetConnection() == false)
//            //{
//            //    System.Windows.Forms.MessageBox.Show("RCopia Server connection is failed. Cannot connect with E-Prescription");
//            //    return string.Empty;
//            //}

//            if (iAttempt == 1 && uri.Contains("http") == false)
//            {
//                if (uri.Contains("<Command>send_") == true)
//                {
//                    uri = UploadAddress + "?xml=" + uri;
//                }
//                else if (uri.Contains("<Command>update_") == true)
//                {
//                    uri = DownloadAddress + "?xml=" + uri;
//                }
//                else
//                {
//                    uri = UploadAddress + "?xml=" + uri;
//                }
//            }

//            //Replace Escape Codes - Refer http://www.december.com/html/spec/esccodes.html
//            //uri = uri.Replace("<", "%3C");
//            //uri = uri.Replace(">", "%3E");
//            uri = uri.Replace("#", "%23");
//            //uri = uri.Replace("%", "%25");
//            //uri = uri.Replace("{", "%7B");
//            //uri = uri.Replace("}", "%7D");
//            //uri = uri.Replace("|", "%7C");
//            //uri = uri.Replace("^", "%5E");
//            //uri = uri.Replace("~", "%7E");

//            //uri = uri.Replace("[", "%5B");
//            //uri = uri.Replace("]", "%5D");
//            //uri = uri.Replace("`", "%60");
//            //uri = uri.Replace(";", "%3B");
//            //uri = uri.Replace("/", "%2F");
//            //uri = uri.Replace("?", "%3F");
//            //uri = uri.Replace(":", "%3A");
//            //uri = uri.Replace("@", "%40");
//            //uri = uri.Replace("=", "%3D");
//            //uri = uri.Replace("&", "%26");
//            //uri = uri.Replace("$", "%24");

//            // parameters: name1=value1&name2=value2	
//            WebRequest webRequest;
//            try
//            {
//                webRequest = WebRequest.Create(uri);
//            }
//            catch
//            {
//                return string.Empty;
//            }
//            //string ProxyString = 
//            //   System.Configuration.ConfigurationManager.AppSettings
//            //   [GetConfigKey("proxy")];
//            //webRequest.Proxy = new WebProxy (ProxyString, true);
//            //Commenting out above required change to App.Config
//            webRequest.ContentType = "application/x-www-form-urlencoded";
//            webRequest.Method = "POST";
//            webRequest.UseDefaultCredentials = true;


//            //byte[] bytes = Encoding.ASCII.GetBytes (parameters);
//            Stream os = null;
//            try
//            { // send the Post
//                //webRequest.ContentLength = bytes.Length;   //Count bytes to send
//                os = webRequest.GetRequestStream();
//                //os.Write (bytes, 0, bytes.Length);         //Send it
//            }
//            catch (WebException ex)
//            {
//                //MessageBox.Show(ex.Message, "HttpPost: Request error",
//                //   MessageBoxButtons.OK, MessageBoxIcon.Error);

//                //New Code - to Proceed only with the Capella transactions and ignore the RCopia transaction, if the request fails
//                //Changes made to let the capella production go
//                //Need to remove the following one line - if go for RCopia Certification
//                //Start
//                return string.Empty;
//                //End

//                if (iAttempt <= 3)
//                {
//                    string sLog = string.Empty;
//                    try
//                    {
//                        XmlDocument xmldoc = new XmlDocument();
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress, ""));
//                            }
//                        }
//                        else
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        XmlNodeList xmllist = xmldoc.GetElementsByTagName("Command");
//                        sLog = xmllist[0].Value + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
//                        xmllist = xmldoc.GetElementsByTagName("ExternalID");
//                        sLog = sLog + xmllist[0].InnerText;
//                    }
//                    catch
//                    {
//                        sLog = ex.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
//                    }
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();

//                    iAttempt = iAttempt + 1;
//                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
//                    HttpPost(uri, iAttempt);
//                }
//                else if (iAttempt == 5)
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                }
//                else
//                {
//                    if (uri.Contains("<Command>send_") == true)
//                    {
//                        sOldURL = UploadAddress;
//                    }
//                    else if (uri.Contains("<Command>update_") == true)
//                    {
//                        sOldURL = DownloadAddress;
//                    }
//                    else
//                    {
//                        sOldURL = UploadAddress;
//                    }
//                    //sOldURL = UploadAddress;
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                    if (sOldURL == "DEFULAT")
//                    {
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            uri = uri.Replace(sOldURL, UploadAddress);
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            uri = uri.Replace(sOldURL, DownloadAddress);
//                        }
//                        else
//                        {
//                            uri = uri.Replace(sOldURL, UploadAddress);
//                        }
//                        //uri = uri.Replace(sOldURL, UploadAddress);
//                    }
//                    else
//                    {
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            uri = UploadAddress;
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            uri = DownloadAddress;
//                        }
//                        else
//                        {
//                            uri = UploadAddress;
//                        }
//                        //uri = UploadAddress;
//                    }
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    string sLog = string.Empty;
//                    sLog = "ANS2 returned successful response. URLs updated at " + DateTime.Now;
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();
//                    HttpPost(uri, 5);
//                }
//            }
//            catch (Exception e)
//            {
//                //MessageBox.Show(e.InnerException.ToString());

//                if (iAttempt <= 3)
//                {
//                    string sLog = string.Empty;
//                    try
//                    {
//                        XmlDocument xmldoc = new XmlDocument();
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress, ""));
//                            }
//                        }
//                        else
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        //xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                        XmlNodeList xmllist = xmldoc.GetElementsByTagName("Command");
//                        sLog = xmllist[0].Value + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
//                        xmllist = xmldoc.GetElementsByTagName("ExternalID");
//                        sLog = sLog + xmllist[0].InnerText;
//                    }
//                    catch
//                    {
//                        sLog = e.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
//                    }
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();

//                    iAttempt = iAttempt + 1;
//                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
//                    HttpPost(uri, iAttempt);
//                }
//                else if (iAttempt == 5)
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                }
//                else
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                    HttpPost(uri, 5);
//                }
//            }
//            finally
//            {
//                if (os != null)
//                {
//                    os.Close();
//                }
//            }

//            try
//            { // get the response
//                WebResponse webResponse = webRequest.GetResponse();
//                if (webResponse == null)
//                { return null; }
//                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
//                //MessageBox.Show(sr.ReadToEnd());
//                string sResult = sr.ReadToEnd().Trim();

//                if (sResult.Contains("<Error>") == true)
//                {
//                    XmlDocument xmldoc = new XmlDocument();
//                    xmldoc.LoadXml(sResult);
//                    XmlNodeList xmllist = xmldoc.GetElementsByTagName("Error");
//                    //MessageBox.Show(xmllist[0].InnerText);
//                    string sLog = string.Empty;
//                    sLog = "Error Text: " + xmllist[0].InnerText;
//                    xmllist = xmldoc.GetElementsByTagName("Command");
//                    sLog = sLog + " - Error at : " + xmllist[0].InnerText;
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    sLog = sLog + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
//                    xmllist = xmldoc.GetElementsByTagName("ExternalID");
//                    sLog = sLog + xmllist[0].InnerText;
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();
//                    return sResult;
//                }
//                else
//                {
//                    return sResult;
//                }
//            }
//            catch (WebException ex)
//            {
//                //MessageBox.Show(ex.Message, "HttpPost: Response error",
//                //   MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception e)
//            {
//                //MessageBox.Show(e.InnerException.ToString());
//            }


//            return null;
//        }

//        //Added by Selvaraman
//        public string URLPost(string uri, int iAttempt)
//        {
//            //if (Proxy.Util.NetworkUtil.CheckRCopiaInternetConnection() == false)
//            //{
//            //    System.Windows.Forms.MessageBox.Show("RCopia Server connection is failed. Cannot connect with E-Prescription");
//            //    return string.Empty;
//            //}

//            string sResult = string.Empty;
//            if (iAttempt == 1 && uri.Contains("http") == false)
//            {
//                uri = UploadAddress + "?xml=" + uri;
//            }

//            try
//            {
//                WebRequest webReq = WebRequest.Create(uri);

//                WebResponse webResp = webReq.GetResponse();

//                Stream str = webResp.GetResponseStream();
//                StreamReader srread = new StreamReader(str);
//                sResult = srread.ReadToEnd();
//            }
//            catch (Exception e)
//            {
//                //New Code - to Proceed only with the Capella transactions and ignore the RCopia transaction, if the request fails
//                //Changes made to let the capella production go
//                //Need to remove the following one line - if go for RCopia Certification
//                //Start
//                return string.Empty;
//                //End

//                if (iAttempt <= 3)
//                {
//                    string sLog = string.Empty;
//                    sLog = e.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();

//                    iAttempt = iAttempt + 1;
//                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
//                    URLPost(uri, iAttempt);
//                }
//                else if (iAttempt == 5)
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                }
//                else
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                    URLPost(uri, 5);
//                }
//            }
//            return sResult;
//        }

//        public void GetURLAddressList(string GetURL, Boolean bForce)
//        {
//            try
//            {

//                if (GetURL == null)
//                {
//                    return;
//                }

//                XmlNodeList xmlReqNode = null;
//                Rcopia_Update_info rcopiaUpdateInfo = null;
//                RCopiaGenerateXML rcopiaXML = new RCopiaGenerateXML();
//                RCopiaXMLResponseProcess rcopiaResponseXML = new RCopiaXMLResponseProcess();
//                string sInputXML = string.Empty;
//                string sResponseXML = string.Empty;

//                //To get the list of URL Address
//                //Check the URL GetDateTime
//                IList<Rcopia_Update_info> TemprcopiaUpdateList = new List<Rcopia_Update_info>();
//                //Rcopia_Update_InfoManager rcopiUpdateMngr = new Rcopia_Update_InfoManager();
//                //IList<Rcopia_Update_info> rcopiaUpdateList = rcopiUpdateMngr.GetRcopiaUpdateInfo();
//                rcopiaUpdateInfo = (from g in rcopiaUpdateList where g.Command == "get_url" select g).ToList<Rcopia_Update_info>()[0];

//                if (rcopiaUpdateInfo.Last_Updated_Date_Time.Date != DateTime.Now.Date || bForce == true)
//                {
//                    sInputXML = rcopiaXML.CreateGetURLXML();
//                    sInputXML = sInputXML.Trim();
//                    sInputXML = sInputXML.Replace("\n", "");

//                    sResponseXML = URLPost(GetURL + sInputXML, 1);
//                    urlxmldoc.LoadXml(sResponseXML);
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineUploadURL");
//                    UploadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineDownloadURL");
//                    DownloadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("WebBrowserURL");
//                    RCopiaSessionAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?";
//                    rcopiaUpdateInfo.Value = sResponseXML;
//                    rcopiaUpdateInfo.Last_Updated_Date_Time = DateTime.Now;
//                    TemprcopiaUpdateList.Add(rcopiaUpdateInfo);
//                    rcopiaProxy.InsertinToRcopia_Update_info("get_url", DateTime.Now, sResponseXML, string.Empty);
//                }
//                else
//                {
//                    urlxmldoc.LoadXml(rcopiaUpdateInfo.Value);
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineUploadURL");
//                    UploadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineDownloadURL");
//                    DownloadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("WebBrowserURL");
//                    RCopiaSessionAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?";
//                    TextWriter tx = null;
//                    try
//                    {
//                        tx = new StreamWriter(sRCopiaLog, true);
//                        string sLog = string.Empty;
//                        sLog = "ANS not being called since successful response received at " + rcopiaUpdateInfo.Last_Updated_Date_Time;
//                        tx.WriteLine(sLog);
//                    }
//                    catch (Exception e)
//                    {

//                    }
//                    finally
//                    {
//                        tx.Close();
//                        tx.Dispose();
//                    }
//                }
//            }
//            catch
//            {

//            }
//        }
//    }
//}

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Acurus.Capella.Core.DomainObjects;
using System.Xml;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Threading;
using System.Security.Authentication;

//Added by Selvaraman - 04-May-11
namespace Acurus.Capella.UI.RCopia
{
    public partial class RCopiaSessionManager
    {
        public string UploadAddress = "DEFAULT";
        public string DownloadAddress = "DEFAULT";
        public string RCopiaSessionAddress = string.Empty;

        private static XmlDocument urlxmldoc = new XmlDocument();

        public string sRCopiaLog = string.Empty;

        Rcopia_Update_info rcopiaUpdateInfoANS1 = null;
        Rcopia_Update_info rcopiaUpdateInfoANS2 = null;
        Rcopia_Update_info rcopiaUpdateInfoGETURL = null;
        Rcopia_Update_InfoManager rcopiUpdateMngr = null;
        Rcopia_Update_InfoManager rcopiaProxy = new Rcopia_Update_InfoManager();
        IList<Rcopia_Update_info> rcopiaUpdateList = new List<Rcopia_Update_info>();

        public RCopiaSessionManager(string sLegalOrg)
        {
            if (System.Configuration.ConfigurationSettings.AppSettings["RCopiaLogPathName"] != null)
            {
                sRCopiaLog = System.Configuration.ConfigurationSettings.AppSettings["RCopiaLogPathName"];
            }
            rcopiaUpdateList = rcopiaProxy.GetRcopiaUpdateInfo();
            if (rcopiaUpdateList.Count == 0)
            {
                return;
            }
            rcopiaUpdateInfoANS1 = (from g in rcopiaUpdateList where g.Command == "ANS1" select g).ToList<Rcopia_Update_info>()[0];
            rcopiaUpdateInfoANS2 = (from g in rcopiaUpdateList where g.Command == "ANS2" select g).ToList<Rcopia_Update_info>()[0];
            rcopiaUpdateInfoGETURL = (from g in rcopiaUpdateList where g.Command == "get_url" select g).ToList<Rcopia_Update_info>()[0];

            if (rcopiaUpdateInfoGETURL.Value.Contains("RCExtResponse") == false)
            {
                UploadAddress = rcopiaUpdateInfoANS1.Value + "?xml=";
                DownloadAddress = rcopiaUpdateInfoANS2.Value + "?xml=";
                RCopiaSessionAddress = rcopiaUpdateInfoGETURL.Value + "?";
            }
            else
            {
                GetURLAddressList(rcopiaUpdateInfoANS1.Value, false,sLegalOrg);
            }
        }

        //Added by Selvaraman
        //BugID:51252 --switch between uploadAddress and downloadAddress acc. to uri
        public string HttpPost(string uri, int iAttempt)
        {
            //if (Proxy.Util.NetworkUtil.CheckRCopiaInternetConnection() == false)
            //{
            //    System.Windows.Forms.MessageBox.Show("RCopia Server connection is failed. Cannot connect with E-Prescription");
            //    return string.Empty;
            //}

            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            if (uri.Contains("http") == true)
            {
                string[] uriObj = uri.Split(new[] { "?xml=" }, StringSplitOptions.None);
                string sUriURL = uriObj[0] + "?xml=";
                string sUriReq = uriObj[1];

                sUriReq = sUriReq.Replace("<>", "&lt;&gt;");
                sUriReq = sUriReq.Replace("%", "%25");
                sUriReq = sUriReq.Replace("<", "%3C");
                sUriReq = sUriReq.Replace(">", "%3E");
                //sUriReq = sUriReq.Replace("&", "&amp;");
                sUriReq = sUriReq.Replace("#", "%23");
                sUriReq = sUriReq.Replace("{", "%7B");
                sUriReq = sUriReq.Replace("}", "%7D");
                sUriReq = sUriReq.Replace("|", "%7C");
                sUriReq = sUriReq.Replace("^", "%5E");
                sUriReq = sUriReq.Replace("~", "%7E");
                sUriReq = sUriReq.Replace("[", "%5B");
                sUriReq = sUriReq.Replace("]", "%5D");
                sUriReq = sUriReq.Replace("`", "%60");
                sUriReq = sUriReq.Replace(";", "%3B");
                sUriReq = sUriReq.Replace("/", "%2F");
                sUriReq = sUriReq.Replace("?", "%3F");
                sUriReq = sUriReq.Replace(":", "%3A");
                sUriReq = sUriReq.Replace("@", "%40");
                sUriReq = sUriReq.Replace("=", "%3D");
                sUriReq = sUriReq.Replace("&", "%26");
                sUriReq = sUriReq.Replace("$", "%24");

                uri = sUriURL + sUriReq;
            }

            if (iAttempt == 1 && uri.Contains("http") == false)
            {
                if (uri.Contains("<Command>send_") == true)
                {
                    uri = UploadAddress + "?xml=" + uri;
                }
                else if (uri.Contains("<Command>update_") == true)
                {
                    uri = DownloadAddress + "?xml=" + uri;
                }
                else
                {
                    uri = UploadAddress + "?xml=" + uri;
                }
            }

            //Replace Escape Codes - Refer http://www.december.com/html/spec/esccodes.html
            //uri = uri.Replace("<", "%3C");
            //uri = uri.Replace(">", "%3E");
            //uri = uri.Replace("#", "%23");
            //uri = uri.Replace("%", "%25");
            //uri = uri.Replace("{", "%7B");
            //uri = uri.Replace("}", "%7D");
            //uri = uri.Replace("|", "%7C");
            //uri = uri.Replace("^", "%5E");
            //uri = uri.Replace("~", "%7E");

            //uri = uri.Replace("[", "%5B");
            //uri = uri.Replace("]", "%5D");
            //uri = uri.Replace("`", "%60");
            //uri = uri.Replace(";", "%3B");
            //uri = uri.Replace("/", "%2F");
            //uri = uri.Replace("?", "%3F");
            //uri = uri.Replace(":", "%3A");
            //uri = uri.Replace("@", "%40");
            //uri = uri.Replace("=", "%3D");
            //uri = uri.Replace("&", "%26");
            //uri = uri.Replace("$", "%24");

            // parameters: name1=value1&name2=value2	
            WebRequest webRequest;
            try
            {
                webRequest = WebRequest.Create(uri);
            }
            catch
            {
                return string.Empty;
            }
            //string ProxyString = 
            //   System.Configuration.ConfigurationManager.AppSettings
            //   [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            webRequest.UseDefaultCredentials = true;


            //byte[] bytes = Encoding.ASCII.GetBytes (parameters);
            Stream os = null;
            try
            { // send the Post
                //webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                //os.Write (bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Request error",
                //   MessageBoxButtons.OK, MessageBoxIcon.Error);

                //New Code - to Proceed only with the Capella transactions and ignore the RCopia transaction, if the request fails
                //Changes made to let the capella production go
                //Need to remove the following one line - if go for RCopia Certification
                //Start
                return string.Empty;
                //End

                if (iAttempt <= 3)
                {
                    string sLog = string.Empty;
                    try
                    {
                        XmlDocument xmldoc = new XmlDocument();
                        if (uri.Contains("<Command>send_") == true)
                        {
                            if (UploadAddress.Contains("?xml=") == false)
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
                            }
                            else
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
                            }
                        }
                        else if (uri.Contains("<Command>update_") == true)
                        {
                            if (UploadAddress.Contains("?xml=") == false)
                            {
                                xmldoc.LoadXml(uri.Replace(DownloadAddress + "?xml=", ""));
                            }
                            else
                            {
                                xmldoc.LoadXml(uri.Replace(DownloadAddress, ""));
                            }
                        }
                        else
                        {
                            if (UploadAddress.Contains("?xml=") == false)
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
                            }
                            else
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
                            }
                        }
                        XmlNodeList xmllist = xmldoc.GetElementsByTagName("Command");
                        sLog = xmllist[0].Value + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
                        xmllist = xmldoc.GetElementsByTagName("ExternalID");
                        sLog = sLog + xmllist[0].InnerText;
                    }
                    catch
                    {
                        sLog = ex.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
                    }
                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
                    tx.WriteLine(sLog);
                    tx.Close();
                    tx.Dispose();

                    iAttempt = iAttempt + 1;
                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
                    HttpPost(uri, iAttempt);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.InnerException.ToString());

                if (iAttempt <= 3)
                {
                    string sLog = string.Empty;
                    try
                    {
                        XmlDocument xmldoc = new XmlDocument();
                        if (uri.Contains("<Command>send_") == true)
                        {
                            if (UploadAddress.Contains("?xml=") == false)
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
                            }
                            else
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
                            }
                        }
                        else if (uri.Contains("<Command>update_") == true)
                        {
                            if (UploadAddress.Contains("?xml=") == false)
                            {
                                xmldoc.LoadXml(uri.Replace(DownloadAddress + "?xml=", ""));
                            }
                            else
                            {
                                xmldoc.LoadXml(uri.Replace(DownloadAddress, ""));
                            }
                        }
                        else
                        {
                            if (UploadAddress.Contains("?xml=") == false)
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
                            }
                            else
                            {
                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
                            }
                        }
                        //xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
                        XmlNodeList xmllist = xmldoc.GetElementsByTagName("Command");
                        sLog = xmllist[0].Value + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
                        xmllist = xmldoc.GetElementsByTagName("ExternalID");
                        sLog = sLog + xmllist[0].InnerText;
                    }
                    catch
                    {
                        sLog = e.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
                    }
                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
                    tx.WriteLine(sLog);
                    tx.Close();
                    tx.Dispose();

                    iAttempt = iAttempt + 1;
                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
                    HttpPost(uri, iAttempt);
                }
                else
                {
                    //HttpPost(uri, 5);
                }
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                //MessageBox.Show(sr.ReadToEnd());
                string sResult = sr.ReadToEnd().Trim();

                if (sResult.Contains("<Error>") == true)
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(sResult);
                    XmlNodeList xmllist = xmldoc.GetElementsByTagName("Error");
                    //MessageBox.Show(xmllist[0].InnerText);
                    string sLog = string.Empty;
                    sLog = "Error Text: " + xmllist[0].InnerText;
                    xmllist = xmldoc.GetElementsByTagName("Command");
                    sLog = sLog + " - Error at : " + xmllist[0].InnerText;
                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
                    sLog = sLog + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
                    xmllist = xmldoc.GetElementsByTagName("ExternalID");
                    sLog = sLog + xmllist[0].InnerText;
                    tx.WriteLine(sLog);
                    tx.Close();
                    tx.Dispose();
                    return sResult;
                }
                else
                {
                    return sResult;
                }
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Response error",
                //   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch 
            {
                //MessageBox.Show(e.InnerException.ToString());
            }


            return null;
        }

        //Added by Selvaraman
        public string URLPost(string uri, int iAttempt)
        {
            //if (Proxy.Util.NetworkUtil.CheckRCopiaInternetConnection() == false)
            //{
            //    System.Windows.Forms.MessageBox.Show("RCopia Server connection is failed. Cannot connect with E-Prescription");
            //    return string.Empty;
            //}

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.DefaultConnectionLimit = 9999;

            string sResult = string.Empty;
            if (iAttempt == 1 && uri.Contains("http") == false)
            {
                uri = UploadAddress + "?xml=" + uri;
            }

            try
            {
                WebRequest webReq = WebRequest.Create(uri);

                WebResponse webResp = webReq.GetResponse();

                Stream str = webResp.GetResponseStream();
                StreamReader srread = new StreamReader(str);
                sResult = srread.ReadToEnd();
            }
            catch (Exception e)
            {
                //New Code - to Proceed only with the Capella transactions and ignore the RCopia transaction, if the request fails
                //Changes made to let the capella production go
                //Need to remove the following one line - if go for RCopia Certification
                //Start
                return string.Empty;
                //End

                if (iAttempt <= 3)
                {
                    string sLog = string.Empty;
                    sLog = e.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
                    tx.WriteLine(sLog);
                    tx.Close();
                    tx.Dispose();

                    iAttempt = iAttempt + 1;
                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
                    URLPost(uri, iAttempt);
                }
                else
                {
                    URLPost(uri, 5);
                }
            }
            return sResult;
        }

        public void GetURLAddressList(string GetURL, Boolean bForce, string sLegalOrg)
        {
            try
            {

                if (GetURL == null)
                {
                    return;
                }

                XmlNodeList xmlReqNode = null;
                Rcopia_Update_info rcopiaUpdateInfo = null;
                RCopiaGenerateXML rcopiaXML = new RCopiaGenerateXML();
                RCopiaXMLResponseProcess rcopiaResponseXML = new RCopiaXMLResponseProcess();
                string sInputXML = string.Empty;
                string sResponseXML = string.Empty;

                //To get the list of URL Address
                //Check the URL GetDateTime
                IList<Rcopia_Update_info> TemprcopiaUpdateList = new List<Rcopia_Update_info>();
                //Rcopia_Update_InfoManager rcopiUpdateMngr = new Rcopia_Update_InfoManager();
                //IList<Rcopia_Update_info> rcopiaUpdateList = rcopiUpdateMngr.GetRcopiaUpdateInfo();
                rcopiaUpdateInfo = (from g in rcopiaUpdateList where g.Command == "get_url" select g).ToList<Rcopia_Update_info>()[0];

                if (rcopiaUpdateInfo.Last_Updated_Date_Time.Date != DateTime.Now.Date || bForce == true)
                {
                    sInputXML = rcopiaXML.CreateGetURLXML(sLegalOrg);
                    sInputXML = sInputXML.Trim();
                    sInputXML = sInputXML.Replace("\n", "");

                    sResponseXML = URLPost(GetURL + sInputXML, 1);
                    urlxmldoc.LoadXml(sResponseXML);
                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineUploadURL");
                    UploadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineDownloadURL");
                    DownloadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
                    xmlReqNode = urlxmldoc.GetElementsByTagName("WebBrowserURL");
                    RCopiaSessionAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?";
                    rcopiaUpdateInfo.Value = sResponseXML;
                    rcopiaUpdateInfo.Last_Updated_Date_Time = DateTime.Now;
                    TemprcopiaUpdateList.Add(rcopiaUpdateInfo);
                    rcopiaProxy.InsertinToRcopia_Update_info("get_url", DateTime.Now, sResponseXML, string.Empty, sLegalOrg);
                }
                else
                {
                    urlxmldoc.LoadXml(rcopiaUpdateInfo.Value);
                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineUploadURL");
                    UploadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineDownloadURL");
                    DownloadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
                    xmlReqNode = urlxmldoc.GetElementsByTagName("WebBrowserURL");
                    RCopiaSessionAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?";
                    TextWriter tx = null;
                    try
                    {
                        tx = new StreamWriter(sRCopiaLog, true);
                        string sLog = string.Empty;
                        sLog = "ANS not being called since successful response received at " + rcopiaUpdateInfo.Last_Updated_Date_Time;
                        tx.WriteLine(sLog);
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        tx.Close();
                        tx.Dispose();
                    }
                }
            }
            catch
            {

            }
        }
    }
}





//using System;
//using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.IO;
//using Acurus.Capella.Core.DomainObjects;
//using System.Xml;
//using Acurus.Capella.DataAccess.ManagerObjects;
//using System.Threading;

////Added by Selvaraman - 04-May-11
//namespace Acurus.Capella.UI.RCopia
//{
//    public partial class RCopiaSessionManager
//    {
//        public string UploadAddress = "DEFAULT";
//        public string DownloadAddress = "DEFAULT";
//        public string RCopiaSessionAddress = string.Empty;

//        private XmlDocument urlxmldoc = new XmlDocument();

//        public string sOldURL = string.Empty;
//        public string sRCopiaLog = string.Empty;

//        Rcopia_Update_info rcopiaUpdateInfoANS1 = null;
//        Rcopia_Update_info rcopiaUpdateInfoANS2 = null;
//        Rcopia_Update_info rcopiaUpdateInfoGETURL = null;
//        Rcopia_Update_info rcopiaCheckConnection = null;
//        Rcopia_Update_InfoManager rcopiaProxy = new Rcopia_Update_InfoManager();
//        IList<Rcopia_Update_info> rcopiaUpdateList = new List<Rcopia_Update_info>();

//        public RCopiaSessionManager()
//        {
//            if (System.Configuration.ConfigurationSettings.AppSettings["RCopiaLogPathName"] != null)
//            {
//                sRCopiaLog = System.Configuration.ConfigurationSettings.AppSettings["RCopiaLogPathName"];
//            }
//            rcopiaUpdateList = rcopiaProxy.GetRcopiaUpdateInfo();
//            if (rcopiaUpdateList.Count == 0)
//            {
//                return;
//            }
//            rcopiaUpdateInfoANS1 = (from g in rcopiaUpdateList where g.Command == "ANS1" select g).ToList<Rcopia_Update_info>()[0];
//            rcopiaUpdateInfoANS2 = (from g in rcopiaUpdateList where g.Command == "ANS2" select g).ToList<Rcopia_Update_info>()[0];
//            rcopiaUpdateInfoGETURL = (from g in rcopiaUpdateList where g.Command == "get_url" select g).ToList<Rcopia_Update_info>()[0];
//            //ClientSession.RCopiaConnection = (from g in rcopiaUpdateList where g.Command == "check_connection" select g).ToList<Rcopia_Update_info>()[0].Value;

//            GetURLAddressList(rcopiaUpdateInfoANS1.Value, false);
//        }

//        //Added by Selvaraman
//        //BugID:51252 --switch between uploadAddress and downloadAddress acc. to uri
//        public string HttpPost(string uri, int iAttempt)
//        {
//            //if (Proxy.Util.NetworkUtil.CheckRCopiaInternetConnection() == false)
//            //{
//            //    System.Windows.Forms.MessageBox.Show("RCopia Server connection is failed. Cannot connect with E-Prescription");
//            //    return string.Empty;
//            //}

//            if (iAttempt == 1 && uri.Contains("http") == false)
//            {
//                if (uri.Contains("<Command>send_") == true)
//                {
//                    uri = UploadAddress + "?xml=" + uri;
//                }
//                else if (uri.Contains("<Command>update_") == true)
//                {
//                    uri = DownloadAddress + "?xml=" + uri;
//                }
//                else
//                {
//                    uri = UploadAddress + "?xml=" + uri;
//                }
//            }

//            //Replace Escape Codes - Refer http://www.december.com/html/spec/esccodes.html
//            //uri = uri.Replace("<", "%3C");
//            //uri = uri.Replace(">", "%3E");
//            uri = uri.Replace("#", "%23");
//            //uri = uri.Replace("%", "%25");
//            //uri = uri.Replace("{", "%7B");
//            //uri = uri.Replace("}", "%7D");
//            //uri = uri.Replace("|", "%7C");
//            //uri = uri.Replace("^", "%5E");
//            //uri = uri.Replace("~", "%7E");

//            //uri = uri.Replace("[", "%5B");
//            //uri = uri.Replace("]", "%5D");
//            //uri = uri.Replace("`", "%60");
//            //uri = uri.Replace(";", "%3B");
//            //uri = uri.Replace("/", "%2F");
//            //uri = uri.Replace("?", "%3F");
//            //uri = uri.Replace(":", "%3A");
//            //uri = uri.Replace("@", "%40");
//            //uri = uri.Replace("=", "%3D");
//            //uri = uri.Replace("&", "%26");
//            //uri = uri.Replace("$", "%24");

//            // parameters: name1=value1&name2=value2	
//            WebRequest webRequest;
//            try
//            {
//                webRequest = WebRequest.Create(uri);
//            }
//            catch
//            {
//                return string.Empty;
//            }
//            //string ProxyString = 
//            //   System.Configuration.ConfigurationManager.AppSettings
//            //   [GetConfigKey("proxy")];
//            //webRequest.Proxy = new WebProxy (ProxyString, true);
//            //Commenting out above required change to App.Config
//            webRequest.ContentType = "application/x-www-form-urlencoded";
//            webRequest.Method = "POST";
//            webRequest.UseDefaultCredentials = true;


//            //byte[] bytes = Encoding.ASCII.GetBytes (parameters);
//            Stream os = null;
//            try
//            { // send the Post
//                //webRequest.ContentLength = bytes.Length;   //Count bytes to send
//                os = webRequest.GetRequestStream();
//                //os.Write (bytes, 0, bytes.Length);         //Send it
//            }
//            catch (WebException ex)
//            {
//                //MessageBox.Show(ex.Message, "HttpPost: Request error",
//                //   MessageBoxButtons.OK, MessageBoxIcon.Error);

//                //New Code - to Proceed only with the Capella transactions and ignore the RCopia transaction, if the request fails
//                //Changes made to let the capella production go
//                //Need to remove the following one line - if go for RCopia Certification
//                //Start
//                return string.Empty;
//                //End

//                if (iAttempt <= 3)
//                {
//                    string sLog = string.Empty;
//                    try
//                    {
//                        XmlDocument xmldoc = new XmlDocument();
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress, ""));
//                            }
//                        }
//                        else
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        XmlNodeList xmllist = xmldoc.GetElementsByTagName("Command");
//                        sLog = xmllist[0].Value + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
//                        xmllist = xmldoc.GetElementsByTagName("ExternalID");
//                        sLog = sLog + xmllist[0].InnerText;
//                    }
//                    catch
//                    {
//                        sLog = ex.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
//                    }
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();

//                    iAttempt = iAttempt + 1;
//                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
//                    HttpPost(uri, iAttempt);
//                }
//                else if (iAttempt == 5)
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                }
//                else
//                {
//                    if (uri.Contains("<Command>send_") == true)
//                    {
//                        sOldURL = UploadAddress;
//                    }
//                    else if (uri.Contains("<Command>update_") == true)
//                    {
//                        sOldURL = DownloadAddress;
//                    }
//                    else
//                    {
//                        sOldURL = UploadAddress;
//                    }
//                    //sOldURL = UploadAddress;
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                    if (sOldURL == "DEFULAT")
//                    {
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            uri = uri.Replace(sOldURL, UploadAddress);
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            uri = uri.Replace(sOldURL, DownloadAddress);
//                        }
//                        else
//                        {
//                            uri = uri.Replace(sOldURL, UploadAddress);
//                        }
//                        //uri = uri.Replace(sOldURL, UploadAddress);
//                    }
//                    else
//                    {
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            uri = UploadAddress;
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            uri = DownloadAddress;
//                        }
//                        else
//                        {
//                            uri = UploadAddress;
//                        }
//                        //uri = UploadAddress;
//                    }
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    string sLog = string.Empty;
//                    sLog = "ANS2 returned successful response. URLs updated at " + DateTime.Now;
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();
//                    HttpPost(uri, 5);
//                }
//            }
//            catch (Exception e)
//            {
//                //MessageBox.Show(e.InnerException.ToString());

//                if (iAttempt <= 3)
//                {
//                    string sLog = string.Empty;
//                    try
//                    {
//                        XmlDocument xmldoc = new XmlDocument();
//                        if (uri.Contains("<Command>send_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        else if (uri.Contains("<Command>update_") == true)
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(DownloadAddress, ""));
//                            }
//                        }
//                        else
//                        {
//                            if (UploadAddress.Contains("?xml=") == false)
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                            }
//                            else
//                            {
//                                xmldoc.LoadXml(uri.Replace(UploadAddress, ""));
//                            }
//                        }
//                        //xmldoc.LoadXml(uri.Replace(UploadAddress + "?xml=", ""));
//                        XmlNodeList xmllist = xmldoc.GetElementsByTagName("Command");
//                        sLog = xmllist[0].Value + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
//                        xmllist = xmldoc.GetElementsByTagName("ExternalID");
//                        sLog = sLog + xmllist[0].InnerText;
//                    }
//                    catch
//                    {
//                        sLog = e.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
//                    }
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();

//                    iAttempt = iAttempt + 1;
//                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
//                    HttpPost(uri, iAttempt);
//                }
//                else if (iAttempt == 5)
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                }
//                else
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                    HttpPost(uri, 5);
//                }
//            }
//            finally
//            {
//                if (os != null)
//                {
//                    os.Close();
//                }
//            }

//            try
//            { // get the response
//                WebResponse webResponse = webRequest.GetResponse();
//                if (webResponse == null)
//                { return null; }
//                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
//                //MessageBox.Show(sr.ReadToEnd());
//                string sResult = sr.ReadToEnd().Trim();

//                if (sResult.Contains("<Error>") == true)
//                {
//                    XmlDocument xmldoc = new XmlDocument();
//                    xmldoc.LoadXml(sResult);
//                    XmlNodeList xmllist = xmldoc.GetElementsByTagName("Error");
//                    //MessageBox.Show(xmllist[0].InnerText);
//                    string sLog = string.Empty;
//                    sLog = "Error Text: " + xmllist[0].InnerText;
//                    xmllist = xmldoc.GetElementsByTagName("Command");
//                    sLog = sLog + " - Error at : " + xmllist[0].InnerText;
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    sLog = sLog + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString() + " for record ";
//                    xmllist = xmldoc.GetElementsByTagName("ExternalID");
//                    sLog = sLog + xmllist[0].InnerText;
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();
//                    return sResult;
//                }
//                else
//                {
//                    return sResult;
//                }
//            }
//            catch (WebException ex)
//            {
//                //MessageBox.Show(ex.Message, "HttpPost: Response error",
//                //   MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception e)
//            {
//                //MessageBox.Show(e.InnerException.ToString());
//            }


//            return null;
//        }

//        //Added by Selvaraman
//        public string URLPost(string uri, int iAttempt)
//        {
//            //if (Proxy.Util.NetworkUtil.CheckRCopiaInternetConnection() == false)
//            //{
//            //    System.Windows.Forms.MessageBox.Show("RCopia Server connection is failed. Cannot connect with E-Prescription");
//            //    return string.Empty;
//            //}

//            string sResult = string.Empty;
//            if (iAttempt == 1 && uri.Contains("http") == false)
//            {
//                uri = UploadAddress + "?xml=" + uri;
//            }

//            try
//            {
//                WebRequest webReq = WebRequest.Create(uri);

//                WebResponse webResp = webReq.GetResponse();

//                Stream str = webResp.GetResponseStream();
//                StreamReader srread = new StreamReader(str);
//                sResult = srread.ReadToEnd();
//            }
//            catch (Exception e)
//            {
//                //New Code - to Proceed only with the Capella transactions and ignore the RCopia transaction, if the request fails
//                //Changes made to let the capella production go
//                //Need to remove the following one line - if go for RCopia Certification
//                //Start
//                return string.Empty;
//                //End

//                if (iAttempt <= 3)
//                {
//                    string sLog = string.Empty;
//                    sLog = e.Message + " attempt " + iAttempt + " failed at " + DateTime.Now.ToString();
//                    TextWriter tx = new StreamWriter(sRCopiaLog, true);
//                    tx.WriteLine(sLog);
//                    tx.Close();
//                    tx.Dispose();

//                    iAttempt = iAttempt + 1;
//                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
//                    URLPost(uri, iAttempt);
//                }
//                else if (iAttempt == 5)
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                }
//                else
//                {
//                    GetURLAddressList(rcopiaUpdateInfoANS2.Value, true);
//                    URLPost(uri, 5);
//                }
//            }
//            return sResult;
//        }

//        public void GetURLAddressList(string GetURL, Boolean bForce)
//        {
//            try
//            {

//                if (GetURL == null)
//                {
//                    return;
//                }

//                XmlNodeList xmlReqNode = null;
//                Rcopia_Update_info rcopiaUpdateInfo = null;
//                RCopiaGenerateXML rcopiaXML = new RCopiaGenerateXML();
//                RCopiaXMLResponseProcess rcopiaResponseXML = new RCopiaXMLResponseProcess();
//                string sInputXML = string.Empty;
//                string sResponseXML = string.Empty;

//                //To get the list of URL Address
//                //Check the URL GetDateTime
//                IList<Rcopia_Update_info> TemprcopiaUpdateList = new List<Rcopia_Update_info>();
//                //Rcopia_Update_InfoManager rcopiUpdateMngr = new Rcopia_Update_InfoManager();
//                //IList<Rcopia_Update_info> rcopiaUpdateList = rcopiUpdateMngr.GetRcopiaUpdateInfo();
//                rcopiaUpdateInfo = (from g in rcopiaUpdateList where g.Command == "get_url" select g).ToList<Rcopia_Update_info>()[0];

//                if (rcopiaUpdateInfo.Last_Updated_Date_Time.Date != DateTime.Now.Date || bForce == true)
//                {
//                    sInputXML = rcopiaXML.CreateGetURLXML();
//                    sInputXML = sInputXML.Trim();
//                    sInputXML = sInputXML.Replace("\n", "");

//                    sResponseXML = URLPost(GetURL + sInputXML, 1);
//                    urlxmldoc.LoadXml(sResponseXML);
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineUploadURL");
//                    UploadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineDownloadURL");
//                    DownloadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("WebBrowserURL");
//                    RCopiaSessionAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?";
//                    rcopiaUpdateInfo.Value = sResponseXML;
//                    rcopiaUpdateInfo.Last_Updated_Date_Time = DateTime.Now;
//                    TemprcopiaUpdateList.Add(rcopiaUpdateInfo);
//                    rcopiaProxy.InsertinToRcopia_Update_info("get_url", DateTime.Now, sResponseXML, string.Empty);
//                }
//                else
//                {
//                    urlxmldoc.LoadXml(rcopiaUpdateInfo.Value);
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineUploadURL");
//                    UploadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("EngineDownloadURL");
//                    DownloadAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?xml=";
//                    xmlReqNode = urlxmldoc.GetElementsByTagName("WebBrowserURL");
//                    RCopiaSessionAddress = ((XmlElement)xmlReqNode[0]).InnerText + "?";
//                    TextWriter tx = null;
//                    try
//                    {
//                        tx = new StreamWriter(sRCopiaLog, true);
//                        string sLog = string.Empty;
//                        sLog = "ANS not being called since successful response received at " + rcopiaUpdateInfo.Last_Updated_Date_Time;
//                        tx.WriteLine(sLog);
//                    }
//                    catch (Exception e)
//                    {

//                    }
//                    finally
//                    {
//                        tx.Close();
//                        tx.Dispose();
//                    }
//                }
//            }
//            catch
//            {

//            }
//        }
//    }
//}
