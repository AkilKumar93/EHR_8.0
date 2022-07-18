using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class DictationData : BusinessBase<ulong>
    {
        #region Declarations

        private string _File_Name = string.Empty;
        private string _Physician_Name = string.Empty;
        private string _Facility_Name = string.Empty;
        private string _First_Name = string.Empty;
        private string _Last_Name = string.Empty;
        private ulong _Account_No = 0;
        private ulong _Medical_Record_No = 0;
        private DateTime _DOS = DateTime.MinValue;
        private DateTime _DOB = DateTime.MinValue;
        private string _CC = string.Empty;
        private string _HPI = string.Empty;
        private string _ROS = string.Empty;
        private string _Vitals = string.Empty;
        private IDictionary<string, string> _Exam = new Dictionary<string, string>();
        private string _Assessment = string.Empty;
        private string _Plan = string.Empty;
        private string _PMH = string.Empty;
        private string _SurgicalHistory = string.Empty;
        private string _SocialHistory = string.Empty;
        private string _FamilyHistory = string.Empty;
        private IDictionary<string, string> _Result = new Dictionary<string, string>();
        private string _Others = string.Empty;

        #endregion

        #region Constructors

        public DictationData() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(this.GetType().FullName);
            sb.Append(_File_Name);
            sb.Append(_Physician_Name);
            sb.Append(_Facility_Name);
            sb.Append(_First_Name);
            sb.Append(_Last_Name);
            sb.Append(_Account_No);
            sb.Append(_Medical_Record_No);
            sb.Append(_DOS);
            sb.Append(_DOB);
            sb.Append(_CC);
            sb.Append(_HPI);
            sb.Append(_ROS);
            sb.Append(_Vitals);
            sb.Append(_Exam);            
            sb.Append(_Assessment);
            sb.Append(_Plan);
            sb.Append(_PMH);
            sb.Append(_SurgicalHistory);
            sb.Append(_SocialHistory);
            sb.Append(_FamilyHistory);
            sb.Append(_Result);
            sb.Append(_Others);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string File_Name
        {
            get { return _File_Name; }
            set
            {
                _File_Name = value;
            }
        }

        [DataMember]
        public virtual string Physician_Name
        {
            get { return _Physician_Name; }
            set
            {
                _Physician_Name = value;
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
        public virtual string First_Name
        {
            get { return _First_Name; }
            set
            {
                _First_Name = value;
            }
        }

        [DataMember]
        public virtual string Last_Name
        {
            get { return _Last_Name; }
            set
            {
                _Last_Name = value;
            }
        }

        [DataMember]
        public virtual ulong Account_No
        {
            get { return _Account_No; }
            set
            {
                _Account_No = value;
            }
        }

        [DataMember]
        public virtual ulong Medical_Record_No
        {
            get { return _Medical_Record_No; }
            set
            {
                _Medical_Record_No = value;
            }
        }

        [DataMember]
        public virtual DateTime DOS
        {
            get { return _DOS; }
            set
            {
                _DOS = value;
            }
        }

        [DataMember]
        public virtual DateTime DOB
        {
            get { return _DOB; }
            set
            {
                _DOB = value;
            }
        }

        [DataMember]
        public virtual string CC
        {
            get { return _CC; }
            set
            {
                _CC = value;
            }
        }

        [DataMember]
        public virtual string HPI
        {
            get { return _HPI; }
            set
            {
                _HPI = value;
            }
        }

        [DataMember]
        public virtual string ROS
        {
            get { return _ROS; }
            set
            {
                _ROS = value;
            }
        }

        [DataMember]
        public virtual string Vitals
        {
            get { return _Vitals; }
            set
            {
                _Vitals = value;
            }
        }

        [DataMember]
        public virtual IDictionary<string, string> Exam
        {
            get { return _Exam; }
            set
            {
                _Exam = value;
            }
        }

        [DataMember]
        public virtual string Assessment
        {
            get { return _Assessment; }
            set
            {
                _Assessment = value;
            }
        }

        [DataMember]
        public virtual string Plan
        {
            get { return _Plan; }
            set
            {
                _Plan = value;
            }
        }

        [DataMember]
        public virtual string PMH
        {
            get { return _PMH; }
            set
            {
                _PMH = value;
            }
        }

        [DataMember]
        public virtual string SurgicalHistory
        {
            get { return _SurgicalHistory; }
            set
            {
                _SurgicalHistory = value;
            }
        }

        [DataMember]
        public virtual string SocialHistory
        {
            get { return _SocialHistory; }
            set
            {
                _SocialHistory = value;
            }
        }

        [DataMember]
        public virtual string FamilyHistory
        {
            get { return _FamilyHistory; }
            set
            {
                _FamilyHistory = value;
            }
        }

        [DataMember]
        public virtual IDictionary<string, string> Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
            }
        }

        [DataMember]
        public virtual string Others
        {
            get { return _Others; }
            set
            {
                _Others = value;
            }
        }

        #endregion
    }
}
