using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
[DataContract]
    public class LabSettings:BusinessBase<int>
    {
        #region Declatation 
        private string _Lab_Practice_Application = string.Empty;
        private string _Lab_Practice_ID = string.Empty;
        private string _Lab_Facility_Application = string.Empty;
        private string _Receiving_Facility = string.Empty;
        private string _Lab_Client_Account_No = string.Empty;
        private string _Interface_Identifier = string.Empty;
        private ulong _Lab_ID=0;
        private string _Credential_Informantion = string.Empty;
        private string _User_Name = string.Empty;
        private string _Password = string.Empty;
        private string _URL = string.Empty;
        private string _Client_Information = string.Empty;
        private string _Result_URL = string.Empty;
        private string _Lab_Name = string.Empty;
        #endregion
        #region Constructors
        public LabSettings() { }
        #endregion
        #region Method
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Lab_Practice_Application);
            sb.Append(_Lab_Practice_ID);
            sb.Append(_Lab_Facility_Application);
            sb.Append(_Receiving_Facility);
            sb.Append(_Lab_Client_Account_No);
            sb.Append(_Interface_Identifier);
            sb.Append(_Lab_ID);
            sb.Append(_Credential_Informantion);
            sb.Append(_User_Name);
            sb.Append(_Password);
            sb.Append(_URL);
            sb.Append(_Client_Information);
            sb.Append(_Result_URL);
            sb.Append(_Lab_Name);
            return sb.ToString().GetHashCode();
        }

        #endregion
        #region Properties
        [DataMember]
        public virtual string Lab_Practice_Application
        {
            get { return _Lab_Practice_Application; }
            set
            {
                _Lab_Practice_Application = value;
            }
        }
        [DataMember]
        public virtual string Lab_Practice_ID
        {
            get { return _Lab_Practice_ID; }
            set
            {
                _Lab_Practice_ID = value;
            }
        }
        [DataMember]
        public virtual string Lab_Facility_Application
        {
            get { return _Lab_Facility_Application; }
            set
            {
                _Lab_Facility_Application = value;
            }
        }
        [DataMember]
        public virtual string Receiving_Facility
        {
            get { return _Receiving_Facility; }
            set
            {
                _Receiving_Facility = value;
            }
        }
        [DataMember]
        public virtual string Lab_Client_Account_No
        {
            get { return _Lab_Client_Account_No; }
            set
            {
                _Lab_Client_Account_No = value;
            }
        }
        [DataMember]
        public virtual string Interface_Identifier
        {
            get { return _Interface_Identifier; }
            set
            {
                _Interface_Identifier = value;
            }
        }
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set
            {
                _Lab_ID = value;
            }
        }
        [DataMember]
        public virtual string Credential_Informantion
        {
            get { return _Credential_Informantion; }
            set
            {
                _Credential_Informantion = value;
            }
        }
        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set
            {
                _User_Name = value;
            }
        }
        [DataMember]
        public virtual string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
            }
        }
        [DataMember]
        public virtual string URL
        {
            get { return _URL; }
            set
            {
                _URL = value;
            }
        }
        [DataMember]
        public virtual string Client_Information
        {
            get { return _Client_Information; }
            set
            {
                _Client_Information = value;
            }
        }
        [DataMember]
        public virtual string Result_URL
        {
            get { return _Result_URL; }
            set
            {
                _Result_URL = value;
            }
        }
        [DataMember]
        public virtual string Lab_Name
        {
            get { return _Lab_Name; }
            set
            {
                _Lab_Name = value;
            }
        }
        #endregion
    }
}
