using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]

    public partial class ImmunizationDTO
    {
        #region Declarations

        private IList<Immunization> _Immunization;
        private IList<ImmunizationHistory> _ImmunizationHistoryList;
        private ulong _MaxGroupId = 0;
        // Human _ObjHuman;
        //private IList<FileManagementIndex> _fileManagementindex;
        //private ulong _file_count = 0;
        IList<PhysicianProcedure> _phyProcedureList;
        //PhysicianLibrary _objPhysician;
        IList<StaticLookup> _objStaticLookupList;
        IList<VaccineManufacturerCodes> _manufacturerList;

        #endregion


        #region Constructor

        public ImmunizationDTO()
        {
            _Immunization = new List<Immunization>();
            _ImmunizationHistoryList = new List<ImmunizationHistory>();
            _MaxGroupId = 0;
            // _ObjHuman = new Human();
            _phyProcedureList = new List<PhysicianProcedure>();
            // _objPhysician = new PhysicianLibrary();
            //  _fileManagementindex = new List<FileManagementIndex>();
        }

        #endregion


        #region Properties
        [DataMember]
        public virtual IList<Immunization> Immunization
        {
            get { return _Immunization; }
            set { _Immunization = value; }
        }

        [DataMember]
        public virtual IList<ImmunizationHistory> ImmunizationHistoryList
        {
            get { return _ImmunizationHistoryList; }
            set { _ImmunizationHistoryList = value; }
        }

        [DataMember]
        public virtual ulong MaxGroupId
        {
            get { return _MaxGroupId; }
            set { _MaxGroupId = value; }
        }

        //Commented By Suvarnni For Code Review Bug on 19.01.2016:37226
        //[DataMember]
        //public virtual Human ObjHuman
        //{
        //    get { return _ObjHuman; }
        //    set { _ObjHuman = value; }
        //}

        //[DataMember]
        //public virtual PhysicianLibrary objPhysician
        //{
        //    get { return _objPhysician; }
        //    set { _objPhysician = value; }
        //}

        //[DataMember]
        //public virtual IList<FileManagementIndex> lstFileManagementIndex
        //{
        //    get { return _fileManagementindex; }
        //    set { _fileManagementindex = value; }
        //}

        //[DataMember]
        //public virtual ulong File_Count
        //{
        //    get { return _file_count; }
        //    set { _file_count = value; }
        //}

        [DataMember]
        public virtual IList<PhysicianProcedure> phyProcedureList
        {
            get { return _phyProcedureList; }
            set { _phyProcedureList = value; }
        }

        [DataMember]
        public virtual IList<StaticLookup> objStaticLookupList
        {
            get { return _objStaticLookupList; }
            set { _objStaticLookupList = value; }
        }

        [DataMember]
        public virtual IList<VaccineManufacturerCodes> manufacturerList
        {
            get { return _manufacturerList; }
            set { _manufacturerList = value; }
        }

        #endregion
    }
}
