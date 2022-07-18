using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class OrderSpecimenDTO
    {
        #region Declarations

        private IList<OrderLabDetailsDTO> _ilstOrderLabDetailsDTO = null;
        private IList<OrdersAssessment> _OrderAssList = null;
        //private IList<Specimen> _objSpecimen=null;
        private FillHumanDTO _objHuman = new FillHumanDTO();
        IList<FillHumanDTO> _ilstGuarantor = new List<FillHumanDTO>();
        private string _ICDs = string.Empty;
        
        #endregion

        #region Constructor

        public OrderSpecimenDTO() { }

        #endregion

        #region Properties
        [DataMember]
        public virtual IList<OrdersAssessment> OrderAssList
        {
            get { return _OrderAssList; }
            set { _OrderAssList = value; }
        }
        [DataMember]
        public virtual IList<OrderLabDetailsDTO> ilstOrderLabDetailsDTO
        {
            get { return _ilstOrderLabDetailsDTO; }
            set { _ilstOrderLabDetailsDTO = value; }
        }
        //[DataMember]
        //public virtual IList<Specimen> SpecimenList
        //{
        //    get { return _objSpecimen; }
        //    set { _objSpecimen = value; }
        //}
        [DataMember]
        public virtual FillHumanDTO objHuman
        {
            get { return _objHuman; }
            set { _objHuman = value; }
        }

        [DataMember]
        public virtual IList<FillHumanDTO> ilstGuarantor
        {
            get { return _ilstGuarantor; }
            set { _ilstGuarantor = value; }
        }
        [DataMember]
        public virtual string ICDs
        {
            get { return _ICDs; }
            set { _ICDs = value; }
        }
        #endregion
    }
}
