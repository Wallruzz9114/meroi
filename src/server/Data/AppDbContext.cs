using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder
                .Entity<UserOrder>()
                .HasKey(uo => new { uo.UserId, uo.OrderId });
        }
    }
}