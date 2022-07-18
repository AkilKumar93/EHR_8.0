using System;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class InHouseProcedure : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Encounter_ID=0;
        private ulong _Human_ID=0;
        private ulong _Physician_ID=0;
        private string _Procedure_Code = string.Empty;
        private string _Procedure_Code_Description = string.Empty;
        private string _Notes = String.Empty;
        private string _Created_By = String.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _iVersion=0;
        private string _Authorization_Required = string.Empty;
        private string _FacName = string.Empty;
        private ulong _In_House_Group_ID = 0;
        private string _Internal_Property_Results_File_Name = string.Empty;//4-2-12
        private string _file_management_id = string.Empty;
        private string _Internal_Property_FileName = string.Empty;
        private string _Device_Identifier_UDI = string.Empty;
        private string _Device_Identifier_DI = string.Empty;
        private string _Serial_Number = string.Empty;
        private string _Lot_or_Batch = string.Empty;
        private string _Manufactured_Date = string.Empty;
        private string _Expiration_Date = string.Empty;
        private string _Distinct_ID = string.Empty;
        private string _Issuing_Agency = string.Empty;
        private string _Brand_Name = string.Empty;
        private string _Version_Model = string.Empty;
        private string _Company_Name = string.Empty;
        private string _MRI_Safety_Status = string.Empty;
        private string _GMDN_PT_Name = string.Empty;
        private string _Description = string.Empty;
        private string _Rubber_Content = string.Empty;
        private string _Is_Active = string.Empty;
        private string _GMDN_PT_Definition = string.Empty;
        
        #endregion

        #region Constructors

        public InHouseProcedure() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Procedure_Code);
            sb.Append(_Procedure_Code_Description);
            sb.Append(_Notes);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_iVersion);
            sb.Append(_Authorization_Required);
            sb.Append(_FacName);
            sb.Append(_In_House_Group_ID);
            sb.Append(_file_management_id);
            sb.Append(_Internal_Property_Results_File_Name);
            sb.Append(_Device_Identifier_UDI);
            sb.Append(_Device_Identifier_DI);
            sb.Append(_Serial_Number);
            sb.Append(_Lot_or_Batch);
            sb.Append(_Manufactured_Date);
            sb.Append(_Expiration_Date);
            sb.Append(_Distinct_ID);
            sb.Append(_Issuing_Agency);
            sb.Append(_Brand_Name);
            sb.Append(_Version_Model);
            sb.Append(_Company_Name);
            sb.Append(_MRI_Safety_Status);
            sb.Append(_GMDN_PT_Name);
            sb.Append(_Description);
            sb.Append(_Rubber_Content);
            sb.Append(_Is_Active);
            sb.Append(_GMDN_PT_Definition);
            
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
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
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
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
        public virtual string Procedure_Code_Description
        {
            get { return _Procedure_Code_Description; }
            set
            {
                _Procedure_Code_Description = value;
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
            get { return _iVersion; }
            set { _iVersion = value; }
        }


        [DataMember]
        public virtual string Authorization_Required
        {
            get { return _Authorization_Required; }
            set { _Authorization_Required = value; }
        }

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _FacName; }
            set
            {
                _FacName = value;
            }
        }

        [DataMember]
        public virtual ulong In_House_Procedure_Group_ID
        {
            get { return _In_House_Group_ID; }
            set
            {
                _In_House_Group_ID = value;
            }
        }
        [DataMember]
        public virtual string Internal_Property_Results_File_Name
        {
            get { return _Internal_Property_Results_File_Name; }
            set
            {
                _Internal_Property_Results_File_Name = value;
            }
        }


        [DataMember]
        public virtual string File_Management_Index_ID
        {
            get { return _file_management_id; }
            set
            {
                _file_management_id = value;
            }
        }

        [DataMember]
        public virtual string Internal_Property_File_Name
        {
            get { return _Internal_Property_FileName ; }
            set
            {
                _Internal_Property_FileName = value;
            }
        }

        [DataMember]
        public virtual string Device_Identifier_UDI
        {
            get { return _Device_Identifier_UDI; }
            set
            {
                _Device_Identifier_UDI = value;
            }
        }

        [DataMember]
        public virtual string Device_Identifier_DI
        {
            get { return _Device_Identifier_DI; }
            set
            {
                _Device_Identifier_DI = value;
            }
        }

        [DataMember]
        public virtual string Serial_Number
        {
            get { return _Serial_Number; }
            set
            {
                _Serial_Number = value;
            }
        }

        [DataMember]
        public virtual string Lot_or_Batch
        {
            get { return _Lot_or_Batch; }
            set
            {
                _Lot_or_Batch = value;
            }
        }

        [DataMember]
        public virtual string Manufactured_Date
        {
            get { return _Manufactured_Date; }
            set
            {
                _Manufactured_Date = value;
            }
        }

        [DataMember]
        public virtual string Expiration_Date
        {
            get { return _Expiration_Date; }
            set
            {
                _Expiration_Date = value;
            }
        }

        [DataMember]
        public virtual string Distinct_ID
        {
            get { return _Distinct_ID; }
            set
            {
                _Distinct_ID = value;
            }
        }


        [DataMember]
        public virtual string Issuing_Agency
        {
            get { return _Issuing_Agency; }
            set
            {
                _Issuing_Agency = value;
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
        public virtual string Version_Model
        {
            get { return _Version_Model; }
            set
            {
                _Version_Model = value;
            }
        }

        [DataMember]
        public virtual string Company_Name
        {
            get { return _Company_Name; }
            set
            {
                _Company_Name = value;
            }
        }

        [DataMember]
        public virtual string MRI_Safety_Status
        {
            get { return _MRI_Safety_Status; }
            set
            {
                _MRI_Safety_Status = value;
            }
        }

        [DataMember]
        public virtual string GMDN_PT_Name
        {
            get { return _GMDN_PT_Name; }
            set
            {
                _GMDN_PT_Name = value;
            }
        }



        [DataMember]
        public virtual string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public virtual string Rubber_Content
        {
            get { return _Rubber_Content; }
            set
            {
                _Rubber_Content = value;
            }
        }

        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set
            {
                _Is_Active = value;
            }
        }


          [DataMember]
        public virtual string GMDN_PT_Definition
        {
            get { return _GMDN_PT_Definition; }
            set
            {
                _GMDN_PT_Definition = value;
            }
        }
        

        #endregion


    }
}
