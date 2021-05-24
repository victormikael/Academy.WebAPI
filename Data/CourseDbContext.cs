using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options)
        {
        }
        
        // Mapeando as entidades para tabela
        public DbSet<Course> Courses {get; set;}
    }
}