using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleProject
{
    public class TupleClass
    {
        //اگر بخواهیم برای هرچیزی کوچکی دیتا تایپ ایجاد نکنیم و تمیز تر کد بنویسیم
        // می تونیم از تاپل استفاده کنیم به شکل زیر 

        public (int Id,string name,string family) GetPerson(int id)
        {
            //یک مدل موقت ایجاد می کنیم و بعد از استفاده از بین می ره
            //خروجی متد هم می تونه یک تاپل باشه
            (int Id, string name, string family) person = (1, "Alireza", "Rezaee");

            return person;
        }
    }
}
