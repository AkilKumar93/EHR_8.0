using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ApplicationUsageLog : BusinessBase<uint>
    {
        #region Declarations

        private string _Application_Screen_Name = string.Empty;
        private string _Legal_Org = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_and_Time = DateTime.MinValue;
        private int _Version = 0;

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Application_Screen_Name);
            sb.Append(_Legal_Org);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_and_Time);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Application_Screen_Name
        {
            get { return _Application_Screen_Name; }
            set { _Application_Screen_Name = value; }
        }

        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set { _Legal_Org = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        [DataMember]
        public virtual DateTime Created_Date_and_Time
        {
            get { return _Created_Date_and_Time; }
            set
            {
                _Created_Date_and_Time = value;
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
