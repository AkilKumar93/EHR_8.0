using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillResultDTO
    {
        private IList<ResultMaster> _ResultMasterList = null;
        private IList<ResultORC> _ResultORCList = null;
        private IList<ResultOBR> _ResultOBRList = null;
        private IList<ResultOBX> _ResultOBXList = null;
        private IList<ResultNTE> _ResultNTEList = null;
        private IList<ResultZEF> _ResultZEFList = null;
        private IList<ResultZPS> _ResultZPSList = null;
        //private IList<ResultLookup> _ResultLookupList = null;
        private DateTime _Encounter_Date_Of_Service=new DateTime();
        private ulong _Lab_ID=0;
        //sarava
        private IList<ResultSPM> _ResultSPMList = null;

        public FillResultDTO()
        {
            _ResultMasterList = new List<ResultMaster>();
            _ResultORCList = new List<ResultORC>();
            _ResultOBRList = new List<ResultOBR>();
            _ResultOBXList = new List<ResultOBX>();
            _ResultNTEList = new List<ResultNTE>();
            _ResultZEFList = new List<ResultZEF>();
            _ResultZPSList = new List<ResultZPS>();
            _ResultSPMList = new List<ResultSPM>();
        }

        [DataMember]
        public virtual IList<ResultMaster> ResultMasterList
        {
            get { return _ResultMasterList; }
            set { _ResultMasterList = value; }
        }
        [DataMember]
        public virtual IList<ResultORC> ResultORCList
        {
            get { return _ResultORCList; }
            set { _ResultORCList = value; }
        }
        [DataMember]
        public virtual IList<ResultOBR> ResultOBRList
        {
            get { return _ResultOBRList; }
            set { _ResultOBRList = value; }
        }
        [DataMember]
        public virtual IList<ResultOBX> ResultOBXList
        {
            get { return _ResultOBXList; }
            set { _ResultOBXList = value; }
        }
        [DataMember]
        public virtual IList<ResultNTE> ResultNTEList
        {
            get { return _ResultNTEList; }
            set { _ResultNTEList = value; }
        }
        [DataMember]
        public virtual IList<ResultZEF> ResultZEFList
        {
            get { return _ResultZEFList; }
            set { _ResultZEFList = value; }
        }
        [DataMember]
        public virtual IList<ResultZPS> ResultZPSList
        {
            get { return _ResultZPSList; }
            set { _ResultZPSList = value; }
        }
        //[DataMember]
        //public virtual IList<ResultLookup> ResultLookupList
        //{
        //    get { return _ResultLookupList; }
        //    set { _ResultLookupList = value; }
        //}

        [DataMember]
        public virtual DateTime Encounter_Date_Of_Service
        {
            get { return _Encounter_Date_Of_Service; }
            set { _Encounter_Date_Of_Service = value; }
        }
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        [DataMember]
        public virtual IList<ResultSPM> ResultSPMList
        {
            get { return _ResultSPMList; }
            set { _ResultSPMList = value; }
        }
    }
}
