using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
   public partial class PreventiveScreenLookup:BusinessBase<ulong>
    {
         #region Decleration

        private string _Field_Name = string.Empty;
        private string _Value = string.Empty;
        private int _Sort_Order=0;
        private ulong _Parent_Preventive_Screen_Lookup_ID = 0;
        private string _Options = string.Empty;
        private string _Status = string.Empty;
        private string _Depending_Value = string.Empty;
        private string _Description = string.Empty;



        #endregion

        #region Constructors

        public PreventiveScreenLookup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Field_Name);
            sb.Append(_Value);
            sb.Append(_Sort_Order);
            sb.Append(_Parent_Preventive_Screen_Lookup_ID);
            sb.Append(_Options);
            sb.Append(_Status);
            sb.Append(_Depending_Value);
            sb.Append(_Description);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Implementation

        [DataMember]
        public virtual ulong Parent_Preventive_Screen_Lookup_ID
        {
            get { return _Parent_Preventive_Screen_Lookup_ID; }
            set { _Parent_Preventive_Screen_Lookup_ID = value; }
        }
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
        public virtual string Depending_Value
        {
            get { return _Depending_Value; }
            set { _Depending_Value = value; }
        }

        [DataMember]
        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        #endregion

    }
}
