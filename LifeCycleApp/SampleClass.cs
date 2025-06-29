using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleApp
{
    interface IServiceTransient
    {
        Guid Id { get; }
    }

    class ServiceTransient : IServiceTransient
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    interface IServiceScoped
    {
        Guid Id { get; }
    }

    class ServiceScoped : IServiceScoped
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    class Consumer
    {
        public readonly IServiceTransient Transient;
        public readonly IServiceScoped Scoped;
        public Consumer(IServiceTransient transient, IServiceScoped scoped)
        {
            Transient = transient;
            Scoped = scoped;
        }
    }

}

