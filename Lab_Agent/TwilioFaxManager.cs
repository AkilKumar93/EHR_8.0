using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using System.Reflection;
using System.IO;
using System.Collections;
using Acurus.Capella.DataAccess.ManagerObjects;
using Twilio;
using Twilio.Rest.Fax.V1;
using System.Net;

namespace Acurus.Capella.Lab_Agent
{
    public partial class TwilioFaxManager
    {
        public void FaxSentFiles()
        {
            ActivityLogManager objActivityMngr = new ActivityLogManager();
            IList<ActivityLog> lstactivitylogWaiting = new List<ActivityLog>();
            IList<ActivityLog> lstactivitylogUpdate = new List<ActivityLog>();
            ActivityLog objactivitylog = new ActivityLog();

            //Get Fax_Status=READY TO SEND items from activity_log table
            lstactivitylogWaiting = objActivityMngr.GetFaxActivityTypeByStatus();
            Console.WriteLine("Send Activity Log Count " + lstactivitylogWaiting.Count);
            if (lstactivitylogWaiting != null && lstactivitylogWaiting.Count > 0)
            {
                string sTwilio_S_Id = System.Configuration.ConfigurationSettings.AppSettings["Twilio_S_Id"];
                string sTwilio_Auth_Token = System.Configuration.ConfigurationSettings.AppSettings["Twilio_Auth_Token"];
                string sWaiting = System.Configuration.ConfigurationSettings.AppSettings["Twilio_Ready_for_Send_Path"];
                string sUrlProjectDestination = System.Configuration.ConfigurationSettings.AppSettings["Twilio_Destination_Project_URL_Path"];
                string sUrlTwilio = System.Configuration.ConfigurationSettings.AppSettings["Twilio_Send_Url_Path"];

                foreach (ActivityLog objActLog in lstactivitylogWaiting)
                {
                    Console.WriteLine("Send File Name :" + objActLog.Fax_File_Name);
                    if (!objActLog.Fax_File_Name.Contains("|"))
                    {
                        string sSourcePath = Path.Combine(sWaiting, objActLog.Fax_File_Name);                       
                        string sDestinationUrlPath = Path.Combine(sUrlProjectDestination, objActLog.Fax_File_Name);                       
                        DirectoryInfo dirUrl = new DirectoryInfo(Path.GetDirectoryName(sDestinationUrlPath));
                        if (!dirUrl.Exists)
                        {
                            dirUrl.Create();
                        }
                        try
                        {
                            File.Move(sSourcePath, sDestinationUrlPath);
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }
                        sUrlTwilio = Path.Combine(sUrlTwilio, objActLog.Fax_File_Name);
                        string accountSid = sTwilio_S_Id;
                        string authToken = sTwilio_Auth_Token;

                        TwilioClient.Init(accountSid, authToken);
                        Console.WriteLine(Environment.NewLine + sUrlTwilio);


                        var fax = FaxResource.Create(
                            from: objActLog.Fax_Sender_Number,
                            to: objActLog.Fax_Recipient_Number,
                            mediaUrl: new Uri(sUrlTwilio)
                        );
                    }
                    else
                    {
                        Console.WriteLine("Multiple files ");
                        string[] sPath = objActLog.Fax_File_Name.Split('|');
                        foreach (string s in sPath)
                        {
                            string sSourcePath = Path.Combine(sWaiting, s);
                            string sDestinationUrlPath = Path.Combine(sUrlProjectDestination, s);
                            DirectoryInfo dirUrl = new DirectoryInfo(Path.GetDirectoryName(sDestinationUrlPath));
                            if (!dirUrl.Exists)
                            {
                                dirUrl.Create();
                            }
                            try
                            {
                                File.Move(sSourcePath, sDestinationUrlPath);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                throw (ex);
                            }
                            sUrlTwilio = Path.Combine(sUrlTwilio,s);
                            string accountSid = sTwilio_S_Id;
                            string authToken = sTwilio_Auth_Token;

                            TwilioClient.Init(accountSid, authToken);
                            Console.WriteLine(Environment.NewLine + sUrlTwilio);


                            var fax = FaxResource.Create(
                                from: objActLog.Fax_Sender_Number,
                                to: objActLog.Fax_Recipient_Number,
                                mediaUrl: new Uri(sUrlTwilio)
                            );
                        }
                        //Activity log update
                        objActLog.Fax_Status = "SENT";
                        lstactivitylogUpdate.Add(objActLog);
                        Console.WriteLine("Sucessfully sent");
                    }
                    if (lstactivitylogUpdate.Count > 0)
                    {
                        objActivityMngr.UpdateActivityLogManager(lstactivitylogUpdate);
                    }
                }
            }
        }

        public void FaxReceiveFiles()
        {
            Console.Write(Environment.NewLine + "Fax Receive Start...");

            string sReceive = System.Configuration.ConfigurationSettings.AppSettings["Twilio_Receive_Path"];
            string FaxTimePath = System.Configuration.ConfigurationSettings.AppSettings["Twilio_FaxTimePath"];
            DirectoryInfo dir = new DirectoryInfo(sReceive);
            if (!dir.Exists)
            {
                dir.Create();
            }
            
            FileInfo[] fFiles = dir.GetFiles();
            string sTwilio_S_Id = System.Configuration.ConfigurationSettings.AppSettings["Twilio_S_Id"];
            string sTwilio_Auth_Token = System.Configuration.ConfigurationSettings.AppSettings["Twilio_Auth_Token"];
            TwilioClient.Init(sTwilio_S_Id, sTwilio_Auth_Token);

            if (!File.Exists(FaxTimePath))
            {
                File.Create(FaxTimePath);
            }

            string slastRunTime = string.Empty;
            slastRunTime = File.ReadAllText(FaxTimePath).Replace("\r\n", "");
          
            if (slastRunTime == string.Empty)
                slastRunTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss").Replace("\r\n", "");

            Console.Write(Environment.NewLine+"Fax Receive Last Updated Time :" + slastRunTime);
            //var faxes = FaxResource.Read();
            var faxes = FaxResource.Read(dateCreatedAfter: DateTime.Parse(slastRunTime).AddMinutes(-1));

            foreach (var record in faxes)
            {
                Console.Write(Environment.NewLine + "Fax Receive has File to download..");
                var fax = FaxResource.Fetch(pathSid: record.Sid.ToString());
                if (fax.Status.ToString() == "received")
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile(fax.MediaUrl, Path.Combine(sReceive, record.Sid.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".tif"));

                    //Update last run time
                    File.WriteAllText(FaxTimePath, String.Empty);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    using (TextWriter tx = new StreamWriter(FaxTimePath, true))
                    {
                        tx.WriteLine(sb);
                    }
                }
            }
        }
    }
}
