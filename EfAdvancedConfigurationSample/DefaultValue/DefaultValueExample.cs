using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigurationSample.DefaultValue
{
    public class PersonDefaultValue
    {
        DefaultValueContext context;
        public PersonDefaultValue()
        {
           context = new DefaultValueContext();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime RegisterDate { get; set; }

        public int Age { get; set; }

        public void Add()
        {
            context.Add(this);
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

    public class DefaultValueContext : DbContext
    {

        public DbSet<PersonDefaultValue> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //اگر فیلد مورد نظر خالی باشد مقدار پیش فرض داخل ستون قرار داده می شود
            modelBuilder.Entity<PersonDefaultValue>().Property(e => e.Age).HasDefaultValue(18);

            //این فرقش اینه که سمت دیتابیس مقدار داده می شود 
            //الان تابع تاریخ و ساعت جاری در فیلد در صورت نال بودن قرار داده می شود
            modelBuilder.Entity<PersonDefaultValue>().Property(e => e.RegisterDate).HasDefaultValueSql("getdate()");
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "DefaultValueDB";
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
