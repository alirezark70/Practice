using Ef.RealationConfigurationSample.Models;
using Ef.RealationConfigurationSample.OwnedTypeSample;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample
{
    //public class SampleContext : DbContext
    //{
    //    public DbSet<Person> Person { get; set; }

    //    public DbSet<Address> Addresses { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {

    //        optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
            


    //        modelBuilder.ApplyConfiguration(new OneToOneConfig());
    //        modelBuilder.ApplyConfiguration(new OneToManyConfig());
    //        modelBuilder.ApplyConfiguration(new OwnerTypeConfig());
    //        modelBuilder.ApplyConfiguration(new OtherConfig());
    //        //رابطه چند به چند
    //        modelBuilder.Entity<ProductAndTagRelationShip>().HasKey(src => new { src.ProductId, src.TagId });


    //    }
    //}
    //public static class MakeConnectionString
    //{
    //    public static string ConnectionString()
    //    {
    //        var connection = new SqlConnectionStringBuilder();
    //        connection.InitialCatalog = "ConfigSampleDB";
    //        connection.DataSource = ".";
    //        connection.Encrypt = true;
    //        connection.CommandTimeout = 200;
    //        connection.TrustServerCertificate = true;
    //        connection.UserID = "sa";
    //        connection.Password = "00@alireza";

    //        return connection.ConnectionString;
    //    }
    //}
}
