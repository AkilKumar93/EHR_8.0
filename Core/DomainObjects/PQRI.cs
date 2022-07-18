using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PQRI : BusinessBase<int>
    {
        #region Decleration

        private int _PQRI_ID = 0;
        private int _Human_ID = 0;
        private int _Encounter_ID = 0;
        private int _Physician_ID = 0;
        private string _PQRI_Name = string.Empty;
        private string _PQRI_Value = string.Empty;
        private string _Additional_Measure_Name = string.Empty;
        private string _Additional_Measure_Value = string.Empty;
        private string _Options = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty; 
        private DateTime  _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Is_Done = string.Empty;
        private int _iVersion=0;
       
        
        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_PQRI_ID);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Physician_ID);
            sb.Append(_PQRI_Name);
            sb.Append(_PQRI_Value);
            sb.Append(_Additional_Measure_Name);
            sb.Append(_Additional_Measure_Value);
            sb.Append(_Options);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_iVersion);
            sb.Append(_Is_Done);
            
            return sb.ToString().GetHashCode();
        }

        #endregion
        #region Implementation
        [DataMember]
        public virtual int PQRI_ID
        {
            get { return _PQRI_ID; }
            set { _PQRI_ID = value; }
        }

        [DataMember]
        public virtual int Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual int  Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual int  Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual string PQRI_Name
        {
            get { return _PQRI_Name; }
            set { _PQRI_Name = value; }
        }
        [DataMember]
        public virtual string PQRI_Value
        {
            get { return _PQRI_Value; }
            set { _PQRI_Value = value; }
        }
        [DataMember]
        public virtual string Additional_Measure_Name
        {
            get { return _Additional_Measure_Name; }
            set { _Additional_Measure_Name = value; }
        }
        [DataMember]
        public virtual string Additional_Measure_Value
        {
            get { return _Additional_Measure_Value; }
            set { _Additional_Measure_Value = value; }
        }
        [DataMember]
        public virtual string Options
        {
            get { return _Options; }
            set { _Options = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime  Created_Date_And_Time
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
            get { return _iVersion; }
            set { _iVersion = value; }
        }
        [DataMember]
        public virtual string Is_Done
        {
            get { return _Is_Done; }
            set { _Is_Done = value; }
        }
       
       #endregion
    }
}
