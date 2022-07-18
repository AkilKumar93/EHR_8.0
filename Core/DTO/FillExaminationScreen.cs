using Acurus.Capella.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillExaminationScreen
    {
       // private string _ExamDetails = string.Empty;
        private string _System = string.Empty;
        private string _Condition = string.Empty;
        private string _Status = string.Empty;
        private string _Notes = string.Empty;       
        private ulong _ExaminationID = 0;
        private int _Version = 0;      
        private string _CreatedBy = string.Empty;
        private DateTime _CreatedDateTime = DateTime.MinValue;               
        private ulong _PEnc = 0;
        private bool _physician_process;
        private IList<Examination> _CopypreviousEncounterList;


        #region Constructor

        public FillExaminationScreen() 
        {
            _physician_process = false;

        }
        #endregion
        //[DataMember]
        //public string ExamDetails
        //{
        //    get { return _ExamDetails; }
        //    set { _ExamDetails = value; }
        //}

        #region Properties

        [DataMember]
        public virtual IList<Examination> CopypreviousEncounterList
        {
            get { return _CopypreviousEncounterList; }
            set { _CopypreviousEncounterList = value; }
        }
        [DataMember]
        public string System
        {
            get { return _System; }
            set { _System = value; }
        }
        [DataMember]
        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }
        [DataMember]
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [DataMember]
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }       
       
       
        [DataMember]
        public ulong ExaminationID
        {
            get { return _ExaminationID; }
            set { _ExaminationID = value; }
        }
        [DataMember]
        public int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public ulong PEnc
        {
            get { return _PEnc; }
            set { _PEnc = value; }
        }
     
        [DataMember]
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [DataMember]
        public DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            set { _CreatedDateTime = value; }
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
