using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    public partial class RuleMedication:BusinessBase<ulong>
    {
           #region Declarations

        private string _Generic_Name = string.Empty;
        private string _Message = string.Empty;
        private string _Status = string.Empty;
        private string _Rules = string.Empty;
        private int _Sort_Order = 0;

        #endregion

        #region Constructors

        public RuleMedication() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Generic_Name);
            sb.Append(_Message);
            sb.Append(_Status);
            sb.Append(_Rules);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

       
        [DataMember]
        public virtual string Generic_Name
        {
            get { return _Generic_Name; }
            set { _Generic_Name = value; }
        }

        [DataMember]
        public virtual string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        [DataMember]
        public virtual string Rules
        {
            get { return _Rules; }
            set { _Rules = value; }
        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }

        #endregion
    }
}
