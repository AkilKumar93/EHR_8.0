using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class AuthorizationDTO
    {
        #region Declarations

        private IList<Authorization> _ilstAuthorization;
        private IList<AuthorizationEncounter> _ilstAuthorizationEncounter;
        private IList<AuthorizationICD> _ilstAuthorizationICD;
        private IList<AuthorizationProcedure> _ilstAuthorizationProcedure;
        private IList<DateTime> _EncounterDate = new List<DateTime>();
        private IList<ulong> _Human_ID = new List<ulong>();
        private IList<string> _PatientName = new List<string>();
        private IList<DateTime> _PatientDOB = new List<DateTime>();
        private IList<string> _PhysicianName = new List<string>();
        private IList<string> _FacilityName = new List<string>();        
        private IList<string> _CurrProcess = new List<string>();
        private int _AuthApptTotalCount = 0;

        #endregion

         #region Constructor

        public AuthorizationDTO()
        {
            _ilstAuthorization = new List<Authorization>();
            _ilstAuthorizationEncounter = new List<AuthorizationEncounter>();
            _ilstAuthorizationICD = new List<AuthorizationICD>();
            _ilstAuthorizationProcedure = new List<AuthorizationProcedure>();      
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<Authorization> ilstAuthorization
        {
            get { return _ilstAuthorization; }
            set { _ilstAuthorization = value; }
        }
        [DataMember]
        public virtual IList<AuthorizationEncounter> ilstAuthorizationEncounter
        {
            get { return _ilstAuthorizationEncounter; }
            set { _ilstAuthorizationEncounter = value; }
        }
        [DataMember]
        public virtual IList<AuthorizationICD> ilstAuthorizationICD
        {
            get { return _ilstAuthorizationICD; }
            set { _ilstAuthorizationICD = value; }
        }
        [DataMember]
        public virtual IList<AuthorizationProcedure> ilstAuthorizationProcedure
        {
            get { return _ilstAuthorizationProcedure; }
            set { _ilstAuthorizationProcedure = value; }
        }
        [DataMember]
        public virtual IList<DateTime> EncounterDate
        {
            get { return _EncounterDate; }
            set { _EncounterDate = value; }
        }
        [DataMember]
        public virtual IList<ulong> Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual IList<string> PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }
        [DataMember]
        public virtual IList<DateTime> PatientDOB
        {
            get { return _PatientDOB; }
            set { _PatientDOB = value; }
        }
        [DataMember]
        public virtual IList<string> PhysicianName
        {
            get { return _PhysicianName; }
            set { _PhysicianName = value; }
        }
        [DataMember]
        public virtual IList<string> FacilityName
        {
            get { return _FacilityName; }
            set { _FacilityName = value; }
        }
        [DataMember]
        public virtual IList<string> CurrProcess
        {
            get { return _CurrProcess; }
            set { _CurrProcess = value; }
        }
        [DataMember]
        public virtual int AuthApptTotalCount
        {
            get { return _AuthApptTotalCount; }
            set { _AuthApptTotalCount = value; }
        }   
        #endregion
    }
}
