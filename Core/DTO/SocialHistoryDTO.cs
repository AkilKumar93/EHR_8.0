using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public partial class SocialHistoryDTO
    {
        #region Declarations
        private IList<SocialHistory> _SocialList= null;
        private GeneralNotes _GeneralNotesObject = null;
        //Changed by vaishali on 18-11-2015
        //private IList<StaticLookup> _StaticList = null;
      
        #endregion

        #region Constructor

        public SocialHistoryDTO() { }

        #endregion

        #region Properties
        [DataMember]
        public virtual IList<SocialHistory> SocialList
        {
            get { return _SocialList; }
            set { _SocialList = value; }
        }
        [DataMember]
        public virtual GeneralNotes GeneralNotesObject
        {
            get { return _GeneralNotesObject; }
            set { _GeneralNotesObject = value; }
        }
        //Changed by vaishali on 18-11-2015
        //public virtual IList<StaticLookup> StaticList
        //{
        //    get { return _StaticList; }
        //    set { _StaticList = value; }
        //}
      
        #endregion
    }
}
