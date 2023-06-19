using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigurationSample.ComputedColumn
{
    public class PersonComputedColumn
    {
        //وقتی ما میخواهیم محاسبه ای در ستونی انجام دهیم از این روش استفاده می کنیم

        //توضیح کامل تر این است که می توان ستونی را معرفی کرد که مقدار آن سمت دیتابیس محاسبه شود
        //و اشاره و مقداری که ازش استفاده می کنه ستون های دیگر همان جدول هستند
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

    }

    public class ComputedColumnContext : DbContext
    {

        public DbSet<PersonComputedColumn> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //با این تنظیمات ستون نام کامل به صورت خودکار از مجموع نام کوچک و نام خانوادگی پر می شود
            modelBuilder.Entity<PersonComputedColumn>().Property(e => e.FullName).
                HasComputedColumnSql("FirstName + ' ' + LastName", true);
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "ComputedColumnDB";
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
