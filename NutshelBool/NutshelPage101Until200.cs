using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace NutshelBooK
{
    public class NutshelPage101Until200
    {
    }

    #region Static Constractur
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public Person(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }
    }

    public class Child : Person
    {
        private static int _maximumAge;
        private int _age;
        static Child()
        {
            _maximumAge = 18;
        }
        public Child(string firstName, string lastName, int age) : base(firstName, lastName)
        {
            _age = age;
        }
        //موارد استفاده از سازنده ثابت
        

        public void AgeChecker()
        {
            if (_age > _maximumAge)
            {
                WriteLine("This Chiled More Than 18");
            }
        }
    }
    #endregion


    #region Property
    public class PropertyExample
    {
        private decimal _x;

        public decimal X
        {
            get { return _x; }
           private set { _x = Math.Round(value,2); }
        }
    }
    #endregion

    #region Finalizers
    public class FinalizersExample
    {
        //مدیریت اشیا یا آبجکت های در سی شارپ است
        //برای آزادسازی منابع کنترل نشده توسط آبجکت
        //Dispose And Finalaize
        
        //Finalaize
        //توسط garbage collector 
        //فراخوانی میشه  به صورت اتوماتیک و برنامه نویس کنترلی روش نداره
        //این فقط در داخل خود کلاس یا آبجکت در دسترس است و به صورت 
        //protected 
        //تعریف شده است

        public void ShowName(string name)
        {
            Console.WriteLine(name);
        }
        ~FinalizersExample()
        {
            System.Diagnostics.Trace.WriteLine("finalizer is called.");
        }

    }
    #endregion
    #region Indexer In Ef core
    public class Blog
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        public int BlogId { get; set; }

        public object this[string key]
        {
            get { return _data[key]; }
            set { _data[key] = value; }
        }
    }
    #endregion
}
