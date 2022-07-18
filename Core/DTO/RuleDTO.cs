using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class RuleDTO
    {
        #region Declarations
        private RuleMaster _Rule_Master;
        private IList<RuleProblem> _Rule_Problem;
        private IList<RuleMedicationAndAllergy> _Rule_Medication_And_Allergy;
        private IList<RuleLabResultReminder> _Rule_lab_Result_Reminder;
        #endregion

         #region Constructor

        public RuleDTO() { }

        #endregion

        #region Properties
        [DataMember]
        public virtual IList<RuleProblem> Rule_Problem
        {
            get { return _Rule_Problem; }
            set { _Rule_Problem = value; }
        }

        [DataMember]
        public virtual IList<RuleMedicationAndAllergy> Rule_Medication_And_Allergy
        {
            get { return _Rule_Medication_And_Allergy; }
            set { _Rule_Medication_And_Allergy = value; }
        }


        [DataMember]
        public virtual IList<RuleLabResultReminder> Rule_lab_Result_Reminder
        {
            get { return _Rule_lab_Result_Reminder; }
            set { _Rule_lab_Result_Reminder = value; }
        }
        
        
        
         [DataMember]
        public virtual RuleMaster Rule_Master
        {
            get { return _Rule_Master; }
            set { _Rule_Master = value; }
        }
        #endregion
    }
}
