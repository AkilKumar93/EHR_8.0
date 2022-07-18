using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{

    [DataContract]
    public partial class FillLabAgentDTO
    {
        private ulong _WfObj_ID = new ulong();
        private ulong _WF_Obj_System_ID = new ulong();
        private string _Current_Process = string.Empty;
        private string _labName = string.Empty;
        private string _Obj_Type = string.Empty;
        private DateTime _Current_Arrival_Time = new DateTime();
        private string _Is_Submit_Imediately = string.Empty;
        private string _Order_Code_Type = string.Empty;

        #region Construcor
        public FillLabAgentDTO()
        {
        }
        #endregion
        [DataMember]
        public virtual string Is_Submit_Imediately
        {
            get { return _Is_Submit_Imediately; }
            set { _Is_Submit_Imediately = value; }
        }
        [DataMember]
        public virtual DateTime Current_Arrival_Time
        {
            get { return _Current_Arrival_Time; }
            set { _Current_Arrival_Time = value; }
        }
        [DataMember]
        public virtual ulong WfObj_ID
        {
            get { return _WfObj_ID; }
            set { _WfObj_ID = value; }
        }
        [DataMember]
        public virtual ulong WF_Obj_System_ID
        {
            get { return _WF_Obj_System_ID; }
            set { _WF_Obj_System_ID = value; }
        }
        [DataMember]
        public virtual string Current_Process
        {
            get { return _Current_Process; }
            set { _Current_Process = value; }
        }

        [DataMember]
        public virtual string LabName
        {
            get { return _labName; }
            set { _labName = value; }
        }
        [DataMember]
        public virtual string Obj_Type
        {
            get { return _Obj_Type; }
            set { _Obj_Type = value; }
        }
        [DataMember]
        public virtual string Order_Code_Type
        {
            get { return _Order_Code_Type; }
            set { _Order_Code_Type = value; }
        }


    }
}
