using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class EandMCodingICD : BusinessBase<ulong>
    {

        #region Declarations

        //private ulong _E_M_Coding_ID = 0;
        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        private string _ICD = string.Empty;
        private string _ICD_Description = string.Empty;
        private string _ICD_Category = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Source = string.Empty;
        private ulong _Source_ID = 0;
        private string _ICD_Type = string.Empty;
        private string _Is_Delete = string.Empty;
        private string _Sequence = string.Empty;
        #endregion

        #region HashCode override method Value

        public override int GetHashCode()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            //sb.Append(_E_M_Coding_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_ICD);
            sb.Append(_ICD_Description);
            sb.Append(_ICD_Category);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Source);
            sb.Append(_Source_ID);
            sb.Append(_ICD_Type);
            sb.Append(_Is_Delete);
            sb.Append(_Sequence);
            return sb.ToString().GetHashCode();
        }

        #endregion

        # region getset properties

        //[DataMember]
        //public virtual ulong E_M_Coding_ID
        //{
        //    get { return _E_M_Coding_ID; }
        //    set { _E_M_Coding_ID = value; }
        //}
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
        public virtual string ICD
        {
            get { return _ICD; }
            set { _ICD = value; }
        }
        [DataMember]
        public virtual string ICD_Description
        {
            get { return _ICD_Description; }
            set { _ICD_Description = value; }
        }
        [DataMember]
        public virtual string ICD_Category
        {
            get { return _ICD_Category; }
            set { _ICD_Category = value; }
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
            set
            {
                _Version = value;
            }
        }
        [DataMember]
        public virtual string Source
        {
            get { return _Source; }
            set
            {
                _Source = value;
            }
        }
        [DataMember]
        public virtual ulong Source_ID
        {
            get { return _Source_ID; }
            set
            {
                _Source_ID = value;
            }
        }
        [DataMember]
        public virtual string ICD_Type
        {
            get { return _ICD_Type; }
            set { _ICD_Type = value; }
        }
        [DataMember]
        public virtual string Is_Delete
        {
            get { return _Is_Delete; }
            set { _Is_Delete = value; }
        }
        [DataMember]
        public virtual string Sequence
        {
            get { return _Sequence; }
            set { _Sequence = value; }
        }
        #endregion
    }
}
