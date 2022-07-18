using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface ICreateExceptionManager : IManagerBase<CreateException, ulong>
    {
        //IList<CreateException> GetAllExceptionDetailsByDesc(ulong EncounterID, string OrderBy);
        CodingExceptionDTO GetAllExceptionDetailsByDesc1(ulong EncounterID, string OrderBy, int PageNo, int MaxResultPerPage, ulong humanid);
        IList<CreateException> GetExceptionByUniqueID(ulong ExceptionID);
        //IList<ExceptionDTO> GetException(ulong Enconter_id, string Created_date_time, int Pageno, int MaxResults);
        CodingExceptionDTO AddCreateExceptionDetails(CreateException objCreateException, int Pageno, int Maxresult, string MacAddress);
        CodingExceptionDTO UpdateExceptionDetails(CreateException objCreateException, int Pageno, int Maxresult, string MacAddress);
        CodingExceptionDTO DeleteException(ulong ExceptionID, int Pageno, int Maxresult, string MacAddress, string sModified_By, DateTime dtModified_Date_And_Time);
        //void BatchUpdateException(IList<CreateException> exceptionlist);
        IList<CreateException> GetReviewExceptionDetails(ulong EncounterID);
        bool CheckFeedBack(ulong EncounterID);
        int CheckPhysicianAssistant(ulong EncounterID);
        CodingExceptionDTO GetAllExceptionDetailsByDescAndGetEncounterDetails(ulong EncounterID, int PageNo, int MaxResultPerPage, ulong humanid, ulong PhysicianID);

    }
    public partial class CreateExceptionManager : ManagerBase<CreateException, ulong>, ICreateExceptionManager
    {
        #region Constructor
        public CreateExceptionManager()
            : base()
        {
        }

        public CreateExceptionManager(INHibernateSession session)
            : base(session)
        {
        }
        #endregion

        #region Methods

        public CodingExceptionDTO GetAllExceptionDetailsByDesc1(ulong EncounterID, string OrderBy, int PageNo, int MaxResultPerPage, ulong humanid)
        {
            ArrayList Exceptlist = null;
            CodingExceptionDTO objdto = new CodingExceptionDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISQLQuery qur = iMySession.CreateSQLQuery("Select Concat(Last_Name, ',',First_Name,' ',MI) as name from human where Human_ID=" + humanid);
                //Exceptlist = new ArrayList(qur.List());
                //if (Exceptlist != null && Exceptlist.Count > 0)
                //{
                //    objdto.HumanName = Exceptlist[0].ToString();
                //}
                //ICriteria criteriaEnc = session.GetISession().CreateCriteria(typeof(Encounter)).Add(Expression.Eq("Id", EncounterID));
                //if (criteriaEnc.List<Encounter>().Count > 0)
                //{
                //    objdto.objEncounter = criteriaEnc.List<Encounter>()[0];
                //}

                //if (objdto.objEncounter != null)
                //{
                //    ICriteria criteriaHuman = session.GetISession().CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", objdto.objEncounter.Human_ID));
                //    if (criteriaHuman.List<Human>().Count > 0)
                //    {
                //        objdto.objHuman = criteriaHuman.List<Human>()[0];
                //    }
                //    ICriteria phy = session.GetISession().CreateCriteria(typeof(PhysicianLibrary)).Add(Expression.Eq("Id",Convert.ToUInt64(objdto.objEncounter.Encounter_Provider_ID)));
                //    if (phy.List<PhysicianLibrary>().Count > 0)
                //    {
                //        objdto.objPhysician = phy.List<PhysicianLibrary>()[0];
                //    }
                //}
                IList<CreateException> getexceptionlist = new List<CreateException>();
                IQuery query1 = iMySession.GetNamedQuery("Get.GetExceptionCount");
                query1.SetInt32(0, Convert.ToInt32(EncounterID));
                if (query1.List().Count > 0)//added by vijayan
                    objdto.ExceptionCount = Convert.ToInt32(query1.List()[0]);

                IQuery query = iMySession.GetNamedQuery("Fill.Exception.WithLimit");
                query.SetInt32(0, Convert.ToInt32(EncounterID));
                PageNo = PageNo - 1;
                query.SetInt32(1, PageNo * MaxResultPerPage);
                query.SetInt32(2, MaxResultPerPage);
                // query.SetString(1, OrderBy);

                Exceptlist = new ArrayList(query.List());
                if (Exceptlist.Count > 0)
                {
                    foreach (object[] obj in Exceptlist)
                    {
                        CreateException objexception = new CreateException();
                        objexception.Issues = obj[0].ToString();
                        objexception.Id = Convert.ToUInt64(obj[1]);
                        objexception.FeedBack = obj[2].ToString();
                        objexception.Id = Convert.ToUInt64(obj[0]);
                        objexception.Enounter_ID = Convert.ToUInt64(obj[1]);
                        objexception.Human_ID = Convert.ToUInt64(obj[2]);
                        objexception.Physician_ID = Convert.ToUInt64(obj[3]);
                        objexception.Issues = obj[4].ToString();
                        objexception.FeedBack = obj[5].ToString();
                        objexception.Created_By = obj[6].ToString();
                        objexception.Created_Date_And_Time = Convert.ToDateTime(obj[7]);
                        objexception.Modified_By = obj[8].ToString();
                        objexception.Modified_Date_And_Time = Convert.ToDateTime(obj[9]);
                        objexception.FeedBack_ProvidedBy = obj[10].ToString();
                        objexception.Version = Convert.ToInt32(obj[11]);

                        getexceptionlist.Add(objexception);
                    }
                    objdto.Exception = getexceptionlist;
                }
                iMySession.Close();
            }
            return objdto;
        }
        ////public IList<CreateException> GetAllExceptionDetailsByDesc(ulong EncounterID, string OrderBy)
        //{
        //    ICriteria criteria = session.GetISession().CreateCriteria(typeof(CreateException)).Add(Expression.Eq("Enounter_ID", EncounterID)).AddOrder(Order.Desc(OrderBy));
        //    return criteria.List<CreateException>();

        //}
        public IList<CreateException> GetReviewExceptionDetails(ulong EncounterID)
        {
            IList<CreateException> list =new List<CreateException>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(CreateException)).Add(Expression.Eq("Enounter_ID", EncounterID));
                list = criteria.List<CreateException>();
                iMySession.Close();
            }
            return list;
        }
        public IList<CreateException> GetExceptionByUniqueID(ulong ExceptionID)
        {
              IList<CreateException> list =new List<CreateException>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
                  ICriteria criteria = session.GetISession().CreateCriteria(typeof(CreateException)).Add(Expression.Eq("Id", ExceptionID));
                  list = criteria.List<CreateException>();
                  iMySession.Close();
              }
            
            return list;

        }
        //public void BatchUpdateException(IList<CreateException> exceptionlist)
        //{
        //    Update(exceptionlist);
        //}
        public CodingExceptionDTO AddCreateExceptionDetails(CreateException objException, int Pageno, int Maxresult, string MacAddress)
        {
            IList<CreateException> createExceptionList = new List<CreateException>();
            IList<CreateException> createExceptionListnull = new List<CreateException>();
            createExceptionList.Add(objException);

            //SaveUpdateDeleteWithTransaction(ref createExceptionList, null, null, MacAddress);
            if (createExceptionList.Count>0)
                SaveUpdateDelete_DBAndXML_WithTransaction(ref createExceptionList, ref createExceptionListnull, null, MacAddress, false, true, 0, string.Empty);
            return GetAllExceptionDetailsByDesc1(objException.Enounter_ID, "Created_Date_And_Time", Pageno, Maxresult,objException.Human_ID);

        }
        public CodingExceptionDTO UpdateExceptionDetails(CreateException objException, int Pageno, int Maxresult, string MacAddress)
        {
            IList<CreateException> createExceptionList = new List<CreateException>();
            createExceptionList.Add(objException);
            IList<CreateException> obList = null;

            //SaveUpdateDeleteWithTransaction(ref obList, createExceptionList, null, MacAddress);
            if (createExceptionList.Count > 0)
                SaveUpdateDelete_DBAndXML_WithTransaction(ref obList, ref createExceptionList, null, MacAddress, false, true, 0, string.Empty);
            return GetAllExceptionDetailsByDesc1(objException.Enounter_ID, "Modified_Date_And_Time", Pageno, Maxresult,objException.Human_ID);
        }
        public CodingExceptionDTO DeleteException(ulong ExceptionID, int Pageno, int Maxresult, string MacAddress, string sModified_By, DateTime dtModified_Date_And_Time)
        {
            CreateException theUser = (CreateException)session.GetISession().Load(typeof(CreateException), ExceptionID);
            theUser.Modified_By = sModified_By;
            theUser.Modified_Date_And_Time = dtModified_Date_And_Time;
            IList<CreateException> obList = new List<CreateException>();
            obList.Add(theUser);
            IList<CreateException> saveList = null;
           // SaveUpdateDeleteWithTransaction(ref saveList, null, obList, MacAddress);
            if (obList.Count > 0)
                SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref saveList, obList, MacAddress, false, true, 0, string.Empty);
            return GetAllExceptionDetailsByDesc1(theUser.Enounter_ID, "Created_Date_And_Time", Pageno, Maxresult,theUser.Human_ID);
        }

        public bool CheckFeedBack(ulong EncounterID)
        {
            ArrayList ExceptFeedBacklist = null;

            IQuery query3 = session.GetISession().GetNamedQuery("GetCheckFeedBack");
            query3.SetInt32(0, Convert.ToInt32(EncounterID));
            ExceptFeedBacklist = new ArrayList(query3.List());
            for (int i = 0; i < ExceptFeedBacklist.Count; i++)
            {
                if (ExceptFeedBacklist[i].ToString().Trim() == string.Empty)
                {
                    return false;
                }
            }
            return true;


        }



        public int CheckPhysicianAssistant(ulong EncounterID)
        {
            int ReturnValue;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Encounter)).Add(Expression.Eq("Id", EncounterID));
                ulong ReturnID = Convert.ToUInt64(criteria.List<Encounter>()[0].Encounter_Provider_ID);
                ICriteria criteria1 = iMySession.CreateCriteria(typeof(PhysicianLibrary)).Add(Expression.Eq("Id", ReturnID));
                string Physician_Type = Convert.ToString(criteria1.List<PhysicianLibrary>()[0].PhyType);
                if (Physician_Type == "PHYSICIAN ASSISTANT")
                    ReturnValue = 1;
                else
                    ReturnValue = 0;
                iMySession.Close();
            }
            return ReturnValue;
        }

        public CodingExceptionDTO GetAllExceptionDetailsByDescAndGetEncounterDetails(ulong EncounterID, int PageNo, int MaxResultPerPage, ulong humanid, ulong PhysicianID)
        {
            ArrayList Exceptlist = null;
            CodingExceptionDTO objdto = new CodingExceptionDTO();
           // ExceptionDTO objdto = new ExceptionDTO();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISQLQuery qur = iMySession.CreateSQLQuery("Select Concat(Last_Name, ',',First_Name,' ',MI) as name from human where Human_ID=" + humanid);
                //Exceptlist = new ArrayList(qur.List());
                //if (Exceptlist != null && Exceptlist.Count > 0)
                //{
                //    objdto.HumanName = Exceptlist[0].ToString();
                //}
              
                IList<CreateException> getexceptionlist = new List<CreateException>();
                IQuery query1 = iMySession.GetNamedQuery("Get.GetExceptionCount");
                query1.SetInt32(0, Convert.ToInt32(EncounterID));
                if (query1.List().Count > 0)//added by vijayan
                    objdto.ExceptionCount = Convert.ToInt32(query1.List()[0]);

                IQuery query = iMySession.GetNamedQuery("Fill.Exception.WithLimit");
                query.SetInt32(0, Convert.ToInt32(EncounterID));
                PageNo = PageNo - 1;
                query.SetInt32(1, PageNo * MaxResultPerPage);
                query.SetInt32(2, MaxResultPerPage);
             

                Exceptlist = new ArrayList(query.List());
                if (Exceptlist.Count > 0)
                {
                    foreach (object[] obj in Exceptlist)
                    {
                        CreateException objexception = new CreateException();
                        objexception.Issues = obj[0].ToString();
                        objexception.Id = Convert.ToUInt64(obj[1]);
                        objexception.FeedBack = obj[2].ToString();
                        objexception.Id = Convert.ToUInt64(obj[0]);
                        objexception.Enounter_ID = Convert.ToUInt64(obj[1]);
                        objexception.Human_ID = Convert.ToUInt64(obj[2]);
                        objexception.Physician_ID = Convert.ToUInt64(obj[3]);
                        objexception.Issues = obj[4].ToString();
                        objexception.FeedBack = obj[5].ToString();
                        objexception.Created_By = obj[6].ToString();
                        objexception.Created_Date_And_Time = Convert.ToDateTime(obj[7]);
                        objexception.Modified_By = obj[8].ToString();
                        objexception.Modified_Date_And_Time = Convert.ToDateTime(obj[9]);
                        objexception.FeedBack_ProvidedBy = obj[10].ToString();
                        objexception.Version = Convert.ToInt32(obj[11]);

                        getexceptionlist.Add(objexception);
                    }
                    objdto.Exception = getexceptionlist;
                }
                if (objdto != null && PhysicianID !=0)
                {                    
                    ICriteria criteria = iMySession.CreateCriteria(typeof(PhysicianLibrary)).Add(Expression.Eq("Id", PhysicianID));
                    objdto.PhysicianLibraryList = criteria.List<PhysicianLibrary>();
                }
                iMySession.Close();
            }
            return objdto;
        }
        #endregion
    }
}

