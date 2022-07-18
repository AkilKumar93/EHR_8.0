using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class CallQcExceptionDto
    {
        #region Declarations

        private IList<CallLog> _CallLogList;
        private IList<AddException> _AddExceptionList;
        //private IList<Qc_Err> _Qc_ErrList;
        //added by srividhya
        private decimal _PatientExcCallQCAmount = 0;
        private decimal _CheckExcCallQCAmount = 0;
        private decimal _BatchExcCallQCAmount = 0;
        private decimal _PatientWOCheckExcCallQCAmount = 0;
        private int _AlreadyCompletedList = 0;
        private int _CompletedList = 0;
        private int _UniqueExcLineItem = 0;
        private int _UniqueCallLineItem = 0;
        private int _UniqueQCLineItem = 0;
        private int _UniqueExcAndCallLineItem = 0;
        private int _UniqueExcAndQCLineItem = 0;
        private int _UniqueCallAndQCLineItem = 0;
        private int _UniqueExcAndCallAndQCLineItem = 0;
        private int _NotStartedLineItem = 0;
        private int _TotalProcessed = 0;
        private int _iExceptionCount = 0;
        private int _iCallCount = 0;
        private int _iQCCount = 0;

        //Added by srividhya on 17-12-2013
        private decimal _UniqueExcAmount = 0;
        private decimal _UniqueCallAmount = 0;
        private decimal _UniqueQCAmount = 0;
        private decimal _UniqueExcAndCallAmount = 0;
        private decimal _UniqueExcAndQCAmount = 0;
        private decimal _UniqueCallAndQCAmount = 0;
        private decimal _UniqueExcAndCallAndQCAmount = 0;
        private decimal _CompletedAmount = 0;
        private decimal _AlreadyCompletedAmount = 0;
        private decimal _NotStartedAmount = 0;
        private decimal _TotalProcessedAmount = 0;
        private string _sCompletedList = string.Empty;

        #endregion

        #region Constructor

        public CallQcExceptionDto()
        {
            _CallLogList = new List<CallLog>();
            _AddExceptionList = new List<AddException>();
            //_Qc_ErrList = new List<Qc_Err>();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<CallLog> CallLogList
        {
            get { return _CallLogList; }
            set { _CallLogList = value; }
        }

        [DataMember]
        public virtual IList<AddException> AddExceptionList
        {
            get { return _AddExceptionList; }
            set { _AddExceptionList = value; }
        }

        //[DataMember]
        //public virtual IList<Qc_Err> Qc_ErrList
        //{
        //    get { return _Qc_ErrList; }
        //    set { _Qc_ErrList = value; }
        //}
        [DataMember]
        public virtual decimal PatientExcCallQCAmount
        {
            get { return _PatientExcCallQCAmount; }
            set { _PatientExcCallQCAmount = value; }
        }
        [DataMember]
        public virtual decimal CheckExcCallQCAmount
        {
            get { return _CheckExcCallQCAmount; }
            set { _CheckExcCallQCAmount = value; }
        }
        [DataMember]
        public virtual decimal BatchExcCallQCAmount
        {
            get { return _BatchExcCallQCAmount; }
            set { _BatchExcCallQCAmount = value; }
        }
        [DataMember]
        public virtual decimal PatientWOCheckExcCallQCAmount
        {
            get { return _PatientWOCheckExcCallQCAmount; }
            set { _PatientWOCheckExcCallQCAmount = value; }
        }
        [DataMember]
        public virtual int AlreadyCompletedList
        {
            get { return _AlreadyCompletedList; }
            set { _AlreadyCompletedList = value; }
        }
        [DataMember]
        public virtual int CompletedList
        {
            get { return _CompletedList; }
            set { _CompletedList = value; }
        }

        [DataMember]
        public virtual int UniqueExcLineItem
        {
            get { return _UniqueExcLineItem; }
            set { _UniqueExcLineItem = value; }
        }
        [DataMember]
        public virtual int UniqueCallLineItem
        {
            get { return _UniqueCallLineItem; }
            set { _UniqueCallLineItem = value; }
        }
        [DataMember]
        public virtual int UniqueQCLineItem
        {
            get { return _UniqueQCLineItem; }
            set { _UniqueQCLineItem = value; }
        }
        [DataMember]
        public virtual int UniqueExcAndCallLineItem
        {
            get { return _UniqueExcAndCallLineItem; }
            set { _UniqueExcAndCallLineItem = value; }
        }
        [DataMember]
        public virtual int UniqueExcAndQCLineItem
        {
            get { return _UniqueExcAndQCLineItem; }
            set { _UniqueExcAndQCLineItem = value; }
        }
        [DataMember]
        public virtual int UniqueCallAndQCLineItem
        {
            get { return _UniqueCallAndQCLineItem; }
            set { _UniqueCallAndQCLineItem = value; }
        }
        [DataMember]
        public virtual int UniqueExcAndCallAndQCLineItem
        {
            get { return _UniqueExcAndCallAndQCLineItem; }
            set { _UniqueExcAndCallAndQCLineItem = value; }
        }
        [DataMember]
        public virtual int NotStartedLineItem
        {
            get { return _NotStartedLineItem; }
            set { _NotStartedLineItem = value; }
        }
        [DataMember]
        public virtual int TotalProcessed
        {
            get { return _TotalProcessed; }
            set { _TotalProcessed = value; }
        }
        [DataMember]
        public virtual int iExceptionCount
        {
            get { return _iExceptionCount; }
            set { _iExceptionCount = value; }
        }
        [DataMember]
        public virtual int iCallCount
        {
            get { return _iCallCount; }
            set { _iCallCount = value; }
        }
        [DataMember]
        public virtual int iQCCount
        {
            get { return _iQCCount; }
            set { _iQCCount = value; }
        }
        
        [DataMember]
        public virtual decimal UniqueExcAmount
        {
            get { return _UniqueExcAmount; }
            set { _UniqueExcAmount = value; }
        }
        [DataMember]
        public virtual decimal UniqueCallAmount
        {
            get { return _UniqueCallAmount; }
            set { _UniqueCallAmount = value; }
        }
        [DataMember]
        public virtual decimal UniqueQCAmount
        {
            get { return _UniqueQCAmount; }
            set { _UniqueQCAmount = value; }
        }
        [DataMember]
        public virtual decimal UniqueExcAndCallAmount
        {
            get { return _UniqueExcAndCallAmount; }
            set { _UniqueExcAndCallAmount = value; }
        }
        [DataMember]
        public virtual decimal UniqueExcAndQCAmount
        {
            get { return _UniqueExcAndQCAmount; }
            set { _UniqueExcAndQCAmount = value; }
        }
        [DataMember]
        public virtual decimal UniqueCallAndQCAmount
        {
            get { return _UniqueCallAndQCAmount; }
            set { _UniqueCallAndQCAmount = value; }
        }
        [DataMember]
        public virtual decimal UniqueExcAndCallAndQCAmount
        {
            get { return _UniqueExcAndCallAndQCAmount; }
            set { _UniqueExcAndCallAndQCAmount = value; }
        }
        [DataMember]
        public virtual decimal CompletedAmount
        {
            get { return _CompletedAmount; }
            set { _CompletedAmount = value; }
        }
        [DataMember]
        public virtual decimal AlreadyCompletedAmount
        {
            get { return _AlreadyCompletedAmount; }
            set { _AlreadyCompletedAmount = value; }
        }
        [DataMember]
        public virtual decimal NotStartedAmount
        {
            get { return _NotStartedAmount; }
            set { _NotStartedAmount = value; }
        }
        [DataMember]
        public virtual decimal TotalProcessedAmount
        {
            get { return _TotalProcessedAmount; }
            set { _TotalProcessedAmount = value; }
        }
        [DataMember]
        public virtual string sCompletedList
        {
            get { return _sCompletedList; }
            set { _sCompletedList = value; }
        }
        #endregion
    }
}
