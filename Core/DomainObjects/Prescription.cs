using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Prescription:BusinessBase<int>
    {
        #region Declarations
        
        private int _Encounter_ID = 0;
        private int _Human_ID = 0;
        private int _Physician_ID = 0;
        private string _Facility_Name = string.Empty;
        private DateTime _Prescription_Date = DateTime.MinValue;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Created_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private int _Version = 0;

        #endregion

         #region Constructors

        public Prescription() { }

        #endregion

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Facility_Name);
            sb.Append(_Prescription_Date);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Created_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();

        }

        #region Properties

        [DataMember]
        public virtual int Encounter_ID
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
            }
        }

        [DataMember]
        public virtual int Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }

        [DataMember]
        public virtual int Physician_ID
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
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
        public virtual DateTime Prescription_Date
        {
            get { return _Prescription_Date; }
            set
            {
               _Prescription_Date = value;
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
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
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
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }

        #endregion
    }
}
