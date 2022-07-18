using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class PatientResults:BusinessBase<ulong>
    {
        #region Declarations

        private ulong _encounterId = 0;
        private ulong _HumanID = 0;
        private ulong _physicianId = 0;
        private string _Loinc_Identifier = string.Empty;
        private string _Loinc_Observation = string.Empty;
        private string _Value = string.Empty;
        private string _createdBy = string.Empty;
        private DateTime _createdDateTime = DateTime.MinValue;
        private string _modifiedBy = string.Empty;
        private DateTime _modifiedDatetime = DateTime.MinValue;
        private ulong _Vitals_Group_ID = 0;
        private int _Version=0;
        private DateTime _Captured_date_and_time = DateTime.Now;
        private string _Notes = string.Empty;
        private string _Results_Type = string.Empty;
        private string _Abnormal_Flags = string.Empty;
        private string _Units = string.Empty;
        private string _Reference_Range = string.Empty;
        private string _Acurus_Result_Code = string.Empty;
        private string _Acurus_Result_Description = string.Empty;
        private ulong _Result_Master_ID = 0;
        private ulong _Result_OBX_ID = 0;
        private string _Is_Sent_to_Rcopia = string.Empty;
        private string _Local_Time = string.Empty;
        private int _Internal_Property_Month = 0;
        private int _Internal_Property_Year = 0;
        private string _Snomed_Code = string.Empty;
       // private string _Reason_For_Not_Performed = string.Empty;
        
        #endregion

        #region Constructors

        public PatientResults() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_encounterId);
            sb.Append(_HumanID);
            sb.Append(_physicianId);
            sb.Append(_Loinc_Identifier);
            sb.Append(_Loinc_Observation);
            sb.Append(_Value);
            sb.Append(_createdBy);
            sb.Append(_createdDateTime);
            sb.Append(_modifiedBy);
            sb.Append(_modifiedDatetime);
            sb.Append(_Vitals_Group_ID);
            sb.Append(_Version);
            sb.Append(_Captured_date_and_time);
            sb.Append(_Notes);
            sb.Append(_Results_Type);
            sb.Append(_Abnormal_Flags);
            sb.Append(_Units);
            sb.Append(_Reference_Range);
            sb.Append(_Acurus_Result_Code);
            sb.Append(_Acurus_Result_Description);
            sb.Append(_Result_Master_ID);
            sb.Append(_Result_OBX_ID);
            sb.Append(_Is_Sent_to_Rcopia);
            sb.Append(_Local_Time);
            sb.Append(_Internal_Property_Month);
            sb.Append(_Internal_Property_Year);
            sb.Append(_Snomed_Code);
           // sb.Append(_Reason_For_Not_Performed);
            
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        
        public virtual ulong Encounter_ID
        {
            get { return _encounterId; }
            set { _encounterId = value; }
        }
        
        public virtual ulong Human_ID
        {
            get { return _HumanID; }
            set { _HumanID = value; }
        }
        
        public virtual ulong Physician_ID
        {
            get { return _physicianId; }
            set { _physicianId = value; }

        }
        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set { _Snomed_Code = value; }
        }
        public virtual string Local_Time
        {
            get { return _Local_Time; }
            set { _Local_Time = value; }
        }
        
        public virtual string Loinc_Identifier
        {
            get { return _Loinc_Identifier; }
            set { _Loinc_Identifier = value; }
        }
        
        public virtual string Loinc_Observation
        {
            get { return _Loinc_Observation; }
            set { _Loinc_Observation = value; }
        }
        
        public virtual string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        
        public virtual string Created_By
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        
        public virtual DateTime Created_Date_And_Time
        {
            get { return _createdDateTime; }
            set { _createdDateTime = value; }
        }
        
        public virtual string Modified_By
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _modifiedDatetime; }
            set { _modifiedDatetime = value; }
        }

        public virtual ulong Vitals_Group_ID
        {
            get { return _Vitals_Group_ID; }
            set { _Vitals_Group_ID = value; }
        }
        
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
      
        public virtual DateTime Captured_date_and_time
        {
            get { return _Captured_date_and_time; }
            set { _Captured_date_and_time = value; }
        }


        public virtual string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        
        public virtual string Results_Type
        {
            get { return _Results_Type; }
            set { _Results_Type = value; }
        }
        
        public virtual string Abnormal_Flags
        {
            get { return _Abnormal_Flags; }
            set { _Abnormal_Flags = value; }
        }
        
        public virtual string Units
        {
            get { return _Units; }
            set { _Units = value; }
        }
        
        public virtual string Reference_Range
        {
            get { return _Reference_Range; }
            set { _Reference_Range = value; }
        }

        //public virtual string Reason_For_Not_Performed
        //{
        //    get { return _Reason_For_Not_Performed; }
        //    set { _Reason_For_Not_Performed = value; }
        //}
        public virtual string Acurus_Result_Code
        {
            get { return _Acurus_Result_Code; }
            set { _Acurus_Result_Code = value; }
        }
        
        public virtual string Acurus_Result_Description
        {
            get { return _Acurus_Result_Description; }
            set { _Acurus_Result_Description = value; }
        }
        
        public virtual ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }
        
        public virtual ulong Result_OBX_ID
        {
            get { return _Result_OBX_ID; }
            set { _Result_OBX_ID = value; }
        }
        public virtual string Is_Sent_to_Rcopia
        {
            get { return _Is_Sent_to_Rcopia; }
            set { _Is_Sent_to_Rcopia = value; }
        }
        public virtual int Internal_Property_Month
        {
            get { return _Internal_Property_Month; }
            set { _Internal_Property_Month = value; }
        }

        public virtual int Internal_Property_Year
        {
            get { return _Internal_Property_Year; }
            set { _Internal_Property_Year = value; }
        }    
        #endregion
   }
    
}
