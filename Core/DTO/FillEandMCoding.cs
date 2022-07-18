using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class FillEandMCoding
    {
        private IList<Assessment> _AssessmentList = new List<Assessment>();
        private IList<ProblemList> _ProblemList = new List<ProblemList>();
        private IList<EAndMCoding> _EandMCodingList = new List<EAndMCoding>();
        private IList<EandMCodingICD> _EandMCodingICDList = new List<EandMCodingICD>();
        private IList<Encounter> _EncounterList = new List<Encounter>();
        //private IList<ulong> _OrderProcedureID = new List<ulong>();
        //private IList<string> _OrderProcedure = new List<string>();
        //private IList<string> _OrderProcedureDesc = new List<string>();
        private IList<ulong> _ImmunProcedureID = new List<ulong>();
        private IList<string> _ImmunProcedure = new List<string>();
        private IList<string> _ImmunProcedureDesc = new List<string>();
        private IList<ulong> _InhouseProcedureID = new List<ulong>();
        private IList<string> _InhouseProcedure = new List<string>();
        private IList<string> _InhouseProcedureDesc = new List<string>();
        private IList<string> _ProcedureMasterList = new List<string>();
        private IList<string> _ProcList = new List<string>();
        private IList<string> _ICDList = new List<string>();
        private string _BillingWFObjCurrentProcess = string.Empty;

        [DataMember]
        public IList<Assessment> AssessmentList
        {
            get { return _AssessmentList; }
            set { _AssessmentList = value; }
        }
        [DataMember]
        public IList<ProblemList> ProblemList
        {
            get { return _ProblemList; }
            set { _ProblemList = value; }
        }
        [DataMember]
        public IList<EAndMCoding> EandMCodingList
        {
            get { return _EandMCodingList; }
            set { _EandMCodingList = value; }
        }
        [DataMember]
        public IList<EandMCodingICD> EandMCodingICDList
        {
            get { return _EandMCodingICDList; }
            set { _EandMCodingICDList = value; }
        }
        [DataMember]
        public IList<Encounter> EncounterList
        {
            get { return _EncounterList; }
            set { _EncounterList = value; }
        }
        //[DataMember]
        //public IList<string> OrderProcedure
        //{
        //    get { return _OrderProcedure; }
        //    set { _OrderProcedure = value; }
        //}
        //[DataMember]
        //public IList<string> OrderProcedureDesc
        //{
        //    get { return _OrderProcedureDesc; }
        //    set { _OrderProcedureDesc = value; }
        //}
        //[DataMember]
        //public IList<ulong> OrderProcedureID
        //{
        //    get { return _OrderProcedureID; }
        //    set { _OrderProcedureID = value; }
        //}
        [DataMember]
        public IList<string> ImmunProcedure
        {
            get { return _ImmunProcedure; }
            set { _ImmunProcedure = value; }
        }
        [DataMember]
        public IList<string> ImmunProcedureDesc
        {
            get { return _ImmunProcedureDesc; }
            set { _ImmunProcedureDesc = value; }
        }
        [DataMember]
        public IList<ulong> ImmunProcedureID
        {
            get { return _ImmunProcedureID; }
            set { _ImmunProcedureID = value; }
        }
        [DataMember]
        public IList<ulong> InhouseProcedureID
        {
            get { return _InhouseProcedureID; }
            set { _InhouseProcedureID = value; }
        }
        [DataMember]
        public IList<string> InhouseProcedure
        {
            get { return _InhouseProcedure; }
            set { _InhouseProcedure = value; }
        }
        [DataMember]
        public IList<string> InhouseProcedureDesc
        {
            get { return _InhouseProcedureDesc; }
            set { _InhouseProcedureDesc = value; }
        }
        [DataMember]
        public IList<string> ProcedureMasterList
        {
            get { return _ProcedureMasterList; }
            set { _ProcedureMasterList = value; }
        }
        [DataMember]
        public IList<string> ProcList
        {
            get { return _ProcList; }
            set { _ProcList = value; }
        }
        [DataMember]
        public IList<string> ICDList
        {
            get { return _ICDList; }
            set { _ICDList = value; }
        }
        [DataMember]
        public string BillingWFObjCurrentProcess
        {
            get { return _BillingWFObjCurrentProcess; }
            set { _BillingWFObjCurrentProcess = value; }
        }
    }
}
