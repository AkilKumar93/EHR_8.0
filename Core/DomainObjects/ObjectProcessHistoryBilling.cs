using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ObjectProcessHistoryBilling : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _WfObjId = 0;
        private string _Process_Name = string.Empty;
        private DateTime _Process_Start_Date_And_Time=DateTime.MinValue ;
        private DateTime _Process_End_Date_And_Time = DateTime.MinValue;
        private int _version = 0;
        private string _Obj_Type = string.Empty;
        private string _Obj_Sub_Type = string.Empty;
        private string _Comments = string.Empty;
        private string _User_Name = string.Empty;

        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private string _Doc_Name = string.Empty;
        private ulong _Demos_Enc_PPLine_Comp = 0;
        private decimal _Wf_Obj_Amount = 0;
        private string _Sub_Batch_Range = string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private string _Completed_List = string.Empty;
        private int _Duplicate_Demos_Enc_PPLine = 0;
        private decimal _Duplicate_Amount = 0;
        private string _Batch_Name_in_Billing = string.Empty;
        private string _Print_Name_in_Billing = string.Empty;
        private string _Report_Verified = string.Empty;

        #endregion


        #region Constructors

        public ObjectProcessHistoryBilling() { }

        #endregion


        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_WfObjId);
            sb.Append(_Process_Name);
            sb.Append(_Process_Start_Date_And_Time);
            sb.Append(_Process_End_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Obj_Type);
            sb.Append(_Obj_Sub_Type);
            sb.Append(_Comments);
            sb.Append(_User_Name);
            sb.Append(_DOOS);
            sb.Append(_Batch_Name);
            sb.Append(_Doc_Name);
            sb.Append(_Demos_Enc_PPLine_Comp);
            sb.Append(_Wf_Obj_Amount);
            sb.Append(_Sub_Batch_Range);
            sb.Append(_Doc_Type);
            sb.Append(_Doc_Sub_Type);
            sb.Append(_Completed_List);
            sb.Append(_Duplicate_Demos_Enc_PPLine);
            sb.Append(_Duplicate_Amount);
            sb.Append(_Batch_Name_in_Billing);
            sb.Append(_Print_Name_in_Billing);
            sb.Append(_Report_Verified);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties

        [DataMember]
        public virtual ulong Wf_Object_ID
        {
            get { return _WfObjId; }
            set
            {
                _WfObjId = value;
            }
        }
        [DataMember]
        public virtual string Process_Name
        {
            get { return _Process_Name; }
            set
            {
                _Process_Name = value;
            }
        }
        [DataMember]
        public virtual DateTime Process_Start_Date_And_Time
        {
            get { return _Process_Start_Date_And_Time; }
            set
            {
                _Process_Start_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual DateTime Process_End_Date_And_Time
        {
            get { return _Process_End_Date_And_Time; }
            set
            {
                _Process_End_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        [DataMember]
        public virtual string Obj_Type
        {
            get
            {
                return _Obj_Type;
            }
            set
            {
                _Obj_Type = value;
            }
        }
        [DataMember]
        public virtual string Obj_Sub_Type
        {
            get
            {
                return _Obj_Sub_Type;
            }
            set
            {
                _Obj_Sub_Type = value;
            }
        }
        [DataMember]
        public virtual string Comments
        {
            get
            {
                return _Comments;
            }
            set
            {
                _Comments = value;
            }
        }
        [DataMember]
        public virtual string User_Name
        {
            get
            {
                return _User_Name;
            }
            set
            {
                _User_Name = value;
            }
        }
        [DataMember]
        public virtual string Doc_Type
        {
            get
            {
                return _Doc_Type;
            }
            set
            {
                _Doc_Type = value;
            }
        }
        [DataMember]
        public virtual string Doc_Sub_Type
        {
            get
            {
                return _Doc_Sub_Type;
            }
            set
            {
                _Doc_Sub_Type = value;
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
        public virtual string Doc_Name
        {
            get { return _Doc_Name; }
            set
            {
                _Doc_Name = value;
            }
        }
        [DataMember]
        public virtual ulong Demos_Enc_PPLine_Comp
        {
            get { return _Demos_Enc_PPLine_Comp; }
            set
            {
                _Demos_Enc_PPLine_Comp = value;
            }
        }
        [DataMember]
        public virtual decimal Wf_Obj_Amount
        {
            get { return _Wf_Obj_Amount; }
            set
            {
                _Wf_Obj_Amount = value;
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
        public virtual string Completed_List
        {
            get { return _Completed_List; }
            set
            {
                _Completed_List = value;
            }
        }
        [DataMember]
        public virtual int Duplicate_Demos_Enc_PPLine
        {
            get { return _Duplicate_Demos_Enc_PPLine; }
            set
            {
                _Duplicate_Demos_Enc_PPLine = value;
            }
        }
        [DataMember]
        public virtual decimal Duplicate_Amount
        {
            get { return _Duplicate_Amount; }
            set
            {
                _Duplicate_Amount = value;
            }
        }
        [DataMember]
        public virtual string Batch_Name_in_Billing
        {
            get { return _Batch_Name_in_Billing; }
            set
            {
                _Batch_Name_in_Billing = value;
            }
        }
        [DataMember]
        public virtual string Print_Name_in_Billing
        {
            get { return _Print_Name_in_Billing; }
            set
            {
                _Print_Name_in_Billing = value;
            }
        }
        [DataMember]
        public virtual string Report_Verified
        {
            get { return _Report_Verified; }
            set
            {
                _Report_Verified = value;
            }
        }
        #endregion
    }
}
