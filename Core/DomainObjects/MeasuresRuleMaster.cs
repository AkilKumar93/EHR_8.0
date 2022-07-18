using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class MeasuresRuleMaster : BusinessBase<ulong>
    {
        private string _Measure_Name = string.Empty;
        private string _Rule_Description = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_and_Time = new DateTime();
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_and_Time = new DateTime();
        private string _Table_Name = string.Empty;
        private string _Where_Criteria = string.Empty;
        private string _Additional_Rule = string.Empty;
        private int _Parent_Rule_ID = 0;

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Measure_Name);
            sb.Append(_Rule_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_and_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_and_Time);
            sb.Append(_Table_Name);
            sb.Append(_Where_Criteria);
            sb.Append(_Additional_Rule);
            sb.Append(_Parent_Rule_ID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        [DataMember]
        public virtual string Measure_Name
        {
            get { return _Measure_Name; }
            set
            {
                _Measure_Name = value;
            }
        }
        [DataMember]
        public virtual string Rule_Description
        {
            get { return _Rule_Description; }
            set
            {
                _Rule_Description = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_and_Time
        {
            get { return _Created_Date_and_Time; }
            set
            {
                _Created_Date_and_Time = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_and_Time
        {
            get { return _Modified_Date_and_Time; }
            set
            {
                _Modified_Date_and_Time = value;
            }
        }
        [DataMember]
        public virtual string Table_Name
        {
            get { return _Table_Name; }
            set
            {
                _Table_Name = value;
            }
        }
        [DataMember]
        public virtual string Where_Criteria
        {
            get { return _Where_Criteria; }
            set
            {
                _Where_Criteria = value;
            }
        }
        [DataMember]
        public virtual string Additional_Rule
        {
            get { return _Additional_Rule; }
            set
            {
                _Additional_Rule = value;
            }
        }

        [DataMember]
        public virtual int Parent_Rule_ID
        {
            get { return _Parent_Rule_ID; }
            set
            {
                _Parent_Rule_ID = value;
            }
        }



    }
}
