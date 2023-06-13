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

        public string Laptop { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public string TestBranch { get; set; }

        public string Test { get; set; }
    }
}
