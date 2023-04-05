using System;
using MediatR;
using StoreSystem.Application.Models.Orders.Queries.ViewModels;

namespace StoreSystem.Application.Models.Orders.Queries.GetOrdersByClientAndDate
{
    public class GetOrdersByClientAndDateQuery : IRequest<OrdersVm>
    {
        public Guid ClientId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
