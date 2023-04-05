using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Domain;

namespace StoreSystem.Application.Interfaces
{
    public interface IStoreSystemDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
