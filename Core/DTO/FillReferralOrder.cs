using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]

  public partial class FillReferralOrder
  {
      #region Declaration
      private ReferralOrder _tophyName = new ReferralOrder();
      private ReferralOrder _referralSpecialty = new ReferralOrder();
      private ReferralOrder _toFacName = new ReferralOrder();
      private ReferralOrder _reasonforReferral = new ReferralOrder();
      private ReferralOrder _noOfVisit = new ReferralOrder();
      private ReferralOrder _referralNotes = new ReferralOrder();
      private ReferralOrdersAssessment _ICD = new ReferralOrdersAssessment();
      private ReferralOrdersAssessment _assessmentDescription = new ReferralOrdersAssessment();
      #endregion

      #region Methods
      [DataMember]
      public ReferralOrder tophyName
      {
          get { return _tophyName; }
          set { _tophyName = value; }
      }
      [DataMember]
      public ReferralOrder referralSpecialty
      {
          get { return _referralSpecialty; }
          set { _referralSpecialty = value; }
      }
      [DataMember]
      public ReferralOrder toFacName
      {
          get { return _toFacName; }
          set { _toFacName = value; }
      }
      [DataMember]
      public ReferralOrder reasonforReferral
      {
          get { return _reasonforReferral; }
          set { _reasonforReferral = value; }
      }
      [DataMember]
      public ReferralOrder noOfVisit
      {
          get { return _noOfVisit; }
          set { _noOfVisit = value; }
      }
      [DataMember]
      public ReferralOrder referralNotes
      {
          get { return _referralNotes; }
          set { _referralNotes = value; }
      }

      [DataMember]
      public ReferralOrdersAssessment ICD
      {
          get { return _ICD; }
          set { _ICD = value; }
      }
      [DataMember]
      public ReferralOrdersAssessment assessmentDescription
      {
          get { return _assessmentDescription; }
          set { _assessmentDescription = value; }
      }

      #endregion 
  }
}
