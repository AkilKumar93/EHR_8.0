using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ICD9ICD10Mapping: BusinessBase<ulong>
    { 
        #region Declarations

        private string _ICD9 = string.Empty;
        private string _ICD10 = string.Empty;
        private string _MappingRule = string.Empty;
        private string _RuleName = string.Empty;
        private string _Short_Description = string.Empty;
        private string _Long_Description = string.Empty;
        private string _Is_Active = string.Empty;
        private int _Version=0;
        private string _ICD_9_Description = string.Empty;
        #endregion

        #region Constructors

        public ICD9ICD10Mapping() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(this.GetType().FullName);
            sb.Append(_ICD9);
            sb.Append(_ICD10);
            sb.Append(_MappingRule);
            sb.Append(_RuleName);
            sb.Append(_Short_Description);
            sb.Append(_Long_Description);
            sb.Append(_Is_Active); 
            sb.Append(_Version);
            sb.Append(_ICD_9_Description);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string ICD9
        {
            get { return _ICD9; }
            set { _ICD9 = value; }
        }

        [DataMember]
        public virtual string ICD10
        {
            get { return _ICD10; }
            set { _ICD10 = value; }
        }

        [DataMember]
        public virtual string MappingRule
        {
            get { return _MappingRule; }
            set { _MappingRule = value; }
        }

        [DataMember]
        public virtual string RuleName
        {
            get { return _RuleName; }
            set { _RuleName = value; }
        }

        [DataMember]
        public virtual string Short_Description
        {
            get { return _Short_Description; }
            set { _Short_Description = value; }
        }

        [DataMember]
        public virtual string Long_Description
        {
            get { return _Long_Description; }
            set { _Long_Description = value; }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }


        [DataMember]
        public virtual string ICD_9_Description
        {
            get { return _ICD_9_Description; }
            set { _ICD_9_Description = value; }
        }
        #endregion
    }
}
