using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ProviderReviewRuleMaster : BusinessBase<ulong>
    {
        #region Declarations
        private string _facility_name = String.Empty;
        private string _phy_asst_user_name = String.Empty;
        private string _provider_user_name = String.Empty;
        private string _rule_name = String.Empty;
        private string _rule = String.Empty;
        private string _rule_percentage = String.Empty;
        private string _regulatory_percentage = String.Empty;
        private string _is_inclusive = String.Empty;
        private int _priority = 0;
        #endregion

        #region Constructors

        public ProviderReviewRuleMaster() { }

        #endregion


        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_facility_name);
            sb.Append(_phy_asst_user_name);
            sb.Append(_provider_user_name);
            sb.Append(_rule_name);
            sb.Append(_rule);
            sb.Append(_rule_percentage);
            sb.Append(_regulatory_percentage);
            sb.Append(_is_inclusive);
            sb.Append(_priority);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _facility_name; }
            set
            {
                _facility_name = value;
            }
        }
        [DataMember]
        public virtual string Phy_Asst_User_Name
        {
            get { return _phy_asst_user_name; }
            set
            {
                _phy_asst_user_name = value;
            }
        }
        [DataMember]
        public virtual string Provider_User_Name
        {
            get { return _provider_user_name; }
            set
            {
                _provider_user_name = value;
            }
        }
        [DataMember]
        public virtual string Rule_Name
        {
            get { return _rule_name; }
            set
            {
                _rule_name = value;
            }
        }
        [DataMember]
        public virtual string Rule
        {
            get { return _rule; }
            set
            {
                _rule = value;
            }
        }
        [DataMember]
        public virtual string Rule_Percentage
        {
            get { return _rule_percentage; }
            set
            {
                _rule_percentage = value;
            }
        }
        [DataMember]
        public virtual string Regulatory_Percentage
        {
            get { return _regulatory_percentage; }
            set
            {
                _regulatory_percentage = value;
            }
        }
        [DataMember]
        public virtual string Is_Inclusive
        {
            get { return _is_inclusive; }
            set
            {
                _is_inclusive = value;
            }
        }
        [DataMember]
        public virtual int Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
            }
        }

        #endregion
    }
}
