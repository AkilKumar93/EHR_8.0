using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PlanCPTFormRequired : BusinessBase<int>
    {
        #region Declarations

        private string _Insurance_Plan_ID = String.Empty;
        private string _Procedure_Code = string.Empty;
        private string _Form_Required = string.Empty;
        private string _Is_Mandatory =string.Empty;
        private string _Created_By= String.Empty;
        private System.DateTime _Created_Date_And_Time= DateTime.MinValue;
        private string _Modified_By = String.Empty;
        private System.DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Version = 0;
        private string _Procedure_Description = string.Empty;
        #endregion
        public PlanCPTFormRequired() { }

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Insurance_Plan_ID);
            sb.Append(_Procedure_Code);
            sb.Append(_Form_Required);
            sb.Append(_Is_Mandatory);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Procedure_Description);
            
            return sb.ToString().GetHashCode();
        }
        #region Properties

        [DataMember]
        public virtual string Insurance_Plan_ID
        {
            get { return _Insurance_Plan_ID; }
            set
            {
                _Insurance_Plan_ID = value;
            }
        }
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set
            {
                _Procedure_Code = value;
            }
        }
        [DataMember]
        public virtual string Form_Required
        {
            get { return _Form_Required; }
            set
            {
                _Form_Required = value;
            }
        }
        [DataMember]
        public virtual string Is_Mandatory
        {
            get { return _Is_Mandatory; }
            set
            {
                _Is_Mandatory = value;
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
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual string Procedure_Description
        {
            get { return _Procedure_Description; }
            set
            {
                _Procedure_Description = value;
            }
        }

         [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
         [DataMember]
         public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
         [DataMember]
         public virtual ulong Version
         {
             get { return _Version; }
             set
             {
                 _Version = value;
             }
         }






        #endregion
    }
}
