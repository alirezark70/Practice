using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sleep = System.Threading.Thread;
using static System.Console;
using static System.IO.File;
using static NutshelBooK.EventExample;
using System.Runtime.CompilerServices;

namespace NutshelBooK
{
    internal class NutshelPage151Until200
    {
    }

    #region Type Parameters And Conversions

    public class TypeParametersAndConversions
    {
        public StringBuilder Foo<T>(T arg)
        {
            //if(arg is StringBuilder)
            //    return (StringBuilder)arg;//اگر کد را اینگونه بنویسیم ابهام ایجاد می شود 

            StringBuilder stringBuilder = arg as StringBuilder;
            if (stringBuilder != null)
            {
                return stringBuilder;
            }
            return null;
            //انواع تایپ ها و تبدیل ها در زمان کامپایلر مشخص می شود
        }


        public int Foo2<T>(T arg)
        {
            //وقتی ما میخواهیم یک مدل جنریک را به یک ولیو تایپ تبدیل کنیم تبدیل انباکسین هم با ابهام مواجه است
            //بهتر است به آبجکت تبدیل کنیم سپس به یک ولیو تایپ تبدیل اش کنیم

            return (int)(object)arg;
        }
    }


    #endregion


    #region Covariance

    public class CovarianceExample
    {
        class Animal
        {

        }
        class Bear : Animal
        {

        }
        class Camel : Animal
        { }


        class Stack<T>
        {
            int position;
            T[] data = new T[100];

            public void Push(T arg) => data[position++] = arg;

            public T Pop() => data[--position];

        }

        class ZooCleaner
        {
            public static void Wash(Stack<Animal> animals)  //Compailer Time Error
            {
            }

            public static void WashWithoutError<T>(Stack<T> animals) where T : Animal//این خط باعث می شود ما با ابهام کوواریانس مواجه نشویم
            {

            }
        }

        void ExampleMethod()
        {
            Stack<Bear> bears = new Stack<Bear>();
            //Stack<Animal> animals = bears;//این خط خطا میدهد و دلیل خطا هم کوواریانس است

            //animals.Push(new Camel());//تلاش برای ریختن مدل شتر درون مدل پرنده ها

            //ZooCleaner.Wash(bears);//این خط خطا دارد و دلیل خطا هم کوواریانس می باشد 
            //برای رفع ابهام باید یک محدودیت 
            //Parameters Constraint 
            //اضافه کنیم

            ZooCleaner.WashWithoutError(bears);

            //راه حل دیگری هم وجود دارد به نام
            //out Parameters
            //که با کلمه کلیدی
            //out
            //در پارامتر کار می کند
            //این شیوه اولویت ندارد
        }
    }

    #endregion

    #region Contravariance تضاد
    //اگر تبدیل ها به صورت برعکس انجام شود 
    //تضاد رخ می دهد
    #endregion


    #region Chapter 4


    #region Delegates
    //دلیگیت نماینده ای است که یک متد را صدا میزند
    //باید پارامترها و خروجی مانند متدی باشد که فراخوانی می کند

    public class DeletageExample
    {
        //خروجی متد باید اینتیجر باشد و پارامتر هم یک عدد اینت
        delegate int Transformer(int x);

        int Square(int x)
        { return x; }

        void MethodExample()
        {
            //دلیگیت را این گونه به متد بالا متصل کردیم
            Transformer t = Square;

            //فراخوانی بدین شکل است
            //دلیگیت یک اشاره گر یا صدا زننده یک متد است
            int result = t(19);

            //دلیگیت ها متد را در زمان ران تایم صدا میزند

        }

        //یکی دیگر از کاربردهای دلیگیت ها این است که ما بتوانیم یک متد را به عنوان آرگومان به یک متد دیگر پاس بدهیم

        void Trasform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(i);
            }
        }


    }
    #endregion

    #region Instance And Static Method Targets



    public class InstanceAndStaticMethodTargets
    {
        public delegate void progressReporter(int percentComplete);

        class MyReporter
        {
            public string Prefix = "";

            public void ReportProgress(int percentComplete)
            {
                Console.WriteLine(Prefix + percentComplete);
            }
        }

        public void MethodTest()
        {
            MyReporter r = new MyReporter();

            r.Prefix = "%Complete : ";
            progressReporter progress = r.ReportProgress;
            progress(99);

            Console.WriteLine(progress.Target == r);

            Console.WriteLine(progress.Method);
        }



    }

    #endregion


    #region Multicast Delegate 
    public class MultiCastDelegateExample
    {
        //می توان دلیگیت ها را به چندین نوبت مختلف  اجرا کرد
        public delegate void ProgressReporter(int percentComplete);

        class Util
        {
            public static void HardWork(ProgressReporter pr)
            {
                for (int i = 0; i < 10; i++)
                {
                    pr(i * 10);// Invoke Delegate

                    sleep.Sleep(1500); //Simulate Hard Work

                }
            }
        }

        public void Execute()
        {
            ProgressReporter p = WriteProgressToConsole;

            p += WriteProgressToFile;

            Util.HardWork(p);
        }

        void WriteProgressToConsole(int percentComplete)
        {
            WriteLine(percentComplete);
        }

        void WriteProgressToFile(int percentComplete)
        {
            AppendAllText(@"D:\\progress.txt", $"{percentComplete.ToString()}\n");
        }
    }
    #endregion


    #region The Func And Action Delegates
    public class TheFuncAndActionDelegates
    {
        static void Transform<T>(T[] values, Func<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }

        //دو دلیگیت همیشه باهم ناسازگار هستند حتی اگر پارامترها و خروجی آن ها هم یکی باشند
        delegate void D1(int x);
        delegate void D2(int x);
        void Example(int x) { }

        void MethodTest()
        {
            D1 d1 = Example;
            //  D2 d2 = d1; این خط خطا میدهد
            //ولی شکل زیر صحیح است
            D2 d2 = new D2(d1);

            //زمانی که سی شارپ به وجود آمد مقادیر 
            //Func And Action 
            //نبود و بدین دلیل برنامه نویس ها از دلیگیت استفاده می کردند 


        }


        //--------------------------
        //در هنگام فراخوانی یک متد وقتی پارامتر ما از نوع مرجع باشد در هنگام صدا زدن می تواند به صورت ضمنی تغییر کنند
        delegate void StringAction(string s);
        void MethodTest2()
        {
            void ActOnObject(object o) => Console.WriteLine(o);

            StringAction sa = new StringAction(ActOnObject);
            //در اینجا  آبجکت به صورت ضمنی به رشته تبدیل شد
            sa("Hello");
        }





    }
    #endregion


    #region Event
    //event
    //وظیفه اصلی ایونت ها این است که جلوی تداخل دلیگیت ها را بگیرند
    public class EventExample
    {
        public delegate void PriceChangeHandler(decimal oldPrice, decimal newPrice);

        class BroadCaster
        {
            public event PriceChangeHandler PriceChange;

            public void TestMethod()
            {
                PriceChange += BroadCaster_PriceChange;
            }

            private void BroadCaster_PriceChange(decimal oldPrice, decimal newPrice)
            {
                throw new NotImplementedException();
            }
        }


    }

    public class HowDoEventsWorkOnTheInside
    {
        //وقتی ما یک ایونتی را اجرا می کنید 3 اتفاق می افتد

        // PriceChangedHandler priceChanged;  
        // private delegatepublic
        // event PriceChangedHandler PriceChanged
        // {  add    { priceChanged += value; }
        // remove { priceChanged -= value;
        // }}
        //دوتا کلمه کلیدی به اسم
        //Add And Remove اضافه می کند

        //در مرحله سوم کامپایلر می رود و میگردد به تمام رفرنس ها یا فیلد های دلیگیتی که به دلیگیت اصلی رفرنس دارند
    }

    public class PriceChangeExample
    {
        //یک مثال برای اینکه قیمت سهام وقتی تغییر میکند رویداد تغییر قیمت فعال می شود
        string symbol;
        public delegate void PriceChangeHandler(decimal newPrice, decimal lastPrice);
        public PriceChangeExample(string symbol)
        {
            this.symbol = symbol;
        }
        public class Stock
        {
            string symbol;
            decimal price;

            public Stock(string symbol)
            {
                this.symbol = symbol;
            }

            //برای پیاده سازی از 
            //eventHandler 
            //استفاده می کنیم
            public event EventHandler<PriceChangedEventArgs> PriceChanged;

            protected virtual void OnPriceChanged(PriceChangedEventArgs e)
            {
                if(PriceChanged != null)
                {
                    PriceChanged(this, e);
                }
            }

            public decimal Price
            {
                get => price;
                set
                {
                    if (price == value) return;

                    decimal oldPrice = price;
                    price = value;

                   OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
                }
            }

            
        }
        //یک دیزاین پترن مشترک می باشد که در اکثر کتاب خانه های دات نت ایونت ها به این شکل پیاده سازی شده است
        //کاربر بدون تغییر می توانند مدل های خودش را پیاده سازی کند
        //می بایست از یک فضای نام 
        //system.eventArgs
        //استفاده کنیم 
        //متد حتما باید وید باشد

       public class PriceChangedEventArgs:System.EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public PriceChangedEventArgs(decimal newPrice, decimal lastPrice)
            {
                NewPrice = newPrice;
                LastPrice = lastPrice;
            }
        }


       
    }
    #endregion



    #region Action Delegate
    //به یک دلیگیتی که نه پارامتر دارد و نه خروجی یک اکشن گفته می شود

    #endregion

    #endregion

}
