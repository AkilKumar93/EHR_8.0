using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class VisitPaymentHistoryArc: BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Human_ID=0;
        private ulong _Encounter_ID=0;
        private ulong _Visit_Payment_ID = 0;
        private string _Method_of_Payment = string.Empty;
        private string _Check_Card_No = string.Empty;
        private DateTime _Check_Date=DateTime.MinValue;
        private string _Auth_No = string.Empty;
        private decimal _Patient_Payment ;
        private ulong _Payment_Message_ID = 0;
        private string _Payment_Note = string.Empty ;
        private string _createdby = String.Empty;
        private DateTime _createddateandtime=DateTime.MinValue;
        private string _modifiedby = string.Empty;
        private DateTime _modifieddateandtime=DateTime.MinValue;
        private int _iVersion=0;
        private decimal _Refund_Amount = 0;
        private decimal _Rec_On_Acc = 0;
        private string _Is_Delete = string.Empty;
        private string _Relationship = String.Empty;
        private string _Amount_Paid_By = String.Empty;
        private ulong _Voucher_No = 0;
        private string _Batch_Status = "OPEN";
        private string _Facility_Name = String.Empty;
        #endregion

        #region Constructors

        public VisitPaymentHistoryArc() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Visit_Payment_ID);
            sb.Append(_Method_of_Payment);
            sb.Append(_Check_Card_No);
            sb.Append(_Check_Date);
            sb.Append(_Auth_No);
            sb.Append(_Patient_Payment);
            sb.Append(_Payment_Message_ID);
            sb.Append(_Payment_Note);
            sb.Append(_createdby);
            sb.Append(_createddateandtime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddateandtime);
            sb.Append(_iVersion);
            sb.Append(_Refund_Amount);
            sb.Append(_Rec_On_Acc);
            sb.Append(_Is_Delete);
            sb.Append(_Voucher_No);
            sb.Append(_Batch_Status);
            sb.Append(_Facility_Name);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual string Relationship
        {
            get { return _Relationship; }
            set
            {
                _Relationship = value;
            }
        }
        [DataMember]
        public virtual string Amount_Paid_By
        {
            get { return _Amount_Paid_By; }
            set
            {
                _Amount_Paid_By = value;
            }
        }

        [DataMember]
        public virtual ulong Visit_Payment_ID
        {
            get { return _Visit_Payment_ID; }
            set
            {
                _Visit_Payment_ID = value;
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
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
            }
        }
        [DataMember]
        public virtual string Method_of_Payment
        {
            get { return _Method_of_Payment; }
            set
            {
                _Method_of_Payment = value;
            }
        }
        [DataMember]
        public virtual string Check_Card_No
        {
            get { return _Check_Card_No; }
            set
            {
                _Check_Card_No = value;
            }
        }
        [DataMember]
        public virtual DateTime Check_Date
        {
            get { return _Check_Date; }
            set
            {
                _Check_Date = value;
            }
        }
        [DataMember]
        public virtual string Auth_No
        {
            get { return _Auth_No; }
            set
            {
                _Auth_No = value;
            }
        }
        [DataMember]
        public virtual decimal Patient_Payment
        {
            get { return _Patient_Payment; }
            set
            {
                _Patient_Payment = value;
            }
        }
        [DataMember]
        public virtual ulong Payment_Message_ID
        {
            get { return _Payment_Message_ID; }
            set
            {
                _Payment_Message_ID = value;
            }
        }
        [DataMember]
        public virtual string Payment_Note
        {
            get { return _Payment_Note; }
            set
            {
                _Payment_Note = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _createdby; }
            set
            {
                _createdby = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _createddateandtime; }
            set
            {
                _createddateandtime = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set
            {
                _modifiedby = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _modifieddateandtime; }
            set
            {
                _modifieddateandtime = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _iVersion; }
            set { _iVersion = value; }
        }
        [DataMember]
        public virtual decimal Refund_Amount
        {
            get { return _Refund_Amount; }
            set
            {
                _Refund_Amount = value;
            }
        }
        [DataMember]
        public virtual decimal Rec_On_Acc
        {
            get { return _Rec_On_Acc; }
            set
            {
                _Rec_On_Acc = value;
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
        public virtual ulong Voucher_No
        {
            get { return _Voucher_No; }
            set
            {
                _Voucher_No = value;
            }
        }
        [DataMember]
        public virtual string Batch_Status
        {
            get { return _Batch_Status; }
            set
            {
                _Batch_Status = value;
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
