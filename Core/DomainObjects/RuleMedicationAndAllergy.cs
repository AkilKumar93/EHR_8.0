using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
     [DataContract]
    public partial class RuleMedicationAndAllergy : BusinessBase<ulong>
    {
        #region Parameter Variable Decleration
         private ulong _Rule_Master_ID = 0;
         private string _Drug_Name = string.Empty;
         private string _Rx_Norm_ID = string.Empty;
         private string _NDC = string.Empty;
         private string _Type = string.Empty;
         private string _Created_By = string.Empty;
         private DateTime _Created_Date_And_Time = DateTime.MinValue;
         private string _Modified_By = string.Empty;
         private DateTime _Modified_Date_And_Time = DateTime.MinValue;
         private int _Version=0;
        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Rule_Master_ID);
            sb.Append(_Drug_Name);
            sb.Append(_Rx_Norm_ID);
            sb.Append(_NDC);
            sb.Append(_Type);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation

        [DataMember]
        public virtual ulong Rule_Master_ID
        {
            get { return _Rule_Master_ID; }
            set { _Rule_Master_ID = value; }
        }
        [DataMember]
        public virtual string Drug_Name
        {
            get { return _Drug_Name; }
            set { _Drug_Name = value; }
        }
        [DataMember]
        public virtual string Rx_Norm_ID
        {
            get { return _Rx_Norm_ID; }
            set { _Rx_Norm_ID = value; }
        }
        [DataMember]
        public virtual string NDC
        {
            get { return _NDC; }
            set { _NDC = value; }
        }
        [DataMember]
        public virtual string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }


        #endregion
    }
}
