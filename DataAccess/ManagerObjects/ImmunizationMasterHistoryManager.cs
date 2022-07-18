using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IImmunizationMasterHistoryManager : IManagerBase<ImmunizationMasterHistory, long>
    {
        ImmunizationHistoryDTO GetFromImmunizationMasterHistory(ulong ulHumanID, int iPageNumber, int iMaxResult, ulong ulEncounterID, bool isLoad);
        ImmunizationHistoryDTO InsertIntoImmunizationHistory(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> objImmuHistoryInsert, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad);
        ImmunizationHistoryDTO InsertIntoImmunizationHistoryFromOrders(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> objImmuHistoryInsert, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad, ISession MySession, ref GenerateXml XMLObj);
        ImmunizationHistoryDTO DeleteImmunizationHistoryDetails(IList<ImmunizationMasterHistory> ImmHis, IList<ImmunizationMasterHistory> objImmuHistorySave, IList<ImmunizationMasterHistory> DeleteList, string sMacAddress);
        ImmunizationHistoryDTO UpdateImmunizationHistoryDetails(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> objImmuHistorySave, IList<ImmunizationMasterHistory> objImmuHistoryUpdate, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad);
        ImmunizationHistoryDTO UpdateImmunizationHistoryDetailsFromOrders(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> objImmuHistorySave, IList<ImmunizationMasterHistory> objImmuHistoryUpdate, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad, ISession MySession, ref GenerateXml XMLObj);
        //ImmunizationHistoryDTO GetLoadPhyProcedAndVaccAndPhyCodeLib(ulong PhysicianID, string procedureType, ulong LabID);
    }
    public partial class ImmunizationMasterHistoryManager : ManagerBase<ImmunizationMasterHistory, long>, IImmunizationMasterHistoryManager
    {
        #region Constructors

        public ImmunizationMasterHistoryManager()
            : base()
        {

        }
        public ImmunizationMasterHistoryManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public ImmunizationHistoryDTO GetFromImmunizationMasterHistory(ulong ulHumanID, int PageNumber, int MaxResultSet, ulong ulEncounterID, bool Is_Load)
        {
           // bool IsPrevious = false;
            ICriteria criteria = null;
            IList<ImmunizationMasterHistory> CommonImmunizationList = new List<ImmunizationMasterHistory>();
            ImmunizationHistoryDTO objImmunizationDTO = new ImmunizationHistoryDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (!Is_Load)
                {
                    criteria = iMySession.CreateCriteria(typeof(ImmunizationMasterHistory)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Encounter_ID", ulEncounterID));
                    CommonImmunizationList = criteria.List<ImmunizationMasterHistory>();
                }
                else if (Is_Load)
                {
                    criteria = iMySession.CreateCriteria(typeof(ImmunizationMasterHistory)).Add(Expression.Eq("Human_ID", ulHumanID));//.Add(Expression.Eq("Encounter_Id", EncounterId));
                    CommonImmunizationList = criteria.List<ImmunizationMasterHistory>();
                    EncounterManager encMngr = new EncounterManager();
                    IList<Encounter> EncLst = new List<Encounter>();
                    EncLst = encMngr.GetEncounterUsingHumanID(ulHumanID);
                    if (EncLst.Count > 0)
                    {
                        //foreach (Encounter item in EncLst)
                        //{
                        //    if (ulEncounterID >= item.Id)
                        //    {
                        //        if (CommonImmunizationList.Any(a => a.Encounter_ID == item.Id))
                        //        {
                        //            CommonImmunizationList = CommonImmunizationList.Where(a => a.Encounter_ID == item.Id).ToList<ImmunizationMasterHistory>();
                        //            IsPrevious = true;
                        //            break;

                        //        }
                        //    }
                        //}
                    }

                    //if (!IsPrevious && Is_Load)
                    //    CommonImmunizationList = CommonImmunizationList.Where(a => a.Human_ID == ulHumanID && a.Encounter_ID == Convert.ToUInt16(0)).ToList<ImmunizationMasterHistory>();

                }
                objImmunizationDTO.ImmunizationCount = CommonImmunizationList.Count;
                if (CommonImmunizationList != null && CommonImmunizationList.Count > 0)
                    CommonImmunizationList = CommonImmunizationList.Skip((PageNumber - 1) * MaxResultSet).Take(MaxResultSet).ToList(); //GetByCriteria(MaxResultSet, PageNumber, criteria);
                objImmunizationDTO.ImmunizationMasterList = CommonImmunizationList;
                iMySession.Close();
            }
            return objImmunizationDTO;

        }

        public IList<ImmunizationMasterHistory> GetImmunizationDeteailsbyID(ulong MasterId)
        {
              ICriteria criteria = null;
              IList<ImmunizationMasterHistory> lst = new List<ImmunizationMasterHistory>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
             

                  criteria = iMySession.CreateCriteria(typeof(ImmunizationMasterHistory)).Add(Expression.Eq("Id", MasterId));
                  lst = criteria.List<ImmunizationMasterHistory>();
              }
             
              return lst;
        }
        public ImmunizationHistoryDTO InsertIntoImmunizationHistory(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> InsertImmuHistory, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<ImmunizationMasterHistory> UpdateImmunizationHistory = null;
            if (InsertImmuHistory.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertImmuHistory, ref UpdateImmunizationHistory, null, sMacAddress, true, true, InsertImmuHistory[0].Human_ID, string.Empty);
            }
            return null;
        }

        public ImmunizationHistoryDTO InsertIntoImmunizationHistoryFromOrders(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> InsertImmuHistory, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad, ISession MySession, ref GenerateXml XMLObj)
        {
            IList<ImmunizationMasterHistory> UpdateImmunizationHistory = null;
            if (InsertImmuHistory.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithoutTransaction(ref InsertImmuHistory, ref UpdateImmunizationHistory, null, MySession, sMacAddress, true, true, ulHumanID, string.Empty, ref XMLObj);
            }
            return null;
        }

        public ImmunizationHistoryDTO DeleteImmunizationHistoryDetails(IList<ImmunizationMasterHistory> ImmHis, IList<ImmunizationMasterHistory> objImmuHistorySave, IList<ImmunizationMasterHistory> DeleteList, string sMacAddress)
        {

            //IList<ImmunizationMasterHistory> Ulist = null;
            if (DeleteList.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithTransaction(ref objImmuHistorySave, ref DeleteList, null, sMacAddress, true, true, DeleteList[0].Human_ID, string.Empty);
            }
            return null;

        }

        public ImmunizationHistoryDTO UpdateImmunizationHistoryDetails(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> objImmuHistorySave, IList<ImmunizationMasterHistory> updateList, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad)
        {
            if (updateList.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithTransaction(ref objImmuHistorySave, ref updateList, null, sMacAddress, true, true, updateList[0].Human_ID, string.Empty);
            }
            return GetFromImmunizationMasterHistory(ulHumanID, iPageNumber, iMaxResult, ulEncounterID, isLoad);
        }

        public ImmunizationHistoryDTO UpdateImmunizationHistoryDetailsFromOrders(IList<ImmunizationMasterHistory> objImmuHistory, IList<ImmunizationMasterHistory> objImmuHistorySave, IList<ImmunizationMasterHistory> updateList, ulong ulHumanID, int iPageNumber, int iMaxResult, string sMacAddress, ulong ulEncounterID, bool isLoad, ISession MySession, ref GenerateXml XMLObj)
        {
            if (updateList.Count > 0)
            {
                SaveUpdateDelete_DBAndXML_WithoutTransaction(ref objImmuHistorySave, ref updateList, null, MySession, sMacAddress, true, true, ulHumanID, string.Empty, ref XMLObj);
            }
            return GetFromImmunizationMasterHistory(ulHumanID, iPageNumber, iMaxResult, ulEncounterID, isLoad);
        }

        public ImmunizationHistoryDTO GetLoadPhyProcedAndVaccAndPhyCodeLib(ulong PhysicianID, string procedureType, ulong LabID, string sLegalOrg)
        {
            //bool IsPrevious = false;
            ICriteria criteria = null;
            IList<PhysicianProcedure> PhysicianProcedureList = new List<PhysicianProcedure>();
            IList<VaccineManufacturerCodes> listVaccine = new List<VaccineManufacturerCodes>();
            ImmunizationHistoryDTO objImmunizationDTO = new ImmunizationHistoryDTO();
            IList<ProcedureCodeLibrary> listPrb = new List<ProcedureCodeLibrary>();
            IList<ProcedureCodeLibrary> listPrb1 = new List<ProcedureCodeLibrary>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (LabID != 0)
                    criteria = iMySession.CreateCriteria(typeof(PhysicianProcedure)).Add(Expression.Eq("Physician_ID", PhysicianID)).Add(Expression.Eq("Lab_ID", LabID)).Add(Expression.Eq("Legal_Org" , sLegalOrg)).AddOrder(Order.Asc("Sort_Order"));
                else
                    criteria = iMySession.CreateCriteria(typeof(PhysicianProcedure)).Add(Expression.Eq("Physician_ID", PhysicianID)).Add(Expression.Eq("Procedure_Type", procedureType)).Add(Expression.Eq("Lab_ID", LabID)).Add(Expression.Eq("Legal_Org", sLegalOrg)).AddOrder(Order.Asc("Sort_Order"));
                PhysicianProcedureList = criteria.List<PhysicianProcedure>();
                PhysicianProcedureList = (PhysicianProcedureList).Any(a => a.Sort_Order == 0) ? (PhysicianProcedureList).Where(a => a.Sort_Order != 0).ToList().Concat(PhysicianProcedureList.Where(a => a.Sort_Order == 0).OrderBy(b => b.Procedure_Description)).ToList() : PhysicianProcedureList;
                objImmunizationDTO.PhysicianProcedure = PhysicianProcedureList;
                if (PhysicianProcedureList != null && PhysicianProcedureList.Count > 0)
                {
                    criteria = iMySession.CreateCriteria(typeof(ProcedureCodeLibrary)).Add(Expression.In("Procedure_Code", PhysicianProcedureList.Select(a => a.Physician_Procedure_Code).ToList()));
                    if (criteria.List<ProcedureCodeLibrary>().Count > 0)
                    {
                        IList<ProcedureCodeLibrary> TempList = criteria.List<ProcedureCodeLibrary>();
                        foreach (ProcedureCodeLibrary obj in TempList)
                            listPrb.Add(obj);
                    }
                    if (listPrb != null && listPrb.Count > 0)
                    {
                        objImmunizationDTO.ProcedureCodeLibrary = listPrb;
                    }
                }
                criteria = iMySession.CreateCriteria(typeof(VaccineManufacturerCodes)).Add(Expression.Eq("Status", "Active")).AddOrder(Order.Asc("Sort_Order"));
                listVaccine = criteria.List<VaccineManufacturerCodes>();
                if (listVaccine != null && listVaccine.Count > 0)
                {
                    objImmunizationDTO.VaccineManufacturerCodes = listVaccine;
                }
                iMySession.Close();
            }
            return objImmunizationDTO;
        }
        #endregion

    }
}
