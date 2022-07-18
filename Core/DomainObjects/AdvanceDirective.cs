using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class AdvanceDirective : BusinessBase<ulong>
    {
        #region Declarations

        private string _Status = string.Empty;
        private ulong _Human_ID = 0;
        private string _Comments = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version =0;
        private ulong _Encounter_Id = 0;
        private ulong _advance_directive_master_Id = 0;
        #endregion

        #region Constructors

        public AdvanceDirective() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Status);
            sb.Append(_Human_ID);
            sb.Append(_Comments);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Encounter_Id);
            sb.Append(_advance_directive_master_Id);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

         
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
         
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
         
        public virtual string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
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
         
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        
        public virtual ulong Encounter_Id
        {
            get { return _Encounter_Id; }
            set { _Encounter_Id = value; }
        }

        public virtual ulong Advance_Directive_Master_ID
        {
            get { return _advance_directive_master_Id; }
            set { _advance_directive_master_Id = value; }
        }
        #endregion
    }
}
