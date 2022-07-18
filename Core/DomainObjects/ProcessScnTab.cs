using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ProcessScnTab : BusinessBase<int>
    {
        #region Declarations

        private int _Scn_ID=0;
        private string _Process_Name= string.Empty;
        private string _Permission = string.Empty;

        #endregion
        #region Constructors

        public ProcessScnTab() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Scn_ID);
            sb.Append(_Process_Name);
            sb.Append(_Permission);
            return sb.ToString().GetHashCode();
        }
        [DataMember]
        public virtual string Process_Name
        {
            get { return _Process_Name; }
            set { _Process_Name = value; }
        }

        [DataMember]
        public virtual int Scn_ID
        {
            get { return _Scn_ID; }
            set { _Scn_ID = value; }
        }

        [DataMember]
        public virtual string Permission
        {
            get { return _Permission; }
            set { _Permission = value; }
        }
        #endregion
    }
}
