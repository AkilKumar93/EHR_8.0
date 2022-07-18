using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class CheckArc : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Batch_ID = 0;
        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private ulong _Carrier_ID = 0;
        private string _Payment_ID = string.Empty;
        private ulong _Human_ID = 0;
        private ulong _Encounter_ID = 0;
        private DateTime _Check_Date = DateTime.MinValue;
        private DateTime _Deposit_Date = DateTime.MinValue;
        private DateTime _Posted_Date = DateTime.MinValue;
        private string _Carrier_Patient_Name = string.Empty;
        private string _Payment_Type = string.Empty;
        private string _Card_Type = string.Empty;
        private ulong _Payment_Conf_ID = 0;
        private decimal _Payment_Amount = 0;
        private double _Payment_Posted_Amount = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Is_Delete = string.Empty;
      

        #endregion

        #region Constructors

        public CheckArc() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Batch_ID);
            sb.Append(_DOOS);
            sb.Append(_Batch_Name);
            sb.Append(_Carrier_ID);
            sb.Append(_Payment_ID);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Check_Date);
            sb.Append(_Deposit_Date);
            sb.Append(_Posted_Date);
            sb.Append(_Carrier_Patient_Name);
            sb.Append(_Payment_Type);
            sb.Append(_Card_Type);
            sb.Append(_Payment_Conf_ID);
            sb.Append(_Payment_Amount);
            sb.Append(_Payment_Posted_Amount);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
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
        public virtual ulong Carrier_ID
        {
            get { return _Carrier_ID; }
            set
            {
                _Carrier_ID = value;
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
        public virtual DateTime Check_Date
        {
            get { return _Check_Date; }
            set
            {
                _Check_Date = value;
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
        public virtual DateTime Posted_Date
        {
            get { return _Posted_Date; }
            set
            {
                _Posted_Date = value;
            }
        }

        [DataMember]
        public virtual string Carrier_Patient_Name
        {
            get { return _Carrier_Patient_Name; }
            set
            {
                _Carrier_Patient_Name = value;
            }
        }
        [DataMember]
        public virtual string Payment_Type
        {
            get { return _Payment_Type; }
            set
            {
                _Payment_Type = value;
            }
        }
        [DataMember]
        public virtual string Card_Type
        {
            get { return _Card_Type; }
            set
            {
                _Card_Type = value;
            }
        }
        [DataMember]
        public virtual ulong Payment_Conf_ID
        {
            get { return _Payment_Conf_ID; }
            set
            {
                _Payment_Conf_ID = value;
            }
        }
        [DataMember]
        public virtual decimal Payment_Amount
        {
            get { return _Payment_Amount; }
            set
            {
                _Payment_Amount = value;
            }
        }
        [DataMember]
        public virtual double Payment_Posted_Amount
        {
            get { return _Payment_Posted_Amount; }
            set
            {
                _Payment_Posted_Amount = value;
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
