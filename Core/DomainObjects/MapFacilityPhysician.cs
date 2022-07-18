using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class MapFacilityPhysician : BusinessBase<ulong>
    {
        
        #region Declarations

        private ulong _Map_ID=0;
        private string _Facility_Name=string.Empty;
        private ulong _Phy_Rec_ID=0;
        private string _Scheduler_Color=string.Empty;
        private int _version=0;
        private string _Status=string.Empty;
        private ulong _Sort_Order = 0;
        private string _Is_Active = string.Empty;
        private string _Machine_Technician_ID = string.Empty;
        private string _Legal_Org = string.Empty;
        
        #endregion

        #region Constructors

        public MapFacilityPhysician() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Map_ID);
            sb.Append(_Facility_Name);
            sb.Append(_Phy_Rec_ID);
            sb.Append(_Scheduler_Color);
            sb.Append(_version);
            sb.Append(_Status);
            sb.Append(_Sort_Order);
            sb.Append(_Is_Active);
            sb.Append(_Machine_Technician_ID);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Map_ID
        {
            get { return _Map_ID; }
            set { _Map_ID = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }

        }
        [DataMember]
        public virtual ulong Phy_Rec_ID
        {
            get { return _Phy_Rec_ID; }
            set { _Phy_Rec_ID = value; }
        }
        [DataMember]
        public virtual string Scheduler_Color
        {
            get { return _Scheduler_Color; }
            set { _Scheduler_Color = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        

        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        [DataMember]
        public virtual ulong Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }

        [DataMember]
        public virtual string Machine_Technician_ID
        {
            get { return _Machine_Technician_ID; }
            set { _Machine_Technician_ID = value; }
        }
        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set { _Legal_Org = value; }
        }
        #endregion
    }
}
