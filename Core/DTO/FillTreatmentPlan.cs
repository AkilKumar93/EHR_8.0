using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class FillTreatmentPlan
    {
        #region Declarations

        private IList<TreatmentPlan> _Treatment_Plan_List;
        private FillDocuments _FillDocumentList;
        private ulong _PreviousEncounterId;
        private bool _IsPhysicianProcess;

        #endregion

        #region Constructor

        public FillTreatmentPlan()
        {
            _Treatment_Plan_List = new List<TreatmentPlan>();
            _FillDocumentList = new FillDocuments();
            _IsPhysicianProcess = false;
            _PreviousEncounterId = 0;
        }

        #endregion

        #region Properties


        [DataMember]
        public virtual IList<TreatmentPlan> Treatment_Plan_List
        {
            get
            {
                return _Treatment_Plan_List;
            }
            set
            {
                _Treatment_Plan_List = value;
            }
        }

        [DataMember]
        public virtual FillDocuments FillDocumentList
        {
            get
            {
                return _FillDocumentList;
            }
            set
            {
                _FillDocumentList = value;
            }
        }

        [DataMember]
        public virtual ulong PreviousEncounterId
        {
            get
            {
                return _PreviousEncounterId;
            }
            set
            {
                _PreviousEncounterId = value;
            }
        }
        [DataMember]
        public virtual bool IsPhysicianProcess
        {
            get
            {
                return _IsPhysicianProcess;
            }
            set
            {
                _IsPhysicianProcess = value;
            }
        }
        #endregion

    }
}
