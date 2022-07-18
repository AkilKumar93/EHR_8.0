using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class RoomInLookup : BusinessBase<string>
    {
         #region Declarations

        private string _Facility_Name=string.Empty;
        private string _Exam_Room=string.Empty;
        private string _Description=string.Empty;
          private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.Now;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.Now;
        private int _Sort_Order = 0;

          private int _version=0;

        #endregion

        #region Constructors

          public RoomInLookup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Facility_Name);
            sb.Append(_Exam_Room);
            sb.Append(_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_version);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        [DataMember]
        public virtual string Exam_Room
        {
            get { return _Exam_Room; }
            set { _Exam_Room = value; }
        }
        [DataMember]
        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set { _version = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        #endregion
    }
}
