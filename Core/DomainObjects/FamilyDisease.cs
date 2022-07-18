using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public class FamilyDisease : BusinessBase<ulong>
    {
        #region Parameter Declaration

        private ulong _Family_History_ID = 0;
        private ulong _Human_ID = 0;      
        private string _Internal_Property_Relation = string.Empty;
        private string _Disease=string.Empty ;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _version = 0;
        private string _recodes = string.Empty;

        #endregion

       #region Constructors

        public FamilyDisease() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Family_History_ID);
            sb.Append(_Human_ID);
            sb.Append(_Disease);
            sb.Append(_Internal_Property_Relation);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Parameter Implementation

         
        public virtual int Version
        {
            get { return _version; }
            set { _version = value;}
        }
         
        public virtual ulong Family_History_ID
        {
            get { return _Family_History_ID; }
            set { _Family_History_ID = value; }
        }

        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        public virtual string Disease
        {
            get { return _Disease; }
            set { _Disease = value; }
        }
         
        public virtual string Internal_Property_Relation
        {
            get { return _Internal_Property_Relation; }
            set { _Internal_Property_Relation = value; }
        }
         
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
         
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
         
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
         
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }

        public virtual string Recodes
        {
            get { return _recodes; }
            set { _recodes = value; }
        }

        #endregion
    }
}
