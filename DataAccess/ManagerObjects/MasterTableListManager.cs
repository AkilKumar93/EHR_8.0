using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using Acurus.Capella.Core.DTO;
using System.Collections;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IMasterTableListManager : IManagerBase<MasterTableList, ulong>
    {
        IList<MasterTableList> GetAllMasterTableList(string[] Table_Name,int BucketNo);
        IList<MasterTableList> GetAuditTrailTableList();
        
    }
    public partial class MasterTableListManager : ManagerBase<MasterTableList,ulong>,IMasterTableListManager
    {
        #region Constructors

        public MasterTableListManager()
            : base()
        {

        }
        public MasterTableListManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        # region userDefinedMethods

        public IList<MasterTableList> GetAllMasterTableList(string[] Table_Name, int BucketNo)
        {            
            IList<MasterTableList> list = new List<MasterTableList>();
            //ICriteria crt = session.GetISession().CreateCriteria(typeof(MasterTableList)).Add(Expression.Eq("Bucket_Number",BucketNo)).Add(Expression.In("Table_Name", Table_Name));
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(MasterTableList)).Add(Expression.Eq("Bucket_Number", BucketNo)).Add(Expression.In("Table_Name", Table_Name));
                list = crt.List<MasterTableList>();
                iMySession.Close();
            }
            return list;
            //return crt.List<MasterTableList>();
        }

        public IList<MasterTableList> GetAuditTrailTableList()
        {
            IList<MasterTableList> masterList = new List<MasterTableList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(MasterTableList)).Add(Expression.Eq("Is_Audit_Trail", "Y"));
                masterList = crt.List<MasterTableList>();
                iMySession.Close();
            }
            return masterList;

            
        }
        public IList<MasterTableList> GetAuditTrailTableListByTableNames(string[] table_names)
        {
            IList<MasterTableList> masterList = new List<MasterTableList>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crt = iMySession.CreateCriteria(typeof(MasterTableList)).Add(Expression.Eq("Is_Audit_Trail", "Y")).Add(Expression.In("Table_Name", table_names));
                masterList = crt.List<MasterTableList>();
                iMySession.Close();
            }
            return masterList;
        }

        public string GetDeletedAttribute(string entityname)
        {
            string attribute = string.Empty;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery query = iMySession.CreateSQLQuery("select deleted_attribute from master_table_list where domain_object_name='" + entityname + "';");
                attribute = query.List()[0].ToString();
                iMySession.Close();
            }
            return attribute;

            // return session.GetISession().CreateSQLQuery("select deleted_attribute from master_table_list where domain_object_name='" + entityname + "';").List()[0].ToString();            
        }


        #endregion
    }
}
