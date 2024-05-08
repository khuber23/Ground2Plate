using Ground2Plate.Models;
using Microsoft.EntityFrameworkCore;

namespace Ground2Plate.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;

    }
}
