using System;
using System.Runtime.Serialization;
using System.Reflection;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrdersQuestionSetAfp:BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Order_ID = 0;
        private string _Insulin_Dependent = string.Empty;
        private string _Gestational_Age_Weeks = string.Empty;
        private string _Gestational_Age_Days = string.Empty;
        private string _Gestational_Age_Decimal_Form = string.Empty;
        private string _Gestational_Age_Date_Of_Calculation = string.Empty;
        private string _GA_Calculation_Method_LMP = string.Empty;
        private string _LMP_Date = string.Empty;
        private string _GA_Calculation_Method_Ultrasound = string.Empty;
        private string _Ultrasound_Date = string.Empty;
        private string _GA_Calculation_Method_EDD_EDC = string.Empty;
        private string _EDD_EDC_Date = string.Empty;
        private string _Number_Of_Fetuses =string.Empty;
        private string _Created_By=string.Empty;
        private string _Modified_By=string.Empty;       
        private DateTime _Created_Date_And_Time=DateTime.MinValue;
        private DateTime _Modified_Date_And_Time=DateTime.MinValue;
        private int _Version=0;
        private string _Routine_Screening = string.Empty;
        private string _Previous_Neural_Tube_Defects = string.Empty;
        private string _Advanced_Maternal_Age = string.Empty;
        private string _History_Of_Down_Syndrome = string.Empty;
        private string _History_Of_Cystic_Fibrosis = string.Empty;
        private string _Other_Indications = string.Empty;
        private string _Additional_Information = string.Empty;
        private string _Previously_Elevated_AFP = string.Empty;
        private string _Reason_For_Repeat_Early_GA = string.Empty;
        private string _Reason_For_Repeat_Hemolyzed = string.Empty;
        private string _Ultrasound_Measurement_Crown_Rump_Length = string.Empty;
        private string _Ultrasound_Measurement_Crown_Rump_Length_Date = string.Empty;
        private string _Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B = string.Empty;
        private string _Nuchal_Translucency = string.Empty;
        private string _Nuchal_Translucency_For_Twin_B = string.Empty;
        private string _Donor_Egg = string.Empty;
        private string _Age_Of_Egg_Donor = string.Empty;
        private string _Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy = string.Empty;
        private string _Prior_First_Trimester_Testing = string.Empty;
        private string _Prior_Second_Trimester_Testing = string.Empty;
        private string _FHX_NTD = string.Empty;
        private string _Prior_Pregnancy_With_Down_Syndrome = string.Empty;
        private string _Chorionicity_Monochorionic = string.Empty;
        private string _Chorionicity_Dichorionic = string.Empty;
        private string _Chorionicity_Unknown = string.Empty;
        private string _Sonographer_Last_Name = string.Empty;
        private string _Sonographer_First_Name = string.Empty;
        private string _Sonographer_ID_Number = string.Empty;
        private string _Credentialed_By_NTQR = string.Empty;
        private string _Credentialed_By_FMF = string.Empty;
        private string _Credentialed_By_Other_Organization = string.Empty;
        private string _Site_Number = string.Empty;
        private string _Reading_Physician_ID = string.Empty;

        #endregion

        #region Constructors

        public OrdersQuestionSetAfp() { }

        public OrdersQuestionSetAfp(OrdersQuestionSetAfp obj) 
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(obj, null), null);
            }
        }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Order_ID);
            sb.Append(_Insulin_Dependent);
            sb.Append(_Gestational_Age_Weeks);
            sb.Append(_Gestational_Age_Days);
            sb.Append(_Gestational_Age_Decimal_Form);
            sb.Append(_Gestational_Age_Date_Of_Calculation);
            sb.Append(_GA_Calculation_Method_LMP);
            sb.Append(_LMP_Date);
            sb.Append(_GA_Calculation_Method_Ultrasound);
            sb.Append(_Ultrasound_Date);
            sb.Append(_GA_Calculation_Method_EDD_EDC);
            sb.Append(_EDD_EDC_Date);
            sb.Append(_Number_Of_Fetuses);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Routine_Screening);
            sb.Append(_Previous_Neural_Tube_Defects);
            sb.Append(_Advanced_Maternal_Age);
            sb.Append(_History_Of_Down_Syndrome);
            sb.Append(_History_Of_Cystic_Fibrosis);
            sb.Append(_Other_Indications);
            sb.Append(_Additional_Information);
            sb.Append(_Previously_Elevated_AFP);
            sb.Append(_Reason_For_Repeat_Early_GA);
            sb.Append(_Reason_For_Repeat_Hemolyzed);
            sb.Append(_Ultrasound_Measurement_Crown_Rump_Length);
            sb.Append(_Ultrasound_Measurement_Crown_Rump_Length_Date);
            sb.Append(_Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B);
            sb.Append(_Nuchal_Translucency);
            sb.Append(_Nuchal_Translucency_For_Twin_B);
            sb.Append(_Donor_Egg);
            sb.Append(_Age_Of_Egg_Donor);
            sb.Append(_Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy);
            sb.Append(_Prior_First_Trimester_Testing);
            sb.Append(_Prior_Second_Trimester_Testing);
            sb.Append(_FHX_NTD);
            sb.Append(_Prior_Pregnancy_With_Down_Syndrome);
            sb.Append(_Chorionicity_Monochorionic);
            sb.Append(_Chorionicity_Dichorionic);
            sb.Append(_Chorionicity_Unknown);
            sb.Append(_Sonographer_First_Name);
            sb.Append(_Sonographer_Last_Name);
            sb.Append(_Sonographer_ID_Number);
            sb.Append(_Credentialed_By_NTQR);
            sb.Append(_Credentialed_By_FMF);
            sb.Append(_Credentialed_By_Other_Organization);
            sb.Append(_Site_Number);
            sb.Append(_Reading_Physician_ID);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
              
        [DataMember]
        public virtual ulong Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }
        [DataMember]
        public virtual string Insulin_Dependent
        {
            get { return _Insulin_Dependent; }
            set { _Insulin_Dependent = value; }
        }

        [DataMember]
        public virtual string Gestational_Age_Weeks
        {
            get { return _Gestational_Age_Weeks; }
            set { _Gestational_Age_Weeks = value; }
        }
        [DataMember]
        public virtual string Gestational_Age_Days
        {
            get { return _Gestational_Age_Days; }
            set { _Gestational_Age_Days = value; }
        }

        [DataMember]
        public virtual string Gestational_Age_Decimal_Form
        {
            get { return _Gestational_Age_Decimal_Form; }
            set { _Gestational_Age_Decimal_Form = value; }
        }
        [DataMember]
        public virtual string Gestational_Age_Date_Of_Calculation
        {
            get { return _Gestational_Age_Date_Of_Calculation; }
            set { _Gestational_Age_Date_Of_Calculation = value; }
        }

             
        [DataMember]
        public virtual string GA_Calculation_Method_LMP
        {
            get { return _GA_Calculation_Method_LMP; }
            set { _GA_Calculation_Method_LMP = value; }
        }

        [DataMember]
        public virtual string LMP_Date
        {
            get { return _LMP_Date; }
            set { _LMP_Date = value; }
        }

        [DataMember]
        public virtual string GA_Calculation_Method_Ultrasound
        {
            get { return _GA_Calculation_Method_Ultrasound; }
            set { _GA_Calculation_Method_Ultrasound = value; }
        }
        [DataMember]
        public virtual string Ultrasound_Date
        {
            get { return _Ultrasound_Date; }
            set { _Ultrasound_Date = value; }
        }
        [DataMember]
        public virtual string GA_Calculation_Method_EDD_EDC
        {
            get { return _GA_Calculation_Method_EDD_EDC; }
            set { _GA_Calculation_Method_EDD_EDC = value; }
        }
        [DataMember]
        public virtual string EDD_EDC_Date
        {
            get { return _EDD_EDC_Date; }
            set { _EDD_EDC_Date = value; }
        }
        [DataMember]
        public virtual string Number_Of_Fetuses
        {
            get { return _Number_Of_Fetuses; }
            set { _Number_Of_Fetuses = value; }
        }
        
        [DataMember]
        public virtual string Routine_Screening
        {
            get { return _Routine_Screening; }
            set { _Routine_Screening = value; }
        }
     
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
       
        
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
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
        public virtual string Previous_Neural_Tube_Defects
        {
            get { return _Previous_Neural_Tube_Defects; }
            set { _Previous_Neural_Tube_Defects = value; }
        }

        
        [DataMember]
        public virtual string Advanced_Maternal_Age
        {
            get { return _Advanced_Maternal_Age; }
            set { _Advanced_Maternal_Age = value; }
        }

        [DataMember]
        public virtual string History_Of_Down_Syndrome
        {
            get { return _History_Of_Down_Syndrome; }
            set { _History_Of_Down_Syndrome = value; }
        }

        [DataMember]
        public virtual string History_Of_Cystic_Fibrosis
        {
            get { return _History_Of_Cystic_Fibrosis; }
            set
            {
                _History_Of_Cystic_Fibrosis = value;
            }
        }

        [DataMember]
        public virtual string Other_Indications
        {
            get { return _Other_Indications; }
            set { _Other_Indications = value; }
        }
        [DataMember]
        public virtual string Previously_Elevated_AFP
        {
            get { return _Previously_Elevated_AFP; }
            set { _Previously_Elevated_AFP = value; }
        }

        [DataMember]
        public virtual string Additional_Information
        {
            get { return _Additional_Information; }
            set { _Additional_Information = value; }
        }

        [DataMember]
        public virtual string Nuchal_Translucency
        {
            get { return _Nuchal_Translucency; }
            set { _Nuchal_Translucency = value; }
        }

        

        [DataMember]
        public virtual string Reason_For_Repeat_Early_GA
        {
            get { return _Reason_For_Repeat_Early_GA; }
            set { _Reason_For_Repeat_Early_GA = value; }
        }

        [DataMember]
        public virtual string Reason_For_Repeat_Hemolyzed
        {
            get { return _Reason_For_Repeat_Hemolyzed; }
            set { _Reason_For_Repeat_Hemolyzed = value; }
        }

        [DataMember]
        public virtual string Ultrasound_Measurement_Crown_Rump_Length
        {
            get { return _Ultrasound_Measurement_Crown_Rump_Length; }
            set { _Ultrasound_Measurement_Crown_Rump_Length = value; }
        }

        [DataMember]
        public virtual string Ultrasound_Measurement_Crown_Rump_Length_Date
        {
            get { return _Ultrasound_Measurement_Crown_Rump_Length_Date; }
            set { _Ultrasound_Measurement_Crown_Rump_Length_Date = value; }
        }

        [DataMember]
        public virtual string Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B
        {
            get { return _Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B; }
            set { _Ultrasound_Measurement_Crown_Rump_Length_For_Twin_B = value; }
        }

        [DataMember]
        public virtual string Nuchal_Translucency_For_Twin_B
        {
            get { return _Nuchal_Translucency_For_Twin_B; }
            set { _Nuchal_Translucency_For_Twin_B = value; }
        }
        [DataMember]
        public virtual string Donor_Egg
        {
            get { return _Donor_Egg; }
            set { _Donor_Egg = value; }
        }
        [DataMember]
        public virtual string Age_Of_Egg_Donor
        {
            get { return _Age_Of_Egg_Donor; }
            set { _Age_Of_Egg_Donor = value; }
        }
        [DataMember]
        public virtual string Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy
        {
            get { return _Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy; }
            set { _Prior_Down_Syndrome_ONTD_Screening_On_Current_Pregnancy = value; }
        }
        [DataMember]
        public virtual string Prior_First_Trimester_Testing
        {
            get { return _Prior_First_Trimester_Testing; }
            set { _Prior_First_Trimester_Testing = value; }
        }
        [DataMember]
        public virtual string Prior_Second_Trimester_Testing
        {
            get { return _Prior_Second_Trimester_Testing; }
            set { _Prior_Second_Trimester_Testing = value; }
        }
        [DataMember]
        public virtual string FHX_NTD
        {
            get { return _FHX_NTD; }
            set { _FHX_NTD = value; }
        }
        [DataMember]
        public virtual string Prior_Pregnancy_With_Down_Syndrome
        {
            get { return _Prior_Pregnancy_With_Down_Syndrome; }
            set { _Prior_Pregnancy_With_Down_Syndrome = value; }
        }
        [DataMember]
        public virtual string Chorionicity_Monochorionic
        {
            get { return _Chorionicity_Monochorionic; }
            set { _Chorionicity_Monochorionic = value; }
        }
        [DataMember]
        public virtual string Chorionicity_Dichorionic
        {
            get { return _Chorionicity_Dichorionic; }
            set { _Chorionicity_Dichorionic = value; }
        }
        [DataMember]
        public virtual string Chorionicity_Unknown
        {
            get { return _Chorionicity_Unknown; }
            set { _Chorionicity_Unknown = value; }
        }
        [DataMember]
        public virtual string Sonographer_Last_Name
        {
            get { return _Sonographer_Last_Name; }
            set { _Sonographer_Last_Name = value; }
        }
        [DataMember]
        public virtual string Sonographer_First_Name
        {
            get { return _Sonographer_First_Name; }
            set { _Sonographer_First_Name = value; }
        }
        [DataMember]
        public virtual string Sonographer_ID_Number
        {
            get { return _Sonographer_ID_Number; }
            set { _Sonographer_ID_Number = value; }
        }
        [DataMember]
        public virtual string Credentialed_By_FMF
        {
            get { return _Credentialed_By_FMF; }
            set { _Credentialed_By_FMF = value; }
        }
        [DataMember]
        public virtual string Credentialed_By_NTQR
        {
            get { return _Credentialed_By_NTQR; }
            set { _Credentialed_By_NTQR = value; }
        }
        [DataMember]
        public virtual string Credentialed_By_Other_Organization
        {
            get { return _Credentialed_By_Other_Organization; }
            set { _Credentialed_By_Other_Organization = value; }
        }
        [DataMember]
        public virtual string Site_Number
        {
            get { return _Site_Number; }
            set { _Site_Number = value; }
        }
        [DataMember]
        public virtual string Reading_Physician_ID
        {
            get { return _Reading_Physician_ID; }
            set { _Reading_Physician_ID = value; }
        }

        #endregion


    }
}
