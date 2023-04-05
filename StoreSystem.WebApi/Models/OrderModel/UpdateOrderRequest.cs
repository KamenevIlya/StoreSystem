using System;
using System.Collections.Generic;
using AutoMapper;
using StoreSystem.Application.Common.Mappings;
using StoreSystem.Application.Models.Orders.Commands.UpdateOrder;
using StoreSystem.Domain;

namespace StoreSystem.WebApi.Models.OrderModel
{
    public class UpdateOrderRequest : IMapWith<UpdateOrderCommand>
    {
        public Guid Id { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderRequest, UpdateOrderCommand>()
                .ForMember(orderCommand => orderCommand.Id,
                    opt => opt.MapFrom(order => order.Id))
                .ForMember(orderCommand => orderCommand.Client,
                    opt => opt.MapFrom(order => order.Client));
        }
    }
}
