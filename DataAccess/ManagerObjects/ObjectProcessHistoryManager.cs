using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IObjectProcessHistoryManager : IManagerBase<ObjectProcessHistory, ulong>
    {
        int AppendToObjectProcessHistory(IList<WFObject> OldWFobjList, ISession MySession, DateTime StartTime, string sMacAddress);
        void AppendToObjectProcessHistoryTable(WFObject OldWFobj, DateTime StartTime, string sMacAddress);
        //Added for ACO by srividhya on 01-oct-2014
        void AppendToObjectProcessHistoryTableForPriority(WFObject OldWFobj, string sOldPriority, DateTime StartTime, string sMacAddress);
    }

    public partial class ObjectProcessHistoryManager : ManagerBase<ObjectProcessHistory, ulong>, IObjectProcessHistoryManager
    {

         #region Constructors

        public ObjectProcessHistoryManager()
            : base()
        {

        }
        public ObjectProcessHistoryManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        public int AppendToObjectProcessHistory(IList<WFObject> OldWFobjList, ISession MySession, DateTime StartTime, string sMacAddress)
        {
            IList<ObjectProcessHistory> ObjProcHisList = new List<ObjectProcessHistory>();
            IList<ObjectProcessHistory> UpdateList = null;         
            GenerateXml XMLObj = null;
            for (int i = 0; i < OldWFobjList.Count; i++)
            {
                ObjectProcessHistory ObjProcHistoryRecord = null;
                ObjProcHistoryRecord = new ObjectProcessHistory();
                ObjProcHistoryRecord.Wf_Object_ID = Convert.ToInt32(OldWFobjList[i].Id);
                ObjProcHistoryRecord.Obj_System_ID = Convert.ToInt32(OldWFobjList[i].Obj_System_Id);
                ObjProcHistoryRecord.Process_Name = OldWFobjList[i].Current_Process;
                ObjProcHistoryRecord.Process_Start_Date_And_Time = StartTime;
                ObjProcHistoryRecord.Process_End_Date_And_Time = System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                ObjProcHistoryRecord.Obj_Type = OldWFobjList[i].Obj_Type;
                ObjProcHistoryRecord.Obj_Sub_Type = OldWFobjList[i].Obj_Sub_Type;
                ObjProcHistoryRecord.User_Name = OldWFobjList[i].Current_Owner;
                ObjProcHistoryRecord.Comments = "MOVED_TO_NEXT_PROCESS";
                ObjProcHisList.Add(ObjProcHistoryRecord);
            }

            //return SaveUpdateDeleteWithoutTransaction(ref ObjProcHisList, null, null, MySession, sMacAddress);           
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ObjProcHisList, ref UpdateList, null, MySession, sMacAddress, false, false, 0, string.Empty,ref XMLObj);
        }

        public void AppendToObjectProcessHistoryTable(WFObject OldWFobj, DateTime StartTime, string sMacAddress)
        {
            IList<ObjectProcessHistory> ObjProcHisList = new List<ObjectProcessHistory>();
            IList<ObjectProcessHistory> updateList = null;
            IList<WFObject> OldWFobjList = new List<WFObject>();
            OldWFobjList.Add(OldWFobj);

            for (int i = 0; i < OldWFobjList.Count; i++)
            {
                ObjectProcessHistory ObjProcHistoryRecord = null;
                ObjProcHistoryRecord = new ObjectProcessHistory();
                ObjProcHistoryRecord.Wf_Object_ID = Convert.ToInt32(OldWFobjList[i].Id);
                ObjProcHistoryRecord.Obj_System_ID= Convert.ToInt32(OldWFobjList[i].Obj_System_Id);
                ObjProcHistoryRecord.Process_Name = OldWFobjList[i].Current_Process;
                ObjProcHistoryRecord.Process_Start_Date_And_Time = StartTime;
                ObjProcHistoryRecord.Process_End_Date_And_Time = System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                ObjProcHistoryRecord.Obj_Type = OldWFobjList[i].Obj_Type;
                ObjProcHistoryRecord.Obj_Sub_Type = OldWFobjList[i].Obj_Sub_Type;
                ObjProcHistoryRecord.User_Name = OldWFobjList[i].Current_Owner;
                ObjProcHistoryRecord.Comments = "PARTIAL_CLOSE";
                ObjProcHisList.Add(ObjProcHistoryRecord);
            }

           // SaveUpdateDeleteWithTransaction(ref ObjProcHisList, null, null, sMacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref ObjProcHisList, ref updateList, null, sMacAddress, false, false, 0, string.Empty);
        }

        public void AppendToObjectProcessHistoryTableForPriority(WFObject OldWFobj, string sOldPriority, DateTime StartTime, string sMacAddress)
        {
            IList<ObjectProcessHistory> ObjProcHisList = new List<ObjectProcessHistory>();
            IList<ObjectProcessHistory> updateList = null;
            ObjectProcessHistory ObjProcHistoryRecord = null;
            ObjProcHistoryRecord = new ObjectProcessHistory();
            ObjProcHistoryRecord.Wf_Object_ID = Convert.ToInt32(OldWFobj.Id);
            ObjProcHistoryRecord.Obj_System_ID = Convert.ToInt32(OldWFobj.Obj_System_Id);
            ObjProcHistoryRecord.Process_Name = OldWFobj.Current_Process;
            ObjProcHistoryRecord.Process_Start_Date_And_Time = StartTime;
            ObjProcHistoryRecord.Process_End_Date_And_Time = System.TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            ObjProcHistoryRecord.Obj_Type = OldWFobj.Obj_Type;
            ObjProcHistoryRecord.Obj_Sub_Type = OldWFobj.Obj_Sub_Type;
            ObjProcHistoryRecord.User_Name = OldWFobj.Current_Owner;
            ObjProcHistoryRecord.Comments = "Priority Changed From \"" + sOldPriority + "\" To \"" + OldWFobj.Priority + "\"";
            ObjProcHisList.Add(ObjProcHistoryRecord);

           // SaveUpdateDeleteWithTransaction(ref ObjProcHisList, null, null, sMacAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref ObjProcHisList, ref updateList, null, sMacAddress, false, false, 0, string.Empty);
        }
    }
}
