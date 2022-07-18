using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class WorkFlowTypeMaster : BusinessBase<ulong>
    {
        #region Declarations
        private string _Legal_Org = string.Empty;
        private string _Facility_Name = string.Empty;
        private string _Payor = string.Empty;
        private string _Workflow_Type = string.Empty;

        #endregion

        #region Constructors

        public WorkFlowTypeMaster() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Legal_Org);
            sb.Append(_Facility_Name);
            sb.Append(_Payor);
            sb.Append(_Workflow_Type);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region properties

        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set { _Legal_Org = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        [DataMember]
        public virtual string Payor
        {
            get { return _Payor; }
            set { _Payor = value; }
        }
        [DataMember]
        public virtual string Workflow_Type
        {
            get { return _Workflow_Type; }
            set { _Workflow_Type = value; }
        }
        #endregion
    }
}
