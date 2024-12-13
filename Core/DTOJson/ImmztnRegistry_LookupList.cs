using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acurus.Capella.Core.DTOJson
{
    public class ImmztnRegistry_LookupList
    {
        public ImmztnRegistry_LookupList()
        {
            ImmunizationRegistryResp = new List<ImmunizationRegistryResp>();
            ImmunizationMsgLookupList = new List<ImmunizationMsgLookupList>();
            ImmunizationErrPatList = new List<ImmunizationErrPatList>();
        }
        public List<ImmunizationRegistryResp> ImmunizationRegistryResp { get; set; }
        public List<ImmunizationMsgLookupList> ImmunizationMsgLookupList { get; set; }
        public List<ImmunizationErrPatList> ImmunizationErrPatList { get; set; }

    }
    public class ImmunizationRegistryResp
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class ImmunizationMsgLookupList
    {
        public string Field_Name { get; set; }
        public string value { get; set; }
    }
    public class ImmunizationErrPatList
    {
        public string Field_Name { get; set; }
        public string value { get; set; }
    }

}
