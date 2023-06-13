using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SampleEfConfiguration.FluentConfig;
using SampleEfConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEfConfiguration.Context
{
    public class ExampleDbContext:DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<ShadowPropertyEntity> ShadowPropertyEntites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //با استفاده از روش زیر تنظیمات که ایجاد کردم رو به مدل بیلدر شناسایی می کنم
            modelBuilder.ApplyConfiguration(new PeopleConfig());
            modelBuilder.ApplyConfiguration(new CompositKeyConfig());
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //با این روش ساده می تونیم بر روی کل مدل ها شرط کلی بگذاریم
            //این ویژگی از دات نت 6 اضافه شده است
            configurationBuilder.Properties<string>().HaveMaxLength(200);

           // base.ConfigureConventions(configurationBuilder);
        }

    }

    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "ConfigSampleDB";
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
