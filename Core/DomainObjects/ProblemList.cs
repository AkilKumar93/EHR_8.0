
using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ProblemList : BusinessBase<ulong>
    {

        #region Parameter Variable Decleration


        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        private ulong _Physician_ID = 0;
        private string _Reference_Source = string.Empty;
        private string _ICD = string.Empty;
        private string _Problem_Description = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _version=0;
        private string _Status = string.Empty;
        private string _Date_Diagnosed = string.Empty;

        private ulong _Rcopia_ID=0;
        private string _Last_Modified_By = string.Empty;
        private DateTime _Last_Modified_Date = DateTime.MinValue;
        private string _Is_Active = string.Empty;

        //saravanan
        private string _Snomed_Code = string.Empty;
        private string _Snomed_Code_Description = string.Empty;


        private string _Version_Year = string.Empty;
        private string _ICD_9 = string.Empty;
        private string _ICD_9_Description = string.Empty;
        private string _DataFrom = string.Empty;
        private string _Resolved_Date = string.Empty;
        private string _Is_Health_Concern = string.Empty;

        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Reference_Source);
            sb.Append(_ICD);
            sb.Append(_Problem_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Status);
            sb.Append(_Date_Diagnosed);
            sb.Append(_Rcopia_ID);
            sb.Append(_Last_Modified_By);
            sb.Append(_Last_Modified_Date);
            sb.Append(_Is_Active);
            sb.Append(_Snomed_Code);
            sb.Append(_Snomed_Code_Description);
            sb.Append(_ICD_9);
            sb.Append(_ICD_9_Description);
            sb.Append(_Version_Year);
            sb.Append(_DataFrom);
            sb.Append(_Resolved_Date);
            sb.Append(_Is_Health_Concern);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation

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
        public virtual string Reference_Source
        {
            get { return _Reference_Source; }
            set { _Reference_Source = value; }
        }
        [DataMember]
        public virtual string ICD
        {
            get { return _ICD; }
            set { _ICD = value; }
        }
        [DataMember]
        public virtual string Problem_Description
        {
            get { return _Problem_Description; }
            set { _Problem_Description = value; }
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
            get { return _version; }
            set { _version = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [DataMember]
        public virtual string Date_Diagnosed
        {
            get { return _Date_Diagnosed; }
            set { _Date_Diagnosed = value; }
        }

        //added by Velmurugan for Rcopia on 18.04.11
        [DataMember]
        public virtual ulong Rcopia_ID
        {
            get { return _Rcopia_ID; }
            set { _Rcopia_ID = value; }
        }
        
        [DataMember]
        public virtual string Last_Modified_By
        {
            get { return _Last_Modified_By; }
            set { _Last_Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Last_Modified_Date
        {
            get { return _Last_Modified_Date; }
            set { _Last_Modified_Date = value; }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }

        [DataMember]
        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set { _Snomed_Code = value; }
        }
        [DataMember]
        public virtual string Snomed_Code_Description
        {
            get { return _Snomed_Code_Description; }
            set { _Snomed_Code_Description = value; }
        }

        [DataMember]
        public virtual string Version_Year
        {
            get { return _Version_Year; }
            set { _Version_Year = value; }
        }
        [DataMember]
        public virtual string ICD_9
        {
            get { return _ICD_9; }
            set { _ICD_9 = value; }
        }
        [DataMember]
        public virtual string ICD_9_Description
        {
            get { return _ICD_9_Description; }
            set { _ICD_9_Description = value; }
        }
        [DataMember]
        public virtual string DataFrom
        {
            get { return _DataFrom; }
            set { _DataFrom = value; }
        }
         [DataMember]
        public virtual string Resolved_Date
        {
            get { return _Resolved_Date; }
            set { _Resolved_Date = value; }
        }
        [DataMember]
        public virtual string Is_Health_Concern
         {
             get { return _Is_Health_Concern; }
             set { _Is_Health_Concern = value; }
         }
        #endregion
    }
}
