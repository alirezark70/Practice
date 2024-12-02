using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSample.LifeTime
{
    public class SingletonSample : ISingletonSample
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }

    public interface ISingletonSample
    {
        Guid GetGuid();
    }

    public class InjectClass
    {
        public void InjectSingleton(IServiceCollection builder)
        {
            //در این روش یک کلاس در طول عمر برنامه یک بار نمونه سازی میشه
            builder.AddSingleton<ISingletonSample, SingletonSample>();
        }
    }

}
