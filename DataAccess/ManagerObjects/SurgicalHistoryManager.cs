using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Linq;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface ISurgicalHistoryManager : IManagerBase<SurgicalHistory, uint>
    {
        SurgicalHistoryDTO LoadSurgicalHistory(ulong HumanId, int PageNumber, int MaxResultSet, ulong EncounterId, bool Is_Load);
        SurgicalHistoryDTO SurgicalSaveUpdateDelete(IList<SurgicalHistory> SurgicalLst, IList<SurgicalHistory> InsertList, IList<SurgicalHistory> UpdateList, IList<SurgicalHistory> DeleteList, ulong HumanId, string macAddress, ulong EncounterId);
    }
    public partial class SurgicalHistoryManager : ManagerBase<SurgicalHistory, uint>, ISurgicalHistoryManager
    {
        #region Constructors

        public SurgicalHistoryManager()
            : base()
        {

        }
        public SurgicalHistoryManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

        public SurgicalHistoryDTO LoadSurgicalHistory(ulong HumanId, int PageNumber, int MaxResultSet, ulong EncounterId, bool Is_Load)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<SurgicalHistory> getSurgicalList = new List<SurgicalHistory>();
            SurgicalHistoryDTO SurgicalDTOObject = new SurgicalHistoryDTO();
            IList<SurgicalHistory> CommonSurgeryList = new List<SurgicalHistory>();
            //ICriteria criteria = session.GetISession().CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).AddOrder(Order.Desc("Date_Of_Surgery"));//Commented By Thiyagarajan
            //DetachedCriteria subcrit = DetachedCriteria.For<SurgicalHistory>().SetProjection(Projections.Max(Projections.Property("Encounter_Id"))).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Le("Encounter_Id", EncounterId)).AddOrder(Order.Desc("Encounter_Id"));
            //ISession mySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ICriteria criteria = iMySession.CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).Add(Subqueries.PropertyIn("Encounter_Id", subcrit));
                //ICriteria criteria = session.GetISession().CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).Add(Expression.Eq("Encounter_Id", EncounterId));
                //SurgicalDTOObject.SurgicalCount = criteria.List<SurgicalHistory>().Count;
                //IList<SurgicalHistory> tempSurgicalList = GetByCriteria(MaxResultSet, PageNumber, criteria);

                IQuery query = iMySession.GetNamedQuery("Get.Surgical.History.And.Encounter.Details");
                query.SetParameter(0, HumanId);
                IList<SurgicalHistory> lstSurg = new List<SurgicalHistory>();
                ArrayList resultList = new ArrayList(query.List());
                Dictionary<ulong, DateTime> dictEnc = new Dictionary<ulong, DateTime>();
                foreach (object objResult in resultList)
                {
                    SurgicalHistory objSurg = new SurgicalHistory();
                    object[] lstObj = (object[])objResult;
                    objSurg.Id = Convert.ToUInt32(lstObj[0]);
                    objSurg.Human_ID = Convert.ToUInt32(lstObj[1]);
                    objSurg.Surgery_Name = Convert.ToString(lstObj[2]);
                    objSurg.Date_Of_Surgery = Convert.ToString(lstObj[3]);
                    objSurg.Description = Convert.ToString(lstObj[4]);
                    objSurg.Is_Present = Convert.ToString(lstObj[5]);
                    objSurg.Created_By = Convert.ToString(lstObj[6]);
                    objSurg.Created_Date_And_Time = Convert.ToDateTime(lstObj[7].ToString());
                    objSurg.Modified_By = Convert.ToString(lstObj[8]);
                    objSurg.Modified_Date_And_Time = Convert.ToDateTime(lstObj[9]);
                    objSurg.Version = Convert.ToInt32(lstObj[10]);
                    objSurg.Encounter_Id = Convert.ToUInt32(lstObj[11]);
                    if (!dictEnc.ContainsKey(Convert.ToUInt32(lstObj[12])))
                        dictEnc.Add(Convert.ToUInt32(lstObj[12]), Convert.ToDateTime(lstObj[13]));
                    lstSurg.Add(objSurg);
                }
                lstSurg = lstSurg.GroupBy(x => x.Id).Select(x => x.First()).ToList<SurgicalHistory>();
                bool IsPrevious = false;

                if (lstSurg.Count > 0)
                    CommonSurgeryList = (from obj in lstSurg where obj.Encounter_Id == EncounterId select obj).ToList<SurgicalHistory>();
                else
                    CommonSurgeryList = new List<SurgicalHistory>();
                if (CommonSurgeryList.Count > 0)
                    IsPrevious = true;
                else
                {
                    DateTime curr_DOS = DateTime.MinValue;
                    if (dictEnc.Count != 0)
                        curr_DOS = Convert.ToDateTime(dictEnc[EncounterId]);
                    foreach (KeyValuePair<ulong, DateTime> entry in dictEnc)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(entry.Value), curr_DOS) < 0)
                        {
                            if (lstSurg.Count > 0)
                            {
                                CommonSurgeryList = (from obj in lstSurg where obj.Encounter_Id == Convert.ToUInt32(entry.Key) select obj).ToList<SurgicalHistory>();
                                IsPrevious = true;
                                break;
                            }

                        }
                    }
                    if (!IsPrevious && Is_Load)
                    {
                        //crt = session.GetISession().CreateCriteria(typeof(HospitalizationHistory)).Add(Expression.Eq("Human_ID", Human_ID)).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
                        CommonSurgeryList = lstSurg.Where(a => a.Human_ID == HumanId && a.Encounter_Id == 0).ToList<SurgicalHistory>();
                    }
                }
                SurgicalDTOObject.SurgicalCount = CommonSurgeryList.Count;
                IList<SurgicalHistory> tempSurgicalList = new List<SurgicalHistory>();
                if (CommonSurgeryList != null && CommonSurgeryList.Count > 0)
                {
                    tempSurgicalList = CommonSurgeryList.Skip((PageNumber - 1) * MaxResultSet).Take(MaxResultSet).ToList(); //GetByCriteria(MaxResultSet, PageNumber, criteria);
                    //tempSurgicalList = GetByCriteria(MaxResultSet, PageNumber, criteria);
                }
                //for (int i = 0; i < tempSurgicalList.Count; i++)
                //{
                //    if (tempSurgicalList[i].Date_Of_Surgery != string.Empty)
                //    {
                //        if (tempSurgicalList[i].Date_Of_Surgery.Split('-').Length > 1)
                //        {
                //            tempSurgicalList[i].TempDateOfSurgery = Convert.ToDateTime(tempSurgicalList[i].Date_Of_Surgery);
                //        }
                //        else
                //        {
                //            //tempSurgicalList[i].TempDateOfSurgery = Convert.ToDateTime("Dec-"+tempSurgicalList[i].Date_Of_Surgery);
                //            tempSurgicalList[i].TempDateOfSurgery = Convert.ToDateTime("Jan-" + tempSurgicalList[i].Date_Of_Surgery);
                //        }
                //    }
                //    //else
                //    //{
                //    //    tempSurgicalList[i].TempDateOfSurgery =(tempSurgicalList[i].Modified_Date_And_Time==DateTime.MinValue)?:;// Convert.ToDateTime(DateTime.Now);
                //    //}
                //}
                SurgicalDTOObject.SurgicalList = tempSurgicalList;

                ICriteria criteria = iMySession.CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", HumanId));
                SurgicalDTOObject.PatientDOB = criteria.List<Human>()[0].Birth_Date;
                iMySession.Close();
            }
            return SurgicalDTOObject;
            // commented for bug_id= 30634
            //bool IsPrevious = false;
            ////int _Count = 0;
            //ICriteria criteria = null;
            //IList<SurgicalHistory> CommonSurgicalList = new List<SurgicalHistory>();
            //IList<SurgicalHistory> getSurgicalList = new List<SurgicalHistory>();
            //SurgicalHistoryDTO SurgicalDTOObject = new SurgicalHistoryDTO();
            //// criteria = session.GetISession().CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).AddOrder(Order.Desc("Date_Of_Surgery"));//.Add(Expression.Eq("Encounter_Id", EncounterId));
            ////CommonSurgicalList = criteria.List<SurgicalHistory>();

            //if (!Is_Load)
            //{
            //    criteria = session.GetISession().CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).AddOrder(Order.Desc("Date_Of_Surgery")).Add(Expression.Eq("Encounter_Id", EncounterId));
            //    CommonSurgicalList = criteria.List<SurgicalHistory>();
            //}

            //else if (Is_Load)
            //{
            //    criteria = session.GetISession().CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).AddOrder(Order.Desc("Date_Of_Surgery"));//.Add(Expression.Eq("Encounter_Id", EncounterId));
            //    CommonSurgicalList = criteria.List<SurgicalHistory>();
            //    IList<SurgicalHistory> lst = CommonSurgicalList.ToList();

            //    if (lst.Any(a => a.Encounter_Id == EncounterId))
            //    {
            //        CommonSurgicalList = lst.Where(a => a.Encounter_Id == EncounterId).ToList<SurgicalHistory>();
            //        IsPrevious = true;

            //    }
            //    else
            //    {
            //        EncounterManager encMngr = new EncounterManager();
            //        IList<Encounter> EncLst = new List<Encounter>();
            //        EncLst = encMngr.GetEncounterUsingHumanID(HumanId);
            //        if (EncLst.Count > 0)
            //        {
            //            foreach (Encounter item in EncLst)
            //            {
            //                if (EncounterId >= item.Id)
            //                {
            //                    if (lst.Any(a => a.Encounter_Id == item.Id))
            //                    {
            //                        CommonSurgicalList = lst.Where(a => a.Encounter_Id == item.Id).ToList<SurgicalHistory>();
            //                        IsPrevious = true;
            //                        break;

            //                    }
            //                }
            //            }
            //        }
            //    }

            //    if (!IsPrevious && Is_Load)

            //    {
            //        //   criteria = session.GetISession().CreateCriteria(typeof(SurgicalHistory)).Add(Expression.Eq("Human_ID", HumanId)).AddOrder(Order.Desc("Date_Of_Surgery")).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
            //        CommonSurgicalList = lst.Where(a => a.Human_ID == HumanId && a.Encounter_Id == Convert.ToUInt16(0)).ToList<SurgicalHistory>();
            //    }

            //}

            //IList<SurgicalHistory> tempSurgicalList = new List<SurgicalHistory>();
            //if (CommonSurgicalList != null && CommonSurgicalList.Count > 0)
            //{
            //    tempSurgicalList = CommonSurgicalList.Skip((PageNumber - 1) * MaxResultSet).Take(MaxResultSet).ToList(); //GetByCriteria(MaxResultSet, PageNumber, criteria);
            //    //tempSurgicalList=GetByCriteria(MaxResultSet, PageNumber, criteria);
            //}

            //for (int i = 0; i < tempSurgicalList.Count; i++)
            //{
            //    if (tempSurgicalList[i].Date_Of_Surgery != string.Empty)
            //    {
            //        if (tempSurgicalList[i].Date_Of_Surgery.Split('-').Length > 1)
            //        {
            //            tempSurgicalList[i].TempDateOfSurgery = Convert.ToDateTime(tempSurgicalList[i].Date_Of_Surgery);
            //        }
            //        else
            //        {
            //            tempSurgicalList[i].TempDateOfSurgery = Convert.ToDateTime("Dec-" + tempSurgicalList[i].Date_Of_Surgery);
            //        }
            //    }
            //    else
            //    {
            //        tempSurgicalList[i].TempDateOfSurgery = Convert.ToDateTime(DateTime.Now);
            //    }
            //}
            //SurgicalDTOObject.SurgicalList = tempSurgicalList;
            //SurgicalDTOObject.SurgicalCount = CommonSurgicalList.Count;
            ////criteria = session.GetISession().CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", HumanId));
            ////SurgicalDTOObject.PatientDOB = criteria.List<Human>()[0].Birth_Date;
            //return SurgicalDTOObject;

        }


        
        public SurgicalHistoryDTO SurgicalSaveUpdateDelete(IList<SurgicalHistory> SurgicalLst, IList<SurgicalHistory> InsertList, IList<SurgicalHistory> UpdateList, IList<SurgicalHistory> DeleteList, ulong HumanId, string macAddress, ulong EncounterId)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<SurgicalHistoryMaster> _insertMasterList = new List<SurgicalHistoryMaster>();
            IList<SurgicalHistoryMaster> _updateMasterList = new List<SurgicalHistoryMaster>();
            IList<SurgicalHistoryMaster> _deleteMasterList = new List<SurgicalHistoryMaster>();
            if (InsertList.Count > 0)
                for (int i = 0; i < InsertList.Count; i++)
                {
                    SurgicalHistoryMaster objMaster = new SurgicalHistoryMaster();

                    if (InsertList[i].Surgical_History_Master_ID != 0)
                    {
                        ICriteria crit = Session.GetISession().CreateCriteria(typeof(SurgicalHistoryMaster)).Add(Expression.Eq("Id", InsertList[i].Surgical_History_Master_ID));
                        objMaster = crit.List<SurgicalHistoryMaster>()[0];
                        objMaster.Surgery_Name = InsertList[i].Surgery_Name;
                        objMaster.Is_Deleted = "N";
                        objMaster.Human_ID = InsertList[i].Human_ID;
                        objMaster.Date_Of_Surgery = InsertList[i].Date_Of_Surgery;
                        objMaster.Description = InsertList[i].Description;
                        objMaster.Version = InsertList[i].Version;
                        objMaster.Modified_By = InsertList[i].Created_By;
                        objMaster.Modified_Date_And_Time = InsertList[i].Created_Date_And_Time;
                        _updateMasterList.Add(objMaster);
                    }
                    else
                    {
                        objMaster.Surgery_Name = InsertList[i].Surgery_Name;
                        objMaster.Is_Deleted = "N";
                        objMaster.Human_ID = InsertList[i].Human_ID;
                        objMaster.Date_Of_Surgery = InsertList[i].Date_Of_Surgery;
                        objMaster.Description = InsertList[i].Description;
                        objMaster.Version = InsertList[i].Version;
                        objMaster.Created_By = InsertList[i].Created_By;
                        objMaster.Created_Date_And_Time = InsertList[i].Created_Date_And_Time;
                        _insertMasterList.Add(objMaster);
                    }

                }

            if (UpdateList.Count > 0)
                for (int i = 0; i < UpdateList.Count; i++)
                {
                    SurgicalHistoryMaster objMaster = new SurgicalHistoryMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(SurgicalHistoryMaster)).Add(Expression.Eq("Id", UpdateList[i].Surgical_History_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<SurgicalHistoryMaster>()[0];
                        objMaster.Surgery_Name = UpdateList[i].Surgery_Name;
                        objMaster.Is_Deleted = "N";
                        objMaster.Human_ID = UpdateList[i].Human_ID;
                        objMaster.Modified_By = UpdateList[i].Modified_By;
                        objMaster.Modified_Date_And_Time = UpdateList[i].Modified_Date_And_Time;
                        objMaster.Date_Of_Surgery = UpdateList[i].Date_Of_Surgery;
                        objMaster.Description = UpdateList[i].Description;
                        objMaster.Version = UpdateList[i].Version;
                        _updateMasterList.Add(objMaster);
                    }
                }

            if (DeleteList.Count > 0)
                for (int i = 0; i < DeleteList.Count; i++)
                {
                    SurgicalHistoryMaster objMaster = new SurgicalHistoryMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(SurgicalHistoryMaster)).Add(Expression.Eq("Id", DeleteList[i].Surgical_History_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<SurgicalHistoryMaster>()[0];
                        objMaster.Surgery_Name = DeleteList[i].Surgery_Name;
                        objMaster.Is_Deleted = "Y";
                        objMaster.Human_ID = DeleteList[i].Human_ID;
                        objMaster.Created_By = DeleteList[i].Modified_By;
                        objMaster.Created_Date_And_Time = DeleteList[i].Modified_Date_And_Time;
                        objMaster.Date_Of_Surgery = DeleteList[i].Date_Of_Surgery;
                        objMaster.Description = DeleteList[i].Description;
                        objMaster.Version = DeleteList[i].Version;
                        _updateMasterList.Add(objMaster);
                    }
                }
            if (_insertMasterList.Count > 0 || _updateMasterList.Count > 0)
            {
                SurgicalHistoryMasterManager masterManager = new SurgicalHistoryMasterManager();
                masterManager.SurgicalSaveUpdateDelete(null, _insertMasterList, _updateMasterList, null, HumanId, string.Empty);
            }

            for (int i = 0; i < _insertMasterList.Count; i++)
            {
                for (int j = 0; j < InsertList.Count; j++)
                {
                    if (InsertList[j].Surgical_History_Master_ID == 0)
                    {
                        InsertList[j].Surgical_History_Master_ID = _insertMasterList[i].Id;
                        break;
                    }
                }
            }
            ISession session = Session.GetISession();
            if (session != null && session.IsOpen)
                session.Close();


            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref UpdateList, DeleteList, macAddress, true, true, HumanId, string.Empty);
            return null;
        }

        #endregion
    }
}
