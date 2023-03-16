using Microsoft.EntityFrameworkCore;

namespace DTO.Entity
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
