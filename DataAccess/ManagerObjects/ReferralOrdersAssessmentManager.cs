using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IReferralOrdersAssessmentManager : IManagerBase<ReferralOrdersAssessment, ulong>
    {
        int BatchOperationsToReferralOrdersAssessment(IList<ReferralOrdersAssessment> savelist, IList<ReferralOrdersAssessment> updtList, IList<ReferralOrdersAssessment> delList, ISession MySession, string MACAddress);
    }
    public partial class ReferralOrdersAssessmentManager : ManagerBase<ReferralOrdersAssessment, ulong>, IReferralOrdersAssessmentManager
    {
         #region Constructors

          public ReferralOrdersAssessmentManager()
            : base()
            {

            }
          public ReferralOrdersAssessmentManager
              (INHibernateSession session)
              : base(session)
          {
          }

        #endregion



          #region IReferralOrdersAssessmentManager Members

          public int BatchOperationsToReferralOrdersAssessment(IList<ReferralOrdersAssessment> savelist, IList<ReferralOrdersAssessment> updtList, IList<ReferralOrdersAssessment> delList, ISession MySession, string MACAddress)
          {
              GenerateXml XMLObj = new GenerateXml();
             // return SaveUpdateDeleteWithoutTransaction(ref savelist, updtList, delList, MySession,MACAddress);
              return SaveUpdateDelete_DBAndXML_WithoutTransaction(ref savelist, ref updtList, delList, MySession, MACAddress, false, true, 0, string.Empty, ref XMLObj);
          }

          #endregion
    }
}
