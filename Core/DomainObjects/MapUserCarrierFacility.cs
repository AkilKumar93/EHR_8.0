using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class MapUserCarrierFacility : BusinessBase<ulong>
    {
        
        #region Declarations

        private ulong _Map_User_Carrier_Facility_ID=0;
        private string _User_Name=string.Empty;
        private ulong _Carrier_ID=0;
        private string _Facility_Name=string.Empty;
        
        #endregion

        #region Constructors

        public MapUserCarrierFacility() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Map_User_Carrier_Facility_ID);
            sb.Append(_User_Name);
            sb.Append(_Carrier_ID);
            sb.Append(_Facility_Name);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Map_User_Carrier_Facility_ID
        {
            get { return _Map_User_Carrier_Facility_ID; }
            set { _Map_User_Carrier_Facility_ID = value; }
        }
        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }

        }
        [DataMember]
        public virtual ulong Carrier_ID
        {
            get { return _Carrier_ID; }
            set { _Carrier_ID = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        #endregion
    }
}
