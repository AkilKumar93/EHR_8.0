using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acurus.Capella.Core.DTOJson
{
    public class Master_VitalList
    {
        public Master_VitalList()
        {
            MasterVitals = new List<Master_Vital>();
        }
        public List<Master_Vital> MasterVitals { get; set; }
    }
    public class Master_Vital
    {
        public string Id { get; set; }
        public string Vital_Name { get; set; }
        public string Vital_Unit { get; set; }
        public string Vital_Type { get; set; }
        public string Sort_Order { get; set; }
    }

}