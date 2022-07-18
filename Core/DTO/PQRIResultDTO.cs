using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class PQRIResultDTO
    {
        private ulong _EncounterID = 0;
        private ulong _HumanID = 0;
        private string _ICD = string.Empty;
        private string _ProcedureCode = string.Empty;
        private string _Value = string.Empty;
        private string _LoincIdentifier = string.Empty;
        private DateTime _ResultDateandTime = DateTime.MinValue;
        private string _MeasureNo = string.Empty;
        private string _Recodes = string.Empty;
        private string _NDCID = string.Empty;
        private string _MeasureName = string.Empty;



        [DataMember]
        public virtual ulong EncounterID
        {
            get { return _EncounterID; }
            set { _EncounterID = value; }
        }
        [DataMember]
        public virtual ulong HumanID
        {
            get { return _HumanID; }
            set { _HumanID = value; }
        }
        [DataMember]
        public virtual string ICD
        {
            get { return _ICD; }
            set { _ICD = value; }
        }
        [DataMember]
        public virtual string ProcedureCode
        {
            get { return _ProcedureCode; }
            set { _ProcedureCode = value; }
        }
        [DataMember]
        public virtual string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        [DataMember]
        public virtual string LoincIdentifier
        {
            get { return _LoincIdentifier; }
            set { _LoincIdentifier = value; }
        }
        [DataMember]
        public virtual DateTime ResultDateandTime
        {
            get { return _ResultDateandTime; }
            set { _ResultDateandTime = value; }
        }
        [DataMember]
        public virtual string MeasureNo
        {
            get { return _MeasureNo; }
            set { _MeasureNo = value; }
        }
        [DataMember]
        public virtual string Recodes
        {
            get { return _Recodes; }
            set { _Recodes = value; }
        }
        [DataMember]
        public virtual string NDCID
        {
            get { return _NDCID; }
            set { _NDCID = value; }
        }

        [DataMember]
        public virtual string MeasureName
        {
            get { return _MeasureName; }
            set { _MeasureName = value; }
        }
    }


}
