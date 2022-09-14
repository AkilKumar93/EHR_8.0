using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using System.Threading;
using System.Web;
using System.IO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IFacilityManager : IManagerBase<FacilityLibrary, ulong>
    {
        IList<FacilityLibrary> GetFacilityList();
        IList<FacilityLibrary> GetFacilityByFacilityname(string facilityName);
        IList<MapFacilityPhysician> GetFacilityByPhysicianID(ulong Phy_ID);
        IList<FacilityLibrary> AddDetails(FacilityLibrary facilityInsert, string sMacAddress);
        IList<FacilityLibrary> DeleteDetails(string FacilityName);
        IList<FacilityLibrary> UpdateDetails(FacilityLibrary facilityListToUpdate, string sMacAddress);
        IList<FacilityLibrary> DeleteFacility(FacilityLibrary facLib, string sMacAddress);
        //FacilityLibraryDTO GetFacility(int PageNumber, int MaxResultSet);
        FacilityLibrary GetFacilityByPOS(string POS);
        FacilityLibrary GetFacilityByPOS(string sFacilityName, string POS);

        //IList<FacilityLibrary> GetFacilityById(ulong facilityId);
        //void BatchDeleteFacilityLibrary(IList<FacilityLibrary> facility);
        string GetTimeZoneOfFacilty(string FacilityName);
        //IList<CodeLookupDTO> GetFacilityListforCodeLookUp(string code, string desc);
        FillLogin GetFacilityProcessAndMACAddressDetails(string sIPAddress);
        IList<FacilityLibrary> GetFacilityName();
        //Added by Gopal 
        IList<FacilityLibrary> GetFacilityFax(string DenialCaptureID);
        IList<FacilityLibrary> GetFacilitybyFacilityType(string FacilityType);
        //Added by srividhya on 25-Jul-2014
        IList<FacilityLibrary> GetFacilitybyShortName(string sFacilityShortName);
        void SaveFacilityforSummary(IList<FacilityLibrary> lstfacility);
        IList<FacilityLibrary> GetFacilitylist();
        IList<FacilityLibrary> GetFacilitybyFacility_shortname(string FacilityshortName);
        IList<FacilityLibrary> GetFacilitybyFacilityname(string FacilityName);
        IList<FacilityLibrary> GetFacilityListByFacilityName(string FacilityName);
        IList<FacilityLibrary> GetFacilityInformationByFacilityType(string FacilityType);
        IList<FacilityLibrary> GetFacilityInformationByFacilityTypeNotLike(string FacilityType);
        OfficeManagerDTO GetFacilityListAndWorkflowList(string FacilityName);
        IList<FacilityLibrary> GetFacilityNameByFacilityType();
        IList<FacilityLibrary> GetAncillaryFacilityList();
    }

    public partial class FacilityManager : ManagerBase<FacilityLibrary, ulong>, IFacilityManager
    {




        #region Constructors

        public FacilityManager()
            : base()
        {

        }
        public FacilityManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods
        public IList<FacilityLibrary> GetFacilityList()
        {
            IList<FacilityLibrary> FacList;
            FacList = GetAll();
            return FacList;
        }

        //public IList<FacilityLibrary> GetFacilityById(ulong facilityId)
        //{
        //    ICriteria criteria = session.GetISession().CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Id", facilityId));
        //    return criteria.List<FacilityLibrary>();
        //}

        public IList<FacilityLibrary> GetFacilityByFacilityname(string facilityName)
        {
            IList<FacilityLibrary> ilstFacilityLibrary = new List<FacilityLibrary>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Fac_Name", facilityName));
                //return criteria.List<FacilityLibrary>();
                ilstFacilityLibrary = criteria.List<FacilityLibrary>();
                iMySession.Close();

            }
            return ilstFacilityLibrary;
        }
        public IList<MapFacilityPhysician> GetFacilityByPhysicianID(ulong Phy_ID)
        {
            IList<MapFacilityPhysician> list = new List<MapFacilityPhysician>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = mySession.CreateCriteria(typeof(MapFacilityPhysician)).Add(Expression.Eq("Phy_Rec_ID", Phy_ID));
                list = criteria.List<MapFacilityPhysician>();
                mySession.Close();
            }
            return list;
        }
        public string GetTimeZoneOfFacilty(string FacilityName)
        {
            IList<FacilityLibrary> listFacLib = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Fac_Name", FacilityName));
                if (crit.List<FacilityLibrary>().Count != 0)
                    listFacLib[0].Time_Zone = crit.List<FacilityLibrary>()[0].Time_Zone;
                mySession.Close();
            }
            return string.Empty;
        }

        public IList<FacilityLibrary> AddDetails(FacilityLibrary facilityInsert, string sMacAddress)
        {

            IList<FacilityLibrary> FacilityList = new List<FacilityLibrary>();
            FacilityList.Add(facilityInsert);

            //Added Latha - 2/8/10 - Checking for null value.
            if (FacilityList.Count > 0)
            {
                //SaveUpdateDeleteWithTransaction(ref FacilityList, null, null, sMacAddress);
            }
            return GetFacilityList();
        }

        //public void BatchDeleteFacilityLibrary(IList<FacilityLibrary> facility)
        //{
        //    Delete(facility);
        //}

        public IList<FacilityLibrary> DeleteDetails(string FacilityName)
        {
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = mySession.CreateSQLQuery("delete from facility_library where Facility_Name ='" + FacilityName + "'");
                sql.List<FacilityLibrary>();
                mySession.Close();
            }
            return GetFacilityList();
        }

        public IList<FacilityLibrary> DeleteFacility(FacilityLibrary facLib, string sMacAddress)
        {
            //IList<FacilityLibrary> facListInsert = null;
            IList<FacilityLibrary> facListDelete = null;

            if (facLib != null)
            {
                facListDelete = new List<FacilityLibrary>();
                facListDelete.Add(facLib);

                //SaveUpdateDeleteWithTransaction(ref facListInsert, null, facListDelete, sMacAddress);
            }
            return GetFacilityList();
        }

        public IList<FacilityLibrary> UpdateDetails(FacilityLibrary facilityListToUpdate, string sMacAddress)
        {
            //Added Latha - 2/8/10 - Checking for null value.
            //IList<FacilityLibrary> facListInsert = null;
            IList<FacilityLibrary> facListUpdate = new List<FacilityLibrary>();
            facListUpdate.Add(facilityListToUpdate);

            if (facListUpdate != null)
            {
                if (facListUpdate.Count > 0)
                {
                    //SaveUpdateDeleteWithTransaction(ref facListInsert, facListUpdate, null, sMacAddress);
                }
            }
            return GetFacilityList();
        }
        public FacilityLibrary GetFacilityByPOS(string POS)
        {
            FacilityLibrary objFac = new FacilityLibrary();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("POS", POS));
                if (crit.List<FacilityLibrary>().Count != 0)
                    objFac = crit.List<FacilityLibrary>()[0];
                mySession.Close();
            }
            return objFac;
        }

        //public IList<CodeLookupDTO> GetFacilityListforCodeLookUp(string code, string desc)
        //{
        //    IList<CodeLookupDTO> CodeLookUpList = new List<CodeLookupDTO>();
        //    IList<FacilityLibrary> FacilityLibraryList = new List<FacilityLibrary>();
        //    CodeLookupDTO objCodeLookUp;
        //    using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        FacilityLibraryList = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Like("POS", code))
        //          .Add(Expression.Like("POS_Description", desc)).List<FacilityLibrary>();

        //        for (int i = 0; i < FacilityLibraryList.Count; i++)
        //        {
        //            objCodeLookUp = new CodeLookupDTO();
        //            objCodeLookUp.Code = FacilityLibraryList[i].POS;
        //            objCodeLookUp.Description = FacilityLibraryList[i].POS_Description;
        //            CodeLookUpList.Add(objCodeLookUp);
        //        }
        //        mySession.Close();
        //    }
        //    return CodeLookUpList;
        //}
        public FillLogin GetFacilityProcessAndMACAddressDetails(string sIPAddress)
        {
            FillLogin login = new FillLogin();
            //Srividhya: bug id:27061            
            IList<FacilityLibrary> FacList = new List<FacilityLibrary>();
            FacilityLibrary FacRecord = new FacilityLibrary();

            FacList = GetFacilityList();

            for (int i = 0; i < FacList.Count; i++)
            {
                if (i == 0)
                {
                    FacRecord = new FacilityLibrary();
                    login.Facility_Library_List.Add(FacRecord);
                }
                FacRecord = new FacilityLibrary();
                FacRecord = FacList[i];
                login.Facility_Library_List.Add(FacRecord);
            }

            ProcessMasterManager processMngr = new ProcessMasterManager();
            login.Process_Master_List = processMngr.GetAllProcessList();
            RegisteredNetworkManager RegNetMngr = new RegisteredNetworkManager();
            login.Default_Facility = RegNetMngr.GetFacilityByClientIPAddress(sIPAddress);
            UserManager userMngr = new UserManager();
            login.UserList = userMngr.GetUserAndFacilityList();
            return login;

        }
        public IList<FacilityLibrary> GetFacilityName()
        {
            IList<FacilityLibrary> ilstFacilityName = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = mySession.GetNamedQuery("Get.FacilityName");

                ArrayList aryPaid = new ArrayList();
                aryPaid = new ArrayList(query.List());
                if (aryPaid.Count != 0)
                {
                    for (int i = 0; i < aryPaid.Count; i++)
                    {
                        FacilityLibrary objFac = new FacilityLibrary();
                        //object[] obj = (object[])aryPaid[0];
                        objFac.Fac_Name = aryPaid[i].ToString();
                        ilstFacilityName.Add(objFac);
                    }

                }
                mySession.Close();
            }
            return ilstFacilityName;
        }
        public FacilityLibrary GetFacilityByPOS(string sFacilityName, string POS)
        {
            FacilityLibrary objFac = new FacilityLibrary();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Fac_Name", sFacilityName)).Add(Expression.Eq("POS", POS));
                if (crit.List<FacilityLibrary>().Count != 0)
                    objFac = crit.List<FacilityLibrary>()[0];
                mySession.Close();
            }
            return objFac;
        }

        //Added by Gopal - 20131025

        public IList<FacilityLibrary> GetFacilityFax(string DenialCaptureID)
        {
            IList<FacilityLibrary> ilstFacilityName = new List<FacilityLibrary>();

            FacilityLibrary objFac = new FacilityLibrary();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = mySession.GetNamedQuery("Get.FacilityFaxNumber.From.FacilityLibrary");
                query.SetString(0, DenialCaptureID);
                ArrayList aryPaid = new ArrayList();
                aryPaid = new ArrayList(query.List());
                if (aryPaid.Count != 0)
                {
                    object[] obj = (object[])aryPaid[0];
                    objFac.Fac_Fax = obj[0].ToString();
                    objFac.Fac_Telephone = obj[1].ToString();
                }
                ilstFacilityName.Add(objFac);
                mySession.Close();
            }
            return ilstFacilityName;
        }

        public IList<FacilityLibrary> GetFacilitybyFacilityType(string FacilityType)
        {
            IList<FacilityLibrary> ilstFacilityName = new List<FacilityLibrary>();
            FacilityLibrary objFac = new FacilityLibrary();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = mySession.GetNamedQuery("Get.FacilityNamebyType.From.FacilityLibrary");
                query.SetString(0, FacilityType);
                ArrayList aryPaid = new ArrayList();
                aryPaid = new ArrayList(query.List());
                for (int i = 0; i < aryPaid.Count; i++)
                {
                    objFac = new FacilityLibrary();
                    if (aryPaid.Count != 0)
                    {
                        objFac.Fac_Name = aryPaid[i].ToString();
                    }
                    ilstFacilityName.Add(objFac);
                }
                mySession.Close();
            }
            return ilstFacilityName;
        }
        public IList<FacilityLibrary> GetFacilitybyShortName(string sFacilityShortName)
        {
            IList<FacilityLibrary> FacList = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Short_Name", sFacilityShortName));
                FacList = crit.List<FacilityLibrary>();
                mySession.Close();
            }
            return FacList;
        }

        public void SaveFacilityforSummary(IList<FacilityLibrary> lstfacility)
        {
            IList<FacilityLibrary> nullList = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref lstfacility, ref nullList, null, string.Empty, false, false, 0, "");
        }
        //=============================Code added by Balaji.TJ=================

        public IList<FacilityLibrary> GetFacilitylist()
        {
            IList<FacilityLibrary> ilstFacilityName = new List<FacilityLibrary>();
            FacilityLibrary objFac = new FacilityLibrary();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sql = mySession.CreateSQLQuery("Select f.* from facility_library f").AddEntity("f", typeof(FacilityLibrary));
                ilstFacilityName = sql.List<FacilityLibrary>();
                mySession.Close();
            }
            return ilstFacilityName;
        }

        public IList<FacilityLibrary> GetFacilitybyFacility_shortname(string FacilityshortName)
        {
            FacilityLibrary objFac = new FacilityLibrary();
            IList<FacilityLibrary> FacilityList = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Short_Name", FacilityshortName));
                FacilityList = crit.List<FacilityLibrary>();
                mySession.Close();
            }
            return FacilityList;
        }

        public IList<FacilityLibrary> GetFacilitybyFacilityname(string FacilityName)
        {
            IList<FacilityLibrary> ilstFacilityName = new List<FacilityLibrary>();
            FacilityLibrary objFac = new FacilityLibrary();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = mySession.GetNamedQuery("Get.Shortname.From.FacilityLibrary");
                query.SetString(0, FacilityName);
                ArrayList aryPaid = new ArrayList();
                aryPaid = new ArrayList(query.List());
                for (int i = 0; i < aryPaid.Count; i++)
                {
                    objFac = new FacilityLibrary();
                    if (aryPaid.Count != 0)
                    {
                        objFac.Fac_Name = aryPaid[i].ToString();
                    }
                    ilstFacilityName.Add(objFac);
                }
                mySession.Close();
            }
            return ilstFacilityName;
        }
        public IList<FacilityLibrary> GetFacilityListByFacilityName(string FacilityName)
        {
            IList<FacilityLibrary> FacilityList = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Fac_Name", FacilityName));

                FacilityList = crit.List<FacilityLibrary>();
                mySession.Close();
            }
            return FacilityList;
        }
        public IList<FacilityLibrary> GetFacilityInformationByFacilityType(string FacilityType)
        {
            IList<FacilityLibrary> FacilityList = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery FacCriteria = mySession.CreateSQLQuery("Select * from Facility_Library f where f.Facility_Name like '%" + FacilityType + "'").AddEntity("f", typeof(FacilityLibrary));
                FacilityList = FacCriteria.List<FacilityLibrary>();
                mySession.Close();
            }
            return FacilityList;

        }
        public IList<FacilityLibrary> GetFacilityInformationByFacilityTypeNotLike(string FacilityType)
        {
            IList<FacilityLibrary> FacilityList = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery FacCriteria = mySession.CreateSQLQuery("Select * from Facility_Library f where f.Facility_Name not like '%" + FacilityType + "'").AddEntity("f", typeof(FacilityLibrary));
                FacilityList = FacCriteria.List<FacilityLibrary>();
                mySession.Close();
            }
            return FacilityList;
        }
        public OfficeManagerDTO GetFacilityListAndWorkflowList(string FacilityName)
        {
            OfficeManagerDTO OfficeManagerDTOList = new OfficeManagerDTO();

            //IList<FacilityLibrary> FacList=new List<FacilityLibrary>();
            //FacList = GetAll();


            //if(FacList.Count>0)
            //{
            //    OfficeManagerDTOList.lstFacilityLibrary = FacList;
            //}

            IList<WorkFlow> WFMapList;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                /* ICriteria criteria = iMySession.CreateCriteria(typeof(WorkFlow)).Add(Expression.Eq("Fac_Name", FacilityName));
                 WFMapList = criteria.List<WorkFlow>();*/
                IList<WorkFlowTypeMaster> WFTypeMasterList = new List<WorkFlowTypeMaster>();
                IList<WorkFlowTypeMaster> WFTypeMasterListDefault;
                string WorkFlowType = string.Empty;
                IList<FacilityLibrary> FacList;
                ICriteria criteriaFacType = iMySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Fac_Name", FacilityName));
                FacList = criteriaFacType.List<FacilityLibrary>();

                if (FacList.Count > 0)
                {
                    ICriteria criteriaWFType = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", FacilityName)).Add(Expression.Eq("Legal_Org", FacList[0].Legal_Org));
                    WFTypeMasterList = criteriaWFType.List<WorkFlowTypeMaster>();
                }

                if (WFTypeMasterList.Count == 0)
                {
                    ICriteria criteria1 = iMySession.CreateCriteria(typeof(WorkFlowTypeMaster)).Add(Expression.Eq("Facility_Name", "DEFAULT")).Add(Expression.Eq("Legal_Org", FacList[0].Legal_Org));
                    WFTypeMasterListDefault = criteria1.List<WorkFlowTypeMaster>();
                    if (WFTypeMasterListDefault.Count > 0)
                        WorkFlowType = WFTypeMasterListDefault[0].Workflow_Type;
                }
                else
                {
                    WorkFlowType = WFTypeMasterList[0].Workflow_Type;
                }

                if (WorkFlowType != string.Empty)
                {
                    ICriteria criteria = iMySession.CreateCriteria(typeof(WorkFlow)).Add(Expression.Eq("Workflow_Type", WorkFlowType));

                    WFMapList = criteria.List<WorkFlow>();
                    if (WFMapList != null && WFMapList.Count > 0)
                    {
                        OfficeManagerDTOList.listWorkflow = WFMapList;
                    }
                }
                iMySession.Close();
            }
            /*if (WFMapList.Count > 0)
            {
                OfficeManagerDTOList.listWorkflow = WFMapList;
            }*/
            return OfficeManagerDTOList;
        }
        public IList<FacilityLibrary> GetFacilityNameByFacilityType()
        {
            IList<FacilityLibrary> list = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Fac_Type", "HOME_VISIT"));
                list = criteria.List<FacilityLibrary>();
                mySession.Close();
            }
            return list;
        }

        public IList<FacilityLibrary> GetAncillaryFacilityList()
        {
            IList<FacilityLibrary> list = new List<FacilityLibrary>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = mySession.CreateCriteria(typeof(FacilityLibrary)).Add(Expression.Eq("Is_Ancillary", "Y"));
                list = criteria.List<FacilityLibrary>();
                mySession.Close();
            }
            return list;
        }
        #endregion
    }
}
