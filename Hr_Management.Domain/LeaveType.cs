using Hr_Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr_Management.Domain
{
    public class LeaveType: BaseDomainEntity<int>
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
