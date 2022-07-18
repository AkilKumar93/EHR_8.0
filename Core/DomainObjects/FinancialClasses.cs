using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class FinancialClasses : BusinessBase<ulong>
    {
        #region Declarations

        private string _Financial_Class_Name = string.Empty;

        #endregion

        #region Constructors

        public FinancialClasses() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Financial_Class_Name);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual string Financial_Class_Name
        {
            get { return _Financial_Class_Name; }
            set
            {
                _Financial_Class_Name = value;
            }
        }

        #endregion

    }
}
