using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IFlowSheetTemplateManager : IManagerBase<FlowSheetTemplate, ulong>
    {
        IList<FlowSheetTemplate> AppendFlowSheetTemplate(IList<FlowSheetTemplate> flowsheet, string MACAddress);
        IList<FlowSheetTemplate> GetFlowSheetTemplate(ulong ulPhyID);
        IList<FlowSheetTemplate> UpdateFlowSheetTemplate(FlowSheetTemplate flowsheet, string MACAddress);
        IList<FlowSheetTemplate> DeleteFlowSheetTemplate(FlowSheetTemplate flowsheet, string MACAddress);

        IList<PatientResults> GetFlowSheetDetails(ulong ulHumanID, string TemplateName, ulong ulPhyID);
        IList<ResultOBX> GetFlowSheetDetailsForResults(ulong ulHumanID, string TemplateName, ulong ulPhyID);
        IList<PatientResults> GetFlowSheetDetailsByDate(ulong ulHumanID, string TemplateName, string From, string To, ulong ulPhyID);
        IList<ResultOBX> GetFlowSheetDetailsByDateForResults(ulong ulHumanID, string TemplateName, string From, string To, ulong ulPhyID);
        //IList<ResultReferenceInterval> GetResultReferenceInterval();
        IList<PatientResults> GetPatientResultsforFlowSheet(ulong ulHumanID, ulong PhyID);
        IList<FlowSheetTemplate> GetFlowSheetTemplateByTemplateName(string sTemplateName);
    }

    public partial class FlowSheetTemplateManager : ManagerBase<FlowSheetTemplate, ulong>, IFlowSheetTemplateManager
    {
        #region Constructors

        public FlowSheetTemplateManager()
            : base()
        {

        }
        public FlowSheetTemplateManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods
        //AppendFlowSheetTemplate Method Declared But Never Used
        public IList<FlowSheetTemplate> AppendFlowSheetTemplate(IList<FlowSheetTemplate> flowsheet, string MACAddress)
        {
            IList<FlowSheetTemplate> flowList = new List<FlowSheetTemplate>();
            IList<FlowSheetTemplate> UpdateFlowSheet = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref flowsheet, ref UpdateFlowSheet, null, MACAddress,false,false,0,string.Empty);
            flowList = GetFlowSheetTemplate(flowsheet[0].Physician_ID);
            return flowList;
        }

        public IList<FlowSheetTemplate> GetFlowSheetTemplate(ulong physicianId)
        {
            IList<FlowSheetTemplate> flowList = new List<FlowSheetTemplate>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var sqlQuery = @"SELECT V.* 
                                 FROM   FLOW_SHEET_TEMPLATE V 
                                 WHERE  V.PHYSICIAN_ID IN ( :PHYSICIAN_ID ) 
                                         OR V.PHYSICIAN_ID = '0' 
                                 ORDER  BY PHYSICIAN_ID, 
                                           SORT_ORDER ASC";

                ISQLQuery sql = mySession.CreateSQLQuery(sqlQuery).AddEntity("v.*", typeof(FlowSheetTemplate));
                sql.SetParameter("PHYSICIAN_ID", physicianId);
                flowList = sql.List<FlowSheetTemplate>();

                mySession.Close();
            }
            return flowList;
        }
        //UpdateFlowSheetTemplate Method Never Used But Declared.
        public IList<FlowSheetTemplate> UpdateFlowSheetTemplate(FlowSheetTemplate flowsheet, string MACAddress)
        {
            IList<FlowSheetTemplate> flowAddList = new List<FlowSheetTemplate>();

            IList<FlowSheetTemplate> flowList = new List<FlowSheetTemplate>();
            flowList.Add(flowsheet);

            SaveUpdateDelete_DBAndXML_WithTransaction(ref flowAddList,ref flowList, null, MACAddress,false,false,0,string.Empty);

            flowList = GetFlowSheetTemplate(flowList[0].Physician_ID);

            return flowAddList;
        }

        public IList<FlowSheetTemplate> DeleteFlowSheetTemplate(FlowSheetTemplate flowsheet, string MACAddress)
        {
            IList<FlowSheetTemplate> flowAddOrUpdateList = null;
            IList<FlowSheetTemplate> flowList = new List<FlowSheetTemplate>();
            flowList.Add(flowsheet);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref flowAddOrUpdateList, ref flowAddOrUpdateList, flowList, MACAddress, false, false, 0, string.Empty);
            flowList = GetFlowSheetTemplate(flowList[0].Physician_ID);
            return flowList;
        }

        public IList<PatientResults> GetFlowSheetDetails(ulong ulHumanID, string TemplateName, ulong ulPhyID)
        {
            IList<PatientResults> lstPatientResults = new List<PatientResults>();

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit1 = mySession.CreateCriteria(typeof(FlowSheetTemplate))
                                           .Add(Expression.Eq("Template_Name", TemplateName))
                                           .Add(Expression.Eq("Physician_ID", ulPhyID))
                                           .AddOrder(Order.Desc("Sort_Order"));

                var flowsheetTemplateList = crit1.List<FlowSheetTemplate>();

                if (flowsheetTemplateList.Count == 0)
                {
                    return lstPatientResults;
                }

                var lstVitalResults = flowsheetTemplateList.FirstOrDefault().Acurus_Result_Code.Split('|');

                if (lstVitalResults.Length > 0)
                {
                    IList<PatientResults> tempvitalsList = new List<PatientResults>();

                    var sqlQuery = @"SELECT V.* 
                                     FROM   PATIENT_RESULTS V 
                                     WHERE  V.ACURUS_RESULT_CODE IN ( :VITALANDRESULTCRITERIA ) 
                                            AND V.HUMAN_ID = :HUMANID 
                                            AND VALUE <> '' 
                                     ORDER  BY V.CAPTURED_DATE_AND_TIME ASC ";

                    ISQLQuery sql = session.GetISession()
                                           .CreateSQLQuery(sqlQuery)
                                           .AddEntity("v.*", typeof(PatientResults));

                    sql.SetParameterList("VITALANDRESULTCRITERIA", lstVitalResults);
                    sql.SetParameter("HUMANID", ulHumanID);

                    lstPatientResults = sql.List<PatientResults>();
                }
                mySession.Close();
            }
            return lstPatientResults;
        }

        public IList<ResultOBX> GetFlowSheetDetailsForResults(ulong ulHumanID, string TemplateName, ulong ulPhyID)
        {
            IList<ResultOBX> lstPatientResults = new List<ResultOBX>();

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit1 = mySession.CreateCriteria(typeof(FlowSheetTemplate))
                                           .Add(Expression.Eq("Template_Name", TemplateName))
                                           .Add(Expression.Eq("Physician_ID", ulPhyID))
                                           .AddOrder(Order.Desc("Sort_Order"));

                var flowsheetTemplateList = crit1.List<FlowSheetTemplate>();

                if (flowsheetTemplateList.Count == 0)
                {
                    return lstPatientResults;
                }

                var lstVitalResults = flowsheetTemplateList.FirstOrDefault().Acurus_Result_Description.Split('|');

                if (lstVitalResults.Length > 0)
                {
                    IList<ResultOBX> tempvitalsList = new List<ResultOBX>();

                    var sqlQuery = @"SELECT x.*,m.*,r.*
                                     FROM   result_obx x , result_master m, result_obr r
                                     WHERE  x.obx_observation_text IN ( :VITALANDRESULTCRITERIA ) 
                                            and m.matching_patient_id=:HUMANID 
                                            AND m.result_master_id = x.result_master_id
                                            AND m.result_master_id = r.result_master_id
                                            AND x.obx_observation_value <> ''
                                     ORDER  BY x.obx_date_and_time_of_observation ASC";

                    ISQLQuery sql = session.GetISession()
                                           .CreateSQLQuery(sqlQuery)
                                           .AddEntity("x", typeof(ResultOBX))
                                           .AddEntity("m",typeof(ResultMaster))
                                           .AddEntity("r", typeof(ResultOBR));

                    sql.SetParameterList("VITALANDRESULTCRITERIA", lstVitalResults);
                    sql.SetParameter("HUMANID", ulHumanID);

                    if (sql.List().Count > 0)
                    {
                        foreach (IList<Object> l in sql.List())
                        {
                            ResultOBX resultOBXRecord = (ResultOBX)l[0];
                            ResultOBR resultOBRRecord = (ResultOBR)l[2];
                            resultOBXRecord.OBX_Date_And_Time_Of_Observation = resultOBRRecord.OBR_Specimen_Collection_Date_And_Time;
                            lstPatientResults.Add(resultOBXRecord);
                        }
                    }
                }
                mySession.Close();
            }
            return lstPatientResults;
        }

        public IList<PatientResults> GetFlowSheetDetailsByDate(ulong ulHumanID, string TemplateName, string From, string To, ulong ulPhyID)
        {

            IList<PatientResults> lstPatientResults = new List<PatientResults>();

            string VitalAndResultCriteria = string.Empty;

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit1 = mySession.CreateCriteria(typeof(FlowSheetTemplate))
                                 .Add(Expression.Eq("Template_Name", TemplateName))
                                 .Add(Expression.Eq("Physician_ID", ulPhyID))
                                 .AddOrder(Order.Desc("Sort_Order"));

                var flowsheetTemplateList = crit1.List<FlowSheetTemplate>();

                if (flowsheetTemplateList.Count == 0)
                {
                    return lstPatientResults;
                }

                var lstVitalResults = flowsheetTemplateList[0].Acurus_Result_Code.Split('|');

                if (lstVitalResults.Length > 0)
                {
                    IList<PatientResults> tempvitalsList = new List<PatientResults>();

                    var sqlQuery = @"SELECT V.* 
                                     FROM   PATIENT_RESULTS V 
                                     WHERE  V.ACURUS_RESULT_CODE IN ( :VITALANDRESULTCRITERIA ) 
                                            AND V.HUMAN_ID = ( :HUMANID )
                                            AND VALUE <> '' 
                                            AND V.CAPTURED_DATE_AND_TIME BETWEEN :FROM AND :TO  
                                     ORDER  BY V.CAPTURED_DATE_AND_TIME ASC";

                    ISQLQuery sql = mySession.CreateSQLQuery(sqlQuery).AddEntity("v.*", typeof(PatientResults));

                    sql.SetParameterList("VITALANDRESULTCRITERIA", lstVitalResults);
                    sql.SetParameter("HUMANID", ulHumanID);
                    sql.SetParameter("FROM", From);
                    sql.SetParameter("TO", To);

                    tempvitalsList = sql.List<PatientResults>();

                    if (tempvitalsList.Count > 0)
                    {
                        lstPatientResults = tempvitalsList;
                    }
                }
                mySession.Close();
            }

            return lstPatientResults;
        }

        public IList<ResultOBX> GetFlowSheetDetailsByDateForResults(ulong ulHumanID, string TemplateName, string From, string To, ulong ulPhyID)
        {

            IList<ResultOBX> lstPatientResults = new List<ResultOBX>();

            string VitalAndResultCriteria = string.Empty;

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit1 = mySession.CreateCriteria(typeof(FlowSheetTemplate))
                                 .Add(Expression.Eq("Template_Name", TemplateName))
                                 .Add(Expression.Eq("Physician_ID", ulPhyID))
                                 .AddOrder(Order.Desc("Sort_Order"));

                var flowsheetTemplateList = crit1.List<FlowSheetTemplate>();

                if (flowsheetTemplateList.Count == 0)
                {
                    return lstPatientResults;
                }

                var lstVitalResults = flowsheetTemplateList[0].Acurus_Result_Description.Split('|');

                if (lstVitalResults.Length > 0)
                {
                    IList<ResultOBX> tempvitalsList = new List<ResultOBX>();

                     var sqlQuery = @"SELECT x.*,m.*,r.*
                                     FROM   result_obx x , result_master m, result_obr r
                                     WHERE  x.obx_observation_text IN ( :VITALANDRESULTCRITERIA ) 
                                            and m.matching_patient_id=:HUMANID 
                                            AND m.result_master_id = x.result_master_id
                                            AND m.result_master_id = r.result_master_id
                                            AND x.obx_observation_value <> ''
                                            AND r.OBR_Specimen_Collection_Date_And_Time BETWEEN :FROM AND :TO  
                                     ORDER  BY x.obx_date_and_time_of_observation ASC";

                     ISQLQuery sql = session.GetISession()
                                           .CreateSQLQuery(sqlQuery)
                                           .AddEntity("x", typeof(ResultOBX))
                                           .AddEntity("m", typeof(ResultMaster))
                                           .AddEntity("r", typeof(ResultOBR));

                    sql.SetParameterList("VITALANDRESULTCRITERIA", lstVitalResults);
                    sql.SetParameter("HUMANID", ulHumanID);
                    sql.SetParameter("FROM", From);
                    sql.SetParameter("TO", To);

                     if (sql.List().Count > 0)
                    {
                        foreach (IList<Object> l in sql.List())
                        {
                            ResultOBX resultOBXRecord = (ResultOBX)l[0];
                            ResultOBR resultOBRRecord = (ResultOBR)l[2];
                            resultOBXRecord.OBX_Date_And_Time_Of_Observation = resultOBRRecord.OBR_Specimen_Collection_Date_And_Time;
                            lstPatientResults.Add(resultOBXRecord);
                        }
                    }

                }
                mySession.Close();
            }

            return lstPatientResults;
        }

        //public IList<ResultReferenceInterval> GetResultReferenceInterval()
        //{
        //    IList<ResultReferenceInterval> list = new List<ResultReferenceInterval>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit1 = iMySession.CreateCriteria(typeof(ResultReferenceInterval));
        //        list = crit1.List<ResultReferenceInterval>();
        //        iMySession.Close();
        //    }
        //    return list;
        //}

        public IList<PatientResults> GetPatientResultsforFlowSheet(ulong ulHumanID, ulong PhyID)
        {
            IList<PatientResults> vitalHistory = new List<PatientResults>();
            IList<PatientResults> OrderedvitalHistory = new List<PatientResults>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var sqlQuery = @"SELECT V.* 
                                 FROM   PATIENT_RESULTS V 
                                        INNER JOIN DYNAMIC_SCREEN S 
                                                ON ( V.LOINC_OBSERVATION = S.CONTROL_NAME_THIN_CLIENT ) 
                                        INNER JOIN MAP_VITALS_PHYSICIAN M 
                                                ON ( S.MASTER_VITALS_ID = M.MASTER_VITALS_ID ) 
                                 WHERE  V.HUMAN_ID = :HUMANID 
                                        AND V.RESULTS_TYPE = 'VITALS' 
                                        AND M.PHYSICIAN_ID = :PHYID 
                                 GROUP  BY V.PATIENT_RESULTS_ID 
                                 ORDER  BY M.SORT_ORDER, 
                                           V.ENCOUNTER_ID, 
                                           V.CAPTURED_DATE_AND_TIME ";

                ISQLQuery sql = mySession.CreateSQLQuery(sqlQuery).AddEntity("v.*", typeof(PatientResults));
                sql.SetParameter("HUMANID", ulHumanID);
                sql.SetParameter("PHYID", PhyID);

                vitalHistory = sql.List<PatientResults>();

                if (vitalHistory != null && vitalHistory.Count > 0)
                {
                    IList<PatientResults> tempList = vitalHistory.Select(a =>
                    {
                        a.Loinc_Observation = a.Loinc_Observation.Contains("$")
                            ? a.Loinc_Observation.Replace("$", "Second") : a.Loinc_Observation;
                        return a;
                    }).ToList<PatientResults>();

                    vitalHistory = tempList;
                }

                mySession.Close();
            }
            return vitalHistory;

        }

        public IList<FlowSheetTemplate> GetFlowSheetTemplateByTemplateName(string sTemplateName)
        {
            IList<FlowSheetTemplate> flowList = new List<FlowSheetTemplate>();

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var sqlQuery = @"SELECT V.* 
                                 FROM   FLOW_SHEET_TEMPLATE V 
                                 WHERE  V.TEMPLATE_NAME = :TEMPLATE_NAME
                                 ORDER  BY PHYSICIAN_ID, 
                                           SORT_ORDER ASC ";

                ISQLQuery sql = mySession.CreateSQLQuery(sqlQuery).AddEntity("v.*", typeof(FlowSheetTemplate));

                sql.SetParameter("TEMPLATE_NAME", sTemplateName);

                flowList = sql.List<FlowSheetTemplate>();

                mySession.Close();
            }
            return flowList;
        }
        #endregion


    }
}
