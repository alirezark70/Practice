using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigurationSample.ConCurrency
{
    //ما برای مدیریت همزمانی سمت کد دات نت 2 مدل پیاده سازی داریم که برای شریط های متفاوت بهتر است استفاده شوند
    //ConCurrency Token
    //TimeStamp

    //Concurrency Token
    //زمانی که یک فیلد برای ما مهم باشد از این استفاده می کنیم 


    //TimeStamp
    //وقتی کد ردیف برای مهم باشد از این روش استفاده می کنیم

    public class PersonConCurrency
    {
       

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

       
    }

    public class ProductConCurrency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }

    public class ConCurrencyContext : DbContext
    {

        public DbSet<PersonConCurrency> People { get; set; }

        public DbSet<ProductConCurrency> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //در این جا از 
            //ConCurrencyToken 
            //استفاده کرده ایم و وقتی میخواد آپدیت را انجام بده یا اینسرت میاد و مقداری که 
            // در زمانی واکشی را با لحظه ثبت چک می کنه و اگر تغییری کرده بود جلوی فرایند گرفته می شود
            modelBuilder.Entity<PersonConCurrency>().Property(e=>e.FirstName).IsConcurrencyToken();

            //با این کار کل ردیف مهم می شود و همه ستون ها تغییراتش چک می شود
            modelBuilder.Entity<ProductConCurrency>().Property(c=>c.RowVersion).IsConcurrencyToken();
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "ConCurrencyDB";
            connection.DataSource = ".";
            connection.Encrypt = true;
            connection.CommandTimeout = 200;
            connection.TrustServerCertificate = true;
            connection.UserID = "sa";
            connection.Password = "00@alireza";

            return connection.ConnectionString;
        }
    }
}
