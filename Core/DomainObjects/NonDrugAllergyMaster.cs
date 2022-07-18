using System;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class NonDrugAllergyMaster : BusinessBase<ulong>
    {
        #region Parameter Variable Decleration

        private ulong _Non_Drug_Allergy_History_ID = 0;
        private ulong _Human_ID = 0;
        private string _Non_Drug_Allergy_History_Info = string.Empty;
        private string _Is_Present = string.Empty;
        private string _Is_Deleted= string.Empty;
        private string _Description = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time;
        private int _version = 0;
        private string _Snomed_Code = string.Empty;

        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Non_Drug_Allergy_History_ID);
            sb.Append(_Human_ID);
            sb.Append(_Non_Drug_Allergy_History_Info);
            sb.Append(_Is_Present);
            sb.Append(_Is_Deleted);
            sb.Append(_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Snomed_Code);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public virtual ulong Non_Drug_Allergy_History_ID
        {
            get { return _Non_Drug_Allergy_History_ID; }
            set { _Non_Drug_Allergy_History_ID = value; }
        }
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        public virtual string Non_Drug_Allergy_History_Info
        {
            get { return _Non_Drug_Allergy_History_Info; }
            set { _Non_Drug_Allergy_History_Info = value; }
        }
        
        public virtual string Is_Present
        {
            get { return _Is_Present; }
            set { _Is_Present = value; }
        }
        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }

        }
       
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        public virtual string Is_Deleted
        {
            get { return _Is_Deleted; }
            set { _Is_Deleted = value; }
        }

        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set
            {
                _Snomed_Code = value;
            }
        }
        #endregion


    }
}
