using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            private set { _x = Math.Round(value, 2); }
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


    #region Partial Class And Method
    public partial class PartialExample
    {

    }

    public partial class AExample
    {
        partial void OnSomethingHappened(string s);
    }

    //This part can be in a separate file.
    public partial class AExample
    {
        // Comment out this method and the program
        // will still compile.
        partial void OnSomethingHappened(String s)
        {
            Console.WriteLine("Something happened: {0}", s);
        }
    }

    #endregion


    #region Inheritance And Polyphormic

    //Upcasting
    //تدبیل فرزند به والد را می گویند که به صورت ضمنی انجام می شود 
    public class Asset
    {
        public int Age { get; set; }
        public void Display(string name)
        {
            WriteLine(name);
        }
    }

    public class Stuck : Asset
    {

    }

    public class House : Asset
    {
        public void OwnerName()
        {
            WriteLine("Test");
        }
    }


    public class PolyphormicExample
    {


        public void UpcastingMethod()
        {
            //Upcasting
            //تدبیل فرزند به والد را می گویند که به صورت ضمنی انجام می شود 
            //this is Upcasting
            House house = new House() { };
            Asset asset = house;


            var test = asset.Display;
            // test.OwnerName(); تبدیل انجام شده است ولی والد دیدی به محتوای متد های فرزند ندارد و خطا کامپایلر تایپ میدهد
        }

        public void DownCasting()
        {
            //Downcasting
            Asset newAsset = new Asset();

            //الان رفرنس هم به والد و هم به خود دسترسی دارد
            House house = (House)newAsset;
            house.OwnerName();
            house.Display("Test");
        }

        public void AsKeyword()
        {
            //ممکن است عملیات دان کست با خطا روبرو شود و برای کنترل این خطا بهتر است از 
            //as
            //استفاده نکنیم

            //اگر استفاده کنیم و خطا دریافت کنیم نمی توانیم بفهمیم که آیا مقدار خالی است یا یک کلاس که میخواهیم کست کنیم نیست
            Asset newAsset = new Asset();

            House house = newAsset as House;
            house?.OwnerName();
        }

    }
    #endregion


    #region Creating Type


    #region Is Keyword
    public class IsClassExample
    {
        public void IsExample()
        {
            //برای چک کردن مقادیر رفرنس تایپ ها استفاده میشود
            //ولیو تایپ ها را قادر به چک کردن نیست

            //مثال
            Stuck stuck = new Stuck();
            if (stuck is Stuck) { }

            //می توانیم در هنگام استفاده از کلمه کلیدی
            //is
            //یک متغییر محلی تعریف کنیم
            //در تیکه کد زیر در هنگام عملیات چک ما یک متغییر با اسم 
            //a 
            //تعریف کردیم
            if (stuck is Asset a)
                a.Display("Test");


            //می توان بعد از کست کردن اعمال شرطی هم قرار داد
            if (stuck is Asset b && b.Age > 18)
                b.Display("Test");

        }
    }
    #endregion


    #region Virtual Function Member

    //یک متد یا فیلد یا ایندکسر یا پروپرتی می تواند 
    //virtual 
    //تعریف شود و در کلاس های فرزند رفتار را لغو و یا تغییر دهد

    public class AssetVirtualExample
    {
        public virtual decimal Liability => 0;
    }

    public class HouseVirtualExample : AssetVirtualExample
    {
        public decimal Mortgage { get; set; }

        public override decimal Liability => Mortgage;

    }
    public class ImplimentVirtual
    {

        public void TestExample()
        {
            HouseVirtualExample house1 = new HouseVirtualExample() { Mortgage = 20000 };

            AssetVirtualExample asset = house1;

            var result = asset.Liability;// result is 20000
        }

        //tips
        //استفاده مجازی سازی در سازنده یا کانستراکتو کاری خطرناک است
        //چون پیاده ساز های دیگر ممکن است از این ویژگی خبر نداشته باشند
    }

    #endregion


    #region Covariant Return Type
    public class AssetCovariant
    {
        public string Name { get; set; }

        public virtual AssetCovariant Clone() => new AssetCovariant { Name = Name };
    }

    public class HouseCovariant : AssetCovariant
    {
        public decimal Mortage;

        public bool Read { get; set; }

        public override HouseCovariant Clone()
        {
            this.Read = true;
            return this;
        }
    }

    public class ExampelCovariant
    {
        public void Test()
        {
            var house = new HouseCovariant() { Name = "Pardis Home", Mortage = 20000 };

            house.Clone();
            AssetCovariant asset = house;
        }
    }
    #endregion


    #region Hiding Inheruted Members
    public abstract class AMember
    {
        public int Count { get; set; }

        public int Counter { get; set; }
    }

    public abstract class BMember : AMember
    {
        //وقتی که یک فیلد در جدول والد و فرزند هستش هشدار میده
        //باید از کلمه کلیدی 
        //new
        //استفاده کنید برای حل این مشکل
        public int Counter { get; set; }
    }
    #endregion


    #region Difference between Override and Hider
    public class BaseClass
    {
        public virtual void Foo() { WriteLine("BaseClass.Foo"); }
    }

    public class Overrider: BaseClass
    {
        public override void Foo() { WriteLine("Overrider.Foo"); }
    }

    public class Hider : BaseClass
    {
        public new void Foo() { WriteLine("Hider.Foo"); }
    }

    public class DifferenceBetweenOverrideAndHider
    {
        public void Test()
        {
            //تفاوت بین 
            //override
            //and
            //hider

            Overrider overrider = new Overrider();
            BaseClass b1 = overrider;
            overrider.Foo();//Overrider.Foo
            b1.Foo();//Overrider.Foo


            Hider hider = new Hider();
            BaseClass b2 = hider;
            hider.Foo();//Hider.Foo
            b2.Foo();//BaseClass.Foo
        }
    }
    #endregion


    #region Base Keyword
    //با کلمه کلیدی 
    //base
    // برای اعضای پنهان می توان استفاده کرد
    //ینی به صورت مستقیم از والد استفاده کرد
    //همیشه سازنده کلاس والد اول اجرا می شود
    #endregion

    #endregion

}
