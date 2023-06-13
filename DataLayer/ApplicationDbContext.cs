using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationDbContext:DbContext
    {
        #region Prop
        public DbSet<Course> courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<CourseTeachers> CourseTeachers { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; } 
        #endregion


        #region Db Context Constoructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion


        #region OnConfiguration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        } 
        #endregion
    }
}