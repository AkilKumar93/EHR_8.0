using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class PercentileLookUp:BusinessBase<ulong>
    {
        #region Declarations

        private double _Age_In_Months=0;
        private string _Sex=string.Empty;
        private string _Category=string.Empty;
        private double _L=0;
        private double _M=0;
        private double _S=0;

        #endregion

        #region Constructors

        public PercentileLookUp() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Age_In_Months);
            sb.Append(_Sex);
            sb.Append(_Category);
            sb.Append(_L);
            sb.Append(_M);
            sb.Append(_S);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
       
        [DataMember]
        public virtual double Age_In_Months
        {
            get { return _Age_In_Months; }
            set { _Age_In_Months = value; }
        }
       
        [DataMember]
        public virtual string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }

        }

        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set { _Category = value; }

        }

        [DataMember]
        public virtual double L
        {
            get { return _L; }
            set { _L = value; }
        }

        [DataMember]
        public virtual double M
        {
            get { return _M; }
            set { _M = value; }
        }

        [DataMember]
        public virtual double S
        {
            get { return _S; }
            set { _S = value; }
        }
        #endregion
    }
}
