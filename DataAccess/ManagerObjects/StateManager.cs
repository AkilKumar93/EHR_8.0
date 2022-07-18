using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface IStateManager : IManagerBase<State, ulong>
    {
        IList<State> Getstate();
        IList<State> GetCountybyState(string sState);
        IList<State> GetCountybyStateAndCity(string sState, string sCity);
    }

    public partial class StateManager : ManagerBase<State, ulong>, IStateManager
    {
        #region Constructors

        public StateManager()
            : base()
        {

        }
        public StateManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<State> Getstate()
        {
            IList<State> Statelist;
            //Statelist = GetAll();
            using (ISession iMysession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMysession.CreateCriteria(typeof(State)).SetProjection(Projections.Distinct(Projections.ProjectionList().Add(Projections.Alias(Projections.Property("State_Code"), "State_Code"))));
                crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanResultTransformer(typeof(State)));
                Statelist = crit.List<State>();
            }
            return Statelist;
        }
        public IList<State> GetCountybyState(string sState)
        {
            IList<State> ilstState = new List<State>();
            using (ISession iMysession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMysession.CreateCriteria(typeof(State)).Add(Expression.Eq("State_Code", sState));
                ilstState = crit.List<State>();
            }
            return ilstState;
        }

        public IList<State> GetCountybyStateAndCity(string sState,string sCity)
        {
            IList<State> ilstState = new List<State>();
            using (ISession iMysession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMysession.CreateCriteria(typeof(State)).Add(Expression.Eq("State_Code", sState)).Add(Expression.Eq("City", sCity));
                ilstState = crit.List<State>();
            }
            return ilstState;
        }

    }
}
