using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class EAndMCoding : BusinessBase<ulong>
    {

        #region Declarations

        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        private ulong _Physician_ID = 0;
        private string _ProcedureCode = string.Empty;
        private string _Procedure_Code_Description = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private int _Units = 0;
        private string _Modifier1 = string.Empty;
        private string _Modifier2 = string.Empty;
        private string _Modifier3 = string.Empty;
        private string _Modifier4 = string.Empty;
        private decimal _Charge_Amount = 0;
        private string _Modifier1_Description = string.Empty;
        private string _Modifier2_Description = string.Empty;
        private string _Modifier3_Description = string.Empty;
        private string _Modifier4_Description = string.Empty;
        private string _Is_Delete = string.Empty;
        //private int _Sequence = 0;
        //private int _CPT_Order = 0;
        private string _Diagnosis_Pointer_1 = string.Empty;
        private string _Diagnosis_Pointer_2 = string.Empty;
        private string _Diagnosis_Pointer_3 = string.Empty;
        private string _Diagnosis_Pointer_4 = string.Empty;
        private string _Diagnosis_Pointer_5 = string.Empty;
        private string _Diagnosis_Pointer_6 = string.Empty;
        private int _Sort_Order = 0;

        #endregion

        #region HashCode override method Value

        public override int GetHashCode()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_ProcedureCode);
            sb.Append(_Procedure_Code_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Units);
            sb.Append(_Modifier1);
            sb.Append(_Modifier2);
            sb.Append(_Modifier3);
            sb.Append(_Modifier4);
            sb.Append(_Charge_Amount);
            sb.Append(_Modifier1_Description);
            sb.Append(_Modifier2_Description);
            sb.Append(_Modifier3_Description);
            sb.Append(_Modifier4_Description);
            sb.Append(_Is_Delete);
            //sb.Append(_Sequence);
            sb.Append(_Diagnosis_Pointer_1);
            sb.Append(_Diagnosis_Pointer_2);
            sb.Append(_Diagnosis_Pointer_3);
            sb.Append(_Diagnosis_Pointer_4);
            sb.Append(_Diagnosis_Pointer_5);
            sb.Append(_Diagnosis_Pointer_6);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        # region getset properties

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _ProcedureCode; }
            set { _ProcedureCode = value; }
        }
        [DataMember]
        public virtual string Procedure_Code_Description
        {
            get { return _Procedure_Code_Description; }
            set { _Procedure_Code_Description = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
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
        public virtual int Units
        {
            get { return _Units; }
            set { _Units = value; }
        }
        [DataMember]
        public virtual string Modifier1
        {
            get { return _Modifier1; }
            set { _Modifier1 = value; }
        }
        [DataMember]
        public virtual string Modifier2
        {
            get { return _Modifier2; }
            set { _Modifier2 = value; }
        }
        [DataMember]
        public virtual string Modifier3
        {
            get { return _Modifier3; }
            set { _Modifier3 = value; }
        }
        [DataMember]
        public virtual string Modifier4
        {
            get { return _Modifier4; }
            set { _Modifier4 = value; }
        }
        [DataMember]
        public virtual decimal Charge_Amount
        {
            get { return _Charge_Amount; }
            set { _Charge_Amount = value; }
        }
        [DataMember]
        public virtual string Modifier1_Description
        {
            get { return _Modifier1_Description; }
            set { _Modifier1_Description = value; }
        }
        [DataMember]
        public virtual string Modifier2_Description
        {
            get { return _Modifier2_Description; }
            set { _Modifier2_Description = value; }
        }
        [DataMember]
        public virtual string Modifier3_Description
        {
            get { return _Modifier3_Description; }
            set { _Modifier3_Description = value; }
        }
        [DataMember]
        public virtual string Modifier4_Description
        {
            get { return _Modifier4_Description; }
            set { _Modifier4_Description = value; }
        }
        [DataMember]
        public virtual string Is_Delete
        {
            get { return _Is_Delete; }
            set { _Is_Delete = value; }
        }
        //[DataMember]
        //public virtual int Sequence
        //{
        //    get { return _Sequence; }
        //    set { _Sequence = value; }
        //}
        //[DataMember]
        //public virtual int CPT_Order
        //{
        //    get { return _CPT_Order; }
        //    set { _CPT_Order = value; }
        //}
         [DataMember]
        public virtual string Diagnosis_Pointer_1
        {
            get { return _Diagnosis_Pointer_1; }
            set { _Diagnosis_Pointer_1 = value; }
        }
         [DataMember]
        public virtual string Diagnosis_Pointer_2
        {
            get { return _Diagnosis_Pointer_2; }
            set { _Diagnosis_Pointer_2 = value; }
        }
         [DataMember]
        public virtual string Diagnosis_Pointer_3
        {
            get { return _Diagnosis_Pointer_3; }
            set { _Diagnosis_Pointer_3 = value; }
        }
         [DataMember]
        public virtual string Diagnosis_Pointer_4
        {
            get { return _Diagnosis_Pointer_4; }
            set { _Diagnosis_Pointer_4 = value; }
        }
         [DataMember]
        public virtual string Diagnosis_Pointer_5
        {
            get { return _Diagnosis_Pointer_5; }
            set { _Diagnosis_Pointer_5 = value; }
        }
         [DataMember]
        public virtual string Diagnosis_Pointer_6
        {
            get { return _Diagnosis_Pointer_6; }
            set { _Diagnosis_Pointer_6 = value; }
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

