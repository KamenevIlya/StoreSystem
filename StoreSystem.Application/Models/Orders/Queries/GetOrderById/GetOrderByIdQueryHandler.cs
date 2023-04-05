using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Common.Exceptions;
using StoreSystem.Application.Interfaces;
using StoreSystem.Application.Models.Orders.Queries.ViewModels;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderVm>
    {
        private readonly IStoreSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IStoreSystemDbContext dbContext, IMapper mapper) => (_dbContext, _mapper)  = (dbContext, mapper);

        public async Task<OrderVm> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders
                .FirstOrDefaultAsync(order =>
                    order.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderVm>(entity);
        }
    }
}
