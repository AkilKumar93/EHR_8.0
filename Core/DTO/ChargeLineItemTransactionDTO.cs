using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class ChargeLineItemTransactionDTO
    {
        #region Declarations

        private ulong _Charge_Line_Item_Id = 0;
        private DateTime _From_DOS = DateTime.MinValue;
        private DateTime _To_DOS = DateTime.MinValue;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private ulong _Rendering_Provider_ID = 0;
        private string _Procedure_Code = string.Empty;
        private string _NDC_Code = string.Empty;
        private double _Charge_Amount = 0;
        private string _Claim_Type = string.Empty;
        private decimal _Sum_Amount = 0;
        private decimal _PatientBalance = 0;
        private decimal _PatientDue = 0;
        private decimal _PatientUnapplied = 0;
        private string _Modifier1 = string.Empty;
        private string _Modifier2 = string.Empty;
        private string _Modifier3 = string.Empty;
        private string _Modifier4 = string.Empty;
        private string _NDC_Units = string.Empty;
        private string _Place_of_Service = string.Empty;
        private string _EMG = string.Empty;
        private string _Writeoff = string.Empty;
        private string _Paid = string.Empty;
        private string _Diagnosis = string.Empty;
        //private IList<Denial> _ilstDenialList;
        private ulong _Charge_Header_ID = 0;
        private int _Encounter_ID = 0;
        private int _Batch_ID = 0;
        private decimal _Units = 0;
        private string _DoctorName = string.Empty;
        private string _InsurancePlan = string.Empty;
        private string _Created_By = string.Empty;
        private int _TotalCount = 0;
        private ulong _Internal_Reference_ID = 0;
        #endregion

        #region Constructor

        public ChargeLineItemTransactionDTO()
        {
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual ulong Charge_Line_Item_Id
        {
            get { return _Charge_Line_Item_Id; }
            set { _Charge_Line_Item_Id = value; }
        }
        [DataMember]
        public virtual string DoctorName
        {
            get { return _DoctorName; }
            set { _DoctorName = value; }
        }
        [DataMember]
        public virtual string InsurancePlan
        {
            get { return _InsurancePlan; }
            set { _InsurancePlan = value; }
        }
        [DataMember]
        public virtual DateTime From_DOS
        {
            get { return _From_DOS; }
            set { _From_DOS = value; }
        }
        [DataMember]
        public virtual DateTime To_DOS
        {
            get { return _To_DOS; }
            set { _To_DOS = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }

        [DataMember]
        public virtual ulong Rendering_Provider_ID
        {
            get { return _Rendering_Provider_ID; }
            set { _Rendering_Provider_ID = value; }
        }
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set { _Procedure_Code = value; }
        }
        [DataMember]
        public virtual string NDC_Code
        {
            get { return _NDC_Code; }
            set { _NDC_Code = value; }
        }
        [DataMember]
        public virtual double Charge_Amount
        {
            get { return _Charge_Amount; }
            set { _Charge_Amount = value; }
        }
        [DataMember]
        public virtual string Claim_Type
        {
            get { return _Claim_Type; }
            set { _Claim_Type = value; }
        }
        [DataMember]
        public virtual decimal Sum_Amount
        {
            get { return _Sum_Amount; }
            set { _Sum_Amount = value; }
        }
        [DataMember]
        public virtual decimal PatientBalance
        {
            get { return _PatientBalance; }
            set { _PatientBalance = value; }
        }
        [DataMember]
        public virtual decimal PatientDue
        {
            get { return _PatientDue; }
            set { _PatientDue = value; }
        }
        [DataMember]
        public virtual decimal PatientUnapplied
        {
            get { return _PatientUnapplied; }
            set { _PatientUnapplied = value; }
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
        public virtual string NDC_Units
        {
            get { return _NDC_Units; }
            set { _NDC_Units = value; }
        }
        [DataMember]
        public virtual string Place_of_Service
        {
            get { return _Place_of_Service; }
            set { _Place_of_Service = value; }
        }
        [DataMember]
        public virtual string EMG
        {
            get { return _EMG; }
            set { _EMG = value; }
        }
        [DataMember]
        public virtual string Diagnosis
        {
            get { return _Diagnosis; }
            set { _Diagnosis = value; }
        }
        [DataMember]
        public virtual string Writeoff
        {
            get { return _Writeoff; }
            set { _Writeoff = value; }
        }
        [DataMember]
        public virtual string paid
        {
            get { return _Paid; }
            set { _Paid = value; }
        }
        [DataMember]
        public virtual ulong Charge_Header_ID
        {
            get { return _Charge_Header_ID; }
            set { _Charge_Header_ID = value; }
        }
        [DataMember]
        public virtual int Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual decimal Units
        {
            get { return _Units; }
            set { _Units = value; }
        }
        [DataMember]
        public virtual int Batch_ID
        {
            get { return _Batch_ID; }
            set { _Batch_ID = value; }
        }
        [DataMember]
        public virtual int TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; }
        }
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        public virtual ulong Internal_Reference_ID
        {
            get { return _Internal_Reference_ID; }
            set { _Internal_Reference_ID = value; }
        }
        #endregion
    }
}
