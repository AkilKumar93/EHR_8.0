using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Carrier : BusinessBase<ulong>
    {
        #region Declarations

        private string _CarrierName=string.Empty;
        private string _CarrierCode = string.Empty;
        private string _NAIC_ID = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time=DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private ulong _Carrier_Reference_ID=0;
        private string _Is_Externel_Phy_ID_Provided = string.Empty;
        private string _Is_Phy_Service_Type_Req = string.Empty;
        private int _sort_order = 0;        
        private string _Claim_Receiver_Name = string.Empty;        
        private string _Claim_Receiver_ID = string.Empty;
        private string _Claim_Settings = string.Empty;
        private string _Is_Active = string.Empty;
        #endregion

        #region Constructors

        public Carrier() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_CarrierName);
            sb.Append(_NAIC_ID);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Carrier_Reference_ID);
            sb.Append(_Is_Externel_Phy_ID_Provided);
            sb.Append(_Is_Phy_Service_Type_Req);
            sb.Append(_sort_order);           
            sb.Append(_Claim_Receiver_Name);
            sb.Append(_Claim_Receiver_ID);
            sb.Append(_Claim_Settings);
            sb.Append(_Is_Active);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual string Carrier_Name
        {
            get { return _CarrierName; }
            set { _CarrierName = value; }
        }
        [DataMember]
        public virtual string Carrier_Code
        {
            get { return _CarrierCode; }
            set { _CarrierCode = value; }
        }
        [DataMember]
        public virtual string NAIC_ID
        {
            get { return _NAIC_ID; }
            set { _NAIC_ID = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual ulong Carrier_Reference_ID
        {
            get { return _Carrier_Reference_ID; }
            set { _Carrier_Reference_ID = value; }
        }
        [DataMember]
        public virtual string Is_Externel_Phy_ID_Provided
        {
            get { return _Is_Externel_Phy_ID_Provided; }
            set { _Is_Externel_Phy_ID_Provided = value; }
        }
        [DataMember]
        public virtual string Is_Phy_Service_Type_Req
        {
            get { return _Is_Phy_Service_Type_Req; }
            set { _Is_Phy_Service_Type_Req = value; }
        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _sort_order; }
            set { _sort_order = value; }
        }
       
        [DataMember]
        public virtual string Claim_Receiver_Name
        {
            get { return _Claim_Receiver_Name; }
            set { _Claim_Receiver_Name = value; }
        }
       
        [DataMember]
        public virtual string Claim_Receiver_ID
        {
            get { return _Claim_Receiver_ID; }
            set { _Claim_Receiver_ID = value; }
        }
        [DataMember]
        public virtual string Claim_Settings
        {
            get { return _Claim_Settings; }
            set { _Claim_Settings = value; }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }
        #endregion
    }
}
