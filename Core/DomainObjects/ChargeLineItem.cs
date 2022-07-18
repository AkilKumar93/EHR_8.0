    using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ChargeLineItem : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Charge_Header_ID = 0;
        private DateTime _From_DOS = DateTime.MinValue;
        private DateTime _To_DOS = DateTime.MinValue;
        private string _Place_of_Service = string.Empty;
        private string _EMG = string.Empty;
        private string _Procedure_Code = string.Empty;
        private string _Modifier1 = string.Empty;
        private string _Modifier2 = string.Empty;
        private string _Modifier3 = string.Empty;
        private string _Modifier4 = string.Empty;
        private string _Diagnosis_Pointer = string.Empty;        
        private decimal _Charge_Amount = 0;
        private int _Units = 0;
        private string _EPSDT = string.Empty;
        private string _FP = string.Empty;
        private ulong _Rendering_Provider_ID = 0;
        private string _NDC_Code = string.Empty;
        private string _NDC_Units = string.Empty;
        private string _Charge_Notes = string.Empty;
        private string _Bill_Destination = string.Empty;
        //private string _Primary_Payer_Name = string.Empty;
        //private ulong _Primary_Payer_ID = 0;
        private ulong _Pat_Insured_Plan_ID = 0;
        //private string _Pat_Insured_Relationship = string.Empty;
        private ulong _Bill_To_ID = 0;
        private ulong _Account_Transaction_ID = 0;
        private ulong _Pat_Other_Insured_Plan_ID = 0;
        //private string _Secondary_Payer_Name = string.Empty;
        //private ulong _Secondary_Payer_ID = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Deleted = string.Empty;
        private int _Sort_Order = 0;
        private string _Additional_ICD = string.Empty;
        private string _Charge_Header_Identifier = string.Empty;

        #endregion

        #region Constructors

        public ChargeLineItem() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Charge_Header_ID);
            sb.Append(_From_DOS);
            sb.Append(_To_DOS);
            sb.Append(_Place_of_Service);
            sb.Append(_EMG);
            sb.Append(_Procedure_Code);
            sb.Append(_Modifier1);
            sb.Append(_Modifier2);
            sb.Append(_Modifier3);
            sb.Append(_Modifier4);
            sb.Append(_Diagnosis_Pointer);            
            sb.Append(_Charge_Amount);
            sb.Append(_Units);
            sb.Append(_EPSDT);
            sb.Append(_FP);
            sb.Append(_Rendering_Provider_ID);
            sb.Append(_NDC_Code);
            sb.Append(_NDC_Units);
            sb.Append(_Charge_Notes);
            sb.Append(_Bill_Destination);
            //sb.Append(_Primary_Payer_Name);
            //sb.Append(_Primary_Payer_ID);
            sb.Append(_Pat_Insured_Plan_ID);
            //sb.Append(_Pat_Insured_Relationship);
            sb.Append(_Bill_To_ID);
            sb.Append(_Account_Transaction_ID);
            sb.Append(_Pat_Other_Insured_Plan_ID);            
            //sb.Append(_Secondary_Payer_Name);
            //sb.Append(_Secondary_Payer_ID);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Deleted);
            sb.Append(_Sort_Order);
            sb.Append(_Additional_ICD);
            sb.Append(_Charge_Header_Identifier);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual ulong Charge_Header_ID
        {
            get { return _Charge_Header_ID; }
            set
            {
                _Charge_Header_ID = value;
            }
        }
        [DataMember]
        public virtual DateTime From_DOS
        {
            get { return _From_DOS; }
            set
            {
                _From_DOS = value;
            }
        }
        [DataMember]
        public virtual DateTime To_DOS
        {
            get { return _To_DOS; }
            set
            {
                _To_DOS = value;
            }
        }
        [DataMember]
        public virtual string Place_of_Service
        {
            get { return _Place_of_Service; }
            set
            {
                _Place_of_Service = value;
            }
        }
        [DataMember]
        public virtual string EMG
        {
            get { return _EMG; }
            set
            {
                _EMG = value;
            }
        }
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set
            {
                _Procedure_Code = value;
            }
        }
        [DataMember]
        public virtual string Modifier1
        {
            get { return _Modifier1; }
            set
            {
                _Modifier1 = value;
            }
        }
        [DataMember]
        public virtual string Modifier2
        {
            get { return _Modifier2; }
            set
            {
                _Modifier2 = value;
            }
        }
        [DataMember]
        public virtual string Modifier3
        {
            get { return _Modifier3; }
            set
            {
                _Modifier3 = value;
            }
        }
        [DataMember]
        public virtual string Modifier4
        {
            get { return _Modifier4; }
            set
            {
                _Modifier4 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis_Pointer
        {
            get { return _Diagnosis_Pointer; }
            set
            {
                _Diagnosis_Pointer = value;
            }
        }       
        [DataMember]
        public virtual decimal Charge_Amount
        {
            get { return _Charge_Amount; }
            set
            {
                _Charge_Amount = value;
            }
        }
        [DataMember]
        public virtual int Units
        {
            get { return _Units; }
            set
            {
                _Units = value;
            }
        }
        [DataMember]
        public virtual string EPSDT
        {
            get { return _EPSDT; }
            set
            {
                _EPSDT = value;
            }
        }
        [DataMember]
        public virtual string FP
        {
            get { return _FP; }
            set
            {
                _FP = value;
            }
        }
        [DataMember]
        public virtual ulong Rendering_Provider_ID
        {
            get { return _Rendering_Provider_ID; }
            set
            {
                _Rendering_Provider_ID = value;
            }
        }
        [DataMember]
        public virtual string NDC_Code
        {
            get { return _NDC_Code; }
            set
            {
                _NDC_Code = value;
            }
        }
        [DataMember]
        public virtual string NDC_Units
        {
            get { return _NDC_Units; }
            set
            {
                _NDC_Units = value;
            }
        }
        [DataMember]
        public virtual string Charge_Notes
        {
            get { return _Charge_Notes; }
            set
            {
                _Charge_Notes = value;
            }
        }
        [DataMember]
        public virtual string Bill_Destination
        {
            get { return _Bill_Destination; }
            set
            {
                _Bill_Destination = value;
            }
        }
        //[DataMember]
        //public virtual string Primary_Payer_Name
        //{
        //    get { return _Primary_Payer_Name; }
        //    set
        //    {
        //        _Primary_Payer_Name = value;
        //    }
        //}
        //[DataMember]
        //public virtual ulong Primary_Payer_ID
        //{
        //    get { return _Primary_Payer_ID; }
        //    set
        //    {
        //        _Primary_Payer_ID = value;
        //    }
        //}
        [DataMember]
        public virtual ulong Pat_Insured_Plan_ID
        {
            get { return _Pat_Insured_Plan_ID; }
            set
            {
                _Pat_Insured_Plan_ID = value;
            }
        }
        //[DataMember]
        //public virtual string Pat_Insured_Relationship
        //{
        //    get { return _Pat_Insured_Relationship; }
        //    set
        //    {
        //        _Pat_Insured_Relationship = value;
        //    }
        //}
        [DataMember]
        public virtual ulong Bill_To_ID
        {
            get { return _Bill_To_ID; }
            set
            {
                _Bill_To_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Account_Transaction_ID
        {
            get { return _Account_Transaction_ID; }
            set
            {
                _Account_Transaction_ID = value;
            }
        }

        [DataMember]
        public virtual ulong Pat_Other_Insured_Plan_ID
        {
            get { return _Pat_Other_Insured_Plan_ID; }
            set
            {
                _Pat_Other_Insured_Plan_ID = value;
            }
        }
        //[DataMember]
        //public virtual string Secondary_Payer_Name
        //{
        //    get { return _Secondary_Payer_Name; }
        //    set
        //    {
        //        _Secondary_Payer_Name = value;
        //    }
        //}
        //[DataMember]
        //public virtual ulong Secondary_Payer_ID
        //{
        //    get { return _Secondary_Payer_ID; }
        //    set
        //    {
        //        _Secondary_Payer_ID = value;
        //    }
        //}
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
        public virtual string Deleted
        {
            get { return _Deleted; }
            set
            {
                _Deleted = value;
            }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set
            {
                _Sort_Order = value;
            }
        }
        [DataMember]
        public virtual string Additional_ICD
        {
            get { return _Additional_ICD; }
            set
            {
                _Additional_ICD = value;
            }
        }
        [DataMember]
        public virtual string Charge_Header_Identifier
        {
            get { return _Charge_Header_Identifier; }
            set
            {
                _Charge_Header_Identifier = value;
            }
        }
        #endregion
    }
}
