using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class MoveVerificationDTO
    {
        #region Declarations
      
        bool _EAndMIsPrimaryFilled = false;
        bool _IsWorkflowPushed = false;
        string _ExceptionCreatedBy = string.Empty;
        int _ExceptionCount = 0;
        bool _IsFeedBackProvided = false;
        string _IsPFSHVerified = string.Empty;
        IList<EAndMCoding> _EandMCodingList = new List<EAndMCoding>();
        bool _IsGcodePresent = false;
        bool _IsICDPresent = false;
        bool _IsDuplicatePresent = false;
        bool _IsACOValid = false;
        FillEandMCoding _EandMdtoList = new FillEandMCoding();
        bool _IsICDFilled= false;



        #endregion

        #region Properties

      
        [DataMember]
        public virtual bool EAndMIsPrimaryFilled
        {
            get { return _EAndMIsPrimaryFilled; }
            set { _EAndMIsPrimaryFilled = value; }
        }
        [DataMember]
        public virtual bool IsWorkflowPushed
        {
            get { return _IsWorkflowPushed; }
            set { _IsWorkflowPushed = value; }
        }
        [DataMember]
        public virtual string ExceptionCreatedBy
        {
            get { return _ExceptionCreatedBy; }
            set { _ExceptionCreatedBy = value; }
        }
        [DataMember]
        public virtual bool IsFeedBackProvided
        {
            get { return _IsFeedBackProvided; }
            set { _IsFeedBackProvided = value; }
        }
        [DataMember]
        public virtual int ExceptionCount
        {
            get { return _ExceptionCount; }
            set { _ExceptionCount = value; }
        }
        [DataMember]
        public virtual string IsPFSHVerified
        {
            get { return _IsPFSHVerified; }
            set { _IsPFSHVerified = value; }
        }

        [DataMember]
        public virtual IList<EAndMCoding> EandMCodingList
        {
            get { return _EandMCodingList; }
            set { _EandMCodingList = value; }
        }
        [DataMember]
        public virtual bool IsGcodePresent
        {
            get { return _IsGcodePresent; }
            set { _IsGcodePresent = value; }
        }

        [DataMember]
        public virtual bool IsICDPresent
        {
            get { return _IsICDPresent; }
            set { _IsICDPresent = value; }
        }

        [DataMember]
        public virtual bool IsDuplicatePresent
        {
            get { return _IsDuplicatePresent; }
            set { _IsDuplicatePresent = value; }
        }
        [DataMember]
        public virtual bool IsACOValid
        {
            get { return _IsACOValid; }
            set { _IsACOValid = value; }
        }
        [DataMember]
        public virtual FillEandMCoding EandMdtoList
        {
            get { return _EandMdtoList; }
            set { _EandMdtoList = value; }
        }

        [DataMember]
        public virtual bool IsICDFilled
        {
            get { return _IsICDFilled; }
            set { _IsICDFilled = value; }
        }
        #endregion



    }
}
