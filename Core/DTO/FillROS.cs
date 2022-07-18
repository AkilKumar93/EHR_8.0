using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
    public partial class FillROS
    {
        #region Declarations
        private IList<ROS> _ros_List;
        private IList<GeneralNotes> _general_Notes_List;
        private IList<GeneralNotes> _ros_generalNotes_List;
        private bool _physician_process;
        private ulong _PreviousEnc = 0;
        #endregion

        #region Constructor

        public FillROS()
        {
            _physician_process = false;
            _ros_List = new List<ROS>();
            _general_Notes_List = new List<GeneralNotes>();
            _ros_generalNotes_List = new List<GeneralNotes>();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<ROS> Ros_List
        {
            get { return _ros_List; }
            set { _ros_List = value; }
        }

        [DataMember]
        public virtual IList<GeneralNotes> General_Notes_List
        {
            get { return _general_Notes_List; }
            set { _general_Notes_List = value; }
        }

        [DataMember]
        public virtual ulong PreviousEnc
        {
            get { return _PreviousEnc; }
            set { _PreviousEnc = value; }
        }

        [DataMember]
        public virtual bool Physician_Process
        {
            get { return _physician_process; }
            set { _physician_process = value; }
        }
        [DataMember]
        public virtual IList<GeneralNotes> ROS_GeneralNotes_List
        {
            get { return _ros_generalNotes_List; }
            set { _ros_generalNotes_List = value; }
        }

        #endregion
    }
}
