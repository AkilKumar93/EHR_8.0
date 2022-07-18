using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class CreateException : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _EnconterID = 0;
        private ulong _HumanID = 0;
        private ulong _PhySicianID = 0;
    
        private string _Issues = string.Empty;
        private string _FeedBack = string.Empty;
        private string _FeedBack_ProvidedBy = string.Empty;

        private string _createdby = string.Empty;
        private System.DateTime _createddatetime = DateTime.MinValue;
        private string _modifiedby = string.Empty;
        private System.DateTime _modifieddatetime = DateTime.MinValue;

        private int _Version = 0;

        #endregion


        #region Constructors

        public CreateException() { }

        #endregion


        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_EnconterID);
            sb.Append(_HumanID);
            sb.Append(_PhySicianID);
            sb.Append(_FeedBack_ProvidedBy);
            sb.Append(_Issues);
            sb.Append(_FeedBack);
            sb.Append(_createdby);
            sb.Append(_createddatetime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddatetime);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }

        #endregion


        #region Properties

        [DataMember]
        public virtual ulong Enounter_ID
        {
            get { return _EnconterID; }
            set
            {
                _EnconterID = value;
            }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _HumanID; }
            set
            {
                _HumanID = value;
            }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _PhySicianID; }
            set
            {
                _PhySicianID = value;
            }
        }

        [DataMember]
        public virtual string FeedBack_ProvidedBy
        {
            get { return _FeedBack_ProvidedBy; }
            set
            {
                _FeedBack_ProvidedBy = value;
            }
        }

        [DataMember]
        public virtual string Issues
        {
            get { return _Issues; }
            set
            {
                _Issues = value;
            }
        }
        [DataMember]
        public virtual string FeedBack
        {
            get { return _FeedBack; }
            set
            {
                _FeedBack = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _createdby; }
            set
            {
                _createdby = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set
            {
                _modifiedby = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Created_Date_And_Time
        {
            get { return _createddatetime; }
            set
            {
                _createddatetime = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Modified_Date_And_Time
        {
            get { return _modifieddatetime; }
            set
            {
                _modifieddatetime = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        
        #endregion


    }
}
