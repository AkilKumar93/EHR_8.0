using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class AppointmentPreChecks
    {
           #region Declarations

        private IList<Encounter> _SamePatient = new List<Encounter>();
        private IList<Encounter> _DifferentPatient = new List<Encounter>();
        bool _bBlock = false;
        private IList<Encounter> _CurrentEncounter = new List<Encounter>();
        private string _Block_Type = string.Empty;

        #endregion

        #region Constructor

        public AppointmentPreChecks()
        {

        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<Encounter> SamePatient
        {
            get { return _SamePatient; }
            set { _SamePatient = value; }
        }
        [DataMember]
        public virtual IList<Encounter> DifferentPatient
        {
            get { return _DifferentPatient; }
            set { _DifferentPatient = value; }
        }
        [DataMember]
        public virtual bool bBlock
        {
            get { return _bBlock; }
            set { _bBlock = value; }
        }
        [DataMember]
        public virtual IList<Encounter> CurrentEncounter
        {
            get { return _CurrentEncounter; }
            set { _CurrentEncounter = value; }
        }

        [DataMember]
        public virtual string Block_Type
        {
            get { return _Block_Type; }
            set { _Block_Type = value; }
        }

       #endregion
    }
}
