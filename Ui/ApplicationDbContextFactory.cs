using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //اگر بخواهیم در محیط تست و توسعه یک نمونه از دیبی کانکست بسازیم باید از این اینترفیس استفاده کنیم
            //اگر اینکار نکینم خطا میده
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer("Server=localhost, Database=NikamoozDb; User Id=sa; Password= Str0ngPa$$w0rd;");
             ApplicationDbContext ctx = new ApplicationDbContext(optionBuilder.Options);


            return ctx;
        }
    }
}
