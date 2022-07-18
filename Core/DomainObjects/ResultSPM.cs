using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ResultSPM : BusinessBase<ulong>
    {
        #region Declarations

        private int _Version = 0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Result_Master_ID = 0;

        private string _SPM_Set_ID = string.Empty;
        private string _SPM_Specimen_ID = string.Empty;
        private string _SPM_Specimen_Parent_IDs = string.Empty;
        private string _SPM_Specimen_Type = string.Empty;
        private string _SPM_Specimen_Type_Modifier = string.Empty;
        private string _SPM_Specimen_Additives = string.Empty;
        private string _SPM_Specimen_Collection_Method = string.Empty;
        private string _SPM_Specimen_Source_Site = string.Empty;
        private string _SPM_Specimen_Source_Site_Modifier = string.Empty;
        private string _SPM_Specimen_Collection_Site = string.Empty;
        private string _SPM_Specimen_Role = string.Empty;
        private string _SPM_Specimen_Collection_Amount = string.Empty;
        private string _SPM_Grouped_Specimen_Count = string.Empty;
        private string _SPM_Specimen_Description = string.Empty;
        private string _SPM_Specimen_Handling_Code = string.Empty;
        private string _SPM_Specimen_Risk_Code = string.Empty;
        private string _SPM_Specimen_Collection_Date_And_Time = string.Empty;
        private string _SPM_Specimen_Expiration_Date_And_Time = string.Empty;
        private string _SPM_Specimen_Availability = string.Empty;
        private string _SPM_Specimen_Reject = string.Empty;
        private string _SPM_Specimen_Quality = string.Empty;
        private string _SPM_Specimen_Appropriateness = string.Empty;
        private string _SPM_Specimen_Condition = string.Empty;
        private string _SPM_Specimen_Current_Quantity = string.Empty;
        private string _SPM_Number_of_Specimen_Containers = string.Empty;
        private string _SPM_Container_Type = string.Empty;
        private string _SPM_Container_Condition = string.Empty;
        private string _SPM_Specimen_Child_Role = string.Empty;

        #endregion

        #region Constructors

        public ResultSPM() { }
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
            sb.Append(_SPM_Set_ID);
            sb.Append(_SPM_Specimen_ID);
            sb.Append(_SPM_Specimen_Parent_IDs);
            sb.Append(_SPM_Specimen_Type);
            sb.Append(_SPM_Specimen_Type_Modifier);
            sb.Append(_SPM_Specimen_Additives);
            sb.Append(_SPM_Specimen_Collection_Method);
            sb.Append(_SPM_Specimen_Source_Site);
            sb.Append(_SPM_Specimen_Source_Site_Modifier);
            sb.Append(_SPM_Specimen_Collection_Site);
            sb.Append(_SPM_Specimen_Role);
            sb.Append(_SPM_Specimen_Collection_Amount);
            sb.Append(_SPM_Grouped_Specimen_Count);
            sb.Append(_SPM_Specimen_Description);
            sb.Append(_SPM_Specimen_Handling_Code);
            sb.Append(_SPM_Specimen_Risk_Code);
            sb.Append(_SPM_Specimen_Collection_Date_And_Time);
            sb.Append(_SPM_Specimen_Expiration_Date_And_Time);
            sb.Append(_SPM_Specimen_Availability);
            sb.Append(_SPM_Specimen_Reject);
            sb.Append(_SPM_Specimen_Quality);
            sb.Append(_SPM_Specimen_Appropriateness);
            sb.Append(_SPM_Specimen_Condition);
            sb.Append(_SPM_Specimen_Current_Quantity);
            sb.Append(_SPM_Number_of_Specimen_Containers);
            sb.Append(_SPM_Container_Type);
            sb.Append(_SPM_Container_Condition);
            sb.Append(_SPM_Specimen_Child_Role);
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
        public virtual string SPM_Set_ID
        {
            get { return _SPM_Set_ID; }
            set { _SPM_Set_ID = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_ID
        {
            get
            {
                return _SPM_Specimen_ID;
            }
            set { _SPM_Specimen_ID = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Parent_IDs
        {
            get { return _SPM_Specimen_Parent_IDs; }
            set { _SPM_Specimen_Parent_IDs = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Type
        {
            get { return _SPM_Specimen_Type; }
            set { _SPM_Specimen_Type = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Type_Modifier
        {
            get { return _SPM_Specimen_Type_Modifier; }
            set { _SPM_Specimen_Type_Modifier = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Additives
        {
            get { return _SPM_Specimen_Additives; }
            set { _SPM_Specimen_Additives = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Collection_Method
        {
            get { return _SPM_Specimen_Collection_Method; }
            set { _SPM_Specimen_Collection_Method = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Source_Site
        {
            get { return _SPM_Specimen_Source_Site; }
            set { _SPM_Specimen_Source_Site = value; }
        }

        [DataMember]
        public virtual string SPM_Specimen_Source_Site_Modifier
        {
            get { return _SPM_Specimen_Source_Site_Modifier; }
            set { _SPM_Specimen_Source_Site_Modifier = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Collection_Site
        {
            get { return _SPM_Specimen_Collection_Site; }
            set { _SPM_Specimen_Collection_Site = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Role
        {
            get { return _SPM_Specimen_Role; }
            set { _SPM_Specimen_Role = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Collection_Amount
        {
            get { return _SPM_Specimen_Collection_Amount; }
            set { _SPM_Specimen_Collection_Amount = value; }

        }
        [DataMember]
        public virtual string SPM_Grouped_Specimen_Count
        {
            get { return _SPM_Grouped_Specimen_Count; }
            set { _SPM_Grouped_Specimen_Count = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Description
        {
            get { return _SPM_Specimen_Description; }
            set { _SPM_Specimen_Description = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Handling_Code
        {
            get { return _SPM_Specimen_Handling_Code; }
            set { _SPM_Specimen_Handling_Code = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Risk_Code
        {
            get { return _SPM_Specimen_Risk_Code; }
            set { _SPM_Specimen_Risk_Code = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Collection_Date_And_Time
        {
            get { return _SPM_Specimen_Collection_Date_And_Time; }
            set { _SPM_Specimen_Collection_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Expiration_Date_And_Time
        {
            get { return _SPM_Specimen_Expiration_Date_And_Time; }
            set { _SPM_Specimen_Expiration_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Availability
        {
            get { return _SPM_Specimen_Availability; }
            set { _SPM_Specimen_Availability = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Reject
        {
            get { return _SPM_Specimen_Reject; }
            set { _SPM_Specimen_Reject = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Quality
        {
            get { return _SPM_Specimen_Quality; }
            set { _SPM_Specimen_Quality = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Appropriateness
        {
            get { return _SPM_Specimen_Appropriateness; }
            set { _SPM_Specimen_Appropriateness = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Condition
        {
            get { return _SPM_Specimen_Condition; }
            set { _SPM_Specimen_Condition = value; }
        }


        [DataMember]
        public virtual string SPM_Specimen_Current_Quantity
        {
            get { return _SPM_Specimen_Current_Quantity; }
            set { _SPM_Specimen_Current_Quantity = value; }
        }
        [DataMember]
        public virtual string SPM_Number_of_Specimen_Containers
        {
            get { return _SPM_Number_of_Specimen_Containers; }
            set { _SPM_Number_of_Specimen_Containers = value; }
        }


        [DataMember]
        public virtual string SPM_Container_Type
        {
            get { return _SPM_Container_Type; }
            set { _SPM_Container_Type = value; }
        }
        [DataMember]
        public virtual string SPM_Container_Condition
        {
            get { return _SPM_Container_Condition; }
            set { _SPM_Container_Condition = value; }
        }
        [DataMember]
        public virtual string SPM_Specimen_Child_Role
        {
            get { return _SPM_Specimen_Child_Role; }
            set { _SPM_Specimen_Child_Role = value; }
        }
       


        #endregion
    }
}
