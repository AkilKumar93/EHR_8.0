using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace Acurus.Capella.LabAgent
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
        public const string OPENSTATUS = "OPENSTATUS";
        public const string WRITEOFF = "WRITEOFF";
        public const string UNAPPLIED = "UNAPPLIED";

        public const ulong CASH_INS_PLAN_ID = 68;
        public static bool bNotWorkset;
        public static bool bHold;
        public static string SCREEN_NAME;
        public const ulong SE_ERR_FNF = 2L;
        public static int iTotDamage = 0;
        public static DateTime APPOINMENT_DATE = DateTime.MinValue;

        [DllImport("shell32.dll", EntryPoint = "ShellExecuteA")]
        public static extern ulong ShellExecute(int hWnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        //public static int TaskManager = 0;

        public enum eTaskManager
        {
            eTaskManager_GeneralTask = 0,
            eTaskManager_PatientTask = 1
        }


        //public static Application GetApplicationRecord(string AppName)
        //{
        //    IApplicationManager applist = new ManagerFactory().GetApplicationManager();
        //    return applist.GetApplicationRecord(AppName);

        //}

        //public static string AssignScreenTitle(RadForm frmCurrentScreen, string CurrentScreenTitle)
        //{
        //    string ScreenTitle;

        //    if (frmCurrentScreen.IsMdiContainer == false && ClientSession.UserName != string.Empty)
        //    {
        //        if (frmCurrentScreen.IsMdiChild == true)
        //        {
        //            ScreenTitle = CurrentScreenTitle; //frmCurrentScreen.Text;
        //        }
        //        else
        //        {
        //            //ScreenTitle = frmCurrentScreen.Text + " - " + ClientSession.UserName;
        //            ScreenTitle = CurrentScreenTitle + " - " + ClientSession.UserName;
        //        }
        //    }
        //    else if (frmCurrentScreen.IsMdiContainer == false && ClientSession.UserName == string.Empty)
        //    {
        //        ScreenTitle = ConfigurationSettings.AppSettings.Get("ClientName") + " - " +
        //            CurrentScreenTitle;
        //        //           frmCurrentScreen.Text;
        //    }
        //    else
        //    {
        //        ScreenTitle = CurrentScreenTitle + " - " + ClientSession.UserName; //+" - " + ScreenID;
        //        //ScreenTitle =
        //        //frmCurrentScreen.Text + " - " + ClientSession.UserName; //+" - " + ScreenID;
        //    }

        //    return ScreenTitle;
        //}

        //public void getUserList()//added by vijayan
        //{
        //    LoginProxy loginProxy = new LoginProxy();
        //    if (userList.ContainsKey("USERLIST"))
        //        userList.Remove("USERLIST");
        //    userList.Add("USERLIST", loginProxy.GetUserList());
        //}
        public static DateTime ConvertToUniversal(DateTime inputDateTime)
        {
            //inputDateTime = inputDateTime.ToUniversalTime();
            inputDateTime = System.TimeZoneInfo.ConvertTimeToUtc(inputDateTime);
            return inputDateTime;
        }

        public static DateTime ConvertToLocal(DateTime inputDateTime)
        {
            inputDateTime = inputDateTime.ToLocalTime();

            return inputDateTime;
        }

        //public string ConvertCelsiusToFarenheit(string s)
        //{
        //    decimal cel = Convert.ToDecimal(s);
        //    decimal far = decimal.Round((cel * 9.0m / 5) + 32, 2);
        //    return far.ToString();
        //}
        //public string ConvertFarenheitToCelsius(string s)
        //{
        //    decimal far = Convert.ToDecimal(s);
        //    decimal cel = decimal.Round((far - 32) / 1.8m, 2);
        //    return cel.ToString();
        //}
        //public string ConvertLbsToKg(string s)
        //{
        //    decimal kgValue = decimal.Round(Convert.ToDecimal(s) / 2.2m, 2);
        //    return kgValue.ToString();
        //}
        //public string ConvertKgToLbs(string s)
        //{
        //    decimal kgValue = Convert.ToDecimal(s);
        //    decimal lbsValue = decimal.Round(kgValue * 2.2m, 2);
        //    return lbsValue.ToString();
        //}
        //public string ConvertInchesToCM(string s)
        //{
        //    decimal cmValue = decimal.Round((Convert.ToDecimal(s) * 2.54m), 2);
        //    return cmValue.ToString();
        //}
        //public string ConvertCMToInches(string s)
        //{
        //    decimal inValue = decimal.Round((Convert.ToDecimal(s) * 0.3937008m), 3);
        //    return inValue.ToString();
        //}
        //public string ConvertCMToFeetInch(string s)
        //{
        //    string result;
        //    decimal cmValue = Convert.ToDecimal(s);
        //    decimal feetValue = Math.Floor(cmValue / 30.48m);
        //    decimal inchValue = cmValue / 2.54m;
        //    decimal inchValue1 = decimal.Round((inchValue - (feetValue * 12m)), 2);
        //    if (inchValue1 == 12)
        //    {
        //        feetValue = feetValue + 1;
        //        result = feetValue + "'" + "0" + "''";
        //    }
        //    else
        //        result = feetValue.ToString() + "'" + inchValue1.ToString() + "''";

        //    return result;
        //}

        //public string ConvertFeetInchToInch(string s1, string s2)
        //{
        //    if (s1 == string.Empty)
        //    {
        //        return string.Empty;
        //    }
        //    decimal inValue = 0;
        //    if (s2 != string.Empty)
        //        inValue = decimal.Round((Convert.ToDecimal(s1) * 12m) + Convert.ToDecimal(s2), 2);
        //    else
        //        inValue = decimal.Round((Convert.ToDecimal(s1) * 12m), 2);
        //    if (inValue != 0m)
        //        return inValue.ToString();
        //    else
        //        return string.Empty;

        //}
        //public string ConvertMmolToMg(string s)
        //{
        //    decimal mg = decimal.Round((Convert.ToDecimal(s) * 18m), 2);
        //    return mg.ToString();
        //}
        //public string ConvertMgToMmol(string s)
        //{
        //    decimal mg = decimal.Round((Convert.ToDecimal(s) / 18m), 2);
        //    return mg.ToString();
        //}
        //public string ConvertInchtoFeetInch(string s)
        //{
        //    decimal inch = Convert.ToDecimal(s);
        //    decimal feet = Math.Floor(inch / 12m);
        //    decimal remainInch = decimal.Round((inch % 12m), 2);
        //    return feet.ToString() + "'" + " " + remainInch.ToString() + "''";
        //}

        //public string InvokeMethod(string className, string methodName, string[] arguments)
        //{
        //    //string[] MyArguments;
        //    try
        //    {
        //        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        //        string[] assemblyName = currentAssembly.FullName.ToString().Split(',');
        //        Type myType = currentAssembly.GetType(assemblyName[0] + '.' + className);
        //        MethodInfo myMethod = myType.GetMethod(methodName);
        //        object instance = Activator.CreateInstance(myType);
        //        return myMethod.Invoke(instance, arguments).ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        return string.Empty;
        //    }
        //}

        public Form OpenDynamicForm(string className, string[] arguments)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string[] assemblyName = currentAssembly.FullName.ToString().Split(',');
            Form frmApplication;

            string sTemp = string.Empty;

            try
            {
                sTemp = currentAssembly.ManifestModule.ScopeName.Replace(".exe", string.Empty);
            }
            catch
            {

            }

            frmApplication = (Form)currentAssembly.CreateInstance(sTemp + ".frm" + className);

            frmApplication.Show();


            return frmApplication;
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

        //17-Aug-2011 Developed by Vinoth
        public static int CalculateAgeInDays(DateTime birthDate)
        {

            DateTime now = DateTime.Today;
            TimeSpan difference = now.Subtract(birthDate);
            return (int)difference.TotalDays;
        }
        //17-Aug-2011 Developed by Vinoth



        //Created By Selvaraman
        //Modified By Selvaraman - 10-Aug - For Peformance Tuning
        public static string FillPatientSummaryBar(string LastName,string FirstName, string MI,string Suffix, DateTime DOB, ulong ulHumanID,string MedRecNo, string HomePhoneNo,string Sex,string SSN, string sPriPlan, string sPriCarrier, string sSecPlan, string sSecCarrier )
        {

            string sMySummary;

            sMySummary = LastName + "," + FirstName+
               "  " + MI+ "  " + Suffix+ "   |   " +
               DOB.ToString("dd-MMM-yyyy") + "   |   " +
               (CalculateAge(DOB)).ToString() +
               "  year(s)    |   " + Sex.Substring(0, 1) + "   |   Acc #:" + ulHumanID +
               "   |   " + "Med Rec #:" +MedRecNo+ "   |   " +
               "Phone #:" + HomePhoneNo+ "   |   ";

            if (sPriPlan != string.Empty)
            {
                sMySummary += "Pri Plan:" + sPriCarrier+" - "+ sPriPlan + "   |   ";
            }
            if (sSecPlan != string.Empty)
            {
                sMySummary += "Sec Plan:" + sSecCarrier+" - "+ sSecPlan + "   |   ";
            }
            if (SSN!= string.Empty)
            {
                sMySummary += "SSN:" +SSN+ "   |   ";
            }

            return sMySummary;
        }
        public static string FillPatientSummaryBarforPatientChart(string LastName, string FirstName, string MI, string Suffix, DateTime DOB, ulong ulHumanID, string MedRecNo, string HomePhoneNo, string Sex, string PatientStatus, string SSN, string sPriPlan, string sPriCarrier, string sSecPlan, string sSecCarrier)
        {

            string sMySummary;
            if (PatientStatus == "DECEASED")
            {
                sMySummary = LastName + "," + FirstName +
                   "  " + MI + "  " + Suffix + "   |   " +
                   DOB.ToString("dd-MMM-yyyy") + "   |   " +
                   (CalculateAge(DOB)).ToString() +
                   "  year(s)    |   " + Sex.Substring(0, 1) + "   |   " + PatientStatus + "   |   Acc #:" + ulHumanID +
                   "   |   " + "Med Rec #:" + MedRecNo + "   |   " +
                   "Phone #:" + HomePhoneNo + "   |   ";
            }
            else
            {
                sMySummary = LastName + "," + FirstName +
               "  " + MI + "  " + Suffix + "   |   " +
               DOB.ToString("dd-MMM-yyyy") + "   |   " +
               (CalculateAge(DOB)).ToString() +
               "  year(s)    |   " + Sex.Substring(0, 1) + "   |   Acc #:" + ulHumanID +
               "   |   " + "Med Rec #:" + MedRecNo + "   |   " +
               "Phone #:" + HomePhoneNo + "   |   ";

            }

            if (sPriPlan != string.Empty)
            {
                sMySummary += "Pri Plan:" + sPriCarrier + " - " + sPriPlan + "   |   ";
            }
            if (sSecPlan != string.Empty)
            {
                sMySummary += "Sec Plan:" + sSecCarrier + " - " + sSecPlan + "   |   ";
            }
            if (SSN != string.Empty)
            {
                sMySummary += "SSN:" + SSN + "   |   ";
            }

            return sMySummary;
        }

        public void OpenFiles(string s_ImageFileName, string s_FileType)
        {
            ulong iOpenImageResult = 0;
            string msg;
            string sEasyprint;
            int StartIndex = 0;
            if ((s_FileType == "*.tif"))
            {
                iOpenImageResult = ShellExecute(0, "open", "mspview", s_ImageFileName, string.Empty, 0);
            }
            if ((s_FileType == "*.txt"))
            {
                iOpenImageResult = ShellExecute(0, "open", "notepad", s_ImageFileName, string.Empty, 1);
            }
            if ((s_FileType == "*.doc"))
            {
                iOpenImageResult = ShellExecute(0, "open", "winword", s_ImageFileName, string.Empty, 0);
            }
            //added by srividhya on 04-feb-2012
            if ((s_FileType == "*.xls"))
            {
                iOpenImageResult = ShellExecute(0, "open", "excel", s_ImageFileName, string.Empty, 0);
            }

            //StartIndex = s_ImageFileName.IndexOf('.');
            sEasyprint = s_ImageFileName.Substring(StartIndex, 4);
            //sEasyprint = s_ImageFileName.Substring((s_ImageFileName.Length - 9));
            // sEasyprint = sEasyprint.Substring(0, 5);

            if (((sEasyprint == "MAIL.") && (s_FileType == "*.pdf")))
            {
                iOpenImageResult = ShellExecute(0, "open", "C:\\Program Files\\Medicare Remit EasyPrint\\EasyPrint", s_ImageFileName, string.Empty, 0);
            }
            if (((sEasyprint != "MAIL.") && (s_FileType == "*.pdf")))
            {
                iOpenImageResult = ShellExecute(0, "open", "Acrord32", s_ImageFileName, string.Empty, 0);
            }
            if ((iOpenImageResult <= 32))
            {
                switch (iOpenImageResult)
                {
                    case 2L:
                        msg = "Unable to open the File. Contact system admin";
                        break;
                    case 3L:
                        msg = "Path not found";
                        break;
                    case 5L:
                        msg = "Access denied";
                        break;
                    case 8L:
                        msg = "Out of memory";
                        break;
                    case 32L:
                        msg = "DLL not found";
                        break;
                    case 26L:
                        msg = "A sharing violation occurred";
                        break;
                    case 27L:
                        msg = "Incomplete or invalid file association";
                        break;
                    case 28L:
                        msg = "DDE Time out";
                        break;
                    case 29L:
                        msg = "DDE transaction failed";
                        break;                        
                    case 30L:
                        msg = "DDE busy";
                        break;
                    case 31L:
                        msg = "No association for file extension";
                        break;
                    case 11L:
                        msg = "Invalid EXE file or error in EXE image";
                        break;
                    default:
                        msg = "Unknown error";
                        break;
                }
               // RadMessageBox.Show(msg, string.Empty, MessageBoxButtons.OK);
            }
        }

        public static decimal MyConvertToDecimal(string MyString)
        {
            decimal deResult = 0;
            decimal.TryParse(MyString, out deResult);
            return (deResult);
        }

        public static int GetTifIPageCount(string TifPath)
        {
            int IPageCount = 0;

            try
            {
                bool t = false;
                Image theTIFF = Image.FromFile(TifPath);
                if (t == false)
                   // IPageCount = theTIFF.GetFrameCount(FrameDimension.Page);
                theTIFF.Dispose();
                return IPageCount;
            }
            catch (Exception e)
            {
                iTotDamage = iTotDamage + 1;
            }
            return IPageCount;
        }

        public static void General_grlbl_TextChanged(object sender, EventArgs e)
        {
            //base.OnTextChanged(e);
            resizeLabel(sender);
        }
        private static Boolean mGrowing = false;

        private static void resizeLabel(object sender)
        {
            //if (mGrowing) return;
            //try
            //{
            //    mGrowing = true;
            //    Size sz = new Size(((RadLabel)sender).Width, Int32.MaxValue);
            //    sz = TextRenderer.MeasureText(((RadLabel)sender).Text, ((RadLabel)sender).Font, sz, TextFormatFlags.WordBreak);
            //    ((RadLabel)sender).Height = sz.Height + 15;
            //}
            //finally
            //{
            //    mGrowing = false;
            //}
        }
        public static decimal CalculateAgeInMonths(DateTime birthDate, DateTime now)
        {
            decimal leap = 0;
            decimal Months = 0;
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


            //else
            //{
            //    leap=3
            //}

            if (leap == 28)
            {
                Months = Convert.ToDecimal(now.Subtract(birthDate).Days / (365.25 / 12));
            }
            else if (leap == 31)
            {
                Months = Convert.ToDecimal(now.Subtract(birthDate).Days / (365.25 / 12));
            }
            else if (leap == 29)
            {
                Months = Convert.ToDecimal(now.Subtract(birthDate).Days / (366 / 12));
            }
            else if (leap == 30)
            {
                Months = Convert.ToDecimal(now.Subtract(birthDate).Days / (365.25 / 12));
            }
            
            return Months;

          
        }
        // Added by Manimozhi - 19th Dec 2012
        public void ImportMedicalDictionary()
        {
            string sOriginalContent = string.Empty;
            string sLine = string.Empty;
            string sDictionaryPath = System.Configuration.ConfigurationSettings.AppSettings["SpellCheckerDictionaryPath"];
            System.IO.StreamReader file = new System.IO.StreamReader(sDictionaryPath);
            sOriginalContent = file.ReadToEnd();
            file.Close();
            string[] sOriginalSplitContent = sOriginalContent.Split('\n');

            string sUserLocation = System.Environment.GetEnvironmentVariable("USERPROFILE");
            System.IO.StreamReader fs = new System.IO.StreamReader(sUserLocation + "\\Application Data\\Microsoft\\UProof\\CUSTOM.DIC");
            string sResultContent = fs.ReadToEnd();
            string[] sResultSplitContent = sResultContent.Split('\n');
            fs.Close();
            StreamWriter stwriter = new StreamWriter(sUserLocation + "\\Application Data\\Microsoft\\UProof\\CUSTOM.DIC", true);
            for (int i = 0; i < sOriginalSplitContent.Length; i++)
            {
                sLine = sOriginalSplitContent[i];

                if (sResultSplitContent.Contains(sOriginalSplitContent[i] + "\r") == false) // a => sOriginalContent[i].ToString()!=sResultContent[i].ToString()))
                {
                    stwriter.WriteLine(sLine);

                }
            }
            stwriter.Close();
        }

    }
}
