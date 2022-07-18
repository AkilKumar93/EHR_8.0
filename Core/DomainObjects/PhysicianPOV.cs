using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
   public partial class PhysicianPOV:BusinessBase<ulong>
    {
        #region Declarations
       private ulong _Phy_ID=0 ;
       private string _Purpose_of_Visit = string.Empty;
       private int _Duration =0;
       private int _version=0;
       private int _SortOrder=0;
       private string _DefaultValue=string.Empty;
       private string _visitDescription = string.Empty;
       private string _Block_Category = string.Empty;
       private string _Is_Active = string.Empty;
       private string _Legal_Org = string.Empty;
        #endregion

        #region Constructors

        public PhysicianPOV() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Phy_ID);
            sb.Append(_Purpose_of_Visit);
            sb.Append(_Duration);
            sb.Append(_version);
            sb.Append(_SortOrder);
            sb.Append(_DefaultValue);
            sb.Append(_visitDescription);
            sb.Append(_Block_Category);
            sb.Append(_Is_Active);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Phy_ID
        {
            get { return _Phy_ID; }
            set
            {
                _Phy_ID = value;
            }
        }
        [DataMember]
        public virtual string Purpose_of_Visit
        {
            get { return _Purpose_of_Visit; }
            set
            {
                _Purpose_of_Visit = value;
            }
        }
        [DataMember]
        public virtual int Duration
        {
            get { return _Duration; }
            set
            {
                _Duration = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set
            {
                _version = value;
            }
        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _SortOrder; }
            set
            {
                _SortOrder = value;
            }
        }

        [DataMember]
        public virtual string Default_Value
        {
            get { return _DefaultValue; }
            set
            {
                _DefaultValue = value;
            }
        }
        [DataMember]
        public virtual string Description
        {
            get { return _visitDescription; }
            set
            {
                _visitDescription = value;
            }
        }
        [DataMember]
        public virtual string Block_Category
        {
            get { return _Block_Category; }
            set
            {
                _Block_Category = value;
            }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set
            {
                _Is_Active = value;
            }
        }
        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set
            {
                _Legal_Org = value;
            }
        }
        #endregion
    }
}
