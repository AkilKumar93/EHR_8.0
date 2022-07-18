using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DTO
{
    
    [Serializable]
    public partial class FillTestScreen
    {
        private string _Test=string.Empty;
        private string _Question=string.Empty;
        private string _Status=string.Empty;
        private string _Notes=string.Empty;
        private string _StatusOptions=string.Empty;
        private ulong _TestLookupId=0;
        //private string _NormalSystemStatus=string.Empty;
        private ulong _TestID=0;
        private int _UpdateFlag=0;
        private int _Version=0;
       // private string _DefaultValue=string.Empty;
        private string _CreatedBy=string.Empty;
        private DateTime _CreatedDateTime=DateTime.MinValue;
        private string _Score=string.Empty;
        private string _Is_Score=string.Empty;
        private string _Is_Status=string.Empty;
        //private string _Is_Notes=string.Empty;
        private string _Maximum_Score=string.Empty;
        private string _ModifiedBy = string.Empty;
        private DateTime _ModifiedDateTime = DateTime.MinValue;

    
    
        public virtual string Test
        {
            get { return _Test; }
            set { _Test = value; }
        }
       
     public virtual string Question
         {
            get { return _Question; }
            set { _Question = value; }
        }
       
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
       
        public virtual string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        
        public virtual string StatusOptions
        {
            get { return _StatusOptions; }
            set { _StatusOptions = value; }
        }
       
        public virtual ulong TestLookupId
        {
            get { return _TestLookupId; }
            set { _TestLookupId = value; }
        }
       
        //public virtual string NormalSystemStatus
        //{
        //    get { return _NormalSystemStatus; }
        //    set { _NormalSystemStatus = value; }
        //}
        
        public virtual ulong TestID
        {
            get { return _TestID; }
            set { _TestID = value; }
        }
       
        public virtual int UpdateFlag
        {
            get { return _UpdateFlag; }
            set { _UpdateFlag = value; }
        }
        
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        
        //public virtual string DefaultValue
        //{
        //    get { return _DefaultValue; }
        //    set { _DefaultValue = value; }
        //}
        
      
        
        public virtual string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
       
        public virtual DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            set { _CreatedDateTime = value; }
        }
       
        public virtual string Score
        {
            get { return _Score; }
            set { _Score = value; }

        }
        
        public virtual string Maximum_Score
        {
            get { return _Maximum_Score; }
            set { _Maximum_Score = value; }

        }

       
        public virtual string Is_Score
        {
            get { return _Is_Score; }
            set { _Is_Score = value; }

        }
       
        public virtual string Is_Status
        {
            get { return _Is_Status; }
            set { _Is_Status = value; }

        }
       
        //public virtual string Is_Notes
        //{
        //    get { return _Is_Notes; }
        //    set { _Is_Notes = value; }

        //}
        public virtual string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        public virtual DateTime ModifiedDateTime
        {
            get { return _ModifiedDateTime; }
            set { _ModifiedDateTime = value; }
        }
       
}
}
