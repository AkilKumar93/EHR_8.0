 using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
    public partial class ProblemHistoryDTO
    {
        #region Declarations
        private IList<PastMedicalHistory> _PastMedicalList= null;
        private GeneralNotes _GeneralNotesObject = null;
        private IList<ProblemList> _ProblemList = null;
        private IList<PastMedicalHistoryMaster> _PastMedicalMasterList = null;
      
        #endregion

        #region Constructor

        public ProblemHistoryDTO() { }

        #endregion

        #region Properties
        public virtual IList<PastMedicalHistory> PastMedicalList
        {
            get { return _PastMedicalList; }
            set { _PastMedicalList = value; }
        }

        public virtual IList<PastMedicalHistoryMaster> PastMedicalMasterList
        {
            get { return _PastMedicalMasterList; }
            set { _PastMedicalMasterList = value; }
        }
        public virtual GeneralNotes GeneralNotesObject
        {
            get { return _GeneralNotesObject; }
            set { _GeneralNotesObject = value; }
        }

        public virtual IList<ProblemList> ProblemList
        {
            get { return _ProblemList; }
            set { _ProblemList = value; }
        }
     
        #endregion
    }
}
