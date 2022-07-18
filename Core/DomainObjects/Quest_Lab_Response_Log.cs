using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Quest_Lab_Response_Log : BusinessBase<int>
    {
        #region Declarations

      
        private ulong _Order_Submit_ID = 0;
        private string _Order_Response = String.Empty;
        private DateTime _Response_Received_Date_and_Time = DateTime.MinValue;     
        private int _version = 0;
        #endregion

        #region Constructors

        public Quest_Lab_Response_Log() { }

        #endregion


        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Order_Submit_ID);
            sb.Append(_Order_Response);
            sb.Append(_Response_Received_Date_and_Time);
            sb.Append(_version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

     
        [DataMember]
        public virtual ulong Order_Submit_ID
        {
            get { return _Order_Submit_ID; }
            set
            {
                _Order_Submit_ID = value;
            }
        }



        [DataMember]
        public virtual string Order_Response
        {
            get { return _Order_Response; }
            set
            {
                _Order_Response = value;
            }
        }
       
        [DataMember]
        public virtual System.DateTime Response_Received_Date_and_Time
        {
            get { return _Response_Received_Date_and_Time; }
            set
            {
                _Response_Received_Date_and_Time = value;
            }
        }
      

        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set
            {
                _version = value;
            }
        }     
        #endregion
    }
}