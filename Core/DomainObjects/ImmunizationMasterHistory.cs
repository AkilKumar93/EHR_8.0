using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ImmunizationMasterHistory : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private ulong _Physician_ID = 0;
        private string _Procedure_Code = string.Empty;
        private string _Immunization_Description = string.Empty;
        private ulong _Dose = 0;
        private ulong _Dose_No = 0;
        private DateTime _Date_On_Vis = DateTime.MinValue;
        private DateTime _Vis_Given_Date = DateTime.MinValue;
        private string _Location = string.Empty;
        private string _Lot_Number = string.Empty;
        private string _Manufacturer = string.Empty;
        private DateTime _Expiry_Date = DateTime.MinValue;
        private string _Route_Of_Administration = string.Empty;
        private string _Notes = string.Empty;
        private string _Immunization_Source = string.Empty;
        private string _Is_VIS_Given = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _CVX_Code = string.Empty;
        private int _Version = 0;
        private string _Administered_Date = string.Empty;
        private ulong _Immunization_Order_Id = 0;
        private string _Protection_State = string.Empty;
        private string _Snomed_Code = string.Empty;
        private string _Administration_Unit = string.Empty;
        private decimal _Administered_Amount = 0;
        private string _Is_Deleted = string.Empty;
        #endregion

        #region Constructors

        public ImmunizationMasterHistory() { }

        #endregion
        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Physician_ID);
            sb.Append(_Procedure_Code);
            sb.Append(_Immunization_Description);
            sb.Append(_Dose);
            sb.Append(_Dose_No);
            sb.Append(_Date_On_Vis);
            sb.Append(_Vis_Given_Date);
            sb.Append(_Location);
            sb.Append(_Lot_Number);
            sb.Append(_Manufacturer);
            sb.Append(_Expiry_Date);
            sb.Append(_Route_Of_Administration);
            sb.Append(_Notes);
            sb.Append(_Immunization_Source);
            sb.Append(_Is_VIS_Given);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_CVX_Code);
            sb.Append(_Version);
            sb.Append(_Administered_Date);
            sb.Append(_Immunization_Order_Id);
            sb.Append(_Protection_State);
            sb.Append(_Snomed_Code);
            sb.Append(_Administration_Unit);
            sb.Append(_Administered_Amount);
            sb.Append(_Is_Deleted);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties


        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }

        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
            }
        }

        public virtual string Procedure_Code
        {
            get { return _Procedure_Code; }
            set
            {
                _Procedure_Code = value;
            }
        }

        public virtual string Immunization_Description
        {
            get { return _Immunization_Description; }
            set
            {
                _Immunization_Description = value;
            }
        }

        public virtual ulong Dose
        {
            get { return _Dose; }
            set
            {
                _Dose = value;
            }
        }

        public virtual ulong Dose_No
        {
            get { return _Dose_No; }
            set
            {
                _Dose_No = value;
            }
        }

        public virtual DateTime Date_On_Vis
        {
            get { return _Date_On_Vis; }
            set
            {
                _Date_On_Vis = value;
            }
        }

        public virtual DateTime Vis_Given_Date
        {
            get { return _Vis_Given_Date; }
            set
            {
                _Vis_Given_Date = value;
            }
        }

        public virtual string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
            }
        }

        public virtual string Lot_Number
        {
            get { return _Lot_Number; }
            set
            {
                _Lot_Number = value;
            }
        }

        public virtual string Manufacturer
        {
            get { return _Manufacturer; }
            set
            {
                _Manufacturer = value;
            }
        }

        public virtual DateTime Expiry_Date
        {
            get { return _Expiry_Date; }
            set
            {
                _Expiry_Date = value;
            }
        }

        public virtual string Route_Of_Administration
        {
            get { return _Route_Of_Administration; }
            set
            {
                _Route_Of_Administration = value;
            }
        }

        public virtual string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
            }
        }

        public virtual string Immunization_Source
        {
            get { return _Immunization_Source; }
            set
            {
                _Immunization_Source = value;
            }
        }

        public virtual string Is_VIS_Given
        {
            get { return _Is_VIS_Given; }
            set
            {
                _Is_VIS_Given = value;
            }
        }

        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }

        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }

        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }

        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }

        public virtual string CVX_Code
        {
            get { return _CVX_Code; }
            set
            {
                _CVX_Code = value;
            }
        }

        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }

        public virtual string Administered_Date
        {
            get { return _Administered_Date; }
            set
            {
                _Administered_Date = value;
            }
        }

        public virtual ulong Immunization_Order_ID
        {
            get { return _Immunization_Order_Id; }
            set
            {
                _Immunization_Order_Id = value;
            }
        }

        public virtual string Protection_State
        {
            get { return _Protection_State; }
            set
            {
                _Protection_State = value;
            }
        }

      
        public virtual string Snomed_Code
        {
            get { return _Snomed_Code; }
            set
            {
                _Snomed_Code = value;
            }
        }
        public virtual string Administered_Unit
        {
            get { return _Administration_Unit; }
            set { _Administration_Unit = value; }
        }
        public virtual decimal Administered_Amount
        {
            get { return _Administered_Amount; }
            set { _Administered_Amount = value; }
        }
        public virtual string Is_Deleted
        {
            get { return _Is_Deleted; }
            set
            {
                _Is_Deleted = value;
            }
        }
        #endregion
    }
}
