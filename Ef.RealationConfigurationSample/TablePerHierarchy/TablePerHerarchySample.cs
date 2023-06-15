using Ef.RealationConfigurationSample.Models;
using Ef.RealationConfigurationSample.OwnedTypeSample;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.TablePerHierarchy
{
    public class TablePerHerarchySample
    {
        // Table Per Herarchy Or TPH
        //همه مدل های در دیتابیس یک جدول گرفته می شود و با 
        //[Discriminator]
        //قابل تفکیک از هم می باشد
        //در مواردی که مدل های فرزند فیلد های متفاوت بسیاری داشته باشند این ویژگی مناسب نیست
    }

    public class PersonTPH
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

    public class Student : PersonTPH
    {
        public string StudentNumber { get; set; }
    }

    public class Teacher:PersonTPH
    {
        public string TeacherNumber { get; set; }
    }

    public class SampleContext : DbContext
    {
        public DbSet<PersonTPH> Person { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonTPH>(c =>
            {
                //با این کافنیگ می شود 
                //thp
                //را تغییرات داد
                c.HasDiscriminator<int>("PersonType").HasValue<PersonTPH>(1).HasValue<Student>(2).HasValue<Teacher>(3);
            });
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "TPHDB";
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
