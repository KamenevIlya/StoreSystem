using System;
using AutoMapper;
using StoreSystem.Application.Common.Mappings;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Queries.ViewModels
{
    public class OrderVm : IMapWith<Order>
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderVm>()
                .ForMember(orderVm => orderVm.ClientId,
                    opt => opt.MapFrom(order => order.ClientId))
                .ForMember(orderVm => orderVm.CreatedOn,
                    opt => opt.MapFrom(order => order.CreatedOn))
                .ForMember(orderVm => orderVm.Id,
                    opt => opt.MapFrom(order => order.Id));
        }
    }
}
