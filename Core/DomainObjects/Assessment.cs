using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Assessment : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        private ulong _Physician_ID = 0;
        private string _Assessment_Type = string.Empty;
        private string _ICD = string.Empty;
        private string _Primary_Diagnosis = string.Empty;
        private string _Chronic_Problem = string.Empty;
        private string _Assessment_Notes = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _ICD_Description = string.Empty;
        private string _Assessment_Status = string.Empty;
        private string _Diagnosis_Source = string.Empty;
        private int _version=0;
        private string _Snomed_Code = string.Empty;
        private string _Snomed_Code_Description = string.Empty;
        private ulong _Internal_Property_ProblemListID = 0;
        private int _Internal_Property_ProblemListVersion = 0;
        private string _ICD_9 = string.Empty;
        private string _ICD_9_Description = string.Empty;
        private string _Version_Year = string.Empty;
        private string _Parent_ICD = string.Empty;

        #endregion

        #region Constructors

        public Assessment() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Assessment_Type);
            sb.Append(_ICD);
            sb.Append(_Primary_Diagnosis);
            sb.Append(_Chronic_Problem);
            sb.Append(_Assessment_Notes);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_ICD_Description);
            sb.Append(_Assessment_Status);
            sb.Append(_Diagnosis_Source);
            sb.Append(_version);
            sb.Append(_Snomed_Code);
            sb.Append(_Snomed_Code_Description);
            sb.Append(_Internal_Property_ProblemListID);
            sb.Append(_Internal_Property_ProblemListVersion);
            sb.Append(_ICD_9);
            sb.Append(_ICD_9_Description);
            sb.Append(_Version_Year);
            sb.Append(_Parent_ICD);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }

        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }

        public virtual string Assessment_Type
        {
            get { return _Assessment_Type; }
            set { _Assessment_Type = value; }

        }

        public virtual string ICD
        {
            get { return _ICD; }
            set { _ICD = value; }
        }

        public virtual string Primary_Diagnosis
        {
            get { return _Primary_Diagnosis; }
            set { _Primary_Diagnosis = value; }
        }

        public virtual string Chronic_Problem
        {
            get { return _Chronic_Problem; }
            set { _Chronic_Problem = value; }
        }

        public virtual string Assessment_Notes
        {
            get { return _Assessment_Notes; }
            set { _Assessment_Notes = value; }
        }

        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }

        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }

        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        public virtual string ICD_Description
        {
            get { return _ICD_Description; }
            set { _ICD_Description = value; }
        }

        public virtual string Assessment_Status
        {
            get { return _Assessment_Status; }
            set { _Assessment_Status = value; }
        }

        public virtual string Diagnosis_Source
        {
            get { return _Diagnosis_Source; }
            set { _Diagnosis_Source = value; }
        }

        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set { _Snomed_Code = value; }
        }

        public virtual string Snomed_Code_Description
        {
            get { return _Snomed_Code_Description; }
            set { _Snomed_Code_Description = value; }
        }
        public virtual ulong Internal_Property_ProblemListID
        {
            get { return _Internal_Property_ProblemListID; }
            set { _Internal_Property_ProblemListID = value; }
        }

        public virtual int Internal_Property_ProblemListVersion
        {
            get { return _Internal_Property_ProblemListVersion; }
            set { _Internal_Property_ProblemListVersion = value; }
        }

        public virtual string ICD_9
        {
            get { return _ICD_9; }
            set { _ICD_9 = value; }
        }
        public virtual string ICD_9_Description
        {
            get { return _ICD_9_Description; }
            set { _ICD_9_Description = value; }
        }
        public virtual string Version_Year
        {
            get { return _Version_Year; }
            set { _Version_Year = value; }
        }
        public virtual string Parent_ICD
        {
            get { return _Parent_ICD; }
            set { _Parent_ICD = value; }
        } 
       
        #endregion
    }
}
