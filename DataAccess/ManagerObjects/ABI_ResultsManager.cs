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

    public partial interface IABI_ResultsManager : IManagerBase<ABI_Results, uint>
    {

        InHouseProcedureDTO Save_Update_DeleteWith_ABI(IList<ABI_Results> addList, IList<ABI_Results> updateList, IList<ABI_Results> deleteList, string macAddress, InHouseProcedure objInHouseProcedure, string ProcedureCode);
        IList<ABI_Results> GetABIResultByPatientIDAndDate(DateTime date , ulong patient_id);
        
        IList<string> GetABIResultForPatientDistinctOfDate(ulong humanId);
        void DeleteABI_Result(ulong OrderID, string MacAddress, ISession MySession);
        IList<ABI_Results> GetABIResultByOrderID(ulong OrderID);

        IList<ABI_Results> DeleteFromABI_Result(ulong Abi_id, string MacAddress);
        string GetFileNameForInhouseID(ulong InhouseID);
        IList<ABI_Results> SaveUpdatDeleteABI(IList<ABI_Results> addList, IList<ABI_Results> updateList, IList<ABI_Results> deleteList, string macAddress);

        ABIResultsDTO GetABI_ResultBy_ABI_ID(string id);
        ABIResultsDTO GetABI_ResultBY_Human_ID(ulong human_id);


        
    }

    public partial class ABI_ResultsManager : ManagerBase<ABI_Results, uint>, IABI_ResultsManager
    {
        #region Constructors

        public ABI_ResultsManager()
            : base()
        {

        }
        public ABI_ResultsManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        int iTryCount = 0;
        #region Get Methods
        public InHouseProcedureDTO Save_Update_DeleteWith_ABI(IList<ABI_Results> addList, IList<ABI_Results> updateList, IList<ABI_Results> deleteList, string macAddress,InHouseProcedure objInHouseProcedure,string ProcedureCode)
        {



            InHouseProcedureManager ObjInHouseProcedureManager = new InHouseProcedureManager();
            InHouseProcedureDTO ObjInHouseProcedureDTO = null;
            ulong InHouseProcedureID = 0;
            ulong In_House_ID = 0;
            if (ProcedureCode != string.Empty && objInHouseProcedure != null)
            {
                if (objInHouseProcedure.Id == 0)
                {
                    //ObjInHouseProcedureDTO = ObjInHouseProcedureManager.InsertInHouseProcedure(objInHouseProcedure, null, macAddress, ProcedureCode);
                    InHouseProcedureID = ObjInHouseProcedureDTO.Current_Submited_In_House_Procedure_Id;
                }
                else
                {
                    ObjInHouseProcedureDTO = ObjInHouseProcedureManager.FillInHouseProcedure(objInHouseProcedure.Encounter_ID, objInHouseProcedure.Physician_ID, objInHouseProcedure.Human_ID);
                    InHouseProcedureID = objInHouseProcedure.Id;
                    //InHouseProcedureID = addList[0].In_House_Procedure_ID;
                }
            }
            foreach (ABI_Results ABI_RESULTObj in addList)
            {
               if(ABI_RESULTObj.In_House_Procedure_ID==0)
                ABI_RESULTObj.In_House_Procedure_ID = InHouseProcedureID;
            

            }
            //SaveUpdateDeleteWithTransaction(ref addList, updateList, deleteList, macAddress);
            if (ProcedureCode != string.Empty && objInHouseProcedure != null)
            {
                foreach (InHouseProcedure DTOObj in ObjInHouseProcedureDTO.OtherProcedure)
                {

                    if (addList.Count != 0)
                        In_House_ID = addList[0].In_House_Procedure_ID;
                    else if (updateList.Count != 0)
                        In_House_ID = updateList[0].In_House_Procedure_ID;
                    else
                        In_House_ID = deleteList[0].In_House_Procedure_ID;
                    if (DTOObj.Id == In_House_ID)
                    {


                        string str = GetFileNameForInhouseID(DTOObj.Id);

                        DTOObj.Internal_Property_Results_File_Name = str;



                    }
                }
            }



            return ObjInHouseProcedureDTO;


            #region Backup

            //  InHouseProcedureManager ObjInHouseProcedureManager = new InHouseProcedureManager();
          //  InHouseProcedureDTO ObjInHouseProcedureDTO=null;
          //  ulong InHouseProcedureID=0;
          //  ulong In_House_ID=0;
          //  if (ProcedureCode != string.Empty && objInHouseProcedure!=null)
          //  {
          //      if (objInHouseProcedure.Id == 0)
          //      {
          //          ObjInHouseProcedureDTO = ObjInHouseProcedureManager.InsertInHouseProcedure(objInHouseProcedure, null, macAddress, ProcedureCode);
          //          InHouseProcedureID = ObjInHouseProcedureDTO.Current_Submited_In_House_Procedure_Id;
          //      }
          //      else
          //      {
          //          ObjInHouseProcedureDTO = ObjInHouseProcedureManager.UpdateInHouseProcedure(objInHouseProcedure, macAddress, ProcedureCode, ProcedureCode);
          //          InHouseProcedureID = ObjInHouseProcedureDTO.OtherProcedure[0].Id;
          //      }
          //  }
          //  foreach (ABI_Results ABI_RESULTObj in addList)
          //  {
          //      ABI_RESULTObj.In_House_Procedure_ID = InHouseProcedureID;
          //  }
          //  SaveUpdateDeleteWithTransaction(ref addList, updateList, deleteList, macAddress);
          //  if (ProcedureCode != string.Empty && objInHouseProcedure != null)
          //  {
          //      foreach (InHouseProcedure DTOObj in ObjInHouseProcedureDTO.OtherProcedure)
          //      {
                   
          //          if (addList.Count != 0)
          //              In_House_ID = addList[0].In_House_Procedure_ID;
          //          else if(updateList.Count!=0)
          //              In_House_ID = updateList[0].In_House_Procedure_ID;
          //          else
          //              In_House_ID = deleteList[0].In_House_Procedure_ID;
          //          if (DTOObj.Id == In_House_ID)
          //              {


          //                  string str = GetFileNameForInhouseID(DTOObj.Id);

          //                  DTOObj.Results_File_Name = str;



          //              }
          //      }
          //}
            
            

          //  return ObjInHouseProcedureDTO;
#endregion
        }

        public IList<ABI_Results> GetABIResultByPatientIDAndDate(DateTime date, ulong patient_id)
        {
            IList<ABI_Results> ilstABI_Results=new List<ABI_Results>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = iMySession.CreateSQLQuery("Select a.* from abi_results a where a.created_date_and_time like '" + date.ToString("yyyy-MM-dd") + "%' and a.Patient_ID='" + patient_id + "'").AddEntity("s", typeof(ABI_Results));
                ilstABI_Results = sql.List<ABI_Results>();
                iMySession.Close();
            }
            return ilstABI_Results;
            
        }
        public void DeleteABI_Result(ulong OrderID, string MacAddress,ISession MySession)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria cri = iMySession.CreateCriteria(typeof(ABI_Results)).Add(Expression.Eq("In_House_Procedure_ID", OrderID));
                IList<ABI_Results> ObjABI_Result = cri.List<ABI_Results>();
                IList<ABI_Results> addlst = new List<ABI_Results>();
                //if (ObjABI_Result.Count > 0)
                //    SaveUpdateDeleteWithoutTransaction(ref addlst, null, ObjABI_Result.ToArray<ABI_Results>(), MySession, MacAddress);
                iMySession.Close();
            }
            
        }
        public IList<ABI_Results> GetABIResultByOrderID(ulong OrderID)
        {
            IList<ABI_Results> ilstABI_Results=new List<ABI_Results>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ABI_Results)).Add(Expression.Eq("In_House_Procedure_ID", OrderID));
                ilstABI_Results= criteria.List<ABI_Results>();
                iMySession.Close();
            }
            return ilstABI_Results;

        }
        #endregion

        #region IABI_ResultsManager Members
         //ISQLQuery sqlqueryMaster = session.GetISession().CreateSQLQuery("select a.* from master_vitals a  where a.Master_Vitals_ID  in ('" + MasterID + "')").AddEntity("a", typeof(MasterVitals));
         //           masterlist = sqlqueryMaster.List<MasterVitals>();

        public IList<string> GetABIResultForPatientDistinctOfDate(ulong humanId)
        {
            IList<ABI_Results> ilstABIResult = new List<ABI_Results>();
            IList<string> lstDate = new List<string>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
                    ICriteria crit = iMySession.CreateCriteria(typeof(ABI_Results)).Add(Expression.Eq("Patient_ID", humanId)).AddOrder(Order.Desc("Created_Date_And_Time"));
                    ilstABIResult = crit.List<ABI_Results>();
                    if (ilstABIResult.Count > 0)
                    {
                        for (int i = 0; i < ilstABIResult.Count; i++)
                        {

                            lstDate.Add(ilstABIResult[i].Created_Date_And_Time.ToString());
                        } 

                    }
                    iMySession.Close();

              }
            return lstDate;

        }
        public string GetFileNameForInhouseID(ulong InhouseID)
        {
            string returnstr=string.Empty;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.ResultFileName_ABN");
                query.SetString(0, InhouseID.ToString());
                IList<string> FileNameList = query.List<string>();
                string temp = string.Empty;
                foreach (string str in FileNameList)
                {
                    temp += "," + str;
                }

                if (temp.Length > 0)
                    returnstr = temp.Substring(1);
                iMySession.Close();
            }
            return returnstr;
        }
        public ABIResultsDTO GetABI_ResultBy_ABI_ID(string id)
        {
            ABIResultsDTO ObjDto = new ABIResultsDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ABI_Results)).Add(Expression.In("Id", id.Split(',').Where(A => A != string.Empty).ToArray()));
                //return crit.List<ABI_Results>();
                ObjDto.lstABIResult = crit.List<ABI_Results>();
                StaticLookupManager objstatic = new StaticLookupManager();
                ObjDto.LookUpListForABI = objstatic.getStaticLookupByFieldName("ABI RESULT");
                iMySession.Close();
            }
            return ObjDto;
        }


     public ABIResultsDTO GetABI_ResultBY_Human_ID(ulong  human_id)
     {
         ABIResultsDTO ObjDto = new ABIResultsDTO();
           using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                  ICriteria crit = iMySession.CreateCriteria(typeof(ABI_Results)).Add(Expression.Eq("Patient_ID", human_id)).AddOrder(Order.Desc("Created_Date_And_Time"));
                  //  return  crit.List<ABI_Results>();
                 ObjDto.lstABIResult = crit.List<ABI_Results>();
                 StaticLookupManager objstatic = new StaticLookupManager();
                 ObjDto.LookUpListForABI = objstatic.getStaticLookupByFieldName("ABI RESULT");
                 iMySession.Close();
            }
         return ObjDto;

     }
        #endregion



        public IList<ABI_Results> DeleteFromABI_Result(ulong Abi_id, string MacAddress)
        {



            iTryCount = 0;
        TryAgain:
            int iResult = 0;
            ICriteria cri = session.GetISession().CreateCriteria(typeof(ABI_Results)).Add(Expression.Eq("Id",Convert.ToInt32( Abi_id)));
            IList<ABI_Results> ObjABI_Result = cri.List<ABI_Results>();

            ICriteria crit = session.GetISession().CreateCriteria(typeof(FileManagementIndex)).Add(Expression.Eq("Result_Master_ID", Abi_id)).Add(Expression.Eq("Source", "ABI"));
            IList<FileManagementIndex> lstfileMgnt = crit.List<FileManagementIndex>();


            Session.GetISession().Clear();
            ISession MySession = Session.GetISession();
            ITransaction trans = null;


            try
            {
                trans = MySession.BeginTransaction();



                if (ObjABI_Result != null)
                {

                    if (ObjABI_Result.Count > 0)
                    {
                        IList<ABI_Results> lstAbiresult = new List<ABI_Results>();
                        //iResult = SaveUpdateDeleteWithoutTransaction(ref lstAbiresult, null, ObjABI_Result, MySession, MacAddress);



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


                    }

                }


                if (lstfileMgnt != null)
                {
                    if (lstfileMgnt.Count > 0)
                    {

                          FileManagementIndexManager filemanagementmgr = new FileManagementIndexManager();
                         IList<FileManagementIndex> addlist = new List<FileManagementIndex>();
                         //iResult = filemanagementmgr.SaveUpdateDeleteWithoutTransaction(ref addlist, null, lstfileMgnt, MySession, MacAddress);

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

                    }
                }




                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                //CAP-1942
                throw new Exception(ex.Message,ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                //CAP-1942
                throw new Exception(e.Message,e);
            }
            finally
            {
                MySession.Close();
            }


            return new List<ABI_Results >();

        }



      public   IList<ABI_Results> SaveUpdatDeleteABI(IList<ABI_Results> addList, IList<ABI_Results> updateList, IList<ABI_Results> deleteList, string macAddress)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (updateList.Count > 0)
                {

                    ICriteria cri = iMySession.CreateCriteria(typeof(ABI_Results)).Add(Expression.Eq("Id", Convert.ToInt32(updateList[0].Id)));
                    updateList[0].Version = cri.List<ABI_Results>()[0].Version;
                }


                //SaveUpdateDeleteWithTransaction(ref addList, updateList, deleteList, macAddress);
                iMySession.Close();
            }
            return new List<ABI_Results>();
        }
        
    }
    
  
}
