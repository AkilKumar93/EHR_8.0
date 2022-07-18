using System;
using System.Runtime.Serialization;
using System.Reflection;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrdersQuestionSetBloodLead : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Order_ID = 0;
        private string _Blood_Lead_Type = string.Empty;
        private string _Blood_Lead_Type_HL7_Value = string.Empty;
        private string _Blood_Lead_Type_Purpose = string.Empty;
        private string _Blood_Lead_Type_Purpose_HL7_Value = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;


        #endregion

        #region Constructors

        public OrdersQuestionSetBloodLead() { }

        public OrdersQuestionSetBloodLead(OrdersQuestionSetBloodLead obj) 
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(obj, null), null);
            }
        }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Order_ID);
            sb.Append(_Blood_Lead_Type);
            sb.Append(_Blood_Lead_Type_HL7_Value);
            sb.Append(_Blood_Lead_Type_Purpose);
            sb.Append(_Blood_Lead_Type_Purpose_HL7_Value);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
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
        public virtual string Blood_Lead_Type
        {
            get { return _Blood_Lead_Type; }
            set { _Blood_Lead_Type = value; }
        }

        [DataMember]
        public virtual string Blood_Lead_Type_HL7_Value
        {
            get { return _Blood_Lead_Type_HL7_Value; }
            set { _Blood_Lead_Type_HL7_Value = value; }
        }
        [DataMember]
        public virtual string Blood_Lead_Type_Purpose
        {
            get { return _Blood_Lead_Type_Purpose; }
            set { _Blood_Lead_Type_Purpose = value; }
        }

        [DataMember]
        public virtual string Blood_Lead_Type_Purpose_HL7_Value
        {
            get { return _Blood_Lead_Type_Purpose_HL7_Value; }
            set { _Blood_Lead_Type_Purpose_HL7_Value = value; }
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


        #endregion
    }
}
