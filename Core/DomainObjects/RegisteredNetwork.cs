using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class RegisteredNetwork:BusinessBase<ulong>
    {
        #region Declarations

        private string _Primary_IP_Address = string.Empty;       
        private string _Secondary_IP_Address = string.Empty;
        private string _Facility_Name = string.Empty;    
        #endregion

        #region Constructors

        public RegisteredNetwork() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Primary_IP_Address);
            sb.Append(_Secondary_IP_Address);
            sb.Append(_Facility_Name);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
       
        [DataMember]
        public virtual string Primary_IP_Address
        {
            get { return _Primary_IP_Address; }
            set
            {
                _Primary_IP_Address = value;
            }
        }
        [DataMember]
        public virtual string Secondary_IP_Address
        {
            get { return _Secondary_IP_Address; }
            set
            {
                _Secondary_IP_Address = value;
            }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set
            {
                _Facility_Name = value;
            }
        }
        #endregion
    }
}
