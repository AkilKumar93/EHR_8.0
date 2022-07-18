using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ProcedureLoincMap:BusinessBase<ulong>
    {
        #region Declarations

        private string _MapSetName = string.Empty;
        private string _MapSetType = string.Empty;
        private string _MapSetSeparatorCode = string.Empty;
        private string _Loinc_Num = string.Empty;
        private string _Procedure_Code = string.Empty;
        private int _Sort_Order = 0;

        #endregion

        #region Constructors

        public ProcedureLoincMap() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_MapSetName);
            sb.Append(_MapSetType);
            sb.Append(_MapSetSeparatorCode);
            sb.Append(_Loinc_Num);
            sb.Append(_Procedure_Code);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string MapSetName
        {
            get { return _MapSetName; }
            set { _MapSetName = value; }
        }

        [DataMember]
        public virtual string MapSetType
        {
            get { return _MapSetType; }
            set { _MapSetType = value; }
        }


        [DataMember]
        public virtual string MapSetSeparatorCode
        {
            get { return _MapSetSeparatorCode; }
            set { _MapSetSeparatorCode = value; }
        }

        [DataMember]
        public virtual string Loinc_Num
        {
            get { return _Loinc_Num; }
            set { _Loinc_Num = value; }
        }


        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set { _Procedure_Code = value; }
        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
       

        #endregion

    }
}
