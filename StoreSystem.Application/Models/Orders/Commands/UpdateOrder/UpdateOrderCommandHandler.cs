using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Common.Exceptions;
using StoreSystem.Application.Interfaces;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IStoreSystemDbContext _dbContext;

        public UpdateOrderCommandHandler(IStoreSystemDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            entity.Client = request.Client;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
