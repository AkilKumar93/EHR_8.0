using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
     [DataContract]
    public partial class LabLocationProcedure:BusinessBase<ulong>
    {
          #region Declarations

        private ulong _Lab_Location_ID = 0;
        private ulong _Lab_ID = 0;
        private string _Procedure_Code = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version=0;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Janani - Main - 30 Jul 2011 - End
        #endregion


         #region Constructors

        public LabLocationProcedure() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Lab_Location_ID);
            sb.Append(_Lab_ID);
            sb.Append(_Procedure_Code);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Lab_Location_ID
        {
            get { return _Lab_Location_ID; }
            set { _Lab_Location_ID = value; }
        }
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        [DataMember]
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set { _Procedure_Code = value; }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        //Janani - Main - 30 Jul 2011 - Start
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //Janani - Main - 30 Jul 2011 - End
        #endregion
    }
}
