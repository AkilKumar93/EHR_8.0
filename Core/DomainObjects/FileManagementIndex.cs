using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    //[DataContract]
    [Serializable]
    public partial class FileManagementIndex : BusinessBase<ulong>
    {
           #region Declarations

        private ulong _Human_ID = 0;
        private DateTime _Document_Date=DateTime.MinValue;
        private string _Document_Type = string.Empty;
        private string _Document_Sub_Type = string.Empty;
        private string _File_Path = string.Empty;
        private string _File_Version = string.Empty;
        private string _Source = string.Empty;
        private string _Relationship = string.Empty;
        private string _GivenTo = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.Now;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time=DateTime.MinValue;
        private DateTime _Printed_Date_And_Time = DateTime.Now;
        private int _Version=0;
        private ulong _Scan_Index_convertion_ID = 0;
        private ulong _Order_ID = 0;
        private ulong _Result_Master_ID = 0;
        private string _Orders_Description = string.Empty;
        private ulong _Encounter_id = 0;
        private ulong _Workset_ID = 0;
        private DateTime _Appointment_Date = DateTime.MinValue;
        private string _Facility_Name = string.Empty;
        private ulong _Appointment_Provider_ID = 0;
        private DateTime _Document_To_Date = DateTime.MinValue;

        private string _Generate_Link_File_Path = string.Empty;
        private string _Exam_Photos_Notes = string.Empty;
        private string _Is_Delete = string.Empty;
        private string _Batch_Status = "OPEN";
        #endregion

        #region Constructors

        public FileManagementIndex() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Document_Date);
            sb.Append(_Document_Type);
            sb.Append(_Document_Sub_Type);
            sb.Append(_File_Path);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Printed_Date_And_Time);
            sb.Append(_File_Version);
            sb.Append(_Source);
            sb.Append(_Relationship);
            sb.Append(_GivenTo);
            sb.Append(_Version);
            sb.Append(_Scan_Index_convertion_ID);
            sb.Append(_Order_ID);
            sb.Append(_Result_Master_ID);
            sb.Append(_Orders_Description);
            sb.Append(_Workset_ID);
            sb.Append(_Appointment_Date);
            sb.Append(_Facility_Name);
            sb.Append(_Appointment_Provider_ID);
            sb.Append(_Document_To_Date);
            sb.Append(_Generate_Link_File_Path);
            sb.Append(_Exam_Photos_Notes);
            sb.Append(_Is_Delete);
            sb.Append(_Batch_Status);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual ulong Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }

        [DataMember]
        public virtual ulong Scan_Index_Conversion_ID
        {
            get { return _Scan_Index_convertion_ID; }
            set { _Scan_Index_convertion_ID = value; }
        }
        [DataMember]
        public virtual string Generate_Link_File_Path
        {
            get { return _Generate_Link_File_Path; }
            set { _Generate_Link_File_Path = value; }
        }

        [DataMember]
        public virtual string File_Version
        {
            get { return _File_Version; }
            set { _File_Version = value; }
        }
        
        [DataMember]
        public virtual DateTime Document_Date
        {
            get { return _Document_Date; }
            set { _Document_Date = value; }
        }
        [DataMember]
        public virtual string Document_Type
        {
            get { return _Document_Type; }
            set { _Document_Type = value; }

        }
        [DataMember]
        public virtual string Document_Sub_Type
        {
            get { return _Document_Sub_Type; }
            set { _Document_Sub_Type = value; }
        }
     
        [DataMember]
        public virtual string File_Path
        {
            get { return _File_Path; }
            set { _File_Path = value; }
        }


        [DataMember]
        public virtual string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        [DataMember]
        public virtual string Relationship
        {
            get { return _Relationship; }
            set { _Relationship = value; }
        }


        [DataMember]
        public virtual string Given_To
        {
            get { return _GivenTo; }
            set { _GivenTo = value; }
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
        public virtual DateTime Printed_Date_And_Time
        {
            get { return _Printed_Date_And_Time; }
            set { _Printed_Date_And_Time = value; }
        }


        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }

        [DataMember]
        public virtual string Orders_Description
        {
            get { return _Orders_Description; }
            set { _Orders_Description = value; }
        }

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_id; }
            set { _Encounter_id = value; }
        }
        [DataMember]
        public virtual ulong Workset_ID
        {
            get { return _Workset_ID; }
            set { _Workset_ID = value; }
        }
        [DataMember]
        public virtual DateTime Appointment_Date
        {
            get { return _Appointment_Date; }
            set { _Appointment_Date = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }


        [DataMember]
        public virtual ulong Appointment_Provider_ID
        {
            get { return _Appointment_Provider_ID; }
            set { _Appointment_Provider_ID = value; }
        }
        [DataMember]
        public virtual DateTime Document_To_Date
        {
            get { return _Document_To_Date; }
            set { _Document_To_Date = value; }
        }
           [DataMember]
        public virtual string Exam_Photos_Notes
        {
            get { return _Exam_Photos_Notes; }
            set { _Exam_Photos_Notes = value; }
        }

           [DataMember]
           public virtual string Is_Delete
           {
               get { return _Is_Delete; }
               set { _Is_Delete = value; }
           }
        
         [DataMember]
           public virtual string Batch_Status
           {
               get { return _Batch_Status; }
               set { _Batch_Status = value; }
           }


        
        #endregion
    }
}
