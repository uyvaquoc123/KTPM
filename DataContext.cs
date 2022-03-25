using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        



        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }


    }
}