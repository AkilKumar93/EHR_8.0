using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using System.Runtime.Serialization;
using System.Collections;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class FillLookupDetails
    {
         #region Declarations
      
        
         int _Bucket_1_Count = 0;
         //IList<FillPendingDownload> _Bucket_2_Tables = null;
         //IList<UserRelatedModification> _User_Related = null;
         string _UTC_Time = string.Empty;

        #endregion

         #region Constructor

        public FillLookupDetails() { }

        #endregion

        #region Properties
        
        [DataMember]
        public virtual int Bucket_1_Count
        {
            get { return _Bucket_1_Count ; }
            set { _Bucket_1_Count = value; }
        }

        //[DataMember]
        //public virtual IList<FillPendingDownload> Bucket_2_Tables
        //{
        //    get { return _Bucket_2_Tables; }
        //    set { _Bucket_2_Tables = value; }
        //}

        //[DataMember]
        //public virtual IList<UserRelatedModification> User_Related
        //{
        //    get { return _User_Related; }
        //    set { _User_Related = value; }
        //}

        [DataMember]
        public virtual string UTC_Time
        {
            get { return _UTC_Time; }
            set { _UTC_Time = value; }
        }


        
        #endregion
    }
}
