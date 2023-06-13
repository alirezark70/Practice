// See https://aka.ms/new-console-template for more information

using DataLayer;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionBuilder.UseSqlServer("Server=localhost, Database=NikamoozDb; User Id=sa; Password= Str0ngPa$$w0rd;");
using ApplicationDbContext ctx = new ApplicationDbContext(optionBuilder.Options);

//ctx.FirstOrDefault();
