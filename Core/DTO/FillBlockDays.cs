using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillBlockDays
    {
        private IList<Blockdays> _blockDays;
        private int _blockDaysCount=0;
       
       
        [DataMember]
        public virtual IList<Blockdays> BlockDays
        {
            get { return _blockDays; }
            set { _blockDays = value; }
        }
        
        [DataMember]
        public virtual int BlockDaysCount
        {
            get { return _blockDaysCount; }
            set { _blockDaysCount = value; }
        }

     
    }
}
