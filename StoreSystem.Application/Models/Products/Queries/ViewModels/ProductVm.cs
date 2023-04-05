using System;
using AutoMapper;
using StoreSystem.Application.Common.Mappings;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Products.Queries.ViewModels
{
    public class ProductVm : IMapWith<Product>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>()
                .ForMember(productVm => productVm.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Price,
                    opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Type,
                    opt => opt.MapFrom(product => product.Type))
                .ForMember(productVm => productVm.Quantity,
                opt => opt.MapFrom(product => product.Quantity));
        }
    }
}
