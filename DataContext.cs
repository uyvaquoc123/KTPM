using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        



        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Rank> Ranks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.DepartmentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Rank)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.RankId);


            base.OnModelCreating(modelBuilder);
        }


    }
}