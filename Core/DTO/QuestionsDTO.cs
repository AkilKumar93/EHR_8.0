using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class QuestionsDTO
    {
        #region Declarations

      
        private string _ICD_9 = string.Empty;
        private string _Parent_ID=string.Empty ;
        private string _Diagnosis_Description = string.Empty;
        private string _Leaf_Node = string.Empty;
        private string _Mutually_Exclusive = string.Empty;
        private ulong _HCC_Category = 0;
        private string _Prefix = string.Empty;

        #endregion

        #region Constructor

        public QuestionsDTO() 
        {
        }

        #endregion
        
        #region Properties

        [DataMember]
        public virtual string ICD_9
        {
            get { return _ICD_9; }
            set { _ICD_9 = value; }
        }

        [DataMember]
        public virtual string Parent_ID
        {
            get { return _Parent_ID; }
            set { _Parent_ID = value; }

        }

        [DataMember]
        public virtual string Diagnosis_Description
        {
            get { return _Diagnosis_Description; }
            set { _Diagnosis_Description = value; }
        }

        
        [DataMember]
        public virtual string Leaf_Node
        {
            get { return _Leaf_Node; }
            set { _Leaf_Node = value; }
        }
        [DataMember]
        public virtual string Mutually_Exclusive
        {
            get { return _Mutually_Exclusive; }
            set { _Mutually_Exclusive = value; }
        }
      
        [DataMember]
        public virtual ulong HCC_Category
        {
            get { return _HCC_Category; }
            set { _HCC_Category = value; }
        }

        [DataMember]
        public virtual string Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }

        #endregion
    }
}
