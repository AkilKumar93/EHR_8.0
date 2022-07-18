using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ChargeHeader : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Batch_ID = 0;

        private ulong _Encounter_ID = 0;

        private string _Voucher_No = string.Empty;


        private ulong _Human_ID = 0;
        private string _Patient_Condition_Rel_To_Emp = string.Empty;
        private string _Patient_Condition_Rel_To_AutoAcc = string.Empty;
        private string _Patient_Condition_Rel_To_OtherAcc = string.Empty;
        private string _Place_AutoAcc = string.Empty;
        private DateTime _Date_of_Current_Illness =DateTime.MinValue;// "1111-11-11";
        private DateTime _Other_Date = DateTime.MinValue;//"1111-11-11";
        private DateTime _Dates_Patient_Unable_to_work_From = DateTime.MinValue;//"1111-11-11";
        private DateTime _Dates_Patient_Unable_to_work_To = DateTime.MinValue;//"1111-11-11";
        private ulong _Referring_Provider_ID = 0;
        private DateTime _Hosp_Dates_From = DateTime.MinValue;//"1111-11-11";
        private DateTime _Hosp_Dates_To = DateTime.MinValue;//"1111-11-11";
        private string _Reserved_Box_19 = string.Empty;
        private string _Outside_Lab = string.Empty;
        private double _Lab_Charge_Amount = 0;
        private string _Resubmission_Code = string.Empty;
        private string _Original_Ref_No = string.Empty;
        private ulong _Billing_Provider_ID = 0;
        private string _Appt_Facility_Name = string.Empty;
        private string _Prior_Auth_No = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Reserved_Box_10d = string.Empty;
        private string _Resubmission_Text = string.Empty;
        private string _Claim_Codes = string.Empty;
        private string _Other_Claim_ID = string.Empty;
        private string _Ref_Prov_Type = string.Empty;
        private string _Current_Illness_Qualifier = string.Empty;
        private string _Other_Date_Qualifier = string.Empty;
        private string _Additional_Claim_Info = string.Empty;
        private string _ICD_Type = string.Empty;
        private string _Diagnosis1 = string.Empty;
        private string _Diagnosis2 = string.Empty;
        private string _Diagnosis3 = string.Empty;
        private string _Diagnosis4 = string.Empty;
        private string _Diagnosis5 = string.Empty;
        private string _Diagnosis6 = string.Empty;
        private string _Diagnosis7 = string.Empty;
        private string _Diagnosis8 = string.Empty;
        private string _Diagnosis9 = string.Empty;
        private string _Diagnosis10 = string.Empty;
        private string _Diagnosis11 = string.Empty;
        private string _Diagnosis12 = string.Empty;
        private string _Hold_Claim = string.Empty;
        private ulong _Group_ID = 0;
        private string _Billing_Facility = string.Empty;
        private ulong _Encounter_Provider_ID = 0;
        private string _Charge_Header_Identifier = string.Empty;
        private string _Encounter_Type = string.Empty;
        private string _Is_Delete = string.Empty;
        private ulong _Internal_Reference_ID = 0;
        #endregion

        #region Constructors

        public ChargeHeader() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Batch_ID);

            sb.Append(_Encounter_ID);

            sb.Append(_Voucher_No);

            sb.Append(_Human_ID);
            sb.Append(_Patient_Condition_Rel_To_Emp);
            sb.Append(_Patient_Condition_Rel_To_AutoAcc);
            sb.Append(_Patient_Condition_Rel_To_OtherAcc);
            sb.Append(_Place_AutoAcc);
            sb.Append(_Date_of_Current_Illness);
            sb.Append(_Other_Date);
            sb.Append(_Dates_Patient_Unable_to_work_From);
            sb.Append(_Dates_Patient_Unable_to_work_To);
            sb.Append(_Referring_Provider_ID);
            sb.Append(_Hosp_Dates_From);
            sb.Append(_Hosp_Dates_To);
            sb.Append(_Reserved_Box_19);
            sb.Append(_Outside_Lab);
            sb.Append(_Lab_Charge_Amount);
            sb.Append(_Resubmission_Code);
            sb.Append(_Original_Ref_No);
            sb.Append(_Billing_Provider_ID);
            sb.Append(_Appt_Facility_Name);
            sb.Append(_Prior_Auth_No);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Encounter_ID);
            sb.Append(_Reserved_Box_10d);
            sb.Append(_Resubmission_Text);
            sb.Append(_Claim_Codes);
            sb.Append(_Other_Claim_ID);
            sb.Append(_Ref_Prov_Type);
            sb.Append(_Current_Illness_Qualifier);
            sb.Append(_Other_Date_Qualifier);
            sb.Append(_Additional_Claim_Info);
            sb.Append(_ICD_Type);
            sb.Append(_Diagnosis1);
            sb.Append(_Diagnosis2);
            sb.Append(_Diagnosis3);
            sb.Append(_Diagnosis4);
            sb.Append(_Diagnosis5);
            sb.Append(_Diagnosis6);
            sb.Append(_Diagnosis7);
            sb.Append(_Diagnosis8);
            sb.Append(_Diagnosis9);
            sb.Append(_Diagnosis10);
            sb.Append(_Diagnosis11);
            sb.Append(_Diagnosis12);
            sb.Append(_Hold_Claim);
            sb.Append(_Group_ID);
            sb.Append(_Billing_Facility);
            sb.Append(_Encounter_Provider_ID);
            sb.Append(_Charge_Header_Identifier);
            sb.Append(_Encounter_Type);
            sb.Append(_Is_Delete);
            sb.Append(_Internal_Reference_ID);
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
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
            }
        }

        [DataMember]
        public virtual string Voucher_No
        {
            get { return _Voucher_No; }
            set
            {
                _Voucher_No = value;
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
        public virtual string Patient_Condition_Rel_To_Emp
        {
            get { return _Patient_Condition_Rel_To_Emp; }
            set
            {
                _Patient_Condition_Rel_To_Emp = value;
            }
        }
        [DataMember]
        public virtual string Patient_Condition_Rel_To_AutoAcc
        {
            get { return _Patient_Condition_Rel_To_AutoAcc; }
            set
            {
                _Patient_Condition_Rel_To_AutoAcc = value;
            }
        }
        [DataMember]
        public virtual string Patient_Condition_Rel_To_OtherAcc
        {
            get { return _Patient_Condition_Rel_To_OtherAcc; }
            set
            {
                _Patient_Condition_Rel_To_OtherAcc = value;
            }
        }
        [DataMember]
        public virtual string Place_AutoAcc
        {
            get { return _Place_AutoAcc; }
            set
            {
                _Place_AutoAcc = value;
            }
        }
        [DataMember]
        public virtual DateTime Date_of_Current_Illness
        {
            get { return _Date_of_Current_Illness; }
            set
            {
                _Date_of_Current_Illness = value;
            }
        }
        [DataMember]
        public virtual DateTime Other_Date
        {
            get { return _Other_Date; }
            set
            {
                _Other_Date = value;
            }
        }
        [DataMember]
        public virtual DateTime Dates_Patient_Unable_to_work_To
        {
            get { return _Dates_Patient_Unable_to_work_To; }
            set
            {
                _Dates_Patient_Unable_to_work_To = value;
            }
        }
        [DataMember]
        public virtual DateTime Dates_Patient_Unable_to_work_From
        {
            get { return _Dates_Patient_Unable_to_work_From; }
            set
            {
                _Dates_Patient_Unable_to_work_From = value;
            }
        }
        [DataMember]
        public virtual ulong Referring_Provider_ID
        {
            get { return _Referring_Provider_ID; }
            set
            {
                _Referring_Provider_ID = value;
            }
        }
        [DataMember]
        public virtual DateTime Hosp_Dates_From
        {
            get { return _Hosp_Dates_From; }
            set
            {
                _Hosp_Dates_From = value;
            }
        }
        [DataMember]
        public virtual DateTime Hosp_Dates_To
        {
            get { return _Hosp_Dates_To; }
            set
            {
                _Hosp_Dates_To = value;
            }
        }
        [DataMember]
        public virtual string Reserved_Box_19
        {
            get { return _Reserved_Box_19; }
            set
            {
                _Reserved_Box_19 = value;
            }
        }
        [DataMember]
        public virtual string Outside_Lab
        {
            get { return _Outside_Lab; }
            set
            {
                _Outside_Lab = value;
            }
        }
        [DataMember]
        public virtual double Lab_Charge_Amount
        {
            get { return _Lab_Charge_Amount; }
            set
            {
                _Lab_Charge_Amount = value;
            }
        }
        [DataMember]
        public virtual string Resubmission_Code
        {
            get { return _Resubmission_Code; }
            set
            {
                _Resubmission_Code = value;
            }
        }
        [DataMember]
        public virtual string Original_Ref_No
        {
            get { return _Original_Ref_No; }
            set
            {
                _Original_Ref_No = value;
            }
        }
        [DataMember]
        public virtual ulong Billing_Provider_ID
        {
            get { return _Billing_Provider_ID; }
            set
            {
                _Billing_Provider_ID = value;
            }
        }
        [DataMember]
        public virtual string Appt_Facility_Name
        {
            get { return _Appt_Facility_Name; }
            set
            {
                _Appt_Facility_Name = value;
            }
        }
        [DataMember]
        public virtual string Prior_Auth_No
        {
            get { return _Prior_Auth_No; }
            set
            {
                _Prior_Auth_No = value;
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
        public virtual string Reserved_Box_10d
        {
            get { return _Reserved_Box_10d; }
            set
            {
                _Reserved_Box_10d = value;
            }
        }
        [DataMember]
        public virtual string Resubmission_Text
        {
            get { return _Resubmission_Text; }
            set
            {
                _Resubmission_Text = value;
            }
        }
        [DataMember]
        public virtual string Claim_Codes
        {
            get { return _Claim_Codes; }
            set
            {
                _Claim_Codes = value;
            }
        }
        [DataMember]
        public virtual string Other_Claim_ID
        {
            get { return _Other_Claim_ID; }
            set
            {
                _Other_Claim_ID = value;
            }
        }
        [DataMember]
        public virtual string Ref_Prov_Type
        {
            get { return _Ref_Prov_Type; }
            set
            {
                _Ref_Prov_Type = value;
            }
        }
        [DataMember]
        public virtual string Current_Illness_Qualifier
        {
            get { return _Current_Illness_Qualifier; }
            set
            {
                _Current_Illness_Qualifier = value;
            }
        }
        [DataMember]
        public virtual string Other_Date_Qualifier
        {
            get { return _Other_Date_Qualifier; }
            set
            {
                _Other_Date_Qualifier = value;
            }
        }
        [DataMember]
        public virtual string Additional_Claim_Info
        {
            get { return _Additional_Claim_Info; }
            set
            {
                _Additional_Claim_Info = value;
            }
        }
        [DataMember]
        public virtual string ICD_Type
        {
            get { return _ICD_Type; }
            set
            {
                _ICD_Type = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis1
        {
            get { return _Diagnosis1; }
            set
            {
                _Diagnosis1 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis2
        {
            get { return _Diagnosis2; }
            set
            {
                _Diagnosis2 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis3
        {
            get { return _Diagnosis3; }
            set
            {
                _Diagnosis3 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis4
        {
            get { return _Diagnosis4; }
            set
            {
                _Diagnosis4 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis5
        {
            get { return _Diagnosis5; }
            set
            {
                _Diagnosis5 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis6
        {
            get { return _Diagnosis6; }
            set
            {
                _Diagnosis6 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis7
        {
            get { return _Diagnosis7; }
            set
            {
                _Diagnosis7 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis8
        {
            get { return _Diagnosis8; }
            set
            {
                _Diagnosis8 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis9
        {
            get { return _Diagnosis9; }
            set
            {
                _Diagnosis9 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis10
        {
            get { return _Diagnosis10; }
            set
            {
                _Diagnosis10 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis11
        {
            get { return _Diagnosis11; }
            set
            {
                _Diagnosis11 = value;
            }
        }
        [DataMember]
        public virtual string Diagnosis12
        {
            get { return _Diagnosis12; }
            set
            {
                _Diagnosis12 = value;
            }
        }
        [DataMember]
        public virtual string Hold_Claim
        {
            get { return _Hold_Claim; }
            set
            {
                _Hold_Claim = value;
            }
        }
        [DataMember]
        public virtual ulong Group_ID
        {
            get { return _Group_ID; }
            set
            {
                _Group_ID = value;
            }
        }
        [DataMember]
        public virtual string Billing_Facility
        {
            get { return _Billing_Facility; }
            set
            {
                _Billing_Facility = value;
            }
        }
        [DataMember]
        public virtual ulong Encounter_Provider_ID
        {
            get { return _Encounter_Provider_ID; }
            set
            {
                _Encounter_Provider_ID = value;
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
        [DataMember]
        public virtual string Encounter_Type
        {
            get { return _Encounter_Type; }
            set
            {
                _Encounter_Type = value;
            }
        }
        [DataMember]
        public virtual string Is_Delete
        {
            get { return _Is_Delete; }
            set { _Is_Delete = value; }
        }
        [DataMember]
        public virtual ulong Internal_Reference_ID
        {
            get { return _Internal_Reference_ID; }
            set
            {
                _Internal_Reference_ID = value;
            }
        }
        #endregion
    }

}
