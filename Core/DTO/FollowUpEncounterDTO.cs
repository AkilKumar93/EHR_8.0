using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;
using System.Data;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class FollowUpEncounterDTO
    {
        private IList<ChiefComplaints> _ChiefComplaints = null;
        private FillROS _Ros = null;
        private NonDrugHistoryDTO _NonDrugAllergy = null;
        private IList<Rcopia_Allergy> _ilstDrugAllergy = null;
        private FillROS _fillRos = null;
        //True Or False 
        private bool _bChiefComplaints;
        private bool _bROS;

        #region Constructor

        public FollowUpEncounterDTO()
        {
            _ChiefComplaints = new List<ChiefComplaints>();
            _NonDrugAllergy = new NonDrugHistoryDTO();
            _ilstDrugAllergy = new List<Rcopia_Allergy>();
            _bChiefComplaints = true;
        }

        #endregion
        #region Properties
     
     
  
        [DataMember]
        public virtual NonDrugHistoryDTO NonDrugHistory
        {
            get { return _NonDrugAllergy; }
            set { _NonDrugAllergy = value; }
        }
      
        [DataMember]
        public virtual bool bChiefComplaints
        {
            get { return _bChiefComplaints; }
            set { _bChiefComplaints = value; }
        }
        [DataMember]
        public virtual bool bROS
        {
            get { return _bROS; }
            set { _bROS = value; }
        }
        #endregion
    }
}
