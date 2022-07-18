using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
   public partial class FamilyDTO
    {
        private IList<FamilyHistory> _Family_History = null;
        private IList<FamilyHistoryMaster> _Family_History_Master = null;
        private GeneralNotes _objGeneralNotes = null;
        private IList<FamilyDisease> _Family_Disease = null;
        private IList<FamilyDiseaseMaster> _Family_Disease_Master = null;
        private IList<StaticLookup> _lStaticLookup = null;
        private IList<UserLookup> _lstUserLookup = null; 
         #region Constructor

        public FamilyDTO() 
        {
            _Family_History = new List<FamilyHistory>();
            _Family_History_Master = new List<FamilyHistoryMaster>();
            _objGeneralNotes = new GeneralNotes();
            _Family_Disease = new List<FamilyDisease>();
            _Family_Disease_Master = new List<FamilyDiseaseMaster>();
            _lStaticLookup = new List<StaticLookup>();
            _lstUserLookup = new List<UserLookup>();

        }

        #endregion

        #region Properties
       
        public virtual GeneralNotes objGeneralNotes
        {
            get { return _objGeneralNotes; }
            set { _objGeneralNotes = value; }
        }

       
        public virtual IList<FamilyHistory> Family_History
        {
            get { return _Family_History; }
            set { _Family_History = value; }
        }


        public virtual IList<FamilyHistoryMaster> Family_History_Master
        {
            get { return _Family_History_Master; }
            set { _Family_History_Master = value; }
        }

       
        public virtual IList<FamilyDisease> Family_Disease
        {
            get { return _Family_Disease; }
            set { _Family_Disease = value; }
        }

        public virtual IList<FamilyDiseaseMaster> Family_Disease_Master
        {
            get { return _Family_Disease_Master; }
            set { _Family_Disease_Master = value; }
        }
        [DataMember]
        public virtual IList<StaticLookup> lStaticLookup
        {
            get { return _lStaticLookup; }
            set { _lStaticLookup = value; }
        }
        [DataMember]
        public virtual IList<UserLookup> lstUserLookup
        {
            get { return _lstUserLookup; }
            set { _lstUserLookup = value; }
        }
        #endregion
    }
}
