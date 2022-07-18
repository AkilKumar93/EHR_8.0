using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
   public partial class user_scn_tab:BusinessBase<int>
    {
        #region Declaration
        private string _user_name = String.Empty;
        private ulong _scn_id = 0;
        private string _Permission = String.Empty;

        #endregion
         #region Constructors
        public user_scn_tab() { }

       #endregion
        # region Methods
        public override int GetHashCode()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_user_name);
           sb.Append(_scn_id);
            sb.Append(_Permission);
            return sb.ToString().GetHashCode();
        }
        #endregion
        #region Properties

        [DataMember]
        public virtual string user_name
        {
            get { return _user_name; }
            set
            {
                _user_name = value;
            }
        }
        [DataMember]
        public virtual ulong scn_id
        {
            get { return _scn_id; }
            set
            {
                _scn_id = value;
            }
        }
        [DataMember]
        public virtual string Permission
        {
            get { return _Permission; }
            set
            {
                _Permission = value;
            }
        }
        # endregion
    }
}
