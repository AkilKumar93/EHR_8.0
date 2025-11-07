using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class IndexingFileLookup : BusinessBase<ulong>
    {
        #region Declarations
        private string _Segment_Name = string.Empty;
        private string _Segment_Field = string.Empty;
        private string _Segment_Sub_Field = string.Empty;
        private string _Table_Name = string.Empty;
        private string _Column_Name = string.Empty;
        private string _Field_Description = string.Empty;
        private string _Domain_Object = string.Empty;
        private int _Sort_Order = 0;
        private String _Segment_Type =string.Empty;
        #endregion

        #region Constructors
        public IndexingFileLookup() { }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Segment_Name);
            sb.Append(_Segment_Field);
            sb.Append(_Segment_Sub_Field);
            sb.Append(_Table_Name);
            sb.Append(_Column_Name);
            sb.Append(_Field_Description);
            sb.Append(_Domain_Object);
            sb.Append(_Sort_Order);
            sb.Append(_Segment_Type);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties

        [DataMember]
        public virtual string Segment_Name
        {
            get { return _Segment_Name; }
            set { _Segment_Name = value; }
        }
        [DataMember]
        public virtual string Segment_Field
        {
            get { return _Segment_Field; }
            set { _Segment_Field = value; }
        }
        [DataMember]
        public virtual string Segment_Sub_Field
        {
            get { return _Segment_Sub_Field; }
            set { _Segment_Sub_Field = value; }
        }
        [DataMember]
        public virtual string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }
        }
        [DataMember]
        public virtual string Column_Name
        {
            get { return _Column_Name; }
            set { _Column_Name = value; }
        }
        [DataMember]
        public virtual string Field_Description
        {
            get { return _Field_Description; }
            set { _Field_Description = value; }
        }
        [DataMember]
        public virtual string Domain_Object
        {
            get { return _Domain_Object; }
            set { _Domain_Object = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string Segment_Type
        {
            get { return _Segment_Type; }
            set { _Segment_Type = value; }
        }
        #endregion
    }
}