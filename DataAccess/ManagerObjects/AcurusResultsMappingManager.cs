using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAcurusResultsMappingManager : IManagerBase<AcurusResultsMapping, string>
    {
        IList<AcurusResultsMapping> GetFlowsheetMapResults(string AcurusDesc);
        IList<AcurusResultsMapping> GetAcurusResultsMappingListForResultMaster(ulong ulLabID, string sResultCode);
        ArrayList GetAcurusResultMappingListForMRE(string sOrderCode, string sGender, int iAge, int iLabID);
    }
    public partial class AcurusResultsMappingManager : ManagerBase<AcurusResultsMapping, string>, IAcurusResultsMappingManager
    {
        #region Constructors

        public AcurusResultsMappingManager()
            : base()
        {

        }
        public AcurusResultsMappingManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Methods
        public IList<AcurusResultsMapping> GetFlowsheetMapResults(string searchCriteria)
        {
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                string keyWord = searchCriteria.Trim() + "%";

                var query = @"SELECT  P.*
                              FROM ACURUS_RESULTS_MAPPING P
                              WHERE P.ACURUS_RESULT_DESCRIPTION LIKE (:KEY_WORD)
                              GROUP BY P.ACURUS_RESULT_DESCRIPTION,
                                       P.ACURUS_RESULT_CODE";

                var sqlQuery = iMySession.CreateSQLQuery(query)
                                         .AddEntity("P", typeof(AcurusResultsMapping));

                sqlQuery.SetParameter("KEY_WORD", keyWord);

                var lstAcurusResultsMapping = sqlQuery.List<AcurusResultsMapping>();

                iMySession.Close();

                return lstAcurusResultsMapping;

            }

        }
        public IList<AcurusResultsMapping> GetAcurusResultsMappingListForResultMaster(ulong ulLabID, string sResultCode)
        {
            IList<AcurusResultsMapping> AcurusResultList = new List<AcurusResultsMapping>();
            using (ISession iMySessionAcurusResultMappingResult = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISession iMySessionAcurusResultMappingResult = NHibernateSessionManager.Instance.CreateISession();
                ISQLQuery sql = iMySessionAcurusResultMappingResult.CreateSQLQuery("Select * FROM Acurus_Results_Mapping  where Lab_ID='" + ulLabID + "' and Lab_Result_Code='" + sResultCode + "' order by Sort_Order asc").AddEntity(typeof(AcurusResultsMapping));
                if (sql.List<AcurusResultsMapping>().Count != 0)
                {
                    AcurusResultList = sql.List<AcurusResultsMapping>();
                }
                iMySessionAcurusResultMappingResult.Close();
            }
            return AcurusResultList;
        }
        public IList<AcurusResultsMapping> GetAcurusResultsMappingList(string sResultDescription)
        {
            IList<AcurusResultsMapping> AcurusResultList = new List<AcurusResultsMapping>();
            using (ISession iMySessionAcurusResultMappingList = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISession iMySessionAcurusResultMappingList= NHibernateSessionManager.Instance.CreateISession();
                ISQLQuery sql = iMySessionAcurusResultMappingList.CreateSQLQuery("Select * FROM Acurus_Results_Mapping  where Acurus_Result_Description in (" + sResultDescription + ") order by Sort_Order asc").AddEntity(typeof(AcurusResultsMapping));
                if (sql.List<AcurusResultsMapping>().Count != 0)
                {
                    AcurusResultList = sql.List<AcurusResultsMapping>();
                }
                iMySessionAcurusResultMappingList.Close();
            }
            return AcurusResultList;
        }



        public ArrayList GetAcurusResultMappingListForMRE(string sOrderCode, string sGender, int iAge, int iLabID)
        {
            ArrayList arylist = new ArrayList();
            using (ISession iMySessionAcurusResultMappingMRE = NHibernateSessionManager.Instance.CreateISession())
            {
                //ISession iMySessionAcurusResultMappingMRE = NHibernateSessionManager.Instance.CreateISession();
                ArrayList arylstAcurusResultsList = new ArrayList();

                ////for (int i = 0; i < sOrderCode.Length; i++)
                ////{
                IQuery query1 = iMySessionAcurusResultMappingMRE.GetNamedQuery("Get.Acurus.Results.Mapping");
                query1.SetString(0, sGender.ToUpper().ToString());
                query1.SetParameter(1, iAge);
                query1.SetString(2, sGender.ToUpper().ToString());
                query1.SetParameter(3, iAge);
                query1.SetString(4, sOrderCode);
                query1.SetParameter(5, iLabID);
                arylist = new ArrayList(query1.List());
                //if (arylist.Count>0)
                arylstAcurusResultsList.AddRange(arylist);
                // }


                //if (arylstAcurusResultsList.Count > 1)
                //{
                //    object[] objlst = (object[])arylstAcurusResultsList[0];
                //    if (objlst[0].ToString() == "" && objlst[1].ToString() == "" && objlst[2].ToString() == "" && objlst[3].ToString() == "")
                //    {
                //        arylstAcurusResultsList.Clear();
                //    }
                //}
                iMySessionAcurusResultMappingMRE.Close();
            }
            return arylist;
        }


        #endregion
    }
}
