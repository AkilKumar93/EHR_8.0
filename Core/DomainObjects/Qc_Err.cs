using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
         [DataContract]
   public partial  class Qc_Err : BusinessBase<ulong>
    {
        
        #region Declarations
        private ulong _Parent_Object_ID=0;
        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private string _Sub_Batch_Range = string.Empty;
        private string _Doc_Name = string.Empty;
        private string _Patient_Name = string.Empty;
        private string _DOS =  string.Empty;
        private string _CPT_Code = string.Empty;
        private int _Page_Number=0;
        private string _Created_By = string.Empty;
        private string _Error_Type = string.Empty;
        private string _Error_Field = string.Empty;
        private string _Error_Description = string.Empty;
        //private string _Error_Corr_By = string.Empty;
        //code committed by balaji
        //private string _Error_Corr_Notes = string.Empty;
        private ulong _Account_Number = 0;
        private string _Chk_Int_War_No = string.Empty;
        private decimal _WorkSetAmt = 0;
        private ulong _Encounter_ID = 0;
        private int _Version=0;
        private ulong _Charge_Header_ID = 0;
        private ulong _Internal_Reference_ID = 0;
        //added by balaji
        private ulong _Comments_Message_ID = 0;
        private ulong _Review_Comments_Message_ID = 0;
        private ulong _Internal_Response_Message_ID = 0;
        private ulong _Client_Response_Message_ID = 0;
        private ulong _Charge_Line_Item_ID = 0;
        private string _Field_Name = string.Empty;
        private string _Reason_Code = string.Empty;
        private string _Reason_Sub_Code = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Claim_Number = string.Empty;
        private string _Exc_Category = string.Empty;

        #endregion

        #region Constructors
        public Qc_Err() { }
        #endregion

           #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Parent_Object_ID);
            sb.Append(_DOOS);
            sb.Append(_Batch_Name);
            sb.Append(_Sub_Batch_Range);
            sb.Append(_Doc_Name);
            sb.Append(_Patient_Name);
            sb.Append(_DOS);
            sb.Append(_CPT_Code);
            sb.Append(_Page_Number);
            sb.Append(_Created_By);
            sb.Append(_Error_Type);
            sb.Append(_Error_Field);
            sb.Append(_Error_Description);
            //sb.Append(_Error_Corr_By);
            //sb.Append(_Error_Corr_Notes);
            sb.Append(_Account_Number);
            sb.Append(_Chk_Int_War_No);
            sb.Append(_WorkSetAmt);
            sb.Append(_Encounter_ID);
            sb.Append(_Version);
            sb.Append(_Charge_Header_ID);
            sb.Append(_Internal_Reference_ID);
            //added by balaji
            sb.Append(_Comments_Message_ID);
            sb.Append(_Review_Comments_Message_ID);
            sb.Append(_Internal_Response_Message_ID);
            sb.Append(_Client_Response_Message_ID);
            sb.Append(_Charge_Line_Item_ID);
            sb.Append(_Field_Name);
            sb.Append(_Reason_Code);
            sb.Append(_Reason_Sub_Code);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Claim_Number);
            sb.Append(_Exc_Category);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual ulong Parent_Object_ID
        {
            get { return _Parent_Object_ID; }
            set
            {
                _Parent_Object_ID = value;
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
        public virtual string Sub_Batch_Range
        {
            get { return _Sub_Batch_Range; }
            set
            {
                _Sub_Batch_Range = value;
            }
        }
        [DataMember]
        public virtual string Doc_Name
        {
            get { return _Doc_Name; }
            set
            {
                _Doc_Name = value;
            }
        }
        [DataMember]
        public virtual string Patient_Name
        {
            get { return _Patient_Name; }
            set
            {
                _Patient_Name = value;
            }
        }

        [DataMember]
        public virtual string DOS
        {
            get { return _DOS; }
            set
            {
                _DOS = value;
            }
        }

        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _CPT_Code; }
            set
            {
                _CPT_Code = value;
            }
        }

        [DataMember]
        public virtual int Page_Number
        {
            get { return _Page_Number; }
            set
            {
                _Page_Number = value;
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
        public virtual string Error_Type
        {
            get { return _Error_Type; }
            set
            {
                _Error_Type = value;
            }
        }

        [DataMember]
        public virtual string Error_Field
        {
            get { return _Error_Field; }
            set
            {
                _Error_Field = value;
            }
        }

     

        [DataMember]
        public virtual string Error_Description
        {
            get { return _Error_Description; }
            set
            {
                _Error_Description = value;
            }
        }

        //[DataMember]
        //public virtual string Error_Corr_By
        //{
        //    get { return _Error_Corr_By; }
        //    set
        //    {
        //        _Error_Corr_By = value;
        //    }
        //}

        //[DataMember]
        //public virtual string Error_Corr_Notes
        //{
        //    get { return _Error_Corr_Notes; }
        //    set
        //    {
        //        _Error_Corr_Notes = value;
        //    }
        //}
        [DataMember]
        public virtual ulong Account_Number
        {
            get { return _Account_Number; }
            set
            {
                _Account_Number = value;
            }
        }
        [DataMember]
        public virtual string Chk_Int_War_No
        {
            get { return _Chk_Int_War_No; }
            set
            {
                _Chk_Int_War_No = value;
            }
        }
        [DataMember]
        public virtual decimal WorkSetAmt
        {
            get { return _WorkSetAmt; }
            set
            {
                _WorkSetAmt = value;
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
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
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
        public virtual ulong Internal_Reference_ID
        {
            get { return _Internal_Reference_ID; }
            set
            {
                _Internal_Reference_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Comments_Message_ID
        {
            get { return _Comments_Message_ID; }
            set
            {
                _Comments_Message_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Review_Comments_Message_ID
        {
            get { return _Review_Comments_Message_ID; }
            set
            {
                _Review_Comments_Message_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Internal_Response_Message_ID
        {
            get { return _Internal_Response_Message_ID; }
            set
            {
                _Internal_Response_Message_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Client_Response_Message_ID
        {
            get { return _Client_Response_Message_ID; }
            set
            {
                _Client_Response_Message_ID = value;
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
        public virtual string Field_Name
        {
            get { return _Field_Name; }
            set
            {
                _Field_Name = value;
            }
        }
        [DataMember]
        public virtual string Reason_Code
        {
            get { return _Reason_Code; }
            set
            {
                _Reason_Code = value;
            }
        }
        [DataMember]
        public virtual string Reason_Sub_Code
        {
            get { return _Reason_Sub_Code; }
            set
            {
                _Reason_Sub_Code = value;
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
        public virtual string Claim_Number
        {
            get { return _Claim_Number; }
            set { _Claim_Number = value; }
        }
        [DataMember]
        public virtual string Exc_Category
        {
            get { return _Exc_Category; }
            set { _Exc_Category = value; }
        }
        #endregion



    }
}
