using Ef.RealationConfigurationSample.TablePerHierarchy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.TablePerType
{

    public class TablePerTypeSample
    {
        
        
        //Table Per Type
        // در این روش فیلد های مشترک در یک جدول قرارداده میشوند 
        //فیلد های متفاوت در جدول های جداگانه نگه داری می شوند
    }

    public class PersonTPT
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

 
    }

    public class GetSampleQuery
    {
        public void GetSample()
        {
            //برای خوندان این مدل کوئری به روش زیر استفاده می کنیم
            var context= new SampleTPTContext();

            var people=context.Persons.ToList();

            var student=people.OfType<StudentTPT>().ToList();

            var teacher=people.OfType<TeacherTPT>().ToList();
            
        }
    }

    public class StudentTPT : PersonTPT
    {
        public string StudentNumber { get; set; }
    }

    public class TeacherTPT : PersonTPT
    {
        public string TeacherNumber { get; set; }
    }

    public class SampleTPTContext : DbContext
    {
        public DbSet<PersonTPT> Persons { get; set; }

        //public DbSet<StudentTPT> Students { get; set; }

        //public DbSet<TeacherTPT> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //با این روش پیاده سازی می شود 
            // بدی این روش این است که جوین های زیادی زده می شود
            //مزیت های بیشتری این روش دارد و یکیش اینه که دقیقا ساختار کد ما در دیتابیس ساخته می شود
            modelBuilder.Entity<TeacherTPT>().ToTable(nameof(TeacherTPT));
            modelBuilder.Entity<StudentTPT>().ToTable(nameof(StudentTPT));
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "TPTDB";
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
