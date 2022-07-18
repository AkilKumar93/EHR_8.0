using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class role_scn_tab:BusinessBase<int>

    {
        #region Declaration

        private string _Role_Name = String.Empty;
        private ulong _Scn_ID= 0;
        private string _Status=String.Empty;
        private string _Scn_Name = String.Empty;
       
        #endregion 
        #region Constructors
        public role_scn_tab() { }

       #endregion
        # region Methods
        public override int GetHashCode()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Role_Name);
            sb.Append(_Scn_ID);
            sb.Append(_Status);
            sb.Append(_Scn_Name);

            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties

        [DataMember]
        public virtual string Role_Name
        {
            get { return _Role_Name; }
            set
            {
                _Role_Name = value;
            }
        }
        [DataMember]
        public virtual ulong Scn_ID
        {
            get { return _Scn_ID; }
            set
            {
                _Scn_ID = value;
            }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }
       
       
        # endregion
    }
}
