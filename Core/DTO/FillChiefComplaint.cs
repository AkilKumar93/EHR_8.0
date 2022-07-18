using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    // [DataContract]
    public partial class FillChiefComplaint
    {
        
       private string _purpose_of_visit = string.Empty;
   
       // private IList<ChiefComplaints> _previousEncounterList;
        private IList<ChiefComplaints> _CopypreviousEncounterList;
        private IList<ChiefComplaints> _currentCCList;

        private ulong _PEncID = 0;
        private bool _physician_process;

        #region Constructors

        public FillChiefComplaint()
        {
            //_ccList = new List<ChiefComplaints>();
            //_previousEncounterList = new List<ChiefComplaints>();
            //_CopypreviousEncounterList = new List<ChiefComplaints>();
            _currentCCList = new List<ChiefComplaints>();
           _physician_process = false;

            
        }

        #endregion

        #region Properties


        [DataMember]
        public virtual string Purpose_Of_Visit
        {
            get { return _purpose_of_visit; }
            set { _purpose_of_visit = value; }
        }

     

        //[DataMember]
        //public virtual IList<ChiefComplaints> PreviousEncounterList
        //{
        //    get { return _previousEncounterList; }
        //    set { _previousEncounterList = value; }
        //}
        [DataMember]
        public virtual IList<ChiefComplaints> CopypreviousEncounterList
        {
            get { return _CopypreviousEncounterList; }
            set { _CopypreviousEncounterList = value; }
        }

        [DataMember]
        public virtual IList<ChiefComplaints> CurrentCCList
        {
            get { return _currentCCList; }
            set { _currentCCList = value; }
        }
        [DataMember]
        public ulong PEncID
        {
            get { return _PEncID; }
            set { _PEncID = value; }
        }
        [DataMember]
        public virtual bool Physician_Process
        {
            get { return _physician_process; }
            set { _physician_process = value; }
        }


       


        #endregion
    }
}
