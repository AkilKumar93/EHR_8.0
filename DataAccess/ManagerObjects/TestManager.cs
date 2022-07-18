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
    public partial interface ITestManager : IManagerBase<Test, ulong>
    {
        IList<FillTestScreen> AppendTest(IList<Test> TestList, string MACAddress, IList<FillTestScreen> FillTestList);
        IList<FillTestScreen> UpdateTest(IList<Test> TestList, string MACAddress, IList<FillTestScreen> FillTestList);
        IList<Test> GetTestList(ulong ulEncID);
        int GetTestEntries(string Category, ulong ulEncID);
        IList<Test> GetTestOtherThanNotExamined(ulong EncounterId);

    }


    public partial class TestManager : ManagerBase<Test, ulong>, ITestManager
    {
        #region Constructors

        public TestManager()
            : base()
        {

        }
        public TestManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods
        public IList<FillTestScreen> GetFillTest(IList<FillTestScreen> FillTestList, IList<Test> TestList)
        {
            if (FillTestList != null && FillTestList.Count > 0)
            {
                for (int i = 0; i < TestList.Count; i++)
                {
                    FillTestList[i].TestID = TestList[i].Id;
                    FillTestList[i].Version = TestList[i].Version;
                }
            }
            return FillTestList;
        }

        public IList<FillTestScreen> AppendTest(IList<Test> TestList, string MACAddress, IList<FillTestScreen> FillTestList)
        {
            IList<FillTestScreen> testScreenList = new List<FillTestScreen>();

            IList<Test> TestListupdate = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref TestList, ref TestListupdate, null, MACAddress, true, false, TestList[0].Encounter_ID, string.Empty);
            TestLookupManager testMngr = new TestLookupManager();
            if (TestList != null && TestList.Count > 0)
            {
                testScreenList = GetFillTest(FillTestList, TestList); 
            }

            return testScreenList;
        }
        public IList<FillTestScreen> UpdateTest(IList<Test> TestList, string MACAddress, IList<FillTestScreen> FillTestList)
        {
            IList<FillTestScreen> testScreenList = new List<FillTestScreen>();

            IList<Test> addList = null;

            SaveUpdateDelete_DBAndXML_WithTransaction(ref addList, ref TestList, null, MACAddress, true, false, TestList[0].Encounter_ID, string.Empty);

            TestLookupManager testMngr = new TestLookupManager();
            if (TestList != null && TestList.Count > 0)
            {
                testScreenList = GetFillTest(FillTestList, TestList);
            }
            return testScreenList;
        }
        public IList<Test> GetTestList(ulong ulEncID)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            //ICriteria crit;
            IList<Test> listTest = new List<Test>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Test)).Add(Expression.Eq("Encounter_ID", ulEncID));
                listTest = crit.List<Test>();
                iMySession.Close();
            }
            return listTest;
        }

        public int GetTestEntries(string Category, ulong ulEncID)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<Test> listTest = new List<Test>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit;
                crit = iMySession.CreateCriteria(typeof(Test)).Add(Expression.Eq("Encounter_ID", ulEncID)).Add(Expression.Eq("Category", Category));
                listTest = crit.List<Test>();
                iMySession.Close();
            }
            return listTest.Count;
        }
        public IList<Test> GetTestOtherThanNotExamined(ulong EncounterId)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ArrayList arrList = null;
            IList<Test> testList = new List<Test>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Test.GetTestExceptNotExamined");
                query.SetInt32(0, Convert.ToInt32(EncounterId)); ;

                arrList = new ArrayList(query.List());

                Test tx = null;

                //added by Ginu on 2-Aug-2010
                if (arrList != null)
                {
                    for (int i = 0; i < arrList.Count; i++)
                    {
                        tx = new Test();
                        object[] obj = (object[])arrList[i];


                        tx.Id = Convert.ToUInt64(obj[0]);
                        tx.Question_Name = obj[1].ToString();
                        tx.Created_Date_And_Time = Convert.ToDateTime(obj[2]);
                        testList.Add(tx);
                    }
                }
                iMySession.Close();
            }
            return testList;
        }

        #endregion
    }
}
