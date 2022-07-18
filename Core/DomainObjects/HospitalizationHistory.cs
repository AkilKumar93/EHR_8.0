using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class HospitalizationHistory : BusinessBase<ulong>
    {
        #region Parameter Variable Decleration

        private ulong _Human_ID=0;        
        private string _From_Date = string.Empty;
        private string _To_Date = string.Empty;
        private string _Reason_For_Hospitalization = string.Empty;
        private string _Created_By = string.Empty;
        private string _Hospitalization_Notes = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _version = 0;
        private ulong _Encounter_Id = 0;
        private ulong _hospitalization_history_master_id = 0;
        private string _Discharge_Physician = string.Empty;
        private string _Is_Readmitted = string.Empty;
        private string _Readmission_Date = string.Empty;  

        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_hospitalization_history_master_id); 
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_Reason_For_Hospitalization);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Encounter_Id);
            sb.Append(_Hospitalization_Notes);
            sb.Append(_Discharge_Physician);
            sb.Append(_Is_Readmitted);
            sb.Append(_Readmission_Date);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation

        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        public virtual ulong Hospitalization_History_Master_ID
        {
            get { return _hospitalization_history_master_id; }
            set { _hospitalization_history_master_id = value; }
        }

        public virtual string From_Date
        {
            get { return _From_Date; }
            set { _From_Date = value; }
        }

        public virtual string To_Date
        {
            get { return _To_Date; }
            set { _To_Date = value; }
        }

        public virtual string Reason_For_Hospitalization
        {
            get { return _Reason_For_Hospitalization; }
            set { _Reason_For_Hospitalization = value; }
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

        public virtual string Hospitalization_Notes
        {
            get { return _Hospitalization_Notes; }
            set { _Hospitalization_Notes = value; }
        }
        public virtual string Discharge_Physician
        {
            get { return _Discharge_Physician; }
            set { _Discharge_Physician = value; }
        }

        public virtual ulong Encounter_Id
        {
            get { return _Encounter_Id; }
            set { _Encounter_Id = value; }
        }

        public virtual string Is_Readmitted
        {
            get { return _Is_Readmitted; }
            set { _Is_Readmitted = value; }
        }
        public virtual string Readmission_Date
        {
            get { return _Readmission_Date; }
            set { _Readmission_Date = value; }
        }
        #endregion

        
    }
}
