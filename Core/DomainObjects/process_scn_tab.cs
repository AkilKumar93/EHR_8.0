using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;



namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
   public partial class process_scn_tab:BusinessBase<int>
   {
       #region Declaration
       private string _Process_name = String.Empty;
       private ulong _Scn_ID = 0;
       private string _Is_RBAC_or_PBAC =  String.Empty;

       #endregion
         #region Constructors
       public process_scn_tab() { }

       #endregion
        # region Methods
        public override int GetHashCode()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Process_name);
            sb.Append(_Scn_ID);
            sb.Append(_Is_RBAC_or_PBAC);
            return sb.ToString().GetHashCode();
        }
        #endregion
        #region Properties

        [DataMember]
        public virtual string Process_name
        {
            get { return _Process_name; }
            set
            {
                _Process_name = value;
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
        public virtual string Is_RBAC_or_PBAC
        {
            get { return _Is_RBAC_or_PBAC; }
            set
            {
                _Is_RBAC_or_PBAC = value;
            }
        }
        # endregion
   }
}
