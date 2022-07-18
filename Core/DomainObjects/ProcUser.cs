using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ProcUser : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Proc_User_ID=0;
        private string _Process_Name=string.Empty;
        private string _User_Name=string.Empty;
        private string _Status=string.Empty;
        private string _Created_By=string.Empty;
        private DateTime _Created_Date_And_Time=DateTime.MinValue;
        private string _Modified_By=string.Empty;
        private DateTime _Modified_Date_And_Time=DateTime.MinValue;
        private int _Version=0;
       
        #endregion

        #region Constructors

        public ProcUser() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Proc_User_ID);
            sb.Append(_Process_Name);
            sb.Append(_User_Name);
            sb.Append(_Status);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
           
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region properties

        [DataMember]
        public virtual string Process_Name
        {
            get { return _Process_Name; }
            set { _Process_Name = value; }
        }
        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
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
        #endregion
    }
}