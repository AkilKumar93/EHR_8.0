using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using System.Reflection;
using System.IO;
using System.Collections;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.DataAccess;
using System.Data;
using System.Data.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Xml;


namespace Acurus.Capella.Lab_Agent
{
    public partial class RcopiaMedicationManager
    {
        public void RcopiaMedicationTempUpload()
        {

            Rcopia_Medication_TempManager objRMedTempmngr = new Rcopia_Medication_TempManager();
            Rcopia_MedicationManager objRMedmngr = new Rcopia_MedicationManager();

            Rcopia_Allergy_TempManager objRAllergyTempmngr = new Rcopia_Allergy_TempManager();
            Rcopia_AllergyManager objRAllergymngr = new Rcopia_AllergyManager();

            Rcopia_Update_InfoManager objUpdateInfoMngr = new Rcopia_Update_InfoManager();
            RCopiaSessionManager rcopiaSessionMngr = new RCopiaSessionManager();
            RCopiaTransactionManager objmngr = new RCopiaTransactionManager();
            UserManager objuser = new UserManager();

            
            IList<Rcopia_Medication_Temp> lstMed = new List<Rcopia_Medication_Temp>();
            IList<Rcopia_Medication_Temp> lstUpdateMed = new List<Rcopia_Medication_Temp>();

            IList<Rcopia_Allergy_Temp> lstAllergy = new List<Rcopia_Allergy_Temp>();
            IList<Rcopia_Allergy_Temp> lstUpdateAllergy = new List<Rcopia_Allergy_Temp>();

            IList<User> lstuser = new List<User>();
            
            string sRcopiaUser=string.Empty;
            DateTime dtClientDate = DateTime.Now;

            Console.WriteLine("Get Rcopia Physician...");
            lstuser = objuser.GetUserBasedonRole("Physician");
            
            Console.WriteLine("Get Rcopia Medication List ...");
            lstMed = objRMedTempmngr.GetRCopiaMedByStatus();

            Console.WriteLine("Get Rcopia Allergy List ...");
            lstAllergy = objRAllergyTempmngr.GetRCopiaAllergyByStatus();

            if(lstuser.Count>0)
                sRcopiaUser=lstuser[0].RCopia_User_Name;
           
            //Medication
            if (lstMed.Count > 0)
            {
                Console.WriteLine("Rcopia Medication Temp List Count : " + lstMed.Count);
                foreach (Rcopia_Medication_Temp objMedecationTemp in lstMed)
                {
                    Console.WriteLine("Send rcopia medication for patient id : " + objMedecationTemp.Human_ID);
                    objmngr = new RCopiaTransactionManager();
                    objmngr.SendPatientToRCopia(objMedecationTemp.Human_ID, string.Empty);
                    
                    objmngr = new RCopiaTransactionManager();
                    objmngr.SendMedicationToRCopia(objMedecationTemp, sRcopiaUser);

                }
                Console.WriteLine("Download rcopia Medication ... Processing...");
                objUpdateInfoMngr.DownloadRCopiaInfo(rcopiaSessionMngr.DownloadAddress, sRcopiaUser, string.Empty, dtClientDate, "", 0);
                
                string sTempDisId =string.Empty;
                var humanId = lstMed.Select(a => a.Human_ID).Distinct().ToList();
                foreach (var vhumanid in humanId)
                {
                    if (sTempDisId == string.Empty)

                        sTempDisId =vhumanid.ToString();
                    else
                        sTempDisId += ", " + vhumanid.ToString();
                }
              
                //Get Rcopia medication with distinct human Id
                IList<Rcopia_Medication> lstRcopiaMedicationCheck=new List<Rcopia_Medication>();
                Console.WriteLine("Get medication list to check medication temp datas are imported..");
                lstRcopiaMedicationCheck=objRMedmngr.GetRmedicationByHumanID(sTempDisId);

                if (lstRcopiaMedicationCheck.Count > 0)
                {
                    
                    //Compare medication and temp table
                    foreach (Rcopia_Medication_Temp objMedecationTemp in lstMed)
                    {
                        var lst = (from m in lstRcopiaMedicationCheck where m.Brand_Name == objMedecationTemp.Brand_Name && objMedecationTemp.Human_ID == m.Human_ID select m).ToList();
                        if (lst.Count > 0)
                        {
                            objMedecationTemp.Status = "IMPORTED";
                            lstUpdateMed.Add(objMedecationTemp);
                        }
                    }

                    //Update status in temp table
                    if (lstUpdateMed.Count > 0)
                    {
                        Console.WriteLine("Medication temp table update the status as IMPORTED...");
                        objRMedTempmngr = new Rcopia_Medication_TempManager();
                        objRMedTempmngr.UpdateToRcopia_Medication_Temp(lstUpdateMed);
                    }
                }
            }
            Console.WriteLine("Medication end..."+Environment.NewLine);

            Console.WriteLine("Allergy start..." + Environment.NewLine);
            //Allergy
            if (lstAllergy.Count > 0)
            {
                Console.WriteLine("Rcopia Allergy Temp List Count : " + lstAllergy.Count);
               // DBConnector dbInstance = new DBConnector();
                foreach (Rcopia_Allergy_Temp objAllergyTemp in lstAllergy)
                {
                    //DataSet dsReturn = dbInstance.ReadData("select PRODUCT_NDC from ndc where brand_name like '%" + objAllergyTemp.Allergy_Name + "%'");
                    //if (dsReturn.Tables[0].Rows.Count < 0)
                    //{
                    //    DataRow item = dsReturn.Tables[0].Rows[0];
                    //    objAllergyTemp.NDC_ID = item["PRODUCT_NDC"].ToString();
                    //}
                    Console.WriteLine("Send Rcopia Allergy for patient id : " + objAllergyTemp.Human_ID);
                    objAllergyTemp.NDC_ID = "67253020011";
                    objAllergyTemp.Status = "Active";
                    objmngr = new RCopiaTransactionManager();
                    objmngr.SendPatientToRCopia(objAllergyTemp.Human_ID, string.Empty);

                    objmngr = new RCopiaTransactionManager();
                    objmngr.SendAllergyToRCopia(objAllergyTemp, sRcopiaUser);

                }
                Console.WriteLine("Download rcopia Allergy...");
                objUpdateInfoMngr.DownloadRCopiaInfo(rcopiaSessionMngr.DownloadAddress, sRcopiaUser, string.Empty, dtClientDate, "", 0);

                string sTempDisId = string.Empty;
                var humanId = lstAllergy.Select(a => a.Human_ID).Distinct().ToList();
                foreach (var vhumanid in humanId)
                {
                    if (sTempDisId == string.Empty)

                        sTempDisId = vhumanid.ToString();
                    else
                        sTempDisId += ", " + vhumanid.ToString();
                }

                //Get Rcopia medication with distinct human Id
                IList<Rcopia_Allergy> lstRcopiaAllergyCheck = new List<Rcopia_Allergy>();
                lstRcopiaAllergyCheck = objRAllergymngr.GetRAllergyByHumanID(sTempDisId);

                if (lstRcopiaAllergyCheck.Count > 0)
                {
                    //Compare medication and temp table
                    foreach (Rcopia_Allergy_Temp objAllergyTemp in lstAllergy)
                    {
                        var lst = (from m in lstRcopiaAllergyCheck where m.Allergy_Name == objAllergyTemp.Allergy_Name && objAllergyTemp.Human_ID == m.Human_ID select m).ToList();
                        if (lst.Count > 0)
                        {
                            objAllergyTemp.Status = "IMPORTED";
                            lstUpdateAllergy.Add(objAllergyTemp);
                        }
                    }

                    //Update status in temp table
                    if (lstUpdateAllergy.Count > 0)
                    {
                        objRAllergyTempmngr = new Rcopia_Allergy_TempManager();
                        objRAllergyTempmngr.UpdateToRcopia_Allergy_Temp(lstUpdateAllergy);
                    }
                }
            }
            Console.WriteLine("Allergy end...");

        }
    }
    public class DBConnector
    {
        MySqlDataAdapter MyDataAdap = null;

        private string ReadConnection()
        {
            string ConnectionData;
            ConnectionData = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;
            return ConnectionData;
        }

        public DataSet ReadData(string Query)
        {
            DataSet DsReturn = new DataSet();
            MyDataAdap = new MySqlDataAdapter(Query, ReadConnection());
            MyDataAdap.Fill(DsReturn);
            return DsReturn;
        }

        //public bool CreateFile(StringBuilder sbrContent, string FileName)
        //{
        //    bool status = false;


        //    string OutputDir = ConfigurationManager.AppSettings["Output"];

        //    if (!Directory.Exists(OutputDir))
        //    {
        //        Directory.CreateDirectory(OutputDir);

        //    }

        //    string OutputFile = ConfigurationManager.AppSettings["Output"] + FileName;

        //    System.IO.File.WriteAllText(OutputFile, sbrContent.ToString());

        //    return status;

        //}

    }
}
