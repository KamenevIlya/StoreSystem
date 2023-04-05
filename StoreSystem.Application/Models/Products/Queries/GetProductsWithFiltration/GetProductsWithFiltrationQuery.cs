using System;
using MediatR;
using StoreSystem.Application.Models.Products.Queries.ViewModels;

namespace StoreSystem.Application.Models.Products.Queries.GetProductsWithFiltration
{
    public class GetProductsWithFiltrationQuery : IRequest<ProductsVm>
    {
        public Guid? ProductTypeId { get; set; }

        public decimal? Price { get; set; }

        public bool? IsInStock { get; set; }
    }
}
