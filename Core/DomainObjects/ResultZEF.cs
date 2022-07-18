using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ResultZEF : BusinessBase<ulong>
    {
        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;
        private string _ZEF_Segment_Type_ID = string.Empty;
        private string _ZEF_Sequence_Number = string.Empty;
        private string _ZEF_Embedded_PDF = string.Empty;

        #region Constructors

        public ResultZEF() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Version);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Result_Master_ID);
            sb.Append(_ZEF_Segment_Type_ID);
            sb.Append(_ZEF_Sequence_Number);
            sb.Append(_ZEF_Embedded_PDF);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
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
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set { _Result_Master_ID = value; }
        }
        [DataMember]
        public virtual string ZEF_Segment_Type_ID
        {
            get { return _ZEF_Segment_Type_ID; }
            set { _ZEF_Segment_Type_ID = value; }
        }
        [DataMember]
        public virtual string ZEF_Sequence_Number
        {
            get { return _ZEF_Sequence_Number; }
            set { _ZEF_Sequence_Number = value; }
        }
        [DataMember]
        public virtual string ZEF_Embedded_PDF
        {
            get { return _ZEF_Embedded_PDF; }
            set { _ZEF_Embedded_PDF = value; }
        }
        #endregion
    }
}
