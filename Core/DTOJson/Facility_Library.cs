using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acurus.Capella.Core.DTOJson
{
    public class Facility_Library
    {
        public Facility_Library()
        {
            FacilityList = new List<FacilityList>();
        }
        public List<FacilityList> FacilityList { get; set; }
    }

    public class FacilityList
    {
        public string Name { get; set; }
        public string Primary_IP { get; set; }
        public string Secondary_IP { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string City { get; set; }
        public string Slot_Length { get; set; }
        public string Facility_NPI { get; set; }
        public string Taxonomy_Code { get; set; }
        public string Taxonomy_Description { get; set; }
        public string Facility_Fax { get; set; }
        public string Legal_Org { get; set; }
    }
}