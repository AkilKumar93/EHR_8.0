using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acurus.Capella.Core.DTOJson
{
    public class Room_in_lookupList
    {
        public Room_in_lookupList()
        {
            facility = new List<Facility>();
        }
        public List<Facility> facility { get; set; }
    }
    public class ExamRoom
    {
        public string Name { get; set; }
        public string sortorder { get; set; }
    }

    public class Facility
    {
        public Facility()
        {
            exam_room = new List<ExamRoom>();
        }
        public string name { get; set; }
        public List<ExamRoom> exam_room { get; set; }
    }

    
}
