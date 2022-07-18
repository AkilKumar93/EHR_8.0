using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class LabLocation : BusinessBase<ulong>
    {
        #region Declarations
       
        private string _Location_Name=string.Empty ;
        private ulong _Lab_Id=0;
        private string _Street_Address1 = string.Empty;
        private string _Street_Address2 = string.Empty;
        private string _City = string.Empty;
        private string _State = string.Empty;
        private string _ZipCode = string.Empty;
        private string _Phone_No = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Lab_NPI = string.Empty;
        private string _Suit_Number = string.Empty;
        private string _E_Mail = string.Empty;
        private string _Fax_No = string.Empty;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Janani - Main - 30 Jul 2011 - End
        #endregion

        #region Constructors

        public LabLocation() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Location_Name);
            sb.Append(_Lab_Id);
            sb.Append(_Street_Address1);
            sb.Append(_Street_Address2);
            sb.Append(_City);
            sb.Append(_State);
            sb.Append(_ZipCode);
            sb.Append(_Phone_No);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Lab_NPI);
            sb.Append(_Suit_Number);
            sb.Append(_E_Mail);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            sb.Append(_Fax_No);            
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual string Location_Name
        {
            get { return _Location_Name; }
            set { _Location_Name = value; }
        }
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_Id; }
            set { _Lab_Id = value; }
        }
       

        [DataMember]
        public virtual string Street_Address1
        {
            get { return _Street_Address1; }
            set { _Street_Address1 = value; }

        }
        [DataMember]
        public virtual string Street_Address2
        {
            get { return _Street_Address2; }
            set { _Street_Address2 = value; }

        }
        [DataMember]
        public virtual string City
        {
            get { return _City; }
            set { _City = value; }

        }
        [DataMember]
        public virtual string State
        {
            get { return _State; }
            set { _State = value; }

        }
        [DataMember]
        public virtual string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }

        }
        [DataMember]
        public virtual string Phone_No
        {
            get { return _Phone_No; }
            set { _Phone_No = value; }

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
        public virtual string Lab_NPI
        {
            get { return _Lab_NPI; }
            set { _Lab_NPI = value; }
        }

        [DataMember]
        public virtual string Suit_Number
        {
            get { return _Suit_Number; }
            set { _Suit_Number = value; }
        }

        [DataMember]
        public virtual string E_Mail
        {
            get { return _E_Mail; }
            set { _E_Mail = value; }
        }
        //Janani - Main - 30 Jul 2011 - Start
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //Janani - Main - 30 Jul 2011 - End        
        [DataMember]
        public virtual string Fax_No
        {
            get { return _Fax_No; }
            set { _Fax_No = value; }
        }        
        #endregion
    }
}
