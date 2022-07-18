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
    public partial interface IResultOBRManager : IManagerBase<ResultOBR, ulong>
    {
        int SaveResultOBR(ref IList<ResultOBR> resultOBRList, ISession MySession, string macAddress);
        IList<ResultOBR> GetResultByMasterID(ulong result_master_id);
        int DeleteResultOBR(IList<ResultOBR> resultOBRList, ISession MySession, string macAddress);
        int UpdateResultOBR(IList<ResultOBR> resultOBRList, ISession MySession, string macAddress);
        ulong SaveResultOBRforSummary(IList<ResultOBR> lstresultobr);

    }

    public partial class ResultOBRManager : ManagerBase<ResultOBR, ulong>, IResultOBRManager
    {
        #region Constructors


        public ResultOBRManager()
            : base()
        {

        }
        public ResultOBRManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region IResultOBRManager Members

        public int SaveResultOBR(ref IList<ResultOBR> resultOBRList, ISession MySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            //iResult = SaveUpdateDeleteWithoutTransaction(ref resultOBRList, null, null, MySession, macAddress);
            IList<ResultOBR> ResultOBRnull = null;
            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultOBRList, ref ResultOBRnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            return iResult;
        }

        public IList<ResultOBR> GetResultByMasterID(ulong result_master_id)
        {
            IList<ResultOBR> listresult = new List<ResultOBR>();
            GenerateXml XMLObj = new GenerateXml();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ResultOBR)).Add(Expression.Eq("Result_Master_ID", result_master_id));
                listresult= crit.List<ResultOBR>();
                iMySession.Close();
            }
            return listresult;
        }

        public int DeleteResultOBR(IList<ResultOBR> resultOBRList, ISession MySession, string macAddress)
        {
            IList<ResultOBR> SaveOBR=new List<ResultOBR>();
            GenerateXml XMLObj = new GenerateXml();
           // return SaveUpdateDeleteWithoutTransaction(ref SaveOBR, null, resultOBRList, MySession, macAddress);
            IList<ResultOBR> ResultOBRnull = null;
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveOBR, ref ResultOBRnull, resultOBRList, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        public int UpdateResultOBR(IList<ResultOBR> resultOBRList, ISession MySession, string macAddress)
        {
            IList<ResultOBR> SaveOBR = new List<ResultOBR>();
            GenerateXml XMLObj = new GenerateXml();
            //return SaveUpdateDeleteWithoutTransaction(ref SaveOBR, resultOBRList, null, MySession, macAddress);            
            return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref SaveOBR, ref resultOBRList, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
        }

        public ulong SaveResultOBRforSummary(IList<ResultOBR> lstresultobr)
        {
            //SaveUpdateDeleteWithTransaction(ref lstresultobr, null, null, string.Empty);
            IList<ResultOBR> lstresultobrnull = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref lstresultobr, ref lstresultobrnull, null, string.Empty, false, true, 0, string.Empty);
            return lstresultobr[0].Id;
        }

        #endregion
    }
}
