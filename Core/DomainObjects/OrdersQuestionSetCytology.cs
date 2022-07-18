using System;
using System.Runtime.Serialization;
using System.Reflection;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrdersQuestionSetCytology:BusinessBase<ulong>
    {
         #region Declarations

        private ulong _Order_ID = 0;
        private string _Gyn_Source_Cervical = string.Empty;
        private string _Gyn_Source_Endocervical = string.Empty;
        private string _Gyn_Source_Labia_Vulva = string.Empty;
        private string _Gyn_Source_Vaginal = string.Empty;
        private string _Gyn_Source_Endometrial = string.Empty;
        private string _Gyn_Source_Hysterectomy_Supracervical = string.Empty;
        private string _Collection_Technique_Swab_Spatula = string.Empty;
        private string _Collection_Technique_Brush_Spatula = string.Empty;
        private string _Collection_Technique_Spatula_Alone = string.Empty;
        private string _Collection_Technique_Brush_Alone= string.Empty;
        private string _Collection_Technique_Broom_Alone = string.Empty;
        private string _Collection_Technique_Other =string.Empty;
        private string _Created_By=string.Empty;
        private string _Modified_By=string.Empty;       
        private DateTime _Created_Date_And_Time=DateTime.MinValue;
        private DateTime _Modified_Date_And_Time=DateTime.MinValue;
        private int _Version=0;
        private DateTime _LMP_Meno_Date= DateTime.MinValue;
        private string _Previous_Treatment_None = string.Empty;
        private string _Previous_Treatment_Hyst = string.Empty;
        private string _Previous_Treatment_Coniza = string.Empty;
        private string _Previous_Treatment_Colp_BX = string.Empty;
        private string _Previous_Treatment_Laser_Vap = string.Empty;
        private string _Previous_Treatment_Cyro = string.Empty;
        private string _Previous_Treatment_Radiation = string.Empty;
        private string _Previous_Cytology_Info_Negative = string.Empty;
        private string _Previous_Cytology_Info_Atypical = string.Empty;
        private string _Previous_Cytology_Info_Dysplasia = string.Empty;
        private string _Previous_Cytology_Info_Ca_In_Situ = string.Empty;
        private string _Previous_Cytology_Info_Invasive = string.Empty;
        private string _Previous_Cytology_Info_Other = string.Empty;
        private string _Previous_Cytology_Info_Dates_Results = string.Empty;
        private string _Other_Patient_Info_Pregnant = string.Empty;
        private string _Other_Patient_Info_Lactating = string.Empty;
        private string _Other_Patient_Info_Oral_Contraceptives = string.Empty;
        private string _Other_Patient_Info_Menopausal = string.Empty;
        private string _Other_Patient_Info_Estro_RX = string.Empty;
        private string _Other_Patient_Info_PMP_Bleeding = string.Empty;
        private string _Other_Patient_Info_Post_Part = string.Empty;
        private string _Other_Patient_Info_IUD = string.Empty;
        private string _Other_Patient_Info_All_Other_Pat = string.Empty;
        

        #endregion

        #region Constructors

        public OrdersQuestionSetCytology() { }

        public OrdersQuestionSetCytology(OrdersQuestionSetCytology obj) 
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
            sb.Append(_Gyn_Source_Cervical);
            sb.Append(_Gyn_Source_Endocervical);
            sb.Append(_Gyn_Source_Labia_Vulva);
            sb.Append(_Gyn_Source_Vaginal);
            sb.Append(_Gyn_Source_Endometrial);
            sb.Append(_Gyn_Source_Hysterectomy_Supracervical);
            sb.Append(_Collection_Technique_Swab_Spatula);
            sb.Append(_Collection_Technique_Brush_Spatula);
            sb.Append(_Collection_Technique_Spatula_Alone);
            sb.Append(_Collection_Technique_Brush_Alone);
            sb.Append(_Collection_Technique_Broom_Alone);
            sb.Append(_Collection_Technique_Other);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_LMP_Meno_Date);
            sb.Append(_Previous_Treatment_None);
            sb.Append(_Previous_Treatment_Hyst);
            sb.Append(_Previous_Treatment_Coniza);
            sb.Append(_Previous_Treatment_Colp_BX);
            sb.Append(_Previous_Treatment_Laser_Vap);
            sb.Append(_Previous_Treatment_Cyro);
            sb.Append(_Previous_Treatment_Radiation);
            sb.Append(_Previous_Cytology_Info_Negative);
            sb.Append(_Previous_Cytology_Info_Atypical);
            sb.Append(_Previous_Cytology_Info_Dysplasia);
            sb.Append(_Previous_Cytology_Info_Ca_In_Situ);
            sb.Append(_Previous_Cytology_Info_Invasive);
            sb.Append(_Previous_Cytology_Info_Other);
            sb.Append(_Previous_Cytology_Info_Dates_Results);
            sb.Append(_Other_Patient_Info_Pregnant);
            sb.Append(_Other_Patient_Info_Lactating);
            sb.Append(_Other_Patient_Info_Oral_Contraceptives);
            sb.Append(_Other_Patient_Info_Menopausal);
            sb.Append(_Other_Patient_Info_Estro_RX);
            sb.Append(_Other_Patient_Info_PMP_Bleeding);
            sb.Append(_Other_Patient_Info_Post_Part);
            sb.Append(_Other_Patient_Info_IUD);
            sb.Append(_Other_Patient_Info_All_Other_Pat);
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
        public virtual string Gyn_Source_Cervical
        {
            get { return _Gyn_Source_Cervical; }
            set { _Gyn_Source_Cervical = value; }
        }

        [DataMember]
        public virtual string Gyn_Source_Endocervical
        {
            get { return _Gyn_Source_Endocervical; }
            set { _Gyn_Source_Endocervical = value; }
        }
        [DataMember]
        public virtual string Gyn_Source_Labia_Vulva
        {
            get { return _Gyn_Source_Labia_Vulva; }
            set { _Gyn_Source_Labia_Vulva = value; }
        }

        [DataMember]
        public virtual string Gyn_Source_Vaginal
        {
            get { return _Gyn_Source_Vaginal; }
            set { _Gyn_Source_Vaginal = value; }
        }
        [DataMember]
        public virtual string Gyn_Source_Endometrial
        {
            get { return _Gyn_Source_Endometrial; }
            set { _Gyn_Source_Endometrial = value; }
        }

             
        [DataMember]
        public virtual string Gyn_Source_Hysterectomy_Supracervical
        {
            get { return _Gyn_Source_Hysterectomy_Supracervical; }
            set { _Gyn_Source_Hysterectomy_Supracervical = value; }
        }

        [DataMember]
        public virtual string Collection_Technique_Swab_Spatula
        {
            get { return _Collection_Technique_Swab_Spatula; }
            set { _Collection_Technique_Swab_Spatula = value; }
        }

        [DataMember]
        public virtual string Collection_Technique_Brush_Spatula
        {
            get { return _Collection_Technique_Brush_Spatula; }
            set { _Collection_Technique_Brush_Spatula = value; }
        }
        [DataMember]
        public virtual string Collection_Technique_Spatula_Alone
        {
            get { return _Collection_Technique_Spatula_Alone; }
            set { _Collection_Technique_Spatula_Alone = value; }
        }
        [DataMember]
        public virtual string Collection_Technique_Brush_Alone
        {
            get { return _Collection_Technique_Brush_Alone; }
            set { _Collection_Technique_Brush_Alone = value; }
        }
        [DataMember]
        public virtual string Collection_Technique_Broom_Alone
        {
            get { return _Collection_Technique_Broom_Alone; }
            set { _Collection_Technique_Broom_Alone = value; }
        }
        [DataMember]
        public virtual string Collection_Technique_Other
        {
            get { return _Collection_Technique_Other; }
            set { _Collection_Technique_Other = value; }
        }
        
        [DataMember]
        public virtual DateTime LMP_Meno_Date
        {
            get { return _LMP_Meno_Date; }
            set { _LMP_Meno_Date = value; }
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
        public virtual string Previous_Treatment_None
        {
            get { return _Previous_Treatment_None; }
            set { _Previous_Treatment_None = value; }
        }

        
        [DataMember]
        public virtual string Previous_Treatment_Hyst
        {
            get { return _Previous_Treatment_Hyst; }
            set { _Previous_Treatment_Hyst = value; }
        }

        [DataMember]
        public virtual string Previous_Treatment_Coniza
        {
            get { return _Previous_Treatment_Coniza; }
            set { _Previous_Treatment_Coniza = value; }
        }

        [DataMember]
        public virtual string Previous_Treatment_Colp_BX
        {
            get { return _Previous_Treatment_Colp_BX; }
            set
            {
                _Previous_Treatment_Colp_BX = value;
            }
        }

        [DataMember]
        public virtual string Previous_Treatment_Laser_Vap
        {
            get { return _Previous_Treatment_Laser_Vap; }
            set { _Previous_Treatment_Laser_Vap = value; }
        }
        [DataMember]
        public virtual string Previous_Treatment_Cyro
        {
            get { return _Previous_Treatment_Cyro; }
            set { _Previous_Treatment_Cyro = value; }
        }

        [DataMember]
        public virtual string Previous_Treatment_Radiation
        {
            get { return _Previous_Treatment_Radiation; }
            set { _Previous_Treatment_Radiation = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Negative
        {
            get { return _Previous_Cytology_Info_Negative; }
            set { _Previous_Cytology_Info_Negative = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Atypical
        {
            get { return _Previous_Cytology_Info_Atypical; }
            set { _Previous_Cytology_Info_Atypical = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Dysplasia
        {
            get { return _Previous_Cytology_Info_Dysplasia; }
            set { _Previous_Cytology_Info_Dysplasia = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Ca_In_Situ
        {
            get { return _Previous_Cytology_Info_Ca_In_Situ; }
            set { _Previous_Cytology_Info_Ca_In_Situ = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Invasive
        {
            get { return _Previous_Cytology_Info_Invasive; }
            set { _Previous_Cytology_Info_Invasive = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Other
        {
            get { return _Previous_Cytology_Info_Other; }
            set { _Previous_Cytology_Info_Other = value; }
        }

        [DataMember]
        public virtual string Previous_Cytology_Info_Dates_Results
        {
            get { return _Previous_Cytology_Info_Dates_Results; }
            set { _Previous_Cytology_Info_Dates_Results = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_Pregnant
        {
            get { return _Other_Patient_Info_Pregnant; }
            set { _Other_Patient_Info_Pregnant = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_Lactating
        {
            get { return _Other_Patient_Info_Lactating; }
            set { _Other_Patient_Info_Lactating = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_Oral_Contraceptives
        {
            get { return _Other_Patient_Info_Oral_Contraceptives; }
            set { _Other_Patient_Info_Oral_Contraceptives = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_Menopausal
        {
            get { return _Other_Patient_Info_Menopausal; }
            set { _Other_Patient_Info_Menopausal = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_Estro_RX
        {
            get { return _Other_Patient_Info_Estro_RX; }
            set { _Other_Patient_Info_Estro_RX = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_PMP_Bleeding
        {
            get { return _Other_Patient_Info_PMP_Bleeding; }
            set { _Other_Patient_Info_PMP_Bleeding = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_Post_Part
        {
            get { return _Other_Patient_Info_Post_Part; }
            set { _Other_Patient_Info_Post_Part = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_IUD
        {
            get { return _Other_Patient_Info_IUD; }
            set { _Other_Patient_Info_IUD = value; }
        }
        [DataMember]
        public virtual string Other_Patient_Info_All_Other_Pat
        {
            get { return _Other_Patient_Info_All_Other_Pat; }
            set { _Other_Patient_Info_All_Other_Pat = value; }
        }
        

        #endregion
    }
}
