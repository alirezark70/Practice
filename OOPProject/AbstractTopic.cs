using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public abstract class AbstractTopic
    {
        //گاهی اوعات ما نیازی نیست که در کلاس والد متدی را پیاده سازی کنیم و فقط داشته باشیم کافی است 
        //برای این کار از ابسترکت در متد استفاده می کنیم

        public abstract void GetMethod();
    }
}
