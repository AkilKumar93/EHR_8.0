using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class CheckOutDTO
    {

        #region Declarations
         //private FillHumanDTO _objhuman;
        //private Encounter _EncounterList;

        IList<CheckoutOrdersDTO> _CheckoutOrdersList;
        //IList<PatientPane> _PatientPaneList;
        FillDocuments _DocumentList;
        #endregion

        #region Constructor
        public CheckOutDTO()
        {
           
            _DocumentList = new FillDocuments();
          // _objhuman = new FillHumanDTO();
            _CheckoutOrdersList = new List<CheckoutOrdersDTO>();
        }
        #endregion


        #region Properties
      

        [DataMember]
        public virtual FillDocuments DocumentList
        {
            get { return _DocumentList; }
            set { _DocumentList = value; }
        }

        //[DataMember]
        //public virtual FillHumanDTO objhuman
        //{
        //    get { return _objhuman; }
        //    set { _objhuman = value; }
        //}
        [DataMember]
        public virtual IList<CheckoutOrdersDTO> CheckoutOrdersList
        {
            get { return _CheckoutOrdersList; }
            set { _CheckoutOrdersList = value; }
        }

        #endregion
    }
}
