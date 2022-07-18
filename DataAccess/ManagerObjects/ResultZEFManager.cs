using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IResultZEFManager : IManagerBase<ResultZEF, ulong>
    {
        int SaveResultZEF(ref IList<ResultZEF> resultZEFList, ISession MySession, string macAddress);
        IList<ResultZEF> GetResultByMasterID(ulong result_master_id);
    }

    public partial class ResultZEFManager : ManagerBase<ResultZEF, ulong>, IResultZEFManager
    {
        #region Constructors


        public ResultZEFManager()
            : base()
        {

        }
        public ResultZEFManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public int SaveResultZEF(ref IList<ResultZEF> resultZEFList, ISession MySession, string macAddress)
        {
            int iResult = 0;
            GenerateXml XMLObj = new GenerateXml();
            IList<ResultZEF> resultZEFListnull = null;
            iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref resultZEFList, ref resultZEFListnull, null, MySession, macAddress, false, true, 0, string.Empty, ref XMLObj);
            //iResult = SaveUpdateDeleteWithoutTransaction(ref resultZEFList, null, null, MySession, macAddress);
            return iResult;
        }

        public IList<ResultZEF> GetResultByMasterID(ulong result_master_id)
        {
            IList<ResultZEF> lstresult = new List<ResultZEF>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(ResultZEF)).Add(Expression.Eq("Result_Master_ID", result_master_id));
                lstresult = crit.List<ResultZEF>();
                iMySession.Close();
            }
            return lstresult;
        }
    }
}
