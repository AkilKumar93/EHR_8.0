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
    public partial interface IResultORCManager : IManagerBase<ResultORC, ulong>
    {
        int SaveResultORC(ref IList<ResultORC> resultORCList, ISession MySession, string macAddress);
        IList<ResultORC> GetResultByMasterID(ulong result_master_id);
        int DeleteResultORC(IList<ResultORC> resultORCList, ISession MySession, string macAddress);
        int UpdateResultORC(IList<ResultORC> resultORCList, ISession MySession, string macAddress);
        void SaveResultORCforSummary(IList<ResultORC> lstresultorc);
    }

    public partial class ResultORCManager : ManagerBase<ResultORC, ulong>, IResultORCManager
    {
        #region Constructors


        public ResultORCManager()
            : base()
        {

        }
        public ResultORCManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        #region IResultORCManager Members
        public int SaveResultORC(ref IList<ResultORC> resultORCList, ISession MySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultORC> resultORCListnull = null;
            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultORCList, ref resultORCListnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //iResult = SaveUpdateDeleteWithoutTransaction(ref resultORCList, null, null, MySession, macAddress);
            return iResult;
        }

        public IList<ResultORC> GetResultByMasterID(ulong result_master_id)
        {
            IList<ResultORC> lstresult = new List<ResultORC>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ResultORC)).Add(Expression.Eq("Result_Master_ID", result_master_id));
                lstresult = crit.List<ResultORC>();
                iMySession.Close();
            }
            return lstresult;
        }

        public int DeleteResultORC(IList<ResultORC> resultORCList, ISession MySession, string macAddress)
        {
            IList<ResultORC> SaveORC=new List<ResultORC>();
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultORC> resultORCListnull = null;
            //return SaveUpdateDeleteWithoutTransaction(ref SaveORC, null, resultORCList, MySession, macAddress);
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveORC, ref resultORCListnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        public int UpdateResultORC(IList<ResultORC> resultORCList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();            
            IList<ResultORC> SaveORC = new List<ResultORC>();
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveORC, ref resultORCList, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref SaveORC, resultORCList, null, MySession, macAddress);
        }

        public void SaveResultORCforSummary(IList<ResultORC> lstresultorc)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultORC> resultORCListnull = null;
            //SaveUpdateDeleteWithTransaction(ref lstresultorc, null, null, string.Empty);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref lstresultorc, ref resultORCListnull, null, string.Empty, false, true, 0, string.Empty);
        }

        #endregion
    }
}
