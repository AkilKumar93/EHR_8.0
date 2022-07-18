using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class UserScnTab : BusinessBase<int>
    {

        #region Declarations


        private int  _SCN_ID=0;
        private string _User_Name = string.Empty;
        private string _Permission = string.Empty;

        #endregion

        #region Constructors

        public UserScnTab() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_SCN_ID);
            sb.Append(_User_Name);
            sb.Append(_Permission);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual int SCN_ID
        {
            get { return _SCN_ID; }
            set { _SCN_ID = value; }
        }
        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        [DataMember]
        public virtual string Permission
        {
            get { return _Permission; }
            set { _Permission = value; }
        }
        #endregion



    }
}
