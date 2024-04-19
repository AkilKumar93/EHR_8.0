using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IBlockdaysManager : IManagerBase<Blockdays, ulong>
    {
        ulong InsertBlockDaysList(IList<Blockdays> blockDayObjList, string MACAddress);
        IList<Blockdays> GetBlockedDaysByBlockId(ulong BlockId);
        ulong UpdateBlockDays(Blockdays blockDayObj, string MACAddress, DateTime dtPreviousFromDate);
        FillBlockDays GetBlockDaysDetails(ulong PhyId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult);
        FillBlockDays DeleteBlockDays(Blockdays blockDayObj, ulong PhyId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult, string MACAddress);
        void DeleteUsingFromAndToDates(string FacilityName, ulong PhyId, string BlockType, DateTime FromDate, DateTime ToDate, string Day, IList<Blockdays> blockDayObjList, string MACAddress);
        bool GetBlockStatus(ulong PhyId, string FacilityName, DateTime Blockdate, string Time, int Duration);
        string GetBlockDays(ulong PhyId, string FacilityName, DateTime Blockdate, string Time, int Duration);
        IList<Blockdays> GetBlockDaysUsingPhyFacApptDt(ulong[] PhyId, string[] FacilityName, DateTime ApptDt_Start, DateTime ApptDt_End, string sView);
        ulong GetMaxGroupID();
        ulong UpdateRecursiveBlockdays(ulong GroupID, ulong PhyId, IList<Blockdays> list, string MACAddress);
        ulong UpdateRecursiveBlockdaysUsingTechID(ulong GroupID, ulong techID, IList<Blockdays> list, string MACAddress);
        FillBlockDays DeleteUsingGroupID(ulong GruopID, string UserName, DateTime currentDtTime, string MACAddress, ulong PhyId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult);
        IList<Blockdays> GetBlockDaysUsingPhyFacApptDtbyFacility(ulong PhyId, string[] FacilityName, DateTime ApptDt);
        ArrayList GetStartAndEndTimeFromFacilityLibrary(string FacilityName);
        IList<Blockdays> GetBlockDaysByPhysicianID(ulong PhyId, string FacilityName, DateTime ApptDt, double AddDate);
        IList<Blockdays> GetBlockDaysDetByBlockID(string[] BlockDaysId);
        void SaveUpdateBlockDays(IList<Blockdays> SaveList, IList<Blockdays> UpdateList, IList<Blockdays> Deletelist, string MACAddress);
        IList<Blockdays> GetBlockDaysByGroupID(ulong BlockDaysId);//, ulong sPhysicianID);
        FillBlockDays DeleteUsingGroupIDMechID(ulong GroupID, string UserName, DateTime currentDtTime, string MACAddress, ulong MecID, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult);
        IList<Blockdays> DeleteUsingBlockID(ulong BlockID, ulong GroupID);
        IList<Blockdays> UpdateUsingBlockID(ulong BlockID, ulong GroupID);

    }
    public partial class BlockdaysManager : ManagerBase<Blockdays, ulong>, IBlockdaysManager
    {
        #region Constructors

        public BlockdaysManager()
            : base()
        {

        }
        public BlockdaysManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region CRUD


        public ulong InsertBlockDaysList(IList<Blockdays> blockDayObjList, string MACAddress)
        {
            //SaveUpdateDeleteWithTransaction(ref blockDayObjList, null, null, MACAddress);
            IList<Blockdays> blockDayObjListnull = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref blockDayObjList, ref blockDayObjListnull, null, MACAddress, false, false, 0, string.Empty);
            return GetMaxGroupID();
        }

        public ulong UpdateBlockDays(Blockdays blockDayObj, string MACAddress,DateTime dtPreviousFromDate)
        {
            IList<Blockdays> savelis = null;
            IList<Blockdays> obList = new List<Blockdays>();
            obList.Add(blockDayObj);
            //SaveUpdateDeleteWithTransaction(ref savelis, obList, null, MACAddress);
            //SaveUpdateDelete_DBAndXML_WithTransaction(ref savelis, ref obList, null, MACAddress, false, false, 0, string.Empty);
                IList<Blockdays> ilstBalanceblockdays = new List<Blockdays>();
                using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                {
                    //ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Id", BlockID));
                    IList<Blockdays> UpdateList1 = new List<Blockdays>();
                    UpdateList1.Add(blockDayObj);
                    IList<Blockdays> saveList = null;
                    IList<Blockdays> delList = null;
                    IList<Blockdays> UpdateList = new List<Blockdays>();
                    if (UpdateList1 != null && UpdateList1.Count > 0)
                    {
                        ulong groupIDMax = GetMaxGroupID();
                        ulong GroupID = UpdateList1[0].Blockdays_Group_ID;
                        ulong BlockID = UpdateList1[0].Id;
                        IList<Blockdays> imaginarylst = GetBlockDaysByGroupID(GroupID);
                        foreach (Blockdays obj in UpdateList1)
                        {
                            obj.Blockdays_Group_ID = groupIDMax + 1;
                            UpdateList.Add(obj);
                        }
                        if (imaginarylst != null && imaginarylst.Count > 1)
                        {
                            foreach (Blockdays obj in imaginarylst)
                            {
                                if (obj.Id != BlockID)
                                {
                                    if (obj.Id < BlockID)
                                    {
                                        obj.To_Date_Choosen = dtPreviousFromDate.AddDays(-1);
                                    }
                                    else
                                    {
                                        obj.Blockdays_Group_ID = groupIDMax + 2;
                                    }
                                    UpdateList.Add(obj);
                                }
                            }
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref UpdateList, delList, string.Empty, false, false, 0, string.Empty);
                        }
                        else
                        {
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref savelis, ref obList, null, MACAddress, false, false, 0, string.Empty);
                        }
                    }
                    iMySession.Close();
                }
         
            return GetMaxGroupID();
        }


        public FillBlockDays DeleteBlockDays(Blockdays blockDayObj, ulong PhyId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult, string MACAddress)
        {
            IList<Blockdays> saveList = null;
            IList<Blockdays> obList = new List<Blockdays>();
            obList.Add(blockDayObj);
            IList<Blockdays> saveListnull = null;
            //SaveUpdateDeleteWithTransaction(ref saveList, null, obList, MACAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref saveListnull, obList, MACAddress, false, false, 0, string.Empty);
            return GetBlockDaysDetails(PhyId, FacilityName, dtBasedOnShowAll, pgNumber, MaxResult);
        }

        public void DeleteUsingFromAndToDates(string FacilityName, ulong PhyId, string BlockType, DateTime FromDate, DateTime ToDate, string Day, IList<Blockdays> blockDayObjList, string MACAddress)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.CreateQuery("delete from Blockdays where Facility_Name='" + FacilityName
                     + "' and Physician_ID=" + PhyId + " and Block_Type='" + BlockType + "' and From_Date_Choosen='"
                     + FromDate.ToString("yyyy-MM-dd") + "' and To_Date_Choosen='" + ToDate.ToString("yyyy-MM-dd") + "' and Day_Choosen='" + Day + "'");
                query.ExecuteUpdate();

                InsertBlockDaysList(blockDayObjList, MACAddress);
                iMySession.Close();
            }

        }



        #endregion

        #region GetMethods

        public ulong GetMaxGroupID()
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays))
                    .SetProjection(Projections.Max("Blockdays_Group_ID"));
                if (crit.List<object>().Count > 0)
                {
                    return Convert.ToUInt64(crit.List<object>()[0]);
                }
                return 0;
            }
        }

        public IList<Blockdays> GetBlockedDaysByBlockId(ulong BlockId)
        {
            IList<Blockdays> ilstBlockdays = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Id", BlockId));
                ilstBlockdays = criteria.List<Blockdays>();
                iMySession.Close();
            }
            return ilstBlockdays;
        }
        public FillBlockDays GetBlockDaysDetails(ulong PhyId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult)
        {
            //PhyId = 100;
            //FacilityName = "1904 N OG AVE";
            //pgNumber = 1;
            //MaxResult = 25;
            FillBlockDays objFillBlock = new FillBlockDays();
            ArrayList arrList = new ArrayList();
            Blockdays objBlk = new Blockdays();
            IList<Blockdays> blkList = new List<Blockdays>();
            string PhysicianID = PhyId.ToString();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.BlockDaysDetails");
                IQuery queryCount = iMySession.GetNamedQuery("Get.BlockDaysDetails.Count");
                //ICriteria crit, critCount;
                if (PhyId != 0)
                {
                    query.SetString(0, PhysicianID);
                    query.SetString(1, FacilityName);
                    query.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                    queryCount.SetString(0, PhysicianID);
                    queryCount.SetString(1, FacilityName);
                    queryCount.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                }
                else
                {
                    query.SetString(0, "%");
                    query.SetString(1, FacilityName);
                    query.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                    queryCount.SetString(0, "%");
                    queryCount.SetString(1, FacilityName);
                    queryCount.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                }
                query.SetInt32(3, (pgNumber - 1) * MaxResult);
                query.SetInt32(4, MaxResult);
                arrList = new ArrayList(queryCount.List());
                if (arrList != null && arrList.Count > 0)
                {
                    objFillBlock.BlockDaysCount = Convert.ToInt16(arrList[0]);
                }
                arrList = new ArrayList(query.List());
                if (arrList != null && arrList.Count > 0)
                {
                    for (int i = 0; i < arrList.Count; i++)
                    {
                        object[] oj = (object[])arrList[i];
                        objBlk = new Blockdays();
                        objBlk.Id = Convert.ToUInt64(oj[0]);
                        objBlk.Physician_ID = Convert.ToUInt64(oj[1]);
                        objBlk.Facility_Name = oj[2].ToString();
                        objBlk.From_Time = oj[3].ToString();
                        objBlk.To_Time = oj[4].ToString();
                        objBlk.From_Date_Choosen = Convert.ToDateTime(oj[5].ToString());
                        objBlk.To_Date_Choosen = Convert.ToDateTime(oj[6].ToString());
                        objBlk.Reason = oj[7].ToString();
                        objBlk.Day_Choosen = oj[8].ToString();
                        objBlk.Block_Type = oj[9].ToString();
                        objBlk.Blockdays_Group_ID = Convert.ToUInt64(oj[10]);
                        objBlk.Block_Date = Convert.ToDateTime(oj[11].ToString());
                        //Here Created_By as a BlockDaysId for String Datatype
                        objBlk.Created_By = Convert.ToString(oj[12].ToString());
                        objBlk.Is_Alternate_Weeks = oj[13].ToString();
                        objBlk.Is_Alternate_Months = oj[14].ToString();
                        blkList.Add(objBlk);
                    }
                }
                objFillBlock.BlockDays = blkList;
                iMySession.Close();
            }
            return objFillBlock;
        }

        public FillBlockDays GetBlockDaysDetailsUsingMechID(ulong TechId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult)
        {
            //PhyId = 100;
            //FacilityName = "1904 N OG AVE";
            //pgNumber = 1;
            //MaxResult = 25;
            FillBlockDays objFillBlock = new FillBlockDays();
            ArrayList arrList = new ArrayList();
            Blockdays objBlk = new Blockdays();
            IList<Blockdays> blkList = new List<Blockdays>();
            string TechMechID = TechId.ToString();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.BlockDaysDetailsTechID");
                IQuery queryCount = iMySession.GetNamedQuery("Get.BlockDaysDetailsTechID.Count");
                //ICriteria crit, critCount;
                if (TechId != 0)
                {
                    query.SetString(0, TechMechID);
                    query.SetString(1, FacilityName);
                    query.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                    queryCount.SetString(0, TechMechID);
                    queryCount.SetString(1, FacilityName);
                    queryCount.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                }
                else
                {
                    query.SetString(0, "%");
                    query.SetString(1, FacilityName);
                    query.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                    queryCount.SetString(0, "%");
                    queryCount.SetString(1, FacilityName);
                    queryCount.SetString(2, dtBasedOnShowAll.ToString("yyyy-MM-dd"));
                }
                query.SetInt32(3, (pgNumber - 1) * MaxResult);
                query.SetInt32(4, MaxResult);
                arrList = new ArrayList(queryCount.List());
                if (arrList != null && arrList.Count > 0)
                {
                    objFillBlock.BlockDaysCount = Convert.ToInt16(arrList[0]);
                }
                arrList = new ArrayList(query.List());
                if (arrList != null && arrList.Count > 0)
                {
                    for (int i = 0; i < arrList.Count; i++)
                    {
                        object[] oj = (object[])arrList[i];
                        objBlk = new Blockdays();
                        objBlk.Id = Convert.ToUInt64(oj[0]);
                        objBlk.Machine_Technician_Library_ID = Convert.ToUInt64(oj[1]);
                        objBlk.Facility_Name = oj[2].ToString();
                        objBlk.From_Time = oj[3].ToString();
                        objBlk.To_Time = oj[4].ToString();
                        objBlk.From_Date_Choosen = Convert.ToDateTime(oj[5].ToString());
                        objBlk.To_Date_Choosen = Convert.ToDateTime(oj[6].ToString());
                        objBlk.Reason = oj[7].ToString();
                        objBlk.Day_Choosen = oj[8].ToString();
                        objBlk.Block_Type = oj[9].ToString();
                        objBlk.Blockdays_Group_ID = Convert.ToUInt64(oj[10]);
                        objBlk.Block_Date = Convert.ToDateTime(oj[11].ToString());
                        //Here Created_By as a BlockDaysId for String Datatype
                        objBlk.Created_By = Convert.ToString(oj[12].ToString());
                        objBlk.Is_Alternate_Weeks = oj[13].ToString();
                        objBlk.Is_Alternate_Months = oj[14].ToString();
                        blkList.Add(objBlk);
                    }
                }
                objFillBlock.BlockDays = blkList;
                iMySession.Close();
            }
            return objFillBlock;
        }

        public bool GetBlockStatus(ulong PhyId, string FacilityName, DateTime Blockdate, string Time, int Duration)
        {
            DateTime endTime;
            string sFinalEndTime = string.Empty;
            string[] split = Time.Split(':');
            Time = split[0] + ":" + split[1];
            if (split.Length > 0)
            {
                endTime = new DateTime(0001, 1, 1, Convert.ToInt16(split[0]), Convert.ToInt16(split[1]), 0);
                endTime = endTime.AddMinutes(Convert.ToDouble(Duration));
                string[] strEndTime = endTime.TimeOfDay.ToString().Split(':');
                if (strEndTime.Length > 0)
                {
                    sFinalEndTime = strEndTime[0] + ":" + strEndTime[1];
                }

            }
            ArrayList arrList = new ArrayList();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.BlockDays.GetBlockStatus")
                                   .SetString(0, PhyId.ToString())
                                   .SetString(1, FacilityName)
                                   .SetString(2, Blockdate.ToString("yyyy-MM-dd"))
                                   .SetString(3, Time)
                                   .SetString(4, sFinalEndTime);

                arrList = new ArrayList(query.List());
                iMySession.Close();
            }
            if (arrList.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public string GetBlockDays(ulong PhyId, string FacilityName, DateTime Blockdate, string Time, int Duration)
        {
            DateTime endTime;
            string sFinalEndTime = string.Empty;
            string[] split = Time.Split(':');
            if (split.Length > 0)
            {
                endTime = new DateTime(0001, 1, 1, Convert.ToInt16(split[0]), Convert.ToInt16(split[1]), 0);
                endTime = endTime.AddMinutes(Convert.ToDouble(Duration));
                string[] strEndTime = endTime.TimeOfDay.ToString().Split(':');
                if (strEndTime.Length > 0)
                {
                    sFinalEndTime = strEndTime[0] + ":" + strEndTime[1];
                }

            }
            ArrayList arrList = new ArrayList();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = session.GetISession().GetNamedQuery("Get.BlockDays.GetBlockdays")
                                   .SetString(0, PhyId.ToString())
                                   .SetString(1, FacilityName)
                                   .SetString(2, Blockdate.ToString("yyyy-MM-dd"))
                                   .SetString(3, Time)
                                   .SetString(4, sFinalEndTime);

                arrList = new ArrayList(query.List());
                iMySession.Close();
            }
            string sBlockType = string.Empty;
            if (arrList.Count > 0)
            {
                for (int bDCount = 0; bDCount < arrList.Count; bDCount++)
                {
                    if (arrList[bDCount].ToString().Trim() != "RECURSIVE" || arrList[bDCount].ToString().Trim() != "NONRECURSIVE")
                    {
                        sBlockType = arrList[bDCount].ToString();
                    }
                    else
                    {
                        sBlockType = arrList[bDCount].ToString();
                    }
                }


            }
            return sBlockType;
        }


        public IList<Blockdays> GetBlockDaysUsingPhyFacApptDt(ulong[] PhyId, string[] FacilityName, DateTime ApptDt_Start, DateTime ApptDt_End, string sView)
        {
            //ICriteria crit = session.GetISession().CreateCriteria(typeof(Blockdays)).Add(Expression.In("Physician_ID", PhyId))
            //    .Add(Expression.Eq("Facility_Name", FacilityName)).Add(Expression.Eq("Block_Date", ApptDt));
            //return crit.List<Blockdays>();

            //Changed by Selvaraman
            ArrayList aryBlockList = null;
            IList<Blockdays> blockList = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (sView == "SwitchToWeekView")
                {
                    IQuery query1 = iMySession.GetNamedQuery("Get.BlockDays.DateandPhyByWeekandMonth");
                    query1.SetString(0, ApptDt_Start.AddDays(((int)DayOfWeek.Sunday) - ((int)ApptDt_Start.DayOfWeek)).ToString("yyyy-MM-dd HH:mm:ss"));
                    query1.SetString(1, ApptDt_End.AddDays(((int)DayOfWeek.Saturday) - ((int)ApptDt_Start.DayOfWeek)).ToString("yyyy-MM-dd HH:mm:ss"));
                    query1.SetParameterList("FacList", FacilityName);
                    query1.SetParameterList("PhyList", PhyId);
                    aryBlockList = new ArrayList(query1.List());
                }
                else if (sView == "SwitchToMonthView")
                {
                    IQuery query1 = iMySession.GetNamedQuery("Get.BlockDays.DateandPhyByWeekandMonth");
                    DateTime StartOfMonth = new DateTime(ApptDt_Start.Year, ApptDt_Start.Month, 1, ApptDt_Start.Hour, ApptDt_Start.Minute, ApptDt_Start.Second);
                    DateTime EndOfMonth = StartOfMonth.AddMonths(1).AddDays(-1);
                    query1.SetString(0, StartOfMonth.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss"));
                    query1.SetString(1, EndOfMonth.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss"));
                    query1.SetParameterList("FacList", FacilityName);
                    query1.SetParameterList("PhyList", PhyId);
                    aryBlockList = new ArrayList(query1.List());
                }
                else
                {
                    IQuery query = iMySession.GetNamedQuery("Get.BlockDays.DateandPhy");
                    query.SetString(0, ApptDt_Start.ToString("yyyy-MM-dd"));
                    query.SetParameterList("FacList", FacilityName);
                    query.SetParameterList("PhyList", PhyId);
                    aryBlockList = new ArrayList(query.List());
                }

                Blockdays block = null;
                if (aryBlockList != null)
                {
                    for (int i = 0; i < aryBlockList.Count; i++)
                    {
                        object[] oj = (object[])aryBlockList[i];
                        block = new Blockdays();
                        block.Id = Convert.ToUInt64(oj[0]);
                        block.Physician_ID = Convert.ToUInt64(oj[1]);
                        block.Facility_Name = oj[2].ToString();
                        block.Block_Date = Convert.ToDateTime(oj[3]);
                        block.From_Time = oj[4].ToString();
                        block.To_Time = oj[5].ToString();
                        block.From_Date_Choosen = Convert.ToDateTime(oj[6].ToString());
                        block.To_Date_Choosen = Convert.ToDateTime(oj[7].ToString());
                        block.Reason = oj[8].ToString();
                        block.Day_Choosen = oj[9].ToString();
                        block.Block_Type = oj[10].ToString();

                        blockList.Add(block);
                    }
                }
                iMySession.Close();
            }
            return blockList;
        }


        public ulong UpdateRecursiveBlockdays(ulong GroupID, ulong PhyId, IList<Blockdays> list, string MACAddress)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Physician_ID", PhyId)).Add(Expression.Eq("Blockdays_Group_ID", GroupID));
                IList<Blockdays> oldList = crit.List<Blockdays>();
                //SaveUpdateDeleteWithTransaction(ref list, null, oldList, MACAddress);
                IList<Blockdays> oldListnull = null;
                SaveUpdateDelete_DBAndXML_WithTransaction(ref list, ref oldListnull, oldList, MACAddress, false, false, 0, string.Empty);
                iMySession.Close();
                return GetMaxGroupID();
            }
        }

        public ulong UpdateRecursiveBlockdaysUsingTechID(ulong GroupID, ulong techID, IList<Blockdays> list, string MACAddress)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Machine_Technician_Library_ID", techID)).Add(Expression.Eq("Blockdays_Group_ID", GroupID));
                IList<Blockdays> oldList = crit.List<Blockdays>();
                //SaveUpdateDeleteWithTransaction(ref list, null, oldList, MACAddress);
                IList<Blockdays> oldListnull = null;
                SaveUpdateDelete_DBAndXML_WithTransaction(ref list, ref oldListnull, oldList, MACAddress, false, false, 0, string.Empty);
                iMySession.Close();
                return GetMaxGroupID();
            }
        }

        public FillBlockDays DeleteUsingGroupID(ulong GroupID, string UserName, DateTime currentDtTime, string MACAddress, ulong PhyId, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Blockdays_Group_ID", GroupID)).Add(Expression.Eq("Physician_ID", PhyId));
                IList<Blockdays> delList = crit.List<Blockdays>();
                IList<Blockdays> saveList = null;
                if (delList != null && delList.Count > 0)
                {
                    foreach (Blockdays obj in delList)
                    {
                        obj.Modified_By = UserName;
                        obj.Modified_Date_And_Time = currentDtTime;
                    }
                    //SaveUpdateDeleteWithTransaction(ref saveList, null, delList, MACAddress);
                    IList<Blockdays> oldListnull = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref oldListnull, delList, MACAddress, false, false, 0, string.Empty);
                }
                iMySession.Close();
            }

            return GetBlockDaysDetails(PhyId, FacilityName, dtBasedOnShowAll, pgNumber, MaxResult);
        }
        public FillBlockDays DeleteUsingGroupIDMechID(ulong GroupID, string UserName, DateTime currentDtTime, string MACAddress, ulong MecID, string FacilityName, DateTime dtBasedOnShowAll, int pgNumber, int MaxResult)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Blockdays_Group_ID", GroupID)).Add(Expression.Eq("Machine_Technician_Library_ID", MecID));
                IList<Blockdays> delList = crit.List<Blockdays>();
                IList<Blockdays> saveList = null;
                if (delList != null && delList.Count > 0)
                {
                    foreach (Blockdays obj in delList)
                    {
                        obj.Modified_By = UserName;
                        obj.Modified_Date_And_Time = currentDtTime;
                    }
                    //SaveUpdateDeleteWithTransaction(ref saveList, null, delList, MACAddress);
                    IList<Blockdays> oldListnull = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref oldListnull, delList, MACAddress, false, false, 0, string.Empty);
                }
                iMySession.Close();
            }

            return GetBlockDaysDetailsUsingMechID(MecID, FacilityName, dtBasedOnShowAll, pgNumber, MaxResult);
        }

        public IList<Blockdays> GetBlockDaysUsingPhyFacApptDtbyFacility(ulong PhyId, string[] FacilityName, DateTime ApptDt)
        {
            IList<Blockdays> blockList = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.BlockDays.DateandPhybyFAcility");
                query.SetString(0, ApptDt.AddDays(-31).ToString("yyyy-MM-dd"));
                query.SetString(1, ApptDt.AddDays(31).ToString("yyyy-MM-dd"));
                query.SetParameterList("FacList", FacilityName);
                query.SetString(2, PhyId.ToString());

                ArrayList aryBlockList = null;

                Blockdays block = null;
                aryBlockList = new ArrayList(query.List());

                if (aryBlockList != null)
                {
                    for (int i = 0; i < aryBlockList.Count; i++)
                    {
                        object[] oj = (object[])aryBlockList[i];
                        block = new Blockdays();
                        block.Id = Convert.ToUInt64(oj[0]);
                        block.Physician_ID = Convert.ToUInt64(oj[1]);
                        block.Facility_Name = oj[2].ToString();
                        block.Block_Date = Convert.ToDateTime(oj[3]);
                        block.From_Time = oj[4].ToString();
                        block.To_Time = oj[5].ToString();
                        block.From_Date_Choosen = Convert.ToDateTime(oj[6].ToString());
                        block.To_Date_Choosen = Convert.ToDateTime(oj[7].ToString());
                        block.Reason = oj[8].ToString();
                        block.Day_Choosen = oj[9].ToString();
                        block.Block_Type = oj[10].ToString();

                        blockList.Add(block);
                    }
                }
                iMySession.Close();
            }
            return blockList;

        }
        public IList<Blockdays> GetBlockDaysByPhysicianID(ulong PhyId, string FacilityName, DateTime StartDate, double AddDate)
        {
            IList<Blockdays> ilstBlockdays = new List<Blockdays>();
            string sDate = StartDate.ToString("yyyy-MM-dd");
            string sAddDate = StartDate.AddDays(AddDate).ToString("yyyy-MM-dd");
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery query = iMySession.CreateSQLQuery("SELECT b.* FROM block_days as b where b.Physician_ID='" + PhyId + "' and  b.Facility_Name='" + FacilityName + "' and  b.Block_Date >='" + sDate + "' and  b.Block_Date<='" + sAddDate + "'").AddEntity("b", typeof(Blockdays));
                ilstBlockdays = query.List<Blockdays>();
                iMySession.Close();
            }
            return ilstBlockdays;
        }

        #region GetStartAndEndTimeFromFacilityLibraryByFacilityName
        public ArrayList GetStartAndEndTimeFromFacilityLibrary(string FacilityName)
        {
            ArrayList TimeList = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.StartAndEndTime.From.FacilityLibrary");
                query.SetString(0, FacilityName);

                TimeList = new ArrayList(query.List());
                iMySession.Close();
            }
            return TimeList;
        }
        #endregion

        public IList<Blockdays> GetBlockDaysDetByBlockID(string[] BlockDaysId)
        {
            IList<Blockdays> ilstBlockdays = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria BlockCrt = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.In("Id", BlockDaysId));
                ilstBlockdays = BlockCrt.List<Blockdays>();
                iMySession.Close();
            }
            return ilstBlockdays;
        }
        int iTryCount;
        public void SaveUpdateBlockDays(IList<Blockdays> SaveList, IList<Blockdays> UpdateList, IList<Blockdays> Deletelist, string MACAddress)
        {
            BlockdaysManager BlockMngr = new BlockdaysManager();
            GenerateXml XMLObj = new GenerateXml();
            iTryCount = 0;
        TryAgain1:
            int iResult = 0;
            ISession MySession = Session.GetISession();
            ITransaction trans = null;

            try
            {
                trans = MySession.BeginTransaction();
                if (SaveList.Count > 0)
                {

                    //iResult = BlockMngr.SaveUpdateDeleteWithoutTransaction(ref SaveList, null, null, MySession, MACAddress);
                    IList<Blockdays> UpdateListnull = null;
                    iResult = BlockMngr.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveList, ref UpdateListnull, null, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain1;
                        }
                        else
                        {
                            trans.Rollback();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                }
                if (UpdateList.Count > 0)
                {
                    SaveList = null;
                    //iResult = BlockMngr.SaveUpdateDeleteWithoutTransaction(ref SaveList, UpdateList, null, MySession, MACAddress);
                    //IList<Blockdays> UpdateListnull = null;
                    iResult = BlockMngr.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveList, ref UpdateList, null, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain1;
                        }
                        else
                        {
                            trans.Rollback();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                }
                if (Deletelist.Count > 0)
                {
                    SaveList = null;

                    //iResult = BlockMngr.SaveUpdateDeleteWithoutTransaction(ref SaveList, null, Deletelist, MySession, MACAddress);
                    IList<Blockdays> UpdateListnull = null;
                    iResult = BlockMngr.SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveList, ref UpdateListnull, Deletelist, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain1;
                        }
                        else
                        {
                            trans.Rollback();
                            throw new Exception("Deadlock occurred. Transaction failed.");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        throw new Exception("Exception occurred. Transaction failed.");
                    }
                }
                //MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                //CAP-1942
                throw new Exception(ex.Message,ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //CAP-1942
                throw new Exception(e.Message, e);
            }
            finally
            {
                MySession.Close();
            }
        }
        #endregion


        public IList<Blockdays> GetBlockDaysByGroupID(ulong BlockDaysGroupId)//, ulong sPhysicianID)
        {
            IList<Blockdays> ilstBlockdays = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria BlockCrt = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Blockdays_Group_ID", BlockDaysGroupId));//.Add(Expression.Eq("Physician_ID", sPhysicianID));
                ilstBlockdays = BlockCrt.List<Blockdays>();
                iMySession.Close();
            }
            return ilstBlockdays;
        }

        public IList<Blockdays> DeleteUsingBlockID(ulong BlockID, ulong GroupID)//, IList<Blockdays> imaginarylst)
        {
            IList<Blockdays> ilstBalanceblockdays = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Id", BlockID));
                IList<Blockdays> delList = crit.List<Blockdays>();
                IList<Blockdays> saveList = null;
                IList<Blockdays> UpdateList = new List<Blockdays>();
                if (delList != null && delList.Count > 0)
                {
                    ulong groupIDMax = GetMaxGroupID();
                    IList<Blockdays> imaginarylst = GetBlockDaysByGroupID(GroupID);
                    foreach (Blockdays obj in imaginarylst)
                    {
                        if (obj.Id != BlockID)
                        {
                            if (obj.Id < BlockID)
                            {
                                obj.To_Date_Choosen = delList[0].From_Date_Choosen.AddDays(-1);
                            }
                            else
                            {
                                obj.Blockdays_Group_ID = groupIDMax + 1;
                            }
                            UpdateList.Add(obj);
                        }
                    }

                    // IList<Blockdays> oldListnull = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref UpdateList, delList, string.Empty, false, false, 0, string.Empty);
                }
                iMySession.Close();
            }
            // ilstBalanceblockdays=GetBlockDaysByGroupID(BlockDaysGroupId,sPhysicianID);
            return ilstBalanceblockdays;
        }
        public IList<Blockdays> UpdateUsingBlockID(ulong BlockID, ulong GroupID)
        {
            IList<Blockdays> ilstBalanceblockdays = new List<Blockdays>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Blockdays)).Add(Expression.Eq("Id", BlockID));
                IList<Blockdays> UpdateList1 = crit.List<Blockdays>();
                IList<Blockdays> saveList = null;
                IList<Blockdays> delList = null;
                IList<Blockdays> UpdateList = new List<Blockdays>();
                if (UpdateList1 != null && UpdateList1.Count > 0)
                {
                    ulong groupIDMax = GetMaxGroupID();
                    IList<Blockdays> imaginarylst = GetBlockDaysByGroupID(GroupID);
                    foreach (Blockdays obj in UpdateList1)
                    {
                        obj.Blockdays_Group_ID = groupIDMax + 1;
                        UpdateList.Add(obj);
                    }
                    if (imaginarylst != null && imaginarylst.Count > 1)
                    {
                        foreach (Blockdays obj in imaginarylst)
                        {
                            if (obj.Id != BlockID)
                            {
                                if (obj.Id < BlockID)
                                {
                                    obj.To_Date_Choosen = UpdateList1[0].From_Date_Choosen.AddDays(-1);
                                }
                                else
                                {
                                    obj.Blockdays_Group_ID = groupIDMax + 2;
                                }
                                UpdateList.Add(obj);
                            }
                        }
                    }

                    // IList<Blockdays> oldListnull = null;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref UpdateList, delList, string.Empty, false, false, 0, string.Empty);
                }
                iMySession.Close();
            }
            // ilstBalanceblockdays=GetBlockDaysByGroupID(BlockDaysGroupId,sPhysicianID);
            return ilstBalanceblockdays;
        }
    }
}
