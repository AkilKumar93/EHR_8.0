using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Context : BusinessBase<ulong>
    {

        #region Declarations
        private string _Context_Name = string.Empty;
        private string _Context_Company_Name = string.Empty;
        private string _Context_Phone_Number = string.Empty;
        private string _Context_Fax_Number = string.Empty;
        private string _Context_Email = string.Empty;


        #endregion
        #region Constructors

        public Context() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Context_Name);
            sb.Append(_Context_Company_Name);
            sb.Append(_Context_Phone_Number);
            sb.Append(_Context_Fax_Number);
            sb.Append(_Context_Email);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties

        public virtual string Context_Name
        {
            get { return _Context_Name; }
            set
            {
                _Context_Name = value;
            }
        }
        public virtual string Context_Company_Name
        {
            get { return _Context_Company_Name; }
            set
            {
                _Context_Company_Name = value;
            }
        }
        public virtual string Context_Phone_Number
        {
            get { return _Context_Phone_Number; }
            set
            {
                _Context_Phone_Number = value;
            }
        }
        public virtual string Context_Fax_Number
        {
            get { return _Context_Fax_Number; }
            set
            {
                _Context_Fax_Number = value;
            }
        }
        public virtual string Context_Email
        {
            get { return _Context_Email; }
            set
            {
                _Context_Email = value;
            }
        }
        #endregion
    }
}
