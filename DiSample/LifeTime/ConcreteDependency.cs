using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSample.LifeTime
{
    public class ConcreteDependency
    {
        //بعضی وقتا ما نمیخوایم اینترفیس بسازیم و فقط میخوام کلاس را تعریف کنیم
        //بهش میگن
        //Concrete Depencency

        public void AddConcerte(IServiceCollection services) { 
        services.AddTransient<ConcreteDependency>();
        }
    }
}
