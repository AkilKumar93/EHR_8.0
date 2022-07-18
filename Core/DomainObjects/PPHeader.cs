using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PPHeader : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Batch_ID=0;
        private decimal _Total_Payment=0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Encounter_ID=0;
        private string _Payment_ID=string.Empty;
        private ulong _Check_Table_Int_ID=0;
        private ulong _Carrier_ID=0;
        private ulong _Human_ID=0;
        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private DateTime _Deposit_Date = DateTime.MinValue;
        private int _Version=0;
        private string _Is_Delete = string.Empty;
        

        #endregion

        #region Constructors

        public PPHeader() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Batch_ID);
            sb.Append(_Total_Payment);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Encounter_ID);
            sb.Append(_Payment_ID);
            sb.Append(_Check_Table_Int_ID);
            sb.Append(_Carrier_ID);
            sb.Append(_Human_ID);
            sb.Append(_DOOS);
            sb.Append(_Batch_Name);
            sb.Append(_Deposit_Date);
            sb.Append(_Version);
            sb.Append(_Is_Delete);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual ulong Batch_ID
        {
            get { return _Batch_ID; }
            set
            {
                _Batch_ID = value;
            }
        }
        [DataMember]
        public virtual decimal Total_Payment
        {
            get { return _Total_Payment; }
            set
            {
                _Total_Payment = value;
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
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
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
        public virtual DateTime Deposit_Date
        {
            get { return _Deposit_Date; }
            set
            {
                _Deposit_Date = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
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

        #endregion
    }
}
