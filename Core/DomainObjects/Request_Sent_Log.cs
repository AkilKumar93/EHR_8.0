using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Request_Sent_Log : BusinessBase<ulong>
    {

        #region Declarations
        private ulong _Source_ID = 0;
        private string _Source = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private ulong _Request_Sent_Log_Group_ID = 0;
        #endregion
        #region Constructors

        public Request_Sent_Log() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Source_ID);
            sb.Append(_Source);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Request_Sent_Log_Group_ID);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties

        public virtual ulong Source_ID
        {
            get { return _Source_ID; }
            set
            {
                _Source_ID = value;
            }
        }

        public virtual string Source
        {
            get { return _Source; }
            set
            {
                _Source = value;
            }
        }

        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }

        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        public virtual ulong Request_Sent_Log_Group_ID
        {
            get { return _Request_Sent_Log_Group_ID; }
            set
            {
                _Request_Sent_Log_Group_ID = value;
            }
        }

        #endregion
    }

}