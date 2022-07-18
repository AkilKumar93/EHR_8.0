using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IFamilyDiseaseMasterManager : IManagerBase<FamilyDiseaseMaster, uint>
    {
        IList<FamilyDiseaseMaster> GetFamilyDiseaseByDiseaseID(ulong DiseaseID);
        int SaveFamilyDiseaseList(IList<FamilyDiseaseMaster> famdis, ISession mySession, string macAddress);
        int DeleteFamilyDiseaseList(int familyDisID, ISession mySession, string macAddress);
        int UpdateFamilyDiseaseList(IList<FamilyDiseaseMaster> InsertFamilyDiseaseLst, IList<FamilyDiseaseMaster> DeleteFamilyDiseaseLst, ISession mySession, string macAddress);
    }
    public class FamilyDiseaseMasterManager : ManagerBase<FamilyDiseaseMaster, uint>, IFamilyDiseaseMasterManager
    {
        #region Constructors

        public FamilyDiseaseMasterManager()
            : base()
        {

        }
        public FamilyDiseaseMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Method


        public IList<FamilyDiseaseMaster> GetFamilyDiseaseByDiseaseID(ulong DiseaseID)
        {
            IList<FamilyDiseaseMaster> ilist = new List<FamilyDiseaseMaster>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(FamilyDiseaseMaster)).Add(Expression.Eq("Family_History_ID", Convert.ToInt32(DiseaseID)));

                ilist = criteria.List<FamilyDiseaseMaster>();
                //return criteria.List<FamilyDisease>();
                iMySession.Close();
            }
            return ilist;

        }

        public int SaveFamilyDiseaseList(IList<FamilyDiseaseMaster> famdis, ISession mySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
           //return SaveUpdateDeleteWithoutTransaction(ref famdis, null, null, mySession, macAddress);
            IList<FamilyDiseaseMaster> Updatefamdisnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref famdis, ref Updatefamdisnull, null, mySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
        }
        public int DeleteFamilyDiseaseList(int familyDisID, ISession mySession, string macAddress)
        {
            IList<FamilyDiseaseMaster> famDis = new List<FamilyDiseaseMaster>();
            IList<FamilyDiseaseMaster> famSave = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(FamilyDiseaseMaster)).Add(Expression.Eq("Family_History_ID", familyDisID));
                famDis = crt.List<FamilyDiseaseMaster>();               
                iMySession.Close();
            }
            //return SaveUpdateDeleteWithoutTransaction(ref famSave, null, famDis, mySession,macAddress);
            IList<FamilyDiseaseMaster> Updatefamdisnull = null;
            GenerateXml XMLObj = new GenerateXml();

            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref famSave, ref Updatefamdisnull, famDis, mySession, macAddress, false, false, 0, string.Empty, ref XMLObj);
           
        }
        public int UpdateFamilyDiseaseList(IList<FamilyDiseaseMaster> InsertFamilyDiseaseLst, IList<FamilyDiseaseMaster> DeleteFamilyDiseaseLst, ISession mySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            IList<FamilyDiseaseMaster> Updatefamdisnull = null;
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
