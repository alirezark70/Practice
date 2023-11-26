using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenereateProject.Models
{
    public class Personel:BaseDataModel
    {
        public string PersonalName { get; set; }

        public string PositionName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PeopleId { get; set; }

        public People People { get; set; }
    }
}
