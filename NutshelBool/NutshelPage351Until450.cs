using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NutshelBooK
{
    internal class NutshelPage351Until450
    {
    }


    #region The ICollection And IList Interface
    //شمارشگرهای 
    //IEnumerable And IEnumerator
    //فقط شمارشگر رو به جلو هستند و امکانات زیر را ارائه نمی دهند
    //امکان اندازه گیری تعداد کالکشن
    //امکان کار  و دسترسی بر روی ایندکس معین
    //امکان جستجو در کالکشن

    //بهترین کالکشن های در نظر گرفته شده برای کار بر روی ایندکس و ...
    //ICollection and IList and IDictionary


    //IList<T>
    //بهتر و کاربردی تر از 
    //ICollection
    //می باشد


    #endregion



    #region IList<T> and IList
    public class IListTAndIListClass
    {

    }

    #endregion


    #region Array Class
    //آرایه یک رفرنس تایپ می باشد که از قوانین رفرنس تایپ ها هم پیروی می کند
    //یعنی دو مقدار شبیه هم باهم برابر نیستند چن رفرنس های مرجع متفاوتی دارند

    public class ArrayClass
    {
        void TestArray()
        {
            var arrayList = Array.CreateInstance(typeof(string), 3);

            arrayList.SetValue("Alireza", 0);


            string[] s1 = (string[])arrayList;

        }
    }




    #endregion


    #region Length and Rank
    //لنت طول یک آرایه را برمیگرداند
    //رنک rank تعداد بعدهای یک آرایه را برمیگرداند
    #endregion




    #region Searching
    public class SearchingArrayClass
    {
        public void Prossess()
        {
            string[] names = { "Alireza", "Soo", "Mohammad", "Ali" };

            string match = Array.Find(names, n => n.Contains('a'));
        }


    }

    #endregion


    #region Predicate<T>
    public class PredicateClass
    {
        //پردیکیت هم یک نوع دلیکیت و اکشن است
        //یک ورودی می گیرد و یک خروجی از نوع 
        //bool
        //برمیگرداند

        private Predicate<string>? checkContains;

        public static bool Containsaaaa(string input)
        {
            return input.Contains("a");
        }


        public void ExampleMethod()
        {
            checkContains = Containsaaaa;

            string[] names = { "Alireza", "Soo", "Mohammad", "Ali" };

            string match = Array.Find(names, checkContains);
        }
    }
    #endregion


    #region Collection - Copying
    public class CopyingClass
    {
        //ما 4 نوع کپی داریم
        //clone
        public void CloneExample()
        {
            int[] arr = { 1, 2, };

            //اگر ما از کلون استفاده کنیم یک مقدار جدید ایجاد می شود
            var copyArr = arr.Clone();
        }


        public void CopyAndCopyToExample()
        {
            //copyto and copy
            //یک کپی از زیر مجموعه پیوسته از آرایه ایجاد می کند

            int[] arr = { 1, 2, };

            arr.CopyTo(arr, 0);
        }
    }
    #endregion


    #region Converting And Resizing
    public class ConvertingAndResizing
    {
        //متد کانورت یه شکل زیر می باشد
        //public delegate TOutput Converter<TInput,TOutput> (TInput input)

        public void ExampleMethod()
        {
            float[] arr = { 1.2f, 2.1f, 3.9f };

            int[] result = Array.ConvertAll(arr, r => Convert.ToInt32(r));
            //result is {1,2,4}
        }
    }
    #endregion


    #region List<T> and ArrayList

    public class ListTAndArrayList
    {
        //List<T>
        //بین برنامه نویسان استفاده بیشتری دارد
        //لیست یک آرایه به اندازه ورودی ایجاد می کند و با پر شدن با یک لیست جدید جایگزین می شود
        //در هربار که فضای جدید ایجاد می شود المان ها در لیست جابجا می شود و این می تواند عملیات ادد را
        //کمی کند تر از آرایه بکند


        //یک List<T>
        //می تواند سریع تر از آرایه باشد
        //اگر موجودیت T
        //یک value type باشد


        public void ListMethodExample()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            //میشه تو متد ریمو آل از پریدیکیت استفاده کرد تا آیتم های مورد نظر حذف گردند
            list.RemoveAll(x => x == 1);

            list.Reverse();

            //تفاوت ادد با اینترست در این است که 
            //در ادد یک مقدار به آخر آرایه اضافه می شود ولی در اینتسرت می توان
            //ایندکس خانه ای که باید اطلاعات داخلش برود هم می توانیم بدیهیم

            list.Insert(0, 2);

            list.Add(3);
        }
    }
    #endregion


    #region LinkedList
    public class LindedListClass
    {
        //لیست ها یک آیتم رو به جلو دارند ولی
        //لینکدلیست با 2 آیتم کار می کند
        //روبه جلو و رو به عقب

        public void ListMethodExample()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddAfter(list.First, 11);

            //میشه یه مقدار را قبل یا بعد یک آیتم اضافه کرد
        }
    }
    #endregion


    #region Queue<T> and Queue

    public class QueueClass
    {
        //queue is first in first out (Fifo)
        //یعنی اولی که اومده اولین خارج میشه


        //لیست queue
        //لیست ها را پیاده سازی نمی کند و نمیشود آنها را به لیست تبدیل کرد چون
        //از طریق ایندکس نمی شود به اعضا آن دسترسی داشت
        //فقط با تبدیل کردن به آرایه می شود به صورت تصادفی به عضای آن دسترسی پیدا کرد

        public void QueueExample()
        {
            Queue<string> queue = new Queue<string>();
            //برای ایجاد صف و وارد کردن آیتنم از enqueue 
            //استفاده می کنیم
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Enqueue("three");
            queue.Enqueue("four");
            queue.Enqueue("five");

            //یک کپی از صف را به یک آرایه تبدیل می کند
            string[] copyQueue = queue.ToArray();


            //foreach (var item in queue)
            //{
            //    //یک صف را می شود شمارش کرد
            //    Console.WriteLine(item);
            //}

            //enqueue
            //یک ایتم جدید به آخر لیست اضافه می کند

            //dequeue
            //قدیمی ترین آیتم را از لیست خذف می کند/یعنی اولیترین آیتم را حذف می کند


            //peek
            //اولین ایتم لیست را برمیگرداند


            string dequeue=queue.Dequeue();

            string peek=queue.Peek(); //return one

            //این متد مقداری که پک شده است را از صف خارج می کند
            queue.Dequeue();

            string peek2 = queue.Peek();//return two

            queue.Dequeue();
            string peek3 = queue.Peek();//return three

            //
            queue.Enqueue("six");

        }
    }
    #endregion


    #region Stack<T> and Stack
    //Stack<T> and Stack are last-in, first-out (LIFO) data structures,

    #region Stack<T>
    public class StackTClass
    {
        //push
        //برای وارد کردن مقدار به یک صف 

        //pop
        //برای خارج کردن آخرین ورودی از صف استفاده می شود

        //Peek
        //برای مشاهده ایتم بعدی استفاده می شود



    }
    #endregion

    #endregion


    #region BitArray
    public class BitArrayClass
    {
        //یک ارایه از مقادیر 
        //bool
        //نگه داری می کند
        //اگر ما یک لیست از بول بخواهیم استفاده از این مورد بهتر است چون 
        //یک لیست از بول در هرخانه یک بایت حافظه نیاز دارد
        //ولی برای بیت آرای برای هر خانه یک بیت نیاز مورد استفاده قرار می گیرد

        public void BitArrayMethodExample()
        {
            var bits = new BitArray(3);
            
        }
    }
    #endregion


    #region HashSet<T> and SortedSet<T>
    public class HashSetTandSortedTClass
    {
        //در متد های این ها جستجو بر اساس هش انجام می شود
        //آنها موارد تکراری را ذخیره نمی کنند و بدون صدا درخواست برای اد موارد تکراری را نادیده می گیرند
        //بر اساس موقعیت به المان دسترسی نداریم

        //sorted<T>
        //به صورت پیش فرض المان ها را مرتب نگه داری می کند

        //hashSet<T>
        //در حالیکه لیست بالا به صورت پیش فرض المان ها را مرتب نگه داری نمی کند
        //---

        //وجه اشتراک این دو لیست این است که اینترفیس زیر را پیاده سازی کردند
        //ISet<T>


        public void HashsetTest()
        {
            HashSet<char> letters = new HashSet<char> ("the quick brown fox");
            //در سازنده توانست لیستی از چار بگیرد چون
            //ienumerable<char>
            //پیاده سازی کرده است

            bool r1 = letters.Contains('t');//true

            bool r2 = letters.Contains('j');//false

            foreach (char c in letters)
            {
                Console.Write(c);//the quickbrownfx
                //موارد تکراری وارد لیست نشده اند
                //به عنوان مثال اسپیس های اضافه وارد لیست نشده اند
            }
        }

        public void SortedTest()
        {
            var letters = new SortedSet<char>("the quick brown fox");
            foreach (char c in letters) Console.Write(c);   //  bcefhiknoqrtuwx
        }

    }
    #endregion



    #region ReadonlyCollection<T>
    public class ReadonlyCollectionT
    {
        //ساخت یک کلاس و یک مجوموعه که کاملا به صورت داخلی قابلیت اضافه و آپدیت داره
        //کاملا
        //immiutable می باشد
        List<string> names = new List<string>();

        public IReadOnlyCollection<string> Names { get; private set; }

        public ReadonlyCollectionT()
        {
            Names = new ReadOnlyCollection<string>(names);
        }

        public void AddInternally() => names.Add("Test");

    }
    #endregion

    #region Innutable Collections
    public class ImmutableCollectionClass
    {
        //مجموعه تغییر پذیر برای اپلیکیشن خوب هستند و جلو بروز تغییرات و خطاهای را میگیرند
        //مشکلات تغییر حالت را از بین میبرند
        //موازی سازی و چند رشته ای را آسان می کنند
        //استدلال کد را آسان تر می کنند


        //مجموعه های تغییر ناپذیر را اگر بخواهیم تغییر بدیم 
        //یک لیست جدید ایجاد میشه و لیست قبلی غیر قابل تغییر می ماند


        //مجموعه های تغییر ناپذیر برای خواندن و نوشتن کندتر از مجموعه های تغییر پذیر هستند

        public void Method1()
        {
            var oldList = ImmutableList.Create<int>(1, 2, 3, 4);

            //در این جا یک لیست جدید ایجاد میشه و قبلیه تغییر نمی کنه
            var newList = oldList.Add(5);
        }

        public void Method2()
        {
            var oldList =new List<int>() { 1,2,3,4};

            //در اینجا نمی شود مثل بالا کار کرد چون خطای کامپایلر تایم میدهد
            //var newList = oldList.Add(5);


        }
    }
    #endregion
}
