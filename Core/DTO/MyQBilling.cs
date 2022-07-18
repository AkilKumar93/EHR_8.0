using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class MyQBilling
    {
        //Billing
        private ulong _Wf_Object_Id=0;
        private string _Obj_Type = string.Empty;
        private string _Obj_Sub_Type = string.Empty;
        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private string _Sub_Batch_Range = string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private string _Parent_Obj_Type = string.Empty;
        private int _Demos_Enc_PPLine_Rcvd=0;
        private string _Insurance_Name = string.Empty;
        private int _Page_Number=0;
        private ulong _Obj_System_Id=0;
        private int _Rend_Prov_Id=0;
        private string _Scan_File_Path_Name = string.Empty;
        private string _Scan_Type = string.Empty;
        private string _Current_Process = string.Empty;
        private ulong _Account_Number = 0;
        private string _Patient_Name = string.Empty;
        private string _DOS = string.Empty;
        private string _Procedure_Code = string.Empty;
        private decimal _Billed_Charge = 0;
        private string _Doc_Name = string.Empty;
        private string _Facility_Name = string.Empty;

        #region Constructors

        public MyQBilling() { }

        #endregion

         #region Properties
        [DataMember]
        public virtual ulong Wf_Object_Id
        {
            get { return _Wf_Object_Id; }
            set { _Wf_Object_Id = value; }
        }
        [DataMember]
        public virtual string Obj_Type
        {
            get { return _Obj_Type; }
            set { _Obj_Type = value; }
        }
        [DataMember]
        public virtual string Obj_Sub_Type
        {
            get { return _Obj_Sub_Type; }
            set { _Obj_Sub_Type = value; }
        }
        [DataMember]
        public virtual string DOOS
        {
            get { return _DOOS; }
            set { _DOOS = value; }
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
            set { _Sub_Batch_Range = value; }
        }
        [DataMember]
        public virtual string Doc_Type
        {
            get { return _Doc_Type; }
            set { _Doc_Type = value; }
        }
        [DataMember]
        public virtual string Doc_Sub_Type
        {
            get { return _Doc_Sub_Type; }
            set { _Doc_Sub_Type = value; }
        }
        [DataMember]
        public virtual string Parent_Obj_Type
        {
            get { return _Parent_Obj_Type; }
            set { _Parent_Obj_Type = value; }
        }
        [DataMember]
        public virtual int Demos_Enc_PPLine_Rcvd
        {
            get { return _Demos_Enc_PPLine_Rcvd; }
            set
            {
                _Demos_Enc_PPLine_Rcvd = value;
            }
        }
        [DataMember]
        public virtual string Insurance_Name
        {
            get { return _Insurance_Name; }
            set { _Insurance_Name = value; }
        }
        [DataMember]
        public virtual int Page_Number
        {
            get { return _Page_Number; }
            set { _Page_Number = value; }
        }
        [DataMember]
        public virtual ulong Obj_System_Id
        {
            get { return _Obj_System_Id; }
            set { _Obj_System_Id = value; }
        }
        [DataMember]
        public virtual int Rend_Prov_Id
        {
            get { return _Rend_Prov_Id; }
            set { _Rend_Prov_Id = value; }
        }
        [DataMember]
        public virtual string Scan_File_Path_Name
        {
            get { return _Scan_File_Path_Name; }
            set { _Scan_File_Path_Name = value; }
        }

        [DataMember]
        public virtual string Scan_Type
        {
            get { return _Scan_Type; }
            set { _Scan_Type = value; }
        }
        [DataMember]
        public virtual string Current_Process
        {
            get { return _Current_Process; }
            set { _Current_Process = value; }
        }
        [DataMember]
        public virtual ulong Account_Number
        {
            get { return _Account_Number; }
            set { _Account_Number = value; }
        }
        [DataMember]
        public virtual string Patient_Name
        {
            get { return _Patient_Name; }
            set { _Patient_Name = value; }
        }
        [DataMember]
        public virtual string DOS
        {
            get { return _DOS; }
            set { _DOS = value; }
        }
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set { _Procedure_Code = value; }
        }
        [DataMember]
        public virtual decimal Billed_Charge
        {
            get { return _Billed_Charge; }
            set { _Billed_Charge = value; }
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
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set
            {
                _Facility_Name = value;
            }
        }
         #endregion

    }
}
