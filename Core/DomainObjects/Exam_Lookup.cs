using System;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{

    [DataContract]
    public partial class Exam_Lookup : BusinessBase<ulong>
    {
        #region Decleration

        private ulong _Exam_Lookup_Id = 0;
        private string _Category = string.Empty;
        private string _System_Name = string.Empty;
        private string _Condition_Name = string.Empty;
        private string _User_Name = string.Empty;
        private int _Sort_Order = 0;
        private string _Field_Type = string.Empty;
        private string _Field_value = string.Empty;
        private string _Options = string.Empty;
        private string _Normal_System_Status = string.Empty;
        private string _Default_Value = string.Empty;
        private string _Status = string.Empty;
        private string _Short_Description = string.Empty;
        private string _Default_System_Color = string.Empty;
        private string _Other_Description = string.Empty;
        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Exam_Lookup_Id);
            sb.Append(_User_Name);
            sb.Append(_Category);
            sb.Append(_System_Name);
            sb.Append(_Condition_Name);
            sb.Append(_Sort_Order);
            sb.Append(_Field_Type);
            sb.Append(_Field_value);
            sb.Append(_Options);
            sb.Append(_Normal_System_Status);
            sb.Append(_Default_Value);
            sb.Append(_Status);
            sb.Append(_Short_Description);
            sb.Append(_Default_System_Color);
            sb.Append(_Other_Description);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Implementation
        [DataMember]
        public virtual ulong Exam_Lookup_Id
        {
            get { return _Exam_Lookup_Id; }
            set { _Exam_Lookup_Id = value; }
        }

        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        [DataMember]
        public virtual string System_Name
        {
            get { return _System_Name; }
            set { _System_Name = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string Normal_System_Status
        {
            get { return _Normal_System_Status; }
            set { _Normal_System_Status = value; }
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
        public virtual string Field_Type
        {
            get { return _Field_Type; }
            set { _Field_Type = value; }
        }
        [DataMember]
        public virtual string Field_Value
        {
            get { return _Field_value; }
            set { _Field_value = value; }
        }
        [DataMember]
        public virtual string Options
        {
            get { return _Options; }
            set { _Options = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [DataMember]
        public virtual string Condition_Name
        {
            get { return _Condition_Name; }
            set { _Condition_Name = value; }
        }
        [DataMember]
        public virtual string Short_Description
        {
            get { return _Short_Description; }
            set { _Short_Description = value; }
        }
        [DataMember]
        public virtual string Default_System_Color
        {
            get { return _Default_System_Color; }
            set { _Default_System_Color = value; }
        }
        [DataMember]
        public virtual string Other_Description
        {
            get { return _Other_Description; }
            set { _Other_Description = value; }
        }
        #endregion
    }
}
