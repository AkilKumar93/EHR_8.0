using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ObjectProcessHistory : BusinessBase<ulong>
    {
        #region Declarations

        private int _WfObjId = 0;
        private string _Process_Name = string.Empty;
        private DateTime _Process_Start_Date_And_Time = DateTime.MinValue;
        private DateTime _Process_End_Date_And_Time = DateTime.MinValue;
        private int _version = 0;
        private string _Obj_Type = string.Empty;
        private string _Obj_Sub_Type = string.Empty;
        private string _Comments = string.Empty;
        private string _User_Name = string.Empty;
        private int _obj_system_id = 0;

        #endregion


        #region Constructors

        public ObjectProcessHistory() { }

        #endregion


        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_WfObjId);
            sb.Append(_Process_Name);
            sb.Append(_Process_Start_Date_And_Time);
            sb.Append(_Process_End_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Obj_Type);
            sb.Append(_Obj_Sub_Type);
            sb.Append(_Comments);
            sb.Append(_User_Name);
            sb.Append(_obj_system_id);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties

        [DataMember]
        public virtual int Wf_Object_ID
        {
            get { return _WfObjId; }
            set
            {
                _WfObjId = value;
            }
        }
        [DataMember]
        public virtual string Process_Name
        {
            get { return _Process_Name; }
            set
            {
                _Process_Name = value;
            }
        }
        [DataMember]
        public virtual DateTime Process_Start_Date_And_Time
        {
            get { return _Process_Start_Date_And_Time; }
            set
            {
                _Process_Start_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual DateTime Process_End_Date_And_Time
        {
            get { return _Process_End_Date_And_Time; }
            set
            {
                _Process_End_Date_And_Time = value;
            }
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
        public virtual string Obj_Type
        {
            get
            {
                return _Obj_Type;
            }
            set
            {
                _Obj_Type = value;
            }
        }
        [DataMember]
        public virtual string Obj_Sub_Type
        {
            get
            {
                return _Obj_Sub_Type;
            }
            set
            {
                _Obj_Sub_Type = value;
            }
        }
        [DataMember]
        public virtual string Comments
        {
            get
            {
                return _Comments;
            }
            set
            {
                _Comments = value;
            }
        }
        [DataMember]
        public virtual string User_Name
        {
            get
            {
                return _User_Name;
            }
            set
            {
                _User_Name = value;
            }
        }


        [DataMember]
        public virtual int Obj_System_ID
        {
            get { return _obj_system_id; }
            set
            {
                _obj_system_id = value;
            }
        }

        #endregion
    }
}
