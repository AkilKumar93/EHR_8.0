
using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Immunization : BusinessBase<ulong>
    { 
        #region Declarations

        private string _Procedure_Code = string.Empty;
        private string _CVXcode = string.Empty;
        private string _Immunization_Description = string.Empty;
        private ulong _Human_ID=0;
        private ulong _Physician_ID=0;
        private ulong _Encounter_ID=0;
        private ulong _Dose=0;
        private ulong _Doseno=0;
        private string _GivenBy = string.Empty;
        private string _Location = string.Empty;
        private string _ImmunizationSource = string.Empty;
        private string _LotNumber = string.Empty;
        private string _Manufacturer = string.Empty;
        private DateTime _DateonVis = DateTime.MinValue;
        private string _RouteofAdministration = string.Empty;
        private string _Notes = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Visit_Date = DateTime.MinValue;
        private DateTime _Expiry_Date = DateTime.MinValue;
        private DateTime _VIS_Given_Date = DateTime.MinValue;
        private DateTime _Given_Date = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Vfc = string.Empty;
        private int _iVersion=0;
        private string _Is_VIS_Given = string.Empty;
        private string _Authorization_Required = string.Empty;
        private string _MVX_Code = string.Empty;
        private string _Administration_Unit = string.Empty;
        private decimal _Administered_Amount = 0;
        private string _CVX_Code_description = string.Empty;
        private string _Administered_Unit_Identifier = string.Empty;
        private string _Vaccine_In_House = string.Empty;
        private string _Facility_Name = string.Empty;
        private ulong _Immun_Group_ID = 0;
        private string _NDC = string.Empty;
        private string _file_management_index_id = string.Empty;
        private string _Internal_Property_File_Name = string.Empty;
        private string _vaccine_Type = string.Empty;


        private string _Refused_Administration = string.Empty;
        private string _Eligibility_Captured = string.Empty;
        private string _Immunization_Information_Source = string.Empty;
        private string _Observation = string.Empty;
        private string  _Is_Administration_Refused = string.Empty;
        private string _Immunization_Evidence = string.Empty;
        private string _Snomed_Code = string.Empty;
        private string _Document_Type = string.Empty;
        private string _Is_Deleted = string.Empty;

        #endregion

        #region Constructors

        public Immunization() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Procedure_Code);
            sb.Append(_CVXcode);
            sb.Append(_Immunization_Description);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Dose);
            sb.Append(_Doseno);
            sb.Append(_GivenBy);
            sb.Append(_Location);
            sb.Append(_LotNumber);
            sb.Append(_Manufacturer);
            sb.Append(_DateonVis);
            sb.Append(_RouteofAdministration);
            sb.Append(_Notes);
            sb.Append(_ImmunizationSource);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Visit_Date);
            sb.Append(_Expiry_Date);
            sb.Append(_VIS_Given_Date);
            sb.Append(_Given_Date);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Vfc);
            sb.Append(_iVersion);
            sb.Append(_Is_VIS_Given);
            sb.Append(_Authorization_Required);
            sb.Append(_MVX_Code);
            sb.Append(_Administration_Unit);
            sb.Append(_Administered_Amount);
            sb.Append(_CVX_Code_description);
            sb.Append(_Administered_Unit_Identifier);
            sb.Append(_Vaccine_In_House);
            sb.Append(_Facility_Name);
            sb.Append(_Immun_Group_ID);
            sb.Append(_NDC);
            sb.Append(_file_management_index_id);
            sb.Append(_vaccine_Type);
            sb.Append(_Immunization_Evidence);
            sb.Append(_Snomed_Code);
            sb.Append(_Document_Type);
            sb.Append(_Is_Deleted);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties
        
       
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
        public virtual string CVX_Code
        {
            get { return _CVXcode; }
            set
            {
                _CVXcode = value;
            }
        }
        [DataMember]
        public virtual string Immunization_Description
        {
            get { return _Immunization_Description; }
            set
            {
                _Immunization_Description = value;
            }
        }
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
        public virtual ulong Physician_Id
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Encounter_Id
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Dose_No
        {
            get { return _Doseno; }
            set
            {
                _Doseno = value;
            }
        }
        [DataMember]
        public virtual string Lot_Number
        {
            get { return _LotNumber; }
            set
            {
                _LotNumber = value;
            }
        }
        [DataMember]
        public virtual ulong Dose
        {
            get { return _Dose; }
            set
            {
                _Dose = value;
            }
        }
        [DataMember]
        public virtual string Given_By
        {
            get { return _GivenBy; }
            set
            {
                _GivenBy = value;
            }
        }
        [DataMember]
        public virtual string Immunization_Source
        {
            get { return _ImmunizationSource; }
            set
            {
                _ImmunizationSource = value;
            }
        }
        [DataMember]
        public virtual string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
            }
        }
        [DataMember]
        public virtual string Manufacturer
        {
            get { return _Manufacturer; }
            set
            {
                _Manufacturer = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Date_on_Vis
        {
            get { return _DateonVis; }
            set
            {
                _DateonVis = value;
            }
        }
        [DataMember]
        public virtual string Route_of_Administration
        {
            get { return _RouteofAdministration; }
            set
            {
                _RouteofAdministration = value;
            }
        }
        [DataMember]
        public virtual string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
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
        public virtual System.DateTime Created_Date_And_Time

        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Visit_Date
        {
            get { return _Visit_Date; }
            set
            {
                _Visit_Date = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Expiry_Date
        {
            get { return _Expiry_Date; }
            set
            {
                _Expiry_Date = value;
            }
        }
        [DataMember]
        public virtual System.DateTime VIS_Given_Date
        {
            get { return _VIS_Given_Date; }
            set
            {
                _VIS_Given_Date = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Given_Date
        {
            get { return _Given_Date; }
            set
            {
                _Given_Date = value;
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
        public virtual System.DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Vfc
        {
            get { return _Vfc; }
            set
            {
                _Vfc = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _iVersion; }
            set { _iVersion = value; }
        }
        [DataMember]
        public virtual string Is_VIS_Given
        {
            get { return _Is_VIS_Given; }
            set
            {
                _Is_VIS_Given = value;
            }
        }
        [DataMember]
        public virtual string Authorization_Required
        {
            get { return _Authorization_Required; }
            set { _Authorization_Required = value; }
        }

        [DataMember]
        public virtual string MVX_Code
        {
            get { return _MVX_Code; }
            set { _MVX_Code = value; }
        }

        [DataMember]
        public virtual string Administered_Unit
        {
            get { return _Administration_Unit; }
            set { _Administration_Unit = value; }
        }

        [DataMember]
        public virtual decimal Administered_Amount
        {
            get { return _Administered_Amount; }
            set { _Administered_Amount = value; }
        }


        [DataMember]
        public virtual string CVX_Code_Description
        {
            get { return _CVX_Code_description; }
            set
            {
                _CVX_Code_description = value;
            }
        }

        [DataMember]
        public virtual string Administered_Unit_Identifier
        {
            get { return _Administered_Unit_Identifier; }
            set
            {
                _Administered_Unit_Identifier = value;
            }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set
            {
                _Facility_Name = value;
            }
        }

        [DataMember]
        public virtual ulong Immunization_Group_ID
        {
            get { return _Immun_Group_ID; }
            set
            {
                _Immun_Group_ID = value;
            }
        }

        [DataMember]
        public virtual string Vaccine_In_House
        {
            get { return _Vaccine_In_House; }
            set
            {
                _Vaccine_In_House = value;
            }
        }

        [DataMember]
        public virtual string NDC
        {
            get { return _NDC; }
            set
            {
                _NDC = value;
            }
        }


        [DataMember]
        public virtual string File_Management_Index_Id
        {
            get { return _file_management_index_id ; }
            set
            {
                _file_management_index_id = value;
            }
        }

        [DataMember]
        public virtual string Internal_Property_FileName
        {
            get { return _Internal_Property_File_Name ; }
            set
            {
                _Internal_Property_File_Name = value;
            }
        }


        [DataMember]
        public virtual string Vaccine_Type
        {
            get { return _vaccine_Type; }
            set
            {
                _vaccine_Type = value;
            }
        }


      


        [DataMember]
        public virtual string Refused_Administration
        {
            get { return _Refused_Administration; }
            set
            {
                _Refused_Administration = value;
            }
        }


        [DataMember]
        public virtual string Eligibility_Captured
        {
            get { return _Eligibility_Captured; }
            set
            {
                _Eligibility_Captured = value;
            }
        }


        [DataMember]
        public virtual string Immunization_Information_Source
        {
            get { return _Immunization_Information_Source; }
            set
            {
                _Immunization_Information_Source = value;
            }
        }


        [DataMember]
        public virtual string Observation
        {
            get { return _Observation; }
            set
            {
                _Observation = value;
            }
        }


        [DataMember]
        public virtual string Is_Administration_Refused
        {
            get { return _Is_Administration_Refused; }
            set
            {
                _Is_Administration_Refused=value;
            }
        }
        [DataMember]
        public virtual string Immunization_Evidence
        {
            get { return _Immunization_Evidence; }
            set
            {
                _Immunization_Evidence = value;
            }
        }
        [DataMember]
        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set
            {
                _Snomed_Code = value;
            }
        }
        [DataMember]
        public virtual string Document_Type
        {
            get { return _Document_Type; }
            set
            {
                _Document_Type = value;
            }
        }
        [DataMember]
        public virtual string Is_Deleted
        {
            get { return _Is_Deleted; }
            set
            {
                _Is_Deleted = value;
            }
        }
        #endregion
    }
}
