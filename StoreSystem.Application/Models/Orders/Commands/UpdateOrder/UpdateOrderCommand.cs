using System;
using MediatR;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }

        public Client Client { get; set; }
    }
}
