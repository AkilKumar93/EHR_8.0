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
    public partial interface IMapPhysicianPhysicianAssitantManager : IManagerBase<MapPhysicianPhysicianAssistant, ulong>
    {
        IList<MapPhysicianPhysicianAssistant> GetMapPhysicianPhyAsstList(int PhyAsstID);
        IList<MapPhysicianPhysicianAssistant> GetMapPhysicianPhyAsstListByIDRole(int Phy_ID, string UserRole);
    }

    public partial class MapPhysicianPhysicianAssitantManager : ManagerBase<MapPhysicianPhysicianAssistant, ulong>, IMapPhysicianPhysicianAssitantManager
    {
        #region Constructors

        public MapPhysicianPhysicianAssitantManager()
            : base()
        {

        }
        public MapPhysicianPhysicianAssitantManager(INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<MapPhysicianPhysicianAssistant> GetMapPhysicianPhyAsstList(int PhyAsstID)
        {
            IList<MapPhysicianPhysicianAssistant> MapList=null;
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            //ICriteria crit = session.GetISession().CreateCriteria(typeof(MapPhysicianPhysicianAssistant)).Add(Expression.Eq("Physician_Asst_ID", PhyAsstID));
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(MapPhysicianPhysicianAssistant)).Add(Expression.Eq("Physician_Asst_ID", PhyAsstID));
                MapList = crit.List<MapPhysicianPhysicianAssistant>();
                iMySession.Close();
            }

            return MapList;
        }
        //public MapPhysicianAndPhysicianAssistantDTO GetMapPhysicianPhyAsstDetails(int PhyAsstID)
        //{
        //    MapPhysicianAndPhysicianAssistantDTO objMapPhysicianAndPhysicianAssistantDTO = new MapPhysicianAndPhysicianAssistantDTO();
        //    IList<MapPhysicianPhysicianAssistant> MapList = null;
        //    ISession iMySession = NHibernateSessionManager.Instance.CreateISession();

        //   // ICriteria crit = session.GetISession().CreateCriteria(typeof(MapPhysicianPhysicianAssistant)).Add(Expression.Eq("Physician_Asst_ID", PhyAsstID));
        //    ICriteria crit = iMySession.CreateCriteria(typeof(MapPhysicianPhysicianAssistant)).Add(Expression.Eq("Physician_Asst_ID", PhyAsstID));
        //    MapList = crit.List<MapPhysicianPhysicianAssistant>();
        //    objMapPhysicianAndPhysicianAssistantDTO.PhyAstantlist = MapList;
        //    if (MapList.Count > 0)
        //    {
        //        IList<int> PhysicianList=MapList.Select(a=>a.Physician_ID).ToList<int>();
        //        ICriteria criteria = iMySession.CreateCriteria(typeof(PhysicianLibrary)).Add(Expression.In("Id", PhysicianList.ToArray<int>()));
        //        objMapPhysicianAndPhysicianAssistantDTO.PhysicianLibraryList= criteria.List<PhysicianLibrary>();
        //    }
        //    iMySession.Close();
        //    return objMapPhysicianAndPhysicianAssistantDTO;
        //}
        public IList<MapPhysicianPhysicianAssistant> GetMapPhysicianPhyAsstListByIDRole(int Phy_ID,string UserRole)
        {
            IList<MapPhysicianPhysicianAssistant> MapList = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if (UserRole.ToUpper() == "PHYSICIAN ASSISTANT")
                {
                    ICriteria crit = iMySession.CreateCriteria(typeof(MapPhysicianPhysicianAssistant)).Add(Expression.Eq("Physician_Asst_ID", Phy_ID)).Add(Expression.Eq("Status", "A"));
                    MapList = crit.List<MapPhysicianPhysicianAssistant>();
                }
                else if (UserRole.ToUpper() == "PHYSICIAN")
                {
                    ICriteria crit = iMySession.CreateCriteria(typeof(MapPhysicianPhysicianAssistant)).Add(Expression.Eq("Default_Physician", Phy_ID)).Add(Expression.Eq("Status", "A"));
                    MapList = crit.List<MapPhysicianPhysicianAssistant>();
                }
                iMySession.Close();
            }

            return MapList;
        }
    }
}
