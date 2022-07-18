using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ObjectMaster : BusinessBase<ulong>
    {
        #region Declarations
        private string _Object_Type=string.Empty;
        private string _Object_Sub_Type=string.Empty;
        private string _Parent_Object_Type = string.Empty;
        private string _Birth_Process = string.Empty;
        private string _Status=string.Empty;
        private string _Is_Allocate = string.Empty;

        #endregion

        #region Constructors

        public ObjectMaster() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Object_Type);
            sb.Append(_Object_Sub_Type);
            sb.Append(_Parent_Object_Type);
            sb.Append(_Birth_Process);
            sb.Append(_Status);
            sb.Append(_Is_Allocate);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region properties

        
        [DataMember]
        public virtual string Obj_Type
        {
            get { return _Object_Type; }
            set { _Object_Type = value; }
        }
        [DataMember]
        public virtual string Obj_Sub_Type
        {
            get { return _Object_Sub_Type; }
            set { _Object_Sub_Type = value; }
        }
        

        [DataMember]
        public virtual string Parent_Obj_Type
        {
            get { return _Parent_Object_Type; }
            set { _Parent_Object_Type = value; }
        }

        [DataMember]
        public virtual string Birth_Process
        {
            get { return _Birth_Process; }
            set { _Birth_Process = value; }
        }

        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        [DataMember]
        public virtual string Is_Allocate
        {
            get { return _Is_Allocate; }
            set { _Is_Allocate = value; }
        }
        
        #endregion
    }
}