using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaceMethod
{
    public abstract class HumanAbstrac
    {
        //تفاوت میان اینترفیس و ابسرترک کلاس
        // در اینترفیس می توانیم ارث بری چندگانه داشته باشیم
        //در ابسترکت کلاس نمی توانیم و فقط می تونیم از یک کلاس ابسترکت ارث بری کنیم
        //اینترفیس استیت ندارد
        //Interfec Don't have State But Abstract Class have State
        //اگر میخواهیم با دیتا کار کنیم از ابسترکت استفاده می کنیم
    }

    public abstract class AnimalAbstrac
    {

    }
    public class InterfaceVsAbstracClass/*:HumanAbstrac,AnimalAbstrac*/
    {
    }
}
