using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Statement_Chargeline : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Patient_Statement_ID=0;
        private ulong _Charge_Line_Item_ID=0;
        private decimal _Patient_Due=0;
        private decimal _Insurance_Due=0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;

        #endregion

        #region Constructors

        public Statement_Chargeline() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Patient_Statement_ID);
            sb.Append(_Charge_Line_Item_ID);
            sb.Append(_Patient_Due);
            sb.Append(_Insurance_Due);
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
        public virtual ulong Patient_Statement_ID
        {
            get { return _Patient_Statement_ID; }
            set
            {
                _Patient_Statement_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Charge_Line_Item_ID
        {
            get { return _Charge_Line_Item_ID; }
            set
            {
                _Charge_Line_Item_ID = value;
            }
        }
        [DataMember]
        public virtual decimal Patient_Due
        {
            get { return _Patient_Due; }
            set
            {
                _Patient_Due = value;
            }
        }
        [DataMember]
        public virtual decimal Insurance_Due
        {
            get { return _Insurance_Due; }
            set
            {
                _Insurance_Due = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
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
        #endregion
    }
}
