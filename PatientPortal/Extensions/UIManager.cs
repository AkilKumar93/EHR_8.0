using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Reflection;
using System.Collections;
using System.IO;
using Acurus.Capella.Core.DTO;
using System.Drawing;
using System.Web.UI;
using Acurus.Capella.PatientPortal;



namespace Acurus.Capella.PatientPortal
{
    public partial class UIManager
    {
        //Unused variable are commented for bug Id 54517
        //public static frmLogin frmLogin = null;
       // public static frmC3PO frmMain = null;
       // public static frmAPPOINTMENTS frmScheduler = null;
        
        //public static frmPatientChart frmPatChart = null;
        //public static bool flagPFSHVerified = false;
        public static bool IsPFSHVerified = false;
       // public static frmPFSH frmPFSH = null;
        //public static Hashtable getHumanIDsForAllergyRecord = new Hashtable();
       // public static Hashtable getHumanIDsForAllergyCondition = new Hashtable();
        ///public static Hashtable getHumanIDsForPFSH = new Hashtable();
        public static bool is_Menu_Level_PFSH = false;
        //public static bool is_True_Or_False_PFSHKey = false;
        //public static DateTime Birth_Date_For_Social = DateTime.MinValue;
        //public static bool HistorySaveButton = false;
        public static ulong select_physician_id = 0;
        //public static ulong ULPreviousEnc = 0;
        //public static bool Carrier = false;
        //public static bool KillCapella_For_Progress_notes = false;
        //public static bool Is_RosPrevEnc = false;
        //public static bool Is_GeneralExamPrevEnc = false;
        //public static bool Is_FocusedExamPrevEnc = false;
        //public static bool Is_SelectedAssesmentPrevEnc = false;
        //public static bool Is_RuledOutAssesmentPrevEnc = false;
        //public static bool Is_GeneralPlanPrevEnc = false;
        //public static bool Is_CarePlanPrevEnc = false;
        //public static bool Is_PreventivePlanPrevEnc = false;
        //public static bool Is_NonDrugPrevEnc = false;
        //public static bool Is_CCPrevEnc = false;
        //public static bool Is_PastVitalsClick = false;
        //public static string Template_Name = string.Empty;
        //public static int Template_Id = 0;
       // public static bool Is_VitalsPrevEnc = false;
       // public static bool Is_Autosave_No = false;
        //public static bool copyPrevious = false;
        //public static string DB_Filepath = string.Empty;//not in use
        public static bool IsAnnotation = false;
        //public static bool IsTestArea = false;
       // public static bool bFollowUpEncounterAssessment = false;
       // public static string sCMGTestDone = string.Empty;
        //public static ulong CMGEncounterProviderId = 0;
        public static ulong Individual_select_physician_Id = 0;
        public static bool Is_Cancel = false;
        //public static bool Is_Dictation = false;
       // public static Hashtable MyFormParameters = new Hashtable();
       // public static bool is_True_Or_False_PatientNoteKey = false;
        public static string PFSH_OpeingFrom = string.Empty;
       // public static ulong PFSH_Human_ID = 0;
       // public static ulong PFSH_Encounter_ID= 0;
       // public static ulong PFSH_Physician_ID = 0;
        //public static bool PatientSummaryBarRefreshed = false;
        public static bool bFollows_DST = false;
        public static Exception UnhandledException;
        public static string Encryptionbase64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }

            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }

        }

        public string InvokeMethod(string className, string methodName, string[] arguments)
        {

            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                string[] assemblyName = currentAssembly.FullName.ToString().Split(',');
                Type myType = currentAssembly.GetType(assemblyName[0] + '.' + className);
                MethodInfo myMethod = myType.GetMethod(methodName);
                object instance = Activator.CreateInstance(myType);
                return myMethod.Invoke(instance, arguments).ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
        public string ConvertInchesToCM(string s)
        {
            if (s == string.Empty)
            {
                return s;
            }
            decimal cmValue = decimal.Round((Convert.ToDecimal(s) * 2.54m), 2);
            return cmValue.ToString();
        }
        public string ConvertInchtoFeetInch(string s)
        {
            if (s == string.Empty)
            {
                return s;
            }
            decimal inch = Convert.ToDecimal(s);
            decimal feet = Math.Floor(inch / 12m);
            decimal remainInch = decimal.Round((inch % 12m), 2);
            return feet.ToString() + "'" + " " + remainInch.ToString() + "''";
        }
        //public string ConvertCelsiusToFarenheit(string s)
        //{
        //    if (s == string.Empty)
        //    {
        //        return s;
        //    }
        //    decimal cel = Convert.ToDecimal(s);
        //    decimal far = decimal.Round((cel * 9.0m / 5) + 32, 2);
        //    return far.ToString();
        //}
        public string ConvertFarenheitToCelsius(string s)
        {
            if (s == string.Empty)
            {
                return s;
            }
            decimal far = Convert.ToDecimal(s);
            decimal cel = decimal.Round((far - 32) / 1.8m, 2);
            return cel.ToString();
        }
        public string ConvertLbsToKg(string s)
        {
            if (s == string.Empty)
            {
                return s;
            }

            decimal kgValue = decimal.Round(Convert.ToDecimal(s) / 2.2m, 2);
            return kgValue.ToString();
        }
        public string ConvertKgToLbs(string s)
        {
            if (s == string.Empty)
            {
                return s;
            }
            decimal kgValue = Convert.ToDecimal(s);
            decimal lbsValue = decimal.Round(kgValue * 2.2m, 2);
            return lbsValue.ToString();
        }
        public string ConvertCMToInches(string s)
        {
            if (s == string.Empty)
            {
                return s;
            }
            decimal inValue = decimal.Round((Convert.ToDecimal(s) * 0.3937008m), 3);
            return inValue.ToString();
        }
        //public string ConvertCMToFeetInch(string s)
        //{
        //    if (s == string.Empty)
        //    {
        //        return s;
        //    }
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

        public string ConvertFeetInchToInch(string s1, string s2)
        {
            if (s1 == string.Empty)
            {
                return string.Empty;
            }
            decimal inValue = 0;
            if (s2 != string.Empty)
                inValue = decimal.Round((Convert.ToDecimal(s1) * 12m) + Convert.ToDecimal(s2), 2);
            else
                inValue = decimal.Round((Convert.ToDecimal(s1) * 12m), 2);
            if (inValue != 0m)
                return inValue.ToString();
            else
                return string.Empty;

        }
        //public string ConvertMmolToMg(string s)
        //{
        //    if (s == string.Empty)
        //    {
        //        return s;
        //    }
        //    decimal mg = decimal.Round((Convert.ToDecimal(s) * 18m), 2);
        //    return mg.ToString();
        //}
        //public string ConvertMgToMmol(string s)
        //{
        //    if (s == string.Empty)
        //    {
        //        return s;
        //    }
        //    decimal mg = decimal.Round((Convert.ToDecimal(s) / 18m), 2);
        //    return mg.ToString();
        //}
        //public string ConversionOnRetrieval(string vitalName, string vitalValue)
        //{
        //    int j = 0;
        //    string MethdName = ConvertInchtoFeetInch(vitalValue.ToString());
        //    string[] Splitter = { ".", "(", ",", ")" };
        //    string[] MthdInfo = MethdName.Split(Splitter, StringSplitOptions.RemoveEmptyEntries);
        //    if (MethdName.Length > 0)
        //    {

        //        string[] Arguments = new string[MthdInfo.Length];
        //        string ClassName = string.Empty;
        //        //string MethodName = MthdInfo[1];
        //        Arguments[j] = vitalValue;
        //        j++;
        //        return MethdName;
        //    }
        //    else
        //        return string.Empty;
        //}

        //public string CalculateBMIOnCMAndKG(string Height, string Weight)
        //{
        //    decimal BMI = 0;
        //    decimal HtVal = 0;
        //    decimal WtVal = 0;
        //    try
        //    {
        //        if (Height != string.Empty)
        //            HtVal = Convert.ToDecimal(Height);
        //        if (Weight != string.Empty)
        //            WtVal = Convert.ToDecimal(Weight);
        //        if (HtVal > 0 && WtVal > 0)
        //            BMI = decimal.Round(((WtVal / (HtVal * HtVal)) * 10000m), 1);
        //        if (BMI != 0)
        //            return BMI.ToString();
        //        else
        //            return string.Empty;
        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //}
        //public Page InvokeFormInstance(string sProcessMasterScnName, string sTagName)
        //{
        //    if (sProcessMasterScnName == string.Empty)
        //    {
        //        //RadMessageBox.Show("Cannot Dynamically Open the Form. Please Contact Administrator");
        //       // return null;
        //    }

        //    string[] Splitter = { ".", ".", ".", "(", ",", ")" };
        //    string[] MthdInfo = sProcessMasterScnName.Split(Splitter, StringSplitOptions.RemoveEmptyEntries);

        //    string sMyFormName = MthdInfo[0].ToString() + "." + MthdInfo[1].ToString() + "." + MthdInfo[2].ToString() + "." + MthdInfo[3].ToString();

        //    object[] Args = new object[MthdInfo.Length - 4];

        //    for (int i = 4; i < MthdInfo.Length; i++)
        //    {
        //        Args[i - 4] = MyFormParameters[MthdInfo[i]];
        //    }

        //    object FormTag = sTagName;

        //    Type FType = Type.GetType(sMyFormName, true, true);

        //    Page CurrentForm = (Page)Activator.CreateInstance(FType, Args);

        //    Page MyResultForm = null;

        //    Assembly currentAssembly = Assembly.GetExecutingAssembly();
        //   // List<Form> formsFromOtherAssemblies = new List<Form>();
        //    Boolean bExists = false;

        //    if (sTagName != string.Empty)
        //    {
        //        //foreach (RadForm form in System.Windows.Forms.Application.OpenForms)
        //        //{
        //            //if (Convert.ToInt32(form.Tag) == Convert.ToInt32(MyFormParameters[sTagName]))
        //            //{
        //            //    bExists = true;
        //            //    MyResultForm = form;
        //            //    break;
        //            //}
        //        //}
        //    }

        //    if (bExists == false)
        //    {
        //        MyResultForm = CurrentForm;
        //        if (sTagName != string.Empty)
        //        {
        //           // MyResultForm.Tag = MyFormParameters[sTagName];
        //        }
        //        //if (sProcessMasterScnName.Contains("-") == true)
        //        //{
        //        //    MyResultForm.Tag = FormTag;
        //        //}
        //    }

        //    return MyResultForm;
        //}
    }
}
