using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NutshelBooK
{
    public class NutshelPage101Until150
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
    //https://www.dntips.ir/post/2485/%D8%A8%D8%B1%D8%B1%D8%B3%DB%8C-%D9%85%D9%81%D8%A7%D9%87%DB%8C%D9%85-covariant-%D9%88-contravariant-%D8%AF%D8%B1-%D8%B2%D8%A8%D8%A7%D9%86-%D8%B3%DB%8C%E2%80%8C%D8%B4%D8%A7%D8%B1%D9%BE
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

    public class Overrider : BaseClass
    {
        public override void Foo() { WriteLine("Overrider.Foo"); }
    }

    public class Hider : BaseClass
    {
        //زمانی که ما کلمه کلیدی 
        //new
        //استفاده می کنیم یعنی یک شی جدید از آن ویژگی ساختیم و این دیگه متد اصلی والد نیست
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

    #region Constructors And Inheritance
    public class BaseClassConAndInh
    {
        public int x;
        //public BaseClassConAndInh() { }

        public BaseClassConAndInh(int x) { this.x = x; }
    }

    public class SubClassConAndInh : BaseClassConAndInh
    {
        public SubClassConAndInh(int x) : base(x) { }
    }

    #endregion


    #region Constructor And Field Initialization Order
    //ترتیب اجرا شدن کلاس فرزند ووالد 

    public class ACAFIO
    {
        int x = 1; //Executes 3st
        public ACAFIO(int x)
        {
            //Executes 4st
        }
    }
    public class BCAFIO : ACAFIO
    {
        int y = 1; //Executes 1st
        public BCAFIO(int x) : base(x = 1) //Executes 2st
        {
            //Executes 5st
        }
    }
    #endregion

    #region The Object Type
    //Stack  یا پشته
    //استک یا پشته یک نوع خطی از ساختار داده است که قادر به ذخیره اشیا است
    //ساختار داده اینگونه است Lifo
    //Last In First Out
    //آخرین موردی که اضافه میشه اولین موردی است که از لیست خارج می شود

    //با توجه به مثال کتاب از خود کلاس و آبچک استفاده شده است
    public class StackExample
    {
        int position;
        object[] data = new object[10];

        public void Push(object obj)
        {
            data[position++] = obj;

        }

        public object Pop() => data[--position];
    }
    #endregion


    #region GetType And typeOf
    //Call GetType On The Instance
    //Use the tyeof operator on a type name
    //GetType is evaluated at runtime; typeof is evaluated statically at compile time

    #endregion


    #region Struct And Class
    //Struct is value type and class is Reference Type
    //Struct does not support inheritance
    //Struct doesn't have Finalizer Becuase this is not subclassess

    //Struct
    //همه فیلد های که در استراکت تعریف می شوند در سازنده باید مقدار داشته باشند در غیر این صورت خطای کامپایلر میگیریم
    //بهترین حالت برای استفاده از این برای مقادیر عددی می باشد 
    //ساختارها فقط می توانند از اینترفیس ها ارث بری کنند و از کلاس ها نمی توانند مشتق شوند
    public struct StructExample
    {
        public int x;
        public int y;
        public StructExample(int x = 1, int y = 1)
        {
            this.x = x;
            this.y = y;
        }

    }



    public struct WebOptions
    {
        string _protocol;

        public string Protocol { get => _protocol ?? "https"; set => _protocol = value; }
    }

    //reference type always live on the heap
    //value type live on stack
    //when value type field in a class , it will reside on the heap
    //وقتی یک فیلدی که ولیو تایپ می باشد و در کلاس قرار داده می شود در همان فضای هیپ که کلاس ذخیره می شود قرار می گیرد


    #endregion


    #region Interface
    public interface ITestInterfaceA
    {
        void Foo();
    }
    public interface ITestInterfaceB
    {
        void Foo();
    }

    public class ImplimentInterfaces : ITestInterfaceA, ITestInterfaceB
    {
        public void Foo()
        {
            throw new NotImplementedException();
        }

        void ITestInterfaceB.Foo()
        {
            throw new NotImplementedException();
        }
    }


    public class ExampleInterface
    {
        public void Test()
        {
            //برای دسترسی به متدی در اینترفیس که هم نام است بدین شیو استفاده می کنیم

            ImplimentInterfaces implimentInterfaces = new ImplimentInterfaces();

            implimentInterfaces.Foo();// Implimentation Interface A

            ((ITestInterfaceB)implimentInterfaces).Foo(); // Implimentation Interface B
        }
    }
    #endregion


    #region Implementing Interface Members Virtually
    public interface IUndoAble
    {
        void Undo();
    }
    public class TextBox : IUndoAble
    {
        public virtual void Undo()
        {
            WriteLine("TextBox Undo");
        }
    }
    public class RichTextBox : TextBox, IUndoAble
    {
        public override void Undo()
        {
            WriteLine("RichBox Undo");
        }
    }

    public interface IUndoAbleB
    {
        void Undo();
    }
    public class TextBoxB : IUndoAbleB
    {
        void IUndoAbleB.Undo()
        {
            WriteLine("TextBox Undo");
        }
        protected virtual void Undo()
        {
            Undo();
        }
    }
    public class RichTextBoxB : TextBoxB, IUndoAbleB
    {
        protected override void Undo()
        {

            WriteLine("RichTextBox Undo");
        }
    }

    public class VirtuallyInterface
    {
        public void Test()
        {

            RichTextBox richTextBox = new RichTextBox();
            ((TextBox)richTextBox).Undo();//RichText
            //متدی که مجازی یا
            //virtual 
            //شده با کست کردن نمی شود به متد های پنهانش دسترسی پیدا کرد
            //برای پیاده سازی این شرایط کلاس باید از اینترفیس خود مشتق شود و نه با کلاس پایه
        }

        //بهترین روش برای پیاده سازی بدین شکل است

    }
    #endregion


    #region Enums
    public enum TestEnum : byte
    {
        //به صورت پیش فرض از صفر شروع می شود ولی می توان عدد هم مشخص کرد و از همان مقدار شروع شود
        //به صورت پیش فرض مقدارش برابر است با دیتا تایپ 
        //int
        //ولی میشود مثل این اینام که تایپ شو من بایت انتخاب کردم تایپشو مشخص کنیم
        first = 1, second = 2, third = 3, fourth = 4, fifth = 5, sixth = 6, seven = 7
    }


    public class EnumExample
    {
        enum SingleHue : short
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8
        };

        [Flags]
        enum MultiHue : short
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8
        };


        public void WithoutFlag()
        {
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (SingleHue)val);
        }

        public void WithFlag()
        {
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (MultiHue)val);


            //برای اینکه چک کنیم یک اینام تعریف شده از روش زیر استفاده می کنیم

            SingleHue enumValue = (SingleHue)14;

            //با این روش می توانیم بفهمیم که یک مقدار اینام موجود هست یا خیر
            var isCurrect = Enum.IsDefined(typeof(SingleHue), enumValue);
        }

    }


    #endregion


    #endregion


    #region Nested Types

    #endregion

    #region Generic
    //جنیریک ها باعث می شوند ما بتوانیم از تکرار کد جلوگیری کنیم
    public class TestGeneric : IComparable<int>
    {
        public static void Swap<T>(T a, T b)
        {
            //
            T temp = a;
            a = b;
            b = temp;

        }

        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }
    }

    //ما می توانیم مقدار را که یک نوع جنریک هست چک کنیم که مقدار نال نداشته باشد
    public class ExampleGeneric<T> where T : notnull
    {
        void Example()
        {
            //اگر در زمان مقداردهی به متد جنریک متد و پارامترها هم نوع باشند خود کامپایلر تشخیص می دهد
            TestGeneric.Swap(14, 15);
        }
    }
    public interface Interface1
    { }
    public class SomeClass { }
    public class ExampleGeneric<C, U> where C : SomeClass, Interface1 where U : new()
    {
        //این کلاس ملزم شده است که از اینترفیس و کلاس معرفی شده مشتق شده 
        //new
        //هم می گویید این کلاس باید سازنده بدون پارامتر داشته باشد


    }

    #region Generic Constraints

    public class ExampleGenericConstraint
    {
        //اینترفیس 
        //icomparable
        //یک اینترفیس مرتب سازی می باشد
        //بیشتر برای مقایسه استفاده می شود و باید متدش که 
        //compareTo
        //می باشد پیاده سازی شود
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        //محدودیت ها یا
        //Constraint
        //ها به شرح زیر است


        //where T : base-class   // Base-class constraint
        //where T : interface    // Interface constraint
        //where T : class        // Reference-type constraint
        //where T : class?       // (see "Nullable Reference Types" in Chapter 1)
        //where T : struct       // Value-type constraint (excludes Nullable types)
        //where T : unmanaged    // Unmanaged constraint //باید حتما ساختار ولیو تایپ یا استراکت باشد و هر گونه رفرنس تایپ را قبول نمی کند
        //where T : new()        // Parameterless constructor constraint// سازنده بدون پارامتر باشد
        //where U : T            // Naked type constraint

        public void TestMethod()
        {
            var result = Max<int>(10, 11);



            WriteLine(result);
        }
    }


    #region Unmanaged Types
    public struct Coords<T>
    {
        public T X;
        public T Y;
    }

    public class UnmanagedTypes
    {
        //محدودیت برای اینکه مشخص بشه که ممکنه تایپ های مدیریت نشده به متد ارسال بشه
        public unsafe static void DisplaySize<T>()
        {
            WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)}");
        }
    }
    #endregion

    #region Default Generic Constrant
    class A1
    {
        //در سی شارپ 9 برای رفع ابهام در ولیو تایپ ها ساختارهای استراکت برای پارامترهای نال اضافه شد
        //و ابهام را برطرف می کند
        public virtual void F1<T>(T? t) where T : struct { }
        public virtual void F1<T>(T? t) where T : class { }
    }

    class B1 : A1
    {
        public override void F1<T>(T? t) /*where T : struct*/ { }
        public override void F1<T>(T? t) where T : class { }
    }
    #endregion

    #region Nuked Type Constraint
    //کلیت تعریف این است که مدل اول با مدل دوم جنزیک یا باید هر دو نال پذیر باشند و یا برعکس
    //شکل هم باید باشند
    //////class Stack<T> { Stack<U> FilteredStack<U>() where U : T { ...} }
    #endregion


    #endregion


    #endregion

    #region Test
    public class TestDefault
    {
        public virtual void TestMethod<T>(T? input) where T : struct
        {

        }
    }

    public class TestDefaultB : TestDefault
    {
        public override void TestMethod<T>(T? input)
        {
            base.TestMethod(input);
        }
    }

    #endregion

}
