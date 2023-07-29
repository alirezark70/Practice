using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    public class NutshelPage201Until250
    {
    }

    #region Chapter4

    #region AnonymousType
    class AnonymousTypes
    {

    }
    #endregion


    #region Tuples
    class Tuples
    {
        void Example()
        {
            //this is Anonymous Tuple
            var bob = ("Bob", 32, 14);

            string name = bob.Item1;
        }
    }
    #endregion


    #region Record
    class RecorExample
    {
        //یک نوع ساختار برای کار کردن با داده فقط خواندنی است
        //کامپایل تایم می باشند

        //وقتی ما از رکورد استفاده می کنیم 2 تا هدف داریم
        //1 = ما میخواهیم یک ساختمان داده ایجاد کنیم که برابری دیتا برای ما اهمیت دارد
        //2 = هدف ما ایجاد یک شی داده ای به صورت غیر قابل تغییر می باشد


        //یک رکورد می تواند از رکورد ارث بری کند
        //یک رکورد نمی تواند از یک کلاس ارث بری کند
        //یک کلاس نمی تواند از یک رکورد ارث بری کند
        record RecordClasses
        {
            private readonly int _x;
            private readonly int _y;

            public RecordClasses(int x, int y)
            {
                void Test()
                {

                }
                //می توان بدین صورت هم به سازنده مقدار داد
                (_x, _y) = (x, y);
            }

            //این یک رکورد کلاس می باشد
            //این یک رکورد کلاس می باشد
        }

        record struct RecordStruct
        {
            //ما رکورد استراکت هم داریم
        }


        class ValueEquality
        {
            //تعریف برابری داده
            //دو متغییر از یک نوع اگر در مقدار و ویژگی ها و فیلد ها یکی باشند باهم برابر هستند

        }
    }
    #endregion


    #region Calculated Fields And Lazy Evaluation

    class CalculatedFieldsAndLazyEvaluation
    {
        private double? _disctance;
        double CalculateDistance(int x, int y)
        {
            //علامت زیر
            //==?
            //میگه اگه مقدار اول نال بود مقدار دوم ست کن
            double? distanceFromOrgin = _disctance ??= Math.Sqrt(x * x + y * y);

            return distanceFromOrgin.GetValueOrDefault();
        }
    }

    #endregion



    #region Is Pattern

    public class IsPattern
    {
        public void ExampleIsPattern()
        {
            var obj = "Hi";

            //در این پترن گفتیم اگه طول رشته 20 باشد بره داخل شرط
            if (obj is string { Length: 20 })
            {
                Console.WriteLine(obj.Length);
            }

            //در اینجا مقدار رشته را در یک متغییر محلی به نام اس ریختیم
            if (obj is string s)
            {

            }
        }

        public void GetFullName(object firstName, object lastName)
        {
            if (firstName is string f && lastName is string s)
                Console.WriteLine(f + " " + s);


            Console.WriteLine("arguman is Incurrect");
        }
    }
    #endregion


    #region Var Pattern
    public class VarPattern
    {
        void Example()
        {
            bool IsJanetOrJohn(string name)
            {
                return name.ToUpper() is var upper && (upper == "JANET" || upper == "JOHN");
            }

            bool IsHanetOrJohnTwo(string name) => name.ToUpper() is "JANET" or "JOHN";
        }


    }
    #endregion

    
    #region Tuple And Positional Patterns

    public class TupleAndPositionalPatterns
    {
        //Tuple Pattern
        int AverageCelsiusTemperature(Season season, bool daytime)
            => (season, daytime) switch
            {
                (Season.Spring, true) => 20,
                (Season.Spring, false) => 16,
                (Season.Summer, true) => 27,
                (Season.Summer, false) => 22,
                (Season.Fall, true) => 18,
                (Season.Fall, false) => 12,
                (Season.Winter, true) => 10,
                _ => throw new Exception("Unexpected Combination")
            };

        public int GetAverageCelsiusTemperature(Season season, bool daytime)
        {
            return AverageCelsiusTemperature(season, daytime);
        }

       public enum Season
        {
            Spring,
            Summer,
            Fall,
            Winter
        }
    }


    #endregion


    #region Property Patterns
    class PropertyPatterns
    {
        bool ShouldAllow(Url url) => url switch
        {
            { Scheme:"http",Port:80}=>true,
            { Scheme: "https", Port: 443 } => true,
            { Scheme: "ftp", Port: 21 } => true,
            _=>false
        };


        class Url
        {
            public string Scheme { get; set; }
            public int Port { get; set; }

        }
    }
    #endregion




    #region Dynamic Binding

    class DynamicBinding
    {
        //داینامیک فرایند را از کامپایلر تایم به ران تایم تغییر می دهد
        // این زمانی مفید است که ما از نوع و جنس خبر داریم ولی به دلایلی کامپایلر توانایی شناسایی ندارد 
        //برای همین از داینامیک استفاده می کنیم در این زمان

        void Example()
        {
            //dynamic d = GetSomeObject();
        }
    }
    #endregion


    #region Static Binding Versus Dynamic Binding
    class StaticBindingVersusDynamicBinding
    {
        //اتصال ثابت و اتصال داینامیک
        //در فرایندی که در زمان کامپایلر تایم اتصال مشخص شود اتصال ثابت می گوییم
        //و در فرایندی که اتصال تا زمان ران تایم مشخص نباشد و توسط کامپایلر مشخص نگردد اتصال داینامیک می گوییم

        //این یک اتصال ثابت است
        Person Person = new Person("","");


        //این یک اتصال داینامیک می باشد
        //dynamic d=.....
    }
    #endregion


    #endregion
}
