using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class PQRIDTO
    {
        private IList<PQRI> _PQRIList = new List<PQRI>();
        private int _Human_ID = 0;
        private string _Tobacco_Social_Info = string.Empty;
        private string _SmokingHabit_Social_Info = string.Empty;
        private string _Bmi = string.Empty;
        private string _Bmi_Status = string.Empty;
        private string _Tobacco_Is_Present = string.Empty;
        private string _Smoking_Is_Present = string.Empty;
        private string _Is_Done = string.Empty;
        private string _Measure_Number = string.Empty;
        private string _Numerator = string.Empty;
       


        [DataMember]
        public virtual IList<PQRI> PQRIList
        {
            get { return _PQRIList; }
            set { _PQRIList = value; }
        }
        [DataMember]
        public virtual int Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Tobacco_Social_Info
        {
            get { return _Tobacco_Social_Info; }
            set { _Tobacco_Social_Info = value; }
        }
        [DataMember]
        public virtual string Bmi
        {
            get { return _Bmi; }
            set { _Bmi = value; }
        }
        [DataMember]
        public virtual string Bmi_Status
        {
            get { return _Bmi_Status; }
            set { _Bmi_Status = value; }
        }
        [DataMember]
        public virtual string Tobacco_Is_Present
        {
            get { return _Tobacco_Is_Present; }
            set { _Tobacco_Is_Present = value; }
        }
        [DataMember]
        public virtual string Smoking_Is_Present
        {
            get { return _Smoking_Is_Present; }
            set { _Smoking_Is_Present = value; }
        }
        [DataMember]
        public virtual string SmokingHabit_Social_Info
        {
            get { return _SmokingHabit_Social_Info; }
            set { _SmokingHabit_Social_Info = value; }
        }
        [DataMember]
        public virtual string Is_Done
        {
            get { return _Is_Done; }
            set { _Is_Done = value; }
        }
        [DataMember]
        public virtual string Measure_Number
        {
            get { return _Measure_Number; }
            set { _Measure_Number = value; }
        }
       
        [DataMember]
        public virtual string Numerator
        {
            get { return _Numerator; }
            set { _Numerator = value; }
        }
    }
}
