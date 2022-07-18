using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class AOELookUp:BusinessBase<ulong>
    {
        #region Decleration
        private string _Order_Code =string.Empty;
        private string _AOE_Question = string.Empty;
        private ulong _Lab_ID = 0;
        private ulong _Sort_Order = 0;
        private string _AOE_Identifier = string.Empty;
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Order_Code);
            sb.Append(_AOE_Question);
            sb.Append(_Lab_ID);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion


        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        [DataMember]
        public virtual ulong Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string Order_Code
        {
            get { return _Order_Code; }
            set { _Order_Code = value; }
        }
        [DataMember]
        public virtual string AOE_Question
        {
            get { return _AOE_Question; }
            set { _AOE_Question = value; }
        }
        [DataMember]
        public virtual string AOE_Identifier
        {
            get { return _AOE_Identifier; }
            set { _AOE_Identifier = value; }
        }



    }
}
