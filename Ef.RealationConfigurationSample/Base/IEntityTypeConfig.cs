using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.Base
{
    public interface IEntityTypeConfig<Entity> : IEntityTypeConfiguration<Entity> where Entity : class
    {
    }
}
