using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ProcedureCodeLibrary:BusinessBase<string>
    {
         #region Declarations


        private string _Procedure_Code = string.Empty;
        private string _Procedure_Product_Code = string.Empty;
        private string _Procedure_Description = string.Empty;
        private string _Procedure_CMN_Req = string.Empty;
        private string _Procedure_Type = string.Empty;
        private DateTime _ModifiedDateAndTime=DateTime.MinValue;
        private DateTime _CreatedDateAndTime=DateTime.MinValue;
        private string _CreatedBy = string.Empty;
        private string _ModifiedBy = string.Empty;
        private int _Version=0;
        private string _CVX_Code = string.Empty;
        private string _Procedure_Contract_ID = string.Empty;
        private double _Procedure_Allowed = 0;
        private double _Procedure_Adjust = 0;
        private string _Modifier = string.Empty;
        private double _Procedure_Charge = 0;
        private string _CVX_Code_description = string.Empty;
        private string _Order_Group_Name = string.Empty;
        private int _sort_order = 0;
        private string _short_Description = string.Empty;        
        private string _From_Date = string.Empty;
        private string _To_Date = string.Empty;
        private string _Is_Active = string.Empty;
        private string _Category = string.Empty;
        private string _Default_Dose = string.Empty;
        #endregion

        #region Constructors

        public ProcedureCodeLibrary() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Default_Dose);
            sb.Append(_Procedure_Code);
            sb.Append(_Procedure_Product_Code);
            sb.Append(_Procedure_Description);
            sb.Append(_Procedure_CMN_Req);
            sb.Append(_Procedure_Type);
            sb.Append(_ModifiedDateAndTime);
            sb.Append(_CreatedDateAndTime);
            sb.Append(_CreatedBy);
            sb.Append(_ModifiedBy);
            sb.Append(_Version);
            sb.Append(_CVX_Code);
            sb.Append(_Procedure_Charge);
            sb.Append(_Procedure_Contract_ID);
            sb.Append(_CVX_Code_description);
            sb.Append(_Procedure_Adjust);
            sb.Append(_Procedure_Allowed);
            sb.Append(_Modifier);
            sb.Append(_Order_Group_Name);
            sb.Append(_short_Description);
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_Is_Active);
            sb.Append(_Category);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties

        [DataMember]
        public virtual string Default_Dose
        {
            get { return _Default_Dose; }
            set
            {
                _Default_Dose = value;
            }
        }


       
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set
            {
                _Procedure_Code = value;
            }
        }
      
        
        
        
        [DataMember]
        public virtual string Procedure_Product_Code
        {
            get { return _Procedure_Product_Code; }
            set
            {
                _Procedure_Product_Code = value;
            }
        }
        [DataMember]
        public virtual string Procedure_Description
        {
            get { return _Procedure_Description; }
            set
            {
                _Procedure_Description = value;
            }
        }
        
      
        [DataMember]
        public virtual string Procedure_CMN_Req
        {
            get { return _Procedure_CMN_Req; }
            set
            {
                _Procedure_CMN_Req = value;
            }
        }

        [DataMember]
        public virtual string Procedure_Type
        {
            get { return _Procedure_Type; }
            set
            {
                _Procedure_Type = value;
            }
        }
       
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _ModifiedDateAndTime; }
            set
            {
                _ModifiedDateAndTime = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _CreatedDateAndTime; }
            set
            {
                _CreatedDateAndTime = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _CreatedBy; }
            set
            {
                _CreatedBy = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _ModifiedBy; }
            set
            {
                _ModifiedBy = value;
            }
        }
      

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [DataMember]
        public virtual string CVX_Code
        {
            get { return _CVX_Code; }
            set
            {
                _CVX_Code = value;
            }
        }
        [DataMember]
        public virtual double Procedure_Charge
        {
            get { return _Procedure_Charge; }
            set
            {
                _Procedure_Charge = value;
            }
        }
        [DataMember]
        public virtual string Procedure_Contract_ID
        {
            get { return _Procedure_Contract_ID; }
            set
            {
                _Procedure_Contract_ID = value;
            }
        }
        [DataMember]
        public virtual string CVX_Code_Description
        {
            get { return _CVX_Code_description; }
            set
            {
                _CVX_Code_description = value;
            }
        }

        [DataMember]
        public virtual double Procedure_Allowed
        {
            get { return _Procedure_Allowed; }
            set
            {
                _Procedure_Allowed = value;
            }
        }
        [DataMember]
        public virtual double Procedure_Adjust
        {
            get { return _Procedure_Adjust; }
            set
            {
                _Procedure_Adjust = value;
            }
        }
        [DataMember]
        public virtual string Modifier
        {
            get { return _Modifier; }
            set
            {
                _Modifier = value;
            }
        }
        [DataMember]
        public virtual string Order_Group_Name
        {
            get { return _Order_Group_Name; }
            set { _Order_Group_Name = value; }
        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _sort_order; }
            set { _sort_order = value; }
        }

        [DataMember]
        public virtual string Short_Description
        {
            get { return _short_Description; }
            set
            {
                _short_Description = value;
            }
        }
        [DataMember]
        public virtual string From_Date
        {
            get { return _From_Date; }
            set
            {
                _From_Date = value;
            }
        }
        [DataMember]
        public virtual string To_Date
        {
            get { return _To_Date; }
            set
            {
                _To_Date = value;
            }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set
            {
                _Is_Active = value;
            }
        }
        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
            }
        }
        #endregion

    }
}
