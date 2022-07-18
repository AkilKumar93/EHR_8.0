using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrdersQuestionSetAOE : BusinessBase<ulong>
    {
        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        private ulong _Physician_ID = 0;
        private ulong _Orders_ID= 0;
        private string _AOE_Question = string.Empty;
        private string _AOE_Value = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Order_Code = string.Empty;
        private string _AOE_Identifier = string.Empty;
        #region Constructors

        public OrdersQuestionSetAOE() { }

        #endregion
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_AOE_Value);
            sb.Append(_AOE_Question);
            sb.Append(_Orders_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Order_Code);
            sb.Append(_AOE_Identifier);
            return sb.ToString().GetHashCode();
        }


        #region Properties


        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual ulong Orders_ID
        {
            get { return _Orders_ID; }
            set { _Orders_ID = value; }
        }
        [DataMember]
        public virtual string AOE_Question
        {
            get { return _AOE_Question; }
            set { _AOE_Question = value; }
        }
        [DataMember]
        public virtual string AOE_Value
        {
            get { return _AOE_Value; }
            set { _AOE_Value = value; }
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
        public virtual string Order_Code
        {
            get { return _Order_Code; }
            set { _Order_Code = value; }
        }
        [DataMember]
        public virtual string AOE_Identifier
        {
            get { return _AOE_Identifier; }
            set { _AOE_Identifier = value; }
        }
        #endregion
    }
}
