using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Loinc:BusinessBase<ulong>
    {
        #region Declarations


        private string _Loinc_Num = string.Empty;
        private string _Component = string.Empty;
        private string _Property = string.Empty;
        private string _Time_Aspct = string.Empty;
        private string _System = string.Empty;

        private string _Scale_Typ = string.Empty;
        private string _Method_Typ = string.Empty;
        private string _Relat_NMS = string.Empty;
        private string _Class = string.Empty;
        private string _Source = string.Empty;

        private string _Dt_Last_Ch = string.Empty;
        private string _Chng_Type = string.Empty;
        private string _Comments = string.Empty;
        private string _AnswerList = string.Empty;
        private string _Status = string.Empty;


        private string _Map_To = string.Empty;
        private string _Scope = string.Empty;
        private string _Consumer_Name = string.Empty;
        private string _IPCC_Units = string.Empty;
        private string _Reference = string.Empty;

        private string _Exact_Cmp_Sy = string.Empty;
        private string _Molar_Mass = string.Empty;
        private ulong _ClassType = 0;
        private string _Formula = string.Empty;
        private string _Species = string.Empty;

        private string _Exmpl_Answers = string.Empty;
        private string _AcsSym = string.Empty;
        private string _Base_Name = string.Empty;
        private string _Final = string.Empty;
        private string _Naaccr_ID = string.Empty;

        private string _Code_Table = string.Empty;
        private string _SetRoot = string.Empty;
        private string _Panelelements = string.Empty;
        private string _Survey_Quest_Text = string.Empty;
        private string _Survey_Quest_Src = string.Empty;

        private string _UnitsRequired = string.Empty;
        private string _Submitted_Units = string.Empty;
        private string _RelatedNames2 = string.Empty;
        private string _ShortName = string.Empty;
        private string _Order_Obs = string.Empty;

        private string _CDISCCode = string.Empty;
        private string _HL7_Field_SubField_ID = string.Empty;
        private string _External_Copyright_Notice = string.Empty;
        private string _Example_Units = string.Empty;
        private string _Inpc_Percentage = string.Empty;

        private string _Long_Common_Name = string.Empty;
        private string _HL7_V2_DataType = string.Empty;
        private string _HL7_V3_DataType = string.Empty;
        private string _Curated_Range_And_Units = string.Empty;

        private string _Document_Sections = string.Empty;
        private string _Definition_Description_Help = string.Empty;
        private string _Example_Ucum_Units = string.Empty;
        private string _Example_Si_Ucum_Units = string.Empty;

        private string _Status_Reason = string.Empty;
        private string _Status_Text = string.Empty;
        //private string _Special_Explanation = string.Empty;

        private int _Sort_Order = 0;
        private string _Change_Reason_Public = string.Empty;
        private string _Common_Test_Rank = string.Empty;

 

        #endregion

        #region Constructors

        public Loinc() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Loinc_Num);
            sb.Append(_Component);
            sb.Append(_Property);
            sb.Append(_Time_Aspct);
            sb.Append(_System);

            sb.Append(_Scale_Typ);
            sb.Append(_Method_Typ);
            sb.Append(_Relat_NMS);
            sb.Append(_Class);
            sb.Append(_Source);

            sb.Append(_Dt_Last_Ch);
            sb.Append(_Chng_Type);
            sb.Append(_Comments);
            sb.Append(_AnswerList);
            sb.Append(_Status);


            sb.Append(_Map_To);
            sb.Append(_Scope);
            sb.Append(_Consumer_Name);
            sb.Append(_IPCC_Units);
            sb.Append(_Reference);

            sb.Append(_Exact_Cmp_Sy);
            sb.Append(_Molar_Mass);
            sb.Append(_ClassType);
            sb.Append(_Formula);
            sb.Append(_Species);

            sb.Append(_Exmpl_Answers);
            sb.Append(_AcsSym);
            sb.Append(_Base_Name);
            sb.Append(_Final);
            sb.Append(_Naaccr_ID);

            sb.Append(_Code_Table);
            sb.Append(_SetRoot);
            sb.Append(_Panelelements);
            sb.Append(_Survey_Quest_Text);
            sb.Append(_Survey_Quest_Src);

            sb.Append(_UnitsRequired);
            sb.Append(_Submitted_Units);
            sb.Append(_RelatedNames2);
            sb.Append(_ShortName);
            sb.Append(_Order_Obs);

            sb.Append(_CDISCCode);
            sb.Append(_HL7_Field_SubField_ID);
            sb.Append(_External_Copyright_Notice);
            sb.Append(_Example_Units);
            sb.Append(_Inpc_Percentage);

            sb.Append(_Long_Common_Name);
            sb.Append(_HL7_V2_DataType);
            sb.Append(_HL7_V3_DataType);
            sb.Append(_Curated_Range_And_Units);

            sb.Append(_Document_Sections);
            sb.Append(_Definition_Description_Help);
            sb.Append(_Example_Ucum_Units);
            sb.Append(_Example_Si_Ucum_Units);

            sb.Append(_Status_Reason);
            sb.Append(_Status_Text);
            //sb.Append(_Special_Explanation);

            sb.Append(_Sort_Order);
            sb.Append(_Change_Reason_Public);
            sb.Append(_Common_Test_Rank);


            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Loinc_Num
        {
            get { return _Loinc_Num; }
            set { _Loinc_Num = value; }
        }

        [DataMember]
        public virtual string Component
        {
            get { return _Component; }
            set { _Component = value; }
        }


        [DataMember]
        public virtual string Property
        {
            get { return _Property ; }
            set { _Property = value; }
        }

        [DataMember]
        public virtual string Time_Aspct
        {
            get { return _Time_Aspct ; }
            set { _Time_Aspct = value; }
        }


        [DataMember]
        public virtual string System
        {
            get { return _System ; }
            set { _System = value; }
        }

        [DataMember]
        public virtual string Scale_Typ
        {
            get { return _Scale_Typ ; }
            set { _Scale_Typ = value; }
        }


        [DataMember]
        public virtual string Method_Typ
        {
            get { return _Method_Typ; }
            set { _Method_Typ = value; }
        }

        [DataMember]
        public virtual string Relat_NMS
        {
            get { return _Relat_NMS ; }
            set { _Relat_NMS = value; }
        }

        [DataMember]
        public virtual string Class
        {
            get { return _Class; }
            set { _Class = value; }
        }

        [DataMember]
        public virtual string Source
        {
            get { return _Source ; }
            set { _Source = value; }
        }


        [DataMember]
        public virtual string Dt_Last_Ch
        {
            get { return _Dt_Last_Ch ; }
            set { _Dt_Last_Ch = value; }
        }

        [DataMember]
        public virtual string Chng_Type
        {
            get { return _Chng_Type  ; }
            set { _Chng_Type = value; }
        }

        [DataMember]
        public virtual string Comments
        {
            get { return _Comments ; }
            set { _Comments = value; }
        }

        [DataMember]
        public virtual string AnswerList
        {
            get { return _AnswerList ; }
            set { _AnswerList = value; }
        }


        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        [DataMember]
        public virtual string Map_To
        {
            get { return _Map_To; }
            set { _Map_To = value; }
        }

        [DataMember]
        public virtual string Scope
        {
            get { return _Scope; }
            set { _Scope = value; }
        }

        [DataMember]
        public virtual string Consumer_Name
        {
            get { return _Consumer_Name; }
            set { _Consumer_Name = value; }
        }


        [DataMember]
        public virtual string IPCC_Units
        {
            get { return _IPCC_Units; }
            set { _IPCC_Units = value; }
        }

        [DataMember]
        public virtual string Reference
        {
            get { return _Reference; }
            set { _Reference = value; }


        }


        [DataMember]
        public virtual string Exact_Cmp_Sy
        {
            get { return _Exact_Cmp_Sy; }
            set { _Exact_Cmp_Sy = value; }
        }

        [DataMember]
        public virtual string Molar_Mass
        {
            get { return _Molar_Mass; }
            set { _Molar_Mass = value; }
        }


        [DataMember]
        public virtual ulong ClassType
        {
            get { return _ClassType; }
            set { _ClassType = value; }
        }

        [DataMember]
        public virtual string Formula
        {
            get { return _Formula; }
            set { _Formula = value; }
        }


        [DataMember]
        public virtual string Species
        {
            get { return _Species; }
            set { _Species = value; }
        }

        [DataMember]
        public virtual string Exmpl_Answers
        {
            get { return _Exmpl_Answers; }
            set { _Exmpl_Answers = value; }
        }


        [DataMember]
        public virtual string AcsSym
        {
            get { return _AcsSym; }
            set { _AcsSym = value; }
        }

        [DataMember]
        public virtual string Base_Name
        {
            get { return _Base_Name; }
            set { _Base_Name = value; }

        }

        [DataMember]
        public virtual string Final
        {
            get { return _Final; }
            set { _Final = value; }
        }

        [DataMember]
        public virtual string Naaccr_ID
        {
            get { return _Naaccr_ID; }
            set { _Naaccr_ID = value; }
        }


        [DataMember]
        public virtual string Code_Table
        {
            get { return _Code_Table; }
            set { _Code_Table = value; }
        }

        [DataMember]
        public virtual string SetRoot
        {
            get { return _SetRoot; }
            set { _SetRoot = value; }
        }

        [DataMember]
        public virtual string Panelelements
        {
            get { return _Panelelements; }
            set { _Panelelements = value; }
        }

        [DataMember]
        public virtual string Survey_Quest_Text
        {
            get { return _Survey_Quest_Text; }
            set { _Survey_Quest_Text = value; }
        }


        [DataMember]
        public virtual string Survey_Quest_Src
        {
            get { return _Survey_Quest_Src; }
            set { _Survey_Quest_Src = value; }
        }

        [DataMember]
        public virtual string UnitsRequired
        {
            get { return _UnitsRequired; }
            set { _UnitsRequired = value; }
        }


        [DataMember]
        public virtual string Submitted_Units
        {
            get { return _Submitted_Units; }
            set { _Submitted_Units = value; }

        }

        [DataMember]
        public virtual string RelatedNames2
        {
            get { return _RelatedNames2; }
            set { _RelatedNames2 = value; }
        }

        [DataMember]
        public virtual string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }


        [DataMember]
        public virtual string Order_Obs
        {
            get { return _Order_Obs; }
            set { _Order_Obs = value; }
        }

        [DataMember]
        public virtual string CDISCCode
        {
            get { return _CDISCCode; }
            set { _CDISCCode = value; }
        }

        [DataMember]
        public virtual string HL7_Field_SubField_ID
        {
            get { return _HL7_Field_SubField_ID; }
            set { _HL7_Field_SubField_ID = value; }
        }

        [DataMember]
        public virtual string External_Copyright_Notice
        {
            get { return _External_Copyright_Notice; }
            set { _External_Copyright_Notice = value; }
        }


        [DataMember]
        public virtual string Example_Units
        {
            get { return _Example_Units; }
            set { _Example_Units = value; }
        }

        [DataMember]
        public virtual string Inpc_Percentage
        {
            get { return _Inpc_Percentage; }
            set { _Inpc_Percentage = value; }
        }


        [DataMember]
        public virtual string Long_Common_Name
        {
            get { return _Long_Common_Name; }
            set { _Long_Common_Name = value; }
        }

        [DataMember]
        public virtual string HL7_V2_DataType
        {
            get { return _HL7_V2_DataType; }
            set { _HL7_V2_DataType = value; }
        }

        [DataMember]
        public virtual string HL7_V3_DataType
        {
            get { return _HL7_V3_DataType; }
            set { _HL7_V3_DataType = value; }
        }

        [DataMember]
        public virtual string Curated_Range_And_Units
        {
            get { return _Curated_Range_And_Units; }
            set { _Curated_Range_And_Units = value; }
        }

        [DataMember]
        public virtual string Document_Sections
        {
            get { return _Document_Sections; }
            set { _Document_Sections = value; }
        }

        [DataMember]
        public virtual string Definition_Description_Help
        {
            get { return _Definition_Description_Help; }
            set { _Definition_Description_Help = value; }
        }


        [DataMember]
        public virtual string Example_Ucum_Units
        {
            get { return _Example_Ucum_Units; }
            set { _Example_Ucum_Units = value; }
        }

        [DataMember]
        public virtual string Example_Si_Ucum_Units
        {
            get { return _Example_Si_Ucum_Units; }
            set { _Example_Si_Ucum_Units = value; }
        }

        [DataMember]
        public virtual string Status_Reason
        {
            get { return _Status_Reason; }
            set { _Status_Reason = value; }
        }

        [DataMember]
        public virtual string Status_Text
        {
            get { return _Status_Text; }
            set { _Status_Text = value; }
        }

        //[DataMember]
        //public virtual string Special_Explanation
        //{
        //    get { return _Special_Explanation; }
        //    set { _Special_Explanation = value; }
        //}

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }

        [DataMember]
        public virtual string Change_Reason_Public
        {
            get { return _Change_Reason_Public; }
            set { _Change_Reason_Public = value; }
        }

        [DataMember]
        public virtual string Common_Test_Rank
        {
            get { return _Common_Test_Rank; }
            set { _Common_Test_Rank = value; }
        }

        #endregion
    }
}
