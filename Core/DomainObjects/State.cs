using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class State : BusinessBase<ulong>
    {
        #region Declarations

        private string _statename = string.Empty;
        private string _statecode = string.Empty;
        private string _County = string.Empty;
        private string _County_Codes = string.Empty;
        private string _City = string.Empty;
        private string _State_Concept_Code = string.Empty;

        #endregion

        #region Constructors

        public State() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_statename);
            sb.Append(_statecode);
            sb.Append(_County);
            sb.Append(_County_Codes);
            sb.Append(_City);
            sb.Append(_State_Concept_Code);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual string State_Name
        {
            get { return _statename; }
            set
            {
                _statename = value;
            }
        }
        [DataMember]
        public virtual string State_Code
        {
            get { return _statecode; }
            set
            {
                _statecode = value;
            }
        }
        [DataMember]
        public virtual string County
        {
            get { return _County; }
            set
            {
                _County = value;
            }
        }
        [DataMember]
        public virtual string County_Codes
        {
            get { return _County_Codes; }
            set
            {
                _County_Codes = value;
            }
        }
        [DataMember]
        public virtual string City
        {
            get { return _City; }
            set
            {
                _City = value;
            }
        }
        [DataMember]
        public virtual string State_Concept_Code
        {
            get { return _State_Concept_Code; }
            set
            {
                _State_Concept_Code = value;
            }
        }

        #endregion  
    }
}
