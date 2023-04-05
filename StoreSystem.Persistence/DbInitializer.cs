using System;
using StoreSystem.Domain;

namespace StoreSystem.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(StoreSystemDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            FillDatabaseForTest(context);
        }

        private static void FillDatabaseForTest(StoreSystemDbContext context)
        {
            var productType = new ProductType { Id = new("1f24c1d3-68ee-48c4-80f3-d54c15dc50bc"), Name = "Dairy" };
            context.ProductTypes.Add(productType);
            var client1 = new Client { Id = new("6cc22a4d-026a-480b-bec2-81ab48e192f6"), PhoneNumber = "88005553535", FullName = "Abubakar Abdul" };
            context.Clients.Add(client1);
            var product1 = new Product { Id = new("1c0d2798-5167-4a65-bd73-c82947264252"), Name = "Milk", Price = 70, Quantity = 10, ProductTypeId = productType.Id };
            context.Products.Add(product1);
            var product2 = new Product { Id = new("2a135baa-4014-471f-ac4a-3783f08ac714"), Name = "Milk", Price = 80, Quantity = 10, ProductTypeId = productType.Id };
            context.Products.Add(product2);
            var order1 = new Order { Id = new("725804bc-3cf2-4423-be83-5e8a0fa51ddc"), CreatedOn = DateTime.Now, ClientId = client1.Id };
            context.Orders.Add(order1);
            context.OrderItems.Add(new() { Id = new("f87bfec8-0816-4381-83c7-d15635b83541"), Quantity = 1, Price = 70, ProductId = product1.Id, OrderId = order1.Id });
            context.SaveChanges();
        }
    }
}
