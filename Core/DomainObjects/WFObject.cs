using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class WFObject : BusinessBase<ulong>
    {       
        #region Declarations

        private ulong _Obj_System_Id=0;
        private DateTime _Current_Arrival_time=DateTime.MinValue;
        private string _Obj_Type=string.Empty;
        private string _Obj_Sub_Type = string.Empty;
        private string _Current_Process = string.Empty;
        private string _Current_Owner = string.Empty;
        private string _Priority = string.Empty;
        private string _Fac_Name=string.Empty;
        private string _ParentObjType = string.Empty;
        private ulong _Parent_Obj_System_Id=0;
        private int _version = 0;
        private string _Process_Allocation = string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private int _Is_Default_MyQ_LineItem = 0;
        private string _Is_Abnormal = string.Empty;
        

        #endregion

        #region Constructors

        public WFObject() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Obj_System_Id);
            sb.Append(_Current_Arrival_time);
            sb.Append(_Obj_Type);
            sb.Append(_Obj_Sub_Type);
            sb.Append(_Current_Process);
            sb.Append(_Current_Owner);
            sb.Append(_Priority);
            sb.Append(_Fac_Name);
            sb.Append(_ParentObjType);
            sb.Append(_Parent_Obj_System_Id);
            sb.Append(_version);
            sb.Append(_Doc_Type);
            sb.Append(_Doc_Sub_Type);
            sb.Append(_Is_Default_MyQ_LineItem);
            sb.Append(_Is_Abnormal);
            return sb.ToString().GetHashCode();
        }

        #endregion


        #region properties

      
        [DataMember]
        public virtual ulong Obj_System_Id
        {
            get { return _Obj_System_Id; }
            set { _Obj_System_Id = value; }
        }
        [DataMember]
        public virtual DateTime Current_Arrival_Time
        {
            get { return _Current_Arrival_time; }
            set { _Current_Arrival_time = value; }
        }
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
        public virtual string Current_Process
        {
            get { return _Current_Process; }
            set { _Current_Process = value; }
        }
        [DataMember]
        public virtual string Current_Owner
        {
            get { return _Current_Owner; }
            set { _Current_Owner = value; }
        }
        [DataMember]
        public virtual string Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        [DataMember]
        public virtual string Fac_Name
        {
            get { return _Fac_Name; }
            set { _Fac_Name = value; }
        }
        [DataMember]
        public virtual string Parent_Obj_Type
        {
            get { return _ParentObjType; }
            set { _ParentObjType = value; }
        }
        [DataMember]
        public virtual ulong Parent_Obj_System_Id
        {
            get { return _Parent_Obj_System_Id; }
            set { _Parent_Obj_System_Id = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        [DataMember]
        public virtual string Process_Allocation
        {
            get
            {
                return _Process_Allocation;
            }
            set
            {
                _Process_Allocation = value;
            }
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
        [DataMember]
        public virtual int Is_Default_MyQ_LineItem
        {
            get { return _Is_Default_MyQ_LineItem; }
            set { _Is_Default_MyQ_LineItem = value; }
        }

        [DataMember]

        public virtual string Is_Abnormal
        {
            get { return _Is_Abnormal; }
            set { _Is_Abnormal = value; }
        }


        #endregion
    }
}
