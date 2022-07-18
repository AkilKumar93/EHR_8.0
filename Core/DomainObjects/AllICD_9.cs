using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class AllICD_9: BusinessBase<string>
    {
         #region Declarations

        private string _ICD_9 = string.Empty;
        private string _parent_ICD_9 = string.Empty;
        private string _Description = string.Empty;
        private string _Description_Synonyms = string.Empty;
        private string _leaf_node = string.Empty;
        private string _Mutually_Exclusive = string.Empty;
        private string _HCC_Category = string.Empty;
        private string _Version_Year = string.Empty;
        private string _Manageable = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Is_Active = string.Empty;
        private int _Sort_Order = 0;
        private string _Is_Report_To_Cancer_Registry = string.Empty;
        private string _From_Date = string.Empty;
        private string _To_Date = string.Empty;

        private string _SNOMED_Code = string.Empty;
        private string _SNOMED_Code_Description = string.Empty;
        private string _Short_Description = string.Empty;
         private string _ICD_ID = string.Empty;



        #endregion

        #region Constructors

        public AllICD_9() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_ICD_9);
            sb.Append(_parent_ICD_9);
            sb.Append(_Description);
            sb.Append(_Description_Synonyms);
            sb.Append(_leaf_node);
            sb.Append(_Mutually_Exclusive);
            sb.Append(_HCC_Category);
            sb.Append(_Version_Year);
            sb.Append(_Manageable);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Is_Active);
            sb.Append(_Sort_Order);
            sb.Append(_Is_Report_To_Cancer_Registry);
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_SNOMED_Code);
            sb.Append(_SNOMED_Code_Description);
            sb.Append(_Short_Description);
            sb.Append(_ICD_ID);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual string SNOMED_Code
        {
            get { return _SNOMED_Code; }
            set { _SNOMED_Code = value; }
        }
        [DataMember]
        public virtual string SNOMED_Code_Description
        {
            get { return _SNOMED_Code_Description; }
            set { _SNOMED_Code_Description = value; }
        }
        [DataMember]
        public virtual string Short_Description
        {
            get { return _Short_Description; }
            set { _Short_Description = value; }
        }
        [DataMember]
        public virtual string ICD_ID
        {
            get { return _ICD_ID; }
            set { _ICD_ID = value; }
        }

        [DataMember]
        public virtual string ICD_9
        {
            get { return _ICD_9; }
            set { _ICD_9 = value; }
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
        public virtual string ICD_9_Description_Synonyms
        {
            get { return _Description_Synonyms; }
            set { _Description_Synonyms = value; }
        }
        [DataMember]
        public virtual string Leaf_Node
        {
            get { return _leaf_node; }
            set { _leaf_node = value; }
        }
         [DataMember]
        public virtual string Mutually_Exclusive
        {
            get { return _Mutually_Exclusive; }
            set { _Mutually_Exclusive = value; }
        }
         [DataMember]
         public virtual string HCC_Category
         {
             get { return _HCC_Category; }
             set { _HCC_Category = value; }
         }

         [DataMember]
         public virtual string Version_Year
         {
             get { return _Version_Year; }
             set { _Version_Year = value; }
         }
         [DataMember]
         public virtual string Manageable
         {
             get { return _Manageable; }
             set { _Manageable = value; }
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
         public virtual string Is_Active
         {
             get { return _Is_Active; }
             set { _Is_Active = value; }
         }
         [DataMember]
         public virtual int Sort_Order
         {
             get { return _Sort_Order; }
             set { _Sort_Order = value; }
         }

         [DataMember]
         public virtual string Is_Report_To_Cancer_Registry
         {
             get { return _Is_Report_To_Cancer_Registry; }
             set { _Is_Report_To_Cancer_Registry = value; }
         }
         [DataMember]
         public virtual string From_Date
         {
             get { return _From_Date; }
             set { _From_Date = value; }
         }
         [DataMember]
         public virtual string To_Date
         {
             get { return _To_Date; }
             set { _To_Date = value; }
         }
        #endregion
    }
}
