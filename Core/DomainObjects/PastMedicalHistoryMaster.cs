using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class PastMedicalHistoryMaster : BusinessBase<ulong>
    {
        #region Parameter Variable Decleration

        //private ulong _Past_Medical_History_ID = 0;
        private ulong _Human_ID=0;
        private string _Past_Medical_Info = string.Empty;
        private string _From_Date = string.Empty;
        private string _To_Date = string.Empty;
        private string _Notes = string.Empty;
        private string _Is_present = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time=DateTime.MinValue ;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        //private ulong _Encounter_Id = 0;
        //private IList<ProblemList> _probListBag;

        private int _version = 0;

        private string _Is_Mandatory = string.Empty;
        private string _AHA_Question_ICD = string.Empty;
        private string _Is_Deleted = "N";

        #endregion

        #region GetHashValue

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            //sb.Append(_Past_Medical_History_ID);
            sb.Append(_Human_ID);
            sb.Append(_Past_Medical_Info);
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_Notes);
            sb.Append(_Is_present);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
           // sb.Append(_probListBag);
            sb.Append(_AHA_Question_ICD);
            sb.Append(_Is_Mandatory);
            sb.Append(_version);
            sb.Append(_Is_Deleted);
           // sb.Append(_Encounter_Id);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Value Implementation
        
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        //public virtual ulong Past_Medical_History_ID
        //{
        //    get { return _Past_Medical_History_ID; }
        //    set { _Past_Medical_History_ID = value; }
        //}
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        public virtual string Past_Medical_Info
        {
            get { return _Past_Medical_Info; }
            set { _Past_Medical_Info = value; }
        }
        public virtual string From_Date
        {
            get { return _From_Date; }
            set { _From_Date = value; }
        }
        public virtual string To_Date
        {
            get { return _To_Date; }
            set { _To_Date = value; }
        }
        public virtual string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public virtual string Is_present
        {
            get { return _Is_present; }
            set { _Is_present = value; }
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
        public virtual string AHA_Question_ICD
        {
            get { return _AHA_Question_ICD; }
            set { _AHA_Question_ICD = value; }
        }
        public virtual string Is_Mandatory
        {
            get { return _Is_Mandatory; }
            set { _Is_Mandatory = value; }
        }
        public virtual string Is_Deleted
        {
            get { return _Is_Deleted; }
            set { _Is_Deleted = value; }
        }
        //public virtual ulong Encounter_Id
        //{
        //    get { return _Encounter_Id; }
        //    set { _Encounter_Id = value; }
        //}

        //[DataMember]
        //public virtual IList<ProblemList> ProblemListBag
        //{
        //    get { return _probListBag; }
        //    set { _probListBag = value; }
        //}
        #endregion
    }
}
