using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{

    [Serializable]
    public partial class SurgicalHistoryDTO
    {
        #region Declarations
        private IList<SurgicalHistory> _SurgicalList = null;
        private IList<SurgicalHistoryMaster> _SurgicalMasterList = null;
        private GeneralNotes _GeneralNotesObject = null;
        private DateTime _PatientDOB = DateTime.MinValue;
        private Dictionary<ulong, DateTime> _dictSurgeryDate = new Dictionary<ulong, DateTime>();
        private int _SurgicalCount = 0;

        #endregion

        #region Constructor

        public SurgicalHistoryDTO() { }

        #endregion

        #region Properties
        public virtual IList<SurgicalHistory> SurgicalList
        {
            get { return _SurgicalList; }
            set { _SurgicalList = value; }
        }


        public virtual IList<SurgicalHistoryMaster> SurgicalMasterList
        {
            get { return _SurgicalMasterList; }
            set { _SurgicalMasterList = value; }
        }
        public virtual GeneralNotes GeneralNotesObject
        {
            get { return _GeneralNotesObject; }
            set { _GeneralNotesObject = value; }
        }
        public virtual int SurgicalCount
        {
            get { return _SurgicalCount; }
            set { _SurgicalCount = value; }
        }
        public virtual DateTime PatientDOB
        {
            get { return _PatientDOB; }
            set { _PatientDOB = value; }
        }
        public virtual Dictionary<ulong, DateTime> dictSurgeryDate
        {
            get { return _dictSurgeryDate; }
            set { _dictSurgeryDate = value; }
        }
        #endregion
    }
}
