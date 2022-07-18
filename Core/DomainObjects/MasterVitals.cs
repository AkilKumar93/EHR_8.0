using System;
using System.Runtime.Serialization;
namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class MasterVitals:BusinessBase<ulong>
    {
        #region Declarations

        private string _Vital_Name=string.Empty ;
        private string _Vital_Unit = string.Empty;
        private string _Vital_Type = string.Empty;
        private int _Sort_Order=0;

        #endregion

        #region Constructors

        public MasterVitals() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Vital_Name);
            sb.Append(_Vital_Type);
            sb.Append(_Vital_Unit);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
       
        [DataMember]
        public virtual string Vital_Name
        {
            get { return _Vital_Name; }
            set { _Vital_Name = value; }
        }
       
        [DataMember]
        public virtual string Vital_Type
        {
            get { return _Vital_Type; }
            set { _Vital_Type = value; }
        }

        [DataMember]
        public virtual string Vital_Unit
        {
            get { return _Vital_Unit; }
            set { _Vital_Unit = value; }

        }

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }

        }

        #endregion
    }
}
