using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acurus.Capella.Core.DTOJson
{
    
    public class SpecialityList
    {
        public SpecialityList()
        {
            speciality = new List<Speciality>();
        }
        public List<Speciality> speciality { get; set; }
    }

    public class Speciality
    {
        public string name { get; set; }
    }
}
