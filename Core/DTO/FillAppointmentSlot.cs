using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
  public partial class FillAppointmentSlot
  {
      #region Declarations

        private IList<DateTime> _AppointmentDate = new List<DateTime>();
        private IList<string> _AppointmentTime = new List<string>();
        private IList<string> _BlockCategory = new List<string>();
        private IList<string> _Day = new List<string>();
        private IList<ulong> _HumanId = new List<ulong>();
        

      #endregion

           #region Constructor

        public FillAppointmentSlot() { }

        #endregion

        #region Properties
        [DataMember]
        public virtual IList<DateTime> AppointmentDate
        {
            get { return _AppointmentDate; }
            set { _AppointmentDate = value; }
        }

        [DataMember]
        public virtual IList<string> AppointmentTime
        {
            get { return _AppointmentTime; }
            set { _AppointmentTime = value; }
        }

        [DataMember]
        public virtual IList<string> BlockCategory
        {
            get { return _BlockCategory; }
            set { _BlockCategory = value; }
        }

        [DataMember]
        public virtual IList<string> Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
        [DataMember]
        public virtual IList<ulong> HumanId
        {
            get { return _HumanId; }
            set { _HumanId = value; }
        }

        #endregion
  }
}
