using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class SurgicalHistory : BusinessBase<ulong>
    {
        #region Parameter Variable Decleration
        private ulong _Surgical_History_Master_ID = 0;
        private ulong _Human_ID = 0;
        private string _Surgery_Name = string.Empty;
        private string _Date_Of_Surgery = string.Empty;
        private string _Description = string.Empty;
        private string _Is_Present = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _version = 0;
        private ulong _Encounter_Id = 0;
        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Surgery_Name);
            sb.Append(_Date_Of_Surgery);
            sb.Append(_Surgical_History_Master_ID);
            sb.Append(_Description);
            sb.Append(_Is_Present);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Encounter_Id);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation

        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public virtual ulong Surgical_History_Master_ID
        {
            get { return _Surgical_History_Master_ID; }
            set { _Surgical_History_Master_ID = value; }
        }
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        public virtual string Surgery_Name
        {
            get { return _Surgery_Name; }
            set { _Surgery_Name = value; }
        }
        public virtual string Date_Of_Surgery
        {
            get { return _Date_Of_Surgery; }
            set { _Date_Of_Surgery = value; }
        }

        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public virtual string Is_Present
        {
            get { return _Is_Present; }
            set { _Is_Present = value; }
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
        public virtual ulong Encounter_Id
        {
            get { return _Encounter_Id; }
            set { _Encounter_Id = value; }
        }

        #endregion
    }
}
