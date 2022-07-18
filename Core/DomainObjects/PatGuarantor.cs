using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PatGuarantor : BusinessBase<int>
    {
        #region Decleration


        private int _Human_ID = 0;
        private int _Guarantor_Human_ID = 0;
        private string _Relationship = string.Empty;
        private int _Relationship_No = 0;
        private DateTime _From_Date = DateTime.MinValue;
        private DateTime _To_Date = DateTime.MinValue;
        private string _Active = string.Empty;
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
            sb.Append(_Human_ID);
            sb.Append(_Guarantor_Human_ID);
            sb.Append(_Relationship);
            sb.Append(_Relationship_No);
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_Active);
            sb.Append(_Created_By);
            sb.Append(_Modified_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual int Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }

        [DataMember]
        public virtual int Guarantor_Human_ID
        {
            get { return _Guarantor_Human_ID; }
            set
            {
                _Guarantor_Human_ID = value;
            }
        }


        [DataMember]
        public virtual string Relationship
        {
            get { return _Relationship; }
            set
            {
                _Relationship = value;
            }
        }

        [DataMember]
        public virtual int Relationship_No
        {
            get { return _Relationship_No; }
            set
            {
                _Relationship_No = value;
            }
        }
        [DataMember]
        public virtual DateTime From_Date
        {
            get { return _From_Date; }
            set
            {
                _From_Date = value;
            }
        }
        [DataMember]
        public virtual DateTime To_Date
        {
            get { return _To_Date; }
            set
            {
                _To_Date = value;
            }
        }
        [DataMember]
        public virtual string Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
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
            set { _Modified_By = value; }
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
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }



        #endregion
    }
}
