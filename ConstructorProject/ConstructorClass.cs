using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorProject
{
    public class ConstructorClass
    {
        //یک کلاس والد داریم به اسم پروداتت و یک کلاس فرزند داریم به اسم موبایل 
        // وقتی در سازنده مقداری بدیم 
        // بعد از نمونه سازی فرزند اول سازنده والد صدا زده میشه و سپس سازنده فرزند
    }

    public class Product
    {
        public Product()
        {
            Console.WriteLine("Constructor Product");
        }

        public Product(string name)
        {
            Console.WriteLine($"Constructor Parent Have Value and it's {name}");
        }
    }

    public class Mobile:Product
    {
        public Mobile()
        {
            Console.WriteLine("Constructor Mobile");

        }
        public Mobile(string name):base(name)
        {
            // وقتی هم والد و هم فرزند سازنده اش با پارامتر بود وقتی پارامتر را به کلاس پاس میدیم فقط برای فرزند را ست می کنه
            //برای حل این مشکل باید به مقدار سازنده فرزند 
            //base (parameter)
            //را بدیم که وقتی پارامتر میدیم پاس بده به سازنده والد
            Console.WriteLine($"Constructor {name}");
        }
    }
}
