using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ScnTab : BusinessBase<int>
    {

        #region Declarations


        private string _SCN_Name = string.Empty;
        private int _Parent_SCN_ID=0;
        private int _SCN_ID=0;
        private string _Permission = string.Empty;
        private string _Assigned_Physician_Editable = string.Empty;
        private string _Is_UBAC_Or_PBAC = string.Empty;

        #endregion

        #region Constructors

        public ScnTab() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_SCN_Name);
            sb.Append(_Parent_SCN_ID);
            sb.Append(_SCN_ID);
            sb.Append(_Permission);
            sb.Append(_Assigned_Physician_Editable);
            sb.Append(_Is_UBAC_Or_PBAC);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual int Parent_SCN_ID
        {
            get { return _Parent_SCN_ID; }
            set { _Parent_SCN_ID = value; }
        }

        [DataMember]
        public virtual string SCN_Name
        {
            get { return _SCN_Name; }
            set { _SCN_Name = value; }
        }

        [DataMember]
        public virtual int SCN_ID
        {
            get { return _SCN_ID; }
            set { _SCN_ID = value; }
        }

        [DataMember]
        public virtual string Permission
        {
            get { return _Permission; }
            set { _Permission = value; }
        }

        [DataMember]
        public virtual string Assigned_Physician_Editable
        {
            get { return _Assigned_Physician_Editable; }
            set { _Assigned_Physician_Editable = value; }
        }
        [DataMember]
        public virtual string Is_UBAC_Or_PBAC
        {
            get { return _Is_UBAC_Or_PBAC; }
            set { _Is_UBAC_Or_PBAC = value; }
        }
        #endregion



    }
}
