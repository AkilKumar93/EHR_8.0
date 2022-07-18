
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class VaccineAdminProcedureMapping : BusinessBase<ulong>
    {
           #region Declarations

        private string _Vaccine_Procedure_Code =  string.Empty;
        private string _Vaccine_Procedure_Administered_Unit = string.Empty;
        private string _Admin_Procedure_Code = string.Empty;
        private string _Modifier = string.Empty;
        
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
      

        #endregion        

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Vaccine_Procedure_Code);
            sb.Append(_Admin_Procedure_Code);
            sb.Append(_Vaccine_Procedure_Administered_Unit);
            sb.Append(_Modifier);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
          
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties

        [DataMember]
        public virtual string Vaccine_Procedure_Code
        {
            get { return _Vaccine_Procedure_Code; }
            set
            {
                _Vaccine_Procedure_Code = value;
            }
        }


        [DataMember]
        public virtual string Admin_Procedure_Code
        {
            get { return _Admin_Procedure_Code; }
            set
            {
                _Admin_Procedure_Code = value;
            }
        }


        [DataMember]
        public virtual string Modifier
        {
            get { return _Modifier; }
            set
            {
                _Modifier = value;
            }
        }


        [DataMember]
        public virtual string Vaccine_Procedure_Administered_Unit
        {
            get { return _Vaccine_Procedure_Administered_Unit; }
            set
            {
                _Vaccine_Procedure_Administered_Unit = value;
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
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
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
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
       
        #endregion
    }
}
