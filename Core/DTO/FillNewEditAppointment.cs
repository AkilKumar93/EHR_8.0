using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillNewEditAppointment
    {
        private Encounter _EncounterRecord = new Encounter();
        private ulong _Human_ID = 0;
        private string _sLastName = string.Empty;
        private string _sFirstName = string.Empty;
        private string _sMI = string.Empty;
        private string _sSuffix = string.Empty;
        private DateTime _dtBirthDate=DateTime.MinValue;
        private string _sHomePhoneNo = string.Empty;
        private string _sCellPhoneNo = string.Empty;
        private string _sTest = string.Empty;
        private IList<string> _CptAndItsOrderId = new List<string>();
        private ulong _AuthorizationId = 0;
        private string _HumanType = string.Empty;
        private int _Encounter_Provider_ID = 0;
        //Added by srividhya on 15-Oct-2013
        private string _AuthNo = string.Empty;
        private Boolean _bAuthcount = false;

        #region Properties

        [DataMember]
        public virtual Encounter EncounterRecord
        {
            get { return _EncounterRecord; }
            set { _EncounterRecord = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Last_Name
        {
            get { return _sLastName; }
            set { _sLastName = value; }
        }
        [DataMember]
        public virtual string First_Name
        {
            get { return _sFirstName; }
            set { _sFirstName = value; }
        }
        [DataMember]
        public virtual string MI
        {
            get { return _sMI; }
            set { _sMI = value; }
        }
        [DataMember]
        public virtual string Suffix
        {
            get { return _sSuffix; }
            set { _sSuffix = value; }
        }
        [DataMember]
        public virtual DateTime Birth_Date
        {
            get { return _dtBirthDate; }
            set { _dtBirthDate = value; }
        }
        [DataMember]
        public virtual string Home_Phone_No
        {
            get { return _sHomePhoneNo; }
            set { _sHomePhoneNo = value; }
        }
        [DataMember]
        public virtual string Cell_Phone_No
        {
            get { return _sCellPhoneNo; }
            set { _sCellPhoneNo = value; }
        }
        [DataMember]
        public virtual string Test
        {
            get { return _sTest; }
            set { _sTest = value; }
        }
        [DataMember]
        public virtual IList<string> CptAndItsOrderId
        {
            get { return _CptAndItsOrderId; }
            set { _CptAndItsOrderId = value; }
        }
        [DataMember]
        public virtual ulong AuthorizationId
        {
            get { return _AuthorizationId; }
            set { _AuthorizationId = value; }
        }
        [DataMember]
        public virtual string HumanType
        {
            get { return _HumanType; }
            set { _HumanType = value; }
        }
        [DataMember]
        public virtual string AuthNo
        {
            get { return _AuthNo; }
            set { _AuthNo = value; }
        }

        [DataMember]
        public virtual Boolean bAuthcount
        {
            get { return _bAuthcount; }
            set { _bAuthcount = value; }
        }
        [DataMember]
        public virtual int Encounter_Provider_ID
        {
            get { return _Encounter_Provider_ID; }
            set { _Encounter_Provider_ID = value; }
        }
        #endregion 
    }
}
