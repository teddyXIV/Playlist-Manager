using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class ProjectContext : DbContext
    {
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Item> Items { get; set; }

        public ProjectContext(DbContextOptions options) : base(options) { }
    }
}