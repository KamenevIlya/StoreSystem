﻿using System;

namespace StoreSystem.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
