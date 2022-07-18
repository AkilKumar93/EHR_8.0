using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class PatientInsuredPlan : BusinessBase<ulong>
    {
        #region Declarations


        private ulong _Human_ID = 0;
        private ulong _InsuredHumanID = 0;
        private DateTime _ModifiedDateAndTime = DateTime.MinValue;
        private DateTime _CreatedDateAndTime = DateTime.MinValue;
        private string _ModifiedBy = string.Empty;
        private ulong _InsurancePlanID = 0;
        private string _GroupNumber = string.Empty;
        private string _PolicyHolderID = string.Empty;
        private System.DateTime _EffectiveStartDate = DateTime.MinValue;
        private System.DateTime _TerminationDate = DateTime.MinValue;
        private double _PCPCopay = 0;
        private double _SpecialistCopay = 0;
        private double _Deductible = 0;
        private double _CoInsurance = 0;
        private string _InsuranceType = string.Empty;
        private string _Assignment = string.Empty;
        private string _Relationship = string.Empty;
        private string _Active = string.Empty;
        private ulong _PCPID = 0;
        private string _CreatedBy = string.Empty;
        private int _Relationship_No = 0;
        private int _Version = 0;
        private int _Sort_Order = 0;
        private string _PCP_Name = string.Empty;
        private string _PCP_NPI = string.Empty;
        private double _Deductible_Met_So_Far = 0;
        #endregion

        #region Constructors

        public PatientInsuredPlan() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_InsuredHumanID);
            sb.Append(_ModifiedDateAndTime);
            sb.Append(_CreatedDateAndTime);
            sb.Append(_ModifiedBy);
            sb.Append(_InsurancePlanID);
            sb.Append(_GroupNumber);
            sb.Append(_PolicyHolderID);
            sb.Append(_EffectiveStartDate);
            sb.Append(_TerminationDate);
            sb.Append(_PCPCopay);
            sb.Append(_SpecialistCopay);
            sb.Append(_Deductible);
            sb.Append(_CoInsurance);
            sb.Append(_InsuranceType);
            sb.Append(_InsuranceType);
            sb.Append(_Assignment);
            sb.Append(_Active);
            sb.Append(_PCPID);
            sb.Append(_CreatedBy);
            sb.Append(_Relationship);
            sb.Append(_Relationship_No);
            sb.Append(_Version);
            sb.Append(_Sort_Order);
            sb.Append(_PCP_Name);
            sb.Append(_PCP_NPI);
            sb.Append(_Deductible_Met_So_Far);
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
        public virtual ulong Insured_Human_ID
        {
            get { return _InsuredHumanID; }
            set
            {
                _InsuredHumanID = value;
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
        public virtual string Modified_By
        {
            get { return _ModifiedBy; }
            set
            {
                _ModifiedBy = value;
            }
        }
        [DataMember]
        public virtual ulong Insurance_Plan_ID
        {
            get { return _InsurancePlanID; }
            set
            {
                _InsurancePlanID = value;
            }
        }
        [DataMember]
        public virtual string Group_Number
        {
            get { return _GroupNumber; }
            set
            {
                _GroupNumber = value;
            }
        }
        [DataMember]
        public virtual string Policy_Holder_ID
        {
            get { return _PolicyHolderID; }
            set
            {
                _PolicyHolderID = value;
            }
        }
        [DataMember]
        public virtual DateTime Effective_Start_Date
        {
            get { return _EffectiveStartDate; }
            set
            {
                _EffectiveStartDate = value;
            }
        }
        [DataMember]
        public virtual DateTime Termination_Date
        {
            get { return _TerminationDate; }
            set
            {
                _TerminationDate = value;
            }
        }
        [DataMember]
        public virtual double PCP_Copay
        {
            get { return _PCPCopay; }
            set
            {
                _PCPCopay = value;
            }
        }
        [DataMember]
        public virtual double Specialist_Copay
        {
            get { return _SpecialistCopay; }
            set
            {
                _SpecialistCopay = value;
            }
        }
        [DataMember]
        public virtual double Deductible
        {
            get { return _Deductible; }
            set
            {
                _Deductible = value;
            }
        }
        [DataMember]
        public virtual double Co_Insurance
        {
            get { return _CoInsurance; }
            set
            {
                _CoInsurance = value;
            }
        }
        [DataMember]
        public virtual string Insurance_Type
        {
            get { return _InsuranceType; }
            set
            {
                _InsuranceType = value;
            }
        }
        [DataMember]
        public virtual string Assignment
        {
            get { return _Assignment; }
            set
            {
                _Assignment = value;
            }
        }
        [DataMember]
        public virtual string Relationship
        {
            get { return _Relationship; }
            set
            {
                _Relationship = value;
            }
        }
        [DataMember]
        public virtual string Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
            }
        }
        [DataMember]
        public virtual ulong PCP_ID
        {
            get { return _PCPID; }
            set
            {
                _PCPID = value;
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
        public virtual int Relationship_No
        {
            get { return _Relationship_No; }
            set
            {
                _Relationship_No = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string PCP_Name
        {
            get { return _PCP_Name; }
            set
            {
                _PCP_Name = value;
            }
        }
        [DataMember]
        public virtual string PCP_NPI
        {
            get { return _PCP_NPI; }
            set
            {

                _PCP_NPI = value;
            }
        }
        [DataMember]
        public virtual double Deductible_Met_So_Far
        {
            get { return _Deductible_Met_So_Far; }
            set
            {
                _Deductible_Met_So_Far = value;
            }
        }
        #endregion
    }
}
