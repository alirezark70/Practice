using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr_Management.Domain.Common
{

    public abstract class BaseDomainEntity<T>: BaseEntity
    {
        public T Id { get;protected set; }

    }

    

}
