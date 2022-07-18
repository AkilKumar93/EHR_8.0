using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ResultOBR : BusinessBase<ulong>
    {
        #region Declarations

        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;
        private string _OBR_Segment_Type_ID = string.Empty;
        private string _OBR_Sequence_Number = string.Empty;
        private string _OBR_Specimen_ID = string.Empty;
        private string _OBR_Instituition_ID = string.Empty;
        private string _OBR_Labcorp_Specimen_Number = string.Empty;
        private string _OBR_Labcorp_Specimen_Instituition_Number = string.Empty;
        private string _OBR_Observation_Battery_Identifier = string.Empty;
        private string _OBR_Observation_Battery_Text = string.Empty;
        private string _OBR_Name_Of_Coding_System = string.Empty;
        private string _OBR_Priority = string.Empty;
        private string _OBR_Description_Not_Available = string.Empty;
        private string _OBR_Specimen_Collection_Date_And_Time = string.Empty;
        private string _OBR_Specimen_Collection_End_Time = string.Empty;
        private string _OBR_Specimen_Collection_Volume = string.Empty;
        private string _OBR_Collector_Identifier = string.Empty;
        private string _OBR_Action_Code = string.Empty;
        private string _OBR_Danger_Code = string.Empty;
        private string _OBR_Relevant_Clinical_Information = string.Empty;
        private string _OBR_Date_And_Time_Specimen_Receipt_In_lab = string.Empty;
        private string _OBR_Source_Of_Specimen = string.Empty;
        private string _OBR_Ordering_Provider_ID = string.Empty;
        private string _OBR_Order_Call_Back_Phone = string.Empty;
        private string _OBR_Alternate_Unique_Foreign_Accession_ID = string.Empty;
        private string _OBR_Requester_Field = string.Empty;
        private string _OBR_Producer_Field = string.Empty;
        private string _OBR_Producer_Field2 = string.Empty;
        private string _OBR_Date_And_Time_Observation_Reported = string.Empty;
        private string _OBR_Producer_Charge = string.Empty;
        private string _OBR_Producer_Section_ID = string.Empty;
        private string _OBR_Order_Result_Status = string.Empty;
        private string _temp_property = string.Empty;
        #endregion

        #region Constructors

        public ResultOBR() { }

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
            sb.Append(_OBR_Segment_Type_ID);
            sb.Append(_OBR_Sequence_Number);
            sb.Append(_OBR_Specimen_ID);
            sb.Append(_OBR_Instituition_ID);
            sb.Append(_OBR_Labcorp_Specimen_Number);
            sb.Append(_OBR_Labcorp_Specimen_Instituition_Number);
            sb.Append(_OBR_Observation_Battery_Identifier);
            sb.Append(_OBR_Observation_Battery_Text);
            sb.Append(_OBR_Name_Of_Coding_System);
            sb.Append(_OBR_Priority);
            sb.Append(_OBR_Description_Not_Available);
            sb.Append(_OBR_Specimen_Collection_Date_And_Time);
            sb.Append(_OBR_Specimen_Collection_End_Time);
            sb.Append(_OBR_Specimen_Collection_Volume);
            sb.Append(_OBR_Collector_Identifier);
            sb.Append(_OBR_Action_Code);
            sb.Append(_OBR_Danger_Code);
            sb.Append(_OBR_Relevant_Clinical_Information);
            sb.Append(_OBR_Date_And_Time_Specimen_Receipt_In_lab);
            sb.Append(_OBR_Source_Of_Specimen);
            sb.Append(_OBR_Ordering_Provider_ID);
            sb.Append(_OBR_Order_Call_Back_Phone);
            sb.Append(_OBR_Alternate_Unique_Foreign_Accession_ID);
            sb.Append(_OBR_Requester_Field);
            sb.Append(_OBR_Producer_Field);
            sb.Append(_OBR_Producer_Field2);
            sb.Append(_OBR_Date_And_Time_Observation_Reported);
            sb.Append(_OBR_Producer_Charge);
            sb.Append(_OBR_Producer_Section_ID);
            sb.Append(_OBR_Order_Result_Status);
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
        public virtual string OBR_Segment_Type_ID
        {
            get { return _OBR_Segment_Type_ID; }
            set { _OBR_Segment_Type_ID = value; }
        }
        [DataMember]
        public virtual string OBR_Sequence_Number
        {
            get { return _OBR_Sequence_Number; }
            set { _OBR_Sequence_Number = value; }
        }
        [DataMember]
        public virtual string OBR_Specimen_ID
        {
            get { return _OBR_Specimen_ID; }
            set { _OBR_Specimen_ID = value; }
        }
        [DataMember]
        public virtual string OBR_Instituition_ID
        {
            get { return _OBR_Instituition_ID; }
            set { _OBR_Instituition_ID = value; }
        }
        [DataMember]
        public virtual string OBR_Labcorp_Specimen_Number
        {
            get { return _OBR_Labcorp_Specimen_Number; }
            set { _OBR_Labcorp_Specimen_Number = value; }
        }
        [DataMember]
        public virtual string OBR_Labcorp_Specimen_Instituition_Number
        {
            get { return _OBR_Labcorp_Specimen_Instituition_Number; }
            set { _OBR_Labcorp_Specimen_Instituition_Number = value; }
        }
        [DataMember]
        public virtual string OBR_Observation_Battery_Identifier
        {
            get { return _OBR_Observation_Battery_Identifier; }
            set { _OBR_Observation_Battery_Identifier = value; }
        }
        [DataMember]
        public virtual string OBR_Observation_Battery_Text
        {
            get { return _OBR_Observation_Battery_Text; }
            set { _OBR_Observation_Battery_Text = value; }
        }

        [DataMember]
        public virtual string OBR_Name_Of_Coding_System
        {
            get { return _OBR_Name_Of_Coding_System; }
            set { _OBR_Name_Of_Coding_System = value; }
        }
        [DataMember]
        public virtual string OBR_Priority
        {
            get { return _OBR_Priority; }
            set { _OBR_Priority = value; }
        }
        [DataMember]
        public virtual string OBR_Description_Not_Available
        {
            get { return _OBR_Description_Not_Available; }
            set { _OBR_Description_Not_Available = value; }
        }
        [DataMember]
        public virtual string OBR_Specimen_Collection_Date_And_Time
        {
            get { return _OBR_Specimen_Collection_Date_And_Time; }
            set { _OBR_Specimen_Collection_Date_And_Time = value; }

        }
        [DataMember]
        public virtual string OBR_Specimen_Collection_End_Time
        {
            get { return _OBR_Specimen_Collection_End_Time; }
            set { _OBR_Specimen_Collection_End_Time = value; }
        }
        [DataMember]
        public virtual string OBR_Specimen_Collection_Volume
        {
            get
            {
                return _OBR_Specimen_Collection_Volume;
            }
            set { _OBR_Specimen_Collection_Volume = value; }
        }
        [DataMember]
        public virtual string OBR_Collector_Identifier
        {
            get { return _OBR_Collector_Identifier; }
            set { _OBR_Collector_Identifier = value; }
        }
        [DataMember]
        public virtual string OBR_Action_Code
        {
            get { return _OBR_Action_Code; }
            set { _OBR_Action_Code = value; }
        }
        [DataMember]
        public virtual string OBR_Danger_Code
        {
            get { return _OBR_Danger_Code; }
            set { _OBR_Danger_Code = value; }
        }
        [DataMember]
        public virtual string OBR_Relevant_Clinical_Information
        {
            get { return _OBR_Relevant_Clinical_Information; }
            set { _OBR_Relevant_Clinical_Information = value; }
        }
        [DataMember]
        public virtual string OBR_Date_And_Time_Specimen_Receipt_In_lab
        {
            get { return _OBR_Date_And_Time_Specimen_Receipt_In_lab; }
            set { _OBR_Date_And_Time_Specimen_Receipt_In_lab = value; }
        }
        [DataMember]
        public virtual string OBR_Source_Of_Specimen
        {
            get { return _OBR_Source_Of_Specimen; }
            set { _OBR_Source_Of_Specimen = value; }
        }
        [DataMember]
        public virtual string OBR_Ordering_Provider_ID
        {
            get { return _OBR_Ordering_Provider_ID; }
            set { _OBR_Ordering_Provider_ID = value; }
        }
        [DataMember]
        public virtual string OBR_Order_Call_Back_Phone
        {
            get { return _OBR_Order_Call_Back_Phone; }
            set { _OBR_Order_Call_Back_Phone = value; }
        }
        [DataMember]
        public virtual string OBR_Alternate_Unique_Foreign_Accession_ID
        {
            get { return _OBR_Alternate_Unique_Foreign_Accession_ID; }
            set { _OBR_Alternate_Unique_Foreign_Accession_ID = value; }
        }
        [DataMember]
        public virtual string OBR_Requester_Field
        {
            get { return _OBR_Requester_Field; }
            set { _OBR_Requester_Field = value; }
        }
        [DataMember]
        public virtual string OBR_Producer_Field
        {
            get { return _OBR_Producer_Field; }
            set { _OBR_Producer_Field = value; }
        }
        [DataMember]
        public virtual string OBR_Producer_Field2
        {
            get { return _OBR_Producer_Field2; }
            set { _OBR_Producer_Field2 = value; }
        }
        [DataMember]
        public virtual string OBR_Date_And_Time_Observation_Reported
        {
            get { return _OBR_Date_And_Time_Observation_Reported; }
            set { _OBR_Date_And_Time_Observation_Reported = value; }
        }
        [DataMember]
        public virtual string OBR_Producer_Charge
        {
            get { return _OBR_Producer_Charge; }
            set { _OBR_Producer_Charge = value; }
        }
        [DataMember]
        public virtual string OBR_Producer_Section_ID
        {
            get { return _OBR_Producer_Section_ID; }
            set { _OBR_Producer_Section_ID = value; }
        }
        [DataMember]
        public virtual string OBR_Order_Result_Status
        {
            get { return _OBR_Order_Result_Status; }
            set { _OBR_Order_Result_Status = value; }
        }
        [DataMember]
        public virtual string temp_property
        {
            get { return _temp_property; }
            set { _temp_property = value; }
        }
        #endregion
    }
}

