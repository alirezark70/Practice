using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSample.LifeTime
{
    public class FactoryScopeSample
    {
        //بعضی وقتا ما میخوام بر اساس نیاز مندی 
        //نمونه سازی داینامیکی داشته باشیم
        //برای اینکار از فکتوری استفاده می کنیم که به شکل زیر است

        //برای اینکه بر اساس یک شرطی کدوم از رفرنس ها نمونه سازی بشه ما می تونیم شرط بزاریم

        public void DependencyFactory(IServiceCollection services)
        {
            var isAdd = DateTime.Now.Second / 5 == 0;
            services.AddScoped<IFactorySample>(e =>
            {
                if (isAdd)
                    return new FirstFactory();

                return new SecendFactory();
            });
        }

    }


    public interface IFactorySample
    {
        string GetText();
    }

    public class FirstFactory : IFactorySample
    {
        public string GetText()
        {
            return nameof(FirstFactory);
        }
    }
    public class SecendFactory : IFactorySample
    {
        public string GetText()
        {
            return nameof(SecendFactory);   
        }
    }

}
