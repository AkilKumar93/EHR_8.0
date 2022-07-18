using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
    public partial class FillOtherHistory
    {
        private IList<PhysicianPatient> _PhysicianPatientList;
        private IList<AdvanceDirective> _Advance_Directive;
        private IList<AdvanceDirectiveMaster> _Advance_Directive_Master;
        private IList<PhysicianPatientMaster> _PhysicianPatientMasterList;

        public FillOtherHistory()
        {
            _PhysicianPatientList = new List<PhysicianPatient>();
            _Advance_Directive = new List<AdvanceDirective>();
            _Advance_Directive_Master = new List<AdvanceDirectiveMaster>();
            _PhysicianPatientMasterList = new List<PhysicianPatientMaster>();
        }

         
        public virtual IList<PhysicianPatient> PhysicianPatientList
        {
            get { return _PhysicianPatientList; }
            set { _PhysicianPatientList = value; }
        }

        public virtual IList<PhysicianPatientMaster> PhysicianPatientMasterList
        {
            get { return _PhysicianPatientMasterList; }
            set { _PhysicianPatientMasterList = value; }
        }

        public virtual IList<AdvanceDirective> Advance_Directive
        {
            get { return _Advance_Directive; }
            set { _Advance_Directive = value; }
        }

        public virtual IList<AdvanceDirectiveMaster> Advance_Directive_Master
        {
            get { return _Advance_Directive_Master; }
            set { _Advance_Directive_Master = value; }
        }
    }
}