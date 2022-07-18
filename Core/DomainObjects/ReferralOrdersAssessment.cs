using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ReferralOrdersAssessment:BusinessBase<ulong>
    {
         #region Declarartions

        private ulong _Referral_Order_ID = 0;
        private ulong _Assessment_ID = 0;
        private string _ICD = string.Empty;
        private string _Assessment_Description = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        #endregion


        #region Constructors

        public ReferralOrdersAssessment() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Referral_Order_ID);
            sb.Append(_Assessment_ID);
            sb.Append(_ICD);
            sb.Append(_Assessment_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
              
        [DataMember]
        public virtual ulong Referral_Order_ID
        {
            get { return _Referral_Order_ID; }
            set { _Referral_Order_ID = value; }
        }
        [DataMember]
        public virtual ulong Assessment_ID
        {
            get { return _Assessment_ID; }
            set { _Assessment_ID = value; }
        }
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
        public virtual string Assessment_Description
        {
            get { return _Assessment_Description; }
            set { _Assessment_Description = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }


        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
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

        #endregion
    }
}
