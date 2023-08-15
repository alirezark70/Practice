using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DbContextExample
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
    public class DbContextSample : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Sample");
        }
        //دیبیکانتکس نماینده دیتابیس در پروژه و یک نشست در دات نت کور است
        //خود دبی کانتکست ترکیبی از 2 دیزاین پترن 
        //Unit Of Work And Repository
        //می باشد
    }

    public class SampleAndExampleDbContext
    {
        public void ContextIdSample()
        {
            DbContextSample db1 = new();
            DbContextSample db2 = new();


            //برای لاگ زدن از این کانتکس آیدی استفاده می کنیم
            var contextId1 = db1.ContextId;
            var contextId2 = db2.ContextId;
        }
    }


    public class SettingTheEntityState
    {
        private readonly DbContextSample _db;

        public SettingTheEntityState(DbContextSample db)
        {
            _db = db;
        }

        //در اینجا میخواهیم وضعیت نشست را تغییر بدهیم

        public void SetState()
        {
            //در اینجا یک مدل جدید پرسن می سازیم که آیدی این رکورد در دیتابیس وجود دارد
            //آیدی 10 در دیتابیس وجود دارد
            Person person1 = new Person { Id = 10, FirstName = "Alireza", LastName = "Rezaee" };

            //در اینجا وضعیت مدل ما
            //Detached
            //می باشد چون چنج ترکر خبری از این مدل ندارد
            Console.WriteLine(_db.Entry(person1).State);

            //در اینجا وضعیت به 
            //modified 
            //تغییر می کند
            _db.Entry(person1).State = EntityState.Modified;

            //وقتی ذخیره را انجام بدیم کل مدل را در دیتابیس آپدیت می کند
            //چون مدل وجود داره میره و آپدیت می کنه


            //با دستور زیر پروپرتی مذکور از موارد قابل تغییر خارج میشه
            _db.Entry(person1).Property(e => e.FirstName).IsModified = false;
        }

    }


    #region How SaveChanges Find Changes
    //یه متدی به نام Detected Change
    //در چنگ ترکر هستش که وقتی تغییری انجا میشه متد بالا را صدا میزنه
    // معمولا تنظیم می باشد که به صورت اتوماتیک این کار را انجام بده
    //ولی میشه به صورت دستی هم بهش مقدار بدهیم و صداش بزنیم
    public class HowSavechangeFindChanges
    {


        //بعضی وقت ها ما میخواهیم یک مقداری را به صورت دستی به چنگ ترکر بشناسونیم و 
        //فرایند مقایسه انیتی موجود و اسنپ شات اتفاق نیفته
        //برای اینکار ما می توانیم 
        //Auto Detect Change 
        //را غیر فعال بکنیم
        private readonly DbContextSample _db;

        public HowSavechangeFindChanges(DbContextSample db)
        {
            _db = db;
        }

        public void DeActiveDetectedChange()
        {
            _db.ChangeTracker.AutoDetectChangesEnabled = false;

            //حتما باید بعد از انجام کار این مورد را دوباره 
            //ture
            //کنیم
        }
    }

    #endregion


    #region Performance Tuning For Large Number Of Data
    //وقتی های که ما دیتای خیلی زیادی داریم 
    //اگر بخواهیم با فرایند سیو چنج جلو بریم این اتفاق میفته
    //کل دیتای لود شده را اسنپ شات می کنه و در آخر
    //تمام اطالعات را دوباره مقایسه می کنه و موارد تغییر یافته را به حالت مودیفای درمیاره
    //و این فرایند بشدت پرفرمنس را کم می کند
    //برای رفع این مشکل ما باید از 2 اینترفیس استفاده کنیم
    //INotifyPropertyChanged
    //INotifyPropertyChanging
    public class PerformanceTuningForLargeNumberOfDataClass
    {
        //ما از اینترفیس گفته شده در انتینیی ارث بری می کنیم
        // دوتا ایونت داره که ما باید مدیریتش کنیم
       
    }
   public class Teacher : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int id;

        public int Id
        {
            get { return id; }
            set 
            { 
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            { 
                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }


        class DbContextSample:DbContext
        {
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //با استفاده از این کانفیگ فقط زمان اسنپ شات تغییر می کنه و کماکان اسنپ شات گرفته میشه
                //
                modelBuilder.Entity<Teacher>().HasChangeTrackingStrategy
                    (ChangeTrackingStrategy.ChangedNotifications);
            }
        }
    }

    public class Course : INotifyPropertyChanged, INotifyPropertyChanging
    {
        //در این حالت به اصظلاح می گوییم فول نوتیفای
        //یعنی دیگه اسنپ شاتی گرفته نمیشه و تمام این استراتژی دستی انجام میشه
        public event PropertyChangingEventHandler? PropertyChanging;
        public event PropertyChangedEventHandler? PropertyChanged;

        private int id;

        public int Id
        {
            get { return id; }
            set 
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Id)));
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }


        private string name;

        public string Name
        {
            get { return Name; }
            set 
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Name)));
                Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }


        class DbContextSample:DbContext
        {
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //با این روش ما دیگه نمیزاریم اسنپ شاتی گرفته بشه و در هر تغییر
                //یک ایونتی ریز میشه
                //این راه کار از نظر معماری مشکلاتی داره که 
                //دامین مدلمون درگیر زیر ساخت میشه
                modelBuilder.Entity<Course>()
                    .HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);
            }
        }
    }
    #endregion
}
