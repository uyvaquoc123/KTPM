using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        



        public DbSet<Student> Students { get; set; }



    }
}