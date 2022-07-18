using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Response_Received_Log : BusinessBase<ulong>
    {

        #region Declarations
        private ulong _Response_Sent_Log_ID = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private ulong _Response_Received_Log_Group_ID = 0;
        #endregion
        #region Constructors

        public Response_Received_Log() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Response_Sent_Log_ID);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Response_Received_Log_Group_ID);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties

        public virtual ulong Response_Sent_Log_ID
        {
            get { return _Response_Sent_Log_ID; }
            set
            {
                _Response_Sent_Log_ID = value;
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
        public virtual ulong Response_Received_Log_Group_ID
        {
            get { return _Response_Received_Log_Group_ID; }
            set
            {
                _Response_Received_Log_Group_ID = value;
            }
        }

        #endregion
    }

}
