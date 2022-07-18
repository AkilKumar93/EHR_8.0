using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ResultOBX : BusinessBase<ulong>
    {
        #region Declarations

        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;
        private ulong _Result_OBR_ID = 0;
        private string _OBX_Segment_Type_ID = string.Empty;
        private string _OBX_Sequence_Number = string.Empty;
        private string _OBX_Value_Type = string.Empty;
        private string _OBX_Observation_Identifier = string.Empty;
        private string _OBX_Observation_Text = string.Empty;
        private string _OBX_Name_Of_Coding_System = string.Empty;
        private string _OBX_Loinc_Identifier = string.Empty;
        private string _OBX_Loinc_Observation_Text = string.Empty;
        private string _OBX_Name_Of_Alternate_Coding_System = string.Empty;
        private string _OBX_Observation_Sub_ID = string.Empty;
        private string _OBX_Observation_Value = string.Empty;
        private string _OBX_Units = string.Empty;
        private string _OBX_Reference_Range = string.Empty;
        private string _OBX_Abnormal_Flag = string.Empty;
        private string _OBX_Probability = string.Empty;
        private string _OBX_NatureOf_Abnormal_Test = string.Empty;
        private string _OBX_Observation_Result_Status = string.Empty;
        private string _OBX_Date_Of_Last_Change_In_Reference_Range_Or_Units = string.Empty;
        private string _OBX_User_Defined_Access_Checks = string.Empty;
        private string _OBX_Date_And_Time_Of_Observation = string.Empty;
        private string _OBX_Producer_ID = string.Empty;
        private string _temp_property = string.Empty;
        private string _OBX_Responsible_Observer = string.Empty;


        private string _OBX_Observation_Method = string.Empty;
        private string _OBX_Equipment_Instance = string.Empty;
        private string _OBX_Date_And_Time_Of_Analysis = string.Empty;
        private string _OBX_Reserved_for_harmonization1 = string.Empty;
        private string _OBX_Reserved_for_harmonization2 = string.Empty;
        private string _OBX_Reserved_for_harmonization3 = string.Empty;
        private string _OBX_Performing_Organization_Name = string.Empty;

        private string _OBX_Performing_Organization_Address = string.Empty;
        private string _OBX_Performing_Organization_Medical_Director = string.Empty;

        #endregion

        #region Constructors

        public ResultOBX() { }

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
            sb.Append(_OBX_Segment_Type_ID);
            sb.Append(_OBX_Sequence_Number);
            sb.Append(_OBX_Value_Type);
            sb.Append(_OBX_Observation_Identifier);
            sb.Append(_OBX_Observation_Text);
            sb.Append(_OBX_Name_Of_Coding_System);
            sb.Append(_OBX_Loinc_Identifier);
            sb.Append(_OBX_Loinc_Observation_Text);
            sb.Append(_OBX_Name_Of_Alternate_Coding_System);
            sb.Append(_OBX_Observation_Sub_ID);
            sb.Append(_OBX_Observation_Value);
            sb.Append(_OBX_Units);
            sb.Append(_OBX_Reference_Range);
            sb.Append(_OBX_Abnormal_Flag);
            sb.Append(_OBX_Probability);
            sb.Append(_OBX_NatureOf_Abnormal_Test);
            sb.Append(_OBX_Observation_Result_Status);
            sb.Append(_OBX_Date_Of_Last_Change_In_Reference_Range_Or_Units);
            sb.Append(_OBX_User_Defined_Access_Checks);
            sb.Append(_OBX_Date_And_Time_Of_Observation);
            sb.Append(_OBX_Producer_ID);
            sb.Append(_OBX_Observation_Method);
            sb.Append(_OBX_Equipment_Instance);
            sb.Append(_OBX_Date_And_Time_Of_Analysis);
            sb.Append(_OBX_Reserved_for_harmonization1);
            sb.Append(_OBX_Reserved_for_harmonization2);
            sb.Append(_OBX_Reserved_for_harmonization3);
            sb.Append(_OBX_Performing_Organization_Name);
            sb.Append(_OBX_Performing_Organization_Address);
            sb.Append(_OBX_Performing_Organization_Medical_Director);
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
        public virtual string OBX_Segment_Type_ID
        {
            get
            {
                return _OBX_Segment_Type_ID;
            }
            set { _OBX_Segment_Type_ID = value; }
        }
        [DataMember]
        public virtual string OBX_Sequence_Number
        {
            get { return _OBX_Sequence_Number; }
            set { _OBX_Sequence_Number = value; }
        }
        [DataMember]
        public virtual string OBX_Value_Type
        {
            get { return _OBX_Value_Type; }
            set { _OBX_Value_Type = value; }
        }
        [DataMember]
        public virtual string OBX_Observation_Identifier
        {
            get { return _OBX_Observation_Identifier; }
            set { _OBX_Observation_Identifier = value; }
        }
        [DataMember]
        public virtual string OBX_Observation_Text
        {
            get { return _OBX_Observation_Text; }
            set { _OBX_Observation_Text = value; }
        }
        [DataMember]
        public virtual string OBX_Name_Of_Coding_System
        {
            get { return _OBX_Name_Of_Coding_System; }
            set { _OBX_Name_Of_Coding_System = value; }
        }
        [DataMember]
        public virtual string OBX_Loinc_Identifier
        {
            get { return _OBX_Loinc_Identifier; }
            set { _OBX_Loinc_Identifier = value; }
        }

        [DataMember]
        public virtual string OBX_Loinc_Observation_Text
        {
            get { return _OBX_Loinc_Observation_Text; }
            set { _OBX_Loinc_Observation_Text = value; }
        }
        [DataMember]
        public virtual string OBX_Name_Of_Alternate_Coding_System
        {
            get { return _OBX_Name_Of_Alternate_Coding_System; }
            set { _OBX_Name_Of_Alternate_Coding_System = value; }
        }
        [DataMember]
        public virtual string OBX_Observation_Sub_ID
        {
            get { return _OBX_Observation_Sub_ID; }
            set { _OBX_Observation_Sub_ID = value; }
        }
        [DataMember]
        public virtual string OBX_Observation_Value
        {
            get { return _OBX_Observation_Value; }
            set { _OBX_Observation_Value = value; }

        }
        [DataMember]
        public virtual string OBX_Units
        {
            get { return _OBX_Units; }
            set { _OBX_Units = value; }
        }
        [DataMember]
        public virtual string OBX_Reference_Range
        {
            get { return _OBX_Reference_Range; }
            set { _OBX_Reference_Range = value; }
        }
        [DataMember]
        public virtual string OBX_Abnormal_Flag
        {
            get { return _OBX_Abnormal_Flag; }
            set { _OBX_Abnormal_Flag = value; }
        }
        [DataMember]
        public virtual string OBX_Probability
        {
            get { return _OBX_Probability; }
            set { _OBX_Probability = value; }
        }
        [DataMember]
        public virtual string OBX_NatureOf_Abnormal_Test
        {
            get { return _OBX_NatureOf_Abnormal_Test; }
            set { _OBX_NatureOf_Abnormal_Test = value; }
        }
        [DataMember]
        public virtual string OBX_Observation_Result_Status
        {
            get { return _OBX_Observation_Result_Status; }
            set { _OBX_Observation_Result_Status = value; }
        }
        [DataMember]
        public virtual string OBX_Date_Of_Last_Change_In_Reference_Range_Or_Units
        {
            get { return _OBX_Date_Of_Last_Change_In_Reference_Range_Or_Units; }
            set { _OBX_Date_Of_Last_Change_In_Reference_Range_Or_Units = value; }
        }
        [DataMember]
        public virtual string OBX_User_Defined_Access_Checks
        {
            get { return _OBX_User_Defined_Access_Checks; }
            set { _OBX_User_Defined_Access_Checks = value; }
        }
        [DataMember]
        public virtual string OBX_Date_And_Time_Of_Observation
        {
            get { return _OBX_Date_And_Time_Of_Observation; }
            set { _OBX_Date_And_Time_Of_Observation = value; }
        }
        [DataMember]
        public virtual string OBX_Producer_ID
        {
            get { return _OBX_Producer_ID; }
            set { _OBX_Producer_ID = value; }
        }
        [DataMember]
        public virtual string temp_property
        {
            get { return _temp_property; }
            set { _temp_property = value; }
        }





        [DataMember]
        public virtual string OBX_Responsible_Observer
        {
            get { return _OBX_Responsible_Observer; }
            set { _OBX_Responsible_Observer = value; }
        }
        [DataMember]
        public virtual string OBX_Observation_Method
        {
            get { return _OBX_Observation_Method; }
            set { _OBX_Observation_Method = value; }
        }


        [DataMember]
        public virtual string OBX_Equipment_Instance
        {
            get { return _OBX_Equipment_Instance; }
            set { _OBX_Equipment_Instance = value; }
        }
        [DataMember]
        public virtual string OBX_Date_And_Time_Of_Analysis
        {
            get { return _OBX_Date_And_Time_Of_Analysis; }
            set { _OBX_Date_And_Time_Of_Analysis = value; }
        }
        [DataMember]
        public virtual string OBX_Reserved_for_harmonization1
        {
            get { return _OBX_Reserved_for_harmonization1; }
            set { _OBX_Reserved_for_harmonization1 = value; }
        }
        [DataMember]
        
        public virtual string OBX_Reserved_for_harmonization2
        {
            get { return _OBX_Reserved_for_harmonization2; }
            set { _OBX_Reserved_for_harmonization2 = value; }
        }
        [DataMember]
        public virtual string OBX_Reserved_for_harmonization3
        {
            get { return _OBX_Reserved_for_harmonization3; }
            set { _OBX_Reserved_for_harmonization3 = value; }
        }

        [DataMember]
        public virtual string OBX_Performing_Organization_Name
        {
            get { return _OBX_Performing_Organization_Name; }
            set { _OBX_Performing_Organization_Name = value; }
        }

        [DataMember]
        public virtual string OBX_Performing_Organization_Address
        {
            get { return _OBX_Performing_Organization_Address; }
            set { _OBX_Performing_Organization_Address = value; }
        }

        [DataMember]
        public virtual string OBX_Performing_Organization_Medical_Director
        {
            get { return _OBX_Performing_Organization_Medical_Director; }
            set { _OBX_Performing_Organization_Medical_Director = value; }
        }
        #endregion
    }
}


