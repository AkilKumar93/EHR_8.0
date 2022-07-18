using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Data;
using System.IO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ISpirometryManager : IManagerBase<Spirometry, ulong>
    {
        InHouseProcedureDTO SaveUpdateDeleteSpirometryResults(IList<Spirometry> SaveList, IList<Spirometry> UpdateList, IList<Spirometry> DeleteList, string macAddress, InHouseProcedure objInHouseProcedure, string ProcedureCode);
        IList<Spirometry> GetValueById(ulong Human_id, DateTime Created_Date_Time);
        IList<string> GetSpirometryForPatientDistinctOfDate(ulong humanId);
        IList<Spirometry> GetSpirometryByOrderID(ulong OrderID);
        IList<Spirometry> GetSpirometryResultBySpirometryID(string OrderID);
        IList<Spirometry> GetSpirometryByHumanID(ulong HumanId);
        void DeleteSpirometry(ulong OrderID, string MacAddress, ISession MySession);
        string GetFileNameForInhouseID(ulong InhouseID);
       IList<Spirometry> SaveUpdateDeleteSpirometry(IList<Spirometry> savelist,IList<Spirometry>UpdateModifyList,string MacAddress);
       IList<Spirometry> DeleteFromSpirometry(IList<Spirometry> DeleteList, string MacAddress);
    }
    public partial class SpirometryManager : ManagerBase<Spirometry, ulong>, ISpirometryManager
    {
        #region Constructors

        public SpirometryManager()
            : base()
        {

        }
        public SpirometryManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

        public InHouseProcedureDTO SaveUpdateDeleteSpirometryResults(IList<Spirometry> SaveList, IList<Spirometry> UpdateList, IList<Spirometry> DeleteList, string macAddress, InHouseProcedure objInHouseProcedure, string ProcedureCode)
        {

           // ulong _In_House_Id;
            InHouseProcedureManager ObjInHouseProcedureManager = new InHouseProcedureManager();
            InHouseProcedureDTO ObjInHouseProcedureDTO = null;
            ulong InHouseProcedureID = 0;
            ulong In_House_ID = 0;
            if (ProcedureCode != string.Empty && objInHouseProcedure != null)
            {
                if (objInHouseProcedure.Id == 0)
                {
                    //  ObjInHouseProcedureDTO = ObjInHouseProcedureManager.InsertInHouseProcedure(objInHouseProcedure, null, macAddress, ProcedureCode);
                    InHouseProcedureID = ObjInHouseProcedureDTO.Current_Submited_In_House_Procedure_Id;
                }
                else
                {
                    // ObjInHouseProcedureDTO = ObjInHouseProcedureManager.UpdateInHouseProcedure(objInHouseProcedure, macAddress, ProcedureCode, ProcedureCode);
                    ObjInHouseProcedureDTO = ObjInHouseProcedureManager.FillInHouseProcedure(objInHouseProcedure.Encounter_ID, objInHouseProcedure.Physician_ID, objInHouseProcedure.Human_ID);
                    InHouseProcedureID = ObjInHouseProcedureDTO.OtherProcedure[0].Id;
                }
            }

            if (SaveList != null)
            {
                foreach (Spirometry SpirometryObj in SaveList)
                {
                    if (SpirometryObj.In_House_Procedure_ID != null)
                        if (SpirometryObj.In_House_Procedure_ID == 0)
                            SpirometryObj.In_House_Procedure_ID = InHouseProcedureID;
                }
            }

            //SaveUpdateDeleteWithTransaction(ref SaveList, UpdateList, DeleteList, macAddress);

            if (ProcedureCode != string.Empty && objInHouseProcedure != null)
            {
                foreach (InHouseProcedure DTOObj in ObjInHouseProcedureDTO.OtherProcedure)
                {
                    if (SaveList != null)
                    {
                        if (SaveList.Count != 0)
                            In_House_ID = SaveList[0].In_House_Procedure_ID;
                    }

                    if (UpdateList != null)
                    {
                        if (UpdateList.Count != 0)
                            In_House_ID = UpdateList[0].In_House_Procedure_ID;
                    }
                    if (DeleteList != null)
                    {
                        if (DeleteList.Count != 0)
                            In_House_ID = DeleteList[0].In_House_Procedure_ID;
                    }

                    if (DTOObj.Id == In_House_ID)
                    {
                        string str = GetFileNameForInhouseID(DTOObj.Id);
                        DTOObj.Internal_Property_Results_File_Name = str;
                    }

                }
            }
            return ObjInHouseProcedureDTO;
        }

        public IList<Spirometry> GetValueById(ulong Human_id, DateTime Created_Date_Time)
        {
            IList<Spirometry> lstSpiromtry = new List<Spirometry>();
             using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery query = iMySession.CreateSQLQuery("Select s.* from spirometry s where  s.Created_Date_And_Time like '" + Created_Date_Time.ToString("yyyy-MM-dd") + "%' and s.Patient_ID='" + Human_id + "'").AddEntity("p", typeof(Spirometry));
                 lstSpiromtry=query.List<Spirometry>();
                 iMySession.Close();
            }
             return lstSpiromtry;

        }

        public IList<string> GetSpirometryForPatientDistinctOfDate(ulong humanId)
        {
            IList<Spirometry> ilstSpirometry = new List<Spirometry>();
            IList<string> lstDate = new List<string>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit =iMySession.CreateCriteria(typeof(Spirometry)).Add(Expression.Eq("Patient_ID", humanId)).AddOrder(Order.Desc("Created_Date_And_Time"));
                ilstSpirometry = crit.List<Spirometry>();
                if (ilstSpirometry.Count > 0)
                {
                    for (int i = 0; i < ilstSpirometry.Count; i++)
                    {

                        lstDate.Add(ilstSpirometry[i].Created_Date_And_Time.ToString());
                    }

                }
                iMySession.Close();
            }
            return lstDate;


        }

        public IList<Spirometry> GetSpirometryByOrderID(ulong OrderID)
        {
             IList<Spirometry> lstSpiromtry = new List<Spirometry>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
            ICriteria criteria = iMySession.CreateCriteria(typeof(Spirometry)).Add(Expression.Eq("In_House_Procedure_ID", OrderID));
                 lstSpiromtry = criteria.List<Spirometry>();
                iMySession.Close();
            }
            return lstSpiromtry;
        }

        //BodyImage
        public IList<Spirometry> GetSpirometryResultBySpirometryID(string OrderID)
        {
            //ISQLQuery sqlqueryMaster = session.GetISession().CreateSQLQuery("select a.* from spirometry a  where a.Spirometry_ID  in ('" + OrderID + "')").AddEntity("a", typeof(Spirometry));
            //return sqlqueryMaster.List<Spirometry>();
            IList<Spirometry> lstSpiromtry = new List<Spirometry>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Spirometry)).Add(Expression.In("Id", OrderID.Split(',').Where(A => A != string.Empty).ToArray()));
                lstSpiromtry = crit.List<Spirometry>();
                iMySession.Close();
            }
            return lstSpiromtry;

        }

        public IList<Spirometry> GetSpirometryByHumanID(ulong HumanId)
        {
             IList<Spirometry> lstSpiromtry = new List<Spirometry>();
             using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
             {
                 ICriteria crit = iMySession.CreateCriteria(typeof(Spirometry)).Add(Expression.Eq("Patient_ID", HumanId)).AddOrder(Order.Desc("Created_Date_And_Time"));
                 lstSpiromtry = crit.List<Spirometry>();
                 iMySession.Close();
             }
             return lstSpiromtry;
        }
        //

        public void DeleteSpirometry(ulong OrderID, string MacAddress, ISession MySession)
        {
              IList<Spirometry> ObjSpirometry = new List<Spirometry>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
                  ICriteria cri = iMySession.CreateCriteria(typeof(Spirometry)).Add(Expression.Eq("In_House_Procedure_ID", OrderID));
                  //IList<Spirometry> ObjABI_Result = cri.List<Spirometry>();
                  ObjSpirometry = cri.List<Spirometry>();
                  iMySession.Close();
              }
            IList<Spirometry> addlst = new List<Spirometry>();
            //if (ObjSpirometry.Count > 0)
            //    SaveUpdateDeleteWithoutTransaction(ref addlst, null, ObjSpirometry.ToArray<Spirometry>(), MySession, MacAddress);

        }
        public string GetFileNameForInhouseID(ulong InhouseID)
        {
            string temp = string.Empty;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.ResultFileName_Spirometry");
                query.SetString(0, InhouseID.ToString());
                IList<string> FileNameList = query.List<string>();                
                foreach (string str in FileNameList)
                {
                    temp += "," + str;
                }
                iMySession.Close();
            }
            string returnstr = string.Empty;
            if (temp.Length > 0)
                returnstr = temp.Substring(1);
            return returnstr;

        }
        public IList<Spirometry> SaveUpdateDeleteSpirometry(IList<Spirometry> savelist, IList<Spirometry> UpdateModifyList, string MacAddress)
        {

            if (UpdateModifyList != null && UpdateModifyList.Count > 0)
            {
                for (int i = 0; i < UpdateModifyList.Count; i++)
                {
                    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                    {
                        ICriteria cri = iMySession.CreateCriteria(typeof(Spirometry)).Add(Expression.Eq("Id", UpdateModifyList[i].Id));
                        UpdateModifyList[i].Version = cri.List<Spirometry>()[0].Version;
                        iMySession.Close();
                    }
                }
                //SaveUpdateDeleteWithTransaction(ref savelist, UpdateModifyList, null, MacAddress);
            }
            return new List<Spirometry>();

        }
        int iTryCount = 0;
        public IList<Spirometry> DeleteFromSpirometry(IList<Spirometry> deletelist, string MacAddress)
        {
            if (deletelist != null && deletelist.Count > 0)
            {
                iTryCount = 0;
            TryAgain:
                int iResult = 0;
                ISession MySession = Session.GetISession();
                //ITransaction trans = null;
                try
                {
                    using (ITransaction trans = MySession.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            //trans = MySession.BeginTransaction();
                            FileManagementIndexManager objFileManagementIndexManager = new FileManagementIndexManager();
                            IList<FileManagementIndex> addlist = new List<FileManagementIndex>();
                            IList<FileManagementIndex> FileManagementIndexDeleteList = new List<FileManagementIndex>();
                            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
                            {
                                ICriteria cri = session.GetISession().CreateCriteria(typeof(FileManagementIndex)).Add(Expression.Eq("Result_Master_ID", deletelist[0].Id)).Add(Expression.Eq("Human_ID", deletelist[0].Patient_ID));
                                FileManagementIndexDeleteList = cri.List<FileManagementIndex>();
                                iMySession.Close();
                            }
                            //iResult = objFileManagementIndexManager.SaveUpdateDeleteWithoutTransaction(ref addlist, null, FileManagementIndexDeleteList, MySession, MacAddress);

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
                                    throw new Exception("Deadlock is occured. Transaction failed");

                                }
                            }
                            else if (iResult == 1)
                            {
                                trans.Rollback();
                                //MySession.Close();
                                throw new Exception("Exception is occured. Transaction failed");

                            }

                            IList<Spirometry> lstSpirometry = new List<Spirometry>();
                            //iResult = SaveUpdateDeleteWithoutTransaction(ref lstSpirometry, null, deletelist, MySession, MacAddress);

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
                                    throw new Exception("Deadlock is occured. Transaction failed");
                                }
                            }
                            else if (iResult == 1)
                            {
                                trans.Rollback();
                                //MySession.Close();
                                throw new Exception("Exception is occured. Transaction failed");
                            }

                            MySession.Flush();
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
                    }
                }
                catch(Exception ex)
                {
                    //MySession.Close();
                    throw new Exception(ex.Message);
                }
            }
            return new List<Spirometry>();
        }
        #endregion
    }
}
