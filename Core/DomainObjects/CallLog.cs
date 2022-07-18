using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class CallLog : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Parent_Object_ID=0;
        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private string _Sub_Batch_Range = string.Empty;
        private string _Doc_Name = string.Empty;
        private string _Patient_Name = string.Empty;
        private string _DOS = string.Empty;
        private string _Procedure_Code = string.Empty;
        private int _Page_Number = 0;
        private ulong _Account_Number = 0;
        private string _Type_of_Call = string.Empty;
        private DateTime _DOB = DateTime.MinValue;
        private string _SSN = string.Empty;
        private string _Gender = string.Empty;
        private ulong _Tax_ID = 0;
        private string _Facility_Name = string.Empty;
        private string _Requested_By = string.Empty;
        private string _Insurance_ID = string.Empty;
        private string _Web_Status = string.Empty;
        private DateTime _Time_Checked = DateTime.MinValue;
        private string _Call_Ref_Number = string.Empty;
        private string _Customer_Rep = string.Empty;
        private string _HMO_Name = string.Empty;
        private string _Group_Number = string.Empty;
        private DateTime _Eligibility_Date = DateTime.MinValue;
        private string _PCP = string.Empty;
        private string _Claim_Mailing_Address = string.Empty;
        private string _Subscriber = string.Empty;
        private decimal _Co_Pay = 0;
        private string _Primary_Secondary = string.Empty;
        private string _Caller_Name = string.Empty;
        //committed by balaji
        //private string _Reason_For_Client = string.Empty;
        //private string _Comments = string.Empty;
        private string _Call_Log_Status = string.Empty;
        private string _Chk_Int_War_No = string.Empty;
        private decimal _WorkSetAmt;
        private string _Insurance_Name = string.Empty;
        private ulong _Group_Id = 0;
        private decimal _Billed_Charge = 0;
        private string _Rendering_NPI = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time;
        private int _Version = 0;
        private ulong _Encounter_ID = 0;
        private ulong _Charge_Header_ID = 0;
        private string _Plan_Added_in_MM = string.Empty;
        private ulong _Internal_Reference_ID = 0;
        //added by balaji
        private ulong _Comments_Message_ID = 0;
        private ulong _Review_Comments_Message_ID = 0;
        private ulong _Internal_Response_Message_ID = 0;
        private ulong _Client_Response_Message_ID = 0;
        private ulong _Charge_Line_Item_ID = 0;
        private string _EOB_Claim_ID = string.Empty;
        private string _Field_Name;
        private string _Reason_Code;
        private string _Reason_Sub_Code;
        private string _Insurance_Type;
        private string _Exc_Category = string.Empty;

        #endregion

        #region Constructors

        public CallLog() { }

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
            sb.Append(_Facility_Name);
            sb.Append(_Patient_Name);
            sb.Append(_DOS);
            sb.Append(_Procedure_Code);
            sb.Append(_Page_Number);
            sb.Append(_Account_Number);
            sb.Append(_Type_of_Call);
            sb.Append(_DOB);
            sb.Append(_SSN);
            sb.Append(_Gender);
            sb.Append(_Tax_ID);
            sb.Append(_Facility_Name);
            sb.Append(_Requested_By);
            sb.Append(_Insurance_ID);
            sb.Append(_Web_Status);
            sb.Append(_Time_Checked);
            sb.Append(_Call_Ref_Number);
            sb.Append(_Customer_Rep);
            sb.Append(_HMO_Name);
            sb.Append(_Group_Number);
            sb.Append(_Eligibility_Date);
            sb.Append(_PCP);
            sb.Append(_Claim_Mailing_Address);
            sb.Append(_Subscriber);
            sb.Append(_Co_Pay);
            sb.Append(_Primary_Secondary);
            sb.Append(_Caller_Name);
            //sb.Append(_Reason_For_Client);
            //sb.Append(_Comments);
            sb.Append(_Call_Log_Status);
            sb.Append(_Chk_Int_War_No);
            sb.Append(_WorkSetAmt);
            sb.Append(_Insurance_Name);
            sb.Append(_Group_Id);
            sb.Append(_Billed_Charge);
            sb.Append(_Rendering_NPI);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Encounter_ID);
            sb.Append(_Charge_Header_ID);
            sb.Append(_Plan_Added_in_MM);
            sb.Append(_Internal_Reference_ID);
            sb.Append(_Comments_Message_ID);
            sb.Append(_Review_Comments_Message_ID);
            sb.Append(_Internal_Response_Message_ID);
            sb.Append(_Client_Response_Message_ID);
            sb.Append(_Charge_Line_Item_ID);
            sb.Append(_EOB_Claim_ID);
            sb.Append(_Field_Name);
            sb.Append(_Reason_Code);
            sb.Append(_Reason_Sub_Code);
            sb.Append(_Insurance_Type);
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
            get { return _Procedure_Code; }
            set
            {
                _Procedure_Code = value;
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
        public virtual ulong Account_Number
        {
            get { return _Account_Number; }
            set
            {
                _Account_Number = value;
            }
        }
        [DataMember]
        public virtual string Type_of_Call
        {
            get { return _Type_of_Call; }
            set
            {
                _Type_of_Call = value;
            }
        }
        [DataMember]
        public virtual DateTime DOB
        {
            get { return _DOB; }
            set
            {
                _DOB = value;
            }
        }
        [DataMember]
        public virtual string SSN
        {
            get { return _SSN; }
            set
            {
                _SSN = value;
            }
        }
        [DataMember]
        public virtual string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
            }
        }
        [DataMember]
        public virtual ulong Tax_ID
        {
            get { return _Tax_ID; }
            set
            {
                _Tax_ID = value;
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
        [DataMember]
        public virtual string Requested_By
        {
            get { return _Requested_By; }
            set
            {
                _Requested_By = value;
            }
        }
        [DataMember]
        public virtual string Insurance_ID
        {
            get { return _Insurance_ID; }
            set
            {
                _Insurance_ID = value;
            }
        }
        [DataMember]
        public virtual string Web_Status
        {
            get { return _Web_Status; }
            set
            {
                _Web_Status = value;
            }
        }
        [DataMember]
        public virtual DateTime Time_Checked
        {
            get { return _Time_Checked; }
            set
            {
                _Time_Checked = value;
            }
        }
        [DataMember]
        public virtual string Call_Ref_Number
        {
            get { return _Call_Ref_Number; }
            set
            {
                _Call_Ref_Number = value;
            }
        }
        [DataMember]
        public virtual string Customer_Rep
        {
            get { return _Customer_Rep; }
            set
            {
                _Customer_Rep = value;
            }
        }
        [DataMember]
        public virtual string HMO_Name
        {
            get { return _HMO_Name; }
            set
            {
                _HMO_Name = value;
            }
        }
        [DataMember]
        public virtual string Group_Number
        {
            get { return _Group_Number; }
            set
            {
                _Group_Number = value;
            }
        }
        [DataMember]
        public virtual DateTime Eligibility_Date
        {
            get { return _Eligibility_Date; }
            set
            {
                _Eligibility_Date = value;
            }
        }
        [DataMember]
        public virtual string PCP
        {
            get { return _PCP; }
            set
            {
                _PCP = value;
            }
        }
        [DataMember]
        public virtual string Claim_Mailing_Address
        {
            get { return _Claim_Mailing_Address; }
            set
            {
                _Claim_Mailing_Address = value;
            }
        }
        [DataMember]
        public virtual string Subscriber
        {
            get { return _Subscriber; }
            set
            {
                _Subscriber = value;
            }
        }
        [DataMember]
        public virtual decimal Co_Pay
        {
            get { return _Co_Pay; }
            set
            {
                _Co_Pay = value;
            }
        }
        [DataMember]
        public virtual string Primary_Secondary
        {
            get { return _Primary_Secondary; }
            set
            {
                _Primary_Secondary = value;
            }
        }
        [DataMember]
        public virtual string Caller_Name
        {
            get { return _Caller_Name; }
            set
            {
                _Caller_Name = value;
            }
        }
        //[DataMember]
        //public virtual string Reason_For_Client
        //{
        //    get { return _Reason_For_Client; }
        //    set
        //    {
        //        _Reason_For_Client = value;
        //    }
        //}
        //[DataMember]
        //public virtual string Comments
        //{
        //    get { return _Comments; }
        //    set
        //    {
        //        _Comments = value;
        //    }
        //}
        [DataMember]
        public virtual string Call_Log_Status
        {
            get { return _Call_Log_Status; }
            set
            {
                _Call_Log_Status = value;
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
        public virtual string Insurance_Name
        {
            get { return _Insurance_Name; }
            set
            {
                _Insurance_Name = value;
            }
        }
        [DataMember]
        public virtual ulong Group_Id
        {
            get { return _Group_Id; }
            set
            {
                _Group_Id = value;
            }
        }
        [DataMember]
        public virtual decimal Billed_Charge
        {
            get { return _Billed_Charge; }
            set
            {
                _Billed_Charge = value;
            }
        }
        [DataMember]
        public virtual string Rendering_NPI
        {
            get { return _Rendering_NPI; }
            set
            {
                _Rendering_NPI = value;
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
            set { _Version = value; }
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
        public virtual ulong Charge_Header_ID
        {
            get { return _Charge_Header_ID; }
            set
            {
                _Charge_Header_ID = value;
            }
        }
        [DataMember]
        public virtual string Plan_Added_in_MM
        {
            get { return _Plan_Added_in_MM; }
            set
            {
                _Plan_Added_in_MM = value;
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
        public virtual string EOB_Claim_ID
        {
            get { return _EOB_Claim_ID; }
            set { _EOB_Claim_ID = value; }
        }
        [DataMember]
        public virtual string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }
        [DataMember]
        public virtual string Reason_Code
        {
            get { return _Reason_Code; }
            set { _Reason_Code = value; }
        }
        [DataMember]
        public virtual string Reason_Sub_Code
        {
            get { return _Reason_Sub_Code; }
            set { _Reason_Sub_Code = value; }
        }
        [DataMember]
        public virtual string Insurance_Type
        {
            get { return _Insurance_Type; }
            set { _Insurance_Type = value; }
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
