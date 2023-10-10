using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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


            string dequeue = queue.Dequeue();

            string peek = queue.Peek(); //return one

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
            HashSet<char> letters = new HashSet<char>("the quick brown fox");
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
            var oldList = new List<int>() { 1, 2, 3, 4 };

            //در اینجا نمی شود مثل بالا کار کرد چون خطای کامپایلر تایم میدهد
            //var newList = oldList.Add(5);


        }
    }
    #endregion



    #region Equality Comparer

    public class CustomerClass
    {
        //بعضی وقت ها ما میخواهیم نام و نام خانوادگی را چک کنیم که برابر باشد
        //برای اینکار یک کلاس میسازیم که این کار را برای ما انجام دهد

        public CustomerClass(string firstname, string lastname)
        {
            Id = new Random().Next();
            Firstname = firstname; Lastname = lastname;
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

    }

    public class EqualFullName : EqualityComparer<CustomerClass>
    {
        public override bool Equals(CustomerClass? x, CustomerClass? y)
        {
            return (x?.Firstname == y?.Firstname) && (x?.Lastname == y?.Lastname);
        }

        public override int GetHashCode([DisallowNull] CustomerClass obj)
        {
            return (obj.Lastname + ";" + obj.Firstname).GetHashCode();
        }
    }

    #endregion


    #region Query Syntax Versus Sql Syntax
    public class QuerySyntaxVersusSqlSyntax
    {
        //کوئری های لینک شبیه کوئری های اس کیو ال هستند اما 2 تفاوت اصلی دارند
        //کوئری لینک به یک عبارت سی شارپ خلاصه می شود
        //کوئری لینک از قوانین سی شارپ پیروی می کند
    }
    #endregion


    #region Deferred Execution
    public class DeferredExecutionClass
    {
        public void Excute()
        {
            List<int> numbers = new List<int> { 1 };

            IEnumerable<int> query = numbers.Select(i => i * 10);
            //Console.WriteLine(query);

            //در اینجا یک مقدار دزدی وارد کردیم 
            numbers.Add(20);

            foreach (var item in query)//در این قسمت وقتی اجرا میشه کوئری کامل اجرا میشه 
                                       //داخل این عبارت مقداری که به صورت دزدی وارد کردیم هم وجود دارد
            {
                Console.Write(item + "|");
            }
        }

        public void ExcuteTwo()
        {
            List<int> numbers = new List<int> { 1 };

            IEnumerable<int> query = numbers.Select(i => i * 10);
            //در برخی موارد تاخیر در اجرا باعث مشکل می شود
            numbers.Add(20);

            foreach (var item in query)

            {
                Console.Write(item + "|");
            }

            numbers.Clear();
            //این باعث میشه لیست کوئری هم داخلش پاک بشه با اینکه لوپ باعث اجرای کوئری شده بود


            //برای رفع این مشکل باید از 
            //.Tolist
            //استفاده کنیم چون مقدار را درون یک لیست دیگه میریزه
            //یا
            //ToArray


        }
    }
    #endregion


    #region SubQueries
    public class SubQueriesClass
    {


        public void Execute()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            int subQuery = names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First();

            IEnumerable<string> outerQuery =
                names.Where(n => n.Length == 3);
        }
    }
    #endregion


    #region SubQueries And Deferred Execution
    public class SubqueriesAndDeferredExectutionClass
    {
        List<string> names = new List<string> { "Alireza", "Sommaye", "Namser", "Abbas", "Saeed" };
        public void Execute()
        {
            //وقتی ما یک ساب کوئری داریم
            //وقتی ساب کوئری ما یک فرایند اجرا دارد بع عنوان مثال
            //first or Count or ...
            //کوئری اصلی ما اجرا نمیشه و روی اجرای کوئری اصلی تاثیر نمیزاره

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

            //متد کانت که در حالت معمولی باعث اجرای عملیات میشد در اینجا چون در ساب کوئری استفاده شده
            //باعث اجرای کوئری اصلی نمیشود
            var result = numbers.Where(e => e > numbers.Count);
        }



    }
    #endregion



    #region Progressive Query Building
    public class ProgressiveQueryBuildingClass
    {
        List<string> names = new List<string> { "Alireza", "Sommaye", "Namser", "Abbas", "Saeed" };
        public void Execute()
        {
            //کوئری های پیش رونده 
            //در هر مرحله یک کوئری ایجاد میشود ولی هنوز کوئری اجرا نشده 
            var result = names.Select(e => Regex.Replace(e, "[aeiou]", ""));
            result = result.Where(a => a.Length > 5);



        }
    }
    #endregion

    #region Project Strategies
    public class ProjectStrategiesClass
    {
        class TempProjectionItem
        {
            public string Original;
            public string Vowelless;

        }

        public void Execute()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            //ما میخواهیم وقتی که حروف صدا دار را حذف می کنیم مقدار اصلی را هم در یک پروپرتی دیگه نگه داریم
            IEnumerable<TempProjectionItem> temp = from n in names
                                                   select new TempProjectionItem { Original = n, Vowelless = Regex.Replace(n, "[aeiou]", "") };


            IEnumerable<TempProjectionItem> temp2
                = names.Select(n => new TempProjectionItem { Original = n, Vowelless = Regex.Replace(n, "[aeiou]", "") });


        }
    }
    #endregion


    #region Interpreted Queries
    public class InterpretedQueriesClass
    {
        //کوئری های لینک بر مبنای 2 معماری موازی کار می کنند
        //کوئری های محلی که بر روی 
        //IEnumerable and value type or reference type
        //زده می شوند


        ///پرس و جوی های تفسیر شده بریا منابع داده از راه دور مثل
        ///sql server or something
        ///خصوصیت کوئری های تفسیر شده این است که در زمان اجرا تفسیر می شوند
        ///و این قابلیت اجرا می دهد که ما از پایگاه داده مانند
        ///sql server 
        ///استفاده کنیم
    }
    #endregion


    #region Combining Interpreted and Local Queries
    public class CombiningInterpretedAndLocalQueriesClass
    {
      //AsEnumerable
      //یک کوئری که مفسری است را به یک کوئری محلی تبدیل می کند

      
        ///asQuerable
        ///یک کوئری که محلی است را به یک کوئری مفصری تبدیل می کند


        //بعضیی وقتا امکانش هست که یک کوئری که میخواهیم بنویسیم از یک کلاس سی شارپی استفاده کنیم که از کلاس های سی شارپی 
        //استفاده می کنه که در دیتابیس پشتی بانی نمیشه
        //برای اینکارباید به شکل زیر عمل کنیم
        public void Execute()
        {
            List<CustomerClass> customers = new List<CustomerClass>();
            Regex wordCounter = new Regex(@"\b(\w[-'])+\b");

            IQueryable<CustomerClass> query = customers.Where(e=>e.Id>100).AsQueryable();//یک کوئری نوشتیم و تبدیلش کردیه به یک کوئری مفصری

            //ولی نیمشه از کلاس 
            //regex
            //استفاده کرد برای اینکار بدین صورت عمل می کنیم

            var customerClasses = query.AsEnumerable();


            customerClasses = customerClasses.Where(c => wordCounter.Match(c.Firstname).Length > 10);
            ///متد های زیر 
            ///ToList ToArray
            ///هم همین کار را می کنند
            ///ولی مزیتی که 
            ///AsEnumarable 
            ///داره اینه که کوئری را در لحظه اجرا نمی کنه
        }
    }


    #endregion



    #region Loading Related Data

    public class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        public int MyProperty { get; set; }
    }

    public class EagerLoadingClass
    {
        ///لود کردن زود هنگام یعنی در زمان نوشتن کوئری نوشته میشه و در کوئریه اولیه برای استفاده مستقیم از دیتابیس برمیگرده
        ///یکی از میزیت یا عیوب این بارگزاری این است که فقط یک درخواست سمت دیتابیس می رود
        ///یعنی همی میتواند مفید باشد که تعداد درخواست را کاهش دهد 
        ///هم می تواند یک ضرب دکارتی را بوجود بیاورد و یک لوپ دیتا ایجاد شود
        ///single query and split query
       
    }

    public class ExplicitLoadingClass
    {
        
        ///این بدین صورت است که در کوئری ثانویه به صورت صریح لود می شود
        ///

        public void Execute()
        {
            var db = new TestContext();

            var person= db.People.FirstOrDefault();

            //یکی از فواید این طرح این است که می توان بدون اینکه هیچ اطلاعاتی سمت مموری بیاد یک کوئری سمت سرور اجرا کنیم

           // var postCount=db.Entry(person).Collection(e=>e.Children).Query().Count();
        }

    }
    ///https://learn.microsoft.com/en-us/ef/core/querying/related-data/
    ///https://learn.microsoft.com/en-us/ef/core/querying/single-split-queries

    #endregion


    #region Deletates Versus Expression Trees
    public class CustomerClassDVET
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

    }

    public class DeletatesVersusExpressionTreesClass
    {
        List<CustomerClassDVET> customers=new List<CustomerClassDVET>();
         IQueryable<CustomerClassDVET> customers2 = null;
        public void Execute()
        {
            //برای کوئری های محلی از دلیگیت ها استفاده می کنیم
            Func<CustomerClassDVET, bool> hasDisoucntLocal = p => p.Discount is 0;
            IEnumerable<CustomerClassDVET> queryLocal=customers.Where(hasDisoucntLocal);


            //برای کوئری های که سمت دیتابیس هستند هم از روش زیر اسفتاده می کنیم

            Expression<Func<CustomerClassDVET, bool>> pridicate = c => c.Discount == 0;
            IQueryable<CustomerClassDVET> query2 = customers2.Where(pridicate);




        }
    }

    #endregion


    #region Compiling Expression Trees
    public class CompilingExpressionTreesClass
    {
        //compile()
        //ویژگی است که ما می توانیم یک ویژگی درختی را به یک نماینده یا دلیگیت تبدیل کنیم
        IQueryable<ProductCompilingExpressionTreesClass> products = null;

        void Execute()
        {
            
           // var varaiableDelegate=products.
        }
    }
    public class ProductCompilingExpressionTreesClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

        public DateTime LastSale { get; set; }

        public static Expression<Func<ProductCompilingExpressionTreesClass, bool>> IsSelling()
        {
            return e => e.LastSale > DateTime.Now.AddDays(30);
        }


        void Execute2()
        {
            ///بیس کلاس 
            ///lambdaExpression 
            ///کلاس پایه برای 
            ///expression<T>
            ///می باشد
            ///
            var queryValue = new ProductCompilingExpressionTreesClass();

            Func<ProductCompilingExpressionTreesClass, bool> expression=e=>e.Price>1000;
            var result=expression.Invoke(queryValue);

            LambdaExpersions lambdaExpersions;
        }


         
    }




    #endregion


    #region The Expression DOM
    public class TheExpressionDOM
    {
        public void ExecuteCreateExpression()
        {
            //ما میخواهیم یک 
            //expression Tree
            //بسازیم و برای اینکار باید از پایین ترین مرحله شروع به ساخت کنیم
            //برای اولین مرحله ما باید پارامترهای را پیاده سازی کنیم
            ParameterExpression param = Expression.Parameter(typeof(string), "S");

            //دومین مرحله ایجاد اعضای اکسپریشن است
            MemberExpression stringLength = Expression.Property(param, "Length");

            //در بالا مورد طول شو تعریف کردیم
            //در پایین ما طول را مشخص می کنیم
            ConstantExpression five = Expression.Constant(5);

            //در خط پایین مقایسه را تعریف کردیم
            BinaryExpression comparison = Expression.LessThan(stringLength, five);

            //در مرحله آخر ساخت یک کوئری لامدا می باشد
            Expression<Func<string,bool>> lambda=
                Expression.Lambda<Func<string,bool>>(comparison, param);

            //در بالا ما یک مقایسه سمت سروری ساختیم 

            Func<string,bool> localyQuery=lambda.Compile();
            //در خط بالا ما کوئری را به حالت لوکالی تبدیل کردیم

           bool result= localyQuery("Alireza");

        }
        

    }
    #endregion
}