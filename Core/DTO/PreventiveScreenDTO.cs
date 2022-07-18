using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
   public partial class PreventiveScreenDTO
    {
        private ulong _Preventive_Screen_ID = 0;
        private string _Preventive_Service = string.Empty;
        private string _Preventive_Service_Value = string.Empty;
        private string _Status = string.Empty;
        private string _Options = string.Empty;
        private string _Preventive_Screening_Notes = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _BP_Date_And_Time = DateTime.MinValue;
        private ulong _Preventive_Screen_Lookup_ID = 0;
        private int _Version = 0;
        private string _Depending_Value = string.Empty;        
        private string _Description = string.Empty;
        private string _VitalValue = string.Empty;
        private string _BpVitalName = string.Empty;
        private string _BpVitalValue = string.Empty;
        private DateTime  _Hba1c_Date_And_Time =DateTime.MinValue;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;        
        private ulong _PEnc = 0;
        private bool _physician_process;
        private string _Patient_Sex = string.Empty;

        public PreventiveScreenDTO() 
        {
            _physician_process = false;
            _PEnc = 0;

        }

        [DataMember]
        public virtual ulong Preventive_Screen_ID
        {
            get { return _Preventive_Screen_ID; }
            set
            {
                _Preventive_Screen_ID = value;
            }
        }

        [DataMember]
        public virtual string Preventive_Service
        {
            get { return _Preventive_Service; }
            set
            {
                _Preventive_Service = value;
            }
        }
        [DataMember]
        public virtual string Preventive_Service_Value
        {
            get { return _Preventive_Service_Value; }
            set
            {
                _Preventive_Service_Value = value;
            }
        }

        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }

        [DataMember]
        public virtual string Options
        {
            get { return _Options; }
            set
            {
                _Options = value;
            }
        }
        [DataMember]
        public virtual string Preventive_Screening_Notes
        {
            get { return _Preventive_Screening_Notes; }
            set
            {
                _Preventive_Screening_Notes = value;
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
        public virtual DateTime BP_Date_And_Time
        {
            get { return _BP_Date_And_Time; }
            set
            {
                _BP_Date_And_Time = value;
            }
        }

        [DataMember]
        public virtual ulong Preventive_Screen_Lookup_ID
        {
            get { return _Preventive_Screen_Lookup_ID; }
            set
            {
                _Preventive_Screen_Lookup_ID = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }

        [DataMember]
        public virtual string Depending_Value
        {
            get { return _Depending_Value; }
            set { _Depending_Value = value; }
        }
       
        [DataMember]
        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public virtual string  VitalValue
        {
            get { return _VitalValue; }
            set { _VitalValue = value; }
        }
        [DataMember]
        public virtual string BpVitalName
        {
            get { return _BpVitalName; }
            set { _BpVitalName = value; }
        }
        [DataMember]
        public virtual string BpVitalValue
        {
            get { return _BpVitalValue; }
            set { _BpVitalValue = value; }
        }

        [DataMember]
        public DateTime Hba1c_Date_And_Time
        {
            get { return _Hba1c_Date_And_Time; }
            set { _Hba1c_Date_And_Time = value; }
        }

        [DataMember]
        public DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
      
        [DataMember]
        public ulong PEnc
        {
            get { return _PEnc; }
            set { _PEnc = value; }
        }
        [DataMember]
        public virtual bool Physician_Process
        {
            get { return _physician_process; }
            set { _physician_process = value; }
        }
        [DataMember]
        public virtual string Patient_Sex
        {
            get { return _Patient_Sex; }
            set { _Patient_Sex = value; }
        }
    }
}
