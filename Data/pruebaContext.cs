using prueba.Models;
using Microsoft.EntityFrameworkCore;

namespace prueba.Data
{
    public class pruebaContext : DbContext
    {
        public pruebaContext(DbContextOptions<pruebaContext> options) : base(options){

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}