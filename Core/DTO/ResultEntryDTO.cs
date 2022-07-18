using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class ResultEntryDTO
    {
        #region Declarations

        private IList<OrdersSubmit> _OrderSubmit = new List<OrdersSubmit>();            
        private IList<ResultMaster> _ResultMasterList = new List<ResultMaster>();
        private IList<ResultORC> _ResultORCList = new List<ResultORC>();
        private IList<ResultOBR> _ResultOBRList = new List<ResultOBR>();
        private IList<ResultOBX> _ResultOBXList = new List<ResultOBX>();
        private IList<ResultNTE> _ResultNTEList = new List<ResultNTE>();
        private IList<ResultZPS> _ResultZPSList = new List<ResultZPS>();
        private IList<PatientResults> _PatientResultList = new List<PatientResults>(); 
        private IList<FileManagementIndex> _FileManagementIndex = new List<FileManagementIndex>();   
        private IList<Orders> _Orders = new List<Orders>();   
        #endregion

        #region Constructor

        public ResultEntryDTO() { }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<OrdersSubmit> OrderSubmit
        {
            get { return _OrderSubmit; }
            set { _OrderSubmit = value; }
        }
       
        [DataMember]
        public virtual IList<ResultMaster> ResultMasterList
        {
            get { return _ResultMasterList; }
            set { _ResultMasterList = value; }
        }

        [DataMember]
        public virtual IList<ResultORC> ResultORCList
        {
            get { return _ResultORCList; }
            set { _ResultORCList = value; }
        }

        [DataMember]
        public virtual IList<ResultOBR> ResultOBRList
        {
            get { return _ResultOBRList; }
            set { _ResultOBRList = value; }
        }
        [DataMember]
        public virtual IList<ResultOBX> ResultOBXList
        {
            get { return _ResultOBXList; }
            set { _ResultOBXList = value; }
        }
        [DataMember]
        public virtual IList<ResultNTE> ResultNTEList
        {
            get { return _ResultNTEList; }
            set { _ResultNTEList = value; }
        }
        [DataMember]
        public virtual IList<ResultZPS> ResultZPSList
        {
            get { return _ResultZPSList; }
            set { _ResultZPSList = value; }
        }
        [DataMember]
        public virtual IList<PatientResults> PatientResultList
        {
            get { return _PatientResultList; }
            set { _PatientResultList = value; }
        }    
        [DataMember]
        public virtual IList<FileManagementIndex> FileManagementIndex
        {
            get { return _FileManagementIndex; }
            set { _FileManagementIndex = value; }
        }
      
        [DataMember]
        public virtual IList<Orders> Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
      
        #endregion
    }
}
