using System;
using System.Collections.Generic;
using MediatR;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid ClientId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
