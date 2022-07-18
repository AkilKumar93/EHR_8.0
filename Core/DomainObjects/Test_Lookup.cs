using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Test_Lookup : BusinessBase<ulong>
    {
        #region Decleration
        private ulong _Test_Lookup_Id = 0;
        private string _Category = string.Empty;
        private string _Test_Name = string.Empty;
        private string _Question_Name = string.Empty;
        private string _User_Name = string.Empty;
        private int _Sort_Order=0;
        private string _Options = string.Empty;
        //private string _Normal_System_Status = string.Empty;
        //private string _Default_Value = string.Empty;
        private string _Status = string.Empty;
       // private string _Score = string.Empty;
        private string _Is_Score = string.Empty;
        private string _Is_Status = string.Empty;
        //private string _Is_Notes = string.Empty;
        private string _Maximum_Score = string.Empty;
        #endregion
      
       #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Test_Lookup_Id);
            sb.Append(_User_Name);
            sb.Append(_Category);
            sb.Append(_Test_Name);
            sb.Append(_Question_Name);
            sb.Append(_Sort_Order);
            sb.Append(_Options);
            //sb.Append(_Normal_System_Status);
            //sb.Append(_Default_Value);
            sb.Append(_Status);
            //sb.Append(_Score);
            sb.Append(_Is_Score);
            sb.Append(_Is_Status);
            //sb.Append(_Is_Notes);
            sb.Append(_Maximum_Score);
            return sb.ToString().GetHashCode();
        }

        #endregion
        
        #region Implementation
        [DataMember]
        public virtual ulong Test_Lookup_Id
        {
            get { return _Test_Lookup_Id; }
            set { _Test_Lookup_Id = value; }
        }

        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        [DataMember]
        public virtual string Test_Name
        {
            get { return _Test_Name; }
            set { _Test_Name = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //[DataMember]
        //public virtual string Normal_System_Status
        //{
        //    get { return _Normal_System_Status; }
        //    set { _Normal_System_Status = value; }
        //}
        //[DataMember]
        //public virtual string Default_Value
        //{
        //    get { return _Default_Value; }
        //    set { _Default_Value = value; }
        //}
        [DataMember]
        public virtual string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
       
        [DataMember]
        public virtual string Options
        {
            get { return _Options; }
            set { _Options = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        //[DataMember]
        //public virtual string Score
        //{
        //    get { return _Score; }
        //    set { _Score = value; }
        //}
        [DataMember]
        public virtual string Question_Name
        {
            get { return _Question_Name; }
            set { _Question_Name = value; }
        }
        [DataMember]
        public virtual string Is_Score
        {
            get { return _Is_Score; }
            set { _Is_Score = value; }
        }
         [DataMember]
        public virtual string Is_Status
         {
             get { return _Is_Status; }
             set { _Is_Status = value; }
        }
         //[DataMember]
         //public virtual string Is_Notes
         //{
         //    get { return _Is_Notes; }
         //    set { _Is_Notes = value; }
         //}
        [DataMember]
         public virtual string Maximum_Score
         {
             get { return _Maximum_Score; }
             set { _Maximum_Score = value; }
         }

        #endregion

    }

}
