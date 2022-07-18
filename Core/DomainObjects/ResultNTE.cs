using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ResultNTE : BusinessBase<ulong>
    {
        #region Declarations

        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;
        private ulong _Result_OBR_ID = 0;
        private ulong _Result_OBX_ID = 0;
        private string _Comment_Type = string.Empty;
        private string _NTE_Segment_Type_ID = string.Empty;
        private string _NTE_Sequence_Number = string.Empty;
        private string _NTE_Comment_Source = string.Empty;
        private string _NTE_Comment_Text = string.Empty;
        #endregion

        #region Constructors

        public ResultNTE() { }

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
            sb.Append(_Result_OBR_ID);
            sb.Append(_Result_OBX_ID);
            sb.Append(_Comment_Type);
            sb.Append(_NTE_Segment_Type_ID);
            sb.Append(_NTE_Sequence_Number);
            sb.Append(_NTE_Comment_Source);
            sb.Append(_NTE_Comment_Text);
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
        public virtual ulong Result_OBR_ID
        {
            get { return _Result_OBR_ID; }
            set { _Result_OBR_ID = value; }
        }
        [DataMember]
        public virtual ulong Result_OBX_ID
        {
            get
            {
                return _Result_OBX_ID;
            }
            set { _Result_OBX_ID = value; }
        }
        [DataMember]
        public virtual string Comment_Type
        {
            get { return _Comment_Type; }
            set { _Comment_Type = value; }
        }
        [DataMember]
        public virtual string NTE_Segment_Type_ID
        {
            get { return _NTE_Segment_Type_ID; }
            set { _NTE_Segment_Type_ID = value; }
        }
        [DataMember]
        public virtual string NTE_Sequence_Number
        {
            get { return _NTE_Sequence_Number; }
            set { _NTE_Sequence_Number = value; }
        }
        [DataMember]
        public virtual string NTE_Comment_Source
        {
            get { return _NTE_Comment_Source; }
            set { _NTE_Comment_Source = value; }
        }
        [DataMember]
        public virtual string NTE_Comment_Text
        {
            get { return _NTE_Comment_Text; }
            set { _NTE_Comment_Text = value; }
        }
        #endregion
    }
}