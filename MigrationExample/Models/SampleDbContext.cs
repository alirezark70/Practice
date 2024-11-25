using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationExample.Models
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=TestDb; Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //با این روش می تونیم قسمتی از مدل ها رو از ماگرایشن 
            //excelud 
            //کنیم
            modelBuilder.Entity<JuridicalPerson>().ToTable(nameof(JuridicalPerson),e=> e.ExcludeFromMigrations());
        }
        //ما می توانیم با دستور Script-Migration
        //کوئری ساخت مهاجرت را بسازیم و دیتابیس اجراش کنیم


        //مای می تونیم با کمک bundle-migration 
        // یک فایل اکسه بسازیم برای استفاده در 
        //ci/cd
        //دستور برای ایجاد باندل در کامند لاین
        //dotnet ef migrations bundle
    }
}
