using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Acurus.Capella.GenerateCCD
{
    public partial class UtilityManager
    {
        public static ulong ulAppointmentID;
        public static ulong ulMyFindPatientID;
        public static ulong ulAppointmentProviderID;
        public static Hashtable userList = new Hashtable();

        public const ulong CASH_CARRIER_ID = 41;
        public const string SECONDARY_INSURANCE = "SECONDARY_INSURANCE";
        public const string TERTIARY_INSURANCE = "TERTIARY_INSURANCE";
        public const string INSURANCE = "PRIMARY_INSURANCE";
        public const string BILLED_AMOUNT = "BILLED_AMOUNT";
        public const string BILL_TO = "BILL_TO";
        public const string MSGTYPE_CHARGEPOSTING = "CHARGE_POSTING_MESSAGE";
        public const string SPATTERN = "*.tif";
        public const string NEWPAYMENT = "NEWPAYMENT";
        public const string PATIENT_TYPE = "PATIENT";
        public const string TRANSFER = "TRANSFER";
        public const string COPAY = "COPAY";
        public const string COINSURANCE = "COINSURANCE";
        public const string DEDUCTIBLE = "DEDUCTIBLE";
        public const string PP_LINE_ITEM = "PP_LINE_ITEM";
        public const string REFUND = "REFUND";
        public const string OFFSET = "OFFSET";
        public const string OPENSTATUS = "OPEN";
        public const string WRITEOFF = "WRITEOFF";
        public const string UNAPPLIED = "UNAPPLIED";

        public const ulong CASH_INS_PLAN_ID = 68;
        public static bool bWorkset;
        public static bool bHold;
        public static string SCREEN_NAME;
        public const ulong SE_ERR_FNF = 2L;
        public static int iTotDamage = 0;
        public static DateTime APPOINMENT_DATE = DateTime.MinValue;

        //added by srividhya on 01-mar-2012
        public static bool bCancel = false;
        public static bool bCurrentScreen = false;
        public static decimal deExcCallQCAmt = 0;
        public static int iTotalLineItem = 0;
        public static DataSet ds = new DataSet();

        [DllImport("shell32.dll", EntryPoint = "ShellExecuteA")]
        public static extern ulong ShellExecute(int hWnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        public enum eTaskManager
        {
            eTaskManager_GeneralTask = 0,
            eTaskManager_PatientTask = 1
        }

        public static DateTime ConvertToUniversal(DateTime inputDateTime)
        {
            var request = "-08.00";//Himaja = ClientSession.UniversalTime.ToString();
            string[] Hours = { "-08.00" }; //Himaja = ClientSession.UniversalTime.ToString().Split('.');

            DateTime dt = DateTime.MinValue;

            if (Hours != null && Hours[0] != string.Empty)
            {
                double offset = (double.Parse(Hours[0]));
                if (true)//Himaja(UIManager.bFollows_DST)
                {
                    DateTime DayLight_StartDateTime;
                    DateTime DayLight_EndDateTime;
                    int iDSTStartDay = UtilityManager.FindDate(inputDateTime.Year, 3, DayOfWeek.Sunday, 2);
                    int iDSTEndDay = UtilityManager.FindDate(inputDateTime.Year, 11, DayOfWeek.Sunday, 1);
                    DayLight_StartDateTime = new DateTime(inputDateTime.Year, 3, iDSTStartDay, 2, 0, 0);
                    DayLight_EndDateTime = new DateTime(inputDateTime.Year, 11, iDSTEndDay, 2, 0, 0);
                    if ((inputDateTime.Ticks > DayLight_StartDateTime.Ticks) && (inputDateTime.Ticks < DayLight_EndDateTime.Ticks))
                    {
                        if (offset < 0)
                            offset += 1;
                        else
                            offset -= 1;
                    }
                }

                if (inputDateTime.ToString() != "01-01-0001 12:00:00 AM")
                {
                    if (Hours.Length != 0 && Hours.Length == 2)
                    {
                        dt = inputDateTime.AddHours(-offset).AddMinutes(-double.Parse(Hours[1]));
                    }
                }
                else
                {
                    dt = inputDateTime;
                }
            }

            return dt;

        }

        public static int FindDate(int Year, int Month, DayOfWeek Day, int Occurrence)
        {
            if (Occurrence == 0 || Occurrence > 5)
                return 0;

            DateTime FirstDayOfMonth = new DateTime(Year, Month, 1);
            int days_needed = (int)Day - (int)FirstDayOfMonth.DayOfWeek;
            if (days_needed < 0)
                days_needed += 7;
            int resultDate = days_needed + 1 + (7 * (Occurrence - 1));
            return resultDate;
        }

        public string GetFieldNameForSnomedCodefromStaticLookup(string sReasonOrFollowup, string sSnomedCode)
        {
            string sValue = string.Empty;

            IList<StaticLookup> iFieldLookupList = new List<StaticLookup>();
            IList<string> ilstItem = sSnomedCode.Split(',').Select(i => i.TrimStart().ToString()).ToList<string>();


            string strXmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleXML\\staticlookup.xml");// Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\staticlookup.xml");
            if (File.Exists(strXmlFilePath) == true)
            {
                XDocument xmlSnomed = XDocument.Load(strXmlFilePath);
                IEnumerable<XElement> xmlSnomedCode = null;
                try
                {
                    if (ilstItem.Count > 0)
                    {
                        for (int i = 0; i < ilstItem.Count; i++)
                        {
                            xmlSnomedCode = xmlSnomed.Element("root").Element(sReasonOrFollowup).Elements(sReasonOrFollowup.Replace("List", " ").Trim()).Where(xx => xx.Attribute("Description").Value.ToUpper() == ilstItem[i].ToString().ToUpper());
                            if (xmlSnomedCode != null && xmlSnomedCode.Count() > 0)
                            {
                                if (sValue == string.Empty)
                                    sValue = xmlSnomedCode.Attributes("Description").First().Value.ToString() + "~" + xmlSnomedCode.Attributes("Value").First().Value.ToString();
                                else
                                    sValue += "," + xmlSnomedCode.Attributes("Description").First().Value.ToString() + "~" + xmlSnomedCode.Attributes("Value").First().Value.ToString();
                            }
                        }
                    }
                }

                catch (Exception)
                {
                    sValue = string.Empty;
                }
            }
            return sValue;
        }

        public static int CalculateAgeInMonths(DateTime birthDate, DateTime now)
        {
            int leap = 0;
            int Months = 0;
            if (1 == now.Month || 3 == now.Month || 5 == now.Month || 7 == now.Month || 8 == now.Month ||
            10 == now.Month || 12 == now.Month)
            {
                leap = 31;
            }
            else if (2 == now.Month)
            {
                // Check for leap year
                if (0 == (now.Year % 4))
                {
                    // If date is divisible by 400, it's a leap year.
                    // Otherwise, if it's divisible by 100 it's not.
                    if (0 == (now.Year % 400))
                    {
                        leap = 29;
                    }
                    else if (0 == (now.Year % 100))
                    {
                        leap = 28;
                    }

                    // Divisible by 4 but not by 100 or 400
                    // so it leaps
                    leap = 29;
                }
                else
                {
                    leap = 28;
                }
                // Not a leap year

            }
            else
            {
                leap = 30;
            }

            if (leap == 28)
            {
                Months = Convert.ToInt16(now.Subtract(birthDate).Days / (365.25 / 12));
            }
            else if (leap == 31)
            {
                Months = Convert.ToInt16(now.Subtract(birthDate).Days / (365.25 / 12));
            }
            else if (leap == 29)
            {
                Months = Convert.ToInt16(now.Subtract(birthDate).Days / (366 / 12));
            }
            else if (leap == 30)
            {
                Months = Convert.ToInt16(now.Subtract(birthDate).Days / (365.25 / 12));
            }

            return Months;


        }

        public static int CalculateAge(DateTime birthDate)
        {
            // cache the current time
            DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
            // get the difference in years
            int years = now.Year - birthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                --years;

            return years;
        }
        public string GetSnomedForCPT(string sCPT)
        {

            string sSnomedCode = string.Empty;
            string strXmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleXML\\staticlookup.xml");//System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "ConfigXML\\staticlookup.xml");
            if (File.Exists(strXmlFilePath) == true)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strXmlFilePath);
                XmlNodeList node = xDoc.GetElementsByTagName("procedurecodelist");
                foreach (XmlNode xNode in node[0].ChildNodes)
                {
                    if (xNode.Attributes.GetNamedItem("code").Value == sCPT)
                    {
                        sSnomedCode = xNode.Attributes.GetNamedItem("snomedcode").Value;
                        break;
                    }
                }
            }
            return sSnomedCode;
        }

       

    }
}
