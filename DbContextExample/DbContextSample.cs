using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class DbContextSample:DbContext
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
}
