using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
     [DataContract]
    public partial class CorrectedDBEntries : BusinessBase<ulong>
    {
              #region Declarations

         private int _WF_Object_ID = 0;
        private string _Reason_for_Changes = string.Empty;
        private DateTime _Corrected_Date=DateTime.MinValue;
        private string _Corrected_By = string.Empty;
        private string _Old_Process = string.Empty;
         private string _New_Process = string.Empty;
         private string _Old_Owner = string.Empty;
         private string _New_Owner = string.Empty;
         private string _Type_of_Change = string.Empty;
         private int _Version = 0;
        
        #endregion

        #region Constructors

        public CorrectedDBEntries() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_WF_Object_ID);
            sb.Append(_Reason_for_Changes);
            sb.Append(_Corrected_Date);
            sb.Append(_Corrected_By);
            sb.Append(_Old_Process);
            sb.Append(_New_Process);
            sb.Append(_Old_Owner);
            sb.Append(_New_Owner);
            sb.Append(_Type_of_Change);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual int WF_Object_ID
        {
            get { return _WF_Object_ID; }
            set { _WF_Object_ID = value; }
        }
        [DataMember]
        public virtual string Reason_for_Changes
        {
            get { return _Reason_for_Changes; }
            set { _Reason_for_Changes = value; }
        }
        [DataMember]
        public virtual DateTime Corrected_Date
        {
            get { return _Corrected_Date; }
            set { _Corrected_Date = value; }
        }
        [DataMember]
        public virtual string Corrected_By
        {
            get { return _Corrected_By; }
            set { _Corrected_By = value; }
        }
        [DataMember]
        public virtual string Old_Process
        {
            get { return _Old_Process; }
            set { _Old_Process = value; }
        }
        [DataMember]
        public virtual string New_Process
        {
            get { return _New_Process; }
            set { _New_Process = value; }
        }
        [DataMember]
        public virtual string Old_Owner
        {
            get { return _Old_Owner; }
            set { _Old_Owner = value; }
        }
        [DataMember]
        public virtual string New_Owner
        {
            get { return _New_Owner; }
            set { _New_Owner = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        public virtual string Type_of_Change
        {
            get { return _Type_of_Change; }
            set { _Type_of_Change = value; }
        }
       
        #endregion
    }
}
