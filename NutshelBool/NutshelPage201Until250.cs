using System;
using System.Collections.Generic;
using System.Dynamic;
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



    #region Custom Binding
    class CustomBinding: DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }
    }

    public class DynamicDictionary:DynamicObject
    {
        //با این الگو می شود یک شی داینامیک ساخت که مدل ها و پروپرتی هایش یکسان نباشد
        Dictionary<string,object> dictionary = new Dictionary<string,object>();

        public int Count
        {
            get { return dictionary.Count;}
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string name=binder.Name.ToLower();

            return dictionary.TryGetValue(name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            dictionary[binder.Name.ToLower()] = value;

            return true;
        }
    }

    #endregion


    #region Runtime Representation of Dynamic

    class RuntimeRepresentationOfDynamic
    {
        //یک داینامیک می تواند به یک آبجکت تبدیل شود

        void Example()
        {
            object o = new System.Text.StringBuilder();
            dynamic d = o;

            d.Append("Hello");
        }
    }

    #endregion


    #region VarVersusDynamic
    class VarVersusDynamic
    {
        //کلمه کلیدی 
        //var 
        //با داینامیک شباهت های سطحی دارند ولی تفاوت های عمیقی و مفهومی باهم دارند

        //var
        //می گویید بگذارید تایپ را کامپایلر تشخیص دهد


        //dynamic
        //می گویید بگذارید مقدار را زمان ران تایم مشخص شود

    }
    #endregion


    #region Dynamic Calls Without Dynanmic Receivers
    class DynamicCallsWithoutDynamicReceivers
    {
        //تا جایی که ممکن است مقادیر در زمان کامپایل شناسایی می شود

    }
    #endregion


    #region Uncallable Functions
    class UncallableFunctions
    {
        //3 نوع فانشن وجود دارد که نمی شود داینامیک تعریف شوند
        //اکسیشن متد
        //اعظای اینترفیس
        //ایتم های هیدن در کلاس های فرزند
        //چون برای اجرای فرایند آنها نیاز به داستن مقادیر اولیه دارند
    }
    #endregion

    #region Custom Implicit And Explicit Conversion Operators
    public class CustomImplicitAndExplicitConversionOperators
    {
        //انواع تبدیل ضمنی و صریح به صورت سفارشی و شخصی سازی شده
        public readonly struct Digit
        {
            private readonly byte digit;

            public Digit(byte digit)
            {
                if(digit>9)
                {
                    throw new ArgumentOutOfRangeException(nameof(digit),"Digit cannot Be Greater than nine");
                }
                this.digit = digit;
            }

            public static implicit operator byte(Digit d) => d.digit;
            public static explicit operator Digit(byte b)=>new Digit(b);

            public override string ToString()
            {
                return $"{digit}";
            }
        }


    }
    #endregion



    #region Fixed - Size - Buffers
    class FixedSizeBuffers
    {
        //کلمه کلیدی Unsafe
        //یک کلمه کلیدی است که قطعه کدی را در یک بلوک جداگانه در نظر میگیره و مقدار مشخص شده استک رم را بهم 
        //اختصاص میدهد


        unsafe struct UnsafeUnicodeString
        {
            public short length;
            //کلمه کلیدی fixed
            //این بدین معنا است که این عدد در زمان اجرا تغییر نمی کند و همیشه این مقدار می باشد
            public fixed byte Buffer[30];
        }

        unsafe class UnsafeColass
        {
            UnsafeUnicodeString uus;
            public UnsafeColass(string s)
            {
                uus.length = (short)s.Length;
                fixed (byte* p=uus.Buffer)
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        p[i] = (byte)s[i];
                    }
                }
            }
        }

    }
    #endregion

    #endregion
}
