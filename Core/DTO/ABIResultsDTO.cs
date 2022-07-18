using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class ABIResultsDTO
    {

        #region Declarations

        private IList<ABI_Results> _lstABIResult;
        private IList<StaticLookup> _LookUpListForABI;
        #endregion


        public ABIResultsDTO() 
        {
            _lstABIResult = new List<ABI_Results>();
            _LookUpListForABI = new List<StaticLookup>();
        }


        [DataMember]
        public virtual IList<ABI_Results> lstABIResult
        {
            get { return _lstABIResult; }
            set
            {
                _lstABIResult = value;
            }
        }

        [DataMember]
        public virtual IList<StaticLookup> LookUpListForABI
        {
            get { return _LookUpListForABI; }
            set
            {
                _LookUpListForABI = value;
            }
        }
    }
}
