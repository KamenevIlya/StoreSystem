using System;

namespace StoreSystem.Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProductTypeId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ProductType Type { get; set; }
    }
}
