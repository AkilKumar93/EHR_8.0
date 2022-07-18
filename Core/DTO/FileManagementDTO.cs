using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class FileManagementDTO
    {

        #region Declarations

        private IList<FileManagementIndex> _filemanagement = new List<FileManagementIndex>();
        private IList<ResultMaster> _resultMaster = new List<ResultMaster>();

        private IList<ABI_Results> _lst_abi = new List<ABI_Results>();
        private IList<Spirometry> _lst_spirometry = new List<Spirometry>();
        private bool _viewResult = false;
        private IList<Human> _humanLst = new List<Human>();
        private IList<User> _UserLst = new List<User>();
        #endregion

        #region Constructor

        public FileManagementDTO() { }

        #endregion


          #region Properties
        [DataMember]
        public virtual IList<FileManagementIndex> FileManagementList
        {
            get { return _filemanagement; }
            set { _filemanagement = value; }
        }

        [DataMember]
        public virtual IList<ABI_Results> lstABI
        {
            get { return _lst_abi ; }
            set { _lst_abi = value; }
        }

        [DataMember]
        public virtual IList<Spirometry> lstSpirometry
        {
            get { return _lst_spirometry ; }
            set { _lst_spirometry = value; }
        }

        [DataMember]
        public virtual IList<ResultMaster> ResultMasterList
        {
            get { return _resultMaster; }
            set { _resultMaster = value; }
        }

        [DataMember]
        public virtual bool ViewResult
        {
            get { return _viewResult; }
            set { _viewResult = value; }
        }

        [DataMember]
        public virtual IList<Human> HumanList
        {
            get { return _humanLst; }
            set { _humanLst = value; }
        }
        [DataMember]
        public virtual IList<User> UserList
        {
            get { return _UserLst; }
            set { _UserLst = value; }
        }

          #endregion
    }
}
