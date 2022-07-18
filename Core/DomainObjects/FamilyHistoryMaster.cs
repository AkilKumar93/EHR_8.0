using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public class FamilyHistoryMaster : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Human_ID= 0;        
        private int _Age=0;
        private string _Status = string.Empty;
        private string _RelationShip = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Cause_Of_Death = string.Empty;
        //private string _Disease = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Is_Deleted = "N";
        private int _version = 0;
        //private ulong _Encounter_Id = 0;

        #endregion

        #region Constructors

        public FamilyHistoryMaster() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Age);
            sb.Append(_Status);
            sb.Append(_RelationShip);
            sb.Append(_Cause_Of_Death);
            //sb.Append(_Disease);
            sb.Append(_Created_By);
            sb.Append(_Modified_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_Date_And_Time);
            //sb.Append(_Encounter_Id);
            sb.Append(_version);
            sb.Append(_Is_Deleted);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Implementation
        
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }        
        
        public virtual int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
        public virtual string RelationShip
        {
            get { return _RelationShip; }
            set { _RelationShip = value; }
        }
        
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }
        
        public virtual string Cause_Of_Death
        {
            get { return _Cause_Of_Death; }
            set { _Cause_Of_Death = value; }
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
        //public virtual string Disease
        //{
        //    get { return _Disease; }
        //    set { _Disease = value; }
        //}
        #endregion
    }
}
