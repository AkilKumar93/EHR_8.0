using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class MasterTableList:BusinessBase<ulong>

    {
        #region Declarations
        
        private string _Table_Name = string.Empty;
        private int _Bucket_Number = 0;
        private string _Table_Comment = string.Empty;
        private string _Manager_Object_Name = string.Empty;
        private string _Domain_Object_Name = string.Empty;
        private string _Is_Audit_Trail = string.Empty;
        private string _Deleted_Attribute = string.Empty;
        #endregion

        #region Constructors

        public MasterTableList() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            
            sb.Append(_Table_Name);
            sb.Append(_Bucket_Number);
            sb.Append(_Table_Comment);
            sb.Append(_Manager_Object_Name);
            sb.Append(_Domain_Object_Name);
            sb.Append(_Is_Audit_Trail);
            sb.Append(_Deleted_Attribute);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }
        }

        [DataMember]
        public virtual int Bucket_Number
        {
            get { return _Bucket_Number; }
            set { _Bucket_Number = value; }
        }

        [DataMember]
        public virtual string Table_Comment
        {
            get { return _Table_Comment; }
            set { _Table_Comment = value; }
        }
        [DataMember]
        public virtual string Manager_Object_Name
        {
            get { return _Manager_Object_Name; }
            set { _Manager_Object_Name = value; }
        }

        [DataMember]
        public virtual string Domain_Object_Name
        {
            get { return _Domain_Object_Name; }
            set { _Domain_Object_Name = value; }
        }

        [DataMember]
        public virtual string Is_Audit_Trail
        {
            get { return _Is_Audit_Trail; }
            set { _Is_Audit_Trail = value; }
        }

        [DataMember]
        public virtual string Deleted_Attribute
        {
            get { return _Deleted_Attribute; }
            set { _Deleted_Attribute = value; }
        }

        #endregion


    }
}
