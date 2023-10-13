using lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace lab2.Data
{
    public class StudentDb:DbContext
    {
        public StudentDb(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3FTMPVV\\SQL0;Database=Back2school;Trusted_Connection=True;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());




            base.OnModelCreating(modelBuilder);
        }
    }
}
