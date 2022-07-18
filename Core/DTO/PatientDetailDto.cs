using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class PatientDetailDto
    {
          #region Declarations

        private IList<PatientNotes> _ilstPatientNotes;
        private IList<WFObject> _ilstWFObj;
        private IList<User> _ilstUser;

        #endregion

        #region Constructor

        public PatientDetailDto()
        {
            _ilstPatientNotes = new List<PatientNotes>();
            _ilstWFObj = new List<WFObject>();
            _ilstUser = new List<User>();


        }

        #endregion

        #region Properties

      
        [DataMember]
        public virtual IList<PatientNotes> ilstPatientNotes
        {
            get { return _ilstPatientNotes; }
            set { _ilstPatientNotes = value; }
        }
        [DataMember]
        public virtual IList<WFObject> ilstWFObj
        {
            get { return _ilstWFObj; }
            set { _ilstWFObj = value; }
        }
        [DataMember]
        public virtual IList<User> ilstUser
        {
            get { return _ilstUser; }
            set { _ilstUser = value; }
        }
        #endregion

    }
}
