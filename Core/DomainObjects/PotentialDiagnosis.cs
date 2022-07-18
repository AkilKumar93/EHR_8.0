using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PotentialDiagnosis : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private string _ICD_Code = string.Empty;
        private string _ICD_Description = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Notes = string.Empty;
        private string _Source = string.Empty;
        private string _Move_To_Assessment = string.Empty;
        private string _Version_Year = string.Empty;
        #endregion

        #region Constructors
        public PotentialDiagnosis() { }
        #endregion


        #region HashCode Value
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_ICD_Code);
            sb.Append(_ICD_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Notes);
            sb.Append(_Source);
            sb.Append(_Move_To_Assessment);
            sb.Append(_Version_Year);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual string ICD_Code
        {
            get { return _ICD_Code; }
            set
            {
                _ICD_Code = value;
            }
        }
        [DataMember]
        public virtual string ICD_Description
        {
            get { return _ICD_Description; }
            set
            {
                _ICD_Description = value;
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
            set
            {
                _Modified_By = value;
            }
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
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        [DataMember]
        public virtual string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
            }
        }
        [DataMember]
        public virtual string Source
        {
            get { return _Source; }
            set
            {
                _Source = value;
            }
        }
        [DataMember]
        public virtual string Move_To_Assessment
        {
            get { return _Move_To_Assessment; }
            set
            {
                _Move_To_Assessment = value;
            }
        }
        [DataMember]
        public virtual string Version_Year
        {
            get { return _Version_Year; }
            set
            {
                _Version_Year = value;
            }
        }
        #endregion
    }
}
