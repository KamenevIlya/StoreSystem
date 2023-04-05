using System;
using MediatR;

namespace StoreSystem.Application.Models.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
