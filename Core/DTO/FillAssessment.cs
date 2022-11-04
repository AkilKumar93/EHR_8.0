using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class FillAssessment
    {
        #region Declarations
        private IList<Assessment> _Assessment = null;
        private IList<ProblemList> _Problem_List = null;
        //private IList<ProblemList> _Problem_List_Human = null;
        private IList<GeneralNotes> _General_Notes = null;
        //private IList<PhysicianICD_9> _PhysicianICD_9 = null;
        private IList<string> _VitalsBasedICD_List = null;
        private IList<Assessment> _AssessmentCurrentList = null;
        private IList<GeneralNotes> _General_NotesCurrentList = null;
        private ulong _PEncID = 0;
        private bool _physician_process;
        private string _sNofitication;
        private IList<PotentialDiagnosis> _Potential_Diagnosis = null;
        private IList<EandMCodingICD> _EandMICD = null;

        #endregion

        #region Constructor

        public FillAssessment()
        {
            _Assessment = new List<Assessment>();
            _Problem_List = new List<ProblemList>();
            //_Problem_List_Human = new List<ProblemList>();
            _General_Notes = new List<GeneralNotes>();

            _VitalsBasedICD_List = new List<string>();
            _AssessmentCurrentList = new List<Assessment>();
            _General_NotesCurrentList = new List<GeneralNotes>();
            //_PhysicianICD_9 = new List<PhysicianICD_9>();
            _physician_process = false;
            sNofitication = string.Empty;
            _EandMICD = new List<EandMCodingICD>();


        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<Assessment> Assessment
        {
            get { return _Assessment; }
            set { _Assessment = value; }
        }

        [DataMember]
        public virtual IList<ProblemList> Problem_List
        {
            get { return _Problem_List; }
            set { _Problem_List = value; }
        }

        //[DataMember]
        //public virtual IList<ProblemList> Problem_List_Human
        //{
        //    get { return _Problem_List_Human; }
        //    set { _Problem_List_Human = value; }
        //}

        [DataMember]
        public virtual IList<GeneralNotes> General_Notes
        {
            get { return _General_Notes; }
            set { _General_Notes = value; }
        }

        [DataMember]
        public virtual IList<string> VitalsBasedICD_List
        {
            get { return _VitalsBasedICD_List; }
            set { _VitalsBasedICD_List = value; }
        }
        [DataMember]
        public ulong PEncID
        {
            get { return _PEncID; }
            set { _PEncID = value; }
        }
        [DataMember]
        public virtual IList<Assessment> AssessmentCurrentList
        {
            get { return _AssessmentCurrentList; }
            set { _AssessmentCurrentList = value; }
        }
        [DataMember]
        public virtual IList<GeneralNotes> General_NotesCurrentList
        {
            get { return _General_NotesCurrentList; }
            set { _General_NotesCurrentList = value; }
        }
        [DataMember]
        public virtual bool Physician_Process
        {
            get { return _physician_process; }
            set { _physician_process = value; }
        }

        [DataMember]
        public virtual string sNofitication
        {
            get { return _sNofitication; }
            set { _sNofitication = value; }
        }
        [DataMember]
        public virtual IList<PotentialDiagnosis> Potential_Diagnosis
        {
            get { return _Potential_Diagnosis; }
            set { _Potential_Diagnosis = value; }
        }
        public virtual IList<EandMCodingICD> EandMICD
        {
            get { return _EandMICD; }
            set { _EandMICD = value; }
        }
        #endregion
    }
}
