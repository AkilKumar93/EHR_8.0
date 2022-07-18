using System.Runtime.Serialization;
using System;


namespace Acurus.Capella.Core.DomainObjects
{

    [Serializable]
    [DataContract]
    public partial class Notification : BusinessBase<string>
    {
        #region Declarations

        private string _Human_ID = string.Empty;
        private string _Encounter_ID = string.Empty;
        private string _CDS_Rule_Master_Name = string.Empty;
        private string _Created_By = string.Empty;
        private int _Version = 0;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Status = string.Empty;
        #endregion

        #region Constructors

        public Notification() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_CDS_Rule_Master_Name);
            sb.Append(_Version);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Status);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual string Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual string Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual string CDS_Rule_Master_Name
        {
            get { return _CDS_Rule_Master_Name; }
            set { _CDS_Rule_Master_Name = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
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
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion
    }
}
