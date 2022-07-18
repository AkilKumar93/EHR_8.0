using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]

    public partial class SelectPayerDTO
    {
        #region Declarations

        private int _InsuranceCount=0;
        private ulong _Insurance_Plan_ID=0;
        private string _Carrier_Name = string.Empty;
        private string _Ins_Plan_Name = string.Empty;
        private string _Payer_Addrress1 = string.Empty;
        private string _Payer_City = string.Empty;
        private string _Payer_State = string.Empty;
        private string _Payer_Zip = string.Empty;
        private string _Financial_Class_ID = string.Empty;
        private string _Payer_Ph_No = string.Empty;
        private ulong _Carrier_ID = 0;
        #endregion


        #region Constructor

        public SelectPayerDTO() { }

        #endregion


        #region Properties

        [DataMember]
        public virtual int InsuranceCount
        {
            get { return _InsuranceCount; }
            set { _InsuranceCount = value; }
        }

        [DataMember]
        public virtual ulong Insurance_Plan_ID
        {
            get { return _Insurance_Plan_ID; }
            set { _Insurance_Plan_ID = value; }
        }
        [DataMember]
        public virtual string Carrier_Name
        {
            get { return _Carrier_Name; }
            set { _Carrier_Name = value; }
        }
        [DataMember]
        public virtual string Ins_Plan_Name
        {
            get { return _Ins_Plan_Name; }
            set { _Ins_Plan_Name = value; }
        }
        [DataMember]
        public virtual string Payer_Addrress1
        {
            get { return _Payer_Addrress1; }
            set { _Payer_Addrress1 = value; }
        }
        [DataMember]
        public virtual string Payer_City
        {
            get { return _Payer_City; }
            set
            {
                _Payer_City = value;
            }
        }
        [DataMember]
        public virtual string Payer_State
        {
            get { return _Payer_State; }
            set
            {
                _Payer_State = value;
            }
        }
        [DataMember]
        public virtual string Payer_Zip
        {
            get { return _Payer_Zip; }
            set
            {
                _Payer_Zip = value;
            }
        }
        [DataMember]
        public virtual string Financial_Class_ID
        {
            get { return _Financial_Class_ID; }
            set
            {
                _Financial_Class_ID = value;
            }
        }
        [DataMember]
        public virtual string Payer_Ph_No
        {
            get { return _Payer_Ph_No; }
            set
            {
                _Payer_Ph_No = value;
            }
        }
        [DataMember]
        public virtual ulong Carrier_ID 
        {
            get { return _Carrier_ID; }
            set { _Carrier_ID = value; }
        }
        #endregion

    }
}
