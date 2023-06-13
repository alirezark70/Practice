using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class ThreadWithParameterClass
    {
        //اگر متد دارای پارمتر باشد برای پاس دادن به دلیگیت کمی تفاوت دارد
        //اگر تک پارامتر باشد یک مدلی باید انجام بدیم
        //اگر چند پارامتر داشته باشد باید به نحوه دیگری عمل کنیم

        public void OneParameterExecute(string lastname)
        {
            Thread oneParameter = new Thread(PrintLastName);
            oneParameter.Start(lastname);


            Console.Read();
        }
        //تایپ پارامتر میبایست آبجکت باشد
        public void PrintLastName(object lastname)
        {
            Console.WriteLine(lastname);
        }



        public void MultipleParameterExecute(string firstname,string lastname)
        {
            //برای بیتشر از یک پارامتر باید از لامدا اکسپرشن استفاده کنیم
            Thread multiple = new Thread(() => PrintFullName(firstname, lastname));
            multiple.Start();

            Console.Read();
        }

        public void PrintFullName(object firstname,object lastName)
        {
            Console.WriteLine($"Full Name is : {firstname} {lastName}");
        }
       
    }
}
