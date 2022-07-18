using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{

    //Added by Selvaraman - for AuditTrail
    [DataContract]
    public partial class AuditLog : BusinessBase<uint>
    {

        #region Declarations

        private string _Entity_Name=string.Empty;
        private string _Attribute = string.Empty;
        private ulong _entityId=0;
        private string _Transaction_By=string.Empty;
        private DateTime _Transaction_Date_And_Time=DateTime.MinValue;
        private string _oldValue = string.Empty;
        private string _newValue = string.Empty;
        private string _transactionType=string.Empty;
        private int _Human_ID=0;

        #endregion

        #region Constructors

        public AuditLog() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(this.GetType().FullName);
            sb.Append(_Entity_Name);
            sb.Append(_Attribute);
            sb.Append(_entityId);
            sb.Append(_Transaction_By);
            sb.Append(_Transaction_Date_And_Time);
            sb.Append(_oldValue);
            sb.Append(_newValue);
            sb.Append(_transactionType);
            sb.Append(_Human_ID);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Entity_Name
        {
            get { return _Entity_Name; }
            set
            {
                _Entity_Name = value;
            }
        }

        [DataMember]
        public virtual string Attribute
        {
            get { return _Attribute; }
            set
            {
               _Attribute = value;
            }
        }

        [DataMember]
        public virtual ulong Entity_Id
        {
            get { return _entityId; }
            set
            {
                _entityId = value;
            }
        }

        [DataMember]
        public virtual string Transaction_By
        {
            get { return _Transaction_By; }
            set
            {
                _Transaction_By = value;
            }
        }

        [DataMember]
        public virtual DateTime Transaction_Date_And_Time
        {
            get { return _Transaction_Date_And_Time; }
            set
            {
                _Transaction_Date_And_Time = value;
            }
        }

        [DataMember]
        public virtual string Old_Value
        {
            get { return _oldValue; }
            set
            {
                _oldValue = value;
            }
        }

        [DataMember]
        public virtual string New_Value
        {
            get { return _newValue; }
            set
            {
                _newValue = value;
            }
        }

        [DataMember]
        public virtual string Transaction_Type
        {
            get { return _transactionType; }
            set
            {
                _transactionType = value;
            }
        }

        [DataMember]
        public virtual int Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }

        #endregion


    }
}
