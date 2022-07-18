using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ResultORC : BusinessBase<ulong>
    {
        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;
        private string _ORC_Segment_Type_ID = string.Empty;
        private string _ORC_Order_Control = string.Empty;
        private string _ORC_Specimen_ID = string.Empty;
        private string _ORC_Instituition_ID = string.Empty;
        private string _ORC_Filler_Accession_ID = string.Empty;
        private string _ORC_Owner_Of_Accession = string.Empty;
        private string _ORC_Placer_Group_Number = string.Empty;
        private string _ORC_Order_Status = string.Empty;
        private string _ORC_Response_Flag = string.Empty;
        private string _ORC_Quantity = string.Empty;
        private string _ORC_Parent = string.Empty;
        private string _ORC_Date_And_Time_Of_Transaction = string.Empty;
        private string _ORC_Entered_By = string.Empty;
        private string _ORC_Verified_By = string.Empty;
        private string _ORC_Ordering_Provider_ID = string.Empty;
        private string _ORC_Ordering_Provider_Last_Name = string.Empty;
        private string _ORC_Ordering_Provider_First_Initial = string.Empty;
        private string _ORC_Ordering_Provider_Middle_Initial = string.Empty;
        private string _ORC_Ordering_Provider_Suffix = string.Empty;
        private string _ORC_Ordering_Provider_Prefix = string.Empty;
        private string _ORC_Ordering_Provider_Degree = string.Empty;
        private string _ORC_Source_Table = string.Empty;
        private string _temp_property = string.Empty;

        public ResultORC() { }

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
            sb.Append(_ORC_Segment_Type_ID);
            sb.Append(_ORC_Order_Control);
            sb.Append(_ORC_Specimen_ID);
            sb.Append(_ORC_Instituition_ID);
            sb.Append(_ORC_Filler_Accession_ID);
            sb.Append(_ORC_Owner_Of_Accession);
            sb.Append(_ORC_Placer_Group_Number);
            sb.Append(_ORC_Order_Status);
            sb.Append(_ORC_Response_Flag);
            sb.Append(_ORC_Quantity);
            sb.Append(_ORC_Parent);
            sb.Append(_ORC_Date_And_Time_Of_Transaction);
            sb.Append(_ORC_Entered_By);
            sb.Append(_ORC_Verified_By);
            sb.Append(_ORC_Ordering_Provider_ID);
            sb.Append(_ORC_Ordering_Provider_Last_Name);
            sb.Append(_ORC_Ordering_Provider_First_Initial);
            sb.Append(_ORC_Ordering_Provider_Middle_Initial);
            sb.Append(_ORC_Ordering_Provider_Suffix);
            sb.Append(_ORC_Ordering_Provider_Prefix);
            sb.Append(_ORC_Ordering_Provider_Degree);
            sb.Append(_ORC_Source_Table);
            return sb.ToString().GetHashCode();
        }

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
        public virtual string ORC_Segment_Type_ID
        {
            get { return _ORC_Segment_Type_ID; }
            set { _ORC_Segment_Type_ID = value; }
        }
        [DataMember]
        public virtual string ORC_Order_Control
        {
            get { return _ORC_Order_Control; }
            set { _ORC_Order_Control = value; }
        }
        [DataMember]
        public virtual string ORC_Specimen_ID
        {
            get { return _ORC_Specimen_ID; }
            set { _ORC_Specimen_ID = value; }
        }
        [DataMember]
        public virtual string ORC_Instituition_ID
        {
            get { return _ORC_Instituition_ID; }
            set { _ORC_Instituition_ID = value; }
        }
        [DataMember]
        public virtual string ORC_Filler_Accession_ID
        {
            get { return _ORC_Filler_Accession_ID; }
            set { _ORC_Filler_Accession_ID = value; }
        }
        [DataMember]
        public virtual string ORC_Owner_Of_Accession
        {
            get { return _ORC_Owner_Of_Accession; }
            set { _ORC_Owner_Of_Accession = value; }
        }
        [DataMember]
        public virtual string ORC_Placer_Group_Number
        {
            get { return _ORC_Placer_Group_Number; }
            set { _ORC_Placer_Group_Number = value; }
        }
        [DataMember]
        public virtual string ORC_Order_Status
        {
            get { return _ORC_Order_Status; }
            set { _ORC_Order_Status = value; }
        }
        [DataMember]
        public virtual string ORC_Response_Flag
        {
            get { return _ORC_Response_Flag; }
            set { _ORC_Response_Flag = value; }
        }
        [DataMember]
        public virtual string ORC_Quantity
        {
            get { return _ORC_Quantity; }
            set { _ORC_Quantity = value; }
        }
        [DataMember]
        public virtual string ORC_Parent
        {
            get { return _ORC_Parent; }
            set { _ORC_Parent = value; }
        }
        [DataMember]
        public virtual string ORC_Date_And_Time_Of_Transaction
        {
            get { return _ORC_Date_And_Time_Of_Transaction; }
            set { _ORC_Date_And_Time_Of_Transaction = value; }
        }
        [DataMember]
        public virtual string ORC_Entered_By
        {
            get { return _ORC_Entered_By; }
            set { _ORC_Entered_By = value; }
        }
        [DataMember]
        public virtual string ORC_Verified_By
        {
            get { return _ORC_Verified_By; }
            set { _ORC_Verified_By = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_ID
        {
            get { return _ORC_Ordering_Provider_ID; }
            set { _ORC_Ordering_Provider_ID = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_Last_Name
        {
            get { return _ORC_Ordering_Provider_Last_Name; }
            set { _ORC_Ordering_Provider_Last_Name = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_First_Initial
        {
            get { return _ORC_Ordering_Provider_First_Initial; }
            set { _ORC_Ordering_Provider_First_Initial = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_Middle_Initial
        {
            get { return _ORC_Ordering_Provider_Middle_Initial; }
            set { _ORC_Ordering_Provider_Middle_Initial = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_Suffix
        {
            get { return _ORC_Ordering_Provider_Suffix; }
            set { _ORC_Ordering_Provider_Suffix = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_Prefix
        {
            get { return _ORC_Ordering_Provider_Prefix; }
            set { _ORC_Ordering_Provider_Prefix = value; }
        }
        [DataMember]
        public virtual string ORC_Ordering_Provider_Degree
        {
            get { return _ORC_Ordering_Provider_Degree; }
            set { _ORC_Ordering_Provider_Degree = value; }
        }
        [DataMember]
        public virtual string ORC_Source_Table
        {
            get { return _ORC_Source_Table; }
            set { _ORC_Source_Table = value; }
        }
        [DataMember]
        public virtual string temp_property
        {
            get { return _temp_property; }
            set { _temp_property = value; }
        }
    }
}
