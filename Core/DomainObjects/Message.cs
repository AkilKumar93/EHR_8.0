using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Message : BusinessBase<ulong>
    {
        #region Declarations

        private int _Human_ID = 0;
        private int _Charge_PP_Line_ID = 0;
        private string _Message_Type = string.Empty;
        private string _Message_Text = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private DateTime _Message_Date = DateTime.MinValue;
        private int _Statement_ChargeLine_ID=0;
        private int _Appointment_ID = 0;
        private int _Version = 0;
        private int _Denial_id = 0;
        private ulong _Source_ID = 0; //prabu

        #endregion

          #region Constructors

        public Message() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Charge_PP_Line_ID);
            sb.Append(_Message_Type);
            sb.Append(_Message_Text);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Appointment_ID);
            sb.Append(_Version);
            sb.Append(_Message_Date);
            sb.Append(_Statement_ChargeLine_ID);
            sb.Append(_Source_ID);
            sb.Append(_Denial_id);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual int Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual int Charge_PP_Line_ID
        {
            get { return _Charge_PP_Line_ID; }
            set
            {
                _Charge_PP_Line_ID = value;
            }
        }
        [DataMember]
        public virtual int Appointment_ID
        {
            get { return _Appointment_ID; }
            set
            {
                _Appointment_ID = value;
            }
        }
        [DataMember]
        public virtual string Message_Type
        {
            get { return _Message_Type; }
            set
            {
                _Message_Type = value;
            }
        }
        [DataMember]
        public virtual string Message_Text
        {
            get { return _Message_Text; }
            set
            {
                _Message_Text = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        [DataMember]
        public virtual DateTime Message_Date
        {
            get { return _Message_Date; }
            set
            {
                _Message_Date = value;
            }
        }
        [DataMember]
        public virtual int Statement_ChargeLine_ID
        {
            get { return _Statement_ChargeLine_ID; }
            set
            {
                _Statement_ChargeLine_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Source_ID
        {
            get { return _Source_ID; }
            set
            {
                _Source_ID = value;
            }
        }
        [DataMember]
        public virtual int Denial_id
        {
            get { return _Denial_id; }
            set
            {
                _Denial_id = value;
            }
        }
        #endregion


    }
}
