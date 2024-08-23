using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models
{
    public class TeacherDbContext : DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }
        public DbSet<Teacher> teachers { get; set; }
        
    }
}
