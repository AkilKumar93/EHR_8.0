using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PreventiveScreen:BusinessBase<ulong>
    {
         #region Declarations

        private ulong _Encounter_ID=0;
        private ulong _Human_ID=0;
        private ulong _Physician_ID=0;
        private string _Preventive_Service = string.Empty;
        private string _Preventive_Service_Value = string.Empty;
        private string _Status = string.Empty;
        private string _Preventive_Screening_Notes = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time=DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time=DateTime.MinValue;
        private ulong _Preventive_Screening_Lookup_ID = 0;
        private int _Version = 0;
        //private string _Completed_Date = string.Empty;
        //private string _Value = string.Empty;

        #endregion

        #region Constructors

        public PreventiveScreen() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Preventive_Service);
            sb.Append(_Preventive_Service_Value);
            sb.Append(_Status);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Preventive_Screening_Lookup_ID);
            sb.Append(_Version);
            sb.Append(_Preventive_Screening_Notes);
            //sb.Append(_Completed_Date);
            //sb.Append(_Value);
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
        public virtual ulong Preventive_Screening_Lookup_ID
        {
            get { return _Preventive_Screening_Lookup_ID; }
            set
            {
                _Preventive_Screening_Lookup_ID = value;
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
        //[DataMember]
        //public virtual string Completed_Date
        //{
        //    get { return _Completed_Date; }
        //    set
        //    {
        //        _Completed_Date = value;
        //    }
        //}
        //[DataMember]
        //public virtual string Value
        //{
        //    get { return _Value; }
        //    set
        //    {
        //        _Value = value;
        //    }
        //}

        
        #endregion
    }
}
