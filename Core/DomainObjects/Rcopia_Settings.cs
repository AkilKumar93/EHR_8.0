using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{

    [DataContract]
    public class Rcopia_Settings : BusinessBase<ulong>
    {

        #region Declarations

        private string _Request_Message_ID = string.Empty;
        private string _Vendor_Name = string.Empty;
        private string _Vendor_Password = string.Empty;
        private string _Application = string.Empty;
        private string _Rcopia_Version = string.Empty;
        private string _Practice_Name = string.Empty;
        private string _Station = string.Empty;
        private string _System_Name = string.Empty;
        private string _Rcopia_Practice_User_name = string.Empty;
        private string _Synchronous = string.Empty;
        private string _Check_Eligibilityt = string.Empty;
        private string _Command = string.Empty;
        private string _Legal_Org = string.Empty;

        #endregion

        #region Constructors

        public Rcopia_Settings() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Request_Message_ID);
            sb.Append(_Vendor_Name);
            sb.Append(_Vendor_Password);
            sb.Append(_Application);
            sb.Append(_Rcopia_Version);
            sb.Append(_Practice_Name);
            sb.Append(_Station);
            sb.Append(_System_Name);
            sb.Append(_Rcopia_Practice_User_name);
            sb.Append(_Synchronous);
            sb.Append(_Check_Eligibilityt);
            sb.Append(_Command);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Request_Message_ID
        {
            get { return _Request_Message_ID; }
            set
            {
                _Request_Message_ID = value;
            }
        }
        [DataMember]
        public virtual string Vendor_Name
        {
            get { return _Vendor_Name; }
            set
            {
                _Vendor_Name = value;
            }
        }
        [DataMember]
        public virtual string Vendor_Password
        {
            get { return _Vendor_Password; }
            set
            {
                _Vendor_Password = value;
            }

        }
        [DataMember]
        public virtual string Application
        {
            get { return _Application; }
            set
            {
                _Application = value;
            }
        }
        [DataMember]
        public virtual string Rcopia_Version
        {
            get { return _Rcopia_Version; }
            set
            {
                _Rcopia_Version = value;
            }
        }
        [DataMember]
        public virtual string Practice_Name
        {
            get { return _Practice_Name; }
            set
            {
                _Practice_Name = value;
            }
        }
        [DataMember]
        public virtual string Station
        {
            get { return _Station; }
            set
            {
                _Station = value;
            }
        }
        [DataMember]
        public virtual string System_Name
        {
            get { return _System_Name; }
            set
            {
                _System_Name = value;
            }
        }
        [DataMember]
        public virtual string Rcopia_Practice_User_name
        {
            get { return _Rcopia_Practice_User_name; }
            set
            {
                _Rcopia_Practice_User_name = value;
            }
        }
        [DataMember]
        public virtual string Synchronous
        {
            get { return _Synchronous; }
            set
            {
                _Synchronous = value;
            }
        }
        [DataMember]
        public virtual string Check_Eligibilityt
        {
            get { return _Check_Eligibilityt; }
            set
            {
                _Check_Eligibilityt = value;
            }
        }
        [DataMember]
        public virtual string Command
        {
            get { return _Command; }
            set
            {
                _Command = value;
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
