using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{

    [Serializable]
    public partial class SocialHistoryMaster : BusinessBase<ulong>
    {
        //Commented by vaishali on 17-11-2015
        //private ulong _Social_History_ID=0;
        private ulong _Human_ID=0;
        private string _Social_Info = string.Empty;

        private string _Is_Present = string.Empty;
        private string _Description = string.Empty;
        
        private string _Value = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time;
        private int _version = 0;
        private string _Is_Mandatory = string.Empty;
        private string _recodes = string.Empty;
        //private string _Reason_Not_Performed = string.Empty;
        private string _Snomed_Reason_Not_Performed = string.Empty;
        private string _Is_Deleted = "N";

        #region Constructors

        public SocialHistoryMaster() { }

        #endregion

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            //Commented by vaishali on 17-11-2015
            //sb.Append(_Social_History_ID);
            sb.Append(_Human_ID);
            sb.Append(_Social_Info);
            sb.Append(_Is_Present);
            sb.Append(_Description);
            sb.Append(_Value);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_recodes);
            sb.Append(_Is_Mandatory);

            sb.Append(_Is_Deleted);
            //sb.Append(_Reason_Not_Performed);
            sb.Append(_Snomed_Reason_Not_Performed);
            return sb.ToString().GetHashCode();
        }

        
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        //Commented by vaishali on 17-11-2015
        //public virtual ulong Social_History_ID
        //{
        //    get { return _Social_History_ID; }
        //    set { _Social_History_ID = value; }
        //}
       
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
      
        public virtual string Social_Info
        {
            get { return _Social_Info; }
            set { _Social_Info = value; }
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
       
        public virtual string Value
        {
            get { return _Value; }
            set { _Value = value; }
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
       
        public virtual string Recodes
        {
            get { return _recodes; }
            set { _recodes = value; }
        }

       
        public virtual string Is_Mandatory
        {
            get { return _Is_Mandatory; }
            set { _Is_Mandatory = value; }
        }


        //public virtual ulong Encounter_ID
        //{
        //    get { return _Encounter_Id; }
        //    set { _Encounter_Id = value; }
        //}
        //public virtual string Reason_Not_Performed
        //{
        //    get { return _Reason_Not_Performed; }
        //    set { _Reason_Not_Performed = value; }
        //}


        public virtual string Snomed_Reason_Not_Performed
        {
            get { return _Snomed_Reason_Not_Performed; }
            set { _Snomed_Reason_Not_Performed = value; }
        }
        public virtual string Is_Deleted
        {
            get { return _Is_Deleted; }
            set { _Is_Deleted = value; }
        }
    }
}
