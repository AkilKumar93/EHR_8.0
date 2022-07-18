using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class VisitPaymentDTO
    {
        #region Declarations
        private string _Method_of_Payment = string.Empty;
        private string _Check_Card_No = string.Empty;
        private string _Auth_No = string.Empty;
        private decimal _Patient_Payment = 0;
        private decimal _Refund_Amount = 0;
        private decimal _Rec_On_Acc = 0;
        private DateTime _Check_Date = DateTime.MinValue;
        private string _Payment_Note = string.Empty;
        private ulong _Visit_Payment_Id = 0;
        private ulong _PP_Line_Item_Id = 0;
        private ulong _PP_Header_Id = 0;
        private ulong _Check_Table_Int_Id = 0;
        private string _Relationship = String.Empty;
        private string _Amount_Paid_By = String.Empty;
        private DateTime _Created_Date_and_Time = DateTime.MinValue;
        private DateTime _Modified_Date_and_Time = DateTime.MinValue;
        private ulong _Voucher_No = 0;


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
        public virtual string Method_of_Payment
        {
            get { return _Method_of_Payment; }
            set { _Method_of_Payment = value; }
        }
        [DataMember]
        public virtual string Check_Card_No
        {
            get { return _Check_Card_No; }
            set { _Check_Card_No = value; }
        }
        [DataMember]
        public virtual string Auth_No
        {
            get { return _Auth_No; }
            set { _Auth_No = value; }
        }
        [DataMember]
        public virtual decimal Patient_Payment
        {
            get { return _Patient_Payment; }
            set { _Patient_Payment = value; }
        }
        [DataMember]
        public virtual decimal Refund_Amount
        {
            get { return _Refund_Amount; }
            set { _Refund_Amount = value; }
        }
        [DataMember]
        public virtual decimal Rec_On_Acc
        {
            get { return _Rec_On_Acc; }
            set { _Rec_On_Acc = value; }
        }
        [DataMember]
        public virtual DateTime Check_Date
        {
            get { return _Check_Date; }
            set { _Check_Date = value; }
        }
        [DataMember]
        public virtual string Payment_Note
        {
            get { return _Payment_Note; }
            set { _Payment_Note = value; }
        }
        [DataMember]
        public virtual ulong Visit_Payment_Id
        {
            get { return _Visit_Payment_Id; }
            set { _Visit_Payment_Id = value; }
        }
        [DataMember]
        public virtual ulong PP_Line_Item_Id
        {
            get { return _PP_Line_Item_Id; }
            set { _PP_Line_Item_Id = value; }
        }
        [DataMember]
        public virtual ulong PP_Header_Id
        {
            get { return _PP_Header_Id; }
            set { _PP_Header_Id = value; }
        }
        [DataMember]
        public virtual ulong Check_Table_Int_Id
        {
            get { return _Check_Table_Int_Id; }
            set { _Check_Table_Int_Id = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_and_Time
        {
            get { return _Created_Date_and_Time; }
            set { _Created_Date_and_Time = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_and_Time
        {
            get { return _Modified_Date_and_Time; }
            set { _Modified_Date_and_Time = value; }
        }
        [DataMember]
        public virtual ulong Voucher_No
        {
            get { return _Voucher_No; }
            set { _Voucher_No = value; }
        }
        #endregion
    }
}

