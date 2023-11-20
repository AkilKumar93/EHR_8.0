using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.Serialization;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IRuleMasterManager : IManagerBase<RuleMaster, ulong>
    {
        IList<RuleDTO> SaveRuleDTO(RuleMaster objRuleMaster, IList<RuleProblem> objRuleProblem, IList<RuleMedicationAndAllergy> objRuleMedication, IList<RuleLabResultReminder> objRuleLabResult, string sMacAddress, string strStatus, string sLegalOrg);
        Stream SearchRuleName(string RuleName, int pageNumber, int maxResultPerPage, string sLegalOrg);
        IList<RuleDTO> GetAllRule(string strStatus, string sLegalOrg);
        IList<RuleDTO> UpdateRuleDTO(RuleMaster objRuleMaster, Hashtable objRuleProblem, Hashtable objRuleMedication, Hashtable objRuleLabResult, string sMacAddress, string strStatus);
        IList<RuleDTO> DeleteRuleDTO(RuleMaster objRuleMaster, string sMacAddress, string strStatus, string sLegalOrg);
        DataSet GetPatientRemainderForRuleId(ulong ulRuleId, int ulPhysicianID, DateTime dtLocalTime);
        IList<RuleMaster> GetRuleName(string sLegalOrg);
        IList<RuleMaster> GetRuleName(int id, string sLegalOrg);
    }

    public partial class RuleMasterManager : ManagerBase<RuleMaster, ulong>, IRuleMasterManager
    {

        #region Constructors

        public RuleMasterManager()
            : base()
        {

        }
        public RuleMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods


        public IList<RuleDTO> SaveRuleDTO(RuleMaster objRuleMaster, IList<RuleProblem> objRuleProblem, IList<RuleMedicationAndAllergy> objRuleMedication, IList<RuleLabResultReminder> objRuleLabResult, string sMacAddress, string strStatus, string sLegalOrg)
        {
            int iTryCount = 0;
            GenerateXml XMLObj = new GenerateXml();
        TryAgain:
            int iResult = 0;
            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            ulong ulRuleId = 0;
            try
            {
                trans = MySession.BeginTransaction();
                if (objRuleMaster != null && objRuleMaster.Id == 0)
                {
                    IList<RuleMaster> saveList = new List<RuleMaster>();
                    saveList.Add(objRuleMaster);
                    IList<RuleMaster> saveListnull = null;
                    //iResult = SaveUpdateDeleteWithoutTransaction(ref saveList, null, null, MySession, sMacAddress);
                    iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref saveList, ref saveListnull, null, MySession, sMacAddress, false, true, 0, string.Empty, ref XMLObj); 
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                    ulRuleId = saveList[0].Id;
                }
                else
                {
                    IList<RuleMaster> saveList = new List<RuleMaster>();
                    IList<RuleMaster> UpdateList = new List<RuleMaster>();
                    UpdateList.Add(objRuleMaster);
                    //iResult = SaveUpdateDeleteWithoutTransaction(ref saveList, UpdateList, null, MySession, sMacAddress);
                    iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref saveList, ref UpdateList, null, MySession, sMacAddress, false, true, 0, string.Empty, ref XMLObj);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                    ulRuleId = objRuleMaster.Id;
                    # region Delete
                    IList<RuleProblem> prob = MySession.CreateCriteria(typeof(RuleProblem)).Add(Expression.Eq("Rule_Master_ID", ulRuleId)).List<RuleProblem>();
                    if (prob != null && prob.Count > 0)
                    {
                        RuleProblemManager ObjRuleProblemMgr = new RuleProblemManager();
                        iResult = ObjRuleProblemMgr.DeleteRuleProblem(prob, sMacAddress, MySession);

                        if (iResult == 2)
                        {
                            if (iTryCount < 5)
                            {
                                iTryCount++;
                                goto TryAgain;
                            }
                            else
                            {
                                trans.Rollback();
                                //  MySession.Close();
                                throw new Exception("Deadlock occurred. Transaction failed.");
                            }
                        }
                        else if (iResult == 1)
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Exception occurred. Transaction failed.");
                        }
                    }
                    IList<RuleMedicationAndAllergy> med = session.GetISession().CreateCriteria(typeof(RuleMedicationAndAllergy)).Add(Expression.Eq("Rule_Master_ID", ulRuleId)).List<RuleMedicationAndAllergy>();
                    if (med != null && med.Count > 0)
                    {
                        RuleMedicationAndAllergyManager ObjRuleMedicationMgr = new RuleMedicationAndAllergyManager();
                        iResult = ObjRuleMedicationMgr.DeleteRuleMedicationAllergy(med, sMacAddress, MySession);

                        if (iResult == 2)
                        {
                            if (iTryCount < 5)
                            {
                                iTryCount++;
                                goto TryAgain;
                            }
                            else
                            {
                                trans.Rollback();
                                //  MySession.Close();
                                throw new Exception("Deadlock occurred. Transaction failed.");
                            }
                        }
                        else if (iResult == 1)
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Exception occurred. Transaction failed.");
                        }
                    }
                    IList<RuleLabResultReminder> Lab = session.GetISession().CreateCriteria(typeof(RuleLabResultReminder)).Add(Expression.Eq("Rule_Master_ID", ulRuleId)).List<RuleLabResultReminder>();
                    if (Lab != null && Lab.Count > 0)
                    {
                        RuleLabResultReminderManager ObjRuleLabResultMgr = new RuleLabResultReminderManager();
                        iResult = ObjRuleLabResultMgr.DeleteRuleLabResult(Lab, sMacAddress, MySession);

                        if (iResult == 2)
                        {
                            if (iTryCount < 5)
                            {
                                iTryCount++;
                                goto TryAgain;
                            }
                            else
                            {
                                trans.Rollback();
                                //  MySession.Close();
                                throw new Exception("Deadlock occurred. Transaction failed.");
                            }
                        }
                        else if (iResult == 1)
                        {
                            trans.Rollback();
                            // MySession.Close();
                            throw new Exception("Exception occurred. Transaction failed.");
                        }
                    }


                    #endregion

                }

                if (objRuleProblem != null && objRuleProblem.Count > 0)
                {
                    for (int i = 0; i < objRuleProblem.Count; i++)
                    {
                        objRuleProblem[i].Rule_Master_ID = ulRuleId;
                    }
                    RuleProblemManager ObjRuleProblemMgr = new RuleProblemManager();
                    iResult = ObjRuleProblemMgr.SaveRuleProblem(objRuleProblem, sMacAddress, MySession);

                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //  MySession.Close();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                }

                if (objRuleMedication != null && objRuleMedication.Count > 0)
                {
                    for (int i = 0; i < objRuleMedication.Count; i++)
                    {
                        objRuleMedication[i].Rule_Master_ID = ulRuleId;
                    }
                    RuleMedicationAndAllergyManager ObjRuleMedicationMgr = new RuleMedicationAndAllergyManager();
                    iResult = ObjRuleMedicationMgr.SaveRuleMedicationAllergy(objRuleMedication, sMacAddress, MySession);

                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //  MySession.Close();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                }

                if (objRuleLabResult != null && objRuleLabResult.Count > 0)
                {
                    for (int i = 0; i < objRuleLabResult.Count; i++)
                    {
                        objRuleLabResult[i].Rule_Master_ID = ulRuleId;
                    }
                    RuleLabResultReminderManager ObjRuleLabResultMgr = new RuleLabResultReminderManager();
                    iResult = ObjRuleLabResultMgr.SaveRuleLabResult(objRuleLabResult, sMacAddress, MySession);

                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //  MySession.Close();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        // MySession.Close();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                }

                //MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                MySession.Close();
            }
            return GetAllRule(strStatus,sLegalOrg);
        }


        public IList<RuleDTO> GetAllRule(string strStatus, string sLegalOrg)
        {
            IList<RuleDTO> RuleDto = new List<RuleDTO>();
            RuleDTO objDTO = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(RuleMaster)).Add(Expression.Eq("Is_Status", strStatus)).AddOrder(Order.Desc("Modified_Date_And_Time"));
                if (crt.List<RuleMaster>().Count > 0)
                {
                    foreach (RuleMaster objRuleMaster in crt.List<RuleMaster>())
                    {
                        objDTO = new RuleDTO();
                        objDTO.Rule_Master = objRuleMaster;

                        ICriteria crt2 = iMySession.CreateCriteria(typeof(RuleProblem)).Add(Expression.Eq("Rule_Master_ID", objRuleMaster.Id));
                        objDTO.Rule_Problem = crt2.List<RuleProblem>();

                        ICriteria crt3 = iMySession.CreateCriteria(typeof(RuleMedicationAndAllergy)).Add(Expression.Eq("Rule_Master_ID", objRuleMaster.Id));
                        objDTO.Rule_Medication_And_Allergy = crt3.List<RuleMedicationAndAllergy>();

                        ICriteria crt4 = iMySession.CreateCriteria(typeof(RuleLabResultReminder)).Add(Expression.Eq("Rule_Master_ID", objRuleMaster.Id));
                        objDTO.Rule_lab_Result_Reminder = crt4.List<RuleLabResultReminder>();

                        RuleDto.Add(objDTO);
                    }
                }
                iMySession.Close();
            }
            return RuleDto;
        }


        public IList<RuleDTO> UpdateRuleDTO(RuleMaster objRuleMaster, Hashtable objRuleProblem, Hashtable objRuleMedication, Hashtable objRuleLabResult, string sMacAddress, string strStatus)
        {
            throw new NotImplementedException();
        }

        public IList<RuleDTO> DeleteRuleDTO(RuleMaster objRuleMaster, string sMacAddress, string strStatus, string sLegalOrg)
        {
            IList<RuleMaster> SaveList = null;
            IList<RuleMaster> DeleteList = new List<RuleMaster>();
            DeleteList.Add(objRuleMaster);
           // SaveUpdateDeleteWithTransaction(ref SaveList, null, DeleteList, sMacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveList, ref SaveList, DeleteList, string.Empty, false, true, 0, string.Empty);           
            return GetAllRule(strStatus,sLegalOrg);
        }

        public Stream SearchRuleName(string RuleName, int pageNumber, int maxResultPerPage, string sLegalOrg)
        {
            var stream = new MemoryStream();
            var serializer = new NetDataContractSerializer();
            IList<string> ilstRulelist = new List<string>();
            pageNumber = pageNumber - 1;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                string query = "select cast(concat(Rule_Master_Id,'|',Rule_Name,'|',Rule_Description,'|',Last_Run_Date,'|',Expected_Action,'|',Frequency,'|',Alert) as char(1024)) from rule_master where Rule_Name like " + "'%" + RuleName + "%' and Is_Status='Active' and Legal_Org ='"+sLegalOrg+"'";
                ilstRulelist = iMySession.CreateSQLQuery(query).SetMaxResults(maxResultPerPage).SetFirstResult(pageNumber * maxResultPerPage).List<string>();
                
                Hashtable ruleResult = new Hashtable();
                ruleResult.Add("RuleList", ilstRulelist);

                if (pageNumber == 0)
                    ruleResult.Add("TotalCount", iMySession.CreateSQLQuery(query).List<string>().Count);
                iMySession.Close();

                serializer.WriteObject(stream, ruleResult);
                stream.Seek(0L, SeekOrigin.Begin);
            }
            return stream;
        }

      
        public DataSet GetPatientRemainderForRuleId(ulong ulRuleId, int ulPhysicianID, DateTime dtLocalTime)
        {
            IList<ProblemList> ilstProblemList = new List<ProblemList>();
            IList<Rcopia_Medication> ilstRcopia_Medication = new List<Rcopia_Medication>();
            IList<Rcopia_Allergy> ilstRcopia_Allergy = new List<Rcopia_Allergy>();
            IList<Orders> ilstOrder = new List<Orders>();
            IList<ResultMaster> ilstResultMaster = new List<ResultMaster>();
            IList<ResultOBX> ilstResultOBX = new List<ResultOBX>();
            DataSet dsRule = new DataSet();
            //IList<Human> Humlst = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(RuleMaster)).Add(Expression.Eq("Id", ulRuleId));
                IList<RuleMaster> ilstRuleMaster = crt.List<RuleMaster>();
                if (ilstRuleMaster != null && ilstRuleMaster.Count > 0)
                {
                    string strFinalQuery = string.Empty;
                    string sFreq = Convert.ToString(ilstRuleMaster[0].Frequency);
                    string sAlert = Convert.ToString(ilstRuleMaster[0].Alert);
                    if (sFreq != "0")
                    {
                        DateTime dtLast = DateTime.MinValue;
                        if (ilstRuleMaster[0].Last_Run_Date == DateTime.MinValue)
                            dtLast = DateTime.Now;
                        else
                            dtLast = ilstRuleMaster[0].Last_Run_Date;
                        int iLowerLimit = Convert.ToInt32(sFreq) - Convert.ToInt32(sAlert);
                        int iUpperLimit = Convert.ToInt32(sFreq) + (DateTime.Now).Subtract(dtLast).Days;
                        DateTime dtUpper = (DateTime.Now).AddDays(-iUpperLimit);
                        DateTime dtLower = (DateTime.Now).AddDays(-iLowerLimit);
                        strFinalQuery = "select h.Human_ID,concat(h.Last_Name,' , ',h.First_Name,' ',h.MI) as Patient_Name,cast(h.Birth_date as char(20)) as DOB, h.Preferred_Confidential_Correspodence_Mode,h.Preferred_Language,h.Home_Phone_No,h.Cell_Phone_Number,h.Work_Phone_No, cast(h.Created_Date_And_Time as char(30)) as CreatedDateTime ,h.EMail,h.Sex,h.Ethnicity,h.Race,h.Preferred_Language,'Problem','ProblemDateTime#','Medication','MedicationDateTime#','MedAlergy','MedAlergyDateTime#','LabResult','LabResultDateTime#' from human h ";
                    }
                    else
                        strFinalQuery = "select h.Human_ID,concat(h.Last_Name,' , ',h.First_Name,' ',h.MI) as Patient_Name,cast(h.Birth_date as char(20)) as DOB, h.Preferred_Confidential_Correspodence_Mode,h.Preferred_Language,h.Home_Phone_No,h.Cell_Phone_Number,h.Work_Phone_No,cast(h.Created_Date_And_Time as char(30)) as CreatedDateTime,h.EMail,h.Sex,h.Ethnicity,h.Race,h.Preferred_Language ,'Problem','ProblemDateTime#','Medication','MedicationDateTime#','MedAlergy','MedAlergyDateTime#','LabResult','LabResultDateTime#' from human h ";
                    string sAgeQuery = string.Empty;
                    string FromAge = Convert.ToString(ilstRuleMaster[0].From_Age);
                    string ToAge = Convert.ToString(ilstRuleMaster[0].To_Age);
                    string sGender = ilstRuleMaster[0].Gender;
                    if (FromAge != string.Empty)
                        sAgeQuery = "12* date_format(FROM_DAYS(TO_DAYS('" + dtLocalTime.ToString("yyyy-MM-dd") + "')-TO_DAYS(h.birth_date)),'%Y')+date_format(FROM_DAYS(TO_DAYS('" + dtLocalTime.ToString("yyyy-MM-dd") + "')-TO_DAYS(h.birth_date)),'%m')>='" + FromAge + "'";
                    if (ToAge != string.Empty)
                        sAgeQuery += "and 12* date_format(FROM_DAYS(TO_DAYS('" + dtLocalTime.ToString("yyyy-MM-dd") + "')-TO_DAYS(h.birth_date)),'%Y')+date_format(FROM_DAYS(TO_DAYS('" + dtLocalTime.ToString("yyyy-MM-dd") + "')-TO_DAYS(h.birth_date)),'%m')<='" + ToAge + "'";

                    IList<ulong> lstHumanId = new List<ulong>();
                    #region Commented
                    //#region Rule_problem_ProblemList
                    //ISQLQuery Query=iMySession.CreateSQLQuery("select distinct(human_id) from (select * from rule_problem where rule_master_id="+ulRuleId+") as rule_set join (select * from problem_list where is_active='Y') as prob_list on rule_set.icd=prob_list.icd");
                    //IList<UInt32> ilstHuman = Query.List<UInt32>();
                    //if (ilstHuman != null)
                    //    lstHumanId = lstHumanId.Concat(ilstHuman.Select(a => (UInt64)a).ToList()).ToList();
                    //#endregion
                    //#region Rule_MedicationAllergy_Rcopia_Med
                    //ISQLQuery Query_med=iMySession.CreateSQLQuery("Select distinct(human_id) from (select * from rule_medication_and_allergy where rule_master_id="+ulRuleId+" and type='medication') as rule_med_al join (select * from rcopia_medication where deleted = 'N' ) as rcopia_med on rule_med_al.drug_name = rcopia_med.generic_name");
                    //IList<UInt32> ilstHuman_med = Query_med.List<UInt32>();
                    //if (ilstHuman_med != null)
                    //    lstHumanId = lstHumanId.Concat(ilstHuman_med.Select(a => (UInt64)a).ToList()).ToList();
                    //#endregion
                    //#region Rule_MedicationAllergy_Rcopia_Allergy
                    //ISQLQuery Query_Allergy=iMySession.CreateSQLQuery("Select distinct(human_id) from (select * from rule_medication_and_allergy where rule_master_id="+ulRuleId+" and type !='medication') as rule_med_al join (select * from Rcopia_Allergy where deleted = 'N' ) as rcopia_alrgy on rule_med_al.drug_name = rcopia_alrgy.Allergy_Name");
                    //IList<UInt32> ilstHuman_Allergy = Query_Allergy.List<UInt32>();
                    //if (ilstHuman_Allergy != null)
                    //    lstHumanId = lstHumanId.Concat(ilstHuman_Allergy.Select(a => (UInt64)a).ToList()).ToList();
                    //#endregion
                    //#region Rule_lab_result_reminder
                    //ICriteria crt4 = iMySession.CreateCriteria(typeof(RuleLabResultReminder)).Add(Expression.Eq("Rule_Master_ID", ulRuleId));
                    //IList<RuleLabResultReminder> ilstLabResult = crt4.List<RuleLabResultReminder>();
                    //if (ilstLabResult != null && ilstLabResult.Count > 0)
                    //{
                    //    String lstNDC = String.Join(",", ilstLabResult.Select(a => a.Loinc.ToString()).ToArray());
                    //    ISQLQuery Query_rulelab = iMySession.CreateSQLQuery("select distinct(matching_patient_id) from result_master where matching_patient_id != 0 and result_master_id in ( select distinct(result_master_id) from result_obx where obx_loinc_identifier in (" + lstNDC + "))");
                    //    IList<UInt32> ilstHuman_rulelab = Query_rulelab.List<UInt32>();
                    //    if (ilstHuman_rulelab != null)
                    //        lstHumanId = lstHumanId.Concat(ilstHuman_rulelab.Select(a => (UInt64)a).ToList()).ToList();
                    //}
                 
                   
                    //IList<string> tempHumID = new List<string>();
                    //string HumId = string.Empty;
                    //if (lstHumanId.Count > 0)
                    //{

                    //    foreach (ulong id in lstHumanId)
                    //    {
                    //        tempHumID.Add(id.ToString());
                    //    }
                    //    HumId = string.Join(",", tempHumID.ToArray());
                    //}
                   
                    //string WhereCondition = string.Empty;
                    //if (sGender != string.Empty || ilstRuleMaster[0].Race != string.Empty || ilstRuleMaster[0].Ethnicity != string.Empty || ilstRuleMaster[0].Communication != string.Empty)
                    //{
                       
                    //    if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //    else if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                    //    }
                    //    else if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Communication != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                    //    {
                    //        WhereCondition = "and Ethnicity= '" + ilstRuleMaster[0].Ethnicity + "' and Race= '" + ilstRuleMaster[0].Race + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //    else if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                    //    {
                    //        WhereCondition = "and Race= '" + ilstRuleMaster[0].Race + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                    //    }
                    //    else if (sGender != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                    //    }
                    //    else if (sGender != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                    //    {
                    //        WhereCondition = "and Race= '" + ilstRuleMaster[0].Race + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Ethnicity != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                    //    {
                    //        WhereCondition = "and Ethnicity= '" + ilstRuleMaster[0].Ethnicity + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //    else if (sGender != string.Empty)
                    //    {
                    //        WhereCondition = "and Sex= '" + sGender + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Race != string.Empty)
                    //    {
                    //        WhereCondition = "and Race= '" + ilstRuleMaster[0].Race + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Ethnicity != string.Empty)
                    //    {
                    //        WhereCondition = "and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                    //    }
                    //    else if (ilstRuleMaster[0].Communication != string.Empty)
                    //    {
                    //        WhereCondition = "and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                    //    }
                    //}
                      #endregion

                    ICriteria crt2 = iMySession.CreateCriteria(typeof(RuleProblem)).Add(Expression.Eq("Rule_Master_ID", ulRuleId));
                    IList<RuleProblem> ilstProblem = crt2.List<RuleProblem>();
                    IList<ulong> lstHumanIdnew = new List<ulong>();
                    #region ProblemList
                    string sProblemQuery = string.Empty;
                    if (ilstProblem.Count > 0)
                    {
                        Object[] lstICD = ilstProblem.Select(a => a.ICD).ToArray();
                        //ICriteria Assessmentcrt2 = session.GetISession().CreateCriteria(typeof(Assessment)).Add(Expression.In("ICD_9", lstICD));
                        //IList<Assessment> ilstAssessment = Assessmentcrt2.List<Assessment>();
                        ICriteria ProblemListcrt2 = iMySession.CreateCriteria(typeof(ProblemList)).Add(Expression.In("ICD", lstICD));
                        ilstProblemList = ProblemListcrt2.List<ProblemList>();
                        // if(ilstAssessment.Count>0)
                        //   lstHumanId = ilstAssessment.Select(a => a.Human_ID).Distinct().ToList<ulong>();
                        if (ilstProblemList.Count > 0)
                            lstHumanId = ilstProblemList.Select(a => a.Human_ID).Distinct().ToList<ulong>();
                    }
                    #endregion
                    #region Medication&Medication Alergy
                    ICriteria crt3 = iMySession.CreateCriteria(typeof(RuleMedicationAndAllergy)).Add(Expression.Eq("Rule_Master_ID", ulRuleId));
                    IList<RuleMedicationAndAllergy> ilstMedication = crt3.List<RuleMedicationAndAllergy>();
                    if (ilstMedication != null && ilstMedication.Count > 0)
                    {
                        IList<RuleMedicationAndAllergy> lstMed = ilstMedication.Where(med => med.Type == "MEDICATION").ToList<RuleMedicationAndAllergy>();
                        if (lstMed.Count > 0)
                        {
                            string alergy = lstMed[0].Drug_Name;
                            ICriteria crtRcopia_Medication = iMySession.CreateCriteria(typeof(Rcopia_Medication)).Add(Restrictions.Like("Generic_Name", "%" + alergy + "%")); ;
                            ilstRcopia_Medication = crtRcopia_Medication.List<Rcopia_Medication>();
                            if (ilstRcopia_Medication.Count > 0)
                                lstHumanId = lstHumanId.Concat(ilstRcopia_Medication.Select(a => a.Human_ID).Distinct().ToList<ulong>()).Distinct().ToList();
                        }
                        IList<RuleMedicationAndAllergy> lstAlergy = ilstMedication.Where(med => med.Type != "MEDICATION").ToList<RuleMedicationAndAllergy>();
                        if (lstAlergy.Count > 0)
                        {
                            string alergy = lstAlergy[0].Drug_Name;
                            ICriteria crtRcopia_Allergy = iMySession.CreateCriteria(typeof(Rcopia_Allergy)).Add(Restrictions.Like("Allergy_Name", "%" + alergy + "%")); ;
                            ilstRcopia_Allergy = crtRcopia_Allergy.List<Rcopia_Allergy>();
                            //ICriteria crtRcopia_Allergy = session.GetISession().CreateCriteria(typeof(Rcopia_Allergy)).Add(Expression.In("NDC_ID", lstNDC));
                            //ilstRcopia_Allergy = crtRcopia_Allergy.List<Rcopia_Allergy>();
                            if (ilstRcopia_Allergy.Count > 0)
                                lstHumanId = lstHumanId.Concat(ilstRcopia_Allergy.Select(a => a.Human_ID).Distinct().ToList<ulong>()).ToList();
                        }
                    }
                    #endregion
                    ICriteria crt4 = iMySession.CreateCriteria(typeof(RuleLabResultReminder)).Add(Expression.Eq("Rule_Master_ID", ulRuleId));
                    IList<RuleLabResultReminder> ilstLabResult = crt4.List<RuleLabResultReminder>();
                    if (ilstLabResult != null && ilstLabResult.Count > 0)
                    {
                        Object[] lstNDC = ilstLabResult.Select(a => a.Loinc).ToArray();
                        ICriteria crtResultOBX = iMySession.CreateCriteria(typeof(ResultOBX)).Add(Expression.In("OBX_Loinc_Identifier", lstNDC));
                        ilstResultOBX = crtResultOBX.List<ResultOBX>();
                        Object[] lstResultMasID = ilstResultOBX.Select(a => a.Result_Master_ID.ToString()).ToArray();
                        ICriteria crtResultMaster = iMySession.CreateCriteria(typeof(ResultMaster)).Add(Expression.In("Id", lstResultMasID));
                        ilstResultMaster = crtResultMaster.List<ResultMaster>();
                        //Object[] lstOrderID = ilstResultMaster.Select(a => a.Matching_Patient_Id.ToString()).ToArray();
                        // ICriteria crtOrder = session.GetISession().CreateCriteria(typeof(Orders)).Add(Expression.In("Id", lstOrderID));
                        //ilstOrder = crtOrder.List<Orders>();
                        if (ilstResultMaster.Count > 0)
                            lstHumanId = lstHumanId.Concat(ilstResultMaster.Select(a => a.Matching_Patient_Id).ToList<ulong>()).Distinct().ToList();
                    }

                    IList<Human> ilstHuman = new List<Human>();
                    IList<string> tempHumID = new List<string>();
                    string HumId = string.Empty;
                    if (lstHumanId.Count > 0)
                    {

                        foreach (ulong id in lstHumanId)
                        {
                            tempHumID.Add(id.ToString());
                        }
                        HumId = string.Join(",", tempHumID.ToArray());
                    }
                     string WhereCondition = string.Empty;
                    if (sGender != string.Empty || ilstRuleMaster[0].Race != string.Empty || ilstRuleMaster[0].Ethnicity != string.Empty || ilstRuleMaster[0].Communication != string.Empty)
                    {
                        if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        else if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                        }
                        else if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        else if (ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Communication != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                        {
                            WhereCondition = "and Ethnicity= '" + ilstRuleMaster[0].Ethnicity + "' and Race= '" + ilstRuleMaster[0].Race + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        else if (sGender != string.Empty && ilstRuleMaster[0].Race != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "' and Race= '" + ilstRuleMaster[0].Race + "'";
                        }
                        else if (ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                        {
                            WhereCondition = "and Race= '" + ilstRuleMaster[0].Race + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                        }
                        else if (sGender != string.Empty && ilstRuleMaster[0].Ethnicity != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "' and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                        }
                        else if (sGender != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        else if (ilstRuleMaster[0].Race != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                        {
                            WhereCondition = "and Race= '" + ilstRuleMaster[0].Race + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        else if (ilstRuleMaster[0].Ethnicity != string.Empty && ilstRuleMaster[0].Communication != string.Empty)
                        {
                            WhereCondition = "and Ethnicity= '" + ilstRuleMaster[0].Ethnicity + "' and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        else if (sGender != string.Empty)
                        {
                            WhereCondition = "and Sex= '" + sGender + "'";
                        }
                        else if (ilstRuleMaster[0].Race != string.Empty)
                        {
                            WhereCondition = "and Race= '" + ilstRuleMaster[0].Race + "'";
                        }
                        else if (ilstRuleMaster[0].Ethnicity != string.Empty)
                        {
                            WhereCondition = "and Ethnicity='" + ilstRuleMaster[0].Ethnicity + "'";
                        }
                        else if (ilstRuleMaster[0].Communication != string.Empty)
                        {
                            WhereCondition = "and Preferred_Confidential_Correspodence_Mode='" + ilstRuleMaster[0].Communication + "'";
                        }
                        //--START Performance tuning-- to avoid HUman table hit twice. 
                        //if (HumId != string.Empty)
                        //{
                        //    //BUGID:44718
                        //    //WhereCondition = WhereCondition + " and human_id in ( " + HumId + " )";
                        //    //ISQLQuery sql = iMySession.CreateSQLQuery("select * from human " + WhereCondition).AddEntity("c", typeof(Human));
                        //    //ilstHuman = sql.List<Human>();

                        //    //Performance improvement
                        //    WhereCondition = WhereCondition + " and human_id in ( " + HumId + " )";
                        //    //ISQLQuery sql = iMySession.CreateSQLQuery("select human_id from human " + WhereCondition).AddEntity("c", typeof(Human));
                        //    //ilstHuman = sql.List<ulong>();
                        //    ISQLQuery sql = iMySession.CreateSQLQuery("select human_id from human " + WhereCondition);
                        //    IList<UInt32> ilstHuman5 = sql.List<UInt32>();
                        //    if (ilstHuman5 != null)
                        //        lstHumanId = ilstHuman5.Select(a => (UInt64)a).ToList();
                        //}
                        //else
                        //{
                        //    //BUGID:44718
                        //    //ISQLQuery sql = iMySession.CreateSQLQuery("select * from human " + WhereCondition).AddEntity("c", typeof(Human));
                        //    //ilstHuman = sql.List<Human>();
                        //    //ISQLQuery sql = iMySession.CreateSQLQuery("select human_id from human " + WhereCondition).AddEntity("c", typeof(Human));
                        //    //ilstHuman = sql.List<ulong>();
                        //    ISQLQuery sql = iMySession.CreateSQLQuery("select human_id from human " + WhereCondition);
                        //    IList<UInt32> ilstHuman6 = sql.List<UInt32>();
                        //    if (ilstHuman6 != null)
                        //        lstHumanId = ilstHuman6.Select(a => (UInt64)a).ToList();

                        //}
                        ////lstHumanId = ilstHuman.Select(a => a.Id).ToList();//BUGID:44718
                        //-- END Performance tuning--

                    }
                    #endregion
                    if (lstHumanId.Count > 0)
                    {
                        tempHumID.Clear();
                        foreach (ulong id in lstHumanId)
                        {
                            tempHumID.Add(id.ToString());
                        }
                        HumId = string.Join(",", tempHumID.ToArray());
                        strFinalQuery += "where h.Human_id in(" + HumId + ")";

                        if (sAgeQuery != string.Empty)
                        {
                            if (!sAgeQuery.StartsWith("and"))
                                sAgeQuery = "and " + sAgeQuery;

                        }
                    }
                    else if (sAgeQuery != string.Empty)
                    {
                        if (sAgeQuery.StartsWith("and"))
                            sAgeQuery = "where " + sAgeQuery.Remove(0, 3);

                        else
                            sAgeQuery = "where " + sAgeQuery;
                    }
                    else
                        sAgeQuery = "where h.human_id=' '";

                    IList<object> List = iMySession.CreateSQLQuery(strFinalQuery + sAgeQuery + WhereCondition + " Group by h.human_id").List<object>();
                    DataTable dtRule = new DataTable();
                    ArrayList aryrule = null;
                    IQuery query1 = iMySession.GetNamedQuery("Fill.PatientReminder.Heading");
                    aryrule = new ArrayList(query1.List());
                    if (aryrule.Count > 0)
                    {
                        object[] objRuleColumns = (object[])aryrule[0];

                        for (int i = 0; i < objRuleColumns.Length; i++)
                        {

                            dtRule.Columns.Add(objRuleColumns[i].ToString(), typeof(System.String));
                        }
                    }
                    IList<ulong> HumanList = new List<ulong>();
                    DataRow drRule = null;
                    foreach (object[] obj in List)
                    {
                        drRule = dtRule.NewRow();
                        for (int m = 0; m < obj.Length; m++)
                        {
                            if (m == 0)
                                HumanList.Add(Convert.ToUInt64(obj[m]));


                            if (obj[m].ToString() == "Problem")
                            {
                                IList<ProblemList> temlProblemList = ilstProblemList.Where(h => h.Human_ID == Convert.ToUInt64(obj[0])).ToList<ProblemList>();


                                if (temlProblemList.Count > 0)
                                {
                                    var temp = temlProblemList.GroupBy(a => a.ICD);

                                    string strTemp = string.Empty;
                                    foreach (var objtemp in temp)
                                    {
                                        foreach (var objProblemList in objtemp)
                                        {

                                            if (strTemp == string.Empty)
                                                strTemp = objProblemList.ICD + "-" + objProblemList.Problem_Description;
                                            else
                                                strTemp += ", " + objProblemList.ICD + "-" + objProblemList.Problem_Description;
                                            break;
                                        }
                                    }
                                    drRule[m] = strTemp;
                                }
                            }
                            else if (obj[m].ToString() == "ProblemDateTime#")
                            {
                                IList<ProblemList> temlProblemList = ilstProblemList.Where(h => h.Human_ID == Convert.ToUInt64(obj[0])).ToList<ProblemList>();

                                if (temlProblemList.Count > 0)
                                {
                                    var temp = temlProblemList.GroupBy(a => a.ICD);

                                    string strTemp = string.Empty;
                                    foreach (var objtemp in temp)
                                    {
                                        foreach (var objProblemList in objtemp)
                                        {
                                            IList<string> lstdat = strTemp.Split(',').Where(a => a == objProblemList.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt")).ToList();
                                            if (lstdat.Count == 0)
                                            {
                                                if (strTemp == string.Empty)
                                                    strTemp = objProblemList.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                                else
                                                    strTemp += ", " + objProblemList.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                                break;
                                            }
                                        }
                                    }
                                    drRule[m] = strTemp;
                                }

                            }
                            else if (obj[m].ToString() == "Medication")
                            {
                                IList<Rcopia_Medication> tempRcopia_Medication = ilstRcopia_Medication.Where(h => h.Human_ID == Convert.ToUInt64(obj[0])).ToList<Rcopia_Medication>();

                                if (tempRcopia_Medication.Count > 0)
                                {
                                    var temp = tempRcopia_Medication.GroupBy(a => a.ICD_Code);

                                    string strTemp = string.Empty;
                                    foreach (var objtemp in temp)
                                    {
                                        foreach (var objRcopia_Medication in objtemp)
                                        {
                                            if (strTemp == string.Empty)
                                                strTemp = objRcopia_Medication.Generic_Name;
                                            else
                                                strTemp += ", " + objRcopia_Medication.Generic_Name;
                                            break;
                                        }
                                    }
                                    obj[m] = strTemp;
                                }
                            }
                            else if (obj[m].ToString() == "MedicationDateTime#")
                            {
                                IList<Rcopia_Medication> tempRcopia_Medication = ilstRcopia_Medication.Where(h => h.Human_ID == Convert.ToUInt64(obj[0])).ToList<Rcopia_Medication>();

                                if (tempRcopia_Medication.Count > 0)
                                {
                                    var temp = tempRcopia_Medication.GroupBy(a => a.ICD_Code);

                                    string strTemp = string.Empty;
                                    foreach (var objtemp in temp)
                                    {
                                        foreach (var objRcopia_Medication in objtemp)
                                        {
                                            if (strTemp == string.Empty)
                                                strTemp = objRcopia_Medication.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                            else
                                                strTemp += ", " + objRcopia_Medication.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                            break;
                                        }
                                    }
                                    obj[m] = strTemp;
                                }

                            }


                            else if (obj[m].ToString() == "MedAlergy")
                            {
                                IList<Rcopia_Allergy> tempRcopia_Medication = ilstRcopia_Allergy.Where(h => h.Human_ID == Convert.ToUInt64(obj[0])).ToList<Rcopia_Allergy>();

                                if (tempRcopia_Medication.Count > 0)
                                {
                                    var temp = tempRcopia_Medication.GroupBy(a => a.Allergy_Name);

                                    string strTemp = string.Empty;
                                    foreach (var objtemp in temp)
                                    {
                                        foreach (var objRcopia_Allergy in objtemp)
                                        {
                                            if (strTemp == string.Empty)
                                                strTemp = objRcopia_Allergy.Allergy_Name;
                                            else
                                                strTemp += ", " + objRcopia_Allergy.Allergy_Name;
                                            break;
                                        }
                                        obj[m] = strTemp;
                                    }
                                }
                            }
                            else if (obj[m].ToString() == "MedAlergyDateTime#")
                            {
                                IList<Rcopia_Allergy> tempRcopia_Medication = ilstRcopia_Allergy.Where(h => h.Human_ID == Convert.ToUInt64(obj[0])).ToList<Rcopia_Allergy>();

                                if (tempRcopia_Medication.Count > 0)
                                {
                                    var temp = tempRcopia_Medication.GroupBy(a => a.Allergy_Name);

                                    string strTemp = string.Empty;
                                    foreach (var objtemp in temp)
                                    {
                                        foreach (var objRcopia_Allergy in objtemp)
                                        {
                                            if (strTemp == string.Empty)
                                                strTemp = objRcopia_Allergy.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                            else
                                                strTemp += ", " + objRcopia_Allergy.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                            break;
                                        }
                                    }
                                    obj[m] = strTemp;

                                }

                            }

                            else if (obj[m].ToString() == "LabResult")
                            {

                                IList<ResultMaster> tempResultMas = ilstResultMaster.Where(a => a.Matching_Patient_Id == Convert.ToUInt64(obj[0])).ToList<ResultMaster>();

                                if (tempResultMas.Count > 0)
                                {
                                    IList<ResultOBX> tempResultOBX = ilstResultOBX.Where(a => a.Result_Master_ID == tempResultMas[0].Id).ToList<ResultOBX>();

                                    if (tempResultOBX.Count > 0)
                                    {
                                        var temp = tempResultOBX.GroupBy(a => a.OBX_Observation_Value);

                                        string strTemp = string.Empty;
                                        foreach (var objtemp in temp)
                                        {
                                            foreach (var objResultOBX in objtemp)
                                            {
                                                if (strTemp == string.Empty)
                                                    strTemp = objResultOBX.OBX_Observation_Value + " " + objResultOBX.OBX_Units;
                                                else
                                                    strTemp += ", " + objResultOBX.OBX_Observation_Value + " " + objResultOBX.OBX_Units;
                                                break;
                                            }
                                        }
                                        obj[m] = strTemp;
                                    }
                                }

                            }
                            else if (obj[m].ToString() == "LabResultDateTime#")
                            {

                                IList<ResultMaster> tempResultMas = ilstResultMaster.Where(a => a.Matching_Patient_Id == Convert.ToUInt64(obj[0])).ToList<ResultMaster>();

                                if (tempResultMas.Count > 0)
                                {
                                    IList<ResultOBX> tempResultOBX = ilstResultOBX.Where(a => a.Result_Master_ID == tempResultMas[0].Id).ToList<ResultOBX>();

                                    if (tempResultOBX.Count > 0)
                                    {
                                        var temp = tempResultOBX.GroupBy(a => a.OBX_Observation_Value);

                                        string strTemp = string.Empty;
                                        foreach (var objtemp in temp)
                                        {
                                            foreach (var objResultOBX in objtemp)
                                            {
                                                if (strTemp == string.Empty)
                                                    strTemp = objResultOBX.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                                else
                                                    strTemp += ", " + objResultOBX.Created_Date_And_Time.ToString("dd-MMM-yyyy hh:mm tt");
                                                break;


                                            }
                                        }
                                        obj[m] = strTemp;
                                    }
                                }

                            }
                            else
                            {
                                if (m == 2 || m == 8)
                                {
                                    try
                                    {
                                        if (m == 2)
                                            drRule[m] = Convert.ToDateTime(obj[m]).ToString("dd-MMM-yyyy");
                                        else
                                            drRule[m] = Convert.ToDateTime(obj[m]).ToString("dd-MMM-yyyy hh:mm tt");

                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                    drRule[m] = Convert.ToString(obj[m]);
                            }
                        }
                        dtRule.Rows.Add(drRule);
                    }
                    //BUGID:44718 --As instructed--
                    //Humlst = iMySession.CreateCriteria(typeof(Human)).Add(Expression.In("Id", HumanList.ToArray<ulong>())).List<Human>();
                    //if (Humlst != null && Humlst.Count > 0)
                    //{
                    //    for (int g = 0; g < Humlst.Count; g++)
                    //    {

                    //        Humlst[g].Reminder_Date = dtLocalTime;
                    //    }
                    //}
                    dsRule.Tables.Add(dtRule);
                    ilstRuleMaster[0].Last_Run_Date = dtLocalTime;

                }
                iMySession.Close();
            }

            #region Save

        //    iTryCount = 0;

        //TryAgain:
        //    int iResult = 0;
        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    try
        //    {
        //        trans = MySession.BeginTransaction();
        //        if (Humlst != null && Humlst.Count > 0)
        //        {
        //            IList<Human> SaveList = null;
        //            HumanManager humanmgr = new HumanManager();
        //            iResult = humanmgr.BatchOperationsToHuman(SaveList, Humlst, null, MySession, "");
        //            //if bResult = false then, the deadlock is occured 
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock occurred. Transaction failed.");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //  MySession.Close();
        //                throw new Exception("Exception occurred. Transaction failed.");
        //            }
        //        }
        //        if (ilstRuleMaster != null && ilstRuleMaster.Count > 0)
        //        {
        //            IList<RuleMaster> saveListRuleMster = null;
        //            iResult = SaveUpdateDeleteWithoutTransaction(ref saveListRuleMster, ilstRuleMaster, null, MySession, "");
        //            //if bResult = false then, the deadlock is occured 
        //            if (iResult == 2)
        //            {
        //                if (iTryCount < 5)
        //                {
        //                    iTryCount++;
        //                    goto TryAgain;
        //                }
        //                else
        //                {
        //                    trans.Rollback();
        //                    //  MySession.Close();
        //                    throw new Exception("Deadlock occurred. Transaction failed.");
        //                }
        //            }
        //            else if (iResult == 1)
        //            {
        //                trans.Rollback();
        //                //  MySession.Close();
        //                throw new Exception("Exception occurred. Transaction failed.");
        //            }
        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }
        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }

        //    finally
        //    {
        //        MySession.Close();
        //    }

#endregion
            return dsRule;

        }

        public IList<RuleMaster> GetRuleName(string sLegalOrg)
        {
            IList<RuleMaster> hList = new List<RuleMaster>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //Cap - 1352
                //ISQLQuery sql = iMySession.CreateSQLQuery("select * from rule_master r where r.Is_Status='Active' "+ " and r.Legal_Org =' " + sLegalOrg+"'").AddEntity("r", typeof(RuleMaster));
                ISQLQuery sql = iMySession.CreateSQLQuery("select * from rule_master r where r.Is_Status='Active' " + " and r.Legal_Org ='" + sLegalOrg + "'").AddEntity("r", typeof(RuleMaster));
                hList = sql.List<RuleMaster>();
                iMySession.Close();
            }
            return hList;
        }

        public IList<RuleMaster> GetRuleName(int id, string sLegalOrg)
        {
            IList<RuleMaster> hList1 = new List<RuleMaster>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("select * from rule_master r where r.Is_Status='Active' and r.Rule_Master_id='" + id + "' and r.Legal_Org =' " + sLegalOrg + "'").AddEntity("r", typeof(RuleMaster));
                hList1 = sql.List<RuleMaster>();
                iMySession.Close();
            }
           
            return hList1;
        }



       
    }


}





