using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Rcopia_Medication : BusinessBase<ulong>,ICloneable
    {
        #region Declarations

        
        private ulong _Human_ID=0;
        private ulong _Encounter_ID = 0;
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
        private DateTime _Start_Date = DateTime.MinValue;
        private DateTime _Stop_Date = DateTime.MinValue;
        private DateTime _Fill_Date = DateTime.MinValue;
        private string _Stop_Reason = string.Empty;
        private DateTime _Sig_Changed_Date = DateTime.MinValue;
        private string _Last_Modified_By = string.Empty;
        private DateTime _Last_Modified_Date = DateTime.MinValue;
        private string _Height = string.Empty;
        private string _Weight = string.Empty;
        private string _Intended_Use = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version=0;

        private string _Medication_Order = string.Empty;
        private string _ICD_Code = string.Empty;
        private string _ICD_Code_Description = string.Empty;
        private string _Deleted=string.Empty ;

        private string _Pharmacy_Name = string.Empty;
        private string _Pharmacy_Address1 = string.Empty;
        private string _Pharmacy_Address2 = string.Empty;
        private string _Pharmacy_CrossStreet = string.Empty;
        private string _Pharmacy_City = string.Empty;
        private string _Pharmacy_State = string.Empty;

        private string _Pharmacy_Zip = string.Empty;
        private string _Pharmacy_Phone = string.Empty;
        private string _Pharmacy_Fax = string.Empty;
        private string _Pharmacy_Is24Hour = string.Empty;
        private string _Pharmacy_Level3 = string.Empty;
        private string _Pharmacy_Electronic = string.Empty;
        private string _Internal_Property_Code = string.Empty;
        private ulong _Rxnorm_ID = 0;
        private string _Rxnorm_ID_Type = string.Empty;
        private string _DataFrom = string.Empty;
        private string _Facility_Name = string.Empty;


        private ulong _Rx_Order_ID = 0;
        private string _Frequency = string.Empty;
        private string _Is_Medication_Discontinued = string.Empty;
        private string _Reason_For_Medication_Discontinued = string.Empty;

        private string _Stop_Notes = string.Empty;
        private string _Retain_Notes = string.Empty;
        private string _Status = string.Empty;
        private string _Provider_Rcopia_User_Name = string.Empty;
        private string _Preparer_Rcopia_User_Name = string.Empty;
        
        


        #endregion

        #region Constructors

        public Rcopia_Medication() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Rx_Order_ID);
            sb.Append(_Frequency);
            sb.Append(_Is_Medication_Discontinued);
            sb.Append(_Reason_For_Medication_Discontinued);

            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
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
            sb.Append(_Start_Date);
            sb.Append(_Stop_Date);
            sb.Append(_Fill_Date);
            sb.Append(_Stop_Reason);
            sb.Append(_Sig_Changed_Date);
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
            sb.Append(_Medication_Order);
            sb.Append(_ICD_Code);
            sb.Append(_ICD_Code_Description);
            sb.Append(_Deleted);


            sb.Append(_Pharmacy_Name);
            sb.Append(_Pharmacy_Address1);
            sb.Append(_Pharmacy_Address2);
            sb.Append(_Pharmacy_CrossStreet);
            sb.Append(_Pharmacy_City);
            sb.Append(_Pharmacy_State);
            sb.Append(_Pharmacy_Zip);
            sb.Append(_Pharmacy_Phone);
            sb.Append(_Pharmacy_Fax);
            sb.Append(_Pharmacy_Is24Hour);
            sb.Append(_Pharmacy_Level3);
            sb.Append(_Pharmacy_Electronic);
            sb.Append(_Internal_Property_Code);
            sb.Append(_Rxnorm_ID);
            sb.Append(_Rxnorm_ID_Type);
            sb.Append(_DataFrom);
            sb.Append(_Facility_Name);

            sb.Append(_Stop_Notes);
            sb.Append(_Retain_Notes);
            sb.Append(_Status);
            sb.Append(_Provider_Rcopia_User_Name);
            sb.Append(_Preparer_Rcopia_User_Name);
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
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
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
        public virtual DateTime Start_Date
        {
            get { return _Start_Date; }
            set
            {
                _Start_Date = value;
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
        public virtual DateTime Fill_Date
        {
            get { return _Fill_Date; }
            set
            {
                _Fill_Date = value;
            }
        }
        [DataMember]
        public virtual string Stop_Reason
        {
            get { return _Stop_Reason; }
            set
            {
                _Stop_Reason = value;
            }
        }
        [DataMember]
        public virtual DateTime Sig_Changed_Date
        {
            get { return _Sig_Changed_Date; }
            set
            {
                _Sig_Changed_Date = value;
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
        public virtual DateTime Modified_Date_And_Time
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
        public virtual string Medication_Order
        {
            get { return _Medication_Order; }
            set
            {
                _Medication_Order = value;
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
        public virtual string Pharmacy_Name
        {
            get { return _Pharmacy_Name; }
            set { _Pharmacy_Name = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Address1
        {
            get { return _Pharmacy_Address1; }
            set { _Pharmacy_Address1 = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Address2
        {
            get { return _Pharmacy_Address2; }
            set { _Pharmacy_Address2 = value; }
        }
        [DataMember]
        public virtual string Pharmacy_CrossStreet
        {
            get { return _Pharmacy_CrossStreet; }
            set { _Pharmacy_CrossStreet = value; }
        }
        [DataMember]
        public virtual string Pharmacy_City
        {
            get { return _Pharmacy_City; }
            set { _Pharmacy_City = value; }
        }
        [DataMember]
        public virtual string Pharmacy_State
        {
            get { return _Pharmacy_State; }
            set { _Pharmacy_State = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Zip
        {
            get { return _Pharmacy_Zip; }
            set { _Pharmacy_Zip = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Phone
        {
            get { return _Pharmacy_Phone; }
            set { _Pharmacy_Phone = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Fax
        {
            get { return _Pharmacy_Fax; }
            set { _Pharmacy_Fax = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Is24Hour
        {
            get { return _Pharmacy_Is24Hour; }
            set { _Pharmacy_Is24Hour = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Level3
        {
            get { return _Pharmacy_Level3; }
            set { _Pharmacy_Level3 = value; }
        }
        [DataMember]
        public virtual string Pharmacy_Electronic
        {
            get { return _Pharmacy_Electronic; }
            set { _Pharmacy_Electronic = value; }
        }
        [DataMember]
        public virtual string Internal_Property_Code
        {
            get { return _Internal_Property_Code; }
            set { _Internal_Property_Code = value; }
        }
       
        [DataMember]
        public virtual ulong Rxnorm_ID
        {
            get { return _Rxnorm_ID; }
            set
            {
                _Rxnorm_ID = value;
            }
        }
        [DataMember]
        public virtual string Rxnorm_ID_Type
        {
            get { return _Rxnorm_ID_Type; }
            set { _Rxnorm_ID_Type = value; }
        }
        [DataMember]
        public virtual string DataFrom
        {
            get { return _DataFrom; }
            set { _DataFrom = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }

        [DataMember]
        public virtual string Reason_For_Medication_Discontinued
        {
            get { return _Reason_For_Medication_Discontinued; }
            set { _Reason_For_Medication_Discontinued = value; }
        }
        [DataMember]
        public virtual string Is_Medication_Discontinued
        {
            get { return _Is_Medication_Discontinued; }
            set { _Is_Medication_Discontinued = value; }
        }
        [DataMember]
        public virtual string Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        [DataMember]
        public virtual ulong Rx_Order_ID
        {
            get { return _Rx_Order_ID; }
            set { _Rx_Order_ID = value; }
        }

        [DataMember]
        public virtual string Stop_Notes
        {
            get { return _Stop_Notes; }
            set { _Stop_Notes = value; }
        }
        [DataMember]
        public virtual string Retain_Notes
        {
            get { return _Retain_Notes; }
            set { _Retain_Notes = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [DataMember]
        public virtual string Provider_Rcopia_User_Name
        {
            get { return _Provider_Rcopia_User_Name; }
            set { _Provider_Rcopia_User_Name = value; }
        }
        [DataMember]
        public virtual string Preparer_Rcopia_User_Name
        {
            get { return _Preparer_Rcopia_User_Name; }
            set { _Preparer_Rcopia_User_Name = value; }
        }


        #endregion

        #region Methods
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
