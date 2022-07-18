using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class WorkFlow : BusinessBase<ulong>  
    {
        #region Declarations
        private string _Obj_Type=string.Empty;
        private string _Obj_Sub_Type = string.Empty;
        private int _Close_Type=0;
        private string _From_Process = string.Empty;
        private string _To_Process = string.Empty;
        private string _Workflow_Type = string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;

        #endregion

        #region Constructors

        public WorkFlow() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Obj_Type);
            sb.Append(_Obj_Sub_Type);
            sb.Append(_Close_Type);
            sb.Append(_From_Process);
            sb.Append(_To_Process);
            sb.Append(_Workflow_Type);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region properties
      
        [DataMember]
        public virtual string Obj_Type
        {
            get { return _Obj_Type; }
            set { _Obj_Type = value; }
        }
        [DataMember]
        public virtual string Obj_Sub_Type
        {
            get { return _Obj_Sub_Type; }
            set { _Obj_Sub_Type = value; }
        }
        [DataMember]
        public virtual int Close_Type
        {
            get { return _Close_Type; }
            set { _Close_Type = value; }
        }
        [DataMember]
        public virtual string From_Process
        {
            get { return _From_Process; }
            set { _From_Process = value; }
        }
        [DataMember]
        public virtual string To_Process
        {
            get { return _To_Process; }
            set { _To_Process = value; }
        }
        [DataMember]
        public virtual string Workflow_Type
        {
            get { return _Workflow_Type; }
            set { _Workflow_Type = value; }
        }

        [DataMember]
        public virtual string Doc_Type
        {
            get { return _Doc_Type; }
            set { _Doc_Type = value; }
        }
        [DataMember]
        public virtual string Doc_Sub_Type
        {
            get { return _Doc_Sub_Type; }
            set { _Doc_Sub_Type = value; }
        }
        #endregion
    }
}
