using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class Rcopia_NotificationDTO
    {

        #region Declarations

        private string _sType = string.Empty;
        private string _sNumber = string.Empty;

        #endregion

        #region Constructor

        public Rcopia_NotificationDTO()
        {
         //   _AccountTransList = new List<AccountTransaction>();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Type
        {
            get { return _sType; }
            set { _sType = value; }
        }
        [DataMember]
        public virtual string Number
        {
            get { return _sNumber; }
            set { _sNumber = value; }
        }

        #endregion

    }
}
