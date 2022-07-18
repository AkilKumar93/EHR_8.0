using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class MyQ
    {
        private string _EHR_Obj_Type = string.Empty;
        private string _EHR_Obj_Sub_Type = string.Empty;
        private string _Current_Process = string.Empty;
        private string _Current_Owner = string.Empty;
        private ulong _Encounter_ID=0;
        private ulong _Physician_ID=0;
        private ulong _Human_ID=0;
        private ulong _Appt_ID=0;
        private DateTime _Date_of_Service=DateTime.MinValue;
        private DateTime _Appt_Date_Time=DateTime.MinValue;
        private string _Type_Of_Visit = string.Empty;
        private string _assignedPhysician = string.Empty;
        private string _assignedMedicalAsst = string.Empty;
        private string _sLastName=string.Empty;
        private string _sFirstName = string.Empty;
        private string _sMI = string.Empty;
        private string _sSufix = string.Empty;
        private DateTime _DOB=DateTime.MinValue;
        private string _sMedicalRecordNumber = string.Empty;
        private string _sExternalAccNumber = string.Empty;
        //private string _sPhyLastName;
        //private string _sPhyFirstName;
        //private string _sPhyMI;
        //private string _sPhySufix;
        private string _sPhyName=string.Empty;
        private string _Message_Description = string.Empty;
        private DateTime _Msg_Date_And_Time = DateTime.MinValue;
        private string _Assigned_To = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_Time = DateTime.MinValue;
        private ulong _Message_ID = 0;
        //private string _Exam_Room = string.Empty;
        private string _Facility_Name = string.Empty;
        private ulong _Obj_System_Id=0;
        private string _Scan_Type = string.Empty;
        private DateTime _TestDate=DateTime.MinValue;
        private string _Procedure_Ordered = string.Empty;
        private string _LabName = string.Empty;
        private string _LabLocName = string.Empty;
        private ulong _Order_ID = 0;
        private ulong _Lab_Location_ID = 0;
        private ulong _Lab_ID = 0;
        private string _scanned_file_name=string.Empty;
        private int _no_of_pages=0;
        private DateTime _scanned_date=DateTime.MinValue;
        private ulong _Scan_ID = 0;
        private string _File_Reference_No = string.Empty;
        private int _Version = 0;
        private string _Is_EandM_Submitted = string.Empty;
        
        
  //Added by bala for quest
        private ulong _Order_Submit_ID = 0;

        //Prescription
        private int _Prescription_Id = 0;
        private DateTime _Prescription_Date = DateTime.MinValue;

        //Selvamani - 19/06/2012
        private ulong _addendum_Id = 0;
        private DateTime _addendum_Signed_Date_Time;
        private DateTime _addendum_Created_Date_Time;

        private string _addendum_created_By = string.Empty;
        private string _addendum_signed_By = string.Empty;
        //$


        private string _Reason_For_Referral = string.Empty;
        private string _Referred_to = string.Empty;
        private string _Referred_to_Facility = string.Empty;
        // Added by Manimozhi - 11th Sep 2012
        private string _MSH_Date_Time_Of_Message = string.Empty;

        // Added by Bala - 20-Sep-2012
        private string _Patient_Status = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Is_Electronic_Mode = string.Empty;

        //Added By ThiyagrajanM(22-02-2013)
        private ulong _CMG_Encounter_ID = 0;

        //Added By ThiyagrajanM(27-05-2013)
        private ulong _Exception_ID = 0;

        private ulong _Exception_Encounter_ID =0;

        private string _Object_Type = string.Empty;

        private string _Dictation_File_Path = string.Empty;

        private string _Reason = string.Empty;
        private string _Header = string.Empty;
        private string _SubHeader = string.Empty;
        //Added for ACO by srividhya on 26-Sep-2014
        private string _Message_Notes = string.Empty;
        private string _Priority = string.Empty;
        //Added for ACO by srividhya on 16-Oct-2014
        private string _LACE_Score = string.Empty;

        private string _Is_Narrative = string.Empty;

        //Addded by Muthusamy on 4-Dec-2014
        private ulong _Result_Master_ID = 0;
        private string _Is_Abnormal = string.Empty;
        private string _Test_Details = string.Empty;
        private string _Ordering_Physician = string.Empty;
        private string _Created_By = string.Empty;
        
        //Added by Naveena for WISH 
        private string _Insurance_Plan_Name = string.Empty;
        private string _Carrier_Name = string.Empty;
        #region Constructors

        public MyQ() { }

        #endregion

        #region Properties
        [DataMember]
        public virtual string EHR_Obj_Type
        {
            get { return _EHR_Obj_Type; }
            set { _EHR_Obj_Type = value; }
        }
        [DataMember]
        public virtual string EHR_Obj_Sub_Type
        {
            get { return _EHR_Obj_Sub_Type; }
            set { _EHR_Obj_Sub_Type = value; }
        }
        [DataMember]
        public virtual string Current_Process
        {
            get { return _Current_Process; }
            set { _Current_Process = value; }
        }
        [DataMember]
        public virtual string Current_Owner
        {
            get { return _Current_Owner; }
            set { _Current_Owner = value; }
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
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
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
        public virtual ulong Appt_ID
        {
            get { return _Appt_ID; }
            set
            {
                _Appt_ID = value;
            }
        }
        [DataMember]
        public virtual DateTime Date_of_Service
        {
            get { return _Date_of_Service; }
            set
            {
                _Date_of_Service = value;
            }
        }
        [DataMember]
        public virtual DateTime Appt_Date_Time
        {
            get { return _Appt_Date_Time; }
            set
            {
                _Appt_Date_Time = value;
            }
        }
        [DataMember]
        public virtual string Type_Of_Visit
        {
            get { return _Type_Of_Visit; }
            set
            {
                _Type_Of_Visit = value;
            }
        }
        [DataMember]
        public virtual string AssignedPhysician
        {
            get { return _assignedPhysician; }
            set
            {
                _assignedPhysician = value;
            }
        }
        [DataMember]
        public virtual string AssignedMedicalAsst
        {
            get { return _assignedMedicalAsst; }
            set
            {
                _assignedMedicalAsst = value;
            }
        }
        [DataMember]
        public virtual string Last_Name
        {
            get { return _sLastName; }
            set { _sLastName = value; }
        }
        [DataMember]
        public virtual string First_Name
        {
            get { return _sFirstName; }
            set { _sFirstName = value; }
        }
        [DataMember]
        public virtual string MI
        {
            get { return _sMI; }
            set { _sMI = value; }
        }
        [DataMember]
        public virtual DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        [DataMember]
        public virtual string Sufix
        {
            get { return _sSufix; }
            set { _sSufix = value; }
        }
        [DataMember]
        public virtual string Medical_Record_Number
        {
            get { return _sMedicalRecordNumber; }
            set { _sMedicalRecordNumber = value; }
        }
        [DataMember]
        public virtual string External_Account_Number
        {
            get { return _sExternalAccNumber; }
            set { _sExternalAccNumber = value; }
        }
        //[DataMember]
        //public virtual string Phy_Last_Name
        //{
        //    get { return _sPhyLastName; }
        //    set { _sPhyLastName = value; }
        //}
        //[DataMember]
        //public virtual string Phy_First_Name
        //{
        //    get { return _sPhyFirstName; }
        //    set { _sPhyFirstName = value; }
        //}
        //[DataMember]
        //public virtual string Phy_MI
        //{
        //    get { return _sPhyMI; }
        //    set { _sPhyMI = value; }
        //}
        //[DataMember]
        //public virtual string Phy_Sufix
        //{
        //    get { return _sPhySufix; }
        //    set { _sPhySufix = value; }
        //}
        [DataMember]
        public virtual string PhyName
        {
            get { return _sPhyName; }
            set { _sPhyName = value; }
        }
        [DataMember]
        public virtual string Message_Description
        {
            get { return _Message_Description; }
            set { _Message_Description = value; }
        }
        [DataMember]
        public virtual DateTime Msg_Date_And_Time
        {
            get { return _Msg_Date_And_Time; }
            set { _Msg_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Assigned_To
        {
            get { return _Assigned_To; }
            set { _Assigned_To = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_Time
        {
            get { return _Modified_Date_Time; }
            set { _Modified_Date_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual ulong Message_ID
        {
            get { return _Message_ID; }
            set { _Message_ID = value; }
        }
        //[DataMember]
        //public virtual string Exam_Room
        //{
        //    get { return _Exam_Room; }
        //    set { _Exam_Room = value; }
        //}

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        [DataMember]
        public virtual ulong Obj_System_Id
        {
            get { return _Obj_System_Id; }
            set { _Obj_System_Id = value; }
        }
        [DataMember]
        public virtual string Scan_Type
        {
            get { return _Scan_Type; }
            set { _Scan_Type = value; }
        }
        [DataMember]
        public virtual DateTime Test_Date
        {
            get { return _TestDate; }
            set
            {
                _TestDate = value;
            }
        }
        [DataMember]
        public virtual string Procedure_Ordered
        {
            get { return _Procedure_Ordered; }
            set { _Procedure_Ordered = value; }
        }
        [DataMember]
        public virtual string Lab_Name
        {
            get { return _LabName; }
            set { _LabName = value; }
        }
        [DataMember]
        public virtual string Lab_Loc_Name
        {
            get { return _LabLocName; }
            set { _LabLocName = value; }
        }

        [DataMember]
        public virtual ulong Order_ID
        {
            get { return _Order_ID; }
            set
            {
                _Order_ID = value;
            }
        }

        [DataMember]
        public virtual ulong Lab_Location_ID
        {
            get { return _Lab_Location_ID; }
            set { _Lab_Location_ID = value; }
        }

        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }


        [DataMember]
        public virtual DateTime Scanned_Date
        {
            get { return _scanned_date; }
            set
            {
                _scanned_date = value;
            }
        }


        [DataMember]
        public virtual int No_of_Pages
        {
            get { return _no_of_pages; }
            set { _no_of_pages = value; }
        }

        [DataMember]
        public virtual string Scanned_File_Name
        {
            get { return _scanned_file_name; }
            set { _scanned_file_name = value; }
        }

        [DataMember]
        public virtual ulong Scan_ID
        {
            get { return _Scan_ID; }
            set { _Scan_ID = value; }
        }


        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }        
        [DataMember]
        public virtual int Prescription_Id
        {
            get { return _Prescription_Id; }
            set { _Prescription_Id = value; }
        }

        [DataMember]
        public virtual DateTime Prescription_Date
        {
            get { return _Prescription_Date; }
            set { _Prescription_Date = value; }
        }

        //Added by bala for Quest

        [DataMember]
        public virtual ulong Order_Submit_ID
        {
            get { return _Order_Submit_ID; }
            set { _Order_Submit_ID = value; }
        }


        //Selvamani - 19/06/2012
        [DataMember]
        public virtual ulong Addendum_ID
        {
            get { return _addendum_Id; }
            set { _addendum_Id = value; }
        }

        [DataMember]
        public virtual DateTime Addendum_Signed_Date_Time
        {
            get { return _addendum_Signed_Date_Time; }
            set { _addendum_Signed_Date_Time = value; }
        }

        [DataMember]
        public virtual DateTime Addendum_Created_Date_Time
        {
            get { return _addendum_Created_Date_Time; }
            set { _addendum_Created_Date_Time = value; }
        }

        [DataMember]
        public virtual string Addendum_Created_By
        {
            get { return _addendum_created_By; }
            set { _addendum_created_By = value; }
        }

        [DataMember]
        public virtual string Addendum_Signed_By
        {
            get { return _addendum_signed_By; }
            set { _addendum_signed_By = value; }
        }
        //$


        // Manimozhi 
        [DataMember]
        public virtual string Reason_For_Referral
        {
            get { return _Reason_For_Referral; }
            set { _Reason_For_Referral = value; }
        }
        [DataMember]
        public virtual string Referred_to
        {
            get { return _Referred_to; }
            set { _Referred_to = value; }
        }
        [DataMember]
        public virtual string Referred_to_Facility
        {
            get { return _Referred_to_Facility; }
            set { _Referred_to_Facility = value; }
        }
        [DataMember]
        public virtual string MSH_Date_Time_Of_Message
        {
            get { return _MSH_Date_Time_Of_Message; }
            set { _MSH_Date_Time_Of_Message = value; }
        }

        [DataMember]
        public virtual string Patient_Status
        {
            get { return _Patient_Status; }
            set { _Patient_Status = value; }
        }

        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }

        [DataMember]
        public virtual string Is_Electronic_Mode
        {
            get { return _Is_Electronic_Mode; }
            set { _Is_Electronic_Mode = value; }
        }

        [DataMember]
        public virtual ulong CMG_Encounter_ID
        {
            get { return _CMG_Encounter_ID; }
            set
            {
                _CMG_Encounter_ID = value;
            }
        }

        [DataMember]
        public virtual ulong Exception_ID
        {
            get { return _Exception_ID; }
            set
            {
                _Exception_ID = value;
            }
        }

        [DataMember]
        public virtual ulong Exception_Encounter_ID
        {
            get { return _Exception_Encounter_ID; }
            set { _Exception_Encounter_ID = value; }
        }

        [DataMember]
        public virtual string Object_Type
        { 
            get { return _Object_Type; }
            set { _Object_Type = value; }
        }


        [DataMember]
        public virtual string Dictation_File_Path
        {
            get { return _Dictation_File_Path; }
            set { _Dictation_File_Path = value; }
        }

        [DataMember]
        public virtual string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        [DataMember]
        public virtual string File_Reference_No
        {
            get { return _File_Reference_No; }
            set { _File_Reference_No = value; }
        }

        [DataMember]
        public virtual string Header
        {
            get { return _Header; }
            set { _Header = value; }
        }
        
        [DataMember]
        public virtual string SubHeader
        {
            get { return _SubHeader; }
            set { _SubHeader = value; }
        }
        [DataMember]
        public virtual string Message_Notes
        {
            get { return _Message_Notes; }
            set { _Message_Notes = value; }
        }
        [DataMember]
        public virtual string Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        [DataMember]
        public virtual string LACE_Score
        {
            get { return _LACE_Score; }
            set { _LACE_Score = value; }
        }

        [DataMember]
        public virtual string Is_Narrative
        {
            get { return _Is_Narrative; }
            set { _Is_Narrative = value; }
        }

        [DataMember]
        public virtual ulong ResultMasterID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }
        [DataMember]
        public virtual string Is_EandM_Submitted
        {
            get { return _Is_EandM_Submitted; }
            set { _Is_EandM_Submitted = value; }
        }

         [DataMember]
        public virtual string Is_Abnormal
        {
            get { return _Is_Abnormal; }
            set { _Is_Abnormal = value; }
        }
         //For ancillary
         [DataMember]
         public virtual string Test_Details
         {
             get { return _Test_Details; }
             set { _Test_Details = value; }
         }
         [DataMember]
         public virtual string Ordering_Physician
         {
             get { return _Ordering_Physician; }
             set { _Ordering_Physician = value; }
         }
         [DataMember]
         public virtual string Created_By
         {
             get { return _Created_By; }
             set { _Created_By = value; }
         }

        [DataMember]
         public virtual string Insurance_Plan_Name
         {
             get { return _Insurance_Plan_Name; }
             set { _Insurance_Plan_Name = value; }
         }

        [DataMember]
        public virtual string Carrier_Name
         {
             get { return _Carrier_Name; }
             set { _Carrier_Name = value; }
         }
        #endregion  
    }
}
