using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class FillWillingonCancel
    {
        #region Declarations

        private DateTime _Appointment_Date_Time = DateTime.MinValue;
        private string _Facility_Name = string.Empty;
        private string _Physician_Name = string.Empty;
        private ulong _Human_ID = 0;
        private string _Visit_Type = string.Empty;
        private string _Last_Name = string.Empty;
        private string _First_Name = string.Empty;
        private string _Mi = string.Empty;
        private string _Suffix = string.Empty;
        private string _Sex = string.Empty;
        private string _Human_Type = string.Empty;
        private string _Current_Process = string.Empty;
        private ulong _Encounter_ID = 0;
        private ulong _Physician_ID = 0;
        private string _Duration_Time = string.Empty;
        private int _Count = 0;
        private ulong _Machine_Technician_Library_ID = 0;
        private string _Test_Ordered = string.Empty;
        private DateTime _Rescheduled_Appointment_Date = DateTime.MinValue;
        private string _Reason_for_Cancelation = string.Empty;
        #endregion

        #region Constructor
        public FillWillingonCancel() { }

        #endregion

        #region Properties
        [DataMember]
        public virtual DateTime Appointment_Date_Time
        {
            get { return _Appointment_Date_Time; }
            set { _Appointment_Date_Time = value; }
        }

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }

        [DataMember]
        public virtual string Physician_Name
        {
            get { return _Physician_Name; }
            set { _Physician_Name = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
      
        [DataMember]
        public virtual string Visit_Type
        {
            get { return _Visit_Type; }
            set { _Visit_Type = value; }
        }
        [DataMember]
        public virtual string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }
        [DataMember]
        public virtual string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        [DataMember]
        public virtual string Mi
        {
            get { return _Mi; }
            set { _Mi = value; }
        }
        [DataMember]
        public virtual string Suffix
        {
            get { return _Suffix; }
            set { _Suffix = value; }
        }
        [DataMember]
        public virtual string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        [DataMember]
        public virtual string Human_Type
        {
            get { return _Human_Type; }
            set { _Human_Type = value; }
        }

        [DataMember]
        public virtual string Current_Process
        {
            get { return _Current_Process; }
            set { _Current_Process = value; }
        }

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual string Duration_Time
        {
            get { return _Duration_Time; }
            set { _Duration_Time = value; }
        }
        [DataMember]
        public virtual int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        [DataMember]
        public virtual ulong Machine_Technician_Library_ID
        {
            get { return _Machine_Technician_Library_ID; }
            set { _Machine_Technician_Library_ID = value; }
        }
        [DataMember]
        public virtual string Test_Ordered
        {
            get { return _Test_Ordered; }
            set { _Test_Ordered = value; }
        }
        [DataMember]
        public virtual DateTime Rescheduled_Appointment_Date
        {
            get { return _Rescheduled_Appointment_Date; }
            set { _Rescheduled_Appointment_Date = value; }
        }
        [DataMember]
        public virtual string Reason_for_Cancelation
        {
            get { return _Reason_for_Cancelation; }
            set { _Reason_for_Cancelation = value; }
        }

        #endregion  
    }
}
