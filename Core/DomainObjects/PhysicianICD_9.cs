using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class PhysicianICD_9 :FieldLookup
    {
        #region Declarations

        string _parent_ICD_9 = string.Empty;
        string _Description = string.Empty;
        string _leaf_node = string.Empty;
        ulong _physician_ID = 0;

        string _HCC_Category = string.Empty;
        string _Delete = string.Empty;
        string _Icd_9 = string.Empty;
        string _Version_Year = string.Empty;
        string _Is_Ruled_Out = string.Empty;
        int _Version=0;
        string _Created_By = string.Empty;
        DateTime _Created_Date_And_Time = DateTime.MinValue;
        string _Modified_By = string.Empty;
        DateTime _Modified_Date_And_Time = DateTime.MinValue;
        string _ICD_Category = string.Empty;
        double _Physician_ICD_Sort_Order = 0.000;
        int _Category_Sort_Order = 0;
        string _Legal_Org = string.Empty;

        #endregion

        #region Constructors

        public PhysicianICD_9() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_parent_ICD_9);
            sb.Append(_Description);
            sb.Append(_leaf_node);
            sb.Append(_physician_ID);
            sb.Append(_HCC_Category);
            sb.Append(_Delete);
            sb.Append(_Icd_9);
            sb.Append(_Version_Year);
            sb.Append(_Is_Ruled_Out);
            sb.Append(_Version);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_ICD_Category);
            sb.Append(_Physician_ICD_Sort_Order);
            sb.Append(_Category_Sort_Order);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string ICD_9
        {
            get { return _Icd_9; }
            set { _Icd_9 = value; }
        }

        [DataMember]
        public virtual string Parent_ICD_9
        {
            get { return _parent_ICD_9; }
            set { _parent_ICD_9 = value; }
        }
        [DataMember]
        public virtual string ICD_9_Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public virtual string Leaf_Node
        {
            get { return _leaf_node; }
            set { _leaf_node = value; }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _physician_ID; }
            set { _physician_ID = value; }
        }
        [DataMember]
        public virtual string HCC_Category
        {
            get { return _HCC_Category; }
            set { _HCC_Category = value; }
        }
        [DataMember]
        public virtual string Is_Delete
        {
            get { return _Delete; }
            set { _Delete = value; }
        }
        [DataMember]
        public virtual string Version_Year
        {
            get { return _Version_Year; }
            set { _Version_Year = value; }
        }
        [DataMember]
        public virtual string Is_Ruled_Out
        {
            get { return _Is_Ruled_Out; }
            set { _Is_Ruled_Out = value; }
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
        public virtual string ICD_Category
        {
            get { return _ICD_Category; }
            set { _ICD_Category = value; }
        }

        [DataMember]
        public virtual double Physician_ICD_Sort_Order
        {
            get { return _Physician_ICD_Sort_Order; }
            set { _Physician_ICD_Sort_Order = value; }
        }

        [DataMember]
        public virtual int Category_Sort_Order
        {
            get { return _Category_Sort_Order; }
            set { _Category_Sort_Order = value; }
        }

        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set { _Legal_Org = value; }
        }
        #endregion
    }
}
