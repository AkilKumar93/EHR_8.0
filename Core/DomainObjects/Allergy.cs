using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Allergy : BusinessBase<ulong>
    {

        #region Parameter Variable Decleration

        private ulong _Allergy_ID=0;
        private ulong _Human_ID=0;
        private string _Allergy_Info=string.Empty;
        private string _From_Date = string.Empty;
        private string _To_Date = string.Empty;
        private string _Allergy_Notes = string.Empty;
        private string _Status = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;

        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Allergy_ID);
            sb.Append(_Human_ID);
            sb.Append(_Allergy_Info);
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_Allergy_Notes);
            sb.Append(_Status);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation
        [DataMember]
        public virtual ulong Allergy_ID
        {
            get { return _Allergy_ID; }
            set { _Allergy_ID = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Allergy_Info
        {
            get { return _Allergy_Info; }
            set { _Allergy_Info = value; }
        }
        [DataMember]
        public virtual string From_Date
        {
            get { return _From_Date; }
            set { _From_Date = value; }
        }
        [DataMember]
        public virtual string To_Date
        {
            get { return _To_Date; }
            set { _To_Date = value; }
        }
        [DataMember]
        public virtual string Allergy_Notes
        {
            get { return _Allergy_Notes; }
            set { _Allergy_Notes = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
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
        #endregion


    }
}
