using System;
using System.Collections.Generic;

namespace StoreSystem.Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
            
        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
