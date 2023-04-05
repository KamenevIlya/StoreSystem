using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreSystem.Application.Common.Exceptions;
using StoreSystem.Application.Interfaces;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IStoreSystemDbContext _dbContext;

        public DeleteOrderCommandHandler(IStoreSystemDbContext dbContext)
            => _dbContext = dbContext;

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _dbContext.Orders.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
