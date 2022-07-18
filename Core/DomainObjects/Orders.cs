using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class Orders : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Encounter_ID = 0;
        private ulong _Human_ID = 0;
        private ulong _Physician_ID = 0;
        private string _Lab_Procedure = string.Empty;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Lab_Procedure_Description = string.Empty;
        private string _Order_Code_Type = string.Empty;
        private string _Orders_Question_Set_Segment = string.Empty;
        private string _Internal_Property_Current_Process = string.Empty;
        private ulong _Order_Submit_ID = 0;
        private string _Internal_Property_Lab_Name = string.Empty;
        private DateTime _Internal_Property_spec_Collection_Date = DateTime.MinValue;
        private ulong _CMG_Encounter_ID = 0;
        private IList<Lab> _lstLab = new List<Lab>();
        private DateTime _Internal_Property_EncounterDate = DateTime.MinValue;
        private ulong _Internal_Property_Lab_ID = 0;
        private decimal _Quantity = 0;

        private string _Prior_Auth_Req = string.Empty;
        private string _Beyond_Qty_Limit = string.Empty;
        private string _Custom_Item = string.Empty;
        private string _Justification = string.Empty;
        #endregion

        #region Constructors

        public Orders() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Lab_Procedure);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Lab_Procedure_Description);
            sb.Append(_Order_Submit_ID);
            sb.Append(_Orders_Question_Set_Segment);
            sb.Append(_Order_Code_Type);
            sb.Append(_Internal_Property_Current_Process);
            sb.Append(_CMG_Encounter_ID);
            sb.Append(_Internal_Property_EncounterDate);
            sb.Append(_Quantity);
            sb.Append(_Prior_Auth_Req);
            sb.Append(_Beyond_Qty_Limit);
            sb.Append(_Custom_Item);
            sb.Append(_Justification);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Prior_Auth_Req
        {
            get { return _Prior_Auth_Req; }
            set { _Prior_Auth_Req = value; }
        }
        [DataMember]
        public virtual string Beyond_Qty_Limit
        {
            get { return _Beyond_Qty_Limit; }
            set { _Beyond_Qty_Limit = value; }
        }
        [DataMember]
        public virtual string Custom_Item
        {
            get { return _Custom_Item; }
            set { _Custom_Item = value; }
        }
        [DataMember]
        public virtual string Justification
        {
            get { return _Justification; }
            set { _Justification = value; }
        }
        [DataMember]
        public virtual decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual string Lab_Procedure
        {
            get { return _Lab_Procedure; }
            set { _Lab_Procedure = value; }
        }
        [DataMember]
        public virtual string Orders_Question_Set_Segment
        {
            get { return _Orders_Question_Set_Segment; }
            set { _Orders_Question_Set_Segment = value; }
        }

        [DataMember]
        public virtual ulong Internal_Property_LabID
        {
            get { return _Internal_Property_Lab_ID; }
            set { _Internal_Property_Lab_ID = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }


        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [DataMember]
        public virtual string Lab_Procedure_Description
        {
            get { return _Lab_Procedure_Description; }
            set { _Lab_Procedure_Description = value; }
        }
        [DataMember]
        public virtual string Order_Code_Type
        {
            get { return _Order_Code_Type; }
            set { _Order_Code_Type = value; }
        }

        [DataMember]
        public virtual string Internal_Property_Current_Process
        {
            get { return _Internal_Property_Current_Process; }
            set { _Internal_Property_Current_Process = value; }
        }
        [DataMember]
        public virtual ulong Order_Submit_ID
        {
            get { return _Order_Submit_ID; }
            set { _Order_Submit_ID = value; }
        }

        [DataMember]
        public virtual string Internal_Property_Lab_Name
        {
            get { return _Internal_Property_Lab_Name; }
            set { _Internal_Property_Lab_Name = value; }
        }

        [DataMember]
        public virtual DateTime Internal_Property_Spec_Collection_Date
        {
            get { return _Internal_Property_spec_Collection_Date; }
            set { _Internal_Property_spec_Collection_Date = value; }
        }
        [DataMember]
        public virtual ulong CMG_Encounter_ID
        {
            get { return _CMG_Encounter_ID; }
            set { _CMG_Encounter_ID = value; }
        }

        [DataMember]
        public virtual IList<Lab> lstLab
        {
            get { return _lstLab; }
            set { _lstLab = value; }
        }
        [DataMember]
        public virtual DateTime Internal_Property_EncounterDate
        {
            get { return _Internal_Property_EncounterDate; }
            set { _Internal_Property_EncounterDate = value; }
        }

        #endregion
    }
}
