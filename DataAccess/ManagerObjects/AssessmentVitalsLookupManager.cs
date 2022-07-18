using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAssessmentVitalsLookupManager : IManagerBase<AssessmentVitalsLookup, ulong>
    {
        IList<string> GetIcdBasedOnVitals(IList<AssessmentVitalsLookup> AssessmentVitalsLookuplst, IList<PatientResults> vitalsList);
    }

    public partial class AssessmentVitalsLookupManager : ManagerBase<AssessmentVitalsLookup, ulong>, IAssessmentVitalsLookupManager
    {
        public AssessmentVitalsLookupManager()
            : base()
        {

        }
        public AssessmentVitalsLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }



        //public IList<string> GetIcdBasedOnVitals(IList<AssessmentVitalsLookup> AssessmentVitalsLookuplst,IList<PatientResults> vitalsList)
        //{
        //    //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
        //    IList<AssessmentVitalsLookup> AssessmentVitalsLookupList = AssessmentVitalsLookuplst.ToList<AssessmentVitalsLookup>();
        //    IList<string> icdList = new List<string>();
        //    //using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    //{
        //    //    ICriteria crit2 = iMySession.CreateCriteria(typeof(AssessmentVitalsLookup));
        //    //    AssessmentVitalsLookupList = crit2.List<AssessmentVitalsLookup>();

        //        if (AssessmentVitalsLookupList.Count > 0 && vitalsList.Count > 0)
        //        {
        //            //Take distinct from Assessment_Vitals_Lookup table.
        //            var distin = (from val in AssessmentVitalsLookupList
        //                          select val.Field_Name).Distinct().ToList();

        //            //Selvamani - 22/12/2011 
        //            if (vitalsList.Any(v => v.Value.Contains("BMI %tile")))
        //            {
        //                distin.Remove("BMI");
        //                distin.Remove("BMI STATUS");
        //            }
        //            //$

        //            if (distin.Count() != 0)
        //            {
        //                foreach (var lookupDistin in distin)
        //                {
        //                    //Compare the vital name of vitals table and assessment_vitals_lookup.
        //                    var invitals = (from vit in vitalsList
        //                                    where vit.Loinc_Observation.ToUpper() == lookupDistin.ToUpper()
        //                                    select vit).ToList();

        //                    //Selvamani - 22/12/2011 
        //                    if (lookupDistin == "BMI PERCENTILE")
        //                        invitals = vitalsList.Where(s => s.Value.Contains("BMI %tile")).ToList();
        //                    //$

        //                    if (invitals.Count() != 0)
        //                    {
        //                        foreach (var inv in invitals)
        //                        {
        //                            //Get the value of that field from assessment_vitals_lookup.
        //                            var vitalsLook = (from look in AssessmentVitalsLookupList
        //                                              //Latha - Main - 28 Jul 2011 - Start
        //                                              where look.Field_Name.ToUpper() == inv.Loinc_Observation.ToUpper()
        //                                              orderby look.Sort_Order
        //                                              //Latha - Main - 28 Jul 2011 - End
        //                                              select look).ToList();

        //                            //Selvamani - 22/12/2011 
        //                            if (lookupDistin == "BMI PERCENTILE")
        //                            {
        //                                vitalsLook = AssessmentVitalsLookupList.Where(a => a.Field_Name.ToUpper() == lookupDistin).OrderBy(o => o.Sort_Order).ToList();
        //                                inv.Value = inv.Value.Split(' ')[2].ToString();
        //                            }
        //                            //$

        //                            if (vitalsLook.Count() != 0)
        //                            {
        //                                foreach (var vals in vitalsLook)
        //                                {
        //                                    if (inv.Value != string.Empty && inv.Value.Trim() != "" && char.IsDigit(inv.Value, 0) == true)
        //                                    {
        //                                        string[] spli = vals.Value.Split('-');
        //                                        if (spli.Count() == 2)
        //                                        {
        //                                            if (Convert.ToDecimal(inv.Value) >= Convert.ToDecimal(spli[0]) && Convert.ToDecimal(inv.Value) <= Convert.ToDecimal(spli[1]))
        //                                            {
        //                                                icdList.Add(vals.ICD_10);
        //                                                break;
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            if (vals.Value != "")
        //                                            {
        //                                                if (Convert.ToDecimal(inv.Value) >= Convert.ToDecimal(vals.Value))
        //                                                {
        //                                                    icdList.Add(vals.ICD_10);
        //                                                    break;
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                    else if (inv.Value != string.Empty && inv.Value.Trim()!="" && char.IsLetter(inv.Value.Trim(), 0) == true)
        //                                    {
        //                                        if (vals.Description.Trim().ToUpper() == inv.Value.Trim().ToUpper())
        //                                        {
        //                                            icdList.Add(vals.ICD_10);
        //                                            break;
        //                                        }

        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        string sICD = string.Empty;
        //        for (int i = 0; i < icdList.Count; i++)
        //        {
        //            if (sICD == string.Empty)
        //                sICD = icdList[i].ToString();
        //            else
        //                sICD += '|' + icdList[i].ToString();

        //        }
        //        //AllICD_9Manager allIcd = new AllICD_9Manager();
        //        //icdList = allIcd.TakeParentICD(sICD);
        //        //icdList = allIcd.TakingTheParentForProblemListCode(icdList);
        //        //iMySession.Close();
        //    //}
        //    return icdList;
        //}

        public IList<string> GetIcdBasedOnVitals(IList<AssessmentVitalsLookup> AssessmentVitalsLookuplst, IList<PatientResults> vitalsList)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<AssessmentVitalsLookup> AssessmentVitalsLookupList = AssessmentVitalsLookuplst.ToList<AssessmentVitalsLookup>();
            IList<string> icdList = new List<string>();
            //using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            //{
            //    ICriteria crit2 = iMySession.CreateCriteria(typeof(AssessmentVitalsLookup));
            //    AssessmentVitalsLookupList = crit2.List<AssessmentVitalsLookup>();

            if (AssessmentVitalsLookupList.Count > 0 && vitalsList.Count > 0)
            {
                //Take distinct from Assessment_Vitals_Lookup table.
                var distin = (from val in AssessmentVitalsLookupList
                              select val.Field_Name).Distinct().ToList();

                //Selvamani - 22/12/2011 
                if (vitalsList.Any(v => v.Value.Contains("BMI %tile")))
                {
                    distin.Remove("BMI");
                    distin.Remove("BMI STATUS");
                }
                //$

                if (distin.Count() != 0)
                {
                    foreach (var lookupDistin in distin)
                    {
                        //Compare the vital name of vitals table and assessment_vitals_lookup.
                        var invitals = (from vit in vitalsList
                                        where vit.Loinc_Observation.ToUpper() == lookupDistin.ToUpper()
                                        select vit).ToList();

                        //Selvamani - 22/12/2011 
                        if (lookupDistin == "BMI PERCENTILE")
                            invitals = vitalsList.Where(s => s.Value.Contains("BMI %tile")).ToList();
                        //$

                        if (invitals.Count() != 0)
                        {
                            foreach (var inv in invitals)
                            {
                                //Get the value of that field from assessment_vitals_lookup.
                                var vitalsLook = (from look in AssessmentVitalsLookupList
                                                  //Latha - Main - 28 Jul 2011 - Start
                                                  where look.Field_Name.ToUpper() == inv.Loinc_Observation.ToUpper()
                                                  orderby look.Sort_Order
                                                  //Latha - Main - 28 Jul 2011 - End
                                                  select look).ToList();

                                //Selvamani - 22/12/2011 
                                if (lookupDistin == "BMI PERCENTILE")
                                {
                                    vitalsLook = AssessmentVitalsLookupList.Where(a => a.Field_Name.ToUpper() == lookupDistin).OrderBy(o => o.Sort_Order).ToList();
                                    inv.Value = inv.Value.Split(' ')[2].ToString();
                                }
                                //$

                                if (vitalsLook.Count() != 0)
                                {
                                    foreach (var vals in vitalsLook)
                                    {
                                        if (inv.Value != string.Empty && inv.Value.Trim() != "" && char.IsDigit(inv.Value, 0) == true)
                                        {
                                            string[] spli = vals.Value.Split('-');
                                            if (spli.Count() == 2)
                                            {
                                                if (Convert.ToDecimal(inv.Value) >= Convert.ToDecimal(spli[0]) && Convert.ToDecimal(inv.Value) <= Convert.ToDecimal(spli[1]))
                                                {
                                                    icdList.Add(vals.ICD_10 + "!" + vals.Hirarrchy + "!" + vals.Field_Name);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (vals.Value != "")
                                                {
                                                    if (Convert.ToDecimal(inv.Value) >= Convert.ToDecimal(vals.Value))
                                                    {
                                                        icdList.Add(vals.ICD_10 + "!" + vals.Hirarrchy + "!" + vals.Field_Name);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else if (inv.Value != string.Empty && inv.Value.Trim() != "" && char.IsLetter(inv.Value.Trim(), 0) == true)
                                        {
                                            if (vals.Description.Trim().ToUpper() == inv.Value.Trim().ToUpper())
                                            {
                                                icdList.Add(vals.ICD_10 + "!" + vals.Hirarrchy + "!" + vals.Field_Name);
                                                break;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string sICD = string.Empty;
            for (int i = 0; i < icdList.Count; i++)
            {
                if (sICD == string.Empty)
                    sICD = icdList[i].ToString();
                else
                    sICD += '|' + icdList[i].ToString();

            }
            //AllICD_9Manager allIcd = new AllICD_9Manager();
            //icdList = allIcd.TakeParentICD(sICD);
            //icdList = allIcd.TakingTheParentForProblemListCode(icdList);
            //iMySession.Close();
            //}
            return icdList;
        }
    }
}