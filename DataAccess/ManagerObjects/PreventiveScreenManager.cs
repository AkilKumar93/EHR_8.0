using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPreventiveScreenManager : IManagerBase<PreventiveScreen, ulong>
    {
        //IList<PreventiveScreenDTO> GetPreventiveScreenFromServer(ulong ulEncounterID, ulong ulHumanID);
        //IList<PreventiveScreenDTO> SavePreventiveScreen(IList<PreventiveScreen> PreLst, string MacAddress);
        //IList<PreventiveScreenDTO> UpdatePreventiveScreen(IList<PreventiveScreen> PreLst, string MacAddress);
        IList<PreventiveScreenDTO> GetPreventivePlanForPastEncounter(ulong encounter_ID, ulong human_ID, ulong Physician_ID);
        IList<PreventiveScreenDTO> GetPreventiveScreenForThin(ulong ulEncounterID, ulong ulHumanID);
        //IList<PreventiveScreenDTO> UpdatePreventiveScreenForCopyPrevious(IList<PreventiveScreen> PreLst, string MacAddress, ulong encounter_ID, ulong human_ID, ulong Physician_ID);
        IList<PreventiveScreen> GetPreventiveScreenPlanDetails(ulong Encounter_id, ulong HumanId);
        IList<PreventiveScreen> SavePreventiveList(IList<PreventiveScreen> PreLst, string MacAddress);
        IList<PreventiveScreen> UpdatePreventiveList(IList<PreventiveScreen> PreLst, string MacAddress);
        IList<PreventiveScreen> SaveDeletePreventiveList(IList<PreventiveScreen> PreLst, IList<PreventiveScreen> DelProLst,string MacAddress);
    }
    public partial class PreventiveScreenManager : ManagerBase<PreventiveScreen, ulong>, IPreventiveScreenManager
    {
        #region Constructors

        public PreventiveScreenManager()
            : base()
        {

        }
        public PreventiveScreenManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region IPreventiveScreenManager Members

        //public IList<PreventiveScreenDTO> GetPreventiveScreenFromServer(ulong ulEncounterID, ulong ulHumanID)
        //{
        //    ArrayList ary = null;
        //    IList<PreventiveScreenDTO> PreventiveLst = new List<PreventiveScreenDTO>();
        //    PreventiveScreenDTO PreDto = null;
        //    IList<PatientResults> vitalsHBA1CList = new List<PatientResults>();
        //    IList<PatientResults> vitalsList = new List<PatientResults>();
        //    IList<ImmunizationHistory> immunList = new List<ImmunizationHistory>();
        //    IList<Assessment> assesmentList = new List<Assessment>();
        //    IList<Human> HumanList = new List<Human>();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        if (ulHumanID != 0)
        //        {
        //            ISQLQuery humanqry = iMySession.CreateSQLQuery("Select a.* from human a where (a.human_id=" + ulHumanID + ")").AddEntity("a", typeof(Human));
        //            HumanList = humanqry.List<Human>();
        //            PreventiveLst.Add(new PreventiveScreenDTO());
        //            PreventiveLst[0].Patient_Sex = HumanList[0].Sex;
        //        }
        //        IQuery query = iMySession.GetNamedQuery("Fill.PreventiveScreen.Server").SetParameter("ENCOUNTER_ID", Convert.ToString(ulEncounterID));
        //        ary = new ArrayList(query.List());
        //            for (int i = 0; i < ary.Count; i++)
        //            {
        //                object[] ob = (object[])ary[i];
        //                PreDto = new PreventiveScreenDTO();
        //                if(ob[0] != null)
        //                PreDto.Preventive_Screen_ID = Convert.ToUInt64(ob[0]);
        //                if (ob[1] != null)
        //                PreDto.Preventive_Service = Convert.ToString(ob[1]);
        //                if (ob[2] != null)
        //                PreDto.Preventive_Service_Value = Convert.ToString(ob[2]);
        //                if (ob[3] != null)
        //                PreDto.Options = Convert.ToString(ob[3]);
        //                if (ob[4] != null)
        //                PreDto.Status = Convert.ToString(ob[4]);
        //                if (ob[5] != null)
        //                PreDto.Preventive_Screening_Notes = Convert.ToString(ob[5]);
        //                if (ob[6] != null)
        //                PreDto.Created_By = Convert.ToString(ob[6]);
        //                if (ob[7] != null)
        //                PreDto.Created_Date_And_Time = Convert.ToDateTime(ob[7]);
        //                if (ob[8] != null)
        //                PreDto.Preventive_Screen_Lookup_ID = Convert.ToUInt64(ob[8]);
        //                if (ob[9] != null)
        //                PreDto.Version = Convert.ToInt32(ob[9]);
        //                if (ob[10] != null)
        //                PreDto.Depending_Value = Convert.ToString(ob[10]);
        //                if (ob[11] != null)
        //                PreDto.Description = Convert.ToString(ob[11]);
        //                PreventiveLst.Add(PreDto);
        //            }

        //        //Comment by bala for performance tuning

        //        //VitalsManager objVitals = new VitalsManager();
        //        //IList<Vitals> vitalsList = objVitals.GetPastVitalDetailsByEncounterID(ulEncounterID);
        //        //if (PreventiveLst.Count == 0)
        //        //{
        //        //    PreDto = new PreventiveScreenDTO();
        //        //    PreDto.Vitalslst = vitalsList;
        //        //    PreventiveLst.Add(PreDto);
        //        //}
        //        //else
        //        //{
        //        //    PreventiveLst[0].Vitalslst = vitalsList;
        //        //}

        //        //add by bala for performance tuning
        //        //ISQLQuery sql1 = session.GetISession().CreateSQLQuery("Select a.* from patient_results a where a.Loinc_Observation ='HBA1C' and a.Captured_date_and_time=(Select Max(s.Captured_date_and_time) from patient_results s where s.Encounter_ID = '" + ulEncounterID.ToString() + "' and Loinc_Observation ='HBA1C' and Results_Type='Vitals')").AddEntity("a", typeof(PatientResults));
        //        //vitalsHBA1CList = sql1.List<PatientResults>();

        //        IList<DynamicScreen> DynamicscreenList = new List<DynamicScreen>();
        //        ICriteria crt1 = iMySession.CreateCriteria(typeof(DynamicScreen));
        //        DynamicscreenList = crt1.List<DynamicScreen>();

        //        var loinc = from l in DynamicscreenList where l.Control_Name == "HbA1C" select l.Loinc_Identifier;
        //        var loincbp = from l in DynamicscreenList where (l.Control_Name == "BP-Sitting Sys/Dia" || l.Control_Name == "BP-Standing Sys/Dia" || l.Control_Name == "BP-Lying Sys/Dia" || l.Control_Name == "BP-Sitting$ Sys/Dia" || l.Control_Name == "BP-Standing$ Sys/Dia" || l.Control_Name == "BP-Lying$ Sys/Dia") select l.Loinc_Identifier;


        //        IList<PatientResults> FinalVitalshba1cList = new List<PatientResults>();
        //        ISQLQuery sql1 = iMySession.CreateSQLQuery("Select a.* from patient_results a where a.Encounter_ID = '" + ulEncounterID.ToString() + "' and a.human_ID = '" + ulHumanID.ToString() + "'  and a.Loinc_Identifier='" + loinc.First() + "'").AddEntity("a", typeof(PatientResults));
        //        vitalsHBA1CList = sql1.List<PatientResults>();

        //        if (vitalsHBA1CList.Any(v => v.Results_Type == "Vitals") && vitalsHBA1CList.Any(v => v.Results_Type == "Results"))
        //        {
        //            IList<PatientResults> finalVital = (from Hab in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status") && Hab.Captured_date_and_time == ((from Hab1 in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab1.Loinc_Observation.ToLower() == "hba1c status") select Hab1.Captured_date_and_time).Max()) select Hab).ToList<PatientResults>();
        //            IList<PatientResults> finalLabResult = (from Hab in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status") && Hab.Created_Date_And_Time == ((from Hab1 in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab1.Loinc_Observation.ToLower() == "hba1c status") select Hab1.Created_Date_And_Time).Max()) select Hab).ToList<PatientResults>();
        //            if (finalVital[0].Captured_date_and_time > finalLabResult[0].Created_Date_And_Time)
        //            {
        //                if (PreventiveLst.Count == 0)
        //                {
        //                    PreDto = new PreventiveScreenDTO();
        //                    if (vitalsHBA1CList.Count > 0)
        //                    {
        //                        if (vitalsHBA1CList.Count == 1)
        //                        {
        //                            PreDto.VitalValue = finalVital[0].Value;
        //                            PreDto.Hba1c_Date_And_Time = finalVital[0].Captured_date_and_time;
        //                        }
        //                        if (vitalsHBA1CList.Count > 1)
        //                        {
        //                            finalVital = (from Hab in vitalsHBA1CList where Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status" orderby Hab.Captured_date_and_time descending, Hab.Vitals_Group_ID descending select Hab).ToList<PatientResults>();
        //                            PreDto.VitalValue = finalVital[0].Value;
        //                            PreDto.Hba1c_Date_And_Time = finalVital[0].Captured_date_and_time;
        //                        }

        //                    }
        //                    PreventiveLst.Add(PreDto);
        //                }
        //                else
        //                {
        //                    if (vitalsHBA1CList.Count > 0)
        //                    {
        //                        if (vitalsHBA1CList.Count == 1)
        //                        {
        //                            PreventiveLst[0].VitalValue = finalVital[0].Value;
        //                            PreventiveLst[0].Hba1c_Date_And_Time = finalVital[0].Captured_date_and_time;
        //                        }
        //                        if (vitalsHBA1CList.Count > 1)
        //                        {
        //                            finalVital = (from Hab in vitalsHBA1CList where Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status" orderby Hab.Captured_date_and_time descending, Hab.Vitals_Group_ID descending select Hab).ToList<PatientResults>();
        //                            PreventiveLst[0].VitalValue = finalVital[0].Value;
        //                            PreventiveLst[0].Hba1c_Date_And_Time = finalVital[0].Captured_date_and_time;

        //                        }

        //                    }
        //                }
        //            }

        //            if (finalVital[0].Captured_date_and_time < finalLabResult[0].Created_Date_And_Time)
        //            {
        //                if (PreventiveLst.Count == 0)
        //                {
        //                    PreDto = new PreventiveScreenDTO();
        //                    if (vitalsHBA1CList.Count > 0)
        //                    {
        //                        PreDto.VitalValue = finalLabResult[0].Value;
        //                        PreDto.Hba1c_Date_And_Time = finalLabResult[0].Created_Date_And_Time;

        //                    }
        //                    PreventiveLst.Add(PreDto);
        //                }
        //                else
        //                {
        //                    if (vitalsHBA1CList.Count > 0)
        //                    {
        //                        PreventiveLst[0].VitalValue = finalLabResult[0].Value;
        //                        PreventiveLst[0].Hba1c_Date_And_Time = finalLabResult[0].Created_Date_And_Time;

        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (vitalsHBA1CList.Count > 0)
        //            {
        //                if (vitalsHBA1CList[0].Results_Type.ToUpper() == "VITALS")
        //                {
        //                    FinalVitalshba1cList = (from Hab in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status") && Hab.Captured_date_and_time == ((from Hab1 in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab1.Loinc_Observation.ToLower() == "hba1c status") select Hab1.Captured_date_and_time).Max()) select Hab).ToList<PatientResults>();

        //                    if (PreventiveLst.Count == 0)
        //                    {
        //                        PreDto = new PreventiveScreenDTO();
        //                            if (FinalVitalshba1cList.Count == 1)
        //                            {
        //                                PreDto.VitalValue = FinalVitalshba1cList[0].Value;
        //                                PreDto.Hba1c_Date_And_Time = FinalVitalshba1cList[0].Captured_date_and_time;
        //                            }
        //                            if (FinalVitalshba1cList.Count > 1)
        //                            {
        //                                FinalVitalshba1cList = (from Hab in vitalsHBA1CList where Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status" orderby Hab.Captured_date_and_time descending, Hab.Vitals_Group_ID descending select Hab).ToList<PatientResults>();
        //                                PreDto.VitalValue = FinalVitalshba1cList[0].Value;
        //                                PreDto.Hba1c_Date_And_Time = FinalVitalshba1cList[0].Captured_date_and_time;

        //                            }
        //                        PreventiveLst.Add(PreDto);
        //                    }
        //                    else
        //                    {
        //                            if (FinalVitalshba1cList.Count == 1)
        //                            {
        //                                PreventiveLst[0].VitalValue = FinalVitalshba1cList[0].Value;
        //                                PreventiveLst[0].Hba1c_Date_And_Time = FinalVitalshba1cList[0].Captured_date_and_time;
        //                            }
        //                            if (FinalVitalshba1cList.Count > 1)
        //                            {
        //                                FinalVitalshba1cList = (from Hab in vitalsHBA1CList where Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status" orderby Hab.Captured_date_and_time descending, Hab.Vitals_Group_ID descending select Hab).ToList<PatientResults>();
        //                                PreventiveLst[0].VitalValue = FinalVitalshba1cList[0].Value;
        //                                PreventiveLst[0].Hba1c_Date_And_Time = FinalVitalshba1cList[0].Captured_date_and_time;
        //                            }
        //                    }
        //                }
        //                if (vitalsHBA1CList[0].Results_Type.ToUpper() == "RESULTS")
        //                {
        //                    FinalVitalshba1cList = (from Hab in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab.Loinc_Observation.ToLower() == "hba1c status") && Hab.Created_Date_And_Time == ((from Hab1 in vitalsHBA1CList where (Hab.Loinc_Observation.ToUpper() == "HBA1C" || Hab1.Loinc_Observation.ToLower() == "hba1c status") select Hab1.Created_Date_And_Time).Max()) select Hab).ToList<PatientResults>();

        //                    if (PreventiveLst.Count == 0)
        //                    {
        //                        PreDto = new PreventiveScreenDTO();
        //                        if (vitalsHBA1CList.Count > 0)
        //                        {
        //                            PreDto.VitalValue = FinalVitalshba1cList[0].Value;
        //                            PreDto.Hba1c_Date_And_Time = FinalVitalshba1cList[0].Created_Date_And_Time;
        //                        }
        //                        PreventiveLst.Add(PreDto);
        //                    }
        //                    else
        //                    {
        //                            PreventiveLst[0].VitalValue = FinalVitalshba1cList[0].Value;
        //                            PreventiveLst[0].Hba1c_Date_And_Time = FinalVitalshba1cList[0].Created_Date_And_Time;
        //                    }
        //                }
        //            }
        //        }




        //        //ISQLQuery sql2 = session.GetISession().CreateSQLQuery("Select a.* from patient_results a where (a.Loinc_Observation ='bp-sitting sys/dia' or a.Loinc_Observation ='bp-lying sys/dia' or a.Loinc_Observation ='bp-standing sys/dia')  and a.Captured_date_and_time=(Select Max(s.Captured_date_and_time) from patient_results s where s.Encounter_ID = '" + ulEncounterID.ToString() + "' and (Loinc_Observation ='bp-sitting sys/dia' or Loinc_Observation ='bp-lying sys/dia' or Loinc_Observation ='bp-standing sys/dia')) and Results_Type='Vitals'").AddEntity("a", typeof(PatientResults));
        //        //vitalsList = sql2.List<PatientResults>();

        //        IList<PatientResults> FinalVitalsList = new List<PatientResults>();
        //        ISQLQuery sql2 = iMySession.CreateSQLQuery("Select a.* from patient_results a where a.Encounter_ID = '" + ulEncounterID.ToString() + "' and a.human_ID='" + ulHumanID.ToString() + "'  and a.Loinc_Identifier='" + loincbp.First() + "'").AddEntity("a", typeof(PatientResults));
        //        vitalsList = sql2.List<PatientResults>();

        //        if (vitalsList.Any(v => v.Results_Type == "Vitals") && vitalsList.Any(v => v.Results_Type == "Results"))
        //        {
        //            IList<PatientResults> finalBPVital = (from bp in vitalsList
        //                                                  where (bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                      || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                      || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                      || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                      || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                      || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia") &&
        //                                                      bp.Captured_date_and_time == ((from bp1 in vitalsList
        //                                                                                     where bp1.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                                                         || bp1.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                                                         || bp1.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                                                         || bp1.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                                                         || bp1.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                                                         || bp1.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                                                     select bp1.Captured_date_and_time).Max())
        //                                                  select bp).ToList<PatientResults>();
        //            IList<PatientResults> finalBPLabResult = (from bp in vitalsList
        //                                                      where (bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                          || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                          || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                          || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                          || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                          || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia") &&
        //                                                          bp.Created_Date_And_Time == ((from bp1 in vitalsList
        //                                                                                        where bp1.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                                                                                                    || bp1.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                                                                                                    || bp1.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                                                                                                    || bp1.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                                                                                                    || bp1.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                                                                                                    || bp1.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                                                        select bp1.Created_Date_And_Time).Max())
        //                                                      select bp).ToList<PatientResults>();

        //            if (finalBPVital[0].Captured_date_and_time > finalBPLabResult[0].Created_Date_And_Time)
        //            {
        //                if (PreventiveLst.Count == 0)
        //                {
        //                    PreDto = new PreventiveScreenDTO();
        //                    if (vitalsList.Count == 1)
        //                    {
        //                        PreDto.BpVitalValue = finalBPVital[0].Value;
        //                        PreDto.BpVitalName = finalBPVital[0].Loinc_Observation.Replace("$", "");
        //                        PreDto.BP_Date_And_Time = finalBPVital[0].Captured_date_and_time;
        //                    }
        //                    if (vitalsList.Count > 1)
        //                    {
        //                        finalBPVital = (from bp in vitalsList
        //                                        where bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                        orderby bp.Captured_date_and_time descending, bp.Vitals_Group_ID descending
        //                                        select bp).ToList<PatientResults>();
        //                        PreDto.BpVitalValue = finalBPVital[0].Value;
        //                        PreDto.BpVitalName = finalBPVital[0].Loinc_Observation.Replace("$", "");
        //                        PreDto.BP_Date_And_Time = finalBPVital[0].Captured_date_and_time;
        //                    }
        //                    PreventiveLst.Add(PreDto);
        //                }
        //                else
        //                {
        //                    if (vitalsList.Count == 1)
        //                    {
        //                        PreventiveLst[0].BpVitalName = finalBPVital[0].Loinc_Observation.Replace("$", "");
        //                        PreventiveLst[0].BpVitalValue = finalBPVital[0].Value;
        //                        PreventiveLst[0].BP_Date_And_Time = finalBPVital[0].Captured_date_and_time;
        //                    }
        //                    if (vitalsList.Count > 1)
        //                    {
        //                        finalBPVital = (from bp in vitalsList
        //                                        where bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                            || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                        orderby bp.Captured_date_and_time descending, bp.Vitals_Group_ID descending
        //                                        select bp).ToList<PatientResults>();
        //                        PreventiveLst[0].BpVitalName = finalBPVital[0].Loinc_Observation.Replace("$", "");
        //                        PreventiveLst[0].BpVitalValue = finalBPVital[0].Value;
        //                        PreventiveLst[0].BP_Date_And_Time = finalBPVital[0].Captured_date_and_time;
        //                    }
        //                }
        //            }
        //            if (finalBPVital[0].Captured_date_and_time < finalBPLabResult[0].Created_Date_And_Time)
        //            {
        //                if (vitalsList.Count > 0)
        //                {
        //                if (PreventiveLst.Count == 0)
        //                {
        //                        PreDto = new PreventiveScreenDTO();
        //                        PreDto.BpVitalValue = finalBPLabResult[0].Value;
        //                        PreDto.BpVitalName = finalBPLabResult[0].Loinc_Observation.Replace("$", "");
        //                        PreDto.BP_Date_And_Time = finalBPLabResult[0].Created_Date_And_Time;
        //                        PreventiveLst.Add(PreDto);
        //                }
        //                else
        //                {
        //                        PreventiveLst[0].BpVitalName = finalBPLabResult[0].Loinc_Observation.Replace("$", "");
        //                        PreventiveLst[0].BpVitalValue = finalBPLabResult[0].Value;
        //                        PreventiveLst[0].BP_Date_And_Time = finalBPLabResult[0].Created_Date_And_Time;
        //                }
        //                }
        //            }

        //        }
        //        else
        //        {
        //            if (vitalsList.Count > 0)
        //            {
        //                if (vitalsList[0].Results_Type.ToUpper() == "VITALS")
        //                {
        //                    FinalVitalsList = (from bp in vitalsList
        //                                       where (bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia") && bp.Captured_date_and_time == ((from bp1 in vitalsList
        //                                                                                                                                          where bp1.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                                                                                                          select bp1.Captured_date_and_time).Max())
        //                                       select bp).ToList<PatientResults>();
        //                    if (PreventiveLst.Count == 0)
        //                    {
        //                        PreDto = new PreventiveScreenDTO();
        //                        if (FinalVitalsList.Count > 0)
        //                        {
        //                            if (FinalVitalsList.Count == 1)
        //                            {
        //                                PreDto.BpVitalValue = FinalVitalsList[0].Value;
        //                                PreDto.BpVitalName = FinalVitalsList[0].Loinc_Observation.Replace("$", "");
        //                                PreDto.BP_Date_And_Time = FinalVitalsList[0].Captured_date_and_time;
        //                            }
        //                            if (FinalVitalsList.Count > 1)
        //                            {
        //                                FinalVitalsList = (from bp in vitalsList
        //                                                   where (bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia") && bp.Captured_date_and_time == ((from bp1 in vitalsList
        //                                                                                                                                                      where bp1.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                                                                                                                      select bp1.Captured_date_and_time).Max())
        //                                                   select bp).ToList<PatientResults>();
        //                                PreDto.BpVitalValue = FinalVitalsList[0].Value;
        //                                PreDto.BpVitalName = FinalVitalsList[0].Loinc_Observation.Replace("$", "");
        //                                PreDto.BP_Date_And_Time = FinalVitalsList[0].Captured_date_and_time;
        //                            }
        //                        }
        //                        PreventiveLst.Add(PreDto);
        //                    }
        //                    else
        //                    {
        //                        if (FinalVitalsList.Count > 0)
        //                        {
        //                            if (FinalVitalsList.Count == 1)
        //                            {
        //                                PreventiveLst[0].BpVitalName = FinalVitalsList[0].Loinc_Observation.Replace("$", "");
        //                                PreventiveLst[0].BpVitalValue = FinalVitalsList[0].Value;
        //                                PreventiveLst[0].BP_Date_And_Time = FinalVitalsList[0].Captured_date_and_time;
        //                            }
        //                            if (FinalVitalsList.Count > 1)
        //                            {
        //                                FinalVitalsList = (from bp in vitalsList
        //                                                   where (bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                       || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia") && bp.Captured_date_and_time == ((from bp1 in vitalsList
        //                                                                                                                                                      where bp1.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                                                                                                                          || bp1.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                                                                                                                      select bp1.Captured_date_and_time).Max())
        //                                                   select bp).ToList<PatientResults>();
        //                                PreventiveLst[0].BpVitalName = FinalVitalsList[0].Loinc_Observation.Replace("$", "");
        //                                PreventiveLst[0].BpVitalValue = FinalVitalsList[0].Value;
        //                                PreventiveLst[0].BP_Date_And_Time = FinalVitalsList[0].Captured_date_and_time;
        //                            }
        //                        }
        //                    }


        //                }
        //                if (vitalsList[0].Results_Type.ToUpper() == "RESULTS")
        //                {
        //                    FinalVitalsList = (from bp in vitalsList
        //                                       where (bp.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                           || bp.Loinc_Observation.ToLower() == "bp-standing$ sys/dia") && bp.Captured_date_and_time == ((from bp1 in vitalsList
        //                                                                                                                                          where bp1.Loinc_Observation.ToLower() == "bp-sitting sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-lying sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-standing sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-sitting$ sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-lying$ sys/dia"
        //                                                                                                                                              || bp1.Loinc_Observation.ToLower() == "bp-standing$ sys/dia"
        //                                                                                                                                          select bp1.Captured_date_and_time).Max())
        //                                       select bp).ToList<PatientResults>();
        //                    if (FinalVitalsList.Count > 0)
        //                    {
        //                        if (PreventiveLst.Count == 0)
        //                        {
        //                            PreDto = new PreventiveScreenDTO();
        //                            PreDto.BpVitalValue = FinalVitalsList[0].Value;
        //                            PreDto.BpVitalName = FinalVitalsList[0].Loinc_Observation.Replace("$", "");
        //                            PreDto.BP_Date_And_Time = FinalVitalsList[0].Created_Date_And_Time;
        //                            PreventiveLst.Add(PreDto);
        //                        }
        //                        else
        //                        {

        //                            PreventiveLst[0].BpVitalName = FinalVitalsList[0].Loinc_Observation.Replace("$", "");
        //                            PreventiveLst[0].BpVitalValue = FinalVitalsList[0].Value;
        //                            PreventiveLst[0].BP_Date_And_Time = FinalVitalsList[0].Created_Date_And_Time;

        //                        }
        //                    }

        //                }
        //            }
        //        }

        //        //if (PreventiveLst.Count == 0)
        //        //{
        //        //    PreDto = new PreventiveScreenDTO();
        //        //    if (vitalsHBA1CList.Count > 0)
        //        //    {
        //        //        PreDto.VitalValue = vitalsHBA1CList[0].Value;
        //        //        PreDto.Modified_Date_And_Time = vitalsHBA1CList[0].Modified_Date_And_Time;
        //        //    }
        //        //    if (vitalsList.Count > 0)
        //        //    {
        //        //        PreDto.BpVitalValue = vitalsList[0].Value;
        //        //        PreDto.BpVitalName = vitalsList[0].Loinc_Observation;
        //        //        PreDto.Modified_Date_And_Time = vitalsList[0].Modified_Date_And_Time;
        //        //    }
        //        //    PreventiveLst.Add(PreDto);
        //        //}
        //        //else
        //        //{
        //        //    if (vitalsHBA1CList.Count > 0)
        //        //    {
        //        //        PreventiveLst[0].VitalValue = vitalsHBA1CList[0].Value;
        //        //        PreventiveLst[0].Modified_Date_And_Time = vitalsHBA1CList[0].Modified_Date_And_Time;

        //        //    }
        //        //    if (vitalsList.Count > 0)
        //        //    {
        //        //        PreventiveLst[0].BpVitalName = vitalsList[0].Loinc_Observation;
        //        //        PreventiveLst[0].BpVitalValue = vitalsList[0].Value;
        //        //        PreventiveLst[0].Modified_Date_And_Time = vitalsList[0].Modified_Date_And_Time;
        //        //    }
        //        //}
        //        //  ISQLQuery sql3 = session.GetISession().CreateSQLQuery("SELECT a.* from immunization_history a  where a.human_ID='" + ulHumanID + "' and a.immunization_description like 'Pneumococcal%'").AddEntity("a", typeof(ImmunizationHistory));
        //        //  immunList = sql3.List<ImmunizationHistory>();
        //        //  if (immunList.Count > 0)
        //        //  {
        //        //      PreDto.Immunstatus = "Y";
        //        //      PreventiveLst.Add(PreDto);
        //        //  }
        //        //  ISQLQuery sql4 = session.GetISession().CreateSQLQuery("SELECT a.* from assessment a  where a.human_ID='" + ulHumanID + "'and a.encounter_ID='" + ulEncounterID + "' and a.ICD like '714.0%'").AddEntity("a", typeof(Assessment));
        //        //  assesmentList = sql4.List<Assessment>();
        //        //if(assesmentList.Count>0)
        //        //  {
        //        //   PreDto.AssessmentStatus="Y";
        //        //   PreventiveLst.Add(PreDto);
        //        //  }

        //        iMySession.Close();
        //    }
        //    return PreventiveLst;
        //}

        //public IList<PreventiveScreenDTO> SavePreventiveScreen(IList<PreventiveScreen> PreLst, string MacAddress)
        //{
        //    IList<PreventiveScreen> nullList = null;
        //   // SaveUpdateDeleteWithTransaction(ref PreLst, null, null, MacAddress);
        //    SaveUpdateDelete_DBAndXML_WithTransaction(ref PreLst, ref nullList, null, MacAddress, true, false, PreLst[0].Encounter_ID, string.Empty);
        //    //GenerateXml XMLObj = new GenerateXml();
        //    //if (PreLst.Count > 0)
        //    //{

        //    //    ulong encounterid = PreLst[0].Encounter_ID;
        //    //    List<object> lstObj = PreLst.Cast<object>().ToList();
        //    //    XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
        //    //}
        //    return GetPreventiveScreenFromServer(PreLst[0].Encounter_ID, 0);
        //}

        public IList<PreventiveScreen> SavePreventiveList(IList<PreventiveScreen> PreLst, string MacAddress)
        {
            IList<PreventiveScreen> nullList = null;
           // SaveUpdateDeleteWithTransaction(ref PreLst, null, null, MacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref PreLst, ref nullList, null, MacAddress, true, false, PreLst[0].Encounter_ID, string.Empty);
           // GenerateXml XMLObj = new GenerateXml();
            //if (PreLst.Count > 0)
            //{

            //    ulong encounterid = PreLst[0].Encounter_ID;
            //    List<object> lstObj = PreLst.Cast<object>().ToList();
            //    XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
            //}
            return GetPreventiveScreenPlanDetails(PreLst[0].Encounter_ID, PreLst[0].Human_ID);
        }

        public IList<PreventiveScreen> UpdatePreventiveList(IList<PreventiveScreen> PreLst, string MacAddress)
        {
            IList<PreventiveScreen> nulllist = null;
            IList<PreventiveScreen> listPrevent = new List<PreventiveScreen>();
            //SaveUpdateDeleteWithTransaction(ref nulllist, PreLst, null, MacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref nulllist, ref PreLst, null, MacAddress, true, false, PreLst[0].Encounter_ID, string.Empty);
            listPrevent = GetPreventiveScreenPlanDetails(PreLst[0].Encounter_ID, PreLst[0].Human_ID);
            //GenerateXml XMLObj = new GenerateXml();
            //if (PreLst.Count > 0)
            //{
            //    for (int i = 0; i < PreLst.Count; i++)
            //    {
            //        PreLst[i].Version = PreLst[i].Version + 1;
            //    }
            //    ulong encounterid = PreLst[0].Encounter_ID;
            //    List<object> lstObj = PreLst.Cast<object>().ToList();
            //    XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
            //}
            return listPrevent;
        }
        //CAP-1690
        public IList<PreventiveScreen> SaveDeletePreventiveList(IList<PreventiveScreen> PreLst, IList<PreventiveScreen> DelProLst, string MacAddress)
        {
            IList<PreventiveScreen> nullList = null;
            // SaveUpdateDeleteWithTransaction(ref PreLst, null, null, MacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref nullList, ref nullList, DelProLst, MacAddress, true, false, PreLst[0].Encounter_ID, string.Empty);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref PreLst, ref nullList, null, MacAddress, true, false, PreLst[0].Encounter_ID, string.Empty);
            // GenerateXml XMLObj = new GenerateXml();
            //if (PreLst.Count > 0)
            //{

            //    ulong encounterid = PreLst[0].Encounter_ID;
            //    List<object> lstObj = PreLst.Cast<object>().ToList();
            //    XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
            //}
            return GetPreventiveScreenPlanDetails(PreLst[0].Encounter_ID, PreLst[0].Human_ID);
        }

        //public IList<PreventiveScreenDTO> UpdatePreventiveScreen(IList<PreventiveScreen> PreLst, string MacAddress)
        //{
        //    IList<PreventiveScreen> nulllist = null;
        //   // SaveUpdateDeleteWithTransaction(ref nulllist, PreLst, null, MacAddress);
        //    SaveUpdateDelete_DBAndXML_WithTransaction(ref nulllist, ref PreLst, null, MacAddress, true, false, PreLst[0].Encounter_ID, string.Empty);
        //    //GenerateXml XMLObj = new GenerateXml();
        //    //if (PreLst.Count > 0)
        //    //{
        //    //    ulong encounterid = PreLst[0].Encounter_ID;
        //    //    List<object> lstObj = PreLst.Cast<object>().ToList();
        //    //    XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
        //    //}
        //    return GetPreventiveScreenFromServer(PreLst[0].Encounter_ID, 0);
        //}

        /*
        public IList<PreventiveScreenDTO> GetPreventivePlanForPastEncounter(ulong encounterId, ulong humanId, ulong physicianId)
        {
            PreventiveScreenDTO objPreventivecateDTO = null;

            EncounterManager objEncounterManager = new EncounterManager();
            WFObjectManager objWFObjectManager = new WFObjectManager();

            IList<PreventiveScreenDTO> ilstPreventiveScreenDTO = new List<PreventiveScreenDTO>();
            WFObjectManager WFObjectManager = new WFObjectManager();

            ulong previousEncounterId = 0;
            bool isPhysicianProcess = false;
            bool isFromArchive = false;

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                try
                {
                    var ilstEncounter = objEncounterManager.GetPreviousEncounter(encounterId, humanId, physicianId, out isFromArchive);

                    if (ilstEncounter.Count == 0)
                    {
                        objPreventivecateDTO = new PreventiveScreenDTO();
                        objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                        objPreventivecateDTO.PEnc = previousEncounterId;
                        ilstPreventiveScreenDTO.Add(objPreventivecateDTO);

                        return ilstPreventiveScreenDTO;
                    }
                    else if (ilstEncounter.Count == 1)
                    {
                        previousEncounterId = ilstEncounter[0].Id;
                        isPhysicianProcess = objWFObjectManager.IsPreviousEncounterPhysicianProcess(previousEncounterId, isFromArchive);

                        objPreventivecateDTO = new PreventiveScreenDTO();
                        objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                        objPreventivecateDTO.PEnc = previousEncounterId;

                        if (!WFObjectManager.IsPreviousEncounterPhysicianProcess(previousEncounterId, isFromArchive))
                        {
                            ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                            return ilstPreventiveScreenDTO;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ilstEncounter.Count; i++)
                        {
                            previousEncounterId = ilstEncounter[i].Id;
                            isPhysicianProcess = objWFObjectManager.IsPreviousEncounterPhysicianProcess(previousEncounterId, isFromArchive);

                            if (isPhysicianProcess)
                            {
                                objPreventivecateDTO = new PreventiveScreenDTO();

                                objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                                objPreventivecateDTO.PEnc = previousEncounterId;
                                break;
                            }
                        }
                        if (!isPhysicianProcess)
                        {
                            objPreventivecateDTO = new PreventiveScreenDTO();

                            objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                            objPreventivecateDTO.PEnc = previousEncounterId;
                            ilstPreventiveScreenDTO.Add(objPreventivecateDTO);

                            return ilstPreventiveScreenDTO;
                        }
                    }

                }
                catch (Exception)
                {
                    previousEncounterId = 0;
                }
                if (previousEncounterId != 0)
                {

                    ArrayList ary = null;
                    IList<PatientResults> vitalsHBA1CList = new List<PatientResults>();
                    IList<PatientResults> vitalsList = new List<PatientResults>();

                    IQuery query;

                    if (isFromArchive)
                        query = iMySession.GetNamedQuery("Fill.PreventiveScreen.Server.Archive");
                    else
                        query = iMySession.GetNamedQuery("Fill.PreventiveScreen.Server");

                    query.SetParameter("ENCOUNTER_ID", previousEncounterId);

                    ary = new ArrayList(query.List());

                    if (ary.Count > 0)
                    {
                        for (int i = 0; i < ary.Count; i++)
                        {
                            object[] ob = (object[])ary[i];

                            objPreventivecateDTO = new PreventiveScreenDTO();
                            objPreventivecateDTO.Preventive_Screen_ID = Convert.ToUInt64(ob[0]);
                            objPreventivecateDTO.Preventive_Service = Convert.ToString(ob[1]);
                            objPreventivecateDTO.Preventive_Service_Value = Convert.ToString(ob[2]);
                            objPreventivecateDTO.Options = Convert.ToString(ob[3]);
                            objPreventivecateDTO.Status = Convert.ToString(ob[4]);
                            objPreventivecateDTO.Preventive_Screening_Notes = Convert.ToString(ob[5]);
                            objPreventivecateDTO.Created_By = Convert.ToString(ob[6]);
                            objPreventivecateDTO.Created_Date_And_Time = Convert.ToDateTime(ob[7]);
                            objPreventivecateDTO.Preventive_Screen_Lookup_ID = Convert.ToUInt64(ob[8]);
                            objPreventivecateDTO.Version = Convert.ToInt32(ob[9]);
                            objPreventivecateDTO.Depending_Value = Convert.ToString(ob[10]);
                            objPreventivecateDTO.Description = Convert.ToString(ob[11]);
                            objPreventivecateDTO.Physician_Process = true;
                            objPreventivecateDTO.PEnc = previousEncounterId;

                            ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                        }
                    }

                    ISQLQuery sql1 = iMySession.CreateSQLQuery("Select a.* from patient_results a where a.Loinc_Observation ='HBA1C' and a.Vitals_Group_ID=(Select Max(s.Vitals_Group_ID) from patient_results s where s.Encounter_ID = '" + encounterId.ToString() + "' and Loinc_Observation ='HBA1C' and Results_Type='Vitals')").AddEntity("a", typeof(PatientResults));
                    vitalsHBA1CList = sql1.List<PatientResults>();

                    ISQLQuery sql2 = iMySession.CreateSQLQuery("Select a.* from patient_results a where (a.Loinc_Observation ='bp-sitting sys/dia' or a.Loinc_Observation ='bp-lying sys/dia' or a.Loinc_Observation ='bp-standing sys/dia')  and a.Vitals_Group_ID=(Select Max(s.Vitals_Group_ID) from patient_results s where s.Encounter_ID = '" + encounterId.ToString() + "' and (Loinc_Observation ='bp-sitting sys/dia' or Loinc_Observation ='bp-lying sys/dia' or Loinc_Observation ='bp-standing sys/dia'))and Results_Type='Vitals'").AddEntity("a", typeof(PatientResults));
                    vitalsList = sql2.List<PatientResults>();

                    objPreventivecateDTO = new PreventiveScreenDTO();
                    objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                    objPreventivecateDTO.PEnc = previousEncounterId;

                    if (ilstPreventiveScreenDTO.Count == 0)
                    {
                        if (vitalsHBA1CList.Count > 0)
                        {
                            objPreventivecateDTO.VitalValue = vitalsHBA1CList[0].Value;
                            objPreventivecateDTO.Hba1c_Date_And_Time = vitalsHBA1CList[0].Captured_date_and_time;
                            ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                        }
                        if (vitalsList.Count > 0)
                        {
                            objPreventivecateDTO.BpVitalValue = vitalsList[0].Value;
                            objPreventivecateDTO.BpVitalName = vitalsList[0].Loinc_Observation;
                            objPreventivecateDTO.BP_Date_And_Time = vitalsList[0].Captured_date_and_time;
                            ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                        }

                        ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                    }
                    else
                    {
                        if (vitalsHBA1CList.Count > 0)
                        {
                            ilstPreventiveScreenDTO[0].VitalValue = vitalsHBA1CList[0].Value;
                            ilstPreventiveScreenDTO[0].Hba1c_Date_And_Time = vitalsHBA1CList[0].Captured_date_and_time;
                        }
                        if (vitalsList.Count > 0)
                        {
                            ilstPreventiveScreenDTO[0].BpVitalName = vitalsList[0].Loinc_Observation;
                            ilstPreventiveScreenDTO[0].BpVitalValue = vitalsList[0].Value;
                            ilstPreventiveScreenDTO[0].BP_Date_And_Time = vitalsList[0].Captured_date_and_time;
                        }
                    }
                }
                iMySession.Close();
            }
            return ilstPreventiveScreenDTO;
        }*/

        public IList<PreventiveScreenDTO> GetPreventiveScreenForThin(ulong ulEncounterID, ulong ulHumanID)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ArrayList ary = null;
            IList<PreventiveScreenDTO> PreventiveLst = new List<PreventiveScreenDTO>();
            PreventiveScreenDTO PreDto = null;
            IList<PatientResults> vitalsHBA1CList = new List<PatientResults>();
            IList<PatientResults> vitalsList = new List<PatientResults>();
            IList<ImmunizationHistory> immunList = new List<ImmunizationHistory>();
            IList<Assessment> assesmentList = new List<Assessment>();
            IList<Human> HumanList = new List<Human>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                IQuery query = iMySession.GetNamedQuery("Fill.PreventiveScreen.Server").SetParameter("ENCOUNTER_ID", Convert.ToString(ulEncounterID));
                ary = new ArrayList(query.List());
                if (ary.Count > 0)
                {
                    for (int i = 0; i < ary.Count; i++)
                    {
                        object[] ob = (object[])ary[i];
                        PreDto = new PreventiveScreenDTO();
                        PreDto.Preventive_Screen_ID = Convert.ToUInt64(ob[0]);
                        PreDto.Preventive_Service = Convert.ToString(ob[1]);
                        PreDto.Preventive_Service_Value = Convert.ToString(ob[2]);
                        PreDto.Options = Convert.ToString(ob[3]);
                        PreDto.Status = Convert.ToString(ob[4]);
                        PreDto.Preventive_Screening_Notes = Convert.ToString(ob[5]);
                        PreDto.Created_By = Convert.ToString(ob[6]);
                        PreDto.Created_Date_And_Time = Convert.ToDateTime(ob[7]);
                        PreDto.Preventive_Screen_Lookup_ID = Convert.ToUInt64(ob[8]);
                        PreDto.Version = Convert.ToInt32(ob[9]);
                        PreDto.Depending_Value = Convert.ToString(ob[10]);
                        PreDto.Description = Convert.ToString(ob[11]);
                        PreventiveLst.Add(PreDto);
                    }
                }
                if (PreventiveLst.Count == 0)
                {
                    if (ulHumanID != 0)
                    {
                        ISQLQuery humanqry = iMySession.CreateSQLQuery("Select a.* from human a where (a.human_id=" + ulHumanID + ")").AddEntity("a", typeof(Human));
                        HumanList = humanqry.List<Human>();
                        PreventiveLst.Add(new PreventiveScreenDTO());
                        PreventiveLst[0].Patient_Sex = HumanList[0].Sex;
                    }
                    if (PreventiveLst.Count > 0)
                    {
                        PreventiveScreenLookupManager objPreventiveScreenLookupmngr = new PreventiveScreenLookupManager();
                        PreventiveLst = objPreventiveScreenLookupmngr.GetPreventiveScreenFromLocal("Preventive_Service_Value", PreventiveLst[0].Patient_Sex);
                    }
                }
                iMySession.Close();
            }
            return PreventiveLst;
        }

        //public IList<PreventiveScreenDTO> UpdatePreventiveScreenForCopyPrevious(IList<PreventiveScreen> PreLst, string MacAddress, ulong encounter_ID, ulong human_ID, ulong Physician_ID)
        //{

        //    IList<PreventiveScreen> DeleteLst = new List<PreventiveScreen>();
        //    IList<PreventiveScreen> UpdateLst = null;
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        ICriteria crit = iMySession.CreateCriteria(typeof(PreventiveScreen)).Add(Expression.Eq("Encounter_ID", encounter_ID)).Add(Expression.Eq("Human_ID", human_ID));
        //        DeleteLst = crit.List<PreventiveScreen>();

        //      //  SaveUpdateDeleteWithTransaction(ref PreLst, null, DeleteLst, MacAddress);
        //        SaveUpdateDelete_DBAndXML_WithTransaction(ref PreLst, ref UpdateLst, null, MacAddress, false, false, PreLst[0].Encounter_ID, string.Empty);
        //        iMySession.Close();
        //    }
        //    return GetPreventiveScreenFromServer(encounter_ID, 0);
        //}

        public IList<PreventiveScreen> GetPreventiveScreenPlanDetails(ulong encounterId, ulong humanId)
        {
            IList<PreventiveScreen> lstPreventivePlan = new List<PreventiveScreen>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                var query = @"SELECT * 
                              FROM   PREVENTIVE_SCREENING P 
                              WHERE  ( P.ENCOUNTER_ID = :ENCOUNTER_ID 
                                       AND P.HUMAN_ID = :HUMAN_ID ) ";

                ISQLQuery sqlqry = iMySession.CreateSQLQuery(query).AddEntity("p", typeof(PreventiveScreen));

                sqlqry.SetParameter("ENCOUNTER_ID", encounterId);
                sqlqry.SetParameter("HUMAN_ID", humanId);

                lstPreventivePlan = sqlqry.List<PreventiveScreen>();
                iMySession.Close();
            }
            return lstPreventivePlan;
        }

        public IList<PreventiveScreenDTO> GetPreventivePlanForPastEncounter(ulong encounterId, ulong humanId,
            ulong physicianId)
        {

            PreventiveScreenDTO objPreventivecateDTO = new PreventiveScreenDTO();
            EncounterManager objEncounterManager = new EncounterManager();

            IList<PreventiveScreenDTO> ilstPreventiveScreenDTO = new List<PreventiveScreenDTO>();

            ulong previousEncounterId = 0;
            bool isPhysicianProcess = false;
            bool isFromArchive = false;

            var ilstEncounter = objEncounterManager.GetPreviousEncounterDetails(encounterId, humanId, physicianId, out isPhysicianProcess, out isFromArchive);

            if (ilstEncounter.Count > 0)
            {
                previousEncounterId = ilstEncounter[0].Id;

                objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                objPreventivecateDTO.PEnc = previousEncounterId;

                if (isPhysicianProcess)
                {
                    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                    {
                        #region Unused Functionality
                        /*var sQLQuery = @"SELECT A.* 
                                      FROM   PATIENT_RESULTS A 
                                      WHERE  A.LOINC_OBSERVATION = 'HBA1C' 
                                             AND A.VITALS_GROUP_ID = (SELECT MAX(S.VITALS_GROUP_ID) 
                                                                      FROM   PATIENT_RESULTS S 
                                                                      WHERE S.ENCOUNTER_ID = :ENCOUNTER_ID 
                                                                            AND LOINC_OBSERVATION = 'HBA1C' 
                                                                            AND RESULTS_TYPE = 'VITALS') ";

                        ISQLQuery iSQLQueryHBA1C = iMySession.CreateSQLQuery(sQLQuery).AddEntity("A", typeof(PatientResults));
                        iSQLQueryHBA1C.SetParameter("ENCOUNTER_ID", encounterId);
                        var lstVitalsHBA1C = iSQLQueryHBA1C.List<PatientResults>();

                        sQLQuery = @"SELECT A.* 
                                     FROM   PATIENT_RESULTS A 
                                     WHERE  ( A.LOINC_OBSERVATION IN ( 'BP-SITTING SYS/DIA',
                                                                       'BP-LYING SYS/DIA' ,
                                                                       'BP-STANDING SYS/DIA' ) 
                                            AND A.VITALS_GROUP_ID = (SELECT MAX(S.VITALS_GROUP_ID) 
                                                                     FROM  PATIENT_RESULTS S 
                                                                     WHERE S.ENCOUNTER_ID = :ENCOUNTER_ID 
                                                                           AND LOINC_OBSERVATION IN ( 'BP-SITTING SYS/DIA' 
                                                                                                      'BP-LYING SYS/DIA' 
                                                                                                      'BP-STANDING SYS/DIA' )) 
                                            AND RESULTS_TYPE = 'VITALS' ";

                        ISQLQuery iSQLQuery = iMySession.CreateSQLQuery(sQLQuery).AddEntity("A", typeof(PatientResults));
                        iSQLQuery.SetParameter("ENCOUNTER_ID", encounterId);
                        var lstVitals = iSQLQuery.List<PatientResults>();

                        var VitalValue = (lstVitalsHBA1C.Count > 0) ? lstVitalsHBA1C[0].Value : string.Empty;
                        var Hba1c_Date_And_Time = (lstVitalsHBA1C.Count > 0) ? lstVitalsHBA1C[0].Captured_date_and_time : DateTime.MinValue;

                        var BpVitalValue = (lstVitals.Count > 0) ? lstVitals[0].Value : string.Empty;
                        var BpVitalName = (lstVitals.Count > 0) ? lstVitals[0].Loinc_Observation : string.Empty;
                        var BP_Date_And_Time = (lstVitals.Count > 0) ? lstVitals[0].Captured_date_and_time : DateTime.MinValue;
                        */
                        #endregion

                        IQuery iQuery;

                        if (isFromArchive)
                            iQuery = iMySession.GetNamedQuery("Fill.PreventiveScreen.Server.Archive");
                        else
                            iQuery = iMySession.GetNamedQuery("Fill.PreventiveScreen.Server");

                        iQuery.SetParameter("ENCOUNTER_ID", previousEncounterId);

                        var ary = new ArrayList(iQuery.List());


                            for (int i = 0; i < ary.Count; i++)
                            {
                                object[] ob = (object[])ary[i];

                                objPreventivecateDTO = new PreventiveScreenDTO();
                                if(ob[0] != null)
                                objPreventivecateDTO.Preventive_Screen_ID = Convert.ToUInt64(ob[0]);
                                if (ob[1] != null)
                                objPreventivecateDTO.Preventive_Service = Convert.ToString(ob[1]);
                                if (ob[2] != null)
                                objPreventivecateDTO.Preventive_Service_Value = Convert.ToString(ob[2]);
                                if (ob[3] != null)
                                objPreventivecateDTO.Options = Convert.ToString(ob[3]);
                                if (ob[4] != null)
                                objPreventivecateDTO.Status = Convert.ToString(ob[4]);
                                if (ob[5] != null)
                                objPreventivecateDTO.Preventive_Screening_Notes = Convert.ToString(ob[5]);
                                if (ob[6] != null)
                                objPreventivecateDTO.Created_By = Convert.ToString(ob[6]);
                                if (ob[7] != null)
                                objPreventivecateDTO.Created_Date_And_Time = Convert.ToDateTime(ob[7]);
                                if (ob[8] != null)
                                objPreventivecateDTO.Preventive_Screen_Lookup_ID = Convert.ToUInt64(ob[8]);
                                if (ob[9] != null)
                                objPreventivecateDTO.Version = Convert.ToInt32(ob[9]);
                                if (ob[10] != null)
                                objPreventivecateDTO.Depending_Value = Convert.ToString(ob[10]);
                                if (ob[11] != null)
                                objPreventivecateDTO.Description = Convert.ToString(ob[11]);

                                if (i == 0)
                                {
                                    objPreventivecateDTO.Physician_Process = isPhysicianProcess;
                                    objPreventivecateDTO.PEnc = previousEncounterId;

                                    #region Unused Functionality
                                    /* objPreventivecateDTO.VitalValue = VitalValue;
                                    objPreventivecateDTO.Hba1c_Date_And_Time = Hba1c_Date_And_Time;
                                    objPreventivecateDTO.BpVitalValue = BpVitalValue;
                                    objPreventivecateDTO.BpVitalName = BpVitalName;
                                    objPreventivecateDTO.BP_Date_And_Time = BP_Date_And_Time;*/
                                    #endregion
                                }
                                ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                            }
                        #region Unused Functionality
                        /*else
                        {
                            
                            objPreventivecateDTO.VitalValue = VitalValue;
                            objPreventivecateDTO.Hba1c_Date_And_Time = Hba1c_Date_And_Time;
                            objPreventivecateDTO.BpVitalValue = BpVitalValue;
                            objPreventivecateDTO.BpVitalName = BpVitalName;
                            objPreventivecateDTO.BP_Date_And_Time = BP_Date_And_Time;
                           

                            //ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                        }*/
                         #endregion
                        iMySession.Close();
                    }
                }

                if (ilstPreventiveScreenDTO.Count == 0)
                {
                    ilstPreventiveScreenDTO.Add(objPreventivecateDTO);
                }
            }

            return ilstPreventiveScreenDTO;
        }
        #endregion
    }
}

