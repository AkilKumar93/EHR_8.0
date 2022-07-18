using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    /*Authorization_ID, Human_ID,Encounter_Id, Authorization_Number, Payer_Name, Plan_Name, Insurance_Plan_ID, Valid_From,
     *Valid_To, CPT_Code, CPT_Description, Status, Created_By, Created_Date_And_Time, Modified_By, Modified_Date_And_Time, Version*/
    public partial class Authorization : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Human_ID = 0;
        private string _Authorization_No = string.Empty;
        private DateTime _Valid_From_Date = DateTime.MinValue;
        private DateTime _Valid_To_Date = DateTime.MinValue;
        private string _Payer_Name = string.Empty;
        private string _Insurance_Plan_Name = string.Empty;
        private ulong _PCP_ID = 0;
        private ulong _Insurance_Plan_ID = 0;
        private string _PCP_Name = string.Empty;
        private string _Referred_To_Provider = string.Empty;
        private string _Referred_From_Provider = string.Empty;
        private string _Authorization_Category = string.Empty;
        private string _Referred_To_Facility = string.Empty;
        private string _POS = string.Empty;
        private string _Authorization_Notes = string.Empty;
        private string _ICD1 = string.Empty;
        private string _ICD2 = string.Empty;
        private string _ICD3 = string.Empty;
        private string _ICD4 = string.Empty;
        private string _ICD5 = string.Empty;
        private string _ICD6 = string.Empty;
        private string _ICD7 = string.Empty;
        private string _ICD8 = string.Empty;
        private string _ICD9 = string.Empty;
        private string _ICD10 = string.Empty;
        private string _ICD11 = string.Empty;
        private string _ICD12 = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;

        //private ulong _Encounter_ID = 0;
        //private int _Approved_Quantity = 0;
        //private string _Comments = string.Empty;
        //private string _ICD = string.Empty;
        //private string _ICD_Description = string.Empty;
        //private ulong _PCP_ID = 0;
        //private string _Auth_No = string.Empty;
        //private DateTime _From_Date = DateTime.MinValue;
        //private DateTime _To_Date = DateTime.MinValue;
        //private int _Number_Of_Visits_Requested = 0;
        //private int _Number_Of_Visits_Approved = 0;
        //private int _Number_Of_Visits_Used = 0;
        //private string _Authorization_Notes = string.Empty;
        //private string _Request_Date = string.Empty;
        //private string _Authorization_Status = string.Empty;     
        //private string _Is_Active = string.Empty;
        //private int _Number_Of_Visits_Used_Temp = 0;
        //private string _Auth_Type = string.Empty;
        //private DateTime _Appointment_Date = DateTime.MinValue;
        //private string _Is_Current_Appointment = string.Empty;
        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Authorization_No);
            sb.Append(_Valid_From_Date);
            sb.Append(_Valid_To_Date);
            sb.Append(_Payer_Name);
            sb.Append(_Insurance_Plan_Name);
            sb.Append(_PCP_ID);
            sb.Append(_Insurance_Plan_ID);
            sb.Append(_PCP_Name);
            sb.Append(_Referred_To_Provider);
            sb.Append(_Referred_From_Provider);
            sb.Append(_Authorization_Category);
            sb.Append(_Referred_To_Facility);
            sb.Append(_POS);
            sb.Append(_Authorization_Notes);
            sb.Append(_ICD1);
            sb.Append(_ICD2);
            sb.Append(_ICD3);
            sb.Append(_ICD4);
            sb.Append(_ICD5);
            sb.Append(_ICD6);
            sb.Append(_ICD7);
            sb.Append(_ICD8);
            sb.Append(_ICD9);
            sb.Append(_ICD10);
            sb.Append(_ICD11);
            sb.Append(_ICD12);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
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
        public virtual string Authorization_No
        {
            get { return _Authorization_No; }
            set
            {
                _Authorization_No = value;
            }
        }
        [DataMember]
        public virtual DateTime Valid_From_Date
        {
            get { return _Valid_From_Date; }
            set
            {
                _Valid_From_Date = value;
            }
        }
        [DataMember]
        public virtual DateTime Valid_To_Date
        {
            get { return _Valid_To_Date; }
            set
            {
                _Valid_To_Date = value;
            }
        }
        [DataMember]
        public virtual string Payer_Name
        {
            get { return _Payer_Name; }
            set
            {
                _Payer_Name = value;
            }
        }

        [DataMember]
        public virtual string Insurance_Plan_Name
        {
            get { return _Insurance_Plan_Name; }
            set
            {
                _Insurance_Plan_Name = value;
            }
        }

        [DataMember]
        public virtual ulong PCP_ID
        {
            get { return _PCP_ID; }
            set
            {
                _PCP_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Insurance_Plan_ID
        {
            get { return _Insurance_Plan_ID; }
            set
            {
                _Insurance_Plan_ID = value;
            }
        }
        
        [DataMember]
        public virtual string PCP_Name
        {
            get { return _PCP_Name; }
            set
            {
                _PCP_Name = value;
            }
        }
        [DataMember]
        public virtual string Referred_To_Provider
        {
            get { return _Referred_To_Provider; }
            set
            {
                _Referred_To_Provider = value;
            }
        }
        [DataMember]
        public virtual string Referred_From_Provider
        {
            get { return _Referred_From_Provider; }
            set
            {
                _Referred_From_Provider = value;
            }
        }


        [DataMember]
        public virtual string Authorization_Category
        {
            get { return _Authorization_Category; }
            set
            {
                _Authorization_Category = value;
            }
        }

        [DataMember]
        public virtual string Referred_To_Facility
        {
            get { return _Referred_To_Facility; }
            set
            {
                _Referred_To_Facility = value;
            }
        }
        [DataMember]
        public virtual string POS
        {
            get { return _POS; }
            set
            {
                _POS = value;
            }
        }

        [DataMember]
        public virtual string Authorization_Notes
        {
            get { return _Authorization_Notes; }
            set
            {
                _Authorization_Notes = value;
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
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }

        [DataMember]
        public virtual string ICD1
        {
            get { return _ICD1; }
            set
            {
                _ICD1 = value;
            }
        }

        [DataMember]
        public virtual string ICD2
        {
            get { return _ICD2; }
            set
            {
                _ICD2 = value;
            }
        }
        [DataMember]
        public virtual string ICD3
        {
            get { return _ICD3; }
            set
            {
                _ICD3 = value;
            }
        }
        [DataMember]
        public virtual string ICD4
        {
            get { return _ICD4; }
            set
            {
                _ICD4 = value;
            }
        }
        [DataMember]
        public virtual string ICD5
        {
            get { return _ICD5; }
            set
            {
                _ICD5 = value;
            }
        }
        [DataMember]
        public virtual string ICD6
        {
            get { return _ICD6; }
            set
            {
                _ICD6 = value;
            }
        }

        [DataMember]
        public virtual string ICD7
        {
            get { return _ICD7; }
            set
            {
                _ICD7 = value;
            }
        }
        [DataMember]
        public virtual string ICD8
        {
            get { return _ICD8; }
            set
            {
                _ICD8 = value;
            }
        }
        [DataMember]
        public virtual string ICD9
        {
            get { return _ICD9; }
            set
            {
                _ICD9 = value;
            }
        }
        [DataMember]
        public virtual string ICD10
        {
            get { return _ICD10; }
            set
            {
                _ICD10 = value;
            }
        }
        [DataMember]
        public virtual string ICD11
        {
            get { return _ICD11; }
            set
            {
                _ICD11 = value;
            }
        }
        [DataMember]
        public virtual string ICD12
        {
            get { return _ICD12; }
            set
            {
                _ICD12 = value;
            }
        }

        #endregion
    }
}
