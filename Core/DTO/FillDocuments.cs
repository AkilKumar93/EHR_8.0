using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
   public partial class FillDocuments
    {
        #region Declarations

        private IList<Documents> _DocumentsList;
        private Encounter  _EncounterObj;
        private IList<TreatmentPlan> _Treatment_Plan_List;
        private string _EncPhyuserName=string.Empty;
        private IList<PhysicianLibrary> _lstPhysicianLibrary;
        private IList<UserLookup> _lstUserLookup;
        private IList<StaticLookup> _lstStaticLookup;

        #endregion

        #region Constructor

        public FillDocuments()
        {
            _DocumentsList = new List<Documents>();
            _EncounterObj = new Encounter();
            _Treatment_Plan_List = new List<TreatmentPlan>();
            _EncPhyuserName = string.Empty;
            _lstPhysicianLibrary = new List<PhysicianLibrary>();
            _lstUserLookup = new List<UserLookup>();
            _lstStaticLookup = new List<StaticLookup>();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<Documents> DocumentsList
        {
            get { return _DocumentsList; }
            set { _DocumentsList = value; }
        }
        [DataMember]
        public virtual Encounter EncounterObj
        {
            get { return _EncounterObj; }
            set { _EncounterObj = value; }
        }
        [DataMember]
        public virtual IList<TreatmentPlan> Treatment_Plan_List
        {
            get { return _Treatment_Plan_List; }
            set { _Treatment_Plan_List = value; }
        }
        [DataMember]
        public virtual string EncPhyuserName
        {
            get { return _EncPhyuserName; }
            set { _EncPhyuserName = value; }
        }
        [DataMember]
        public virtual IList<PhysicianLibrary> PhysicianLibraryList
        {
            get { return _lstPhysicianLibrary; }
            set { _lstPhysicianLibrary = value; }
        }
        [DataMember]
        public virtual IList<UserLookup> lstUserLookup
        {
            get { return _lstUserLookup; }
            set { _lstUserLookup = value; }
        }
        [DataMember]
        public virtual IList<StaticLookup> lstStaticLookup
        {
            get { return _lstStaticLookup; }
            set { _lstStaticLookup = value; }
        }
        #endregion
    }
}
