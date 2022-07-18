using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class CodingExceptionDTO
    {
        #region Declarations
       
        private IList<CreateException> _Exception;
        private int _ExceptionCount = 0;                                        
        private IList<PhysicianLibrary> _lstPhysicianLibrary;

        #endregion

        #region Constructor

        public CodingExceptionDTO()
        {            
            _Exception = new List<CreateException>();                                                                      
            _lstPhysicianLibrary = new List<PhysicianLibrary>();
        }

        #endregion

        #region Properties
        
        [DataMember]
        public virtual IList<CreateException> Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        [DataMember]
        public virtual int ExceptionCount
        {
            get { return _ExceptionCount; }
            set { _ExceptionCount = value; }
        }
                            
        [DataMember]
        public virtual IList<PhysicianLibrary> PhysicianLibraryList
        {
            get { return _lstPhysicianLibrary; }
            set { _lstPhysicianLibrary = value; }
        }
        #endregion
    }
}
