using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class UserSession : BusinessBase<string>
    {

        #region Declarations

        private string _User_Name = string.Empty;
        private DateTime _Last_Logged_Time=DateTime.MinValue;
        private string _MacAddress = string.Empty;
        private int _Version=0;
        private string _Current_Session_ID = string.Empty;

        #endregion

        #region Constructors

        public UserSession() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_User_Name);
            sb.Append(_Last_Logged_Time);
            sb.Append(_MacAddress);
            sb.Append(_Version);
            sb.Append(_Current_Session_ID);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        [DataMember]
        public virtual string MacAddress
        {
            get { return _MacAddress; }
            set { _MacAddress = value; }
        }

        [DataMember]
        public virtual DateTime Last_Logged_Time
        {
            get { return _Last_Logged_Time; }
            set { _Last_Logged_Time = value; }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [DataMember]
        public virtual string Current_Session_ID
        {
            get { return _Current_Session_ID; }
            set { _Current_Session_ID = value; }
        }

        #endregion



    }
}
