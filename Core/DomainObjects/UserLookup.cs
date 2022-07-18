using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public class UserLookup : FieldLookup
    {
        #region Decleration

        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Is_Active = string.Empty;
        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Is_Active);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Implementation
 
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

        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }
        #endregion
    }
}
