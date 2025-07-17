using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Mail;
using System.Data;
using System.Linq;
using System.Xml;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface ICDC_Audit_LogManager : IManagerBase<CDC_Audit_Log, ulong>
    {
        IList<CDC_Audit_Log> GetCDC_Audit_LogByID(ulong ulCDCAuditLogID);

        void SaveCDC_Audit_LogWithTransaction(IList<CDC_Audit_Log> ListToUpdateCDC_Audit_Log, string MACAddress);

    }

    public partial class CDC_Audit_LogManager : ManagerBase<CDC_Audit_Log, ulong>, ICDC_Audit_LogManager
    {
        #region Constructors

        public CDC_Audit_LogManager()
            : base()
        {

        }
        public CDC_Audit_LogManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods


        public IList<CDC_Audit_Log> GetCDC_Audit_LogByID(ulong ulCDCAuditLogID)
        {
            IList<CDC_Audit_Log> ilstCDC_Audit_Log = new List<CDC_Audit_Log>();
            session.GetISession().Close();
            ICriteria crit = session.GetISession().CreateCriteria(typeof(CDC_Audit_Log)).Add(Expression.Eq("ID", ulCDCAuditLogID.ToString()));
            ilstCDC_Audit_Log = crit.List<CDC_Audit_Log>();

            return ilstCDC_Audit_Log;
        }



        public void SaveCDC_Audit_LogWithTransaction(IList<CDC_Audit_Log> ListToUpdateCDC_Audit_Log, string MACAddress)
        {
            IList<CDC_Audit_Log> ilstCDC_Audit_Log = null;
            SaveUpdateDeleteWithTransaction(ref ilstCDC_Audit_Log, ListToUpdateCDC_Audit_Log, null, MACAddress);
        }
        #endregion
    }
}
