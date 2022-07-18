using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
    public partial class NonDrugHistoryDTO
    {
          #region Declarations
        private IList<NonDrugAllergy> _NonDrugList= null;
        private IList<NonDrugAllergyMaster> _NonDrugMasterList = null;
        private GeneralNotes _GeneralNotesObject = null;
      
        #endregion

        #region Constructor

        public NonDrugHistoryDTO() { }

        #endregion

        #region Properties
        public virtual IList<NonDrugAllergy> NonDrugList
        {
            get { return _NonDrugList; }
            set { _NonDrugList = value; }
        }
        public virtual IList<NonDrugAllergyMaster> NonDrugMasterList
        {
            get { return _NonDrugMasterList; }
            set { _NonDrugMasterList = value; }
        }
        public virtual GeneralNotes GeneralNotesObject
        {
            get { return _GeneralNotesObject; }
            set { _GeneralNotesObject = value; }
        }
      
        #endregion
    }
}
