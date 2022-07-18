using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class DictationException : BusinessBase<ulong>
    {
        #region Declarations

        private string _File_Name = string.Empty;
        private ulong _Encounter_ID = 0;
        private string _Header = string.Empty;
        private string _Sub_Header = string.Empty;
        private string _Data = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _version = 0;
        private ulong _Exception_ID = 0;
        private bool _isResultPending = false;
        private ulong _Human_ID = 0;

        #endregion

        #region Constructors

        public DictationException() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(this.GetType().FullName);
            sb.Append(_File_Name);
            sb.Append(_Exception_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Header);
            sb.Append(_Sub_Header);
            sb.Append(_Data);
            sb.Append(_Created_By);
            sb.Append(_Created_Date);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_isResultPending);
            sb.Append(_Human_ID);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties


        [DataMember]
        public virtual ulong Exception_ID
        {
            get { return _Exception_ID; }
            set { _Exception_ID = value; }
        }


        [DataMember]
        public virtual string File_Name
        {
            get { return _File_Name; }
            set { _File_Name = value; }
        }

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }

        [DataMember]
        public virtual string Header
        {
            get { return _Header; }
            set { _Header = value; }
        }

        [DataMember]
        public virtual string Sub_Header
        {
            get { return _Sub_Header; }
            set { _Sub_Header = value; }
        }

        [DataMember]
        public virtual string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        [DataMember]
        public virtual DateTime Created_Date
        {
            get { return _Created_Date; }
            set { _Created_Date = value; }
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
            get { return _version; }
            set { _version = value; }
        }

        [DataMember]
        public virtual bool IsResultPending
        {
            get { return _isResultPending; }
            set { _isResultPending = value; }
        }

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        #endregion
    }
}
