using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
    public class FillEncounterandWFObject
    {
        private Encounter _EncRecord = new Encounter();
        private WFObject _EncounterWFRecord = new WFObject();
        private WFObject _DocumentationWFRecord = new WFObject();
        //private WFObject _DocReviewWFRecord = new WFObject();
        private WFObject _AddendumWFRecord = new WFObject();

        [DataMember]
        public Encounter EncRecord
        {
            get { return _EncRecord; }
            set { _EncRecord = value; }
        }
        [DataMember]
        public WFObject EncounterWFRecord
        {
            get { return _EncounterWFRecord; }
            set { _EncounterWFRecord = value; }
        }
        [DataMember]
        public WFObject DocumentationWFRecord
        {
            get { return _DocumentationWFRecord; }
            set { _DocumentationWFRecord = value; }
        }
        //[DataMember]
        //public WFObject DocReviewWFRecord
        //{
        //    get { return _DocReviewWFRecord; }
        //    set { _DocReviewWFRecord = value; }
        //}
       
        [DataMember]
        public WFObject AddendumWFRecord
        {
            get { return _AddendumWFRecord; }
            set { _AddendumWFRecord = value; }
        }
    }     
}
