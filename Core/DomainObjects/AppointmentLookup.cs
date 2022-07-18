using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class AppointmentLookup : BusinessBase<ulong>
    {
            #region Declarations

        private string _Facility_Name = string.Empty;  
        private ulong _Physician_ID = 0;
        private int _Sort_Order = 0;
        #endregion

        #region Constructors

        public AppointmentLookup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Facility_Name);
            sb.Append(_Physician_ID);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        #endregion
    }
}
