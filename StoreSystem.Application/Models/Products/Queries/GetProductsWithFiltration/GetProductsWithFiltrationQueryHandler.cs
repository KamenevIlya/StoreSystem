using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Interfaces;
using StoreSystem.Application.Models.Products.Queries.ViewModels;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Products.Queries.GetProductsWithFiltration
{
    public class GetProductsWithFiltrationQueryHandler : IRequestHandler<GetProductsWithFiltrationQuery, ProductsVm>
    {
        private readonly IStoreSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductsWithFiltrationQueryHandler(IStoreSystemDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductsVm> Handle(GetProductsWithFiltrationQuery request, CancellationToken cancellationToken)
        {
            if (request.IsInStock != null)
            {
                if (request.ProductTypeId != null)
                {
                    if (request.Price != null)
                    {
                        var productsQuery = await _dbContext.Products
                            .Where(product => product.Quantity >= 0 && product.Type.Id == request.ProductTypeId)
                            .OrderBy(product => product.Price)
                            .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
                        return new() { Products = productsQuery };
                    }
                    else
                    {
                        var productsQuery = await _dbContext.Products
                            .Where(product => product.Quantity >= 0 && product.Type.Id == request.ProductTypeId)
                            .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
                        return new() { Products = productsQuery };
                    }
                }

                if (request.Price != null)
                {
                    var productsQuery = await _dbContext.Products
                        .Where(product => product.Quantity >= 0 && product.Price == request.Price)
                        .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                    return new() { Products = productsQuery };
                }
                else
                {
                    var productsQuery = await _dbContext.Products
                        .Where(product => product.Quantity >= 0)
                        .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                    return new() { Products = productsQuery };
                }
            }

            if (request.ProductTypeId != null)
            {
                if (request.Price != null)
                {
                    var productsQuery = await _dbContext.Products
                        .Where(product => product.Type.Id == request.ProductTypeId && product.Price == request.Price)
                        .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                    return new() { Products = productsQuery };
                }
                else
                {
                    var productsQuery = await _dbContext.Products
                        .Where(product => product.Type.Id == request.ProductTypeId)
                        .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                    return new() { Products = productsQuery };
                }
            }

            if (request.Price != null)
            {
                var productsQuery = await _dbContext.Products
                    .Where(product => product.Price == request.Price)
                    .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return new() { Products = productsQuery };
            }
            else
            {
                var productsQuery = await _dbContext.Products
                    .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return new() { Products = productsQuery };
            }
        }
    }
}
