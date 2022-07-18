using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class AccountTransaction:BusinessBase<ulong>
    {
        #region Declarations

        private string _Source_Type = string.Empty;
        private ulong _Bill_To_PP_Line_Item_ID=0;
        private string _Claim_Type = string.Empty;
        private string _Line_Type = string.Empty;
        private string _Reversal_Refund_Category = string.Empty;
        private ulong _Batch_Id=0;
        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private ulong _Check_Table_Int_ID =0;
        private ulong _Carrier_ID=0;
        private ulong _Human_ID=0;
        private string _Payment_ID=string.Empty;
        private ulong _PP_Header_ID=0;
        private ulong _Charge_Line_Item_ID=0;
        private DateTime _Deposit_Date = DateTime.MinValue;
        private decimal _Amount=0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Encounter_id=0;
        private int _Version=0;
        private ulong _WF_Object_ID = 0;
        private ulong _Insurance_Plan_ID = 0;
        private string _Is_Delete = string.Empty;
        private string _Claim_Number = string.Empty;
        private ulong _Transaction_Order = 0;
        #endregion

        #region Constructors

        public AccountTransaction() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Source_Type);
            sb.Append(_Bill_To_PP_Line_Item_ID);
            sb.Append(_Claim_Type);
            sb.Append(_Line_Type);
            sb.Append(_Reversal_Refund_Category);
            sb.Append(_Batch_Id);
            sb.Append(_DOOS);
            sb.Append(_Batch_Name);
            sb.Append(_Check_Table_Int_ID);
            sb.Append(_Carrier_ID);
            sb.Append(_Human_ID);
            sb.Append(_Payment_ID);
            sb.Append(_PP_Header_ID);
            sb.Append(_Charge_Line_Item_ID);
            sb.Append(_Deposit_Date);
            sb.Append(_Amount);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Encounter_id);
            sb.Append(_Version);
            sb.Append(_WF_Object_ID);
            sb.Append(_Insurance_Plan_ID);
            sb.Append(_Is_Delete);
            sb.Append(_Claim_Number);
            sb.Append(_Transaction_Order);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual string Source_Type
        {
            get { return _Source_Type; }
            set
            {
                _Source_Type = value;
            }
        }
        [DataMember]
        public virtual ulong Bill_To_PP_Line_Item_ID
        {
            get { return _Bill_To_PP_Line_Item_ID; }
            set
            {
                _Bill_To_PP_Line_Item_ID = value;
            }
        }
        [DataMember]
        public virtual string Claim_Type
        {
            get { return _Claim_Type; }
            set
            {
                _Claim_Type = value;
            }
        }
        [DataMember]
        public virtual string Line_Type
        {
            get { return _Line_Type; }
            set
            {
                _Line_Type = value;
            }
        }
        [DataMember]
        public virtual string Reversal_Refund_Category
        {
            get { return _Reversal_Refund_Category; }
            set
            {
                _Reversal_Refund_Category = value;
            }
        }
        [DataMember]
        public virtual ulong Batch_ID
        {
            get { return _Batch_Id; }
            set
            {
                _Batch_Id = value;
            }
        }
        [DataMember]
        public virtual string DOOS
        {
            get { return _DOOS; }
            set
            {
                _DOOS = value;
            }
        }
        [DataMember]
        public virtual string Batch_Name
        {
            get { return _Batch_Name; }
            set
            {
                _Batch_Name = value;
            }
        }
        [DataMember]
        public virtual ulong Check_Table_Int_ID
        {
            get { return _Check_Table_Int_ID; }
            set
            {
                _Check_Table_Int_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Carrier_ID
        {
            get { return _Carrier_ID; }
            set
            {
                _Carrier_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual string Payment_ID
        {
            get { return _Payment_ID; }
            set
            {
                _Payment_ID = value;
            }
        }
        [DataMember]
        public virtual ulong PP_Header_ID
        {
            get { return _PP_Header_ID; }
            set
            {
                _PP_Header_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Charge_Line_Item_ID
        {
            get { return _Charge_Line_Item_ID; }
            set
            {
                _Charge_Line_Item_ID = value;
            }
        }
        [DataMember]
        public virtual DateTime Deposit_Date
        {
            get { return _Deposit_Date; }
            set
            {
                _Deposit_Date = value;
            }
        }
        [DataMember]
        public virtual decimal Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_id; }
            set
            {
                _Encounter_id = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual ulong WF_Object_ID
        {
            get { return _WF_Object_ID; }
            set
            {
                _WF_Object_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Insurance_Plan_ID
        {
            get { return _Insurance_Plan_ID; }
            set
            {
                _Insurance_Plan_ID = value;
            }
        }
        [DataMember]
        public virtual string Is_Delete
        {
            get { return _Is_Delete; }
            set
            {
                _Is_Delete = value;
            }
        }

        [DataMember]
        public virtual string Claim_Number
        {
            get { return _Claim_Number; }
            set
            {
                _Claim_Number = value;
            }
        }
        [DataMember]
        public virtual ulong Transaction_Order
        {
            get { return _Transaction_Order; }
            set
            {
                _Transaction_Order = value;
            }
        }
        #endregion
    }
}
