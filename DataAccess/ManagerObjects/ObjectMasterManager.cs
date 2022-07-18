using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;


namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IObjectMasterManager : IManagerBase<ObjectMaster, string>
    {
        IList<ObjectMaster> GetObjectListByProcessandObject(string  ObjType ,string ParentProcess);
        IList<ObjectMaster> CheckIsChildObject(string ObjType);
    }
    public partial class ObjectMasterManager : ManagerBase<ObjectMaster, string>, IObjectMasterManager
    {
        #region Constructors

        public ObjectMasterManager()
            : base()
        {

        }
        public ObjectMasterManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<ObjectMaster> GetObjectListByProcessandObject(string ObjType, string ParentProcess)
        {
              IList<ObjectMaster> list = new List<ObjectMaster>();
              using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
              {
                  ICriteria criteria = iMySession.CreateCriteria(typeof(ObjectMaster)).Add(Expression.Eq("Parent_Obj_Type", ObjType)).Add(Expression.Eq("Birth_Process", ParentProcess));
                  list = criteria.List<ObjectMaster>(); ;
                  iMySession.Close();
              }
            return list;
            //return criteria.List<ObjectMaster>();
        }

        public IList<ObjectMaster> CheckIsChildObject(string ObjType)
        {
           
            IList<ObjectMaster> list = new List<ObjectMaster>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(ObjectMaster)).Add(Expression.Eq("Obj_Type", ObjType));
                list = criteria.List<ObjectMaster>();
                iMySession.Close();
            }
            return list;
            //return criteria.List<ObjectMaster>();
        }
    }
}
