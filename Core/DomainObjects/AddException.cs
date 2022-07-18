using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
   public class AddException : BusinessBase<ulong>
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
        private int _Page_Number=0;
        private ulong _Account_Number = 0;
        private string _Field_Name = string.Empty;
        //private string _Type_of_Exception = string.Empty;
        private string _Exc_Sub_Category = string.Empty;
        private string _Exc_Category = string.Empty;
        //committed by balaji
        //private string _Issues = string.Empty;
        //private string _Raised_By = string.Empty;
        //private string _Reviewed_By = string.Empty;
        //private string _Review_Feedback = string.Empty;
        //private string _Feedback_From_Client = string.Empty;
        //private string _Feedback_By = string.Empty;
        private DateTime _Status_Date = DateTime.MinValue;
        private string _Chk_Int_War_No = string.Empty;
        private decimal _WorkSetAmt = 0;
        private string _Secondary_Insurance = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Feedback_Date = DateTime.MinValue;
        private ulong _Group_ID = 0;
        private decimal _Billed_Charge = 0;
        private string _Insurance_Name = string.Empty;
        private string _Reason_Code = string.Empty;
        private string _Client_Category = string.Empty;
        private string _Client_Sub_Category = string.Empty;
        private ulong _Encounter_ID = 0;
        private int _Version=0;
        private string _Facility_Name = string.Empty;
        private ulong _Charge_Header_ID = 0;
        private string _Modifier = string.Empty;
        private string _Denial_Category = string.Empty;
        private DateTime _Denial_Date = DateTime.MinValue;
        private string _Contact_Person = string.Empty;
        private ulong _Internal_Reference_ID = 0;
        //added by balaji
        private ulong _Comments_Message_ID = 0;
        private ulong _Review_Comments_Message_ID = 0;
        private ulong _Internal_Response_Message_ID = 0;
        private ulong _Client_Response_Message_ID = 0;
        private string _Tertiary_Insurance = string.Empty;
        private ulong _Charge_Line_Item_ID = 0;
        private string _EOB_Claim_ID = string.Empty;
        private string _Reason_Sub_Code = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private ulong _Batch_Human_Map_ID = 0;
        #endregion

        #region Constructors

        public AddException() { }

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
            sb.Append(_Procedure_Code);
            sb.Append(_Page_Number);
            sb.Append(_Account_Number);
            sb.Append(_Field_Name);
            sb.Append(_Exc_Sub_Category);
            sb.Append(_Exc_Category);
            //sb.Append(_Issues);
            //sb.Append(_Raised_By);
            //sb.Append(_Reviewed_By);
            //sb.Append(_Review_Feedback);
            //sb.Append(_Feedback_From_Client);
            //sb.Append(_Feedback_By);
            sb.Append(_Status_Date);
            sb.Append(_Chk_Int_War_No);
            sb.Append(_WorkSetAmt);
            sb.Append(_Secondary_Insurance);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Feedback_Date);
            sb.Append(_Group_ID);
            sb.Append(_Billed_Charge);
            sb.Append(_Insurance_Name);
            sb.Append(_Reason_Code);
            sb.Append(_Client_Category);
            sb.Append(_Client_Sub_Category);
            sb.Append(_Encounter_ID);
            sb.Append(_Version);
            sb.Append(_Facility_Name);
            sb.Append(_Charge_Header_ID);
            sb.Append(_Modifier);
            sb.Append(_Denial_Category);
            sb.Append(_Denial_Date);
            sb.Append(_Contact_Person);
            sb.Append(_Internal_Reference_ID);
            sb.Append(_Comments_Message_ID);
            sb.Append(_Review_Comments_Message_ID);
            sb.Append(_Internal_Response_Message_ID);
            sb.Append(_Client_Response_Message_ID);
            sb.Append(_Tertiary_Insurance);
            sb.Append(_Charge_Line_Item_ID);
            sb.Append(_EOB_Claim_ID);
            sb.Append(_Reason_Sub_Code);
            sb.Append(_Created_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Batch_Human_Map_ID);
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
        public virtual string Field_Name
        {
            get { return _Field_Name; }
            set
            {
                _Field_Name = value;
            }
        }
        [DataMember]
        public virtual string Exc_Sub_Category
        {
            get { return _Exc_Sub_Category; }
            set
            {
                _Exc_Sub_Category = value;
            }
        }
        [DataMember]
        public virtual string Exc_Category
        {
            get { return _Exc_Category; }
            set
            {
                _Exc_Category = value;
            }
        }

        //[DataMember]
        //public virtual string Issues
        //{
        //    get { return _Issues; }
        //    set
        //    {
        //        _Issues = value;
        //    }
        //}


        //[DataMember]
        //public virtual string Raised_By
        //{
        //    get { return _Raised_By; }
        //    set
        //    {
        //        _Raised_By = value;
        //    }
        //}

        //[DataMember]
        //public virtual string Reviewed_By
        //{
        //    get { return _Reviewed_By; }
        //    set
        //    {
        //        _Reviewed_By = value;
        //    }
        //}

        //[DataMember]
        //public virtual string Review_Feedback
        //{
        //    get { return _Review_Feedback; }
        //    set
        //    {
        //        _Review_Feedback = value;
        //    }
        //}

        //[DataMember]
        //public virtual string Feedback_From_Client
        //{
        //    get { return _Feedback_From_Client; }
        //    set
        //    {
        //        _Feedback_From_Client = value;
        //    }
        //}

        //[DataMember]
        //public virtual string Feedback_By
        //{
        //    get { return _Feedback_By; }
        //    set
        //    {
        //        _Feedback_By = value;
        //    }
        //}
        [DataMember]
        public virtual DateTime Status_Date
        {
            get { return _Status_Date; }
            set
            {
                _Status_Date = value;
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
        public virtual string Secondary_Insurance
        {
            get { return _Secondary_Insurance; }
            set
            {
                _Secondary_Insurance = value;
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
        public virtual DateTime Feedback_Date
        {
            get { return _Feedback_Date; }
            set
            {
                _Feedback_Date = value;
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
        public virtual decimal Billed_Charge
        {
            get { return _Billed_Charge; }
            set
            {
                _Billed_Charge = value;
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
        public virtual string Reason_Code
        {
            get { return _Reason_Code; }
            set
            {
                _Reason_Code = value;
            }
        }

        [DataMember]
        public virtual string Client_Category
        {
            get { return _Client_Category; }
            set
            {
                _Client_Category = value;
            }
        }

        [DataMember]
        public virtual string Client_Sub_Category
        {
            get { return _Client_Sub_Category; }
            set
            {
                _Client_Sub_Category = value;
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
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set
            {
                _Facility_Name = value;
            }
        }


        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
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
        public virtual string Modifier
        {
            get { return _Modifier; }
            set
            {
                _Modifier = value;
            }
        }
        [DataMember]
        public virtual string Denial_Category
        {
            get { return _Denial_Category; }
            set
            {
                _Denial_Category = value;
            }
        }
        [DataMember]
        public virtual DateTime Denial_Date
        {
            get { return _Denial_Date; }
            set
            {
                _Denial_Date = value;
            }
        }
        [DataMember]
        public virtual string Contact_Person
        {
            get { return _Contact_Person; }
            set
            {
                _Contact_Person = value;
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
        public virtual string Tertiary_Insurance
        {
            get { return _Tertiary_Insurance;}
            set { _Tertiary_Insurance = value; }
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
        public virtual string Reason_Sub_Code
        {
            get { return _Reason_Sub_Code; }
            set { _Reason_Sub_Code = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual ulong Batch_Human_Map_ID
        {
            get { return _Batch_Human_Map_ID; }
            set
            {
                _Batch_Human_Map_ID = value;
            }
        }
        #endregion

    }
}
