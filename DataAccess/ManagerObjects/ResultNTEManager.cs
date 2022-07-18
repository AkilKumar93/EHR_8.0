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
    public partial interface IResultNTEManager : IManagerBase<ResultNTE, ulong>
    {
        int SaveResultNTE(ref IList<ResultNTE> resultNTEList, ISession MySession, string macAddress);
        IList<ResultNTE> GetResultByMasterID(ulong result_master_id);
        int DeleteResultNTE(IList<ResultNTE> resultNTEList, ISession MySession, string macAddress);
    }

    public partial class ResultNTEManager : ManagerBase<ResultNTE, ulong>, IResultNTEManager
    {
        #region Constructors


        public ResultNTEManager()
            : base()
        {

        }
        public ResultNTEManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion



        #region IResultNTEManager Members

        public int SaveResultNTE(ref IList<ResultNTE> resultNTEList, ISession MySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultNTE> resultNTEListnull = null;
            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultNTEList, ref resultNTEListnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //iResult = SaveUpdateDeleteWithoutTransaction(ref resultNTEList, null, null, MySession, macAddress);
            return iResult;
        }

        public IList<ResultNTE> GetResultByMasterID(ulong result_master_id)
        {
            IList<ResultNTE> listresult = new List<ResultNTE>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ResultNTE)).Add(Expression.Eq("Result_Master_ID", result_master_id));
                listresult = crit.List<ResultNTE>();
                iMySession.Close();
            }
            return listresult;
        }


        public int DeleteResultNTE(IList<ResultNTE> resultNTEList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultNTE> SaveNTE = new List<ResultNTE>();
            IList<ResultNTE> SaveNTEnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveNTE, ref SaveNTEnull, resultNTEList, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //return SaveUpdateDeleteWithoutTransaction(ref SaveNTE, null, resultNTEList, MySession, macAddress);
        }

        public int UpdateResultNTE(IList<ResultNTE> SaveresultNTEList, IList<ResultNTE> UpdateresultNTEList, IList<ResultNTE> DeleteresultNTEList, ISession MySession, string macAddress)
        {
            GenerateXml XMLObj = new GenerateXml();
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveresultNTEList, ref UpdateresultNTEList, DeleteresultNTEList, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
           //return SaveUpdateDeleteWithoutTransaction(ref SaveresultNTEList, UpdateresultNTEList, DeleteresultNTEList, MySession, macAddress);
        }


        #endregion
    }
}
