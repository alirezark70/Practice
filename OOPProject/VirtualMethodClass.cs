using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public  class VirtualMethodClass
    {
        //what is virtual method 
        //وقتی ما بخواهیم رفتار کلاس والد را در کلاس فرزند شخصی سازی کنیم از این استفاده می کنیم که از نظر پرفورمنسی توصیه نشده است
        //بهتر است تا مجبور نشده باشیم از این ویژگی استفاده نکنیم
        // از سی شارپ 9 به بالا فرزندانی که متدی را ویرچوال می کنند لازم نیست هم تایپ والد باشند و می توانند پیاده سازی کاملا اختصاصی داشته باشند
        public virtual string GetFullName(string name, string family) => $"{name}" + " " + $"{family}";
    }

    public  class  VirtualClassChild:VirtualMethodClass
     {
        override public string GetFullName(string name, string family) => $"{family}" + " " + $"{name}";
     }

}
