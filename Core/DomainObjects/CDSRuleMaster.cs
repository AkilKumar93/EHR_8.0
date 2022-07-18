using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class CDSRuleMaster : BusinessBase<int>
    {
        #region Declarations
        private string _Message = String.Empty;
        private string _Clinincal_Decision_Name = String.Empty;
        private string _Rules = String.Empty;
        private string _Source_Attributes = String.Empty;
        private string _Developer = String.Empty;
        private string _Funding_Source = String.Empty;
        private string _Where_Criteria = String.Empty;
        private string _Link_Data = String.Empty;
        private string _Release_Date = String.Empty;
        private string _Entity_Name = String.Empty;
        private string _SCN_Name = String.Empty;
        private string _Is_Manage_CDS_Allowed = String.Empty;
        private string _Status = String.Empty;
        private string _Classification = String.Empty;
        private string _Rules_Description = String.Empty;
        private string _Role_Privilege = String.Empty;
        private string _Sort_Order = String.Empty;
        private string _Resolve_Screen = String.Empty;
        private string _Physician_Specialty = string.Empty;
       // private string _Exception_Provider = string.Empty;
        

        #endregion

        #region Constructors

        public CDSRuleMaster() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Message);
            sb.Append(_Clinincal_Decision_Name);
            sb.Append(_Rules);
            sb.Append(_Source_Attributes);
            sb.Append(_Developer);
            sb.Append(_Funding_Source);
            sb.Append(_Where_Criteria);
            sb.Append(_Link_Data);
            sb.Append(_Release_Date);
            sb.Append(_Entity_Name);
            sb.Append(_SCN_Name);
            sb.Append(_Is_Manage_CDS_Allowed);
            sb.Append(_Status);
            sb.Append(_Classification);
            sb.Append(_Rules_Description);
            sb.Append(_Role_Privilege);
            sb.Append(_Sort_Order);
            sb.Append(_Resolve_Screen);
            sb.Append(_Physician_Specialty);
            //sb.Append(_Exception_Provider);
            
            return sb.ToString().GetHashCode();
        }
        #endregion
        #region Properties
        [DataMember]
        public virtual string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        [DataMember]
        public virtual string Clinincal_Decision_Name
        {
            get { return _Clinincal_Decision_Name; }
            set { _Clinincal_Decision_Name = value; }
        }
        [DataMember]
        public virtual string Rules
        {
            get { return _Rules; }
            set { _Rules = value; }
        }
        [DataMember]
        public virtual string Source_Attributes
        {
            get { return _Source_Attributes; }
            set { _Source_Attributes = value; }
        }
        [DataMember]
        public virtual string Developer
        {
            get { return _Developer; }
            set { _Developer = value; }
        }
        [DataMember]
        public virtual string Funding_Source
        {
            get { return _Funding_Source; }
            set { _Funding_Source = value; }
        }
        [DataMember]
        public virtual string Where_Criteria
        {
            get { return _Where_Criteria; }
            set { _Where_Criteria = value; }
        }
        [DataMember]
        public virtual string Link_Data
        {
            get { return _Link_Data; }
            set { _Link_Data = value; }
        }
        [DataMember]
        public virtual string Release_Date
        {
            get { return _Release_Date; }
            set { _Release_Date = value; }
        }
        [DataMember]
        public virtual string Entity_Name
        {
            get { return _Entity_Name; }
            set { _Entity_Name = value; }
        }
        [DataMember]
        public virtual string SCN_Name
        {
            get { return _SCN_Name; }
            set { _SCN_Name = value; }
        }
        [DataMember]
        public virtual string Is_Manage_CDS_Allowed
        {
            get { return _Is_Manage_CDS_Allowed; }
            set { _Is_Manage_CDS_Allowed = value; }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [DataMember]
        public virtual string Classification
        {
            get { return _Classification; }
            set { _Classification = value; }
        }
        [DataMember]
        public virtual string Rules_Description
        {
            get { return _Rules_Description; }
            set { _Rules_Description = value; }
        }
        [DataMember]
        public virtual string Role_Privilege
        {
            get { return _Role_Privilege; }
            set { _Role_Privilege = value; }
        }
        [DataMember]
        public virtual string Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }

        [DataMember]
        public virtual string Resolve_Screen
        {
            get { return _Resolve_Screen; }
            set { _Resolve_Screen = value; }
        }

        [DataMember]
        public virtual string Physician_Specialty
        {
            get { return _Physician_Specialty; }
            set { _Physician_Specialty = value; }
        }
        
        //[DataMember]
        //public virtual string Exception_Provider
        //{
        //    get { return _Exception_Provider; }
        //    set { _Exception_Provider = value; }
        //}
        #endregion
    }
}
