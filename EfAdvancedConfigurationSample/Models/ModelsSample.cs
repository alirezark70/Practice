using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigurationSample.Models
{

    //ساخت فانشن سمت دیتابیس و فراخوانی در پروژه و کد ما
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int? Rating { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
    }

    public class SampleUdfContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MakeConnectionString.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)
                .WithOne(p => p.Blog);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post);

            modelBuilder.HasDbFunction(typeof(SampleUdfContext).GetMethod(nameof(ActivePostCountForBlog), new[] { typeof(int) }))
            .HasName("CommentedPostCountForBlog");

            //hasName
            //اشاره به فانشنی است که سمت دیتابیس ساخته ایم
        }

        //این متد را میسازیم برای اینکه فانش را صدا بزنه ولی در بدنه هیچی نمی نویسسیم و میریم در کانفیگ تنظیماتی انجام میدهیم
        public int ActivePostCountForBlog(int blogId)
            => throw new NotSupportedException();
    }

    public class QueryUdf
    {
        SampleUdfContext context = new();

        public int GetCountComment(int blogId)
        {
            var count = context.ActivePostCountForBlog(blogId);

            return count;
        }
    }
    public static class MakeConnectionString
    {
        public static string ConnectionString()
        {
            var connection = new SqlConnectionStringBuilder();
            connection.InitialCatalog = "UdfDB";
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
