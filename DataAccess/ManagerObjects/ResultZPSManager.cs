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
    public partial interface IResultZPSManager : IManagerBase<ResultZPS, ulong>
    {
        int SaveResultZPS(ref IList<ResultZPS> resultZPSList, ISession MySession, string macAddress);
        IList<ResultZPS> GetResultByMasterID(ulong result_master_id);
        int DeleteResultZPS(IList<ResultZPS> resultZPSList, ISession MySession, string macAddress);
        int UpdateResultZPS(IList<ResultZPS> resultZPSList, ISession MySession, string macAddress);
    }

    public partial class ResultZPSManager : ManagerBase<ResultZPS, ulong>, IResultZPSManager
    {
        #region Constructors


        public ResultZPSManager()
            : base()
        {

        }
        public ResultZPSManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region IResultZPSManager Members

        public int SaveResultZPS(ref IList<ResultZPS> resultZPSList, ISession MySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultZPS> resultZPSListnull = null;
            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultZPSList, ref resultZPSListnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //iResult = SaveUpdateDeleteWithoutTransaction(ref resultZPSList, null, null, MySession, macAddress);
            return iResult;
        }

        public IList<ResultZPS> GetResultByMasterID(ulong result_master_id)
        {
           IList<ResultZPS> lstresult = new List<ResultZPS>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ResultZPS)).Add(Expression.Eq("Result_Master_ID", result_master_id));
                lstresult = crit.List<ResultZPS>();
                iMySession.Close();
            }
            return lstresult;
        }

        public int DeleteResultZPS(IList<ResultZPS> resultZPSList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultZPS> SaveZPS = new List<ResultZPS>();
            IList<ResultZPS> SaveZPSnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveZPS, ref SaveZPSnull, resultZPSList, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref SaveZPS, null, resultZPSList, MySession, macAddress);
        }

        public int UpdateResultZPS(IList<ResultZPS> resultZPSList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultZPS> SaveZPS = new List<ResultZPS>();
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveZPS, ref resultZPSList, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref SaveZPS, resultZPSList, null, MySession, macAddress);
        }


       
        #endregion
    }
}
