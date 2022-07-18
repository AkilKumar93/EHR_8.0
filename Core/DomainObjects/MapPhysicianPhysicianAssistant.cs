using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class MapPhysicianPhysicianAssistant : BusinessBase<int>
    {
        
        #region Declarations

        private int _Map_Physician_Phy_Assistant_ID=0;
        private int _Physician_ID=0;
        private int _Physician_Asst_ID=0;
        private string _Status=string.Empty;
        private int _Default_Physician = 0;
        #endregion

        #region Constructors

        public MapPhysicianPhysicianAssistant() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Map_Physician_Phy_Assistant_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Physician_Asst_ID);
            sb.Append(_Status);
            sb.Append(_Default_Physician);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual int Map_Physician_Phy_Assistant_ID
        {
            get { return _Map_Physician_Phy_Assistant_ID; }
            set { _Map_Physician_Phy_Assistant_ID = value; }
        }
        [DataMember]
        public virtual int Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }

        }
        [DataMember]
        public virtual int Physician_Asst_ID
        {
            get { return _Physician_Asst_ID; }
            set { _Physician_Asst_ID = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [DataMember]
        public virtual int Default_Physician
        {
            get { return _Default_Physician; }
            set { _Default_Physician = value; }
        }
        #endregion
    }
}
