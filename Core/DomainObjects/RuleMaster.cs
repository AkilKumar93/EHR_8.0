using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class RuleMaster:BusinessBase<ulong>
    {
        #region Parameter Variable Decleration


        private string _Rule_Name = string.Empty;
        private string _Rule_Description = string.Empty;
        private string _From_Age = string.Empty;
        private string _To_Age = string.Empty;
        private string _Gender = string.Empty;
        private string _Expected_Action = string.Empty;
        private int _Alert = 0;
        private int _Frequency = 0;
        private string _Is_Status = string.Empty;
        private DateTime _Last_Run_Date = DateTime.MinValue;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version=0;
        private string _Age_In=string.Empty;
        private int _Physician_id = 0;
        private string _Race = string.Empty;
        private string _Ethnicity = string.Empty;
        private string _communication = string.Empty;
        private string _Legal_Org = string.Empty;

        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Rule_Name);
            sb.Append(_Rule_Description);
            sb.Append(_From_Age);
            sb.Append(_To_Age);
            sb.Append(_Gender);
            sb.Append(_Expected_Action);
            sb.Append(_Alert);
            sb.Append(_Frequency);
            sb.Append(_Is_Status);
            sb.Append(_Last_Run_Date);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Age_In);
            sb.Append(_Physician_id);
            sb.Append(_Race);
            sb.Append(_Ethnicity);
            sb.Append(_communication);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation

        [DataMember]
        public virtual string Rule_Name
        {
            get { return _Rule_Name; }
            set { _Rule_Name = value; }
        }
        [DataMember]
        public virtual string Rule_Description
        {
            get { return _Rule_Description; }
            set { _Rule_Description = value; }
        }
        [DataMember]
        public virtual string From_Age
        {
            get { return _From_Age; }
            set { _From_Age = value; }
        }

        [DataMember]
        public virtual string To_Age
        {
            get { return _To_Age; }
            set { _To_Age = value; }
        }
        [DataMember]
        public virtual string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [DataMember]
        public virtual string Expected_Action
        {
            get { return _Expected_Action; }
            set { _Expected_Action = value; }
        }

        [DataMember]
        public virtual int Alert
        {
            get { return _Alert; }
            set { _Alert = value; }
        }
        [DataMember]
        public virtual int Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        [DataMember]
        public virtual string Is_Status
        {
            get { return _Is_Status; }
            set { _Is_Status = value; }
        }

        [DataMember]
        public virtual DateTime Last_Run_Date
        {
            get { return _Last_Run_Date; }
            set { _Last_Run_Date = value; }
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
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [DataMember]
        public virtual string Age_In
        {
            get { return _Age_In; }
            set { _Age_In = value; }
        }

        [DataMember]
        public virtual int Physician_ID
        {
            get { return _Physician_id; }
            set { _Physician_id = value; }
        }

          [DataMember]
        public virtual string Race
        {
            get { return _Race; }
            set { _Race = value; }
        }

          [DataMember]
          public virtual string Ethnicity
          {
              get { return _Ethnicity; }
              set { _Ethnicity = value; }
          }

          [DataMember]
          public virtual string Communication
          {
              get { return _communication; }
              set { _communication = value; }
          }

          [DataMember]
          public virtual string Legal_Org
          {
              get { return _Legal_Org; }
              set { _Legal_Org = value; }
          }

        #endregion
    }
}
