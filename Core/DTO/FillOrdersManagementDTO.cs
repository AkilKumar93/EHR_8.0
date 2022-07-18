using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class FillOrdersManagementDTO
    {
        DateTime _Ordered_Date_And_Time =new DateTime();
        string _Order_Type = string.Empty;
        string _Current_Process = string.Empty;
        string _Human_Id = string.Empty;
        string _Human_Name = string.Empty;
        DateTime _Date_Of_Birth = new DateTime();
        string _Procedures = string.Empty;
        ulong _Physician_ID = 0;
        string _Facility_Name = string.Empty;
        ulong _Lab_ID = 0;
        ulong _Lab_Location_ID = 0;
        ulong _Total_Record_Found = 0;
        ulong _WF_Object_Id = 0;
        ulong _Group_ID = 0;
        string _Assessment = string.Empty;
        string _To_Physician_Name = string.Empty;
        string _To_Facility_Name = string.Empty;
        string _Temp_Property = string.Empty;
        string _Encounter_ID= string.Empty;
        string _Specimen_Collected_Date_Time= string.Empty;
        //Added by Manimozhi - bug id -15312
        ulong _File_Management_Index_Order_ID = 0;
        bool _Is_Electronic_Result_Available = false;
        string _Ordering_Provider = string.Empty;
        string _Lab_Name = string.Empty;
      


        [DataMember]
        public virtual string Specimen_Collected_Date_Time
        {
            get { return _Specimen_Collected_Date_Time; }
            set { _Specimen_Collected_Date_Time = value; }
        }
        [DataMember]
        public virtual string Temp_Property
        {
            get { return _Temp_Property; }
            set { _Temp_Property = value; }
        }
        [DataMember]
        public virtual string Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual string To_Physician_Name
        {
            get { return _To_Physician_Name; }
            set { _To_Physician_Name = value; }
        }
        [DataMember]
        public virtual string To_Facility_Name
        {
            get { return _To_Facility_Name; }
            set { _To_Facility_Name = value; }
        }

        [DataMember]
        public virtual DateTime Ordered_Date_And_Time
        {
            get { return _Ordered_Date_And_Time; }
            set { _Ordered_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Order_Type
        {
            get { return _Order_Type; }
            set { _Order_Type = value; }
        }
        [DataMember]
        public virtual string Assessment
        {
            get { return _Assessment; }
            set { _Assessment = value; }
        }
        [DataMember]
        public virtual string Current_Process
        {
            get { return _Current_Process; }
            set { _Current_Process = value; }
        }
        [DataMember]
        public virtual string Human_Id
        {
            get { return _Human_Id; }
            set { _Human_Id = value; }
        }
        [DataMember]
        public virtual string Human_Name
        {
            get { return _Human_Name; }
            set { _Human_Name = value; }
        }
        [DataMember]
        public virtual DateTime Date_Of_Birth
        {
            get { return _Date_Of_Birth; }
            set { _Date_Of_Birth = value; }
        }
        [DataMember]
        public virtual string Procedures
        {
            get { return _Procedures; }
            set { _Procedures = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        [DataMember]
        public virtual ulong Group_ID
        {
            get { return _Group_ID; }
            set { _Group_ID = value; }
        }
        [DataMember]
        public virtual ulong Lab_Location_ID
        {
            get { return _Lab_Location_ID; }
            set { _Lab_Location_ID = value; }
        }
        [DataMember]
        public virtual ulong Total_Record_Found
        {
            get { return _Total_Record_Found; }
            set { _Total_Record_Found = value; }
        }
        [DataMember]
        public virtual ulong WF_Object_Id
        {
            get { return _WF_Object_Id; }
            set { _WF_Object_Id = value; }
        }
        //Added by Manimozhi - bug id -15312
        [DataMember]
        public virtual ulong File_Management_Index_Order_ID
        {
            get { return _File_Management_Index_Order_ID; }
            set { _File_Management_Index_Order_ID = value; }
        }
        [DataMember]
        public virtual bool Is_Electronic_Result_Available
        {
            get { return _Is_Electronic_Result_Available; }
            set { _Is_Electronic_Result_Available = value; }
        }

        //Added By Saravanakumar
        [DataMember]
        public virtual string Ordering_Provider
        {
            get { return _Ordering_Provider; }
            set { _Ordering_Provider = value; }
        }
        [DataMember]
        public virtual string Lab_Name
        {
            get { return _Lab_Name; }
            set { _Lab_Name = value; }
        }
    }
}
