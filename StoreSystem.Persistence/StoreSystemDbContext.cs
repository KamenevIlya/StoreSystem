using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Interfaces;
using StoreSystem.Domain;
using StoreSystem.Persistence.EntityTypeConfigurations;

namespace StoreSystem.Persistence
{
    public sealed class StoreSystemDbContext : DbContext, IStoreSystemDbContext
    {
        public DbSet<Client>Clients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public StoreSystemDbContext(DbContextOptions<StoreSystemDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductTypeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
