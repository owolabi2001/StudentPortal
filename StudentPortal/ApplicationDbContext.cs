using Microsoft.EntityFrameworkCore;
using StudentPortal.Model;

namespace StudentPortal
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Result> Results { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().
                HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>().
                HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses).HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentCourses).HasForeignKey(s => s.CourseId);
        }
    }
}
