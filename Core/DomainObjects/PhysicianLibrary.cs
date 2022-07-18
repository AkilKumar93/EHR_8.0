using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class PhysicianLibrary : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _PhyRecID = 0;
        private string _PhyPrefix = string.Empty;
        private string _PhyFName = string.Empty;
        private string _PhyMName = string.Empty;
        private string _PhyLName = string.Empty;
        private string _PhySuffix = string.Empty;
        private string _PhyPrimaryCodeType = string.Empty;
        private string _PhyPrimaryIDCode = string.Empty;
        private string _PhyAddress1 = string.Empty;
        private string _PhyAddress2 = string.Empty;
        private string _PhyCity = string.Empty;
        private string _PhyState = string.Empty;
        private string _PhyZip = string.Empty;
        private string _PhyTelephone = string.Empty;
        private string _PhyFax = string.Empty;
        private string _PhyEMail = string.Empty;
        private string _PhyType = string.Empty;
        private string _PhyNotes = string.Empty;
        private string _PhyNPI = string.Empty;
        private string _PhyQual = string.Empty;
        private string _PhyOtherID = string.Empty;
        private DateTime _ChangedDateAndTime = DateTime.MinValue;
        private DateTime _CreatedDateAndTime = DateTime.MinValue;
        private string _PhyColor = string.Empty;
        private string _PhyTemplate = string.Empty;
        private int _version = 0;
        private string _State_License_Number = string.Empty;
        private string _Group_Tax_ID_Number = string.Empty;
        private string _Medicare_Provider_Number_CCN_Number = string.Empty;
        private string _MediCal_Provider_Number = string.Empty;
        private string _MediCal_Submitter_Number = string.Empty;
        private string _Physician_SSN = string.Empty;
        private string _Physician_Number1 = string.Empty;
        private string _Physician_Number2 = string.Empty;
        private string _Physician_Number3 = string.Empty;
        private string _Physician_Number4 = string.Empty;
        private int _sort_order = 0;
        //private int _Insurance_Plan_ID = 0;
        //private string _Policy_Holder_ID = string.Empty;
        private string _Category = string.Empty;
        private string _Encounter_Mode = string.Empty;
        private string _Med_Phy_Assistant = string.Empty;
        private string _Is_Active = string.Empty;
        private DateTime _Encounter_Date_of_Service = DateTime.MinValue;
        private string _Physician_Password = string.Empty;
        private string _PhyUserName = string.Empty;
        private string _Taxonomy_Code = string.Empty;
        private string _Taxonomy_Description = string.Empty;
        private string _Physician_EMail_Password = string.Empty;
        private string _Physician_EMail_Port = string.Empty;
        private string _Physician_Other_EMail_Username = string.Empty;
        private string _Physician_Other_EMail_Password = string.Empty;
        private string _Physician_Other_EMail_Port = string.Empty;
        private string _Company = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private string _Mail_Server_Address = string.Empty;

        private string _Physician_MDoffice_EMail_Username = string.Empty;

        private string _Physician_MDoffice_EMail_Password = string.Empty;

        private string _Physician_Other_EMail_Server_Address = string.Empty;



        
        #endregion

        #region Constructors

        public PhysicianLibrary() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_PhyRecID);
            sb.Append(_PhyPrefix);
            sb.Append(_PhyFName);
            sb.Append(_PhyLName);
            sb.Append(_PhyMName);
            sb.Append(_PhySuffix);
            sb.Append(_PhyPrimaryCodeType = string.Empty);
            sb.Append(_PhyPrimaryIDCode = string.Empty);
            sb.Append(_PhyAddress1 = string.Empty);
            sb.Append(_PhyAddress2 = string.Empty);
            sb.Append(_PhyCity = string.Empty);
            sb.Append(_PhyState = string.Empty);
            sb.Append(_PhyZip = string.Empty);
            sb.Append(_PhyTelephone = string.Empty);
            sb.Append(_PhyFax = string.Empty);
            sb.Append(_PhyEMail = string.Empty);
            sb.Append(_PhyType = string.Empty);
            sb.Append(_PhyNotes = string.Empty);
            sb.Append(_PhyNPI = string.Empty);
            sb.Append(_PhyQual = string.Empty);
            sb.Append(_PhyOtherID = string.Empty);
            sb.Append(_ChangedDateAndTime);
            sb.Append(_CreatedDateAndTime);
            sb.Append(_PhyColor = string.Empty);
            sb.Append(_PhyTemplate = string.Empty);
            sb.Append(_State_License_Number = string.Empty);
            sb.Append(_Group_Tax_ID_Number = string.Empty);
            sb.Append(_Medicare_Provider_Number_CCN_Number = string.Empty);
            sb.Append(_MediCal_Provider_Number = string.Empty);
            sb.Append(_MediCal_Submitter_Number = string.Empty);
            sb.Append(_Physician_SSN = string.Empty);
            sb.Append(_Physician_Number1 = string.Empty);
            sb.Append(_Physician_Number2 = string.Empty);
            sb.Append(_Physician_Number3 = string.Empty);
            sb.Append(_Physician_Number4 = string.Empty);
            sb.Append(_version);
            sb.Append(_Category);
            sb.Append(_Encounter_Mode);
            sb.Append(_Med_Phy_Assistant);
            sb.Append(_Is_Active);
            sb.Append(_Encounter_Date_of_Service);
            sb.Append(_Physician_Password);
            sb.Append(_PhyUserName);
            sb.Append(_Taxonomy_Code);
            sb.Append(_Taxonomy_Description);
            sb.Append(_Physician_EMail_Password);
            sb.Append(_Physician_EMail_Port);
            sb.Append(_Physician_Other_EMail_Username);
            sb.Append(_Physician_Other_EMail_Password);
            sb.Append(_Physician_Other_EMail_Port);
            sb.Append(_Company);
            sb.Append(_Created_By);
            sb.Append(_Modified_By);
            sb.Append(_Mail_Server_Address);
            sb.Append(_Physician_MDoffice_EMail_Username);
            sb.Append(_Physician_MDoffice_EMail_Password);
            sb.Append(_Physician_Other_EMail_Server_Address);

            
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong PhyId
        {
            get { return _PhyRecID; }
            set
            {
                _PhyRecID = value;
            }
        }
        [DataMember]
        public virtual string Mail_Server_Address
        {
            get { return _Mail_Server_Address; }
            set
            {
                _Mail_Server_Address = value;
            }
        }
        [DataMember]
        public virtual string PhyPrefix
        {
            get { return _PhyPrefix; }
            set
            {
                _PhyPrefix = value;
            }
        }
        [DataMember]
        public virtual string PhyFirstName
        {
            get { return _PhyFName; }
            set
            {
                _PhyFName = value;
            }
        }
        [DataMember]
        public virtual string PhyMiddleName
        {
            get { return _PhyMName; }
            set
            {
                _PhyMName = value;
            }
        }
        [DataMember]
        public virtual string PhyLastName
        {

            get { return _PhyLName; }
            set
            {
                _PhyLName = value;
            }
        }
        [DataMember]
        public virtual string PhySuffix
        {
            get { return _PhySuffix; }
            set
            {
                _PhySuffix = value;
            }
        }
        [DataMember]
        public virtual string PhyPrimaryCodeType
        {
            get { return _PhyPrimaryCodeType; }
            set
            {
                _PhyPrimaryCodeType = value;
            }
        }
        [DataMember]
        public virtual string PhyPrimaryIDCode
        {
            get { return _PhyPrimaryIDCode; }
            set
            {
                _PhyPrimaryIDCode = value;
            }
        }
        [DataMember]
        public virtual string PhyAddress1
        {
            get { return _PhyAddress1; }
            set
            {
                _PhyAddress1 = value;
            }
        }
        [DataMember]
        public virtual string PhyAddress2
        {
            get { return _PhyAddress2; }
            set
            {
                _PhyAddress2 = value;
            }
        }
        [DataMember]
        public virtual string PhyCity
        {
            get { return _PhyCity; }
            set
            {
                _PhyCity = value;
            }
        }
        [DataMember]
        public virtual string PhyState
        {
            get { return _PhyState; }
            set
            {
                _PhyState = value;
            }
        }
        [DataMember]
        public virtual string PhyZip
        {
            get { return _PhyZip; }
            set
            {
                _PhyZip = value;
            }
        }

        [DataMember]
        public virtual string PhyTelephone
        {
            get { return _PhyTelephone; }
            set
            {
                _PhyTelephone = value;
            }
        }
        [DataMember]
        public virtual string PhyFax
        {
            get { return _PhyFax; }
            set
            {
                _PhyFax = value;
            }
        }
        [DataMember]
        public virtual string PhyEMail
        {
            get { return _PhyEMail; }
            set
            {
                _PhyEMail = value;
            }
        }
        [DataMember]
        public virtual string PhyType
        {
            get { return _PhyType; }
            set
            {
                _PhyType = value;
            }
        }
        [DataMember]
        public virtual string PhyNotes
        {
            get { return _PhyNotes; }
            set
            {
                _PhyNotes = value;
            }
        }
        [DataMember]
        public virtual string PhyNPI
        {
            get { return _PhyNPI; }
            set
            {
                _PhyNPI = value;
            }
        }
        [DataMember]
        public virtual string PhyQual
        {
            get { return _PhyQual; }
            set
            {
                _PhyQual = value;
            }
        }
        [DataMember]
        public virtual string PhyOtherID
        {
            get { return _PhyOtherID; }
            set
            {
                _PhyOtherID = value;
            }
        }
        [DataMember]
        public virtual DateTime ChangedDateAndTime
        {
            get { return _ChangedDateAndTime; }
            set
            {
                _ChangedDateAndTime = value;
            }
        }
        [DataMember]
        public virtual DateTime CreatedDateAndTime
        {
            get { return _CreatedDateAndTime; }
            set
            {
                _CreatedDateAndTime = value;
            }
        }
        [DataMember]
        public virtual string PhyColor
        {
            get { return _PhyColor; }
            set
            {
                _PhyColor = value;
            }
        }
        [DataMember]
        public virtual string PhyTemplate
        {
            get { return _PhyTemplate; }
            set
            {
                _PhyTemplate = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set
            {
                _version = value;
            }
        }

        [DataMember]
        public virtual string State_License_Number
        {
            get { return _State_License_Number; }
            set
            {
                _State_License_Number = value;
            }
        }

        [DataMember]
        public virtual string Group_TaxID_Number
        {
            get { return _Group_Tax_ID_Number; }
            set
            {
                _Group_Tax_ID_Number = value;
            }
        }

        [DataMember]
        public virtual string Medicare_Provider_Number_or_CCN_Number
        {
            get { return _Medicare_Provider_Number_CCN_Number; }
            set
            {
                _Medicare_Provider_Number_CCN_Number = value;
            }
        }

        [DataMember]
        public virtual string Medical_Provider_Number
        {
            get { return _MediCal_Provider_Number; }
            set
            {
                _MediCal_Provider_Number = value;
            }
        }

        [DataMember]
        public virtual string Medical_Submitter_Number
        {
            get { return _MediCal_Submitter_Number; }
            set
            {
                _MediCal_Submitter_Number = value;
            }
        }

        [DataMember]
        public virtual string Physician_SSN_Number
        {
            get { return _Physician_SSN; }
            set
            {
                _Physician_SSN = value;
            }
        }

        [DataMember]
        public virtual string Physician_Number1
        {
            get { return _Physician_Number1; }
            set
            {
                _Physician_Number1 = value;
            }
        }

        [DataMember]
        public virtual string Physician_Number2
        {
            get { return _Physician_Number2; }
            set
            {
                _Physician_Number2 = value;
            }
        }

        [DataMember]
        public virtual string Physician_Number3
        {
            get { return _Physician_Number3; }
            set
            {
                _Physician_Number3 = value;
            }
        }

        [DataMember]
        public virtual string Physician_Number4
        {
            get { return _Physician_Number4; }
            set
            {
                _Physician_Number4 = value;
            }
        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _sort_order; }
            set { _sort_order = value; }
        }
        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        [DataMember]
        public virtual string Encounter_Mode
        {
            get { return _Encounter_Mode; }
            set { _Encounter_Mode = value; }
        }
        // [DataMember]
        // public virtual int Insurance_Plan_ID    
        // {
        //     get { return _Insurance_Plan_ID; }
        //     set { _Insurance_Plan_ID = value; }
        // }
        //[DataMember]
        // public virtual string Policy_Holder_ID 
        // {
        //     get { return _Policy_Holder_ID; }
        //     set { _Policy_Holder_ID = value; }
        // }
        [DataMember]
        public virtual string Med_Phy_Assistant
        {
            get { return _Med_Phy_Assistant; }
            set { _Med_Phy_Assistant = value; }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }

        [DataMember]
        public virtual DateTime Encounter_Date_of_Service
        {
            get { return _Encounter_Date_of_Service; }
            set
            {
                _Encounter_Date_of_Service = value;
            }
        }
        [DataMember]
        public virtual string Physician_Password
        {
            get { return _Physician_Password; }
            set
            {
                _Physician_Password = value;
            }
        }
        [DataMember]
        public virtual string PhyUserName
        {
            get { return _PhyUserName; }
            set
            {
                _PhyUserName = value;
            }
        }
        [DataMember]
        public virtual string Taxonomy_Code
        {
            get { return _Taxonomy_Code; }
            set
            {
                _Taxonomy_Code = value;
            }
        }
        [DataMember]
        public virtual string Taxonomy_Description
        {
            get { return _Taxonomy_Description; }
            set
            {
                _Taxonomy_Description = value;
            }
        }
        [DataMember]
        public virtual string Physician_EMail_Password
        {
            get { return _Physician_EMail_Password; }
            set
            {
                _Physician_EMail_Password = value;
            }
        }
        [DataMember]
        public virtual string Physician_EMail_Port
        {
            get { return _Physician_EMail_Port; }
            set
            {
                _Physician_EMail_Port = value;
            }
        }
        [DataMember]
        public virtual string Physician_Other_EMail_Username
        {
            get { return _Physician_Other_EMail_Username; }
            set
            {
                _Physician_Other_EMail_Username = value;
            }

        }

        [DataMember]
        public virtual string Physician_Other_EMail_Password
        {
            get { return _Physician_Other_EMail_Password; }
            set
            {
                _Physician_Other_EMail_Password = value;
            }
        }
        [DataMember]
        public virtual string Physician_Other_EMail_Port
        {
            get { return _Physician_Other_EMail_Port; }
            set
            {
                _Physician_Other_EMail_Port = value;
            }
        }
        [DataMember]
        public virtual string Company
        {
            get { return _Company; }
            set { _Company = value; }
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
        public virtual string Physician_MDoffice_EMail_Username
        {
            get { return _Physician_MDoffice_EMail_Username; }
            set
            {
                _Physician_MDoffice_EMail_Username = value;
            }
        }


        [DataMember]
        public virtual string Physician_MDoffice_EMail_Password
        {
            get { return _Physician_MDoffice_EMail_Password; }
            set
            {
                _Physician_MDoffice_EMail_Password = value;
            }
        }


        [DataMember]
        public virtual string Physician_Other_EMail_Server_Address
        {
            get { return _Physician_Other_EMail_Server_Address; }
            set
            {
                _Physician_Other_EMail_Server_Address = value;
            }
        }
        #endregion
    }
}
