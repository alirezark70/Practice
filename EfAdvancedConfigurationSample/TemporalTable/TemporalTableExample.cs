using EfAdvancedConfigurationSample.ConCurrency;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigurationSample.TemporalTable
{
    internal class TemporalTableExample
    {
        //با استفاده از ef core
        //می توانیم تاریخچه تغییرات را ثبت و بازخوانی کنیم


    }

    public class PersonTemporalTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

    public class PersonRepository
    {
        TemporalTableContext ctx = new TemporalTableContext();


        public void GetHistory()
        {
            var result = ctx.People.TemporalAll();
        }

        public void GetWithTimeHistory()
        {
            var result = ctx.People.TemporalBetween(DateTime.Now, DateTime.Now.AddMonths(3));
        }
    }

    public class TemporalTableContext : DbContext
    {

        public DbSet<PersonTemporalTable> People { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonTemporalTable>().ToTable(c =>
            {
                //با این روش یک جدول جدا از جدول اصلی ساخته می شود که تغییرات در آن نگه داری می شود
                c.IsTemporal();
            });
        }

    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "TemporalTableDB";
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
