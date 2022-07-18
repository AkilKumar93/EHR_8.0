using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]    
    [DataContract]
    public partial class DynamicScreen:BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Dynamic_Screen_ID=0;
        private ulong _Screen_ID = 0;
        private ulong _Master_Vitals_ID = 0;
        private string _Control_Name = string.Empty;
        private string _Control_Type = string.Empty;
        private string _Display_Text = string.Empty;
        private string _LookUp_Field = string.Empty;
        private string _Table_Name = string.Empty;
        private string _Column_Name = string.Empty;
        private string _Mandatory = string.Empty;
        private string _Minimum_Value = string.Empty;
        private string _Maximum_Value = string.Empty;
        private string _Column_Span = string.Empty;
        private string _Is_Editable = string.Empty;
        private string _LookUp_Method = string.Empty;
        private string _Utility_Method = string.Empty;
        private ulong _Parent_Control_ID = 0;
        private int _Maximum_Length = 0;
        private string _Allow_Decimal = string.Empty;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Janani - Main - 30 Jul 2011 - End
        private string _Control_Content_Type = string.Empty;
        private string _Loinc_Identifier = string.Empty;
        private string _Acurus_Result_Code = string.Empty;
        private string _Acurus_Result_Description = string.Empty;
        private string _Is_Flow_Sheet_Required = string.Empty;
        private string _Control_Name_Thin_Client = string.Empty;
        private string _Column_Span_Thin_Client = string.Empty;
        private string _LookUp_Method_Thin_Client = string.Empty;
         private string _Snomed_Code = string.Empty;
         private string _Is_Macra_Field = string.Empty;
        
            
        #endregion

        public DynamicScreen() { }

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Dynamic_Screen_ID);
            sb.Append(_Screen_ID);
            sb.Append(_Master_Vitals_ID);
            sb.Append(_Control_Name);
            sb.Append(_Control_Type);
            sb.Append(_Display_Text);
            sb.Append(_LookUp_Field);
            sb.Append(_Table_Name);
            sb.Append(_Column_Name);
            sb.Append(_Mandatory);
            sb.Append(_Minimum_Value);
            sb.Append(_Maximum_Value);
            sb.Append(_Column_Span);
            sb.Append(_Is_Editable);
            sb.Append(_LookUp_Method);
            sb.Append(_Utility_Method);
            sb.Append(_Parent_Control_ID);
            sb.Append(_Maximum_Length);
            sb.Append(_Allow_Decimal);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            sb.Append(_Loinc_Identifier);
            sb.Append(_Acurus_Result_Code);
            sb.Append(_Acurus_Result_Description);
            sb.Append(_Is_Flow_Sheet_Required);
            sb.Append(_Control_Name_Thin_Client);
            sb.Append(_Column_Span_Thin_Client);
            sb.Append(_LookUp_Method_Thin_Client);
            sb.Append(_Snomed_Code);
            sb.Append(_Is_Macra_Field);
            return sb.ToString().GetHashCode();
        }

        #endregion


        #region Properties

        [DataMember]
        public virtual ulong Dynamic_Screen_ID
        {
            get { return _Dynamic_Screen_ID; }
            set { _Dynamic_Screen_ID = value; }
        }

        [DataMember]
        public virtual ulong Screen_ID
        {
            get { return _Screen_ID; }
            set { _Screen_ID = value; }

        }

        [DataMember]
        public virtual ulong Master_Vitals_ID
        {
            get { return _Master_Vitals_ID; }
            set { _Master_Vitals_ID = value; }
        }
        [DataMember]
        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set { _Snomed_Code = value; }

        }

        [DataMember]
        public virtual string Is_Macra_Field
        {
            get { return _Is_Macra_Field; }
            set { _Is_Macra_Field = value; }

        }


        [DataMember]
        public virtual string Control_Name
        {
            get { return _Control_Name; }
            set { _Control_Name = value; }

        }

        [DataMember]
        public virtual string Control_Type
        {
            get { return _Control_Type; }
            set { _Control_Type = value; }

        }

        [DataMember]
        public virtual string Display_Text
        {
            get { return _Display_Text; }
            set { _Display_Text = value; }

        }

        [DataMember]
        public virtual string LookUp_Field
        {
            get { return _LookUp_Field; }
            set { _LookUp_Field = value; }

        }

        [DataMember]
        public virtual string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }

        }

        [DataMember]
        public virtual string Column_Name
        {
            get { return _Column_Name; }
            set { _Column_Name = value; }

        }

        [DataMember]
        public virtual string Mandatory
        {
            get { return _Mandatory; }
            set { _Mandatory = value; }

        }

        [DataMember]
        public virtual string Minimum_Value
        {
            get { return _Minimum_Value; }
            set { _Minimum_Value = value; }

        }

        [DataMember]
        public virtual string Maximum_Value
        {
            get { return _Maximum_Value; }
            set { _Maximum_Value = value; }

        }

        [DataMember]
        public virtual string Column_Span
        {
            get { return _Column_Span; }
            set { _Column_Span = value; }

        }

         [DataMember]
        public virtual string Is_Editable
        {
            get { return _Is_Editable; }
            set { _Is_Editable = value; }

        }

         [DataMember]
         public virtual string LookUp_Method
         {
             get { return _LookUp_Method; }
             set { _LookUp_Method = value; }

         }
         [DataMember]
         public virtual string Utility_Method
         {
             get { return _Utility_Method; }
             set { _Utility_Method = value; }

         }
         [DataMember]
         public virtual ulong Parent_Control_ID
         {
             get { return _Parent_Control_ID; }
             set { _Parent_Control_ID = value; }
         }

         [DataMember]
         public virtual int Maximum_Length
         {
             get { return _Maximum_Length; }
             set { _Maximum_Length = value; }
         }

         [DataMember]
         public virtual string Allow_Decimal
         {
             get { return _Allow_Decimal; }
             set { _Allow_Decimal = value; }
         }

         //Janani - Main - 30 Jul 2011 - Start
         [DataMember]
         public virtual int Sort_Order
         {
             get { return _Sort_Order; }
             set { _Sort_Order = value; }
         }
        //Janani - Main - 30 Jul 2011 - End

         [DataMember]
         public virtual string Control_Content_Type
         {
             get { return _Control_Content_Type; }
             set { _Control_Content_Type = value; }
         }
         [DataMember]
         public virtual string Loinc_Identifier
         {
             get { return _Loinc_Identifier; }
             set { _Loinc_Identifier = value; }
         }

         [DataMember]
         public virtual string Acurus_Result_Code
         {
             get { return _Acurus_Result_Code; }
             set { _Acurus_Result_Code = value; }
         }
         [DataMember]
         public virtual string Acurus_Result_Description
         {
             get { return _Acurus_Result_Description; }
             set { _Acurus_Result_Description = value; }
         }
         [DataMember]
         public virtual string Is_Flow_Sheet_Required
         {
             get { return _Is_Flow_Sheet_Required; }
             set { _Is_Flow_Sheet_Required = value; }
         }
         [DataMember]
         public virtual string Control_Name_Thin_Client
         {
             get { return _Control_Name_Thin_Client; }
             set { _Control_Name_Thin_Client = value; }

         }

         [DataMember]
         public virtual string Column_Span_Thin_Client
         {
             get { return _Column_Span_Thin_Client; }
             set { _Column_Span_Thin_Client = value; }

         }
         [DataMember]
         public virtual string LookUp_Method_Thin_Client
         {
             get { return _LookUp_Method_Thin_Client; }
             set { _LookUp_Method_Thin_Client = value; }

         }
        #endregion

    }
}
