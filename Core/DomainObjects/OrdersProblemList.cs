using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrdersProblemList:BusinessBase<ulong>
    {
         #region Declarartions

        private ulong _Order_ID = 0;
        private ulong _Problem_List_ID = 0;
        private string _ICD = string.Empty;
        private string _ICD_Description = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private ulong _Encounter_ID = 0;

        #endregion


        #region Constructors

        public OrdersProblemList() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Order_ID);
            sb.Append(_Problem_List_ID);
            sb.Append(_ICD);
            sb.Append(_ICD_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Encounter_ID);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
              
        [DataMember]
        public virtual ulong Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }
        [DataMember]
        public virtual ulong Problem_List_ID
        {
            get { return _Problem_List_ID; }
            set { _Problem_List_ID = value; }
        }

        [DataMember]
        public virtual string ICD
        {
            get { return _ICD; }
            set { _ICD = value; }
        }

        [DataMember]
        public virtual string ICD_Description
        {
            get { return _ICD_Description; }
            set { _ICD_Description = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }


        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
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

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }

        #endregion
    }
}
