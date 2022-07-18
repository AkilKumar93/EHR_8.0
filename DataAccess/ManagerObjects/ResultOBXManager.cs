using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.IO;
using System.Runtime.Serialization;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IResultOBXManager : IManagerBase<ResultOBX, ulong>
    {
        Stream GetLoincValuesForLongName(string strLoincName, int pageNumber, int maxResultPerPage);
        int SaveResultOBX(ref IList<ResultOBX> resultOBXList, ISession MySession, string macAddress);
        IList<ResultOBX> GetResultByMasterID(ulong result_master_id);
        int DeleteResultOBX(IList<ResultOBX> resultOBXList, ISession MySession, string macAddress);
        int UpdateResultOBX(ref IList<ResultOBX> SaveresultOBXList,IList<ResultOBX> UpdateresultOBXList,IList<ResultOBX> DeleteresultOBXList, ISession MySession, string macAddress);
        IList<ResultOBX> GetResultForRecommendedMaterials(ulong humanID);
        void SaveResultOBXforSummary(IList<ResultOBX> lstresultobx);
    }

    public partial class ResultOBXManager : ManagerBase<ResultOBX, ulong>, IResultOBXManager
    {
        #region Constructors


        public ResultOBXManager()
            : base()
        {

        }
        public ResultOBXManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region IResultOBXManager Members

        public int SaveResultOBX(ref IList<ResultOBX> resultOBXList, ISession MySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            //iResult = SaveUpdateDeleteWithoutTransaction(ref resultOBXList, null, null, MySession, macAddress);
            IList<ResultOBX> ResultOBXnull = null;
            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultOBXList, ref ResultOBXnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            return iResult;
        }

        public IList<ResultOBX> GetResultByMasterID(ulong result_master_id)
        {
            ICriteria crit = session.GetISession().CreateCriteria(typeof(ResultOBX)).Add(Expression.Eq("Result_Master_ID", result_master_id));
            return crit.List<ResultOBX>();
        }

        public int DeleteResultOBX(IList<ResultOBX> resultOBXList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultOBX> SaveOBX = new List<ResultOBX>();
            //return SaveUpdateDeleteWithoutTransaction(ref SaveOBX, null, resultOBXList, MySession, macAddress);
            IList<ResultOBX> ResultOBXnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveOBX, ref ResultOBXnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        public int SaveResultOBX(IList<ResultOBX> resultOBXList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            //return SaveUpdateDeleteWithoutTransaction(ref resultOBXList, null, null, MySession, macAddress);
            IList<ResultOBX> ResultOBXnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultOBXList, ref ResultOBXnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            
        }

        public int UpdateResultOBX(ref IList<ResultOBX> SaveresultOBXList, IList<ResultOBX> UpdateresultOBXList, IList<ResultOBX> DeleteresultOBXList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();            
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveresultOBXList, ref UpdateresultOBXList, DeleteresultOBXList, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref SaveresultOBXList, UpdateresultOBXList, DeleteresultOBXList, MySession, macAddress);
        }

        #endregion

        public IList<ResultOBX> GetResultForRecommendedMaterials(ulong ulHumanId)
        {
            IList<ResultOBX> resultOBXLst = new List<ResultOBX>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                resultOBXLst = iMySession.CreateSQLQuery("select o.* from result_obx o inner join result_master m on (o.Result_Master_ID=m.Result_Master_ID) where  o.obx_observation_text <> '' and o.obx_loinc_identifier <> '' and m.Matching_Patient_Id= '" + ulHumanId + "' order by Created_Date_And_Time").AddEntity("o", typeof(ResultOBX)).List<ResultOBX>();
                iMySession.Close();
            }

            return resultOBXLst;
        }



        public Stream GetLoincValuesForLongName(string strLoincName, int pageNumber, int maxResultPerPage)
        {
            var stream = new MemoryStream();
            var serializer = new NetDataContractSerializer();
            IList<ResultOBX> loinc = new List<ResultOBX>();
            pageNumber = pageNumber - 1;

            string strLoinc = "%" + strLoincName + "%";
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt =iMySession.CreateCriteria(typeof(ResultOBX)).Add(Expression.Like("OBX_Observation_Text", strLoinc));
                 loinc = GetByCriteria(maxResultPerPage, pageNumber, crt);
                 iMySession.Close();
            }
            Hashtable loincResult = new Hashtable();
            loincResult.Add("LoincList", loinc);

            if (pageNumber == 0)
                loincResult.Add("TotalCount", loinc.Count);

            serializer.WriteObject(stream, loincResult);
            stream.Seek(0L, SeekOrigin.Begin);

            return stream;
        }

        public void SaveResultOBXforSummary(IList<ResultOBX> lstresultobx)
        {
            GenerateXml XMLObj = new GenerateXml();
            //SaveUpdateDeleteWithTransaction(ref lstresultobx, null, null, string.Empty);
            IList<ResultOBX> ResultOBXnull = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref lstresultobx, ref ResultOBXnull, null, string.Empty, false, true, 0, string.Empty);
           
        }

    }
}
