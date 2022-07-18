using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Acurus.Capella.Core.DomainObjects
{
    public class ReasonCodeLookup : BusinessBase<ulong>
    {
        #region Declarations
        private string _Field_Name = string.Empty;
        private string _Reason_Code = string.Empty;
        private string _Sub_Code  = string.Empty;
        private string _Description = string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private int _Sort_Order = 0;
        private string _Category=string.Empty;
        #endregion

        #region Constructors

        public ReasonCodeLookup() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Field_Name);
            sb.Append(_Reason_Code);
            sb.Append(_Sub_Code);
            sb.Append(_Description);
            sb.Append(_Doc_Type);
            sb.Append(_Doc_Sub_Type);
            sb.Append(_Sort_Order);
            sb.Append(_Category);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties       
        public virtual string Field_Name
        {
            get { return _Field_Name; }
            set
            {
                _Field_Name = value;
            }
        }
        public virtual string Reason_Code
        {
            get { return _Reason_Code; }
            set
            {
                _Reason_Code = value;
            }
        }
        public virtual string Sub_Code
        {
            get { return _Sub_Code; }
            set
            {
                _Sub_Code = value;
            }
        }
        public virtual string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
        public virtual string Doc_Type
        {
            get { return _Doc_Type; }
            set
            {
                _Doc_Type = value;
            }
        }
        public virtual string Doc_Sub_Type
        {
            get { return _Doc_Sub_Type; }
            set
            {
                _Doc_Sub_Type = value;
            }
        }
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set
            {
                _Sort_Order = value;
            }
        }


        public virtual string Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
            }
        }
        #endregion
    }

}
