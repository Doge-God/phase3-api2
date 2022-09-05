using Microsoft.EntityFrameworkCore;
using phase3_api2.Domain.Model;

namespace phase3_api2.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Prod> Prods { get; set; }
    }
}