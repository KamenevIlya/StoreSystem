using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Interfaces;
using StoreSystem.Application.Models.Orders.Queries.ViewModels;

namespace StoreSystem.Application.Models.Orders.Queries.GetOrdersByClientAndDate
{
    public class GetOrdersByClientAndDateQueryHandler : IRequestHandler<GetOrdersByClientAndDateQuery, OrdersVm>
    {
        private readonly IStoreSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersByClientAndDateQueryHandler(IStoreSystemDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrdersVm> Handle(GetOrdersByClientAndDateQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await _dbContext.Orders
                .Where(order => order.Client.Id == request.ClientId
                                && order.CreatedOn >= request.DateFrom
                                && order.CreatedOn <= request.DateTo)
                .OrderByDescending(order => order.CreatedOn)
                .ProjectTo<OrderVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new() { Orders = ordersQuery };
        }
    }
}
