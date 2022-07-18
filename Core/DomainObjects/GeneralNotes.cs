using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class GeneralNotes : BusinessBase<ulong>
    {
        #region Declarations

        private string _Parent_Field = string.Empty;
        private string _Name_Of_The_Field = string.Empty;
        private ulong _Human_ID = 0;
        private ulong _Encounter_ID = 0;
        private string _Notes = string.Empty;
        private int _version=0;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        #endregion

        #region Constructors

        public GeneralNotes() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Parent_Field);
            sb.Append(_Name_Of_The_Field);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Notes);
            sb.Append(_version);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        public virtual string Parent_Field
        {
            get { return _Parent_Field; }
            set { _Parent_Field = value; }

        }
        public virtual string Name_Of_The_Field
        {
            get { return _Name_Of_The_Field; }
            set { _Name_Of_The_Field = value; }

        }
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }
        public virtual string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }

        }
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }

        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }

        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        #endregion
    }
}
