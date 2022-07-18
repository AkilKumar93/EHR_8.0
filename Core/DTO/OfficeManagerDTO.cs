using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class OfficeManagerDTO
    {
        #region Declarations


        //private IList<FacilityLibrary> _lstFacilityLibrary;
        private IList<WorkFlow> _listWorkflow;


        #endregion

        #region Constructor

        public OfficeManagerDTO()
        {

            //_lstFacilityLibrary = new List<FacilityLibrary>();
            _listWorkflow = new List<WorkFlow>();
        }
        #endregion

        #region Properties

        //[DataMember]
        //public virtual IList<FacilityLibrary> lstFacilityLibrary
        //{
        //    get { return _lstFacilityLibrary; }
        //    set { _lstFacilityLibrary = value; }
        //}
        [DataMember]
        public virtual IList<WorkFlow> listWorkflow
        {
            get { return _listWorkflow; }
            set { _listWorkflow = value; }
        }
        #endregion
    }
}
