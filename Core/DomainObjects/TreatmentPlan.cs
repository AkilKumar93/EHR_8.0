using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    [Serializable]
   public partial class TreatmentPlan:BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Encounter_Id=0;
        private ulong _Human_Id=0;
        private ulong _Physician_Id=0;
        private string _Plan = string.Empty;        
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version=0;
        private string _Addendum_plan = string.Empty;
        private string _Plan_Type = string.Empty;
        private ulong _Source_ID = 0;
        private string _Plan_For_Plan = string.Empty;
        private string _Plan_Reference = string.Empty;
        private string _Followup_Plan_Snomed = string.Empty;
        private string _Corrections_to_be_made = string.Empty;
        private string _Amendment_Type = string.Empty;
        private string _Local_Time = string.Empty;
        #endregion

        #region Constructors

        public TreatmentPlan() 
        {
            
        }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_Id);
            sb.Append(_Human_Id);
            sb.Append(_Physician_Id);
            sb.Append(_Plan);            
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Addendum_plan);
            sb.Append(_Plan_Type);
            sb.Append(_Source_ID);
            sb.Append(_Plan_For_Plan);
            sb.Append(_Plan_Reference);
            sb.Append(_Followup_Plan_Snomed);
            sb.Append(_Corrections_to_be_made);
            sb.Append(_Amendment_Type);
            sb.Append(_Local_Time);
            return sb.ToString().GetHashCode();          
        }

        #endregion

        #region properties
      
        [DataMember]
        public virtual ulong Encounter_Id
        {
            get { return _Encounter_Id; }
            set { _Encounter_Id = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_Id; }
            set { _Human_Id = value; }
        }
        [DataMember]
        public virtual ulong Physician_Id
        {
            get { return _Physician_Id; }
            set { _Physician_Id = value; }
        }

        [DataMember]
        public virtual string Followup_Plan_Snomed
        {
            get { return _Followup_Plan_Snomed; }
            set { _Followup_Plan_Snomed = value; }
        }
        [DataMember]
        public virtual string Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
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
            get { return _Version; }
            set { _Version = value; }
        }

        [DataMember]
        public virtual string Addendum_Plan
        {
            get { return _Addendum_plan; }
            set { _Addendum_plan = value; }
        }

        [DataMember]
        public virtual string Plan_Type
        {
            get { return _Plan_Type; }
            set { _Plan_Type = value; }
        }
        [DataMember]
        public virtual ulong Source_ID
        {
            get { return _Source_ID; }
            set { _Source_ID = value; }
        }

        [DataMember]
        public virtual string Plan_For_Plan
        {
            get { return _Plan_For_Plan; }
            set { _Plan_For_Plan = value; }
        }

        [DataMember]
        public virtual string Plan_Reference
        {
            get { return _Plan_Reference; }
            set { _Plan_Reference = value; }
        }

        [DataMember]
        public virtual string Corrections_to_be_made
        {
            get { return _Corrections_to_be_made; }
            set { _Corrections_to_be_made = value; }
        }

        [DataMember]
        public virtual string Amendment_Type
        {
            get { return _Amendment_Type; }
            set { _Amendment_Type = value; }
        }

        [DataMember]
        public virtual string Local_Time
        {
            get { return _Local_Time; }
            set { _Local_Time = value; }
        }
        #endregion
    }
}
