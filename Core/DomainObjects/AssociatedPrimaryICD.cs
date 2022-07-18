using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class AssociatedPrimaryICD : BusinessBase<ulong>
    {
        #region Declarations

        private string _ICD_9 = string.Empty;
        private string _Associated_ICD9 = string.Empty;
        private string _Associated_ICD9_Description = string.Empty;
        private string _Mutually_Exclusive = string.Empty;
        private string _HCC_Category = string.Empty;
        private string _Leaf_Node = string.Empty;
        private string _Prefix = string.Empty;

        #endregion

        #region Constructors

        public AssociatedPrimaryICD() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_ICD_9);
            sb.Append(_Associated_ICD9);
            sb.Append(_Associated_ICD9_Description);
            sb.Append(_Mutually_Exclusive);
            sb.Append(_HCC_Category);
            sb.Append(_Leaf_Node);
            sb.Append(_Prefix);
            
            return sb.ToString().GetHashCode();
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
        public virtual string Associated_ICD_9
        {
            get { return _Associated_ICD9; }
            set { _Associated_ICD9 = value; }
        }
        [DataMember]
        public virtual string Associated_ICD_9_Description
        {
            get { return _Associated_ICD9_Description; }
            set { _Associated_ICD9_Description = value; }
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
         public virtual string Leaf_Node
         {
             get { return _Leaf_Node; }
             set { _Leaf_Node = value; }
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
