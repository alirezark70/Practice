using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaceMethod
{

    /// <summary>
    /// یک اینترفیس داریم به اسم انسان
    /// یک متد داره به نام اسم 
    /// همین متد را اینترفیس حیوان هم داره و هم نام هستند
    /// </summary>
    public interface Human
    {
        void Name(string name);
    }

    public interface Animal
    {
        void Name(string name);
    }
    /// <summary>
    /// از هر دو اینترفیس ارث بری کردیم و متد های هم نام را بدین شکل پیاده سازی می کنیم
    /// </summary>
    public class ExplicitInterfaceClasses : Human, Animal
    {
        //we don't take access modifires to this method because it's explicit interface method
         void Human.Name(string name)
        {
            Console.WriteLine($"Human Name is {name}");
        }

        //هر متد را بر اساس کارایی که داره پیاده سازی میکنیم
        //کاری که می کنیم سطح دسترسی ازش برمیداریم یعنی نه پابلیکه نه پریویت
        //سپس اسم اینترفیس قبل اسم متد بهش میدیم
        void Animal.Name(string name)
        {
            Console.WriteLine($"Animal Name is {name}");
        }
    }
}
