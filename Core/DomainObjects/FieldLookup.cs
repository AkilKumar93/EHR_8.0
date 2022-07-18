using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{

    
    [Serializable]

    public partial class FieldLookup : BusinessBase<ulong>
    {
        #region Decleration

        private string _User_Name=string.Empty;
        private string _Field_Name = string.Empty;
        private string _Value = string.Empty;
        private int _Sort_Order=0;
        private string _Description = string.Empty;
        private string _Default_Value = string.Empty;
        private string _Is_Physician=string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private ulong _Physician_ID = 0;

        //private string _Physician_Procedure_Code = string.Empty;
        //private string _Procedure_Description = string.Empty;
        //private string _Procedure_Type = string.Empty;
        //private int _Version = 0;
        //private string _Created_By = string.Empty;
        //private string _Modified_By = string.Empty;
        //private DateTime _Created_Date_And_Time = DateTime.MinValue;
        //private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        //private ulong _Lab_ID = 0;

        //private string _parent_ICD_9 = string.Empty;
        //private string _leaf_node = string.Empty;
        //private string _HCC_Category = string.Empty;
        //private string _Delete = string.Empty;
        //private string _Icd_9 = string.Empty;
        //private string _Version_Year = string.Empty;
        //private string _Is_Ruled_Out = string.Empty;
        //private string _ICD_9_Description = string.Empty;


        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_User_Name);
            sb.Append(_Field_Name);
            sb.Append(_Value);
            sb.Append(_Sort_Order);
            sb.Append(_Description);
            sb.Append(_Default_Value);
            sb.Append(_Is_Physician);
            sb.Append(_Doc_Type);
            sb.Append(_Doc_Sub_Type);
            sb.Append(_Physician_ID);

            //sb.Append(_Physician_Procedure_Code);
            //sb.Append(_Procedure_Description);
            //sb.Append(_Procedure_Type);
            //sb.Append(_Created_By);
            //sb.Append(_Created_Date_And_Time);
            //sb.Append(_Modified_By);
            //sb.Append(_Modified_Date_And_Time);
            //sb.Append(_Version);
            //sb.Append(_Lab_ID);

            //sb.Append(_parent_ICD_9);
            //sb.Append(_leaf_node);
            //sb.Append(_HCC_Category);
            //sb.Append(_Delete);
            //sb.Append(_Icd_9);
            //sb.Append(_Version_Year);
            //sb.Append(_Is_Ruled_Out);
            //sb.Append(_ICD_9_Description);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Implementation

        [DataMember]
        public virtual string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }
        [DataMember]
        public virtual string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public virtual string Default_Value
        {
            get { return _Default_Value; }
            set { _Default_Value = value; }
        }
        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        [DataMember]
        public virtual string Is_Physician
        {
            get { return _Is_Physician; }
            set { _Is_Physician = value; }
        }
        [DataMember]
        public virtual string Doc_Type
        {
            get { return _Doc_Type; }
            set { _Doc_Type = value; }
        }
        [DataMember]
        public virtual string Doc_Sub_Type
        {
            get { return _Doc_Sub_Type; }
            set { _Doc_Sub_Type = value; }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }

        //[DataMember]
        //public virtual string Physician_Procedure_Code
        //{
        //    get { return _Physician_Procedure_Code; }
        //    set { _Physician_Procedure_Code = value; }
        //}
        //[DataMember]
        //public virtual string Procedure_Description
        //{
        //    get { return _Procedure_Description; }
        //    set { _Procedure_Description = value; }
        //}
        //[DataMember]
        //public virtual string Procedure_Type
        //{
        //    get { return _Procedure_Type; }
        //    set { _Procedure_Type = value; }
        //}
        //[DataMember]
        //public virtual string Created_By
        //{
        //    get { return _Created_By; }
        //    set { _Created_By = value; }
        //}
        //[DataMember]
        //public virtual string Modified_By
        //{
        //    get { return _Modified_By; }
        //    set { _Modified_By = value; }
        //}

        //[DataMember]
        //public virtual DateTime Modified_Date_And_Time
        //{
        //    get { return _Modified_Date_And_Time; }
        //    set { _Modified_Date_And_Time = value; }
        //}

        //[DataMember]
        //public virtual DateTime Created_Date_And_Time
        //{
        //    get { return _Created_Date_And_Time; }
        //    set { _Created_Date_And_Time = value; }
        //}

        //[DataMember]
        //public virtual int Version
        //{
        //    get { return _Version; }
        //    set { _Version = value; }
        //}

        //[DataMember]
        //public virtual ulong Lab_ID
        //{
        //    get { return _Lab_ID; }
        //    set { _Lab_ID = value; }
        //}





        //[DataMember]
        //public virtual string Parent_ICD_9
        //{
        //    get { return _parent_ICD_9; }
        //    set { _parent_ICD_9 = value; }
        //}
        //[DataMember]
        //public virtual string Leaf_Node
        //{
        //    get { return _leaf_node; }
        //    set { _leaf_node = value; }
        //}

        //[DataMember]
        //public virtual string HCC_Category
        //{
        //    get { return _HCC_Category; }
        //    set { _HCC_Category = value; }
        //}

        //[DataMember]
        //public virtual string Is_Delete
        //{
        //    get { return _Delete; }
        //    set { _Delete = value; }
        //}

        //[DataMember]
        //public virtual string ICD_9
        //{
        //    get { return _Icd_9; }
        //    set { _Icd_9 = value; }
        //}

        //[DataMember]
        //public virtual string Version_Year
        //{
        //    get { return _Version_Year; }
        //    set { _Version_Year = value; }
        //}

        //[DataMember]
        //public virtual string Is_Ruled_Out
        //{
        //    get { return _Is_Ruled_Out; }
        //    set { _Is_Ruled_Out = value; }
        //}

        //[DataMember]
        //public virtual string ICD_9_Description
        //{
        //    get { return _ICD_9_Description; }
        //    set { _ICD_9_Description = value; }
        //}

        #endregion
    }
}
