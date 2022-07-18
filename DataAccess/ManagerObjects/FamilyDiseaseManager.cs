using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IFamilyDiseaseManager : IManagerBase<FamilyDisease, uint>
    {
        IList<FamilyDisease> GetFamilyDiseaseByDiseaseID(ulong DiseaseID);
        int SaveFamilyDiseaseList(IList<FamilyDisease> famdis, ISession mySession, string macAddress);
        int DeleteFamilyDiseaseList(int familyDisID, ISession mySession, string macAddress);
        int UpdateFamilyDiseaseList(IList<FamilyDisease> InsertFamilyDiseaseLst, IList<FamilyDisease> DeleteFamilyDiseaseLst, ISession mySession, string macAddress);
    }
    public class FamilyDiseaseManager : ManagerBase<FamilyDisease, uint>, IFamilyDiseaseManager
    {
        #region Constructors

        public FamilyDiseaseManager()
            : base()
        {

        }
        public FamilyDiseaseManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Method

        
        public IList<FamilyDisease> GetFamilyDiseaseByDiseaseID(ulong DiseaseID)
        {
            IList<FamilyDisease> ilist = new List<FamilyDisease>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(FamilyDisease)).Add(Expression.Eq("Family_History_ID", Convert.ToInt32(DiseaseID)));

                ilist = criteria.List<FamilyDisease>();
                //return criteria.List<FamilyDisease>();
                iMySession.Close();
            }
            return ilist;

        }

        public int SaveFamilyDiseaseList(IList<FamilyDisease> famdis, ISession mySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
           //return SaveUpdateDeleteWithoutTransaction(ref famdis, null, null, mySession, macAddress);
            IList<FamilyDisease> Updatefamdisnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref famdis, ref Updatefamdisnull, null, mySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
        }
        public int DeleteFamilyDiseaseList(int familyDisID, ISession mySession, string macAddress)
        {
            IList<FamilyDisease> famDis = new List<FamilyDisease>();
            IList<FamilyDisease> famSave = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(FamilyDisease)).Add(Expression.Eq("Family_History_ID", familyDisID));
                famDis = crt.List<FamilyDisease>();               
                iMySession.Close();
            }
            //return SaveUpdateDeleteWithoutTransaction(ref famSave, null, famDis, mySession,macAddress);
            IList<FamilyDisease> Updatefamdisnull = null;
            GenerateXml XMLObj = new GenerateXml();

            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref famSave, ref Updatefamdisnull, famDis, mySession, macAddress, false, false, 0, string.Empty, ref XMLObj);
           
        }
        public int UpdateFamilyDiseaseList(IList<FamilyDisease> InsertFamilyDiseaseLst, IList<FamilyDisease> DeleteFamilyDiseaseLst, ISession mySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            IList<FamilyDisease> Updatefamdisnull = null;
            if (InsertFamilyDiseaseLst.Count > 0 || DeleteFamilyDiseaseLst.Count > 0)
            {
                //iResult = SaveUpdateDeleteWithoutTransaction(ref InsertFamilyDiseaseLst, null, DeleteFamilyDiseaseLst, mySession, macAddress);
                iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref InsertFamilyDiseaseLst, ref Updatefamdisnull, DeleteFamilyDiseaseLst, mySession, macAddress, false, false, 0, string.Empty, ref XMLObj);
            }
            return iResult;
        }

        #endregion

    }
}
