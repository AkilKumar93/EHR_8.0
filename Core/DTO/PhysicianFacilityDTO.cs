using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
   public class PhysicianFacilityDTO
   {
       #region Declarations
        private ulong _PhyId = 0;
        private string _PhyPrefix = string.Empty;
        private string _PhyFName = string.Empty;
        private string _PhyMName = string.Empty;
        private string _PhyLName = string.Empty;
        private string _PhySuffix = string.Empty;
        private string _PhyCity = string.Empty;
        private string _PhyState = string.Empty;
        private string _PhyZip = string.Empty;
        private string _PhySpecialtyCode = string.Empty;
        private string _PhyNPI = string.Empty;
        private string _PhyFacility = string.Empty;
       // private ulong _PhySpecialtyID = 0;
        private string _PhySpecialtyID = string.Empty;
        private string _PhyAddrs= string.Empty;
        private string _PhyPhone= string.Empty;
        private string _PhyFax = string.Empty;
        private string _PhyEmail = string.Empty;
        private string _PhyCompany = string.Empty;
        private IList<ulong> _PhyIdList = new List<ulong>();
        private IList<string> _PhyNameList = new List<string>();
        private string _Category= string.Empty;
       #endregion

        #region Constructor

        public PhysicianFacilityDTO()
        {

        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong PhyId
        {
            get { return _PhyId; }
            set
            {
                _PhyId = value;
            }
        }
        [DataMember]
        public virtual string PhyCompany
        {
            get { return _PhyCompany; }
            set
            {
                _PhyCompany = value;
            }
        }

              [DataMember]
        public virtual string PhyEmail
        {
            get { return _PhyEmail; }
            set
            {
                _PhyEmail = value;
            }
        }

        [DataMember]
        public virtual string PhyPrefix
        {
            get { return _PhyPrefix; }
            set
            {
                _PhyPrefix = value;
            }
        }

        [DataMember]
        public virtual string PhyAddrs
        {
            get { return _PhyAddrs; }
            set
            {
                _PhyAddrs = value;
            }
        }
        [DataMember]
        public virtual string PhyPhone
        {
            get { return _PhyPhone; }
            set
            {
                _PhyPhone = value;
            }
        }
        [DataMember]
        public virtual string PhyFax
        {
            get { return _PhyFax; }
            set
            {
                _PhyFax = value;
            }
        }

        [DataMember]
        public virtual string PhyFirstName
        {
            get { return _PhyFName; }
            set
            {
                _PhyFName = value;
            }
        }
        [DataMember]
        public virtual string PhyMiddleName
        {
            get { return _PhyMName; }
            set
            {
                _PhyMName = value;
            }
        }
        [DataMember]
        public virtual string PhyLastName
        {

            get { return _PhyLName; }
            set
            {
                _PhyLName = value;
            }
        }
        [DataMember]
        public virtual string PhySuffix
        {
            get { return _PhySuffix; }
            set
            {
                _PhySuffix = value;
            }
        }

        [DataMember]
        public virtual string PhyCity
        {
            get { return _PhyCity; }
            set
            {
                _PhyCity = value;
            }
        }
        [DataMember]
        public virtual string PhyState
        {
            get { return _PhyState; }
            set
            {
                _PhyState = value;
            }
        }
        [DataMember]
        public virtual string PhyZip
        {
            get { return _PhyZip; }
            set
            {
                _PhyZip = value;
            }
        }
        [DataMember]
        public virtual string PhySpecialtyCode
        {
            get { return _PhySpecialtyCode; }
            set
            {
                _PhySpecialtyCode = value;
            }
        }

        [DataMember]
        public virtual string PhyNPI
        {
            get { return _PhyNPI; }
            set
            {
                _PhyNPI = value;
            }
        }
        [DataMember]
        public virtual string PhyFacility
        {
            get { return _PhyFacility; }
            set
            {
                _PhyFacility = value;
            }
        }

        [DataMember]
        public virtual string PhySpecialtyID
        {
            get { return _PhySpecialtyID; }
            set
            {
                _PhySpecialtyID = value;
            }
        }
      
        [DataMember]
        public virtual IList<ulong> PhyIdList
        {
            get { return _PhyIdList; }
            set { _PhyIdList = value; }
        }
        [DataMember]
        public virtual IList<string> PhyNameList
        {
            get { return _PhyNameList; }
            set { _PhyNameList = value; }
        }
        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        #endregion
    }
}
