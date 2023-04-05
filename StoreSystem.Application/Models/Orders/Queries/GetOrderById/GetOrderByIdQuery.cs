using System;
using MediatR;
using StoreSystem.Application.Models.Orders.Queries.ViewModels;

namespace StoreSystem.Application.Models.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderVm>
    {
        public Guid Id { get; set; }
    }
}
