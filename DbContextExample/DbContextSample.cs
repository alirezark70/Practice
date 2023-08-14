using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
