using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Acurus.Capella.PatientPortal.WebServices
{
    /// <summary>
    /// Summary description for PatientPortalWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PatientPortalWebService : System.Web.Services.WebService
    {



        [WebMethod(EnableSession = true)]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        public string GetPatientDetailsUsingPatientInformattion(ulong ulHumanID)
        {
            HumanManager hnProxy = new HumanManager();
            IList<Human> humanList = new List<Human>();
            //string sreturn = "test";
            humanList = hnProxy.GetPatientDetailsUsingPatientInformattion(ulHumanID);
            return JsonConvert.SerializeObject(humanList);
            //return sreturn;
        }
    }
}
