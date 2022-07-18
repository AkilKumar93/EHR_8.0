    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public class Rcopia_Prescription_List : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Human_ID = 0;
        private string _External_ID = string.Empty;
        private string _Drug = string.Empty;
        private string _NDC_ID = string.Empty;
        private string _First_DataBank_Med_ID = string.Empty;
        private string _Brand_Name = string.Empty;
        private string _Generic_Name = string.Empty;
        private string _Route = string.Empty;
        private string _Form = string.Empty;
        private string _Strength = string.Empty;
        private string _Action = string.Empty;
        private string _Dose = string.Empty;
        private string _Dose_Unit = string.Empty;
        private string _Dose_Timing = string.Empty;
        private string _Dose_Other = string.Empty;
        private string _Duration = string.Empty;
        private string _Quantity = string.Empty;
        private string _Quantity_Unit = string.Empty;
        private string _Refills = string.Empty;
        private string _Substitution_Permitted = string.Empty;
        private string _Other_Notes = string.Empty;
        private string _Patient_Notes = string.Empty;
        private string _Comments = string.Empty;
        private DateTime _Completed_Date = DateTime.MinValue;
        private DateTime _Stop_Date = DateTime.MinValue;
        private DateTime _Signed_Date = DateTime.MinValue;
        private string _Last_Modified_By = string.Empty;
        private DateTime _Last_Modified_Date = DateTime.MinValue;
        private string _Height = string.Empty;
        private string _Weight = string.Empty;
        private string _Intended_Use = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Brand_Type = string.Empty;
        private string _Order = string.Empty;
        private string _ICD_Code = string.Empty;
        private string _ICD_Code_Description = string.Empty;
        private string _Deleted=string.Empty ;
        private int _Formulary_ID = 0;
        private string _Electronic = string.Empty;

        #endregion

        #region Constructors

        public Rcopia_Prescription_List() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_External_ID);
            sb.Append(_Drug);
            sb.Append(_NDC_ID);
            sb.Append(_First_DataBank_Med_ID);
            sb.Append(_Brand_Name);
            sb.Append(_Generic_Name);
            sb.Append(_Route);
            sb.Append(_Form);
            sb.Append(_Strength);
            sb.Append(_Action);
            sb.Append(_Dose);
            sb.Append(_Dose_Unit);
            sb.Append(_Dose_Timing);
            sb.Append(_Dose_Other);
            sb.Append(_Duration);
            sb.Append(_Quantity);
            sb.Append(_Quantity_Unit);
            sb.Append(_Refills);
            sb.Append(_Substitution_Permitted);
            sb.Append(_Other_Notes);
            sb.Append(_Patient_Notes);
            sb.Append(_Comments);
            sb.Append(_Completed_Date);
            sb.Append(_Stop_Date);
            sb.Append(_Signed_Date);
            sb.Append(_Last_Modified_By);
            sb.Append(_Last_Modified_Date);
            sb.Append(_Height);
            sb.Append(_Weight);
            sb.Append(_Intended_Use);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Brand_Type);
            sb.Append(_Order);
            sb.Append(_ICD_Code);
            sb.Append(_ICD_Code_Description);
            sb.Append(_Deleted);
            sb.Append(_Formulary_ID);
            sb.Append(_Electronic);
            return sb.ToString().GetHashCode();

        }
        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual string External_ID
        {
            get { return _External_ID; }
            set
            {
                _External_ID = value;
            }
        }
        [DataMember]
        public virtual string Drug
        {
            get { return _Drug; }
            set
            {
                _Drug = value;
            }
        }
        [DataMember]
        public virtual string NDC_ID
        {
            get { return _NDC_ID; }
            set
            {
                _NDC_ID = value;
            }
        }
        [DataMember]
        public virtual string First_DataBank_Med_ID
        {
            get { return _First_DataBank_Med_ID; }
            set
            {
                _First_DataBank_Med_ID = value;
            }
        }
        [DataMember]
        public virtual string Brand_Name
        {
            get { return _Brand_Name; }
            set
            {
                _Brand_Name = value;
            }
        }
        [DataMember]
        public virtual string Generic_Name
        {
            get { return _Generic_Name; }
            set
            {
                _Generic_Name = value;
            }
        }
        [DataMember]
        public virtual string Route
        {
            get { return _Route; }
            set
            {
                _Route = value;
            }
        }
        [DataMember]
        public virtual string Form
        {
            get { return _Form; }
            set
            {
                _Form = value;
            }
        }
        [DataMember]
        public virtual string Strength
        {
            get { return _Strength; }
            set
            {
                _Strength = value;
            }
        }
        [DataMember]
        public virtual string Action
        {
            get { return _Action; }
            set
            {
                _Action = value;
            }
        }
        [DataMember]
        public virtual string Dose
        {
            get { return _Dose; }
            set
            {
                _Dose = value;
            }
        }
        [DataMember]
        public virtual string Dose_Unit
        {
            get { return _Dose_Unit; }
            set
            {
                _Dose_Unit = value;
            }
        }
        [DataMember]
        public virtual string Dose_Timing
        {
            get { return _Dose_Timing; }
            set
            {
                _Dose_Timing = value;
            }
        }
        [DataMember]
        public virtual string Dose_Other
        {
            get { return _Dose_Other; }
            set
            {
                _Dose_Other = value;
            }
        }
        [DataMember]
        public virtual string Duration
        {
            get { return _Duration; }
            set
            {
                _Duration = value;
            }
        }
        [DataMember]
        public virtual string Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
            }
        }
        [DataMember]
        public virtual string Quantity_Unit
        {
            get { return _Quantity_Unit; }
            set
            {
                _Quantity_Unit = value;
            }
        }
        [DataMember]
        public virtual string Refills
        {
            get { return _Refills; }
            set
            {
                _Refills = value;
            }
        }
        [DataMember]
        public virtual string Substitution_Permitted
        {
            get { return _Substitution_Permitted; }
            set
            {
                _Substitution_Permitted = value;
            }
        }
        [DataMember]
        public virtual string Other_Notes
        {
            get { return _Other_Notes; }
            set
            {
                _Other_Notes = value;
            }
        }
        [DataMember]
        public virtual string Patient_Notes
        {
            get { return _Patient_Notes; }
            set
            {
                _Patient_Notes = value;
            }
        }
        [DataMember]
        public virtual string Comments
        {
            get { return _Comments; }
            set
            {
                _Comments = value;
            }
        }
        [DataMember]
        public virtual DateTime Completed_Date
        {
            get { return _Completed_Date; }
            set
            {
                _Completed_Date = value;
            }
        }
        [DataMember]
        public virtual DateTime Stop_Date
        {
            get { return _Stop_Date; }
            set
            {
                _Stop_Date = value;
            }
        }
        [DataMember]
        public virtual DateTime Signed_Date
        {
            get { return _Signed_Date; }
            set
            {
                _Signed_Date = value;
            }
        }
        [DataMember]
        public virtual string Last_Modified_By
        {
            get { return _Last_Modified_By; }
            set
            {
                _Last_Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Last_Modified_Date
        {
            get { return _Last_Modified_Date; }
            set
            {
                _Last_Modified_Date = value;
            }
        }
        [DataMember]
        public virtual string Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
            }
        }
        [DataMember]
        public virtual string Weight
        {
            get { return _Weight; }
            set
            {
                _Weight = value;
            }
        }
        [DataMember]
        public virtual string Intended_Use
        {
            get { return _Intended_Use; }
            set
            {
                _Intended_Use = value;
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
        public virtual DateTime Modified_Date_And_time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual string Brand_Type
        {
            get { return _Brand_Type; }
            set
            {
                _Brand_Type = value;
            }
        }
        [DataMember]
        public virtual string Prescription_Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
            }
        }
        [DataMember]
        public virtual string ICD_Code
        {
            get { return _ICD_Code; }
            set
            {
                _ICD_Code = value;
            }
        }
        [DataMember]
        public virtual string ICD_Code_Description
        {
            get { return _ICD_Code_Description; }
            set
            {
                _ICD_Code_Description = value;
            }
        }
        [DataMember]
        public virtual string Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }
        [DataMember]
        public virtual int Formulary_ID
        {
            get { return _Formulary_ID; }
            set
            {
                _Formulary_ID = value;
            }
        }
        [DataMember]
        public virtual string Electronic
        {
            get { return _Electronic; }
            set { _Electronic = value; }
        }
        #endregion

    }
}
