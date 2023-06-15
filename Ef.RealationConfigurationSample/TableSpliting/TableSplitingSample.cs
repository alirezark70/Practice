using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.TableSpliting
{
    public class TableSplitingSample
    {
        //زمان های وجود دارد که ما همیشه اطلاعات کل جدول را نمی خواهیم و فقط اکثر وقت ها فیلد های مشخصی میخواهیم
        //در این حالت یک 2 تا جدول سمت کد داریم ولی ما به ازای این یک جدول سمت دیتابیس ایجاد می شود
        // در ظاهر یک رابطه یک به یک است ولی اینطوری نیست 

        public void GetTableSpliting()
        {
            var contex = new SampleTableSplitingContext();

            //با کوئری زیر فقط اطلاعات جدول اولی میاد و جدول دوم دیتیل برای ما نمیاد
            var news=contex.NewsTableS.ToList();

            //با کوئری زیر اطلاعات فرزند را هم میاریم
            var newsIncludeNewsDetails = contex.NewsTableS.Include(c => c.NewsDetailTableS);
        }
    }

    public class NewsTableS
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string Body { get; set; }

        public NewsDetailTableS? NewsDetailTableS { get; set; }
    }

    public class NewsDetailTableS
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Body { get; set; }
    }

    public class SampleTableSplitingContext : DbContext
    {

        public DbSet<NewsTableS> NewsTableS { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //این کافنیگ نیاز است برای انجام 
            //table spliting
            modelBuilder.Entity<NewsTableS>(c =>
            {
                c.HasOne(c => c.NewsDetailTableS).WithOne().HasForeignKey<NewsDetailTableS>(c=>c.Id);
            });

            modelBuilder.Entity<NewsDetailTableS>().ToTable(nameof(NewsTableS));
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "TableSplitingDB";
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
