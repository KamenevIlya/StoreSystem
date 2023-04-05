using System;
using System.Collections.Generic;
using AutoMapper;
using StoreSystem.Application.Common.Mappings;
using StoreSystem.Application.Models.Orders.Commands.CreateOrder;
using StoreSystem.Domain;

namespace StoreSystem.WebApi.Models.OrderModel
{
    public class CreateOrderRequest : IMapWith<CreateOrderCommand>
    {
        public Guid ClientId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderRequest, CreateOrderCommand>()
                .ForMember(orderCommand => orderCommand.ClientId,
                    opt => opt.MapFrom(request => request.ClientId))
                .ForMember(orderCommand => orderCommand.OrderItems,
                    opt => opt.MapFrom(request => request.OrderItems));
        }
    }
}
