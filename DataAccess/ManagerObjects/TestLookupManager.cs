using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface ITestLookupManager : IManagerBase<Test_Lookup, ulong>
    {
        IList<FillTestScreen> GetTestLookupListFromServer(string Category, string UserName, ulong ulEncID);
        IList<FillTestScreen> GetTestLookupListFromLocal(string Category, string UserName, ulong ulEncID, string sTestOrQuestion);
        IList<Test_Lookup> BatchOperationsToTestLookup(IList<Test_Lookup> addList, IList<Test_Lookup> updateList, IList<Test_Lookup> deleteList, string sMACAddress, string sUserName, string sSystemOrCondition);
        IList<Test_Lookup> GetTestLookup(string UserName);
        IList<string> GetTestCategoryList(string UserName);

    }
    public partial class TestLookupManager : ManagerBase<Test_Lookup, ulong>, ITestLookupManager
    {
        #region Constructors
        public TestLookupManager()
            : base()
        {

        }
        public TestLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        #region Implementation
        public IList<FillTestScreen> GetTestLookupListFromServer(string Category, string UserName, ulong ulEncID)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ArrayList arylstTestLookup = null;
            object[] objArrTestLookup = null;
            IQuery query;

            IList<FillTestScreen> fillTestScreenList = new List<FillTestScreen>();
            FillTestScreen fillTestScreen;

            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query = iMySession.GetNamedQuery("Get.Test.Lookup.Old");
                query.SetParameter(0, ulEncID);
                query.SetParameter(1, Category);

                arylstTestLookup = new ArrayList(query.List());

                if (arylstTestLookup!=null)
                {
                    for (int i = 0; i < arylstTestLookup.Count; i++)
                    {
                        objArrTestLookup = (object[])arylstTestLookup[i];

                        fillTestScreen = new FillTestScreen();

                        fillTestScreen.Test = objArrTestLookup[0].ToString();
                        fillTestScreen.Question = objArrTestLookup[1].ToString();
                        fillTestScreen.Status = objArrTestLookup[2].ToString();
                        fillTestScreen.Notes = objArrTestLookup[3].ToString();
                        fillTestScreen.StatusOptions = objArrTestLookup[4].ToString();
                        fillTestScreen.TestLookupId = Convert.ToUInt64(objArrTestLookup[5].ToString());
                        //fillTestScreen.NormalSystemStatus = objArrTestLookup[7].ToString();
                        fillTestScreen.TestID = Convert.ToUInt64(objArrTestLookup[7].ToString());
                        //fillTestScreen.UpdateFlag = Convert.ToInt32(objArrTestLookup[9].ToString());
                        fillTestScreen.Version = Convert.ToInt32(objArrTestLookup[9].ToString());
                        //fillTestScreen.DefaultValue = objArrTestLookup[11].ToString();
                        fillTestScreen.CreatedBy = objArrTestLookup[10].ToString();
                        fillTestScreen.CreatedDateTime = Convert.ToDateTime(objArrTestLookup[11].ToString());
                        fillTestScreen.Score = objArrTestLookup[12].ToString();
                        fillTestScreen.Is_Score = objArrTestLookup[13].ToString();
                        fillTestScreen.Is_Status = objArrTestLookup[14].ToString();
                        //fillTestScreen.Is_Notes = objArrTestLookup[17].ToString();
                        fillTestScreen.Maximum_Score = objArrTestLookup[15].ToString();




                        fillTestScreenList.Add(fillTestScreen);

                    }
                    if (arylstTestLookup.Count == 0)
                    {
                        TestLookupManager testlookupMngr = new TestLookupManager();
                        fillTestScreenList = testlookupMngr.GetTestLookupListFromLocal(Category, UserName, ulEncID, "TEST_QUESTION");
                    }
                }
               
                iMySession.Close();
            }
            return fillTestScreenList;
        }
        public IList<FillTestScreen> GetTestLookupListFromLocal(string Category, string UserName, ulong ulEncID, string sTestOrQuestion)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ArrayList arylstTestLookup = null;
            object[] objArrTestLookup = null;
            IQuery query;

            IList<FillTestScreen> fillTestScreenList = new List<FillTestScreen>();
            FillTestScreen fillTestScreen;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query = iMySession.GetNamedQuery("Get.Test.Lookup.New");
                query.SetString(0, Category);
                query.SetString(1, UserName);

                arylstTestLookup = new ArrayList(query.List());

                if (arylstTestLookup!=null)
                {
                    for (int i = 0; i < arylstTestLookup.Count; i++)
                    {
                        objArrTestLookup = (object[])arylstTestLookup[i];

                        fillTestScreen = new FillTestScreen();

                        fillTestScreen.Test = objArrTestLookup[0].ToString();
                        fillTestScreen.Question = objArrTestLookup[1].ToString();
                        fillTestScreen.Status = objArrTestLookup[2].ToString();
                        fillTestScreen.Notes = objArrTestLookup[3].ToString();
                        fillTestScreen.StatusOptions = objArrTestLookup[4].ToString();
                        fillTestScreen.TestLookupId = Convert.ToUInt64(objArrTestLookup[5].ToString());
                       // fillTestScreen.NormalSystemStatus = objArrTestLookup[7].ToString();
                        fillTestScreen.TestID = Convert.ToUInt64(objArrTestLookup[7].ToString());
                        //fillTestScreen.UpdateFlag = Convert.ToInt32(objArrTestLookup[9].ToString());
                        fillTestScreen.Version = Convert.ToInt32(objArrTestLookup[9].ToString());
                        //fillTestScreen.DefaultValue = objArrTestLookup[11].ToString();
                        //fillTestScreen.CreatedBy = objArrTestLookup[12].ToString();
                        //fillTestScreen.CreatedDateTime = Convert.ToDateTime(objArrTestLookup[13].ToString());
                        fillTestScreen.Score = objArrTestLookup[12].ToString();
                        fillTestScreen.Is_Score = objArrTestLookup[13].ToString();
                        fillTestScreen.Is_Status = objArrTestLookup[14].ToString();
                        //fillTestScreen.Is_Notes = objArrTestLookup[17].ToString();
                        fillTestScreen.Maximum_Score = objArrTestLookup[15].ToString();


                        fillTestScreenList.Add(fillTestScreen);

                    }
                }
               
                iMySession.Close();
            }
            return fillTestScreenList;


        }



        public IList<Test_Lookup> BatchOperationsToTestLookup(IList<Test_Lookup> addList, IList<Test_Lookup> updateList, IList<Test_Lookup> deleteList, string sMACAddress, string sUserName, string sSystemOrCondition)
        {
            //SaveUpdateDeleteWithTransaction(ref addList, updateList, deleteList, sMACAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref addList, ref updateList, deleteList, sMACAddress, false, false, 0, string.Empty);
            return GetTestLookup(sUserName);
        }
        public IList<Test_Lookup> GetTestLookup(string UserName)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<Test_Lookup> testList = new List<Test_Lookup>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Test_Lookup)).Add(Expression.Eq("User_Name", UserName));
                testList = crit.List<Test_Lookup>();
                iMySession.Close();
            }
            return testList;
        }

        public IList<string> GetTestCategoryList(string UserName)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            IList<string> testList = new List<string>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery crit = iMySession.CreateSQLQuery("Select distinct t.Category from test_lookup t where t.user_name='" + UserName + "'");
                testList = crit.List<string>();
                iMySession.Close();
            }
            return testList;
        }
        #endregion


    }

}
