using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class FillLogin
    {
        #region Declarations
        private IList<FacilityLibrary> _Facility_Library_List;
        private IList<ProcessMaster> _Process_Master_List;
        private string _Default_Facility;
        private IList<User> _UserList;
        #endregion

        #region Constructor
        public FillLogin()
        {
            _Facility_Library_List = new List<FacilityLibrary>();
            _Process_Master_List = new List<ProcessMaster>();
            _Default_Facility = string.Empty;
            _UserList = new List<User>();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual IList<FacilityLibrary> Facility_Library_List
        {
            get { return _Facility_Library_List; }
            set { _Facility_Library_List = value; }
        }
        [DataMember]
        public virtual IList<ProcessMaster> Process_Master_List
        {
            get { return _Process_Master_List; }
            set { _Process_Master_List = value; }
        }
        [DataMember]
        public virtual string Default_Facility
        {
            get { return _Default_Facility; }
            set { _Default_Facility = value; }
        }
        [DataMember]
        public virtual IList<User> UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
        #endregion
    }
}
