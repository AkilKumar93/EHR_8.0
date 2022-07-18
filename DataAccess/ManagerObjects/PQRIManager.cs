using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
     public partial interface IPQRIManager: IManagerBase<PQRI,ulong>
    {
         PQRIDTO GetSocialHistoryDetails(ulong myHumanID,string SmokingHabit,ulong Physician_Id,ulong Encounter_Id,string Bmi,bool bLoad);
         PQRIDTO SavePQRIData(IList<PQRI> PQRISaveList, IList<PQRI> PQRIUpdateList,string strfrom);
    }
     public partial class PQRIManager : ManagerBase<PQRI, ulong>, IPQRIManager
     {

           #region Constructors

        public PQRIManager()
            : base()
        {

        }
        public PQRIManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion 

         #region Methods
        public PQRIDTO GetSocialHistoryDetails(ulong myHumanID, string TobaccoUse, ulong Physician_Id, ulong Encounter_Id, string Bmi,bool bLoad)
        {
            PQRIDTO objPQRIDTO = new PQRIDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria savecrit = iMySession.CreateCriteria(typeof(PQRI)).Add(Expression.Eq("Encounter_ID", Convert.ToInt32(Encounter_Id)));
                objPQRIDTO.PQRIList = savecrit.List<PQRI>();

                if (bLoad) //&& (objPQRIDTO.PQRIList == null || objPQRIDTO.PQRIList.Count==0))
                {

                    IQuery query1 = iMySession.GetNamedQuery("Fill.SocialHistory.TobaccoUse");

                    query1.SetString(0, Convert.ToString(myHumanID));
                    // query1.SetString(1, TobaccoUse);
                    IQuery query2 = iMySession.GetNamedQuery("Get.PQRIBMI.Status");
                    query2.SetString(0, Convert.ToString(myHumanID));
                    IQuery query3 = iMySession.GetNamedQuery("Fill.SocialHistory.SmokinHabit");
                    query3.SetString(0, Convert.ToString(myHumanID));
                    IQuery query4 = iMySession.GetNamedQuery("Fill.SocialHistory.Bmi");
                    query4.SetString(0, Convert.ToString(myHumanID));
                    query4.SetString(1, Convert.ToString(Encounter_Id));
                    IQuery query5 = iMySession.GetNamedQuery("Fill.SocialHistory.Bmistatus");
                    query5.SetString(0, Convert.ToString(myHumanID));
                    query5.SetString(1, Convert.ToString(Encounter_Id));
                    // query4.SetString(2, Convert.ToString(Physician_Id));

                    ArrayList aryBMIlist = null;
                    ArrayList aryTobaccoList = null;
                    ArrayList arySmokingList = null;
                    ArrayList aryBMIStatus = null;
                    aryTobaccoList = new ArrayList(query1.List());
                    for (int i = 0; i < aryTobaccoList.Count; i++)
                    {
                        object[] TobaccoObj = (object[])aryTobaccoList[i];
                        objPQRIDTO.Tobacco_Social_Info = TobaccoObj[0].ToString();
                        objPQRIDTO.Tobacco_Is_Present = TobaccoObj[1].ToString();

                    }
                    arySmokingList = new ArrayList(query3.List());
                    for (int j = 0; j < arySmokingList.Count; j++)
                    {
                        object[] SmokingObj = (object[])arySmokingList[j];
                        objPQRIDTO.SmokingHabit_Social_Info = SmokingObj[0].ToString();
                        objPQRIDTO.Smoking_Is_Present = SmokingObj[1].ToString();
                    }

                    aryBMIlist = new ArrayList(query4.List());
                    {
                        for (int k = 0; k < aryBMIlist.Count; k++)
                        {

                            object[] BmiObj = (object[])aryBMIlist[k];
                            if (k == 0)
                            {
                                if (BmiObj[2] != null)
                                {
                                    objPQRIDTO.Bmi = BmiObj[2].ToString();
                                    //objPQRIDTO.Bmi_Status = BmiObj[1].ToString();
                                }
                            }
                        }


                    }
                    aryBMIStatus = new ArrayList(query5.List());
                    {
                        for (int k = 0; k < aryBMIStatus.Count; k++)
                        {

                            object[] BmiObj = (object[])aryBMIStatus[k];
                            if (k == 0)
                            {
                                if (BmiObj[2] != null)
                                {
                                    objPQRIDTO.Bmi_Status = BmiObj[2].ToString();
                                }
                            }
                        }


                    }
                }
                iMySession.Close();

            }
            return objPQRIDTO;
        }
        public PQRIDTO SavePQRIData(IList<PQRI> PQRISaveList, IList<PQRI> PQRIUpdateList,string strfrom)
       {
           //ICriteria savecrit = null;
          // IList<PQRI> pqri = null;
           IList<PQRI> objlist = null;
            ulong ulEncounter_id=0;
            if (strfrom != "SocialHistory")
            {
                if (PQRISaveList != null && PQRISaveList.Count > 0)
                {
                    ulEncounter_id = Convert.ToUInt64(PQRISaveList[0].Encounter_ID);
                    //SaveUpdateDeleteWithTransaction(ref PQRISaveList, PQRIUpdateList, null, string.Empty);                    
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref PQRISaveList, ref PQRIUpdateList, null, string.Empty, false, false, ulEncounter_id, string.Empty);

                }
                else if (PQRIUpdateList != null && PQRIUpdateList.Count > 0)
                {
                    ulEncounter_id = Convert.ToUInt64(PQRIUpdateList[0].Encounter_ID);
                    //SaveUpdateDeleteWithTransaction(ref PQRISaveList, PQRIUpdateList, null, string.Empty);
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref PQRISaveList, ref PQRIUpdateList, null, string.Empty, false, false, ulEncounter_id, string.Empty);
                }
            }

            else
            {

               
                IList<PQRI> lstGetList = new List<PQRI>();
                using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                {
                    ISQLQuery query1 = iMySession.CreateSQLQuery("select u.* FROM pqri u where human_id=(:Human_ID) and Encounter_ID=(:Encounter_Id)").AddEntity("u", typeof(PQRI));
                    query1.SetParameter("Human_ID", Convert.ToString(PQRIUpdateList[0].Human_ID));
                    query1.SetParameter("Encounter_Id", Convert.ToString(PQRIUpdateList[0].Encounter_ID));
                    lstGetList = query1.List<PQRI>();
                    iMySession.Close();
                }
                if (lstGetList.Count > 0 && lstGetList != null)
                {
                     ulEncounter_id = Convert.ToUInt64(PQRIUpdateList[0].Encounter_ID);
                     for (int i = 0; i < lstGetList.Count; i++)
                     {
                         if (PQRIUpdateList.Count > i)
                         {
                             lstGetList[i].PQRI_Name = PQRIUpdateList[i].PQRI_Name;
                             lstGetList[i].PQRI_Value = PQRIUpdateList[i].PQRI_Value;
                             lstGetList[i].Options = PQRIUpdateList[i].Options;
                         }

                       //  Updatelist = Updatelist.Select(a => { a.Options = PQRIUpdateList[i].Options; a.PQRI_Value = PQRIUpdateList[i].PQRI_Value; a.Modified_By = PQRIUpdateList[i].Modified_By; a.Modified_Date_And_Time = System.DateTime.Now; return a; }).ToList<PQRI>();

                         
                     }
                     //SaveUpdateDeleteWithTransaction(ref objlist, lstGetList, null, string.Empty);
                     SaveUpdateDelete_DBAndXML_WithTransaction(ref objlist, ref lstGetList, null, string.Empty, false, false, ulEncounter_id, string.Empty);
                }
                else
                {

                    ulEncounter_id = Convert.ToUInt64(PQRIUpdateList[0].Encounter_ID);
                    //SaveUpdateDeleteWithTransaction(ref PQRIUpdateList, null, null, string.Empty);
                    IList<PQRI> pqriupdatenull = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref PQRIUpdateList, ref pqriupdatenull, null, string.Empty, false, false, ulEncounter_id, string.Empty);
                }

            }
           return GetSocialHistoryDetails(0, string.Empty, 0, ulEncounter_id,string.Empty,false);
       }





       }

        #endregion 
     }


