using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;
using System.Collections;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class FillPatientChart
    {
        private IList<PatientPane> _PatChartList;
        private FillEncounterandWFObject _Fill_Encounter_and_WFObject;
        private string _Notification = string.Empty;

        //private IList<string> _PblmListParentICD;
        //private IList<FileManagementIndex> _ScanList;
        //private IList<ProblemList> _PblmMedList;
        //private FillResultMasterAndEntry _ResultList;
        //private IList<PatientNotes> _PatientMessage = null;
        //private IList<Encounter> _Phone_Encounter = null;
        //private IList<TreatmentPlan> _Phone_Encounter_Plan = null;
       //private IList<FileManagementIndex> _SummaryList;
        //private FillPatientSummaryBarDTO _PatientSummary;
       

        #region Constructor

        public FillPatientChart()
        {
            _PatChartList = new List<PatientPane>();
            //_PblmMedList = new List<ProblemList>();
           // _Spirometry = new List<string>();
           // _ABI_Results = new List<string>();
            //_PblmListParentICD = new List<string>();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<PatientPane> PatChartList
        {
            get { return _PatChartList; }
            set
            {
                _PatChartList = value;
            }
        }
        [DataMember]
        public virtual FillEncounterandWFObject Fill_Encounter_and_WFObject
        {
            get { return _Fill_Encounter_and_WFObject; }
            set
            {
                _Fill_Encounter_and_WFObject = value;
            }
        }


        [DataMember]
        public virtual string Notification
        {
            get { return _Notification; }
            set { _Notification = value; }
        }
        //[DataMember]
        //public virtual IList<ProblemList> PblmMedList
        //{
        //    get { return _PblmMedList; }
        //    set
        //    {
        //        _PblmMedList = value;
        //    }
        //}
        //[DataMember]
        //public virtual IList<FileManagementIndex> ScanList
        //{
        //    get { return _ScanList; }
        //    set
        //    {
        //        _ScanList = value;
        //    }
        //}
        //[DataMember]
        //public virtual FillResultMasterAndEntry ResultList
        //{
        //    get { return _ResultList; }
        //    set
        //    {
        //        _ResultList = value;
        //    }
        //}

        //[DataMember]
        //public virtual IList<PatientNotes> PatientMessage
        //{
        //    get { return _PatientMessage; }
        //    set
        //    {
        //        _PatientMessage = value;
        //    }
        //}

        //[DataMember]
        //public virtual IList<Encounter> Phone_Encounter
        //{
        //    get { return _Phone_Encounter; }
        //    set
        //    {
        //        _Phone_Encounter = value;
        //    }
        //}

        //[DataMember]
        //public virtual IList<TreatmentPlan> Phone_Encounter_Plan
        //{
        //    get { return _Phone_Encounter_Plan; }
        //    set
        //    {
        //        _Phone_Encounter_Plan = value;
        //    }
        //}
       

        //[DataMember]
        //public virtual IList<FileManagementIndex> SummaryOfCare
        //{
        //    get { return _SummaryList; }
        //    set
        //    {
        //        _SummaryList = value;
        //    }
        //}
        //[DataMember]
        //public FillPatientSummaryBarDTO PatientSummary
        //{
        //    get { return _PatientSummary; }
        //    set
        //    {
        //        _PatientSummary = value;
        //    }
        //}

        //public virtual IList<string> PblmListParentICD
        //{
        //    get { return _PblmListParentICD; }
        //    set
        //    {
        //        _PblmListParentICD = value;
        //    }
        //}
        #endregion


    }
}
