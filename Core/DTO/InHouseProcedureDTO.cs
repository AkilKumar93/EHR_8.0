using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]

    public partial class InHouseProcedureDTO
    {
        #region Declarations

        private IList<InHouseProcedure> _OtherProcedure;
        private ulong _MaxGroupId = 0;
        private ulong _Current_Submited_In_House_Procedure_Id = 0;
        //private ulong _file_count = 0;
        private IList<FileManagementIndex> _fileManagementindex;
        private IList<PhysicianProcedure> _procedureList;
        #endregion


        #region Constructor

        public InHouseProcedureDTO()
        {
            _OtherProcedure = new List<InHouseProcedure>();
            _fileManagementindex = new List<FileManagementIndex>();
            _procedureList = new List<PhysicianProcedure>();
            _MaxGroupId = 0;
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual IList<InHouseProcedure> OtherProcedure
        {
            get { return _OtherProcedure; }
            set { _OtherProcedure = value; }
        }

        [DataMember]
        public virtual ulong MaxGroupId
        {
            get { return _MaxGroupId; }
            set { _MaxGroupId = value; }
        }
        [DataMember]
        public virtual ulong Current_Submited_In_House_Procedure_Id
        {
            get { return _Current_Submited_In_House_Procedure_Id; }
            set { _Current_Submited_In_House_Procedure_Id = value; }
        }
        /* [DataMember]
         public virtual ulong File_Count
         {
             get { return _file_count; }
             set { _file_count = value; }
         }*/

        [DataMember]
        public virtual IList<FileManagementIndex> lstFileManagementIndex
        {
            get { return _fileManagementindex; }
            set { _fileManagementindex = value; }
        }
        [DataMember]
        public virtual IList<PhysicianProcedure> lstprocedureList
        {
            get { return _procedureList; }
            set { _procedureList = value; }
        }

        #endregion

    }





}
