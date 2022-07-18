using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrderCodeLibrary:BusinessBase<string>
    {
          #region Declarations

         private string _CPT_Code = string.Empty;
         private string _CPT_Code_Description = string.Empty;
         private string _Order_Code=string.Empty;
         private string _Order_Code_Name = string.Empty;
        private ulong _Lab_ID=0;
        private string _Order_Code_Procedure_Class = string.Empty;
        private string _Order_Code_Type = string.Empty;
        private string _Order_Code_Question_Set_Segment = string.Empty;
        private string _Temperature_State = string.Empty;
        private string _PAP_Indicator = string.Empty;
        private string _Order_Group_Name = string.Empty;
        private string _Loinc = string.Empty;

        
        #endregion

        #region Constructors

        public OrderCodeLibrary() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_CPT_Code);
            sb.Append(_CPT_Code_Description);
            sb.Append(_Order_Code);
            sb.Append(_Order_Code_Name);
            sb.Append(_Lab_ID);
            sb.Append(_Order_Code_Procedure_Class);
            sb.Append(_Order_Code_Type);
            sb.Append(_Order_Code_Question_Set_Segment);
            sb.Append(_Temperature_State);
            sb.Append(_PAP_Indicator);
            sb.Append(_Order_Group_Name);
            sb.Append(_Loinc);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
              
        [DataMember]
        public virtual string CPT_Code
        {
            get { return _CPT_Code; }
            set { _CPT_Code = value; }
        }
        [DataMember]
        public virtual string CPT_Code_Description
        {
            get { return _CPT_Code_Description; }
            set { _CPT_Code_Description = value; }
        }

        [DataMember]
        public virtual string Order_Code
        {
            get { return _Order_Code; }
            set { _Order_Code = value; }
        }
        [DataMember]
        public virtual string Order_Code_Name
        {
            get { return _Order_Code_Name; }
            set { _Order_Code_Name = value; }
        }

        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        [DataMember]
        public virtual string Order_Code_Procedure_Class
        {
            get { return _Order_Code_Procedure_Class; }
            set { _Order_Code_Procedure_Class = value; }
        }
        [DataMember]
        public virtual string Order_Code_Type
        {
            get { return _Order_Code_Type; }
            set { _Order_Code_Type = value; }
        }

        [DataMember]
        public virtual string Order_Code_Question_Set_Segment
        {
            get { return _Order_Code_Question_Set_Segment; }
            set { _Order_Code_Question_Set_Segment = value; }
        }


        [DataMember]
        public virtual string Temperature_State
        {
            get { return _Temperature_State; }
            set { _Temperature_State = value; }
        }

        [DataMember]
        public virtual string PAP_Indicator
        {
            get { return _PAP_Indicator; }
            set { _PAP_Indicator = value; }
        }
        [DataMember]
        public virtual string Order_Group_Name
        {
            get { return _Order_Group_Name; }
            set { _Order_Group_Name = value; }
        }
        [DataMember]
        public virtual string Loinc
        {
            get { return _Loinc; }
            set { _Loinc = value; }
        }
        
        #endregion
    }
}
