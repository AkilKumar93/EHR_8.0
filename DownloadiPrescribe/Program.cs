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
using System.Net.Http;
using Acurus.Capella.DataAccess;
using System.Threading.Tasks;
using NHibernate;
using System.Collections;
using static Acurus.Capella.DataAccess.RCopiaXMLResponseProcess;
using System.Text.RegularExpressions;
using System.Configuration;

namespace DownloadiPrescribe
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            DateTime dtRCopia_Last_Updated_Date_Time = DateTime.MinValue;
            DateTime lastUpdateDate = DateTime.Now;
            string sLegalOrgListConfig = ConfigurationManager.AppSettings["sLegalOrgList"];
            List<string> sLegalOrgList = new List<string>(sLegalOrgListConfig.Split(','));
            Rcopia_Update_InfoManager rcopiaUpdateMngr = new Rcopia_Update_InfoManager();
            CultureInfo culture = new CultureInfo("en-US");
            DateTime.TryParse(rcopiaUpdateMngr.GetRcopiaUpdateInfoCommandName("get_rcopia_event"), out dtRCopia_Last_Updated_Date_Time);
            foreach (var sLegalOrg in sLegalOrgList)
            {

                RCopiaGenerateXML rcopiaXML = new RCopiaGenerateXML();
                RCopiaSessionManager rcopiaSessionMngr = new RCopiaSessionManager(sLegalOrg);
                RCopiaXMLResponseProcess rcopiaResponseXML = new RCopiaXMLResponseProcess();
                string sInputXML = rcopiaXML.CreateGetRcopiaEventXML(dtRCopia_Last_Updated_Date_Time, sLegalOrg);
                string sOutputXML = rcopiaSessionMngr.HttpPost(rcopiaSessionMngr.DownloadAddress + sInputXML, 1);
                EventXMLResponseModel responseModel = rcopiaResponseXML.ReadEventXMLResponse(sOutputXML, sLegalOrg);

                foreach (var patientId in responseModel.ilstPatientIds)
                {
                    HumanManager humanManager = new HumanManager();

                    var human = humanManager.GetHumanFromHumanID(Convert.ToUInt64(patientId));

                    if (human != null && human.Id != 0)
                    {
                        Rcopia_Update_InfoManager objUpdateInfoMngr = new Rcopia_Update_InfoManager();
                        objUpdateInfoMngr.DownloadRCopiaInfo(string.Empty, "Acurus", string.Empty, DateTime.Now, string.Empty, 0, Convert.ToUInt64(patientId), sLegalOrg);
                    }
                }
                lastUpdateDate = responseModel.dtLastUpdateDate;
            }

            rcopiaUpdateMngr.InsertinToRcopia_Update_info("get_rcopia_event", Convert.ToDateTime(lastUpdateDate, culture), string.Empty, string.Empty);
        }


    }
}
