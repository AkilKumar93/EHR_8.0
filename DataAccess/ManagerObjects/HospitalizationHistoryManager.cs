using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using System;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IHospitalizationHistoryManager : IManagerBase<HospitalizationHistory, uint>
    {
        //HospitalizationDTO SaveHospitalizationHistory(HospitalizationHistory hospHistory, int pagenumber, int maxnumber, string macAddress); //prabu 14/04/10
        //HospitalizationDTO UpdateHospitalizationHistory(HospitalizationHistory hospHistory, int pagenumber, int maxnumber, string macAddress);
        //HospitalizationDTO DeleteHospitalizationHistory(HospitalizationHistory hospHistory, int pagenumber, int maxnumber, string macAddress);
        //HospitalizationDTO GetHospitalizationHistoryByPatientIDandSatus(ulong Human_ID, ulong EncounterID, int pagenumber, int maxnumber);
        //IList<HospitalizationHistory> GetHospitalizationHistoryByHospID(ulong HospId);

        HospitalizationDTO SaveHospitalizationHistory(IList<HospitalizationHistory> hosplst, IList<HospitalizationHistory> hospHistory, int pagenumber, int maxnumber, string macAddress, ulong EncounterID, IList<HospitalizationHistory> ilstAdd); //prabu 14/04/10
        HospitalizationDTO UpdateHospitalizationHistory(IList<HospitalizationHistory> hosplst, IList<HospitalizationHistory> hospHistory, IList<HospitalizationHistory> updateList, int pagenumber, int maxnumber, string macAddress, ulong EncounterID);
        HospitalizationDTO DeleteHospitalizationHistory(IList<HospitalizationHistory> hosplst, IList<HospitalizationHistory> hospHistory, IList<HospitalizationHistory> DeleteList, string macAddress, ulong EncounterID, ulong HuamnID);
        HospitalizationDTO GetHospitalizationHistoryByPatientIDandSatus(ulong Human_ID, ulong EncounterID, int pagenumber, int maxnumber, bool Is_Load);
        IList<HospitalizationHistory> GetHospitalizationHistoryByHospID(ulong HospId, ulong EncounterID);
        HospitalizationDTO HospitalHistorySaveUpdateDelete(IList<HospitalizationHistory> HosptHistory, IList<HospitalizationHistory> InsertList, IList<HospitalizationHistory> UpdateList, IList<HospitalizationHistory> DeleteList, ulong HumanId, string macAddress, ulong EncounterId);
    }
    public partial class HospitalizationHistoryManager : ManagerBase<HospitalizationHistory, uint>, IHospitalizationHistoryManager
    {
        #region Constructors

        public HospitalizationHistoryManager()
            : base()
        {

        }
        public HospitalizationHistoryManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

        public HospitalizationDTO GetHospitalizationHistoryByPatientIDandSatus(ulong Human_ID, ulong EncounterID, int pagenumber, int maxnumber, bool Is_Load)
        {
            bool IsPrevious = false;
            HospitalizationDTO hospDto = new HospitalizationDTO();
            IList<HospitalizationHistory> CommonHospitalizationList = new List<HospitalizationHistory>();
            ICriteria crt = null;
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (!Is_Load)
                {
                    crt = mySession.CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Human_ID", Human_ID)).Add(Expression.Eq("Encounter_Id", EncounterID));
                    CommonHospitalizationList = crt.List<HospitalizationHistory>();
                }

                else //if (crt.List<HospitalizationHistory>().Count == 0)
                {
                    #region Commented for Bug ID: 33624
                    //crt = mySession.CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Human_ID", Human_ID));//.Add(Expression.Eq("Encounter_Id", EncounterID));
                    //CommonHospitalizationList = crt.List<HospitalizationHistory>();

                    //IList<HospitalizationHistory> lst = CommonHospitalizationList.ToList();


                    //if (lst.Any(a => a.Encounter_Id == EncounterID))
                    //{
                    //    CommonHospitalizationList = lst.Where(a => a.Encounter_Id == EncounterID).ToList<HospitalizationHistory>();
                    //    IsPrevious = true;

                    //}
                    //else
                    //{

                    //    EncounterManager encMngr = new EncounterManager();
                    //    IList<Encounter> EncLst = new List<Encounter>();
                    //    EncLst = encMngr.GetEncounterUsingHumanID(Human_ID);
                    //    Encounter currentObj = (from objEnc in EncLst where objEnc.Id == EncounterID select objEnc).ToList<Encounter>()[0];
                    //    if (EncLst.Count > 0 && Is_Load)
                    //    {
                    //        foreach (Encounter item in EncLst)
                    //        {
                    //            //if (EncounterID >= item.Id)//Commented for Bug ID: 33624
                    //            if (DateTime.Compare(item.Date_of_Service, currentObj.Date_of_Service) < 0)
                    //            {
                    //                if (lst.Any(a => a.Encounter_Id == item.Id))
                    //                {
                    //                    CommonHospitalizationList = lst.Where(a => a.Encounter_Id == item.Id).ToList<HospitalizationHistory>();

                    //                    IsPrevious = true;
                    //                    break;

                    //                }
                    //            }
                    //        }
                    //    }
                    //}



                    //if (!IsPrevious && Is_Load)
                    //{
                    //    //crt = session.GetISession().CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Human_ID", Human_ID)).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
                    //    CommonHospitalizationList = lst.Where(a => a.Human_ID == Human_ID && a.Encounter_Id == Convert.ToUInt16(0)).ToList<HospitalizationHistory>();
                    //}
                    #endregion
                    IQuery query = mySession.GetNamedQuery("Get.Hospitalization.History.And.Encounter.Details");
                    query.SetParameter(0, Human_ID);
                    IList<HospitalizationHistory> lstHosp = new List<HospitalizationHistory>();
                    ArrayList resultList = new ArrayList(query.List());
                    Dictionary<ulong, DateTime> dictEnc = new Dictionary<ulong, DateTime>();
                    foreach (object objResult in resultList)
                    {
                        HospitalizationHistory objHosp = new HospitalizationHistory();
                        object[] lstObj = (object[])objResult;
                        objHosp.Id = Convert.ToUInt32(lstObj[0]);
                        objHosp.Human_ID = Convert.ToUInt32(lstObj[1]);
                        objHosp.From_Date = Convert.ToString(lstObj[2]);
                        objHosp.To_Date = Convert.ToString(lstObj[3]);
                        objHosp.Reason_For_Hospitalization = Convert.ToString(lstObj[4]);
                        objHosp.Created_By = Convert.ToString(lstObj[5]);
                        objHosp.Created_Date_And_Time = Convert.ToDateTime(lstObj[6].ToString());
                        objHosp.Modified_By = Convert.ToString(lstObj[7]);
                        objHosp.Modified_Date_And_Time = Convert.ToDateTime(lstObj[8]);
                        objHosp.Version = Convert.ToInt32(lstObj[9]);
                        objHosp.Hospitalization_Notes = Convert.ToString(lstObj[10]);
                        objHosp.Encounter_Id = Convert.ToUInt32(lstObj[11]);
                        if (!dictEnc.ContainsKey(Convert.ToUInt32(lstObj[12])))
                            dictEnc.Add(Convert.ToUInt32(lstObj[12]), Convert.ToDateTime(lstObj[13]));
                        lstHosp.Add(objHosp);
                    }
                    lstHosp = lstHosp.GroupBy(x => x.Id).Select(x => x.First()).ToList<HospitalizationHistory>();
                    if (lstHosp.Count > 0)
                        CommonHospitalizationList = (from obj in lstHosp where obj.Encounter_Id == EncounterID select obj).ToList<HospitalizationHistory>();
                    if (CommonHospitalizationList.Count > 0)
                        IsPrevious = true;
                    else
                    {
                        DateTime curr_DOS = DateTime.MinValue;
                        if (dictEnc.Count != 0)
                            curr_DOS = Convert.ToDateTime(dictEnc[EncounterID]);
                        foreach (KeyValuePair<ulong, DateTime> entry in dictEnc)
                        {
                            if (DateTime.Compare(Convert.ToDateTime(entry.Value), curr_DOS) < 0)
                            {
                                if (lstHosp.Count > 0)
                                {
                                    CommonHospitalizationList = (from obj in lstHosp where obj.Encounter_Id == Convert.ToUInt32(entry.Key) select obj).ToList<HospitalizationHistory>();
                                    IsPrevious = true;
                                    break;
                                }

                            }
                        }
                        if (!IsPrevious && Is_Load)
                        {
                            //crt = session.GetISession().CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Human_ID", Human_ID)).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
                            CommonHospitalizationList = lstHosp.Where(a => a.Human_ID == Human_ID && a.Encounter_Id == Convert.ToUInt16(0)).ToList<HospitalizationHistory>();
                        }
                    }
                    //commented by nijanthan 18-1-16
                    //hospDto.iHospCount = CommonHospitalizationList.Count;
                }
                //commented by nijanthan 18-1-16
                //hospDto.iHospCount = CommonHospitalizationList.Count;
                IList<HospitalizationHistory> tempHospitalizationHistoryList = new List<HospitalizationHistory>();
                if (CommonHospitalizationList != null && CommonHospitalizationList.Count > 0)
                {
                    tempHospitalizationHistoryList = CommonHospitalizationList.Skip((pagenumber - 1) * maxnumber).Take(maxnumber).ToList(); //GetByCriteria(MaxResultSet, PageNumber, criteria);
                    //tempSurgicalList = GetByCriteria(MaxResultSet, PageNumber, criteria);
                }

                //for (int i = 0; i < tempHospitalizationHistoryList.Count; i++)
                //{
                //    if (tempHospitalizationHistoryList[i].From_Date != string.Empty)
                //    {
                //        if (tempHospitalizationHistoryList[i].From_Date.Split('-').Length > 1)
                //        {
                //            tempHospitalizationHistoryList[i].TempFromDate = Convert.ToDateTime(tempHospitalizationHistoryList[i].From_Date);
                //        }
                //        else
                //        {
                //            tempHospitalizationHistoryList[i].TempFromDate = Convert.ToDateTime("Dec-" + tempHospitalizationHistoryList[i].From_Date);
                //        }
                //    }
                //    else
                //    {
                //        tempHospitalizationHistoryList[i].TempFromDate = tempHospitalizationHistoryList[i].Modified_Date_And_Time;//Convert.ToDateTime(DateTime.Now);
                //    }
                //}
                hospDto.HospList = tempHospitalizationHistoryList;
                mySession.Close();
            }
            //if (EncounterID > 0)
            //{
            //    Encounter objEncounter = null;
            //    ICriteria crt1 = session.GetISession().CreateCriteria(typeof(Encounter)).Add(Expression.Eq("Id", EncounterID));
            //    if (crt1.List<Encounter>().Count > 0)
            //        objEncounter = crt1.List<Encounter>()[0];
            //    hospDto.Encount = objEncounter;

            //}
            //IList<Human> objHuman = null;
            //ICriteria crt2 = session.GetISession().CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", Human_ID));
            //objHuman = crt.List<Human>()[0].Birth_Date;
            //hospDto.DateofBirth = crt2.List<Human>()[0].Birth_Date;
            return hospDto;
        }

        public IList<HospitalizationHistory> GetHospitalizationHistoryByHospID(ulong HospId, ulong EncounterID)
        {
            IList<HospitalizationHistory> lsthospitalHistory = new List<HospitalizationHistory>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Id", HospId)).Add(Expression.Eq("Encounter_Id", EncounterID));
                if (criteria.List<HospitalizationHistory>().Count == 0)
                    criteria = iMySession.CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Id", HospId));
                lsthospitalHistory = criteria.List<HospitalizationHistory>();
                iMySession.Close();
            }
            return lsthospitalHistory;
        }
        //prabu 14/04/10
        public HospitalizationDTO SaveHospitalizationHistory(IList<HospitalizationHistory> hosplst, IList<HospitalizationHistory> hospHistory, int pagenumber, int maxnumber, string macAddress, ulong EncounterID, IList<HospitalizationHistory> ilstAdd)
        {
            IList<HospitalizationHistory> UpdateHospHistory = null;
            if (hospHistory.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithTransaction(ref hospHistory, ref UpdateHospHistory, null, macAddress, true, true, hospHistory[0].Human_ID, string.Empty);
            }
            HospitalizationDTO HospitalDTOObject = new HospitalizationDTO();
            HospitalDTOObject.HospList = hosplst.Concat(hospHistory).ToList<HospitalizationHistory>();
            return HospitalDTOObject;
        }
        //prabu 14/04/10
        public HospitalizationDTO UpdateHospitalizationHistory(IList<HospitalizationHistory> hosplst, IList<HospitalizationHistory> hospHistory, IList<HospitalizationHistory> updateList, int pagenumber, int maxnumber, string macAddress, ulong EncounterID)
        {
            
            //ulong EncounterID = 0;
            //IList<HospitalizationHistory> objHospitalizationHistory = new List<HospitalizationHistory>();
            //IList<HospitalizationHistory> +objHospitalizationHistorySave = null;
            //objHospitalizationHistory.Add(hospHistory);
            ulong Encounter_Id = hospHistory.Count > 0 ? hospHistory[0].Encounter_Id : updateList.Count > 0 ? updateList[0].Encounter_Id : 0;
            if (hospHistory.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithTransaction(ref hospHistory, ref updateList, null, macAddress, true, false, Encounter_Id, string.Empty);
            }
            //SaveUpdateDeleteWithTransaction(ref hospHistory, updateList, null, macAddress);
            HospitalizationDTO HospitalDTOObject = new HospitalizationDTO();
            HospitalDTOObject.HospList = hosplst.Concat(updateList).ToList<HospitalizationHistory>();
            return HospitalDTOObject;
            /*

            if (hospHistory != null && hospHistory.Count > 0)
                Human_ID = hospHistory[0].Human_ID;
            else if (updateList != null && updateList.Count > 0)
                Human_ID = updateList[0].Human_ID;
            IList<HospitalizationHistory> CommonHospList = new List<HospitalizationHistory>();
            HospitalizationHistory hospHis = new HospitalizationHistory();
            HospitalizationHistory hosHS = new HospitalizationHistory();
            foreach (HospitalizationHistory obj in hosplst)
            {
                CommonHospList.Add(obj);
            }
            GenerateXml XMLObj = new GenerateXml();
            if (updateList.Count > 0)
            {
                ulong encounterid = updateList[0].Encounter_Id;
                foreach (HospitalizationHistory objlst in updateList)
                {
                    var HosHis = (from lst in CommonHospList where lst.Id == objlst.Id select lst);
                    hosHS = HosHis.ToList<HospitalizationHistory>()[0];

                }
                for (int i = 0; i < CommonHospList.Count; i++)
                {
                    if (CommonHospList[i].Id == hosHS.Id)
                    {

                        CommonHospList[i] = updateList[0];
                        CommonHospList[i].Version += 1;
                    }


                }


                HospitalDTOObject.HospList = CommonHospList;
                List<object> lstObj = updateList.Cast<object>().ToList();
                XMLObj.GenerateXmlUpdate(lstObj, encounterid, string.Empty);
            }
            //for (int i = 0; i < CommonHospList.Count; i++)
            //{
            //    if (CommonHospList[i].From_Date != string.Empty)
            //    {
            //        if (CommonHospList[i].From_Date.Split('-').Length > 1)
            //        {
            //            CommonHospList[i].TempFromDate = Convert.ToDateTime(CommonHospList[i].From_Date);
            //        }
            //        else
            //        {
            //            CommonHospList[i].TempFromDate = Convert.ToDateTime("Dec-" + CommonHospList[i].From_Date);
            //        }
            //    }
            //    else
            //    {
            //        CommonHospList[i].TempFromDate = CommonHospList[i].Modified_Date_And_Time;//Convert.ToDateTime(DateTime.Now);
            //    }
            //}
            HospitalDTOObject.HospList = CommonHospList;
            return HospitalDTOObject;
            //GenerateXml XMLObj = new GenerateXml();
            //if (updateList.Count > 0)
            //{
            //    ulong encounterid = updateList[0].Encounter_Id;
            //    List<object> lstObj = updateList.Cast<object>().ToList();
            //    XMLObj.GenerateXmlSave(lstObj, encounterid, string.Empty);
            //}

            //return GetHospitalizationHistoryByPatientIDandSatus(Human_ID, EncounterID, pagenumber, maxnumber, false);
             */
        }



        public HospitalizationDTO DeleteHospitalizationHistory(IList<HospitalizationHistory> hosplst, IList<HospitalizationHistory> hospHistory, IList<HospitalizationHistory> DeleteList,  string macAddress, ulong EncounterID, ulong HumanID)
        {
            ulong Human_ID = 0;
            // HospitalizationHistory HospHis = (HospitalizationHistory)session.GetISession().Load(typeof(HospitalizationHistory), hospHistory.Id);
            //ulong EncounterID = 0;
            //IList<HospitalizationHistory> objHospitalizationHistory = new List<HospitalizationHistory>();
            //IList<HospitalizationHistory> objHospitalizationHistorySave = null;
            //objHospitalizationHistory.Add(hospHistory);

            IList<HospitalizationHistory> UpdateList = null;
            ulong Encounter_Id = hospHistory.Count > 0 ? hospHistory[0].Encounter_Id : DeleteList.Count > 0 ? DeleteList[0].Encounter_Id : 0;
            if (hospHistory.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithTransaction(ref hospHistory, ref UpdateList, DeleteList, macAddress, true, false, Encounter_Id, string.Empty);
            }
            HospitalizationDTO HospitalDTOObject = new HospitalizationDTO();
            //SaveUpdateDeleteWithTransaction(ref hospHistory, null, DeleteList, macAddress);
            if (hospHistory != null && hospHistory.Count > 0)
                Human_ID = hospHistory[0].Human_ID;
            else if (DeleteList != null && DeleteList.Count > 0)
                Human_ID = DeleteList[0].Human_ID;
            else
                Human_ID = HumanID;
            IList<HospitalizationHistory> CommonHospList = new List<HospitalizationHistory>();
            HospitalizationHistory hospHis = new HospitalizationHistory();
            HospitalizationHistory hosHS = new HospitalizationHistory();
            foreach (HospitalizationHistory obj in hosplst)
            {
                CommonHospList.Add(obj);
            }
            ulong encounterid = 0;
            List<object> lstObj = new List<object>();
            if (DeleteList.Count > 0)
            {
                encounterid = DeleteList[0].Encounter_Id;
                foreach (HospitalizationHistory obj in DeleteList)
                {
                    var hoshist = (from lst in CommonHospList where lst.Id == obj.Id select lst);
                    hosHS = hoshist.ToList<HospitalizationHistory>()[0];
                }
                for (int i = 0; i < CommonHospList.Count; i++)
                {
                    if (CommonHospList[i].Id == hosHS.Id)
                        CommonHospList.Remove(CommonHospList[i]);
                }
                HospitalDTOObject.HospList = CommonHospList;
                
            }
            return HospitalDTOObject;
            // return GetHospitalizationHistoryByPatientIDandSatus(Human_ID, EncounterID, pagenumber, maxnumber, false);
        }



        public HospitalizationDTO HospitalHistorySaveUpdateDelete(IList<HospitalizationHistory> HosptHistory, IList<HospitalizationHistory> InsertList, IList<HospitalizationHistory> UpdateList, IList<HospitalizationHistory> DeleteList, ulong HumanId, string macAddress, ulong EncounterId)
        {
            ulong Human_ID = InsertList.Count > 0 ? InsertList[0].Human_ID : UpdateList.Count > 0 ? UpdateList[0].Human_ID : DeleteList.Count > 0 ? DeleteList[0].Human_ID : 0;
            IList<HospitalizationHistoryMaster> _insertMasterList = new List<HospitalizationHistoryMaster>();
            IList<HospitalizationHistoryMaster> _updateMasterList = new List<HospitalizationHistoryMaster>();
            IList<HospitalizationHistoryMaster> _deleteMasterList = new List<HospitalizationHistoryMaster>();
            if (InsertList.Count > 0)
                for (int i = 0; i < InsertList.Count; i++)
                {
                    HospitalizationHistoryMaster objMaster = new HospitalizationHistoryMaster();

                    if (InsertList[i].Hospitalization_History_Master_ID != 0)
                    {
                        ICriteria crit = Session.GetISession().CreateCriteria(typeof(HospitalizationHistoryMaster)).Add(Expression.Eq("Id", InsertList[i].Hospitalization_History_Master_ID));
                        objMaster = crit.List<HospitalizationHistoryMaster>()[0];
                        objMaster.Reason_For_Hospitalization = InsertList[i].Reason_For_Hospitalization;
                        objMaster.From_Date = InsertList[i].From_Date;
                        objMaster.Readmission_Date = InsertList[i].Readmission_Date;
                        objMaster.Human_ID = InsertList[i].Human_ID;
                        objMaster.Hospitalization_Notes = InsertList[i].Hospitalization_Notes;
                        objMaster.Discharge_Physician = InsertList[i].Discharge_Physician;
                        objMaster.Is_Deleted = "N";
                        objMaster.To_Date = InsertList[i].To_Date;
                        objMaster.Is_Readmitted = InsertList[i].Is_Readmitted;
                        objMaster.Version = InsertList[i].Version;
                        objMaster.Modified_By = InsertList[i].Created_By;
                        objMaster.Modified_Date_And_Time = InsertList[i].Created_Date_And_Time;
                        _updateMasterList.Add(objMaster);
                    }
                    else
                    {
                        objMaster.Reason_For_Hospitalization = InsertList[i].Reason_For_Hospitalization;
                        objMaster.From_Date = InsertList[i].From_Date;
                        objMaster.Readmission_Date = InsertList[i].Readmission_Date;
                        objMaster.Human_ID = InsertList[i].Human_ID;
                        objMaster.Hospitalization_Notes = InsertList[i].Hospitalization_Notes;
                        objMaster.Discharge_Physician = InsertList[i].Discharge_Physician;
                        objMaster.Is_Deleted = "N";
                        objMaster.To_Date = InsertList[i].To_Date;
                        objMaster.Is_Readmitted = InsertList[i].Is_Readmitted;
                        objMaster.Version = InsertList[i].Version;
                        objMaster.Created_By = InsertList[i].Created_By;
                        objMaster.Created_Date_And_Time = InsertList[i].Created_Date_And_Time;
                        _insertMasterList.Add(objMaster);
                    }

                }

            if (UpdateList.Count > 0)
                for (int i = 0; i < UpdateList.Count; i++)
                {
                    HospitalizationHistoryMaster objMaster = new HospitalizationHistoryMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(HospitalizationHistoryMaster)).Add(Expression.Eq("Id", UpdateList[i].Hospitalization_History_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<HospitalizationHistoryMaster>()[0];
                        objMaster.Reason_For_Hospitalization = UpdateList[i].Reason_For_Hospitalization;
                        objMaster.From_Date = UpdateList[i].From_Date;
                        objMaster.Readmission_Date = UpdateList[i].Readmission_Date;
                        objMaster.Human_ID = UpdateList[i].Human_ID;
                        objMaster.Hospitalization_Notes = UpdateList[i].Hospitalization_Notes;
                        objMaster.Discharge_Physician = UpdateList[i].Discharge_Physician;
                        objMaster.Is_Deleted = "N";
                        objMaster.To_Date = UpdateList[i].To_Date;
                        objMaster.Is_Readmitted = UpdateList[i].Is_Readmitted;
                        objMaster.Version = UpdateList[i].Version;
                        objMaster.Modified_By = UpdateList[i].Modified_By;
                        objMaster.Modified_Date_And_Time = UpdateList[i].Modified_Date_And_Time;
                        _updateMasterList.Add(objMaster);
                    }
                }

            if (DeleteList.Count > 0)
                for (int i = 0; i < DeleteList.Count; i++)
                {
                    HospitalizationHistoryMaster objMaster = new HospitalizationHistoryMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(HospitalizationHistoryMaster)).Add(Expression.Eq("Id", DeleteList[i].Hospitalization_History_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<HospitalizationHistoryMaster>()[0];
                        objMaster.Reason_For_Hospitalization = DeleteList[i].Reason_For_Hospitalization;
                        objMaster.From_Date = DeleteList[i].From_Date;
                        objMaster.Readmission_Date = DeleteList[i].Readmission_Date;
                        objMaster.Human_ID = DeleteList[i].Human_ID;
                        objMaster.Hospitalization_Notes = DeleteList[i].Hospitalization_Notes;
                        objMaster.Discharge_Physician = DeleteList[i].Discharge_Physician;
                        objMaster.Is_Deleted = "Y";
                        objMaster.Modified_By = DeleteList[i].Modified_By;
                        objMaster.Modified_Date_And_Time = DeleteList[i].Modified_Date_And_Time;
                        objMaster.To_Date = DeleteList[i].To_Date;
                        objMaster.Is_Readmitted = DeleteList[i].Is_Readmitted;
                        objMaster.Version = DeleteList[i].Version;
                        _updateMasterList.Add(objMaster);
                    }
                }

            if (_insertMasterList.Count > 0 || _updateMasterList.Count > 0)
            {
                HospitalizationHistoryMasterManager masterManager = new HospitalizationHistoryMasterManager();
                masterManager.HospitalHistorySaveUpdateDelete(null, _insertMasterList, _updateMasterList, null, HumanId, string.Empty);
            }

            for (int i = 0; i < _insertMasterList.Count; i++)
            {
                for (int j = 0; j < InsertList.Count; j++)
                {
                    if (InsertList[j].Hospitalization_History_Master_ID == 0)
                    {
                        InsertList[j].Hospitalization_History_Master_ID = _insertMasterList[i].Id;
                        break;
                    }
                }
            }


            ISession session = Session.GetISession();
            if (session != null && session.IsOpen)
                session.Close();

            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref UpdateList, DeleteList, macAddress, true, true, Human_ID, string.Empty);
            return null;

        }
        #endregion
    }
}
