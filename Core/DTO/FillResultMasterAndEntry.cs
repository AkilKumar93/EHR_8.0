using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillResultMasterAndEntry
    {
        #region Declarations
        private IList<ResultMaster> _Result_Master_List = null;
        private ulong _Order_ID = 0;
        private ulong _Human_ID = 0;
        private ulong _Result_Master_ID = 0;
        private string _Order_Code = string.Empty;
        private string _Order_Description = string.Empty;
        private string _Table = string.Empty;
        #endregion

        #region Constructor
        public FillResultMasterAndEntry()
        {
            _Result_Master_List = new List<ResultMaster>();
           // _Result_Entry_List = new List<ResultEntry>();
        }
        #endregion

        #region Properties

        [DataMember]
        public virtual IList<ResultMaster> Result_Master_List
        {
            get { return _Result_Master_List; }
            set { _Result_Master_List = value; }
        }


        [DataMember]
        public virtual ulong Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }

        [DataMember]
        public virtual string Order_Code
        {
            get { return _Order_Code; }
            set { _Order_Code = value; }
        }

        [DataMember]
        public virtual string Order_Description
        {
            get { return _Order_Description; }
            set { _Order_Description = value; }
        }

        [DataMember]
        public virtual string Table
        {
            get { return _Table; }
            set { _Table = value; }
        }

        #endregion
    }
}
