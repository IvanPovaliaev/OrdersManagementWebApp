using Microsoft.EntityFrameworkCore;
using OrdersManagement.Domain.Entities;

namespace OrdersManagement.Infrastructure.Persistence
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                        .Property(p => p.Weight)
                        .HasPrecision(18, 2);
        }
    }
}
