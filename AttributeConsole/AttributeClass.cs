using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AttributeConsole
{
    public class AttributeClass
    {
        //به اصطلاح وقتی میخواهیم اتریبیوتی اختصاص بدیم می گویم دکوریت کردن
        //بعضی از اتریبیوت ها در زمان دیباگ به درد ما میخوره که در فضای نام
        //System.Diagnostics;
    }

    //وقتی نمونه سازی میشه و روش کلیک می کنیم این اطلاعات را برای راحتی کار در زمان دولوپ نمایش میده
    [DebuggerDisplay($"FirstName is {nameof(Person.FirstName)} and LastName : {nameof(Person.LastName)}")]

    //این یک اتریبیوتی است که با ان می توانیم اطلاعات قابل مشاهده را کاملا شخصی سازی کنیم
    //ما یک کلاس درست کردم و گذاشتیم توی این حالا کلاس را میریم کامل می کنیم
    [DebuggerTypeProxy(typeof(DebuggerPersonProxySample))]
    public class Person
    {
        //این پروپرتی در زمان توسعه و دیباگ این پروپرتی را نمایش نمیده
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Guid Id => new Guid();
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class PersonPrint
    {
        private readonly Person _person;

        public PersonPrint(Person person)
        {
            this._person = person;
        }

       public void Print()
        {
            PrintFullName();
            PrintAge();
        }

        private void PrintAge()
        {
            Console.WriteLine($"Age Is {_person.Age}");
        }

        private void PrintFullName()
        {
            Console.WriteLine($"FirstName :{_person.FirstName} And LastName : {_person.LastName}");
        }
    }


    public class CompilerMode
    {
        //با این اتریبیوت به سیستم میگیم که این متد فقط در حالت دولوپ اجرا بشه و در حالت ریلیز و اصلی حذف بشه
        [Conditional("DEBUG")]
         //می توانیم به ادرس زیر برویم و تغییرات را درون فضای دیباگ بزاریم که بر اساس اون تفکیک انجام بشه
         //Clik Right On the Project And General Conditional 
        public void TestComplieMode()
        {

        }
    }
}
