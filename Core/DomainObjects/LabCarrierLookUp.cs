using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class LabCarrierLookUp : BusinessBase<ulong>
    {
        #region Declarations


        private ulong _Ins_Plan_ID = 0;
        private string _LCA_Carrier_Code = string.Empty;
        private string _LCA_Plan_Type = string.Empty;
        private string _Plan_Attention = string.Empty;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        private ulong _Lab_ID = 0;
        //Janani - Main - 30 Jul 2011 - End
        #endregion

        #region Constructors

        public LabCarrierLookUp() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Ins_Plan_ID);
            sb.Append(_LCA_Carrier_Code);
            sb.Append(_LCA_Plan_Type);
            sb.Append(_Plan_Attention);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            sb.Append(_Lab_ID);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties


        [DataMember]
        public virtual ulong Ins_Plan_ID
        {
            get { return _Ins_Plan_ID; }
            set
            {
                _Ins_Plan_ID = value;
            }
        }
        [DataMember]
        public virtual string LCA_Carrier_Code
        {
            get { return _LCA_Carrier_Code; }
            set
            {
                _LCA_Carrier_Code = value;
            }
        }
        [DataMember]
        public virtual string LCA_Plan_Type
        {
            get { return _LCA_Plan_Type; }
            set
            {
                _LCA_Plan_Type = value;
            }
        }
        [DataMember]
        public virtual string Plan_Attention
        {
            get { return _Plan_Attention; }
            set
            {
                _Plan_Attention = value;
            }
        }
        //Janani - Main - 30 Jul 2011 - Start
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //Janani - Main - 30 Jul 2011 - End
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        #endregion

    }
}
