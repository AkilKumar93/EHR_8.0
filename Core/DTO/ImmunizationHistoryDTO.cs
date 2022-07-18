using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;



namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]

    public partial class ImmunizationHistoryDTO
    {
        #region Declarations

        private IList<ImmunizationHistory> _Immunization;
        private IList<ImmunizationMasterHistory> _ImmunizationMasterList;
        //private IList<ImmunizationPortalHistory> _ImmunizationPortalList;
        private int _ImmunizationCount = 0;
        private IList<PhysicianProcedure> _PhysicianProcedure;
        private IList<VaccineManufacturerCodes> _VaccineManufacturerCodes;
        private IList<ProcedureCodeLibrary> _ProcedureCodeLibrary;

        #endregion


        #region Constructor

        public ImmunizationHistoryDTO()
        {
            _Immunization = new List<ImmunizationHistory>();
            _ImmunizationMasterList = new List<ImmunizationMasterHistory>();
          //  _ImmunizationPortalList = new List<ImmunizationPortalHistory>();

        }

        #endregion


        #region Properties
        [DataMember]
        public virtual IList<ImmunizationHistory> Immunization
        {
            get { return _Immunization; }
            set { _Immunization = value; }
        }

        [DataMember]
        public virtual IList<ImmunizationMasterHistory> ImmunizationMasterList
        {
            get { return _ImmunizationMasterList; }
            set { _ImmunizationMasterList = value; }
        }

        //[DataMember]
        //public virtual IList<ImmunizationPortalHistory> ImmunizationPortalList
        //{
        //    get { return _ImmunizationPortalList; }
        //    set { _ImmunizationPortalList = value; }
        //}


        [DataMember]
        public virtual int ImmunizationCount
        {
            get { return _ImmunizationCount; }
            set { _ImmunizationCount = value; }
        }
        [DataMember]
        public virtual IList<PhysicianProcedure> PhysicianProcedure
        {
            get { return _PhysicianProcedure; }
            set { _PhysicianProcedure = value; }
        }
        [DataMember]
        public virtual IList<VaccineManufacturerCodes> VaccineManufacturerCodes
        {
            get { return _VaccineManufacturerCodes; }
            set { _VaccineManufacturerCodes = value; }
        }
        [DataMember]
        public virtual IList<ProcedureCodeLibrary> ProcedureCodeLibrary
        {
            get { return _ProcedureCodeLibrary; }
            set { _ProcedureCodeLibrary = value; }
        }
        #endregion
    }
}