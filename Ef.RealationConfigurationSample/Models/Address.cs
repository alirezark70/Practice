using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.Models
{
    public class Address
    {
        public int Id { get; set; }

        

        public int PersonId { get; set; }
        public int PersonId2 { get; set; }
        public Person Person { get; set; }
    }
}
