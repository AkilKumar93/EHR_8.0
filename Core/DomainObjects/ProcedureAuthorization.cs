using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ProcedureAuthorization:BusinessBase<string>
    {
        #region Declarations

        private string _Procedure_Code = string.Empty;
        private string _Modifier = string.Empty;
        private ulong _Insurance_Plan_ID = 0;
        private string _Is_Auth_Required = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Janani - Main - 30 Jul 2011 - End
        #endregion

         #region Constructors

        public ProcedureAuthorization() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Procedure_Code);
            sb.Append(_Modifier);
            sb.Append(_Insurance_Plan_ID);
            sb.Append(_Is_Auth_Required);
            sb.Append(_Created_By);
            sb.Append(_Modified_By);
            sb.Append(_Created_Date_And_Time);
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
        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set { _Procedure_Code = value; }
        }
        [DataMember]
        public virtual string Modifier
        {
            get { return _Modifier; }
            set { _Modifier = value; }
        }

        [DataMember]
        public virtual ulong Insurance_Plan_ID
        {
            get { return _Insurance_Plan_ID; }
            set { _Insurance_Plan_ID = value; }
        }
        [DataMember]
        public virtual string Is_Auth_Required
        {
            get { return _Is_Auth_Required; }
            set { _Is_Auth_Required = value; }
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
