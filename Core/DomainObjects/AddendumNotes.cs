using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    [Serializable]
    public partial class AddendumNotes : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Human_ID = 0;
        private ulong _Encounter_ID = 0;
        private string _Addendum_Notes = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private ulong _Provider_Signed_ID = 0;
        private DateTime _Provider_Signed_Date_And_Time = DateTime.MinValue;
        private ulong _Provider_Review_Signed_ID = 0;
        private DateTime _Provider_Review_Signed_Date_And_Time = DateTime.MinValue;
        private string _Addendum_Source = string.Empty;
        private string _Is_Accept = string.Empty;      
        private int _Version = 0;
        private string _Local_Time = string.Empty;

        #endregion

        #region Constructors

        public AddendumNotes() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Addendum_Notes);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Provider_Signed_ID);
            sb.Append(_Provider_Signed_Date_And_Time);
            sb.Append(_Provider_Review_Signed_ID);
            sb.Append(_Provider_Review_Signed_Date_And_Time);
            sb.Append(_Addendum_Source);
            sb.Append(_Is_Accept);
            sb.Append(_Version);
            sb.Append(_Local_Time);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }

        [DataMember]
        public virtual string Addendum_Notes
        {
            get { return _Addendum_Notes; }
            set { _Addendum_Notes = value; }
        }

        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        [DataMember]
        public virtual System.DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }

        [DataMember]
        public virtual string Modified_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        [DataMember]
        public virtual System.DateTime Modified_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }

        [DataMember]
        public virtual ulong Provider_Signed_ID
        {
            get { return _Provider_Signed_ID; }
            set { _Provider_Signed_ID = value; }
        }

        [DataMember]
        public virtual System.DateTime Provider_Signed_Date_And_Time
        {
            get { return _Provider_Signed_Date_And_Time; }
            set { _Provider_Signed_Date_And_Time = value; }
        }

        [DataMember]
        public virtual ulong Provider_Review_Signed_ID
        {
            get { return _Provider_Review_Signed_ID; }
            set { _Provider_Review_Signed_ID = value; }
        }

        [DataMember]
        public virtual System.DateTime Provider_Review_Signed_Date_And_Time
        {
            get { return _Provider_Review_Signed_Date_And_Time; }
            set { _Provider_Review_Signed_Date_And_Time = value; }
        }

        [DataMember]
        public virtual string Addendum_Source
        {
            get { return _Addendum_Source; }
            set { _Addendum_Source = value; }
        }

        [DataMember]
        public virtual string Is_Accept
        {
            get { return _Is_Accept; }
            set { _Is_Accept = value; }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [DataMember]
        public virtual string Local_Time
        {
            get { return _Local_Time; }
            set { _Local_Time = value; }
        }

        #endregion
    }
}