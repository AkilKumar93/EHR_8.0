using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;
using System.Data;

namespace Acurus.Capella.Core.DTO
{

    [Serializable]
    public partial class PatientResultsDTO
    {
        #region Decalration
        private IList<PatientResults> _VitalsList;
        private IList<object> _ObjList;
        private DataSet _dsLatestResults;
        private ulong _MaxGroupId = 0;
        private int _VitalCount = 0;
        private string _sNotification = string.Empty;
        #endregion

        #region Constructors
        public PatientResultsDTO()
        {
            _VitalsList = new List<PatientResults>();
            _ObjList = new List<object>();
            _dsLatestResults = new DataSet();
        }
        #endregion

        #region Properties


        public virtual IList<PatientResults> VitalsList
        {
            get { return _VitalsList; }
            set { _VitalsList = value; }
        }
        public virtual IList<object> ObjList
        {
            get { return _ObjList; }
            set { _ObjList = value; }
        }
        public virtual ulong MaxGroupId
        {
            get { return _MaxGroupId; }
            set { _MaxGroupId = value; }
        }

        public virtual int VitalCount
        {
            get { return _VitalCount; }
            set { _VitalCount = value; }
        }

        public virtual DataSet dsLatestResults
        {
            get { return _dsLatestResults; }
            set { _dsLatestResults = value; }
        }

        //public virtual string sNotification
        //{
        //    get { return _sNotification; }
        //    set { _sNotification = value; }
        //}
        #endregion


    }
}
