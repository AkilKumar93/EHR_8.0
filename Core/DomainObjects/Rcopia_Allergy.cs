using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Rcopia_Allergy : BusinessBase<ulong>
    {
        #region Declarations


        private ulong _Human_ID = 0;
        private string _External_ID = string.Empty;
        private string _Allergy_Name = string.Empty;
        private string _NDC_ID = string.Empty;
        private string _First_DataBank_Med_ID = string.Empty;
        private string _Reaction = string.Empty;
        private DateTime _OnsetDate = DateTime.MinValue;
        private string _Last_Modified_By = string.Empty;
        private DateTime _Last_Modified_Date = DateTime.MinValue;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Status = string.Empty;
        private int _Version=0;
        private string _Deleted=string.Empty ;
        private ulong _Rxnorm_ID = 0;
        private string _Rxnorm_ID_Type = string.Empty;
        private string _DataFrom = string.Empty;
        private string _Notes = string.Empty;
        private string _Reaction_Snomed_Code = string.Empty;
        private string _Reaction_Snomed_Description = string.Empty;
        private string _Severity = string.Empty;
        private string _Severity_Snomed_Code = string.Empty;
        private string _Severity_Snomed_Description = string.Empty;

        #endregion

        #region Constructors

        public Rcopia_Allergy() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_External_ID);
            sb.Append(_Allergy_Name);
            sb.Append(_NDC_ID);
            sb.Append(_First_DataBank_Med_ID);
            sb.Append(_Reaction);
            sb.Append(_OnsetDate);
            sb.Append(_Last_Modified_By);
            sb.Append(_Last_Modified_Date);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Status);
            sb.Append(_Version);
            sb.Append(_Deleted);
            sb.Append(_Rxnorm_ID);
            sb.Append(_Rxnorm_ID_Type);
            sb.Append(_DataFrom);
            sb.Append(_Notes);
            sb.Append(_Reaction_Snomed_Code);
            sb.Append(_Reaction_Snomed_Description);
            sb.Append(_Severity);
            sb.Append(_Severity_Snomed_Code);
            sb.Append(_Severity_Snomed_Description);
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
        public virtual string External_ID
        {
            get { return _External_ID; }
            set
            {
                _External_ID = value;
            }
        }
        [DataMember]
         public virtual string Allergy_Name
        {
            get { return _Allergy_Name; }
            set
            {
                _Allergy_Name = value;
            }
        }
        [DataMember]
        public virtual string NDC_ID
        {
            get { return _NDC_ID; }
            set
            {
                _NDC_ID = value;
            }
        }
        [DataMember]
        public virtual string First_DataBank_Med_ID
        {
            get { return _First_DataBank_Med_ID; }
            set
            {
                _First_DataBank_Med_ID = value;
            }
        }
        [DataMember]
        public virtual string Reaction
        {
            get { return _Reaction; }
            set
            {
                _Reaction = value;
            }
        }
        [DataMember]
        public virtual DateTime OnsetDate
        {
            get { return _OnsetDate; }
            set
            {
                _OnsetDate = value;
            }
        }
        [DataMember]
        public virtual string Last_Modified_By
        {
            get { return _Last_Modified_By; }
            set
            {
                _Last_Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Last_Modified_Date
        {
            get { return _Last_Modified_Date; }
            set
            {
                _Last_Modified_Date = value;
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
        public virtual string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual string Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }
        
        [DataMember]
        public virtual ulong Rxnorm_ID
        {
            get { return _Rxnorm_ID; }
            set
            {
                _Rxnorm_ID = value;
            }
        }
        [DataMember]
        public virtual string Rxnorm_ID_Type
        {
            get { return _Rxnorm_ID_Type; }
            set { _Rxnorm_ID_Type = value; }
        }
        [DataMember]
        public virtual string DataFrom
        {
            get { return _DataFrom; }
            set { _DataFrom = value; }
        }
        [DataMember]
        public virtual string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        [DataMember]
        public virtual string Reaction_Snomed_Code
        {
            get { return _Reaction_Snomed_Code; }
            set { _Reaction_Snomed_Code = value; }
        }
        [DataMember]
        public virtual string Severity
        {
            get { return _Severity; }
            set { _Severity = value; }
        }
        [DataMember]
        public virtual string Severity_Snomed_Code
        {
            get { return _Severity_Snomed_Code; }
            set { _Severity_Snomed_Code = value; }
        }



        #endregion



    }
}
