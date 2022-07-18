using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Physician_Drug : BusinessBase<ulong>
    {
        #region Declarations


        //All_Drug_ID, Drug_Name, Route_Of_Administration, Strength, Physician_Name

        private string _Drug_Name = string.Empty;
        //private string _Route_Of_Administration = string.Empty;
        //private string _Strength = string.Empty;
        private ulong _Physician_ID = 0;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Drug_Name);
            //sb.Append(_Route_Of_Administration);
            //sb.Append(_Strength);
            sb.Append(_Physician_ID);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        
        [DataMember]
        public virtual string Drug_Name
        {
            get { return _Drug_Name; }
            set { _Drug_Name = value; }
        }

        //[DataMember]
        //public virtual string Route_Of_Administration
        //{
        //    get { return _Route_Of_Administration; }
        //    set { _Route_Of_Administration = value; }
        //}
        //[DataMember]
        //public virtual string Strength
        //{
        //    get { return _Strength; }
        //    set { _Strength = value; }
        //}
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }


        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
       

        #endregion
    }
}
