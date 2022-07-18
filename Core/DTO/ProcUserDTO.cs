using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
   public partial class ProcUserDTO
    {
                 #region Declarations

        private IList<ProcUser> _ProcUser;
        private int _ProcUserCount=0;
        private bool _bCheck=false;

        #endregion

         #region Constructor

        public ProcUserDTO() 
        {
            _ProcUser = new List<ProcUser>();
        }

        #endregion
        #region Properties

        [DataMember]
        public virtual IList<ProcUser> ProcUser
        {
            get { return _ProcUser; }
            set { _ProcUser = value; }
        }

        [DataMember]
        public virtual int ProcUserCount
        {
            get { return _ProcUserCount; }
            set { _ProcUserCount = value; }
        }

        [DataMember]
        public virtual bool bCheck
        {
            get { return _bCheck; }
            set { _bCheck = value; }
        }

        #endregion
       

    }
}
