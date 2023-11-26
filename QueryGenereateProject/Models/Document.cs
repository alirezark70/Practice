using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenereateProject.Models
{
    public class Document:BaseDataModel
    {
        public string Name { get; set; }

        public string Desctiption { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int PersonelId { get; set; }

        public List<Personel> Personels { get; set; }
    }
}
