using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSession20.Entities
{
    public class Employee
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? ParentId { get; set; }

        public Employee Parent { get; set; }

        public List<Employee> Children { get; set; }

    }

    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }
    }

    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "NikEfDB";
            connection.DataSource = ".";
            connection.Encrypt = true;
            connection.CommandTimeout = 200;
            connection.UserID = "sa";
            connection.Password = "Str0ngPa$$w0rd";
            connection.TrustServerCertificate = true;

            return connection.ConnectionString;
        }
    }
}
