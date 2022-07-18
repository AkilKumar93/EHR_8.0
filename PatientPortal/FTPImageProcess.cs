using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections;
using System.IO;
using System.Net;

namespace Acurus.Capella.PatientPortal
{

    public partial class FTPImageProcess
    {
        string uri = string.Empty;
        FtpWebRequest reqFTP;
        FtpWebResponse responseFTP;

        public string UploadToImageServer(string HumanID, string serverIP, string UserName, string Password, string SelectedFilePath, string File_Name_Convention)
        {
            #region "Ftp Operations"
            //bool result = true;
            string serverPath = string.Empty;


            FileInfo fileInf = new FileInfo(SelectedFilePath);
            //    if (File_Name_Convention != string.Empty)
            //    {
            //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri + File_Name_Convention));
            //    }
            //    else
            //    {
            //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri + fileInf.Name));
            //    }
            //    reqFTP.Credentials = new NetworkCredential(UserName, Password);
            //    reqFTP.KeepAlive = false;
            //    reqFTP.UsePassive = false;
            //    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            //    reqFTP.UseBinary = true;
            //    reqFTP.ContentLength = fileInf.Length;
            //    int buffLength = 1;
            //    byte[] buff = new byte[fileInf.Length];
            //    int contentLen;
            //    FileStream fs = fileInf.OpenRead();
            //    try
            //    {
            //        Stream strm = reqFTP.GetRequestStream();
            //        contentLen = fs.Read(buff, 0, buffLength);
            //        while (contentLen != 0)
            //        {
            //            strm.Write(buff, 0, contentLen);
            //            contentLen = fs.Read(buff, 0, buffLength);
            //        }
            //        strm.Close();
            //        fs.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        result = false;
            //    }

            //    if (result)
            //    {
            //        if (File_Name_Convention != string.Empty)
            //        {
            //            serverPath = uri + File_Name_Convention;
            //        }
            //        else
            //        {
            //            serverPath = uri + fileInf.Name;
            //        }
            //    }  

            //return serverPath;

            #endregion

            /* Credential To Access NAS Server */
            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
            bool result = false;

            uri = serverIP + HumanID + "/";

            if (File_Name_Convention != string.Empty)
            {
                uri = ((uri + File_Name_Convention));
            }
            else
            {
                uri = ((uri + fileInf.Name));
            }
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            System.IO.File.Copy(SelectedFilePath, uri.Replace(ftpIP, UNCPath), true);
                            result = true;
                        }
                    }
                }
            }
            catch { result = false; }


            if (result)
            {
                serverPath = uri;
            }

            return serverPath;


        }


        public bool CreateDirectory(string HumanID, string serverIP, string UserName, string Password)
        {
            uri = serverIP + HumanID + "/";

            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            Directory.CreateDirectory(uri.Replace(ftpIP, UNCPath));
                        }

                    }

                }
            }
            catch { }
            return true;
        }


        public bool FileCopy(string HumanID, string serverIP, string UserName, string Password, string FileName, string localPath)
        {
            /* Credential To Access NAS Server */

            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];

            bool result = true;
            bool isFileCopyFailed = true;
            if (HumanID != "0")
            {
                uri = serverIP + HumanID + "/" + FileName;
            }
            else
            {
                uri = serverIP + "/" + FileName;
            }
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCPath, userName, domain, password))
                    {
                        FileInfo fiRemoteAvailable = new FileInfo(uri.Replace(@"ftp://192.168.101.7", UNCPath));

                        if (Directory.Exists(fiRemoteAvailable.Directory.FullName))
                        {
                            System.IO.File.Copy(localPath, uri.Replace(@"ftp://192.168.101.7", UNCPath), true);
                        }
                        else
                        {
                            Directory.CreateDirectory(fiRemoteAvailable.Directory.FullName);
                            System.IO.File.Copy(localPath, uri.Replace(@"ftp://192.168.101.7", UNCPath), true);

                        }
                    }
                }
            }
            catch { isFileCopyFailed = false; result = false; }



            return result;
        }
        public bool DownloadFromImageServer(string HumanID, string serverIP, string UserName, string Password, string FileName, string localPath)
        {
            /* Credential To Access NAS Server */
            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
            bool result = false;





            if (HumanID != "0")
            {
                uri = serverIP + HumanID + "/" + FileName;
            }
            else
            {
                uri = serverIP + "/" + FileName;
            }

            //try
            //{
            //    System.IO.File.Copy(uri.Replace(ftpIP, UNCPath), (Path.Combine(localPath, FileName)), true);
            //}
            // catch
            // {
            using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
            {
                if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                {
                    {
                        System.IO.File.Copy(uri.Replace(ftpIP, UNCPath), (Path.Combine(localPath, FileName)), true);
                        result = true;
                    }
                }
                // }
            }




            return result;

        }

        public bool DeleteFromImageServer(string HumanID, string serverIP, string UserName, string Password, string FileName)
        {
            bool result = true;
            uri = serverIP + HumanID + "/" + FileName;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Credentials = new NetworkCredential(UserName, Password);
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                responseFTP = (FtpWebResponse)reqFTP.GetResponse();

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public ArrayList GetTemplateImagesList(string serverIP, string UserName, string Password)
        {
            uri = serverIP + "/";
            ArrayList fileList = new ArrayList();

            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            string[] filesAvailed = Directory.GetFileSystemEntries(uri.Replace(ftpIP, UNCPath));
                            foreach (string item in filesAvailed)
                            {
                                FileInfo fi = new FileInfo(item);
                                fileList.Add(fi.Name);
                            }
                        }

                    }

                }
            }
            catch { }

            return fileList;
        }

        public bool CopyandPasteFileinServer(string serverIP, string UserName, string Password, string sourcePath, string destinationHuman_ID, string sFileName, out string sDestinationPath)
        {

            bool result = true;
            string destinationuri = string.Empty;



            if (CreateDirectoryForFileCopying(destinationHuman_ID, serverIP, UserName, Password))
            {
                destinationuri = serverIP + destinationHuman_ID + "/" + sFileName;
                try
                {
                    FtpWebRequest ftpDownload, ftpUploadRequest;
                    ftpDownload = (FtpWebRequest)FtpWebRequest.Create(new Uri(sourcePath));
                    ftpDownload.Credentials = new NetworkCredential(UserName, Password);
                    ftpDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                    ftpUploadRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(destinationuri));
                    ftpUploadRequest.Credentials = new NetworkCredential(UserName, Password);
                    ftpUploadRequest.Method = WebRequestMethods.Ftp.UploadFile;

                    using (FtpWebResponse response = (FtpWebResponse)ftpDownload.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (Stream requestStream = ftpUploadRequest.GetRequestStream())
                            {
                                byte[] buffer = new byte[102400];
                                int read = 0;
                                do
                                {
                                    read = responseStream.Read(buffer, 0, buffer.Length);
                                    requestStream.Write(buffer, 0, read);
                                    requestStream.Flush();
                                } while (!(read == 0));
                                requestStream.Flush();
                                requestStream.Close();
                                response.Close();
                                responseStream.Close();
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {

                    }
                    result = false;
                }

            }
            sDestinationPath = destinationuri;
            return result;


        }

        public bool CreateDirectoryForFileCopying(string HumanID, string serverIP, string UserName, string Password)
        {

            uri = serverIP + HumanID + "/";
            IList<string> strArray = HumanID.Split('/').Where(a => a != "").ToList<string>();

            for (int i = 0; i < strArray.Count(); i++)
            {
                if (i == 0)
                {
                    uri = serverIP + strArray[0] + "/";
                }
                else if (i == 1)
                {
                    uri = serverIP + strArray[0] + "/" + strArray[1] + "/";
                }
                try
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                    reqFTP.Credentials = new NetworkCredential(UserName, Password);
                    reqFTP.KeepAlive = false;
                    reqFTP.UsePassive = false;
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;

                    responseFTP = (FtpWebResponse)reqFTP.GetResponse();
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {

                    }
                }


            }


            return true;
        }

        public ArrayList GetFiles(string serverip, string username, string password, string path)
        {
            bool status = false;
            ArrayList arrFiles = new ArrayList();
            try
            {
                DirectoryInfo DrTarget = new DirectoryInfo(path);
                arrFiles.Add(DrTarget.GetFiles());
                status = true;
            }
            catch (Exception Ex)
            {
                //if (Ex is FileNotFoundException | Ex is DirectoryNotFoundException | Ex is UnauthorizedAccessException)
                {
                    status = false;
                }
            }
            finally
            {
                if (!status)
                {
                    arrFiles.Add(GetTemplateImagesList(serverip, username, password));
                }
            }
            return arrFiles;
        }

        

        public string UploadToADfiletoServerIndexing(string HumanID, string SelectedFilePath)
        {

            string serverPath = string.Empty;
            FileInfo fileInf = new FileInfo(SelectedFilePath);
            /* Credential To Access NAS Server */
            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPathAD"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPathAD"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIPAD"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserNameAD"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["PasswordAD"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["DomainAD"];
            bool result = false;

            uri = ftpIP + HumanID + "/";
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            CreateDirectoryAD(HumanID.ToString(), ftpIP, userName, password);

                            uri = ((uri + fileInf.Name));
                            System.IO.File.Copy(SelectedFilePath, uri.Replace(ftpIP, UNCPath), true);
                            result = true;
                            //string ftpServerIP = System.Configuration.ConfigurationManager.AppSettings["ftpServerIP"];
                            //string ftpUserName = System.Configuration.ConfigurationManager.AppSettings["ftpUserID"];
                            //string ftpPassword = System.Configuration.ConfigurationManager.AppSettings["ftpPassword"];
                            //UploadToImageServer(HumanID, ftpServerIP, ftpUserName, ftpPassword, SelectedFilePath, string.Empty);
                        }
                    }
                }
            }
            catch { result = false; }
            if (result)
            {
                serverPath = uri;
                fileInf.Delete();
            }

            return serverPath;
        }

        public bool DownloadFromADImageServer(string HumanID, string sourceFileName, string DestinationFolderPath)
        {
            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPathAD"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPathAD"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIPAD"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["UserNameAD"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["PasswordAD"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["DomainAD"];
            bool result = false;
            if (HumanID != "0")
            {
                uri = ftpIP + HumanID + "/" + sourceFileName;
            }
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            System.IO.File.Copy(uri.Replace(ftpIP, UNCPath), (Path.Combine(DestinationFolderPath, sourceFileName)), true);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool CreateDirectoryAD(string HumanID, string serverIP, string UserName, string Password)
        {
            uri = serverIP + HumanID + "/";

            string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPathAD"];
            string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPathAD"];
            string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIPAD"];
            string userName = System.Configuration.ConfigurationSettings.AppSettings["userNameAD"];
            string password = System.Configuration.ConfigurationSettings.AppSettings["PasswordAD"];
            string domain = System.Configuration.ConfigurationSettings.AppSettings["DomainAD"];
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            Directory.CreateDirectory(uri.Replace(ftpIP, UNCPath));
                        }

                    }

                }
            }
            catch { }
            return true;
        }
        public bool CreateDirectoryFAX(string UNCAuthPath, string UNCPath,string ftpIP,string userName, string password ,string domain ,string sDestinationFtpPath)
        {
            //string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
            //string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            //string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
            //string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            //string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            //string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
            uri = UNCPath + "/" + sDestinationFtpPath + "/";
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            Directory.CreateDirectory(uri);
                        }

                    }

                }
            }
            catch { }
            return true;
        }

        public string UploadToImageServerFAX( string UNCAuthPath, string UNCPath,string ftpIP,string userName,string password,string domain ,string sDestinationFtpPath, string SourceFilePath, string File_Name_Convention)
        {
            
            string serverPath = string.Empty;
            FileInfo fileInf = new FileInfo(SourceFilePath);
            

            /* Credential To Access NAS Server */
            //string UNCAuthPath = System.Configuration.ConfigurationSettings.AppSettings["UNCAuthPath"];
            //string UNCPath = System.Configuration.ConfigurationSettings.AppSettings["UNCPath"];
            //string ftpIP = System.Configuration.ConfigurationSettings.AppSettings["ftpServerIP"];
            //string userName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            //string password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            //string domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
            bool result = false;

            uri = ftpIP + "/" + sDestinationFtpPath + "/";

            if (File_Name_Convention != string.Empty)
            {
                uri = ((uri + File_Name_Convention));
            }
            else
            {
                uri = ((uri + fileInf.Name));
            }
            try
            {
                using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
                {
                    if (unc.NetUseWithCredentials(UNCAuthPath, userName, domain, password))
                    {
                        {
                            System.IO.File.Copy(SourceFilePath, uri.Replace(ftpIP, UNCPath), true);
                            result = true;
                        }
                    }
                }
            }
            catch { result = false; }


            if (result)
            {
                serverPath = uri;
            }

            return serverPath;


        }

    }
}
