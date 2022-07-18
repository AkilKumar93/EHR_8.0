using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ProviderReviewTracker : BusinessBase<ulong>
    {
        #region Declarations
        private string _user_name = String.Empty;
        private ulong _provider_review_rule_master_id = 0;
        private ulong _human_id = 0;
        private ulong _encounter_id = 0;
        private string _createdby = String.Empty;
        private System.DateTime _createddatetime = DateTime.MinValue;
        private string _modifiedby = String.Empty;
        private System.DateTime _modifieddatetime = DateTime.MinValue;
        private string _status = String.Empty;
        #endregion

        #region Constructors

        public ProviderReviewTracker() { }

        #endregion


        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_user_name);
            sb.Append(_provider_review_rule_master_id);
            sb.Append(_human_id);
            sb.Append(_encounter_id);
            sb.Append(_createdby);
            sb.Append(_createddatetime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddatetime);
            sb.Append(_status);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string User_Name
        {
            get { return _user_name; }
            set
            {
                _user_name = value;
            }
        }
        [DataMember]
        public virtual ulong Provider_Review_Rule_Master_Id
        {
            get { return _provider_review_rule_master_id; }
            set
            {
                _provider_review_rule_master_id = value;
            }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _human_id; }
            set
            {
                _human_id = value;
            }
        }
        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _encounter_id; }
            set
            {
                _encounter_id = value;
            }
        }


        [DataMember]
        public virtual string Created_By
        {
            get { return _createdby; }
            set
            {
                _createdby = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set
            {
                _modifiedby = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Created_Date_And_Time
        {
            get { return _createddatetime; }
            set
            {
                _createddatetime = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Modified_Date_And_Time
        {
            get { return _modifieddatetime; }
            set
            {
                _modifieddatetime = value;
            }
        }

        [DataMember]
        public virtual string Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }
       
        #endregion
    }
}
