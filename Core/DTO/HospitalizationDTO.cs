using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
    public partial class HospitalizationDTO
    {
        private IList<HospitalizationHistory> _HospList = null;
        private IList<HospitalizationHistoryMaster> _HospMasterList = null;
        private Encounter _Encount;

        private DateTime _DateofBirth = DateTime.MinValue;
        private Dictionary<ulong, DateTime> _dictHospFromDate = new Dictionary<ulong, DateTime>();
        #region Constructor

        public HospitalizationDTO() { }

        #endregion

        #region Properties


        public virtual IList<HospitalizationHistory> HospList
        {
            get { return _HospList; }
            set { _HospList = value; }
        }

        public virtual IList<HospitalizationHistoryMaster> HospMasterList
        {
            get { return _HospMasterList; }
            set { _HospMasterList = value; }
        }


        public virtual Encounter Encount
        {
            get { return _Encount; }
            set { _Encount = value; }
        }


        public virtual DateTime DateofBirth
        {
            get { return _DateofBirth; }
            set { _DateofBirth = value; }
        }

        public virtual Dictionary<ulong, DateTime> dictHospFromDate
        {
            get { return _dictHospFromDate; }
            set { _dictHospFromDate = value; }
        }
        #endregion
    }
}
