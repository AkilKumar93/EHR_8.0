using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Data;
using System.IO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPotentialDiagnosisManager : IManagerBase<PotentialDiagnosis, ulong>
    {
        IList<PotentialDiagnosis> GetFromPotentialDiagnosisList(ulong ulHumanID, string sMacAddress);
        IList<PotentialDiagnosis> SaveUpdateDeletePotentialDiagnosis(IList<PotentialDiagnosis> addList, IList<PotentialDiagnosis> updateList, IList<PotentialDiagnosis> deleteList, ulong uHuman_ID);
        void MoveToAssessmentList(List<string> ilstIDs, ulong HumanID, string ModifiedBy, DateTime ModifiedDateTime);
    }
    public partial class PotentialDiagnosisManager : ManagerBase<PotentialDiagnosis, ulong>, IPotentialDiagnosisManager
    {
        #region Constructors
        public PotentialDiagnosisManager()
            : base()
        {
        }
        public PotentialDiagnosisManager(INHibernateSession session)
            : base(session)
        {
        }

        #endregion
        #region Methods

        public IList<PotentialDiagnosis> GetFromPotentialDiagnosisList(ulong ulHumanID, string sMacAddress)
        {
            IList<PotentialDiagnosis> list = new List<PotentialDiagnosis>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(PotentialDiagnosis))
                                               .Add(Expression.Eq("Human_ID", ulHumanID));
                list = criteria.List<PotentialDiagnosis>();
                iMySession.Close();
            }
            return list;

        }


        public IList<PotentialDiagnosis> SaveUpdateDeletePotentialDiagnosis(IList<PotentialDiagnosis> addList, IList<PotentialDiagnosis> updateList, IList<PotentialDiagnosis> deleteList, ulong uHuman_ID)
        {

            SaveUpdateDelete_DBAndXML_WithTransaction(ref addList, ref updateList, deleteList, string.Empty, true, false, uHuman_ID, string.Empty);
            IList<PotentialDiagnosis> fillPotentialList = new List<PotentialDiagnosis>();
            fillPotentialList = GetFromPotentialDiagnosisList(uHuman_ID, string.Empty);
            return fillPotentialList;
        }
        public void MoveToAssessmentList(List<string> ilstIDs, ulong HumanID, string ModifiedBy, DateTime ModifiedDateTime)
        {
            IList<PotentialDiagnosis> fillPotentialList = null;
            IList<PotentialDiagnosis> list = new List<PotentialDiagnosis>();
            ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ICriteria criteria = iMySession.CreateCriteria(typeof(PotentialDiagnosis))
                                           .Add(Expression.In("Id", ilstIDs));
            list = criteria.List<PotentialDiagnosis>();
            list = list.Select(l =>
            {
                l.Move_To_Assessment = "Y";
                l.Modified_By = ModifiedBy;
                l.Modified_Date_And_Time = ModifiedDateTime;
                return l;
            }).ToList<PotentialDiagnosis>();
            SaveUpdateDelete_DBAndXML_WithTransaction(ref fillPotentialList, ref list, null, string.Empty, true, true, HumanID, string.Empty);
            iMySession.Close();
        }



        #endregion
    }
}
