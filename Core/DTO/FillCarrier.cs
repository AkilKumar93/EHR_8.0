using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;
using System.Collections;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillCarrier
    {
        private int _CarrierCount=0;
        private IList<Carrier> _carrierList;
        private IList _AllCarrierName;

        #region Constructor

        public FillCarrier()
        {
            _carrierList = new List<Carrier>();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual int CarrierCount
        {
            get { return _CarrierCount; }
            set { _CarrierCount = value; }
        }

        [DataMember]
        public virtual IList<Carrier> CarrierList
        {
            get { return _carrierList; }
            set { _carrierList = value; }
        }
        [DataMember]
        public virtual IList AllCarrierName
        {
            get { return _AllCarrierName; }
            set { _AllCarrierName = value; }
        }

        #endregion


    }
}
