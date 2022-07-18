using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class PhysicianPatient : BusinessBase<ulong>
    {
         #region Declarations

        private string _Physician_Name = string.Empty;
        private ulong _Human_ID = 0;
        private ulong _physician_patient_master_ID = 0;
        private string _Relationship = string.Empty;
        private string _Phone_No = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _version =0;
        private ulong _Encounter_Id = 0;
        #endregion

        #region Constructors

        public PhysicianPatient() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Physician_Name);
            sb.Append(_Human_ID);
            sb.Append(_Relationship);
            sb.Append(_Phone_No);
            sb.Append(_physician_patient_master_ID);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Encounter_Id);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        
        public virtual string Physician_Name
        {
            get { return _Physician_Name; }
            set { _Physician_Name = value; }
        }
        
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        public virtual ulong Physician_Patient_Master_ID
        {
            get { return _physician_patient_master_ID; }
            set { _physician_patient_master_ID = value; }
        }
        
        public virtual string Relationship
        {
            get { return _Relationship; }
            set { _Relationship = value; }
        }
        
        public virtual string Phone_No
        {
            get { return _Phone_No; }
            set { _Phone_No = value; }

        }
        //
        //public virtual ulong Advance_Directive_ID
        //{
        //    get { return _Advance_Directive_ID; }
        //    set { _Advance_Directive_ID = value; }
        //}
        
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
        
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        
        public virtual ulong Encounter_Id
        {
            get { return _Encounter_Id; }
            set { _Encounter_Id = value; }
        }
        #endregion
    }
}
